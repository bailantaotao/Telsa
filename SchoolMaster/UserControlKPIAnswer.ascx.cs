using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_UserControlKPIAnswer : System.Web.UI.UserControl
{
    /** 自訂義事件 */
    public MyEventArgs eventArgs = new MyEventArgs();

    /** 自訂義class，繼承eventargs，好將資料傳回main form */
    public class MyEventArgs : EventArgs
    {
        // 目前此form的問卷編號
        
        public string DomainID = "-1";
        public string ClassID = "-1";
        public string Question = string.Empty;
        public ArrayList DescriptionItem = new ArrayList();        
		public ArrayList AnswerItem = new ArrayList();
        public string UserAnswer = string.Empty;
        public bool Finish = false;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // (1-1)- 我是題目
            LbQuestion.Text = "(" + (eventArgs.DomainID).ToString() + "-" + (eventArgs.ClassID).ToString() + ")- " + eventArgs.Question;

            // 敘述
            if (eventArgs.DescriptionItem.Count > 0)
            {
                if (eventArgs.DescriptionItem.Count == 1)
                {
                    foreach (string desc in eventArgs.DescriptionItem)
                    {
                        LbDescription.Text += desc;
                    }
                }
                else
                {
                    int Index = 0;
                    foreach (string desc in eventArgs.DescriptionItem)
                    {
                        LbDescription.Text += "(" + (++Index) + ")- " + desc + "<br />";
                    }
                }
            }
            else
            {
                LbDescription.Text = " N / A";
            }

            // 評量標準
            if (eventArgs.AnswerItem.Count > 0)
            {
                for (int i = 0; i < eventArgs.AnswerItem.Count; i++)
                {
                    string[] sItem = (string[])eventArgs.AnswerItem[i];
                    ListItem li = new ListItem(sItem[1] + "，" + sItem[2], sItem[1]);
                    RblItem.Items.Add(li);
                }
                //if (eventArgs.AnswerItem.Count > 0)
                //    RblItem.Items[0].Selected = true;
            }
        }
        else
        {
            
            foreach (ListItem li in RblItem.Items)
            {
                if (li.Selected)
                {
                    eventArgs.UserAnswer = li.Value;
                    eventArgs.Finish = true;
                    break;
                }
            }            
        }
    }
}