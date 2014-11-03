using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_SDPEvaluateResult : System.Web.UI.Page
{
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string SCHOOLNAME = "SCHOOLNAME";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        SchoolName,
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        setDefault(DdlType.SchoolName);

        DlYear.Visible = false;
        DlSemester.Visible = false;

        LbExpScore1.Visible = false;
        LbExpScore2.Visible = false;
        LbExpScore3.Visible = false;
        LbExpScore4.Visible = false;
        LbExpScore5.Visible = false;
        LbExpScore6.Visible = false;
        LbExpScore7.Visible = false;
        LbExpScore8.Visible = false;
        LbExpScore9.Visible = false;
        LbExpScore10.Visible = false;
        LbExpScore11.Visible = false;
        LbExpScore12.Visible = false;
        BtnConfirm.Visible = false;
        BtnCancelConfirm.Visible = false;
        LbTargetSchool.Visible = false;

        LbGuideYear.Text = Session["GuideYear"].ToString();
        LbGuideSemester.Text = Session["GuideSemester"].ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.SchoolName:
                setSchoolName();
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
            DlTargetSchool.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlTargetSchool.Items.Add("None");
            return;
        }
        DlTargetSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DlTargetSchool.Items.Add(province[0]);
        }
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        LbExpScore1.Visible = true;
        LbExpScore2.Visible = true;
        LbExpScore3.Visible = true;
        LbExpScore4.Visible = true;
        LbExpScore5.Visible = true;
        LbExpScore6.Visible = true;
        LbExpScore7.Visible = true;
        LbExpScore8.Visible = true;
        LbExpScore9.Visible = true;
        LbExpScore10.Visible = true;
        LbExpScore11.Visible = true;
        LbExpScore12.Visible = true;
        BtnConfirm.Visible = true;
        BtnCancelConfirm.Visible = true;

        DlProvinceScore1.Visible = false;
        DlProvinceScore2.Visible = false;
        DlProvinceScore3.Visible = false;
        DlProvinceScore4.Visible = false;
        DlProvinceScore5.Visible = false;
        DlProvinceScore6.Visible = false;
        DlProvinceScore7.Visible = false;
        DlProvinceScore8.Visible = false;
        DlProvinceScore9.Visible = false;
        DlProvinceScore10.Visible = false;
        DlProvinceScore11.Visible = false;
        DlProvinceScore12.Visible = false;
        BtnSave.Visible = false;
        BtnCancel.Visible = false;

        int Score1 = Convert.ToInt32(DlProvinceScore1.SelectedValue);
        int Score2 = Convert.ToInt32(DlProvinceScore2.SelectedValue);
        int Score3 = Convert.ToInt32(DlProvinceScore3.SelectedValue);
        int Score4 = Convert.ToInt32(DlProvinceScore4.SelectedValue);
        int Score5 = Convert.ToInt32(DlProvinceScore5.SelectedValue);
        int Score6 = Convert.ToInt32(DlProvinceScore6.SelectedValue);
        int Score7 = Convert.ToInt32(DlProvinceScore7.SelectedValue);
        int Score8 = Convert.ToInt32(DlProvinceScore8.SelectedValue);
        int Score9 = Convert.ToInt32(DlProvinceScore9.SelectedValue);
        int Score10 = Convert.ToInt32(DlProvinceScore10.SelectedValue);
        int Score11 = Convert.ToInt32(DlProvinceScore11.SelectedValue);
        int Score12 = Convert.ToInt32(DlProvinceScore12.SelectedValue);

        LbExpScore1.Text = Score1.ToString();
        LbExpScore2.Text = Score2.ToString();
        LbExpScore3.Text = Score3.ToString();
        LbExpScore4.Text = Score4.ToString();
        LbExpScore5.Text = Score5.ToString();
        LbExpScore6.Text = Score6.ToString();
        LbExpScore7.Text = Score7.ToString();
        LbExpScore8.Text = Score8.ToString();
        LbExpScore9.Text = Score9.ToString();
        LbExpScore10.Text = Score10.ToString();
        LbExpScore11.Text = Score11.ToString();
        LbExpScore12.Text = Score12.ToString();

        int ExpertTotalScore = Score1 + Score2 + Score3 + Score4 + Score5 + Score6 + Score7 + Score8 + Score9 + Score10 + Score11 + Score12;
        string ExpertScoreLevel;

        if (ExpertTotalScore > 84)
            ExpertScoreLevel = "A";
        else if (ExpertTotalScore > 60 && ExpertTotalScore < 85)
            ExpertScoreLevel = "B";
        else
            ExpertScoreLevel = "C";

        LbProvinceScoreLevel.Text = ExpertTotalScore.ToString();
        LbScoreLevelExpert.Text = ExpertScoreLevel;

        LbTargetSchool.Visible = true;
        LbTargetSchool.Text = DlTargetSchool.SelectedValue.ToString();
        DlTargetSchool.Visible = false;
    }

    private void storeData()
    {
        int Score1 = Convert.ToInt32(DlProvinceScore1.SelectedValue);
        int Score2 = Convert.ToInt32(DlProvinceScore2.SelectedValue);
        int Score3 = Convert.ToInt32(DlProvinceScore3.SelectedValue);
        int Score4 = Convert.ToInt32(DlProvinceScore4.SelectedValue);
        int Score5 = Convert.ToInt32(DlProvinceScore5.SelectedValue);
        int Score6 = Convert.ToInt32(DlProvinceScore6.SelectedValue);
        int Score7 = Convert.ToInt32(DlProvinceScore7.SelectedValue);
        int Score8 = Convert.ToInt32(DlProvinceScore8.SelectedValue);
        int Score9 = Convert.ToInt32(DlProvinceScore9.SelectedValue);
        int Score10 = Convert.ToInt32(DlProvinceScore10.SelectedValue);
        int Score11 = Convert.ToInt32(DlProvinceScore11.SelectedValue);
        int Score12 = Convert.ToInt32(DlProvinceScore12.SelectedValue);

        int ExpertTotalScore = Score1 + Score2 + Score3 + Score4 + Score5 + Score6 + Score7 + Score8 + Score9 + Score10 + Score11 + Score12;
        string ExpertScoreLevel;

        if (ExpertTotalScore > 84)
            ExpertScoreLevel = "A";
        else if (ExpertTotalScore > 60 && ExpertTotalScore < 85)
            ExpertScoreLevel = "B";
        else
            ExpertScoreLevel = "C";
        
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from GuideExpertScore where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into GuideExpertScore (SN, Year, Semester, TargetSchool, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel) VALUES ('" +
                            Session["UserGuideListSN"].ToString() + "',N'" +
                            LbGuideYear.Text.Trim() + "',N'" +
                            LbGuideSemester.Text.Trim() + "',N'" +
                            DlTargetSchool.SelectedValue + "',N'" +
                            DlProvinceScore1.SelectedValue + "',N'" +
                            DlProvinceScore2.SelectedValue + "',N'" +
                            DlProvinceScore3.SelectedValue + "',N'" +
                            DlProvinceScore4.SelectedValue + "',N'" +
                            DlProvinceScore5.SelectedValue + "',N'" +
                            DlProvinceScore6.SelectedValue + "',N'" +
                            DlProvinceScore7.SelectedValue + "',N'" +
                            DlProvinceScore8.SelectedValue + "',N'" +
                            DlProvinceScore9.SelectedValue + "',N'" +
                            DlProvinceScore10.SelectedValue + "',N'" +
                            DlProvinceScore11.SelectedValue + "',N'" +
                            DlProvinceScore12.SelectedValue + "',N'" +
                            ExpertTotalScore + "',N'" +
                            ExpertScoreLevel + "')";
        ms.WriteData(query, sb);

        Response.Redirect("GuideList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
    }
    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
        if (DlTargetSchool.SelectedValue.Equals(Resources.Resource.DdlTypeSchoolname))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + "目标学校不可为<学校名称>" + "');window.location='GuideSDPEvaluateResult.aspx';", true);
        }
        else
        {
            storeData();
        }
    }
    protected void BtnCancelConfirm_Click(object sender, EventArgs e)
    {
        DlProvinceScore1.Visible = true;
        DlProvinceScore2.Visible = true;
        DlProvinceScore3.Visible = true;
        DlProvinceScore4.Visible = true;
        DlProvinceScore5.Visible = true;
        DlProvinceScore6.Visible = true;
        DlProvinceScore7.Visible = true;
        DlProvinceScore8.Visible = true;
        DlProvinceScore9.Visible = true;
        DlProvinceScore10.Visible = true;
        DlProvinceScore11.Visible = true;
        DlProvinceScore12.Visible = true;
        BtnSave.Visible = true;
        BtnCancel.Visible = true;

        LbExpScore1.Visible = false;
        LbExpScore2.Visible = false;
        LbExpScore3.Visible = false;
        LbExpScore4.Visible = false;
        LbExpScore5.Visible = false;
        LbExpScore6.Visible = false;
        LbExpScore7.Visible = false;
        LbExpScore8.Visible = false;
        LbExpScore9.Visible = false;
        LbExpScore10.Visible = false;
        LbExpScore11.Visible = false;
        LbExpScore12.Visible = false;
        BtnConfirm.Visible = false;
        BtnCancelConfirm.Visible = false;

        LbProvinceScoreLevel.Text = null;
        LbScoreLevelExpert.Text = null;

        LbTargetSchool.Visible = false;
        DlTargetSchool.Visible = true;
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