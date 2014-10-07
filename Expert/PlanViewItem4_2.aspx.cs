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
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LbNO.Text = Session["Semester"].ToString();
        LbYear.Text = Session["PlanYear"].ToString();
        setInitial();
        if (!IsPostBack)
        {
            
        }
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString()+"&SCHOOLNAME="+Session["SCHOOLNAME"].ToString());
    }

    private void setInitial()
    {
        LbTarget1.Text = "目标一";
        LbTarget2.Text = "目标二";
        LbTarget3.Text = "目标三";
        LbTarget4.Text = "目标一";
        LbTarget5.Text = "目标二";
        LbTarget6.Text = "目标三";
        LbTarget7.Text = "目标一";
        LbTarget8.Text = "目标二";
        LbTarget9.Text = "目标三";

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select PlanSummaryDimensions.DimensionsID, PlanSummaryDimensions.NO, PlanSummaryDimensions.Description, PlanTargetActivity.Target from PlanSummaryDimensions " +
            "left join PlanTargetActivity on PlanTargetActivity.SN = PlanSummaryDimensions.SN and PlanTargetActivity.PlanSummaryDimensionsNO = PlanSummaryDimensions.NO " +
            "and PlanTargetActivity.DimensionsID = PlanSummaryDimensions.DimensionsID " +
            "where PlanSummaryDimensions.SN ='" + Session["UserPlanListSN"].ToString() + "' " +
            "group by PlanTargetActivity.target,PlanSummaryDimensions.DimensionsID,PlanSummaryDimensions.NO,PlanSummaryDimensions.Description " +
            "order by DimensionsID asc, NO asc";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            if (d[0].Equals("1"))
            {
                if (d[1].Equals("1"))
                {
                    TbQuestion1.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget1.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
                else if (d[1].Equals("2"))
                {
                    TbQuestion2.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget2.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
                else if (d[1].Equals("3"))
                {
                    TbQuestion3.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget3.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
            }
            else if (d[0].Equals("2"))
            {
                if (d[1].Equals("1"))
                {
                    TbQuestion4.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget4.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
                else if (d[1].Equals("2"))
                {
                    TbQuestion5.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget5.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
                else if (d[1].Equals("3"))
                {
                    TbQuestion6.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget6.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }

            }
            else if (d[0].Equals("3"))
            {
                if (d[1].Equals("1"))
                {
                    TbQuestion7.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget7.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
                else if (d[1].Equals("2"))
                {
                    TbQuestion8.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget8.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
                }
                else if (d[1].Equals("3"))
                {
                    TbQuestion9.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]);
                    LbTarget9.Text += "<br />" + (d[3].Equals("") ? Resources.Resource.TipNotWrite : d[3]);
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