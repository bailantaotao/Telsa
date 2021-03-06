﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem5 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    


    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        LbYear.Text = Session["PlanYear"].ToString();
        
        if (!IsPostBack)
        {
            setInitial();
        }

    }


    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("column1", typeof(string)));
        dt.Columns.Add(new DataColumn("column2", typeof(string)));
        dt.Columns.Add(new DataColumn("column3", typeof(string)));
        dt.Columns.Add(new DataColumn("column4", typeof(string)));
        dt.Columns.Add(new DataColumn("column5", typeof(string)));
        dt.Columns.Add(new DataColumn("column6", typeof(string)));
        dt.Columns.Add(new DataColumn("column7", typeof(string)));
        dt.Columns.Add(new DataColumn("column8", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select WeekNO, StartTime, EndTime, WorkContent, 1, 1, FinishRate, EstimateContidion " +
                        "from PlanCalendar " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' order by WeekNo asc " ;

        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            dr["column1"] = d[0];
            dr["column2"] = d[1].Contains(BaseClass.standardTimestamp)?Resources.Resource.TipNotWrite:d[1].Split(' ')[0];
            dr["column3"] = d[2].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[2].Split(' ')[0];
            dr["column4"] = d[3];
            dr["column5"] = findPersonInCharge(i, "PlanCalendarLeader");
            dr["column6"] = findPersonInCharge(i, "PlanCalendarPersonInCharge");
            dr["column7"] = d[6];
            dr["column8"] = d[7].Equals("") ? Resources.Resource.TipNotWrite : d[7];
            dt.Rows.Add(dr);
        }
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }

    private string findPersonInCharge(int index, string targetTable)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string personInCharge = string.Empty;
        string query = "select WeekNo, No, PlanCalendarPersonInCharge " +
                       "from " + targetTable + " " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' order by WeekNo asc ";

        ms.GetAllColumnData(query, data);
        for (int j = 0; j < data.Count; j++)
        {
            string[] DBData = (string[])data[j];
            if ((index+1).ToString().Equals(DBData[0]))
            {
                personInCharge += DBData[2] + "<br/>";
            }
        }
        return personInCharge;
    }

    private void setPersonInChargeData()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select WeekNo, No, PlanCalendarPersonInCharge " +
                       "from PlanCalendarPersonInCharge " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' order by WeekNo asc ";

        ms.GetAllColumnData(query, data);
        List<PersonInCharge> personIncharge = (List<PersonInCharge>)Session["PersonInCharge"];
        if (personIncharge != null)
        {
            for (int i = 0; i < personIncharge.Count; i++)
            {

                PersonInCharge pic = new PersonInCharge();
                for (int j = 0; j < data.Count; j++)
                {
                    string[] DBData = (string[])data[j];
                    if ((i + 1).ToString().Equals(DBData[0]))
                    {
                        pic.data.Add(new string[] { DBData[1], DBData[2] });
                    }
                }
                if (pic.data.Count > 0)
                {
                    personIncharge.RemoveAt(i);
                    personIncharge.Insert(i, pic);
                    Session["PersonInCharge"] = personIncharge;
                }

            }
        }

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["PersonInCharge"] != null)
            Session.Remove("PersonInCharge");
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString());
    }

    protected void btn_AddPersonInCharge(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            String yourAssignedValue = ((LinkButton)sender).CommandArgument;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanViewChargeInPerson.aspx?param1=0&param2=0&param3=" + yourAssignedValue + "', '', config='height=500,width=300');", true);
        }
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }

    protected void GvSchool_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[4].Text = Server.HtmlDecode(e.Row.Cells[4].Text);
            e.Row.Cells[5].Text = Server.HtmlDecode(e.Row.Cells[5].Text);
        }
    }
}