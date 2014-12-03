using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideSummary : System.Web.UI.Page
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
        DropDownList1.Visible = false;
        DropDownList2.Visible = false;
        LbGuideYear.Text = Session["GuideYear"].ToString();
        LbGuideSemester.Text = Session["GuideSemester"].ToString();
        LbGuideSummaryUserName.Text += "用户名称：" + Session["UserName"].ToString();
        LbGuideSummaryUserID.Text += "&nbsp&nbsp&nbsp代号：" + Session["UserID"].ToString();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            
        }
        setInitial();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
        else if (DropDownList3.SelectedValue.ToString() == "请选择")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + "请选择项次" + "');", true);
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
        string query = "select MainContent, MainExperience, ExistingProblem, ImprovementSuggest, Result from GuideSummary where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
                       "and No='" + DropDownList3.SelectedValue.ToString() + "'"; 
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            TBGuideSummaryContent.Text=d[0];
            TBGuideSummaryExperience.Text=d[1];
            TBGuideSummaryExistingProblem.Text=d[2];
            TBGuideSummarySuggest.Text=d[3];
            TBGuideSummaryResult.Text=d[4];
        }
    }
    private bool haveEmptyData()
    {
        return false;
        if (TBGuideSummaryContent.Text.Trim().Equals(""))
            return true;
        if (TBGuideSummaryExperience.Text.Trim().Equals(""))
            return true;
        if (TBGuideSummaryExistingProblem.Text.Trim().Equals(""))
            return true;
        if (TBGuideSummarySuggest.Text.Trim().Equals(""))
            return true;
        if (TBGuideSummaryResult.Text.Trim().Equals(""))
            return true;
        return false;
    }
    private void storeData()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from GuideSummary where SN ='" + Session["UserGuideListSN"].ToString() + "'" + "and Year=" + LbGuideYear + "and Cycle=" + LbGuideSemester + "and No=" + DropDownList3.SelectedValue;
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into GuideSummary (SN, Year, Cycle, No, MainContent, MainExperience, ExistingProblem, ImprovementSuggest, Result) VALUES ('" +
                        Session["UserGuideListSN"].ToString() + "',N'" +
                        LbGuideYear.Text.Trim() + "',N'" +
                        LbGuideSemester.Text.Trim() + "',N'" +
                        DropDownList3.SelectedValue.ToString() + "',N'" +
                        TBGuideSummaryContent.Text.Trim() + "',N'" +
                        TBGuideSummaryExperience.Text.Trim() + "',N'" +
                        TBGuideSummaryExistingProblem.Text.Trim() + "',N'" +
                        TBGuideSummarySuggest.Text.Trim() + "',N'" +
                        TBGuideSummaryResult.Text.Trim()  + "')";
        ms.WriteData(query, sb);
        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("../ProvinceIndex.aspx");
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("../MingdeIndex.aspx");
        }
    }
}