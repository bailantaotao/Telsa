using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_QViewStudent : System.Web.UI.Page
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

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserID"] = "admin";
        //Session["ListSN"] = "1";
        //Session["SchoolID"] = "巴彦淖尔市磴口县渡口镇明德小学";
        //Session["Year"] = "2014";
        //Session["Semester"] = "1";

        LbYear.Text = Request[YEAR].ToString();
        LbSchoolNo.Text = getSchoolNo(Request[SCHOOLNAME].ToString());
        LbSemester.Text = Request[SEMESTER].ToString();
        LbSchool.Text = Request[SCHOOLNAME].ToString();   

        //getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            setGradeLevel();
            if (Session["QViewStudent"] != null)
                Query = Session["QViewStudent"].ToString();
            else
                SearchType();

            LoadInternetStudy(1);
            
        }

    }

    private string getSchoolNo(string schoolName)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select UserID from Account where school = N'" + schoolName + "'";
        ms.GetOneData(query, sb);

        if (sb.ToString().Equals(""))
            return "Unknown type";
        return sb.ToString();
    }

    private void setGradeLevel()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select GradeLevel from QGrade order by GradeLevel asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlGradeLevel.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlGradeLevel.Items.Add("None");
            return;
        }
        DdlGradeLevel.Items.Add("年级");
        foreach (string[] gradelevel in data)
        {
            DdlGradeLevel.Items.Add(gradelevel[0]);
        }
    }

    private void SearchType()
    {
        string yearSemester = LbYear.Text.Trim() + LbSemester.Text.Trim();
        Query = "select QStudent" + yearSemester + ".Name, QStudent" + yearSemester + ".IdentifyID, QStudent" + yearSemester + ".GradeLevel, QStudent" + yearSemester + ".Class, QStudent" + yearSemester + ".StudentID " +
                "from QStudent" + yearSemester + " ";

        string tmp = string.Empty;
        string[] storeParam = new string[3];
        string[] sqlParam = new string[] { "QStudent" + yearSemester + ".GradeLevel", "QStudent" + yearSemester + ".Class", "QStudent" + yearSemester + ".Name" };
        storeParam[0] = DdlGradeLevel.SelectedIndex == 0 ? null : DdlGradeLevel.SelectedValue;
        storeParam[1] = DdlClass.SelectedIndex == 0 ? null : DdlClass.SelectedValue;
        storeParam[2] = DdlStudentID.SelectedIndex == 0 ? null : DdlStudentID.SelectedValue;
        

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
        //Query += (tmp.Length > 0) ? tmp + "and QScore.QSchool <> '' " : "where QScore.QSchool <> '' ";
        Query += tmp;



        Query += "order by QStudent" + yearSemester + ".StudentID asc";
        Session["QViewStudent"] = Query;
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

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "<table style='width:750px;'>";
            LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "学生姓名" + "</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "身分证件号</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "年级</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "班级</font></td>";
            LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbCompleted.Text += "班内学号</font></td>";
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

                
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#FFFFFF;' colspan = '6'>";
            LbCompleted.Text += "<td colspan = '6' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += "该班级找不到任何学生的资料</td>";
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
        Query = Session["QViewStudent"].ToString();
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
        Response.Redirect("../SystemManagerIndex.aspx");
    }
    protected void BtnStudentSearch_Click(object sender, EventArgs e)
    {
        if ((!TbIdentifyId.Text.Trim().Equals("") && TbStudentName.Text.Trim().Equals("")) || (TbIdentifyId.Text.Trim().Equals("") && !TbStudentName.Text.Trim().Equals("")) || (!TbIdentifyId.Text.Trim().Equals("") && !TbStudentName.Text.Trim().Equals("")))
        {
            string yearSemester = LbYear.Text.Trim() + LbSemester.Text.Trim();
            ManageSQL ms = new ManageSQL();
            ArrayList data = new ArrayList();

            /** 這邊的查詢學生是用or，不是and */
            string query = "select Name, IdentifyID from QStudent" + yearSemester + " where " +
                (TbStudentName.Text.Trim().Equals("") ? ("") : ("Name = '" + TbStudentName.Text.Trim() + "' ")) +
                (TbStudentName.Text.Trim().Equals("") ? ("IdentifyID = '" + TbIdentifyId.Text.Trim() + "'") : ("or IdentifyID = '" + TbIdentifyId.Text.Trim() + "'"));

            ms.GetAllColumnData(query, data);

            LbStudentContent.Text = "<table style='width:750px;'>";
            LbStudentContent.Text += "<tr align='center' style='background-color:#0008ff;'>";
            LbStudentContent.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbStudentContent.Text += "学年</font></td>";
            LbStudentContent.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbStudentContent.Text += "学生姓名</font></td>";
            LbStudentContent.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
            LbStudentContent.Text += "身分证件号</font></td>";
            LbStudentContent.Text += "</tr>";

            if (data.Count == 0)
            {
                goto NOSTUDENT;
            }
            else 
            {
                LbStudentContent.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbStudentContent.Text += LbYear.Text.Trim() + "</td>";
                LbStudentContent.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbStudentContent.Text += ((string[])(data[0]))[0] + "</td>";
                LbStudentContent.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbStudentContent.Text += ((string[])(data[0]))[1] + "</td>";
                goto STUDENTFINALLY;
            }
        NOSTUDENT:
            LbStudentContent.Text += "<tr align='center' style='background-color:#FFFFFF;'>";
            LbStudentContent.Text += "<td colspan = '3' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbStudentContent.Text += "没有这笔学生的资料</td>";
            LbStudentContent.Text += "</tr>";

        STUDENTFINALLY:
            LbStudentContent.Text += "</table>";


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('请至少在学生姓名或身分证件号输入资料');", true);
        }
    }
    protected void DdlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVST_DdlGradeLevel_SelectedIndexChanged"] = DdlGradeLevel.SelectedValue;
        if (DdlGradeLevel.SelectedIndex == 0)
            return;

        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        string query = "select SN from QList where Year = '" + LbYear.Text + "' and Semester = '" + LbSemester.Text + "'";
        ms.GetOneData(query, sb);

        string listSN = sb.ToString();

        query = "select count(GradeLevel) from QGradeClassHistory where ListSN = '" + listSN + "' and GradeLevel = '" + DdlGradeLevel.SelectedValue + "'";
        ms.GetOneData(query, sb);

        if (sb.ToString().Equals("0"))
        {
            DdlGradeLevel.SelectedIndex = 0;

            DdlClass.Items.Clear();
            DdlClass.Items.Add(new ListItem("班级", "0"));

            DdlStudentID.Items.Clear();
            DdlStudentID.Items.Add(new ListItem("班内学号", "0"));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('目前该年级尚未键入任何学生之资料');", true);
            return;
        }

        setClass(listSN);
    }

    private void setClass(string listSN)
    {
        DdlClass.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select class from QGradeClassHistory " +
                "where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and ListSN = '" + listSN + "' and GradeLevel = '" + Session["QVST_DdlGradeLevel_SelectedIndexChanged"].ToString() + "'";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlClass.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlClass.Items.Add("None");
            return;
        }
        DdlClass.Items.Add("班級");
        foreach (string[] Class in data)
        {
            DdlClass.Items.Add(Class[0]);
        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVST_DdlClass_SelectedIndexChanged"] = DdlClass.SelectedValue;
        setStudentID();
    }

    private void setStudentID()
    {
        DdlStudentID.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select Name from QStudent" + LbYear.Text.Trim() + LbSemester.Text.Trim() + " where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and Class = '" + DdlClass.SelectedValue + "'";


        if (!ms.GetAllColumnData(Query, data))
        {
            DdlStudentID.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlStudentID.Items.Add("None");
            return;
        }
        DdlStudentID.Items.Add("班内学号");
        foreach (string[] studetnName in data)
        {
            DdlStudentID.Items.Add(studetnName[0]);
        }
    }
}