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

            Session["CurrentPage"] = "Home";
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
        }

    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        try
        {
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


                                    string LoginPassword = txtPassword.Text;
                                    string LoginName = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
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
                        //SendRegisterMail(LoginName, LoginPassword);
                        Response.Redirect("RegisterPlaceAd.aspx");
                        //mpealteruser.Show();
                        //lblErr.Visible = true;
                        //lblErr.Text = "Registered successfully <br />Do you want to add the car now?";
                    }

                }
            }


        }
        catch (Exception ex)
        {
        }
    }

    //private void SendRegisterMail(string LoginName, string LoginPassword)
    //{
    //    try
    //    {
    //        clsMailFormats format = new clsMailFormats();
    //        MailMessage msg = new MailMessage();
    //        msg.From = new MailAddress("info@UnitedCarExchange.com");
    //        msg.To.Add(LoginName);
    //        msg.Subject = "Registration details from United Car Exchange";
    //        msg.IsBodyHtml = true;
    //        string text = string.Empty;
    //        text = format.SendRegistrationdetails(LoginName, LoginPassword, ref text);
    //        msg.Body = text.ToString();
    //        SmtpClient smtp = new SmtpClient();
    //        //smtp.Host = "smtp.gmail.com";
    //        //smtp.Port = 587;
    //        //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
    //        //smtp.EnableSsl = true;
    //        //smtp.Send(msg);
    //        smtp.Host = "127.0.0.1";
    //        smtp.Port = 25;
    //        smtp.Send(msg);
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
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
            Response.Redirect("placead.aspx");
        }
        catch (Exception ex)
        {
        }
    }

}
