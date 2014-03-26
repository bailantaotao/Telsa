using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEditAddClass : System.Web.UI.Page
{
    private const int QuestionMaxNumbers = 10;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || string.IsNullOrEmpty(Request["QuestionClassID"]))
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");

        // test
        //Session["QuestionClassID"] = "1";
        //Session["QuestionClassYear"] = "104";
        //Session["ClassID"] = "1";
        // test
        BaseClass bc = new BaseClass();

        //string DecryptQuestionID = bc.decryption(Request["QuestionClassID"]);
        //Session["QuestionClassID"] = DecryptQuestionID;
        //string DecryptQuestionClassYear = bc.decryption(Request["QuestionClassYear"]);
        //Session["QuestionClassYear"] = DecryptQuestionClassYear;
        //string DecryptClassID = bc.decryption(Request["ClassID"]);
        //Session["ClassID"] = DecryptClassID;

        
        Session["QuestionClassID"] = Request["QuestionClassID"];
        
        Session["QuestionClassYear"] = Request["QuestionClassYear"];

        Session["ClassID"] = Request["ClassID"];

        for (int i = 0; i < QuestionMaxNumbers; i++)
        {
            Manager_UserControlQuestionItem c = (Manager_UserControlQuestionItem)LoadControl("UserControlQuestionItem.ascx");
            c.eventArgs.QuestionID = i;
            //c.cClick += new userControl_questionTest.questionClick(c_cClick);
            //PnQuestion.Controls.Add(c);
            PnQuestionList.Controls.Add(c);
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool CheckData()
    {
        if (string.IsNullOrEmpty(TbTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('標題不可為空');", true);
            return false;
        }
        else if (string.IsNullOrEmpty(TbDescription.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('說明不可為空');", true);
            return false;
        }
        else if (string.IsNullOrEmpty(TbPassScore.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('及格分數不可為空');", true);
            return false;
        }
        else if (string.IsNullOrEmpty(TbURL.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('URL輸入不可為空');", true);
            return false;
        }
        
        int PassScore = -1;
        bool IsDigit = Int32.TryParse(TbPassScore.Text, out PassScore);

        if (!IsDigit)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('及格分數必須是數字');", true);
            return false;
        }
        if (PassScore < 0 && 100 < PassScore)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('及格分數必須為0~100');", true);
            return false;
        }

        for (int i = 0; i < PnQuestionList.Controls.Count; i++)
        {
            switch (this.PnQuestionList.Controls[i].GetType().ToString())
            {
                case "ASP.manager_usercontrolquestionitem_ascx":
                    Manager_UserControlQuestionItem c = (Manager_UserControlQuestionItem)PnQuestionList.Controls[i];
                    if (c.eventArgs.PassScore < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1).ToString() + "題，配分不得小於0');", true);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(c.eventArgs.Answer))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1).ToString() + "題，必須輸入答案');", true);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(c.eventArgs.Question))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1).ToString() + "題，必須描述問題');", true);
                        return false;
                    }
                    else if (c.eventArgs.AnswerItemCount < 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1).ToString() + "題，必須輸入問題之答案');", true);
                        return false;
                    }


                    break;
                default:
                    break;
            }
        }
        return true;
    }
    private void UploadData()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        // 資料庫有問題，InternetStudyQuestionItem必須重新設計

        // get data must be add QuestionYear, ClassID
        // and in addYear, must insert data to table.
        // in this, must to update
        string Query;
        Query = "Update InternetStudy set " +
                "ClassName = N'" + TbTitle.Text + "'," +
                "ClassDescription = N'" + TbDescription.Text + "'," +
                "PassScore = N'" + TbPassScore.Text + "'," +
                "QuestionURL = N'" + TbURL.Text + "'," +
                "QuestionAddedComplete = N'" + "True" + "' " +
                "where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";

        if (ms.WriteData(Query, sb))
        {
            sb.Clear();

            Query = "delete from InternetStudyQuestionContent where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.WriteData(Query, sb);
            sb.Clear();

            // 先刪除再新增資料
            Query = "delete from InternetStudyQuestionItem where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.WriteData(Query, sb);
            sb.Clear();

            for (int i = 0; i < PnQuestionList.Controls.Count; i++)
            {
                //string t = pn_main.Controls[i].GetType().ToString();
                switch (this.PnQuestionList.Controls[i].GetType().ToString())
                {
                    case "ASP.manager_usercontrolquestionitem_ascx":
                        Manager_UserControlQuestionItem c = (Manager_UserControlQuestionItem)PnQuestionList.Controls[i];

                        Query = "insert into InternetStudyQuestionContent " +
                                "( QuestionClassID, QuestionNo, QuestionContent, IsSingleSelection, Score, Answer ) " +
                                "VALUES " +
                                "( '" + Session["QuestionClassID"].ToString() + "',N'" + 
                                c.eventArgs.QuestionID + "',N'" + 
                                c.eventArgs.Question + "',N'" + 
                                c.eventArgs.IsSingleSelected + "',N'" + 
                                c.eventArgs.PassScore + "',N'" +
                                c.eventArgs.Answer + "')";

                        bool isTrue = ms.WriteData(Query, sb);
                        sb.Clear();

                        for (int j = 0; j < c.eventArgs.AnswerItemCount; j++)
                        {
                            //StringBuilder sb = new StringBuilder();
                            Query = "insert into InternetStudyQuestionItem (QuestionClassID, QuestionNo, QuestionAnswerNumbers, AnswerContent) " +
                                    "VALUES " +
                                    "('" + Session["QuestionClassID"].ToString() + "',N'" + 
                                    c.eventArgs.QuestionID + "',N'" +
                                    j + "',N'" + 
                                    c.eventArgs.AnswerItem[j] + "')";
                            isTrue = ms.WriteData(Query, sb);
                        }

                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            return;
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
                if (Session["AddYearTag"] != null)
                {
                    Response.Redirect("InternetStudyEditAddYear.aspx");
                }
                else
                {
                    Response.Redirect("InternetStudyEdit.aspx");
                }
            }            
        }
        else if (btn.ID == "BtnCancel")
        {
            if (Session["AddYearTag"] != null)
            {
                Response.Redirect("InternetStudyEditAddYear.aspx");
            }
            else
            {
                Response.Redirect("InternetStudyEdit.aspx");
            }
        }
    }
}