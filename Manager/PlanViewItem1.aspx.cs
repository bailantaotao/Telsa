using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem1 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string MODIFIED = "MODIFIED";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //LbNO.Text = Session["Semester"].ToString();
        LbYear.Text = Session["PlanYear"].ToString();
        if (!IsPostBack)
        {
            setInitial();
        }
        //getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        //if (!IsPostBack)
        //{

    }


    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    protected void btn_Clicked(object sender, EventArgs e)
    {
        
    }
    private void SetPreviousData()
    {
        
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));
        dt.Columns.Add(new DataColumn("Column7", typeof(string)));
        dt.Columns.Add(new DataColumn("Column8", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select PlanTitle, PlanName, PlanGender, PlanEthnic, PlanCulture, PlanProfession, PlanTel, PlanAddress from PlanMember where SN ='" + Session["UserPlanListSN"].ToString() + "' order by PlanNo asc";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++ )
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            
            dr["Column1"] = d[0];
            dr["Column2"] = d[1].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[1];
            dr["Column3"] = d[2].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[2];
            dr["Column4"] = d[3].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[3];
            dr["Column5"] = d[4].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[4];
            dr["Column6"] = d[5].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[5];
            dr["Column7"] = d[6].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[6];
            dr["Column8"] = d[7].Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipNotWrite : d[7];
            dt.Rows.Add(dr);
        }


        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }


    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString()+"&SCHOOLNAME="+Session["SCHOOLNAME"].ToString());
    }

    protected void BtnStore_Click(object sender, EventArgs e)
    {
        
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}