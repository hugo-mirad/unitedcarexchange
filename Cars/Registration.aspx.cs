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

public partial class Registration : System.Web.UI.Page
{

    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    UserRegistration objUserregBL = new UserRegistration();
    UserRegistrationInfo objUserRegInfo = new UserRegistrationInfo();
    public GeneralFunc objGeneralFunc = new GeneralFunc();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GeneralFunc.SaveSiteVisit();
            //lblpackagename.Text = Session["PackgeName"].ToString();
            if (Session["PackageID"] != null && Session["PackgeName"] != null && Session["PackgePrice"] != null)
            {
                lblpackagename.Text = Session["PackgeName"].ToString();
                lblpckgprice.Text = Session["PackgePrice"].ToString();
            }
            else
            {
                Response.Redirect("Sellregi.aspx");

            }

            Session["CurrentPage"] = "Registration";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;
            GeneralFunc.SetPageDefaults(Page);

            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);



            if (Session[Constants.USER_NAME] != null)
            {
                if (Session[Constants.USER_NAME].ToString() != "")
                {
                    Response.Redirect("Default.aspx");
                }
            }
            dsDropDown = objdropdownBL.Usp_Get_DropDown();

            FillStates();

            //Filling pack Details
            try
            {
                if (Session["PackageID"].ToString() == "4")
                {
                    lblpackagFet.Text = Session["regular"].ToString();
                }
                else if (Session["PackageID"].ToString() == "5")
                {
                    lblpackagFet.Text = Session["premium"].ToString();
                }
                else if (Session["PackageID"].ToString() == "6")
                {
                    lblpackagFet.Text = Session["Deluxe"].ToString();
                }
            }
            catch { }


            if (Session["Registration"] != null)
            {
                fillAllDetail();
            }
        }
    }



    protected void fillAllDetail()
    {

        //USP_RegisterDetails
        try
        {

            DataSet dsUserInfo = objUserregBL.USP_RegisterDetails(Convert.ToInt32(Session["RegUSER_ID"].ToString()));
            txtContcname.Text = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
            TextBox1.Text = dsUserInfo.Tables[0].Rows[0]["lastname"].ToString();

            txtphone.Text = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
            txtAltPhone.Text = dsUserInfo.Tables[0].Rows[0]["AltPhone"].ToString();

            txtemail.Text = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
            txtconfEmail.Text = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();

            txtPassword.Text = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
            txtConfirmPassword.Text = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();

            txtBusinessName.Text = dsUserInfo.Tables[0].Rows[0]["BusinessName"].ToString();
            txtAltEmail.Text = dsUserInfo.Tables[0].Rows[0]["AltEmail"].ToString();

            txtRegAddress.Text = dsUserInfo.Tables[0].Rows[0]["Address"].ToString();
            txtRegCity.Text = dsUserInfo.Tables[0].Rows[0]["City"].ToString();
            ddlLocationState.Text = dsUserInfo.Tables[0].Rows[0]["StateID"].ToString();

            txtRegZip.Text = dsUserInfo.Tables[0].Rows[0]["Zip"].ToString();
            txtCoupon.Text = dsUserInfo.Tables[0].Rows[0]["CouponCode"].ToString();

            txtRefferedBy.Text = dsUserInfo.Tables[0].Rows[0]["ReferCode"].ToString();
        }
        catch { }
    }

    protected void btnregister_Click(object sender, EventArgs e)
    {
        try
        {

            if (Session["Registration"] == null)
            {

                Session["sName"] = GeneralFunc.ToProper(txtContcname.Text).Trim();
                Session["sEmail"] = txtemail.Text;
                Session["sPhone"] = txtphone.Text;

                objUserRegInfo.Name = GeneralFunc.ToProper(txtContcname.Text).Trim();
                objUserRegInfo.UserName = txtemail.Text;
                objUserRegInfo.Pwd = txtPassword.Text;
                objUserRegInfo.PhoneNumber = txtphone.Text;
                string RegPhone = txtphone.Text;
                objUserRegInfo.CouponCode = txtCoupon.Text;
                objUserRegInfo.ReferCode = txtRefferedBy.Text;
                objUserRegInfo.Address = GeneralFunc.ToProper(txtRegAddress.Text).Trim();
                objUserRegInfo.City = GeneralFunc.ToProper(txtRegCity.Text).Trim();
                objUserRegInfo.StateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
                objUserRegInfo.BusinessName = txtBusinessName.Text;
                objUserRegInfo.AltEmail = txtAltEmail.Text;
                objUserRegInfo.AltPhone = txtAltPhone.Text;
                if (txtRegZip.Text.Length == 4)
                {
                    objUserRegInfo.Zip = "0" + txtRegZip.Text;
                }
                else
                {
                    objUserRegInfo.Zip = txtRegZip.Text;
                }
                if (Session["PackageID"] == null)
                {
                    Session["PackageID"] = 0;
                    objUserRegInfo.PackageID = Convert.ToInt32(Session["PackageID"].ToString());
                }
                else if (Session["PackageID"].ToString() == "")
                {
                    Session["PackageID"] = 0;
                    objUserRegInfo.PackageID = Convert.ToInt32(Session["PackageID"].ToString());
                }
                else
                {
                    objUserRegInfo.PackageID = Convert.ToInt32(Session["PackageID"].ToString());
                }
                string UserID;
                string FistName = GeneralFunc.ToProper(txtContcname.Text).Trim();
                if (FistName.Length > 3)
                {
                    FistName = FistName.Substring(0, 3);
                }
                string s = "";
                int j;
                Random random1 = new Random();
                for (j = 1; j < 4; j++)
                {
                    s += random1.Next(0, 9).ToString();
                }
                UserID = FistName + RegPhone;
                int EmailExists = 1;

                DataSet dsPhoneExists = objdropdownBL.ChkUserExistsPhoneNumber(RegPhone);
                if (dsPhoneExists.Tables.Count > 0)
                {
                    if (dsPhoneExists.Tables[0].Rows.Count > 0)
                    {
                        mdepAlertExists.Show();
                        lblErrorExists.Visible = true;
                        lblErrorExists.Text = "Phone number " + RegPhone + " already exists";
                    }
                    else
                    {
                        DataSet dsUserExists = objUserregBL.USP_ChkUserExists(txtemail.Text);

                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + txtemail.Text + " already exists";
                            }
                            else
                            {
                                DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                if (dsUserIDExists.Tables.Count > 0)
                                {
                                    if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                    {
                                        UserID = UserID + s.ToString();
                                        DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                        Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                        Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                        Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                        Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                        Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                        Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                        Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                        Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                        //Session[Constants.NAME] = Session["RegUserName"]; 
                                        //Session[Constants.USER_ID] = Session["RegUSER_ID"];
                                        Session["Registration"] = "Registration";


                                        string LoginPassword = txtPassword.Text;
                                        string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();

                                        try
                                        {
                                            DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                            Session["Lastname"] = TextBox1.Text;
                                        }
                                        catch { }
                                        //SendRegisterMail(LoginName, LoginPassword);
                                        Response.Redirect("RegisterPlaceAd.aspx");
                                        //mpealteruser.Show();
                                        //lblErr.Visible = true;
                                        //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                    }
                                    else
                                    {
                                        DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                        Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                        Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                        Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                        Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                        Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                        Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                        Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                        Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                        //Session[Constants.NAME] = Session["RegUserName"]; 
                                        //Session[Constants.USER_ID] = Session["RegUSER_ID"];


                                        string LoginPassword = txtPassword.Text;
                                        string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                        Session["Registration"] = "Registration";
                                        //SendRegisterMail(LoginName, LoginPassword);
                                        try
                                        {
                                            DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                            Session["Lastname"] = TextBox1.Text;
                                        }
                                        catch { }
                                        Response.Redirect("RegisterPlaceAd.aspx", false);
                                        //mpealteruser.Show();
                                        //lblErr.Visible = true;
                                        //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                    }
                                }
                                else
                                {
                                    DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                    Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                    Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                    Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                    Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                    Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                    Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                    Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                    Session["Lastname"] = TextBox1.Text;
                                    Session["Registration"] = "Registration";
                                    //Session[Constants.NAME] = Session["RegUserName"]; 
                                    //Session[Constants.USER_ID] = Session["RegUSER_ID"];


                                    string LoginPassword = txtPassword.Text;
                                    string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    //SendRegisterMail(LoginName, LoginPassword);
                                    try
                                    {
                                        DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                        Session["Lastname"] = TextBox1.Text;
                                    }
                                    catch { }

                                    Response.Redirect("RegisterPlaceAd.aspx");
                                    //mpealteruser.Show();
                                    //lblErr.Visible = true;
                                    //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                }

                            }
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                    Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                    Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                    Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                    Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                    Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                    Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                    Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                    string LoginPassword = txtPassword.Text;
                                    string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["Registration"] = "Registration";
                                    try
                                    {
                                        DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                        Session["Lastname"] = TextBox1.Text;
                                    }
                                    catch { }
                                    //SendRegisterMail(LoginName, LoginPassword);
                                    Response.Redirect("RegisterPlaceAd.aspx");
                                    //mpealteruser.Show();
                                    //lblErr.Visible = true;
                                    //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                }
                                else
                                {
                                    DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                    Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                    Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                    Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                    Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                    Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                    Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                    Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                    string LoginPassword = txtPassword.Text;
                                    string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["Registration"] = "Registration";
                                    try
                                    {
                                        DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                        Session["Lastname"] = TextBox1.Text;
                                    }
                                    catch { }
                                    //SendRegisterMail(LoginName, LoginPassword);
                                    Response.Redirect("RegisterPlaceAd.aspx");
                                    //mpealteruser.Show();
                                    //lblErr.Visible = true;
                                    //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                }
                            }
                            else
                            {
                                DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                string LoginPassword = txtPassword.Text;
                                string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["Registration"] = "Registration";
                                try
                                {
                                    DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                    Session["Lastname"] = TextBox1.Text;
                                }
                                catch { }
                                //SendRegisterMail(LoginName, LoginPassword);
                                Response.Redirect("RegisterPlaceAd.aspx");
                                //mpealteruser.Show();
                                //lblErr.Visible = true;
                                //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                            }

                        }
                    }
                }
                else
                {
                    DataSet dsUserExists = objUserregBL.USP_ChkUserExists(txtemail.Text);

                    if (dsUserExists.Tables.Count > 0)
                    {
                        if (dsUserExists.Tables[0].Rows.Count > 0)
                        {
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Email " + txtemail.Text + " already exists";
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                    Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                    Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                    Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                    Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                    Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                    Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                    Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                    Session["Registration"] = "Registration";
                                    //Session[Constants.NAME] = Session["RegUserName"]; 
                                    //Session[Constants.USER_ID] = Session["RegUSER_ID"];


                                    string LoginPassword = txtPassword.Text;
                                    string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    try
                                    {
                                        DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                        Session["Lastname"] = TextBox1.Text;
                                    }
                                    catch { }
                                    //SendRegisterMail(LoginName, LoginPassword);
                                    Response.Redirect("RegisterPlaceAd.aspx");
                                    //mpealteruser.Show();
                                    //lblErr.Visible = true;
                                    //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                }
                                else
                                {
                                    DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                    Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                    Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                    Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                    Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                    Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                    Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                    Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                    Session["Registration"] = "Registration";
                                    //Session[Constants.NAME] = Session["RegUserName"]; 
                                    //Session[Constants.USER_ID] = Session["RegUSER_ID"];


                                    string LoginPassword = txtPassword.Text;
                                    string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                    //SendRegisterMail(LoginName, LoginPassword);
                                    Response.Redirect("RegisterPlaceAd.aspx");
                                    //mpealteruser.Show();
                                    //lblErr.Visible = true;
                                    //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                                }
                            }
                            else
                            {
                                DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                Session["Registration"] = "Registration";


                                string LoginPassword = txtPassword.Text;
                                string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                try
                                {
                                    DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                    Session["Lastname"] = TextBox1.Text;
                                }
                                catch { }
                                //SendRegisterMail(LoginName, LoginPassword);
                                Response.Redirect("RegisterPlaceAd.aspx");

                            }

                        }
                    }
                    else
                    {
                        DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                        if (dsUserIDExists.Tables.Count > 0)
                        {
                            if (dsUserIDExists.Tables[0].Rows.Count > 0)
                            {
                                UserID = UserID + s.ToString();
                                DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                string LoginPassword = txtPassword.Text;
                                string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["Registration"] = "Registration";
                                //SendRegisterMail(LoginName, LoginPassword);
                                try
                                {
                                    DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));

                                }
                                catch { }
                                Response.Redirect("RegisterPlaceAd.aspx");
                                //mpealteruser.Show();
                                //lblErr.Visible = true;
                                //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                            }
                            else
                            {
                                DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                                Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                                Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                                Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                                Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                                Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                                Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                                Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                                string LoginPassword = txtPassword.Text;
                                string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                                Session["Registration"] = "Registration";
                                try
                                {
                                    DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                    Session["Lastname"] = TextBox1.Text;
                                }
                                catch { }
                                //SendRegisterMail(LoginName, LoginPassword);
                                Response.Redirect("RegisterPlaceAd.aspx");
                                //mpealteruser.Show();
                                //lblErr.Visible = true;
                                //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                            }
                        }
                        else
                        {
                            DataSet dsUserInfo = objUserregBL.Usp_Save_RegisterLogUser(objUserRegInfo, EmailExists, UserID);
                            Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
                            Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                            Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
                            Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
                            Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
                            Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
                            Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                            Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                            Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
                            string LoginPassword = txtPassword.Text;
                            string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
                            Session["Registration"] = "Registration";
                            try
                            {
                                DataSet dsUserInfolast = objUserregBL.USP_lastnameUpdate(TextBox1.Text, Convert.ToInt32(Session["RegUSER_ID"].ToString()));
                                Session["Lastname"] = TextBox1.Text;
                            }
                            catch { }
                            //SendRegisterMail(LoginName, LoginPassword);
                            Response.Redirect("RegisterPlaceAd.aspx", false);
                            //mpealteruser.Show();
                            //lblErr.Visible = true;
                            //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                        }

                    }
                }


            }
            else
            {


                //Upadte Registration
                string RegPhone = txtphone.Text;
                string FistName = GeneralFunc.ToProper(txtContcname.Text).Trim();
                if (FistName.Length > 3)
                {
                    FistName = FistName.Substring(0, 3);
                }
                string UserID = FistName + RegPhone;
                DataSet dsUserInfolast = objUserregBL.Usp_Update_RegisterLogUser
                    (Convert.ToInt32(Session["RegUSER_ID"].ToString()), txtContcname.Text, txtemail.Text, txtPassword.Text, txtphone.Text, 1,
        txtCoupon.Text, txtRefferedBy.Text, txtRegAddress.Text, txtRegCity.Text, Convert.ToInt32(ddlLocationState.SelectedValue), txtRegZip.Text,
       Convert.ToInt32(Session["PackageID"].ToString()), txtBusinessName.Text,
       txtAltEmail.Text, txtAltPhone.Text, UserID, TextBox1.Text);

                Response.Redirect("RegisterPlaceAd.aspx", false);
            }
        }


        catch (Exception ex)
        {
        }
    }


    private void FillStates()
    {
        try
        {
            ddlLocationState.DataSource = dsDropDown.Tables[1];
            ddlLocationState.DataTextField = "State_Code";
            ddlLocationState.DataValueField = "State_ID";
            ddlLocationState.DataBind();
            ddlLocationState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnlistcar_Click(object sender, EventArgs e)
    {

    }
    protected void BtnCls_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("RegisterPlaceAd.aspx");
        }
        catch (Exception ex)
        {
        }
    }

}
