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

    private string Query = string.Empty;
    private string QueryID = string.Empty;
    private string TargetSchool = string.Empty;

    private enum DdlType
    {
        SchoolName,
    }
    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.SchoolName:
                setSchoolName();
                break;
        }
    }
    private void setDefault_MingDe(DdlType type)
    {
        switch (type)
        {
            case DdlType.SchoolName:
                setSchoolName_MingDe();
                break;
        }
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            setDefault(DdlType.SchoolName);
        }
        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            setDefault_MingDe(DdlType.SchoolName);
        }
    }
    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();


        Query = "select School from Account " +
                                "left join Area on Account.zipcode = Area.ID " +
                                "where School not like N'%專家%' and School not like N'%专家%' and School not like N'%管理%' and Area.ID =" + Session["Province"].ToString() +
                                "group by School ";

        if (!ms.GetAllColumnData(Query, data))
        {
            DlTargetSchool.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlTargetSchool.Items.Add("None");
            return;
        }

        DlTargetSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DlTargetSchool.Items.Add(province[0]);
        }

    }
    private void setSchoolName_MingDe()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select School from Account " +
                           "left join Area on Account.zipcode = Area.ID " +
                           "where School not like N'%專家%' and School not like N'%专家%' and School not like N'%管理%' " +
                           "group by School ";

        if (!ms.GetAllColumnData(Query, data))
        {
            DlTargetSchool.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlTargetSchool.Items.Add("None");
            return;
        }

        DlTargetSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DlTargetSchool.Items.Add(province[0]);
        }

    }
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
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        QueryID = "select UserID from Account " +
                "where Account.School= N'" + DlTargetSchool.SelectedValue.ToString() + "'";

        ms.GetAllColumnData(QueryID, data);
        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            TargetSchool = d[0];
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
        string fileName = TargetSchool + DateTime.Now.ToString("yyyy") + "4" + targetIndex;   //目前刪除getSemester()函示不做學期的判斷
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
}