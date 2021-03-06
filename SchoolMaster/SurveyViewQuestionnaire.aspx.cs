﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_SurveyViewQuestionnaire : System.Web.UI.Page
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
    private string StatusQ2A1 = string.Empty;
    private string StatusQ2A2 = string.Empty;
    private string StatusQ2A3 = string.Empty;
    private string StatusQ2A4 = string.Empty;
    private string StatusQ2A5 = string.Empty;
    private string StatusQ2A6 = string.Empty;
    private string StatusQ2A7 = string.Empty;
    private string StatusQ2A8 = string.Empty;
    private string StatusQ2A9 = string.Empty;

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
        string query = "select Q1A1, Q1A2, Q1A3, Q1A4, Q1A5, Q1A6, Q1A7, Q1A8, Q1A9, Q2A1, Q2A2, Q2A3, Q2A4, Q2A5, Q2A6, Q2A7, Q2A8, Q2A9, Request, Comment1, Comment2, Proposal from SurveyQuestionnaire " +
                       "where Year='" + Session["SurveyYear"].ToString() + "'" +
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
                CbQ2A1.Checked = true;
            }
            if (d[10].ToString() == "True")
            {
                CbQ2A2.Checked = true;
            }
            if (d[11].ToString() == "True")
            {
                CbQ2A3.Checked = true;
            }
            if (d[12].ToString() == "True")
            {
                CbQ2A4.Checked = true;
            }
            if (d[13].ToString() == "True")
            {
                CbQ2A5.Checked = true;
            }
            if (d[14].ToString() == "True")
            {
                CbQ2A6.Checked = true;
            }
            if (d[15].ToString() == "True")
            {
                CbQ2A7.Checked = true;
            }
            if (d[16].ToString() == "True")
            {
                CbQ2A8.Checked = true;
            }
            if (d[17].ToString() == "True")
            {
                CbQ2A9.Checked = true;
            }
            TbRequest.Text = d[18];
            TbComment1.Text = d[19];
            TbComment2.Text = d[20];
            TbProposal.Text = d[21];
        }
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SurveyViewList.aspx?SN=" + Session["SurveySN"].ToString() + "&YEAR=" + Session["SurveyYear"].ToString());
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
    
}