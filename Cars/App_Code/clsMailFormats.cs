using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;
using System.Text;
using System.IO;


/// <summary>
/// Summary description for clsMailFormats
/// </summary>
public class clsMailFormats
{

    #region RegisterFormat


    public string SendRegistrationdetails(string Username, string Password, string Name, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegisterSuccess.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";
            if (line.Contains("###UploadUser###"))
            {
                strMail = line.Replace("###UploadUser###", Name) + "<br />";
            }
            else if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", Password) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    #endregion RegisterFormat

    #region Passwordcahnge


    public string ChangePassword(string Password, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailFormats/PasswordChange.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Password) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    #endregion Passwordcahnge
    #region UserUpdate
    public string SendUserUpdatedetails(string Username, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailFormats/UserUpdate.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", Username) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    #endregion UserUpdate

    #region CouponDownload
    public string SendCoupondownloaddetails(int CouponID, Double CouAmount, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailFormats/Coupondownload.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UploadDate###"))
            {
                strMail = line.Replace("###UploadDate###", CouponID.ToString()) + "<br />";
            }
            else if (line.Contains("###RecordCount###"))
            {
                strMail = line.Replace("###RecordCount###", CouAmount.ToString()) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    #endregion CouponDownload


    public string SendForgetPassword(string Username, string Password, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/ForgetPassword.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###UserLoginName###"))
            {
                strMail = line.Replace("###UserLoginName###", Username) + "<br />";
            }
            else if (line.Contains("###UserLoginPassword###"))
            {
                strMail = line.Replace("###UserLoginPassword###", Password) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    public string SendNewcarRequestDetails(string Username, string Phone, string Email, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/NewCarRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                strMail = line.Replace("###Cusname###", Username) + "<br />";
            }
            else if (line.Contains("###Phone###"))
            {
                strMail = line.Replace("###Phone###", Phone) + "<br />";
            }
            else if (line.Contains("###Email###"))
            {
                strMail = line.Replace("###Email###", Email) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    public string SendDealerRequestDetails(string Username, string Phone, string Email, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/DealerRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                strMail = line.Replace("###Cusname###", Username) + "<br />";
            }
            else if (line.Contains("###Phone###"))
            {
                strMail = line.Replace("###Phone###", Phone) + "<br />";
            }
            else if (line.Contains("###Email###"))
            {
                strMail = line.Replace("###Email###", Email) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    public string SendContactRequestDetails(string Username, string Phone, string Email, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/ContactRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                strMail = line.Replace("###Cusname###", Username) + "<br />";
            }
            else if (line.Contains("###Phone###"))
            {
                strMail = line.Replace("###Phone###", Phone) + "<br />";
            }
            else if (line.Contains("###Email###"))
            {
                strMail = line.Replace("###Email###", Email) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    public string SendOffermaildetails(ref string strMailFormat)
    {

        string strMail = string.Empty;
        strMail += "<html><head><title>United Car Exchange</title></head>";
        strMail += "<body style=\"padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px;\" ondragstart=\"return false\" onselectstart=\"return false\">";
        strMail += "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" height=\"100%\"><tr><td style=\"background: #f5f5f5;\" align=\"center\" valign=\"top\">";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"24\"></td></tr></table><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr>";
        strMail += "<td style=\"background: #f5f5f5;\" width=\"183\" height=\"44\"><a href=\"http://www.UnitedCarExchange.com\" target=\"_blank\"><img src=\"http://www.UnitedCarExchange.com/Offerimages/logo.jpg\" border=\"0\" /></a></td>";
        strMail += "<td style=\"background: #f5f5f5;\" width=\"417\" height=\"44\" align=\"right\"><div style=\"color: #717171; font-family: arial, verdana; font-size: 12px;\">Customer service: <b>888-786-8307</b></div><div style=\"color: #717171; font-family: arial, verdana; font-size: 10px;\">P.O. Box #504. Iselin, NJ 08830-0504</div></td>";
        strMail += "</tr></table><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"6\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"25\"><img style=\"display: block;\" src=\"http://www.UnitedCarExchange.com/Offerimages/body_header_shadow-top.jpg\" /></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"250\"><a href=\"http://www.UnitedCarExchange.com/Offers.aspx\" target=\"_blank\"><img style=\"display: block;\" src=\"http://www.UnitedCarExchange.com/Offerimages/image_header.jpg\" border=\"0\" /></a></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"27\"><img style=\"display: block;\" src=\"http://www.UnitedCarExchange.com/Offerimages/image_header_shadow.jpg\" /></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"15\"></td></tr></table>";
        strMail += "<table style=\"background: #e9e9e9;\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"24\"></td><td style=\"background: #e9e9e9; color: #555555; font-family: arial, verdana; font-size: 15px;line-height: 19px;\" width=\"552\" align=\"left\">You can now advertise your used car for $9.99 one time charge. Its Quick, Easy and Simple at UnitedCarExchange.com/Offers<a href=\"http://www.UnitedCarExchange.com/Offers.aspx\" style=\"color: #FF1100; margin: 0 4px;font-weight: bold\">Click Now</a> to Advertise</td><td style=\"background: #e9e9e9;\" width=\"24\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"12\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"40\"><div style=\"width: 570px; height: 2px; margin: 0 auto 10px auto; border-bottom: #ccc 2px dashed\"></div></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"24\"></td><td style=\"background: #e9e9e9; font-family: arial, verdana; font-size: 25px; color: #393939;\" width=\"552\" align=\"left\">Flat 80% off only in your area</td><td style=\"background: #e9e9e9;\" width=\"24\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\"><tr><td style=\"background: #e9e9e9;\" width=\"30\"></td><td style=\"background: #e9e9e9;\" valign=\"top\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\"><tr><td style=\"background: #e9e9e9;\" width=\"320\" height=\"6\"></td></tr><tr><td style=\"background: #e9e9e9; font-family: arial, verdana; font-size: 15px; color: #707070;\" width=\"320\" align=\"left\">";
        strMail += "This August, Advertise you car with UnitedCarExchange.com to sell it Fast, Easy and at Best Price. In fact, we are offering a flat 80% discount, only in your Area!<br><br>All the Enhanced listing features which usually costs you $49.99 now available just for $9.99<br><br>Team <a href=\"http://www.UnitedCarExchange.com\" style=\"color: #FF6600; margin: 0 4px; font-weight: bold; font-size: 12px;\" target=\"_blank\">UnitedCarEchange.com</a></td></tr><tr><td style=\"background: #e9e9e9;\" width=\"320\" height=\"14\"></td></tr></table></td><td style=\"background: #e9e9e9;\" width=\"30\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"25\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"25\"><img style=\"display: block;\" src=\"http://www.UnitedCarExchange.com/Offerimages/body_header_shadow.jpg\" /></td></tr></table>";
        strMail += "</td></tr></table></body></html>";
        return strMail;
    }


    public string SendContactSellar(string sellarName, string zipCode, string Phone, string Email, string firstName, string lastName, string Comments,
        ref string strMailFormat, string sYear, string Make, string Model, string price)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/SellarRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###SellarName###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###SellarName###", sellarName);
                }
                else
                {
                    strMail = strMail.Replace("###SellarName###", sellarName);
                }
            }

            if (line.Contains("###Phone###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###Phone###", Phone);
                }
                else
                {
                    strMail = strMail.Replace("###Phone###", Phone);
                }
            }
            if (line.Contains("###Email###"))
            {
                if (strMail == "")
                {
                    strMail += line.Replace("###Email###", Email);
                }
                else
                {
                    strMail = strMail.Replace("###Email###", Email);
                }
            }
            if (line.Contains("###Year###"))
            {
                if (strMail == "")
                {
                    strMail += line.Replace("###Year###", sYear);
                }
                else
                {
                    strMail = strMail.Replace("###Year###", sYear);
                }
            }
            if (line.Contains("###Make###"))
            {
                if (strMail == "")
                {
                    strMail += line.Replace("###Make###", Make);
                }
                else
                {
                    strMail = strMail.Replace("###Make###", Make);
                }
            }
            if (line.Contains("###Model###"))
            {
                if (strMail == "")
                {
                    strMail += line.Replace("###Model###", Model);
                }
                else
                {
                    strMail = strMail.Replace("###Model###", Model);
                }
            }
            if (line.Contains("###price###"))
            {
                if (strMail == "")
                {
                    strMail += line.Replace("###price###", price);
                }
                else
                {
                    strMail = strMail.Replace("###price###", price);
                }
            }
            if (line.Contains("###Comments###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###Comments###", Comments);
                }
                else
                {
                    strMail = strMail.Replace("###Comments###", Comments);
                }
            }
            if (line.Contains("###firstName###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###firstName###", firstName);
                }
                else
                {
                    strMail = strMail.Replace("###firstName###", firstName);
                }
            }
            if (line.Contains("###lastName###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###lastName###", lastName);
                }
                else
                {
                    strMail = strMail.Replace("###lastName###", lastName);
                }
            }

            if (line.Contains("###City###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###City###", zipCode);
                }
                else
                {
                    strMail = strMail.Replace("###City###", zipCode);
                }
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    public string SendEMailPreferences(string Customer, string PreferencesID, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/SubscribeRequest.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);

        sbQuery = new StringBuilder();

        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("####PreferencesID####"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("####PreferencesID####", PreferencesID);
                }
                else
                {
                    strMail = strMail.Replace("####PreferencesID####", PreferencesID);
                }
            }

            if (line.Contains("###Customer###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###Customer###", Customer));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###Customer###", Customer));
                }
            }


