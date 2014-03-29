using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEditAddYear : System.Web.UI.Page
{
    private string Query = string.Empty;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");

        if (Session["QuestionClassYear"] == null)
            Response.Redirect("../SessionOut.aspx");
        Session["AddYearTag"] = true;
        LoadInternetStudyClass();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    

    private void LoadInternetStudyClass()
    {
        LbYear.Text = Resources.Resource.TipAdd + Session["QuestionClassYear"].ToString() + Resources.Resource.TipYears;
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();
        StringBuilder sb = new StringBuilder();

        Query = "select QuestionClassID, QuestionClassYear, ClassID, ClassName, QuestionAddedComplete from InternetStudy where QuestionClassYear = '" + Session["QuestionClassYear"].ToString() + "' order by ClassID asc";

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "No</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipClassName  + "</td>";
            //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            //LbCompleted.Text += "完成閱讀期限</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipAdd + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipEdit + "</td>";
            LbCompleted.Text += "</tr>";

            if (data.Count > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    string EncryptQuestionClassID = GetEncryptionString(QuestionClassID, ((string[])(data[i]))[0]);
                    string EncryptQuestionClassYear = GetEncryptionString(QuestionClassYear, ((string[])(data[i]))[1]);
                    string EncryptClassID = GetEncryptionString(ClassID, ((string[])(data[i]))[2]);

                    int DBClassID = -1;
                    bool isDigit = Int32.TryParse(((string[])(data[i]))[2], out DBClassID);
                    
                    bool IsAdded = false, DBAddedComplete = false ;                    
                    IsAdded = bool.TryParse(((string[])(data[i]))[4], out DBAddedComplete);

                    

                    LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                    

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";

                    //if(isDigit)
                    //    LbCompleted.Text += (DBClassID + 1).ToString() + "</td>";
                    //else
                    //    LbCompleted.Text += (i + 1).ToString() + "</td>";
                    // 如果已經新增過該類別之問題，才可以做檢視的動作
                    if (DBAddedComplete)
                    {
                        LbCompleted.Text += "<a href='InternetStudyEditDisplay.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'>" + (i + 1).ToString() + "</a></td>";
                    }
                    else
                    {
                        LbCompleted.Text += "<a href='#'>" + (i + 1).ToString() + "</a></td>";
                    }

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";

                    //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //LbCompleted.Text += ((string[])(data[i]))[4] + "</td>";

                    // 如果已經新增過該類別之問題，則只能做修改
                    if (DBAddedComplete)
                    {
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "<a href='#'><img src='../Image/zh-TW/ButtonAddGary.png'></a></td>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "<a href='InternetStudyEditModify.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";
                    }
                    else
                    {
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "<a href='InternetStudyEditAddClass.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";

                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "<a href='#'><img src='../Image/zh-TW/ButtonAddGary.png'></a></td>";
                    }
                    LbCompleted.Text += "</tr>";
                }

                Query = "select count(*) from InternetStudy where QuestionAddedComplete = 'True' and QuestionClassYear = '" + Session["QuestionClassYear"].ToString() + "'";
                if (ms.GetOneData(Query, sb))
                {
                    int AllOK = -1;
                    bool bIsDigit = int.TryParse(sb.ToString(), out AllOK);
                    if (bIsDigit)
                    {
                        if( AllOK == 10)
                        { 
                            BtnCompleted.Enabled = true;
                            BtnCompleted.Text = Resources.Resource.BtnFinish;
                        }
                    }
                }

                sb.Clear();
                data.Clear();

                
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += Resources.Resource.TipInputDataError + "</td>";
                LbCompleted.Text += "</tr>";
            }
            LbCompleted.Text += "</table>";
        }
    }

    private string GetEncryptionString(string Tag, string Data)
    {
        //BaseClass bc = new BaseClass();
        //return (Tag + "=" + bc.encryption(Data));
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        Button btn = (Button)sender;
        if (btn.ID == "BtnBack")
        {
            if (CompareValidator1.IsValid && !string.IsNullOrEmpty(TbToday.Text))
            {
                if (DateTime.Parse(TbToday.Text.Trim()) >= DateTime.Now)
                {
                    Query = "Update InternetStudy set " +
                        "DeadLine = N'" + TbToday.Text + "' " +
                        "where QuestionClassYear = '" + Session["QuestionClassYear"].ToString() + "'";
                    ms.WriteData(Query, sb);

                    Session.Remove("InternetStudyEditYearQuery");
                    Session.Remove("AddYearTag");
                    Response.Redirect("InternetStudyEdit.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMGreterDate + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMErrorDate + "');", true);
            }
        }
        else if (btn.ID == "BtnCancel")
        {
            Query = "delete from InternetStudy where QuestionClassYear = '" + Session["QuestionClassYear"].ToString() + "'";
            
            ms.WriteData(Query, sb);
            Session.Remove("InternetStudyEditYearQuery");
            Session.Remove("AddYearTag");
            Response.Redirect("InternetStudyEdit.aspx");
            
        }
        else if (btn.ID == "BtnCompleted")
        {
            if (CompareValidator1.IsValid && !string.IsNullOrEmpty(TbToday.Text))
            {
                if (DateTime.Parse(TbToday.Text.Trim()) >= DateTime.Now)
                {
                    Query = "Update InternetStudy set " +
                        "DeadLine = N'" + TbToday.Text + "' " +
                        "where QuestionClassYear = '" + Session["QuestionClassYear"].ToString() + "'";
                    ms.WriteData(Query, sb);

                    Session.Remove("InternetStudyEditYearQuery");
                    Session.Remove("AddYearTag");
                    Response.Redirect("InternetStudyEdit.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMGreterDate + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMErrorDate + "');", true);
            }
        }
    }

}