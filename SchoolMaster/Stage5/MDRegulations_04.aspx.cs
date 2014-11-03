using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stage5_MDRegulations_04 : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FileIsToLarge"] != null)
        {
            Session.Remove("FileIsToLarge");
        }
        if (!IsPostBack)
        {
            /*LbStatus1.Text = (getUploadSuccess(1)) ? "Yes" : "No";
            LbStatus2.Text = (getUploadSuccess(2)) ? "Yes" : "No";
            LbStatus3.Text = (getUploadSuccess(3)) ? "Yes" : "No";
            LbStatus4.Text = (getUploadSuccess(4)) ? "Yes" : "No";*/
        }
    }
    protected void SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SelectValue"] = DlRegulationSelect.SelectedValue;
        if (DlRegulationSelect.SelectedValue == "1")
            Response.Redirect("MDRegulations_01.aspx");
        if (DlRegulationSelect.SelectedValue == "2")
            Response.Redirect("MDRegulations_02.aspx");
        if (DlRegulationSelect.SelectedValue == "3")
            Response.Redirect("MDRegulations_03.aspx");
        if (DlRegulationSelect.SelectedValue == "4")
            Response.Redirect("MDRegulations_04.aspx");
        if (DlRegulationSelect.SelectedValue == "5")
            Response.Redirect("MDRegulations_05.aspx");
        if (DlRegulationSelect.SelectedValue == "6")
            Response.Redirect("MDRegulations_06.aspx");
        if (DlRegulationSelect.SelectedValue == "7")
            Response.Redirect("MDRegulations_07.aspx");
    }
    /*private bool getUploadSuccess()
    {
        //int targetIndex
        string saveDir = @"Upload\Stage5\";
        string appPath = Request.PhysicalApplicationPath;
        string fileName1 = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") +  targetIndex;  //目前刪除getSemester()函示不做學期的判斷
        string pathToCheck1 = appPath + saveDir + fileName1;
        string fileName2 = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + targetIndex;  //目前刪除getSemester()函示不做學期的判斷
        string pathToCheck2 = appPath + saveDir + fileName2;
        string fileName3 = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + targetIndex;  //目前刪除getSemester()函示不做學期的判斷
        string pathToCheck3 = appPath + saveDir + fileName3;
        string fileName4 = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + targetIndex;  //目前刪除getSemester()函示不做學期的判斷
        string pathToCheck4 = appPath + saveDir + fileName4;

        //===========================================(Start)
        foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
        {
            if (file.Contains(fileName1))
            {
                LbStatus1.Text = "Yes";
                //return true;
            }
            else
            {
                LbStatus1.Text = "No";
            }
            if (file.Contains(fileName2))
            {
                LbStatus2.Text = "Yes";
                //return true;
            }
            else
            {
                LbStatus2.Text = "No";
            }
            if (file.Contains(fileName3))
            {
                LbStatus3.Text = "Yes";
                //return true;
            }
            else
            {
                LbStatus3.Text = "No";
            }
            if (file.Contains(fileName4))
            {
                LbStatus4.Text = "Yes";
                //return true;
            }
            else
            {
                LbStatus4.Text = "No";
            }
        }
        return false;
    }*/

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.CommandArgument.Equals("1"))
        {
            if (FileUpload1.FileName.Length == 0)
            {
                //LbStatus1.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload1.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                string[] allowExtensions = { ".doc", ".docx" };
                bool isFind = false;
                foreach (string tag in allowExtensions)
                {
                    if (fileExtension.Equals(tag))
                        isFind = true;
                }
                if (!isFind)
                {
                    //LbStatus1.Text = "上传格式必须为WORD (*.doc, *.docx)";
                    return;
                }
            }
            string saveDir = @"Upload\Stage5\";
            string appPath = Request.PhysicalApplicationPath;
            string tempfileName = "";
            StringBuilder sb = new StringBuilder();

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "4" + "1" + "." + FileUpload1.FileName.Split('.')[(FileUpload1.FileName.Split('.').Length - 1)];
            string pathToCheck = appPath + saveDir + fileName;
            //===========================================(Start)
            foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
            {
                if (file.Contains(fileName.Substring(0, fileName.LastIndexOf('.'))))
                {
                    System.IO.File.Delete(file);
                    sb.Append("(既有档案已被复写)");
                    break;
                }
            }

            string savePath = appPath + saveDir + fileName;
            FileUpload1.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("2"))
        {
            if (FileUpload2.FileName.Length == 0)
            {
                //LbStatus2.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload2.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload2.FileName).ToLower();
                string[] allowExtensions = { ".doc", ".docx" };
                bool isFind = false;
                foreach (string tag in allowExtensions)
                {
                    if (fileExtension.Equals(tag))
                        isFind = true;
                }
                if (!isFind)
                {
                    //LbStatus2.Text = "上传格式必须为WORD (*.doc, *.docx)";
                    return;
                }
            }
            string saveDir = @"Upload\Stage5\";
            string appPath = Request.PhysicalApplicationPath;
            string tempfileName = "";
            StringBuilder sb = new StringBuilder();

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "4" + "2" + "." + FileUpload2.FileName.Split('.')[(FileUpload2.FileName.Split('.').Length - 1)];
            string pathToCheck = appPath + saveDir + fileName;
            //===========================================(Start)
            foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
            {
                if (file.Contains(fileName.Substring(0, fileName.LastIndexOf('.'))))
                {
                    System.IO.File.Delete(file);
                    sb.Append("(既有档案已被复写)");
                    break;
                }
            }

            string savePath = appPath + saveDir + fileName;
            FileUpload2.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("3"))
        {
            if (FileUpload3.FileName.Length == 0)
            {
                //LbStatus3.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload3.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload3.FileName).ToLower();
                string[] allowExtensions = { ".doc", ".docx" };
                bool isFind = false;
                foreach (string tag in allowExtensions)
                {
                    if (fileExtension.Equals(tag))
                        isFind = true;
                }
                if (!isFind)
                {
                    //LbStatus3.Text = "上传格式必须为WORD (*.doc, *.docx)";
                    return;
                }
            }
            string saveDir = @"Upload\Stage5\";
            string appPath = Request.PhysicalApplicationPath;
            string tempfileName = "";
            StringBuilder sb = new StringBuilder();

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "4" + "3" + "." + FileUpload3.FileName.Split('.')[(FileUpload3.FileName.Split('.').Length - 1)];
            string pathToCheck = appPath + saveDir + fileName;
            //===========================================(Start)
            foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
            {
                if (file.Contains(fileName.Substring(0, fileName.LastIndexOf('.'))))
                {
                    System.IO.File.Delete(file);
                    sb.Append("(既有档案已被复写)");
                    break;
                }
            }

            string savePath = appPath + saveDir + fileName;
            FileUpload3.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("4"))
        {
            if (FileUpload4.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload4.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload4.FileName).ToLower();
                string[] allowExtensions = { ".doc", ".docx" };
                bool isFind = false;
                foreach (string tag in allowExtensions)
                {
                    if (fileExtension.Equals(tag))
                        isFind = true;
                }
                if (!isFind)
                {
                    //LbStatus4.Text = "上传格式必须为WORD (*.doc, *.docx)";
                    return;
                }
            }
            string saveDir = @"Upload\Stage5\";
            string appPath = Request.PhysicalApplicationPath;
            string tempfileName = "";
            StringBuilder sb = new StringBuilder();

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "4" + "4" + "." + FileUpload4.FileName.Split('.')[(FileUpload4.FileName.Split('.').Length - 1)];
            string pathToCheck = appPath + saveDir + fileName;
            //===========================================(Start)
            foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
            {
                if (file.Contains(fileName.Substring(0, fileName.LastIndexOf('.'))))
                {
                    System.IO.File.Delete(file);
                    sb.Append("(既有档案已被复写)");
                    break;
                }
            }

            string savePath = appPath + saveDir + fileName;
            FileUpload4.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        Response.Redirect("MDRegulations_04.aspx");
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
    private bool getUploadDir(int targetIndex, StringBuilder sb, StringBuilder outFile)
    {
        string saveDir = @"Upload\Stage5\";
        string appPath = Request.PhysicalApplicationPath;
        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "4" + targetIndex;   //目前刪除getSemester()函示不做學期的判斷
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
    private int GetMaxRequestSize()
    {
        //取得預設的maxRequestLength設定值.
        Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        HttpRuntimeSection section = config.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
        return section.MaxRequestLength * 1024;
    }
    protected override System.Collections.Specialized.NameValueCollection DeterminePostBackMode()
    {
        //此處是唯一有機會於上傳檔案之Request開始收取前,判斷大小的地方
        if (Request.ContentLength > GetMaxRequestSize()) //判斷上傳檔案是否大於4 MB
        {
            Session["FileIsToLarge"] = true;
            //利用Cache來註記檔案太大,稍後的Timer將會查詢此欄位來決定是否Redirect.
            return null; //file to large
        }
        Session["FileIsAccept"] = true;
        //接受檔案,稍後的Timer將會查詢此欄位來重新顯示IFrame
        //(我們會在上傳前,將IFrame隱藏,來避開顯示錯誤.)
        return base.DeterminePostBackMode();
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../../Index.aspx");
    }
}