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

public partial class UserControl_CarsHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["PageName"].ToString() == "Home")
            {
                lnkbtnHome.CssClass = "act";
                lnkbtnHome.Enabled = false;
            }
            if (Session["PageName"].ToString() == "UsedCars")
            {
                lnkbtnUsedcars.CssClass = "act";
            }
            if (Session["PageName"].ToString() == "NewCars")
            {
                lnkbtnNewCars.CssClass = "act";
            }
            if (Session["PageName"].ToString() == "Packages")
            {
                lnkbtnSellACar.CssClass = "act";
            }
        }
    }
}
