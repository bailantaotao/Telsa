using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItemAddMember : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        getRequest();
        if (Session["moreCount"] == null)
        {
            init(0, 50);
        }
        else
        {
            init(0, Convert.ToInt32(Session["moreCount"].ToString()) * 50 + 50);
        }
    }

    public void getRequest()
    {

        if (Request["PTAN"] == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('你没有权利进行接下来的操作');window.opener=null;window.close();", true);
            return;
        }
    }

    void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.Visible = false;
        if (Session["moreCount"] == null)
            Session["moreCount"] = 1;
        else
        {
            Session["moreCount"] = Convert.ToInt32(Session["moreCount"].ToString()) + 1;
        }
        init(Convert.ToInt32(Session["moreCount"].ToString()) * 50, Convert.ToInt32(Session["moreCount"].ToString()) * 50 + 50);

    }

    private void init(int startIndex, int endIndex)
    {
        DataTable dt = new DataTable();
        DataView dv = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);

        dt = dv.ToTable();
        this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<table>"));

        for (int i = startIndex; i < dt.Rows.Count && i < endIndex; i += 5)
        {
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<tr>"));
            for (int j = i; j < i + 5 && j < endIndex && j < dt.Rows.Count; j++)
            {
                LinkButton tb = new LinkButton();
                tb.Text = dt.Rows[j][0].ToString();
                tb.ID = "lkb" + (j + i).ToString();
                tb.CommandArgument = dt.Rows[j][1].ToString();
                tb.Click += tb_Click;
                this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<td width='130px'>"));
                this.UpdatePanel1.ContentTemplateContainer.Controls.Add(tb);
                this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</td>"));
            }
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</tr>"));
        }
        this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</table>"));

        if (Session["moreCount"] == null)
        {
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<table>"));
            Button btn = new Button();
            btn.ID = "1";
            btn.Text = "more...";
            btn.Click += btn_Click;
            if (dt.Rows.Count <= endIndex)
            {                
                btn.Visible = false;
            }
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<tr><td colspan='5'>"));
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(btn);
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</tr></td>"));
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</table>"));
        }
        else
        {
            if (endIndex - dt.Rows.Count >= 0 && endIndex - dt.Rows.Count <= 50)
                return;
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<table>"));
            Button btn = new Button();
            btn.ID = Session["moreCount"].ToString();
            btn.Text = "more...";
            btn.Click += btn_Click;
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("<tr><td colspan='5'>"));
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(btn);
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</tr></td>"));
            this.UpdatePanel1.ContentTemplateContainer.Controls.Add(new LiteralControl("</table>"));
        }
    }

    void tb_Click(object sender, EventArgs e)
    {
        LinkButton lkb = (LinkButton)sender;
        string id = lkb.CommandArgument;

        //ArrayList d = new ArrayList();
        //string query = "select SU_NAME, SU_SEX, SU_folk, SU_GdShl, SU_Tel, SU_Address from SchoolUser where ID ='" + id + "'";
        ManageSQL ms = new ManageSQL();
        //ms.GetAllColumnData(query, d);
        StringBuilder sb = new StringBuilder();

        //if (d.Count > 0)
        //{
            //string[] schoolUserData = (string[])d[0];

            /** 更新原來的資料表內容 */
            string query = "update PlanMember set " +
                    "PlanName =N'" + lkb.Text + "' " +
                    //"PlanGender =N'" + (schoolUserData[1].Equals("0")?"男":"女") + "'," +
                    //"PlanEthnic =N'" + schoolUserData[2] + "'," +
                    //"PlanCulture =N'" + schoolUserData[3] + "'," +
                    //"PlanTel =N'" + schoolUserData[4] + "'," +
                    //"PlanAddress =N'" + schoolUserData[5] + "' " +
                    "where SN = '" + Session["UserPlanListSN"].ToString() + "' AND PlanNo='" + (Convert.ToInt32(Request["PTAN"].ToString())+1) + "'";
            //query = "insert into PlanMember (SN, PlanNo, PlanName, PlanGender, PlanEthnic, PlanCulture, PlanTel, PlanAddress) VALUES ('" +
            //     Session["UserPlanListSN"].ToString() + "','" +
            //     Request["PTAN"].ToString() + "','" +
            //     schoolUserData[0] + "','" +
            //     schoolUserData[1] + "','" +
            //     schoolUserData[2] + "','" +
            //     schoolUserData[3] + "','" +
            //     schoolUserData[4] + "','" +
            //     schoolUserData[5] + "','" +
            ms.WriteData(query, sb);


            List<DataTable> personIncharge = (List<DataTable>)Session["Member"];

            for (int i = 0; i < personIncharge.Count; i++)
            {
                if (i.ToString().Equals(Request["PTAN"].ToString()))
                {
                    DataTable oldData = personIncharge[i];
                    oldData.Rows[0]["PlanName"] = lkb.Text;
                    //oldData.Rows[0]["PlanGender"] = schoolUserData[1];
                    //oldData.Rows[0]["PlanEthnic"] = schoolUserData[2];
                    //oldData.Rows[0]["PlanCulture"] = schoolUserData[3];
                    
                    //oldData.Rows[0]["PlanTel"] = schoolUserData[4];
                    //oldData.Rows[0]["PlanAddress"] = schoolUserData[5];


                    personIncharge[i] = oldData;
                    Session["Member"] = personIncharge;
                }
            }
        //}
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "window.opener.location.href='PlanItem1.aspx';window.close();", true);
    }

}