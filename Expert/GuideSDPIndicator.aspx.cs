﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Expert_GuideSDPIndicator : System.Web.UI.Page
{
    public string backgroundImage = Resources.Resource.ImgUrlBackground;   

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("GuideSDPEvaluateResult.aspx");
    }
}