using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Expert_GuideViewActivity : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string NO = string.Empty;
    private string DimensionsID = string.Empty;

    private StringBuilder GuideName = new StringBuilder();
    private StringBuilder GuideActivityNO = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;


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
            LbGuideActivity.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["ActivityNO"] == null)
            return;
        if (!parseData("ActivityNO"))
            return;

        getTitle();

        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            if (!IsPostBack)
            {
                setPersonal();
                setInitial();
            }
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            if (!IsPostBack)
            {
                setPersonal_MingDer();
                setInitial_MingDer();
            }
        }
        

        GvSchool.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
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
        GuideActivityNO.Clear();
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        string query = "select Area.name from Area where Area.ID='" + Session["Province"].ToString() + "'";
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

                            Label box1 = (Label)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[0].FindControl("LbGuideViewActivityMemberName");
                            Label box2 = (Label)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("LbGuideViewActivityGender");
                            Label box3 = (Label)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("LbGuideViewActivityJob");
                            Label box4 = (Label)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("LbGuideViewActivityUnit");
                            Label box5 = (Label)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("LbGuideViewActivityPhone");


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
                    Label box1 = (Label)GvSchool.Rows[rowIndex].Cells[0].FindControl("LbGuideViewActivityMemberName");
                    Label box2 = (Label)GvSchool.Rows[rowIndex].Cells[1].FindControl("LbGuideViewActivityGender");
                    Label box3 = (Label)GvSchool.Rows[rowIndex].Cells[2].FindControl("LbGuideViewActivityJob");
                    Label box4 = (Label)GvSchool.Rows[rowIndex].Cells[3].FindControl("LbGuideViewActivityUnit");
                    Label box5 = (Label)GvSchool.Rows[rowIndex].Cells[4].FindControl("LbGuideViewActivityPhone");

                    box1.Text = dt.Rows[i]["LbGuideViewActivityMemberName"].ToString();
                    box2.Text = dt.Rows[i]["LbGuideViewActivityGender"].ToString();
                    box3.Text = dt.Rows[i]["LbGuideViewActivityJob"].ToString();
                    box4.Text = dt.Rows[i]["LbGuideViewActivityUnit"].ToString();
                    box5.Text = dt.Rows[i]["LbGuideViewActivityPhone"].ToString();
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
            LbGuideViewActivityYear.Text = d[0];
            LbGuideViewActivitySemester.Text = d[1];
            LbGuideViewActivityTargetSchool.Text = d[2];
            LbGuideViewActivityStartTime.Text = d[3].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[3].Split(' ')[0];
            LbGuideViewActivityEndTime.Text = d[4].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[4].Split(' ')[0];
            LbGuideViewActivityProgress.Text = d[5];
            LbGuideViewActivityPoint.Text = d[6];
            LbGuideViewActivityDescription.Text = d[7];
        }
    }
    private void setPersonal_MingDer()
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
            LbGuideViewActivityYear.Text = d[0];
            LbGuideViewActivitySemester.Text = d[1];
            LbGuideViewActivityTargetSchool.Text = d[2];
            LbGuideViewActivityStartTime.Text = d[3].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[3].Split(' ')[0];
            LbGuideViewActivityEndTime.Text = d[4].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[4].Split(' ')[0];
            LbGuideViewActivityProgress.Text = d[5];
            LbGuideViewActivityPoint.Text = d[6];
            LbGuideViewActivityDescription.Text = d[7];
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("LbGuideViewActivityMemberName", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityGender", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityJob", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityUnit", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityPhone", typeof(string)));
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
                dr["LbGuideViewActivityMemberName"] = d[0];
                dr["LbGuideViewActivityGender"] = d[1];
                dr["LbGuideViewActivityJob"] = d[2];
                dr["LbGuideViewActivityUnit"] = d[3];
                dr["LbGuideViewActivityPhone"] = d[4];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((Label)GvSchool.Rows[i].Cells[0].FindControl("LbGuideViewActivityMemberName")).Text = d[0];
                ((Label)GvSchool.Rows[i].Cells[1].FindControl("LbGuideViewActivityGender")).Text = d[1];
                ((Label)GvSchool.Rows[i].Cells[2].FindControl("LbGuideViewActivityJob")).Text = d[2];
                ((Label)GvSchool.Rows[i].Cells[3].FindControl("LbGuideViewActivityUnit")).Text = d[3];
                ((Label)GvSchool.Rows[i].Cells[4].FindControl("LbGuideViewActivityPhone")).Text = d[4];

                
            }
            return;
        }



        dr = dt.NewRow();
        dr["LbGuideViewActivityMemberName"] = string.Empty;
        dr["LbGuideViewActivityGender"] = string.Empty;
        dr["LbGuideViewActivityJob"] = string.Empty;
        dr["LbGuideViewActivityUnit"] = string.Empty;
        dr["LbGuideViewActivityPhone"] = string.Empty;
        dr["SN"] = "1";
        dt.Rows.Add(dr);

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();

    }
    private void setInitial_MingDer()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("LbGuideViewActivityMemberName", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityGender", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityJob", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityUnit", typeof(string)));
        dt.Columns.Add(new DataColumn("LbGuideViewActivityPhone", typeof(string)));
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
                dr["LbGuideViewActivityMemberName"] = d[0];
                dr["LbGuideViewActivityGender"] = d[1];
                dr["LbGuideViewActivityJob"] = d[2];
                dr["LbGuideViewActivityUnit"] = d[3];
                dr["LbGuideViewActivityPhone"] = d[4];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((Label)GvSchool.Rows[i].Cells[0].FindControl("LbGuideViewActivityMemberName")).Text = d[0];
                ((Label)GvSchool.Rows[i].Cells[1].FindControl("LbGuideViewActivityGender")).Text = d[1];
                ((Label)GvSchool.Rows[i].Cells[2].FindControl("LbGuideViewActivityJob")).Text = d[2];
                ((Label)GvSchool.Rows[i].Cells[3].FindControl("LbGuideViewActivityUnit")).Text = d[3];
                ((Label)GvSchool.Rows[i].Cells[4].FindControl("LbGuideViewActivityPhone")).Text = d[4];


            }
            return;
        }



        dr = dt.NewRow();
        dr["LbGuideViewActivityMemberName"] = string.Empty;
        dr["LbGuideViewActivityGender"] = string.Empty;
        dr["LbGuideViewActivityJob"] = string.Empty;
        dr["LbGuideViewActivityUnit"] = string.Empty;
        dr["LbGuideViewActivityPhone"] = string.Empty;
        dr["SN"] = "1";
        dt.Rows.Add(dr);

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("GuideViewActivityList.aspx" );
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("GuideViewActivityList.aspx");
        }
        
    }
<<<<<<< HEAD
=======
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
>>>>>>> develop
}