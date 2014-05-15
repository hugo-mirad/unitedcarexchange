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

public partial class Finance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CurrentPage"] = "Finance Page";
            Session["PageName"] = "Finance Page";
            Session["CurrentPageConfig"] = null;
            KeyWords.Addkeywordstags(Header);
            GeneralFunc.SaveSiteVisit();
            GeneralFunc.SetPageDefaults(Page);
            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);


        }
    }

    public void btnsubmits_click(object sender,EventArgs e)
    {
        String strHostName = Request.UserHostAddress.ToString();
          string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
        VisitSiteLog objVisitSiteLog = new VisitSiteLog();

        objVisitSiteLog.USp_secondcarlaonsapplication(2001 ,DateTime.Now ,strIp,txt_Fname.Text ,
         txt_LName.Text,txt_email.Text,txt_prim1.Text,Convert.ToDateTime(txtStartDate.Text).ToString() ,StrAdd.Text,City.Text,
          Sate.Text,Zipcode.Text);
        txt_Fname.Text = ""; txt_LName.Text = ""; txt_email.Text = ""; txt_prim1.Text = ""; txtStartDate.Text = ""; StrAdd.Text = ""; City.Text = ""; Sate.Text = ""; Zipcode.Text = "";  
     System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Thank you.Your application is submitted successfully.');", true);

    
    }
}
