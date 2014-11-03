using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton lbtnRed = new LinkButton();
        LinkButton lbtnBlue = new LinkButton();
        LinkButton lbtnYellow = new LinkButton();

        lbtnRed.ID = lbtnRed.Text = "Red";
        lbtnBlue.ID = lbtnBlue.Text = "Blue";
        lbtnYellow.ID = lbtnYellow.Text = "Yellow";

        lbtnRed.Click += new EventHandler(lbtn_Click);
        lbtnBlue.Click += new EventHandler(lbtn_Click);
        lbtnYellow.Click += new EventHandler(lbtn_Click);

        divControlContainer.Controls.Add(lbtnRed);
        divControlContainer.Controls.Add(new LiteralControl("<br/>"));
        divControlContainer.Controls.Add(lbtnBlue);
        divControlContainer.Controls.Add(new LiteralControl("<br/>"));
        divControlContainer.Controls.Add(lbtnYellow);
        divControlContainer.Controls.Add(new LiteralControl("<br/>"));
    }

    protected void lbtn_Click(object sender, EventArgs e)
    {
        //Get Event Sender Control 
        LinkButton lbtnSender = (LinkButton)sender;

        //Clear Previous Saved Values 
        ddlProducts.Items.Clear();
        lblText.Text = "";

        //Populate DropDownList Items 
        for (int i = 1; i < 10; i++)
        {
            string productName = lbtnSender.ID + " Product " + i.ToString();
            ddlProducts.Items.Add(new ListItem(productName, productName));
        }
        //Show ModalPopup 
        mpeThePopup.Show();
    }

    protected void btnChooseProduct_Click(object sender, EventArgs e)
    {
        //Changed Label Control Text 
        lblText.Text = "You have selected " + ddlProducts.SelectedItem.Text;
        //Show ModalPopup 
        mpeThePopup.Show();
    }
    protected void btnCancelModalPopup_Click(object sender, EventArgs e)
    {
        Label1.Text = "You have selected " + ddlProducts.SelectedItem.Text;
        mpeThePopup.Hide();
    }
}