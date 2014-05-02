using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarsInfo;
using CarsBL.Masters;
using System.Collections.Generic;
using System.Net.Mail;
using CarsBL.Transactions;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Xml;
using System.Data;


public partial class UserControl_HeadderBlogin : System.Web.UI.UserControl
{
    DropdownBL objdropdownBL = new DropdownBL();
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {
            FillMakes();
            FillModels();
            FillWithin();
            HttpCookie UserCookies = Request.Cookies["UserSettings"];

            if (UserCookies == null)
            {

                // mpesubscribe.Show();




                if (Session["PageName"] != "Email Prefereces" && Session["PageName"] != "Unsubscribe")
                {
                    if (Session[Constants.Subscribe] == null)
                    {
                        //SetPostalCodeJavascript();
                    }
                }
            }
        }

        if (Request.Cookies["userZip"] == null)
        {
            Response.Cookies["userZip"].Value = "";
            //Response.Cookies["userZip"].Expires = DateTime.Now.AddMinutes(1); // add expiry time
        }



        /*
        string cookievalue;
        if (Request.Cookies["userZip"] != null)
        {
            HttpCookie myCookie = new HttpCookie("userZip");
            myCookie = Request.Cookies["userZip"];
            cookievalue = Request.Cookies["userZip"].ToString();
            Response.Write("<p>" + myCookie.Name + "<p>" + myCookie.Value);
        }
        else
        {
            Response.Cookies["userZip"].Value = "";
            //Response.Cookies["userZip"].Expires = DateTime.Now.AddMinutes(1); // add expiry time
        }
       */


        if (Session[Constants.NAME] != null)
        {
            logoutLi.Visible = true;
            accountLi.Visible = true;
            reviewLi.Visible = false;

            loginLi.Visible = false;
            sellLi.Visible = false;


        }
        else
        {
            logoutLi.Visible = false;
            accountLi.Visible = false;
            reviewLi.Visible = false;

            loginLi.Visible = true;
            sellLi.Visible = true;
        }

       
        //string Pref="";
        //if (Request.Cookies["PrefCookie"] != null)
        //    {
        //        Pref = Request.Cookies["PrefCookie"].Value;
        //    }
        //if (Pref == "Pref" && Session[Constants.NAME] != null)
        //{
        //    loginLi.Visible = false;
        //    logoutLi.Visible = true;
        //}
        //else
        //{
        //    loginLi.Visible = false; ;
        //    logoutLi.Visible = true;
        //}



        if (Session["CurrentPage"] == "Account" || Session["CurrentPage"] == "Reviews")
        {
            accountLi.Attributes.Add("class", "active");
        }

