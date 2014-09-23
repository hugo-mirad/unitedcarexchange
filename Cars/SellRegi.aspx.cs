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
            Session["Registration"] = null;
            GeneralFunc.SetPageDefaults(Page);
            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            Session["Registration"] = null;
            Session["RegistrationPlaceAd"] = null;
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
            Session["PackageID"] = 4;
            Session["PackgeName"] = "Regular";
            Session["PackgePrice"] = "$99.99";
            Session["regular"] = "Ad Runs For 90 Days<br>20 Photos<br>15 + Multi Site Promotions<br>Mobile, Social & Web Listings<br>Ad Traffic Report<br>";
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
            Session["PackageID"] = 5;
            Session["PackgeName"] = "Premium";
            Session["PackgePrice"] = "$199.99";
            Session["premium"] = "Ad Runs For 90 Days<br>20 Photos<br>15 + Multi Site Promotions<br>Mobile, Social & Web Listings<br>Ad Traffic Report<br>Popular Ads<br>Email Promotions & Dealer Network Ads<br>Unlimited Renewals (Run Till It Sells)<br>";
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
            Session["PackageID"] = 6;
            Session["PackgeName"] = "Deluxe";
            Session["PackgePrice"] = "$299.99";
            Session["Deluxe"] = "Ad Runs For 90 Days<br>20 Photos<br>15 + Multi Site Promotions<br>Mobile, Social & Web Listings<br>Ad Traffic Report<br>Popular / Banner Ads<br>Email Promotions & Dealer Network Ads<br>Unlimited Renewals (Run Till It Sells)<br>Expert Advice<br>Premium Site Listings";

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
