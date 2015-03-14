using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamMain : System.Web.UI.Page
{
    private const int QuestionMaxNumbers = 10;
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

        SetDdlDefault(DdlDimension);
        if (Session["DdlDimension_SelectIndex"] != null)
        {
            ListDdlDomains();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (getCurrentKPIQSN() == MANAGER_HAVE_YET_TO_QUESTIONNAIRE)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('新學年、學期尚未開放數據錄入');", true);
                DdlDimension.Visible = false;
                DdlDomain.Visible = false;
                Label2.Visible = false;
                LbSubmitCount.Visible = false;
                BtnStartInput.Visible = false;
            }
            else {
                setSubmitedCount();
            }
        }
    }

    private void SetDdlDefault(DropDownList ddl)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select * from KPIDimensionsNameMapping";

        if (ms.GetAllColumnData(query, data))
        {
            foreach (string[] tmp in data)
            {
                DdlDimension.Items.Add(new ListItem(tmp[1], tmp[0]));
            }
        }
        else
        {
            DdlDimension.Items.Add(Resources.Resource.TipKPIError);
        }
    }

    private const int SUCCESS = 0;
    private const int MANAGER_HAVE_YET_TO_QUESTIONNAIRE = 1;

    private int getCurrentKPIQSN()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ArrayList data = new ArrayList();
        string today = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        // smaller than today SN will be showed
        string query = "select SN, DeadLine, KPIYear, Semester from KPIDeadline where DeadLine > Convert(datetime, '" + today + "') order by SN asc";
        ms.GetAllColumnData(query, data);

        if (data.Count == 1)
        {
            Session["KPISN"] = ((string[])data[0])[0];
            return SUCCESS;
        }

        if (data.Count > 1)
        {
            double target = 10000.0;
            int tag = -99;
            for(int i = 0 ; i < data.Count; i++)
            {
                string[] deadline = (string[])data[i];
                DateTime historyDeadline = Convert.ToDateTime(deadline[1]);
                TimeSpan diff = historyDeadline.Subtract(Convert.ToDateTime(today));
                double diffday = diff.TotalDays;
                if (diffday < target)
                {
                    target = diffday;
                    tag = i;
                }
            }
            Session["KPISN"] = ((string[])data[tag])[0];
            return SUCCESS;
        }

        return MANAGER_HAVE_YET_TO_QUESTIONNAIRE;
    }

    /*private void setSubmitedCount()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ArrayList data = new ArrayList();
        getSchoolName(sb);
        string schoolName = sb.ToString();
        string query = "select count(schoolName) from KPIRecordMain where SchoolName=N'" + schoolName + "' and KPIDeadlineSN = '" + Session["KPISN"].ToString() + "'";

        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("0"))
        {
            LbSubmitCount.Text = "0";
            return;
        }

        query = "select IsFinish from KPIRecordMain where SchoolName=N'" + sb.ToString() + "' and KPIDeadlineSN = '" + Session["KPISN"].ToString() + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("false"))
        {
            LbSubmitCount.Text = "0";
            return;
        }

        query = "select ID from KPIRecordMain where SchoolName=N'" + schoolName + "' and KPIDeadlineSN = '" + Session["KPISN"].ToString() + "'";
        ms.GetOneData(query, sb);

        string ID = sb.ToString();

        query = "select FilledCount from KPIRecordDomainScore where ID='" + ID + "'";
        ms.GetAllColumnData(query, data);

        if (data.Count == 0)
        {
            LbSubmitCount.Text = "0";
            return;
        }

        query = "select count(DomainID) from KPIDomainNameMapping";
        ms.GetRowNumbers(query, sb);

        int FilledCount = 1;
        int MAX_COUNT = Convert.ToInt32(sb.ToString());
        int count = 0;

        query = "select MAX(FilledCount) from KPIRecordDomainScore where ID='" + ID + "'";
        ms.GetOneData(query, sb);

        int MAX_FILLED_COUNT = Convert.ToInt32(sb.ToString());
        for (int i = 1; i <= MAX_FILLED_COUNT; i++)
        {
            foreach (string[] d in data)
            {
                if (Convert.ToInt32(d[0]) >= FilledCount)
                {
                    count++;
                    if (count == MAX_COUNT)
                    {
                        FilledCount++;
                        break;
                    }
                }
            }
            if (count == MAX_COUNT)
                count = 0;
            else
            {
                FilledCount--;
                break;
            }
        }
        LbSubmitCount.Text = (FilledCount > MAX_FILLED_COUNT) ? MAX_FILLED_COUNT.ToString() : FilledCount.ToString();
    }*/
    private void setSubmitedCount()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ArrayList data = new ArrayList();
        getSchoolName(sb);
        string schoolName = sb.ToString();
        string query = "select count(schoolName) from KPIRecordMain where SchoolName=N'" + schoolName + "' and KPIDeadlineSN = '" + Session["KPISN"].ToString() + "'";

        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("0"))
        {
            LbSubmitCount.Text = "0";
            return;
        }

        query = "select IsFinish from KPIRecordMain where SchoolName=N'" + schoolName + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("false"))
        {
            LbSubmitCount.Text = "0";
            return;
        }

        query = "select ID from KPIRecordMain where SchoolName=N'" + schoolName + "' and KPIDeadlineSN = '" + Session["KPISN"].ToString() + "'";
        ms.GetOneData(query, sb);

        string ID = sb.ToString();

        query = "select FilledCount from KPIRecordDomainScore where ID='" + ID + "'";
        ms.GetAllColumnData(query, data);

        if (data.Count == 0)
        {
            LbSubmitCount.Text = "0";
            return;
        }

        query = "select count(DomainID) from KPIDomainNameMapping";
        ms.GetRowNumbers(query, sb);

        int FilledCount = 1;
        int MAX_COUNT = Convert.ToInt32(sb.ToString());
        int count = 0;

        query = "select MAX(FilledCount) from KPIRecordDomainScore where ID='" + ID + "'";
        ms.GetOneData(query, sb);

        int MAX_FILLED_COUNT = Convert.ToInt32(sb.ToString());
        for (int i = 1; i <= MAX_FILLED_COUNT; i++)
        {
            foreach (string[] d in data)
            {
                if (Convert.ToInt32(d[0]) >= FilledCount)
                {
                    count++;
                    if (count == MAX_COUNT)
                    {
                        FilledCount++;
                        break;
                    }
                }
            }
            if (count == MAX_COUNT)
                count = 0;
            else
            {
                FilledCount--;
                break;
            }
        }
        LbSubmitCount.Text = (FilledCount > MAX_FILLED_COUNT) ? MAX_FILLED_COUNT.ToString() : FilledCount.ToString();
    }

    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
   
    private void ListDdlDomains()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select KPIDimensionsDomainMappingTable.DimensionsID, KPIDimensionsDomainMappingTable.DomainID, KPIDomainNameMapping.DomainName " +
                        "from KPIDimensionsNameMapping " +
                        "left join KPIDimensionsDomainMappingTable on KPIDimensionsNameMapping.DimensionsID = KPIDimensionsDomainMappingTable.DimensionsID " +
                        "left join KPIDomainNameMapping on KPIDimensionsDomainMappingTable.DomainID = KPIDomainNameMapping.DomainID ";

        if (ms.GetAllColumnData(query, data))
        {
            if (data.Count > 0)
            {
                DdlDomain.Items.Clear();
                DdlDomain.Items.Add(new ListItem(Resources.Resource.TipPlzChoose, "0"));
                int ddlDimensionSelectIndex = (Session["DdlDimension_SelectIndex"]==null)?DdlDimension.SelectedIndex:Convert.ToInt32(Session["DdlDimension_SelectIndex"].ToString());
                foreach (string[] tmp in data)
                {
                    int DimensionsID = -1;
                    bool DimensionsSuccess = false;
                    DimensionsSuccess = Int32.TryParse(tmp[0], out DimensionsID);
                    if (DimensionsSuccess)
                    {
                        if (ddlDimensionSelectIndex == DimensionsID)
                        {
                            DdlDomain.Items.Add(new ListItem(tmp[2], tmp[1]));
                        }
                    }
                }
            }
        }
        else
        {
            DdlDomain.Items.Add(Resources.Resource.TipKPIError);
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnStartInput")
        {
            Session["InputMode"] = "True";
            Session["DdlDomain_SelectValue"] = DdlDomain.SelectedValue;
            Session["DdlDomain_SelectIndex"] = DdlDomain.SelectedIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipKPICancelQuestionnaire + "');window.location='KPIExamStart.aspx';", true);
        }
    }

    protected void DdlDimension_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["DdlDimension_SelectIndex"] = DdlDimension.SelectedIndex;
        ListDdlDomains();
        
    }
    protected void DdlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["DdlDomain_SelectValue"] = DdlDomain.SelectedValue;
        Session["DdlDomain_SelectIndex"] = DdlDomain.SelectedIndex;
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}