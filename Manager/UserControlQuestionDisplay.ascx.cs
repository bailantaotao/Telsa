using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_UserControlQuestionDisplay : System.Web.UI.UserControl
{
    /** 自訂義事件 */
    public MyEventArgs eventArgs = new MyEventArgs();

    /** 自訂義class，繼承eventargs，好將資料傳回main form */
    public class MyEventArgs : EventArgs
    {
        // 目前此form的問卷編號
        public int QuestionID = -1;
        public string Question = string.Empty;
        public bool IsSingleSelected = true;
        public int PassScore = -1;
        public string Answer = string.Empty;
        public ArrayList AnswerItem = new ArrayList();
        public int AnswerItemCount = -1;
        //public string[] AnswerItem = new string[]{"", "", "", ""};

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LbQuestionNumber.Text = (eventArgs.QuestionID + 1).ToString() + ". 題目: ";
            LbQuestion.Text = eventArgs.Question;
            LbPassScore.Text = (eventArgs.PassScore < 0) ? "0" : eventArgs.PassScore.ToString();
            LbAnswer.Text = eventArgs.Answer;
            LbQuestionType.Text = eventArgs.IsSingleSelected ? "單選題" : "多選題";
            if (eventArgs.AnswerItem.Count > 0)
            {
                LbQuestionItem1.Text = eventArgs.AnswerItem[0].ToString();
                LbQuestionItem2.Text = eventArgs.AnswerItem[1].ToString();
                LbQuestionItem3.Text = eventArgs.AnswerItem[2].ToString();
                LbQuestionItem4.Text = eventArgs.AnswerItem[3].ToString();
                eventArgs.AnswerItemCount = 4;
            }
            //LbQuestion.Text = "222";
            //LbAnswer.Text = "123213";
            //LbQuestionItem1.Text = "1";
            //LbQuestionItem2.Text = "2";
            //LbQuestionItem3.Text = "3";
            //LbQuestionItem4.Text = "4";
        }
        else
        {
            

        }
    }
}