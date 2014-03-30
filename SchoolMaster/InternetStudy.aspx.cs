using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
        //    Response.Redirect("SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("0"))
        //    Response.Redirect("SessionOut.aspx");

        Session["UserID"] = "fuck";
        

        if (!IsPostBack)
        {
            AddYearToDDL();
            if (Session["CurrentYear"] != null)
            {
                int digit = -1;
                bool IsDigit = Int32.TryParse(Session["CurrentYear"].ToString(), out digit);
                if (IsDigit)
                {
                    SearchType(digit);
                }
                else
                {
                    SearchType(BaseClass.NowYear);            
                }
            }
            else
                SearchType(BaseClass.NowYear);            
        }
        else
        {
            if (!DdlYear.SelectedValue.Equals(Resources.Resource.TipPlzChoose))
            {
                Session["CurrentYear"] = DdlYear.SelectedValue;
                SearchType(Convert.ToInt32(DdlYear.SelectedValue));
            }
        }

        LoadInternetStudy();
        
    }

    private void SearchType(int QuestionClassYear)
    {
        Query = "select InternetStudy.QuestionClassID, InternetStudy.QuestionClassYear, InternetStudy.ClassID, InternetStudy.ClassName, " +
                        "InternetStudy.Deadline, InternetStudy.PassScore, InternetStudyUserAnswer.TotalScore from InternetStudy " +
                        "left join InternetStudyUserAnswer on InternetStudy.QuestionClassID = InternetStudyUserAnswer.QuestionClassID " +
                        "where InternetStudy.QuestionClassYear = '" + QuestionClassYear + "'";
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

    private void LoadInternetStudy()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        if (ms.GetAllColumnData(Query, data))
        {

            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "No</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipClassName + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipDeadline + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipAnswerState + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipUserScore + "</td>";
            LbCompleted.Text += "</tr>";

            if (data.Count > 0)
            {
                for (int i = 0 ; i < data.Count; i++)
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
                    LbCompleted.Text += ((string[])(data[i]))[4] + "</td>";

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += String.IsNullOrEmpty(((string[])(data[i]))[6]) ? Resources.Resource.TipUnPass : (Convert.ToInt32(((string[])(data[i]))[6]) >= Convert.ToInt32(((string[])(data[i]))[5])) ? Resources.Resource.TipPass : Resources.Resource.TipUnPass + "</td>";

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += String.IsNullOrEmpty(((string[])(data[i]))[6]) ? "......" : ((string[])(data[i]))[6].ToString() + "</td>";

                    LbCompleted.Text += "</tr>";

                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan='5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += "此年度尚未產生問卷</td>";
                LbCompleted.Text += "</tr>";

            }

            LbCompleted.Text += "</table>";
        }

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
        BaseClass bc = new BaseClass();
        int Low = -1, High = -1;
        //if (string.IsNullOrEmpty(TbYearA.Text) && string.IsNullOrEmpty(TbYearB.Text))
        //{
        //    SearchType(BaseClass.NowYear);            
        //}
        //else if (Int32.TryParse(TbYearA.Text, out Low) && Int32.TryParse(TbYearB.Text, out High))
        //{
        //    if (Low > High)
        //        bc.swap(ref Low, ref High);
        //    SearchType(Low, High);
        //}
        //else if (Int32.TryParse(TbYearA.Text, out Low))
        //{
        //    SearchType(Low);
        //}              
        //else if (Int32.TryParse(TbYearB.Text, out High))
        //{
        //    SearchType(High);
        //}
        //else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('請輸入數字');", true);
            return;
        }
        LoadInternetStudy();
    }

}