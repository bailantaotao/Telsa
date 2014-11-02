using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideViewList : System.Web.UI.Page
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
    private const string SCHOOLNAME = "SCHOOLNNAME";


    private StringBuilder schoolName = new StringBuilder();
    private StringBuilder schoolID = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            HyperLink1.Visible = false;
            img.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            getSchoolName(schoolName);

            if (!verifyValid())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanErrorData + "');window.location='GuidePreList.aspx';", true);
                return;
            }
        }
            
        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            if (!verifyValid_MingDer())
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanErrorData + "');window.location='GuidePreList.aspx';", true);
                return;
            }
            getSchoolName(schoolName);
            getSchoolID(schoolID);
        }
        if (!IsPostBack)
        {
            setInitial();
        }
    }
    private void SearchType()
    {

        Query = "select GuideList.GuideYear, GuideListUser.SN from GuideListUser " +
                "left join GuideList on GuideListUser.GuideListSN = GuideList.SN " +
                "where GuideSchool = N'" + schoolName.ToString() + "'" +
                "and GuideList.GuideYear = '" + Request["YEAR"].ToString() + "'";
    }
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    private bool getSchoolID(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select UserID from Account where School = '" + Request["SCHOOLNAME"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    private string getSemster()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select GuideList.GuideSemester from GuideList " +
                       "left join GuideListUser on GuideListUser.GuideListSN = GuideList.SN " +
                       "where GuideListUser.SN='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetOneData(query, sb);
        return sb.ToString();
    }
    private bool verifyValid()
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
    }
    private bool verifyValid_MingDer()
    {
        if (String.IsNullOrEmpty(Request["SN"]) || String.IsNullOrEmpty(Request["YEAR"]) || String.IsNullOrEmpty(Request["SCHOOLNAME"]))
            return false;

        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "select Count(GuideStatus) " +
                        "from GuideListUser " +
                        "left join GuideList on GuideListUser.GuideListSN = GuideList.SN " +
                        "where GuideListUser.GuideListSN ='" + Request["SN"].ToString() + "' and GuideList.GuideYear = '" + Request["YEAR"].ToString() + "' and GuideListUser.GuideSchool=N'" + Request["SCHOOLNAME"].ToString() + "'";
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
            query = "select SN from GuideListUser where GuideListSN = '" + Request["SN"].ToString() + "' and GuideSchool=N'" + Request["SCHOOLNAME"].ToString() + "'";
            ms.GetOneData(query, sb);
            Session["UserGuideListSN"] = sb.ToString();
        }
        Session["GuideSN"] = Request["SN"].ToString();
        Session["GuideYear"] = Request["YEAR"].ToString();
        Session["SCHOOLNAME"] = Request["SCHOOLNAME"].ToString();

        return true;
    }


    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideViewPreList.aspx");
    }
    /*protected void BtnUploadAttachment_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('GuideItemUpload.aspx', '', config='height=500,width=550')", true);
    }*/
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rowIndex++;
                }
            }
        }
    }
    private bool getUploadDir(string targetName, StringBuilder sb, StringBuilder outFile)
    {
        string saveDir = @"Upload\Stage4\";
        string appPath = Request.PhysicalApplicationPath;
        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + getSemster() + targetName;
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
    protected void btn_Download(object sender, EventArgs e)
    {
        /*string TargetName = "";
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select GuideItemName" +
                       "from GuideItem " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                TargetName = d[0];
            }
            return;
        }*/

        string TargetName = "";
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;

                string query = "select GuideItemName" +
                       "from GuideItem " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and ItemNo = '" + (Convert.ToInt32(yourAssignedValue) + 1);
                ms.GetAllColumnData(query, data);

                if (data.Count > 0)
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        string[] d = (string[])data[i];
                        TargetName = d[0];
                    }
                    return;
                }
                StringBuilder sb = new StringBuilder();
                StringBuilder sbOutFile = new StringBuilder();
                if (getUploadDir(TargetName, sb, sbOutFile))
                    xDownload(sb.ToString(), sbOutFile.ToString());
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.PlanTipUploadError + "');", true);
            }
            catch
            {
                //Check for exception
            }
        }
    }
    private void setInitial()
    {
       
    }
}