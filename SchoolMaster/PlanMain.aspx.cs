using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanMain : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string semester = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);
                
        if (!verifyValid())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanErrorData + "');window.location='PlanList.aspx';", true);
            return;
        }
        if (!IsPostBack)
        {

            LbStatus1.Text = (getUploadSuccess(1)) ? "Yes" : "No";
            LbStatus2.Text = (getUploadSuccess(2)) ? "Yes" : "No";
            LbStatus3.Text = (getUploadSuccess(3)) ? "Yes" : "No";
            LbStatus4.Text = (getUploadSuccess(4)) ? "Yes" : "No";
            LbStatus5.Text = (getUploadSuccess(5)) ? "Yes" : "No";
            LbStatus6.Text = (getUploadSuccess(6)) ? "Yes" : "No";
            LbStatus7.Text = (getUploadSuccess(7)) ? "Yes" : "No";
            LbStatus8.Text = (getUploadSuccess(8)) ? "Yes" : "No";
        }
    }

    private bool getUploadSuccess(int targetIndex)
    {
        string saveDir = @"Upload\Stage3\";
        string appPath = Request.PhysicalApplicationPath;
        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + getSemster() + targetIndex;
        string pathToCheck = appPath + saveDir + fileName;

        //===========================================(Start)
        foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
        {
            if (file.Contains(fileName))
            {
                return true;
            }
        }
        return false;
    }

    private void SearchType()
    {

        Query = "select planList.PlanYear, planlistuser.sn, planlistuser.planstatus from planlistuser " +
                "left join planlist on PlanListUser.PlanListSN = PlanList.SN " +                
                "where PlanSchool = N'" + schoolName.ToString() + "'" +
                "and PlanList.PlanYear = '" + Request["YEAR"].ToString() + "'";
    }
        
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    private bool verifyValid()
    {
        if (String.IsNullOrEmpty(Request["SN"]) || String.IsNullOrEmpty(Request["YEAR"]))
            return false;

        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select Count(PlanStatus) "+
                        "from PlanlistUser "+
                        "left join planlist on PlanListUser.PlanListSN = PlanList.SN " +
                        "where PlanListUser.PlanListSN ='" + Request["SN"].ToString() + "' and PlanList.planyear = '" + Request["YEAR"].ToString() + "' and PlanListUser.PlanSchool=N'" + Session["schoolName"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;

        // 如果是0代表沒有任何資料
        if (sb.ToString().Equals("0"))
        {
            query = "insert into PlanListUser (PlanListSN, PlanStatus, PlanStartTime, PlanSchool) VALUES ('" +
                    Request["SN"].ToString() + "','" +
                    false + "','" +
                    DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "',N'" +
                    schoolName.ToString() + "')";
            ms.WriteData(query, sb);
            query = "select top 1 (SN) from PlanListUser";
            ms.GetOneData(query, sb);
            Session["UserPlanListSN"] = sb.ToString();
        }      
        else
        {
            //非0，所以有資料
            query = "select SN from PlanListUser where PlanListSN = '" + Request["SN"].ToString() + "' and PlanSchool=N'" + Session["schoolName"].ToString() + "'";
            ms.GetOneData(query, sb);
            Session["UserPlanListSN"] = sb.ToString();
        }
        Session["PlanSN"] = Request["SN"].ToString();
        Session["PlanYear"] = Request["YEAR"].ToString();

        return true;
    }



    protected void LkbPlanItem5_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem5.aspx");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.CommandArgument.Equals("1"))
        {
            Session["targetUploadIndex"] = 1;
        }
        else if (btn.CommandArgument.Equals("2"))
        {
            Session["targetUploadIndex"] = 2;
        }
        else if (btn.CommandArgument.Equals("3"))
        {
            Session["targetUploadIndex"] = 3;
        }
        else if (btn.CommandArgument.Equals("4"))
        {
            Session["targetUploadIndex"] = 4;
        }
        else if (btn.CommandArgument.Equals("5"))
        {
            Session["targetUploadIndex"] = 5;
        }
        else if (btn.CommandArgument.Equals("6"))
        {
            Session["targetUploadIndex"] = 6;
        }
        else if (btn.CommandArgument.Equals("7"))
        {
            Session["targetUploadIndex"] = 7;
        }
        else if (btn.CommandArgument.Equals("8"))
        {
            Session["targetUploadIndex"] = 8;
        }
        else if (btn.CommandArgument.Equals("9"))
        {
            Session["targetUploadIndex"] = 9;
        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanItemUpload.aspx', '', config='height=500,width=550')", true);
    }
    protected void LkbPlanItem6_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem6.aspx");
    }
    protected void LkbPlanItem7_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem7.aspx");

    }
    protected void LkbPlanItem8_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem8.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("PlanList.aspx");
    }
    private bool getUploadDir(int targetIndex, StringBuilder sb, StringBuilder outFile)
    {
        string saveDir = @"Upload\Stage3\";
        string appPath = Request.PhysicalApplicationPath;
        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + getSemster() + targetIndex;
        string pathToCheck = appPath + saveDir + fileName;

        //===========================================(Start)
        foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
        {
            if (file.Contains(fileName))
            {
                sb.Clear();
                outFile.Clear();
                fileName = file.Substring(file.LastIndexOf("\\"), file.Length - file.LastIndexOf("\\"));
                sb.Append(Request.PhysicalApplicationPath + saveDir + fileName);
                outFile.Append(fileName);
                return true;
            }
        }
        return false;
    }

    public bool xDownload(string xFile, string out_file)
    //xFile 路徑+檔案, 設定另存的檔名
    {
        if (File.Exists(xFile))
        {
            try
            {
                FileInfo xpath_file = new FileInfo(xFile);  //要 using System.IO;
                // 將傳入的檔名以 FileInfo 來進行解析（只以字串無法做）
                System.Web.HttpContext.Current.Response.Clear(); //清除buffer
                System.Web.HttpContext.Current.Response.ClearHeaders(); //清除 buffer 表頭
                System.Web.HttpContext.Current.Response.Buffer = false;
                System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
                // 檔案類型還有下列幾種"application/pdf"、"application/vnd.ms-excel"、"text/xml"、"text/HTML"、"image/JPEG"、"image/GIF"
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(out_file, System.Text.Encoding.UTF8));
                // 考慮 utf-8 檔名問題，以 out_file 設定另存的檔名
                System.Web.HttpContext.Current.Response.AppendHeader("Content-Length", xpath_file.Length.ToString()); //表頭加入檔案大小
                System.Web.HttpContext.Current.Response.WriteFile(xpath_file.FullName);

                // 將檔案輸出
                System.Web.HttpContext.Current.Response.Flush();
                // 強制 Flush buffer 內容
                System.Web.HttpContext.Current.Response.End();
                return true;

            }
            catch (Exception e)
            { return false; }

        }
        else
            return false;
    }
    protected void LkbDownloadItem1_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(1, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem2_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(2, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem3_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(3, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem4_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(4, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem5_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(5, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem6_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(6, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem7_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(7, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem8_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(8, sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }

    private string getSemster()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanList.PlanSemester from PlanList " +
                       "left join PlanListUser on PlanListUser.PlanListSN = PlanList.SN " +
                       "where PlanListUser.SN='" + Session["UserPlanListSN"].ToString() + "'";
        ms.GetOneData(query, sb);
        return sb.ToString();
    }

    protected void LkbPlanItem2_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem2.aspx");
    }
    protected void LkbPlanItem3_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem3.aspx");
    }
    protected void LkbPlanItem4_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem4.aspx");
    }
    protected void LkbPlanItem4_2_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem4_2.aspx");
    }
    protected void LkbPlanItem9_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem9.aspx");
    }
    protected void LkbPlanItem11_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem11.aspx");
    }
    protected void LkbPlanItem1_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanItem1.aspx");
        
    }
    protected void ButtonDownLoad_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(Convert.ToInt32(btn.CommandArgument), sb, sbOutFile))
            xDownload(sb.ToString(), sbOutFile.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);

    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}