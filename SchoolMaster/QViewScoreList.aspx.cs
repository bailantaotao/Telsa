using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_QViewScoreList : System.Web.UI.Page
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
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

        removeSession("ViewStudentList");
        removeSession("QVSL_PageSelect_SelectedIndexChanged");
        removeSession("QVST_DdlGradeLevel_SelectedIndexChanged");
        removeSession("QVST_DdlClass_SelectedIndexChanged");
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
            case DdlType.Year:
                setYear();
                break;
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
    //private void setSchoolName()
    //{
    //    ManageSQL ms = new ManageSQL();
    //    ArrayList data = new ArrayList();

    //    Query = "select School from Account " +
    //                        "left join Area on Account.zipcode = Area.ID " +
    //                        "where School not like N'%專家%' and School not like N'%管理%' " +
    //                        "group by School ";


    //    if (!ms.GetAllColumnData(Query, data))
    //    {
    //        DdlSchoolName.Items.Add("None");
    //        return;
    //    }

    //    if (data.Count == 0)
    //    {
    //        DdlSchoolName.Items.Add("None");
    //        return;
    //    }
    //    DdlSchoolName.Items.Add(Resources.Resource.DdlTypeSchoolname);
    //    foreach (string[] province in data)
    //    {
    //        DdlSchoolName.Items.Add(province[0]);
    //    }
    //}



    private void SearchType()
    {
        StringBuilder sb = new StringBuilder();
        getSchoolName(sb);
        Session["SchoolName"] = sb.ToString();

        Query = "select QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School " +
                "from QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + " " +
                "where QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".Zipcode = '" + Session["Province"].ToString() + "'";

        

        Session["QViewScoreList"] = Query;
        //StringBuilder sb = new StringBuilder();
        //getSchoolName(sb);
        //Session["SchoolName"] = sb.ToString();

        //Query = "select QList.SN, QList.Year, Qlist.Deadline, Qlist.Semester, QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School  " +
        //        "from QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + "  " +
        //        "left join QScore on QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".StudentID = QScore.StudentID  " +
        //        "left join QList on QList.SN = QScore.ListSN " +
        //        "left join Account on Account.School = QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School ";

        //string tmp = string.Empty;
        //string[] storeParam = new string[4];
        //string[] sqlParam = new string[] { "QList.Year", "QList.Semester", "QScore.School", "Account.Zipcode" };
        //storeParam[0] = DdlYear.SelectedIndex == 0 ? null : DdlYear.Items[DdlYear.SelectedIndex].ToString();
        //storeParam[1] = DdlSemester.SelectedIndex == 0 ? null : DdlSemester.SelectedValue;
        //storeParam[2] = DdlSchoolName.SelectedIndex == 0 ? null : DdlSchoolName.Items[DdlSchoolName.SelectedIndex].ToString();
        //storeParam[3] = DdlProvince.SelectedIndex == 0 ? null : DdlProvince.SelectedValue;


        //for (int i = 0; i < storeParam.Length; i++)
        //{
        //    if (!string.IsNullOrEmpty(storeParam[i]))
        //    {
        //        if (string.IsNullOrEmpty(tmp))
        //        {
        //            tmp += "where " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
        //        }
        //        else
        //        {
        //            tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
        //        }

        //    }
        //}
        //Query += (tmp.Length > 0) ? tmp + "and QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School <> '' " : "where QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + ".School <> '' ";



        //Query += "order by QList.Year desc, QList.Semester asc";
        //Session["PlanList"] = Query;
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
        Query = Session["QViewScoreList"].ToString();
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
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }

}