using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem3 : System.Web.UI.Page
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
        //LbNO.Text = Session["Semester"].ToString();
        LbYear.Text = Session["PlanYear"].ToString();
        if (!IsPostBack)
        {
            setPlanSchoolDirection();
            setInitial(GvInternalAdvantage, "PlanInternalAdvantage", "BtnRemoveInternalAdvantage");
            setInitial(GvInternalDefect, "PlanInternalDefect", "BtnRemoveInternalDefect");
            setInitial(GvExternalChallenge, "PlanExternalChallenge", "BtnRemoveExternalChallenge");
            setInitial(GvExternalOpportunity, "PlanExternalOpportunity", "BtnRemoveExternalOpportunity");
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
    protected void btn_InternalAdvantageClicked(object sender, EventArgs e)
    {
        //get your command argument from the button here
        Button btn = (Button)sender;        
        try
        {
            String yourAssignedValue = ((Button)sender).CommandArgument;
            if (btn.ID.ToString().Equals("BtnRemoveInternalAdvantage"))
            {
                deleteRow(GvInternalAdvantage, "PlanInternalAdvantage", yourAssignedValue, btn.ID);
            }
            else if (btn.ID.ToString().Equals("BtnRemoveInternalDefect"))
            {
                deleteRow(GvInternalDefect, "PlanInternalDefect", yourAssignedValue, btn.ID);
            }
            else if (btn.ID.ToString().Equals("BtnRemoveExternalChallenge"))
            {
                deleteRow(GvExternalChallenge, "PlanExternalChallenge", yourAssignedValue, btn.ID);
            }
            else if (btn.ID.ToString().Equals("BtnRemoveExternalOpportunity"))
            {
                deleteRow(GvExternalOpportunity, "PlanExternalOpportunity", yourAssignedValue, btn.ID);
            }
        }
        catch
        {
            //Check for exception
        }
        
    }

    private void deleteRow(GridView gv, string targetViewState, string rowIndex, string btnID)
    {
        if (Convert.ToInt32(rowIndex) == 0)
        {
            if (ViewState[targetViewState] == null)
                return;

            DataTable dt = (DataTable)ViewState[targetViewState];
            if (dt.Rows.Count == 0)
                return;
            dt.Rows[0][1] = "";
            TextBox box1 = (TextBox)gv.Rows[Convert.ToInt32(rowIndex)].Cells[0].FindControl("column1");
            box1.Text = "";
            ViewState[targetViewState] = dt;
            gv.DataSource = dt;
            gv.DataBind();
            SetPreviousData(gv, targetViewState, btnID);
        }
        else
        {
            DataTable dt = (DataTable)ViewState[targetViewState];
            dt.Rows.RemoveAt(Convert.ToInt32(rowIndex));

            for (int i = Convert.ToInt32(rowIndex); i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = (i + 1).ToString();
            }
            ViewState[targetViewState] = dt;
            gv.DataSource = dt;
            gv.DataBind();
            SetPreviousData(gv, targetViewState, btnID);
            
        }
    }

    private void SetPreviousData(GridView gv, string targetViewState, string btnID)
    {
        int rowIndex = 0;
        if (ViewState[targetViewState] == null)
            return;

        DataTable dt = (DataTable)ViewState[targetViewState];
        if (dt.Rows.Count == 0)
            return;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            TextBox box1 = (TextBox)gv.Rows[rowIndex].Cells[0].FindControl("column1");
            box1.Text = dt.Rows[i]["column1"].ToString();
            if (i < 1)
            {
                ((Button)gv.Rows[i].Cells[2].FindControl(btnID)).Text = "清空";
            }
            rowIndex++;
        }                        
        

    }
    private void setInitial(GridView gv, string targetViewState, string btnID)
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("SN", typeof(string)));
        dt.Columns.Add(new DataColumn("column1", typeof(string)));
        dt.Columns.Add(new DataColumn("btnClear", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select NO, Description from " + targetViewState + " where SN ='" + Session["UserPlanListSN"].ToString() + "' order by NO asc";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["SN"] = d[0];
                dr["column1"] = d[1];
                dr["btnClear"] = "清空";
                dt.Rows.Add(dr);
            }
            ViewState[targetViewState] = dt;

            gv.DataSource = dt;
            gv.DataBind();
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((TextBox)gv.Rows[i].Cells[1].FindControl("column1")).Text = d[1];
                if (i < 1)
                {
                    ((Button)gv.Rows[i].Cells[2].FindControl(btnID)).Text = "清空";
                    ((Button)gv.Rows[i].Cells[2].FindControl(btnID)).Text = "清空";
                }
            }

            return;
        }


        dr = dt.NewRow();
        dr["SN"] = "1";
        dr["column1"] = string.Empty;
        dt.Rows.Add(dr);

        ViewState[targetViewState] = dt;

        gv.DataSource = dt;
        gv.DataBind();

        ((Button)gv.Rows[0].Cells[2].FindControl(btnID)).Text = "清空";
    }
    private void setPlanSchoolDirection()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select SchoolDirection from PlanSchoolDirection where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.GetOneData(query, sb);
        TbSchoolDirection.Text = sb.ToString();
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        //int rowIndex = 0;
        Button btn = (Button)sender;
        if (btn.ID.ToString().Equals("BtnAddInternalAdvantage"))
        {
            addRow(GvInternalAdvantage, "PlanInternalAdvantage", "BtnRemoveInternalAdvantage");
            //if (ViewState["InternalAdvantage"] == null)
            //    return;

            //DataTable dtCurrentTable = (DataTable)ViewState["InternalAdvantage"];
            //DataRow drCurrentRow = null;
            //if (dtCurrentTable.Rows.Count == 0)
            //    return;

            //for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            //{
            //    //extract the TextBox values
            //    TextBox box1 = (TextBox)GvInternalAdvantage.Rows[rowIndex].Cells[0].FindControl("column1");
            //    drCurrentRow = dtCurrentTable.NewRow();
            //    drCurrentRow["SN"] = i + 1;
            //    dtCurrentTable.Rows[i - 1]["column1"] = box1.Text;
            //    rowIndex++;
            //}

            //dtCurrentTable.Rows.Add(drCurrentRow);
            //ViewState["InternalAdvantage"] = dtCurrentTable;

            //GvInternalAdvantage.DataSource = dtCurrentTable;
            //GvInternalAdvantage.DataBind();
            
            //SetPreviousData(GvInternalAdvantage);
        }
        else if (btn.ID.ToString().Equals("BtnAddInternalDefect"))
        {
            addRow(GvInternalDefect, "PlanInternalDefect", "BtnRemoveInternalDefect");
        }
        else if (btn.ID.ToString().Equals("BtnAddExternalChallenge"))
        {
            addRow(GvExternalChallenge, "PlanExternalChallenge", "BtnRemoveExternalChallenge");
        }
        else if (btn.ID.ToString().Equals("BtnAddExternalOpportunity"))
        {
            addRow(GvExternalOpportunity, "PlanExternalOpportunity", "BtnRemoveExternalOpportunity");
        }
        
    }

    private void addRow(GridView gv, string targetViewState, string btnID)
    {
        int rowIndex = 0;
        if (ViewState[targetViewState] == null)
            return;

        DataTable dtCurrentTable = (DataTable)ViewState[targetViewState];
        DataRow drCurrentRow = null;
        if (dtCurrentTable.Rows.Count == 0)
            return;

        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        {
            //extract the TextBox values
            TextBox box1 = (TextBox)gv.Rows[rowIndex].Cells[0].FindControl("column1");
            drCurrentRow = dtCurrentTable.NewRow();
            drCurrentRow["SN"] = i + 1;
            dtCurrentTable.Rows[i - 1]["column1"] = box1.Text;
            rowIndex++;
        }

        dtCurrentTable.Rows.Add(drCurrentRow);
        ViewState[targetViewState] = dtCurrentTable;

        gv.DataSource = dtCurrentTable;
        gv.DataBind();

        SetPreviousData(gv, targetViewState, btnID);
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
        else
        {
            storeData();
            storeData(GvInternalAdvantage, "PlanInternalAdvantage", "PlanInternalAdvantage");
            storeData(GvInternalDefect, "PlanInternalDefect", "PlanInternalDefect");
            storeData(GvExternalChallenge, "PlanExternalChallenge", "PlanExternalChallenge");
            storeData(GvExternalOpportunity, "PlanExternalOpportunity", "PlanExternalOpportunity");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
        }
    }

    private bool haveEmptyData()
    {
        //if (ViewState["InternalAdvantage"] != null)
        //{
        //    DataTable dt = (DataTable)ViewState["InternalAdvantage"];
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            bool flag = false;
        //            flag = isEmpty(((TextBox)GvInternalAdvantage.Rows[i].Cells[0].FindControl("column1")).Text);
        //            if (flag)
        //                return true;
        //        }
        //        return false;
        //    }
        //}
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
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSchoolDirection where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        
        sb.Clear();
        query = "insert into PlanSchoolDirection (SN, SchoolDirection) VALUES ('" +
                        Session["UserPlanListSN"].ToString() + "','" +
                        TbSchoolDirection.Text + "')";
        ms.WriteData(query, sb);        
    }

    private void storeData(GridView gv, string targetViewState, string targetTable)
    {
        writeData(gv, targetViewState, targetTable);

        //if (ViewState["InternalAdvantage"] != null)
        //{
            //StringBuilder sb = new StringBuilder();
            //DataTable dt = (DataTable)ViewState["InternalAdvantage"];
            //if (dt.Rows.Count > 0)
            //{
            //    ManageSQL ms = new ManageSQL();
            //    // 先刪除原本的
            //    string query = "delete from PlanInternalAdvantage where SN ='" + Session["UserPlanListSN"].ToString() + "' and NO ='" + NO + "'";
            //    ms.WriteData(query, sb);
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        sb.Clear();
            //        query = "insert into PlanInternalAdvantage (SN, NO, Description) VALUES ('" +
            //                        Session["UserPlanListSN"].ToString() + "','" +
            //                        DimensionsID + "','" + 
            //                        NO + "','" +
            //                        ((TextBox)GvInternalAdvantage.Rows[i].Cells[0].FindControl("column1")).Text + "')";

            //        ms.WriteData(query, sb);
                    
            //    }
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='PlanList.aspx';", true);
            //}
            //writeData((DataTable)ViewState["InternalAdvantage"], "PlanInternalAdvantage");
            
        //}
    }

    private void writeData(GridView gv, string targetViewState, string targetTable)
    {
        StringBuilder sb = new StringBuilder();
        DataTable dt = (DataTable)ViewState[targetViewState];
        if (dt.Rows.Count > 0)
        {
            ManageSQL ms = new ManageSQL();
            // 先刪除原本的
            string query = "delete from "+targetTable+" where SN ='" + Session["UserPlanListSN"].ToString() + "'";
            ms.WriteData(query, sb);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Clear();
                query = "insert into " + targetTable + " (SN, NO, Description) VALUES ('" +
                                Session["UserPlanListSN"].ToString() + "','" +
                                (i+1).ToString() + "',N'" +
                                ((TextBox)gv.Rows[i].Cells[0].FindControl("column1")).Text + "')";

                ms.WriteData(query, sb);

            }
            
        }
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}