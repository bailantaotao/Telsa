using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem1 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private const int NATION = 0;
    private const int CULTURE = 1;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string MODIFIED = "MODIFIED";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;
    private ArrayList mProvinceUser = new ArrayList();


    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LbNO.Text = Session["Semester"].ToString();
        LbYear.Text = Session["PlanYear"].ToString();
        setName();
        if (!IsPostBack)
        {
            if (Session["Member"] == null)
            {
                List<DataTable> personInCharge = new List<DataTable>();
                Session["Member"] = personInCharge;
            }
            setInitial();
        }
        //getSchoolName(schoolName);
        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        //if (!IsPostBack)
        //{

        //}

    }


    private void setName()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder zipcode = new StringBuilder();
        string query = "select zipcode from Account where UserID = '" + Session["UserID"].ToString() + "'";
        ms.GetOneData(query, zipcode);

        if (zipcode.ToString().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('成员名单链结错误，请联络系统管理者');", true);
            return;
        }

        query = "select top(50) SU_NAME, SU_SEX, SU_FOLK, SU_GdShl, SU_Tel, SU_Address from SchoolUser where A_ID = '"+zipcode.ToString()+"'";

        ms.GetAllColumnData(query, mProvinceUser);

        if (mProvinceUser.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('找不到成员名单，如有疑问请询问系统管理者');", true);
            return;
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
    protected void btn_Clicked(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;
                if (Convert.ToInt32(yourAssignedValue) < 2)
                {
                    if (ViewState["dt"] != null)
                    {
                        DataTable dt = (DataTable)ViewState["dt"];
                        if (dt.Rows.Count > 0)
                        {

                            LinkButton box1 = (LinkButton)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[1].FindControl("TbName");
                            DropDownList box2 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("TbGender");

                            setConfig(((DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("TbNation")), NATION);
                            DropDownList box3 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("TbNation");

                            setConfig(((DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("TbCulture")), CULTURE);
                            DropDownList box4 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("TbCulture");

                            TextBox box5 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[5].FindControl("TbProfessional");
                            TextBox box6 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[6].FindControl("TbTel");
                            TextBox box7 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[7].FindControl("TbAddress");

                            box1.Text = "";
                            box2.SelectedIndex = 0;
                            box3.SelectedIndex = 0;
                            box4.SelectedIndex = 0;
                            box5.Text = "";
                            box6.Text = "";
                            box7.Text = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][1] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][2] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][3] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][4] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][5] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][6] = "";
                            dt.Rows[Convert.ToInt32(yourAssignedValue)][7] = "";

                        }
                        ViewState["dt"] = dt;
                        GvSchool.DataSource = dt;
                        GvSchool.DataBind();
                        SetPreviousData();
                    }
                }
                else
                {
                    List<DataTable> personInCharge = (List<DataTable>)Session["Member"];
                    personInCharge.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    Session["Member"] = personInCharge;

                    DataTable dt = (DataTable)ViewState["dt"];
                    dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["SN"] = (i + 1).ToString();
                    }
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
    public void setConfig(DropDownList ddl, int config)
    {
        string query = "select * from ";
        if (config == NATION)
            query += "PlanNationMappingTable";
        else if(config == CULTURE)
            query += "PlanCultureMappingTable";
        
        
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ms.GetAllColumnData(query, data);
        
        foreach (string[] t in data)
        {
            ddl.Items.Add(new ListItem(t[0], t[0]));
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

                    LinkButton box1 = (LinkButton)GvSchool.Rows[rowIndex].Cells[1].FindControl("TbName");
                    DropDownList box2 = (DropDownList)GvSchool.Rows[rowIndex].Cells[2].FindControl("TbGender");

                    setConfig(((DropDownList)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbNation")), NATION);
                    DropDownList box3 = (DropDownList)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbNation");

                    setConfig(((DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbCulture")), CULTURE);
                    DropDownList box4 = (DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbCulture");

                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("TbProfessional");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("TbTel");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("TbAddress");

                    box1.Text = dt.Rows[i]["TbName"].ToString();
                    //box2.SelectedIndex = (dt.Rows[i]["TbGender"].ToString().Equals(Resources.Resource.TipPlzChoose) || dt.Rows[i]["TbGender"].ToString().Equals("")) ? 0 : (dt.Rows[i]["TbGender"].ToString().Equals("1") ? 2 : 1);
                    box2.SelectedValue = dt.Rows[i]["TbGender"].ToString();
                    
                    box3.SelectedValue = dt.Rows[i]["TbNation"].ToString();
                    box4.SelectedValue = dt.Rows[i]["TbCulture"].ToString();
                    box5.Text = dt.Rows[i]["TbProfessional"].ToString();
                    box6.Text = dt.Rows[i]["TbTel"].ToString();
                    box7.Text = dt.Rows[i]["TbAddress"].ToString();
                    if (i < 2)
                    {
                        ((Button)GvSchool.Rows[i].Cells[8].FindControl("lbnView")).Text = "清空";
                        ((Button)GvSchool.Rows[i].Cells[8].FindControl("lbnView")).Text = "清空";
                    }
                    rowIndex++;
                }
            }
        }
    }

    private string getNation()
    {
        return string.Empty;
    }

    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("PlanTitle", typeof(string)));
        dt.Columns.Add(new DataColumn("TbName", typeof(string)));
        dt.Columns.Add(new DataColumn("TbGender", typeof(string)));
        dt.Columns.Add(new DataColumn("TbNation", typeof(string)));
        dt.Columns.Add(new DataColumn("TbCulture", typeof(string)));
        dt.Columns.Add(new DataColumn("TbProfessional", typeof(string)));
        dt.Columns.Add(new DataColumn("TbTel", typeof(string)));
        dt.Columns.Add(new DataColumn("TbAddress", typeof(string)));
        dt.Columns.Add(new DataColumn("SN", typeof(string)));
        dt.Columns.Add(new DataColumn("btnClear", typeof(string)));


        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select PlanTitle, PlanName, PlanGender, PlanEthnic, PlanCulture, PlanProfession, PlanTel, PlanAddress from PlanMember where SN ='" + Session["UserPlanListSN"].ToString() + "' order by PlanNo asc";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            List<DataTable> personInCharge = (List<DataTable>)Session["Member"];
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["PlanTitle"] = d[0];
                dr["TbName"] = d[1].Equals("") ? Resources.Resource.TipPlzChoose : d[1];
                dr["TbGender"] = d[2];
                dr["TbNation"] = d[3];
                dr["TbCulture"] = d[4];
                dr["TbProfessional"] = d[5];
                dr["TbTel"] = d[6];
                dr["TbAddress"] = d[7];
                dr["SN"] = (i+1).ToString();
                dr["btnClear"] = "清空";
                dt.Rows.Add(dr);

                personInCharge.Add(new DataTable());
            }
            Session["Member"] = personInCharge;

            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                //dr["SN"] = (i + 1).ToString();
                //dr["PlanTitle"] = d[0];

                ((LinkButton)GvSchool.Rows[i].Cells[1].FindControl("TbName")).Text = d[1].Equals("") ? Resources.Resource.TipPlzChoose : d[1];
                //((DropDownList)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).SelectedIndex = d[2].Equals(Resources.Resource.TipPlzChoose) ? 0 : (Convert.ToInt32(d[2]) + 1);
                ((DropDownList)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).SelectedValue = d[2];

                setConfig(((DropDownList)GvSchool.Rows[i].Cells[3].FindControl("TbNation")), NATION);
                ((DropDownList)GvSchool.Rows[i].Cells[3].FindControl("TbNation")).SelectedValue = d[3];

                setConfig(((DropDownList)GvSchool.Rows[i].Cells[4].FindControl("TbCulture")), CULTURE);
                ((DropDownList)GvSchool.Rows[i].Cells[4].FindControl("TbCulture")).SelectedValue = d[4];

                ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("TbProfessional")).Text = d[5];
                ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("TbTel")).Text = d[6];
                ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("TbAddress")).Text = d[7];
                if (i < 2)
                {
                    ((Button)GvSchool.Rows[i].Cells[8].FindControl("lbnView")).Text = "清空";
                    ((Button)GvSchool.Rows[i].Cells[8].FindControl("lbnView")).Text = "清空";
                }
            }
            setPersonInChargeData();
            return;
        }

        List<DataTable> personIncharge = (List<DataTable>)Session["Member"];
        
        dr = dt.NewRow();
        dr["PlanTitle"] = "主任";
        dr["TbName"] = string.Empty;
        dr["TbGender"] = string.Empty;
        dr["TbNation"] = string.Empty;
        dr["TbCulture"] = string.Empty;
        dr["TbProfessional"] = string.Empty;
        dr["TbTel"] = string.Empty;
        dr["TbAddress"] = string.Empty;
        dr["SN"] = "1";
        dr["btnClear"] = "清空";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["PlanTitle"] = "副主任";
        dr["TbName"] = string.Empty;
        dr["TbGender"] = string.Empty;
        dr["TbNation"] = string.Empty;
        dr["TbCulture"] = string.Empty;
        dr["TbProfessional"] = string.Empty;
        dr["TbTel"] = string.Empty;
        dr["TbAddress"] = string.Empty;
        dr["SN"] = "2";
        dr["btnClear"] = "清空";
        dt.Rows.Add(dr);

        personIncharge.Add(new DataTable());
        Session["Member"] = personIncharge;

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();
        ((Button)GvSchool.Rows[0].Cells[8].FindControl("lbnView")).Text = "清空";
        ((Button)GvSchool.Rows[1].Cells[8].FindControl("lbnView")).Text = "清空";
        setConfig(((DropDownList)GvSchool.Rows[0].Cells[3].FindControl("TbNation")), NATION);
        setConfig(((DropDownList)GvSchool.Rows[1].Cells[3].FindControl("TbNation")), NATION);
        setConfig(((DropDownList)GvSchool.Rows[0].Cells[3].FindControl("TbCulture")), CULTURE);
        setConfig(((DropDownList)GvSchool.Rows[1].Cells[3].FindControl("TbCulture")), CULTURE);
    }

    private void setPersonInChargeData()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select  PlanNo, PlanGender, PlanEthnic, PlanCulture, PlanProfession, PlanTel, PlanAddress " +
                       "from PlanMember " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' " +
                       "order by PlanNo asc";

        ms.GetAllColumnData(query, data);
        List<DataTable> personIncharge = (List<DataTable>)Session["Member"];
        if (personIncharge != null)
        {
            for (int i = 0; i < personIncharge.Count; i++)
            {

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("PlanName", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanGender", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanEthnic", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanCulture", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanProfession", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanTel", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanAddress", typeof(string)));

                for (int j = 0; j < data.Count; j++)
                {
                    string[] DBData = (string[])data[j];
                    if ((i+1).ToString().Equals(DBData[0]))
                    {
                        DataRow workRow = dt.NewRow();
                        workRow["PlanName"] = "";
                        workRow["PlanGender"] = DBData[0];
                        workRow["PlanEthnic"] = DBData[1];
                        workRow["PlanCulture"] = DBData[2];
                        workRow["PlanProfession"] = DBData[3];
                        workRow["PlanTel"] = DBData[4];
                        workRow["PlanAddress"] = DBData[5];
                        dt.Rows.Add(workRow);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    personIncharge.RemoveAt(i);
                    personIncharge.Insert(i, dt);
                    Session["Member"] = personIncharge;
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
                    LinkButton box1 = (LinkButton)GvSchool.Rows[rowIndex].Cells[1].FindControl("TbName");
                    DropDownList box2 = (DropDownList)GvSchool.Rows[rowIndex].Cells[2].FindControl("TbGender");

                    setConfig(((DropDownList)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbNation")), NATION);
                    DropDownList box3 = (DropDownList)GvSchool.Rows[rowIndex].Cells[3].FindControl("TbNation");

                    setConfig(((DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbCulture")), CULTURE);
                    DropDownList box4 = (DropDownList)GvSchool.Rows[rowIndex].Cells[4].FindControl("TbCulture");


                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("TbProfessional");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("TbTel");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("TbAddress");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["SN"] = (i + 1).ToString();
                    drCurrentRow["PlanTitle"] = "成員";
                    dtCurrentTable.Rows[i - 1]["TbName"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["TbGender"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["TbNation"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["TbCulture"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["TbProfessional"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["TbTel"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["TbAddress"] = box7.Text;

                    rowIndex++;
                }
                List<DataTable> personInCharge = (List<DataTable>)Session["Member"];
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("PlanName", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanGender", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanEthnic", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanCulture", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanProfession", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanTel", typeof(string)));
                dt.Columns.Add(new DataColumn("PlanAddress", typeof(string)));
                DataRow workRow = dt.NewRow();
                workRow["PlanName"] = "";
                workRow["PlanGender"] = "";
                workRow["PlanEthnic"] = "";
                workRow["PlanCulture"] = "";
                workRow["PlanProfession"] = "";
                workRow["PlanTel"] = "";
                workRow["PlanAddress"] = "";
                dt.Rows.Add(workRow);
                personInCharge.Add(dt);
                Session["Member"] = personInCharge;

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
        if (Session["Member"] != null)
            Session.Remove("Member");
        if (Session["moreCount"] != null)
            Session.Remove("moreCount");
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (Session["Member"] != null)
            Session.Remove("Member");
        if (Session["moreCount"] != null)
            Session.Remove("moreCount");

        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
        else
        {
            storeData();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
        }
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
                    bool flag = false;
                    //flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[1].FindControl("TbName")).Text);
                    //if (flag)
                    //    return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[3].FindControl("TbNation")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[4].FindControl("TbCulture")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[5].FindControl("TbProfessional")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[6].FindControl("TbTel")).Text);
                    if (flag)
                        return true;
                    flag = isEmpty(((TextBox)GvSchool.Rows[i].Cells[7].FindControl("TbAddress")).Text);
                    if (flag)
                        return true;
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
                string query = "delete from PlanMember where SN ='" + Session["UserPlanListSN"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into PlanMember (SN, PlanTitle, PlanName, PlanGender, PlanEthnic, PlanCulture, PlanProfession, PlanTel, PlanAddress, PlanNO) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    dt.Rows[i][0].ToString() + "',N'" +
                                    ((LinkButton)GvSchool.Rows[i].Cells[1].FindControl("TbName")).Text + "',N'" +
                                    //(((DropDownList)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).SelectedValue.Equals(Resources.Resource.TipPlzChoose) ? Resources.Resource.TipPlzChoose : Convert.ToInt32(((DropDownList)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).SelectedIndex - 1).ToString()) + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[2].FindControl("TbGender")).SelectedValue + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[3].FindControl("TbNation")).SelectedValue + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[4].FindControl("TbCulture")).SelectedValue + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("TbProfessional")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("TbTel")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("TbAddress")).Text + "',N'"+
                                    dt.Rows[i][8].ToString() + "')";

                    ms.WriteData(query, sb);
                    
                }
                
            }
        }
    }

    protected void btn_AddPersonInCharge(object sender, EventArgs e)
    {
        storeData();
        if (sender is LinkButton)
        {
            if (Session["moreCount"] != null)
                Session.Remove("moreCount");
            String yourAssignedValue = ((LinkButton)sender).CommandArgument;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "window.open('PlanItemAddMember.aspx?PTAN=" + yourAssignedValue + "', '', config='height=500,width=550,scrollbars=yes');", true);
        }
    }
}