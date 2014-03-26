using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEditDisplay : System.Web.UI.Page
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
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();

        //string DecryptQuestionID = bc.decryption(Request["QuestionClassID"]);
        //Session["QuestionClassID"] = DecryptQuestionID;
        //string DecryptQuestionClassYear = bc.decryption(Request["QuestionClassYear"]);
        //Session["QuestionClassYear"] = DecryptQuestionClassYear;
        //string DecryptClassID = bc.decryption(Request["ClassID"]);
        //Session["ClassID"] = DecryptClassID;

        Session["QuestionClassID"] = Request["QuestionClassID"];

        Session["QuestionClassYear"] = Request["QuestionClassYear"];

        Session["ClassID"] = Request["ClassID"];

        string Query = string.Empty;
        Query = "select count(*) from InternetStudy where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
        if (ms.GetRowNumbers(Query, sb))
        {
            int Digit = -1;
            bool IsDigit = Int32.TryParse(Session["QuestionClassID"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('未能找到該類別之資料，SORRY!');", true);
                return;
            }

            IsDigit = Int32.TryParse(Session["QuestionClassYear"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('未能找到該類別之資料，SORRY!');", true);
                return;
            }

            IsDigit = Int32.TryParse(Session["ClassID"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('未能找到該類別之資料，SORRY!');", true);
                return;
            }

            Query = "select ClassName, ClassDescription, PassScore, QuestionURL from InternetStudy where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.GetAllColumnData(Query, data);
            if (data.Count > 0)
            {
                LbTitle.Text = ((string[])data[0])[0].ToString();
                LbDescription.Text = ((string[])data[0])[1].ToString();
                LbPassScore.Text = ((string[])data[0])[2].ToString();
                //HyURL.Text = ((string[])data[0])[3].ToString();
                //mplayer.Url = ((string[])data[0])[3].ToString();
                LbUrl.Text = "<embed src='http://player.youku.com/player.php/sid/XNTg2ODk2ODIw/v.swf' allowFullScreen='true' quality='high' width='640' height='480' align='middle' allowScriptAccess='always' type='application/x-shockwave-flash'></embed>";
            }
            data.Clear();

            Query = "select QuestionNo, QuestionContent, IsSingleSelection, Score, Answer from InternetStudyQuestionContent where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "' " +
                    "order by QuestionNo asc";
            ms.GetAllColumnData(Query, data);

            for (int i = 0; i < QuestionMaxNumbers; i++)
            {
                ArrayList ALAnswerItem = new ArrayList();
                bool IsSingleSelect = false;
                int QuestionID = -1;
                int PassScore = -1;


                Manager_UserControlQuestionDisplay c = (Manager_UserControlQuestionDisplay)LoadControl("UserControlQuestionDisplay.ascx");
                if (Int32.TryParse(((string[])data[i])[0], out QuestionID))
                {
                    c.eventArgs.QuestionID = QuestionID;
                }
                else
                {
                    c.eventArgs.QuestionID = i;
                }

                c.eventArgs.Question = ((string[])data[i])[1].ToString();

                if (bool.TryParse(((string[])data[i])[2], out IsSingleSelect))
                {
                    c.eventArgs.IsSingleSelected = IsSingleSelect;
                }
                else
                {
                    c.eventArgs.IsSingleSelected = true;
                }


                if (Int32.TryParse(((string[])data[i])[3], out PassScore))
                {
                    c.eventArgs.PassScore = PassScore;
                }
                else
                {
                    c.eventArgs.PassScore = 0;
                }


                c.eventArgs.Answer = ((string[])data[i])[4].ToString();



                Query = "select QuestionAnswerNumbers, AnswerContent from InternetStudyQuestionItem where QuestionClassID ='" + Session["QuestionClassID"].ToString() + "' " +
                        "and QuestionNo = '" + c.eventArgs.QuestionID + "' order by QuestionAnswerNumbers asc";

                ms.GetAllColumnData(Query, ALAnswerItem);
                if (ALAnswerItem.Count > 0)
                {
                    for (int j = 0; j < ALAnswerItem.Count; j++)
                    {
                        c.eventArgs.AnswerItem.Add(((string[])ALAnswerItem[j])[1]);
                    }

                }
                //c.eventArgs.QuestionContent = ;
                //c.cClick += new userControl_questionTest.questionClick(c_cClick);
                //PnQuestion.Controls.Add(c);
                PnQuestionList.Controls.Add(c);
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnBack")
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