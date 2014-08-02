using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Premium : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CurrentPage"] = "Home";
        Session["PageName"] = "";
        Session["CurrentPageConfig"] = null;

        //GeneralFunc.SetPageDefaults(Page);
        ServiceReference objServiceReference = new ServiceReference();

        ScriptReference objScriptReference = new ScriptReference();

        objServiceReference.Path = "~/CarsService.asmx";

        objScriptReference.Path = "~/Static/Js/CarsJScript.js";

        scrptmgr.Services.Add(objServiceReference);
        scrptmgr.Scripts.Add(objScriptReference);
    }

    protected void btnProceed_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Registration.aspx");
    }
    protected void btnPremiumSilver_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 4;
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
    protected void btnPremiumGold_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 5;
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
    protected void btnPremiumPlatinum_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 6;
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
    protected void ImgbtnSellcar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["PackageID"] = 1;
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
