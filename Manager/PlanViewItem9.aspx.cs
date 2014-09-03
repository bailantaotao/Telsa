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
        if (!Session["ClassCode"].ToString().Equals("2"))
            Response.Redirect("../SessionOut.aspx");


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LbNO.Text = Session["Semester"].ToString();
        LbYear.Text = Session["PlanYear"].ToString();
        setInitial();
    }


    protected void BtnCancel_Click(object sender, EventArgs e)
    {         
        Response.Redirect("PlanViewMain.aspx?SN="+Session["PlanSN"].ToString()+"&YEAR="+Session["PlanYear"].ToString()+"&SCHOOLNAME="+Session["SCHOOLNAME"].ToString());
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
                    LbRC00.Text = d[2];
                    LbRC01.Text = d[3];
                    LbRC02.Text = d[4];
                    LbRC03.Text = d[5];
                    LbRC04.Text = splitData(d[6]);
                    LbRC05.Text = splitData(d[7]);
                    LbRC06.Text = d[8];
                }
                else if (d[1].Equals("2"))
                {
                    LbRC10.Text = d[2];
                    LbRC11.Text = d[3];
                    LbRC12.Text = d[4];
                    LbRC13.Text = d[5];
                    LbRC14.Text = splitData(d[6]);
                    LbRC15.Text = splitData(d[7]);
                    LbRC16.Text = d[8];
                }
                else if (d[1].Equals("3"))
                {
                    LbRC20.Text = d[2];
                    LbRC21.Text = d[3];
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
                    LbRC30.Text = d[2];
                    LbRC31.Text = d[3];
                    LbRC32.Text = d[4];
                    LbRC33.Text = d[5];
                    LbRC34.Text = splitData(d[6]);
                    LbRC35.Text = splitData(d[7]);
                    LbRC36.Text = d[8];
                }
                else if (d[1].Equals("2"))
                {
                    LbRC40.Text = d[2];
                    LbRC41.Text = d[3];
                    LbRC42.Text = d[4];
                    LbRC43.Text = d[5];
                    LbRC44.Text = splitData(d[6]);
                    LbRC45.Text = splitData(d[7]);
                    LbRC46.Text = d[8];
                }
                else if (d[1].Equals("3"))
                {
                    LbRC50.Text = d[2];
                    LbRC51.Text = d[3];
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
                    LbRC60.Text = d[2];
                    LbRC61.Text = d[3];
                    LbRC62.Text = d[4];
                    LbRC63.Text = d[5];
                    LbRC64.Text = splitData(d[6]);
                    LbRC65.Text = splitData(d[7]);
                    LbRC66.Text = d[8];
                }
                else if (d[1].Equals("2"))
                {
                    LbRC70.Text = d[2];
                    LbRC71.Text = d[3];
                    LbRC72.Text = d[4];
                    LbRC73.Text = d[5];
                    LbRC74.Text = splitData(d[6]);
                    LbRC75.Text = splitData(d[7]);
                    LbRC76.Text = d[8];
                }
                else if (d[1].Equals("3"))
                {
                    LbRC80.Text = d[2];
                    LbRC81.Text = d[3];
                    LbRC82.Text = d[4];
                    LbRC83.Text = d[5];
                    LbRC84.Text = splitData(d[6]);
                    LbRC85.Text = splitData(d[7]);
                    LbRC86.Text = d[8];
                }
            }
        }

    }
    private string splitData(string date)
    {
        string[] tmp = date.Split(' ');
        if (tmp.Length > 0)
        {
            return tmp[0];
        }
        return "";
    }
}