using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SurveyViewList : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string DEADLINE = "DEADLINE";
    private const string MODIFIED = "MODIFIED";
    private const string SCHOOLNAME = "SCHOOLNAME";


    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    
    protected void Page_Init(object sender, EventArgs e)
    {
        getSchoolName(schoolName);

        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();

        string query = string.Empty;
        string query1 = string.Empty;
        string query2 = string.Empty;
        string query3 = string.Empty;

        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");
        if (Session["SurveySN"] != null)
            Session.Remove("SurveySN");
        if (Session["SurveyYear"] != null)
            Session.Remove("SurveyYear");

    }
    private string getSchoolID()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select userid from account where School = N'" + Request["schoolName"].ToString() + "'";
        if (ms.GetOneData(query, sb))
        {
            return sb.ToString();
        }
        return string.Empty;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);

        if (!IsPostBack)
        {

        }
        ManageSQL ms = new ManageSQL();
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();

        string query1 = string.Empty;
        string query = string.Empty;


        query = "select Deadline from SurveyList where SN=" + Request["SN"].ToString();
        ms.GetOneData(query, sb1);

        LbSurveyYear.Text = Request["YEAR"].ToString();
        LbSurveySchool.Text = Request["schoolName"].ToString();
        LbSurveySchoolID.Text = getSchoolID();
        LbDeadline.Text = sb1.ToString().Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : sb1.ToString().Split(' ')[0];
        query1 = "select SurveyStatus from SurveyListUser where SurveyYear=" + Request["YEAR"].ToString() + " and SurveySchool= N'" + Request["schoolName"].ToString() + "'";
        ms.GetOneData(query1, sb2);

        if (sb2.ToString() == "True")
        {
            LbSurveyStatus.Text = "已完成";
        }
        if (sb2.ToString() == "False")
        {
            LbSurveyStatus.Text += "未完成";
        }
        Session["SurveyYear"] = LbSurveyYear.Text;
        Session["schoolName"] = LbSurveySchool.Text;
        Session["SurveySN"] = Request["SN"].ToString();
    }
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        Session["schoolName"] = sb.ToString();
        return true;
    }
    
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SurveyViewPreList.aspx");
    }
}