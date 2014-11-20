using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_PlanItemAdd : System.Web.UI.Page
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
                if (Convert.ToInt32(yourAssignedValue) < 1)
                {
                    // not to do anything
                    //if (ViewState["dt"] != null)
                    //{
                    //    DataTable dt = (DataTable)ViewState["dt"];
                    //    if (dt.Rows.Count > 0)
                    //    {

                    //    }
                    //    ViewState["dt"] = dt;
                    //}
                }
                else
                {
                    storeData();
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
        dt.Columns.Add(new DataColumn("Year", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Planyear " +
                       "from planlist order by PlanYear desc";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["Year"] = d[0];
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

    protected void BtnAdd_Click(object sender, EventArgs e)
    {        
        //if (TbDepartmentName.Text.Trim().Equals(""))
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        //    return;
        //}



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

                    //TextBox box1 = (TextBox)GvDepartment.Rows[rowIndex].Cells[1].FindControl("TbName");

                    drCurrentRow = dtCurrentTable.NewRow();

                    //drCurrentRow["Department"] = TbDepartmentName.Text.Trim();
                    //drCurrentRow["SN"] = (i+1).ToString();
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dt"] = dtCurrentTable;

                GvDepartment.DataSource = dtCurrentTable;
                GvDepartment.DataBind();
            }
            SetPreviousData();
            //TbDepartmentName.Text = "";
        }

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewList.aspx");
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
            return;
        }
        if (haveData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('已有资料存在');", true);
            return;
        }
        
        
        storeData();
        
    }

    private bool haveEmptyData()
    {
        if (TbYear.Text.Equals(""))
            return true;
        else if (TbDeadline.Text.Equals(""))
            return true;

        return false;
    }

    private bool haveData()
    {
        string query = "select count(*) from planList where PlanYear='" + TbYear.Text.Trim() + "'";
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

            query = "insert into PlanList (PlanYear, PlanDeadline) VALUES ('" +
                            TbYear.Text.Trim() + "','" +
                            TbDeadline.Text.Trim() + "')";

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