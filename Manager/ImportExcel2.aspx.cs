using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ImportExcel2 : System.Web.UI.Page
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
        //if (!Session["ClassCode"].ToString().Equals("2"))
        //    Response.Redirect("../SessionOut.aspx");
        Session["UserID"] = "123";
        if (!IsPostBack)
        {
            //DdlProvince.Items.Add(new ListItem(Resources.Resource.TipPlzChoose, "0"));
            //initYear();
            //initProvince();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FileIsToLarge"] != null)
        {
            LbStatus.Text = "上传的档案过大，仅支援最大1MB";
            Session.Remove("FileIsToLarge");
        }
    }
    public void initYear()
    {
        string year = DateTime.Now.ToString("yyyy");
        int minYear = Convert.ToInt32(year) - 1;
        int maxYear = Convert.ToInt32(year) + 10;
        for (int i = minYear; i < maxYear; i++)
            DdlYear.Items.Add(i.ToString());
    }
    public void initProvince()
    {
        ManageSQL ms = new ManageSQL();
        string query = "select ID, Name from Area where ID <= 31 order by id ";
        ArrayList data = new ArrayList();

        ms.GetAllColumnData(query, data);
        foreach(string[] d in data)
        {
            ListItem li = new ListItem(d[1], d[0]);
            DdlProvince.Items.Add(li);
        }
    }
    protected void BtnUpload_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName.Length == 0)
        {
            LbStatus.Text = "请上传具备内容的档案";
            return;
        }
        string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
        if (FileUpload1.HasFile)
        {
            
            string[] allowExtensions = { ".xls", ".xlsx" };
            bool isFind = false;
            foreach (string tag in allowExtensions)
            {
                if (fileExtension.Equals(tag))
                    isFind = true;
            }
            if (!isFind)
            {
                LbStatus.Text = "上传格式必须为EXCEL (*.xls, *.xlsx)";
                return;
            }
        }



        string saveDir = @"ProvinceData\Stage3\";
        string appPath = Request.PhysicalApplicationPath;
        string tempfileName = "";
        //如果事先宣告 using System.Text;
        StringBuilder sb = new StringBuilder();

        string fileName = Session["UserID"].ToString() +"_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + (DdlProvince.SelectedIndex).ToString("00") +"_" +DdlYear.SelectedValue + "." + FileUpload1.FileName.Split('.')[(FileUpload1.FileName.Split('.').Length - 1)];
        string pathToCheck = appPath + saveDir + fileName;
        //===========================================(Start)
        //foreach (string file in System.IO.Directory.GetFileSystemEntries(appPath + saveDir))
        //{
        //    if (file.Contains(fileName.Substring(0, fileName.LastIndexOf('.'))))
        //    {
        //        System.IO.File.Delete(file);
        //        sb.Append("(既有档案已被复写)");
        //        break;
        //    }
        //}
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
        LbStatus.Text = "上传成功 " + sb.ToString();

        DataTable dt = new DataTable();
        Import_To_Grid(pathToCheck, fileExtension, "Yes", ref dt);
        Import_To_Database(ref dt);
    }

    private void Import_To_Grid(string FilePath, string Extension, string isHDR, ref DataTable dt)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": //Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                break;
            case ".xlsx": //Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;
        }

        conStr = String.Format(conStr, FilePath, isHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();
        
        cmdExcel.Connection = connExcel;

        //Get the name of First Sheet
        //connExcel.Open();
        //DataTable dtExcelSchema;
        //dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        //connExcel.Close();
        string SheetName = "工作表1$";
        //Read Data from First Sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();

        //Bind Data to GridView
        

        string a = dt.Rows[0][1].ToString();
    }

    public void Import_To_Database(ref DataTable dt)
    {
        if (dt.Rows.Count == 0)
        {
            return;
        }

        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        DataTable problem = new DataTable();
        problem.Columns.Add("ID");
        problem.Columns.Add("SU_NAME");
        problem.Columns.Add("SU_SEX");
        problem.Columns.Add("SU_BTHDAY");
        problem.Columns.Add("SHL_ID");
        problem.Columns.Add("SU_CSES");
        problem.Columns.Add("SU_TEL");
        problem.Columns.Add("SU_MOBILE");
        problem.Columns.Add("SU_ADDRESS");
        problem.Columns.Add("SU_PHOTO");
        problem.Columns.Add("SU_FOLK");
        problem.Columns.Add("SU_MARTIAL");
        problem.Columns.Add("SU_GDSHL");
        problem.Columns.Add("SU_EDUCATION");
        problem.Columns.Add("SU_WORKTIME");
        problem.Columns.Add("SU_SORTID");
        problem.Columns.Add("ADDTIME");
        problem.Columns.Add("A_ID");
        problem.Columns.Add("C_ID");
        problem.Columns.Add("SU_WORKTIME1");

        for (int i = 0; i < dt.Rows.Count; i++)
        {
           
           string query = "insert into SchoolUser (ID, SU_NAME, SU_SEX, SU_BTHDAY, SHL_ID, SU_CSES, "+
                            "SU_TEL, SU_MOBILE, SU_ADDRESS, SU_PHOTO, SU_FOLK,"+
                            "SU_MARTIAL, SU_GDSHL, SU_EDUCATION, SU_WORKTIME,"+
                            "SU_SORTID, ADDTIME, A_ID, C_ID, SU_WORKTIME1) VALUES (" +
                "N'" + dt.Rows[i]["ID"].ToString() + "', " +
                "N'" + dt.Rows[i]["SU_NAME"].ToString().Trim().Replace("'", "\"") + "', " +
                "N'" + dt.Rows[i]["SU_SEX"].ToString().Trim() + "', " +
                "N'" + (dt.Rows[i]["SU_BTHDAY"].ToString().Equals("NULL") ? "" : dt.Rows[i]["SU_BTHDAY"].ToString()) + "', " +
                "N'" + dt.Rows[i]["SHL_ID"].ToString().Trim() + "', " +
                "N'" + dt.Rows[i]["SU_CSES"].ToString().Trim().Replace("'", "\"") + "', " +
                "N'" + dt.Rows[i]["SU_TEL"].ToString().Trim() + "', " +
                "N'" + dt.Rows[i]["SU_MOBILE"].ToString().Trim() + "', " +
                "N'" + dt.Rows[i]["SU_ADDRESS"].ToString().Trim().Replace("'", "\"") + "', " +
                "N'" + dt.Rows[i]["SU_PHOTO"].ToString() + "', " +
                "N'" + dt.Rows[i]["SU_FOLK"].ToString().Trim().Replace("'", "\"") + "', " +
                "N'" + dt.Rows[i]["SU_MARTIAL"].ToString().Trim() + "', " +
                "N'" + dt.Rows[i]["SU_GDSHL"].ToString().Trim().Replace("'", "\"") + "', " +
                "N'" + dt.Rows[i]["SU_EDUCATION"].ToString().Trim().Replace("'", "\"") + "', " +
                "N'" + (dt.Rows[i]["SU_WORKTIME"].ToString().Equals("NULL") ? "" : dt.Rows[i]["SU_WORKTIME"].ToString()) + "', " +
                "N'" + dt.Rows[i]["SU_SORTID"].ToString() + "', " +
                "N'" + (dt.Rows[i]["ADDTIME"].ToString().Equals("NULL") ? "" : dt.Rows[i]["ADDTIME"].ToString()) + "', " +
                "N'" + dt.Rows[i]["A_ID"].ToString().Trim() + "', " +
                "N'" + dt.Rows[i]["C_ID"].ToString().Trim() + "', " +
                "N'" + (dt.Rows[i]["SU_WORKTIME1"].ToString().Equals("NULL") ? "" : dt.Rows[i]["SU_WORKTIME1"].ToString()) + "')";
            bool success = ms.WriteData(query, sb);
            if (!success)
            {
                DataRow workRow = problem.NewRow();
                
                workRow["ID"] = dt.Rows[i]["ID"].ToString();
                workRow["SU_NAME"] = dt.Rows[i]["SU_NAME"].ToString();
                workRow["SU_SEX"] = dt.Rows[i]["SU_SEX"].ToString();
                workRow["SU_BTHDAY"] = dt.Rows[i]["SU_BTHDAY"].ToString();
                workRow["SHL_ID"] = dt.Rows[i]["SHL_ID"].ToString();
                workRow["SU_CSES"] = dt.Rows[i]["SU_CSES"].ToString();
                workRow["SU_TEL"] = dt.Rows[i]["SU_TEL"].ToString();
                workRow["SU_MOBILE"] = dt.Rows[i]["SU_MOBILE"].ToString();
                workRow["SU_ADDRESS"] = dt.Rows[i]["SU_ADDRESS"].ToString();
                workRow["SU_PHOTO"] = dt.Rows[i]["SU_PHOTO"].ToString();
                workRow["SU_FOLK"] = dt.Rows[i]["SU_FOLK"].ToString();
                workRow["SU_MARTIAL"] = dt.Rows[i]["SU_MARTIAL"].ToString();
                workRow["SU_GDSHL"] = dt.Rows[i]["SU_GDSHL"].ToString();
                workRow["SU_EDUCATION"] = dt.Rows[i]["SU_EDUCATION"].ToString();
                workRow["SU_WORKTIME"] = dt.Rows[i]["SU_WORKTIME"].ToString();
                workRow["SU_SORTID"] = dt.Rows[i]["SU_SORTID"].ToString();
                workRow["ADDTIME"] = dt.Rows[i]["ADDTIME"].ToString();
                workRow["A_ID"] = dt.Rows[i]["A_ID"].ToString();
                workRow["C_ID"] = dt.Rows[i]["C_ID"].ToString();
                workRow["SU_WORKTIME1"] = dt.Rows[i]["SU_WORKTIME1"].ToString();
                problem.Rows.Add(workRow);
            }
            
        }
                
    }



}