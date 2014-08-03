using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewMain : System.Web.UI.Page
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
                           
        }
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
                        "where PlanListUser.PlanListSN ='" + Request["SN"].ToString() + "' and PlanList.planyear = '" + Request["YEAR"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;

        // 如果是0代表沒有任何資料
        if (sb.ToString().Equals("0"))
        {
            query = "insert into PlanListUser (PlanListSN, PlanStatus, PlanStartTime, PlanSchool) VALUES ('" +
                    Request["SN"].ToString() + "','" +
                    false + "','" +
                    DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "','" +
                    schoolName.ToString() + "')";
            ms.WriteData(query, sb);
            query = "select top 1 (SN) from PlanListUser";
            ms.GetOneData(query, sb);
            Session["UserPlanListSN"] = sb.ToString();
        }      
        else
        {
            //非0，所以有資料
            query = "select SN from PlanListUser where PlanListSN = '" + Request["SN"].ToString() + "'";
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

        Response.Redirect("PlanViewItem5.aspx");
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanItemUpload.aspx', '', config='height=500,width=550')", true);
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
            Response.Redirect(sb.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem3_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(3, sb, sbOutFile))
            Response.Redirect(sb.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem4_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(4, sb, sbOutFile))
            Response.Redirect(sb.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem5_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(5, sb, sbOutFile))
            Response.Redirect(sb.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem6_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(6, sb, sbOutFile))
            Response.Redirect(sb.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem7_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(7, sb, sbOutFile))
            Response.Redirect(sb.ToString());
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
    }
    protected void LkbDownloadItem8_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbOutFile = new StringBuilder();
        if (getUploadDir(8, sb, sbOutFile))
            Response.Redirect(sb.ToString());
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
    protected void LkbPlanItem6_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanViewItem6.aspx");
    }
    protected void LkbPlanItem7_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanViewItem7.aspx");
    }
    protected void LkbPlanItem8_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select PlanSemester from PlanList where SN = '" + Request["SN"].ToString() + "'";
        ms.GetOneData(query, sb);
        Session["Semester"] = sb.ToString();

        Response.Redirect("PlanViewItem8.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString());
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("PlanList.aspx");
    }
}