            strMailFormat = strMailFormat + strMail;
        }
        bNew = true;
        return strMailFormat;
    }


    public string SendEMailPreferencesEdit(string Customer, string PreferencesID, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/SubscribeRequestEdit.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);

        sbQuery = new StringBuilder();

        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("####PreferencesID####"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("####PreferencesID####", PreferencesID);
                }
                else
                {
                    strMail = strMail.Replace("####PreferencesID####", PreferencesID);
                }
            }

            if (line.Contains("###Customer###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###Customer###", Customer));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###Customer###", Customer));
                }
            }


            strMailFormat = strMailFormat + strMail;
        }
        bNew = true;
        return strMailFormat;
    }


    public string SendReferFriend(string CustomerEmail, ref string strMailFormat)
    {
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/ReferFrn.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);

        sbQuery = new StringBuilder();

        while ((line = objStreamReader.ReadLine()) != null)
        {

            string strMail = string.Empty;

            strMail = line + "<br />";

            strMailFormat = strMailFormat + strMail;
        }

        return strMailFormat;
    }


    public string SendStatusChangeRequestMail(string Customer, string Status, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/StatusChangeMail.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);

        sbQuery = new StringBuilder();

        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###Cusname###", Customer);
                }
                else
                {
                    strMail = strMail.Replace("###Cusname###", Customer);
                }
            }

            if (line.Contains("###Status###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###Status###", Status));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###Status###", Status));
                }
            }


            strMailFormat = strMailFormat + strMail;
        }
        bNew = true;
        return strMailFormat;
    }
    public string SendCarInfoRequestMail(string Customer, string OldYear, string OldMake, string OldModel, string NewYear, string NewMake, string NewModel, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/CarInfoEdit.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);

        sbQuery = new StringBuilder();

        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###Cusname###"))
            {
                if (strMail == "")
                {
                    strMail = line.Replace("###Cusname###", Customer);
                }
                else
                {
                    strMail = strMail.Replace("###Cusname###", Customer);
                }
            }

            if (line.Contains("###OldYear###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###OldYear###", OldYear));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###OldYear###", OldYear));
                }
            }

            if (line.Contains("###NewYear###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###NewYear###", NewYear));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###NewYear###", NewYear));
                }
            }

            if (line.Contains("###OldMake###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###OldMake###", OldMake));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###OldMake###", OldMake));
                }
            }

            if (line.Contains("###NewMake###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###NewMake###", NewMake));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###NewMake###", NewMake));
                }
            }
            if (line.Contains("###OldModel###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###OldModel###", OldModel));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###OldModel###", OldModel));
                }
            }
            if (line.Contains("###NewModel###"))
            {
                if (strMail == "")
                {
                    strMail = GeneralFunc.ToProper(line.Replace("###NewModel###", NewModel));
                }
                else
                {
                    strMail = GeneralFunc.ToProper(strMail.Replace("###NewModel###", NewModel));
                }
            }

            strMailFormat = strMailFormat + strMail;
        }
        bNew = true;
        return strMailFormat;
    }
}