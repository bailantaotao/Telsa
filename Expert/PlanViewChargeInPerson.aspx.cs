﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_PlanViewChargeInPerson : System.Web.UI.Page
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
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
        //    Response.Redirect("../SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("0"))
        //    Response.Redirect("../SessionOut.aspx");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // test script http://localhost:50995/SchoolMaster/PlanChargeInPerson.aspx?SN=1&DID=1&PSDN=1&PTAN=1
        //Session["UserPlanListSN"] = "17";
        getRequest();
        if (!IsPostBack)
        {
            setInitial();            
        }

    }

    public void getRequest()
    {
        // param1 = DID
        // param2 = PSDN
        // param3 = PTAN
        if (Request["param1"] == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('你没有权利进行接下来的操作');window.opener=null;window.close();", true);
            return;
        }
        if (Request["param2"] == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('你没有权利进行接下来的操作');window.opener=null;window.close();", true);
            return;
        }
        if (Request["param3"] == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('你没有权利进行接下来的操作');window.opener=null;window.close();", true);
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

    protected void btn_Delete(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;

                //storeData();
                DataTable dt = (DataTable)ViewState["dt"];
                dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                for (int i = Convert.ToInt32(yourAssignedValue); i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][1] = (i + 1).ToString();
                }
                ViewState["dt"] = dt;
                GvDepartment.DataSource = dt;
                GvDepartment.DataBind();
                SetPreviousData();
                

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
        dt.Columns.Add(new DataColumn("PersonInCharge", typeof(string)));
        

        //ManageSQL ms = new ManageSQL();
        //ArrayList data = new ArrayList();
        //string query = "select NO, PersonInCharge " +
        //               "from PlanTargetActivityPersonInCharge " +
        //               "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
        //               "DimensionsID = '" + Request["DID"].ToString() + "' and " +
        //               "PlanSummaryDimensionsNO = '" + Request["PSDN"].ToString() + "' and " +
        //               "PlanTargetActivityNO = '" + Request["PTAN"].ToString() + "' order by NO asc";

        //ms.GetAllColumnData(query, data);
        List<PersonInCharge> personIncharge = (List<PersonInCharge>)Session["PersonInCharge"];

        
        for (int i = 0; i < personIncharge.Count; i++)
        {
            if (i.ToString().Equals(Request["param3"].ToString()))
            {
                PersonInCharge collection = personIncharge[i];
                if (collection.data.Count > 0)
                {
                    for (int j = 0; j < collection.data.Count; j++)
                    {
                        string[] t = (string[])collection.data[j];
                        dr = dt.NewRow();
                        dr["PersonInCharge"] = t[1];
                        dr["SN"] = j;
                        dt.Rows.Add(dr);
                    }
                    ViewState["dt"] = dt;

                    GvDepartment.DataSource = dt;
                    GvDepartment.DataBind();
                    return;
                }

            }
        }
        

        ViewState["dt"] = dt;

        GvDepartment.DataSource = dt;
        GvDepartment.DataBind();
        if (GvDepartment.Rows.Count == 0)
        {
            //dt.Rows.Add(dt.NewRow());
            //GvDepartment.DataSource = dt;
            //GvDepartment.DataBind();
            //int totalcolums = GvDepartment.Rows[0].Cells.Count;
            //GvDepartment.Rows[0].Cells.Clear();
            //GvDepartment.Rows[0].Cells.Add(new TableCell());
            //GvDepartment.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //GvDepartment.Rows[0].Cells[0].Text = "现在没有任何负责人";
        }
    }

    private void addDatatoDB()
    {

    }

    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
    }

    private bool haveEmptyData()
    {
        return false;
    }
    private bool isEmpty(string data)
    {
        if (string.IsNullOrEmpty(data))
            return true;
        return false;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "window.opener=null;window.close();", true);

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "window.opener=null;window.close();", true);
    }
}