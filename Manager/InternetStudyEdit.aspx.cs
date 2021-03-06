﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEdit : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
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

    }

    protected void Page_Load(object sender, EventArgs e)
    {
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
            LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += "No</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipClassName + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipDeadline + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipAdd + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipEdit + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipComment + "</td>";
            LbCompleted.Text += "</tr>";

            LbTotalCount.Text = Resources.Resource.TipTotal + " " + data.Count.ToString() + " " + Resources.Resource.TipNumbers;

            if (data.Count > 0)
            {
                //Setting pagings
                DataPage = data.Count / 10;

                if (data.Count % 10 != 0)
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
                    LbCompleted.Text += (i + 1).ToString() + "</td>";
                    

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    // 如果已經新增過該類別之問題，才可以做檢視的動作
                    if (DBAddedComplete)
                    {
                        LbCompleted.Text += "<a href='InternetStudyEditDisplay.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'>" + ((string[])(data[i]))[3] + "</a></td>";
                    }
                    else
                    {
                        LbCompleted.Text += "<a href='#'>" + ((string[])(data[i]))[3] + "</a></td>";
                    }

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

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                    LbCompleted.Text += "<a href='InternetStudyComment.aspx?" + EncryptQuestionClassID + "'>" + Resources.Resource.TipComment + "</a></td>";


                    LbCompleted.Text += "</tr>";

                    Flag++;
                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan = '6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += Resources.Resource.SMNowYearNoData + "</td>";
                LbCompleted.Text += "</tr>";

                LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
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
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();
        int State = 0;

        Query = "select QuestionClassYear from InternetStudy group by QuestionClassYear order by QuestionClassYear desc";

        if (!ms.GetAllColumnData(Query, data))
            goto ADDNEYQUESTIONNAIRE;

        if (data.Count == 0)
        {
            goto ADDNEYQUESTIONNAIRE;
        }
        State = 1;
        // 1. 找出最近的年度
        StringBuilder RefYear = new StringBuilder();
        if (!GetRecentYear(data, RefYear))
        {
            goto ADDNEYQUESTIONNAIRE;
        }
        State = 2;
        // 2. 取得該年度問卷的基本資料
        Query = "select QuestionClassID, QuestionClassYear, ClassID, ClassName, DeadLine, ClassDescription, PassScore, QuestionURL, QuestionAddedComplete from InternetStudy " +
                "where QuestionClassYear ='" + RefYear.ToString() + "'";
        if (!ms.GetAllColumnData(Query, data))
        {
            goto ADDNEYQUESTIONNAIRE;
        }
        // 將資料儲存到資料庫
        if (!CopyInternetStudyData(data))
        {
            goto ADDNEYQUESTIONNAIRE;
        }

        State = 3;
        // 3. 取得參考年度問卷10提的ID
        ArrayList QuestionID = new ArrayList();
        Query = "Select QuestionClassID from InternetStudy where QuestionClassYear ='" + RefYear.ToString() + "' order by QuestionClassID asc";
        if (!ms.GetAllColumnData(Query, QuestionID))
        {
            goto ADDNEYQUESTIONNAIRE;
        }

        // 4. 取得新增年度問卷10提的ID
        ArrayList ThisYearQuestionID = new ArrayList();
        Query = "Select QuestionClassID from InternetStudy where QuestionClassYear ='" + TbAddYear.Text.Trim() + "' order by QuestionClassID asc";
        if (!ms.GetAllColumnData(Query, ThisYearQuestionID))
        {
            goto ADDNEYQUESTIONNAIRE;
        }

        State = 4;
        // 4. 取得問卷的題目內容、類型
        if (!CopyInternetStudyDataContent(data, QuestionID, ThisYearQuestionID))
        {
            goto ADDNEYQUESTIONNAIRE;
        }

        State = 5;
        // 5. 取得問卷的答案選項
        if (!CopyInternetStudyAnswerItem(data, QuestionID, ThisYearQuestionID))
        {
            goto ADDNEYQUESTIONNAIRE;
        }

        return true;
        
        ADDNEYQUESTIONNAIRE:
        
        if(2 < State)
        {
            Query = "delete from InternetStudy where QuestionClassYear='" + TbAddYear.Text.Trim() + "'";
            ms.WriteData(Query, sb);
        }
        for (int i = 0; i < ClassMaxNumbers; i++)
        {
            Query = "insert into InternetStudy (QuestionClassYear, ClassID, ClassName, Deadline, ClassDescription, PassScore, QuestionURL, QuestionAddedComplete) VALUES ('" +
                    TbAddYear.Text + "','" +
                    i + "','" +
                    " N / A" + "','" +
                    TbAddYear.Text + "-12-31" + "','" +
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

    private bool GetRecentYear(ArrayList YearTable, StringBuilder Status)
    {
        int UserInputYear = Convert.ToInt32(TbAddYear.Text);
        foreach (string[] Year in YearTable)
        {
            if (Convert.ToInt32(Year[0]) < UserInputYear)
            {
                Status.Append(Year[0]);
                return true;
            }
        }
        return false;
    }

    private bool CopyInternetStudyData(ArrayList QuestionData)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder STATUS = new StringBuilder();
        foreach(string[] data in QuestionData)
        {
            Query = "insert into InternetStudy (QuestionClassYear, ClassID, ClassName, Deadline, ClassDescription, PassScore, QuestionURL, QuestionAddedComplete) VALUES (N'" +
                    TbAddYear.Text + "',N'" +
                    data[2] + "',N'" +
                    data[3] + "',N'" +
                    TbAddYear.Text + "-12-31" + "',N'" +
                    data[5] + "',N'" +
                    data[6] + "',N'" +
                    data[7] + "',N'" +
                    data[8] + "')";
            if (!ms.WriteData(Query, STATUS))
                return false;
        }
        return true;
    }

    private bool CopyInternetStudyDataContent(ArrayList _data, ArrayList QuestionID, ArrayList ThisYearQuestionID)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder STATUS = new StringBuilder();
        int Index = 0;
        foreach(string[] id in QuestionID)
        {

            Query = "select QuestionClassID, QuestionNo, QuestionContent, IsSingleSelection, Score, Answer from InternetStudyQuestionContent " +
                "where QuestionClassID='" + id[0] + "'";

            if (!ms.GetAllColumnData(Query, _data))
                return false;

            foreach (string[] Content in _data)
            {
                Query = "insert into InternetStudyQuestionContent (QuestionClassID, QuestionNo, QuestionContent, IsSingleSelection, Score, Answer) VALUES (N'" +
                        ((string[])ThisYearQuestionID[Index])[0] + "',N'" +
                        Content[1] + "',N'" +
                        Content[2] + "',N'" +
                        Content[3] + "',N'" +
                        Content[4] + "',N'" +
                        Content[5] + "')";

                if (!ms.WriteData(Query, STATUS))
                    return false;
            }
            Index++;
            
        }
        return true;
    }

    private bool CopyInternetStudyAnswerItem(ArrayList _data, ArrayList _QuestionID, ArrayList ThisYearQuestionID)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        int Index = 0;
        foreach (string[] id in _QuestionID)
        {
            Query = "select QuestionClassID, QuestionNo, QuestionAnswerNumbers, AnswerContent from InternetStudyQuestionItem " +
                    "where QuestionClassID ='" + id[0] + "'";

            if (!ms.GetAllColumnData(Query, _data))
                return false;
            foreach (string[] content in _data)
            {
                Query = "insert into InternetStudyQuestionItem (QuestionClassID, QuestionNo, QuestionAnswerNumbers, AnswerContent) VALUES (N'" +
                        ((string[])ThisYearQuestionID[Index])[0] + "',N'" +
                        content[1] + "',N'" +
                        content[2] + "',N'" +
                        content[3] + "')";
                if (!ms.WriteData(Query, sb))
                    return false;

            }
            Index++;
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMNoYear + "');", true);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMExistYear + "');", true);
                sb.Clear();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMNoNumber + "');", true);
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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMNoNumber + "');", true);
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
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}