using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItemUpload : System.Web.UI.Page
{
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
    protected void Page_Init(object sender, EventArgs e)
    {
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
        //    Response.Redirect("../SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("0"))
        //    Response.Redirect("../SessionOut.aspx");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserID"] = "NM14001";

        if (Session["FileIsToLarge"] != null)
        {
            LbStatus.Text = "上传的档案过大，仅支援最大1MB";
            Session.Remove("FileIsToLarge");
        }
    }
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName.Length == 0)
        {
            LbStatus.Text = "请上传具备内容的档案";
            return;
        }

        if (FileUpload1.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string[] allowExtensions = { ".doc", ".docx"};
            bool isFind = false;
            foreach (string tag in allowExtensions)
            {
                if (fileExtension.Equals(tag))
                    isFind = true;
            }
            if (!isFind)
            {
                LbStatus.Text = "上传格式必须为WORD (*.doc, *.docx)";
                return;
            }
        }



        string saveDir = @"Upload\Stage3\";
        string appPath = Request.PhysicalApplicationPath;
        string tempfileName = "";
        //如果事先宣告 using System.Text;
        StringBuilder sb = new StringBuilder();

        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + getSemster() + (DdlUploadFile.SelectedIndex + 1).ToString();
        string pathToCheck = appPath + saveDir + fileName;
        //===========================================(Start)
        if (System.IO.File.Exists(pathToCheck))
        {
            sb.Append("(既有档案已被复写)");
            //int my_counter = 2;
            //while (System.IO.File.Exists(pathToCheck))
            //{
            //    //--檔名相同的話，目前上傳的檔名（改成 tempfileName），
            //    //  前面會用數字來代替。
            //    tempfileName = my_counter.ToString() + "_" + fileName;
            //    pathToCheck = appPath + saveDir + tempfileName;
            //    my_counter = my_counter + 1;
            //}
            //fileName = tempfileName;
            //LbStatus.Text += "<br>抱歉，您上傳的檔名發生衝突，檔名修改如下---- " + fileName;
        }
        //===========================================(End)                
        //-- 完成檔案上傳的動作。
        string savePath = appPath + saveDir + fileName;
        FileUpload1.SaveAs(savePath);
        

        LbStatus.Text = "上传成功 " + sb.ToString();
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
}