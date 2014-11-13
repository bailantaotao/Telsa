using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_GuideViewSDPEvaluateResult : System.Web.UI.Page
{
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string TargetSchool = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList dataschoolname = new ArrayList();

        string queryschoolname = "select School from Account where UserID = '" + Session["UserID"].ToString() + "'";
        ms.GetAllColumnData(queryschoolname, dataschoolname);

        if (dataschoolname.Count != 0)
        {
            string[] s = (string[])dataschoolname[0];
            LbGuideViewResultTargetSchool.Text += s[0];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);
        
        if (!IsPostBack)
        {
            //LbGuideViewResultTargetSchool.Text += Session["schoolName"];
            /*ManageSQL ms = new ManageSQL();
            ArrayList dataschoolname = new ArrayList();

            string queryschoolname = "select TargetSchool from GuideExpertScore where TargetSchool = N'" + Session["schoolName"].ToString() + "'";
            ms.GetAllColumnData(queryschoolname, dataschoolname);

            if (dataschoolname.Count != 0)
            {
                string[] s = (string[])dataschoolname[0];
                LbGuideViewResultTargetSchool.Text += s[0];
            }*/
        }
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
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideViewSDPEvaluateResult.aspx");
    }
    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ArrayList data1 = new ArrayList();

        string query = "select Year, Semester, School, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
               "from GuideExpertScore " +
               "where School = N'" + Session["schoolName"].ToString() + "'" +
               "and Year =" + DlGuideViewResultYear.SelectedValue.ToString() +
               "and Semester =" + DlGuideViewResultSemester.SelectedValue.ToString();

        ms.GetAllColumnData(query, data);
        if (data.Count == 0)
        {
            LbProvinceScore1.Text = null;
            LbProvinceScore2.Text = null;
            LbProvinceScore3.Text = null;
            LbProvinceScore4.Text = null;
            LbProvinceScore5.Text = null;
            LbProvinceScore6.Text = null;
            LbProvinceScore7.Text = null;
            LbProvinceScore8.Text = null;
            LbProvinceScore9.Text = null;
            LbProvinceScore10.Text = null;
            LbProvinceScore11.Text = null;
            LbProvinceScore12.Text = null;
            LbProvinceScoreLevel.Text = null;
            LbScoreLevelExpert.Text = null;
        }
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            //LbGuideViewResultYear.Text = d[0];
            //LbGuideViewResultSemester.Text = d[1];
            //LbGuideViewResultTargetSchool.Text = d[2];
            LbProvinceScore1.Text = d[3];
            LbProvinceScore2.Text = d[4];
            LbProvinceScore3.Text = d[5];
            LbProvinceScore4.Text = d[6];
            LbProvinceScore5.Text = d[7];
            LbProvinceScore6.Text = d[8];
            LbProvinceScore7.Text = d[9];
            LbProvinceScore8.Text = d[10];
            LbProvinceScore9.Text = d[11];
            LbProvinceScore10.Text = d[12];
            LbProvinceScore11.Text = d[13];
            LbProvinceScore12.Text = d[14];
            LbProvinceScoreLevel.Text = d[15];
            LbScoreLevelExpert.Text = d[16];
        }

        string query1 = "select Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
               "from GuideSchoolMasterScore " +
               "where TargetSchool = N'" + Session["schoolName"].ToString() + "'" +
               "and Year =" + DlGuideViewResultYear.SelectedValue.ToString() +
               "and Semester =" + DlGuideViewResultSemester.SelectedValue.ToString();
        ms.GetAllColumnData(query1, data1);
        if (data1.Count == 0)
        {
            LbShlScore1.Text = null;
            LbShlScore2.Text = null;
            LbShlScore3.Text = null;
            LbShlScore4.Text = null;
            LbShlScore5.Text = null;
            LbShlScore6.Text = null;
            LbShlScore7.Text = null;
            LbShlScore8.Text = null;
            LbShlScore9.Text = null;
            LbShlScore10.Text = null;
            LbShlScore11.Text = null;
            LbShlScore12.Text = null;
            LbShlScoreLevel.Text = null;
            LbScoreLevelSchool.Text = null;
        }
        if (data1.Count > 0)
        {
            string[] d1 = (string[])data1[0];
            LbShlScore1.Text = d1[0];
            LbShlScore2.Text = d1[1];
            LbShlScore3.Text = d1[2];
            LbShlScore4.Text = d1[3];
            LbShlScore5.Text = d1[4];
            LbShlScore6.Text = d1[5];
            LbShlScore7.Text = d1[6];
            LbShlScore8.Text = d1[7];
            LbShlScore9.Text = d1[8];
            LbShlScore10.Text = d1[9];
            LbShlScore11.Text = d1[10];
            LbShlScore12.Text = d1[11];
            LbShlScoreLevel.Text = d1[12];
            LbScoreLevelSchool.Text = d1[13];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            setInitial();
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}