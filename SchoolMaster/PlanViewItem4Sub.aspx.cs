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
        
        
        LbYear.Text = Session["PlanYear"].ToString();

        if (!IsPostBack)
        {
            if (Session["PersonInCharge"] == null)
            {
                List<PersonInCharge> personInCharge = new List<PersonInCharge>();
                Session["PersonInCharge"] = personInCharge;
            }
            if (Session["PersonInCharge2"] == null)
            {
                List<PersonInCharge> personInCharge2 = new List<PersonInCharge>();
                Session["PersonInCharge2"] = personInCharge2;
            }
            setInitial();
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
        string query = "select Target, Activity, StartTime, EndTime, 1, Budget, Resource, OtherResources, FinishRate, EstimateTime, 1 " +
                        "from PlanTargetActivity " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                        "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                        "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' ";

        ms.GetAllColumnData(query, data);

        List<PersonInCharge> personInCharge = (List<PersonInCharge>)Session["PersonInCharge"];
        List<PersonInCharge> personInCharge2 = (List<PersonInCharge>)Session["PersonInCharge2"];
        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            dr = dt.NewRow();
            dr["column1"] = d[0].Equals("") ? Resources.Resource.TipNotWrite : d[0];
            dr["column2"] = d[1].Equals("") ? Resources.Resource.TipNotWrite : d[1];
            dr["column3"] = d[2].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[2].Split(' ')[0];
            dr["column4"] = d[3].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[3].Split(' ')[0];
            dr["column5"] = findPersonInCharge(i, "PlanTargetActivityPersonInCharge");
            dr["column6"] = d[5].Equals("0") ? Resources.Resource.TipNotWrite : d[5];
            dr["column7"] = d[6].Equals("") ? Resources.Resource.TipNotWrite : d[6];
            dr["column8"] = d[7].Equals("") ? Resources.Resource.TipNotWrite : d[7];
            dr["column9"] = d[8].Equals("") ? Resources.Resource.TipNotWrite : d[8];
            dr["column10"] = d[9].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[9].Split(' ')[0];
            dr["column11"] = findPersonInCharge(i, "PlanTargetActivityPersonInCharge2");
            dt.Rows.Add(dr);
            personInCharge.Add(new PersonInCharge());
            personInCharge2.Add(new PersonInCharge());
        }
        Session["PersonInCharge"] = personInCharge;
        Session["PersonInCharge2"] = personInCharge2;
        setPersonInChargeData();
        setPersonInChargeData2();
        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
    }
    private string findPersonInCharge(int index, string targetTable)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string personInCharge = string.Empty;
        string query = "select PlanTargetActivityNO, NO, PersonInCharge " +
                       "from " + targetTable + " " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                       "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                       "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' " +
                       "order by PlanTargetActivityNO asc, No asc";

        ms.GetAllColumnData(query, data);
        for (int j = 0; j < data.Count; j++)
        {
            string[] DBData = (string[])data[j];
            if (index.ToString().Equals(DBData[0]))
            {
                personInCharge += DBData[2] + "\n";
            }
        }
        return personInCharge;
    }

    private void setPersonInChargeData()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select PlanTargetActivityNO, NO, PersonInCharge " +
                       "from PlanTargetActivityPersonInCharge " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                       "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                       "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' " +
                       "order by PlanTargetActivityNO asc, No asc";

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
                    if (i.ToString().Equals(DBData[0]))
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
    private void setPersonInChargeData2()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select PlanTargetActivityNO, NO, PersonInCharge " +
                       "from PlanTargetActivityPersonInCharge2 " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                       "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                       "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' " +
                       "order by PlanTargetActivityNO asc, No asc";

        ms.GetAllColumnData(query, data);
        List<PersonInCharge> personIncharge = (List<PersonInCharge>)Session["PersonInCharge2"];
        if (personIncharge != null)
        {
            for (int i = 0; i < personIncharge.Count; i++)
            {

                PersonInCharge pic = new PersonInCharge();
                for (int j = 0; j < data.Count; j++)
                {
                    string[] DBData = (string[])data[j];
                    if (i.ToString().Equals(DBData[0]))
                    {
                        pic.data.Add(new string[] { DBData[1], DBData[2] });
                    }
                }
                if (pic.data.Count > 0)
                {
                    personIncharge.RemoveAt(i);
                    personIncharge.Insert(i, pic);
                    Session["PersonInCharge2"] = personIncharge;
                }

            }
        }

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["PersonInCharge"] != null)
            Session.Remove("PersonInCharge");
        if (Session["PersonInCharge2"] != null)
            Session.Remove("PersonInCharge2");
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
    protected void btn_AddPersonInCharge2(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            String yourAssignedValue = ((LinkButton)sender).CommandArgument;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanViewChargeInPerson2.aspx?param1=0&param2=0&param3=" + yourAssignedValue + "', '', config='height=500,width=300');", true);
        }
    }
    
}