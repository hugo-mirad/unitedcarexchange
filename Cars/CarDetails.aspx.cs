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
using System.Collections.Generic;
using CarsBL.Masters;


public partial class CarDetails : System.Web.UI.Page
{

    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    UsedCarsInfo objUsedCarsInfo = new UsedCarsInfo();
    UserRegistrationInfo objUserInfo = new UserRegistrationInfo();
    UserRegistration objUserRegBL = new UserRegistration();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

            if (!IsPostBack)
            {
                hdnSubAlert.Value = "true";
                GeneralFunc.SetPageDefaults(Page);
                Session["CurrentPage"] = "Account";




                Session["PageName"] = "";
                Session["CurrentPageConfig"] = null;
                //KeyWords.Addkeywordstags(Header);
                GeneralFunc.SaveSiteVisit();
                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);

                string s = Session["PostingID"].ToString();
                //binding mutilsies listing
                DataSet dsCarDetailsInfo = new DataSet();
                dsCarDetailsInfo = objdropdownBL.USP_GetCustomerDetailsByPostingID(Convert.ToInt32(Session["PostingID"].ToString()));
                grdMultiSites.DataSource = dsCarDetailsInfo.Tables[4];
                grdMultiSites.DataBind();

                hdvdicarid.Value = Session["caridhdn"].ToString();
                lblUserName.Text = Session[Constants.NAME].ToString();
                try
                {
                    lblUserMemberDate.Text = Session["Memebersincedate"].ToString();
                }
                catch { }
                //   int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                //  int UID = 120;

                //dsDropDown = objdropdownBL.Usp_Get_DropDown();

                // FillStates();

                //DataSet dsUserInfoDetails1 = objdropdownBL.USP_GetUSerDetailsByUserID(UID);

                //Session["getRegUserdata"] = dsUserInfoDetails;
                //Session["getRegUserdata"] = dsUserInfoDetails1;

                // lblRegName.Text = dsUserInfoDetails1.Tables[0].Rows[0]["Name"].ToString();


                // Session["sName"] = dsUserInfoDetails1.Tables[0].Rows[0]["Name"].ToString();
                //Session["sEmail"] = dsUserInfoDetails1.Tables[0].Rows[0]["UserName"].ToString();
                //Session["sPhone"] = objGeneralFunc.filPhnm(dsUserInfoDetails1.Tables[0].Rows[0]["PhoneNumber"].ToString());

            }
        }
    }
}
