﻿using System;
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

public partial class Packages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session["CurrentPage"] = "Home";

            Session["CurrentPageConfig"] = null;


            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScript.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);
        }

    }
    protected void btnPremiumSilver_Click(object sender, EventArgs e)
    {
        try
        {
            Session["PackageID"] = 4;
            Response.Redirect("Registration.aspx");
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
            Response.Redirect("Registration.aspx");
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
            Response.Redirect("Registration.aspx");
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
            Response.Redirect("Registration.aspx");
        }
        catch (Exception ex)
        {
        }
    }
}