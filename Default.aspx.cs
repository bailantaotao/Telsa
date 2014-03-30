using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected override void OnInit(EventArgs e)
    {
        // Define an Literal control.
        HtmlGenericControl css = new HtmlGenericControl();
        css.TagName = "style";
        css.Attributes.Add("type", "text/css");

        string imageURL = string.Empty;

        //Logic to determin imageURL goes here

        //Update Tag
        css.InnerHtml = @"body{background-image: url(" + Resources.Resource.ImgUrlBackgroundLogin + "); background-repeat:no-repeat; background-position: center top;}";

        // Add the Tag to the Head section of the page.
        Page.Header.Controls.Add(css);
        
        base.OnInit(e);
    } 
    protected override void InitializeCulture()
    {
        Page.UICulture = "zh-CN";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void ImgBtn_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ib = (ImageButton)sender;
        if (ib.ID == "ImgBtn_Login")
        {
            LoginVerification();
        }
        else if (ib.ID == "ImgBtn_Forget")
        {
        }
        else if (ib.ID == "ImgBtn_Cancel")
        {
            Tb_Account.Text = "";
            Tb_Pwd.Text = "";
            Tb_VerificationCode.Text = "";
        }
    }
    private void LoginVerification()
    {
        Session.Clear();
        Session["UserID"] = "";
        Session["UserName"] = "";
        Session["ClassCode"] = "";
        Session["IsMingDer"] = "";
        
        BaseClass bc = new BaseClass();
        if (Tb_Account.Text == "")
            ClientScriptArea.Text = bc.responseMsg("帳號不得為空");
        else if(Tb_Pwd.Text == "")
            ClientScriptArea.Text = bc.responseMsg("密碼不得為空");
        else if (Tb_VerificationCode.Text == "" || String.Compare(Request.Cookies["CheckCode"].Value, Tb_VerificationCode.Text, true) != 0)
            ClientScriptArea.Text = bc.responseMsg("驗證碼輸入錯誤");
        else
        {
            ManageSQL ms = new ManageSQL();
            string query = "select UserID, UserName, ClassCode from Account where UserID = '" + Tb_Account.Text + "' and Password = '" + Tb_Pwd.Text + "'";            
            ArrayList data = new ArrayList();
            if (ms.GetAllColumnData(query, data))
            {
                if (data.Count == 0)
                {
                    Tb_VerificationCode.Text = "";
                    ClientScriptArea.Text = bc.responseMsg("找不到此帳號!");
                }
                else
                {
                    Session["UserID"] = ((string[])data[0])[0];
                    Session["UserName"] = ((string[])data[0])[1];
                    Session["ClassCode"] = ((string[])data[0])[2];
                    if (Session["ClassCode"].ToString().Equals("1"))
                    {
                        string IsMingder = "select IsMingder from ExpertAuthority where UserID = '" + Tb_Account.Text + "'";
                        StringBuilder sb = new StringBuilder();
                        if (ms.GetOneData(IsMingder, sb))
                        {
                            Session["IsMingDer"] = sb.ToString();
                        }
                    }
                    if (Session["ClassCode"].ToString().Equals("0"))
                    {
                        //ClientScriptArea.Text = bc.responseMsg("你是校長");
                        Response.Redirect("SchoolMaster/InternetStudy.aspx");
                    }
                    else if (Session["ClassCode"].ToString().Equals("1"))
                    {
                        if (Session["IsMingDer"].ToString().Equals("True"))
                            ClientScriptArea.Text = bc.responseMsg("你是明德專家");
                        else
                            ClientScriptArea.Text = bc.responseMsg("你是省專家");
                    }
                    else if (Session["ClassCode"].ToString().Equals("2"))
                    {
                        //ClientScriptArea.Text = bc.responseMsg("你是系統管理員");
                        Response.Redirect("Manager/InternetStudyEdit.aspx");
                    }
                    //Response.Redirect("Index.aspx");
                    
                }
            }
        }
    }

}