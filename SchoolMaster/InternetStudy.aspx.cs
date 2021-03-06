﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_InternetStudy : System.Web.UI.Page
{
    
    private string Query = string.Empty;
    public string backgroundImage = Resources.Resource.ImgUrlBackground;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            AddYearToDDL();
            if (Session["CurrentYear"] != null)
            {
                int digit = -1;
                bool IsDigit = Int32.TryParse(Session["CurrentYear"].ToString(), out digit);
                if (IsDigit)
                {
                    LoadInternetStudy(digit);
                }
                else
                {
                    DdlYear.SelectedValue = BaseClass.NowYear.ToString();
                    LoadInternetStudy(BaseClass.NowYear);
                }
            }
            else
            {
                DdlYear.SelectedValue = BaseClass.NowYear.ToString();
                LoadInternetStudy(BaseClass.NowYear);
            }
        }
        else
        {
            if (!DdlYear.SelectedValue.Equals(Resources.Resource.TipPlzChoose))
            {
                Session["CurrentYear"] = DdlYear.SelectedValue;
                LoadInternetStudy(Convert.ToInt32(DdlYear.SelectedValue));
            }
        }

        
    }


    private void AddYearToDDL()
    {
        Query = "select QuestionClassYear from InternetStudy group by QuestionClassYear order by QuestionClassYear asc";
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        if(ms.GetAllColumnData(Query,data))
        {
            if (data.Count > 0)
            {
                for (int i = 0; i < data.Count; i++)
                    DdlYear.Items.Add(((string[])data[i])[0]);
            }
            else
            {
                DdlYear.Items.Add("未有任何資料");
            }
        }
    }

    private bool UserIsReviewQuestionnaire(ArrayList UserAnswerTable, String QuestionnireID)
    {
        foreach(string[] table in UserAnswerTable)
        {
            if (table[0].Equals(QuestionnireID))
                return true;
        }
        return false;
    }

    private int GetUserMaxScore(ArrayList UserAnswerTable, String QuestionnireID)
    {
        int MaxScore = -1;
        foreach (string[] table in UserAnswerTable)
        {
            if (string.IsNullOrEmpty(table[1]))
                continue;
            if (table[0].Equals(QuestionnireID))
            {
                MaxScore = Math.Max(MaxScore, Convert.ToInt32(table[1]));
            }
        }
        return MaxScore;
    }

    private void LoadInternetStudy(int pQuestionClassYear)
    {

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();
        Query = "select QuestionAddedComplete from InternetStudy where QuestionClassYear='" + pQuestionClassYear + "' group by QuestionAddedComplete";

        LbCompleted.Text = "<table style='width:700px;'>";
        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;'>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += "No</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipClassName + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipDeadline + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipAnswerState + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipUserScore + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipComment + "</td>";
        LbCompleted.Text += "</tr>";

        if (ms.GetAllColumnData(Query, data))
        {
            if(data.Count == 1)
            { 
                bool bdata = false;
                bool isParseOK = bool.TryParse(((string[])data[0])[0], out bdata);

                if (bdata)
                {
                    data.Clear();
                    //Query = "select InternetStudy.QuestionClassID, InternetStudy.QuestionClassYear, InternetStudy.ClassID, InternetStudy.ClassName, " +
                    //        "InternetStudy.Deadline, InternetStudy.PassScore, InternetStudyUserAnswer.TotalScore from InternetStudy " +
                    //        "left join InternetStudyUserAnswer on InternetStudy.QuestionClassID = InternetStudyUserAnswer.QuestionClassID " +
                    //        "where InternetStudy.QuestionClassYear = '" + pQuestionClassYear + "'";
                    
                    //get user score
                    Query = "select InternetStudy.QuestionClassID, InternetStudyUserAnswer.TotalScore from InternetStudy " +
                            "left join InternetStudyUserAnswer on InternetStudy.QuestionClassID = InternetStudyUserAnswer.QuestionClassID " +
                            "and InternetStudy.QuestionClassYear = '" + pQuestionClassYear + "' and InternetStudyUserAnswer.UserID = '" + Session["UserID"].ToString() + "'";

                    string QuestionContent = "select InternetStudy.QuestionClassID, InternetStudy.QuestionClassYear, InternetStudy.ClassID, InternetStudy.ClassName, " +
                                                "InternetStudy.Deadline, InternetStudy.PassScore from InternetStudy " +
                                                "where InternetStudy.QuestionClassYear = '" + pQuestionClassYear + "'";
                    ArrayList QuestionCollection = new ArrayList();
                    if (ms.GetAllColumnData(QuestionContent, QuestionCollection) && ms.GetAllColumnData(Query, data))
                    {
                        if (QuestionCollection.Count > 0)
                        {
                            for (int i = 0; i < QuestionCollection.Count; i++)
                            {
                                string EncryptQuestionClassID = GetEncryptionString(QuestionClassID, ((string[])(QuestionCollection[i]))[0]);
                                string EncryptQuestionClassYear = GetEncryptionString(QuestionClassYear, ((string[])(QuestionCollection[i]))[1]);
                                string EncryptClassID = GetEncryptionString(ClassID, ((string[])(QuestionCollection[i]))[2]);

                                bool UserIsReview = UserIsReviewQuestionnaire(data, ((string[])(QuestionCollection[i]))[0]);
                                int MaxScore = GetUserMaxScore(data, ((string[])(QuestionCollection[i]))[0]);
                                

                                LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                                LbCompleted.Text += (i + 1).ToString() + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                                
                                LbCompleted.Text += "<a href='InternetStudyQuestionnaire.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'>" + ((string[])(QuestionCollection[i]))[3] + "</a></td>";


                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                                LbCompleted.Text += ((string[])(QuestionCollection[i]))[4].Split(' ')[0] + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                                LbCompleted.Text += (data == null) ? Resources.Resource.TipUnPass : (MaxScore >= Convert.ToInt32(((string[])(QuestionCollection[i]))[5])) ? Resources.Resource.TipPass : Resources.Resource.TipUnPass + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                                LbCompleted.Text += (data == null) ? "......" : (MaxScore == -1) ? "......" : MaxScore + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                                if (UserIsReview)
                                    LbCompleted.Text += "<a href='InternetStudyComment.aspx?" + EncryptQuestionClassID + "'>" + Resources.Resource.TipComment + "</a></td>";
                                else
                                    LbCompleted.Text += "<a href='#'>" + Resources.Resource.TipComment + "</a></td>";

                                LbCompleted.Text += "</tr>";

                            }
                        }
                        else
                        {
                            LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                            LbCompleted.Text += "<td colspan='6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                            LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                            LbCompleted.Text += "</tr>";

                        }
                    }
                    else
                    {
                        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                        LbCompleted.Text += "<td colspan='6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                        LbCompleted.Text += "</tr>";

                    }
                }
                else
                {
                    LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                    LbCompleted.Text += "<td colspan='6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                    LbCompleted.Text += "</tr>";

                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan='6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                LbCompleted.Text += "</tr>";

            }
        }
        else
        {
            LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan='6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
            LbCompleted.Text += "</tr>";

        }

        LbCompleted.Text += "</table>";

    }

    private string GetEncryptionString(string Tag, string Data)
    {
        //BaseClass bc = new BaseClass();
        //return (Tag + "=" +bc.encryption(Data));
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }



    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}