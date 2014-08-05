using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem5 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    


    private StringBuilder schoolName = new StringBuilder();

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
        LbNO.Text = Session["Semester"].ToString();
        if (!IsPostBack)
        {
            setInitial();
        }

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

                            //TextBox box1 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[0].FindControl("column1");
                            TextBox box2 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("column2");
                            TextBox box3 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("column3");
                            TextBox box4 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("column4");
                            DropDownList box5 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("column5");
                            DropDownList box6 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[5].FindControl("column6");
                            DropDownList box7 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[6].FindControl("column7");
                            TextBox box8 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[7].FindControl("column8");

                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("column2")).Attributes.Add("readonly", "true");
                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");

                            //box1.Text = "";
                            box2.Text = "";
                            box3.Text = "";
                            box4.Text = "";
                            box5.SelectedIndex = 0;
                            box6.SelectedIndex = 0;
                            box7.SelectedIndex = 0;
                            box8.Text = "";

                            dt.Rows[Convert.ToInt32(yourAssignedValue)][1] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][2] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][3] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][4] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][5] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][6] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][7] = "";

                            ((Button)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[8].FindControl("lbnView")).Text = "清空";
                        }
                        ViewState["dt"] = dt;
                        GvSchool.DataSource = dt;
                        GvSchool.DataBind();
                        SetPreviousData();
                    }
                }
                else
                {
                    DataTable dt = (DataTable)ViewState["dt"];
                    dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SN"] = (i + 1).ToString();
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
                    //TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("column1");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4");
                    DropDownList box5 = (DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    DropDownList box6 = (DropDownList)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");
                    DropDownList box7 = (DropDownList)GvSchool.Rows[rowIndex].Cells[6].FindControl("column7");
                    TextBox box8 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("column8");

                    ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");


                    //box1.Text = dt.Rows[i]["column1"].ToString();
                    box2.Text = dt.Rows[i]["column2"].ToString();
                    box3.Text = dt.Rows[i]["column3"].ToString();
                    box4.Text = dt.Rows[i]["column4"].ToString();
                    box5.SelectedValue = dt.Rows[i]["column5"].ToString();
                    box6.SelectedValue = dt.Rows[i]["column6"].ToString();
                    box7.SelectedValue = dt.Rows[i]["column7"].ToString();
                    box8.Text = dt.Rows[i]["column8"].ToString();
                    if (i < 1)
                    {
                        ((Button)GvSchool.Rows[i].Cells[8].FindControl("lbnView")).Text = "清空";
                    }
                    rowIndex++;
                }
            }
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SN", typeof(string)));
        dt.Columns.Add(new DataColumn("column2", typeof(string)));
        dt.Columns.Add(new DataColumn("column3", typeof(string)));
        dt.Columns.Add(new DataColumn("column4", typeof(string)));
        dt.Columns.Add(new DataColumn("column5", typeof(string)));
        dt.Columns.Add(new DataColumn("column6", typeof(string)));
        dt.Columns.Add(new DataColumn("column7", typeof(string)));
        dt.Columns.Add(new DataColumn("column8", typeof(string)));
        dt.Columns.Add(new DataColumn("btnClear", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select WeekNO, StartTime, EndTime, WorkContent, Leader, PersonInCharge, FinishRate, EstimateContidion " +
                        "from PlanCalendar " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' order by WeekNo asc ";

        ms.GetAllColumnData(query, data);

        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["SN"] = d[0];
                dr["column2"] = d[1];
                dr["column3"] = d[2];
                dr["column4"] = d[3];
                dr["column5"] = d[4];
                dr["column6"] = d[5];
                dr["column7"] = d[6];
                dr["column8"] = d[7];
                dr["btnClear"] = "清空";
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text = d[1];
                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text = d[2];
                ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text = d[3];
                ((DropDownList)GvSchool.Rows[i].Cells[4].FindControl("column5")).Text = d[4];
                ((DropDownList)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text = d[5];
                ((DropDownList)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text = d[6];
                ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text = d[7];

                ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Attributes.Add("readonly", "true");
                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                if (i < 1)
                {
                    ((Button)GvSchool.Rows[i].Cells[8].FindControl("lbnView")).Text = "清空";
                }
            }

            return;
        }

        dr = dt.NewRow();
        dr["SN"] = "1";
        dr["column2"] = string.Empty;
        dr["column3"] = string.Empty;
        dr["column4"] = string.Empty;
        dr["column5"] = string.Empty;
        dr["column6"] = string.Empty;
        dr["column7"] = string.Empty;
        dr["column8"] = string.Empty;
        dr["btnClear"] = "清空";
        dt.Rows.Add(dr);
        
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();

        ((TextBox)GvSchool.Rows[0].Cells[1].FindControl("column2")).Attributes.Add("readonly", "true");
        ((TextBox)GvSchool.Rows[0].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
        ((Button)GvSchool.Rows[0].Cells[8].FindControl("lbnView")).Text = "清空";
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
                    //TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("column1");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4");
                    DropDownList box5 = (DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    DropDownList box6 = (DropDownList)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");
                    DropDownList box7 = (DropDownList)GvSchool.Rows[rowIndex].Cells[6].FindControl("column7");
                    TextBox box8 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("column8");

                    ((TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["SN"] = (i + 1);

                    //dtCurrentTable.Rows[i - 1]["column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["column4"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["column5"] = box5.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["column6"] = box6.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["column7"] = box7.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["column8"] = box8.Text;

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
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text);
                    //if (flag)
                    //    return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[4].FindControl("column5")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text);
                    if (flag)
                        return true;
                }
                return false;
            }
        }
        return false;
    }
    private bool isEmpty(string data)
    {
        if (string.IsNullOrEmpty(data))
            return true;
        return false;
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
                string query = "delete from PlanCalendar where SN ='" + Session["UserPlanListSN"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into PlanCalendar (SN, WeekNO, StartTime, EndTime, WorkContent, Leader, PersonInCharge, FinishRate, EstimateContidion) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    (i+1).ToString() + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text.Split(' ')[0] + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text.Split(' ')[0] + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[4].FindControl("column5")).SelectedValue + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[5].FindControl("column6")).SelectedValue + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[6].FindControl("column7")).SelectedValue + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text + "')";

                    ms.WriteData(query, sb);
                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
            }
        }
    }
}