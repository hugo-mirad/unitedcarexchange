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

public partial class ContactUs : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GeneralFunc.SaveSiteVisit();
            Session["CurrentPage"] = "Contact Us";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;
            KeyWords.Addkeywordstags(Header);

            
            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);
        }
    }
    protected void btnregister_Click(object sender, EventArgs e)
    {
        try
        {

            string Name = GeneralFunc.ToProper(txtContcname.Text).Trim();
            string Phone = txtphone.Text;
            string Email = txtemail.Text;
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(CommonVariable.FromInfoMail);
            msg.To.Add(CommonVariable.ContactUsEMail);
            msg.CC.Add(CommonVariable.ContactUsEMailCC);
            msg.Bcc.Add(CommonVariable.ArchieveMail);
            msg.Subject = "Regarding Contact request";
            msg.IsBodyHtml = true;
            string text = string.Empty;
            text = format.SendContactRequestDetails(Name, Phone, Email, ref text);
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


            mpealteruser.Show();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }

}
