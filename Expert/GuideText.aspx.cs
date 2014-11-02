using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GuideText : System.Web.UI.Page
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
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setInitial();
        }
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
        else
        {
            storeData();
        }
    }

    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select MainContent, SubjectAbility, PersonalityMold, SchoolManagement, SDPFormulate, SDPImplement, SDPEffect, NextStepSuggest from GuideText where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            TBGuideTextContent.Text = d[0];
            TBGuideTextSubject.Text = d[1];
            TBGuideTextPersonality.Text = d[2];
            TBGuideTextSchoolManagement.Text = d[3];
            TBGuideTextSDPFormulate.Text = d[4];
            TBGuideTextSDPImplement.Text = d[5];
            TBGuideTextSDPeffect.Text = d[6];
            TBGuideTextNextStepSuggest.Text = d[7];
        }
    }

    private bool haveEmptyData()
    {
        return false;
        if (TBGuideTextContent.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextSubject.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextPersonality.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextSchoolManagement.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextSDPFormulate.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextSDPImplement.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextSDPeffect.Text.Trim().Equals(""))
            return true;
        if (TBGuideTextNextStepSuggest.Text.Trim().Equals(""))
            return true;
        return false;
    }
    private void storeData()
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        // 先刪除原本的
        string query = "delete from GuideText where SN ='" + Session["UserGuideListSN"].ToString() + "'";
        ms.WriteData(query, sb);
        sb.Clear();
        query = "insert into GuideText (SN, Year, Semester, MainContent, SubjectAbility, PersonalityMold, SchoolManagement, SDPFormulate, SDPImplement, SDPEffect, NextStepSuggest) VALUES ('" +
                        Session["UserGuideListSN"].ToString() + "',N'" +
                        LbGuideYear.Text.Trim() + "',N'" +
                        LbGuideSemester.Text.Trim() + "',N'" +
                        TBGuideTextContent.Text + "',N'" +
                        TBGuideTextSubject.Text + "',N'" +
                        TBGuideTextPersonality.Text + "',N'" +
                        TBGuideTextSchoolManagement.Text + "',N'" +
                        TBGuideTextSDPFormulate.Text + "',N'" +
                        TBGuideTextSDPImplement.Text + "',N'" +
                        TBGuideTextSDPeffect.Text + "',N'" +
                        TBGuideTextNextStepSuggest.Text + "')";
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