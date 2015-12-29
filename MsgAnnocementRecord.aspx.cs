using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MsgAnnocement : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        LbUserName.Text = Session["UserName"].ToString();
        setInitial();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");

    }

    private void getUserID(ArrayList data)
    {
        ManageSQL ms = new ManageSQL();

        string query = string.Empty;
        
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SendTime", typeof(string)));
        dt.Columns.Add(new DataColumn("Subjects", typeof(string)));
        dt.Columns.Add(new DataColumn("ReceiverID", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select [SendTime], [Subjects], [ReceiverID]" +
                        "from [MsgSubject] " +
                        "left join [MsgUserData] on [MsgSubject].[EmailID]=[MsgUserData].[EmailID] " +
                        "where [SenderID] ='" + Session["UserID"].ToString() + "'";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["SendTime"] = d[0];
                dr["Subjects"] = d[1];
                dr["ReceiverID"] = d[2];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvMsgRecord.DataSource = dt;
            GvMsgRecord.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((Label)GvMsgRecord.Rows[i].Cells[0].FindControl("SendTime")).Text = d[0];
                ((Label)GvMsgRecord.Rows[i].Cells[1].FindControl("Subjects")).Text = d[1];
                ((Label)GvMsgRecord.Rows[i].Cells[1].FindControl("ReceiverID")).Text = d[2];
            }
            return;
        }



        dr = dt.NewRow();
        dr["SendTime"] = string.Empty;
        dr["Subjects"] = string.Empty;
        dr["ReceiverID"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState["dt"] = dt;

        GvMsgRecord.DataSource = dt;
        GvMsgRecord.DataBind();

    }
    
    protected void BtnClose_Click(object sender, EventArgs e)
    {
        if(Session["NotifyAll"] != null)
            Session.Remove("NotifyAll");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.close();", true);
    }

    
}