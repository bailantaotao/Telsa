using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideActivityList : System.Web.UI.Page
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

    private enum DdlType
    {
        SchoolName,
    }
    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.SchoolName:
                setSchoolName();
                break;
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        BtnCancel.Text = "返回";
        BtnStore.Visible = false;
        setDefault(DdlType.SchoolName);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            setInitial();
        }
        
    }

    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ArrayList zipcode = new ArrayList();

        
        Query = "select School from Account " +
                            "left join Area on Account.zipcode = Area.ID " +
                            "where School not like N'%專家%' and School not like N'%管理者%' and Area.ID =" + Session["Province"].ToString() +
                            "group by School ";


        if (!ms.GetAllColumnData(Query, data))
        {
            DlGuideTargetSchool.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlGuideTargetSchool.Items.Add("None");
            return;
        }
        DlGuideTargetSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DlGuideTargetSchool.Items.Add(province[0]);
        }
    }
    protected void btn_View(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                storeData();
                String yourAssignedValue = ((Button)sender).CommandArgument;

                string query = "select TargetSchool, Year, Semester " +
                       "from GuideActivityRecordList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and ActivityNo=" + (Convert.ToInt32(yourAssignedValue) + 1) ;
                ms.GetAllColumnData(query, data);

                if (data.Count > 0)
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        string[] d = (string[])data[i];
                        Session["ActivityTargetSchool"] = d[0];
                        Session["ActivityYear"] = d[1];
                        Session["ActivitySemester"] = d[2];
                    }
                }

                Response.Redirect("GuideActivity.aspx?ActivityNO=" + (Convert.ToInt32(yourAssignedValue) + 1));
            }
            catch
            {
                //Check for exception
            }
        }
    }
    protected void btn_Delete(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        StringBuilder sbmember = new StringBuilder();
        string query = string.Empty;
        string querymember = string.Empty;

        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;
                   
                storeData();
                DataTable dt = (DataTable)ViewState["dt"];
                dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                for (int i = Convert.ToInt32(yourAssignedValue); i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][1] = (i + 1).ToString();
                }
                ViewState["dt"] = dt;
                GvActivityList.DataSource = dt;
                GvActivityList.DataBind();
                SetPreviousData();

                storeData();

                query = "delete from GuideActivity where SN='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and ActivityNo=" + (Convert.ToInt32(yourAssignedValue)+1);
                ms.WriteData(query, sb);

                querymember = "delete from GuideActivityMember where SN='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and ActivityNo=" + (Convert.ToInt32(yourAssignedValue) + 1);
                ms.WriteData(querymember, sbmember);
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
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rowIndex++;
                }
            }
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("TargetShl", typeof(string)));
        dt.Columns.Add(new DataColumn("ShlYear", typeof(string)));
        dt.Columns.Add(new DataColumn("ShlSemester", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select TargetSchool, Year, Semester " +
                       "from GuideActivityRecordList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["TargetShl"] = d[0];
                dr["ShlYear"] = d[1];
                dr["ShlSemester"] = d[2];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvActivityList.DataSource = dt;
            GvActivityList.DataBind();
            return;
        }

        /*dr = dt.NewRow();
        dr["TargetShl"] = "明德小学";
        dr["ShlYear"] = "2014";
        dr["ShlSemester"] = "1";
        dt.Rows.Add(dr);*/

        ViewState["dt"] = dt;

        GvActivityList.DataSource = dt;
        GvActivityList.DataBind();
        return;
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select TargetSchool, Year, Semester " +
                       "from GuideActivityRecordList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);

        if (DlGuideTargetSchool.SelectedValue.ToString().Equals("学校名称"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
            return;
        }

        if (data.Count == 0)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("TargetShl", typeof(string)));
            dt.Columns.Add(new DataColumn("ShlYear", typeof(string)));
            dt.Columns.Add(new DataColumn("ShlSemester", typeof(string)));

            dr = dt.NewRow();
            dr["TargetShl"] = DlGuideTargetSchool.SelectedValue;
            dr["ShlYear"] = DlListYear.SelectedValue;
            dr["ShlSemester"] = DlAddListSemester.SelectedValue;
            dt.Rows.Add(dr);

            ViewState["dt"] = dt;

            GvActivityList.DataSource = dt;
            GvActivityList.DataBind();

            return;
        }

        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["dt"];
            DataRow drCurrentRow = null ;
            if (dtCurrentTable.Rows.Count > 0 )
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["TargetShl"] = DlGuideTargetSchool.SelectedValue;
                    drCurrentRow["ShlYear"] = DlListYear.SelectedValue;
                    drCurrentRow["ShlSemester"] = DlAddListSemester.SelectedValue;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dt"] = dtCurrentTable;

                GvActivityList.DataSource = dtCurrentTable;
                GvActivityList.DataBind();
            }

            Session["ActivityTargetSchool"] = DlGuideTargetSchool.SelectedValue.ToString();
            Session["ActivityYear"] = DlListYear.SelectedValue.ToString();
            Session["ActivitySemester"] = DlAddListSemester.SelectedValue.ToString();

            SetPreviousData();
            storeData();
            //TbListName.Text = "";
            //String yourAssignedValue = ((Button)sender).CommandArgument;
            Response.Redirect("GuideActivity.aspx?ActivityNO=" + (data.Count+1));
            //Response.Redirect("GuideActivity.aspx");
        }

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
            storeData();
    }

    private bool haveEmptyData()
    {
        return false;
    }
    
    private void storeData()
    {
        if (ViewState["dt"] != null)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count >= 0)
            {  
                ManageSQL ms = new ManageSQL();
                // 先刪除原本的
                string query = "delete from GuideActivityRecordList where SN ='" + Session["UserGuideListSN"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into GuideActivityRecordList (SN, TargetSchool, Year, Semester, ActivityNo) VALUES ('" +
                                    Session["UserGuideListSN"].ToString() + "',N'" +
                                    dt.Rows[i][0].ToString() + "',N'" +
                                    dt.Rows[i][1].ToString() + "',N'" +
                                    dt.Rows[i][2].ToString() + "',N'" +
                                    (i+1) + "')";

                    ms.WriteData(query, sb);

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " ", true);

            }
        }
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("../ProvinceIndex.aspx");
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("../MingdeIndex.aspx");
        }
    }
}