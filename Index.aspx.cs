using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("SessionOut.aspx");

        LbWelcome.Text = Resources.Resource.TipWelcome + " " + Session["UserName"].ToString() ;
        LbOpenPermission.Text = Resources.Resource.TipOpenPermission + Session["OpenPermissionDate"].ToString();
        LbLastLogin.Text = Resources.Resource.TipLastLogin + Session["LastLoginTime"].ToString();

        LoadMsg(true, PnMingderMsg);
        LoadMsg(false, PnProvinceMsg);
    }

    private void LoadMsg(bool IsMingder, Panel pn)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Subjects, Msg, UserName, SendTime from MsgUserData " +
                        "left join MsgSubject on MsgUserData.EmailID = MsgSubject.EmailID " +
                        "left join Account on Account.UserID = MsgUserData.SenderID " +
                        "left join ExpertAuthority on Account.UserID = ExpertAuthority.UserID " +
                        "where " +
                        "MsgUserData.ReceiverID = '" + Session["UserID"].ToString() + "' and " +
                        "GETDATE() <= MsgSubject.NotifyDeadLine and " +
                        "ExpertAuthority.IsMingDer = '"+IsMingder+"'";

        
        Label Introduction = new Label();
        Introduction.Text = (IsMingder == true) ? Introduction.Text = Resources.Resource.TipMingderMsg : Resources.Resource.TipProvinceMsg;
        Introduction.Text += "<br />";
        Introduction.Text += "---------------------------------------------------------<br />";
        Introduction.Width = 362;
        pn.Controls.Add(Introduction);

        if (!ms.GetAllColumnData(query, data))
        {
            return;
        }

        if (data.Count == 0)
        {
            return;
        }

        foreach(string[] box in data)
        {
            Label lb = new Label();
            lb.Text = box[2] + " " + box[3].Split(' ')[0] + "<br />";
            lb.Text += Resources.Resource.TipSubject + "：" + box[1] + "<br />";
            lb.Text += Resources.Resource.TipMessage + "：" + box[0] + "<br />";
            lb.Width = 362;
            pn.Controls.Add(lb);
        }


    }

    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}