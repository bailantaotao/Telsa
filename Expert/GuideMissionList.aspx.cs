using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideMissionList : System.Web.UI.Page
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

    private enum DdlType
    {
        Province,
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        BtnStore.Visible = false;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setInitial();
        }
    }
    private string SearchProvince()
    {
        string query = "select Area.name from Area where Area.id='" + Session["Province"].ToString() + "'";
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ms.GetOneData(query, sb);
        return string.IsNullOrEmpty(sb.ToString()) ? "none" : sb.ToString();
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
                Response.Redirect("GuideMission.aspx?MissionNO=" + (Convert.ToInt32(yourAssignedValue) + 1));
            }
            catch
            {
                //Check for exception
            }
        }
    }
    protected void btn_Delete(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = string.Empty;

        //get your command argument from the button here
        if (sender is Button)
        {
            try
            {
                String yourAssignedValue = ((Button)sender).CommandArgument;
                
                storeData();
                DataTable dt = (DataTable)ViewState["dt"];
                dt.Rows.RemoveAt(Convert.ToInt32(yourAssignedValue));
                for (int i = Convert.ToInt32(yourAssignedValue); i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][1] = (i + 1).ToString();
                }
                ViewState["dt"] = dt;
                GvMissionList.DataSource = dt;
                GvMissionList.DataBind();
                SetPreviousData();

                storeData();

                query = "delete from GuideMission where SN='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and MissionNo=" + (Convert.ToInt32(yourAssignedValue) + 1);
                ms.WriteData(query, sb);
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
            if (dt.Rows.Count >= 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rowIndex++;
                }
            }
        }
    }
    private void setInitial()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("MissionListName", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListYear", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListSemester", typeof(string)));
        dt.Columns.Add(new DataColumn("MissionListNo", typeof(string)));

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MissionName, Year, Semester, No " +
                       "from GuideMissionList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                dr = dt.NewRow();
                dr["MissionListNo"] = d[3];
                dr["MissionListName"] = d[0];
                dr["MissionListYear"] = d[1];
                dr["MissionListSemester"] = d[2];
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvMissionList.DataSource = dt;
            GvMissionList.DataBind();
            return;
        }

        /*dr = dt.NewRow();
        dr["MissionListName"] = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";
        dr["MissionListYear"] = "2014";
        dr["MissionListSemester"] = "1";
        dr["MissionListNo"] = "1";
        dt.Rows.Add(dr);*/

        

        ViewState["dt"] = dt;

        GvMissionList.DataSource = dt;
        GvMissionList.DataBind();
        
        return;
    }

    
    protected void BtnAdd_Click1(object sender, EventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Year, Semester, No " +
                       "from GuideMissionList " +
                       "where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);

        if (data.Count == 0)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("MissionListName", typeof(string)));
            dt.Columns.Add(new DataColumn("MissionListYear", typeof(string)));
            dt.Columns.Add(new DataColumn("MissionListSemester", typeof(string)));
            dt.Columns.Add(new DataColumn("MissionListNo", typeof(string)));

            dr = dt.NewRow();
            dr["MissionListName"] = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";
            dr["MissionListYear"] = DlListYear.SelectedValue;
            dr["MissionListSemester"] = DlAddListSemester.SelectedValue;
            dr["MissionListNo"] = "1";
            dt.Rows.Add(dr);

            ViewState["dt"] = dt;

            GvMissionList.DataSource = dt;
            GvMissionList.DataBind();

            return;
        }

        int rowIndex = 0;
        if (ViewState["dt"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["dt"];
            DataRow drCurrentRow = null;

            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["MissionListNo"] = (data.Count + 1);
                    drCurrentRow["MissionListName"] = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";
                    drCurrentRow["MissionListYear"] = DlListYear.SelectedValue;
                    drCurrentRow["MissionListSemester"] = DlAddListSemester.SelectedValue;
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["dt"] = dtCurrentTable;

                GvMissionList.DataSource = dtCurrentTable;
                GvMissionList.DataBind();
            }
            SetPreviousData();
            storeData();
        }
        Response.Redirect("GuideMission.aspx?MissionNO=" + (data.Count + 1));
    }
    
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        storeData();
    }

    private bool haveEmptyData()
    {
        return false;
    }

    private void storeData()
    {
        if (ViewState["dt"] != null)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count >= 0)
            {
                ManageSQL ms = new ManageSQL();
                // 先刪除原本的
                string query = "delete from GuideMissionList where SN ='" + Session["UserGuideListSN"].ToString() + "'" ;
                ms.WriteData(query, sb);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Clear();
                    query = "insert into GuideMissionList (SN, MissionName, Year, Semester, No, County) VALUES ('" +
                                    Session["UserGuideListSN"].ToString() + "',N'" +
                                    dt.Rows[i][0].ToString() + "',N'" +
                                    dt.Rows[i][1].ToString() + "',N'" +
                                    dt.Rows[i][2].ToString() + "',N'" +
                                    (i + 1) + "',N'" +
                                    SearchProvince().ToString() + "')";

                    ms.WriteData(query, sb);

                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " ", true);

            }
        }
    }
   
    

    


    
}