using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_PlanItem9 : System.Web.UI.Page
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
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LbYear.Text = Session["PlanYear"].ToString();
        if (!IsPostBack)
        {
            setInitial();
        }
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString());
    }
    protected void BtnStore_Click(object sender, EventArgs e)
    {
        if (haveEmptyData())
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanEmptyData + "');", true);
        }
        else
        {
            storeData();
        }
    }
    private bool haveEmptyData()
    {
        return false;
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
            if (d[0].Equals("1"))
            {
                if (d[1].Equals("1"))
                {
                    TbRC00.Text = d[2];
                    TbRC01.Text = d[3];
                    TbRC02.Text = externalFeedBack(d[4]);
                    TbRC03.Text = externalFeedBack(d[5]);
                    TbRC04.Text = splitData(d[6]);
                    TbRC05.Text = splitData(d[7]);
                    TbRC06.Text = externalFeedBack(d[8]);
                }
                else if (d[1].Equals("2"))
                {
                    TbRC10.Text = d[2];
                    TbRC11.Text = d[3];
                    TbRC12.Text = externalFeedBack(d[4]);
                    TbRC13.Text = externalFeedBack(d[5]);
                    TbRC14.Text = splitData(d[6]);
                    TbRC15.Text = splitData(d[7]);
                    TbRC16.Text = externalFeedBack(d[8]);
                }
                else if (d[1].Equals("3"))
                {
                    TbRC20.Text = d[2];
                    TbRC21.Text = d[3];
                    TbRC22.Text = externalFeedBack(d[4]);
                    TbRC23.Text = externalFeedBack(d[5]);
                    TbRC24.Text = splitData(d[6]);
                    TbRC25.Text = splitData(d[7]);
                    TbRC26.Text = externalFeedBack(d[8]);
                }
            }
            else if (d[0].Equals("2"))
            {
                if (d[1].Equals("1"))
                {
                    TbRC30.Text = d[2];
                    TbRC31.Text = d[3];
                    TbRC32.Text = externalFeedBack(d[4]);
                    TbRC33.Text = externalFeedBack(d[5]);
                    TbRC34.Text = splitData(d[6]);
                    TbRC35.Text = splitData(d[7]);
                    TbRC36.Text = externalFeedBack(d[8]);
                }
                else if (d[1].Equals("2"))
                {
                    TbRC40.Text = d[2];
                    TbRC41.Text = d[3];
                    TbRC42.Text = externalFeedBack(d[4]);
                    TbRC43.Text = externalFeedBack(d[5]);
                    TbRC44.Text = splitData(d[6]);
                    TbRC45.Text = splitData(d[7]);
                    TbRC46.Text = externalFeedBack(d[8]);
                }
                else if (d[1].Equals("3"))
                {
                    TbRC50.Text = d[2];
                    TbRC51.Text = d[3];
                    TbRC52.Text = externalFeedBack(d[4]);
                    TbRC53.Text = externalFeedBack(d[5]);
                    TbRC54.Text = splitData(d[6]);
                    TbRC55.Text = splitData(d[7]);
                    TbRC56.Text = externalFeedBack(d[8]);
                }
            }
            else if (d[0].Equals("3"))
            {
                if (d[1].Equals("1"))
                {
                    TbRC60.Text = d[2];
                    TbRC61.Text = d[3];
                    TbRC62.Text = externalFeedBack(d[4]);
                    TbRC63.Text = externalFeedBack(d[5]);
                    TbRC64.Text = splitData(d[6]);
                    TbRC65.Text = splitData(d[7]);
                    TbRC66.Text = externalFeedBack(d[8]);
                }
                else if (d[1].Equals("2"))
                {
                    TbRC70.Text = d[2];
                    TbRC71.Text = d[3];
                    TbRC72.Text = externalFeedBack(d[4]);
                    TbRC73.Text = externalFeedBack(d[5]);
                    TbRC74.Text = splitData(d[6]);
                    TbRC75.Text = splitData(d[7]);
                    TbRC76.Text = externalFeedBack(d[8]);
                }
                else if (d[1].Equals("3"))
                {
                    TbRC80.Text = d[2];
                    TbRC81.Text = d[3];
                    TbRC82.Text = externalFeedBack(d[4]);
                    TbRC83.Text = externalFeedBack(d[5]);
                    TbRC84.Text = splitData(d[6]);
                    TbRC85.Text = splitData(d[7]);
                    TbRC86.Text = externalFeedBack(d[8]);
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
            return Resources.Resource.TipNotWrite;

        string[] tmp = date.Split(' ');
        if (tmp.Length > 0)
        {
            return tmp[0];
        }
        return "";
    }

    private void storeData()
    {
        
        // 先刪除原本的
        //string query = "delete from PlanCharacteristic where SN ='" + Session["UserPlanListSN"].ToString() + "'";
        //ms.WriteData(query, sb);
        //sb.Clear();
        writeData(1, 1, TbRC00.Text.Trim(), TbRC01.Text.Trim());
        writeData(1, 2, TbRC10.Text.Trim(), TbRC11.Text.Trim());
        writeData(1, 3, TbRC20.Text.Trim(), TbRC21.Text.Trim());
        writeData(2, 1, TbRC30.Text.Trim(), TbRC31.Text.Trim());
        writeData(2, 2, TbRC40.Text.Trim(), TbRC41.Text.Trim());
        writeData(2, 3, TbRC50.Text.Trim(), TbRC51.Text.Trim());
        writeData(3, 1, TbRC60.Text.Trim(), TbRC61.Text.Trim());
        writeData(3, 2, TbRC70.Text.Trim(), TbRC71.Text.Trim());
        writeData(3, 3, TbRC80.Text.Trim(), TbRC81.Text.Trim());

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", " window.location='PlanMain.aspx?SN=" + Session["PlanSN"].ToString() + "&YEAR=" + Session["PlanYear"].ToString() + "';", true);
    }

    private void writeData(int DimensionsID, int NO, string solution, string unsolution)
    {
        StringBuilder sb = new StringBuilder();
        ManageSQL ms = new ManageSQL();
        string query = string.Empty;
        query = "select COUNT(*) from PlanMonitor where SN='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='" + DimensionsID + "' and NO='" + NO + "'";
        ms.GetRowNumbers(query, sb);
        if (sb.ToString().Equals("0") || sb.ToString().Equals("-1"))
        {
            query = "insert into PlanMonitor (SN, DimensionsID, NO, Solution, UnSolution) VALUES ('" +
                        Session["UserPlanListSN"].ToString() + "','" +
                        DimensionsID + "','" +
                        NO + "',N'" +
                        solution + "',N'" +
                        unsolution + "')";
            ms.WriteData(query, sb);
        }
        else
        {
            query = "update PlanMonitor set Solution=N'" + solution + "', "+
                                            "unsolution=N'" + unsolution + "' " +
                                            "where SN='" + Session["UserPlanListSN"].ToString() + "' and DimensionsID='" + DimensionsID + "' and NO='" + NO + "'";                                   
            ms.WriteData(query, sb);
        }
    }
}