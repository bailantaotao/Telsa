using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_InternetStudyQuestionnaire : System.Web.UI.Page
{
    private const int QuestionMaxNumbers = 10;
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        //if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || string.IsNullOrEmpty(Request["QuestionClassID"]))
        //    Response.Redirect("../SessionOut.aspx");
        //if (!Session["ClassCode"].ToString().Equals("2"))
        //    Response.Redirect("../SessionOut.aspx");

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
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.TipDataLose + "，SORRY!');", true);
                return;
            }

            IsDigit = Int32.TryParse(Session["QuestionClassYear"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.TipDataLose + "，SORRY!');", true);
                return;
            }

            IsDigit = Int32.TryParse(Session["ClassID"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.TipDataLose + "，SORRY!');", true);
                return;
            }

            Query = "select ClassName, ClassDescription, QuestionURL from InternetStudy where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.GetAllColumnData(Query, data);
            if (data.Count > 0)
            {
                LbTitle.Text = ((string[])data[0])[0].ToString();
                LbDescription.Text = ((string[])data[0])[1].ToString();
                HyURL.Text = ((string[])data[0])[2].ToString();
                LbUrl.Text = "<embed src='" + ((string[])data[0])[2].ToString() + "' allowFullScreen='true' quality='high' width='" + Resources.Resource.VideoWidth + "' height='" + Resources.Resource.VideoHeight + "' align='middle' allowScriptAccess='always' type='application/x-shockwave-flash'></embed>";
            }
            data.Clear();

            Query = "select QuestionNo, QuestionContent from InternetStudyQuestionContent where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "' " +
                    "order by QuestionNo asc";
            ms.GetAllColumnData(Query, data);

            for (int i = 0; i < QuestionMaxNumbers; i++)
            {
                ArrayList ALAnswerItem = new ArrayList();
                int QuestionID = -1;

                SchoolMaster_UserControlQuestionAnswer c = (SchoolMaster_UserControlQuestionAnswer)LoadControl("UserControlQuestionAnswer.ascx");
                if (Int32.TryParse(((string[])data[i])[0], out QuestionID))
                {
                    c.eventArgs.QuestionID = QuestionID;
                }
                else
                {
                    c.eventArgs.QuestionID = i;
                }

                c.eventArgs.Question = ((string[])data[i])[1].ToString();


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

    private bool CheckData()
    {

        for (int i = 0; i < PnQuestionList.Controls.Count; i++)
        {
            switch (this.PnQuestionList.Controls[i].GetType().ToString())
            {
                case "ASP.schoolmaster_usercontrolquestionanswer_ascx":
                    SchoolMaster_UserControlQuestionAnswer c = (SchoolMaster_UserControlQuestionAnswer)PnQuestionList.Controls[i];
                    
                    if (string.IsNullOrEmpty(c.eventArgs.Answer))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1) + Resources.Resource.SMInputAnswer + "');", true);
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

        int Score = GetScore();

        string Query;
        Query = "insert into InternetStudyUserAnswer " +
                "(QuestionClassID, UserID, TotalScore, FinishTime) VALUES ('" +
                Session["QuestionClassID"].ToString() + "','" +
                Session["UserID"].ToString() + "','" +
                Score + "','" +
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

        if (ms.WriteData(Query, sb))
        {

            for (int i = 0; i < PnQuestionList.Controls.Count; i++)
            {
                switch (this.PnQuestionList.Controls[i].GetType().ToString())
                {
                    case "ASP.schoolmaster_usercontrolquestionanswer_ascx":
                        SchoolMaster_UserControlQuestionAnswer c = (SchoolMaster_UserControlQuestionAnswer)PnQuestionList.Controls[i];

                        Query = "insert into InternetStudyUserAnswerDetail " +
                        "( QuestionClassID, QuestionNo, UserChooseAnswer ) " +
                        "VALUES " +
                        "( '" + Session["QuestionClassID"].ToString() + "',N'" +
                        c.eventArgs.QuestionID + "',N'" +
                        c.eventArgs.Answer + "')";

                        ms.WriteData(Query, sb);
                        sb.Clear();
                        break;
                    default:
                        string ttt = this.PnQuestionList.Controls[i].GetType().ToString();
                        break;
                }
            }
        }

    }

    private int GetScore()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList Answer = new ArrayList();

        string Query = "select InternetStudyQuestionContent.QuestionNo, InternetStudyQuestionContent.Score, InternetStudyQuestionContent.Answer " +
                        "from InternetStudyQuestionContent where QuestionClassID = '" + Session["QuestionClassID"] + "' order by QuestionNo asc";

        int UserScore = 0;

        if (ms.GetAllColumnData(Query, Answer))
        {
            if (Answer.Count > 0)
            {                
                    for (int i = 0; i < PnQuestionList.Controls.Count; i++)
                    {
                        switch (this.PnQuestionList.Controls[i].GetType().ToString())
                        {
                            case "ASP.schoolmaster_usercontrolquestionanswer_ascx":
                                SchoolMaster_UserControlQuestionAnswer c = (SchoolMaster_UserControlQuestionAnswer)PnQuestionList.Controls[i];
                                
                                int SystemScore = Convert.ToInt32(((string[])Answer[c.eventArgs.QuestionID])[1]);
                                string SystemAnswer = ((string[])Answer[c.eventArgs.QuestionID])[2];

                                if (c.eventArgs.Answer.Equals(SystemAnswer))
                                {
                                    UserScore += SystemScore;
                                }
                                else
                                {
                                    //string[] SPSystemAnswer = SystemAnswer.Split(',');
                                    //string[] SPUserAnswer = c.eventArgs.Answer.Split(',');
                                    //for (int j = 0; j < SPSystemAnswer.Length; j++)
                                    //{
                                    //    for (int k = 0; k < SPUserAnswer.Length; k++)
                                    //    {
 
                                    //    }
                                    //}
                                    UserScore += 0;
                                }
                                
                                break;
                            default:
                                string ttt = this.PnQuestionList.Controls[i].GetType().ToString();
                                break;
                        }
                    }
                
            }
        }
        return UserScore;
        
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
                Response.Redirect("InternetStudy.aspx");
            }
        }
        else if (btn.ID == "BtnCancel")
        {
            Response.Redirect("InternetStudy.aspx");
        }
    }
}