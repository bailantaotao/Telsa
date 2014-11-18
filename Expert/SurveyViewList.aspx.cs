﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_SurveyViewList : System.Web.UI.Page
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

    private enum DdlType
    {
        Province,
        Year,
        SchoolName,
    }
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
        if (!Session["ClassCode"].ToString().Equals("1"))
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

        /*if (!verifyValid())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanErrorData + "');window.location='SurveyPreList.aspx';", true);
            return;
        }*/
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
    /*private bool verifyValid()
    {
        if (String.IsNullOrEmpty(Request["SN"]) || String.IsNullOrEmpty(Request["YEAR"]))
            return false;

        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select Count(SurveyStatus) " +
                        "from SurveyListUser " +
                        "left join SurveyList on SurveyListUser.SurveyListSN = SurveyList.SN " +
                        "where SurveyListUser.SurveyListSN ='" + Request["SN"].ToString() + "' and SurveyList.SurveyYear = '" + Request["YEAR"].ToString() + "' and SurveyListUser.SurveySchool=N'" + Session["schoolName"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;

        
            //非0，所以有資料
            query = "select SN from SurveyListUser where SurveyListSN = '" + Request["SN"].ToString() + "' and SurveySchool=N'" + Session["schoolName"].ToString() + "'";
            ms.GetOneData(query, sb);
            Session["UserSurveyListSN"] = sb.ToString();

        Session["SurveySN"] = Request["SN"].ToString();
        Session["SurveyYear"] = Request["YEAR"].ToString();

        return true;
    }*/

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SurveyViewPreList.aspx");
    }
}