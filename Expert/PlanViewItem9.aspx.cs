using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanViewItem9 : System.Web.UI.Page
{
    private const int ClassMaxNumbers = 10;
    private int DataPage = 0, Flag = 0, Count = 0;
    private string Query = string.Empty;

    private bool IsMingDer = false;
    private string sn = string.Empty;
    private string year = string.Empty;
    private string modified = string.Empty;

    private const string SN = "SN";
    private const string YEAR = "YEAR";
    private const string MODIFIED = "MODIFIED";

    private StringBuilder schoolName = new StringBuilder();

    public string backgroundImage = Resources.Resource.ImgUrlBackground;



    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("1"))
            Response.Redirect("../SessionOut.aspx");
        if (Session["IsMingDer"].ToString().Equals("True"))
        {
            IsMingDer = true;
            switchControlItem();
            BtnStore.Visible = false;
            BtnCancel.Text = Resources.Resource.BtnBack;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        LbYear.Text = Session["PlanYear"].ToString();
        if (!IsPostBack)
        {
            setInitial();            
        }
        if(!IsMingDer)
            setAttribute();
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {         
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString()+"&SCHOOLNAME="+Session["SCHOOLNAME"].ToString());
    }

    private void switchControlItem()
    {
        for (int i = 0; i < Panel1.Controls.Count; i++)
        {
            //string t = pn_main.Controls[i].GetType().ToString();
            switch (this.Panel1.Controls[i].GetType().ToString())
            {
                case "System.Web.UI.WebControls.Label":
                    Label lb = (Label)this.Panel1.Controls[i];
                    lb.Visible = true;
                    break;
                case "System.Web.UI.LiteralControl":
                    break;
                case "System.Web.UI.WebControls.DropDownList":
                    DropDownList ddl = (DropDownList)this.Panel1.Controls[i];
                    ddl.Visible = false;
                    break;
                case "System.Web.UI.WebControls.TextBox":
                    TextBox tb = (TextBox)this.Panel1.Controls[i];
                    tb.Visible = false;
                    break;
                default:
                    string t2 = this.Panel1.Controls[i].GetType().ToString();
                    break;
            }
        }
    }

    private void setAttribute()
    {

        LbRC04.Attributes.Add("readonly", "true");
        LbRC05.Attributes.Add("readonly", "true");
        LbRC14.Attributes.Add("readonly", "true");
        LbRC15.Attributes.Add("readonly", "true");
        LbRC24.Attributes.Add("readonly", "true");
        LbRC25.Attributes.Add("readonly", "true");
        LbRC34.Attributes.Add("readonly", "true");
        LbRC35.Attributes.Add("readonly", "true");
        LbRC44.Attributes.Add("readonly", "true");
        LbRC45.Attributes.Add("readonly", "true");
        LbRC54.Attributes.Add("readonly", "true");
        LbRC55.Attributes.Add("readonly", "true");
        LbRC64.Attributes.Add("readonly", "true");
        LbRC65.Attributes.Add("readonly", "true");
        LbRC74.Attributes.Add("readonly", "true");
        LbRC75.Attributes.Add("readonly", "true");
        LbRC84.Attributes.Add("readonly", "true");
        LbRC85.Attributes.Add("readonly", "true");

    }

    private void setInitial()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select DimensionsID, NO, Solution, UnSolution, CheckUser, TitleDepart, StartTime, EndTime, Support " +
                       "from PlanMonitor " +
                       "where SN ='" + Session["UserPlanListSN"].ToString() + "' order by DimensionsID asc, NO asc";

        ms.GetAllColumnData(query, data);

        for (int i = 0; i < data.Count; i++)
        {
            string[] d = (string[])data[i];
            if (IsMingDer)
            {
                if (d[0].Equals("1"))
                {
                    if (d[1].Equals("1"))
                    {
                        LbRC00.Text = externalFeedBack(d[2]);
                        LbRC01.Text = externalFeedBack(d[3]);
                        LbRC021.Text = externalFeedBack(d[4]);
                        LbRC031.Text = externalFeedBack(d[5]);
                        LbRC041.Text = splitData(d[6]);
                        LbRC051.Text = splitData(d[7]);
                        LbRC061.Text = externalFeedBack(d[8]);
                    }
                    else if (d[1].Equals("2"))
                    {
                        LbRC10.Text = externalFeedBack(d[2]);
                        LbRC11.Text = externalFeedBack(d[3]);
                        LbRC121.Text = externalFeedBack(d[4]);
                        LbRC131.Text = externalFeedBack(d[5]);
                        LbRC141.Text = splitData(d[6]);
                        LbRC151.Text = splitData(d[7]);
                        LbRC161.Text = externalFeedBack(d[8]);
                    }
                    else if (d[1].Equals("3"))
                    {
                        LbRC20.Text = externalFeedBack(d[2]);
                        LbRC21.Text = externalFeedBack(d[3]);
                        LbRC221.Text = externalFeedBack(d[4]);
                        LbRC231.Text = externalFeedBack(d[5]);
                        LbRC241.Text = splitData(d[6]);
                        LbRC251.Text = splitData(d[7]);
                        LbRC261.Text = externalFeedBack(d[8]);
                    }
                }
                else if (d[0].Equals("2"))
                {
                    if (d[1].Equals("1"))
                    {
                        LbRC30.Text = externalFeedBack(d[2]);
                        LbRC31.Text = externalFeedBack(d[3]);
                        LbRC321.Text = externalFeedBack(d[4]);
                        LbRC331.Text = externalFeedBack(d[5]);
                        LbRC341.Text = splitData(d[6]);
                        LbRC351.Text = splitData(d[7]);
                        LbRC361.Text = externalFeedBack(d[8]);
                    }
                    else if (d[1].Equals("2"))
                    {
                        LbRC40.Text = externalFeedBack(d[2]);
                        LbRC41.Text = externalFeedBack(d[3]);
                        LbRC421.Text = externalFeedBack(d[4]);
                        LbRC431.Text = externalFeedBack(d[5]);
                        LbRC441.Text = splitData(d[6]);
                        LbRC451.Text = splitData(d[7]);
                        LbRC461.Text = externalFeedBack(d[8]);
                    }
                    else if (d[1].Equals("3"))
                    {
                        LbRC50.Text = externalFeedBack(d[2]);
                        LbRC51.Text = externalFeedBack(d[3]);
                        LbRC521.Text = externalFeedBack(d[4]);
                        LbRC531.Text = externalFeedBack(d[5]);
                        LbRC541.Text = splitData(d[6]);
                        LbRC551.Text = splitData(d[7]);
                        LbRC561.Text = externalFeedBack(d[8]);
                    }
                }
                else if (d[0].Equals("3"))
                {
                    if (d[1].Equals("1"))
                    {
                        LbRC60.Text = externalFeedBack(d[2]);
                        LbRC61.Text = externalFeedBack(d[3]);
                        LbRC621.Text = externalFeedBack(d[4]);
                        LbRC631.Text = externalFeedBack(d[5]);
                        LbRC641.Text = splitData(d[6]);
                        LbRC651.Text = splitData(d[7]);
                        LbRC661.Text = externalFeedBack(d[8]);
                    }
                    else if (d[1].Equals("2"))
                    {
                        LbRC70.Text = externalFeedBack(d[2]);
                        LbRC71.Text = externalFeedBack(d[3]);
                        LbRC721.Text = externalFeedBack(d[4]);
                        LbRC731.Text = externalFeedBack(d[5]);
                        LbRC741.Text = splitData(d[6]);
                        LbRC751.Text = splitData(d[7]);
                        LbRC761.Text = externalFeedBack(d[8]);
                    }
                    else if (d[1].Equals("3"))
                    {
                        LbRC80.Text = externalFeedBack(d[2]);
                        LbRC81.Text = externalFeedBack(d[3]);
                        LbRC821.Text = externalFeedBack(d[4]);
                        LbRC831.Text = externalFeedBack(d[5]);
                        LbRC841.Text = splitData(d[6]);
                        LbRC851.Text = splitData(d[7]);
                        LbRC861.Text = externalFeedBack(d[8]);
                    }
                }
            }

            else
            {
                if (d[0].Equals("1"))
                {
                    if (d[1].Equals("1"))
                    {
                        LbRC00.Text = externalFeedBack(d[2]);
                        LbRC01.Text = externalFeedBack(d[3]);
                        LbRC02.Text = d[4];
                        LbRC03.Text = d[5];
                        LbRC04.Text = splitData(d[6]);
                        LbRC05.Text = splitData(d[7]);
                        LbRC06.Text = d[8];
                    }
                    else if (d[1].Equals("2"))
                    {
                        LbRC10.Text = externalFeedBack(d[2]);
                        LbRC11.Text = externalFeedBack(d[3]);
                        LbRC12.Text = d[4];
                        LbRC13.Text = d[5];
                        LbRC14.Text = splitData(d[6]);
                        LbRC15.Text = splitData(d[7]);
                        LbRC16.Text = d[8];
                    }
                    else if (d[1].Equals("3"))
                    {
                        LbRC20.Text = externalFeedBack(d[2]);
                        LbRC21.Text = externalFeedBack(d[3]);
                        LbRC22.Text = d[4];
                        LbRC23.Text = d[5];
                        LbRC24.Text = splitData(d[6]);
                        LbRC25.Text = splitData(d[7]);
                        LbRC26.Text = d[8];
                    }
                }
                else if (d[0].Equals("2"))
                {
                    if (d[1].Equals("1"))
                    {
                        LbRC30.Text = externalFeedBack(d[2]);
                        LbRC31.Text = externalFeedBack(d[3]);
                        LbRC32.Text = d[4];
                        LbRC33.Text = d[5];
                        LbRC34.Text = splitData(d[6]);
                        LbRC35.Text = splitData(d[7]);
                        LbRC36.Text = d[8];
                    }
                    else if (d[1].Equals("2"))
                    {
                        LbRC40.Text = externalFeedBack(d[2]);
                        LbRC41.Text = externalFeedBack(d[3]);
                        LbRC42.Text = d[4];
                        LbRC43.Text = d[5];
                        LbRC44.Text = splitData(d[6]);
                        LbRC45.Text = splitData(d[7]);
                        LbRC46.Text = d[8];
                    }
                    else if (d[1].Equals("3"))
                    {
                        LbRC50.Text = externalFeedBack(d[2]);
                        LbRC51.Text = externalFeedBack(d[3]);
                        LbRC52.Text = d[4];
                        LbRC53.Text = d[5];
                        LbRC54.Text = splitData(d[6]);
                        LbRC55.Text = splitData(d[7]);
                        LbRC56.Text = d[8];
                    }
                }
                else if (d[0].Equals("3"))
                {
                    if (d[1].Equals("1"))
                    {
                        LbRC60.Text = externalFeedBack(d[2]);
                        LbRC61.Text = externalFeedBack(d[3]);
                        LbRC62.Text = d[4];
                        LbRC63.Text = d[5];
                        LbRC64.Text = splitData(d[6]);
                        LbRC65.Text = splitData(d[7]);
                        LbRC66.Text = d[8];
                    }
                    else if (d[1].Equals("2"))
                    {
                        LbRC70.Text = externalFeedBack(d[2]);
                        LbRC71.Text = externalFeedBack(d[3]);
                        LbRC72.Text = d[4];
                        LbRC73.Text = d[5];
                        LbRC74.Text = splitData(d[6]);
                        LbRC75.Text = splitData(d[7]);
                        LbRC76.Text = d[8];
                    }
                    else if (d[1].Equals("3"))
                    {
                        LbRC80.Text = externalFeedBack(d[2]);
                        LbRC81.Text = externalFeedBack(d[3]);
                        LbRC82.Text = d[4];
                        LbRC83.Text = d[5];
                        LbRC84.Text = splitData(d[6]);
                        LbRC85.Text = splitData(d[7]);
                        LbRC86.Text = d[8];
                    }
                }
            }
        }

    }

    private string externalFeedBack(string data)
    {
        return data.Equals("") ? Resources.Resource.TipNotWrite : data;
    }

    private string splitData(string date)
    {
        if (date.Contains(BaseClass.standardTimestamp))
        {
            if(IsMingDer)
                return Resources.Resource.TipNotWrite;
            else
                return "";
        }
           
        string[] tmp = date.Split(' ');
        if (tmp.Length > 0)
        {
            return tmp[0];
        }
        return "";
    }

    protected void BtnStore_Click(object sender, EventArgs e)
    {
        writeData(1, 1, LbRC02.Text.Trim(), LbRC03.Text.Trim(), LbRC04.Text.Trim(), LbRC05.Text.Trim(), LbRC06.Text.Trim());
        writeData(1, 2, LbRC12.Text.Trim(), LbRC13.Text.Trim(), LbRC14.Text.Trim(), LbRC15.Text.Trim(), LbRC16.Text.Trim());
        writeData(1, 3, LbRC22.Text.Trim(), LbRC23.Text.Trim(), LbRC24.Text.Trim(), LbRC25.Text.Trim(), LbRC26.Text.Trim());
        writeData(2, 1, LbRC32.Text.Trim(), LbRC33.Text.Trim(), LbRC34.Text.Trim(), LbRC35.Text.Trim(), LbRC36.Text.Trim());
        writeData(2, 2, LbRC42.Text.Trim(), LbRC43.Text.Trim(), LbRC44.Text.Trim(), LbRC45.Text.Trim(), LbRC46.Text.Trim());
        writeData(2, 3, LbRC52.Text.Trim(), LbRC53.Text.Trim(), LbRC54.Text.Trim(), LbRC55.Text.Trim(), LbRC56.Text.Trim());
        writeData(3, 1, LbRC62.Text.Trim(), LbRC63.Text.Trim(), LbRC64.Text.Trim(), LbRC65.Text.Trim(), LbRC66.Text.Trim());
        writeData(3, 2, LbRC72.Text.Trim(), LbRC73.Text.Trim(), LbRC74.Text.Trim(), LbRC75.Text.Trim(), LbRC76.Text.Trim());
        writeData(3, 3, LbRC82.Text.Trim(), LbRC83.Text.Trim(), LbRC84.Text.Trim(), LbRC85.Text.Trim(), LbRC86.Text.Trim());

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanViewMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() +"&SCHOOLNAME="+Session["SCHOOLNAME"].ToString() + "';", true);
    }

    private void writeData(int DimensionsID, int NO, string CheckUser, string TitleDepart, string StartTime, string EndTime, string Support)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = string.Empty;
        query = "select COUNT(*) from PlanMonitor where SN='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='" + DimensionsID + "' and NO='" + NO + "'";
        ms.GetRowNumbers(query, sb);
        if (sb.ToString().Equals("0") || sb.ToString().Equals("-1"))
        {
            query = "insert into PlanMonitor (SN, DimensionsID, NO, CheckUser, TitleDepart, StartTime, EndTime, Support) VALUES ('" +
                        Session["UserPlanListSN"].ToString() + "','" +
                        DimensionsID + "','" +
                        NO + "',N'" +
                        CheckUser + "',N'" +
                        TitleDepart + "',N'" +
                        StartTime + "',N'" +
                        EndTime + "',N'" +
                        Support + 
                        "')";
            ms.WriteData(query, sb);
        }
        else
        {
            query = "update PlanMonitor set CheckUser=N'" + CheckUser + "', " +
                                            "TitleDepart=N'" + TitleDepart + "', " +
                                            "StartTime=N'" + StartTime + "', " +
                                            "EndTime=N'" + EndTime + "', " +
                                            "Support=N'" + Support + "' " +
                                            "where SN='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='" + DimensionsID + "' and NO='" + NO + "'";
            ms.WriteData(query, sb);
        }
    }
}