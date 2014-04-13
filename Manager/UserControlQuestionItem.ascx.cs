using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_UserControlQuestionItem : System.Web.UI.UserControl
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
        public bool AnswerHaveEmpty = false;
        //public string[] AnswerItem = new string[]{"", "", "", ""};

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckBox[] cb = new CheckBox[] { CbQuestionItem1, CbQuestionItem2, CbQuestionItem3, CbQuestionItem4, CbQuestionItem5 };
        TextBox[] tb = new TextBox[] { TbQuestionItem1, TbQuestionItem2, TbQuestionItem3, TbQuestionItem4, TbQuestionItem5 };
        if (!IsPostBack)
        {
            // 題號
            LbQuestionNumber.Text = (eventArgs.QuestionID + 1).ToString() + ". " + Resources.Resource.TipQuestion + " ";
            // 題目內容
            TbQuestion.Text = eventArgs.Question;
            // 此題分數
            TbPassScore.Text = (eventArgs.PassScore < 0) ? "10" : eventArgs.PassScore.ToString();
            //TbAnswer.Text = eventArgs.Answer;
            //RblQuestionType.SelectedIndex = eventArgs.IsSingleSelected ? 0 : 1;

            // 單選或多選
            LbQuestionType.Text = eventArgs.IsSingleSelected ? Resources.Resource.TipSingleQuestion : Resources.Resource.TipMultiQuestion;

            int CheckCount = 0;

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
                                CheckCount++;
                                break;
                            }
                        }
                    }
                }
            }

            // 用來判斷question type
            Session["QuestionNoType_" + eventArgs.QuestionID] = CheckCount;
            LbQuestionType.Text = (CheckCount > 1) ? Resources.Resource.TipMultiQuestion : Resources.Resource.TipSingleQuestion;

            // Count 在外面設定好了
            if (eventArgs.AnswerItem.Count > 0)
            {
                TbQuestionItem1.Text = eventArgs.AnswerItem[0].ToString();
                TbQuestionItem2.Text = eventArgs.AnswerItem[1].ToString();
                TbQuestionItem3.Text = eventArgs.AnswerItem[2].ToString();
                TbQuestionItem4.Text = eventArgs.AnswerItem[3].ToString();
                TbQuestionItem5.Text = eventArgs.AnswerItem[4].ToString();
                eventArgs.AnswerItemCount = 5;
            }
            

            //// debug test
            TbQuestion.Text = "中国";

            TbQuestionItem1.Text = "1";
            TbQuestionItem2.Text = "2";
            TbQuestionItem3.Text = "3";
            TbQuestionItem4.Text = "4";
            TbQuestionItem5.Text = "5";
        }
        else
        {
            eventArgs.Question = TbQuestion.Text;

            int t = 0;
            bool IsDigit = Int32.TryParse(Session["QuestionNoType_" + eventArgs.QuestionID].ToString(), out t);
            if(IsDigit)
            {
                if (t < 2)
                {
                    eventArgs.IsSingleSelected = true;
                }
                else
                {
                    eventArgs.IsSingleSelected = false;
                }
            }

            eventArgs.Answer = string.Empty;
            int PassScore = -1;
            IsDigit = Int32.TryParse(TbPassScore.Text, out PassScore);
            if (IsDigit)
                eventArgs.PassScore = PassScore;

            for (int i = 0; i < cb.Length; i++)
            {
                if (cb[i].Checked)
                {
                    eventArgs.Answer += i + ",";
                }
            }
            eventArgs.Answer = (eventArgs.Answer.Length > 1) ? eventArgs.Answer.Substring(0, eventArgs.Answer.Length - 1) : eventArgs.Answer;

            if (eventArgs.AnswerItem.Count > 0)
            {
                eventArgs.AnswerItem[0] = TbQuestionItem1.Text;
                eventArgs.AnswerItem[1] = TbQuestionItem2.Text;
                eventArgs.AnswerItem[2] = TbQuestionItem3.Text;
                eventArgs.AnswerItem[3] = TbQuestionItem4.Text;
                eventArgs.AnswerItem[4] = TbQuestionItem5.Text;
            }
            else
            {
                eventArgs.AnswerItem.Add(TbQuestionItem1.Text);
                eventArgs.AnswerItem.Add(TbQuestionItem2.Text);
                eventArgs.AnswerItem.Add(TbQuestionItem3.Text);
                eventArgs.AnswerItem.Add(TbQuestionItem4.Text);
                eventArgs.AnswerItem.Add(TbQuestionItem5.Text);
            }
            for (int i = 0; i < eventArgs.AnswerItem.Count; i++)
            {
                if (tb[i].Text.Equals(""))
                {
                    eventArgs.AnswerHaveEmpty = true;
                    break;
                }
            }
            eventArgs.AnswerItemCount = eventArgs.AnswerItem.Count;

        }
    }
    protected void CbQuestionItem_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        if (cb.Checked)
        {
            int count = 0;
            bool IsDigit = Int32.TryParse(Session["QuestionNoType_" + eventArgs.QuestionID].ToString(), out count);
            if (IsDigit)
            {
                Session["QuestionNoType_" + eventArgs.QuestionID] = ++count;
                if (count > 1)
                    LbQuestionType.Text = Resources.Resource.TipMultiQuestion;
                else
                    LbQuestionType.Text = Resources.Resource.TipSingleQuestion;
            }
        }
        else
        {
            int count = 0;
            bool IsDigit = Int32.TryParse(Session["QuestionNoType_" + eventArgs.QuestionID].ToString(), out count);
            if (IsDigit)
            {
                Session["QuestionNoType_" + eventArgs.QuestionID] = --count;
                if (count > 1)
                    LbQuestionType.Text = Resources.Resource.TipMultiQuestion;
                else
                    LbQuestionType.Text = Resources.Resource.TipSingleQuestion;
            }
        }
    }
}