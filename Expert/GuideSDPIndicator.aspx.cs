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
<<<<<<< HEAD
=======
    protected void ImgBtnIndex_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["IsMingDer"].ToString().Equals("False"))
        {
            Response.Redirect("../ProvinceIndex.aspx");
        }
        else if (Session["IsMingDer"].ToString().Equals("True"))
        {
            Response.Redirect("../MingdeIndex.aspx");
        }
    }
>>>>>>> develop
}