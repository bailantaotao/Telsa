using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamScoreViewDomainDetail : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionYear = "Year";
    private const string QuestionCycle = "Cycle";
    private const string QuestionDimension = "Dimension";
    private const string QuestionSchoolname = "schoolName";
    private const string QuestionScoreLevel = "ScoreLevel";
    private string QuestionDomain = "Domain";
    private string Year = string.Empty;
    private string Cycle = string.Empty;
    private string Dimension = string.Empty;
    private string Domain = string.Empty;
    private string SchoolName = string.Empty;
    private string ScoreLevel = string.Empty;
    private string ClassID = "ClassID";

    public string backgroundImage = Resources.Resource.ImgUrlBackground;


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");
        LbSchoolNo.Text = Resources.Resource.TipKPISchoolNo + getSchoolID();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Year = Request["Year"].ToString();
        Cycle = Request["Cycle"].ToString();
        Dimension = Request["Dimension"].ToString();
        Domain = Request["Domain"].ToString();
        SchoolName = Request["schoolName"].ToString();
        ScoreLevel = Request["ScoreLevel"].ToString();
        if (!IsPostBack)
        {
            SearchType();
            LoadInternetStudy(1);
        }
        LbSchoolName.Text = Request["schoolName"].ToString();
        LbYear.Text = Year;
        LbCycle.Text = Cycle;
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

    private bool getKPIMainRecordID(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select KPIRecordMain.ID from KPIRecordMain where KPIYear = '" + Year + "' and Cycle = '" + Cycle + "' and KPIRecordMain.SchoolName = N'" + Request["schoolName"].ToString() + "' ";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getKPIMainRecordID(sb);

        Query = "select KPIClass.DomainID, KPIClass.ClassID, KPIClass.ClassName, KPIRecordDomainDetail.ClassScore " +
                "from KPIClass  " +
                "left join KPIRecordDomainDetail on KPIClass.DomainID = KPIRecordDomainDetail.DomainID and KPIClass.ClassID = KPIRecordDomainDetail.ClassID " +
                "and KPIRecordDomainDetail.ID ='" + sb.ToString() + "' and KPIRecordDomainDetail.DimensionID = '" + Dimension + "'  and KPIRecordDomainDetail.DomainID = '" + Domain + "'";
    }
    private bool getDimensionRange(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        Query = "select DomainName from KPIDomainNameMapping where DomainID ='" + Domain + "'";
        if (ms.GetOneData(Query, sb))
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

        StringBuilder DomainName = new StringBuilder();

        

        if (ms.GetAllColumnData(Query, data))
        {
            
            LbCompleted.Text = "<table style='width:750px;'>";
            if (!getDimensionRange(DomainName))
            {
                goto NODATA;
            }
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipNo + Domain;
            LbCompleted.Text += Resources.Resource.TipKPIDomain + "- ";
            LbCompleted.Text += DomainName.ToString() + "</td>";            
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKPIScore + "</td>";
            LbCompleted.Text += "</tr>";

            
            

            if (data.Count > 0)
            {

                foreach(string[] tmp in data)
                {
                    if (!tmp[0].Equals(Domain))
                        continue;
                    
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += "(" + tmp[0] + "-" + tmp[1] + ")";
                    LbCompleted.Text += tmp[2] + "</td>";

                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                    LbCompleted.Text += string.IsNullOrEmpty(tmp[3])?"0":tmp[3] + "</td>";
                    LbCompleted.Text += "</tr>";
                    
                }
                goto FINALLY;
            }
        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan = '4' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKPINoAnswer + "</td>";
            LbCompleted.Text += "</tr>";
        FINALLY:
            LbCompleted.Text += "</table>";
        }

    }


    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("KPIExamScoreViewDomain.aspx?" + QuestionYear + "=" + Year + "&" + QuestionCycle + "=" + Cycle + "&" + QuestionDimension + "=" + Dimension + "&" + QuestionSchoolname + "=" + SchoolName + "&" + QuestionScoreLevel + "=" + ScoreLevel );    
    }
    protected void BtnNotify_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        if (getSchoolMaster(sb))
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('MsgNotify.aspx?" + "SM=" + sb.ToString() + "', '', config='height=500,width=700')", true);
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No data');", true);
    }

    private bool getSchoolMaster(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select UserID from Account where School=N'" + Request["schoolName"].ToString() + "'";
        if (ms.GetOneData(query, sb))
        {
            if (string.IsNullOrEmpty(sb.ToString()))
                return false;
            return true;
        }
        return false;

    }
}