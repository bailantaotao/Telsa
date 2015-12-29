using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RecoverPassword : System.Web.UI.Page
{
    private string Query = string.Empty;

    public string backgroundImage = Resources.Resource.ImgUrlBackground;

    private enum DdlType
    {
        Province,
        SchoolName
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (Session.Count == 0 || Session["UserName"].ToString() == "" || Session["UserID"].ToString() == "" || Session["ClassCode"].ToString() == "")
            Response.Redirect("../SessionOut.aspx");

        setDefault(DdlType.Province);
        //DdlSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        setSchoolName();
    }

    private string SearchProvince()
    {
        string query = "select area.name from area where area.id='" + Session["Province"].ToString() + "'";
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();
        ms.GetOneData(query, sb);
        return string.IsNullOrEmpty(sb.ToString()) ? "none" : sb.ToString();
    }

    private void setDefault(DdlType type)
    {
        switch (type)
        {
            case DdlType.Province:
                setProvince();
                break;
            case DdlType.SchoolName:
                setSchoolName();
                break;
        }
    }
    private void setProvince()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        Query = "select area.name from area where ID <= 31 order by id asc";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlProvince.Items.Add("None");
            return;
        }

        if (data.Count == 0)
        {
            DdlProvince.Items.Add("None");
            return;
        }
        DdlProvince.Items.Add(Resources.Resource.DdlTypeProvince);
        foreach (string[] province in data)
        {
            DdlProvince.Items.Add(province[0]);
        }
    }
    private void setSchoolName()
    {
        ManageSQL ms = new ManageSQL();
        ArrayList data = new ArrayList();
        StringBuilder sb = new StringBuilder();
        string QueryZipcode = string.Empty;

        QueryZipcode = "select ID from Area where Name = N'" + DdlProvince.SelectedValue.ToString() + "'";
        ms.GetOneData(QueryZipcode, sb);

        Query = "select School from Account where zipcode ='" + sb.ToString() + "' and School not like N'%專家%' and School not like N'%专家%' and School not like N'%管理者%' group by School ";
        if (!ms.GetAllColumnData(Query, data))
        {
            DdlSchool.Items.Add("None");
            return;
        }

        /*if (data.Count == 0)
        {
            DdlSchool.Items.Add("None");
            return;
        }*/
        //DdlSchool.Items.Add(Resources.Resource.DdlTypeSchoolname);
        foreach (string[] province in data)
        {
            DdlSchool.Items.Add(province[0]);
        }
    }

    private void RecoverPasswordFunc()
    {
        ManageSQL ms = new ManageSQL();
        StringBuilder sb = new StringBuilder();

        Query = "update Account set Password='0000' where School=N'" + DdlSchool.SelectedValue.ToString() + "'";
        ms.WriteData(Query, sb);

        Response.Redirect("SystemManagerIndex.aspx");
    }
    protected void BtnModify_Click(object sender, EventArgs e)
    {
        RecoverPasswordFunc();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SystemManagerIndex.aspx");
    }
    protected void DdlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlSchool.Items.Clear();
        setSchoolName();
    }
}