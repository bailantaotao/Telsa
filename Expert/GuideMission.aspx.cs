using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideMission : System.Web.UI.Page
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
    private const string SCHOOLNAME = "SCHOOLNAME";
    private const string MEMBERNAME = "MEMBERNAME";

    private StringBuilder schoolName = new StringBuilder();
    private StringBuilder MemberName = new StringBuilder();
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        SchoolName,
        MemberName,
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        setDefault(DdlType.SchoolName);
        setDefault(DdlType.MemberName);

        Label2.Visible = false;
        TbGuideMissionTime.Visible = false;
        if (!IsPostBack)
        {
            DlGuideMissionMember2.Visible = false;
            DlGuideMissionMember3.Visible = false;
            DlGuideMissionMember4.Visible = false;
            DlGuideMissionMember5.Visible = false;
            DlGuideMissionMember6.Visible = false;
            DlGuideMissionMember7.Visible = false;
            DlGuideMissionMember8.Visible = false;
            DlGuideMissionMember9.Visible = false;
            DlGuideMissionMember10.Visible = false;
            DlGuideMissionTargetSchool2.Visible = false;
            DlGuideMissionTargetSchool3.Visible = false;
            DlGuideMissionTargetSchool4.Visible = false;
            DlGuideMissionTargetSchool5.Visible = false;
            DlGuideMissionTargetSchool6.Visible = false;
            DlGuideMissionTargetSchool7.Visible = false;
            DlGuideMissionTargetSchool8.Visible = false;
            DlGuideMissionTargetSchool9.Visible = false;
            DlGuideMissionTargetSchool10.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Label1.Text = SearchProvince() + "省明德特色办学校长研修跟踪指导专家任务书";

    }
    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.SchoolName:
                setSchoolName();
                break;
            case DdlType.MemberName:
                setMemberName();
                break;

        }
    }
    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select School from Account " +
                            "left join Area on Account.zipcode = Area.ID " +
                            "where School not like N'%專家%' and School not like N'%管理%' and Area.ID =" + Session["Province"].ToString() +
                            "group by School ";


        if (!ms.GetAllColumnData(Query, data))
        {
            DlGuideMissionTargetSchool1.Items.Add("None");
            DlGuideMissionTargetSchool2.Items.Add("None");
            DlGuideMissionTargetSchool3.Items.Add("None");
            DlGuideMissionTargetSchool4.Items.Add("None");
            DlGuideMissionTargetSchool5.Items.Add("None");
            DlGuideMissionTargetSchool6.Items.Add("None");
            DlGuideMissionTargetSchool7.Items.Add("None");
            DlGuideMissionTargetSchool8.Items.Add("None");
            DlGuideMissionTargetSchool9.Items.Add("None");
            DlGuideMissionTargetSchool10.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlGuideMissionTargetSchool1.Items.Add("None");
            DlGuideMissionTargetSchool2.Items.Add("None");
            DlGuideMissionTargetSchool3.Items.Add("None");
            DlGuideMissionTargetSchool4.Items.Add("None");
            DlGuideMissionTargetSchool5.Items.Add("None");
            DlGuideMissionTargetSchool6.Items.Add("None");
            DlGuideMissionTargetSchool7.Items.Add("None");
            DlGuideMissionTargetSchool8.Items.Add("None");
            DlGuideMissionTargetSchool9.Items.Add("None");
            DlGuideMissionTargetSchool10.Items.Add("None");
            return;
        }
        //DlGuideMissionTargetSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        DlGuideMissionTargetSchool1.Items.Add(Resources.Resource.DdlTypeSchoolname);
        DlGuideMissionTargetSchool2.Items.Add("");
        DlGuideMissionTargetSchool3.Items.Add("");
        DlGuideMissionTargetSchool4.Items.Add("");
        DlGuideMissionTargetSchool5.Items.Add("");
        DlGuideMissionTargetSchool6.Items.Add("");
        DlGuideMissionTargetSchool7.Items.Add("");
        DlGuideMissionTargetSchool8.Items.Add("");
        DlGuideMissionTargetSchool9.Items.Add("");
        DlGuideMissionTargetSchool10.Items.Add("");
        foreach (string[] province in data)
        {
            //DlGuideMissionTargetSchool.Items.Add(province[0]);
            DlGuideMissionTargetSchool1.Items.Add(province[0]);
            DlGuideMissionTargetSchool2.Items.Add(province[0]);
            DlGuideMissionTargetSchool3.Items.Add(province[0]);
            DlGuideMissionTargetSchool4.Items.Add(province[0]);
            DlGuideMissionTargetSchool5.Items.Add(province[0]);
            DlGuideMissionTargetSchool6.Items.Add(province[0]);
            DlGuideMissionTargetSchool7.Items.Add(province[0]);
            DlGuideMissionTargetSchool8.Items.Add(province[0]);
            DlGuideMissionTargetSchool9.Items.Add(province[0]);
            DlGuideMissionTargetSchool10.Items.Add(province[0]);
        }
    }
    private void setMemberName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();

        Query = "select MemberName from GuideActivityMember " +
                "where SN = '" + Session["UserGuideListSN"].ToString() + "'";


        if (!ms.GetAllColumnData(Query, data))
        {
            DlGuideMissionMember1.Items.Add("None");
            DlGuideMissionMember2.Items.Add("None");
            DlGuideMissionMember3.Items.Add("None");
            DlGuideMissionMember4.Items.Add("None");
            DlGuideMissionMember5.Items.Add("None");
            DlGuideMissionMember6.Items.Add("None");
            DlGuideMissionMember7.Items.Add("None");
            DlGuideMissionMember8.Items.Add("None");
            DlGuideMissionMember9.Items.Add("None");
            DlGuideMissionMember10.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlGuideMissionMember1.Items.Add("None");
            DlGuideMissionMember2.Items.Add("None");
            DlGuideMissionMember3.Items.Add("None");
            DlGuideMissionMember4.Items.Add("None");
            DlGuideMissionMember5.Items.Add("None");
            DlGuideMissionMember6.Items.Add("None");
            DlGuideMissionMember7.Items.Add("None");
            DlGuideMissionMember8.Items.Add("None");
            DlGuideMissionMember9.Items.Add("None");
            DlGuideMissionMember10.Items.Add("None");
            return;
        }
        DlGuideMissionMember1.Items.Add(Resources.Resource.DdlTypeMembername);
        DlGuideMissionMember2.Items.Add("");
        DlGuideMissionMember3.Items.Add("");
        DlGuideMissionMember4.Items.Add("");
        DlGuideMissionMember5.Items.Add("");
        DlGuideMissionMember6.Items.Add("");
        DlGuideMissionMember7.Items.Add("");
        DlGuideMissionMember8.Items.Add("");
        DlGuideMissionMember9.Items.Add("");
        DlGuideMissionMember10.Items.Add("");
        foreach (string[] province in data)
        {
            //DlGuideMissionTargetSchool.Items.Add(province[0]);
            DlGuideMissionMember1.Items.Add(province[0]);
            DlGuideMissionMember2.Items.Add(province[0]);
            DlGuideMissionMember3.Items.Add(province[0]);
            DlGuideMissionMember4.Items.Add(province[0]);
            DlGuideMissionMember5.Items.Add(province[0]);
            DlGuideMissionMember6.Items.Add(province[0]);
            DlGuideMissionMember7.Items.Add(province[0]);
            DlGuideMissionMember8.Items.Add(province[0]);
            DlGuideMissionMember9.Items.Add(province[0]);
            DlGuideMissionMember10.Items.Add(province[0]);
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
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        storeData();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideMissionList.aspx");
    }
    private void storeData()
    {
         StringBuilder sb = new StringBuilder();
         ManageSQL ms = new ManageSQL();
            // 先刪除原本的
         string MemberQuery ;
         string SchoolQuery ;

         MemberQuery = DlGuideMissionMember1.SelectedValue.ToString() + " " + DlGuideMissionMember2.SelectedValue.ToString() + " " + DlGuideMissionMember3.SelectedValue.ToString() + " " +
                       DlGuideMissionMember4.SelectedValue.ToString() + " " + DlGuideMissionMember5.SelectedValue.ToString() + " " + DlGuideMissionMember6.SelectedValue.ToString() + " " +
                       DlGuideMissionMember7.SelectedValue.ToString() + " " + DlGuideMissionMember8.SelectedValue.ToString() + " " + DlGuideMissionMember9.SelectedValue.ToString() + " " +
                       DlGuideMissionMember10.SelectedValue.ToString() ;
         SchoolQuery = DlGuideMissionTargetSchool1.SelectedValue.ToString() + " " + DlGuideMissionTargetSchool2.SelectedValue.ToString() + " " + DlGuideMissionTargetSchool3.SelectedValue.ToString() + " " +
                       DlGuideMissionTargetSchool4.SelectedValue.ToString() + " " + DlGuideMissionTargetSchool5.SelectedValue.ToString() + " " + DlGuideMissionTargetSchool6.SelectedValue.ToString() + " " +
                       DlGuideMissionTargetSchool7.SelectedValue.ToString() + " " + DlGuideMissionTargetSchool8.SelectedValue.ToString() + " " + DlGuideMissionTargetSchool9.SelectedValue.ToString() + " " +
                       DlGuideMissionTargetSchool10.SelectedValue.ToString() ;
         
         string query = "delete from GuideMission where SN ='" + Session["UserGuideListSN"].ToString() + "'" + "and MissionNo=" + Request["MissionNo"].ToString() ;
             ms.WriteData(query, sb);
             sb.Clear();
             query = "insert into GuideMission (SN, MissionTime, MissionMember, MissionStartTime, MissionEndTime, MissionTargetSchool, MissionSchoolNum, MissionNo) VALUES ('" +
                                 Session["UserGuideListSN"].ToString() + "',N'" +
                                 TbGuideMissionTime.Text + "',N'" +
                                 MemberQuery + "',N'" +
                                 TbGuideMissionStartTime.Text + "',N'" +
                                 TbGuideMissionEndTime.Text + "',N'" +
                                 SchoolQuery + "',N'" +
                                 LbSchoolCount.Text.Trim() + "',N'" +
                                 Request["MissionNo"].ToString() + "')";
             ms.WriteData(query, sb);
             
             Response.Redirect("GuideMissionList.aspx");
    }

    protected void DlGuideMissionMember1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember2.Visible = true;
    }
    protected void DlGuideMissionMember2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember3.Visible = true;
    }
    protected void DlGuideMissionMember3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember4.Visible = true;
    }
    protected void DlGuideMissionMember4_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember5.Visible = true;
    }
    protected void DlGuideMissionMember5_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember6.Visible = true;
        LbSchoolCount.Text = "5";
    }
    protected void DlGuideMissionMember6_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember7.Visible = true;
    }
    protected void DlGuideMissionMember7_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember8.Visible = true;
    }
    protected void DlGuideMissionMember8_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember9.Visible = true;
    }
    protected void DlGuideMissionMember9_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionMember10.Visible = true;
    }
    protected void DlGuideMissionTargetSchool1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool2.Visible = true;
        if (DlGuideMissionTargetSchool1.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "1";
    }
    protected void DlGuideMissionTargetSchool2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool3.Visible = true;
        if (DlGuideMissionTargetSchool2.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "2";
    }
    protected void DlGuideMissionTargetSchool3_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool4.Visible = true;
        if (DlGuideMissionTargetSchool3.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "3";
    }
    protected void DlGuideMissionTargetSchool4_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool5.Visible = true;
        if (DlGuideMissionTargetSchool4.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "4";
    }
    protected void DlGuideMissionTargetSchool5_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool6.Visible = true;
        if (DlGuideMissionTargetSchool5.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "5";
    }
    protected void DlGuideMissionTargetSchool6_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool7.Visible = true;
        if (DlGuideMissionTargetSchool6.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "6";
    }
    protected void DlGuideMissionTargetSchool7_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool8.Visible = true;
        if (DlGuideMissionTargetSchool7.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "7";
    }
    protected void DlGuideMissionTargetSchool8_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool9.Visible = true;
        if (DlGuideMissionTargetSchool8.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "8";
    }
    protected void DlGuideMissionTargetSchool9_SelectedIndexChanged(object sender, EventArgs e)
    {
        DlGuideMissionTargetSchool10.Visible = true;
        if (DlGuideMissionTargetSchool9.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "9";
    }
    protected void DlGuideMissionTargetSchool10_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DlGuideMissionTargetSchool10.SelectedValue.Equals(""))
            return;
        LbSchoolCount.Text = "10";
    }
}