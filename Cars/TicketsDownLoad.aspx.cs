
using System;
using System.Collections;
using System.Collections.Generic;
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
using CarsBL.CentralDBTransactions;
using CarsInfo;
using System.Net.Mail;
using CarsBL.Masters;
using CarsBL.RvTransactions;

public partial class TicketsDownLoad : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
    DataSet dsActiveSmartzUsers = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                if (Session["TicketDdl"] == null)
                {
                    SmartzTicketDdlDs = objdropdownBL.USP_SmartzTicketDropDown();
                    Session["TicketDdl"] = SmartzTicketDdlDs;
                }
                dsActiveSmartzUsers = objCentralDBBL.GetSmartzUsersActiveData();
                Session["ActiveSmartzUsers"] = dsActiveSmartzUsers;
                int SelMode = 1;
               
                Session.Timeout = 180;
            }
        }
    }

   

 


 

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {

            int SelMode;
            if (rdbtnProcessed.Checked == true)
            {
                SelMode = 3;
            }
            else if (rdbtnPending.Checked == true)
            {
                SelMode = 1;
            }
            else
            {
                SelMode = 0;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
