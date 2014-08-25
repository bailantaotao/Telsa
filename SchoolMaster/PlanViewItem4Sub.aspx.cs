using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem4Sub : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string NO = string.Empty;
    private string DimensionsID = string.Empty;
    


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
        if (Request["NO"] == null || Request["DimensionsID"] == null)
            return;
        if (!parseData("NO") || !parseData("DimensionsID"))
            return;

        getTitle();
        setInitial();

        if (!IsPostBack)
        {
        }

        //NO = Request["NO"].ToString();
        //DimensionsID = Request["DimensionsID"].ToString();
        //getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        //if (!IsPostBack)
        //{

    }
    private bool parseData(string tag)
    {
        bool isdigit = false;
        int result = -1;
        isdigit = Int32.TryParse(Request[tag].ToString(), out result);
        return isdigit;
    }

    private void getTitle()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select Description from PlanSummaryDimensions where  SN= '" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='" + Request["DimensionsID"].ToString() + "' and NO='" + Request["NO"].ToString() + "'";

        ms.GetOneData(query, sb);
        if (Request["DimensionsID"].ToString().Equals("1"))
        {
            LbTitle.Text = "学科能力: ";
        }
        else if (Request["DimensionsID"].ToString().Equals("2"))
        {
            LbTitle.Text = "人格陶冶: ";
        }
        else if (Request["DimensionsID"].ToString().Equals("3"))
        {
            LbTitle.Text = "学校管理: ";
        }
        LbTitle.Text += Request["NO"].ToString()+". ";

        LbTitle.Text += sb.ToString();
        
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
        dt.Columns.Add(new DataColumn("column9", typeof(string)));
        dt.Columns.Add(new DataColumn("column10", typeof(string)));
        dt.Columns.Add(new DataColumn("column11", typeof(string)));
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Target, Activity, StartTime, EndTime, PersonInCharge, Budget, Resource, OtherResources, FinishRate, EstimateTime, EstimatePersonInCharge " +
                        "from PlanTargetActivity " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                        "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                        "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' ";

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
            dr["column9"] = d[8];
            dr["column10"] = d[9];
            dr["column11"] = d[10];
            dt.Rows.Add(dr);
        }
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString());
    }
    
}