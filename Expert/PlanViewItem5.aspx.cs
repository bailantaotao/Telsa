using System;
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
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LbNO.Text = Session["Semester"].ToString();
        LbYear.Text = Session["PlanYear"].ToString();
        setInitial();
        if (!IsPostBack)
        {
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
        string query = "select WeekNO, StartTime, EndTime, WorkContent, Leader, PersonInCharge, FinishRate, EstimateContidion " +
                        "from PlanCalendar " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' order by WeekNo asc " ;

        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            dr["column1"] = d[0];
            dr["column2"] = d[1];
            dr["column3"] = d[2];
            dr["column4"] = d[3];
            dr["column5"] = d[4];
            dr["column6"] = d[5];
            dr["column7"] = d[6];
            dr["column8"] = d[7];
            dt.Rows.Add(dr);
        }
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString()+"&SCHOOLNAME="+Session["SCHOOLNAME"].ToString());
    }
   
}