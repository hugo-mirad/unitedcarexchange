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
using CarsInfo;
using CarsBL.Transactions;
using System.Net.Mail;

public partial class PaymentSucces : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CurrentPage"] = "Home";

            Session["CurrentPageConfig"] = null;
            Session["PageName"] = "";
            GeneralFunc.SetPageDefaults(Page);
            BankDetailsBL objBankDetailsBL = new BankDetailsBL();
            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            PmntDetailsinfo objPmntDetailsinfo = new PmntDetailsinfo();


            int CarID;

            if ((Session["CarID"] == null) || (Session["CarID"].ToString() == ""))
            {
                CarID = Convert.ToInt32(0);
            }
            else
            {
                CarID = Convert.ToInt32(Session["CarID"].ToString());
            }
            int UID = 0;

            if (Session["RegUSER_ID"] != null)
            {
                UID = Convert.ToInt32(Session["RegUSER_ID"].ToString());
            }


            if (UID != 0)
            {
                int PackageID = Convert.ToInt32(Request.QueryString["item_number"].ToString());

                string packageName = string.Empty;

                if (PackageID == 1)
                {
                    packageName = "Basic - FREE";
                }
                else if (PackageID == 2)
                {
                    packageName = "Standard";
                }
                else if (PackageID == 3)
                {
                    packageName = "Enhanced";
                }
                else if (PackageID == 4)
                {
                    packageName = "Silver Deluxe";
                }
                else if (PackageID == 5)
                {
                    packageName = "Gold Deluxe";
                }
                else if (PackageID == 6)
                {
                    packageName = "Platinum Deluxe";
                }

                lblPackage.Text = packageName;


                if (Session["PayBy"] == null)
                {
                    //Request.QueryString["item_number"]
                    //tx=02R12984CT146441A&st=Completed&amt=0.10&cc=USD&cm=&item_number=2


                    objPmntDetailsinfo.Currency = Request.QueryString["cc"];

                    lblamount.Text = Request.QueryString["amt"];

                    lblCurrency.Text = objPmntDetailsinfo.Currency;

                    lbluser.Text = Session["RegName"].ToString();
                    objPmntDetailsinfo.Amount = lblamount.Text;


                    txtTran.Text = Request.QueryString["tx"];


                    objPmntDetailsinfo.TransactionID = Request.QueryString["tx"];
                    objPmntDetailsinfo.PmntType = 1;

                    if (Request.QueryString["st"] != null)
                    {
                        if (Request.QueryString["st"].ToString() == "Completed")
                        {
                            objPmntDetailsinfo.PmntStatus = 2;
                        }
                        else
                        {
                            objPmntDetailsinfo.PmntStatus = 4;
                        }
                    }
                    else
                    {
                        objPmntDetailsinfo.PmntStatus = 4;
                    }

                    String strHostName = Request.UserHostAddress.ToString();
                    string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                    objPmntDetailsinfo.IPAddress = strIp;

                    int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                    int UserPackID = Convert.ToInt32(Session["RegUserPackID"].ToString());
                    bool bnew = objBankDetailsBL.UpdatePmntStatus(objPmntDetailsinfo, PackageID, UID, CarID, UserPackID, PostingID);

                }
                else
                {
                    ///NetCode="+ReturnValues[4].Trim(char.Parse("|"))+"&TransID="+ReturnValues[6].Trim(char.Parse("|"))
                    ///



                    objPmntDetailsinfo.Currency = Request.QueryString["cc"];

                    lblamount.Text = Request.QueryString["amt"];

                    lblCurrency.Text = objPmntDetailsinfo.Currency;

                    lbluser.Text = Session["RegName"].ToString();

                    objPmntDetailsinfo.Amount = lblamount.Text;
                    txtTran.Text = Request.QueryString["NetCode"];

                    objPmntDetailsinfo.TransactionID = Request.QueryString["NetCode"];

                    objPmntDetailsinfo.PmntStatus = 2;

                    objPmntDetailsinfo.CardType = Session["PayBy"].ToString();
                    objPmntDetailsinfo.PmntType = 1;

                    String strHostName = Request.UserHostAddress.ToString();
                    string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                    objPmntDetailsinfo.IPAddress = strIp;


                    int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                    int UserPackID = Convert.ToInt32(Session["RegUserPackID"].ToString());
                    bool bnew = objBankDetailsBL.UpdatePmntStatus(objPmntDetailsinfo, PackageID, UID, CarID, UserPackID, PostingID);


                }
                string LoginPassword = Session["RegPassword"].ToString();
                string LoginName = Session["RegUserName"].ToString();
                SendRegisterMail(LoginName, LoginPassword);

            }


            //UpdatePmntStatus(PmntDetailsinfo objPmntDetailsinfo, int PackageID, int UID, int CarID)

        }
    }
    private void SendRegisterMail(string LoginName, string LoginPassword)
    {
        try
        {
            string UserDisName = Session["RegName"].ToString();
            string UserLoginID = Session["RegLogUserID"].ToString();

            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(CommonVariable.FromInfoMail);
            msg.To.Add(LoginName);
            msg.Bcc.Add(CommonVariable.ArchieveMail);
            msg.Subject = "Registration details from United Car Exchange for Car ID# " + Session["CarID"].ToString();
            msg.IsBodyHtml = true;
            string text = string.Empty;
            text = format.SendRegistrationdetails(UserLoginID, LoginPassword, UserDisName, ref text);
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
        }
        catch (Exception ex)
        {
        }
    }
}
