﻿    using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideViewText : System.Web.UI.Page
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
        No,
    }
    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.No:
                setNo();
                break;
        }
    }
    private void setNo()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select No from GuideText " +
                "where SN ='" + Session["UserGuideListSN"].ToString() + "'";


        if (!ms.GetAllColumnData(Query, data))
        {
            DropDownList3.Items.Add("请选择");
            return;
        }

        if (data.Count == 0)
        {
            DropDownList3.Items.Add("请选择");
            return;
        }
        foreach (string[] province in data)
        {
            DropDownList3.Items.Add(province[0]);
        }
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
            LbGuideTextUserID.Visible = false;
        }
        setDefault(DdlType.No);

        LbGuideYear.Text = Session["GuideYear"].ToString();
        LbGuideSemester.Text = Session["GuideSemester"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            if (!IsPostBack)
            {
                
            }
            setInitial();
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            if (!IsPostBack)
            {
                
            }
            setInitial_MingDer();
        }
        
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

    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MainContent, SubjectAbility, PersonalityMold, SchoolManagement, SDPFormulate, SDPImplement, SDPEffect, NextStepSuggest from GuideText where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and No='" + DropDownList3.SelectedValue.ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                LbGuideViewTextContent.Text = d[0];
                LbGuideViewTextSubject.Text = d[1];
                LbGuideViewTextPersonality.Text = d[2];
                LbGuideViewTextSchoolManagement.Text = d[3];
                LbGuideViewTextSDPFormulate.Text = d[4];
                LbGuideViewTextSDPImplement.Text = d[5];
                LbGuideViewTextSDPeffect.Text = d[6];
                LbGuideViewTextNextStepSuggest.Text = d[7];
            }
    }
    private void setInitial_MingDer()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MainContent, SubjectAbility, PersonalityMold, SchoolManagement, SDPFormulate, SDPImplement, SDPEffect, NextStepSuggest from GuideText where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and No='" + DropDownList3.SelectedValue.ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            LbGuideViewTextContent.Text = d[0];
            LbGuideViewTextSubject.Text = d[1];
            LbGuideViewTextPersonality.Text = d[2];
            LbGuideViewTextSchoolManagement.Text = d[3];
            LbGuideViewTextSDPFormulate.Text = d[4];
            LbGuideViewTextSDPImplement.Text = d[5];
            LbGuideViewTextSDPeffect.Text = d[6];
            LbGuideViewTextNextStepSuggest.Text = d[7];
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