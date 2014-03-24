using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_UserControlQuestion : System.Web.UI.UserControl
{
    /** 自訂義事件 */
    public MyEventArgs eventArgs = new MyEventArgs();

    /** 自訂義class，繼承eventargs，好將資料傳回main form */
    public class MyEventArgs : EventArgs
    {
        // 目前此form的問卷編號
        public string QuestionID = string.Empty;
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
            LbQuestionNumber.Text = eventArgs.QuestionID + ". 題目: ";
            
        }
        else
        {
            eventArgs.Question = TbQuestion.Text;
            eventArgs.IsSingleSelected = (RblQuestionType.SelectedIndex == 0) ? true : false;
            int PassScore = -1;
            bool IsDigit = Int32.TryParse(TbPassScore.Text, out PassScore);
            if(IsDigit)
                eventArgs.PassScore = PassScore;
            eventArgs.Answer = TbAnswer.Text;
            /** 將來要改成動態新增答案選項 */
            //eventArgs.AnswerItem.Add(TbQuestionItem1.Text);
            //eventArgs.AnswerItem.Add(TbQuestionItem2.Text);
            //eventArgs.AnswerItem.Add(TbQuestionItem3.Text);
            //eventArgs.AnswerItem.Add(TbQuestionItem4.Text);
            eventArgs.AnswerItem.Add("1");
            eventArgs.AnswerItem.Add("2");
            eventArgs.AnswerItem.Add("3");
            eventArgs.AnswerItem.Add("4");
            eventArgs.AnswerItemCount = eventArgs.AnswerItem.Count;
            
        }
    }


}