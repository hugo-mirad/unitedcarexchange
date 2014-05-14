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

public partial class SellRegi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session["CurrentPage"] = "SellRegi";
            Session["PageName"] = "SellRegi";
            Session["CurrentPageConfig"] = null;

            GeneralFunc.SetPageDefaults(Page);
            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);


        }
    }


    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Registration.aspx");
    }
    protected void btnFree_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 1;
            Session["PackgeName"] = "Basic - FREE";
            Session["PackgePrice"] = "FREE";

            if (Session[Constants.USER_ID] != null)
            {
                mpeSuccessalert.Show();
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnBasic_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 2;
            Session["PackgeName"] = "Standard";
            Session["PackgePrice"] = "$24.99";
            if (Session[Constants.USER_ID] != null)
            {
                mpeSuccessalert.Show();
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnEnhanced_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 3;
            Session["PackgeName"] = "Enhanced";
            Session["PackgePrice"] = "$49.99";
            if (Session[Constants.USER_ID] != null)
            {
                mpeSuccessalert.Show();
            }
            else
            {
                Response.Redirect("Registration.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }

}
