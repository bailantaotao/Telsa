using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewList : System.Web.UI.Page
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
        ImportYear
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");
        if (Session["PlanSN"] != null)
            Session.Remove("PlanSN");
        if(Session["PlanYear"] != null)
            Session.Remove("PlanYear");

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            DdlProvince.Visible = true;
            DdlImportYear.Visible = true;
            LbProvince.Visible = false;
            IsMingDer = true;
            setDefault(DdlType.Province);
            setDefault(DdlType.ImportYear);
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


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            setDefault(DdlType.SchoolName);
            setDefault(DdlType.Year);
            if (Session["PlanList"] != null)
                Query = Session["PlanList"].ToString();
            else
                SearchType();
            
            LoadInternetStudy(1);
            
        }

    }
    private string SearchProvince()
    {
        string query = "select Area.name from Area where Area.ID='" + Session["Province"].ToString() + "'";
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
            case DdlType.SchoolName:
                setSchoolName();
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
        Query = "select PlanYear from PlanList order by PlanYear desc";
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
    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        if (IsMingDer)
        {
            Query = "select School from Account " +                                
                              "left join Area on Account.zipcode = Area.id " +
                              "where School not like N'%專家%' and School not like N'%管理%' " + 
                              "group by School ";
        }
        else
        {
            Query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.id " +
                    "where Area.name =N'" + LbProvince.Text + "' and School not like N'%專家%' and School not like N'%管理%' " +
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
    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getSchoolName(sb);
        Session["SchoolName"] = sb.ToString();

        Query = "select PlanList.SN, Account.ImportYear, PlanList.PlanYear, PlanList.PlanDeadline, PlanListUser.PlanSchool " +
                "from PlanList  " +
                "left join PlanListUser on PlanListUser.PlanListSN = PlanList.SN " +
                "left join Account on PlanListUser.PlanSchool = Account.School " +
                "left join Area on Area.id = Account.Zipcode ";

        string tmp = string.Empty;
        string[] storeParam = new string[5];
        string[] sqlParam = new string[] { "PlanList.PlanYear", "Account.ImportYear", "PlanListUser.PlanSchool", "Area.name", "PlanListUser.PlanStatus" };
        storeParam[0] = DdlYear.SelectedIndex == 0 ? null : DdlYear.Items[DdlYear.SelectedIndex].ToString();
        if (IsMingDer)
            storeParam[1] = DdlImportYear.SelectedIndex == 0 ? null : DdlImportYear.Items[DdlImportYear.SelectedIndex].ToString();
        else
            storeParam[1] = DdlImportYear.SelectedIndex == -1 ? null : DdlImportYear.Items[DdlImportYear.SelectedIndex].ToString();
        storeParam[2] = DdlSchoolName.SelectedIndex == 0 ? null : DdlSchoolName.Items[DdlSchoolName.SelectedIndex].ToString();
        if(IsMingDer)
            storeParam[3] = DdlProvince.SelectedIndex == 0 ?  null : DdlProvince.Items[DdlProvince.SelectedIndex].ToString();
        else
            storeParam[3] = DdlProvince.SelectedIndex == -1 ? null : DdlProvince.Items[DdlProvince.SelectedIndex].ToString();
        storeParam[4] = DdlStatus.SelectedIndex == 0 ? null : DdlStatus.SelectedValue;

        for (int i = 0; i < (IsMingDer ? storeParam.Length : storeParam.Length ); i++)
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
                Query += "where Area.name=N'" + LbProvince.Text + "' and PlanSchool <> '' ";
            }
            else
            {
                Query += "and  Area.name=N'" + LbProvince.Text + "' and PlanSchool <> '' ";
            }
        }
        else
        {
            if (string.IsNullOrEmpty(tmp))
            {
                Query += "where PlanSchool <> '' ";
            }
            else
            {
                Query += "and PlanSchool <> '' ";
            }
        }

        Query += "order by PlanList.PlanYear desc ";
        Session["PlanList"] = Query;
    }
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }


    private void LoadInternetStudy(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ArrayList data1 = new ArrayList();
        BaseClass bc = new BaseClass();

        ArrayList userData = new ArrayList();
        string queryTime = string.Empty;

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanSN + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanYear + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.DdlTypeImportYear + "</td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanSchoolName.Substring(0, Resources.Resource.TipPlanSchoolName.Length - 1) + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanDeadline + "</font></td>";
            // +[20140906, HungTao] add function for plan complete numbers
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipFinishRate + "</font></td>";
            // -[20140906, HungTao] add function for plan complete numbers
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += Resources.Resource.TipPlanStatus + "</font></td>";
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

                string userQuery = "select planList.PlanYear, planlistuser.sn, planlistuser.planstatus from planlistuser " +
                                    "left join planlist on PlanListUser.PlanListSN = PlanList.SN " + 
                                    "where " +
                                    "planlistuser.PlanSchool = N'" + ((string[])(data[i]))[3] + "' and " +
                                    "PlanList.PlanYear = '" + ((string[])(data[i]))[1] + "'";
                ms.GetAllColumnData(userQuery, userData);



                string EncryptSN = GetEncryptionString(SN, ((string[])(data[i]))[0]);
                string EncryptYEAR = GetEncryptionString(YEAR, ((string[])(data[i]))[1]);
                string EncryptSchoolName = GetEncryptionString(SCHOOLNAME, ((string[])(data[i]))[4]);
                TimeSpan ts = TimeSpan.Zero;
                try
                {
                    DateTime dttx1 = DateTime.Now ;
                    DateTime dttx2 = DateTime.Parse(((string[])(data[i]))[2]);
                    ts = dttx1.Subtract(dttx2);                    
                }
                catch
                { }
                string EncryptMODIFIED = string.Empty;
                if(ts == TimeSpan.Zero)
                    EncryptMODIFIED = GetEncryptionString(MODIFIED, "false");
                else
                    EncryptMODIFIED = GetEncryptionString(MODIFIED, (ts.Days <= 0) ? "true" : "false");
                
                //string EncryptClassID = GetEncryptionString(ClassID, ((string[])(data[i]))[2]);

                //bool IsAdded = false, DBAddedComplete = false;
                //IsAdded = bool.TryParse(((string[])(data[i]))[5], out DBAddedComplete);

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += (i + 1).ToString() + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[4] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[3].Split(' ')[0] + "</td>";

                // +[20140906, HungTao] add function for plan complete numbers
                string whetherDo = "select Count(PlanStatus) " +
                       "from PlanlistUser " +
                       "left join planlist on PlanListUser.PlanListSN = PlanList.SN " +
                       "where PlanListUser.PlanListSN ='" + ((string[])(data[i]))[0] + "' and PlanList.planyear = '" + ((string[])(data[i]))[1] + "' and PlanListUser.PlanSchool=N'" + ((string[])(data[i]))[3] + "'";
                StringBuilder TotalTargetNumbers = new StringBuilder();
                ms.GetRowNumbers(whetherDo, TotalTargetNumbers);
                if (TotalTargetNumbers.ToString().Equals("0"))
                {
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += "0 / 0</td>";
                }
                else
                {
                    
                    string queryTargetNumbers = "select count(SN) from PlanTargetActivity where SN = '" + ((string[])(userData[0]))[1] + "' ";
                    ms.GetOneData(queryTargetNumbers, TotalTargetNumbers);
                    queryTargetNumbers += "and Finish='True'";
                    StringBuilder FinishTargetNumbers = new StringBuilder();
                    ms.GetOneData(queryTargetNumbers, FinishTargetNumbers);


                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                    LbCompleted.Text += FinishTargetNumbers.ToString() + " / " + TotalTargetNumbers.ToString() + "</td>";
                    
                }
                // -[20140906, HungTao] add function for plan complete numbers

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                
                if (ts.Days <= 0)
                {
                    // 代表還沒到deadline 可填寫問卷

                    if (userData.Count == 0)
                    {
                        // 如果是空的，代表使用者還沒填過
                        LbCompleted.Text += Resources.Resource.TipPlanUnsubmit + "</td>";
                    }
                    else
                    {
                        //如果不是空的，則檢查是為true或false   
                        if (((string[])(userData[0]))[2].ToLower().Equals("true"))
                        {
                            LbCompleted.Text += Resources.Resource.TipPlanSubmited + "</td>";
                        }
                        else
                        {
                            LbCompleted.Text += Resources.Resource.TipPlanUnsubmit + "</td>";
                        }

                    }
                }
                else
                {
                    //已經到了deadline, 接下來要看使用者是否有資料在裡面
                    if (userData.Count == 0)
                    {
                        // 沒有資料，代表該學校是後來才加進群組的，則提已過期
                        LbCompleted.Text += Resources.Resource.TipPlanExpired + "</td>";
                    }
                    else
                    {
                        // 有資料，但已經超過deadline, 故還是顯示已提交
                        //if (((string[])(userData[0]))[2].ToLower().Equals("true"))
                        //{
                            LbCompleted.Text += Resources.Resource.TipPlanSubmited + "</td>";
                        //}
                        //else
                        //{
                        //    LbCompleted.Text += Resources.Resource.TipPlanUnsubmit + "</td>";
                        //}
                    }
                }
                //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                //LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";

                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                queryTime = "select PlanSubmitTime from PlanListUser " +
                         "left join planlist on PlanListUser.PlanListSN = PlanList.SN " +
                       "where PlanListUser.PlanListSN ='" + ((string[])(data[i]))[0] + "' and PlanList.planyear = '" + ((string[])(data[i]))[1] + "' and PlanListUser.PlanSchool=N'" + ((string[])(data[i]))[3] + "'";
                ms.GetAllColumnData(queryTime, data1);
                if (data1.Count > 0)
                {
                    string[] d = (string[])data1[0];
                    LbCompleted.Text += d[0].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotFinish : d[0].Split(' ')[0];
                }

                if (ts.Days <= 0)
                {
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                    LbCompleted.Text += "<a href='PlanViewMain.aspx?" + EncryptSN + "&" + EncryptYEAR + "&" + EncryptSchoolName + "'>";
                    // 代表還沒到deadline 可填寫問卷
                    // 如果是空的，代表使用者還沒填過
                    if (userData.Count == 0)
                    {
                        LbCompleted.Text += Resources.Resource.TipPlanModified;
                    }
                    else
                    {
                        //如果不是空的，則檢查是為true或false   
                        if (((string[])(userData[0]))[2].ToLower().Equals("true"))
                        {
                            //要換到view的頁面
                            LbCompleted.Text += Resources.Resource.TipPlanView;
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
                        // 沒有資料，代表該學校是後來才加進群組的，則提已過期
                        LbCompleted.Text += "none";
                    }
                    else
                    {
                        // 有資料，但已經超過deadline, 但裡面資料可能有缺，就靠後面每個function判斷是否有資料了
                        //if (((string[])(userData[0]))[2].ToLower().Equals("true"))
                        //{
                        //要換到view的頁面
                        LbCompleted.Text += "<a href='PlanViewMain.aspx?" + EncryptSN + "&" + EncryptYEAR + "&" + EncryptSchoolName + "'>" + Resources.Resource.TipPlanView + "</a>";
                        //}
                        //else
                        //{
                        //    LbCompleted.Text += Resources.Resource.TipPlanUnsubmit + "</td>";
                        //}
                    }
                    
                }
                //if (((string[])(data[i]))[3].Equals("true"))
                //{
                //    LbCompleted.Text += Resources.Resource.TipPlanView;
                //}
                //else
                //{
                //    LbCompleted.Text += Resources.Resource.TipPlanModified;
                //}
                
                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#FFFFFF;' colspan = '6'>";
            LbCompleted.Text += "<td colspan = '6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += "尚未有任一位使用者新增问卷资料" + "</td>";
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
        Query = Session["PlanList"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        SearchType();
        LoadInternetStudy(1);
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
    protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedIndex == 0)
            return;

        setSchoolName_Province(DdlProvince.Items[DdlProvince.SelectedIndex].ToString());
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
}