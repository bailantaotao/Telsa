using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem1 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string MODIFIED = "MODIFIED";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");
        //if (ViewState["dt"] == null)
        //{
        //    setInitial();
        //}


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setInitial();
        }
        //getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        //if (!IsPostBack)
        //{

        //}

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
                if (Convert.ToInt32(yourAssignedValue) < 2)
                {
                    if (ViewState["dt"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["dt"];
                        if (dt.Rows.Count > 0)
                        {

                            TextBox box1 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("TbName");
                            TextBox box2 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("TbGender");
                            TextBox box3 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("TbNation");
                            TextBox box4 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("TbCulture");
                            TextBox box5 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[5].FindControl("TbProfessional");
                            TextBox box6 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[6].FindControl("TbTel");
                            TextBox box7 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[7].FindControl("TbAddress");

                            box1.Text = "";
                            box2.Text = "";
                            box3.Text = "";
                            box4.Text = "";
                            box5.Text = "";
                            box6.Text = "";
                            box7.Text = "";
                        }
                        ViewState["dt"] = dt;
                    }
                }
                else
                {
                    DataTable dt = (DataTable)ViewState["dt"];
                    dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    for (int i = Convert.ToInt32(yourAssignedValue); i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][8] = (i + 1).ToString();
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
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("TbName");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("TbGender");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbNation");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbCulture");
                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("TbProfessional");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("TbTel");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("TbAddress");

                    box1.Text = dt.Rows[i]["TbName"].ToString();
                    box2.Text = dt.Rows[i]["TbGender"].ToString();
                    box3.Text = dt.Rows[i]["TbNation"].ToString();
                    box4.Text = dt.Rows[i]["TbCulture"].ToString();
                    box5.Text = dt.Rows[i]["TbProfessional"].ToString();
                    box6.Text = dt.Rows[i]["TbTel"].ToString();
                    box7.Text = dt.Rows[i]["TbAddress"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("PlanTitle", typeof(string)));
        dt.Columns.Add(new DataColumn("TbName", typeof(string)));
        dt.Columns.Add(new DataColumn("TbGender", typeof(string)));
        dt.Columns.Add(new DataColumn("TbNation", typeof(string)));
        dt.Columns.Add(new DataColumn("TbCulture", typeof(string)));
        dt.Columns.Add(new DataColumn("TbProfessional", typeof(string)));
        dt.Columns.Add(new DataColumn("TbTel", typeof(string)));
        dt.Columns.Add(new DataColumn("TbAddress", typeof(string)));
        dt.Columns.Add(new DataColumn("SN", typeof(string)));

        dr = dt.NewRow();
        dr["PlanTitle"] = "主任";
        dr["TbName"] = string.Empty;
        dr["TbGender"] = string.Empty;
        dr["TbNation"] = string.Empty;
        dr["TbCulture"] = string.Empty;
        dr["TbProfessional"] = string.Empty;
        dr["TbTel"] = string.Empty;
        dr["TbAddress"] = string.Empty;
        dr["SN"] = "1";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["PlanTitle"] = "副主任";
        dr["TbName"] = string.Empty;
        dr["TbGender"] = string.Empty;
        dr["TbNation"] = string.Empty;
        dr["TbCulture"] = string.Empty;
        dr["TbProfessional"] = string.Empty;
        dr["TbTel"] = string.Empty;
        dr["TbAddress"] = string.Empty;
        dr["SN"] = "2";
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

                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("TbName");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("TbGender");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbNation");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbCulture");
                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("TbProfessional");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("TbTel");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("TbAddress");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["SN"] = (i + 1).ToString();
                    drCurrentRow["PlanTitle"] = "成員";
                    dtCurrentTable.Rows[i - 1]["TbName"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["TbGender"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["TbNation"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["TbCulture"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["TbProfessional"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["TbTel"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["TbAddress"] = box7.Text;

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
        Response.Redirect("PlanMain.aspx");
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
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool flag = false;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[1].FindControl("TbName")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[3].FindControl("TbNation")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[4].FindControl("TbCulture")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[5].FindControl("TbProfessional")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[6].FindControl("TbTel")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[7].FindControl("TbAddress")).Text);
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
                string query = "delete from PlanMember where SN ='" + Session["UserPlanListSN"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into PlanMember (SN, PlanTitle, PlanName, PlanGender, PlanEthnic, PlanCulture, PlanProfession, PlanTel, PlanAddress, PlanNO) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    dt.Rows[i][0].ToString() + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("TbName")).Text + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).Text + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("TbNation")).Text + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[4].FindControl("TbCulture")).Text + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("TbProfessional")).Text + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("TbTel")).Text + "','" +
                                    ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("TbAddress")).Text + "','"+
                                    dt.Rows[i][8].ToString() + "')";

                    ms.WriteData(query, sb);
                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanList.aspx';", true);
            }
        }
    }
}