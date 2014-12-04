using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem4Sub : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string NO = string.Empty;
    private string DimensionsID = string.Empty;

    string DID = string.Empty;
    string PSDN = string.Empty;


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
        if (Request["NO"] == null || Request["DimensionsID"] == null)
            return;
        if (!parseData("NO") || !parseData("DimensionsID"))
            return;

        getTitle();

        if (!IsPostBack)
        {
            if (Session["PersonInCharge"] == null)
            {
                List<PersonInCharge> personInCharge = new List<PersonInCharge>();
                Session["PersonInCharge"] = personInCharge;
            }
            if (Session["PersonInCharge2"] == null)
            {
                List<PersonInCharge> personInCharge = new List<PersonInCharge>();
                Session["PersonInCharge2"] = personInCharge;
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
        DID = Request["DimensionsID"].ToString();
        PSDN = Request["NO"].ToString();
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
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;
                if (Convert.ToInt32(yourAssignedValue) < 1)
                {
                    if (ViewState["dt"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["dt"];
                        if (dt.Rows.Count > 0)
                        {

                            TextBox box1 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[0].FindControl("column1");
                            TextBox box2 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("column2");
                            TextBox box3 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("column3");
                            TextBox box4 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("column4");
                            //TextBox box5 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("column5");
                            TextBox box6 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[5].FindControl("column6");
                            TextBox box7 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[6].FindControl("column7");
                            TextBox box8 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[7].FindControl("column8");
                            //DropDownList box9 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[8].FindControl("column9");
                            TextBox box10 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[9].FindControl("column10");
                            //DropDownList box11 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[10].FindControl("column11");

                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                            box1.Text = "";
                            box2.Text = "";
                            box3.Text = "";
                            box4.Text = "";
                            //box5.Text = "";
                            box6.Text = "";
                            box7.Text = "";
                            box8.Text = "";
                            //box9.SelectedIndex = 0;
                            box10.Text = "";
                            //box11.SelectedIndex = 0;

                            dt.Rows[Convert.ToInt32(yourAssignedValue)][0] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][1] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][2] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][3] = "";
                            //dt.Rows[Convert.ToInt32(yourAssignedValue)][4] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][5] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][6] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][7] = "";
                            //dt.Rows[Convert.ToInt32(yourAssignedValue)][8] = 0;
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][9] = "";
                            //dt.Rows[Convert.ToInt32(yourAssignedValue)][10] = 0;

                        }
                        ViewState["dt"] = dt;
                        GvSchool.DataSource = dt;
                        GvSchool.DataBind();
                        SetPreviousData();
                    }
                }
                else
                {
                    List<PersonInCharge> personInCharge = (List<PersonInCharge>)Session["PersonInCharge"];
                    personInCharge.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    Session["PersonInCharge"] = personInCharge;

                    List<PersonInCharge> personInCharge2 = (List<PersonInCharge>)Session["PersonInCharge2"];
                    personInCharge2.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    Session["PersonInCharge2"] = personInCharge2;

                    DataTable dt = (DataTable)ViewState["dt"];
                    dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    ViewState["dt"] = dt;
                    GvSchool.DataSource = dt;
                    GvSchool.DataBind();
                    SetPreviousData();
                }
                

            }
            catch
            {
                //Check for exception
            }
        }
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("column1");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4");
                    //TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("column7");
                    TextBox box8 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("column8");
                    DropDownList box9 = (DropDownList)GvSchool.Rows[rowIndex].Cells[8].FindControl("column9");
                    TextBox box10 = (TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10");
                    //DropDownList box11 = (DropDownList)GvSchool.Rows[rowIndex].Cells[10].FindControl("column11");

                    ((TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                    box1.Text = dt.Rows[i]["column1"].ToString();
                    box2.Text = dt.Rows[i]["column2"].ToString();
                    box3.Text = dt.Rows[i]["column3"].ToString();
                    box4.Text = dt.Rows[i]["column4"].ToString();
                    //box5.Text = dt.Rows[i]["column5"].ToString();
                    box6.Text = dt.Rows[i]["column6"].ToString();
                    box7.Text = dt.Rows[i]["column7"].ToString();
                    box8.Text = dt.Rows[i]["column8"].ToString();
                    box9.SelectedValue = dt.Rows[i]["column9"].ToString();
                    box10.Text = dt.Rows[i]["column10"].ToString();
                    //box11.SelectedValue = dt.Rows[i]["column11"].ToString();
                    if (i < 1)
                    {
                        ((Button)GvSchool.Rows[i].Cells[11].FindControl("lbnView")).Text = "清空";
                    }
                    rowIndex++;
                }
            }
        }
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
        dt.Columns.Add(new DataColumn("btnClear", typeof(string)));
        dt.Columns.Add(new DataColumn("finish", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Target, Activity, StartTime, EndTime, 1, Budget, Resource, OtherResources, FinishRate, EstimateTime, 1, Finish " +
                        "from PlanTargetActivity " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                        "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                        "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' order by NO asc";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            List<PersonInCharge> personInCharge = (List<PersonInCharge>)Session["PersonInCharge"];
            List<PersonInCharge> personInCharge2 = (List<PersonInCharge>)Session["PersonInCharge2"];
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["column1"] = d[0];
                dr["column2"] = d[1];
                dr["column3"] = d[2].Contains(BaseClass.standardTimestamp) ? "" : d[2].Split(' ')[0];
                dr["column4"] = d[3].Contains(BaseClass.standardTimestamp) ? "" : d[3].Split(' ')[0];
                //dr["column5"] = d[4];
                dr["column6"] = d[5];
                dr["column7"] = d[6];
                dr["column8"] = d[7];
                dr["column9"] = d[8];
                dr["column10"] = d[9].Contains(BaseClass.standardTimestamp) ? "" : d[9].Split(' ')[0];
                //dr["column11"] = d[10];
                dr["btnClear"] = "清空";
                dr["finish"] = d[11];

                dt.Rows.Add(dr);
                personInCharge.Add(new PersonInCharge());
                personInCharge2.Add(new PersonInCharge());
            }
            Session["PersonInCharge"] = personInCharge;
            Session["PersonInCharge2"] = personInCharge2;

            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text = d[0];
                ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text = d[1];
                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text = d[2].Contains(BaseClass.standardTimestamp) ? "" : d[2].Split(' ')[0];
                ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text = d[3].Contains(BaseClass.standardTimestamp) ? "" : d[3].Split(' ')[0];
                //((TextBox)GvSchool.Rows[i].Cells[4].FindControl("column5")).Text = d[4];
                ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text = d[5];
                ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text = d[6];
                ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text = d[7];
                ((DropDownList)GvSchool.Rows[i].Cells[8].FindControl("column9")).SelectedValue = d[8];
                ((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Text = d[9].Contains(BaseClass.standardTimestamp) ? "" : d[9].Split(' ')[0];
                //((DropDownList)GvSchool.Rows[i].Cells[10].FindControl("column11")).SelectedValue = d[10];

                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                ((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                if (i < 1)
                {
                    ((Button)GvSchool.Rows[i].Cells[11].FindControl("lbnView")).Text = "清空";
                }
            }
            setPersonInChargeData();
            setPersonInChargeData2();
            return;
        }

        List<PersonInCharge> personIncharge = (List<PersonInCharge>)Session["PersonInCharge"];
        List<PersonInCharge> personIncharge2 = (List<PersonInCharge>)Session["PersonInCharge2"];

        dr = dt.NewRow();
        dr["column1"] = string.Empty;
        dr["column2"] = string.Empty;
        dr["column3"] = string.Empty;
        
        dr["column4"] = string.Empty;
        dr["column5"] = string.Empty;
        dr["column6"] = string.Empty;
        dr["column7"] = string.Empty;
        dr["column8"] = string.Empty;
        dr["column9"] = string.Empty;
        dr["column10"] = string.Empty;
        dr["column11"] = string.Empty;
        dr["btnClear"] = "清空";
        dr["finish"] = "False";
        dt.Rows.Add(dr);

        personIncharge.Add(new PersonInCharge());
        personIncharge2.Add(new PersonInCharge());
        Session["PersonInCharge"] = personIncharge;
        Session["PersonInCharge2"] = personIncharge2;

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();

        ((TextBox)GvSchool.Rows[0].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
        ((TextBox)GvSchool.Rows[0].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
        ((TextBox)GvSchool.Rows[0].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");
        ((Button)GvSchool.Rows[0].Cells[11].FindControl("lbnView")).Text = "清空";
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
        if (personIncharge !=null)
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
                    if ((i + 1).ToString().Equals(DBData[0]))
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["dt"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)GvSchool.Rows[rowIndex].Cells[0].FindControl("column1");
                    TextBox box2 = (TextBox)GvSchool.Rows[rowIndex].Cells[1].FindControl("column2");
                    TextBox box3 = (TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3");
                    TextBox box4 = (TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4");
                    //TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("column7");
                    TextBox box8 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("column8");
                    DropDownList box9 = (DropDownList)GvSchool.Rows[rowIndex].Cells[8].FindControl("column9");
                    TextBox box10 = (TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10");
                    //DropDownList box11 = (DropDownList)GvSchool.Rows[rowIndex].Cells[10].FindControl("column11");

                    ((TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                    drCurrentRow = dtCurrentTable.NewRow();


                    dtCurrentTable.Rows[i - 1]["column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["column4"] = box4.Text;
                    //dtCurrentTable.Rows[i - 1]["column5"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["column6"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["column7"] = box7.Text;
                    dtCurrentTable.Rows[i - 1]["column8"] = box8.Text;
                    dtCurrentTable.Rows[i - 1]["column9"] = box9.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["column10"] = box10.Text;
                    //dtCurrentTable.Rows[i - 1]["column11"] = box11.SelectedValue;

                    rowIndex++;

                    drCurrentRow[0] = box1.Text;
                }
                
                List<PersonInCharge> personInCharge = (List<PersonInCharge>)Session["PersonInCharge"];
                personInCharge.Add(new PersonInCharge());
                Session["PersonInCharge"] = personInCharge;

                List<PersonInCharge> personInCharge2 = (List<PersonInCharge>)Session["PersonInCharge2"];
                personInCharge2.Add(new PersonInCharge());
                Session["PersonInCharge2"] = personInCharge2;

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dt"] = dtCurrentTable;

                GvSchool.DataSource = dtCurrentTable;
                GvSchool.DataBind();
            }
            SetPreviousData();
        }

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["PersonInCharge"] != null)
            Session.Remove("PersonInCharge");
        if (Session["PersonInCharge2"] != null)
            Session.Remove("PersonInCharge2");
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        //if (!isDigit())
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('预算必须是数字');", true);
        //}
        //else
        //{
        storeData();
        if(Session["PersonInCharge"] != null)
            Session.Remove("PersonInCharge");
        if (Session["PersonInCharge2"] != null)
            Session.Remove("PersonInCharge2");
        //}
    }
    private bool isDigit()
    {
        int digit = -1;
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bool isDigit = Int32.TryParse(((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text.ToString(), out digit);
                    if (!isDigit)
                    {
                        ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text = "";
                        return false;
                    }
                }
            }
        }
        return true;
    }
    private bool haveEmptyData()
    {
        return false;
        if (ViewState["dt"] != null)
        {
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   

                    //bool flag = false;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[4].FindControl("column5")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[8].FindControl("column9")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Text);
                    //if (flag)
                    //    return true;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[10].FindControl("column11")).Text);
                    //if (flag)
                    //    return true;
                }
                return false;
            }
        }
        return false;
    }
    private bool isEmpty(string data)
    {
        if (string.IsNullOrEmpty(data))
            return true;
        return false;
    }

    private void storeData()
    {
        if (ViewState["dt"] != null)
        {

            StringBuilder sb = new StringBuilder();
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                ManageSQL ms = new ManageSQL();
                // 先刪除原本的
                string query = "delete from PlanTargetActivity where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID ='" + Request["DimensionsID"].ToString() + "' and PlanSummaryDimensionsNO='" + Request["NO"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into PlanTargetActivity (SN, DimensionsID, PlanSummaryDimensionsNO, Target, Activity, StartTime, EndTime, Budget, Resource, OtherResources, FinishRate, EstimateTime, NO, Finish) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    Request["DimensionsID"].ToString() + "','" +
                                    Request["NO"].ToString() + "',N'" + 
                                    ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text.Split(' ')[0] + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text.Split(' ')[0] + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[8].FindControl("column9")).SelectedValue + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Text.Split(' ')[0] + "','" +
                                    i + "','"+
                                    dt.Rows[i]["finish"].ToString() + "')";

                    ms.WriteData(query, sb);

                    List<PersonInCharge> personIncharge = (List<PersonInCharge>)Session["PersonInCharge"];
                    if (personIncharge != null)
                    {
                        //foreach (PersonInCharge PersonInChargeInfo in personIncharge)
                        //{
                            // 先刪除原本的
                            query = "delete from PlanTargetActivityPersonInCharge where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                                    "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                                    "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' and " +
                                    "PlanTargetActivityNO = '" + i + "'";
                            ms.WriteData(query, sb);

                            
                            PersonInCharge pic = personIncharge[i];
                            for (int j = 0; j < pic.data.Count; j++)
                            {
                                sb.Clear();
                                string[] tmp = (string[])pic.data[j];
                                query = "insert into PlanTargetActivityPersonInCharge (SN, DimensionsID, PlanSummaryDimensionsNO, PlanTargetActivityNO, NO, PersonInCharge) VALUES ('" +
                                                Session["UserPlanListSN"].ToString() + "','" +
                                                Request["DimensionsID"].ToString() + "','" +
                                                Request["NO"].ToString() + "','" +
                                                i + "',N'" +
                                                tmp[0].ToString() + "',N'" +
                                                tmp[1].ToString() + "')";

                                ms.WriteData(query, sb);

                            }

                        //}
                    }

                    List<PersonInCharge> personIncharge2 = (List<PersonInCharge>)Session["PersonInCharge2"];
                    if (personIncharge2 != null)
                    {
                        //foreach (PersonInCharge PersonInChargeInfo in personIncharge)
                        //{
                        // 先刪除原本的
                        query = "delete from PlanTargetActivityPersonInCharge2 where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                                "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                                "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' and " +
                                "PlanTargetActivityNO = '" + i + "'";
                        ms.WriteData(query, sb);


                        PersonInCharge pic = personIncharge2[i];
                        for (int j = 0; j < pic.data.Count; j++)
                        {
                            sb.Clear();
                            string[] tmp = (string[])pic.data[j];
                            query = "insert into PlanTargetActivityPersonInCharge2 (SN, DimensionsID, PlanSummaryDimensionsNO, PlanTargetActivityNO, NO, PersonInCharge) VALUES ('" +
                                            Session["UserPlanListSN"].ToString() + "','" +
                                            Request["DimensionsID"].ToString() + "','" +
                                            Request["NO"].ToString() + "','" +
                                            i + "',N'" +
                                            tmp[0].ToString() + "',N'" +
                                            tmp[1].ToString() + "')";

                            ms.WriteData(query, sb);

                        }

                        //}
                    }
                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
            }
            
        }


    }
    protected void btn_AddPersonInCharge(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            String yourAssignedValue = ((LinkButton)sender).CommandArgument;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanChargeInPerson.aspx?param1=" + DID + "&param2=" + PSDN + "&param3=" + yourAssignedValue + "', '', config='height=500,width=300');", true);
        }
    }

    protected void btn_AddPersonInCharge2(object sender, EventArgs e)
    {
        if (sender is LinkButton)
        {
            String yourAssignedValue = ((LinkButton)sender).CommandArgument;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanChargeInPerson2.aspx?param1=" + DID + "&param2=" + PSDN + "&param3=" + yourAssignedValue + "', '', config='height=500,width=300');", true);
        }
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}