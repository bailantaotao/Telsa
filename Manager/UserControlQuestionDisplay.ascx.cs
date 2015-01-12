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
        CheckBox[] cb = new CheckBox[] { CbQuestionItem1, CbQuestionItem2, CbQuestionItem3, CbQuestionItem4, CbQuestionItem5 };
        if (!IsPostBack)
        {
            // 題號
            LbQuestionNumber.Text = (eventArgs.QuestionID + 1).ToString() + ". ";// +Resources.Resource.TipQuestion + " ";
            // 題目內容
            LbQuestion.Text = eventArgs.Question;
            // 此題分數
            LbPassScore.Text = (eventArgs.PassScore < 0) ? "0" : eventArgs.PassScore.ToString();
            //LbAnswer.Text = eventArgs.Answer;

            

            // 答案勾選
            if (!string.IsNullOrEmpty(eventArgs.Answer))
            {
                string[] index = eventArgs.Answer.Split(',');

                for (int i = 0; i < cb.Length; i++)
                {
                    for (int j = 0; j < index.Length; j++)
                    {
                        int t = -1;
                        bool IsDigit = Int32.TryParse(index[j], out t);
                        if (IsDigit)
                        {
                            if (i == t)
                            {
                                cb[i].Checked = true;
                                break;
                            }
                        }
                    }
                }
            }

            LbQuestionType.Text = eventArgs.IsSingleSelected ? Resources.Resource.TipSingleQuestion : Resources.Resource.TipMultiQuestion;
            if (eventArgs.AnswerItem.Count > 0)
            {
                LbQuestionItem1.Text = eventArgs.AnswerItem[0].ToString();
                LbQuestionItem2.Text = eventArgs.AnswerItem[1].ToString();
                LbQuestionItem3.Text = eventArgs.AnswerItem[2].ToString();
                LbQuestionItem4.Text = eventArgs.AnswerItem[3].ToString();
                LbQuestionItem5.Text = eventArgs.AnswerItem[4].ToString();
                eventArgs.AnswerItemCount = 5;
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