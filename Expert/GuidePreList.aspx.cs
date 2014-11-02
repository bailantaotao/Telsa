using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuidePreList : System.Web.UI.Page
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

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            IsMingDer = true;
            Response.Redirect("GuideViewPreList.aspx");
        }
        else
        {
            IsMingDer = false;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
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
        
        /*if (!verifyValid())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanErrorData + "');window.location='GuidePreList.aspx';", true);
            return;
        }*/
        Session["UserName"] = LbUserName.Text;
        Session["UserID"] = LbUserID.Text;
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
    /*private bool verifyValid()
    {
        if (String.IsNullOrEmpty(Request["SN"]) || String.IsNullOrEmpty(Request["YEAR"]))
            return false;

        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select Count(GuideStatus) " +
                        "from GuideListUser " +
                        "left join GuideList on GuideListUser.GuideListSN = GuideList.SN " +
                        "where GuideListUser.GuideListSN ='" + Request["SN"].ToString() + "' and GuideList.GuideYear = '" + Request["YEAR"].ToString() + "' and GuideListUser.GuideSchool=N'" + Session["schoolName"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;

        // 如果是0代表沒有任何資料
        if (sb.ToString().Equals("0"))
        {
            query = "insert into GuideListUser (GuideListSN, GuideStatus, GuideSchool) VALUES ('" +
                    Request["SN"].ToString() + "',N'" +
                    false + "',N'" +
                    schoolName.ToString() + "')";
            ms.WriteData(query, sb);
            query = "select top 1 (SN) from GuideListUser";
            ms.GetOneData(query, sb);
            Session["UserGuideListSN"] = sb.ToString();
        }
        else
        {
            //非0，所以有資料
            query = "select SN from GuideListUser where GuideListSN = '" + Request["SN"].ToString() + "' and GuideSchool=N'" + Session["schoolName"].ToString() + "'";
            ms.GetOneData(query, sb);
            Session["UserGuideListSN"] = sb.ToString();
        }
        Session["GuideSN"] = Request["SN"].ToString();
        Session["GuideYear"] = Request["YEAR"].ToString();

        return true;
    }*/
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
                LbCompleted.Text += "<a href='GuideList.aspx?" + EncryptSN + "&" + EncryptYEAR + "'>";
                LbCompleted.Text += "编辑" ;
                LbCompleted.Text += "</a>";
                   
                LbCompleted.Text += "</td>";
                LbCompleted.Text += "</tr>";

                Flag++;

                Session["GuideYear"] = ((string[])(data[i]))[1];
                Session["GuideSemester"] = ((string[])(data[i]))[2];
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
        Query = Session["PlanList"].ToString();
        LoadInternetStudy(DdlPageSelect.SelectedIndex + 1);
    }
}