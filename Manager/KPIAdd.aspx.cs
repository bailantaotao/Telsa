﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_KPIAdd : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            setInitial();
        }
        TbDeadline.Attributes.Add("readonly", "true");

    }
    protected void btn_View(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                storeData();
                String yourAssignedValue = ((Button)sender).CommandArgument;                               
                Response.Redirect("PlanItem7Sub.aspx?DepartmentNO=" + (Convert.ToInt32(yourAssignedValue) + 1));
                
            }
            catch
            {
                //Check for exception
            }
        }
    }

    protected void btn_Delete(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;

                {
                    DataTable dt = (DataTable)ViewState["dt"];

                    ManageSQL ms = new ManageSQL();
                    string querydeadlineSN = "select SN from KPIDeadline where KPIYear = '" + dt.Rows[Convert.ToInt32(yourAssignedValue)][1] + "' and Semester = '" + dt.Rows[Convert.ToInt32(yourAssignedValue)][2] + "'";
                    StringBuilder sbdeadlineSN = new StringBuilder();
                    ms.GetOneData(querydeadlineSN, sbdeadlineSN);
                    string query = "delete from KPIDeadline where KPIYear = '" + dt.Rows[Convert.ToInt32(yourAssignedValue)][1] + "' and Semester = '" + dt.Rows[Convert.ToInt32(yourAssignedValue)][2] + "'";
                    StringBuilder sb = new StringBuilder();
                    ms.WriteData(query, sb);
                    dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));

                    for (int i = Convert.ToInt32(yourAssignedValue); i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i][0] = (i + 1).ToString();
                    }

                    
                    string querydeletedeadline = "delete from KPIRecordMain where KPIDeadlineSN = '" + sbdeadlineSN.ToString() + "'";
                    StringBuilder sbdeletedeadline = new StringBuilder();
                    ms.WriteData(querydeletedeadline, sbdeletedeadline);

                    Response.Redirect("KPIAdd.aspx");
                    //ViewState["dt"] = dt;
                    //GvDepartment.DataSource = dt;
                    //GvDepartment.DataBind();
                    //SetPreviousData();
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
                    //TextBox box1 = (TextBox)GvDepartment.Rows[rowIndex].Cells[1].FindControl("TbName");

                    //box1.Text = dt.Rows[i]["TbName"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SN", typeof(string)));
        dt.Columns.Add(new DataColumn("Year", typeof(string)));
        dt.Columns.Add(new DataColumn("Semester", typeof(string)));
        dt.Columns.Add(new DataColumn("Deadline", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select KPIYear, Semester, Deadline " +
                       "from KPIDeadline order by KPIYear desc, Semester asc";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["SN"] = (i + 1).ToString();
                dr["Year"] = d[0];
                dr["Semester"] = d[1];
                dr["Deadline"] = d[2].Split(' ')[0];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvDepartment.DataSource = dt;
            GvDepartment.DataBind();
            return;
        }

        ViewState["dt"] = dt;

        GvDepartment.DataSource = dt;
        GvDepartment.DataBind();
    }

    private void addDatatoDB()
    {
 
    }

    protected void BtnStore_Click(object sender, EventArgs e)
    {
        int status = haveEmptyData();
        if (status == 1)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
            return;
        }
        else if (status == 2)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('不正确的学期号码');", true);
            return;
        }

        if (haveData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('已有资料存在');", true);
            return;
        }


        storeData();
        
    }

    private const int SUCCESS = 0;
    private const int EMPTY_DATA = 1;
    private const int INCORRECT_DATA = 2;

    private int haveEmptyData()
    {
        if (TbYear.Text.Equals(""))
            return EMPTY_DATA;
        else if (TbDeadline.Text.Equals(""))
            return EMPTY_DATA;
        else if (TbSemester.Text.Equals(""))
            return EMPTY_DATA;
        else if (!TbSemester.Text.Equals("1") && !TbSemester.Text.Equals("2"))
            return INCORRECT_DATA;

        return SUCCESS;
    }

    private bool haveData()
    {
        string query = "select count(*) from KPIDeadline where KPIYear='" + TbYear.Text.Trim() + "' and Semester = '" + TbSemester.Text.Trim() + "'";
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        if (ms.GetRowNumbers(query, sb))
        {
            if (!sb.ToString().Equals("0"))
                return true;
            return false;
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

            ManageSQL ms = new ManageSQL();
            string query = string.Empty;

            query = "insert into KPIDeadline (KPIYear, Deadline, Semester) VALUES ('" +
                            TbYear.Text.Trim() + "','" +
                            TbDeadline.Text.Trim() + "','" +
                            TbSemester.Text.Trim() + "')";

            ms.WriteData(query, sb);

            setInitial();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');", true);


        }
    }

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}