using System;
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

        ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipPlanOperationSuccess + "');window.location='PlanList.aspx';", true);
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