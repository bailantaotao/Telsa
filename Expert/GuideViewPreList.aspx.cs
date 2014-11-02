using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideViewPreList : System.Web.UI.Page
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
    private const string SCHOOLNAME = "SCHOOLNAME";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        Province,
        Year,
        SchoolName,
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");
        if (Session["GuideSN"] != null)
            Session.Remove("GuideSN");
        if (Session["GuideYear"] != null)
            Session.Remove("GuideYear");

        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            DdlProvince.Visible = false;
            DdlSemester.Visible = false;
            DdlYear.Visible = false;
            BtnSearch.Visible = false;
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            IsMingDer = true;
            HyperLink1.Visible = false;
            LbTipProvince.Visible = false;
            LbUserName.Visible = false;
            Label2.Visible = false;
            LbUserID.Visible = false;
            img.Visible = false;
            getSchoolName_MingDer(schoolName);
            setDefault_MingDer(DdlType.Province);
            setDefault_MingDer(DdlType.SchoolName);
            setDefault_MingDer(DdlType.Year);
            if (Session["GuideList"] != null)
                Query = Session["GuideList"].ToString();
            else
                SearchType_MingDer();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            getSchoolName(schoolName);
            LbUserName.Text += Session["UserName"].ToString();
            LbUserID.Text += Session["UserID"].ToString();
            if (!IsPostBack)
            {

                if (Session["GuideList"] != null)
                    Query = Session["GuideList"].ToString();
                else
                    SearchType();

                LoadInternetStudy(1);
            }
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            

            LoadInternetStudy_MingDer(1);
        }
    }

    private void setDefault_MingDer(DdlType type)
    {
        switch (type)
        {
            case DdlType.Province:
                setProvince_MingDer();
                break;
            case DdlType.Year:
                setYear_MingDer();
                break;
            case DdlType.SchoolName:
                setSchoolName_MingDer();
                break;
        }
    }
    private void setProvince_MingDer()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select name from Area where ID <= 31 order by id asc";
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
    private void setYear_MingDer()
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
    private void setSchoolName_MingDer()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select School from Account " +
                            "left join Area on Account.zipcode = Area.ID " +
                            "where School not like N'%專家%' and School not like N'%管理%' " +
                            "group by School ";
    }
    private void SearchType_MingDer()
    {
        StringBuilder sb = new StringBuilder();
        getSchoolName(sb);
        Session["SchoolName"] = sb.ToString();

        Query = "select GuideList.SN, GuideList.GuideYear,  GuideList.GuideSemester, GuideListUser.GuideSchool  " +
                "from GuideList  " +
                "left join GuideListUser on GuideListUser.GuideListSN = GuideList.SN " +
                "left join Account on GuideListUser.GuideSchool = Account.School " +
                "left join Area on Area.ID = Account.Zipcode " +
                "where GuideListUser.GuideSchool NOT Like N'%明德%' " +
                "and GuideListUser.GuideSchool Not Like N'%管理者%' ";

        string tmp = string.Empty;
        string[] storeParam = new string[3];
        string[] sqlParam = new string[] { "Area.name", "GuideList.GuideYear", "GuideList.GuideSemester" };
        storeParam[0] = DdlProvince.SelectedIndex == 0 ? null : DdlProvince.Items[DdlProvince.SelectedIndex].ToString();
        storeParam[1] = DdlYear.SelectedIndex == 0 ? null : DdlYear.Items[DdlYear.SelectedIndex].ToString();
        storeParam[2] = DdlSemester.SelectedIndex == 0 ? null : DdlSemester.Items[DdlSemester.SelectedIndex].ToString();

        for (int i = 0; i < storeParam.Length; i++)
        {
            if (!string.IsNullOrEmpty(storeParam[i]))
            {
                if (string.IsNullOrEmpty(tmp))
                {
                    tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }
                else
                {
                    tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }
            }
        }
        //Query += (tmp.Length > 0) ? tmp + "GuideSchool <> '' " : "where GuideSchool <> '' ";
        Query += (tmp.Length > 0) ? tmp : null;


        Query += "order by GuideList.GuideYear desc, GuideList.GuideSemester asc ";

        Session["GuideList"] = Query;
    }
    private bool getSchoolName_MingDer(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    private void LoadInternetStudy_MingDer(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();

        ArrayList userData = new ArrayList();

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanSN + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanYear + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanSemester + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "省专家名称" + "</td>";
            //LbCompleted.Text += Resources.Resource.TipPlanSchoolName.Substring(0, Resources.Resource.TipPlanSchoolName.Length - 1) + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "</td>";
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

                string userQuery = "select GuideList.GuideYear, GuideListUser.SN, GuideListUser.GuideStatus from Guidelistuser " +
                                    "left join GuideList on GuideListUser.GuideListSN = GuideList.SN " +
                                    "where " +
                                    "GuideListUser.GuideSchool = N'" + ((string[])(data[i]))[3] + "' and " +
                                    "GuideList.GuideYear = '" + ((string[])(data[i]))[1] + "'";
                ms.GetAllColumnData(userQuery, userData);



                string EncryptSN = GetEncryptionString(SN, ((string[])(data[i]))[0]);
                string EncryptYEAR = GetEncryptionString(YEAR, ((string[])(data[i]))[1]);
                string EncryptSchoolName = GetEncryptionString(SCHOOLNAME, ((string[])(data[i]))[3]);

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += (i + 1).ToString() + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<a href='GuideViewList.aspx?" + EncryptSN + "&" + EncryptYEAR + "&" + EncryptSchoolName + "'>";
                LbCompleted.Text += "查看";
                LbCompleted.Text += "</a>";

                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

    NODATA:
        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
        LbCompleted.Text += "<td colspan = '6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
        LbCompleted.Text += "</tr>";

        LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
        PageOrder.Text = "0 / 0";
    FINALLY:
        LbCompleted.Text += "</table>";

    }

    private void SearchType()
    {
        Query = "select SN, GuideYear, GuideSemester " +
                "from GuideList ";
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
        BaseClass bc = new BaseClass();

        ArrayList userData = new ArrayList();

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:375px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "编号" + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "学年" + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "学期" + "</font></td>";
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

                string userQuery = "select GuideList.GuideYear, GuideListUser.SN, GuideListUser.GuideStatus from Guidelistuser " +
                                    "left join GuideList on GuideListUser.GuideListSN = GuideList.SN " +
                                    "where " +
                                    "GuideListUser.GuideSchool = N'" + schoolName.ToString() + "' and " +
                                    "GuideList.GuideYear = '" + ((string[])(data[i]))[1] + "'";
                ms.GetAllColumnData(userQuery, userData);



                string EncryptSN = GetEncryptionString(SN, ((string[])(data[i]))[0]);
                string EncryptYEAR = GetEncryptionString(YEAR, ((string[])(data[i]))[1]);

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += (i + 1).ToString() + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<a href='GuideViewList.aspx?" + EncryptSN + "&" + EncryptYEAR + "'>";
                LbCompleted.Text += "查看";
                LbCompleted.Text += "</a>";

                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

    NODATA:
        LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '3'>";
        LbCompleted.Text += "<td colspan = '3' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
        LbCompleted.Text += Resources.Resource.TipQuestionnaireNotCompelet + "</td>";
        LbCompleted.Text += "</tr>";

        LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
        PageOrder.Text = "0 / 0";
    FINALLY:
        LbCompleted.Text += "</table>";

    }

    private string GetEncryptionString(string Tag, string Data)
    {
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }

    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 使用者一定要有大於10筆的資料，才有足更能力去選擇第二頁、第三頁，故這裡可不判斷是否為空，因為為空時，使用者也無法做選擇頁面的操作
        Query = Session["GuideList"].ToString();
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            LoadInternetStudy_MingDer(DdlPageSelect.SelectedIndex + 1);
        }
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        SearchType_MingDer();
        LoadInternetStudy_MingDer(1);
    }
<<<<<<< HEAD
=======
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
>>>>>>> develop
}