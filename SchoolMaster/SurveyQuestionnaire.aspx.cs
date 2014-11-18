using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_SurveyQuestionnaire : System.Web.UI.Page
{
    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;
    private string StatusQ1A1 = string.Empty;
    private string StatusQ1A2 = string.Empty;
    private string StatusQ1A3 = string.Empty;
    private string StatusQ1A4 = string.Empty;
    private string StatusQ1A5 = string.Empty;
    private string StatusQ1A6 = string.Empty;
    private string StatusQ1A7 = string.Empty;
    private string StatusQ1A8 = string.Empty;
    private string StatusQ1A9 = string.Empty;
    private string StatusQ1A10 = string.Empty;
    private string StatusQ2A1 = string.Empty;
    private string StatusQ2A2 = string.Empty;
    private string StatusQ2A3 = string.Empty;
    private string StatusQ2A4 = string.Empty;
    private string StatusQ2A5 = string.Empty;
    private string StatusQ2A6 = string.Empty;
    private string StatusQ2A7 = string.Empty;
    private string StatusQ2A8 = string.Empty;
    private string StatusQ2A9 = string.Empty;
    private string StatusQ2A10 = string.Empty;

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

        getSchoolName(schoolName);
        LbSurveySchool.Text = schoolName.ToString();
        LbSurveySchoolID.Text = Session["UserID"].ToString();
        LbSurveyYear.Text = Session["SurveyYear"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
    private void setInitial()
    {
        getSchoolName(schoolName);
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Q1A1, Q1A2, Q1A3, Q1A4, Q1A5, Q1A6, Q1A7, Q1A8, Q1A9, Q1A10, Q2A1, Q2A2, Q2A3, Q2A4, Q2A5, Q2A6, Q2A7, Q2A8, Q2A9, Q2A10, Request, Comment1, Comment2, Proposal from SurveyQuestionnaire " +
                       "where SN ='" + Session["UserSurveyListSN"].ToString() + "'" + 
                       "and Year='"+Session["SurveyYear"].ToString()+ "'" +
                       "and School= N'" + schoolName.ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            if (d[0].ToString() == "True")
            {
                CbQ1A1.Checked = true;
            }
            if (d[1].ToString() == "True")
            {
                CbQ1A2.Checked = true;
            }
            if (d[2].ToString() == "True")
            {
                CbQ1A3.Checked = true;
            }
            if (d[3].ToString() == "True")
            {
                CbQ1A4.Checked = true;
            }
            if (d[4].ToString() == "True")
            {
                CbQ1A5.Checked = true;
            }
            if (d[5].ToString() == "True")
            {
                CbQ1A6.Checked = true;
            }
            if (d[6].ToString() == "True")
            {
                CbQ1A7.Checked = true;
            }
            if (d[7].ToString() == "True")
            {
                CbQ1A8.Checked = true;
            }
            if (d[8].ToString() == "True")
            {
                CbQ1A9.Checked = true;
            }
            if (d[9].ToString() == "True")
            {
                CbQ1A10.Checked = true;
            }
            if (d[10].ToString() == "True")
            {
                CbQ2A1.Checked = true;
            }
            if (d[11].ToString() == "True")
            {
                CbQ2A2.Checked = true;
            }
            if (d[12].ToString() == "True")
            {
                CbQ2A3.Checked = true;
            }
            if (d[13].ToString() == "True")
            {
                CbQ2A4.Checked = true;
            }
            if (d[14].ToString() == "True")
            {
                CbQ2A5.Checked = true;
            }
            if (d[15].ToString() == "True")
            {
                CbQ2A6.Checked = true;
            }
            if (d[16].ToString() == "True")
            {
                CbQ2A7.Checked = true;
            }
            if (d[17].ToString() == "True")
            {
                CbQ2A8.Checked = true;
            }
            if (d[18].ToString() == "True")
            {
                CbQ2A9.Checked = true;
            }
            if (d[19].ToString() == "True")
            {
                CbQ2A10.Checked = true;
            }
            TbRequest.Text = d[20];
            TbComment1.Text = d[21];
            TbComment2.Text = d[22];
            TbProposal.Text = d[23];
        }
    }
    private void AnswerStatus()
    {   
        if (CbQ1A1.Checked == true)
        {
            StatusQ1A1 = "True";
        }
        else if (CbQ1A1.Checked == false)
        {
            StatusQ1A1 = "False";
        }
        if (CbQ1A2.Checked == true)
        {
            StatusQ1A2 = "True";
        }
        else if (CbQ1A2.Checked == false)
        {
            StatusQ1A2 = "False";
        }
        if (CbQ1A3.Checked == true)
        {
            StatusQ1A3 = "True";
        }
        else if (CbQ1A3.Checked == false)
        {
            StatusQ1A3 = "False";
        }
        if (CbQ1A4.Checked == true)
        {
            StatusQ1A4 = "True";
        }
        else if (CbQ1A4.Checked == false)
        {
            StatusQ1A4 = "False";
        }
        if (CbQ1A5.Checked == true)
        {
            StatusQ1A5 = "True";
        }
        else if (CbQ1A5.Checked == false)
        {
            StatusQ1A5 = "False";
        }
        if (CbQ1A6.Checked == true)
        {
            StatusQ1A6 = "True";
        }
        else if (CbQ1A6.Checked == false)
        {
            StatusQ1A6 = "False";
        }
        if (CbQ1A7.Checked == true)
        {
            StatusQ1A7 = "True";
        }
        else if (CbQ1A7.Checked == false)
        {
            StatusQ1A7 = "False";
        }
        if (CbQ1A8.Checked == true)
        {
            StatusQ1A8 = "True";
        }
        else if (CbQ1A8.Checked == false)
        {
            StatusQ1A8 = "False";
        }
        if (CbQ1A9.Checked == true)
        {
            StatusQ1A9 = "True";
        }
        else if (CbQ1A9.Checked == false)
        {
            StatusQ1A9 = "False";
        }
        if (CbQ1A10.Checked == true)
        {
            StatusQ1A10 = "True";
        }
        else if (CbQ1A10.Checked == false)
        {
            StatusQ1A10 = "False";
        }
        if (CbQ2A1.Checked == true)
        {
            StatusQ2A1 = "True";
        }
        else if (CbQ2A1.Checked == false)
        {
            StatusQ2A1 = "False";
        }
        if (CbQ2A2.Checked == true)
        {
            StatusQ2A2 = "True";
        }
        else if (CbQ2A2.Checked == false)
        {
            StatusQ2A2 = "False";
        }
        if (CbQ2A3.Checked == true)
        {
            StatusQ2A3 = "True";
        }
        else if (CbQ2A3.Checked == false)
        {
            StatusQ2A3 = "False";
        }
        if (CbQ2A4.Checked == true)
        {
            StatusQ2A4 = "True";
        }
        else if (CbQ2A4.Checked == false)
        {
            StatusQ2A4 = "False";
        }
        if (CbQ2A5.Checked == true)
        {
            StatusQ2A5 = "True";
        }
        else if (CbQ2A5.Checked == false)
        {
            StatusQ2A5 = "False";
        }
        if (CbQ2A6.Checked == true)
        {
            StatusQ2A6 = "True";
        }
        else if (CbQ2A6.Checked == false)
        {
            StatusQ2A6 = "False";
        }
        if (CbQ2A7.Checked == true)
        {
            StatusQ2A7 = "True";
        }
        else if (CbQ2A7.Checked == false)
        {
            StatusQ2A7 = "False";
        }
        if (CbQ2A8.Checked == true)
        {
            StatusQ2A8 = "True";
        }
        else if (CbQ2A8.Checked == false)
        {
            StatusQ2A8 = "False";
        }
        if (CbQ2A9.Checked == true)
        {
            StatusQ2A9 = "True";
        }
        else if (CbQ2A9.Checked == false)
        {
            StatusQ2A9 = "False";
        }
        if (CbQ2A10.Checked == true)
        {
            StatusQ2A10 = "True";
        }
        else if (CbQ2A10.Checked == false)
        {
            StatusQ2A10 = "False";
        }
    }
    private void storeData()
    {
        getSchoolName(schoolName);
        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();
        StringBuilder sb4 = new StringBuilder();
        StringBuilder sb5 = new StringBuilder();

        string query1 = string.Empty;
        string query2 = string.Empty;
        string query3 = string.Empty;
        string query4 = string.Empty;
        ManageSQL ms = new ManageSQL();
        //先刪除原本的
        string query = "delete from SurveyQuestionnaire where SN ='" + Session["UserSurveyListSN"].ToString() + "'" + "and Year ='" + Session["SurveyYear"].ToString() + "'" + "and School= N'" + schoolName.ToString() +"'";
        ms.WriteData(query, sb);
        sb.Clear();
        AnswerStatus();
        query = "insert into SurveyQuestionnaire (SN, Year, School, Q1A1, Q1A2, Q1A3, Q1A4, Q1A5, Q1A6, Q1A7, Q1A8, Q1A9, Q1A10, Q2A1, Q2A2, Q2A3, Q2A4, Q2A5, Q2A6, Q2A7, Q2A8, Q2A9, Q2A10, Request, Comment1, Comment2, Proposal, Complete) VALUES ('" +
                        Session["UserSurveyListSN"].ToString() + "','" +
                        Session["SurveyYear"].ToString() + "', N'" +
                        schoolName.ToString() + "','" +
                        StatusQ1A1 + "','" +
                        StatusQ1A2 + "','" +
                        StatusQ1A3 + "','" +
                        StatusQ1A4 + "','" +
                        StatusQ1A5 + "','" +
                        StatusQ1A6 + "','" +
                        StatusQ1A7 + "','" +
                        StatusQ1A8 + "','" +
                        StatusQ1A9 + "','" +
                        StatusQ1A10 + "','" +
                        StatusQ2A1 + "','" +
                        StatusQ2A2 + "','" +
                        StatusQ2A3 + "','" +
                        StatusQ2A4 + "','" +
                        StatusQ2A5 + "','" +
                        StatusQ2A6 + "','" +
                        StatusQ2A7 + "','" +
                        StatusQ2A8 + "','" +
                        StatusQ2A9 + "','" +
                        StatusQ2A10 + "', N'" +
                        TbRequest.Text.Trim() + "', N'" +
                        TbComment1.Text.Trim() + "', N'" +
                        TbComment2.Text.Trim() + "', N'" +
                        TbProposal.Text.Trim() + "','1')";
        ms.WriteData(query, sb);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='SurveyList.aspx?SN=" + Session["SurveySN"].ToString() + "&YEAR=" + Session["SurveyYear"].ToString() + "';", true);
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        string query = string.Empty;

        StringBuilder sb = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();
        StringBuilder sb4 = new StringBuilder();
        StringBuilder sb5 = new StringBuilder();
        StringBuilder sb6 = new StringBuilder();

        string query1 = string.Empty;
        string query2 = string.Empty;
        string query3 = string.Empty;
        string query4 = string.Empty;
        string query5 = string.Empty;
        ManageSQL ms = new ManageSQL();


        query1 = "select Complete from SurveyQuestionnaire where SN=" + Session["UserSurveyListSN"].ToString() + "and Year= " + Session["SurveyYear"].ToString() + "and School= N'" + schoolName.ToString() + "'";
        ms.GetOneData(query1, sb2);
        query2 = "select Complete from SurveyListLanguage where SN=" + Session["UserSurveyListSN"].ToString() + "and Year= " + Session["SurveyYear"].ToString() + "and School= N'" + schoolName.ToString() + "'";
        ms.GetOneData(query2, sb3);
        query3 = "select Complete from SurveyListMath where SN=" + Session["UserSurveyListSN"].ToString() + "and Year= " + Session["SurveyYear"].ToString() + "and School= N'" + schoolName.ToString() + "'";
        ms.GetOneData(query3, sb4);
        query4 = "select Complete from SurveyListEnglish where SN=" + Session["UserSurveyListSN"].ToString() + "and Year= " + Session["SurveyYear"].ToString() + "and School= N'" + schoolName.ToString() + "'";
        ms.GetOneData(query4, sb5);
        query5 = "update SurveyListUser set SurveyStatus='True' where SN=" + Session["UserSurveyListSN"].ToString() + "and Year= " + Session["SurveyYear"].ToString() + "and School= N'" + schoolName.ToString() + "'";
        

        if (sb2.ToString() == "1")
        {
            if (sb3.ToString() == "1")
            {
                if (sb4.ToString() == "1")
                {
                    if (sb5.ToString() == "1")
                    {
                        ms.WriteData(query, sb6);
                    }
                }
            }
        }

        storeData();
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