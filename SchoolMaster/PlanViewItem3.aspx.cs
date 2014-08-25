using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem3 : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            setPlanSchoolDirection();
            setInitial(GvInternalAdvantage, "PlanInternalAdvantage");
            setInitial(GvInternalDefect, "PlanInternalDefect");
            setInitial(GvExternalChallenge, "PlanExternalChallenge");
            setInitial(GvExternalOpportunity, "PlanExternalOpportunity");
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

    private void setPlanSchoolDirection()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select SchoolDirection from PlanSchoolDirection where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.GetOneData(query, sb);
        LbSchoolDirection.Text = sb.ToString();
    }
   
    private void setInitial(GridView gv, string targetViewState)
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SN", typeof(string)));
        dt.Columns.Add(new DataColumn("column1", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select NO, Description from " + targetViewState + " where SN ='" + Session["UserPlanListSN"].ToString() + "' order by NO asc";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            dr["SN"] = d[0];
            dr["column1"] = d[1];
            dt.Rows.Add(dr);
        }

        ViewState[targetViewState] = dt;

        gv.DataSource = dt;
        gv.DataBind();
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString());
    }
   
    
}