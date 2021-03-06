﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_ViewInternetStudyQuestionnaire : System.Web.UI.Page
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
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["ViewInternetStudyYearQuery"] != null)
                Query = Session["ViewInternetStudyYearQuery"].ToString();
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
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += "No</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipClassName + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipDeadline + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipComment + "</td>";
            LbCompleted.Text += "</tr>";
            //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            //LbCompleted.Text += Resources.Resource.TipAdd + "</td>";
            //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            //LbCompleted.Text += Resources.Resource.TipEdit + "</td>";


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

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += (i + 1).ToString() + "</td>";


                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    // 如果已經新增過該類別之問題，才可以做檢視的動作
                    if (DBAddedComplete)
                    {
                        LbCompleted.Text += "<a href='ViewInternetStudyQuestionnaireDetail.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'>" + ((string[])(data[i]))[3] + "</a></td>";
                    }
                    else
                    {
                        LbCompleted.Text += "<a href='#'>" + ((string[])(data[i]))[3] + "</a></td>";
                    }

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[4].Split(' ')[0] + "</td>";

                    //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //LbCompleted.Text += "<a href='InternetStudyEditAddClass.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";

                    //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //LbCompleted.Text += "<a href='InternetStudyEditModify.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";

                    // 如果已經新增過該類別之問題，則只能做修改
                    //if (DBAddedComplete)
                    //{
                    //    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //    LbCompleted.Text += "<a href='#'><img src='../Image/zh-TW/ButtonAddGary.png'></a></td>";
                    //    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //    LbCompleted.Text += "<a href='InternetStudyEditModify.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";
                    //}
                    //else
                    //{
                    //    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //    LbCompleted.Text += "<a href='InternetStudyEditAddClass.aspx?" + EncryptQuestionClassID + "&" + EncryptQuestionClassYear + "&" + EncryptClassID + "'><img src='../Image/zh-TW/ButtonAddBlack.png'></a></td>";

                    //    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    //    LbCompleted.Text += "<a href='#'><img src='../Image/zh-TW/ButtonAddGary.png'></a></td>";
                    //}
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                    LbCompleted.Text += "<a href='InternetStudyComment.aspx?" + EncryptQuestionClassID + "'>" + Resources.Resource.TipComment + "</a></td>";

                    LbCompleted.Text += "</tr>";

                    Flag++;
                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan = '4' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
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

    private bool CopyInternetStudyDataContent(ArrayList _data, ArrayList QuestionID, ArrayList ThisYearQuestionID)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder STATUS = new StringBuilder();
        int Index = 0;
        foreach (string[] id in QuestionID)
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

    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 使用者一定要有大於10筆的資料，才有足更能力去選擇第二頁、第三頁，故這裡可不判斷是否為空，因為為空時，使用者也無法做選擇頁面的操作
        Query = Session["ViewInternetStudyYearQuery"].ToString();
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
            Session["ViewInternetStudyYearQuery"] = Query;
            TbYearA.Text = "";
            TbYearB.Text = "";
        }
    }
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
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