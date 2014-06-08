using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MsgNotify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!IsPostBack)
        {
            LoadData();
        }
        TbExpirationDate.Attributes.Add("readonly", "true");
    }

    private void LoadData()
    {
        IndexFactory receiverCollection = new ConcreateFactory(Session["UserID"].ToString(), Session["Province"].ToString());
        if (Session["ClassCode"].ToString().Equals("0"))
        {
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.FromSchoolMasterToExpert);            
        }
        else if (Session["ClassCode"].ToString().Equals("2"))
        {
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.FromExpertToMingde);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.MingdeExpert);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.SchoolMaster);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.completeMultiCal();
        }
        else if (Session["IsMingDer"].ToString().ToLower().Equals("true"))
        {
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.FromExpertToMingde);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.SystemManager);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.SchoolMaster);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.completeMultiCal();
        }
        else if (Session["IsMingDer"].ToString().ToLower().Equals("false"))
        {
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.FromExpertToSchoolMaster);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.prepareReceiver(IndexFactory.DATA_TYPE.FromExpertToMingde);
            receiverCollection = new AddMultiReceiver(receiverCollection).CopySet();
            receiverCollection.completeMultiCal();
        }
        DdlReceiver.Items.Add(new ListItem(Resources.Resource.TipPlzChoose,"0"));
        int Index = 1;
        foreach (string[] data in receiverCollection.receiverSet)
        {
            DdlReceiver.Items.Add(new ListItem(Index + ": " + data[1]+" - "+data[2], data[0]));
            Index++;
        }
        
    }
    private bool CheckData()
    {
        if (DdlReceiver.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipReceiverError + "')", true);
            return false;
        }
        if (string.IsNullOrEmpty(TbMsg.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipMsgError + "')", true);
            return false;
        }

        if (string.IsNullOrEmpty(TbSubject.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipSubjectError + "')", true);
            return false;
        }

        if (string.IsNullOrEmpty(TbExpirationDate.Text.Trim()))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipExpirationDate + "')", true);
            return false;
        }

        return true;
    }
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        if (CheckData())
        {
            ManageSQL ms = new ManageSQL();
            StringBuilder sb = new StringBuilder();
            string userid = DdlReceiver.SelectedValue;

            string Query = "insert into MsgSubject (Subjects, Msg, SendTime, NotifyDeadLine) VALUES (N'" +
                            TbSubject.Text.Trim() + "',N'" +
                            TbMsg.Text.Trim() + "','" +
                            DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                            TbExpirationDate.Text + "')";

            if (!ms.WriteData(Query, sb))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }

            if (string.IsNullOrEmpty(sb.ToString()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }

            if (Convert.ToInt32(sb.ToString()) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }

            Query = "select top 1 EmailID from MsgSubject order by EmailID desc";
            if (!ms.GetOneData(Query, sb))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }

            Query = "insert into MsgUserData (ReceiverID, ReceiverIsReadMsg, EmailID, SenderID, Annocement) VALUES ('" +
                    userid + "','" +
                    "False" + "','" +
                    sb.ToString() + "','" +
                    Session["UserID"].ToString() + "','" + 
                    "false" + "')";

            if (!ms.WriteData(Query, sb))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }

            if (string.IsNullOrEmpty(sb.ToString()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }

            if (Convert.ToInt32(sb.ToString()) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                return;
            }
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipLetterFinish + "');window.opener=null;window.close();", true);
        }
        
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if(Session["NotifyAll"] != null)
            Session.Remove("NotifyAll");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.close();", true);
    }
}