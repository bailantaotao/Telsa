using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_KPIExamMain : System.Web.UI.Page
{
    private const int QuestionMaxNumbers = 10;
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
        if (!Session["ClassCode"].ToString().Equals("0"))
            Response.Redirect("../SessionOut.aspx");

        SetDdlDefault(DdlDimension);
        if (Session["DdlDimension_SelectIndex"] != null)
        {
            ListDdlDomains();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    private void SetDdlDefault(DropDownList ddl)
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select * from KPIDimensionsNameMapping";

        if (ms.GetAllColumnData(query, data))
        {
            foreach (string[] tmp in data)
            {
                DdlDimension.Items.Add(new ListItem(tmp[1], tmp[0]));
            }
        }
        else
        {
            DdlDimension.Items.Add(Resources.Resource.TipKPIError);
        }
    }

   
    private void ListDdlDomains()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        string query = "select KPIDimensionsDomainMappingTable.DimensionsID, KPIDimensionsDomainMappingTable.DomainID, KPIDomainNameMapping.DomainName " +
                        "from KPIDimensionsNameMapping " +
                        "left join KPIDimensionsDomainMappingTable on KPIDimensionsNameMapping.DimensionsID = KPIDimensionsDomainMappingTable.DimensionsID " +
                        "left join KPIDomainNameMapping on KPIDimensionsDomainMappingTable.DomainID = KPIDomainNameMapping.DomainID ";

        if (ms.GetAllColumnData(query, data))
        {
            if (data.Count > 0)
            {
                DdlDomain.Items.Clear();
                DdlDomain.Items.Add(new ListItem(Resources.Resource.TipPlzChoose, "0"));
                int ddlDimensionSelectIndex = (Session["DdlDimension_SelectIndex"]==null)?DdlDimension.SelectedIndex:Convert.ToInt32(Session["DdlDimension_SelectIndex"].ToString());
                foreach (string[] tmp in data)
                {
                    int DimensionsID = -1;
                    bool DimensionsSuccess = false;
                    DimensionsSuccess = Int32.TryParse(tmp[0], out DimensionsID);
                    if (DimensionsSuccess)
                    {
                        if (ddlDimensionSelectIndex == DimensionsID)
                        {
                            DdlDomain.Items.Add(new ListItem(tmp[2], tmp[1]));
                        }
                    }
                }
            }
        }
        else
        {
            DdlDomain.Items.Add(Resources.Resource.TipKPIError);
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if (btn.ID == "BtnStartInput")
        {
            Session["InputMode"] = "True";
            Session["DdlDomain_SelectValue"] = DdlDomain.SelectedValue;
            Session["DdlDomain_SelectIndex"] = DdlDomain.SelectedIndex;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + Resources.Resource.TipKPICancelQuestionnaire + "');window.location='KPIExamStart.aspx';", true);
        }
    }

    protected void DdlDimension_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["DdlDimension_SelectIndex"] = DdlDimension.SelectedIndex;
        ListDdlDomains();
        
    }
    protected void DdlDomain_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["DdlDomain_SelectValue"] = DdlDomain.SelectedValue;
        Session["DdlDomain_SelectIndex"] = DdlDomain.SelectedIndex;
    }
}