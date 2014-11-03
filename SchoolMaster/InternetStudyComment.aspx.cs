using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_InternetStudyComment : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;
    public string backgroundImage = Resources.Resource.ImgUrlBackground;
    private const string QuestionClassID = "QuestionClassID";
    private const string QuestionClassYear = "QuestionClassYear";
    private const string ClassID = "ClassID";

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("SessionOut.aspx");
        Session["QuestionClassID"] = Request["QuestionClassID"];
        LoadInternetStudyComment(1);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }


    private void LoadInternetStudyComment(int Select)
    {
        PnComment.Controls.Clear();
        Query = "select Account.UserName, InternetStudyComment.UserComment, Account.School, InternetStudyComment.CommentTime, InternetStudyComment.AutoUUID, Account.UserId from InternetStudyComment " +
        "left join Account on Account.UserID = InternetStudyComment.UserID " +
        "where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "' " +
        "order by CommentTime desc";

        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        BaseClass bc = new BaseClass();

        if (ms.GetAllColumnData(Query, data))
        {
            LbCompleted.Text = "";
            LbCompleted.Text += "<table style='width: 700px; border-top: solid 3px orange; border-bottom: solid 3px orange' >";
            

            LbTotalCount.Text = Resources.Resource.TipTotal + " " + data.Count.ToString() + " " + Resources.Resource.TipNumbers;

            if (data.Count > 0)
            {
                //Setting pagings
                DataPage = data.Count / 10;

                if (data.Count % 10 != 0)
                    DataPage++;

                //Paging
                DdlPageSelect.Items.Clear();

                for (int j = 1; j <= DataPage; j++)
                {
                    DdlPageSelect.Items.Add(j.ToString());
                }

                DdlPageSelect.SelectedIndex = Select - 1;

                if (DataPage != 0)
                {
                    PageOrder.Text = Select.ToString() + " / " + DataPage.ToString();
                }

                Flag = 0;

                Count = (Select - 1) * 10;
                int Max = 0;
                if (Count + 10 < data.Count)
                {
                    Max = Count + 10;
                }
                else
                {
                    Max = data.Count;
                }

                for (int i = Count; i < Max; i++)
                {
                    SchoolMaster_UserControlComment c = (SchoolMaster_UserControlComment)LoadControl("UserControlComment.ascx");

                    c.eventArgs.SchoolMasterName = ((string[])(data[i]))[0];
                    c.eventArgs.SchoolName = ((string[])(data[i]))[2];
                    c.eventArgs.Comment = ((string[])(data[i]))[1];
                    c.eventArgs.CommentTime = ((string[])(data[i]))[3];
                    c.eventArgs.IsOwner = ((string[])(data[i]))[5].Equals(Session["UserID"].ToString());
                    c.eventArgs.CommentUUID = ((string[])(data[i]))[4];
                    c.cClick += c_cClick;
                    c.ID = i.ToString();
                    PnComment.Controls.Add(c);


                    //LbCompleted.Text += "<tr>";
                    //LbCompleted.Text += "<td align='left' style='width:50%; padding-left:30px;font-weight:900'>";
                    //LbCompleted.Text += ((string[])(data[i]))[0] + " - " + ((string[])(data[i]))[2] ;
                    //LbCompleted.Text += "</td>";
                    //LbCompleted.Text += "<td align='right' style='width:50%;'>";
                    //LbCompleted.Text += ((string[])(data[i]))[3];
                    //LbCompleted.Text += "</td>";
                    //LbCompleted.Text += "</tr>";
                    //LbCompleted.Text += "<tr>";
                    //LbCompleted.Text += "<td colspan='2' align='left' style='padding-left:30px; border-bottom: 1px solid Orange; word-break: break-all; width:700px'>";
                    //LbCompleted.Text += ((string[])(data[i]))[1];
                    //LbCompleted.Text += "</td>";
                    //LbCompleted.Text += "</tr>";

                    Flag++;
                }
            }
            else
            {
                LbCompleted.Text += "<tr align='center' style='background-color:#00FFFF;' colspan = '5'>";
                LbCompleted.Text += "<td colspan = '5' style='border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #00FFFF;'>";
                LbCompleted.Text += Resources.Resource.TipNoComment + "</td>";
                LbCompleted.Text += "</tr>";

                LbTotalCount.Text = Resources.Resource.TipTotal + " 0 " + Resources.Resource.TipNumbers; ;
                PageOrder.Text = "0 / 0";
            }
            LbCompleted.Text += "</table>";
        }
    }

    void c_cClick(object sender, SchoolMaster_UserControlComment.MyEventArgs e)
    {
        Response.AddHeader("Refresh", "0");
    }

    private string GetEncryptionString(string Tag, string Data)
    {
        //BaseClass bc = new BaseClass();
        //return (Tag + "=" +bc.encryption(Data));
        BaseClass bc = new BaseClass();
        return (Tag + "=" + Data);
    }

    private bool CheckData()
    {
        if (string.IsNullOrEmpty(TbComment.Text))
        {
            return false;
        }
        return true;
    }

    private void UploadData()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        Query = "insert into InternetStudyComment (" +
                "QuestionClassID, UserID, UserComment, CommentTime ) VALUES ('" +
                Session["QuestionClassID"].ToString() + "','" +
                Session["UserID"].ToString() + "','" +
                TbComment.Text + "','" +
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";

        ms.WriteData(Query, sb);

    }


    protected void PageSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadInternetStudyComment(DdlPageSelect.SelectedIndex + 1);
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnComment")
        {
            if (CheckData())
            {                
                UploadData();
                LoadInternetStudyComment(1);
                TbComment.Text = "";
                Response.AddHeader("Refresh", "0");
            }
        }
        else if (btn.ID == "BtnBack")
        {
            Response.Redirect("InternetStudy.aspx");
        }
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}