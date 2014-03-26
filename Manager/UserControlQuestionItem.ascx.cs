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
        //public string[] AnswerItem = new string[]{"", "", "", ""};

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LbQuestionNumber.Text = (eventArgs.QuestionID + 1).ToString() + ". 題目: ";
            TbQuestion.Text = eventArgs.Question;
            TbPassScore.Text = (eventArgs.PassScore < 0) ? "0" : eventArgs.PassScore.ToString();
            TbAnswer.Text = eventArgs.Answer;
            RblQuestionType.SelectedIndex = eventArgs.IsSingleSelected ? 0 : 1;
            if (eventArgs.AnswerItem.Count > 0)
            {
                TbQuestionItem1.Text = eventArgs.AnswerItem[0].ToString();
                TbQuestionItem2.Text = eventArgs.AnswerItem[1].ToString();
                TbQuestionItem3.Text = eventArgs.AnswerItem[2].ToString();
                TbQuestionItem4.Text = eventArgs.AnswerItem[3].ToString();
                TbQuestionItem5.Text = eventArgs.AnswerItem[4].ToString();
                eventArgs.AnswerItemCount = 5;
            }
            //TbQuestion.Text = "中国";
            //TbAnswer.Text = "123213";
            //TbQuestionItem1.Text = "1";
            //TbQuestionItem2.Text = "2";
            //TbQuestionItem3.Text = "3";
            //TbQuestionItem4.Text = "4";
        }
        else
        {
            eventArgs.Question = TbQuestion.Text;
            eventArgs.IsSingleSelected = (RblQuestionType.SelectedIndex == 0) ? true : false;
            int PassScore = -1;
            bool IsDigit = Int32.TryParse(TbPassScore.Text, out PassScore);
            if (IsDigit)
                eventArgs.PassScore = PassScore;
            eventArgs.Answer = TbAnswer.Text;
            /** 將來要改成動態新增答案選項 */
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
            eventArgs.AnswerItemCount = eventArgs.AnswerItem.Count;

        }
    }
}