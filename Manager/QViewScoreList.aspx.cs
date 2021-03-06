﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_QViewScoreList : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;

    
    private const string YEAR = "YEAR";
    private const string SEMESTER = "SEMESTER";
    private const string SCHOOLNAME = "SCHOOLNAME";
    private const string QuestionImportYear = "ImportYear";

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
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");

        removeSession("ViewStudentList");
        removeSession("QVSL_PageSelect_SelectedIndexChanged");
        removeSession("QVST_DdlGradeLevel_SelectedIndexChanged");
        removeSession("QVST_DdlClass_SelectedIndexChanged");

        removeSession("QViewScore");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserID"] = "admin";
        getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            setDefault(DdlType.Year);
            setDefault(DdlType.Province);
            setDefault(DdlType.ImportYear);
            //setDefault(DdlType.SchoolName);
            DdlSchoolName.Items.Add(new ListItem(Resources.Resource.DdlTypeSchoolname, "0"));
            if (Session["QViewScoreList"] != null)
                Query = Session["QViewScoreList"].ToString();
            else
                SearchType();

            LoadInternetStudy(1);

        }

    }
    private void removeSession(string key)
    {
        if (Session[key] != null)
            Session.Remove(key);
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
                //setSchoolName();
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
        Query = "select name, id from Area where ID <= 31 order by id asc";
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

            DdlProvince.Items.Add(new ListItem(province[0], province[1]));
        }
    }
    private void setYear()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select Year from QList group by Year order by Year desc ";
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

    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getSchoolName(sb);
        Session["SchoolName"] = sb.ToString();

        Query = "select QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School " +
                "from QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + " ";

        string tmp = string.Empty;
        string[] storeParam = new string[2];
        string[] sqlParam = new string[] { "QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School", "QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".Zipcode" };
        storeParam[0] = DdlSchoolName.SelectedIndex == 0 ? null : DdlSchoolName.SelectedValue;
        storeParam[1] = DdlProvince.SelectedIndex == 0 ? null : DdlProvince.SelectedValue;
        
        for (int i = 0; i < storeParam.Length; i++)
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
        Query += tmp + "group by QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School";

        Session["QViewScoreList"] = Query;
        
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
        BaseClass bc = new BaseClass();

        ArrayList userData = new ArrayList();

        LbCompleted.Text = "<table style='width:750px;'>";
        LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "学校" + "</font></td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "学年" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "学期" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "</font></td>";
        LbCompleted.Text += "</tr>";

        if (ms.GetAllColumnData(Query, data))
        {
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

                string EncryptSEMESTER = GetEncryptionString(SEMESTER, (DdlSemester.SelectedValue));
                string EncryptYEAR = GetEncryptionString(YEAR, (DdlYear.SelectedValue));
                string EncryptSchoolName = GetEncryptionString(SCHOOLNAME, ((string[])(data[i]))[0]);


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[0] + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += DdlYear.SelectedValue + "</td>";
                //LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                //LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += DdlSemester.SelectedValue + "</td>";


                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";


                // goto view personal page
                LbCompleted.Text += "<a href='QViewScore.aspx?" + EncryptSEMESTER + "&" + EncryptYEAR + "&" + EncryptSchoolName + "'>" + Resources.Resource.TipPlanView + "</a>";



                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

    NODATA:
        LbCompleted.Text += "<tr align='center' style='background-color:#FFFFFF;'>";
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
        //BaseClass bc = new BaseClass();
        //return (Tag + "=" +bc.encryption(Data));
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }
    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 使用者一定要有大於10筆的資料，才有足更能力去選擇第二頁、第三頁，故這裡可不判斷是否為空，因為為空時，使用者也無法做選擇頁面的操作
        Query = Session["QVSL_PageSelect_SelectedIndexChanged"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您必须选择省分');", true);
            return;
        }
        if (DdlSchoolName.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您必须选择学校');", true);
            return;
        }
        if (DdlYear.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您必须选择学年');", true);
            return;
        }
        if (DdlSemester.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您必须选择学期');", true);
            return;
        }
        SearchType();
        LoadInternetStudy(1);
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
    protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedIndex == 0)
            return;

        setSchoolName_Province(DdlProvince.Items[DdlProvince.SelectedIndex].ToString());
    }
    private void setSchoolName_Province(string schoolName)
    {
        DdlSchoolName.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();


        if (DdlImportYear.SelectedValue.ToString() == Resources.Resource.DdlTypeImportYear)
        {
            Query = "select School from Account " +
                   "left join Area on Account.zipcode = Area.ID " +
                   "where area.name =N'" + schoolName + "'" + " and School not like N'%專家%' and School not like N'%管理者%' " +
                   "group by School ";
        }
        else if (DdlImportYear.SelectedValue.ToString() != Resources.Resource.DdlTypeImportYear)
        {
            Query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.ID " +
                    "where area.name =N'" + schoolName + "'" + " and School not like N'%專家%' and School not like N'%管理者%' " +
                    "and Account.ImportYear =" + DdlImportYear.SelectedValue.ToString() + " " +
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
    protected void DdlImportYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlProvince.SelectedIndex == 0)
            return;

        setSchoolName_ImportYear(DdlProvince.Items[DdlProvince.SelectedIndex].ToString());
    }
    private void setSchoolName_ImportYear(string schoolName)
    {
        DdlSchoolName.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        if (DdlImportYear.SelectedValue.ToString() == Resources.Resource.DdlTypeImportYear)
        {
            Query = "select School from Account " +
                   "left join Area on Account.zipcode = Area.ID " +
                   "where area.name =N'" + schoolName + "'" + " and School not like N'%專家%' and School not like N'%管理者%' " +
                   "group by School ";
        }
        else if (DdlImportYear.SelectedValue.ToString() != Resources.Resource.DdlTypeImportYear)
        {
            Query = "select School from Account " +
                    "left join Area on Account.zipcode = Area.ID " +
                    "where area.name =N'" + schoolName + "'" + " and School not like N'%專家%' and School not like N'%管理者%' " +
                    "and Account.ImportYear =" + DdlImportYear.SelectedValue.ToString() + " " +
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
}