using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamScoreView : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionYear = "Year";
    private const string QuestionCycle = "Cycle";
    private const string ClassID = "ClassID";

    public string backgroundImage = Resources.Resource.ImgUrlBackground;


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
            if (Session["KPIExamScoreViewQuery"] != null)
                Query = Session["KPIExamScoreViewQuery"].ToString();
            else
                SearchType();
            LoadInternetStudy(1);
        }
    }

    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getSchoolName(sb);
        Session["SchoolName"] = sb.ToString();
        
        Query = "select KPIRecordMain.KPIYear, KPIRecordMain.Cycle, KPIDeadline.Deadline, KPIRecordMain.ScoreLevel, KPIRecordMain.isfinish " +
                "from KPIRecordMain " +
                "left join KPIDeadline on KPIRecordMain.KPIYear = KPIDeadline.KPIYear and KPIRecordMain.Cycle = KPIDeadline.Cycle " +
                "where KPIRecordMain.SchoolName = N'" + sb.ToString() + "'";
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
            LbCompleted.Text += Resources.Resource.TipKpiSN + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiYear + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiCycle + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiDeadline + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiLevel + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiState + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiOperation + "</td>";
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

                    string EncryptYearID = GetEncryptionString(QuestionYear, ((string[])(data[i]))[0]);
                    string EncryptCycleID = GetEncryptionString(QuestionCycle, ((string[])(data[i]))[1]);
                    //string EncryptClassID = GetEncryptionString(ClassID, ((string[])(data[i]))[2]);

                    //bool IsAdded = false, DBAddedComplete = false;
                    //IsAdded = bool.TryParse(((string[])(data[i]))[5], out DBAddedComplete);

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";                    
                    LbCompleted.Text += (i + 1).ToString() + "</td>";
                    

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[0] + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[2] + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[3])?"E":((string[])(data[i]))[3] +"</td>";

                    Session["ScoreLevel"] = string.IsNullOrEmpty(((string[])(data[i]))[3]) ? "E" : ((string[])(data[i]))[3];

                    bool isBool = false;
                    bool isComplete = false;
                    isBool = bool.TryParse((((string[])(data[i]))[4]), out isComplete);

                    if (isComplete)
                    {
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += Resources.Resource.TipKPIComplete + "</td>";

                        //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        //LbCompleted.Text += "<a href='KPIExamScoreViewDimension.aspx?" + EncryptYearID + "&" + EncryptCycleID + "'>" + Resources.Resource.TipKPIViewScore + "</a>";
                        //LbCompleted.Text += "</td>";
                    }
                    else
                    {
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                        LbCompleted.Text += Resources.Resource.TipKPIInComplete + "</td>";

                        //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        //LbCompleted.Text += "<a href='#'>" + Resources.Resource.TipKPIViewScore + "</a>";
                        //LbCompleted.Text += "</td>";
                    }
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += "<a href='KPIExamScoreViewDimension.aspx?" + EncryptYearID + "&" + EncryptCycleID + "'>" + Resources.Resource.TipKPIViewScore + "</a>";
                    LbCompleted.Text += "</td>";
                    LbCompleted.Text += "</tr>";

                    Flag++;
                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan = '7' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += Resources.Resource.TipKPINoAnswer + "</td>";
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

    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 使用者一定要有大於10筆的資料，才有足更能力去選擇第二頁、第三頁，故這裡可不判斷是否為空，因為為空時，使用者也無法做選擇頁面的操作
        Query = Session["KPIExamScoreViewQuery"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}