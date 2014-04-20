using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_ViewComment : System.Web.UI.Page
{
    private int DataPage = 0, Flag = 0, Count = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        
        if(!IsPostBack)
            LoadData(1);
    }

    private void LoadData(int Select)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();

        LbComplete.Text = "<table style='width:700px;'>";
        LbComplete.Text += "<tr align='center' style='background-color:#6699FF;'>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbComplete.Text += Resources.Resource.TipReceiver + "</td>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbComplete.Text += Resources.Resource.TipNotifyTime + "</td>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbComplete.Text += Resources.Resource.TipDeadline + "</td>";
        LbComplete.Text += "<td style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
        LbComplete.Text += Resources.Resource.TipMessage + "</td>";
        LbComplete.Text += "</tr>";

        string Query = "select Account.School,Account.UserName, MsgSubject.SendTime, MsgSubject.NotifyDeadLine, MsgSubject.Msg " +
                        "from MsgUserData "+
                        "left join MsgSubject on MsgSubject.EmailID = MsgUserData.EmailID " +
                        "left join Account on MsgUserData.ReceiverID = Account.UserID " +
                        "where MsgUserData.SenderID = '" + Session["UserID"].ToString() + "'";

        ms.GetAllColumnData(Query, data);
        if (data.Count != 0)
        {
            DataPage = data.Count / 10;

            if (data.Count % 10 != 0)
                DataPage++;

            //Paging
            DdlPageSelect.Items.Clear();

            for (int j = 1; j <= DataPage; j++)
            {
                DdlPageSelect.Items.Add(j.ToString());
            }

            DdlPageSelect.SelectedIndex = Select - 1;

            Count = (Select - 1) * 10;
            int Max = 0;
            if (Count + 10 < data.Count)
            {
                Max = Count + 10;
            }
            else
            {
                Max = data.Count;
            }

            for (int i = Count; i < Max; i++)   
            {
                LbComplete.Text += "<tr align='center' style='background-color:#B8CBD4;'>";
                LbComplete.Text += "<td style='width: 30%;border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbComplete.Text += ((string[])(data[i]))[0] + "-" + ((string[])(data[i]))[1].Split(' ')[0] + "</td>";
                LbComplete.Text += "<td style='width: 10%;border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbComplete.Text += ((string[])(data[i]))[2].Split(' ')[0] + "</td>";
                LbComplete.Text += "<td style='width: 10%;border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
                LbComplete.Text += ((string[])(data[i]))[3].Split(' ')[0] + "</td>";
                LbComplete.Text += "<td style='width: 50%;border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF; word-break: break-all; text-align:left;'>";
                LbComplete.Text += ((string[])(data[i]))[4] + "</td>";
                LbComplete.Text += "</tr>";
            }
        }
        else        
        {
            LbComplete.Text += "<td colspan=3 align=center style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #6699FF;'>";
            LbComplete.Text += "No data</td>";
        }
        LbComplete.Text += "</table>";
    }
    protected void DdlPageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData(DdlPageSelect.SelectedIndex);
    }
}