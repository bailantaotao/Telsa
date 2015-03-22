using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_SurveyPreList : System.Web.UI.Page
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
        if (Session["SurveySN"] != null)
            Session.Remove("SurveySN");
        if (Session["SurveyYear"] != null)
            Session.Remove("SurveyYear");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);
        LbSurveySchool.Text = schoolName.ToString();
        LbSurveySchoolID.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {

            if (Session["SurveyList"] != null)
                Query = Session["SurveyList"].ToString();
            else
                SearchType();

            LoadInternetStudy(1);
        }
    }
    private void SearchType()
    {
        Query = "select SN, SurveyYear, Deadline " +
                "from SurveyList";
    }
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        Session["schoolName"] = sb.ToString();
        return true;
    }


    private void LoadInternetStudy(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ArrayList data1 = new ArrayList();
        BaseClass bc = new BaseClass();
        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();

        ArrayList userData = new ArrayList();

        string query = string.Empty;
        string query1 = string.Empty;
        string query2 = string.Empty;
        getSchoolName(schoolName);

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanSN + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "学年" + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "提交有效期限" + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "完成状态" + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.FinishDay + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "</font></td>";
            LbCompleted.Text += "</tr>";

            LbTotalCount.Text = Resources.Resource.TipTotal + " " + data.Count.ToString() + " " + Resources.Resource.TipNumbers;

            if (data.Count == 0)
                goto NODATA;

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

                string userQuery = "select SurveyList.SurveyYear, SurveyListUser.SN, SurveyListUser.SurveyStatus from SurveyListUser " +
                                    "left join SurveyList on SurveyListUser.SurveyListSN = SurveyList.SN " +
                                    "where " +
                                    "SurveyListUser.SurveySchool = N'" + schoolName.ToString() + "' and " +
                                    "SurveyList.SurveyYear = '" + ((string[])(data[i]))[1] + "'";
                ms.GetAllColumnData(userQuery, userData);



                string EncryptSN = GetEncryptionString(SN, ((string[])(data[i]))[0]);
                string EncryptYEAR = GetEncryptionString(YEAR, ((string[])(data[i]))[1]);
                TimeSpan ts = TimeSpan.Zero;
                try
                {
                    DateTime dttx1 = DateTime.Now;
                    DateTime dttx2 = DateTime.Parse(((string[])(data[i]))[2]);
                    ts = dttx1.Subtract(dttx2);
                }
                catch
                { }
                string EncryptMODIFIED = string.Empty;
                if (ts == TimeSpan.Zero)
                    EncryptMODIFIED = GetEncryptionString(MODIFIED, "false");
                else
                    EncryptMODIFIED = GetEncryptionString(MODIFIED, (ts.Days <= 0) ? "true" : "false");
                
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += (i + 1).ToString() + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2].Split(' ')[0] + "</td>";

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                query1 = "select SurveyStatus from SurveyListUser where SurveyYear=" + ((string[])(data[i]))[1] + " and SurveySchool= N'" + schoolName.ToString() + "'";
                ms.GetOneData(query1, sb2);

                if (sb2.ToString() == "True")
                {
                    LbCompleted.Text += "已完成" + "</td>";
                }
                else
                {
                    LbCompleted.Text += "未完成" + "</td>";
                }

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                query2 = "select SurveySubmitTime from SurveyListUser where SurveyYear=" + ((string[])(data[i]))[1] + " and SurveySchool= N'" + schoolName.ToString() + "'";
                ms.GetAllColumnData(query2, data1);
                if (data1.Count > 0)
                {
                    string[] d = (string[])data1[0];
                    LbCompleted.Text += d[0].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotFinish : d[0].Split(' ')[0];
                }

                if (ts.Days <= 0)
                {
                    // 代表還沒到deadline 可填寫問卷
                }
                else
                {
                    //已經到了deadline, 接下來要看使用者是否有資料在裡面
                    if (userData.Count == 0)
                    {
                        // 沒有資料，代表該學校是後來才加進群組的，則提已過期
                        //LbCompleted.Text += Resources.Resource.TipPlanExpired + "</td>";
                    }
                    else
                    {
                        // 有資料，但已經超過deadline, 故還是顯示已提交
                        //LbCompleted.Text += Resources.Resource.TipPlanSubmited + "</td>";
                    }
                }


                if (ts.Days <= 0)
                {
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                    LbCompleted.Text += "<a href='SurveyList.aspx?" + EncryptSN + "&" + EncryptYEAR + "'>";
                    // 代表還沒到deadline 可填寫問卷
                    // 如果是空的，代表使用者還沒填過
                    if (userData.Count == 0)
                    {
                        LbCompleted.Text += "填写";
                    }
                    else
                    {
                        //如果不是空的，則檢查是為true或false   
                        if (((string[])(userData[0]))[2].ToLower().Equals("true"))
                        {
                            //要換到view的頁面
                            LbCompleted.Text += "填写";
                        }
                        else
                        {
                            LbCompleted.Text += Resources.Resource.TipPlanModified;
                        }

                    }
                    LbCompleted.Text += "</a>";
                }
                else
                {
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                    //已經到了deadline, 接下來要看使用者是否有資料在裡面
                    if (userData.Count == 0)
                    {
                        // 沒有資料，代表該學校是後來才加進群組的，則提交已過期
                        LbCompleted.Text += "none";
                    }
                    else
                    {
                        // 有資料，但已經超過deadline, 但裡面資料可能有缺，就靠後面每個function判斷是否有資料了
                        //要換到view的頁面
                        LbCompleted.Text += "<a href='SurveyList.aspx?" + EncryptSN + "&" + EncryptYEAR + "'>" + Resources.Resource.TipPlanView + "</a>";
                    }

                }

                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

    NODATA:
        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
        LbCompleted.Text += "<td colspan = '5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
        LbCompleted.Text += "</tr>";

        LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
        PageOrder.Text = "0 / 0";
    FINALLY:
        LbCompleted.Text += "</table>";

    }

    private string GetEncryptionString(string Tag, string Data)
    {
        //BaseClass bc = new BaseClass();
        //return (Tag + "=" +bc.encryption(Data));
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }
    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 使用者一定要有大於10筆的資料，才有足更能力去選擇第二頁、第三頁，故這裡可不判斷是否為空，因為為空時，使用者也無法做選擇頁面的操作
        Query = Session["SurveyList"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}