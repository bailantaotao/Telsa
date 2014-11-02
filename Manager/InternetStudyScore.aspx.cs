using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyScore : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";
    //private bool IsMingDer = false;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");

        LoadProvince();
        if (!IsPostBack)
        {
            if (Session["InternetStudyYearQuery"] != null)
                Query = Session["InternetStudyYearQuery"].ToString();
            else
                SearchType(BaseClass.NowYear);
            Session["InternetStudyYearQuery"] = Query;

            // will comming when...
            // 1. 使用者按下了查詢，此時page會歸0

            if (Session["InternetStudyEditDataPage"] != null)
                LoadInternetStudy(Convert.ToInt32(Session["InternetStudyEditDataPage"]));
            // will comming when...
            // 1. 使用者第一次選擇頁數
            // 2. 第一次進到此頁面
            else
            {
                LbTotalCount.Text = "0";
                PageOrder.Text = "0 / 0";
                LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void SearchType()
    {
        Query = "select QuestionClassYear, Count(QuestionAddedComplete) from InternetStudy where QuestionAddedComplete='true' group by QuestionClassYear";
    }

    private void SearchType(int QuestionClassYear)
    {
        Query = "select InternetStudy.QuestionClassYear, Count(QuestionAddedComplete) from InternetStudy where InternetStudy.QuestionAddedComplete='true' AND " +
                "InternetStudy.QuestionClassYear='" + QuestionClassYear + "' " + "group by QuestionClassYear";
    }
    private void SearchType(int Low, int High)
    {
        Query = "select InternetStudy.QuestionClassYear, Count(QuestionAddedComplete) from InternetStudy where InternetStudy.QuestionAddedComplete='true' AND " +
                "InternetStudy.QuestionClassYear between '" + Low + "' AND '" + High + "'" + " group by QuestionClassYear";
    }

    private bool GetCompleteQuestionnaire(ArrayList data, ManageSQL ms)
    {
        if (ms.GetAllColumnData(Query, data))
        {
            return true;
        }
        return false;
    }
    private void LoadProvince()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select area.name from area where ID <= 31 order by id asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlProvince.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlProvince.Items.Add("None");
            return;
        }

        foreach (string[] province in data)
        {
            DdlProvince.Items.Add(province[0]);
        }
    }

    private void LoadInternetStudy(int Select)
    {

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();
        // 找出已新增完成的問卷年分，以及是否10筆皆完成
        // select InternetStudy.QuestionClassYear, Count(QuestionAddedComplete) from InternetStudy where InternetStudy.QuestionAddedComplete='true' group by QuestionClassYear


        LbCompleted.Text = "<table style='width:700px;'>";
        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;'>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipYears + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipSchool + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipSchoolMaster + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipFinishRate + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipPassClass + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipUnPassClass + "</td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipNotify + "</td>";
        LbCompleted.Text += "</tr>";

        // step.1 找出目前資料庫所有已存在的問卷年分
        if (!GetCompleteQuestionnaire(data, ms) && data.Count > 0)
        {
            NoData();
            return;
        }

        // step.2 找出該問卷年分裡，已新增完成的年份
        ArrayList ALYear = new ArrayList();
        if (!GRTenQuestionnaire(data, ALYear))
        {
            NoData();
            return;
        }

        // step.3 依據年分，找出question class id, class id
        Hashtable HTYearQuestion = new Hashtable();
        if (!GetQuestionContent(ALYear, HTYearQuestion))
        {
            NoData();
            return;
        }

        // step.4 撈出已作答之使用者
        ArrayList UserData = new ArrayList();
        if (!GetUserAnswerData(UserData))
        {
            NoData();
            return;
        }

        // step.5 比對各年分裡的資料，對應到的使用者答案內容
        if (!ListData(HTYearQuestion, UserData, Select))
        {
            NoData();
            return;
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

    private void NoData()
    {
        LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4;'>";
        LbCompleted.Text += "<td colspan = '7' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
        LbCompleted.Text += "</tr>";

        LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
        PageOrder.Text = "0 / 0";
        LbCompleted.Text += "</table>";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="OriginData"></param>
    /// <param name="YearData"></param>
    /// <returns>false- 表示沒有半個年份的問卷是有10筆新增完成的</returns>
    /// <returns>true- 表示至少有一年的問卷是有10筆新增完成的</returns>
    private bool GRTenQuestionnaire(ArrayList OriginData, ArrayList YearData)
    {
        bool IsFound = false;
        for (int i = 0; i < OriginData.Count; i++)
        {
            int digit = -1;
            bool isDigit = Int32.TryParse(((string[])OriginData[i])[1], out digit);
            if (isDigit)
            {
                if (digit == 10)
                {
                    YearData.Add(((string[])OriginData[i])[0]);
                    IsFound = true;
                }
            }
        }
        return IsFound;
    }
    /// <summary>
    /// 取得每一年的問卷資料內容，每一年共有10份問卷
    /// </summary>
    /// <param name="YearData"></param>
    /// <param name="YearCollection"></param>
    /// <returns>false- 資料庫回傳錯誤</returns>
    /// <returns>true- 全數加入至Hashtable</returns>
    private bool GetQuestionContent(ArrayList YearData, Hashtable YearCollection)
    {
        ManageSQL ms = new ManageSQL();
        for (int i = 0; i < YearData.Count; i++)
        {
            ArrayList QuestionData = new ArrayList();
            Query = "select QuestionClassID, ClassID, ClassName, PassScore from InternetStudy where QuestionClassYear = '" + ((string)YearData[i]) + "' order by QuestionClassYear desc";
            if (ms.GetAllColumnData(Query, QuestionData))
            {
                YearCollection.Add(((string)YearData[i]), QuestionData);
            }
            else
            {
                return false;
            }
        }
        return true;

    }

    private bool GetUserAnswerData(ArrayList UserData)
    {
        ManageSQL ms = new ManageSQL();
        if (Session["ProvinceSelect"] != null && Session["ProvinceSelect"].ToString().Equals("True"))
        {
            if (DdlProvince.SelectedValue.Equals(Resources.Resource.TipPlzChoose))
            {
                Query = "select InternetStudyUserAnswer.UserID, Account.UserName, Account.School " +
                        "from InternetStudyUserAnswer left join Account on Account.UserID = InternetStudyUserAnswer.UserID " +
                        "group by InternetStudyUserAnswer.UserID, Account.UserName, Account.School";
            }
            else
            {
                Query = "select InternetStudyUserAnswer.UserID, Account.UserName, Account.School " +
                        "from InternetStudyUserAnswer left join Account on Account.UserID = InternetStudyUserAnswer.UserID " +
                        "left join area on area.id = Account.Zipcode " +
                        "where area.name like N'%" + DdlProvince.SelectedValue + "%' " +
                        "group by InternetStudyUserAnswer.UserID, Account.UserName, Account.School, area.name";
            }
        }
        else
        {
                Query = "select InternetStudyUserAnswer.UserID, Account.UserName, Account.School " +
                        "from InternetStudyUserAnswer left join Account on Account.UserID = InternetStudyUserAnswer.UserID " +
                        "group by InternetStudyUserAnswer.UserID, Account.UserName, Account.School";
        }


        if (ms.GetAllColumnData(Query, UserData))
        {
            if (UserData.Count == 0)
                return false;
        }
        else
        {
            return false;
        }
        return true;
    }

    private bool ListData(Hashtable YearCollection, ArrayList UserData, int Select)
    {
        ManageSQL ms = new ManageSQL();
        int CompleteBase = 10;
        int CompleteNumbers = 0;
        int DataCount = 0;

        Count = (Select - 1) * 10;

        if (YearCollection.Count > 0)
        {
            foreach (DictionaryEntry entry in YearCollection)
            {
                // QuestionClassID, ClassID, ClassName, PassScore
                ArrayList YearData = (ArrayList)entry.Value;  //每一年的問卷內容，共10筆



                // 調出每一個user該年度所填寫的問卷
                foreach (string[] saUserData in UserData)
                {
                    DataCount++;

                    if (Count < DataCount && DataCount < (Count + 10))
                    {

                        Query = "select InternetStudy.QuestionClassID, InternetStudy.ClassID, InternetStudyUserAnswer.TotalScore " +
                                "from InternetStudy " +
                                "left join InternetStudyUserAnswer on InternetStudyUserAnswer.QuestionClassID = InternetStudy.QuestionClassID " +
                                "left join Account on Account.UserID = InternetStudyUserAnswer.UserID " +
                                "where InternetStudy.QuestionClassYear = '" + entry.Key + "' and Account.UserID = '" + saUserData[0] + "' " +
                                "order by InternetStudy.ClassID desc";

                        LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += entry.Key + "</td>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += saUserData[2] + "</td>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += saUserData[1] + "</td>";

                        string Pass = string.Empty;
                        string UnPass = string.Empty;
                        ArrayList UserAnswer = new ArrayList();
                        int PassNumber = 0;
                        int UnPassNumber = 0;

                        if (ms.GetAllColumnData(Query, UserAnswer))
                        {
                            if (UserAnswer.Count > 0)
                            {
                                for (int i = 0; i < YearData.Count; i++)
                                {
                                    for (int j = 0; j < UserAnswer.Count; j++)
                                    {
                                        int MaxScore = GetUserMaxScore(UserAnswer, ((string[])YearData[i])[0]);
                                        //找到相同的QuestionClassID代表使用者有作答
                                        if (((string[])YearData[i])[0].Equals(((string[])UserAnswer[j])[0]))
                                        {
                                            CompleteNumbers++;

                                            // 使用者不及格XD
                                            if (MaxScore < Convert.ToInt32(((string[])YearData[i])[3]))
                                            {
                                                UnPass += (((string[])YearData[i])[0]) + ",";
                                                UnPassNumber++;
                                            }
                                            //使用者及格
                                            else
                                            {
                                                Pass += (((string[])YearData[i])[0]) + ",";
                                                PassNumber++;
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        UnPass = (UnPass.Length > 0) ? UnPass.Substring(0, UnPass.Length - 1) : UnPass;
                        Pass = (Pass.Length > 0) ? Pass.Substring(0, Pass.Length - 1) : Pass;

                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += CompleteNumbers + " / " + CompleteBase + "</td>";

                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        //LbCompleted.Text += "<a href='ViewInternetStudyScore.aspx?" + "Pass=" + Pass + "'>" + "Click" + "</a></td>";
                        LbCompleted.Text += "<a href='#' onclick=\"window.open('ViewScore.aspx?" + "Pass=" + Pass + "&SM=" + saUserData[0] + "', '檢視科目', config='height=500,width=500');\">" + PassNumber + "</a></td>";

                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        //LbCompleted.Text += "<a href='ViewInternetStudyScore.aspx?" + "UnPass=" + UnPass + "'>" + "Click" + "</a></td>";
                        LbCompleted.Text += "<a href='#' onclick=\"window.open('ViewScore.aspx?" + "UnPass=" + UnPass + "&SM=" + saUserData[0] + "', '檢視科目', config='height=500,width=500');\">" + UnPassNumber + "</a></td>";

                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        //LbCompleted.Text += "<a href='ViewInternetStudyScore.aspx?" + "UnPass=" + UnPass + "'>" + "Click" + "</a></td>";
                        LbCompleted.Text += "<a href='#' onclick=\"window.open('MsgNotify.aspx?" + "SM=" + saUserData[0] + "', '', config='height=500,width=700');\">" + "Click" + "</a></td>";


                        // initialzation
                        CompleteNumbers = 0;
                    }
                }

            }
        }
        else
        {
            return false;
        }

        DataPage = DataCount / 10;

        if (DataCount % 10 != 0)
            DataPage++;

        //Paging
        DdlPageSelect.Items.Clear();

        for (int j = 1; j <= DataPage; j++)
        {
            DdlPageSelect.Items.Add(j.ToString());
        }

        DdlPageSelect.SelectedIndex = Select - 1;

        if (DataPage != 0)
        {
            PageOrder.Text = Select.ToString() + " / " + DataPage.ToString();
        }

        return true;
    }

    private int GetUserMaxScore(ArrayList UserAnswerTable, String QuestionnireID)
    {
        int MaxScore = -1;
        foreach (string[] table in UserAnswerTable)
        {
            if (string.IsNullOrEmpty(table[2]))
                continue;
            if (table[0].Equals(QuestionnireID))
            {
                MaxScore = Math.Max(MaxScore, Convert.ToInt32(table[2]));
            }
        }
        return MaxScore;
    }

    private void CheckSearchType()
    {
        BaseClass bc = new BaseClass();
        int Low = -1, High = -1;
        if (string.IsNullOrEmpty(TbYearA.Text) && string.IsNullOrEmpty(TbYearB.Text))
        {
            if (!DdlProvince.SelectedValue.Equals(Resources.Resource.TipPlzChoose))
            {
                SearchType();
            }
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMNoNumber + "');", true);
            return;
        }
        Session["InternetStudyYearQuery"] = Query;
        Session["InternetStudyEditDataPage"] = 1;
        LoadInternetStudy(1);


        TbYearA.Text = "";
        TbYearB.Text = "";
    }

    protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibt = (ImageButton)sender;
        if (ibt.ID == "ImgBtnSearch")
        {
            CheckSearchType();
        }
    }

    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        Query = Session["InternetStudyYearQuery"].ToString();
        Session["InternetStudyEditDataPage"] = DdlPageSelect.SelectedIndex + 1;
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedValue.Equals(Resources.Resource.TipPlzChoose))
        {
            Session["ProvinceSelect"] = "False";
            LbCompleted.Text = "";
            LbTotalCount.Text = "0";
            PageOrder.Text = "0 / 0";
            LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers;
            DdlPageSelect.Items.Clear();
        }
        else
        {
            Session["ProvinceSelect"] = "True";
            Session["ProvinceSelectValue"] = DdlProvince.SelectedValue;
            CheckSearchType();
        }
        
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}