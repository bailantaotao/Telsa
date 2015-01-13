using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamStart : System.Web.UI.Page
{
    private const int QuestionMaxNumbers = 10;
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || Session["InputMode"] == null)
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

        
        BtnCancel.Visible = false;
        BtnSubmit.Visible = false;
        SetDdlDefault(DdlDimension);
        if (Session["DdlDimension_SelectIndex"] != null)
        {
            ListDdlDomains();
        }
            
        bool CheckPass = PreCheck();
        if (CheckPass)
        {
            PnMain.Controls.Clear();
            ListKPIQuestionnaire();
        }
           
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["InputMode"] != null)
        {
            DdlDimension.SelectedIndex = Convert.ToInt32(Session["DdlDimension_SelectIndex"].ToString());
            DdlDomain.SelectedIndex = Convert.ToInt32(Session["DdlDomain_SelectIndex"].ToString());

            BtnCancel.Visible = true;
            BtnSubmit.Visible = true;

            DdlDimension.Enabled = false;
            DdlDomain.Enabled = false;
        }
    }

    private string getPostBackControlName()
    {
        Control control = null;
        //first we will check the "__EVENTTARGET" because if post back made by       the controls
        //which used "_doPostBack" function also available in Request.Form collection.

        string ctrlname = Page.Request.Params["__EVENTTARGET"];
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = Page.FindControl(ctrlname);
        }

        // if __EVENTTARGET is null, the control is a button type and we need to
        // iterate over the form collection to find it
        else
        {
            string ctrlStr = String.Empty;
            Control c = null;
            foreach (string ctl in Page.Request.Form)
            {
                //handle ImageButton they having an additional "quasi-property" in their Id which identifies
                //mouse x and y coordinates
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    c = Page.FindControl(ctrlStr);
                }
                else
                {
                    c = Page.FindControl(ctl);
                }
                if (c is System.Web.UI.WebControls.Button ||
                         c is System.Web.UI.WebControls.ImageButton)
                {
                    control = c;
                    break;
                }
            }

        }
        return control.ID;
    }

    private void SetDdlDefault(DropDownList ddl)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select * from KPIDimensionsNameMapping";

        if (ms.GetAllColumnData(query, data))
        {
            foreach (string[] tmp in data)
            {
                DdlDimension.Items.Add(new ListItem(tmp[1], tmp[0]));
            }
        }
        else
        {
            DdlDimension.Items.Add(Resources.Resource.TipKPIError);
        }
    }

    private bool CheckData()
    {

        for (int i = 0; i < PnMain.Controls.Count; i++)
        {
            switch (this.PnMain.Controls[i].GetType().ToString())
            {
                case "ASP.schoolmaster_usercontrolkpianswer_ascx":
                    SchoolMaster_UserControlKPIAnswer c = (SchoolMaster_UserControlKPIAnswer)PnMain.Controls[i];

                    if (!c.eventArgs.Finish && string.IsNullOrEmpty(c.eventArgs.UserAnswer))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + (c.eventArgs.DomainID) + "-" + (c.eventArgs.ClassID) + Resources.Resource.SMInputAnswer + "');", true);
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }
        return true;
    }
    private bool getSchoolName(StringBuilder sb)
    {
        ManageSQL ms = new ManageSQL();
        string query = "select school from Account where UserID = '" + Session["UserID"].ToString() + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        return true;
    }
    private bool getCycle(string schoolName, ref int id)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();
        string query = "select count(*) from KPIRecordMain where Schoolname = N'" + schoolName + "' and KPIDEADLINESN = '" + Session["KPISN"].ToString() + "'";
        if (!ms.GetRowNumbers(query, sb))
            return false;

        query = "select top 1 id from KPIRecordMain where Schoolname = N'" + schoolName + "' and KPIDEADLINESN = '" + Session["KPISN"].ToString() + "' and IsFinish='False' order by ID desc";
        if (!ms.GetAllColumnData(query, data))
            return false;
        if (data.Count == 0)
            id = -1;
        else
            id = Convert.ToInt32(((string[])data[0])[0]);

        return true;
        //query = "select top 1 cycle from KPIRecordMain where Schoolname = N'" + schoolName + "' and Year = '"+BaseClass.NowYear+"' and IsFinish='' order by ID desc";
        
        //if (!ms.GetOneColumnData(query, data))
        //    return false;
        //if (data.Count >= 2)
        //    return false;
        //if (data.Count == 0)
        //{
        //    cycle = 1;
        //    return true;
        //}
        //cycle = 2;
        //return true;
    }
    private bool getKPIMainID(ref int id)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select top 1 id from KPIRecordMain order by id desc";
        if (!ms.GetOneData(query, sb))
            return false;
        id=Convert.ToInt32(sb.ToString());
        return true;
    }
    private bool getDimensionHaveData(int id, ref bool haveData)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "select count(*) from KPIRecordDimensionsScore where ID = '" + id + "' and DimensionID='" + DdlDimension.SelectedValue + "'";
        if (!ms.GetOneData(query, sb))
            return false;
        if (sb.ToString().Equals("0"))
            haveData = false;
        else
            haveData = true;
        return true;
    }
    private bool getKPILevel(int userScore, ref int KPILevel)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select * from KPIDomainBoundaryScore where DomainID = '" + DdlDomain.SelectedValue + "' order by Domainlevel desc";
        if (!ms.GetAllColumnData(query, data))
            return false;

        foreach(string[] tmp in data)
        {
            if (userScore > Convert.ToInt32(tmp[2]))
            {
                KPILevel = Convert.ToInt32(tmp[1]);
            }
        }
        return true;
    }
    private bool getDimensionSet(ArrayList DimensionSet)
    {
        ManageSQL ms = new ManageSQL();
        
        string query = "select DimensionsID, DomainID from KPIDimensionsDomainMappingTable where DimensionsID = '" + DdlDimension.SelectedValue + "'";
        if (!ms.GetAllColumnData(query, DimensionSet))
            return false;

        return true;
    }

    private bool getKPIDimensionsLevel(int userScore, ref int KPIDimensionsLevel)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select * from KPIDimensionsBoundaryScore where DimensionsID = '" + DdlDimension.SelectedValue + "' order by Dimensionlevel desc";
        if (!ms.GetAllColumnData(query, data))
            return false;

        foreach (string[] tmp in data)
        {
            if (userScore > Convert.ToInt32(tmp[2]))
            {
                KPIDimensionsLevel = Convert.ToInt32(tmp[1]);
            }
        }
        return true;
    }

    private bool getMainSet(ArrayList MainScoreSet)
    {
        ManageSQL ms = new ManageSQL();

        string query = "select DimensionsID from KPIDimensionsNameMapping";
        if (!ms.GetAllColumnData(query, MainScoreSet))
            return false;

        return true;
    }

    private bool getKPIMainLevel(int userScore, ref string KPIMainLevel)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select * from KPIScoreRank order by ScoreBoundary";
        if (!ms.GetAllColumnData(query, data))
            return false;

        foreach (string[] tmp in data)
        {
            if (userScore > Convert.ToInt32(tmp[1]))
            {
                KPIMainLevel = tmp[0];
            }
        }
        return true;
    }

    private void UploadData()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ArrayList data = new ArrayList();
        
        int KPIID = 0;
        string schoolName = string.Empty;
        string query = string.Empty;
        bool status = false;

        // 取得學校名稱
        status = getSchoolName(sb);
        if(!status)
        {
            return;
        }
        schoolName = sb.ToString();
        
        // 取得該校做了第幾次 超過2就return
        status = getCycle(schoolName, ref KPIID);
        if(!status)
        {
            return;
        }

        // 判斷該校資料是否存在
        if (KPIID == -1)
        {
            // 新增一筆資料到KPIRecordMain
            query = "insert into KPIRecordMain (KPIDEADLINESN, SchoolName, IsFinish) VALUES ('" +
                    Session["KPISN"].ToString() + "',N'" +
                    schoolName + "','" +
                    "False')";
            if (!ms.WriteData(query, sb))
                return;
            status = getCycle(schoolName, ref KPIID);
            if (!status)
            {
                return;
            }
        }


                

        //if(!ms.WriteData(query, sb))
        //    return;

        // 取得KPI ID
        //status = getKPIMainID(ref KPIID);
        //if (!status)
        //{
        //    return;
        //}

        // 判斷KPIRecordDimensionScore是否已有資料
        bool haveData = false;
        status = getDimensionHaveData(KPIID, ref haveData);
        if (!status)
        {
            return;
        }

        if (!haveData)
        {
            //新增一筆資料到KPIDimensiionsScore裡面
            query = "insert into KPIRecordDimensionsScore (ID,DimensionID, TotalScore, IsFinish, ScoreLevel) VALUES ('" +
                    KPIID + "','" +
                    DdlDimension.SelectedValue + "','" +
                    0 + "','" +
                    "False" +"','" +
                    "E" + "')";
            ms.WriteData(query, sb);
        }

        // 新增資料到KPIRecordDomainDetail裡面
        //怕有重複的，先刪除舊有資料
        query = "delete from KPIRecordDomainDetail where ID='" + KPIID + "' and DomainID='" + DdlDomain.SelectedValue + "'";
        ms.WriteData(query, sb);

        int KPIScore = 0;
        for (int i = 0; i < PnMain.Controls.Count; i++)
        {
            switch (this.PnMain.Controls[i].GetType().ToString())
            {
                case "ASP.schoolmaster_usercontrolkpianswer_ascx":
                    SchoolMaster_UserControlKPIAnswer c = (SchoolMaster_UserControlKPIAnswer)PnMain.Controls[i];
                    query = "insert into KPIRecordDomainDetail (ID, DomainID, ClassID, ClassScore, DimensionID) VALUES ('" +
                            KPIID + "','" +
                            c.eventArgs.DomainID + "','" +
                            c.eventArgs.ClassID + "','" +
                            c.eventArgs.UserAnswer + "','" +
                            DdlDimension.SelectedValue + "' )";
                    ms.WriteData(query, sb);
                    KPIScore += Convert.ToInt32(c.eventArgs.UserAnswer);
                    break;
                default:
                    break;
            }
        }

        // 取得該領域的KPI分數
        int KPILevel = -1;
        status = getKPILevel(KPIScore, ref KPILevel);
        if (!status)
        {
            return;
        }


        //新增資料到KPIRecordDomainScore裡面
        //怕有重複的，先刪除舊有資料
        // +[20140911, HungTao] 加入count計算目前使用者填寫幾次
        query = "select count(*) from KPIRecordDomainScore where ID='" + KPIID + "' and DomainID='" + DdlDomain.SelectedValue + "'";
        ms.GetRowNumbers(query, sb);
        if (sb.ToString().Equals("0"))
        {
            query = "insert into KPIRecordDomainScore (ID, DomainID, TotalScore, ScoreLevel, FinishTime, DimensionID, FilledCount) VALUES ('" +
                    KPIID + "','" +
                    DdlDomain.SelectedValue + "','" +
                    KPIScore + "','" +
                    KPILevel + "','" +
                    DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "','" +
                    DdlDimension.SelectedValue + "','" +
                    1 + "')";
        }
        else
        {
            query = "select FilledCount from KPIRecordDomainScore where ID='" + KPIID + "' and DomainID='" + DdlDomain.SelectedValue + "' and DimensionID = '" + DdlDimension.SelectedValue + "'";
            ms.GetOneData(query, sb);

            bool isDigit = false;
            int count = -99;
            isDigit = Int32.TryParse(sb.ToString(), out count);

            query = "update KPIRecordDomainScore set " +
                    "TotalScore = '" + KPIScore + "', " +
                    "ScoreLevel = '" + KPILevel + "', " +
                    "FinishTime = '" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "', " +
                    "FilledCount = '" + (isDigit ? ++count : 1) + "' " +
                    "where " +
                    "ID = '" + KPIID + "' and " +
                    "DomainID = '" + DdlDomain.SelectedValue + "' and " +
                    "DimensionID = '" + DdlDimension.SelectedValue + "' ";
        }

        if (!ms.WriteData(query, sb))
            return;
        //query = "delete from KPIRecordDomainScore where ID='" + KPIID + "' and DomainID='" + DdlDomain.SelectedValue + "'";
        //ms.WriteData(query, sb);

        //query = "insert into KPIRecordDomainScore (ID, DomainID, TotalScore, ScoreLevel, FinishTime, DimensionID) VALUES ('" +
        //        KPIID + "','" +
        //        DdlDomain.SelectedValue + "','" +
        //        KPIScore +"','"+
        //        KPILevel + "','" +
        //        DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "','" +
        //        DdlDimension.SelectedValue + "')";

        //if (!ms.WriteData(query, sb))
        //    return;
        // -[20140911, HungTao] 加入count計算目前使用者填寫幾次


        /**********************************************************************************************/
        // update DimensionScore

        // 取得該維度所包含的領域
        ArrayList dimensionSet = new ArrayList();
        status = getDimensionSet(dimensionSet);
        if (!status)
        {
            return;
        }

        // 先算出個數是否相同，如果不相同就不用計算分數了
        query = "select * from KPIRecordDomainScore where ID ='" + KPIID + "' and DimensionID='"+DdlDimension.SelectedValue+"'";
        if (!ms.GetAllColumnData(query, data))
        {
            return;
        }

        if (data.Count != dimensionSet.Count)
        {
            return;
        }

        bool isNotFind = false;
        int dimensionScore = 0;
        //計算領域內所有的分數
        foreach (string[] tmp in dimensionSet)
        {
            query = "select TotalScore from KPIRecordDomainScore where ID ='" + KPIID + "' and DomainID = '" + tmp[1] + "'";
            if (ms.GetOneData(query, sb))
            {
                dimensionScore += Convert.ToInt32(sb.ToString());
            }
            else
            {
                isNotFind = true;
                break;
            }
        }
        if (isNotFind)
            return;

        // 計算該分數屬於維度內的幾分
        int dimensionLevel = -1;
        status = getKPIDimensionsLevel(dimensionScore, ref dimensionLevel);
        if (!status)
        {
            return;
        }
        
        // 更新維度的分數
        query = "delete from KPIRecordDimensionsScore where ID ='" + KPIID + "' and DimensionID = '"+DdlDimension.SelectedValue+"'";
        if (!ms.WriteData(query, sb))
            return;

        query = "insert into KPIRecordDimensionsScore (ID, DimensionID, TotalScore, ScoreLevel, IsFinish, FinishTime) VALUES ('" +
                KPIID + "','" +                
                DdlDimension.SelectedValue + "','" +
                dimensionScore + "','" +
                dimensionLevel + "','" +
                "True" +"','"+
                DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "')";

        if (!ms.WriteData(query, sb))
            return;


        /**********************************************************************************************/
        // update Total Score

        // 取得該維度所包含的領域
        ArrayList MainScoreSet = new ArrayList();
        status = getMainSet(MainScoreSet);
        if (!status)
        {
            return;
        }

        // 先算出個數是否相同，如果不相同就不用計算分數了
        query = "select * from KPIRecordDimensionsScore where ID ='" + KPIID + "' and IsFinish='True'";
        if (!ms.GetAllColumnData(query, data))
        {
            return;
        }

        if (data.Count != MainScoreSet.Count)
        {
            return;
        }

        isNotFind = false;
        int mainScore = 0;
        //計算領域內所有的分數
        foreach (string[] tmp in MainScoreSet)
        {
            query = "select TotalScore from KPIRecordDimensionsScore where ID ='" + KPIID + "' and DimensionID = '" + tmp[0] + "'";
            if (ms.GetOneData(query, sb))
            {
                mainScore += Convert.ToInt32(sb.ToString());
            }
            else
            {
                isNotFind = true;
                break;
            }
        }
        if (isNotFind)
            return;

        // 計算該分數屬於維度內的幾分
        string mainLevel = string.Empty;
        status = getKPIMainLevel(mainScore, ref mainLevel);
        if (!status)
        {
            return;
        }

        // 更新維度的分數

        query = "update KPIRecordMain set " +
                "TotalScore='" + mainScore + "', " +
                "ScoreLevel='" + mainLevel + "', " +
                "IsFinish='True', " +
                "FinishTime='" + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "' " +
                "where ID='" + KPIID + "'";                                

        if (!ms.WriteData(query, sb))
            return;


    }

    private bool PreCheck()
    {
        if (Session["DdlDimension_SelectIndex"] == null)
            return false;

        if (Session["DdlDomain_SelectIndex"] == null && Session["DdlDomain_SelectValue"] == null)
            return false;

        int dimensionSelectIndex = -1, domainSelectIndex = -1;
        bool dimensionIsSuccess = false, domainIsSuccess = false ;

        dimensionIsSuccess = Int32.TryParse(Session["DdlDimension_SelectIndex"].ToString(), out dimensionSelectIndex);

        domainIsSuccess = Int32.TryParse(Session["DdlDomain_SelectIndex"].ToString(), out domainSelectIndex);

        if (!dimensionIsSuccess || !domainIsSuccess)
            return false;

        if (DdlDimension.Items[dimensionSelectIndex].Value.Equals(Resources.Resource.TipPlzChoose))
            return false;
        if (DdlDomain.Items[domainSelectIndex].Value.Equals(Resources.Resource.TipPlzChoose))
            return false;
        return true;
    }
    private void ListKPIQuestionnaire()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList ClassData = new ArrayList();
        ArrayList AssessmentStandards = new ArrayList();
        ArrayList Description = new ArrayList();
        string dimension = DdlDimension.SelectedValue;
        string domain = (Session["DdlDomain_SelectValue"] == null) ? DdlDomain.SelectedIndex.ToString() : Session["DdlDomain_SelectValue"].ToString();
        
        string query = "select classid, classname from KPICLASS where DomainID = '"+ domain +"' order by ClassID asc";
        if (!ms.GetAllColumnData(query, ClassData))
            return;

        query = "select classid, AssessmentStandardsScore, AssessmentStandards from KPIAssessmentStandards where domainID = '" + domain + "' order by classid asc";
        if (!ms.GetAllColumnData(query, AssessmentStandards))
            return;

        query = "select ClassID, descriptionID, Description from KPIDescription where domainid = '" + domain + "' order by classid asc";
        if (!ms.GetAllColumnData(query, Description))
            return;

        // 是button觸發，所以是postback
        foreach (string[] saClassData in ClassData)
        {
            SchoolMaster_UserControlKPIAnswer smukpi = (SchoolMaster_UserControlKPIAnswer)LoadControl("UserControlKPIAnswer.ascx");
            smukpi.eventArgs.Question = saClassData[1];
            smukpi.eventArgs.DomainID = domain;
            smukpi.eventArgs.ClassID = saClassData[0];
            string iClassID = saClassData[0];
            foreach (string[] saDescription in Description)
            {
                if (saDescription[0].Equals(iClassID))
                    smukpi.eventArgs.DescriptionItem.Add(saDescription[2]);
            }

            foreach (string[] saAssessmentStandards in AssessmentStandards)
            {
                if (saAssessmentStandards[0].Equals(iClassID))
                    smukpi.eventArgs.AnswerItem.Add(saAssessmentStandards);
            }
            
            PnMain.Controls.Add(smukpi);
        }

        
    }

    private void ListDdlDomains()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select KPIDimensionsDomainMappingTable.DimensionsID, KPIDimensionsDomainMappingTable.DomainID, KPIDomainNameMapping.DomainName " +
                        "from KPIDimensionsNameMapping " +
                        "left join KPIDimensionsDomainMappingTable on KPIDimensionsNameMapping.DimensionsID = KPIDimensionsDomainMappingTable.DimensionsID " +
                        "left join KPIDomainNameMapping on KPIDimensionsDomainMappingTable.DomainID = KPIDomainNameMapping.DomainID ";

        if (ms.GetAllColumnData(query, data))
        {
            if (data.Count > 0)
            {
                DdlDomain.Items.Clear();
                DdlDomain.Items.Add(new ListItem(Resources.Resource.TipPlzChoose, "0"));
                int ddlDimensionSelectIndex = (Session["DdlDimension_SelectIndex"]==null)?DdlDimension.SelectedIndex:Convert.ToInt32(Session["DdlDimension_SelectIndex"].ToString());
                foreach (string[] tmp in data)
                {
                    int DimensionsID = -1;
                    bool DimensionsSuccess = false;
                    DimensionsSuccess = Int32.TryParse(tmp[0], out DimensionsID);
                    if (DimensionsSuccess)
                    {
                        if (ddlDimensionSelectIndex == DimensionsID)
                        {
                            DdlDomain.Items.Add(new ListItem(tmp[2], tmp[1]));
                        }
                    }
                }
            }
        }
        else
        {
            DdlDomain.Items.Add(Resources.Resource.TipKPIError);
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnSubmit")
        {
            bool CheckPass = CheckData();
            if (CheckPass)
            {
                UploadData();
                Session.Remove("DdlDimension_SelectIndex");
                BtnCancel.Visible = false;
                BtnSubmit.Visible = false;
                if (Session["InputMode"] != null)
                    Session.Remove("InputMode");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipKPIFinish + "');window.location='KPIExamMain.aspx';", true);
                
            }
        }
        else if (btn.ID == "BtnCancel")
        {
            if (Session["InputMode"] != null)
                Session.Remove("InputMode");
            Response.Redirect("KPIExamMain.aspx");
        }
    }

    protected void DdlDimension_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void DdlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}