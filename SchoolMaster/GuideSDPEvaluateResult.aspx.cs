using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SchoolMaster_GuideSDPEvaluateResult : System.Web.UI.Page
{
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";

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
        getSchoolName(schoolName);
        LbGuideResultTargetSchool.Text = schoolName.ToString();
        //setInitial();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        storeData();
    }
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        Session["schoolName"] = sb.ToString();
        return true;
    }
    private void storeData()
    {
        int Score1 = Convert.ToInt32(DlShlScore1.SelectedValue);
        int Score2 = Convert.ToInt32(DlShlScore2.SelectedValue);
        int Score3 = Convert.ToInt32(DlShlScore3.SelectedValue);
        int Score4 = Convert.ToInt32(DlShlScore4.SelectedValue);
        int Score5 = Convert.ToInt32(DlShlScore5.SelectedValue);
        int Score6 = Convert.ToInt32(DlShlScore6.SelectedValue);
        int Score7 = Convert.ToInt32(DlShlScore7.SelectedValue);
        int Score8 = Convert.ToInt32(DlShlScore8.SelectedValue);
        int Score9 = Convert.ToInt32(DlShlScore9.SelectedValue);
        int Score10 = Convert.ToInt32(DlShlScore10.SelectedValue);
        int Score11 = Convert.ToInt32(DlShlScore11.SelectedValue);
        int Score12 = Convert.ToInt32(DlShlScore12.SelectedValue);

        int SchoolMasterTotalScore = Score1 + Score2 + Score3 + Score4 + Score5 + Score6 + Score7 + Score8 + Score9 + Score10 + Score11 + Score12;
        string SchoolMasterScoreLevel;

        if (SchoolMasterTotalScore > 84)
            SchoolMasterScoreLevel = "A";
        else if (SchoolMasterTotalScore > 60 && SchoolMasterTotalScore < 85)
            SchoolMasterScoreLevel = "B";
        else
            SchoolMasterScoreLevel = "C";

        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from GuideSchoolMasterScore where SN = N'" + schoolName.ToString() + "' and Year =" + DlYear.SelectedValue.ToString() ;
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into GuideSchoolMasterScore (SN, Year, Semester, TargetSchool, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel) VALUES (N'" + 
                            schoolName.ToString() + "',N'" +
                            DlYear.SelectedValue + "',N'" +
                            DlSemester.SelectedValue + "',N'" +
                            schoolName.ToString() + "',N'" +
                            DlShlScore1.SelectedValue + "',N'" +
                            DlShlScore2.SelectedValue + "',N'" +
                            DlShlScore3.SelectedValue + "',N'" +
                            DlShlScore4.SelectedValue + "',N'" +
                            DlShlScore5.SelectedValue + "',N'" +
                            DlShlScore6.SelectedValue + "',N'" +
                            DlShlScore7.SelectedValue + "',N'" +
                            DlShlScore8.SelectedValue + "',N'" +
                            DlShlScore9.SelectedValue + "',N'" +
                            DlShlScore10.SelectedValue + "',N'" +
                            DlShlScore11.SelectedValue + "',N'" +
                            DlShlScore12.SelectedValue + "',N'" +
                            SchoolMasterTotalScore + "',N'" +
                            SchoolMasterScoreLevel + "')";
        ms.WriteData(query, sb);
    }

    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
       
        string query = "select SN, TargetSchool, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
               "from GuideExpertScore " +
               "where TargetSchool in (N'" + schoolName.ToString() + "')";
        ms.GetAllColumnData(query, data);
        
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            LbProvinceScore1.Text = d[2];
            LbProvinceScore2.Text = d[3];
            LbProvinceScore3.Text = d[4];
            LbProvinceScore4.Text = d[5];
            LbProvinceScore5.Text = d[6];
            LbProvinceScore6.Text = d[7];
            LbProvinceScore7.Text = d[8];
            LbProvinceScore8.Text = d[9];
            LbProvinceScore9.Text = d[10];
            LbProvinceScore10.Text = d[11];
            LbProvinceScore11.Text = d[12];
            LbProvinceScore12.Text = d[13];
            LbProvinceScoreLevel.Text = d[14];
            LbScoreLevelExpert.Text = d[15];
        }
    }
<<<<<<< HEAD
    
=======

    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
>>>>>>> develop
}