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


    public string SendRegistrationdetails(string Username, string Password,string Name, ref string strMailFormat)
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
    public string SendCoupondownloaddetails(int CouponID,Double CouAmount,ref string strMailFormat)
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

}