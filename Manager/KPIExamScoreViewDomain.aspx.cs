using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamScoreViewDomain : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionYear = "Year";
    private const string QuestionDimension = "Dimension";
    private const string QuestionSchoolname = "schoolName";
    private const string QuestionScoreLevel = "ScoreLevel";
    private string QuestionDomain = "Domain";
    private string Year = string.Empty;
    private string Cycle = string.Empty;
    private string Dimension = string.Empty;
    private string SchoolName = string.Empty;
    private string ScoreLevel = string.Empty;
    private string sn = "-1";

    private string ClassID = "ClassID";

    public string backgroundImage = Resources.Resource.ImgUrlBackground;


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");
        LbSchoolNo.Text = Resources.Resource.TipKPISchoolNo + getSchoolID();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList data = new ArrayList();
        ManageSQL ms = new ManageSQL();
        string query = "select KPIYear, semester from KPIDeadline where SN = '" + Request["Year"].ToString() + "'";
        ms.GetAllColumnData(query, data);
        sn = Request["Year"].ToString();
        if (data.Count > 0)
        {
            Year = ((string[])data[0])[0];
            Cycle = ((string[])data[0])[1];
        }
        Dimension = Request["Dimension"].ToString();
        SchoolName = Request["schoolName"].ToString();
        ScoreLevel = Request["ScoreLevel"].ToString();
        if (!IsPostBack)
        {
            if (Session["KPIExamScoreViewDomainQuery"] != null)
                Query = Session["KPIExamScoreViewDomainQuery"].ToString();
            else
                SearchType();
            LoadInternetStudy(1);
        }

        LbSchoolName.Text = Request["schoolName"].ToString();
        LbYear.Text = Year;
        LbCycle.Text = Cycle;
        LbDimension.Text = getDimensionName();
    }

    private string getSchoolID()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select userid from account where School = N'" + Request["schoolName"].ToString() + "'";
        if (ms.GetOneData(query, sb))
        {
            return sb.ToString();
        }
        return string.Empty;
    }

    private string getDimensionName()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select DimensionsName from KPIDimensionsNameMapping where DimensionsID = '" + Dimension + "'";
        if (ms.GetOneData(query, sb))
        {
            return sb.ToString();
        }
        return "N / A";
    }

    private bool getKPIMainRecordID(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select KPIRecordMain.ID from KPIRecordMain where KPIDeadlineSN = '" + Request["Year"].ToString() + "' and KPIRecordMain.SchoolName = N'" + Request["schoolName"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getKPIMainRecordID(sb);

        Query = "select KPIDomainNameMapping.DomainName, KPIRecordDomainScore.TotalScore, KPIRecordDomainScore.ScoreLevel, KPIRecordDomainScore.DimensionID, KPIDomainNameMapping.DomainID " +
                "from KPIDomainNameMapping " +
                "left join KPIRecordDomainScore  on KPIRecordDomainScore.DomainID = KPIDomainNameMapping.DomainID  " +
                "left join KPIRecordMain on KPIRecordMain.ID = KPIRecordDomainScore.ID " +
                "and KPIRecordDomainScore.ID ='" + sb.ToString() + "' and DimensionID='" + Dimension + "' "+
                "where KPIRecordMain.SchoolName = N'" + Request["schoolName"].ToString() + "' " +
                "order by DomainID asc";
    }
    private bool getDimensionRange(ArrayList data)
    {
        ManageSQL ms = new ManageSQL();
        Query = "select KPIDimensionsDomainMappingTable.DomainID, KPIDomainNameMapping.DomainName from KPIDimensionsDomainMappingTable "+
                "left join KPIDomainNameMapping on KPIDimensionsDomainMappingTable.DomainID = KPIDomainNameMapping.DomainID " + 
                " where DimensionsID ='" + Dimension + "'";
        if (ms.GetAllColumnData(Query, data))
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
            LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiSN + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKPIDomainName + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKPITotalScore + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiLevel + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiOperation + "</td>";
            LbCompleted.Text += "</tr>";

            LbTotalCount.Text = Resources.Resource.TipTotal + " " + data.Count.ToString() + " " + Resources.Resource.TipNumbers;

            
            int i = 0;
            for (int j = 0; j < DimensionRange.Count; j++)
            {
                string[] domainid = (string[])DimensionRange[j];

                if ((Flag % 2) == 1)
                    LbCompleted.Text += "<tr align='center' style='background-color:#B8CBD4'>";
                else
                    LbCompleted.Text += "<tr align='center'>";

                string EncryptYearID = GetEncryptionString(QuestionYear, sn);
                string EncryptDimensionID = GetEncryptionString(QuestionDimension, Dimension);
                string EncryptDomainID = GetEncryptionString(QuestionDomain, domainid[0]);
                string EncryptSchoolname = GetEncryptionString(QuestionSchoolname, Request["schoolName"].ToString());
                string EncryptScoreLevel = GetEncryptionString(QuestionScoreLevel, Request["ScoreLevel"].ToString());

                if (i >= data.Count || !domainid[0].Equals(((string[])(data[i]))[4]))
                {
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += (j + 1).ToString() + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += domainid[1] + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += "0"  + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += "0"  + "</td>";
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += "<a href='KPIExamScoreViewDomainDetail.aspx?" + EncryptYearID + "&" + EncryptDimensionID + "&" + EncryptDomainID + "&" + EncryptSchoolname + "&" + EncryptScoreLevel + "'>" + Resources.Resource.TipKPIView + "</a>";
                    LbCompleted.Text += "</td>";
                    LbCompleted.Text += "</tr>";
                    Flag++;
                    continue;
                }



                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += (j + 1).ToString() + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[0] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[1]) ? "0" : ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[2]) ? "0" : ((string[])(data[i]))[2] + "</td>";

                bool isNotComplete = false;
                isNotComplete = string.IsNullOrEmpty(((string[])(data[i]))[3]);
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<a href='KPIExamScoreViewDomainDetail.aspx?" + EncryptYearID + "&" + EncryptDimensionID + "&" + EncryptDomainID + "&" + EncryptSchoolname + "&" + EncryptScoreLevel + "'>" + Resources.Resource.TipKPIView + "</a>";
                LbCompleted.Text += "</td>";
                //if (isNotComplete)
                //{
                //    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                //    LbCompleted.Text += "<a href='#'>" + Resources.Resource.TipKPIView + "</a>";
                //    LbCompleted.Text += "</td>";
                //}
                //else
                //{
                //    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                //    LbCompleted.Text += "<a href='KPIExamScoreViewDomainDetail.aspx?" + EncryptYearID + "&" + EncryptCycleID + "&" + EncryptDimensionID + "&" + EncryptDomainID + "'>" + Resources.Resource.TipKPIView + "</a>";
                //    LbCompleted.Text += "</td>";
                //}

                LbCompleted.Text += "</tr>";

                Flag++;
                i++;
                    
            }
            PageOrder.Text = "1 / 1";
            goto FINALLY;
        }
    NODATA:
        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
        LbCompleted.Text += "<td colspan = '5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipKPINoAnswer + "</td>";
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
        Query = Session["KPIExamScoreViewDomainQuery"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPIExamScoreViewDimension.aspx?" + QuestionYear + "=" + sn + "&" + QuestionSchoolname + "=" + SchoolName +  "&" + QuestionScoreLevel + "=" + ScoreLevel );    
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}