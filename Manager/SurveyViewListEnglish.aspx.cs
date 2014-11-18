using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_SurveyViewListEnglish : System.Web.UI.Page
{
    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;
    private string Q1 = string.Empty;
    private string Q2 = string.Empty;
    private string Q3 = string.Empty;
    private string Q4 = string.Empty;
    private string Q5 = string.Empty;
    private string Q6 = string.Empty;
    private string Q7 = string.Empty;
    private string Q8 = string.Empty;
    private string Q9 = string.Empty;
    private string Q10 = string.Empty;
    private string Q11 = string.Empty;
    int S1 = 0;
    int S2 = 0;
    int S3 = 0;
    int S4 = 0;
    int S5 = 0;
    int S6 = 0;
    int S7 = 0;
    int S8 = 0;
    int S9 = 0;
    int S10 = 0;
    int S11 = 0;
    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string MODIFIED = "MODIFIED";

    private StringBuilder schoolName = new StringBuilder();
    private StringBuilder schoolUser = new StringBuilder();
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");

        LbSurveySchool.Text = Session["schoolName"].ToString();
        LbSurveyUser.Text = getSchoolUser();
        Lbdescription1.Text += "1.敬请针对教材的" + '"' + "电子平台" + "'" + "(PowerPoint教材)﹑" + '"' + "教案" + '"' + "(Word教材)及" + '"' + "契合" + '"' + "依照" + '"' + "评价要点" + '"' + "勾选(✔)" + '"' + "很满意" + '"' + "﹑" + '"' + "满意" + '"' + "﹑" + '"' + "基本满意" + '"' + " ﹑" + '"' + "不满意" + '"' + "或" + '"' + "很不满意" + '"' + "(五选一)，并请提出宝贵建议。 " + '"' + "建议事项" + '"' + "不够填写可另附。";
        TbSurveyYear.Text += DateTime.Now.Year.ToString();
        TbSurveyMonth.Text += DateTime.Now.Month.ToString();
        TbSurveyDay.Text += DateTime.Now.Day.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setInitial();
        }
    }
    private string getSchoolUser()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select username from account where School = N'" + Session["schoolName"].ToString() + "'";
        if (ms.GetOneData(query, sb))
        {
            return sb.ToString();
        }
        return string.Empty;
    }
    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select ListYear, ListMonth, ListDay, Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, SatisfyScore1, SatisfyScore2, SatisfyScore3, Proposal1, Proposal2 from SurveyListEnglish " +
                       "where Year='" + Session["SurveyYear"].ToString() + "'" +
                       "and School = N'" + Session["schoolName"].ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            TbSurveyYear.Text = d[0];
            TbSurveyMonth.Text = d[1];
            TbSurveyDay.Text = d[2];
            if (d[3].ToString() == "1")
            {
                RbQ1O1.Checked = true;
            }
            if (d[3].ToString() == "2")
            {
                RbQ1O2.Checked = true;
            }
            if (d[3].ToString() == "3")
            {
                RbQ1O3.Checked = true;
            }
            if (d[3].ToString() == "4")
            {
                RbQ1O4.Checked = true;
            }
            if (d[3].ToString() == "5")
            {
                RbQ1O5.Checked = true;
            }
            if (d[4].ToString() == "1")
            {
                RbQ2O1.Checked = true;
            }
            if (d[4].ToString() == "2")
            {
                RbQ2O2.Checked = true;
            }
            if (d[4].ToString() == "3")
            {
                RbQ2O3.Checked = true;
            }
            if (d[4].ToString() == "4")
            {
                RbQ2O4.Checked = true;
            }
            if (d[4].ToString() == "5")
            {
                RbQ2O5.Checked = true;
            }
            if (d[5].ToString() == "1")
            {
                RbQ3O1.Checked = true;
            }
            if (d[5].ToString() == "2")
            {
                RbQ3O2.Checked = true;
            }
            if (d[5].ToString() == "3")
            {
                RbQ3O3.Checked = true;
            }
            if (d[5].ToString() == "4")
            {
                RbQ3O4.Checked = true;
            }
            if (d[5].ToString() == "5")
            {
                RbQ3O5.Checked = true;
            }
            if (d[6].ToString() == "1")
            {
                RbQ4O1.Checked = true;
            }
            if (d[6].ToString() == "2")
            {
                RbQ4O2.Checked = true;
            }
            if (d[6].ToString() == "3")
            {
                RbQ4O3.Checked = true;
            }
            if (d[6].ToString() == "4")
            {
                RbQ4O4.Checked = true;
            }
            if (d[6].ToString() == "5")
            {
                RbQ4O5.Checked = true;
            }
            if (d[7].ToString() == "1")
            {
                RbQ5O1.Checked = true;
            }
            if (d[7].ToString() == "2")
            {
                RbQ5O2.Checked = true;
            }
            if (d[7].ToString() == "3")
            {
                RbQ5O3.Checked = true;
            }
            if (d[7].ToString() == "4")
            {
                RbQ5O4.Checked = true;
            }
            if (d[7].ToString() == "5")
            {
                RbQ5O5.Checked = true;
            }
            if (d[8].ToString() == "1")
            {
                RbQ6O1.Checked = true;
            }
            if (d[8].ToString() == "2")
            {
                RbQ6O2.Checked = true;
            }
            if (d[8].ToString() == "3")
            {
                RbQ6O3.Checked = true;
            }
            if (d[8].ToString() == "4")
            {
                RbQ6O4.Checked = true;
            }
            if (d[8].ToString() == "5")
            {
                RbQ6O5.Checked = true;
            }
            if (d[9].ToString() == "1")
            {
                RbQ7O1.Checked = true;
            }
            if (d[9].ToString() == "2")
            {
                RbQ7O2.Checked = true;
            }
            if (d[9].ToString() == "3")
            {
                RbQ7O3.Checked = true;
            }
            if (d[9].ToString() == "4")
            {
                RbQ7O4.Checked = true;
            }
            if (d[9].ToString() == "5")
            {
                RbQ7O5.Checked = true;
            }
            if (d[10].ToString() == "1")
            {
                RbQ8O1.Checked = true;
            }
            if (d[10].ToString() == "2")
            {
                RbQ8O2.Checked = true;
            }
            if (d[10].ToString() == "3")
            {
                RbQ8O3.Checked = true;
            }
            if (d[10].ToString() == "4")
            {
                RbQ8O4.Checked = true;
            }
            if (d[10].ToString() == "5")
            {
                RbQ8O5.Checked = true;
            }
            if (d[11].ToString() == "1")
            {
                RbQ9O1.Checked = true;
            }
            if (d[11].ToString() == "2")
            {
                RbQ9O2.Checked = true;
            }
            if (d[11].ToString() == "3")
            {
                RbQ9O3.Checked = true;
            }
            if (d[11].ToString() == "4")
            {
                RbQ9O4.Checked = true;
            }
            if (d[11].ToString() == "5")
            {
                RbQ9O5.Checked = true;
            }
            if (d[12].ToString() == "1")
            {
                RbQ10O1.Checked = true;
            }
            if (d[12].ToString() == "2")
            {
                RbQ10O2.Checked = true;
            }
            if (d[12].ToString() == "3")
            {
                RbQ10O3.Checked = true;
            }
            if (d[12].ToString() == "4")
            {
                RbQ10O4.Checked = true;
            }
            if (d[12].ToString() == "5")
            {
                RbQ10O5.Checked = true;
            }
            if (d[13].ToString() == "1")
            {
                RbQ11O1.Checked = true;
            }
            if (d[13].ToString() == "2")
            {
                RbQ11O2.Checked = true;
            }
            if (d[13].ToString() == "3")
            {
                RbQ11O3.Checked = true;
            }
            if (d[13].ToString() == "4")
            {
                RbQ11O4.Checked = true;
            }
            if (d[13].ToString() == "5")
            {
                RbQ11O5.Checked = true;
            }
            LbScore1.Text = d[14];
            LbScore2.Text = d[15];
            LbScore3.Text = d[16];
            TbPPT.Text = d[17];
            TbWord.Text = d[18];
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SurveyViewList.aspx?SN=" + Session["SurveySN"].ToString() + "&YEAR=" + Session["SurveyYear"].ToString() + "&SCHOOLNAME=" + Session["schoolName"].ToString());
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}