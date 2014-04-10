using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_UserControlQuestionAnswer : System.Web.UI.UserControl
{
    /** 自訂義事件 */
    public MyEventArgs eventArgs = new MyEventArgs();

    /** 自訂義class，繼承eventargs，好將資料傳回main form */
    public class MyEventArgs : EventArgs
    {
        // 目前此form的問卷編號
        public int QuestionID = -1;
        public string Question = string.Empty;

        public string Answer = string.Empty;
		public ArrayList AnswerItem = new ArrayList();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox[] cb = new CheckBox[] { CbQuestionItem1, CbQuestionItem2, CbQuestionItem3, CbQuestionItem4, CbQuestionItem5 };
        if (!IsPostBack)
        {
            // 題號
            LbQuestionNumber.Text = (eventArgs.QuestionID + 1).ToString() + ". " + Resources.Resource.TipQuestion + " ";
            // 題目內容
            LbQuestion.Text = eventArgs.Question;
			if (eventArgs.AnswerItem.Count > 0)
            {
                LbQuestionItem1.Text = eventArgs.AnswerItem[0].ToString();
                LbQuestionItem2.Text = eventArgs.AnswerItem[1].ToString();
                LbQuestionItem3.Text = eventArgs.AnswerItem[2].ToString();
                LbQuestionItem4.Text = eventArgs.AnswerItem[3].ToString();
                LbQuestionItem5.Text = eventArgs.AnswerItem[4].ToString();
            }
        }
        else
        {
            for (int i = 0; i < cb.Length; i++)
            {
                if (cb[i].Checked)
                {
                    eventArgs.Answer += i + ",";
                }
            }
            eventArgs.Answer = (eventArgs.Answer.Length > 1) ? eventArgs.Answer.Substring(0, eventArgs.Answer.Length - 1) : eventArgs.Answer;

        }
    }
}