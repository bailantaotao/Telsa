using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SystemManagerIndex : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("SessionOut.aspx");

        LbWelcome.Text = Resources.Resource.TipWelcome + " " + Session["UserName"].ToString() ;
        LbOpenPermission.Text = Resources.Resource.TipOpenPermission + Session["OpenPermissionDate"].ToString();
        LbLastLogin.Text = Resources.Resource.TipLastLogin + Session["LastLoginTime"].ToString();

        //LoadMsg(true, PnMingderMsg);
        //LoadMsg(false, PnProvinceMsg);
        IndexFactory MingdeExpert = new ConcreateFactory(Session["UserID"].ToString(), Session["Province"].ToString());
        MingdeExpert.prepareNotification(IndexFactory.DATA_TYPE.MingdeExpert);
        ArrayList data = (ArrayList)MingdeExpert.notificationSet.Clone();
        LoadMsg(PnMingde, data, IndexFactory.DATA_TYPE.MingdeExpert);

        IndexFactory System = new ConcreateFactory(Session["UserID"].ToString(), Session["Province"].ToString());
        System.prepareNotification(IndexFactory.DATA_TYPE.System);
        data = (ArrayList)System.notificationSet.Clone();
        LoadMsg(PnSystem, data, IndexFactory.DATA_TYPE.System);

    }

    private void LoadMsg(Panel pn, ArrayList data, IndexFactory.DATA_TYPE type)
    {
        
        Label Introduction = new Label();
        if (type == IndexFactory.DATA_TYPE.MingdeExpert)
            Introduction.Text = Resources.Resource.TipMingderMsg;
        else if (type == IndexFactory.DATA_TYPE.FromExpertToMingde)
            Introduction.Text = Resources.Resource.TipProvinceMsg;
        else if (type == IndexFactory.DATA_TYPE.System)
            Introduction.Text = Resources.Resource.TipSystemMsg;
        else if (type == IndexFactory.DATA_TYPE.SchoolMaster)
            Introduction.Text = Resources.Resource.TipSchoolMasterMsg;
        else if (type == IndexFactory.DATA_TYPE.SystemManager)
            Introduction.Text = Resources.Resource.TipSystemManagerMsg;
        else if (type == IndexFactory.DATA_TYPE.ProvinceAnnocement)
            Introduction.Text = Resources.Resource.TipProvinceAnnocement;

        Introduction.Text += "<br />";
        Introduction.Text += "---------------------------------------------------------<br />";
        if (type != IndexFactory.DATA_TYPE.System)
            Introduction.Width = 724;
        pn.Controls.Add(Introduction);

        if (data.Count == 0)
        {
            return;
        }

        foreach(string[] box in data)
        {
            Label lb = new Label();
            lb.Text = box[2] + " " + box[3].Split(' ')[0] + "<br />";
            lb.Text += Resources.Resource.TipSubject + "：" + box[0] + "<br />";
            lb.Text += Resources.Resource.TipMessage + "：" + box[1] + "<br />";
            if (type != IndexFactory.DATA_TYPE.System)
                lb.Width = 724;
            pn.Controls.Add(lb);
        }


    }

    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void BtnSendMsg_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('MsgNotify.aspx', '', config='height=500,width=700')", true);
    }

    protected void BtnSendAnnocement_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('MsgAnnocement.aspx', '', config='height=500,width=700')", true);
    }
    protected void BtnImportProvinceData_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('Manager/ImportExcel.aspx', '', config='height=200,width=300')", true);
    }
    protected void BtnModifyPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("ModifiedPassword.aspx");
    }
}