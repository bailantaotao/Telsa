using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_UserControlComment : System.Web.UI.UserControl
{
    public MyEventArgs eventArgs = new MyEventArgs();

    /** 自訂義class，繼承eventargs，好將資料傳回main form */
    public class MyEventArgs : EventArgs
    {
        public string CommentUUID = string.Empty;
        public string SchoolMasterName = string.Empty;
        public string SchoolName = string.Empty;
        public string Comment = string.Empty;
        public string CommentTime = string.Empty;

        public bool IsOwner = false;

    }

    /** 自訂上傳click */
    public delegate void questionClick(object sender, MyEventArgs e);

    /** 定義上傳的事件函數 */
    public event questionClick cClick;

    /** 當main form 點擊上傳時會進到此function */
    private void WebUserControl_Click(object sender, MyEventArgs e)
    {
        if (cClick != null)
        {
            cClick(sender, e);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        LbTitle.Text = eventArgs.SchoolName + " - " + eventArgs.SchoolMasterName;
        LbTime.Text = eventArgs.CommentTime;
        LbComment.Text = eventArgs.Comment;
        ImgBtnDelete.Visible = eventArgs.IsOwner;
        
    }


    protected void ImgBtnDelete_Click(object sender, ImageClickEventArgs e)
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        string query = "delete from InternetStudyComment where AutoUUID ='" +
                        eventArgs.CommentUUID + "'";
        if (ms.WriteData(query, sb))
        {
            int Digit = -1;
            bool isDigit = Int32.TryParse(sb.ToString(), out Digit);
            if (!isDigit)
                return;
            if(Digit == 1)
                WebUserControl_Click(this, eventArgs);            
        }
        
    }
}