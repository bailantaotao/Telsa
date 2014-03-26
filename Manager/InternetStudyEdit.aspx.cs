using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEdit : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int Page = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");

    //    ManageSQL ms = new ManageSQL();
    //    ArrayList data = new ArrayList();

    //    if (Session["InternetStudyEditYearQuery"] == null || string.IsNullOrEmpty(Session["InternetStudyEditYearQuery"].ToString()))
    //        SearchType(BaseClass.NowYear);
    //    else
    //        SearchType(Convert.ToInt32(Session["InternetStudyEditYearQuery"].ToString()));

    //    if (ms.GetAllColumnData(Query, data))
    //    {

    //        LbCompleted.Text = "<table style='width:750px;'>";
    //        LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
    //        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
    //        LbCompleted.Text += "No</td>";
    //        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
    //        LbCompleted.Text += "名稱</td>";
    //        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
    //        LbCompleted.Text += "完成閱讀期限</td>";
    //        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
    //        LbCompleted.Text += "新增</td>";
    //        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
    //        LbCompleted.Text += "修改</td>";
    //        LbCompleted.Text += "</tr>";

    //        if (data.Count > 0)
    //        {

    //        }
    //        else
    //        {
    //            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
    //            LbCompleted.Text += "<td colspan = '5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
    //            LbCompleted.Text += "今年度您還沒有新增，請按下新增年度開始</td>";
    //            LbCompleted.Text += "</tr>";
    //        }
    //        LbCompleted.Text += "</table>";
    //        Session["InternetStudyEditYearQuery"] = "";
    //    }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
        //    Response.Redirect("SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("2"))
        //    Response.Redirect("SessionOut.aspx");
        
        if (!IsPostBack)
        {
            if (Session["InternetStudyEditYearQuery"] != null)
                Query = Session["InternetStudyEditYearQuery"].ToString();
            else
                SearchType(BaseClass.NowYear);
            LoadInternetStudy(1);
        }
    }

    private void SearchType(int QuestionClassYear)
    {
        Query = "select InternetStudy.QuestionClassID, InternetStudy.QuestionClassYear, InternetStudy.ClassID, InternetStudy.ClassName, " +
                "InternetStudy.Deadline, InternetStudy.QuestionAddedComplete from InternetStudy " +
                "where InternetStudy.QuestionClassYear = '" + QuestionClassYear + "'";
    }

    private void SearchType(int Low, int High)
    {
        Query = "select InternetStudy.QuestionClassID, InternetStudy.QuestionClassYear, InternetStudy.ClassID, InternetStudy.ClassName, " +
                "InternetStudy.Deadline, InternetStudy.QuestionAddedComplete from InternetStudy " +
                "where InternetStudy.QuestionClassYear between '" + Low + "' AND '" + High + "'";
    }

    private void LoadInternetStudy(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "No</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "名稱</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "完成閱讀期限</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "新增</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "修改</td>";
            LbCompleted.Text += "</tr>";

            LbTotalCount.Text = "共 " + data.Count.ToString() + " 筆";

            if (data.Count > 0)
            {
                //Setting pagings
                Page = data.Count / 10;

                if (data.Count % 10 != 0)
                    Page++;

                //Paging
                DdlPageSelect.Items.Clear();

                for (int j = 1; j <= Page; j++)
                {
                    DdlPageSelect.Items.Add(j.ToString());
                }

                DdlPageSelect.SelectedIndex = Select - 1;

                if (Page != 0)
                {
                    PageOrder.Text = Select.ToString() + " / " + Page.ToString();
                }

                Flag = 0;

                Count = (Select - 1) * 10;
                int Max = 0;
                if (Count + 10 < data.Count)
                {
                    Max = Count + 10;
                }
                else
                {
                    Max = data.Count;
                }

                for (int i = Count; i < Max; i++)
                {

                    if ((Flag % 2) == 1)
                        LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                    else
                        LbCompleted.Text += "<tr align='center'>";

                    string EncryptQuestionClassID = GetEncryptionString(QuestionClassID, ((string[])(data[i]))[0]);
                    string EncryptQuestionClassYear = GetEncryptionString(QuestionClassYear, ((string[])(data[i]))[1]);
                    string EncryptClassID = GetEncryptionString(ClassID, ((string[])(data[i]))[2]);

                    bool IsAdded = false, DBAddedComplete = false;
                    IsAdded = bool.TryParse(((string[])(data[i]))[5], out DBAddedComplete);

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
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

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[4].Split(' ')[0] + "</td>";

                    //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //LbCompleted.Text += "<a href='InternetStudyEditAddClass.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";

                    //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //LbCompleted.Text += "<a href='InternetStudyEditModify.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";

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

                    Flag++;
                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan = '5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += "此年度您還沒有新增，請按下新增年度開始</td>";
                LbCompleted.Text += "</tr>";

                LbTotalCount.Text = "共 0 筆";
                PageOrder.Text = "0 / 0";
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

    private bool AddClassData()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        BaseClass bc = new BaseClass();
        for (int i = 0; i < ClassMaxNumbers; i++)
        {
            Query = "insert into InternetStudy (QuestionClassYear, ClassID, ClassName, Deadline, ClassDescription, PassScore, QuestionURL, QuestionAddedComplete) VALUES ('" +
                    TbAddYear.Text + "','" +
                    i + "','" +
                    " N / A" + "','" +
                    "2014-12-31 00:00:00" + "','" +
                    "" + "','" +
                    "0" + "','" +
                    "" + "','" +
                    "False" + "')";
            if (!ms.WriteData(Query, sb))
                return false;
            sb.Clear();
        }
        return true;
    }

    private void AddYearQuestionnaire()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        BaseClass bc = new BaseClass();
        int YearNumber = -1;

        if(TbAddYear.Text == "")
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('請輸入年份後再按下確定');", true);
        else if (Int32.TryParse(TbAddYear.Text, out YearNumber))
        {
            string query = "select count(QuestionClassYear) from InternetStudy where QuestionClassYear='" + YearNumber + "'";
            if (ms.GetRowNumbers(query, sb))
            {
                if (Convert.ToInt32(sb.ToString()) == 0)
                {
                    sb.Clear();
                    if (AddClassData())
                    {
                        Session["QuestionClassYear"] = TbAddYear.Text;
                        Response.Redirect("InternetStudyEditAddYear.aspx");
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('您輸入的年份目前已存在');", true);
                sb.Clear();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('請輸入數字');", true);
        }
    }

    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 使用者一定要有大於10筆的資料，才有足更能力去選擇第二頁、第三頁，故這裡可不判斷是否為空，因為為空時，使用者也無法做選擇頁面的操作
        Query = Session["InternetStudyEditYearQuery"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }

    protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibt = (ImageButton)sender;
        if (ibt.ID == "ImgBtnSearch")
        {
            BaseClass bc = new BaseClass();
            int Low = -1, High = -1;
            if (string.IsNullOrEmpty(TbYearA.Text) && string.IsNullOrEmpty(TbYearB.Text))
            {
                SearchType(BaseClass.NowYear);
            }
            else if (Int32.TryParse(TbYearA.Text, out Low) && Int32.TryParse(TbYearB.Text, out High))
            {
                if (Low > High)
                    bc.swap(ref Low, ref High);
                SearchType(Low, High);
            }
            else if (Int32.TryParse(TbYearA.Text, out Low))
            {
                SearchType(Low);
            }
            else if (Int32.TryParse(TbYearB.Text, out High))
            {
                SearchType(High);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('請輸入數字');", true);
                return;
            }
            LoadInternetStudy(1);
            Session["InternetStudyEditYearQuery"] = Query;
            TbYearA.Text = "";
            TbYearB.Text = "";
        }
        else if (ibt.ID == "ImgBtnAddYear")
        {
            AddYearQuestionnaire();
        }
    }
}