using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_QInputScore : System.Web.UI.Page
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

        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            setGradeLevel();
            if (Session["QViewScore"] != null)
                Query = Session["QViewScore"].ToString();
            else
                SearchType();
            
            LoadInternetStudy(1);            
        }

        if (GetPostBackControlId(this).Equals(BtnStore.UniqueID))
        {
            
        }
    }

    public string GetPostBackControlId(Page page)
    {
        if (!page.IsPostBack)
            return string.Empty;

        Control control = null;
        // first we will check the "__EVENTTARGET" because if post back made by the controls
        // which used "_doPostBack" function also available in Request.Form collection.
        string controlName = page.Request.Params["__EVENTTARGET"];
        if (!String.IsNullOrEmpty(controlName))
        {
            control = page.FindControl(controlName);
        }
        else
        {
            // if __EVENTTARGET is null, the control is a button type and we need to
            // iterate over the form collection to find it

            // ReSharper disable TooWideLocalVariableScope
            string controlId;
            Control foundControl;
            // ReSharper restore TooWideLocalVariableScope

            foreach (string ctl in page.Request.Form)
            {
                // handle ImageButton they having an additional "quasi-property" 
                // in their Id which identifies mouse x and y coordinates
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    controlId = ctl.Substring(0, ctl.Length - 2);
                    foundControl = page.FindControl(controlId);
                }
                else
                {
                    foundControl = page.FindControl(ctl);
                }

                if (!(foundControl is Button)) continue;

                control = foundControl;
                break;
            }
        }

        return control == null ? String.Empty : control.ID;
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
        string yearSemester = LbYear.Text.Trim()+LbSemester.Text.Trim();

        Query = "select QStudent" + yearSemester + ".GradeLevel, QStudent" + yearSemester + ".Class, QStudent" + yearSemester + ".StudentID, QStudent" + yearSemester + ".Name, QScore" + yearSemester + ".Chinese, QScore" + yearSemester + ".English, QScore" + yearSemester + ".Math, QScore" + yearSemester + ".Society, QScore" + yearSemester + ".Science, QScore" + yearSemester + ".Music, QScore" + yearSemester + ".Physical, QScore" + yearSemester + ".Art " +
                "from QStudent" + yearSemester + " " +
                "left join QScore" + yearSemester + " on QScore" + yearSemester + ".StudentID = QStudent" + yearSemester + ".StudentID ";

        string tmp = string.Empty;
        string[] storeParam = new string[4];
        string[] sqlParam = new string[] { "QStudent" + yearSemester + ".GradeLevel", "QStudent" + yearSemester + ".Class", "QStudent" + yearSemester + ".Name", "QStudent" + yearSemester + ".School" };
        storeParam[0] = DdlGradeLevel.SelectedIndex == 0 ? null : DdlGradeLevel.SelectedValue;
        storeParam[1] = DdlClass.SelectedIndex == 0 ? null : DdlClass.SelectedValue;
        storeParam[2] = DdlStudentName.SelectedIndex == 0 ? null : DdlStudentName.SelectedValue;
        storeParam[3] = LbSchool.Text.Trim();


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
        Query += tmp;


        Query += "order by QStudent" + yearSemester + ".StudentID asc";
        Session["QViewScore"] = Query;

        //Query = "select QStudent" + yearSemester + ".Name, QStudent" + yearSemester + ".IdentifyID, QStudent" + yearSemester + ".GradeLevel, QStudent" + yearSemester + ".Class, QStudent" + yearSemester + ".StudentID " +
        //        "from QStudent" + yearSemester +" " +
        //        "left join QScore"+yearSemester+" on QScore"+yearSemester+".StudentID =QStudent"+yearSemester+".StudentID ";


        //string tmp = string.Empty;
        //string[] storeParam = new string[3];
        //string[] sqlParam = new string[] { "QStudent" + yearSemester + ".GradeLevel", "QStudent" + yearSemester + ".Class", "QStudent" + yearSemester + ".StudentNo" };
        //storeParam[0] = DdlGradeLevel.SelectedIndex == 0 ? null : DdlGradeLevel.SelectedValue;
        //storeParam[1] = DdlClass.SelectedIndex == 0 ? null : DdlClass.SelectedValue;
        //storeParam[2] = DdlStudentName.SelectedIndex == 0 ? null : DdlStudentName.SelectedValue;


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

        //Query += "order by  QStudent" + yearSemester + ".StudentID asc";
        //Session["ViewScore"] = Query;
    }

    private void LoadInternetStudy(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();

        LbCompleted.Text = "<table style='width:750px;'>";
        LbCompleted.Text += "<tr align='center' style='background-color:#0008ff;'>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "年级" + "</font></td>";
        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "班级" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "班内学号" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "语文" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "数学" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "英语" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "品德与社会" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "科学" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "音乐" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "体育" + "</font></td>";

        LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'><font color='white'>";
        LbCompleted.Text += "美术" + "</font></td>";

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


                // 年级
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[0] + "</td>";

                // 班级
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[1] + "</td>";

                // 班内学号
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += ((string[])(data[i]))[2] + "</td>";

                // 语文
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                //if (((string[])(data[i]))[3].Equals(""))
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";
                //else
                //    LbCompleted.Text += ((string[])(data[i]))[3] + "</td>";

                // 数学
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";

                // 英语
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";

                // 品德与社会
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";

                // 科学
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";

                // 音乐
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";

                // 体育
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";

                // 美术
                LbCompleted.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += "<input name='txtemail' id='score' runat='server' type='text' size='3' maxlength='3' value='" + ((string[])(data[i]))[3] + "' /></td>";
                
                LbCompleted.Text += "</tr>";

                Flag++;
            }
            goto FINALLY;
        }

        NODATA:
            LbCompleted.Text += "<tr align='center' style='background-color:#FFFFFF;' colspan = '5'>";
            LbCompleted.Text += "<td colspan = '11' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
            LbCompleted.Text += "该班级找不到任何学生的成绩</td>";
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
        Query = Session["QViewScore"].ToString();
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

    protected void DdlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVS_DdlGradeLevel_SelectedIndexChanged"] = DdlGradeLevel.SelectedValue;
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
            
            DdlStudentName.Items.Clear();
            DdlStudentName.Items.Add(new ListItem("学生姓名", "0"));

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
        Query = "select class from QGradeClassHistory "+
            "where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and ListSN = '" + listSN + "' and GradeLevel = '" + Session["QVS_DdlGradeLevel_SelectedIndexChanged"].ToString() + "'";
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

    protected void DdlStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    private void setStudentName()
    {
        DdlStudentName.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select Name from QStudent"+LbYear.Text.Trim()+LbSemester.Text.Trim()+" where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and Class = '" + DdlClass.SelectedValue + "'";


        if (!ms.GetAllColumnData(Query, data))
        {
            DdlStudentName.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlStudentName.Items.Add("None");
            return;
        }
        DdlStudentName.Items.Add("学生姓名");
        foreach (string[] studetnName in data)
        {
            DdlStudentName.Items.Add(studetnName[0]);
        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVS_DdlClass_SelectedIndexChanged"] = DdlClass.SelectedValue;
        setStudentName();
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {

    }
}