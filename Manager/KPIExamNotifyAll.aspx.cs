using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_KPIExamNotifyAll : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
        //    Response.Redirect("../SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("2"))
        //    Response.Redirect("../SessionOut.aspx");
        setProvince();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void setProvince()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string Query = "select zipcode.name from zipcode";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlProvince.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlProvince.Items.Add("None");
            return;
        }
        DdlProvince.Items.Add(Resources.Resource.DdlTypeProvince);
        foreach (string[] province in data)
        {
            DdlProvince.Items.Add(province[0]);
        }
    }
    private void loadData()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        string query = "select SchoolName, TotalScore, ScoreLevel, zipcode.name " +
                        "from KPIRecordMain " +
                        "left join Account on account.school = kpirecordmain.schoolname " +
                        "left join zipcode on zipcode.zipcode = account.zipcode " +
                        "where zipcode.name=N'" + DdlProvince.Items[DdlProvince.SelectedIndex] + "'";

        if (!ms.GetAllColumnData(query, data))
        {
            return;
        }

        if (data.Count == 0)
        {
            GvSchool.DataSource = null;
            GvSchool.DataBind();
            //GvSchool.Rows[0].Cells.Clear();
            //GvSchool.Rows[0].Cells.Add(new TableCell());
            //GvSchool.Rows[0].Cells[0].ColumnSpan = 4;
            //GvSchool.Rows[0].Cells[0].Text = Resources.Resource.TipKPINoRecord;
            //GvSchool.Rows[0].Cells[0].Style.Add("text-align", "center");
            //GvSchool.Rows[0].Cells[0].Width = 590;
            return;
        }

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("SchoolName"), new DataColumn("ScoreLevel"), new DataColumn("TotalScore") });
        foreach (string[] d in data)
        {
            dt.Rows.Add(d[0], string.IsNullOrEmpty(d[2]) ? "E" : d[2], string.IsNullOrEmpty(d[1]) ? "0" : d[1]);
        }
            
        GvSchool.DataSource = dt;
        GvSchool.DataBind();
        
    }
    protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["NotifyAll"] != null)
            Session.Remove("NotifyAll");
        loadData();
    }
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[3] { new DataColumn("SchoolName"), new DataColumn("ScoreLevel"), new DataColumn("TotalScore") });
        bool isChecked = false;
        foreach (GridViewRow row in GvSchool.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                if (chkRow.Checked)
                {
                    isChecked = true;
                    string SchoolName = row.Cells[1].Text;
                    string ScoreLevel = row.Cells[2].Text;
                    string TotalScore = row.Cells[3].Text;
                    dt.Rows.Add(SchoolName, ScoreLevel, TotalScore);
                }
            }
        }

        if (!isChecked)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipKPIAtLeastOne + "');", true);
            return;
        }

        Session["NotifyAll"] = dt;
        Response.Redirect("MsgNotify.aspx");
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "window.close()", true);
    }
}