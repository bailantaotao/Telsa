using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem2 : System.Web.UI.Page
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
        //LbNO.Text = Session["Semester"].ToString();
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
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select Idea, Motto, Spirit, Profile, Characteristic, Change from PlanCharacteristic where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            TbIdea.Text = d[0];
            TbMotto.Text = d[1];
            TbSpirit.Text = d[2];
            TbOverview.Text = d[3];
            TbCharacteristic.Text = d[4];
            TbChange.Text = d[5];
        }
    }

    private bool haveEmptyData()
    {
        return false;
        if (TbIdea.Text.Trim().Equals(""))
            return true;
        if (TbMotto.Text.Trim().Equals(""))
            return true;
        if (TbSpirit.Text.Trim().Equals(""))
            return true;
        if (TbOverview.Text.Trim().Equals(""))
            return true;
        if (TbCharacteristic.Text.Trim().Equals(""))
            return true;
        if (TbChange.Text.Trim().Equals(""))
            return true;
        return false;
    }

    private void storeData()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from PlanCharacteristic where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into PlanCharacteristic (SN, Idea, Motto, Spirit, Profile, Characteristic, Change) VALUES ('" +
                        Session["UserPlanListSN"].ToString() + "',N'" +
                        TbIdea.Text.Trim() + "',N'" +
                        TbMotto.Text.Trim() + "',N'" +
                        TbSpirit.Text.Trim() + "',N'" +
                        TbOverview.Text.Trim() + "',N'" +
                        TbCharacteristic.Text.Trim() + "',N'" +
                        TbChange.Text.Trim() + "')";
        ms.WriteData(query, sb);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}