using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SchoolMaster_GuideViewSDPIndicator : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideViewSDPEvaluateResult.aspx");
    }
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../Index.aspx");
    }
}