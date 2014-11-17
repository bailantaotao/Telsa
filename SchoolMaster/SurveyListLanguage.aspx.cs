using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_SurveyListLanguage : System.Web.UI.Page
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
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

        getSchoolName(schoolName);
        getSchoolUser(schoolUser);
        LbSurveySchool.Text = schoolName.ToString();
        LbSurveyUser.Text = schoolUser.ToString();
        Lbdescription1.Text += "1.敬请针对教材的" + '"' + "电子平台" + "'" + "(PowerPoint教材)﹑" + '"' + "教案" + '"' + "(Word教材)及" + '"' + "契合" + '"' + "依照" + '"' + "评价要点" + '"' + "勾选(✔)" + '"' + "很满意" + '"' + "﹑" + '"' + "满意" + '"' + "﹑" + '"' + "基本满意" + '"' + " ﹑" + '"' + "不满意" + '"' + "或" + '"' + "很不满意" + '"' + "(五选一)，并请提出宝贵建议。 " + '"' + "建议事项" + '"' + "不够填写可另附。";
        TbSurveyYear.Text += DateTime.Now.Year.ToString();
        TbSurveyMonth.Text += DateTime.Now.Month.ToString();
        TbSurveyDay.Text += DateTime.Now.Day.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
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
        Session["schoolName"] = sb.ToString();
        return true;
    }
    private bool getSchoolUser(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select UserName from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        Session["schoolUser"] = sb.ToString();
        return true;
    }
    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Proposal1, Proposal2 from SurveyListLanguage " +
                       "where SN ='" + Session["UserSurveyListSN"].ToString() + "'" +
                       "and Year='" + Session["SurveyYear"].ToString() + "'" +
                       "and School = N'" + schoolName.ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            TbPPT.Text = d[0];
            TbWord.Text = d[1];
        }
    }
    private void AnswerStatus()
    {
        if (RbQ1O1.Checked == true)
        {
            Q1 = "1";
            S1 = 100;
        }
        if (RbQ1O2.Checked == true)
        {
            Q1 = "2";
            S1 = 80;
        }
        if (RbQ1O3.Checked == true)
        {
            Q1 = "3";
            S1 = 60;
        }
        if (RbQ1O4.Checked == true)
        {
            Q1 = "4";
            S1 = 40;
        }
        if (RbQ1O5.Checked == true)
        {
            Q1 = "5";
            S1 = 20;
        }

        if (RbQ2O1.Checked == true)
        {
            Q2 = "1";
            S2 = 100;
        }
        if (RbQ2O2.Checked == true)
        {
            Q2 = "2";
            S2 = 80;
        }
        if (RbQ2O3.Checked == true)
        {
            Q2 = "3";
            S2 = 60;
        }
        if (RbQ2O4.Checked == true)
        {
            Q2 = "4";
            S2 = 40;
        }
        if (RbQ2O5.Checked == true)
        {
            Q2 = "5";
            S2 = 20;
        }

        if (RbQ3O1.Checked == true)
        {
            Q3 = "1";
            S3 = 100;
        }
        if (RbQ3O2.Checked == true)
        {
            Q3 = "2";
            S3 = 80;
        }
        if (RbQ3O3.Checked == true)
        {
            Q3 = "3";
            S3 = 60;
        }
        if (RbQ3O4.Checked == true)
        {
            Q3 = "4";
            S3 = 40;
        }
        if (RbQ3O5.Checked == true)
        {
            Q3 = "5";
            S3 = 20;
        }

        if (RbQ4O1.Checked == true)
        {
            Q4 = "1";
            S4 = 100;
        }
        if (RbQ4O2.Checked == true)
        {
            Q4 = "2";
            S4 = 80;
        }
        if (RbQ4O3.Checked == true)
        {
            Q4 = "3";
            S4 = 60;
        }
        if (RbQ4O4.Checked == true)
        {
            Q4 = "4";
            S4 = 40;
        }
        if (RbQ4O5.Checked == true)
        {
            Q4 = "5";
            S4 = 20;
        }

        if (RbQ5O1.Checked == true)
        {
            Q5 = "1";
            S5 = 100;
        }
        if (RbQ5O2.Checked == true)
        {
            Q5 = "2";
            S5 = 80;
        }
        if (RbQ5O3.Checked == true)
        {
            Q5 = "3";
            S5 = 60;
        }
        if (RbQ5O4.Checked == true)
        {
            Q5 = "4";
            S5 = 40;
        }
        if (RbQ5O5.Checked == true)
        {
            Q5 = "5";
            S5 = 20;
        }

        if (RbQ6O1.Checked == true)
        {
            Q6 = "1";
            S6 = 100;
        }
        if (RbQ6O2.Checked == true)
        {
            Q6 = "2";
            S6 = 80;
        }
        if (RbQ6O3.Checked == true)
        {
            Q6 = "3";
            S6 = 60;
        }
        if (RbQ6O4.Checked == true)
        {
            Q6 = "4";
            S6 = 40;
        }
        if (RbQ6O5.Checked == true)
        {
            Q6 = "5";
            S6 = 20;
        }

        if (RbQ7O1.Checked == true)
        {
            Q7 = "1";
            S7 = 100;
        }
        if (RbQ7O2.Checked == true)
        {
            Q7 = "2";
            S7 = 80;
        }
        if (RbQ7O3.Checked == true)
        {
            Q7 = "3";
            S7 = 60;
        }
        if (RbQ7O4.Checked == true)
        {
            Q7 = "4";
            S7 = 40;
        }
        if (RbQ7O5.Checked == true)
        {
            Q7 = "5";
            S7 = 20;
        }

        if (RbQ8O1.Checked == true)
        {
            Q8 = "1";
            S8 = 100;
        }
        if (RbQ8O2.Checked == true)
        {
            Q8 = "2";
            S8 = 80;
        }
        if (RbQ8O3.Checked == true)
        {
            Q8 = "3";
            S8 = 60;
        }
        if (RbQ8O4.Checked == true)
        {
            Q8 = "4";
            S8 = 40;
        }
        if (RbQ8O5.Checked == true)
        {
            Q8 = "5";
            S8 = 20;
        }

        if (RbQ9O1.Checked == true)
        {
            Q9 = "1";
            S9 = 100;
        }
        if (RbQ9O2.Checked == true)
        {
            Q9 = "2";
            S9 = 80;
        }
        if (RbQ9O3.Checked == true)
        {
            Q9 = "3";
            S9 = 60;
        }
        if (RbQ9O4.Checked == true)
        {
            Q9 = "4";
            S9 = 40;
        }
        if (RbQ9O5.Checked == true)
        {
            Q9 = "5";
            S9 = 20;
        }

        if (RbQ10O1.Checked == true)
        {
            Q10 = "1";
            S10 = 100;
        }
        if (RbQ10O2.Checked == true)
        {
            Q10 = "2";
            S10 = 80;
        }
        if (RbQ10O3.Checked == true)
        {
            Q10 = "3";
            S10 = 60;
        }
        if (RbQ10O4.Checked == true)
        {
            Q10 = "4";
            S10 = 40;
        }
        if (RbQ10O5.Checked == true)
        {
            Q10 = "5";
            S10 = 20;
        }

        if (RbQ11O1.Checked == true)
        {
            Q11 = "1";
            S11 = 100;
        }
        if (RbQ11O2.Checked == true)
        {
            Q11 = "2";
            S11 = 80;
        }
        if (RbQ11O3.Checked == true)
        {
            Q11 = "3";
            S11 = 60;
        }
        if (RbQ11O4.Checked == true)
        {
            Q11 = "4";
            S11 = 40;
        }
        if (RbQ11O5.Checked == true)
        {
            Q11 = "5";
            S11 = 20;
        }
    }
    private void storeData()
    {
        int Score1 = 0;
        int Score2 = 0;
        int Score3 = 0;

        getSchoolName(schoolName);
        AnswerStatus();
        Score1 = (S1 + S2 + S3 + S4 + S5) / 5;
        Score2 = (S6 + S7 + S8 + S9 + S10) / 5;
        Score3 = S11;
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        //先刪除原本的
        string query = "delete from SurveyListLanguage where SN ='" + Session["UserSurveyListSN"].ToString() + "'" + "and Year ='" + Session["SurveyYear"].ToString() + "'" + "and School= N'" + schoolName.ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();

        query = "insert into SurveyListLanguage (SN, Year, School, ListYear, ListMonth, ListDay, Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11, SatisfyScore1, SatisfyScore2, SatisfyScore3, Proposal1, Proposal2) VALUES ('" +
                        Session["UserSurveyListSN"].ToString() + "','" +
                        Session["SurveyYear"].ToString() + "', N'" +
                        schoolName.ToString() + "','" +
                        TbSurveyYear.Text +"','" +
                        TbSurveyMonth.Text +"','" +
                        TbSurveyDay.Text +"','" +
                        Q1 + "','" +
                        Q2 + "','" +
                        Q3 + "','" +
                        Q4 + "','" +
                        Q5 + "','" +
                        Q6 + "','" +
                        Q7 + "','" +
                        Q8 + "','" +
                        Q9 + "','" +
                        Q10 + "','" +
                        Q11 + "','" +
                        Score1 + "','" +
                        Score2 + "','" +
                        Score3 + "', N'" +
                        TbPPT.Text.Trim() + "', N'" +
                        TbWord.Text.Trim() + "')";
        ms.WriteData(query, sb);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='SurveyList.aspx?SN=" + Session["SurveySN"].ToString() + "&YEAR=" + Session["SurveyYear"].ToString() + "';", true);
    }

    
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string query = string.Empty;

        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();

        storeData();

        query = "update SurveyListLanguage set Complete='1'";
        ms.WriteData(query, sb);
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SurveyList.aspx?SN=" + Session["SurveySN"].ToString() + "&YEAR=" + Session["SurveyYear"].ToString());
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}