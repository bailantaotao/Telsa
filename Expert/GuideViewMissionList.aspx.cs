using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideViewMissionList : System.Web.UI.Page
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
        Province,
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            HyperLink1.Visible = false;
            img.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            if (!IsPostBack)
            {
                setInitial();
            }
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            if (!IsPostBack)
            {
                setInitial_MingDer();
            }
        }
    }
    private string SearchProvince()
    {
        string query = "select zipcode.name from zipcode where zipcode.zipcode='" + Session["Province"].ToString() + "'";
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ms.GetOneData(query, sb);
        return string.IsNullOrEmpty(sb.ToString()) ? "none" : sb.ToString();
    }
    protected void btn_View(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;
                Response.Redirect("GuideViewMission.aspx?MissionNO=" + (Convert.ToInt32(yourAssignedValue) + 1));
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
        dt.Columns.Add(new DataColumn("MissionListName", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListYear", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListSemester", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListNo", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MissionName, Year, Semester, No " +
                       "from GuideMissionList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["MissionListName"] = d[0];
                dr["MissionListYear"] = d[1];
                dr["MissionListSemester"] = d[2];
                dr["MissionListNo"] = d[3];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvMissionList.DataSource = dt;
            GvMissionList.DataBind();
            return;
        }

        /*dr = dt.NewRow();
        dr["MissionListName"] = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";
        dr["MissionListYear"] = "2014";
        dr["MissionListSemester"] = "1";
        dr["MissionListNo"] = "1";
        dt.Rows.Add(dr);*/



        ViewState["dt"] = dt;

        GvMissionList.DataSource = dt;
        GvMissionList.DataBind();

        return;
    }
    private void setInitial_MingDer()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("MissionListName", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListYear", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListSemester", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListNo", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MissionName, Year, Semester, No " +
                       "from GuideMissionList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["MissionListName"] = d[0];
                dr["MissionListYear"] = d[1];
                dr["MissionListSemester"] = d[2];
                dr["MissionListNo"] = d[3];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvMissionList.DataSource = dt;
            GvMissionList.DataBind();
            return;
        }

        /*dr = dt.NewRow();
        dr["MissionListName"] = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";
        dr["MissionListYear"] = "2014";
        dr["MissionListSemester"] = "1";
        dr["MissionListNo"] = "1";
        dt.Rows.Add(dr);*/



        ViewState["dt"] = dt;

        GvMissionList.DataSource = dt;
        GvMissionList.DataBind();

        return;
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("GuideViewList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("GuideViewList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString() + "&SCHOOLNAME=" + Session["SCHOOLNAME"].ToString());
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