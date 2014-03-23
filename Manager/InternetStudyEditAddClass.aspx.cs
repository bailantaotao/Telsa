using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEditAddClass : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {


        for (int i = 0; i < 10 ; i++)
        {
            Manager_UserControlQuestion c = (Manager_UserControlQuestion)LoadControl("UserControlQuestion.ascx");
            c.eventArgs.QuestionID = (i + 1).ToString();
            //c.eventArgs.QuestionContent = ;
            //c.cClick += new userControl_questionTest.questionClick(c_cClick);
            //PnQuestion.Controls.Add(c);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}