﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_InternetStudyEditModify : System.Web.UI.Page
{
    private const int QuestionMaxNumbers = 10;
    private const string RegressionString = "http://player.youku.com/player.php/sid/";
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "" || string.IsNullOrEmpty(Request["QuestionClassID"]))
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");

        // test
        //Session["QuestionClassID"] = "1";
        //Session["QuestionClassYear"] = "104";
        //Session["ClassID"] = "1";
        // test

        BaseClass bc = new BaseClass();
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();

        //string DecryptQuestionID = bc.decryption(Request["QuestionClassID"]);
        //Session["QuestionClassID"] = DecryptQuestionID;
        //string DecryptQuestionClassYear = bc.decryption(Request["QuestionClassYear"]);
        //Session["QuestionClassYear"] = DecryptQuestionClassYear;
        //string DecryptClassID = bc.decryption(Request["ClassID"]);
        //Session["ClassID"] = DecryptClassID;

        Session["QuestionClassID"] = Request["QuestionClassID"];

        Session["QuestionClassYear"] = Request["QuestionClassYear"];

        Session["ClassID"] = Request["ClassID"];

        string Query = string.Empty;
        Query = "select count(*) from InternetStudy where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
        if (ms.GetRowNumbers(Query, sb))
        {
            int Digit = -1;
            bool IsDigit = Int32.TryParse(Session["QuestionClassID"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.TipDataLose + "，SORRY!');", true);
                return;
            }

            IsDigit = Int32.TryParse(Session["QuestionClassYear"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.TipDataLose + "，SORRY!');", true);
                return;
            }

            IsDigit = Int32.TryParse(Session["ClassID"].ToString(), out Digit);
            if (!IsDigit)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.TipDataLose + "，SORRY!');", true);
                return;
            }

            Query = "select ClassName, ClassDescription, PassScore, QuestionURL from InternetStudy where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.GetAllColumnData(Query, data);
            if (data.Count > 0)
            {
                TbTitle.Text = ((string[])data[0])[0].ToString();
                TbDescription.Text = ((string[])data[0])[1].ToString();
                TbPassScore.Text = ((string[])data[0])[2].ToString();
                TbURL.Text = ((string[])data[0])[3].ToString();
                if (((string[])data[0])[3].ToString().Contains(RegressionString))
                {
                    LbUrl.Text = "<embed src='" + ((string[])data[0])[3].ToString() + "' allowFullScreen='true' quality='high' width='" + Resources.Resource.VideoWidth + "' height='" + Resources.Resource.VideoHeight + "' align='middle' allowScriptAccess='always' type='application/x-shockwave-flash'></embed>";
                }
            }
            data.Clear();

            

            Query = "select QuestionNo, QuestionContent, IsSingleSelection, Score, Answer from InternetStudyQuestionContent where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "' " +
                    "order by QuestionNo asc";
            ms.GetAllColumnData(Query, data);

            for (int i = 0; i < QuestionMaxNumbers; i++)
            {
                ArrayList ALAnswerItem = new ArrayList();
                bool IsSingleSelect = false;
                int QuestionID = -1;
                int PassScore = -1;


                Manager_UserControlQuestionItem c = (Manager_UserControlQuestionItem)LoadControl("UserControlQuestionItem.ascx");
                if (Int32.TryParse(((string[])data[i])[0], out QuestionID))
                {
                    c.eventArgs.QuestionID = QuestionID;
                }
                else
                {
                    c.eventArgs.QuestionID = i;
                }

                c.eventArgs.Question = ((string[])data[i])[1].ToString();

                if (bool.TryParse(((string[])data[i])[2], out IsSingleSelect))
                {
                    c.eventArgs.IsSingleSelected = IsSingleSelect;
                }
                else
                {
                    c.eventArgs.IsSingleSelected = true;
                }


                if (Int32.TryParse(((string[])data[i])[3], out PassScore))
                {
                    c.eventArgs.PassScore = PassScore;
                }
                else
                {
                    c.eventArgs.PassScore = 0;
                }


                c.eventArgs.Answer = ((string[])data[i])[4].ToString();



                Query = "select QuestionAnswerNumbers, AnswerContent from InternetStudyQuestionItem where QuestionClassID ='" + Session["QuestionClassID"].ToString() + "' " +
                        "and QuestionNo = '" + c.eventArgs.QuestionID + "' order by QuestionAnswerNumbers asc";

                ms.GetAllColumnData(Query, ALAnswerItem);
                if (ALAnswerItem.Count > 0)
                {
                    for (int j = 0; j < ALAnswerItem.Count; j++)
                    {
                        c.eventArgs.AnswerItem.Add(((string[])ALAnswerItem[j])[1]);
                    }

                }
                //c.eventArgs.QuestionContent = ;
                //c.cClick += new userControl_questionTest.questionClick(c_cClick);
                //PnQuestion.Controls.Add(c);
                PnQuestionList.Controls.Add(c);
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool CheckData()
    {
        if (string.IsNullOrEmpty(TbTitle.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMTitleEmpty + "');", true);
            return false;
        }
        else if (string.IsNullOrEmpty(TbDescription.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMDescriptionEmpty + "');", true);
            return false;
        }
        else if (string.IsNullOrEmpty(TbPassScore.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMPassScoreEmpty + "');", true);
            return false;
        }
        else if (string.IsNullOrEmpty(TbURL.Text))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMURLEmpty + "');", true);
            return false;
        }
        else if (!TbURL.Text.Contains(RegressionString))
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMURLError + "');", true);
        }

        int PassScore = -1;
        bool IsDigit = Int32.TryParse(TbPassScore.Text, out PassScore);

        if (!IsDigit)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMPassScoreIsNumber + "');", true);
            return false;
        }
        if (PassScore < 0 && 100 < PassScore)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMPassScroeRange + "');", true);
            return false;
        }

        //for (int i = 0; i < PnQuestionList.Controls.Count; i++)
        //{
        //    switch (this.PnQuestionList.Controls[i].GetType().ToString())
        //    {
        //        case "ASP.manager_usercontrolquestionitem_ascx":
        //            Manager_UserControlQuestionItem c = (Manager_UserControlQuestionItem)PnQuestionList.Controls[i];
        //            if (c.eventArgs.PassScore < 0)
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID+1) + Resources.Resource.SMScoreLessZero + "');", true);
        //                return false;
        //            }
        //            else if (string.IsNullOrEmpty(c.eventArgs.Answer))
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1) + Resources.Resource.SMInputAnswer + "');", true);
        //                return false;
        //            }
        //            else if (string.IsNullOrEmpty(c.eventArgs.Question))
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1) + Resources.Resource.SMInputQuestion + "');", true);
        //                return false;
        //            }
        //            else if (c.eventArgs.AnswerItemCount < 2)
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1) + Resources.Resource.SMInputQuestionItem + "');", true);
        //                return false;
        //            }
        //            else if (c.eventArgs.AnswerHaveEmpty)
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('第" + (c.eventArgs.QuestionID + 1) + Resources.Resource.SMAnswerHaveEmpty + "');", true);
        //                return false;
        //            }


        //            break;
        //        default:
        //            break;
        //    }
        //}
        return true;
    }
    private void UploadData()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        // 資料庫有問題，InternetStudyQuestionItem必須重新設計

        // get data must be add QuestionYear, ClassID
        // and in addYear, must insert data to table.
        // in this, must to update
        string Query;
        Query = "Update InternetStudy set " +
                "ClassName = N'" + TbTitle.Text + "'," +
                "ClassDescription = N'" + TbDescription.Text + "'," +
                "PassScore = N'" + TbPassScore.Text + "'," +
                "QuestionURL = N'" + TbURL.Text + "' " +
                "where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";

        if (ms.WriteData(Query, sb))
        {
            sb.Clear();

            Query = "delete from InternetStudyQuestionContent where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.WriteData(Query, sb);
            sb.Clear();

            // 先刪除再新增資料
            Query = "delete from InternetStudyQuestionItem where QuestionClassID = '" + Session["QuestionClassID"].ToString() + "'";
            ms.WriteData(Query, sb);
            sb.Clear();

            for (int i = 0; i < PnQuestionList.Controls.Count; i++)
            {
                //string t = pn_main.Controls[i].GetType().ToString();
                switch (this.PnQuestionList.Controls[i].GetType().ToString())
                {
                    case "ASP.manager_usercontrolquestionitem_ascx":
                        Manager_UserControlQuestionItem c = (Manager_UserControlQuestionItem)PnQuestionList.Controls[i];


                        Query = "insert into InternetStudyQuestionContent " +
                                "( QuestionClassID, QuestionNo, QuestionContent, IsSingleSelection, Score, Answer ) " +
                                "VALUES " +
                                "( '" + Session["QuestionClassID"].ToString() + "',N'" + 
                                c.eventArgs.QuestionID + "',N'" + 
                                c.eventArgs.Question + "',N'" + 
                                c.eventArgs.IsSingleSelected + "',N'" + 
                                c.eventArgs.PassScore + "',N'" +
                                c.eventArgs.Answer + "')";
                        
                        ms.WriteData(Query, sb);
                        sb.Clear();

                        //Query = "update InternetStudyQuestionContent set " +
                        //        "QuestionContent = '" + c.eventArgs.Question + "'," +
                        //        "IsSingleSelection = '" + c.eventArgs.IsSingleSelected + "'," +
                        //        "Score = '" + c.eventArgs.PassScore + "'," +
                        //        "Answer = '" + c.eventArgs.Answer + "' " +
                        //        "where " + 
                        //        "QuestionClassID = '" + Session["QuestionClassID"].ToString() + "' and " +
                        //        "QuestionNo = '" + c.eventArgs.QuestionID + "'";                                
                        //ms.WriteData(Query, sb);
                        //sb.Clear();

                        

                        for (int j = 0; j < c.eventArgs.AnswerItemCount; j++)
                        {
                            //StringBuilder sb = new StringBuilder();
                            Query = "insert into InternetStudyQuestionItem (QuestionClassID, QuestionNo, QuestionAnswerNumbers, AnswerContent) " +
                                    "VALUES " +
                                    "('" + Session["QuestionClassID"].ToString() + "',N'" +
                                    c.eventArgs.QuestionID + "',N'" +
                                    j + "',N'" +
                                    c.eventArgs.AnswerItem[j] + "')";
                            ms.WriteData(Query, sb);
                            sb.Clear();
                        }
                        //for (int j = 0; j < c.eventArgs.AnswerItemCount; j++)
                        //{
                        //    Query = "update InternetStudyQuestionItem set " +
                        //            "QuestionAnswerNumbers = '" + j + "'," +
                        //            "AnswerContent = '" + c.eventArgs.AnswerItem[j] + "'," +
                        //            "where " +
                        //            "QuestionClassID = '" + Session["QuestionClassID"].ToString() + "' and " +
                        //            "QuestionNo = '" + c.eventArgs.QuestionID + "'";
                        //    ms.WriteData(Query, sb);
                        //}

                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            return;
        }

    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnSubmit")
        {
            bool CheckPass = CheckData();
            if (CheckPass)
            {
                UploadData();
                if (Session["AddYearTag"] != null)
                {
                    Response.Redirect("InternetStudyEditAddYear.aspx");
                }
                else
                {
                    Response.Redirect("InternetStudyEdit.aspx");
                }
            }
        }
        else if (btn.ID == "BtnCancel")
        {
            if (Session["AddYearTag"] != null)
            {
                Response.Redirect("InternetStudyEditAddYear.aspx");
            }
            else
            {
                Response.Redirect("InternetStudyEdit.aspx");
            }
        }
        else if (btn.ID == "BtnPreview")
        {
            if (TbURL.Text.Contains(RegressionString))
            {
                LbUrl.Text = "<embed src='" + TbURL.Text + "' allowFullScreen='true' quality='high' width='" + Resources.Resource.VideoWidth + "' height='" + Resources.Resource.VideoHeight + "' align='middle' allowScriptAccess='always' type='application/x-shockwave-flash'></embed>";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + Resources.Resource.SMURLError + "');", true);
            }
        }
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../SystemManagerIndex.aspx");
    }
}