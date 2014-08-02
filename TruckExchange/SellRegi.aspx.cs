using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SellRegi : System.Web.UI.Page
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
    protected void btnFree_Click(object sender, EventArgs e)
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
    protected void btnBasic_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 2;
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
