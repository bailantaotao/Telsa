using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_MsgNotify : System.Web.UI.Page
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
        if (Request["SM"] != null && !string.IsNullOrEmpty(Request["SM"].ToString()))
        {
            ManageSQL ms = new ManageSQL();
            ArrayList data = new ArrayList();
            string Query = "select Account.UserName, Account.School from Account where Account.UserID = '" + Request["SM"].ToString() + "'";
            if (ms.GetAllColumnData(Query, data))
            {
                if (data.Count > 0)
                {
                    LbReceiver.Text = ((string[])data[0])[0] + "( " + ((string[])data[0])[1] + " )";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }
            }
        }
        else if (Session["NotifyAll"] != null)
        {
            LbReceiver.Text = "Multi user mode";
        }
    }
    private bool CheckData()
    {
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
    private void getUserID(ArrayList data)
    {
        ManageSQL ms = new ManageSQL();
        DataTable dt = (DataTable)Session["NotifyAll"];
        ArrayList tmp = new ArrayList();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string query = "select UserID from Account where school =N'" + dt.Rows[i]["SchoolName"].ToString() + "'";
            ms.GetAllColumnData(query, tmp);
            data.Add(((string[])tmp[0])[0]);
        }
        //foreach (string[] userid in tmp)
        //{
        //    data.Add(userid[0]);
        //}
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        if (CheckData())
        {
            if (Session["NotifyAll"] != null)
            {
                ManageSQL ms = new ManageSQL();
                StringBuilder sb = new StringBuilder();
                ArrayList data = new ArrayList();
                getUserID(data);
                if (data.Count > 0)
                {
                    foreach (string userid in data)
                    {
                        string Query = "insert into MsgSubject (Subjects, Msg, SendTime, NotifyDeadLine) VALUES (N'" +
                                        TbSubject.Text.Trim() + "',N'" +
                                        TbMsg.Text.Trim() + "','" +
                                        DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                                        TbExpirationDate.Text + "')";

                        if (!ms.WriteData(Query, sb))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                            break;
                        }

                        if (string.IsNullOrEmpty(sb.ToString()))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                            break;
                        }

                        if (Convert.ToInt32(sb.ToString()) == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                            break;
                        }

                        Query = "select top 1 EmailID from MsgSubject order by EmailID desc";
                        if (!ms.GetOneData(Query, sb))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                            break;
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
                            break;
                        }

                        if (string.IsNullOrEmpty(sb.ToString()))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                            break;
                        }

                        if (Convert.ToInt32(sb.ToString()) == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                            break;
                        }                                                
                    }
                    Session.Remove("NotifyAll");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipLetterFinish + "');window.opener=null;window.close();", true);
                }
            }
            else
            {
                ManageSQL ms = new ManageSQL();
                StringBuilder sb = new StringBuilder();
                string Query = "insert into MsgSubject (Subjects, Msg, SendTime, NotifyDeadLine) VALUES (N'" +
                                TbSubject.Text.Trim() + "',N'" +
                                TbMsg.Text.Trim() + "','" +
                                DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                                TbExpirationDate.Text + "')";

                if (!ms.WriteData(Query, sb))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }

                if (string.IsNullOrEmpty(sb.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }

                if (Convert.ToInt32(sb.ToString()) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }

                Query = "select top 1 EmailID from MsgSubject order by EmailID desc";
                if (!ms.GetOneData(Query, sb))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }

                Query = "insert into MsgUserData (ReceiverID, ReceiverIsReadMsg, EmailID, SenderID, Annocement) VALUES ('" +
                        Request["SM"].ToString() + "','" +
                        "False" + "','" +
                        sb.ToString() + "','" +
                        Session["UserID"].ToString() + "','" +
                        "false" + "')";

                if (!ms.WriteData(Query, sb))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }

                if (string.IsNullOrEmpty(sb.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }

                if (Convert.ToInt32(sb.ToString()) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('oops, we have an error.');window.opener=null;window.close();", true);
                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipLetterFinish + "');window.opener=null;window.close();", true);
            }
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if(Session["NotifyAll"] != null)
            Session.Remove("NotifyAll");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.close();", true);
    }
}