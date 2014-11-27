using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_QInputScore2 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;

    private const string YEAR = "YEAR";
    private const string SEMESTER = "SEMESTER";
    private const string SCHOOLNAME = "SCHOOLNAME";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        Province,
        Year,
        SchoolName,
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserID"] = "admin";
        //Session["ListSN"] = "1";
        //Session["SchoolID"] = "巴彦淖尔市磴口县渡口镇明德小学";
        //Session["Year"] = "2014";
        //Session["Semester"] = "1";

        LbYear.Text = Request[YEAR].ToString().Trim();
        LbSchoolNo.Text = getSchoolNo(Request[SCHOOLNAME].ToString()).Trim();
        LbSemester.Text = Request[SEMESTER].ToString().Trim();
        LbSchool.Text = Request[SCHOOLNAME].ToString().Trim();        

        //LbSchoolName.Text = schoolName.ToString();
        //LbSchoolSN.Text = Session["UserID"].ToString();
        //LbSchoolMaster.Text = Session["UserName"].ToString();
        if (!IsPostBack)
        {
            setGradeLevel();
            //if (Session["QViewScore"] != null)
            //    Query = Session["QViewScore"].ToString();
            //else
            //    SearchType();
            

            // Enable the GridView sorting option. 
            gvPerson.AllowSorting = true;


            // Initialize the sorting expression. 
            ViewState["SortExpression"] = "StudentID ASC";

            // Populate the GridView. 
            BindGridView();
            
        }

        removeSession("QInputScoreList");
    }

    private void removeSession(string key)
    {
        if (Session[key] != null)
            Session.Remove(key);
    }


    private void BindGridView()
    {       
        // Get the connection string from Web.config.  
        // When we use Using statement,  
        // we don't need to explicitly dispose the object in the code,  
        // the using statement takes care of it. 
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConStr"].ToString()))
        {
            if (Session["QViewScore"] != null)
                Query = Session["QViewScore"].ToString();
            else
                SearchType();

            // Create a DataSet object. 
            DataSet dsPerson = new DataSet();


            // Create a SELECT query. 
            //string strSelectCmd = "SELECT PersonID,LastName,FirstName FROM Person";
            string strSelectCmd = Query;



            // Create a SqlDataAdapter object 
            // SqlDataAdapter represents a set of data commands and a  
            // database connection that are used to fill the DataSet and  
            // update a SQL Server database.  
            SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);


            // Open the connection 
            conn.Open();


            // Fill the DataTable named "Person" in DataSet with the rows 
            // returned by the query.new n 
            da.Fill(dsPerson, "QScore" + LbYear.Text + LbSemester.Text);


            // Get the DataView from Person DataTable. 
            DataView dvPerson = dsPerson.Tables["QScore" + LbYear.Text + LbSemester.Text].DefaultView;


            // Set the sort column and sort order. 
            dvPerson.Sort = ViewState["SortExpression"].ToString();


            // Bind the GridView control. 
            gvPerson.DataSource = dvPerson;
            gvPerson.DataBind();
        }
    }


    // GridView.RowDataBound Event 
    protected void gvPerson_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Make sure the current GridViewRow is a data row. 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Make sure the current GridViewRow is either  
            // in the normal state or an alternate row. 
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            {
                // Add client-side confirmation when deleting. 
                //((LinkButton)e.Row.Cells[1].Controls[0]).Attributes["onclick"] = "if(!confirm('Are you certain you want to delete this person ?')) return false;";
            }
        }
    }


    // GridView.PageIndexChanging Event 
    protected void gvPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Set the index of the new display page.  
        gvPerson.PageIndex = e.NewPageIndex;


        // Rebind the GridView control to  
        // show data in the new page. 
        BindGridView();
    }


    // GridView.RowEditing Event 
    protected void gvPerson_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Make the GridView control into edit mode  
        // for the selected row.  
        gvPerson.EditIndex = e.NewEditIndex;


        // Rebind the GridView control to show data in edit mode. 
        BindGridView();


    }


    // GridView.RowCancelingEdit Event 
    protected void gvPerson_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // Exit edit mode. 
        gvPerson.EditIndex = -1;


        // Rebind the GridView control to show data in view mode. 
        BindGridView();


    }
    private const int SUCCESS = 0;
    private const int EXCEPTION_DIGIT = 1;
    private const int EXCEPTION_SMALLER_THAN_100 = 2;

    private int digitCheck(string data)
    {
        if (data.Equals(""))
            return SUCCESS;

        int result = 0;
        bool convertSuccess = Int32.TryParse(data, out result);
        if(!convertSuccess)
            return EXCEPTION_DIGIT;

        if (result > 100)
            return EXCEPTION_SMALLER_THAN_100;

        return SUCCESS;
    }

    // GridView.RowUpdating Event 
    protected void gvPerson_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Get the PersonID of the selected row. 
        string strPersonID = gvPerson.Rows[e.RowIndex].Cells[2].Text;
        string tbChin = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbChin")).Text;
        string tbMath = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbMath")).Text;
        string tbEng = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbEng")).Text;
        string tbSoc = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbSoc")).Text;
        string tbSci = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbSci")).Text;
        string tbMus = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbMus")).Text;
        string tbPhy = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbPhy")).Text;
        string tbArt = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("tbArt")).Text;
        if (digitCheck(tbChin) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbMath) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbEng) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbSoc) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbSci) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbMus) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbPhy) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }
        if (digitCheck(tbArt) != SUCCESS)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入成績的格式有誤，必须為數字，且大于0和小于等于100');", true);
            return;
        }


        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConStr"].ToString()))
        {
            // Create a command object. 
            SqlCommand cmd = new SqlCommand();


            // Assign the connection to the command. 
            cmd.Connection = conn;


            // Set the command text 
            // SQL statement or the name of the stored procedure  
            //cmd.CommandText = "UPDATE Person SET LastName = @LastName, FirstName = @FirstName WHERE PersonID = @PersonID";
            cmd.CommandText = "UPDATE " + "QScore" + LbYear.Text + LbSemester.Text + " SET " +
                                "Chinese = @Chinese, " +
                                "Math = @Math, " +
                                "English = @English, "+
                                "Society = @Society, " +
                                "Science = @Science, " +
                                "Music = @Music, " +
                                "Physical = @Physical, " +
                                "Art = @Art " +
                                "WHERE StudentID = @StudentID";



            // Set the command type 
            // CommandType.Text for ordinary SQL statements;  
            // CommandType.StoredProcedure for stored procedures. 
            cmd.CommandType = CommandType.Text;


            


            // Append the parameters. 
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar, 50).Value = strPersonID;
            if (tbChin.Equals(""))
                cmd.Parameters.Add("@Chinese", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Chinese", SqlDbType.Int).Value = Convert.ToInt32(tbChin);

            if (tbMath.Equals(""))
                cmd.Parameters.Add("@Math", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Math", SqlDbType.Int).Value = Convert.ToInt32(tbMath);

            if (tbEng.Equals(""))
                cmd.Parameters.Add("@English", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@English", SqlDbType.Int).Value = Convert.ToInt32(tbEng);

            if (tbSoc.Equals(""))
                cmd.Parameters.Add("@Society", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Society", SqlDbType.Int).Value = Convert.ToInt32(tbSoc);

            if (tbSci.Equals(""))
                cmd.Parameters.Add("@Science", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Science", SqlDbType.Int).Value = Convert.ToInt32(tbSci);

            if (tbMus.Equals(""))
                cmd.Parameters.Add("@Music", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Music", SqlDbType.Int).Value = Convert.ToInt32(tbMus);

            if (tbPhy.Equals(""))
                cmd.Parameters.Add("@Physical", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Physical", SqlDbType.Int).Value = Convert.ToInt32(tbMus);

            if (tbArt.Equals(""))
                cmd.Parameters.Add("@Art", SqlDbType.Int).Value = 0;
            else
                cmd.Parameters.Add("@Art", SqlDbType.Int).Value = Convert.ToInt32(tbArt);


            // Open the connection. 
            conn.Open();


            // Execute the command. 
            cmd.ExecuteNonQuery();
        }


        // Exit edit mode. 
        gvPerson.EditIndex = -1;


        // Rebind the GridView control to show data after updating. 
        BindGridView();


    }


    // GridView.RowDeleting Event 
    protected void gvPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConStr"].ToString()))
        {
            // Create a command object. 
            SqlCommand cmd = new SqlCommand();


            // Assign the connection to the command. 
            cmd.Connection = conn;


            // Set the command text 
            // SQL statement or the name of the stored procedure  
            cmd.CommandText = "DELETE FROM Person WHERE PersonID = @PersonID";


            // Set the command type 
            // CommandType.Text for ordinary SQL statements;  
            // CommandType.StoredProcedure for stored procedures. 
            cmd.CommandType = CommandType.Text;


            // Get the PersonID of the selected row. 
            string strPersonID = gvPerson.Rows[e.RowIndex].Cells[1].Text;


            // Append the parameter. 
            cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = strPersonID;


            // Open the connection. 
            conn.Open();


            // Execute the command. 
            cmd.ExecuteNonQuery();
        }


        // Rebind the GridView control to show data after deleting. 
        BindGridView();
    }


    // GridView.Sorting Event 
    protected void gvPerson_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] strSortExpression = ViewState["SortExpression"].ToString().Split(' ');


        // If the sorting column is the same as the previous one,  
        // then change the sort order. 
        if (strSortExpression[0] == e.SortExpression)
        {
            if (strSortExpression[1] == "ASC")
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
            }
        }
        // If sorting column is another column,   
        // then specify the sort order to "Ascending". 
        else
        {
            ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
        }


        // Rebind the GridView control to show sorted data. 
        BindGridView();
    } 

    private string getSchoolNo(string schoolName)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select UserID from Account where school = N'" + schoolName + "'";
        ms.GetOneData(query, sb);

        if (sb.ToString().Equals(""))
            return "Unknown type";
        return sb.ToString();
    }

    private void setGradeLevel()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select GradeLevel from QGrade order by GradeLevel asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlGradeLevel.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlGradeLevel.Items.Add("None");
            return;
        }
        DdlGradeLevel.Items.Add("年级");
        foreach (string[] gradelevel in data)
        {
            DdlGradeLevel.Items.Add(gradelevel[0]);
        }
    }

    


    private void SearchType()
    {
        string yearSemester = LbYear.Text.Trim()+LbSemester.Text.Trim();

        Query = "select QStudent" + yearSemester + ".GradeLevel, QStudent" + yearSemester + ".Class, QStudent" + yearSemester + ".StudentID, QStudent" + yearSemester + ".Name, QScore" + yearSemester + ".Chinese, QScore" + yearSemester + ".English, QScore" + yearSemester + ".Math, QScore" + yearSemester + ".Society, QScore" + yearSemester + ".Science, QScore" + yearSemester + ".Music, QScore" + yearSemester + ".Physical, QScore" + yearSemester + ".Art " +
                "from QStudent" + yearSemester + " " +
                "left join QScore" + yearSemester + " on QScore" + yearSemester + ".StudentID = QStudent" + yearSemester + ".StudentID ";

        string tmp = string.Empty;
        string[] storeParam = new string[4];
        string[] sqlParam = new string[] { "QStudent" + yearSemester + ".GradeLevel", "QStudent" + yearSemester + ".Class", "QStudent" + yearSemester + ".Name", "QStudent" + yearSemester + ".School" };
        storeParam[0] = DdlGradeLevel.SelectedIndex == 0 ? null : DdlGradeLevel.SelectedValue;
        storeParam[1] = DdlClass.SelectedIndex == 0 ? null : DdlClass.SelectedValue;
        storeParam[2] = DdlStudentName.SelectedIndex == 0 ? null : DdlStudentName.SelectedValue;
        storeParam[3] = LbSchool.Text.Trim();


        for (int i = 0; i < storeParam.Length; i++)
        {
            if (!string.IsNullOrEmpty(storeParam[i]))
            {
                if (string.IsNullOrEmpty(tmp))
                {
                    tmp += "where " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }
                else
                {
                    tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
                }

            }
        }
        Query += tmp;


        Query += "order by QStudent" + yearSemester + ".StudentID asc";
        Session["QViewScore"] = Query;

        //Query = "select QStudent" + yearSemester + ".Name, QStudent" + yearSemester + ".IdentifyID, QStudent" + yearSemester + ".GradeLevel, QStudent" + yearSemester + ".Class, QStudent" + yearSemester + ".StudentID " +
        //        "from QStudent" + yearSemester +" " +
        //        "left join QScore"+yearSemester+" on QScore"+yearSemester+".StudentID =QStudent"+yearSemester+".StudentID ";


        //string tmp = string.Empty;
        //string[] storeParam = new string[3];
        //string[] sqlParam = new string[] { "QStudent" + yearSemester + ".GradeLevel", "QStudent" + yearSemester + ".Class", "QStudent" + yearSemester + ".StudentNo" };
        //storeParam[0] = DdlGradeLevel.SelectedIndex == 0 ? null : DdlGradeLevel.SelectedValue;
        //storeParam[1] = DdlClass.SelectedIndex == 0 ? null : DdlClass.SelectedValue;
        //storeParam[2] = DdlStudentName.SelectedIndex == 0 ? null : DdlStudentName.SelectedValue;


        //for (int i = 0; i < storeParam.Length; i++)
        //{
        //    if (!string.IsNullOrEmpty(storeParam[i]))
        //    {
        //        if (string.IsNullOrEmpty(tmp))
        //        {
        //            tmp += "where " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
        //        }
        //        else
        //        {
        //            tmp += "and " + sqlParam[i] + "=N'" + storeParam[i] + "' ";
        //        }

        //    }
        //}

        //Query += "order by  QStudent" + yearSemester + ".StudentID asc";
        //Session["ViewScore"] = Query;
    }

    private string GetEncryptionString(string Tag, string Data)
    {
        //BaseClass bc = new BaseClass();
        //return (Tag + "=" +bc.encryption(Data));
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }

   

    protected void ImgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Default.aspx");
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        SearchType();
        BindGridView();
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }

    protected void DdlGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVS_DdlGradeLevel_SelectedIndexChanged"] = DdlGradeLevel.SelectedValue;
        if (DdlGradeLevel.SelectedIndex == 0)
            return;

        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        string query = "select SN from QList where Year = '" + LbYear.Text + "' and Semester = '" + LbSemester.Text + "'";
        ms.GetOneData(query, sb);

        string listSN = sb.ToString();

        query = "select count(GradeLevel) from QGradeClassHistory where ListSN = '" + listSN + "' and GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and school =N'" + LbSchool.Text + "'";
        ms.GetOneData(query, sb);

        if (sb.ToString().Equals("0"))
        {
            DdlGradeLevel.SelectedIndex = 0;

            DdlClass.Items.Clear();
            DdlClass.Items.Add(new ListItem("班级", "0"));
            
            DdlStudentName.Items.Clear();
            DdlStudentName.Items.Add(new ListItem("学生姓名", "0"));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('目前该年级尚未键入任何学生之资料');", true);
            return;
        }

        setClass(listSN);
    }

    private void setClass(string listSN)
    {
        DdlClass.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select class from QGradeClassHistory "+
            "where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and ListSN = '" + listSN + "' and GradeLevel = '" + Session["QVS_DdlGradeLevel_SelectedIndexChanged"].ToString() + "'";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlClass.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlClass.Items.Add("None");
            return;
        }
        DdlClass.Items.Add("班級");
        foreach (string[] Class in data)
        {
            DdlClass.Items.Add(Class[0]);
        }
    }

    protected void DdlStudentName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    private void setStudentName()
    {
        DdlStudentName.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select Name from QStudent"+LbYear.Text.Trim()+LbSemester.Text.Trim()+" where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and Class = '" + DdlClass.SelectedValue + "'";


        if (!ms.GetAllColumnData(Query, data))
        {
            DdlStudentName.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlStudentName.Items.Add("None");
            return;
        }
        DdlStudentName.Items.Add("学生姓名");
        foreach (string[] studetnName in data)
        {
            DdlStudentName.Items.Add(studetnName[0]);
        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVS_DdlClass_SelectedIndexChanged"] = DdlClass.SelectedValue;
        setStudentName();
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        SearchType();
        BindGridView();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("QInputScoreList.aspx");
    }
}