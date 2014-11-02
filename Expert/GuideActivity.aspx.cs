using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideActivity : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string NO = string.Empty;
    private string DimensionsID = string.Empty;
    
    private StringBuilder GuideName = new StringBuilder();
    private StringBuilder GuideActivityNO = new StringBuilder();

    private const string SCHOOLNAME = "SCHOOLNAME";

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        SchoolName,
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");
        
        /*if (Session["ActivityYear"] == null || Session["ActivitySemester"] == null || Session["ActivityTargetSchool"] == null)
        {
            ManageSQL ms = new ManageSQL();
            ArrayList data = new ArrayList();
            string query = "select Year, Semester, TargetSchool" +
                   "from GuideActivityRecordList " +
                   "where SN ='" + Session["UserGuideListSN"].ToString() + "' and " +
                   "ActivityNO = '" + Request["ActivityNo"] + "'";

            ms.GetAllColumnData(query, data);
            if (data.Count > 0)
            {
                string[] d = (string[])data[0];
                LbYear.Text += d[0];
                LbSemester.Text += d[1];
                LbTargetSchool.Text += d[2];
            }
        }*/
        //else
        //{
            LbYear.Text = Session["ActivityYear"].ToString();
            LbSemester.Text = Session["ActivitySemester"].ToString();
            LbTargetSchool.Text = Session["ActivityTargetSchool"].ToString();
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //setDefault(DdlType.SchoolName);

        if (Request["ActivityNO"] == null)
            return;
        if (!parseData("ActivityNO"))
            return;

        getTitle();

        if (!IsPostBack)
        {
            setPersonal();
            setInitial();
        }

        GvSchool.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
    }
    /*private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.SchoolName:
                setSchoolName();
                break;
        }
    }*/
    /*private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select School from Account " +
                            "left join Area on Account.zipcode = Area.ID " +
                            "where School not like N'%專家%' and School not like N'%管理%' and Area.ID =" + Session["Province"].ToString() +
                            "group by School ";


        if (!ms.GetAllColumnData(Query, data))
        {
            DropDownList3.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DropDownList3.Items.Add("None");
            return;
        }
        DropDownList3.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DropDownList3.Items.Add(province[0]);
        }
    }*/
    

    private bool parseData(string tag)
    {
        bool isdigit = false;
        int result = -1;
        isdigit = Int32.TryParse(Request[tag].ToString(), out result);
        return isdigit;
    }
    private void getTitle()
    {
        GuideActivityNO.Clear();
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        string query = "select Area.name from Area where Area.id='" + Session["Province"].ToString()  + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals(""))
            return;
        LbGuideActivity.Text = sb.ToString() + "省跟踪指导专家活动纪录表";
        GuideActivityNO.Append(Request["ActivityNO"].ToString());

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

                            TextBox box1 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[0].FindControl("TbGuideActivityMemberName");
                            DropDownList box2 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("DlGuideActivityGender");
                            TextBox box3 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("TbGuideActivityJob");
                            TextBox box4 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("TbGuideActivityUnit");
                            TextBox box5 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("TbGuideActivityPhone");
                            

                            box1.Text = "";
                            box2.Text = "请选择";
                            box3.Text = "";
                            box4.Text = "";
                            box5.Text = "";

                            dt.Rows[Convert.ToInt32(yourAssignedValue)][0] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][1] = "请选择";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][2] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][3] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][4] = "";
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
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("TbGuideActivityMemberName");
                    DropDownList box2 = (DropDownList)GvSchool.Rows[rowIndex].Cells[1].FindControl("DlGuideActivityGender");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("TbGuideActivityJob");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbGuideActivityUnit");
                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbGuideActivityPhone");

                    box1.Text = dt.Rows[i]["TbGuideActivityMemberName"].ToString();
                    box2.SelectedValue = dt.Rows[i]["DlGuideActivityGender"].ToString();
                    box3.Text = dt.Rows[i]["TbGuideActivityJob"].ToString();
                    box4.Text = dt.Rows[i]["TbGuideActivityUnit"].ToString();
                    box5.Text = dt.Rows[i]["TbGuideActivityPhone"].ToString();
                    if (i < 1)
                    {
                        ((Button)GvSchool.Rows[i].Cells[5].FindControl("lbnView")).Text = "清空";
                    }
                    rowIndex++;
                }
            }
        }
    }
    private void setPersonal()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Year, Semester, TargetSchool, StartTime, EndTime, ActionProcess, DiscussionPoint, Description " +
               "from GuideActivity " +
               "where SN ='" + Session["UserGuideListSN"].ToString() + "' and " +
               "ActivityNO = '" + GuideActivityNO.ToString() + "'";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            //DropDownList1.SelectedValue = d[0];
            //DropDownList2.SelectedValue = d[1];
            //DropDownList3.SelectedValue = d[2];
            TextBox1.Text = d[3];
            TextBox2.Text = d[4];
            TbGuideActivityProgress.Text = d[5];
            TbGuideActivityPoint.Text = d[6];
            TbGuideActivityDescription.Text = d[7];
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("TbGuideActivityMemberName", typeof(string)));
        dt.Columns.Add(new DataColumn("DlGuideActivityGender", typeof(string)));
        dt.Columns.Add(new DataColumn("TbGuideActivityJob", typeof(string)));
        dt.Columns.Add(new DataColumn("TbGuideActivityUnit", typeof(string)));
        dt.Columns.Add(new DataColumn("TbGuideActivityPhone", typeof(string)));
        dt.Columns.Add(new DataColumn("SN", typeof(string)));
        dt.Columns.Add(new DataColumn("btnClear", typeof(string)));
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MemberName, Gender, Job, Unit, Phone " +
                        "from GuideActivityMember " +
                        "where SN ='" + Session["UserGuideListSN"].ToString() + "' and " +
                        "ActivityNO = '" + GuideActivityNO.ToString() + "'";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["TbGuideActivityMemberName"] = d[0];
                dr["DlGuideActivityGender"] = d[1];
                dr["TbGuideActivityJob"] = d[2];
                dr["TbGuideActivityUnit"] = d[3];
                dr["TbGuideActivityPhone"] = d[4];
                dr["btnClear"] = "清空";
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("TbGuideActivityMemberName")).Text = d[0];
                ((DropDownList)GvSchool.Rows[i].Cells[1].FindControl("DlGuideActivityGender")).SelectedValue = d[1];
                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("TbGuideActivityJob")).Text = d[2];
                ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("TbGuideActivityUnit")).Text = d[3];
                ((TextBox)GvSchool.Rows[i].Cells[4].FindControl("TbGuideActivityPhone")).Text = d[4];
               
                if (i < 1)
                {
                    ((Button)GvSchool.Rows[i].Cells[5].FindControl("lbnView")).Text = "清空";
                }
            }
            return;
        }



        dr = dt.NewRow();
        dr["TbGuideActivityMemberName"] = string.Empty;
        dr["DlGuideActivityGender"] = string.Empty;
        dr["TbGuideActivityJob"] = string.Empty;
        dr["TbGuideActivityUnit"] = string.Empty;
        dr["TbGuideActivityPhone"] = string.Empty;
        dr["SN"] = "1";
        dr["btnClear"] = "清空";
        dt.Rows.Add(dr);

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();

        ((Button)GvSchool.Rows[0].Cells[5].FindControl("lbnView")).Text = "清空";
    }
    protected void BtnAddMember_Click(object sender, EventArgs e)
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
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("TbGuideActivityMemberName");
                    DropDownList box2 = (DropDownList)GvSchool.Rows[rowIndex].Cells[1].FindControl("DlGuideActivityGender");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("TbGuideActivityJob");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbGuideActivityUnit");
                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbGuideActivityPhone");
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["SN"] = (i + 1).ToString();
                    dtCurrentTable.Rows[i - 1]["TbGuideActivityMemberName"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["DlGuideActivityGender"] = box2.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["TbGuideActivityJob"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["TbGuideActivityUnit"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["TbGuideActivityPhone"] = box5.Text;

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
        Response.Redirect("GuideActivityList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
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
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[0].FindControl("TbGuideActivityMemberName")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[2].FindControl("TbGuideActivityJob")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[3].FindControl("TbGuideActivityUnit")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[4].FindControl("TbGuideActivityPhone")).Text);
                    
                    if (flag)
                        return true;
                }
            }
        }

        if (TextBox1.Text.Trim().Equals(""))
            return true;
        if (TextBox2.Text.Trim().Equals(""))
            return true;
        if (TbGuideActivityProgress.Text.Trim().Equals(""))
            return true;
        if (TbGuideActivityPoint.Text.Trim().Equals(""))
            return true;
        if (TbGuideActivityDescription.Text.Trim().Equals(""))
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
        //string query = "delete from GuideActivity where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        //ms.WriteData(query, sb);
        //sb.Clear();

        string query = "insert into GuideActivity (SN, ActivityNO, Year, Semester, TargetSchool, StartTime, EndTime, ActionProcess, DiscussionPoint, Description) VALUES ('" +
                        Session["UserGuideListSN"].ToString() + "',N'" +
                        GuideActivityNO.ToString() + "',N'" +
                        LbYear.Text + "',N'" +
                        LbSemester.Text + "',N'" +
                        LbTargetSchool.Text + "',N'" +
                        TextBox1.Text + "',N'" +
                        TextBox2.Text + "',N'" +
                        TbGuideActivityProgress.Text.Trim() + "',N'" +
                        TbGuideActivityPoint.Text.Trim() + "',N'" +
                        TbGuideActivityDescription.Text.Trim() + "')";

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
                //string query = "delete from GuideActivityMember where SN ='" + Session["UserGuideListSN"].ToString() + "' and ActivityNO='" + GuideActivityNO.ToString() + "'";
                string query = "delete from GuideActivityMember where SN ='" + Session["UserGuideListSN"].ToString() + "' and ActivityNO='" + Request["ActivityNo"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    if (((TextBox)GvSchool.Rows[i].Cells[0].FindControl("TbGuideActivityMemberName")).Text == "")
                    {
                        break;
                    }
                    else
                    {
                        query = "insert into GuideActivityMember (SN, ActivityNO, MemberName, Gender, Job, Unit, Phone) VALUES ('" +
                                    Session["UserGuideListSN"].ToString() + "',N'" +
                                    Request["ActivityNo"].ToString() + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("TbGuideActivityMemberName")).Text + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[1].FindControl("DlGuideActivityGender")).SelectedValue.ToString() + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("TbGuideActivityJob")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("TbGuideActivityUnit")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[4].FindControl("TbGuideActivityPhone")).Text + "')";

                    }
                    ms.WriteData(query, sb);

                }
                Response.Redirect("GuideActivityList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
            }
        }

    }
}