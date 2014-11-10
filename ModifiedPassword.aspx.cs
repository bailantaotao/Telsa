using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModifiedPassword : System.Web.UI.Page
{
    private string Query = string.Empty;

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void CheckPassword()
    {
        string QueryCheck = string.Empty;

        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        StringBuilder sb1 = new StringBuilder();

        Query = "select Password from Account where UserID= '" + Session["UserID"].ToString() + "'";
        ms.GetOneData(Query, sb);

        if (sb.ToString() == TbOriginCode.Text.Trim())
        {
            if (TbNewCode.Text.Trim() == TbCheckNewCode.Text.Trim())
            {
                QueryCheck = "update Account set Password='" + TbNewCode.Text + "'" +
                             "where UserID='" + Session["UserID"].ToString() + "'";
                ms.WriteData(QueryCheck, sb1);

                if (Session["ClassCode"].ToString().Equals("0"))
                {
                    Response.Redirect("Index.aspx");
                }
                else if (Session["ClassCode"].ToString().Equals("1"))
                {
                    if (Session["IsMingDer"].ToString().Equals("False"))
                    {
                        Response.Redirect("ProvinceIndex.aspx");
                    }
                    if (Session["IsMingDer"].ToString().Equals("True"))
                    {
                        Response.Redirect("MingdeIndex.aspx");
                    }
                }
                else
                {
                    Response.Redirect("SystemManagerIndex.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('新密码内容不同');", true);
                TbOriginCode.Text = null;
                TbNewCode.Text = null;
                TbCheckNewCode.Text = null;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('旧密码错误');", true);
            TbOriginCode.Text = null;
            TbNewCode.Text = null;
            TbCheckNewCode.Text = null;
        }
    }
    protected void BtnModify_Click(object sender, EventArgs e)
    {
        CheckPassword();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        if (Session["ClassCode"].ToString().Equals("0"))
        {
            Response.Redirect("Index.aspx");
        }
        else if (Session["ClassCode"].ToString().Equals("1"))
        {
            if (Session["IsMingDer"].ToString().Equals("False"))
            {
                Response.Redirect("ProvinceIndex.aspx");
            }
            if (Session["IsMingDer"].ToString().Equals("True"))
            {
                Response.Redirect("MingdeIndex.aspx");
            }
        }
        else
        {
            Response.Redirect("SystemManagerIndex.aspx");
        }
    }
}