using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem4 : System.Web.UI.Page
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
        LbYear.Text = Session["PlanYear"].ToString();
        if (!IsPostBack)
        {
            setInitial();
        }
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
        }
    }
    private void setInitial()
    {
        LbTarget1.Text = "目标一" ;
        LbTarget2.Text = "目标二" ;
        LbTarget3.Text = "目标三" ;
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
                    TbQuestion8.Text = (d[2].Equals("") ? Resources.Resource.TipNotWrite : d[2]); ;
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

    private bool haveEmptyData()
    {
        return false;
        for (int i = 0; i < form1.Controls.Count; i++)
        {
            switch (this.form1.Controls[i].GetType().ToString())
            {
                case "System.Web.UI.WebControls.TextBox":
                    TextBox tb = (TextBox)this.form1.Controls[i];
                    if (string.IsNullOrEmpty(tb.Text.Trim()))
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
        }
        return false;
    }

    private void storeData()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();

        writeData(1, 1, TbQuestion1.Text.Trim());
        writeData(1, 2, TbQuestion2.Text.Trim());
        writeData(1, 3, TbQuestion3.Text.Trim());
        writeData(2, 1, TbQuestion4.Text.Trim());
        writeData(2, 2, TbQuestion5.Text.Trim());
        writeData(2, 3, TbQuestion6.Text.Trim());
        writeData(3, 1, TbQuestion7.Text.Trim());
        writeData(3, 2, TbQuestion8.Text.Trim());
        writeData(3, 3, TbQuestion9.Text.Trim());

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
    }

    private void writeData(int DimensionsID, int NO, string description)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = "insert into PlanSummaryDimensions (SN, DimensionsID, NO, Description) VALUES ('" +
                               Session["UserPlanListSN"].ToString() + "','" +
                               DimensionsID + "','" +
                               NO + "',N'" +
                               description + "')";
        ms.WriteData(query, sb);
    }
    protected void btnView1_Click(object sender, EventArgs e)
    {
        if (TbQuestion1.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='1' and NO='1'";
        ms.WriteData(query, sb);
        writeData(1, 1, TbQuestion1.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=1&NO=1");
    }
    protected void btnView2_Click(object sender, EventArgs e)
    {
        if (TbQuestion2.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='1' and NO='2'";
        ms.WriteData(query, sb);
        writeData(1, 2, TbQuestion2.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=1&NO=2");
    }
    protected void btnView3_Click(object sender, EventArgs e)
    {
        if (TbQuestion3.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='1' and NO='3'";
        ms.WriteData(query, sb);
        writeData(1, 3, TbQuestion3.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=1&NO=3");
    }
    protected void btnView4_Click(object sender, EventArgs e)
    {
        if (TbQuestion4.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='2' and NO='1'";
        ms.WriteData(query, sb);
        writeData(1, 1, TbQuestion4.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=2&NO=1");
    }
    protected void btnView5_Click(object sender, EventArgs e)
    {
        if (TbQuestion5.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='2' and NO='2'";
        ms.WriteData(query, sb);
        writeData(2, 2, TbQuestion5.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=2&NO=2");
    }
    protected void btnView6_Click(object sender, EventArgs e)
    {
        if (TbQuestion6.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='2' and NO='3'";
        ms.WriteData(query, sb);
        writeData(2, 3, TbQuestion6.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=2&NO=3");
    }
    protected void btnView7_Click(object sender, EventArgs e)
    {
        if (TbQuestion7.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='3' and NO='1'";
        ms.WriteData(query, sb);
        writeData(3, 1, TbQuestion7.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=3&NO=1");
    }
    protected void btnView8_Click(object sender, EventArgs e)
    {
        if (TbQuestion8.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='3' and NO='2'";
        ms.WriteData(query, sb);
        writeData(3, 2, TbQuestion8.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=3&NO=2");
    }
    protected void btnView9_Click(object sender, EventArgs e)
    {
        if (TbQuestion9.Text.Trim().Equals(""))
        {
            return;
        }
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanSummaryDimensions where SN ='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='3' and NO='3'";
        ms.WriteData(query, sb);
        writeData(3, 3, TbQuestion9.Text.Trim());
        Response.Redirect("PlanItem4Sub.aspx?DimensionsID=3&NO=3");
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}