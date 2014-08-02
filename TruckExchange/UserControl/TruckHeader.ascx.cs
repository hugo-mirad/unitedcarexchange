using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class UserControl_TruckHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PageName"] == "Default")
            {
                lnkbtnHome.CssClass = "act";
            }
            if (Session["PageName"] == "ContactUS")
            {
                lnkbtnContactUS.CssClass = "act";
            }
            if (Session["PageName"] == "UsedTrucks")
            {
                lnkbtnUsedTrucks.CssClass = "act";
            }
            if (Session["PageName"] == "NewTrucks")
            {
                lnkbtnNewTrucks.CssClass = "act";
            }
        }
    }
    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        

    }
    protected void lnkbtnHome_Click1(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx"); 
    }
}
