﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem2 : System.Web.UI.Page
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



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        //getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        //if (!IsPostBack)
        //{

        //}

    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanMain.aspx");
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
        else
        {
            storeData();
        }
    }
    private bool haveEmptyData()
    {
        if (TbIdea.Text.Trim().Equals(""))
            return false;
        if (TbMotto.Text.Trim().Equals(""))
            return false;
        if (TbSpirit.Text.Trim().Equals(""))
            return false;
        if (TbOverview.Text.Trim().Equals(""))
            return false;
        if (TbCharacteristic.Text.Trim().Equals(""))
            return false;
        if (TbChange.Text.Trim().Equals(""))
            return false;
        return true;
    }

    private void storeData()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanCharacteristic where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into PlanCharacteristic (SN, Idea, Motto, Spirit, Profile, Characteristic, Change) VALUES ('" +
                        Session["UserPlanListSN"].ToString() + "','" +
                        TbIdea.Text.Trim() + "','" +
                        TbMotto.Text.Trim() + "','" +
                        TbSpirit.Text.Trim() + "','" +
                        TbOverview.Text.Trim() + "','" +
                        TbCharacteristic.Text.Trim() + "','" +
                        TbChange.Text.Trim() + "')";
        ms.WriteData(query, sb);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanList.aspx';", true);
    }
}