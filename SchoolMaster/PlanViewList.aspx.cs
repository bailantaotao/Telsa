﻿using System;
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

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");
        if (Session["PlanSN"] != null)
            Session.Remove("PlanSN");
        if(Session["PlanYear"] != null)
            Session.Remove("PlanYear");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);
        LbSchoolName.Text = schoolName.ToString();
        LbSchoolSN.Text = Session["UserID"].ToString();
        LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            
            if (Session["PlanList"] != null)
                Query = Session["PlanList"].ToString();
            else
                SearchType();
            
            LoadInternetStudy(1);
        }
    }

    private void SearchType()
    {

        Query = "select SN, PlanYear, PlanDeadline " +
                "from PlanList ";
                

        //Query = "select planlistuser.sn, planList.PlanYear, planList.PlanDeadline, planlistuser.planstatus, planListUser.PlanSchool from planlistuser " +
        //        "left join planlist on PlanListUser.PlanListSN = PlanList.SN "+
        //        "where planlistuser.PlanSchool = N'" + schoolName.ToString() + "'";
                
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
                                    "planlistuser.PlanSchool = N'" + schoolName.ToString() + "' and " +
                                    "PlanList.PlanYear = '" + ((string[])(data[i]))[1] + "'";
                ms.GetAllColumnData(userQuery, userData);



                string EncryptSN = GetEncryptionString(SN, ((string[])(data[i]))[0]);
                string EncryptYEAR = GetEncryptionString(YEAR, ((string[])(data[i]))[1]);
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
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2].Split(' ')[0] + "</td>";

                // +[20140906, HungTao] add function for plan complete numbers
                string whetherDo = "select Count(PlanStatus) " +
                       "from PlanlistUser " +
                       "left join planlist on PlanListUser.PlanListSN = PlanList.SN " +
                       "where PlanListUser.PlanListSN ='" + ((string[])(data[i]))[0] + "' and PlanList.planyear = '" + ((string[])(data[i]))[1] + "' and PlanListUser.PlanSchool=N'" + schoolName.ToString() + "'";
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
                         "where PlanListUser.PlanListSN ='" + ((string[])(data[i]))[0] + "' and PlanList.planyear = '" + ((string[])(data[i]))[1] + "' and PlanListUser.PlanSchool=N'" + schoolName.ToString() + "'";
                ms.GetAllColumnData(queryTime, data1);
                if (data1.Count > 0)
                {
                    string[] d = (string[])data1[0];
                    LbCompleted.Text += d[0].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotFinish : d[0].Split(' ')[0];
                }
               
                if (ts.Days <= 0)
                {
                    LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";

                    LbCompleted.Text += "<a href='PlanViewMain.aspx?" + EncryptSN + "&" + EncryptYEAR + "'>";
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
                        LbCompleted.Text += "<a href='PlanViewMain.aspx?" + EncryptSN + "&" + EncryptYEAR + "'>" + Resources.Resource.TipPlanView + "</a>";
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
        Query = Session["PlanList"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }

    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}