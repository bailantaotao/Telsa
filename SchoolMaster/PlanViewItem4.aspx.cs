using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem4 : System.Web.UI.Page
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
        setInitial();
        if (!IsPostBack)
        {
            
        }
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString());
    }

    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select DimensionsID, NO, Description from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' order by DimensionsID asc, NO asc";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            if (d[0].Equals("1"))
            {
                if (d[1].Equals("1"))
                {
                    LbQuestion1.Text = d[2];
                }
                else if (d[1].Equals("2"))
                {
                    LbQuestion2.Text = d[2];
                }
                else if (d[1].Equals("3"))
                {
                    LbQuestion3.Text = d[2];
                }
            }
            else if (d[0].Equals("2"))
            {
                if (d[1].Equals("1"))
                {
                    LbQuestion4.Text = d[2];
                }
                else if (d[1].Equals("2"))
                {
                    LbQuestion5.Text = d[2];
                }
                else if (d[1].Equals("3"))
                {
                    LbQuestion6.Text = d[2];
                }

            }
            else if (d[0].Equals("3"))
            {
                if (d[1].Equals("1"))
                {
                    LbQuestion7.Text = d[2];
                }
                else if (d[1].Equals("2"))
                {
                    LbQuestion8.Text = d[2];
                }
                else if (d[1].Equals("3"))
                {
                    LbQuestion9.Text = d[2];
                }

            }          
        }

    }

    protected void btnView1_Click(object sender, EventArgs e)
    {
        

        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=1&NO=1");
    }
    protected void btnView2_Click(object sender, EventArgs e)
    {

        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=1&NO=2");
    }
    protected void btnView3_Click(object sender, EventArgs e)
    {


        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=1&NO=3");
    }
    protected void btnView4_Click(object sender, EventArgs e)
    {


        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=2&NO=1");
    }
    protected void btnView5_Click(object sender, EventArgs e)
    {

        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=2&NO=2");
    }
    protected void btnView6_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=2&NO=3");
    }
    protected void btnView7_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=3&NO=1");
    }
    protected void btnView8_Click(object sender, EventArgs e)
    {

        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=3&NO=2");
    }
    protected void btnView9_Click(object sender, EventArgs e)
    {

        Response.Redirect("PlanViewItem4Sub.aspx?DimensionsID=3&NO=3");
    }
}