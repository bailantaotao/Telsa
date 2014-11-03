using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem8Sub : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string NO = string.Empty;
    private string DimensionsID = string.Empty;
    


    private StringBuilder schoolName = new StringBuilder();
    private StringBuilder schoolDepartmentNO = new StringBuilder();

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
        if (Request["DepartmentNO"] == null)
            return;
        if (!parseData("DepartmentNO"))
            return;

        getTitle();
        
        LbYear.Text = Session["PlanYear"].ToString();

        if (!IsPostBack)
        {
            setInitial();
        }

        GvSchool.Attributes.Add("style", "word-break:break-all;word-wrap:break-word");
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
        schoolDepartmentNO.Clear();
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        string query = "select Organization from PlanOrganizationOutline where SN='" + Session["UserPlanListSN"].ToString() + "' and NO='" + Request["DepartmentNO"].ToString() + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals(""))
            return;
        LbTitle.Text = sb.ToString() + "工作行动计画表";
        schoolDepartmentNO.Append(Request["DepartmentNO"].ToString());
        
    }

    private void getSemster()
    {
        //StringBuilder sb = new StringBuilder();
        //ManageSQL ms = new ManageSQL();
        //string query = "select PlanList.PlanSemester from PlanList " +
        //               "left join PlanListUser on PlanListUser.PlanListSN = PlanList.SN " +
        //               "where PlanListUser.SN='" + Session["UserPlanListSN"].ToString() + "'";
        //ms.GetOneData(query, sb);
        //LbSemster.Text = "学期: " + sb.ToString();
        //LbSemster.Text = "学期: " + Session["Semester"].ToString();
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
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select PersonInCharge, Gender, Title, NumbersOfPeople, Condition " +
                       "from PlanOrganization " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                       "OrganizationNO = '" + schoolDepartmentNO.ToString() + "'";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            LbName.Text = (d[0].Equals(Resources.Resource.TipPlzChoose) || d[0].Equals("")) ? Resources.Resource.TipNotWrite : d[0];
            LbGender.Text = (d[1].Equals(Resources.Resource.TipPlzChoose) || d[1].Equals("")) ? Resources.Resource.TipNotWrite : d[1];
            LbProfession.Text = (d[2].Equals(Resources.Resource.TipPlzChoose) || d[2].Equals("")) ? Resources.Resource.TipNotWrite : d[2];
            LbNumbersOfPeople.Text = (d[3].Equals(Resources.Resource.TipPlzChoose) || d[3].Equals("")) ? Resources.Resource.TipNotWrite : d[3];
            LbAdvantage.Text = (d[4].Equals(Resources.Resource.TipPlzChoose) || d[4].Equals("")) ? Resources.Resource.TipNotWrite : d[4];
        }


        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("column1", typeof(string)));
        dt.Columns.Add(new DataColumn("column2", typeof(string)));
        dt.Columns.Add(new DataColumn("column3", typeof(string)));
        dt.Columns.Add(new DataColumn("column4", typeof(string)));
        dt.Columns.Add(new DataColumn("column5", typeof(string)));
        dt.Columns.Add(new DataColumn("column6", typeof(string)));
        data.Clear();
        query = "select Target, Activity, StartTime, EndTime, FinishRate, Condition " +
                        "from PlanOrganizationList " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "'";

        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            dr["column1"] = (d[0].Equals(Resources.Resource.TipPlzChoose) || d[0].Equals("")) ? Resources.Resource.TipNotWrite : d[0];
            dr["column2"] = (d[1].Equals(Resources.Resource.TipPlzChoose) || d[1].Equals("")) ? Resources.Resource.TipNotWrite : d[1];
            dr["column3"] = d[2].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[2].Split(' ')[0];
            dr["column4"] = d[3].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[3].Split(' ')[0];
            dr["column5"] = d[4];
            dr["column6"] = (d[5].Equals(Resources.Resource.TipPlzChoose) || d[5].Equals("")) ? Resources.Resource.TipNotWrite : d[5];
            dt.Rows.Add(dr);
        }

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "&SCHOOLNAME=" + Session["SCHOOLNAME"].ToString());
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("../ProvinceIndex.aspx");
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("../MingdeIndex.aspx");
        }
    }
}