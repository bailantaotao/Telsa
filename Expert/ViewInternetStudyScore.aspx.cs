using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_ViewInternetStudyScore : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || string.IsNullOrEmpty(Request["QuestionClassID"]))
            Response.Redirect("../SessionOut.aspx");
        if (Session["IsMingDer"] == null)
            Response.Redirect("../SessionOut.aspx");

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            DdlProvince.Visible = true;
            LbProvince.Visible = false;
        }
        else
        {
            DdlProvince.Visible = false;
            LbProvince.Visible = true;
        }



    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void LoadInternetStudy(int pQuestionClassYear)
    {

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();
        Query = "select QuestionAddedComplete from InternetStudy where QuestionClassYear='" + pQuestionClassYear + "' group by QuestionAddedComplete";

        LbCompleted.Text = "<table style='width:700px;'>";
        LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += "No</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += Resources.Resource.TipYears + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += Resources.Resource.TipSchool + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += Resources.Resource.TipSchoolMaster + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += Resources.Resource.TipFinishRate + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += Resources.Resource.TipPassClass + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbCompleted.Text += Resources.Resource.TipUnPassClass + "</td>";
        LbCompleted.Text += "</tr>";

        if (ms.GetAllColumnData(Query, data))
        {
            if (data.Count == 1)
            {
                bool bdata = false;
                bool isParseOK = bool.TryParse(((string[])data[0])[0], out bdata);

                if (bdata)
                {
                    data.Clear();
                    Query = "select InternetStudy.QuestionClassID, InternetStudy.QuestionClassYear, InternetStudy.ClassID, InternetStudy.ClassName, " +
                            "InternetStudy.Deadline, InternetStudy.PassScore, InternetStudyUserAnswer.TotalScore from InternetStudy " +
                            "left join InternetStudyUserAnswer on InternetStudy.QuestionClassID = InternetStudyUserAnswer.QuestionClassID " +
                            "where InternetStudy.QuestionClassYear = '" + pQuestionClassYear + "'";

                    if (ms.GetAllColumnData(Query, data))
                    {
                        if (data.Count > 0)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                bool UserIsReview = String.IsNullOrEmpty(((string[])(data[i]))[6]) ? false : true;

                                string EncryptQuestionClassID = GetEncryptionString(QuestionClassID, ((string[])(data[i]))[0]);
                                string EncryptQuestionClassYear = GetEncryptionString(QuestionClassYear, ((string[])(data[i]))[1]);
                                string EncryptClassID = GetEncryptionString(ClassID, ((string[])(data[i]))[2]);

                                LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                                if (UserIsReview)
                                    LbCompleted.Text += "<a href='#'>" + (i + 1).ToString() + "</a></td>";
                                else
                                    LbCompleted.Text += "<a href='InternetStudyQuestionnaire.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'>" + (i + 1).ToString() + "</a></td>";


                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                                LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                                LbCompleted.Text += ((string[])(data[i]))[4].Split(' ')[0] + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                                LbCompleted.Text += String.IsNullOrEmpty(((string[])(data[i]))[6]) ? Resources.Resource.TipUnPass : (Convert.ToInt32(((string[])(data[i]))[6]) >= Convert.ToInt32(((string[])(data[i]))[5])) ? Resources.Resource.TipPass : Resources.Resource.TipUnPass + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                                LbCompleted.Text += String.IsNullOrEmpty(((string[])(data[i]))[6]) ? "......" : ((string[])(data[i]))[6].ToString() + "</td>";

                                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";

                                if (UserIsReview)
                                    LbCompleted.Text += "<a href='InternetStudyComment.aspx?" + EncryptQuestionClassID + "'>" + Resources.Resource.TipComment + "</a></td>";
                                else
                                    LbCompleted.Text += "<a href='#'>" + Resources.Resource.TipComment + "</a></td>";

                                LbCompleted.Text += "</tr>";

                            }
                        }
                        else
                        {
                            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                            LbCompleted.Text += "<td colspan='5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                            LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                            LbCompleted.Text += "</tr>";

                        }
                    }
                    else
                    {
                        LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                        LbCompleted.Text += "<td colspan='5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                        LbCompleted.Text += "</tr>";

                    }
                }
                else
                {
                    LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                    LbCompleted.Text += "<td colspan='5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                    LbCompleted.Text += "</tr>";

                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan='5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
                LbCompleted.Text += "</tr>";

            }
        }
        else
        {
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan='5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
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


    protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}