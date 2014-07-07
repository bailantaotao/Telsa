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
        State
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");


        DdlProvince.Visible = true;
        LbProvince.Visible = false;
        LbTipProvince.Visible = false;
        UpProvince.Visible = true;
        IsMingDer = true;
        setDefault(DdlType.Province);


        setDefault(DdlType.Cycle);
        setDefault(DdlType.SchoolName);
        setDefault(DdlType.ScoreLevel);
        setDefault(DdlType.Year);
        setDefault(DdlType.State);
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
        string query = "select zipcode.name from zipcode where zipcode.zipcode='" + Session["Province"].ToString() + "'";
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
        }
    }
    private void setProvince()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select zipcode.name from zipcode";
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
        Query = "select KPIYear from KPIRecordMain group by KPIYear order by KPIYear asc";
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
        Query = "select School from Account group by School";
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

        Query = "select KPIRecordMain.KPIYear, KPIRecordMain.Cycle, Zipcode.Name, Account.School, KPIRecordMain.ScoreLevel , KPIRecordMain.IsFinish " +
                "from KPIRecordMain " +
                "left join Account on Account.School = KPIRecordMain.SchoolName " +
                "left join Zipcode on Account.ZipCode = ZIPCode.Zipcode ";

        string tmp = string.Empty;
        string[] storeParam = new string[6];
        string[] sqlParam = new string[] { "KPIRecordMain.KPIYear", "KPIRecordMain.ScoreLevel", "Account.School", "KPIRecordMain.Cycle", "KPIRecordMain.IsFinish", "Zipcode.Name" };
        storeParam[0] = DdlYear.SelectedIndex == 0 ? null : DdlYear.Items[DdlYear.SelectedIndex].ToString();
        storeParam[1] = DdlScoreLevel.SelectedIndex == 0 ? null : DdlScoreLevel.Items[DdlScoreLevel.SelectedIndex].ToString();
        storeParam[2] = DdlSchoolName.SelectedIndex == 0 ? null : DdlSchoolName.Items[DdlSchoolName.SelectedIndex].ToString();
        storeParam[3] = DdlCycle.SelectedIndex == 0 ? null : DdlCycle.Items[DdlCycle.SelectedIndex].ToString();
        storeParam[4] = DdlQuestionnaireState.SelectedIndex == 0 ? null : ((DdlQuestionnaireState.SelectedValue == "True") ? "True" : "False");
        storeParam[5] = DdlProvince.SelectedIndex == -1 ? null : (DdlProvince.SelectedIndex == 0 ? null : DdlProvince.Items[DdlProvince.SelectedIndex].ToString());        

        for (int i = 0; i < (IsMingDer ? storeParam.Length : storeParam.Length - 1); i++)
        {
            if (!string.IsNullOrEmpty(storeParam[i]))
            {
                if (string.IsNullOrEmpty(tmp))
                {
                    tmp += sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }
                else
                {
                    tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }

            }
        }

        if (!string.IsNullOrEmpty(tmp))
            Query += "where " + tmp;

        Query += "order by KPIRecordMain.KPIYear desc ";
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
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.TipKpiSN + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeYear + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeCycle + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeProvince + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeSchoolname + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbCompleted.Text += Resources.Resource.DdlTypeScoreLevel + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
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

                string EncryptYearID = GetEncryptionString(QuestionYear, ((string[])(data[i]))[0]);
                string EncryptCycleID = GetEncryptionString(QuestionCycle, ((string[])(data[i]))[1]);
                string EncryptSchoolname = GetEncryptionString(QuestionSchoolname, ((string[])(data[i]))[3]);
                string EncryptScoreLevel = GetEncryptionString(QuestionScoreLevel, string.IsNullOrEmpty(((string[])(data[i]))[4]) ? "E" : ((string[])(data[i]))[4]);
                //string EncryptClassID = GetEncryptionString(ClassID, ((string[])(data[i]))[2]);

                //bool IsAdded = false, DBAddedComplete = false;
                //IsAdded = bool.TryParse(((string[])(data[i]))[5], out DBAddedComplete);

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += (i + 1).ToString() + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += ((string[])(data[i]))[0] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += string.IsNullOrEmpty(((string[])(data[i]))[4]) ? "E" : ((string[])(data[i]))[4] + "</td>";

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbCompleted.Text += "<a href='KPIExamScoreViewDimension.aspx?" + EncryptYearID + "&" + EncryptCycleID + "&" + EncryptSchoolname + "&" + EncryptScoreLevel + "'>" + Resources.Resource.TipKPIViewScore + "</a>";
                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#6699FF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan = '7' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
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
}