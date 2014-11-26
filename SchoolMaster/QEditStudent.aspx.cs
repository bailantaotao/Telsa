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

public partial class SchoolMaster_QEditStudent : System.Web.UI.Page
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
        getSchoolName(schoolName);
        getCurrentListID();
        setYear();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserID"] = "admin";
        //Session["ListSN"] = "1";
        //Session["SchoolID"] = "巴彦淖尔市磴口县渡口镇明德小学";
        //Session["Year"] = "2014";
        //Session["Semester"] = "1";

        //LbYear.Text = Request[YEAR].ToString().Trim();
        //LbSchoolNo.Text = getSchoolNo(Request[SCHOOLNAME].ToString()).Trim();
        //LbSemester.Text = Request[SEMESTER].ToString().Trim();
        //LbSchool.Text = Request[SCHOOLNAME].ToString().Trim();        

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
            gvEditStudent.AllowSorting = true;

            // Initialize the sorting expression. 
            ViewState["SortExpression"] = "StudentID ASC";
            ViewState["Stage2SortExpression"] = "StudentID ASC";

            // Populate the GridView. 
            if (DdlYear.SelectedIndex != 0 && DdlSemester.SelectedIndex != 0)
                BindGridView();

            
        }

        removeSession("QViewScoreList");
        removeSession("QVSL_PageSelect_SelectedIndexChanged");
        removeSession("QViewScore");
        removeSession("QVS_PageSelect_SelectedIndexChanged");
        removeSession("QVS_DdlGradeLevel_SelectedIndexChanged");
        removeSession("QVS_DdlClass_SelectedIndexChanged");

        removeSession("ViewStudentList");
        removeSession("QVSL_PageSelect_SelectedIndexChanged");
        removeSession("QVST_DdlGradeLevel_SelectedIndexChanged");
        removeSession("QVST_DdlClass_SelectedIndexChanged");

        removeSession("QInputScoreList");
    }

    private void removeSession(string key)
    {
        if (Session[key] != null)
            Session.Remove(key);
    }

    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }

    #region get year, semester
    private string currentYear = string.Empty;
    private string currentSemester = string.Empty;
    private string currentSN = string.Empty;
    private void getCurrentListID()
    {
        string time = DateTime.Now.ToString("yyyy-MM-dd");
        string query = "select SN, year, semester from Qlist " +
                    "where deadline >= Convert(datetime, '" + time + "' ) and startline <= Convert(datetime, '" + time + "' )";
        ArrayList data = new ArrayList();
        ManageSQL ms = new ManageSQL();
        ms.GetAllColumnData(query, data);

        if (data.Count > 0)
        {
            currentYear = ((string[])data[0])[1];
            currentSemester = ((string[])data[0])[2];
            currentSN = ((string[])data[0])[0];
        }
    }
    #endregion get year, semester

    #region input data
    protected void btnStage1Input_Click(object sender, EventArgs e)
    {
        if (tbStage1Name.Text.Trim().Equals("") || tbStage1ID.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('学生姓名和学籍辅号不得为空');", true);
            return;
        }

        if (currentYear.Equals("") || currentSemester.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipQuestionnaireNotCompelet + "');", true);
            return;
        }


        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "insert into QStudent" + currentYear + currentSemester + " (IdentifyID, School, Zipcode, Name) VALUES (" +
            "'" + tbStage1ID.Text.Trim() + "', " +
            "N'" + schoolName.ToString() + "', " +
            "'" + Session["Province"].ToString() + "', " +
            "'" + tbStage1Name.Text.Trim() + "')";
        ms.WriteData(query, sb);
        tbStage1ID.Text = "";
        tbStage1Name.Text = "";


    }
    #endregion input data

    #region student edit
    protected void BtnStage2Edit_Click(object sender, EventArgs e)
    {
        if (tbStage2Name.Text.Trim().Equals("") && tbStage2ID.Text.Trim().Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('学生姓名或学籍辅号不得为空');", true);
            return;
        }

        if (currentYear.Equals("") || currentSemester.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipQuestionnaireNotCompelet + "');", true);
            return;
        }

        removeSession("QStage2EditStudent");
        BindEditGridView();
    }

    private void BindEditGridView()
    {
        // Get the connection string from Web.config.  
        // When we use Using statement,  
        // we don't need to explicitly dispose the object in the code,  
        // the using statement takes care of it. 
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConStr"].ToString()))
        {
            if (Session["QStage2EditStudent"] != null)
                Query = Session["QStage2EditStudent"].ToString();
            else
            {
                Query = "select Name, IdentifyID, GradeLevel, Class, StudentID from QStudent" + currentYear + currentSemester + " " +
                        "where IdentifyID = '" + tbStage2ID.Text.Trim() + "' or Name = '" + tbStage2Name.Text.Trim() + "'";
                Session["QStage2EditStudent"] = Query;
            }

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
            da.Fill(dsPerson, "Edit");


            // Get the DataView from Person DataTable. 
            DataView dvPerson = dsPerson.Tables["Edit"].DefaultView;


            // Set the sort column and sort order. 
            dvPerson.Sort = ViewState["Stage2SortExpression"].ToString();


            // Bind the GridView control. 
            gvEditStudent.DataSource = dvPerson;
            gvEditStudent.DataBind();
        }
    }

    // GridView.RowDataBound Event 
    protected void gvEdit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Make sure the current GridViewRow is a data row. 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Make sure the current GridViewRow is either  
            // in the normal state or an alternate row. 
            if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate || e.Row.RowState == DataControlRowState.Edit)
            {
                // Add client-side confirmation when deleting. 
                e.Row.Cells[0].Text= currentYear;
                e.Row.Cells[1].Text = currentSemester;
            }
        }
    }


    // GridView.PageIndexChanging Event 
    protected void gvEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        // Set the index of the new display page.  
        gvEditStudent.PageIndex = e.NewPageIndex;
        

        // Rebind the GridView control to  
        // show data in the new page. 
        BindEditGridView();
    }


    // GridView.RowEditing Event 
    protected void gvEdit_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Make the GridView control into edit mode  
        // for the selected row.  
        gvEditStudent.EditIndex = e.NewEditIndex;


        // Rebind the GridView control to show data in edit mode. 
        BindEditGridView();


    }


    // GridView.RowCancelingEdit Event 
    protected void gvEdit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        // Exit edit mode. 
        gvEditStudent.EditIndex = -1;


        // Rebind the GridView control to show data in view mode. 
        BindEditGridView();


    }

    // GridView.RowUpdating Event 
    protected void gvEdit_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Get the PersonID of the selected row. 
        string studentName = gvEditStudent.Rows[e.RowIndex].Cells[2].Text;
        string identifyID = gvEditStudent.Rows[e.RowIndex].Cells[3].Text;
        string GradeLevel = ((TextBox)gvEditStudent.Rows[e.RowIndex].FindControl("tbGradeLevel")).Text;
        string Class = ((TextBox)gvEditStudent.Rows[e.RowIndex].FindControl("tbClass")).Text;
        string StudentID = ((TextBox)gvEditStudent.Rows[e.RowIndex].FindControl("tbStudentID")).Text;
        if (GradeLevel.Equals("") || digitCheck(GradeLevel) != 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入的年级格式有誤');", true);
            return;
        }
        if (Class.Equals("") || digitCheck(Class) != 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入的班级格式有誤');", true);
            return;
        }
        if (StudentID.Equals(""))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('您輸入的学号格式有誤');", true);
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
            cmd.CommandText = "UPDATE " + "QStudent" + currentYear + currentSemester + " SET " +
                                "GradeLevel = @GradeLevel, " +
                                "Class = @Class, " +
                                "StudentID = @StudentID " +
                                "WHERE IdentifyID = @IdentifyID and Name = @Name";



            // Set the command type 
            // CommandType.Text for ordinary SQL statements;  
            // CommandType.StoredProcedure for stored procedures. 
            cmd.CommandType = CommandType.Text;





            // Append the parameters. 
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = studentName;
            cmd.Parameters.Add("@IdentifyID", SqlDbType.NVarChar, 50).Value = identifyID;

            cmd.Parameters.Add("@GradeLevel", SqlDbType.Int).Value = Convert.ToInt32(GradeLevel);
            cmd.Parameters.Add("@Class", SqlDbType.Int).Value = Convert.ToInt32(Class);
            cmd.Parameters.Add("@StudentID", SqlDbType.NVarChar, 50).Value = Convert.ToInt32(StudentID);


            // Open the connection. 
            conn.Open();


            // Execute the command. 
            cmd.ExecuteNonQuery();
        }


        // Exit edit mode. 
        gvEditStudent.EditIndex = -1;


        // Rebind the GridView control to show data after updating. 
        BindEditGridView();


        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select count(listSN) from QGradeClassHistory left join QList on QGradeClassHistory.listSN = QList.SN where class = '" + Class + "' and GradeLevel = '" + GradeLevel + "' and QGradeClassHistory.listSN='" + currentSN + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("0"))
        {
            query = "select SN from QLIST where Year = '" + currentYear + "' and Semester = '" + currentSemester + "'";
            ms.GetOneData(query, sb);
            string ListSN = sb.ToString();

            query = "insert into QGradeClassHistory (GradeLevel, Class, ListSN) VALUES ('" + GradeLevel + "', '" + Class + "', '" + ListSN + "')";
            ms.WriteData(query, sb);
        }

        query = "select count(StudentID) from QScore" + currentYear + currentSemester + " where StudentID = '" + StudentID + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("0"))
        {
            query = "insert into QScore" + currentYear + currentSemester + " (StudentID) VALUES (" +
                           "'" + StudentID + "')";
            ms.WriteData(query, sb);
        }

        

        if (Session["QVSE_DdlGradeLevel_SelectedIndexChanged"] != null)
        {
            DdlGradeLevel.SelectedValue = Session["QVSE_DdlGradeLevel_SelectedIndexChanged"].ToString();
            if (DdlGradeLevel.SelectedIndex == 0)
                return;
            string listSN = string.Empty;
            if (!preCheckClassSuccess(ref listSN))
                return;

            setClass(listSN);

            Session["QVSE_DdlClass_SelectedIndexChanged"] = DdlClass.SelectedValue;
            setStudentID();
        }

    }



    // GridView.RowDeleting Event 
    protected void gvEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
        BindEditGridView();
    }


    // GridView.Sorting Event 
    protected void gvEdit_Sorting(object sender, GridViewSortEventArgs e)
    {
        string[] strSortExpression = ViewState["SortExpression"].ToString().Split(' ');


        // If the sorting column is the same as the previous one,  
        // then change the sort order. 
        if (strSortExpression[0] == e.SortExpression)
        {
            if (strSortExpression[1] == "ASC")
            {
                ViewState["Stage2SortExpression"] = e.SortExpression + " " + "DESC";
            }
            else
            {
                ViewState["Stage2SortExpression"] = e.SortExpression + " " + "ASC";
            }
        }
        // If sorting column is another column,   
        // then specify the sort order to "Ascending". 
        else
        {
            ViewState["Stage2SortExpression"] = e.SortExpression + " " + "ASC";
        }


        // Rebind the GridView control to show sorted data. 
        BindEditGridView();
    } 
