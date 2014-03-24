using System;
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
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || string.IsNullOrEmpty(Request["QuestionClass"]).ToString())
        //    Response.Redirect("SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("2"))
        //    Response.Redirect("SessionOut.aspx");

        // test
        Session["QuestionClass"] = "1";


        BaseClass bc = new BaseClass();
        ManageSQL ms = new ManageSQL();

        //string DecryptQuestionID = bc.decryption(Request["QuestionClass"]);
        //Session["QuestionClass"] = DecryptQuestionID;


        for (int i = 0; i < QuestionMaxNumbers; i++)
        {
            Manager_UserControlQuestion c = (Manager_UserControlQuestion)LoadControl("UserControlQuestion.ascx");
            c.eventArgs.QuestionID = (i + 1).ToString();
            //c.eventArgs.QuestionContent = ;
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

        if (IsDigit)
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
                case "ASP.manager_usercontrolquestion_ascx":
                    Manager_UserControlQuestion c = (Manager_UserControlQuestion)PnQuestionList.Controls[i];
                    if (c.eventArgs.PassScore < 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + c.eventArgs.QuestionID + "題，配分不得小於0');", true);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(c.eventArgs.Answer))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + c.eventArgs.QuestionID + "題，必須輸入答案');", true);
                        return false;
                    }
                    else if (string.IsNullOrEmpty(c.eventArgs.Question))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + c.eventArgs.QuestionID + "題，必須描述問題');", true);
                        return false;
                    }
                    else if (c.eventArgs.AnswerItemCount < 2)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + c.eventArgs.QuestionID + "題，必須輸入問題之答案');", true);
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


        // 資料庫有問題，InternetStudyQuestionItem必須重新設計
        string Query;


        for (int i = 0; i < PnQuestionList.Controls.Count; i++)
        {
            //string t = pn_main.Controls[i].GetType().ToString();
            switch (this.PnQuestionList.Controls[i].GetType().ToString())
            {
                case "ASP.manager_usercontrolquestion_ascx":
                    Manager_UserControlQuestion c = (Manager_UserControlQuestion)PnQuestionList.Controls[i];
                    
                    for (int j = 0; j < c.eventArgs.AnswerItemCount; j++)
                    {
                        StringBuilder sb = new StringBuilder();
                        Query = "insert into InternetStudyQuestionItem (QuestionClassID, QuestionNo, QuestionAnswerNumbers, AnswerContent) " +
                                "VALUES ('" + Session["QuestionClass"].ToString() + "','" + c.eventArgs.QuestionID + "','" +
                                j + "','" + c.eventArgs.AnswerItem[j] + "'";
                        ms.WriteData(Query, sb);

                    }

                    break;
                default:
                    string ss = PnQuestionList.Controls[i].GetType().ToString();
                    break;
            }
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnSubmit")
        {
            //bool CheckPass = CheckData();
            //if (CheckPass)
            //{
 
            //}
            UploadData();
        }
        else if (btn.ID == "BtnCancel")
        {
 
        }
    }
}