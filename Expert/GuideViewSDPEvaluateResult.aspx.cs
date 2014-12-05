using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideViewSDPEvaluateResult : System.Web.UI.Page
{
    private string Query = string.Empty;
    private string QueryComplete = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string TargetSchool = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        SchoolName,
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
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");

        setDefault(DdlType.SchoolName);
        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            HyperLink1.Visible = false;
            img.Visible = false;
            LbGuideYear.Visible = false;
            LbGuideSemester.Visible = false;
        }
        else if (Session["IsMingDer"].ToString().Equals("False"))
        {
            DlGuideViewResultYear.Visible = false;
            DlGuideViewResultSemester.Visible = false;
            LbGuideYear.Text = Session["GuideYear"].ToString();
            LbGuideSemester.Text = Session["GuideSemester"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
           ManageSQL ms = new ManageSQL();
            ArrayList dataschoolname = new ArrayList();

            string queryschoolname = "select School from GuideExpertScore where SN ='" + Session["UserGuideListSN"].ToString() + "'" ;
            ms.GetAllColumnData(queryschoolname, dataschoolname);

        }
    }

    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList datacomplete = new ArrayList();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();
        StringBuilder zipcodesb = new StringBuilder();

        string namequery = string.Empty;
        string zipcodequery = string.Empty;
        string zipcodequerycomplete = string.Empty;


        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            namequery = "select GuideSchool from GuideListUser where SN='" + Session["UserGuideListSN"].ToString() + "'";
            ms.GetOneData(namequery, sb);

            zipcodequery = "select zipcode from Account where UserName=N'" + sb.ToString() + "'";
            ms.GetOneData(zipcodequery, zipcodesb);

            Query = "select School from Account " +
                                "left join Area on Account.zipcode = Area.ID " +
                                "where School not like N'%專家%' and School not like N'%专家%' and School not like N'%管理者%'" +  
                                "group by School ";
            QueryComplete = "select School from GuideExpertScore " +
                            "left join GuideSchoolMasterScore on GuideExpertScore.School = GuideSchoolMasterScore.TargetSchool "+
                            "where GuideExpertScore.SN = '" + Session["UserGuideListSN"].ToString() + "'";

        }
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Query = "select School from Account " +
                                "left join Area on Account.zipcode = Area.ID " +
                                "where School not like N'%專家%' and School not like N'%专家%' and School not like N'%管理者%' and Area.ID =" + Session["Province"].ToString() +
                                "group by School ";
            QueryComplete = "select School from GuideExpertScore " +
                            "left join GuideSchoolMasterScore on GuideExpertScore.School = GuideSchoolMasterScore.TargetSchool " +
                            "where GuideExpertScore.SN = '"+Session["UserGuideListSN"].ToString()+"'";

        }
        if (!ms.GetAllColumnData(Query, data))
        {
            DlGuideViewResultTargetSchool.Items.Add("None");
            return;
        }
        if (!ms.GetAllColumnData(QueryComplete, datacomplete))
        {
            DlGuideViewResultTargetSchoolComplete.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DlGuideViewResultTargetSchool.Items.Add("None");
            return;
        }
        if (datacomplete.Count == 0)
        {
            DlGuideViewResultTargetSchoolComplete.Items.Add("None");
            return;
        }
        DlGuideViewResultTargetSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DlGuideViewResultTargetSchool.Items.Add(province[0]);
        }
        DlGuideViewResultTargetSchoolComplete.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] provincecomplete in datacomplete)
        {
            DlGuideViewResultTargetSchoolComplete.Items.Add(provincecomplete[0]);
            DlGuideViewResultTargetSchool.Items.Remove(provincecomplete[0]);
        }
       

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("GuideViewList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString());
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("GuideViewList.aspx?SN=" + Session["GuideSN"].ToString() + "&YEAR=" + Session["GuideYear"].ToString() + "&SCHOOLNAME=" + Session["SCHOOLNAME"].ToString());
        }
    }
    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ArrayList data1 = new ArrayList();

        string query = "select Year, Semester, School, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
               "from GuideExpertScore " +
               "where SN ='" + Session["UserGuideListSN"].ToString()  +"'" +
               "and Year =" + LbGuideYear.Text.Trim() + 
               "and Semester =" + LbGuideSemester.Text.Trim() +
               "and School = N'" + DlGuideViewResultTargetSchool.SelectedValue.ToString() + "'" +
               "or School = N'" + DlGuideViewResultTargetSchoolComplete.SelectedValue.ToString() + "'";

        ms.GetAllColumnData(query, data);
        //string[] a = (string[])data[0];
        //string TargetSchool = a[2];
        if (data.Count == 0)
        {
            //string[] d = (string[])data[0];
            //LbGuideViewResultYear.Text = d[0];
            //LbGuideViewResultSemester.Text = d[1];
            //LbGuideViewResultTargetSchool.Text = d[2];
            LbProvinceScore1.Text = "";
            LbProvinceScore2.Text = "";
            LbProvinceScore3.Text = "";
            LbProvinceScore4.Text = "";
            LbProvinceScore5.Text = "";
            LbProvinceScore6.Text = "";
            LbProvinceScore7.Text = "";
            LbProvinceScore8.Text = "";
            LbProvinceScore9.Text = "";
            LbProvinceScore10.Text = "";
            LbProvinceScore11.Text = "";
            LbProvinceScore12.Text = "";
            LbProvinceScoreLevel.Text = "";
            LbScoreLevelExpert.Text = "";
        }
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            //LbGuideViewResultYear.Text = d[0];
            //LbGuideViewResultSemester.Text = d[1];
            //LbGuideViewResultTargetSchool.Text = d[2];
            LbProvinceScore1.Text = d[3];
            LbProvinceScore2.Text = d[4];
            LbProvinceScore3.Text = d[5];
            LbProvinceScore4.Text = d[6];
            LbProvinceScore5.Text = d[7];
            LbProvinceScore6.Text = d[8];
            LbProvinceScore7.Text = d[9];
            LbProvinceScore8.Text = d[10];
            LbProvinceScore9.Text = d[11];
            LbProvinceScore10.Text = d[12];
            LbProvinceScore11.Text = d[13];
            LbProvinceScore12.Text = d[14];
            LbProvinceScoreLevel.Text = d[15];
            LbScoreLevelExpert.Text = d[16];
        }

        string query1 = "select Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
               "from GuideSchoolMasterScore " +
               "where SN = N'" + DlGuideViewResultTargetSchool.SelectedValue.ToString() + "'" +
               "and Year =" + LbGuideYear.Text.Trim() +
               "and Semester =" + LbGuideSemester.Text.Trim() +
               "or TargetSchool = N'" + DlGuideViewResultTargetSchool.SelectedValue.ToString() + "'" +
               "or TargetSchool = N'" + DlGuideViewResultTargetSchoolComplete.SelectedValue.ToString() + "'" ;
        ms.GetAllColumnData(query1, data1);

        if (data1.Count == 0)
        {
            //string[] d1 = (string[])data1[0];
            LbShlScore1.Text = "";
            LbShlScore2.Text = "";
            LbShlScore3.Text = "";
            LbShlScore4.Text = "";
            LbShlScore5.Text = "";
            LbShlScore6.Text = "";
            LbShlScore7.Text = "";
            LbShlScore8.Text = "";
            LbShlScore9.Text = "";
            LbShlScore10.Text = "";
            LbShlScore11.Text = "";
            LbShlScore12.Text = "";
            LbShlScoreLevel.Text = "";
            LbScoreLevelSchool.Text = "";
        }
        if (data1.Count > 0)
        {
            string[] d1 = (string[])data1[0];
            LbShlScore1.Text = d1[0];
            LbShlScore2.Text = d1[1];
            LbShlScore3.Text = d1[2];
            LbShlScore4.Text = d1[3];
            LbShlScore5.Text = d1[4];
            LbShlScore6.Text = d1[5];
            LbShlScore7.Text = d1[6];
            LbShlScore8.Text = d1[7];
            LbShlScore9.Text = d1[8];
            LbShlScore10.Text = d1[9];
            LbShlScore11.Text = d1[10];
            LbShlScore12.Text = d1[11];
            LbShlScoreLevel.Text = d1[12];
            LbScoreLevelSchool.Text = d1[13];
        }
    }
    private void setInitial_MingDer()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        ArrayList data1 = new ArrayList();

        string query = "select Year, Semester, School, Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
               "from GuideExpertScore " +
               "where School = N'" + DlGuideViewResultTargetSchool.SelectedValue.ToString() + "'" +
               "or School = N'" + DlGuideViewResultTargetSchoolComplete.SelectedValue.ToString() + "'" +
               "and Year =" + DlGuideViewResultYear.SelectedValue.ToString() +
               "and Semester =" + DlGuideViewResultSemester.SelectedValue.ToString();

        ms.GetAllColumnData(query, data);

        if (data.Count == 0)
        {
            //string[] d = (string[])data[0];
            //LbGuideViewResultYear.Text = d[0];
            //LbGuideViewResultSemester.Text = d[1];
            //LbGuideViewResultTargetSchool.Text = d[2];
            LbProvinceScore1.Text = "";
            LbProvinceScore2.Text = "";
            LbProvinceScore3.Text = "";
            LbProvinceScore4.Text = "";
            LbProvinceScore5.Text = "";
            LbProvinceScore6.Text = "";
            LbProvinceScore7.Text = "";
            LbProvinceScore8.Text = "";
            LbProvinceScore9.Text = "";
            LbProvinceScore10.Text = "";
            LbProvinceScore11.Text = "";
            LbProvinceScore12.Text = "";
            LbProvinceScoreLevel.Text = "";
            LbScoreLevelExpert.Text = "";
        }
        if (data.Count > 0)
        {
            string[] d = (string[])data[0];
            //LbGuideViewResultYear.Text = d[0];
            //LbGuideViewResultSemester.Text = d[1];
            //LbGuideViewResultTargetSchool.Text = d[2];
            LbProvinceScore1.Text = d[3];
            LbProvinceScore2.Text = d[4];
            LbProvinceScore3.Text = d[5];
            LbProvinceScore4.Text = d[6];
            LbProvinceScore5.Text = d[7];
            LbProvinceScore6.Text = d[8];
            LbProvinceScore7.Text = d[9];
            LbProvinceScore8.Text = d[10];
            LbProvinceScore9.Text = d[11];
            LbProvinceScore10.Text = d[12];
            LbProvinceScore11.Text = d[13];
            LbProvinceScore12.Text = d[14];
            LbProvinceScoreLevel.Text = d[15];
            LbScoreLevelExpert.Text = d[16];
        }

        if (data.Count > 0)
        {
            string[] a = (string[])data[0];
            string TargetSchool = a[2];
            string query1 = "select Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, TotalScore, ScoreLevel " +
                   "from GuideSchoolMasterScore " +
                   "where TargetSchool = N'" + DlGuideViewResultTargetSchool.SelectedValue.ToString() + "'" +
                   "or TargetSchool = N'" + DlGuideViewResultTargetSchoolComplete.SelectedValue.ToString() + "'" +
                   "and Year =" + DlGuideViewResultYear.SelectedValue.ToString() +
                   "and Semester =" + DlGuideViewResultSemester.SelectedValue.ToString();
            ms.GetAllColumnData(query1, data1);
        }
        if (data1.Count == 0)
        {
            //string[] d1 = (string[])data1[0];
            LbShlScore1.Text = "";
            LbShlScore2.Text = "";
            LbShlScore3.Text = "";
            LbShlScore4.Text = "";
            LbShlScore5.Text = "";
            LbShlScore6.Text = "";
            LbShlScore7.Text = "";
            LbShlScore8.Text = "";
            LbShlScore9.Text = "";
            LbShlScore10.Text = "";
            LbShlScore11.Text = "";
            LbShlScore12.Text = "";
            LbShlScoreLevel.Text = "";
            LbScoreLevelSchool.Text = "";
        }
        if (data1.Count > 0)
        {
            string[] d1 = (string[])data1[0];
            LbShlScore1.Text = d1[0];
            LbShlScore2.Text = d1[1];
            LbShlScore3.Text = d1[2];
            LbShlScore4.Text = d1[3];
            LbShlScore5.Text = d1[4];
            LbShlScore6.Text = d1[5];
            LbShlScore7.Text = d1[6];
            LbShlScore8.Text = d1[7];
            LbShlScore9.Text = d1[8];
            LbShlScore10.Text = d1[9];
            LbShlScore11.Text = d1[10];
            LbShlScore12.Text = d1[11];
            LbShlScoreLevel.Text = d1[12];
            LbScoreLevelSchool.Text = d1[13];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            setInitial();
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            setInitial_MingDer();
        }
    }
    protected void DlGuideViewResultTargetSchoolComplete_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DlGuideViewResultTargetSchoolComplete.SelectedValue.Equals(Resources.Resource.DdlTypeSchoolname))
        {
            DlGuideViewResultTargetSchool.Visible = true;
            GuideResultTargetSchool.Visible = true;
        }
        else
        {
            DlGuideViewResultTargetSchool.Visible = false;
            GuideResultTargetSchool.Visible = false;
        }
    }
    protected void DlGuideViewResultTargetSchool_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DlGuideViewResultTargetSchool.SelectedValue.Equals(Resources.Resource.DdlTypeSchoolname))
        {
            DlGuideViewResultTargetSchoolComplete.Visible = true;
            GuideResultTargetSchoolComplete.Visible = true;
        }
        else
        {
            DlGuideViewResultTargetSchoolComplete.Visible = false;
            GuideResultTargetSchoolComplete.Visible = false;
        }
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