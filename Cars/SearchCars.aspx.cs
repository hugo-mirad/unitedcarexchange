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

public partial class SearchCars : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["Orderby"] = "yearOfMake";
            Session["sort"] = "desc";

            Session["CurrentPage"] = "Search Results Page";

            Session["CurrentPageConfig"] = null;

            KeyWords.Addkeywordstags(Header);
            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            GeneralFunc.SetPageDefaults(Page);

            //Reading values From Hiddene fields

            if (Session["hdnPriceMIN"] == null || Session["hdnPriceMAX"] == null || Session["hdnMileageMIN"] == null || Session["hdnMileageMAX"] == null)
            {
                hdnPriceMIN.Value = "5000";
                hdnPriceMAX.Value = "150000";
                hdnMileageMIN.Value = "100";
                hdnMileageMAX.Value = "100000";
            }
            else
            {
                hdnPriceMIN.Value = Session["hdnPriceMIN"].ToString();
                hdnPriceMAX.Value = Session["hdnPriceMAX"].ToString();
                hdnMileageMIN.Value = Session["hdnMileageMIN"].ToString();
                hdnMileageMAX.Value = Session["hdnMileageMAX"].ToString();
            }

        }
    }
} 
