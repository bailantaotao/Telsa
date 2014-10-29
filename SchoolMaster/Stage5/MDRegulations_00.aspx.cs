using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stage5_MDRegulations_00 : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["SelectValue"] = DlRegulationSelect.SelectedValue;
        if (DlRegulationSelect.SelectedValue == "1")
            Response.Redirect("MDRegulations_01.aspx");
        if (DlRegulationSelect.SelectedValue == "2")
            Response.Redirect("MDRegulations_02.aspx");
        if (DlRegulationSelect.SelectedValue == "3")
            Response.Redirect("MDRegulations_03.aspx");
        if (DlRegulationSelect.SelectedValue == "4")
            Response.Redirect("MDRegulations_04.aspx");
        if (DlRegulationSelect.SelectedValue == "5")
            Response.Redirect("MDRegulations_05.aspx");
        if (DlRegulationSelect.SelectedValue == "6")
            Response.Redirect("MDRegulations_06.aspx");
        if (DlRegulationSelect.SelectedValue == "7")
            Response.Redirect("MDRegulations_07.aspx");
    }
}