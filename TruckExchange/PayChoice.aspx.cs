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
using CarsBL.Transactions;
using CarsInfo;
using System.Net.Mail;

public partial class NewTrucks : System.Web.UI.Page
{
    NewCarsBl objNewCarsBl = new NewCarsBl();
    NewCarsInfo objNewCarsInfo = new NewCarsInfo();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            Session["CurrentPage"] = "Paymode";
            Session["PageName"] = "Paymode";
            Session["CurrentPageConfig"] = null;


            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScript.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);





        }

    }

    protected void paymode_Click(object sender, ImageClickEventArgs e)
    {

    }
}
