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

public partial class Manager_ImportExcel : System.Web.UI.Page
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
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");
        
        if (!IsPostBack)
        {
            DdlProvince.Items.Add(new ListItem(Resources.Resource.TipPlzChoose, "0"));
            initYear();
            initProvince();
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
        int minYear = 2013;
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
        string SheetName = "User_ID編號$";
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
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (dt.Rows[i]["Shl_No"].ToString().Equals(""))
                continue;
            string query = "select count(UserID) from Account where UserID ='"+ dt.Rows[i]["User_ID"].ToString()+"'";
            ms.GetRowNumbers(query, sb);
            if (sb.ToString().Equals("0"))
            {
                query = "insert into Account (Shl_No, ID, UserID, Password, School, UserName, Telphone, ClassCode, Email, Zipcode, ImportYear) VALUES (" +
                    "N'" + dt.Rows[i]["Shl_No"].ToString() + "', " +
                    "N'" + dt.Rows[i]["ID"].ToString() + "', " +
                    "N'" + dt.Rows[i]["User_ID"].ToString() + "', " +
                    "N'" + "0000" + "', " +
                    "N'" + dt.Rows[i]["校  名"].ToString() + "', " +
                    "N'" + dt.Rows[i]["校长姓名"].ToString() + "', " +
                    "N'" + dt.Rows[i]["联系方式"].ToString() + "', " +
                    "N'" + "0" + "', " +
                    "N'" + dt.Rows[i]["电子邮件"].ToString() + "', " +
                    "N'" + DdlProvince.SelectedValue + "', " + 
                    "N'" + DdlYear.SelectedValue + "')";
                ms.WriteData(query, sb);

                continue;
            }
            if (sb.ToString().Equals("1"))
            {
                query = "update Account set " +
                    "Shl_No = N'" + dt.Rows[i]["Shl_No"].ToString() + "', " +
                    "ID = N'" + dt.Rows[i]["ID"].ToString() + "', " +
                    "School = N'" + dt.Rows[i]["校  名"].ToString() + "', " +
                    "UserName = N'" + dt.Rows[i]["校长姓名"].ToString() + "', " +
                    "Telphone = N'" + dt.Rows[i]["联系方式"].ToString() + "', " +
                    "Email = N'" + dt.Rows[i]["电子邮件"].ToString() + "', " +
                    "Zipcode = N'" + DdlProvince.SelectedValue + "' " +
                    "where UserID ='" + dt.Rows[i]["User_ID"].ToString() + "'";
                ms.WriteData(query, sb);
                continue;
            }
        }
        
    }

}