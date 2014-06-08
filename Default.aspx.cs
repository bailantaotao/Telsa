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
    public string backgroundImage = Resources.Resource.ImgUrlBackground;
    protected override void OnInit(EventArgs e)
    {

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
            Response.Redirect("ForgetPwd.aspx");
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
            string query = "select Account.UserID, Account.UserName, Account.ClassCode, ZipCode, OpenPermissionDate, LastLoginTime from Account " +
                            "where UserID = '" + Tb_Account.Text + "' and Password = '" + Tb_Pwd.Text + "'";
            ArrayList data = new ArrayList();
            StringBuilder sb = new StringBuilder();
            if (ms.GetAllColumnData(query, data))
            {
                if (data.Count == 0)
                {
                    Tb_VerificationCode.Text = "";
                    ClientScriptArea.Text = bc.responseMsg("找不到此帳號!");
                }
                else
                {
                    query = "update Account set LastLoginTime='" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "' where UserID ='" + Tb_Account.Text + "'";
                    ms.WriteData(query, sb);

                    Session["UserID"] = ((string[])data[0])[0];
                    Session["UserName"] = ((string[])data[0])[1];
                    Session["ClassCode"] = ((string[])data[0])[2];
                    Session["Province"] = ((string[])data[0])[3];
                    Session["OpenPermissionDate"] = ((string[])data[0])[4];
                    Session["LastLoginTime"] = ((string[])data[0])[5];

                    if (Session["ClassCode"].ToString().Equals("1"))
                    {
                        string IsMingder = "select IsMingder from ExpertAuthority where UserID = '" + Tb_Account.Text + "'";
                        if (ms.GetOneData(IsMingder, sb))
                        {
                            Session["IsMingDer"] = sb.ToString();
                            if (sb.ToString().ToLower().Equals("true"))
                            {
                                Response.Redirect("MingdeIndex.aspx");
                            }
                            else
                            {
                                Response.Redirect("ProvinceIndex.aspx");
                            }
                        }
                    }
                    if (Session["ClassCode"].ToString().Equals("0"))
                    {
                        //ClientScriptArea.Text = bc.responseMsg("你是校長");
                        //Response.Redirect("SchoolMaster/InternetStudy.aspx");
                        Response.Redirect("Index.aspx");
                    }
                    else if (Session["ClassCode"].ToString().Equals("1"))
                    {                        
                        //Response.Redirect("Expert/ViewInternetStudyScore.aspx");
                        /*
                        if (Session["IsMingDer"].ToString().Equals("True"))
                            ClientScriptArea.Text = bc.responseMsg("你是明德專家");
                        else
                            ClientScriptArea.Text = bc.responseMsg("你是省專家");                        
                         * */
                    }
                    else if (Session["ClassCode"].ToString().Equals("2"))
                    {
                        //ClientScriptArea.Text = bc.responseMsg("你是系統管理員");
                        //Response.Redirect("Manager/InternetStudyEdit.aspx");
                        Response.Redirect("SystemManagerIndex.aspx");
                    }
                    //Response.Redirect("Index.aspx");
                    
                }
            }
        }
    }

    protected void Tb_Account_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        ManageSQL ms = new ManageSQL();
        string query = "select School from Account where UserID='"+tb.Text+"'";
        StringBuilder sb = new StringBuilder();

        ms.GetOneData(query, sb);
        if (string.IsNullOrEmpty(sb.ToString()))
            LbUserSchool.Text = "";
        else
            LbUserSchool.Text = Resources.Resource.TipWelcome + sb.ToString(); 

    }
}