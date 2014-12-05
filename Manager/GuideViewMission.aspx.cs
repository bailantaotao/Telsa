using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_GuideViewMission : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";
        Label2.Visible = false;
        LbGuideViewMissionTime.Visible = false;

        setInitial();
    }
    private string SearchProvince()
    {
        string query = "select GuideMissionList.County from GuideMissionList where SN='" + Session["UserGuideListSN"].ToString() + "'";
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ms.GetOneData(query, sb);
        return string.IsNullOrEmpty(sb.ToString()) ? "none" : sb.ToString();
    }
    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MissionTime, MissionMember, MissionStartTime, MissionEndTime, MissionTargetSchool, MissionSchoolNum " +
               "from GuideMission " +
               "where SN ='" + Session["UserGuideListSN"].ToString() + "'" +
               "and MissionNo=" + Request["MissionNo"].ToString();
        //"where SN ='" + Session["UserGuideListSN"].ToString() + "' and " +
        //"ActivityNO = '" + GuideActivityNO.ToString() + "'";

        ms.GetAllColumnData(query, data);
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            LbGuideViewMissionTime.Text = d[0];
            LbGuideViewMissionMember.Text = d[1];
            LbGuideViewMissionStartTime.Text = d[2].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[2].Split(' ')[0];
            LbGuideViewMissionEndTime.Text = d[3].Contains(BaseClass.standardTimestamp) ? Resources.Resource.TipNotWrite : d[3].Split(' ')[0];
            LbGuideViewMissionTargetSchool.Text = d[4];
            LbGuideViewMissionSchoolNum.Text = d[5];
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideViewMissionList.aspx");
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}