#endregion 

    private void BindGridView()
    {       
        // Get the connection string from Web.config.  
        // When we use Using statement,  
        // we don't need to explicitly dispose the object in the code,  
        // the using statement takes care of it. 
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConStr"].ToString()))
        {
            if (Session["QEditStudent"] != null)
                Query = Session["QEditStudent"].ToString();
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
            da.Fill(dsPerson, "QStudent" + currentYear + currentSemester);


            // Get the DataView from Person DataTable. 
            DataView dvPerson = dsPerson.Tables["QStudent" + currentYear + currentSemester].DefaultView;


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
                ((LinkButton)e.Row.Cells[5].Controls[0]).Attributes["onclick"] = "if(!confirm('你确定真的要删除这笔资料吗??')) return false;";
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
            cmd.CommandText = "DELETE FROM QStudent" + currentYear + currentSemester + " WHERE identifyID = @identifyID and Name = @Name";


            // Set the command type 
            // CommandType.Text for ordinary SQL statements;  
            // CommandType.StoredProcedure for stored procedures. 
            cmd.CommandType = CommandType.Text;


            // Get the PersonID of the selected row. 
            string Name = gvPerson.Rows[e.RowIndex].Cells[0].Text;
            string identifyID = gvPerson.Rows[e.RowIndex].Cells[1].Text;


            // Append the parameter. 
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name;
            cmd.Parameters.Add("@identifyID", SqlDbType.NVarChar, 50).Value = identifyID;


            // Open the connection. 
            conn.Open();


            // Execute the command. 
            cmd.ExecuteNonQuery();
        }


        // Rebind the GridView control to show data after deleting. 
        BindGridView();

        if (Session["QVSE_DdlGradeLevel_SelectedIndexChanged"] != null)
        {
            DdlGradeLevel.SelectedValue = Session["QVSE_DdlGradeLevel_SelectedIndexChanged"].ToString();
            if (DdlGradeLevel.SelectedIndex == 0)
                return;
            string listSN = string.Empty;
            if (!preCheckClassSuccess(ref listSN))
                return;

            setClass(listSN);

            Session["QVSE_DdlClass_SelectedIndexChanged"] = DdlClass.SelectedValue;
            setStudentID();
        }
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
        string yearSemester = DdlYear.SelectedValue + DdlSemester.SelectedValue;

        Query = "select QStudent" + yearSemester + ".Name, QStudent" + yearSemester + ".IdentifyID, QStudent" + yearSemester + ".GradeLevel, QStudent" + yearSemester + ".Class, QStudent" + yearSemester + ".StudentID " +
                "from QStudent" + yearSemester + " ";                

        string tmp = string.Empty;
        string[] storeParam = new string[3];
        string[] sqlParam = new string[] { "QStudent" + yearSemester + ".GradeLevel", "QStudent" + yearSemester + ".Class", "QStudent" + yearSemester + ".StudentID"};
        storeParam[0] = DdlGradeLevel.SelectedIndex == 0 ? null : DdlGradeLevel.SelectedValue;
        storeParam[1] = DdlClass.SelectedIndex == 0 ? null : DdlClass.SelectedValue;
        storeParam[2] = DdlStudentID.SelectedIndex == 0 ? null : DdlStudentID.SelectedValue;


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
        Session["QEditStudent"] = Query;

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

    private void setYear()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select Year from QList group by Year order by Year desc ";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlYear.Items.Add(Resources.Resource.DdlTypeYear);
            DdlYear.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlYear.Items.Add(Resources.Resource.DdlTypeYear);
            DdlYear.Items.Add("None");
            return;
        }
        DdlYear.Items.Add(Resources.Resource.DdlTypeYear);
        foreach (string[] province in data)
        {
            DdlYear.Items.Add(province[0]);
        }
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
        Session["QVSE_DdlGradeLevel_SelectedIndexChanged"] = DdlGradeLevel.SelectedValue;
        if (DdlGradeLevel.SelectedIndex == 0)
            return;
        string listSN = string.Empty;
        if (!preCheckClassSuccess(ref listSN))
            return;
        
        setClass(listSN);
    }

    private bool preCheckClassSuccess(ref string listSN)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        string query = "select SN from QList where Year = '" + currentYear + "' and Semester = '" + currentSemester + "'";
        ms.GetOneData(query, sb);

        listSN = sb.ToString();

        query = "select count(GradeLevel) from QGradeClassHistory where ListSN = '" + listSN + "' and GradeLevel = '" + DdlGradeLevel.SelectedValue + "'";
        ms.GetOneData(query, sb);

        if (sb.ToString().Equals("0"))
        {
            DdlGradeLevel.SelectedIndex = 0;

            DdlClass.Items.Clear();
            DdlClass.Items.Add(new ListItem("班级", "0"));

            DdlStudentID.Items.Clear();
            DdlStudentID.Items.Add(new ListItem("学生姓名", "0"));

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('目前该年级尚未键入任何学生之资料');", true);
            return false;
        }
        return true;
    }

    private void setClass(string listSN)
    {
        DdlClass.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select class from QGradeClassHistory "+
            "where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and ListSN = '" + listSN + "' and GradeLevel = '" + Session["QVSE_DdlGradeLevel_SelectedIndexChanged"].ToString() + "'";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlClass.Items.Add("班級");
            DdlClass.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlClass.Items.Add("班級");
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



    private void setStudentID()
    {
        DdlStudentID.Items.Clear();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select StudentID from QStudent" + DdlYear.SelectedValue + DdlSemester.SelectedValue + " where GradeLevel = '" + DdlGradeLevel.SelectedValue + "' and Class = '" + DdlClass.SelectedValue + "'";


        if (!ms.GetAllColumnData(Query, data))
        {
            DdlStudentID.Items.Add("学籍辅号");
            DdlStudentID.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlStudentID.Items.Add("学籍辅号");
            DdlStudentID.Items.Add("None");
            return;
        }
        DdlStudentID.Items.Add("学籍辅号");
        foreach (string[] studetnName in data)
        {
            DdlStudentID.Items.Add(studetnName[0]);
        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["QVSE_DdlClass_SelectedIndexChanged"] = DdlClass.SelectedValue;
        setStudentID();
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (DdlYear.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('必须选择学年');", true);
            return;
        }
        if (DdlSemester.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('必须选择学期');", true);
            return;
        }
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select count(SN) from QList where Year ='" + DdlYear.SelectedValue + "' and Semester = '" + DdlSemester.SelectedValue + "'";
        ms.GetOneData(query, sb);
        if (sb.ToString().Equals("0"))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('该学期尚未有任何资料');", true);
            return;
        }
        
        SearchType();
        BindGridView();
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("QViewStudentList.aspx");
    }


}