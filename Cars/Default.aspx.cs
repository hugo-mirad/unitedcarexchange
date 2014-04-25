using System;
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
using System.Net;
using CarsBL.Transactions;
public partial class _Default : System.Web.UI.Page
{

    UserRegistration objUserregBL = new UserRegistration();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String strHostName = Request.UserHostAddress.ToString();
            string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            // string strIp1 = System.Net.Dns.GetHostAddresses(strHostName).GetValue(1).ToString();

            //--------------------


            //-------------------------------------

            GeneralFunc.SaveSiteVisit();
            GeneralFunc.SetPageDefaults(Page);
            //if (Session[Constants.NAME] == null)
            //{
            //    lnkLogin.Visible = true;
            //    lnkBtnLogout.Visible = false;
            //    lblUserName.Visible = false;
            //    lblWelcome.Visible = false;
            //}
            //else
            //{
            //    lnkLogin.Visible = false;
            //    lnkBtnLogout.Visible = true;
            //    lblUserName.Visible = true;
            //    lblWelcome.Visible = true;
            //    lblUserName.Text = Session[Constants.NAME].ToString();
            //}


            if (Session["regRedirect"] != null)
            {
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Please check your mailbox to get login details..!')", true);
                Session["regRedirect"] = null;
            }

            Session["CurrentPage"] = "Home";

            KeyWords.Addkeywordstags(Header);

            Session["PageName"] = "Home";
           
            Session["CurrentPageConfig"] = null;


            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            //Hidden Values


            hdnIPAddress.Value = strIp.ToString();


            // **************** New Code **************************** //

            if (Request.Cookies["IpCookie"] == null)
            {
                HttpCookie statusCookie = new HttpCookie("IpCookie");
                Response.Cookies["IpCookie"].Value = strIp;
            }
            else
            {




            }
            if (Request.Cookies["Zipcookie"] == null)
            {
                HttpCookie zipCookie = new HttpCookie("Zipcookie");
                Response.Cookies["Zipcookie"].Value = "Zipcode";

            }
            else
            {
            }
            if (Request.Cookies["Statuscookie"] == null)
            {
                HttpCookie statusCookie = new HttpCookie("Statuscookie");
                Response.Cookies["Statuscookie"].Value = "false";
            }
            else
            {


                if (Convert.ToString(Request.Cookies["Statuscookie"].Value) != "false")
                {
                    //Session[Constants.NAME] = "test";
                    DataSet dsPerformLogin = new DataSet();
                    string LogStatusDetails = Request.Cookies["Statuscookie"].Value;
                    string[] splitString = LogStatusDetails.Split(',');

                    string LodSta = splitString[0].Trim();
                    string Loduserid = splitString[1].Trim();
                    string Lodpwd = splitString[2].Trim();
                    Loduserid = DecryptPassword(Loduserid);
                    Lodpwd = DecryptPassword(Lodpwd);

                    dsPerformLogin = objUserregBL.PerformLogin(Loduserid, Lodpwd);
                    Session[Constants.USER_ID] = dsPerformLogin.Tables[0].Rows[0]["UId"];
                    Session[Constants.USER_NAME] = dsPerformLogin.Tables[0].Rows[0]["UserName"];
                    Session[Constants.NAME] = dsPerformLogin.Tables[0].Rows[0]["Name"];
                    Session[Constants.PhoneNumber] = dsPerformLogin.Tables[0].Rows[0]["PhoneNumber"];

                    Session["PackageID"] = dsPerformLogin.Tables[0].Rows[0]["PackageID"];

                    Response.Redirect("Account.aspx");
                }
            }

            if (Request.Cookies["SearchCookie"] == null)
            {
                HttpCookie statusCookie = new HttpCookie("SearchCookie");
                Response.Cookies["SearchCookie"].Value = "make-model-year";
            }
            else
            {
            }
            if (Request.Cookies["PrefCookie"] == null)
            {
                HttpCookie statusCookie = new HttpCookie("PrefCookie");
                Response.Cookies["PrefCookie"].Value = "Pref";
                GeneralFunc.SaveCookieData("Zipcode", strIp, DateTime.Now, DateTime.Now, false, "General", null, "Zipcode");
            }
            else
            {
            }
        }
    }


    public string DecryptPassword(string encryptedPassword)
    {
        byte[] passByteData = Convert.FromBase64String(encryptedPassword);
        string originalPassword = System.Text.Encoding.Unicode.GetString(passByteData);
        return originalPassword;
    }
}
