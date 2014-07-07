using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamScoreViewDimension : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionYear = "Year";
    private const string QuestionCycle = "Cycle";
    private const string QuestionDimension = "Dimension";
    private string Year = string.Empty;
    private string Cycle = string.Empty;
    private string ClassID = "ClassID";
    private int Score = 0;

    public string backgroundImage = Resources.Resource.ImgUrlBackground;


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || string.IsNullOrEmpty(Request["Year"]) || string.IsNullOrEmpty(Request["Cycle"]))
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

        LbSchoolNo.Text = Resources.Resource.TipKPISchoolNo + Session["UserID"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Year = Request["Year"].ToString();
        Cycle = Request["Cycle"].ToString();

        if (!IsPostBack)
        {
            if (Session["KPIExamScoreViewDimensionQuery"] != null)
                Query = Session["KPIExamScoreViewDimensionQuery"].ToString();
            else
                SearchType();
            LoadInternetStudy(1);
        }
        LbSchoolName.Text = Session["schoolName"].ToString();
        LbSchoolScoreLevel.Text = Session["ScoreLevel"].ToString();
        LbRealScore.Text = Score.ToString();
        LbYear.Text = Year;
        LbCycle.Text = Cycle;

    }

    private bool getKPIMainRecordID(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select KPIRecordMain.ID from KPIRecordMain where KPIYear = '" + Year + "' and Cycle = '" + Cycle + "' and KPIRecordMain.SchoolName = N'" + Session["schoolName"].ToString() + "' ";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getKPIMainRecordID(sb);

        Query = "select KPIDimensionsNameMapping.DimensionsName, KPIRecordDimensionsScore.TotalScore, KPIRecordDimensionsScore.ScoreLevel, KPIRecordDimensionsScore.IsFinish, KPIDimensionsNameMapping.DimensionsID " +
                "from KPIDimensionsNameMapping " +
                "left join KPIRecordDimensionsScore on KPIRecordDimensionsScore.DimensionID = KPIDimensionsNameMapping.DimensionsID " +
                "and KPIRecordDimensionsScore.ID ='" + sb.ToString() + "' " +   
                "left join KPIRecordMain on KPIRecordMain.ID = KPIRecordDimensionsScore.ID " +
                "where KPIRecordMain.SchoolName = N'" + Session["schoolName"].ToString() + "' " +
                "order by KPIDimensionsNameMapping.DimensionsID asc";
    }

    private bool getDimensionRange(ArrayList data)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select dimensionsID, dimensionsName from KPIDimensionsNameMapping";
        if (ms.GetAllColumnData(query, data))
        {
            return true;
        }
        return false;
    }

    private void LoadInternetStudy(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();
        ArrayList DimensionRange = new ArrayList();

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            if (!getDimensionRange(DimensionRange))
            {
                goto NODATA;
            }
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiSN + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKPIDimensionName + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKPITotalScore + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiLevel + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
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
                Score = 0;
                int i = 0;
                for (int j = 0 ; j < DimensionRange.Count ; j++)
                {
                    string[] domainid = (string[])DimensionRange[j];

                    if ((Flag % 2) == 1)
                        LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                    else
                        LbCompleted.Text += "<tr align='center'>";

                    string EncryptYearID = GetEncryptionString(QuestionYear, Year);
                    string EncryptCycleID = GetEncryptionString(QuestionCycle, Cycle);
                    string EncryptDimensionID = GetEncryptionString(QuestionDimension, domainid[0]);

                    
                    /** 沒有做過的問卷都會跑到這 */
                    if (i >= data.Count || !domainid[0].Equals(((string[])(data[i]))[4]))
                    {
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += (j + 1).ToString() + "<font color='red'>*</font>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += domainid[1] + "</td>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "0" + "</td>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "0" + "</td>";
                        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                        LbCompleted.Text += "<a href='KPIExamScoreViewDomain.aspx?" + EncryptYearID + "&" + EncryptCycleID + "&" + EncryptDimensionID + "'>" + Resources.Resource.TipKPIView + "</a>";
                        LbCompleted.Text += "</td>";
                        LbCompleted.Text += "</tr>";
                        Flag++;
                        continue;
                    }

                    if ((Flag % 2) == 1)
                        LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                    else
                        LbCompleted.Text += "<tr align='center'>";


                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += (j+1).ToString() + (((((string[])(data[i]))[3]).ToString().ToLower().Equals("false"))?"<font color='red'>*</font>":"") + "</td>";


                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += ((string[])(data[i]))[0] + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[1]) ? "0" : ((string[])(data[i]))[1] + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[2]) ? "0" : ((string[])(data[i]))[2] + "</td>";

                    Score += Convert.ToInt32(string.IsNullOrEmpty(((string[])(data[i]))[1]) ? "0" : ((string[])(data[i]))[1]);

                    bool isBool = false;
                    bool isComplete = false;
                    isBool = bool.TryParse((((string[])(data[i]))[3]), out isComplete);
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += "<a href='KPIExamScoreViewDomain.aspx?" + EncryptYearID + "&" + EncryptCycleID + "&" + EncryptDimensionID + "'>" + Resources.Resource.TipKPIView + "</a>";
                    LbCompleted.Text += "</td>";

                    LbCompleted.Text += "</tr>";

                    Flag++;
                    i++;
                    
                }
                goto FINALLY;
            }
        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan = '5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKPINoAnswer + "</td>";
            LbCompleted.Text += "</tr>";

            LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
            PageOrder.Text = "0 / 0";
        FINALLY:
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
        Query = Session["KPIExamScoreViewDimensionQuery"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPIExamScoreView.aspx");
    }
}