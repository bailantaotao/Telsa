using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_KPIExamMain : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";
    private const string QuestionSchoolname = "schoolName";
    private const string QuestionScoreLevel = "ScoreLevel";

    private bool IsMingDer = false;

    private const string QuestionYear = "Year";
    private const string QuestionCycle = "Cycle";


    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        Province,
        Year,
        ScoreLevel,
        SchoolName,
        Cycle,
        State,
        ImportYear
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            DdlProvince.Visible = true;
            DdlImportYear.Visible = true;
            LbProvince.Visible = false;
            IsMingDer = true;
            setDefault(DdlType.Province);
            UpProvince.Visible = true;
            LbTipProvince.Visible = false;
        }
        else
        {
            DdlProvince.Visible = false;
            DdlImportYear.Visible = false;
            LbProvince.Visible = true;
            LbProvince.Text = SearchProvince();
            IsMingDer = false;
        }
        setDefault(DdlType.Cycle);
        setDefault(DdlType.SchoolName);
        setDefault(DdlType.ScoreLevel);
        setDefault(DdlType.Year);
        setDefault(DdlType.State);
        setDefault(DdlType.ImportYear);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["KPIExamMain"] != null)
                Query = Session["KPIExamMain"].ToString();
            else
                SearchType();
            LoadInternetStudy(1);
        }
    }
    private string SearchProvince()
    {
        string query = "select Area.name from Area where Area.id='" + Session["Province"].ToString() + "'";
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ms.GetOneData(query, sb);
        return string.IsNullOrEmpty(sb.ToString()) ? "none" : sb.ToString();
    }
    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.Province:
                setProvince();
                break;
            case DdlType.Year:
                setYear();
                break;
            case DdlType.ScoreLevel:
                setScoreLevel();
                break;
            case DdlType.SchoolName:
                setSchoolName();
                break;
            case DdlType.Cycle:
                setCycle();
                break;
            case DdlType.State:
                setState();
                break;
            case DdlType.ImportYear:
                setImportYear();
                break;
        }
    }
    private void setProvince()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select Area.name from area where ID <= 31 order by id asc";
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
        DdlProvince.Items.Add(Resources.Resource.DdlTypeProvince);
        foreach (string[] province in data)
        {
            DdlProvince.Items.Add(province[0]);
        }
    }
    private void setYear()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select KPIDeadline.KPIYear from KPIDeadline group by KPIYear order by KPIYear asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlYear.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlYear.Items.Add("None");
            return;
        }
        DdlYear.Items.Add(Resources.Resource.DdlTypeYear);
        foreach (string[] province in data)
        {
            DdlYear.Items.Add(province[0]);
        }
    }
    private void setImportYear()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select Account.ImportYear from Account where ImportYear Is Not Null group by ImportYear order by ImportYear asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlImportYear.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlImportYear.Items.Add("None");
            return;
        }
        DdlImportYear.Items.Add(Resources.Resource.DdlTypeImportYear);
        foreach (string[] province in data)
        {
            DdlImportYear.Items.Add(province[0]);
        }
    }
    private void setScoreLevel()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select ScoreRank from KPIScoreRank order by ScoreRank asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlScoreLevel.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlScoreLevel.Items.Add("None");
            return;
        }
        DdlScoreLevel.Items.Add(Resources.Resource.DdlTypeScoreLevel);
        foreach (string[] province in data)
        {
            DdlScoreLevel.Items.Add(province[0]);
        }
    }
    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        if (IsMingDer)
        {
            Query = "select School from Account " +
                              "left join area on Account.zipcode = area.id " +
                              "where School not like N'%專家%' and School not like N'%管理者%' " +
                              "group by School ";
        }
        else
        {
            Query = "select School from Account " +
                    "left join area on Account.zipcode = area.id " +
                    "where area.name =N'" + LbProvince.Text + "'" +
                    "and School not like N'%專家%' and School not like N'%管理者%' " +
                    "group by School ";
        }

        if (!ms.GetAllColumnData(Query, data))
        {
            DdlSchoolName.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlSchoolName.Items.Add("None");
            return;
        }
        DdlSchoolName.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DdlSchoolName.Items.Add(province[0]);
        }
    }
    private void setCycle()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select School from Account group by School";
        DdlCycle.Items.Add(Resources.Resource.DdlTypeCycle);
        DdlCycle.Items.Add("1");
        DdlCycle.Items.Add("2");
    }
    private void setState()
    {
        
        DdlQuestionnaireState.Items.Add(Resources.Resource.DdlTypeState);
        DdlQuestionnaireState.Items.Add(new ListItem(Resources.Resource.TipKPIStateFinish, "True"));
        DdlQuestionnaireState.Items.Add(new ListItem(Resources.Resource.TipKPIStateUnFinish, "False"));
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

        Query = "select KPIDeadline.KPIYear, Account.ImportYear, KPIDeadline.Semester, area.name, Account.School, KPIRecordMain.ScoreLevel , KPIRecordMain.IsFinish, KPIRecordMain.KPIDeadlineSN " +
                "from KPIRecordMain " +
                "left join Account on Account.School = KPIRecordMain.SchoolName " +
                "left join area on Account.ZipCode = area.id " +
                "left join KPIDeadline on KPIDeadline.SN = KPIRecordMain.KPIDeadlineSN ";

        string tmp = string.Empty;
        string[] storeParam = new string[7];
        string[] sqlParam = new string[] { "KPIDeadline.KPIYear", "Account.ImportYear", "KPIRecordMain.ScoreLevel", "Account.School", "KPIDeadline.Semester", "KPIRecordMain.IsFinish", "area.name" };
        storeParam[0] = DdlYear.SelectedIndex == 0 ? null : DdlYear.Items[DdlYear.SelectedIndex].ToString();
        storeParam[1] = DdlImportYear.SelectedIndex == 0 ? null : DdlImportYear.Items[DdlImportYear.SelectedIndex].ToString();
        storeParam[2] = DdlScoreLevel.SelectedIndex == 0 ? null : DdlScoreLevel.Items[DdlScoreLevel.SelectedIndex].ToString();
        storeParam[3] = DdlSchoolName.SelectedIndex == 0 ? null : DdlSchoolName.Items[DdlSchoolName.SelectedIndex].ToString();
        storeParam[4] = DdlCycle.SelectedIndex == 0 ? null : DdlCycle.Items[DdlCycle.SelectedIndex].ToString();
        storeParam[5] = DdlQuestionnaireState.SelectedIndex == 0 ? null : ((DdlQuestionnaireState.SelectedValue == "True") ? "True" : "False");
        storeParam[6] = DdlProvince.SelectedIndex == -1 ? null : (DdlProvince.SelectedIndex == 0 ? null : DdlProvince.Items[DdlProvince.SelectedIndex].ToString());        

        for (int i = 0; i < (IsMingDer ? storeParam.Length : storeParam.Length - 1); i++)
        {
            if (!string.IsNullOrEmpty(storeParam[i]))
            {
                if (string.IsNullOrEmpty(tmp))
                {
                    tmp += "where " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }
                else
                {
                    tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }

            }
        }
        Query += tmp;

        if (!IsMingDer)
        {
            if (string.IsNullOrEmpty(tmp))
            {
                Query += "where area.name=N'" + LbProvince.Text + "' ";                
            }
            else
            {
                Query += "and  area.name=N'" + LbProvince.Text + "' ";
            }
        }

        Query += "order by KPIDeadline.KPIYear desc ";
        Session["KPIExamMain"] = Query;
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
            LbCompleted.Text += Resources.Resource.DdlTypeYear + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeImportYear + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeCycle + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeProvince + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeSchoolname + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeScoreLevel + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiOperation + "</td>";
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

                string EncryptYearID = GetEncryptionString(QuestionYear, ((string[])(data[i]))[6]);
                
                string EncryptSchoolname = GetEncryptionString(QuestionSchoolname, ((string[])(data[i]))[3]);
                string EncryptScoreLevel = GetEncryptionString(QuestionScoreLevel, string.IsNullOrEmpty(((string[])(data[i]))[4]) ? "E" : ((string[])(data[i]))[4]);
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
                LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[4] + "</td>";

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[5]) ? "E" : ((string[])(data[i]))[5] + "</td>";

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<a href='KPIExamScoreViewDimension.aspx?" + EncryptYearID + "&" + EncryptSchoolname + "&" + EncryptScoreLevel + "'>" + Resources.Resource.TipKPIViewScore + "</a>";
                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan = '7' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
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
        Query = Session["KPIExamMain"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void ImgBtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ibt = (ImageButton)sender;
        if (ibt.ID == "ImgBtnSearch")
        {
            SearchType();
            LoadInternetStudy(1);
        }
    }
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('KPIExamNotifyAll.aspx', '', config='height=500,width=739')", true);
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
    private void setSchoolName_Province(string schoolName)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();

        string query = string.Empty;
        string queryID = string.Empty;
        string Selectprovince = string.Empty;

        DdlSchoolName.Items.Clear();
        if (DdlImportYear.SelectedValue.ToString() == Resources.Resource.DdlTypeImportYear)
        {
            queryID = "select ID from Area where Name= N'" + DdlProvince.SelectedValue.ToString() + "'";
            ms.GetOneData(queryID, sb);
            query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.id " +
                    "where School not like N'%專家%' and School not like N'%管理者%' " +
                    "and Account.zipcode=" + sb.ToString() +
                    "group by School ";
        }
        else
        {
            queryID = "select ID from Area where Name= N'" + DdlProvince.SelectedValue.ToString() + "'";
            ms.GetOneData(queryID, sb);
            query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.id " +
                    "where School not like N'%專家%' and School not like N'%管理者%' " +
                    "and Account.zipcode=" + sb.ToString() + " " +
                    "group by School ";
        }

        if (!ms.GetAllColumnData(query, data))
        {
            DdlSchoolName.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlSchoolName.Items.Add("None");
            return;
        }
        DdlSchoolName.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DdlSchoolName.Items.Add(province[0]);
        }
    }
    protected void DdlImportYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedIndex == 0)
            return;

        setSchoolName_ImportYear(DdlProvince.Items[DdlProvince.SelectedIndex].ToString());
    }
    private void setSchoolName_ImportYear(string schoolName)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();

        string query = string.Empty;
        string queryID = string.Empty;
        string Selectprovince = string.Empty;

        DdlSchoolName.Items.Clear();
        if (DdlImportYear.SelectedValue.ToString() == Resources.Resource.DdlTypeImportYear)
        {
            queryID = "select ID from Area where Name= N'" + DdlProvince.SelectedValue.ToString() + "'";
            ms.GetOneData(queryID, sb);
            query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.id " +
                    "where School not like N'%專家%' and School not like N'%管理者%' " +
                    "and Account.zipcode=" + sb.ToString() +
                    "group by School ";
        }
        else
        {
            queryID = "select ID from Area where Name= N'" + DdlProvince.SelectedValue.ToString() + "'";
            ms.GetOneData(queryID, sb);
            query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.id " +
                    "where School not like N'%專家%' and School not like N'%管理者%' " +
                    "and Account.zipcode=" + sb.ToString() + " " +
                    "and Account.ImportYear =" + DdlImportYear.SelectedValue.ToString() + " " +
                    "group by School ";
        }
        if (!ms.GetAllColumnData(query, data))
        {
            DdlSchoolName.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlSchoolName.Items.Add("None");
            return;
        }
        DdlSchoolName.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DdlSchoolName.Items.Add(province[0]);
        }
    }
    protected void DdlProvince_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedIndex == 0)
            return;

        setSchoolName_Province(DdlProvince.Items[DdlProvince.SelectedIndex].ToString());
    }
}