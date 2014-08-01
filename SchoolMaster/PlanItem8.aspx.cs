using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem8 : System.Web.UI.Page
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
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setInitial();
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
    protected void btn_View(object sender, EventArgs e)
    {
        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;

                if (Session["Store"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您尚未储存无法进行修改');", true);
                }
                else {
                    Session.Remove("Store");
                    Response.Redirect("PlanItem8Sub.aspx?DepartmentNO=" + (Convert.ToInt32(yourAssignedValue) + 1) + "");
                }
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
                    if(Session["Store"] !=null)
                        Session.Remove("Store");
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
        dt.Columns.Add(new DataColumn("Department", typeof(string)));
        dt.Columns.Add(new DataColumn("SN", typeof(string)));


        dr = dt.NewRow();
        dr["Department"] = "数学组";
        dr["SN"] = "1";
        dt.Rows.Add(dr);

        ViewState["dt"] = dt;

        GvDepartment.DataSource = dt;
        GvDepartment.DataBind();
    }

    private void addDatatoDB()
    {
 
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {        
        if (TbDepartmentName.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
            return;
        }



        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["dt"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                if (Session["Store"] != null)
                    Session.Remove("Store");
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values

                    //TextBox box1 = (TextBox)GvDepartment.Rows[rowIndex].Cells[1].FindControl("TbName");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["Department"] = TbDepartmentName.Text.Trim();
                    drCurrentRow["SN"] = (i+1).ToString();
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dt"] = dtCurrentTable;

                GvDepartment.DataSource = dtCurrentTable;
                GvDepartment.DataBind();
            }
            SetPreviousData();
            TbDepartmentName.Text = "";
        }

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanList.aspx");
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
                string query = "delete from PlanOrganizationOutline where SN ='" + Session["UserPlanListSN"].ToString() + "'";
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into PlanOrganizationOutline (SN, NO, Organization) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    dt.Rows[i][1].ToString() + "','" +
                                    dt.Rows[i][0].ToString() + "')";

                    ms.WriteData(query, sb);
                    
                }
                Session["Store"] = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');", true);
            }
        }
    }
}