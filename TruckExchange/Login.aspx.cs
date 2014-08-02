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
using System.Web.UI.MobileControls;
using System.Net.Mail;

public partial class Login : System.Web.UI.Page
{
    UserRegistration objUserregBL = new UserRegistration();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session.Abandon();
            Session[Constants.USER_ID] = null;
            Session[Constants.USER_NAME] = null;
            txtEmail.Focus();

            Session["CurrentPage"] = "Home";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;

            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScript.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);


        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsPerformLogin = new DataSet();
            dsPerformLogin = objUserregBL.PerformLogin(txtEmail.Text, txtPassword.Text);
            if (dsPerformLogin != null)
            {
                if (dsPerformLogin.Tables.Count > 0)
                {
                    if (dsPerformLogin.Tables[0].Rows.Count > 0)
                    {
                        Session[Constants.USER_ID] = dsPerformLogin.Tables[0].Rows[0]["UId"];

                        Session[Constants.USER_NAME] = dsPerformLogin.Tables[0].Rows[0]["UserName"];

                        Session[Constants.NAME] = dsPerformLogin.Tables[0].Rows[0]["Name"];

                        Session[Constants.PhoneNumber] = dsPerformLogin.Tables[0].Rows[0]["PhoneNumber"];

                        Session["PackageID"] = dsPerformLogin.Tables[0].Rows[0]["PackageID"];
                        Response.Redirect("account.aspx");


                    }
                    else
                    {
                        lblError.Text = "Invalid username or password!";
                        lblError.Visible = true;
                        txtEmail.Text = "";
                        txtPassword.Text = "";


                    }

                }
                else
                {
                    // CreateUserLog(7);
                    //  objUserlog.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), System.DateTime.Now, Convert.ToInt32(Session[Constants.USERLOG_ID]), 7);

                    lblError.Text = "Invalid username or password!";
                    lblError.Visible = true;
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void lnkRegister_Click(object sender, EventArgs e)
    {
        try
        {
            //if (Session["PackageID"] != null)
            //{
            Response.Redirect("Registration.aspx");
            //}
            //else
            //{
            //    Response.Redirect("SellRegi.aspx");
            //}

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSendPwd_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsUserPwd = objUserregBL.USP_GetPasswordByID(txtForgetUserName.Text);

            if (dsUserPwd.Tables.Count > 0)
            {
                if (dsUserPwd.Tables[0].Rows.Count > 0)
                {
                    clsMailFormats format = new clsMailFormats();
                    string LoginPassword = dsUserPwd.Tables[0].Rows[0]["Pwd"].ToString();
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("info@unitedtruckexchange.com");
                    msg.To.Add(txtForgetUserName.Text);
                    msg.Bcc.Add("archive@unitedtruckexchange.com");
                    msg.Subject = "Forgot Password";
                    msg.IsBodyHtml = true;
                    string text = string.Empty;
                    text = format.SendForgetPassword(txtForgetUserName.Text, LoginPassword, ref text);
                    msg.Body = text.ToString();
                    SmtpClient smtp = new SmtpClient();
                    //smtp.Host = "smtp.gmail.com";
                    //smtp.Port = 587;
                    //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
                    //smtp.EnableSsl = true;
                    //smtp.Send(msg);
                    smtp.Host = "127.0.0.1";
                    smtp.Port = 25;
                    smtp.Send(msg);
                    mpeChangePW.Hide();
                    mpealteruser.Show();
                    lblErr.Visible = true;
                    lblErr.Text = "Password send to your mail id";

                }
                else
                {
                    mpeChangePW.Hide();
                    mpealteruser.Show();
                    lblErr.Visible = true;
                    lblErr.Text = "No user exists with " + txtForgetUserName.Text;
                }
            }
            else
            {
                mpeChangePW.Hide();
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "No user exists with " + txtForgetUserName.Text;
            }
        }
        catch (Exception ex)
        {
        }
    }
  
}
