﻿using System;
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
        if (Request["NO"] == null || Request["DimensionsID"] == null)
            return;
        if (!parseData("NO") || !parseData("DimensionsID"))
            return;

        getTitle();

        if (!IsPostBack)
        {
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
                            TextBox box5 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[4].FindControl("column5");
                            TextBox box6 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[5].FindControl("column6");
                            TextBox box7 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[6].FindControl("column7");
                            TextBox box8 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[7].FindControl("column8");
                            DropDownList box9 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[8].FindControl("column9");
                            TextBox box10 = (TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[9].FindControl("column10");
                            DropDownList box11 = (DropDownList)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[10].FindControl("column11");

                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                            ((TextBox)GvSchool.Rows[Convert.ToInt32(yourAssignedValue)].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                            box1.Text = "";
                            box2.Text = "";
                            box3.Text = "";
                            box4.Text = "";
                            box5.Text = "";
                            box6.Text = "";
                            box7.Text = "";
                            box8.Text = "";
                            box9.SelectedIndex = 0;
                            box10.Text = "";
                            box11.SelectedIndex = 0;
                        }
                    }
                }
                else
                {
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
                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("column7");
                    TextBox box8 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("column8");
                    DropDownList box9 = (DropDownList)GvSchool.Rows[rowIndex].Cells[8].FindControl("column9");
                    TextBox box10 = (TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10");
                    DropDownList box11 = (DropDownList)GvSchool.Rows[rowIndex].Cells[10].FindControl("column11");

                    ((TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                    box1.Text = dt.Rows[i]["column1"].ToString();
                    box2.Text = dt.Rows[i]["column2"].ToString();
                    box3.Text = dt.Rows[i]["column3"].ToString();
                    box4.Text = dt.Rows[i]["column4"].ToString();
                    box5.Text = dt.Rows[i]["column5"].ToString();
                    box6.Text = dt.Rows[i]["column6"].ToString();
                    box7.Text = dt.Rows[i]["column7"].ToString();
                    box8.Text = dt.Rows[i]["column8"].ToString();
                    box9.SelectedValue = dt.Rows[i]["column9"].ToString();
                    box10.Text = dt.Rows[i]["column10"].ToString();
                    box11.SelectedValue = dt.Rows[i]["column11"].ToString();

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

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Target, Activity, StartTime, EndTime, PersonInCharge, Budget, Resource, OtherResources, FinishRate, EstimateTime, EstimatePersonInCharge " +
                        "from PlanTargetActivity " +
                        "where SN ='" + Session["UserPlanListSN"].ToString() + "' and " +
                        "DimensionsID = '" + Request["DimensionsID"].ToString() + "' and " +
                        "PlanSummaryDimensionsNO = '" + Request["NO"].ToString() + "' ";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            for (int i = 0; i < data.Count; i++)
            {
                dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            ViewState["dt"] = dt;

            GvSchool.DataSource = dt;
            GvSchool.DataBind();

            for (int i = 0; i < data.Count; i++)
            {
                string[] d = (string[])data[i];
                ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text = d[0];
                ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text = d[1];
                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text = d[2];
                ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text = d[3];
                ((TextBox)GvSchool.Rows[i].Cells[4].FindControl("column5")).Text = d[4];
                ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text = d[5];
                ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text = d[6];
                ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text = d[7];
                ((DropDownList)GvSchool.Rows[i].Cells[8].FindControl("column9")).SelectedValue = d[8];
                ((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Text = d[9];
                ((DropDownList)GvSchool.Rows[i].Cells[10].FindControl("column11")).SelectedValue = d[10];

                ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                ((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");
            }
            return;
        }


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
        dt.Rows.Add(dr);
        

        ViewState["dt"] = dt;

        GvSchool.DataSource = dt;
        GvSchool.DataBind();

        ((TextBox)GvSchool.Rows[0].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
        ((TextBox)GvSchool.Rows[0].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
        ((TextBox)GvSchool.Rows[0].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");
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
                    TextBox box5 = (TextBox)GvSchool.Rows[rowIndex].Cells[4].FindControl("column5");
                    TextBox box6 = (TextBox)GvSchool.Rows[rowIndex].Cells[5].FindControl("column6");
                    TextBox box7 = (TextBox)GvSchool.Rows[rowIndex].Cells[6].FindControl("column7");
                    TextBox box8 = (TextBox)GvSchool.Rows[rowIndex].Cells[7].FindControl("column8");
                    DropDownList box9 = (DropDownList)GvSchool.Rows[rowIndex].Cells[8].FindControl("column9");
                    TextBox box10 = (TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10");
                    DropDownList box11 = (DropDownList)GvSchool.Rows[rowIndex].Cells[10].FindControl("column11");

                    ((TextBox)GvSchool.Rows[rowIndex].Cells[2].FindControl("column3")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[3].FindControl("column4")).Attributes.Add("readonly", "true");
                    ((TextBox)GvSchool.Rows[rowIndex].Cells[9].FindControl("column10")).Attributes.Add("readonly", "true");

                    drCurrentRow = dtCurrentTable.NewRow();


                    dtCurrentTable.Rows[i - 1]["column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["column3"] = box3.Text;
                    dtCurrentTable.Rows[i - 1]["column4"] = box4.Text;
                    dtCurrentTable.Rows[i - 1]["column5"] = box5.Text;
                    dtCurrentTable.Rows[i - 1]["column6"] = box6.Text;
                    dtCurrentTable.Rows[i - 1]["column7"] = box7.Text;
                    dtCurrentTable.Rows[i - 1]["column8"] = box8.Text;
                    dtCurrentTable.Rows[i - 1]["column9"] = box9.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["column10"] = box10.Text;
                    dtCurrentTable.Rows[i - 1]["column11"] = box11.SelectedValue;

                    rowIndex++;
                }
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
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (!isDigit())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('预算必须是数字');", true);
        }
        else
        {
            storeData();
        }
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
                    query = "insert into PlanTargetActivity (SN, DimensionsID, PlanSummaryDimensionsNO, Target, Activity, StartTime, EndTime, PersonInCharge, Budget, Resource, OtherResources, FinishRate, EstimateTime, EstimatePersonInCharge) VALUES ('" +
                                    Session["UserPlanListSN"].ToString() + "','" +
                                    Request["DimensionsID"].ToString() + "','" +
                                    Request["NO"].ToString() + "',N'" + 
                                    ((TextBox)GvSchool.Rows[i].Cells[0].FindControl("column1")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[1].FindControl("column2")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[2].FindControl("column3")).Text.Split(' ')[0] + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[3].FindControl("column4")).Text.Split(' ')[0] + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[4].FindControl("column5")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[5].FindControl("column6")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[6].FindControl("column7")).Text + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[7].FindControl("column8")).Text + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[8].FindControl("column9")).SelectedValue + "',N'" +
                                    ((TextBox)GvSchool.Rows[i].Cells[9].FindControl("column10")).Text.Split(' ')[0] + "',N'" +
                                    ((DropDownList)GvSchool.Rows[i].Cells[10].FindControl("column11")).SelectedValue + "')";

                    ms.WriteData(query, sb);
                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanList.aspx';", true);
            }
        }
    }
}