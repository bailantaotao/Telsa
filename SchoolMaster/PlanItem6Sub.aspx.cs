using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem6Sub : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string NO = string.Empty;
    private string DimensionsID = string.Empty;
    


    private StringBuilder schoolName = new StringBuilder();
    private StringBuilder schoolMasterTitle = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Title"] == null)
            return;
        if (!parseData("Title"))
            return;

        getTitle();
        getSemster();
        if (!IsPostBack)
        {
            setInitial();
        }


    }
    private bool parseData(string tag)
    {
        bool isdigit = false;
        int result = -1;
        isdigit = Int32.TryParse(Request[tag].ToString(), out result);
        return isdigit;
    }

    private void getTitle()
    {
        schoolMasterTitle.Clear();
        if (Request["Title"].ToString().Equals("0"))
        {
            LbTitle.Text = "校长工作行动计划表";
            schoolMasterTitle.Append("1");
        }
        else
        {
            LbTitle.Text = "副校长工作行动计划表";
            schoolMasterTitle.Append("0");
        }
    }

    private void getSemster()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanList.PlanSemester from PlanList " +
                       "left join PlanListUser on PlanListUser.PlanListSN = PlanList.SN " +
                       "where PlanListUser.SN='" + Session["UserPlanListSN"].ToString() + "'";
        ms.GetOneData(query, sb);
        LbSemster.Text = "学期:"+sb.ToString();
    }

    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    protected void btn_Clicked(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;
                if (Convert.ToInt32(yourAssignedValue) < 1)
                {
                    if (ViewState["dt"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["dt"];
                        if (dt.Rows.Count > 0)
                        {

                            TextBox box1 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[0].FindControl("column1");
                            TextBox box2 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("column2");
                            TextBox box3 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("column3");
                            TextBox box4 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("column4");
                            DropDownList box5 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("column5");
                            TextBox box6 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[5].FindControl("column6");

                            box1.Text = "";
                            box2.Text = "";
                            box3.Text = "";
                            box4.Text = "";
                            box5.SelectedIndex = 0;
                            box6.Text = "";
                        }
                    }
                }
                else
                {
                    DataTable dt = (DataTable)ViewState["dt"];
                    dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    for (int i = Convert.ToInt32(yourAssignedValue); i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][7] = (i + 1).ToString();
                    }
                    ViewState["dt"] = dt;
                    GvSchool.DataSource = dt;
                    GvSchool.DataBind();
                    SetPreviousData();
                }
                

            }
            catch
            {
                //Check for exception
            }
        }
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("column1");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4");
                    DropDownList box5 = (DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");

                    box1.Text = dt.Rows[i]["column1"].ToString();
                    box2.Text = dt.Rows[i]["column2"].ToString();
                    box3.Text = dt.Rows[i]["column3"].ToString();
                    box4.Text = dt.Rows[i]["column4"].ToString();
                    box5.SelectedValue = dt.Rows[i]["column5"].ToString();
                    box6.Text = dt.Rows[i]["column6"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("column1", typeof(string)));
        dt.Columns.Add(new DataColumn("column2", typeof(string)));
        dt.Columns.Add(new DataColumn("column3", typeof(string)));
        dt.Columns.Add(new DataColumn("column4", typeof(string)));
        dt.Columns.Add(new DataColumn("column5", typeof(string)));
        dt.Columns.Add(new DataColumn("column6", typeof(string)));
        dt.Columns.Add(new DataColumn("SN", typeof(string)));

        dr = dt.NewRow();
        dr["column1"] = string.Empty;
        dr["column2"] = string.Empty;
        dr["column3"] = string.Empty;
        dr["column4"] = string.Empty;
        dr["column5"] = string.Empty;
        dr["column6"] = string.Empty;
        dr["SN"] = "1";
        dt.Rows.Add(dr);
        
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }


    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["dt"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("column1");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4");
                    DropDownList box5 = (DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["SN"] = (i + 1).ToString();
                    dtCurrentTable.Rows[i - 1]["column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["column4"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["column5"] = box5.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["column6"] = box6.Text;
                    
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dt"] = dtCurrentTable;

                GvSchool.DataSource = dtCurrentTable;
                GvSchool.DataBind();
            }
            SetPreviousData();
        }

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
        else
        {
            storePersonalData();
            storeData();
        }
    }

    private bool haveEmptyData()
    {
        return false;
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool flag = false;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text);
                    if (flag)
                        return true;
                }                
            }
        }
        //if (TbName.Text.Trim().Equals(""))
        //    return true;
        if (TbGender.Text.Trim().Equals(""))
            return true;
        if (TbTitle.Text.Trim().Equals(""))
            return true;
        if (TbAge.Text.Trim().Equals(""))
            return true;
        if (TbAdvantage.Text.Trim().Equals(""))
            return true;
        if (TbChallenge.Text.Trim().Equals(""))
            return true;
        if (TbOpportunity.Text.Trim().Equals(""))
            return true;
        if (TbProblem.Text.Trim().Equals(""))
            return true;

        return false;
    }
    private bool isEmpty(string data)
    {
        if (string.IsNullOrEmpty(data))
            return true;
        return false;
    }
    private void storePersonalData()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "delete from PlanMasterWork where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into PlanMasterWork (SN, TitleIsSM, WorkersID, Name, Gender, Nation, Profession, Advantage, Problem, DevelopOpportunity, Challenge) VALUES ('" +
                        Session["UserPlanListSN"].ToString() + "',N'" +
                        schoolMasterTitle.ToString() + "',N'" +
                        DdlName.SelectedValue + "',N'" +
                        DdlName.SelectedValue + "',N'" +
                        TbGender.Text.Trim() + "',N'" +
                        TbAge.Text.Trim() + "',N'" +
                        TbTitle.Text.Trim() + "',N'" +
                        TbAdvantage.Text.Trim() + "',N'" + 
                        TbProblem.Text.Trim() + "',N'" +
                        TbOpportunity.Text.Trim() + "',N'" +
                        TbChallenge.Text.Trim() + "')";

        ms.WriteData(query, sb);

    }
    private void storeData()
    {
        if (ViewState["dt"] != null)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                ManageSQL ms = new ManageSQL();
                // 先刪除原本的
                string query = "delete from PlanMasterWorkList where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID ='" + DimensionsID + "' and PlanSummaryDimensionsNO='" + NO + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into PlanMasterWorkList (SN, NO, Target, Activity, StartTime, EndTime, FinishRate, Condition, TitleIsSM) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    (i+1).ToString() + "',N'" + 
                                    ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[4].FindControl("column5")).SelectedValue + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text +  "',N'" +
                                    schoolMasterTitle.ToString() + "')";

                    ms.WriteData(query, sb);
                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanList.aspx';", true);
            }
        }

    }
}