        else if (Session["CurrentPage"] == "Login")
        {
            loginLi.Attributes.Add("class", "active");
        }
        else if (Session["CurrentPage"] == "Used Cars")
        {
            usedCarsLi.Attributes.Add("class", "active");
        }
        else if (Session["CurrentPage"] == "New Cars")
        {
            newCarsLi.Attributes.Add("class", "active");
        }
        else if (Session["CurrentPage"] == "Home")
        {
            homeLi.Attributes.Add("class", "active");

        }
        else if (Session["CurrentPage"] == "Packages" || Session["CurrentPage"] == "Registration" || Session["CurrentPage"] == "Registration PlaceAd" || Session["CurrentPage"] == "Registration PlaceAd Photos")
        {
            sellLi.Attributes.Add("class", "active menuparent has-regularmenu");

        }



    }


    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Cookies["Statuscookie"].Value = "false";
            Response.Cookies["PrefCookie"].Value = "Pref";
            // Update Time of closing application

            string IPAddress = Request.Cookies["IpCookie"].Value;

            VisitSiteLog objVisitSiteLog = new VisitSiteLog();
            objVisitSiteLog.UpdatetimeCookie(IPAddress, DateTime.Now);
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void FillMakes()
    {

        try
        {
            var obj = new List<MakesInfo>();


            MakesBL objMakesBL = new MakesBL();
            if (Cache["Makes"] == null)
            {
                obj = (List<MakesInfo>)objMakesBL.GetMakes1();
            }
            else
            {
                obj = (List<MakesInfo>)Cache["Makes"];
            }



            Session["Makes"] = obj;


            ddlmakesp.DataSource = obj;
            ddlmakesp.DataTextField = "Make";
            ddlmakesp.DataValueField = "MakeID";
            ddlmakesp.DataBind();
            ddlmakesp.Items.Insert(0, new ListItem("Select", "0"));



        }
        catch (Exception ex)
        {
        }
    }
    private void GetModelsInfo(string MakeID, DropDownList DdlModel)
    {
        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Cache["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Cache["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Cache["Model"];
        }

        ddlmodelsp.Items.Clear();

        ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));

        ddlmodelsp.DataSource = obj.FindAll(p => p.MakeID == Convert.ToInt32(MakeID));
        ddlmodelsp.DataTextField = "Model";
        ddlmodelsp.DataValueField = "MakeModelID";
        ddlmodelsp.DataBind();


    }


    protected void btnSubscribe_Click(object sender, EventArgs e)
    {

        //mpesubscribe.Hide();

        //PreferencesBL objPreferencesBL = new PreferencesBL();

        //DataSet dssub = new DataSet();

        //PreferenceInfo ObjPreferncesInfo = new PreferenceInfo();

        //PreferncesItemsInfo ObjPreferncesItemsInfo = new PreferncesItemsInfo();


        //ObjPreferncesInfo.PreferenceID = "0";

        //ObjPreferncesInfo.Zip = txtZip.Text;

        //ObjPreferncesInfo.Name = txtName.Text;

        //if (txtEmailAlert.Text != "Your Email")
        //{
        //    ObjPreferncesInfo.Email = txtEmailAlert.Text;
        //}

        //if (txtPhoneNo.Text != "Your Phone")
        //{
        //    ObjPreferncesInfo.Phone = txtPhoneNo.Text;
        //}

        //String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();

        //ObjPreferncesInfo.IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


        //if (Request.Cookies["UserSettings"] == null)
        //{
        //    HttpCookie myCookie = new HttpCookie("UserSettings");

        //    myCookie.Expires = DateTime.Now.AddDays(500);

        //    myCookie.Values.Add("Email", ObjPreferncesInfo.Email);
        //    myCookie.Values.Add("Name", ObjPreferncesInfo.Name);
        //    myCookie.Values.Add("Phone", ObjPreferncesInfo.Phone);

        //    Response.Cookies.Add(myCookie);
        //}


        //ObjPreferncesItemsInfo.Makeid = ddlMake1.SelectedValue;
        //ObjPreferncesItemsInfo.ModelID = ddlModel1.SelectedValue;
        //ObjPreferncesItemsInfo.PriceRange = ddlRange1.SelectedValue;


        //DataSet dsEmailExist = new DataSet();

        //DataSet dsPreferences = new DataSet();

        //dsEmailExist = objPreferencesBL.GetEmailPreferencesbyEmail(txtEmailAlert.Text);

        //if (dsEmailExist.Tables[0].Rows.Count == 0)
        //{
        //    dsPreferences = objPreferencesBL.SaveSubscribe(ObjPreferncesInfo, 1);


        //    for (int i = 1; i < 6; i++)
        //    {
        //        string SelectedMake = string.Empty;
        //        string SelectedModel = string.Empty;
        //        string SelectedRange = string.Empty;

        //        if (i == 1)
        //        {
        //            SelectedMake = ddlMake1.SelectedValue;
        //            SelectedModel = ddlModel1.SelectedValue;
        //            SelectedRange = ddlRange1.SelectedValue;
        //        }
        //        else if (i == 2)
        //        {
        //            SelectedMake = ddlMake2.SelectedValue;
        //            SelectedModel = ddlModel2.SelectedValue;
        //            SelectedRange = ddlRange2.SelectedValue;
        //        }
        //        else if (i == 3)
        //        {
        //            SelectedMake = ddlMake3.SelectedValue;
        //            SelectedModel = ddlModel3.SelectedValue;
        //            SelectedRange = ddlRange3.SelectedValue;
        //        }
        //        else if (i == 4)
        //        {
        //            SelectedMake = ddlMake4.SelectedValue;
        //            SelectedModel = ddlModel4.SelectedValue;
        //            SelectedRange = ddlRange4.SelectedValue;
        //        }
        //        else if (i == 5)
        //        {
        //            SelectedMake = ddlMake5.SelectedValue;
        //            SelectedModel = ddlModel5.SelectedValue;
        //            SelectedRange = ddlRange5.SelectedValue;
        //        }
        //        if (SelectedMake != "0" && SelectedModel != "0")
        //        {

        //            ObjPreferncesItemsInfo.Makeid = SelectedMake;


        //            ObjPreferncesItemsInfo.ModelID = SelectedModel;

        //            ObjPreferncesItemsInfo.PreferenceID = "0";

        //            ObjPreferncesItemsInfo.PriceRange = SelectedRange;

        //            ObjPreferncesItemsInfo.UserPreferID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

        //            dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, true);
        //        }
        //    }
        //    clsMailFormats format = new clsMailFormats();

        //    MailMessage msg = new MailMessage();

        //    msg.From = new MailAddress(txtEmailAlert.Text);


        //    msg.To.Add("shravan@datumglobal.net");

        //    //msg.Bcc.Add();

        //    msg.Subject = "Welcome to your personalized weekly email alerts preferences.";

        //    msg.IsBodyHtml = true;

        //    string text = string.Empty;

        //    string VerifyPreferences = string.Empty;

        //    string ModifyPreferences = string.Empty;

        //    string PreferencesID = string.Empty;

        //    //VerifyPreferences = "mobicarz.com/VerifyPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

        //    //ModifyPreferences = "mobicarz.com/EmailPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

        //    PreferencesID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

        //    GeneralFunc obj = new GeneralFunc();

        //    text = format.SendEMailPreferences(GeneralFunc.ToProper(dsPreferences.Tables[0].Rows[0]["Name"].ToString()), dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString(), ref text);

        //    msg.Body = text.ToString();

        //    SmtpClient smtp = new SmtpClient();

        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
        //    smtp.EnableSsl = true;
        //    smtp.Send(msg);


        //    //smtp.Host = "127.0.0.1";
        //    //smtp.Port = 25;
        //    //smtp.Send(msg);


        //    // Progress111.Visible = false;


        //    Type cstype = GetType();

        //    ClientScriptManager cs = Page.ClientScript;

        //    cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

        //    lblAlertMsg.Text = "Thank you for signing up for automatic email alerts..";
        //    //mpealert.Show();
        //}
        //else
        //{

        //    Type cstype = GetType();

        //    ClientScriptManager cs = Page.ClientScript;

        //    cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");


        //    lblAlertMsg.Text = "Email ID Already Subscribed..";
        //    //mpealert.Show();

        //}
    }

    private void FillWithin()
    {

        try
        {
            DataSet dsYears = new DataSet();
            if (Session["CarsYears"] == null)
            {
                dsYears = objdropdownBL.GetYears();
                Session["CarsYears"] = dsYears;
            }
            else
            {
                dsYears = Session["CarsYears"] as DataSet;
            }
            ddlyearp.DataSource = dsYears.Tables[0];
            ddlyearp.DataTextField = "Year";
            ddlyearp.DataValueField = "Year";
            ddlyearp.DataBind();
            ddlyearp.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillModels()
    {

        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Cache["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Cache["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Cache["Model"];
        }

    }
    protected void ddlmakesp_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string Pref = "";
        ddlmodelsp.Enabled = true;
        if (ddlmakesp.SelectedIndex > 0)
        {
            GetModelsInfo(ddlmakesp.SelectedValue, ddlmodelsp);
        }
        else
        {
            if (Request.Cookies["PrefCookie"] != null)
            {
                Pref = Request.Cookies["PrefCookie"].Value;
            }
            if (Pref != "Pref")
            {
                ddlmodelsp.Items.Clear();
                ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));

            }
        }
    }
    public void btnsubscr_click(object sender, EventArgs e)
    {

        string Pref = "";

        if (Request.Cookies["PrefCookie"].ToString() != "Pref")
        {
            VisitSiteLog objVisitSiteLog = new VisitSiteLog();
            DataSet dsPerformLogin = new DataSet();
            if (Request.Cookies["PrefCookie"] != null)
            {
                Pref = Request.Cookies["PrefCookie"].Value;
            }

            dsPerformLogin = objVisitSiteLog.RetriveSubInformation(Pref);
            if (dsPerformLogin.Tables[0].Rows.Count > 0)
            {
                FillMakes();
                FillWithin();
                ddlmakesp.SelectedIndex = 0;
                ddlmakesp.SelectedIndex = Convert.ToInt32(dsPerformLogin.Tables[0].Rows[0]["Makeid"].ToString());
                ddlmodelsp.Items.Clear();



                string[] result = Pref.Split('-');
                ddlmodelsp.Items.Insert(0, new ListItem(result[1], "0"));



                // ddlmodelsp.SelectedValue =dsPerformLogin.Tables[0].Rows[0]["ModelID"].ToString();
                ddlyearp.SelectedValue = dsPerformLogin.Tables[0].Rows[0]["Year"].ToString();
                txtfnamep.Text = dsPerformLogin.Tables[0].Rows[0]["FirstName"].ToString();
                txtlastnamep.Text = dsPerformLogin.Tables[0].Rows[0]["LastName"].ToString();
                txtemail.Text = dsPerformLogin.Tables[0].Rows[0]["Email"].ToString();
                //ddlmakesp.SelectedIndex = 0;
                //ddlmodelsp.SelectedIndex = 0;
                //txtemail.Text = ""; txtfnamep.Text = ""; txtlastnamep.Text = "";
                mpesubscribe.Show();
            }
            else
            {
                ddlmakesp.SelectedIndex = 0;
                ddlmodelsp.SelectedIndex = 0;
                //ddlyearp.SelectedIndex = 0;
                txtemail.Text = ""; txtfnamep.Text = ""; txtlastnamep.Text = "";
                mpesubscribe.Show();

            }
        }
    }
    public void btnSubok_click(object sender, EventArgs e)
    {
        if (ddlmakesp.SelectedIndex != 0)
        {
            if (ddlyearp.SelectedIndex != 0)
            {

                String strHostName = Request.UserHostAddress.ToString();
                string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

                Response.Cookies["PrefCookie"].Value = ddlmakesp.SelectedItem + "- " + ddlmodelsp.SelectedItem + " -" + ddlyearp.Text;
                Session["Pref"] = Response.Cookies["PrefCookie"].Value;
                VisitSiteLog objVisitSiteLog = new VisitSiteLog();
                objVisitSiteLog.SaveSubInformation(Convert.ToInt32(ddlmakesp.SelectedValue), Convert.ToInt32(ddlmodelsp.SelectedValue),
                    Convert.ToInt32(ddlyearp.SelectedValue), txtfnamep.Text, txtlastnamep.Text, txtemail.Text, strIp, DateTime.Now, Session["Pref"].ToString());
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "EmailNAClick();", true);
                mpesubscribe.Hide();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('You are subscribed suceessfully for email alerts.');", true);

            }
        }
    }

    public void btncancelp_click(object sender, EventArgs e)
    {
        mpesubscribe.Hide();
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "resetTimer();", true);
    }
}


