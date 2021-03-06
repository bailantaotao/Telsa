﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ViewScore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");

        LoadData();
    }
    private void LoadData()
    {
        ManageSQL ms = new ManageSQL();
        string[] PassContent = { };
        string[] UnPassContent = { };

        if (!string.IsNullOrEmpty(Request["Pass"]))
            PassContent = Request["Pass"].ToString().Split(',');
        if (!string.IsNullOrEmpty(Request["UnPass"]))
            UnPassContent = Request["UnPass"].ToString().Split(',');

        LbComplete.Text = "<table style='width:500px;'>";
        LbComplete.Text += "<tr align='center' style='background-color:#00FFFF;'>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbComplete.Text += Resources.Resource.TipClassName + "</td>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbComplete.Text += Resources.Resource.TipPassScore + "</td>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbComplete.Text += "校長分數" + "</td>";
        LbComplete.Text += "</tr>";

        if ((PassContent.Length > 0 || UnPassContent.Length > 0) && Request["SM"] != null && !string.IsNullOrEmpty(Request["SM"].ToString()))
        {
            Print(PassContent);
            Print(UnPassContent);
        }
        else
        {
            LbComplete.Text += "<td colspan=3 align=center style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbComplete.Text += "No data</td>";
        }
        LbComplete.Text += "</table>";
    }

    private int GetUserMaxScore(ArrayList UserAnswerTable)
    {
        int MaxScore = -1;
        foreach (string[] table in UserAnswerTable)
        {
            if (string.IsNullOrEmpty(table[2]))
                continue;
            MaxScore = Math.Max(MaxScore, Convert.ToInt32(table[2]));
        }
        return MaxScore;
    }

    private void Print(string[] pData)
    {


        if (pData.Length > 0)
        {
            ManageSQL ms = new ManageSQL();
            foreach (string PassID in pData)
            {
                ArrayList data = new ArrayList();
                string Query = "select InternetStudy.ClassName, InternetStudy.PassScore, InternetStudyUserAnswer.TotalScore " +
                                "from InternetStudy " +
                                "left join InternetStudyUserAnswer on InternetStudy.QuestionClassID = InternetStudyUserAnswer.QuestionClassID " +
                                "where InternetStudy.QuestionClassID = '" + PassID + "' and InternetStudyUserAnswer.UserID ='" + Request["SM"].ToString() + "'";
                ms.GetAllColumnData(Query, data);
                int MaxScore = GetUserMaxScore(data);
                LbComplete.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbComplete.Text += ((string[])data[0])[0] + "</td>";
                LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbComplete.Text += ((string[])data[0])[1] + "</td>";
                LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbComplete.Text += MaxScore + "</td>";
                LbComplete.Text += "</tr>";
            }
        }
    }
}