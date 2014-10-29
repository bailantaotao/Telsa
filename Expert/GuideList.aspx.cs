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

public partial class Expert_GuideList : System.Web.UI.Page
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
    private const string MODIFIED = "MODIFIED";
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
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");
        if (Session["GuideSN"] != null)
            Session.Remove("GuideSN");
        if (Session["GuideYear"] != null)
            Session.Remove("GuideYear");

        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            IsMingDer = true;
        }
        else
        {
            IsMingDer = false;
        }

        Label2.Visible = false;
        TbUploadItemName.Visible = false;
        Label3.Visible = false;
        FileUpload1.Visible = false;
        BtnUpload.Visible = false;
        LbStatus.Visible = false;
        ButtonCancelUpload.Visible = false;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        getSchoolName(schoolName);

        if (!verifyValid())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanErrorData + "');window.location='GuidePreList.aspx';", true);
            return;
        }
        if (!IsPostBack)
        {
            //setInitial();
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
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("GvItemNo", typeof(string)));
        dt.Columns.Add(new DataColumn("GvGuideItemName", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select ItemNo, GuideItemName " +
                       "from GuideItem " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
                       "order by ItemNo asc";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["GvItemNo"] = d[0];
                dr["GvGuideItemName"] = d[1];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GridView2.DataSource = dt;
            GridView2.DataBind();
            return;
        }

        /*dr = dt.NewRow();
        dr["GvItemNo"] = "1";
        dr["GvGuideItemName"] = "";
        dt.Rows.Add(dr);*/

        ViewState["dt"] = dt;

        GridView2.DataSource = dt;
        GridView2.DataBind();
        return;
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
            string[] allowExtensions = { ".doc", ".docx" };
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



        string saveDir = @"Upload\Stage4\";
        string appPath = Request.PhysicalApplicationPath;
        string tempfileName = "";
        //如果事先宣告 using System.Text;
        StringBuilder sb = new StringBuilder();

        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + getSemster() + TbUploadItemName.Text + "." + FileUpload1.FileName.Split('.')[(FileUpload1.FileName.Split('.').Length - 1)];
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



        //if (System.IO.File.Exists(pathToCheck))
        //{
        //    sb.Append("(既有档案已被复写)");
        //    //int my_counter = 2;
        //    //while (System.IO.File.Exists(pathToCheck))
        //    //{
        //    //    //--檔名相同的話，目前上傳的檔名（改成 tempfileName），
        //    //    //  前面會用數字來代替。
        //    //    tempfileName = my_counter.ToString() + "_" + fileName;
        //    //    pathToCheck = appPath + saveDir + tempfileName;
        //    //    my_counter = my_counter + 1;
        //    //}
        //    //fileName = tempfileName;
        //    //LbStatus.Text += "<br>抱歉，您上傳的檔名發生衝突，檔名修改如下---- " + fileName;
        //}
        //===========================================(End)                
        //-- 完成檔案上傳的動作。
        string savePath = appPath + saveDir + fileName;
        FileUpload1.SaveAs(savePath);
        /*ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from GuideItem where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        sb.Clear();
        query = "insert into GuideItem (SN, ItemNo, GuideItemName, GuideItemUrl) VALUES ('" +
                            Session["UserGuideListSN"].ToString() + "','" +
                            "1" + "','" +
            //TbUploadItemName.Text.Trim() + "')";
                            TbUploadItemName.Text.Trim() + "','" +
                            "../Upload/Stage4/" + fileName + "')";

        ms.WriteData(query, sb);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " ", true);*/
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        string query = "select ItemNo, GuideItemName " +
                       "from GuideItem " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);


        string query1 = "insert into GuideItem (SN, GuideItemName, GuideItemUrl, ItemNo) VALUES ('" +
                       Session["UserGuideListSN"].ToString() + "',N'" +
                       TbUploadItemName.Text.Trim() + "',N'" +
                       "../Upload/Stage4/" + fileName + "',N'" +
                        (data.Count ) + "')";

        ms.WriteData(query1, sb);

        /*if (data.Count == 0)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("TargetShl", typeof(string)));
            dt.Columns.Add(new DataColumn("ShlYear", typeof(string)));
            dt.Columns.Add(new DataColumn("ShlSemester", typeof(string)));

            dr = dt.NewRow();
            dr["TargetShl"] = DlGuideTargetSchool.SelectedValue;
            dr["ShlYear"] = DlListYear.SelectedValue;
            dr["ShlSemester"] = DlAddListSemester.SelectedValue;
            dt.Rows.Add(dr);

            ViewState["dt"] = dt;

            GvActivityList.DataSource = dt;
            GvActivityList.DataBind();

            return;
        }*/

        LbStatus.Text = "上传成功 " + sb.ToString();

        Label2.Visible = false;
        TbUploadItemName.Visible = false;
        Label3.Visible = false;
        FileUpload1.Visible = false;
        BtnUpload.Visible = false;
        LbStatus.Visible = true;


        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuidePreList.aspx");
    }
    protected void btn_Delete(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;

                ManageSQL ms = new ManageSQL();
                StringBuilder sb = new StringBuilder();
                ArrayList data=new ArrayList();
                // 先刪除原本的
                /*string queryselect = "select ItemNo from GuideItem where SN='" + Session["UserGuideListSN"].ToString() + "'";
                ms.GetAllColumnData(queryselect, data);*/

                string query = "delete from GuideItem where SN ='" + Session["UserGuideListSN"].ToString() + "'" + " and ItemNo = " + (Convert.ToInt32(yourAssignedValue) );
                ms.WriteData(query, sb);

                /*for (int i = Convert.ToInt32(yourAssignedValue)+1; i < data.Count; i++)
                {
                    string querydelete = "update GuideItem ItemNo=" + (i - 1);
                    ms.WriteData(querydelete, sb);
                }*/
                    
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " ", true);
                Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
            }

            catch
            {
                //Check for exception
            }
        }
    }
    protected void BtnUploadAttachment_Click(object sender, EventArgs e)
    {

        Label2.Visible = true;
        TbUploadItemName.Visible = true;
        Label3.Visible = true;
        FileUpload1.Visible = true;
        BtnUpload.Visible = true;
        LbStatus.Visible = false;
        ButtonCancelUpload.Visible = true;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('GuideItemUpload.aspx', '', config='height=500,width=550')", true);
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
    private void storeData()
    {
        if (ViewState["dt"] != null)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                ManageSQL ms = new ManageSQL();
                // 先刪除原本的
                string query = "delete from GuideItem where SN ='" + Session["UserGuideListSN"].ToString() + "'";
                //ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sb.Clear();
                    query = "insert into GuideItem (SN, GuideItemName, ItemNo) VALUES ('" +
                                    Session["UserGuideListSN"].ToString() + "',N'" +
                                    dt.Rows[i][1].ToString() + "',N'" +
                                    (i + 1) + "')";

                    ms.WriteData(query, sb);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " ", true);

            }
        }
    }
    
    /*protected void btn_Download(object sender, EventArgs e)
    {
        string TargetName="";
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
        }

        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
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
    }*/


    protected void ButtonCancelUpload_Click(object sender, EventArgs e)
    {
        Label2.Visible = false;
        TbUploadItemName.Visible = false;
        Label3.Visible = false;
        FileUpload1.Visible = false;
        BtnUpload.Visible = false;
        LbStatus.Visible = false;
        ButtonCancelUpload.Visible = false;
    }
}