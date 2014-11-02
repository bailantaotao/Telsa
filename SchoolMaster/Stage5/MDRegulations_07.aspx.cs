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

public partial class Stage5_MDRegulations_07 : System.Web.UI.Page
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "1" + "." + FileUpload1.FileName.Split('.')[(FileUpload1.FileName.Split('.').Length - 1)];
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "2" + "." + FileUpload2.FileName.Split('.')[(FileUpload2.FileName.Split('.').Length - 1)];
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "3" + "." + FileUpload3.FileName.Split('.')[(FileUpload3.FileName.Split('.').Length - 1)];
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "4" + "." + FileUpload4.FileName.Split('.')[(FileUpload4.FileName.Split('.').Length - 1)];
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
        else if (btn.CommandArgument.Equals("5"))
        {
            if (FileUpload5.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload5.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload5.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "5" + "." + FileUpload5.FileName.Split('.')[(FileUpload5.FileName.Split('.').Length - 1)];
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
            FileUpload5.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("6"))
        {
            if (FileUpload6.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload6.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload6.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "6" + "." + FileUpload6.FileName.Split('.')[(FileUpload6.FileName.Split('.').Length - 1)];
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
            FileUpload6.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("7"))
        {
            if (FileUpload7.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload7.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload7.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "7" + "." + FileUpload7.FileName.Split('.')[(FileUpload7.FileName.Split('.').Length - 1)];
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
            FileUpload7.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("8"))
        {
            if (FileUpload8.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload8.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload8.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "8" + "." + FileUpload8.FileName.Split('.')[(FileUpload8.FileName.Split('.').Length - 1)];
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
            FileUpload8.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("9"))
        {
            if (FileUpload9.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload9.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload9.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "9" + "." + FileUpload9.FileName.Split('.')[(FileUpload9.FileName.Split('.').Length - 1)];
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
            FileUpload9.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("10"))
        {
            if (FileUpload10.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload10.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload10.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "10" + "." + FileUpload10.FileName.Split('.')[(FileUpload10.FileName.Split('.').Length - 1)];
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
            FileUpload10.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("11"))
        {
            if (FileUpload11.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload11.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload11.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "11" + "." + FileUpload11.FileName.Split('.')[(FileUpload11.FileName.Split('.').Length - 1)];
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
            FileUpload11.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("12"))
        {
            if (FileUpload12.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload12.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload12.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "12" + "." + FileUpload12.FileName.Split('.')[(FileUpload12.FileName.Split('.').Length - 1)];
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
            FileUpload12.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("13"))
        {
            if (FileUpload13.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload13.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload13.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "13" + "." + FileUpload13.FileName.Split('.')[(FileUpload13.FileName.Split('.').Length - 1)];
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
            FileUpload13.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("14"))
        {
            if (FileUpload14.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload14.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload14.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "14" + "." + FileUpload14.FileName.Split('.')[(FileUpload14.FileName.Split('.').Length - 1)];
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
            FileUpload14.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("15"))
        {
            if (FileUpload15.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload15.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload15.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "15" + "." + FileUpload15.FileName.Split('.')[(FileUpload15.FileName.Split('.').Length - 1)];
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
            FileUpload15.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("16"))
        {
            if (FileUpload16.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload16.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload16.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "16" + "." + FileUpload16.FileName.Split('.')[(FileUpload16.FileName.Split('.').Length - 1)];
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
            FileUpload16.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("17"))
        {
            if (FileUpload17.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload17.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload17.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "17" + "." + FileUpload17.FileName.Split('.')[(FileUpload17.FileName.Split('.').Length - 1)];
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
            FileUpload17.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("18"))
        {
            if (FileUpload18.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload18.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload18.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "18" + "." + FileUpload18.FileName.Split('.')[(FileUpload18.FileName.Split('.').Length - 1)];
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
            FileUpload18.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("19"))
        {
            if (FileUpload19.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload19.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload19.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "19" + "." + FileUpload19.FileName.Split('.')[(FileUpload19.FileName.Split('.').Length - 1)];
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
            FileUpload19.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("20"))
        {
            if (FileUpload20.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload20.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload20.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "20" + "." + FileUpload20.FileName.Split('.')[(FileUpload20.FileName.Split('.').Length - 1)];
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
            FileUpload20.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("21"))
        {
            if (FileUpload21.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload21.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload21.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "21" + "." + FileUpload21.FileName.Split('.')[(FileUpload21.FileName.Split('.').Length - 1)];
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
            FileUpload21.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("22"))
        {
            if (FileUpload22.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload22.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload22.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "22" + "." + FileUpload22.FileName.Split('.')[(FileUpload22.FileName.Split('.').Length - 1)];
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
            FileUpload22.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("23"))
        {
            if (FileUpload23.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload23.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload23.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "23" + "." + FileUpload23.FileName.Split('.')[(FileUpload23.FileName.Split('.').Length - 1)];
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
            FileUpload23.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("24"))
        {
            if (FileUpload24.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload24.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload24.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "24" + "." + FileUpload24.FileName.Split('.')[(FileUpload24.FileName.Split('.').Length - 1)];
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
            FileUpload24.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("25"))
        {
            if (FileUpload25.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload25.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload25.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "25" + "." + FileUpload25.FileName.Split('.')[(FileUpload25.FileName.Split('.').Length - 1)];
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
            FileUpload25.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("26"))
        {
            if (FileUpload26.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload26.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload26.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "26" + "." + FileUpload26.FileName.Split('.')[(FileUpload26.FileName.Split('.').Length - 1)];
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
            FileUpload26.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("27"))
        {
            if (FileUpload27.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload27.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload27.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "27" + "." + FileUpload27.FileName.Split('.')[(FileUpload27.FileName.Split('.').Length - 1)];
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
            FileUpload27.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("28"))
        {
            if (FileUpload28.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload28.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload28.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "28" + "." + FileUpload28.FileName.Split('.')[(FileUpload28.FileName.Split('.').Length - 1)];
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
            FileUpload28.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("29"))
        {
            if (FileUpload29.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload29.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload29.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "29" + "." + FileUpload29.FileName.Split('.')[(FileUpload29.FileName.Split('.').Length - 1)];
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
            FileUpload29.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }
        else if (btn.CommandArgument.Equals("30"))
        {
            if (FileUpload30.FileName.Length == 0)
            {
                //LbStatus4.Text = "请上传具备内容的档案";
                return;
            }

            if (FileUpload30.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(FileUpload30.FileName).ToLower();
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

            string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + "30" + "." + FileUpload30.FileName.Split('.')[(FileUpload30.FileName.Split('.').Length - 1)];
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
            FileUpload30.SaveAs(savePath);
            if (Session["targetUploadIndex"] != null)
                Session.Remove("targetUploadIndex");
        }


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
        string fileName = Session["UserID"].ToString() + DateTime.Now.ToString("yyyy") + "7" + targetIndex;   //目前刪除getSemester()函示不做學期的判斷
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