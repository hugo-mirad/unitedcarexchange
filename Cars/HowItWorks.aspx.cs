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


public partial class HowItWorks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CurrentPage"] = "How it Works Page";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;

            KeyWords.Addkeywordstags(Header);
            GeneralFunc.SetPageDefaults(Page);

            GeneralFunc.SaveSiteVisit();

            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);


        }
    }
}
