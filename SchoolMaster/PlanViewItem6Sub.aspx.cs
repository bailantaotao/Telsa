using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem6Sub : System.Web.UI.Page
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
        
        LbYear.Text = Session["PlanYear"].ToString();
        if (!IsPostBack)
        {
            setInitial();
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
        //StringBuilder sb = new StringBuilder();
        //ManageSQL ms = new ManageSQL();
        //string query = "select PlanList.PlanSemester from PlanList " +
        //               "left join PlanListUser on PlanListUser.PlanListSN = PlanList.SN " +
        //               "where PlanListUser.SN='" + Session["UserPlanListSN"].ToString() + "'";
        //ms.GetOneData(query, sb);
        //LbSemster.Text = sb.ToString();
        //LbSemster.Text = "学期: " + Session["Semester"].ToString();
    }

    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Name, Gender, Nation, Profession, Advantage, Problem, DevelopOpportunity, Challenge " +
                       "from PlanMasterWork " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                       "TitleIsSM = '" + schoolMasterTitle.ToString() + "'";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            LbName.Text = (d[0].Equals(Resources.Resource.TipPlzChoose) || d[0].Equals("")) ? Resources.Resource.TipNotWrite : d[0];
            LbGender.Text = (d[1].Equals(Resources.Resource.TipPlzChoose) || d[1].Equals("")) ? Resources.Resource.TipNotWrite : d[1];
            LbNation.Text = (d[2].Equals(Resources.Resource.TipPlzChoose) || d[2].Equals("")) ? Resources.Resource.TipNotWrite : d[2];
            LbProfession.Text = (d[3].Equals(Resources.Resource.TipPlzChoose) || d[3].Equals("")) ? Resources.Resource.TipNotWrite : d[3];
            LbAdvantage.Text = (d[4].Equals(Resources.Resource.TipPlzChoose) || d[4].Equals("")) ? Resources.Resource.TipNotWrite : d[4];
            LbProblem.Text = (d[5].Equals(Resources.Resource.TipPlzChoose) || d[5].Equals("")) ? Resources.Resource.TipNotWrite : d[5];
            LbOpportunity.Text = (d[6].Equals(Resources.Resource.TipPlzChoose) || d[6].Equals("")) ? Resources.Resource.TipNotWrite : d[6];
            LbChallenge.Text = (d[7].Equals(Resources.Resource.TipPlzChoose) || d[7].Equals("")) ? Resources.Resource.TipNotWrite : d[7];
        }
        

        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("column1", typeof(string)));
        dt.Columns.Add(new DataColumn("column2", typeof(string)));
        dt.Columns.Add(new DataColumn("column3", typeof(string)));
        dt.Columns.Add(new DataColumn("column4", typeof(string)));
        dt.Columns.Add(new DataColumn("column5", typeof(string)));
        dt.Columns.Add(new DataColumn("column6", typeof(string)));
        data.Clear();
        query = "select NO, Target, Activity, StartTime, EndTime, FinishRate, Condition " +
                        "from PlanMasterWorkList " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                        "TitleIsSM = '" + schoolMasterTitle.ToString() + "' " +
                        "order by No asc ";

        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            dr["column1"] = d[1];
            dr["column2"] = d[2];
            dr["column3"] = d[3].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[3].Split(' ')[0];
            dr["column4"] = d[4].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[4].Split(' ')[0];
            dr["column5"] = d[5];
            dr["column6"] = d[6];
            dt.Rows.Add(dr);
        }
        
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString());
    }
}