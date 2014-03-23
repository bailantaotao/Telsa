using System;
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
        public string QuestionContent = string.Empty;
        public string[] QuestionAnswer;
        public int UserAnswer = -1;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LbQuestion.Text = eventArgs.QuestionID + ". " + eventArgs.QuestionContent;
            for (int i = 0; i < eventArgs.QuestionContent.Length; i++)
                RblQuestionChoose.Items[i].Text = eventArgs.QuestionAnswer[i];
        }
        else
        {
            eventArgs.UserAnswer = RblQuestionChoose.SelectedIndex;
        }
    }
}