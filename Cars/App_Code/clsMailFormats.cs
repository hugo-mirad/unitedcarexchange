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
using System.Collections.Generic;
using CarsBL;
using CarsBL.Transactions;
using CarsBL.RvTransactions;
using WordApplication;


/// <summary>
/// Summary description for clsMailFormats
/// </summary>
public class clsMailFormats
{

    #region RegisterFormat
    private CCWordApp test;
    DropdownBL objdropdownBL = new DropdownBL();
    GeneralFunc objGeneralFunc = new GeneralFunc();
    public string SendRegistrationdetails(string Username, string Password, string Name, ref string strMailFormat, string Link, string TermsLink,int BrandID)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = "";
        if (BrandID == 1)
        {
             SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegisterSuccess.txt");
        }
        else if (BrandID == 2)
        {
             SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegisterSuccessMobi.txt");
        }      
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
            else if (line.Contains("###UCELINK###"))
            {
                strMail = line.Replace("###UCELINK###", Link) + "<br />";
            }
            else if (line.Contains("###Terms###"))
            {
                strMail = line.Replace("###Terms###", TermsLink) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }

    //public string SendRegistrationdetails(string Username, string Password, string Name, ref string strMailFormat, string Link, string TermsLink)
    //{
    //    bool bNew = false;

    //    string OpenPath, contents;
    //    string[] arInfo;
    //    StringBuilder sbQuery;
    //    string line;
    //    string SalesMailFile = "";
    //    SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegisterSuccess.txt");

    //    StreamReader objStreamReader;
    //    objStreamReader = File.OpenText(SalesMailFile);
    //    sbQuery = new StringBuilder();
    //    while ((line = objStreamReader.ReadLine()) != null)
    //    {
    //        string strMail = string.Empty;

    //        strMail = line + "<br />";
    //        if (line.Contains("###UploadUser###"))
    //        {
    //            strMail = line.Replace("###UploadUser###", Name) + "<br />";
    //        }
    //        else if (line.Contains("###UploadDate###"))
    //        {
    //            strMail = line.Replace("###UploadDate###", Username) + "<br />";
    //        }
    //        else if (line.Contains("###RecordCount###"))
    //        {
    //            strMail = line.Replace("###RecordCount###", Password) + "<br />";
    //        }
    //        else if (line.Contains("###UCELINK###"))
    //        {
    //            strMail = line.Replace("###UCELINK###", Link) + "<br />";
    //        }
    //        else if (line.Contains("###Terms###"))
    //        {
    //            strMail = line.Replace("###Terms###", TermsLink) + "<br />";
    //        }
    //        strMailFormat = strMailFormat + strMail;
    //    }

    //    bNew = true;
    //    return strMailFormat;
    //}
    
    public string SendRegistrationdetailsForPDSales(string Username, string Password, string Name, ref string strMailFormat, string PDDate,int BrandID)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = "";
        if (BrandID == 1)
        {
             SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForPDSales.txt");
        }
        else if (BrandID == 2)
        {
             SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForPDSalesMobi.txt");
        }

        
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
            else if (line.Contains("###PDDate###"))
            {
                strMail = line.Replace("###PDDate###", PDDate) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    //public string SendRegistrationdetailsForPDSales(string Username, string Password, string Name, ref string strMailFormat, string PDDate)
    //{
    //    bool bNew = false;

    //    string OpenPath, contents;
    //    string[] arInfo;
    //    StringBuilder sbQuery;
    //    string line;
    //    string SalesMailFile = "";
    //    SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForPDSales.txt");




    //    StreamReader objStreamReader;
    //    objStreamReader = File.OpenText(SalesMailFile);
    //    sbQuery = new StringBuilder();
    //    while ((line = objStreamReader.ReadLine()) != null)
    //    {
    //        string strMail = string.Empty;

    //        strMail = line + "<br />";
    //        if (line.Contains("###UploadUser###"))
    //        {
    //            strMail = line.Replace("###UploadUser###", Name) + "<br />";
    //        }
    //        else if (line.Contains("###UploadDate###"))
    //        {
    //            strMail = line.Replace("###UploadDate###", Username) + "<br />";
    //        }
    //        else if (line.Contains("###RecordCount###"))
    //        {
    //            strMail = line.Replace("###RecordCount###", Password) + "<br />";
    //        }
    //        else if (line.Contains("###PDDate###"))
    //        {
    //            strMail = line.Replace("###PDDate###", PDDate) + "<br />";
    //        }
    //        strMailFormat = strMailFormat + strMail;
    //    }

    //    bNew = true;
    //    return strMailFormat;
    //}

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

    public string SendIntromaildetails(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/SmartzIntroMail.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###AgentName###"))
            {
                strMail = line.Replace("###AgentName###", AgentName) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendIntromaildetailsForDealers(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/DealerIntroMail.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###AgentName###"))
            {
                strMail = line.Replace("###AgentName###", AgentName) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendSpanishIntromaildetails(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;

        strMailFormat = "Gracias por su interés en United Car Exchange.<br /><br />";
        strMailFormat += "Conectamos a compradores y vendedores de vehículos usados en todo el país.<br />";
        strMailFormat += "Hay más de 15 millones de usuarios de Internet que buscan coches usados cada mes como el suyo.<br />";
        strMailFormat += "Nosotros pones su vehículo en 15 sitios Web  que le ayudará a la exposición a más de 100.000 compradores.<br /><br />";
        strMailFormat += "Regístrese para una venta rápida.<br /><br />";
        strMailFormat += "Detalles del paquete explicando nuestra garantía de devolución en dinero están disponibles en<br />";
        strMailFormat += "esp.unitedcarexchange.com/Premium.aspx<br /><br /><br />";
        strMailFormat += "También puede contactar a  nuestro departamento de marketing al 888-786-8307.<br />O envíenos un correo electrónico a info@unitedcarexchange.com.<br /><br /><br />";
        strMailFormat += "Su Consultor de marketing personal<br />";
        strMailFormat += AgentName;

        bNew = true;
        return strMailFormat;
    }

    public string SendRVIntromaildetails(string AgentName, ref string strMailFormat)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RvIntroMail.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("###AgentName###"))
            {
                strMail = line.Replace("###AgentName###", AgentName) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }


    public string SendMultiSitedetails(ref string strMailFormat, DataTable dtMultiSite)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/UCEMultisite.txt");
        StreamReader objStreamReader;
        objStreamReader = File.OpenText(SalesMailFile);
        sbQuery = new StringBuilder();
        while ((line = objStreamReader.ReadLine()) != null)
        {
            string strMail = string.Empty;

            strMail = line + "<br />";

            if (line.Contains("IDMultisiteTable"))
            {
                strMail = line + "<br />";
                for (int i = 0; i < dtMultiSite.Rows.Count; i++)
                {
                    strMail = strMail + "<tr>";
                    strMail = strMail + " <td style=\"width: 230px; background: #fff; padding: 5px\"><strong style=\"color: #333; text-decoration: none\"><a href=\"#\" style=\"color: #232323\">";
                    strMail = strMail + dtMultiSite.Rows[i]["SiteUrl"].ToString();
                    strMail = strMail + "</a></strong></td>";
                    strMail = strMail + " <td style=\"background: #fff; padding: 5px\"><a href=";
                    strMail = strMail + dtMultiSite.Rows[i]["URL"].ToString();
                    strMail = strMail + "target=\"_blank\" style=\"color: #CB3024\">";
                    strMail = strMail + dtMultiSite.Rows[i]["URL"].ToString();
                    strMail = strMail + "</a></td>";
                    strMail = strMail + "</tr>";
                }
            }
            strMailFormat = strMailFormat + strMail;


        }

        bNew = true;

        objStreamReader.Close();

        return strMailFormat;

    }


    /// <summary>
    /// New Modified shravan 0614 2012
    /// </summary>
    /// <param name="strMailFormat"></param>
    /// <param name="dtMultiSite"></param>
    /// <param name="CarsDetails"></param>
    public string SendMultiListMail(ref string strMailFormat, DataTable dtMultiSite, string Carid, string PackageName, string RegName, string UniqueID)
    {

        string strMail = string.Empty;

        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfo>();
        UsedCarsSearch obj = new UsedCarsSearch();
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)obj.FindCarID(Carid);



        string SellerName = obUsedCarsInfo[0].SellerName;


        string Phone = obUsedCarsInfo[0].Phone;
        string Address = obUsedCarsInfo[0].Address1;
        string City = obUsedCarsInfo[0].City;
        string State = obUsedCarsInfo[0].State;
        int PriceAsk = Convert.ToInt32(obUsedCarsInfo[0].Price.ToString());
        string Price = string.Empty;
        if (PriceAsk != 0)
        {
            Price = string.Format("{0:C0}", PriceAsk);
        }
        else
        {
            Price = "";
        }
        int MileageGiven = Convert.ToInt32(obUsedCarsInfo[0].Mileage.ToString());
        System.Globalization.NumberFormatInfo nfi;
        nfi = new System.Globalization.NumberFormatInfo();
        nfi.CurrencySymbol = "";
        string Mileage = string.Empty;
        if (MileageGiven != 0)
        {
            Mileage = string.Format(nfi, "{0:C0}", MileageGiven);
        }
        else
        {
            Mileage = "";
        }

        if (Address == "Emp")
        {
            Address = "";
        }
        if (City == "Emp")
        {
            City = "";
        }

        if (RegName == "")
        {
            SellerName = "";
        }
        else
        {
            SellerName = RegName;
        }


        if (Phone == "Emp")
        {
            Phone = " ";
        }
        else
        {
            Phone = objGeneralFunc.filPhnm(obUsedCarsInfo[0].Phone.ToString());
        }


        string path = string.Empty;

        if (obUsedCarsInfo[0].PIC0 != "Emp")
        {
            path = obUsedCarsInfo[0].PICLOC0 + "/" + obUsedCarsInfo[0].PIC0;
            for (int k = 0; k < 3; k++)
            {
                path = path.Replace("\\", "/");
            }

            path = path.Replace("//", "/");
            path = path.Replace(" ", "%20");
        }
        else
        {
            string carMake = obUsedCarsInfo[0].Make;
            string carModel = obUsedCarsInfo[0].Model;
            carMake = carMake.Replace(' ', '-');
            carModel = carModel.Replace(' ', '-');
            carModel = carModel.Replace('/', '@');
            //if (carModel.IndexOf('/') > 0)
            //{
            //    carModel = "Other";
            //}
            var MakeModel = carMake + "_" + carModel;
            MakeModel = MakeModel.Replace(' ', '-');

            path = "images/MakeModelThumbs/" + MakeModel + ".jpg";
        }
        string sDescription = string.Empty;
        if (obUsedCarsInfo[0].Description == "Emp")
        {
            sDescription = "";
        }
        else
        {
            sDescription = obUsedCarsInfo[0].Description;

        }

        string makeForUrl = obUsedCarsInfo[0].Make;
        makeForUrl = makeForUrl.Replace(" ", "%20");
        string ModelForUrl = obUsedCarsInfo[0].Model;
        ModelForUrl = ModelForUrl.Replace(" ", "%20");
        ModelForUrl = ModelForUrl.Replace("&", "@");


        strMail += "<table width=\"100%\" bgcolor=\"#fff\" style=\"float:left;background-color:rgb(255,255,255);font-family:Arial,'sans serif'\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td align=\"center\"><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>"; ;
        strMail += "<td colspan=\"3\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\" valign=\"top\" height=\"359\"><img src=\"http://smartz.unitedcarexchange.com/images/shadow-top-left.png\"></td>";
        strMail += "<td rowspan=\"2\"><table width=\"730\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#2d2d2d\" height=\"42\" valign=\"middle\"><table width=\"100%\" cellspacing=\"0\" valign=\"middle\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>"; ;
        strMail += "<td colspan=\"4\" height=\"2\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td width=\"12\"></td>";
        strMail += "<td width=\"453\" style=\"color:#fff;font-size:12px;font-family:Arial,'sans serif'\"> Multi-Site Promotion Report for:&nbsp;";
        //Car Year Make Model text start
        strMail += "<strong>";
        strMail += obUsedCarsInfo[0].YearOfMake + " " + obUsedCarsInfo[0].Make + " " + obUsedCarsInfo[0].Model;
        strMail += "</strong></td>";
        strMail += "<td width=\"243\" align=\"right\" style=\"font-size:12px;color:rgb(255,197,190);padding-right:10px; font-weight:normal;\">";
        //Customer Name and Phone Number string 
        ///strMail += "Cynthia Nusbaum (518-821-9009)";        
        strMail += SellerName + " " + (Phone) + "<br />";
        //report date start
        strMail += "<span style=\"color:#fff;font-size:12px; font-weight:normal;\">Report Date:&nbsp; ";
        strMail += string.Format("{0:MM/dd/yyy}", System.DateTime.Now.ToString());



        strMail += "</span></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "      </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#c32c2c\" height=\"6\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"239\" style=\"background:url(http://smartz.unitedcarexchange.com/images/newsletter.jpg) center no-repeat\"><table cellpadding=\"0\" cellspacing=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td height=\"156\"></td>";
        strMail += "<td></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td width=\"8\"></td>";
        strMail += "<td height=\"30\" style=\"text-shadow:rgb(102,102,102) 1px 1px;color:#fff;font-size:14px;font-weight:bold;font-family:Arial,'sans serif'\"><a href=\"http://unitedcarexchange.com/\" target=\"_blank\">";
        strMail += "<div style=\"width:214px;min-height:68px;border:none;outline:none; position:relative; top:-158px\"> </div>";
        strMail += "    </a></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "</table>";
        strMail += "<table width=\"730\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";

        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td>";


        strMail += "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "<td style=\"color: rgb(51,51,51); font-size: 14px; line-height: 20px; font-family: Arial,'sans serif'\"";
        strMail += "valign=\"top\">";
        strMail += "<h3 style=\"font-family: HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';";
        strMail += "line-height: 25px; font-size: 22px; color: #CB3024; text-align: left; margin-bottom: 10px\">";
        strMail += "Key Listing Parameters</h3>";
        strMail += "<table style=\"margin: 0px; padding: 0px; font-size: 12px; color: #232323; width: 438px;";
        strMail += "background: #ccc;\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\" width=\"125\">";
        strMail += "<strong>Registrant Name</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += SellerName;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Email Address</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Email;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Phone</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Phone;
        strMail += "</td>";
        strMail += "</tr>";
        //strMail += "<tr>";
        //strMail += "<td style=\"background: #fff; padding: 5px\">";
        //strMail += "<strong>Package Type</strong>";
        //strMail += "</td>";
        //strMail += "<td style=\"background: #fff; padding: 5px\">";
        //strMail += PackageName;
        //strMail += "</td>";
        //strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Make</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Make;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Model</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Model;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Year</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].YearOfMake;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Mileage</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        if (Mileage != "")
        {
            strMail += Mileage + "ml";
        }
        else
        {
            strMail += Mileage;
        }
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Asking Price</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Price;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>United Car Exchange Listing Link</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<a href='http://unitedcarexchange.com/Buy-Sell-UsedCar/" + obUsedCarsInfo[0].YearOfMake + "-" + makeForUrl + "-" + ModelForUrl + "-" + UniqueID + "'" + " style=\"color: #CB3024\" target=\"_blank\">";
        strMail += " Click here</a>";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";
        strMail += "</td>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "<td style=\"width: 200px;padding-top:50px;\" valign=\"top\">";
        //strMail += "<a target=\"_blank\" href='http://unitedcarexchange.com/SearchCarDetails.aspx?Make=" + obUsedCarsInfo[0].Make.ToString() + "&Model=" + obUsedCarsInfo[0].Model.ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + obUsedCarsInfo[0].Carid.ToString() + "'";
        strMail += "<img src='http://unitedcarexchange.com/" + path + "'" + " style=\"margin-top: 4px\" border=\"0\" width=\"200\">";
        //strMail += "</a>";
        strMail += "  <br>";
        strMail += "</td>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";

        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        if (dtMultiSite.Rows.Count > 0)
        {

            strMail += "<tr>";
            strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
            strMail += "<tbody>";


            strMail += "<tr>";
            strMail += "<td width=\"30\"></td>";
            strMail += "<td valign=\"top\" style=\"color:rgb(51,51,51);font-size:14px;line-height:20px;font-family:Arial,'sans serif'\">";
            strMail += "<h3 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';line-height:25px;font-size:22px;color:#CB3024;text-align:left;margin-bottom:10px\">Multi - Site Submitted URLs</h3>";

            strMail += "<table border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"margin:0px;padding:0px;font-size:12px;width:668px;color:rgb(18,18,18);overflow:hidden; background:#ccc;\">";
            strMail += "<tbody>";
            strMail += "<tr>";
            strMail += "<td style=\"width:200px; background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Site Name</strong></td>";
            strMail += "<td style=\"background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Posted URL</strong></td>";
            strMail += "<td style=\"width:80px;background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Post Date</strong></td>";
            //strMail += "<td style=\"width:80px;background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Expiry Date</strong></td>";
            strMail += "</tr>";

            for (int i = 0; i < dtMultiSite.Rows.Count; i++)
            {
                strMail += "<tr>";
                strMail += "<td style=\"width:200px; background:#fff; padding:5px\"><strong style=\"color:#333; text-decoration:none\">";
                strMail += "<a href=\"#\" style=\"color:#232323\">" + objGeneralFunc.WrapTextByMaxCharacters(dtMultiSite.Rows[i]["SiteName"].ToString(), 30) + "</a></strong></td>";
                strMail += "<td style=\"background:#fff; padding:5px\"><a href='http://" + dtMultiSite.Rows[i]["URL"].ToString() + "'" + " target=\"_blank\" style=\"color:#CB3024\">";
                strMail += "" + objGeneralFunc.WrapTextByMaxCharacters(dtMultiSite.Rows[i]["URL"].ToString(), 40) + "</a></td>";
                strMail += "<td style=\"width:80px;background:#fff; padding:5px\">";
                DateTime dtPostDt = Convert.ToDateTime(dtMultiSite.Rows[i]["UrlPostDate"].ToString());
                string urlPostDate = string.Empty;
                string urlExpiryDate = string.Empty;
                urlPostDate = dtPostDt.ToString("MM/dd/yy");
                if (dtMultiSite.Rows[i]["ValidDays"].ToString() != "")
                {
                    int ValidDays = Convert.ToInt32(dtMultiSite.Rows[i]["ValidDays"].ToString());
                    DateTime dtValidTill = Convert.ToDateTime(dtPostDt.AddDays(ValidDays).ToString());
                    urlExpiryDate = dtValidTill.ToString("MM/dd/yy");
                }
                else
                {
                    urlExpiryDate = "Not Available";
                }
                strMail += urlPostDate + "</td>";
                //strMail += "<td style=\"width:80px;background:#fff; padding:5px\">";
                //strMail += urlExpiryDate + "</td>";
                strMail += "</tr>";
            }


            strMail += "    </tbody>";
            strMail += "    </table>";



            strMail += "    </td>";
            strMail += "<td width=\"30\"></td>";
            strMail += "</tr>";
            strMail += "    </tbody>";
            strMail += "    </table></td>";
            strMail += "</tr>";



            strMail += "<tr>";
            strMail += "<td height=\"18\"></td>";
            strMail += "</tr>";
            strMail += "<tr>";
            strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
            strMail += "</tr>";
        }
        strMail += "<tr>";
        strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\"></td>";
        strMail += "<td valign=\"top\" style=\"color:#333; font-size:12px;\"><h3 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';line-height:25px;font-size:22px;color:#CB3024;text-align:left;margin-bottom:10px\">";
        strMail += "UCE Listing Preview</h3>";
        strMail += "<table style=\"width: 100%; margin-top: 25px; font-size:12px; color:#333;\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\"><h2 style=\"font-size:15px; margin:0 0 2px 0; line-height:15px; padding:0\">";

        strMail += obUsedCarsInfo[0].YearOfMake + " " + obUsedCarsInfo[0].Make + " " + obUsedCarsInfo[0].Model;
        if (Price != "")
        {
            strMail += " - ";
        }
        strMail += "<span style=\"color:#ff9900\">" + Price + "</span></h2></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\" width:50%; vertical-align: top; line-height:17px\"><strong>Phone: &nbsp;</strong>" + Phone + " <br>";
        strMail += "<strong>Email: &nbsp;</strong>" + obUsedCarsInfo[0].Email + " <br>";
        strMail += "</td>";
        strMail += "<td style=\"vertical-align: top; line-height:17px\"><span style=\"text-transform: capitalize; \">";
        strMail += "<strong>Car Location: </strong>";
        if (City != "")
        {
            if (State != "Unspecified")
            {
                strMail += City + ", ";
            }
            else
            {
                strMail += City + " ";
            }
        }
        if (State != "Unspecified")
        {
            strMail += State + " ";
        }
        strMail += obUsedCarsInfo[0].Zipcode;
        strMail += "</span><br />";
        strMail += "<strong>Seller Type: </strong>Private Seller<br>";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table>";
        strMail += "    <br />";
        strMail += "<h2 style=\"font-size:15px; color:#ff9900;  margin:0 0 2px 0; line-height:15px; padding:0;\">";
        //Make Model
        strMail += "About This  " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString() + "</h2>";
        strMail += "<table style=\"width:99%; margin:0; font-size:12px; color:#333;\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td style=\"width:50%;vertical-align:top; line-height:17px\"><strong>Make: </strong>" + obUsedCarsInfo[0].Make.ToString() + "<br>";
        strMail += "<strong>Model: </strong> " + obUsedCarsInfo[0].Model.ToString() + "<br>";
        strMail += "<strong>Year: </strong> ";
        strMail += obUsedCarsInfo[0].YearOfMake.ToString() + "<br>";
        strMail += "<strong>Body Style: </strong> ";
        if (obUsedCarsInfo[0].Bodytype.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].Bodytype.ToString();
        }
        strMail += "<br><strong>Exterior Color: </strong>";
        if (obUsedCarsInfo[0].ExteriorColor.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].ExteriorColor.ToString();
        }
        strMail += "<br><strong>Interior Color: </strong>";
        if (obUsedCarsInfo[0].InteriorColor.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].InteriorColor.ToString();
        }
        strMail += "<br><strong>Doors: </strong>";
        if (obUsedCarsInfo[0].NumberOfDoors.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].NumberOfDoors.ToString();
        }
        strMail += "<br><strong>Vehicle Condition: </strong>";
        if (obUsedCarsInfo[0].ConditionDescription.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].ConditionDescription.ToString();
        }
        strMail += " <br></td><td valign=\"top\" style=\"line-height:17px\"><strong>Price: </strong>" + Price + "<br>";
        strMail += "<strong>Mileage: </strong>";
        if (Mileage != "")
        {
            strMail += Mileage + "ml";
        }
        strMail += "<br><strong>Fuel: </strong>";
        if (obUsedCarsInfo[0].Fueltype.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].Fueltype.ToString();
        }
        strMail += "<br><strong>Engine: </strong>";
        if (obUsedCarsInfo[0].NumberOfCylinder.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].NumberOfCylinder.ToString();
        }
        strMail += "<br><strong>Transmission: </strong>";
        if (obUsedCarsInfo[0].Transmission.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].Transmission.ToString();
        }
        strMail += "<br><strong>DriveTrain: </strong>";
        if (obUsedCarsInfo[0].DriveTrain.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].DriveTrain.ToString();
        }
        strMail += "<br><strong>VIN: </strong>";
        if (obUsedCarsInfo[0].VIN.ToString() != "Emp")
        {
            strMail += obUsedCarsInfo[0].VIN.ToString();
        }
        strMail += "<br></td></tr>";
        strMail += "    </tbody>";
        strMail += "      </table>";
        strMail += "        <p style=\"font-size:12px; padding:0; line-height:18px\">";
        strMail += "      <h2 style=\"font-size:15px; margin:0 0 2px 0; line-height:15px; padding:0; color:#ff9900\">Car Specifications</h2>";


        string lblComFeature = string.Empty;
        string lblSeatsFea = string.Empty;
        string lblSafetyFea = string.Empty;
        string lblSoundFea = string.Empty;
        string lblWindowsFea = string.Empty;
        string lblOtherFea = string.Empty;
        string lblNewFea = string.Empty;
        string lblSpecialsFea = string.Empty;

        CarFeatures objCarFeatures = new CarFeatures();

        DataSet CarsDetails = objCarFeatures.GetCarFeatures(Carid);


        if (CarsDetails.Tables[0].Rows.Count > 0)
        {


            for (int k = 0; k < CarsDetails.Tables[0].Rows.Count; k++)
            {
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                {

                    if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                    {
                        if (lblComFeature == "")
                        {
                            lblComFeature = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                        }
                        else
                        {
                            lblComFeature = lblComFeature + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                        }
                    }


                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "2")
                {
                    if (lblSeatsFea == "")
                    {
                        lblSeatsFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSeatsFea = lblSeatsFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "3")
                {
                    if (lblSafetyFea == "")
                    {
                        lblSafetyFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSafetyFea = lblSafetyFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "4")
                {
                    if (lblSoundFea == "")
                    {
                        lblSoundFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSoundFea = lblSoundFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "5")
                {
                    if (lblWindowsFea == "")
                    {
                        lblWindowsFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblWindowsFea = lblWindowsFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "6")
                {
                    if (lblOtherFea == "")
                    {
                        lblOtherFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblOtherFea = lblOtherFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "7")
                {
                    if (lblNewFea == "")
                    {
                        lblNewFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblNewFea = lblNewFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "8")
                {
                    if (lblSpecialsFea == "")
                    {
                        lblSpecialsFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSpecialsFea = lblSpecialsFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
            }
        }


        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Comfort: </strong>" + lblComFeature + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Seats: </strong>" + lblSeatsFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Safety: </strong>" + lblSafetyFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Sound: </strong>" + lblSoundFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Windows: </strong>" + lblWindowsFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Other: </strong>" + lblOtherFea + "</p>";
        strMail += "      </p>";

        strMail += "      <p style=\" font-size:12px; padding:0\"> <strong style=\"font-size:15px; color:#ff9900\">Description: </strong>" + sDescription + "</p>";
        //strMail += "      <p style=\"font-size:11px; padding:0\"> <strong style=\" font-size: 15px; color:#ff9900\">Surrounding towns:&nbsp;</strong>Berlin, CONNECTICUT(CT); Bloomfield, CONNECTICUT(CT); Branford, CONNECTICUT(CT); Coventry, CONNECTICUT(CT); Danbury, CONNECTICUT(CT); Hamden, CONNECTICUT(CT); </p>";
        //strMail += "      <p style=\"font-size:11px; padding:0\"> <strong style=\" font-size:15px; color:#ff9900\">Near by zip codes: </strong>11701, &nbsp;06401, &nbsp;07712, &nbsp;01721, &nbsp;07716, &nbsp;01501, &nbsp;07001, &nbsp;01436, &nbsp;06063, &nbsp;11706, &nbsp;07002, &nbsp;11361, &nbsp;12508, &nbsp;10506, &nbsp;10507, &nbsp;11426, &nbsp;11710, &nbsp;07719, &nbsp;07621, &nbsp;02779, &nbsp;06037 </p></td>";
        strMail += "<td width=\"30\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\"></td>";
        strMail += "<td valign=\"top\" style=\"color:rgb(51,51,51);font-size:12px;line-height:20px;font-family:Arial,'sans serif'\"><h1 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';color:rgb(32,31,31);font-size:22px;line-height:25px\"> About United Car Exchange</h1>";
        strMail += "<p><span style=\"color:#CB3024\">United Car Exchange</span>&nbsp;is the america's most trusted online buy &amp; sell used car agency. United car exchange helps in providing an online platform where car buyers and sellers can search, buy, sell and come together to talk about their used/new cars.</p>";
        strMail += "You can contact us any time at our customer contact no: <span style=\"color:#CB3024\">888-786-8307</span> </td>";
        strMail += "<td width=\"30\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td align=\"center\" style=\"color:underline;font-size:12px;font-weight:normal;font-family:Arial,'sans serif'\"><a href=\"http://unitedcarexchange.com/Default.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">unitedcarexchange.com</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedcarexchange.com/usedcars.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Used Cars</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedcarexchange.com/Packages.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Sell A Car</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedcarexchange.com/TermsandConditions.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">T&amp;C&nbsp;</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedcarexchange.com/ContactUs.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Contact Us</a></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#efefef\" height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "<td colspan=\"2\" valign=\"top\"><img src=\"http://smartz.unitedcarexchange.com/images/shadow-top-right.png\"  style=\"margin-top:1px\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td>&nbsp;</td>";
        strMail += "<td width=\"4\" background=\"http://smartz.unitedcarexchange.com/images/shadow-left.png\"></td>";
        strMail += "<td width=\"4\" background=\"http://smartz.unitedcarexchange.com/images/shadow-right.png\"></td>";
        strMail += "<td>&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\"></td>";
        strMail += "<td><img src=\"http://smartz.unitedcarexchange.com/images/shadow-bottom.png\" ></td>";
        strMail += "<td colspan=\"2\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "</table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"40\"></td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";
        return strMail;

    }


    public string SendMultiListMailMobi(ref string strMailFormat, DataTable dtMultiSite, string Carid, string PackageName, string RegName, string UniqueID)
    {

        string strMail = string.Empty;

        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfo>();
        UsedCarsSearch obj = new UsedCarsSearch();
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)obj.FindCarID(Carid);



        string SellerName = obUsedCarsInfo[0].SellerName;


        string Phone = obUsedCarsInfo[0].Phone;
        string Address = obUsedCarsInfo[0].Address1;
        string City = obUsedCarsInfo[0].City;
        string State = obUsedCarsInfo[0].State;
        int PriceAsk = Convert.ToInt32(obUsedCarsInfo[0].Price.ToString());
        string Price = string.Empty;
        if (PriceAsk != 0)
        {
            Price = string.Format("{0:C0}", PriceAsk);
        }
        else
        {
            Price = "";
        }
        int MileageGiven = Convert.ToInt32(obUsedCarsInfo[0].Mileage.ToString());
        System.Globalization.NumberFormatInfo nfi;
        nfi = new System.Globalization.NumberFormatInfo();
        nfi.CurrencySymbol = "";
        string Mileage = string.Empty;
        if (MileageGiven != 0)
        {
            Mileage = string.Format(nfi, "{0:C0}", MileageGiven);
        }
        else
        {
            Mileage = "";
        }

        if (Address == "Emp")
        {
            Address = "";
        }
        if (City == "Emp")
        {
            City = "";
        }

        if (RegName == "")
        {
            SellerName = "";
        }
        else
        {
            SellerName = RegName;
        }


        if (Phone == "Emp")
        {
            Phone = " ";
        }
        else
        {
            Phone = objGeneralFunc.filPhnm(obUsedCarsInfo[0].Phone.ToString());
        }


        string path = string.Empty;

        if (obUsedCarsInfo[0].PIC0 != "Emp")
        {
            path = obUsedCarsInfo[0].PICLOC0 + "/" + obUsedCarsInfo[0].PIC0;
            for (int k = 0; k < 3; k++)
            {
                path = path.Replace("\\", "/");
            }

            path = path.Replace("//", "/");
            path = path.Replace(" ", "%20");
        }
        else
        {
            string carMake = obUsedCarsInfo[0].Make;
            string carModel = obUsedCarsInfo[0].Model;
            carMake = carMake.Replace(' ', '-');
            carModel = carModel.Replace(' ', '-');
            carModel = carModel.Replace('/', '@');
            //if (carModel.IndexOf('/') > 0)
            //{
            //    carModel = "Other";
            //}
            var MakeModel = carMake + "_" + carModel;
            MakeModel = MakeModel.Replace(' ', '-');

            path = "images/MakeModelThumbs/" + MakeModel + ".jpg";
        }
        string sDescription = string.Empty;
        if (obUsedCarsInfo[0].Description == "Emp")
        {
            sDescription = "";
        }
        else
        {
            sDescription = obUsedCarsInfo[0].Description;

        }

        string makeForUrl = obUsedCarsInfo[0].Make;
        makeForUrl = makeForUrl.Replace(" ", "%20");
        string ModelForUrl = obUsedCarsInfo[0].Model;
        ModelForUrl = ModelForUrl.Replace(" ", "%20");
        ModelForUrl = ModelForUrl.Replace("&", "@");


        strMail += "<table width=\"100%\" bgcolor=\"#fff\" style=\"float:left;background-color:rgb(255,255,255);font-family:Arial,'sans serif'\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td align=\"center\"><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>"; ;
        strMail += "<td colspan=\"3\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\" valign=\"top\" height=\"359\"><img src=\"http://smartz.unitedcarexchange.com/images/shadow-top-left.png\"></td>";
        strMail += "<td rowspan=\"2\"><table width=\"730\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#2d2d2d\" height=\"42\" valign=\"middle\"><table width=\"100%\" cellspacing=\"0\" valign=\"middle\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>"; ;
        strMail += "<td colspan=\"4\" height=\"2\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td width=\"12\"></td>";
        strMail += "<td width=\"453\" style=\"color:#fff;font-size:12px;font-family:Arial,'sans serif'\"> Multi-Site Promotion Report for:&nbsp;";
        //Car Year Make Model text start
        strMail += "<strong>";
        strMail += obUsedCarsInfo[0].YearOfMake + " " + obUsedCarsInfo[0].Make + " " + obUsedCarsInfo[0].Model;
        strMail += "</strong></td>";
        strMail += "<td width=\"243\" align=\"right\" style=\"font-size:12px;color:rgb(255,197,190);padding-right:10px; font-weight:normal;\">";
        //Customer Name and Phone Number string 
        ///strMail += "Cynthia Nusbaum (518-821-9009)";        
        strMail += SellerName + " " + (Phone) + "<br />";
        //report date start
        strMail += "<span style=\"color:#fff;font-size:12px; font-weight:normal;\">Report Date:&nbsp; ";
        strMail += string.Format("{0:MM/dd/yyy}", System.DateTime.Now.ToString());



        strMail += "</span></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "      </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#EC4739\" height=\"6\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"239\" style=\"background:url(http://smartz.unitedcarexchange.com/images/newsletterMobi.jpg) center no-repeat\"><table cellpadding=\"0\" cellspacing=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td height=\"156\"></td>";
        strMail += "<td></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td width=\"8\"></td>";
        strMail += "<td height=\"30\" style=\"text-shadow:rgb(102,102,102) 1px 1px;color:#fff;font-size:14px;font-weight:bold;font-family:Arial,'sans serif'\"><a href=\"http://mobicarz.com/\" target=\"_blank\">";
        strMail += "<div style=\"width:214px;min-height:68px;border:none;outline:none; position:relative; top:-158px\"> </div>";
        strMail += "    </a></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "</table>";
        strMail += "<table width=\"730\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";

        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td>";


        strMail += "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "<td style=\"color: rgb(51,51,51); font-size: 14px; line-height: 20px; font-family: Arial,'sans serif'\"";
        strMail += "valign=\"top\">";
        strMail += "<h3 style=\"font-family: HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';";
        strMail += "line-height: 25px; font-size: 22px; color: #F95446; text-align: left; margin-bottom: 10px\">";
        strMail += "Key Listing Parameters</h3>";
        strMail += "<table style=\"margin: 0px; padding: 0px; font-size: 12px; color: #232323; width: 438px;";
        strMail += "background: #ccc;\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\" width=\"125\">";
        strMail += "<strong>Registrant Name</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += SellerName;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Email Address</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Email;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Phone</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Phone;
        strMail += "</td>";
        strMail += "</tr>";
        //strMail += "<tr>";
        //strMail += "<td style=\"background: #fff; padding: 5px\">";
        //strMail += "<strong>Package Type</strong>";
        //strMail += "</td>";
        //strMail += "<td style=\"background: #fff; padding: 5px\">";
        //strMail += PackageName;
        //strMail += "</td>";
        //strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Make</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Make;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Model</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Model;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Year</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].YearOfMake;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Mileage</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        if (Mileage != "")
        {
            strMail += Mileage + "ml";
        }
        else
        {
            strMail += Mileage;
        }
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Asking Price</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Price;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>MobiCarz Listing Link</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<a href='http://mobicarz.com/Buy-Sell-UsedCar/" + obUsedCarsInfo[0].YearOfMake.ToString() + "-" + makeForUrl.Replace("-","@") + "-" + ModelForUrl.Replace("-","@") + "-" + UniqueID + "'" + " style=\"color: #F95446\" target=\"_blank\">";
        strMail += " Click here</a>";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";
        strMail += "</td>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "<td style=\"width: 200px;padding-top:50px;\" valign=\"top\">";
        //strMail += "<a target=\"_blank\" href='http://unitedcarexchange.com/SearchCarDetails.aspx?Make=" + obUsedCarsInfo[0].Make.ToString() + "&Model=" + obUsedCarsInfo[0].Model.ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + obUsedCarsInfo[0].Carid.ToString() + "'";
        strMail += "<img src='http://unitedcarexchange.com/" + path + "'" + " style=\"margin-top: 4px\" border=\"0\" width=\"200\">";
        //strMail += "</a>";
        strMail += "  <br>";
        strMail += "</td>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";

        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        if (dtMultiSite.Rows.Count > 0)
        {

            strMail += "<tr>";
            strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
            strMail += "<tbody>";


            strMail += "<tr>";
            strMail += "<td width=\"30\"></td>";
            strMail += "<td valign=\"top\" style=\"color:rgb(51,51,51);font-size:14px;line-height:20px;font-family:Arial,'sans serif'\">";
            strMail += "<h3 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';line-height:25px;font-size:22px;color:#F95446;text-align:left;margin-bottom:10px\">Multi - Site Submitted URLs</h3>";

            strMail += "<table border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"margin:0px;padding:0px;font-size:12px;width:668px;color:rgb(18,18,18);overflow:hidden; background:#ccc;\">";
            strMail += "<tbody>";
            strMail += "<tr>";
            strMail += "<td style=\"width:200px; background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Site Name</strong></td>";
            strMail += "<td style=\"background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Posted URL</strong></td>";
            strMail += "<td style=\"width:80px;background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Post Date</strong></td>";
            //strMail += "<td style=\"width:80px;background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Expiry Date</strong></td>";
            strMail += "</tr>";

            for (int i = 0; i < dtMultiSite.Rows.Count; i++)
            {
                strMail += "<tr>";
                strMail += "<td style=\"width:200px; background:#fff; padding:5px\"><strong style=\"color:#333; text-decoration:none\">";
                strMail += "<a href=\"#\" style=\"color:#232323\">" + objGeneralFunc.WrapTextByMaxCharacters(dtMultiSite.Rows[i]["SiteName"].ToString(), 30) + "</a></strong></td>";
                strMail += "<td style=\"background:#fff; padding:5px\"><a href='http://" + dtMultiSite.Rows[i]["URL"].ToString() + "'" + " target=\"_blank\" style=\"color:#F95446\">";
                strMail += "" + objGeneralFunc.WrapTextByMaxCharacters(dtMultiSite.Rows[i]["URL"].ToString(), 40) + "</a></td>";
                strMail += "<td style=\"width:80px;background:#fff; padding:5px\">";
                DateTime dtPostDt = Convert.ToDateTime(dtMultiSite.Rows[i]["UrlPostDate"].ToString());
                string urlPostDate = string.Empty;
                string urlExpiryDate = string.Empty;
                urlPostDate = dtPostDt.ToString("MM/dd/yy");
                if (dtMultiSite.Rows[i]["ValidDays"].ToString() != "")
                {
                    int ValidDays = Convert.ToInt32(dtMultiSite.Rows[i]["ValidDays"].ToString());
                    DateTime dtValidTill = Convert.ToDateTime(dtPostDt.AddDays(ValidDays).ToString());
                    urlExpiryDate = dtValidTill.ToString("MM/dd/yy");
                }
                else
                {
                    urlExpiryDate = "Not Available";
                }
                strMail += urlPostDate + "</td>";
                //strMail += "<td style=\"width:80px;background:#fff; padding:5px\">";
                //strMail += urlExpiryDate + "</td>";
                strMail += "</tr>";
            }


            strMail += "    </tbody>";
            strMail += "    </table>";



            strMail += "    </td>";
            strMail += "<td width=\"30\"></td>";
            strMail += "</tr>";
            strMail += "    </tbody>";
            strMail += "    </table></td>";
            strMail += "</tr>";



            strMail += "<tr>";
            strMail += "<td height=\"18\"></td>";
            strMail += "</tr>";
            strMail += "<tr>";
            strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
            strMail += "</tr>";
        }
        strMail += "<tr>";
        strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\"></td>";
        strMail += "<td valign=\"top\" style=\"color:#333; font-size:12px;\"><h3 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';line-height:25px;font-size:22px;color:#F95446;text-align:left;margin-bottom:10px\">";
        strMail += "MobiCarz Listing Preview</h3>";
        strMail += "<table style=\"width: 100%; margin-top: 25px; font-size:12px; color:#333;\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\"><h2 style=\"font-size:15px; margin:0 0 2px 0; line-height:15px; padding:0\">";

        strMail += obUsedCarsInfo[0].YearOfMake + " " + obUsedCarsInfo[0].Make + " " + obUsedCarsInfo[0].Model;
        if (Price != "")
        {
            strMail += " - ";
        }
        strMail += "<span style=\"color:#00658B\">" + Price + "</span></h2></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\" width:50%; vertical-align: top; line-height:17px\"><strong>Phone: &nbsp;</strong>" + Phone + " <br>";
        strMail += "<strong>Email: &nbsp;</strong>" + obUsedCarsInfo[0].Email + " <br>";
        strMail += "</td>";
        strMail += "<td style=\"vertical-align: top; line-height:17px\"><span style=\"text-transform: capitalize; \">";
        strMail += "<strong>Car Location: </strong>";
        if (City != "")
        {
            if (State != "Unspecified")
            {
                strMail += City + ", ";
            }
            else
            {
                strMail += City + " ";
            }
        }
        if (State != "Unspecified")
        {
            strMail += State + " ";
        }
        strMail += obUsedCarsInfo[0].Zipcode;
        strMail += "</span><br />";
        strMail += "<strong>Seller Type: </strong>Private Seller<br>";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table>";
        strMail += "    <br />";
        strMail += "<h2 style=\"font-size:15px; color:#00658B;  margin:0 0 2px 0; line-height:15px; padding:0;\">";
        //Make Model
        strMail += "About This  " + obUsedCarsInfo[0].Make.ToString() + " " + obUsedCarsInfo[0].Model.ToString() + "</h2>";
        strMail += "<table style=\"width:99%; margin:0; font-size:12px; color:#333;\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td style=\"width:50%;vertical-align:top; line-height:17px\"><strong>Make: </strong>" + obUsedCarsInfo[0].Make.ToString() + "<br>";
        strMail += "<strong>Model: </strong> " + obUsedCarsInfo[0].Model.ToString() + "<br>";
        strMail += "<strong>Year: </strong> ";
        strMail += obUsedCarsInfo[0].YearOfMake.ToString() + "<br>";
        strMail += "<strong>Body Style: </strong> ";
        if (obUsedCarsInfo[0].Bodytype.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].Bodytype.ToString();
        }
        strMail += "<br><strong>Exterior Color: </strong>";
        if (obUsedCarsInfo[0].ExteriorColor.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].ExteriorColor.ToString();
        }
        strMail += "<br><strong>Interior Color: </strong>";
        if (obUsedCarsInfo[0].InteriorColor.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].InteriorColor.ToString();
        }
        strMail += "<br><strong>Doors: </strong>";
        if (obUsedCarsInfo[0].NumberOfDoors.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].NumberOfDoors.ToString();
        }
        strMail += "<br><strong>Vehicle Condition: </strong>";
        if (obUsedCarsInfo[0].ConditionDescription.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].ConditionDescription.ToString();
        }
        strMail += " <br></td><td valign=\"top\" style=\"line-height:17px\"><strong>Price: </strong>" + Price + "<br>";
        strMail += "<strong>Mileage: </strong>";
        if (Mileage != "")
        {
            strMail += Mileage + "ml";
        }
        strMail += "<br><strong>Fuel: </strong>";
        if (obUsedCarsInfo[0].Fueltype.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].Fueltype.ToString();
        }
        strMail += "<br><strong>Engine: </strong>";
        if (obUsedCarsInfo[0].NumberOfCylinder.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].NumberOfCylinder.ToString();
        }
        strMail += "<br><strong>Transmission: </strong>";
        if (obUsedCarsInfo[0].Transmission.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].Transmission.ToString();
        }
        strMail += "<br><strong>DriveTrain: </strong>";
        if (obUsedCarsInfo[0].DriveTrain.ToString() != "Unspecified")
        {
            strMail += obUsedCarsInfo[0].DriveTrain.ToString();
        }
        strMail += "<br><strong>VIN: </strong>";
        if (obUsedCarsInfo[0].VIN.ToString() != "Emp")
        {
            strMail += obUsedCarsInfo[0].VIN.ToString();
        }
        strMail += "<br></td></tr>";
        strMail += "    </tbody>";
        strMail += "      </table>";
        strMail += "        <p style=\"font-size:12px; padding:0; line-height:18px\">";
        strMail += "      <h2 style=\"font-size:15px; margin:0 0 2px 0; line-height:15px; padding:0; color:#00658B\">Car Specifications</h2>";


        string lblComFeature = string.Empty;
        string lblSeatsFea = string.Empty;
        string lblSafetyFea = string.Empty;
        string lblSoundFea = string.Empty;
        string lblWindowsFea = string.Empty;
        string lblOtherFea = string.Empty;
        string lblNewFea = string.Empty;
        string lblSpecialsFea = string.Empty;

        CarFeatures objCarFeatures = new CarFeatures();

        DataSet CarsDetails = objCarFeatures.GetCarFeatures(Carid);


        if (CarsDetails.Tables[0].Rows.Count > 0)
        {


            for (int k = 0; k < CarsDetails.Tables[0].Rows.Count; k++)
            {
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                {

                    if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                    {
                        if (lblComFeature == "")
                        {
                            lblComFeature = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                        }
                        else
                        {
                            lblComFeature = lblComFeature + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                        }
                    }


                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "2")
                {
                    if (lblSeatsFea == "")
                    {
                        lblSeatsFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSeatsFea = lblSeatsFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "3")
                {
                    if (lblSafetyFea == "")
                    {
                        lblSafetyFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSafetyFea = lblSafetyFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "4")
                {
                    if (lblSoundFea == "")
                    {
                        lblSoundFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSoundFea = lblSoundFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "5")
                {
                    if (lblWindowsFea == "")
                    {
                        lblWindowsFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblWindowsFea = lblWindowsFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "6")
                {
                    if (lblOtherFea == "")
                    {
                        lblOtherFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblOtherFea = lblOtherFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "7")
                {
                    if (lblNewFea == "")
                    {
                        lblNewFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblNewFea = lblNewFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "8")
                {
                    if (lblSpecialsFea == "")
                    {
                        lblSpecialsFea = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                    else
                    {
                        lblSpecialsFea = lblSpecialsFea + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                    }
                }
            }
        }


        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Comfort: </strong>" + lblComFeature + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Seats: </strong>" + lblSeatsFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Safety: </strong>" + lblSafetyFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Sound: </strong>" + lblSoundFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Windows: </strong>" + lblWindowsFea + "</p>";
        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>Other: </strong>" + lblOtherFea + "</p>";
        strMail += "      </p>";

        strMail += "      <p style=\" font-size:12px; padding:0\"> <strong style=\"font-size:15px; color:#00658B\">Description: </strong>" + sDescription + "</p>";
        //strMail += "      <p style=\"font-size:11px; padding:0\"> <strong style=\" font-size: 15px; color:#00658B\">Surrounding towns:&nbsp;</strong>Berlin, CONNECTICUT(CT); Bloomfield, CONNECTICUT(CT); Branford, CONNECTICUT(CT); Coventry, CONNECTICUT(CT); Danbury, CONNECTICUT(CT); Hamden, CONNECTICUT(CT); </p>";
        //strMail += "      <p style=\"font-size:11px; padding:0\"> <strong style=\" font-size:15px; color:#00658B\">Near by zip codes: </strong>11701, &nbsp;06401, &nbsp;07712, &nbsp;01721, &nbsp;07716, &nbsp;01501, &nbsp;07001, &nbsp;01436, &nbsp;06063, &nbsp;11706, &nbsp;07002, &nbsp;11361, &nbsp;12508, &nbsp;10506, &nbsp;10507, &nbsp;11426, &nbsp;11710, &nbsp;07719, &nbsp;07621, &nbsp;02779, &nbsp;06037 </p></td>";
        strMail += "<td width=\"30\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\"></td>";
        strMail += "<td valign=\"top\" style=\"color:rgb(51,51,51);font-size:12px;line-height:20px;font-family:Arial,'sans serif'\"><h1 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';color:rgb(32,31,31);font-size:22px;line-height:25px\"> About MobiCarz</h1>";
        strMail += "<p><span style=\"color:#F95446\">MobiCarz</span>&nbsp;is the america's most trusted online buy &amp; sell used car agency. MobiCarz helps in providing an online platform where car buyers and sellers can search, buy, sell and come together to talk about their used/new cars.</p>";
        strMail += "You can contact us any time at our customer contact no: <span style=\"color:#F95446\">1(888)-465-6693</span> </td>";
        strMail += "<td width=\"30\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td align=\"center\" style=\"color:underline;font-size:12px;font-weight:normal;font-family:Arial,'sans serif'\"><a href=\"http://mobicarz.com/Default.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">mobicarz.com</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://mobicarz.com/usedcars.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Used Cars</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://mobicarz.com/Packages.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Sell A Car</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://mobicarz.com/TermsandConditions.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">T&amp;C&nbsp;</a>&nbsp;&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#efefef\" height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "<td colspan=\"2\" valign=\"top\"><img src=\"http://smartz.unitedcarexchange.com/images/shadow-top-right.png\"  style=\"margin-top:1px\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td>&nbsp;</td>";
        strMail += "<td width=\"4\" background=\"http://smartz.unitedcarexchange.com/images/shadow-left.png\"></td>";
        strMail += "<td width=\"4\" background=\"http://smartz.unitedcarexchange.com/images/shadow-right.png\"></td>";
        strMail += "<td>&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\"></td>";
        strMail += "<td><img src=\"http://smartz.unitedcarexchange.com/images/shadow-bottom.png\" ></td>";
        strMail += "<td colspan=\"2\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "</table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"40\"></td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";
        return strMail;

    }



    public string SendMultiListMailForRV(ref string strMailFormat, DataTable dtMultiSite, string Carid, string PackageName, string RegName, string UniqueID)
    {

        string strMail = string.Empty;

        List<CarsInfo.UsedCarsInfoRV> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfoRV>();
        RvMainBL obj = new RvMainBL();
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfoRV>)obj.FindCarID(Carid);

        //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfoRV>)obj.FindCarID(Carid);


        string SellerName = obUsedCarsInfo[0].SellerName;


        string Phone = obUsedCarsInfo[0].Phone;
        string Address = obUsedCarsInfo[0].Address1;
        string City = obUsedCarsInfo[0].City;
        string State = obUsedCarsInfo[0].State;
        int PriceAsk = Convert.ToInt32(obUsedCarsInfo[0].Price.ToString());
        string Price = string.Format("{0:C0}", PriceAsk);
        int MileageGiven = Convert.ToInt32(obUsedCarsInfo[0].Mileage.ToString());
        System.Globalization.NumberFormatInfo nfi;
        nfi = new System.Globalization.NumberFormatInfo();
        nfi.CurrencySymbol = "";
        string Mileage = string.Format(nfi, "{0:C0}", MileageGiven);


        if (Address == "Emp")
        {
            Address = "Unspecified";
        }
        if (City == "Emp")
        {
            City = "Unspecified";
        }

        if (RegName == "")
        {
            SellerName = "Unspecified";
        }
        else
        {
            SellerName = RegName;
        }


        if (Phone == "Emp")
        {
            Phone = " ";
        }
        else
        {
            Phone = objGeneralFunc.filPhnm(obUsedCarsInfo[0].Phone.ToString());
        }


        string path = string.Empty;

        if (obUsedCarsInfo[0].PIC0 != "Emp")
        {
            path = obUsedCarsInfo[0].PICLOC0 + "/" + obUsedCarsInfo[0].PIC0;
            for (int k = 0; k < 3; k++)
            {
                path = path.Replace("\\", "/");
            }

            path = path.Replace("//", "/");
            path = path.Replace(" ", "%20");

        }
        else
        {
            string StockMake = obUsedCarsInfo[0].Make.ToString();
            StockMake = StockMake.Replace(" ", "-");
            StockMake = StockMake.Replace("/", "@");
            string StockType = obUsedCarsInfo[0].TypeName.ToString();
            StockType = StockType.Replace(" ", "-");
            path = "images/MakeModelThumbs/" + StockType + "_" + StockMake + ".jpg";

        }
        string sDescription = string.Empty;
        if (obUsedCarsInfo[0].Description == "Emp")
        {
            sDescription = "Unspecified";
        }
        else
        {
            sDescription = obUsedCarsInfo[0].Description;

        }
        string RvYear = obUsedCarsInfo[0].YearOfMake.ToString();
        string RvType = obUsedCarsInfo[0].TypeName.ToString();
        string RvMake = obUsedCarsInfo[0].Make.ToString();
        string RvUniqueID = obUsedCarsInfo[0].CarUniqueID.ToString();
        RvType = RvType.Replace(" ", "%20");
        RvMake = RvMake.Replace(" ", "%20");


        strMail += "<table width=\"100%\" bgcolor=\"#fff\" style=\"float:left;background-color:rgb(255,255,255);font-family:Arial,'sans serif'\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td align=\"center\"><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>"; ;
        strMail += "<td colspan=\"3\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\" valign=\"top\" height=\"359\"><img src=\"http://smartz.unitedcarexchange.com/images/shadow-top-left.png\"></td>";
        strMail += "<td rowspan=\"2\"><table width=\"730\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#2d2d2d\" height=\"42\" valign=\"middle\"><table width=\"100%\" cellspacing=\"0\" valign=\"middle\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>"; ;
        strMail += "<td colspan=\"4\" height=\"2\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td width=\"12\"></td>";
        strMail += "<td width=\"453\" style=\"color:#fff;font-size:12px;font-family:Arial,'sans serif'\"> Multi-Site Promotion Report for:&nbsp;";
        //Car Year Make Model text start
        strMail += "<strong>";
        strMail += obUsedCarsInfo[0].YearOfMake + " " + obUsedCarsInfo[0].TypeName + " " + obUsedCarsInfo[0].Make;
        strMail += "</strong></td>";
        strMail += "<td width=\"243\" align=\"right\" style=\"font-size:12px;color:rgb(255,197,190);padding-right:10px; font-weight:normal;\">";
        //Customer Name and Phone Number string 
        ///strMail += "Cynthia Nusbaum (518-821-9009)";        
        strMail += SellerName + " " + (Phone) + "<br />";
        //report date start
        strMail += "<span style=\"color:#fff;font-size:12px; font-weight:normal;\">Report Date:&nbsp; ";
        strMail += string.Format("{0:MM/dd/yyy}", System.DateTime.Now.ToString());



        strMail += "</span></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "      </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#68B55E\" height=\"6\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"239\" style=\"background:url(http://smartz.unitedcarexchange.com/images/Newsheader2.jpeg) center no-repeat\"><table cellpadding=\"0\" cellspacing=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td height=\"156\"></td>";
        strMail += "<td></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td width=\"8\"></td>";
        strMail += "<td height=\"30\" style=\"text-shadow:rgb(102,102,102) 1px 1px;color:#fff;font-size:14px;font-weight:bold;font-family:Arial,'sans serif'\"><a href=\"http://unitedrvexchange.com/\" target=\"_blank\">";
        strMail += "<div style=\"width:214px;min-height:68px;border:none;outline:none; position:relative; top:-158px\"> </div>";
        strMail += "    </a></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "</table>";
        strMail += "<table width=\"730\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";

        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td>";


        strMail += "<table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "<td style=\"color: rgb(51,51,51); font-size: 14px; line-height: 20px; font-family: Arial,'sans serif'\"";
        strMail += "valign=\"top\">";
        strMail += "<h3 style=\"font-family: HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';";
        strMail += "line-height: 25px; font-size: 22px; color: #71AC37; text-align: left; margin-bottom: 10px\">";
        strMail += "Key Listing Parameters</h3>";
        strMail += "<table style=\"margin: 0px; padding: 0px; font-size: 12px; color: #232323; width: 438px;";
        strMail += "background: #ccc;\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\" width=\"125\">";
        strMail += "<strong>Registrant Name</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += SellerName;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Email Address</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Email;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Phone</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Phone;
        strMail += "</td>";
        strMail += "</tr>";
        //strMail += "<tr>";
        //strMail += "<td style=\"background: #fff; padding: 5px\">";
        //strMail += "<strong>Package Type</strong>";
        //strMail += "</td>";
        //strMail += "<td style=\"background: #fff; padding: 5px\">";
        //strMail += PackageName;
        //strMail += "</td>";
        //strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Type</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].TypeName;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Make</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].Make;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Year</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += obUsedCarsInfo[0].YearOfMake;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Mileage</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Mileage + "ml";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>Asking Price</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += Price;
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<strong>United RV Exchange Listing Link</strong>";
        strMail += "</td>";
        strMail += "<td style=\"background: #fff; padding: 5px\">";
        strMail += "<a href='http://unitedrvexchange.com/Buy-Sell-UsedRVs/" + obUsedCarsInfo[0].YearOfMake + "-" + RvType + "-" + RvMake + "-" + RvUniqueID + "'" + " style=\"color: #71AC37\" target=\"_blank\">";
        strMail += " Click here</a>";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";
        strMail += "</td>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "<td style=\"width: 200px;padding-top:50px;\" valign=\"top\">";
        //strMail += "<a target=\"_blank\" href='http://unitedrvexchange.com/SearchCarDetails.aspx?Make=" + obUsedCarsInfo[0].Make.ToString() + "&Model=" + obUsedCarsInfo[0].Model.ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + obUsedCarsInfo[0].Carid.ToString() + "'";
        strMail += "<img src='http://unitedrvexchange.com/" + path + "'" + " style=\"margin-top: 4px\" border=\"0\" width=\"200\">";
        //strMail += "</a>";
        strMail += "  <br>";
        strMail += "</td>";
        strMail += "<td width=\"30\">";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";

        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        if (dtMultiSite.Rows.Count > 0)
        {

            strMail += "<tr>";
            strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
            strMail += "<tbody>";


            strMail += "<tr>";
            strMail += "<td width=\"30\"></td>";
            strMail += "<td valign=\"top\" style=\"color:rgb(51,51,51);font-size:14px;line-height:20px;font-family:Arial,'sans serif'\">";
            strMail += "<h3 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';line-height:25px;font-size:22px;color:#71AC37;text-align:left;margin-bottom:10px\">Multi - Site Submitted URLs</h3>";

            strMail += "<table border=\"0\" cellspacing=\"1\" cellpadding=\"0\" style=\"margin:0px;padding:0px;font-size:12px;width:668px;color:rgb(18,18,18);overflow:hidden; background:#ccc;\">";
            strMail += "<tbody>";
            strMail += "<tr>";
            strMail += "<td style=\"width:200px; background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Site Name</strong></td>";
            strMail += "<td style=\"background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Posted URL</strong></td>";
            strMail += "<td style=\"width:80px;background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Post Date</strong></td>";
            //strMail += "<td style=\"width:80px;background:#ccc; padding:5px\"><strong style=\"color:#333; text-decoration:none\">Expiry Date</strong></td>";
            strMail += "</tr>";

            for (int i = 0; i < dtMultiSite.Rows.Count; i++)
            {
                strMail += "<tr>";
                strMail += "<td style=\"width:200px; background:#fff; padding:5px\"><strong style=\"color:#333; text-decoration:none\">";
                strMail += "<a href=\"#\" style=\"color:#232323\">" + objGeneralFunc.WrapTextByMaxCharacters(dtMultiSite.Rows[i]["SiteName"].ToString(), 30) + "</a></strong></td>";
                strMail += "<td style=\"background:#fff; padding:5px\"><a href='http://" + dtMultiSite.Rows[i]["URL"].ToString() + "'" + " target=\"_blank\" style=\"color:#71AC37\">";
                strMail += "" + objGeneralFunc.WrapTextByMaxCharacters(dtMultiSite.Rows[i]["URL"].ToString(), 40) + "</a></td>";
                strMail += "<td style=\"width:80px;background:#fff; padding:5px\">";
                DateTime dtPostDt = Convert.ToDateTime(dtMultiSite.Rows[i]["UrlPostDate"].ToString());
                string urlPostDate = string.Empty;
                string urlExpiryDate = string.Empty;
                urlPostDate = dtPostDt.ToString("MM/dd/yy");
                if (dtMultiSite.Rows[i]["ValidDays"].ToString() != "")
                {
                    int ValidDays = Convert.ToInt32(dtMultiSite.Rows[i]["ValidDays"].ToString());
                    DateTime dtValidTill = Convert.ToDateTime(dtPostDt.AddDays(ValidDays).ToString());
                    urlExpiryDate = dtValidTill.ToString("MM/dd/yy");
                }
                else
                {
                    urlExpiryDate = "Not Available";
                }
                strMail += urlPostDate + "</td>";
                //strMail += "<td style=\"width:80px;background:#fff; padding:5px\">";
                //strMail += urlExpiryDate + "</td>";
                strMail += "</tr>";
            }


            strMail += "    </tbody>";
            strMail += "    </table>";



            strMail += "    </td>";
            strMail += "<td width=\"30\"></td>";
            strMail += "</tr>";
            strMail += "    </tbody>";
            strMail += "    </table></td>";
            strMail += "</tr>";



            strMail += "<tr>";
            strMail += "<td height=\"18\"></td>";
            strMail += "</tr>";
            strMail += "<tr>";
            strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
            strMail += "</tr>";
        }
        strMail += "<tr>";
        strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\"></td>";
        strMail += "<td valign=\"top\" style=\"color:#333; font-size:12px;\"><h3 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';line-height:25px;font-size:22px;color:#71AC37;text-align:left;margin-bottom:10px\">";
        strMail += "URV Listing Preview</h3>";
        strMail += "<table style=\"width: 100%; margin-top: 25px; font-size:12px; color:#333;\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\"><h2 style=\"font-size:15px; margin:0 0 2px 0; line-height:15px; padding:0\">";

        strMail += obUsedCarsInfo[0].YearOfMake + " " + obUsedCarsInfo[0].TypeName + " " + obUsedCarsInfo[0].Make + " - ";



        strMail += "<span style=\"color:#71AC37\">" + Price + "</span></h2></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td style=\" width:50%; vertical-align: top; line-height:17px\"><strong>Phone: &nbsp;</strong>" + Phone + " <br>";
        strMail += "<strong>Email: &nbsp;</strong>" + obUsedCarsInfo[0].Email + " <br>";
        strMail += "</td>";
        strMail += "<td style=\"vertical-align: top; line-height:17px\"><span style=\"text-transform: capitalize; \">";
        strMail += "<strong>Car Location: </strong>" + City + ", " + State + " " + obUsedCarsInfo[0].Zipcode;
        strMail += "</span><br />";
        strMail += "<strong>Seller Type: </strong>Private Seller<br>";
        strMail += "</td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table>";
        strMail += "    <br />";
        strMail += "<h2 style=\"font-size:15px; color:#71AC37;  margin:0 0 2px 0; line-height:15px; padding:0;\">";
        //Make Model
        strMail += "About This  " + obUsedCarsInfo[0].TypeName.ToString() + " " + obUsedCarsInfo[0].Make.ToString() + "</h2>";
        strMail += "<table style=\"width:99%; margin:0; font-size:12px; color:#333;\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td style=\"width:50%;vertical-align:top; line-height:17px\"><strong>Vehicle Type: </strong>" + obUsedCarsInfo[0].TypeName.ToString() + "<br><strong>Make: </strong>" + obUsedCarsInfo[0].Make.ToString() + "<br>";
        strMail += "<strong>Model: </strong> " + obUsedCarsInfo[0].Model.ToString() + "<br>";
        strMail += "<strong>Year: </strong> ";
        strMail += obUsedCarsInfo[0].YearOfMake.ToString() + "<br>";
        strMail += "<strong>Body Style: </strong> " + obUsedCarsInfo[0].Bodytype.ToString() + "<br>";
        strMail += "<strong>Exterior Color: </strong>" + obUsedCarsInfo[0].ExteriorColor.ToString() + "<br>";
        strMail += "<strong>Interior Color: </strong>" + obUsedCarsInfo[0].InteriorColor.ToString() + "<br>";
        strMail += "<strong>Doors: </strong>" + obUsedCarsInfo[0].NumberOfDoors.ToString() + "<br>";
        strMail += "<strong>Vehicle Condition: </strong>" + obUsedCarsInfo[0].ConditionDescription.ToString() + " <br>";
        if (obUsedCarsInfo[0].Towing_Capacity.ToString() != "Emp")
        {
            strMail += "<strong>Towing Capapcity: </strong>" + obUsedCarsInfo[0].Towing_Capacity.ToString() + "<br>";
        }
        else
        {
            strMail += "<strong>Towing Capapcity: </strong>" + " " + "<br>";
        }
        if (obUsedCarsInfo[0].Dry_Weight.ToString() != "Emp")
        {
            strMail += "<strong>Dry Weight: </strong>" + obUsedCarsInfo[0].Dry_Weight.ToString() + "<br></td>";
        }
        else
        {
            strMail += "<strong>Dry Weight: </strong>" + " " + "<br></td>";
        }
        strMail += "<td valign=\"top\" style=\"line-height:17px\"><strong>Price: </strong>" + Price + "<br>";
        strMail += "<strong>Mileage: </strong>" + Mileage + "ml<br>";
        strMail += "<strong>Fuel: </strong>" + obUsedCarsInfo[0].Fueltype.ToString() + "<br>";
        strMail += "<strong>Engine: </strong>" + " " + "<br>";
        if (obUsedCarsInfo[0].Transmission.ToString() != "Emp")
        {
            strMail += "<strong>Transmission: </strong>" + obUsedCarsInfo[0].Transmission.ToString() + "<br>";
        }
        else
        {
            strMail += "<strong>Transmission: </strong>" + " " + "<br>";
        }
        if (obUsedCarsInfo[0].DriveTrain.ToString() != "Emp")
        {
            strMail += "<strong>DriveTrain: </strong>" + obUsedCarsInfo[0].DriveTrain.ToString() + "<br>";
        }
        else
        {
            strMail += "<strong>DriveTrain: </strong>" + " " + "<br>";
        }
        if (obUsedCarsInfo[0].VIN.ToString() != "Emp")
        {
            strMail += "<strong>VIN: </strong>" + obUsedCarsInfo[0].VIN.ToString() + "<br>";
        }
        else
        {
            strMail += "<strong>VIN: </strong>" + " " + "<br>";
        }
        if (obUsedCarsInfo[0].SleepingCapacity.ToString() != "0")
        {
            strMail += "<strong>Sleeping Capacity: </strong>" + obUsedCarsInfo[0].SleepingCapacity.ToString() + "<br>";
        }
        else
        {
            strMail += "<strong>Sleeping Capacity: </strong>" + " " + "<br>";
        }
        if (obUsedCarsInfo[0].SlideOuts.ToString() != "0")
        {
            strMail += "<strong>SlideOuts: </strong>" + obUsedCarsInfo[0].SlideOuts.ToString() + "<br>";
        }
        else
        {
            strMail += "<strong>SlideOuts: </strong>" + " " + "<br>";
        }
        strMail += "<strong>Engine Manufacturer: </strong>" + obUsedCarsInfo[0].EngineManufacturer.ToString() + "<br>";
        if (obUsedCarsInfo[0].EngineType.ToString() != "Emp")
        {
            strMail += "<strong>Engine Type: </strong>" + obUsedCarsInfo[0].EngineType.ToString() + "<br></td>";
        }
        else
        {
            strMail += "<strong>Engine Type: </strong>" + " " + "<br></td>";
        }
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "      </table>";
        strMail += "        <p style=\"font-size:12px; padding:0; line-height:18px\">";
        strMail += "      <h2 style=\"font-size:15px; margin:0 0 2px 0; line-height:15px; padding:0; color:#71AC37\">Car Specifications</h2>";


        string lblComFeature = string.Empty;
        string lblSeatsFea = string.Empty;
        string lblSafetyFea = string.Empty;
        string lblSoundFea = string.Empty;
        string lblWindowsFea = string.Empty;
        string lblOtherFea = string.Empty;
        string lblNewFea = string.Empty;
        string lblSpecialsFea = string.Empty;

        RvMainBL objCarFeatures = new RvMainBL();

        DataSet CarsDetails = objCarFeatures.GetCarFeatures(Carid);


        if (CarsDetails.Tables[0].Rows.Count > 0)
        {


            for (int k = 0; k < CarsDetails.Tables[0].Rows.Count; k++)
            {
                if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                {

                    if (CarsDetails.Tables[0].Rows[k]["FeatureTypeID"].ToString() == "1")
                    {
                        if (lblComFeature == "")
                        {
                            lblComFeature = CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                        }
                        else
                        {
                            lblComFeature = lblComFeature + ", " + CarsDetails.Tables[0].Rows[k]["FeatureName"].ToString();
                        }
                    }
                }
            }
        }


        strMail += "      <p style=\"line-height:18px; padding:0; margin:0;\"><strong>General: </strong>" + lblComFeature + "</p>";
        strMail += "      </p>";

        strMail += "      <p style=\" font-size:12px; padding:0\"> <strong style=\"font-size:15px; color:#71AC37\">Description: </strong>" + sDescription + "</p>";
        //strMail += "      <p style=\"font-size:11px; padding:0\"> <strong style=\" font-size: 15px; color:#71AC37\">Surrounding towns:&nbsp;</strong>Berlin, CONNECTICUT(CT); Bloomfield, CONNECTICUT(CT); Branford, CONNECTICUT(CT); Coventry, CONNECTICUT(CT); Danbury, CONNECTICUT(CT); Hamden, CONNECTICUT(CT); </p>";
        //strMail += "      <p style=\"font-size:11px; padding:0\"> <strong style=\" font-size:15px; color:#71AC37\">Near by zip codes: </strong>11701, &nbsp;06401, &nbsp;07712, &nbsp;01721, &nbsp;07716, &nbsp;01501, &nbsp;07001, &nbsp;01436, &nbsp;06063, &nbsp;11706, &nbsp;07002, &nbsp;11361, &nbsp;12508, &nbsp;10506, &nbsp;10507, &nbsp;11426, &nbsp;11710, &nbsp;07719, &nbsp;07621, &nbsp;02779, &nbsp;06037 </p></td>";
        strMail += "<td width=\"30\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\">";
        strMail += "<tbody>";
        strMail += "<tr>";
        strMail += "<td width=\"30\"></td>";
        strMail += "<td valign=\"top\" style=\"color:rgb(51,51,51);font-size:12px;line-height:20px;font-family:Arial,'sans serif'\"><h1 style=\"font-family:HelveticaNeueBold,HelveticaNeue-Bold,'Helvetica Neue Bold',helvetica,arial,'sans serif';color:rgb(32,31,31);font-size:22px;line-height:25px\"> About United RV Exchange</h1>";
        strMail += "<p><span style=\"color:#71AC37\">United RV Exchange</span>&nbsp;is the america's most trusted online buy &amp; sell used rv agency. United rv exchange helps in providing an online platform where rv buyers and sellers can search, buy, sell and come together to talk about their used/new rvs.</p>";
        strMail += "You can contact us any time at our customer contact no: <span style=\"color:#71AC37\">888-786-8307</span> </td>";
        strMail += "<td width=\"30\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td  height=\"1\" style=\"border-top:1px dotted #C7C7C7\">&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td align=\"center\" style=\"color:underline;font-size:12px;font-weight:normal;font-family:Arial,'sans serif'\"><a href=\"http://unitedrvexchange.com/Default.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">unitedrvexchange.com</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedrvexchange.com/usedcars.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Used Rvs</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedrvexchange.com/Packages.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Sell A Rv</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedrvexchange.com/TermsandConditions.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">T&amp;C&nbsp;</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href=\"http://unitedrvexchange.com/ContactUs.aspx\" style=\"color:#0000FF;text-decoration:underline\" target=\"_blank\">Contact Us</a></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td bgcolor=\"#efefef\" height=\"10\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "    </table></td>";
        strMail += "<td colspan=\"2\" valign=\"top\"><img src=\"http://smartz.unitedcarexchange.com/images/shadow-top-right.png\"  style=\"margin-top:1px\"></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td>&nbsp;</td>";
        strMail += "<td width=\"4\" background=\"http://smartz.unitedcarexchange.com/images/shadow-left.png\"></td>";
        strMail += "<td width=\"4\" background=\"http://smartz.unitedcarexchange.com/images/shadow-right.png\"></td>";
        strMail += "<td>&nbsp;</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"2\"></td>";
        strMail += "<td><img src=\"http://smartz.unitedcarexchange.com/images/shadow-bottom.png\" ></td>";
        strMail += "<td colspan=\"2\"></td>";
        strMail += "</tr>";
        strMail += "    </tbody>";
        strMail += "</table></td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td height=\"40\"></td>";
        strMail += "</tr>";
        strMail += "</tbody>";
        strMail += "</table>";
        return strMail;

    }

    public string SendRVRegistrationdetailsForPDSales(string Username, string Password, string Name, ref string strMailFormat, string PDDate)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForRvPDSales.txt");
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
            else if (line.Contains("###PDDate###"))
            {
                strMail = line.Replace("###PDDate###", PDDate) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }




    public string SendRVRegistrationdetails(string Username, string Password, string Name, ref string strMailFormat, string Link, string TermsLink)
    {
        bool bNew = false;

        string OpenPath, contents;
        string[] arInfo;
        StringBuilder sbQuery;
        string line;
        string SalesMailFile = HttpContext.Current.Server.MapPath("~/MailTemplate/RegistrationForRVs.txt");
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
            else if (line.Contains("###UCELINK###"))
            {
                strMail = line.Replace("###UCELINK###", Link) + "<br />";
            }
            else if (line.Contains("###Terms###"))
            {
                strMail = line.Replace("###Terms###", TermsLink) + "<br />";
            }
            strMailFormat = strMailFormat + strMail;
        }

        bNew = true;
        return strMailFormat;
    }
    public string SendOffermaildetails(ref string strMailFormat, string StrFlat80, string strFirstBody, string strSecondBody, string strFirstSub)
    {

        string strMail = string.Empty;
        strMail += "<html><head><title>United Car Exchange</title></head>";
        strMail += "<body style=\"padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px;\" ondragstart=\"return false\" onselectstart=\"return false\">";
        strMail += "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" height=\"100%\"><tr><td style=\"background: #f5f5f5;\" align=\"center\" valign=\"top\">";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"24\"></td></tr></table><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr>";
        strMail += "<td style=\"background: #f5f5f5;\" width=\"183\" height=\"44\"><a href=\"http://www.unitedcarexchange.com\" target=\"_blank\"><img src=\"http://www.unitedcarexchange.com/Offerimages/logo.jpg\" border=\"0\" /></a></td>";
        strMail += "<td style=\"background: #f5f5f5;\" width=\"417\" height=\"44\" align=\"right\"><div style=\"color: #717171; font-family: arial, verdana; font-size: 12px;\">Customer service: <b>888-786-8307</b></div><div style=\"color: #717171; font-family: arial, verdana; font-size: 10px;\">P.O. Box #504. Iselin, NJ 08830-0504</div></td>";
        strMail += "</tr></table><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"6\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"25\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/body_header_shadow-top.jpg\" /></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"250\"><a href=\"http://www.unitedcarexchange.com/Offers.aspx\" target=\"_blank\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/image_header.jpg\" border=\"0\" /></a></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"27\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/image_header_shadow.jpg\" /></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"15\"></td></tr></table>";
        strMail += "<table style=\"background: #e9e9e9;\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"24\"></td><td style=\"background: #e9e9e9; color: #555555; font-family: arial, verdana; font-size: 15px;line-height: 19px;\" width=\"552\" align=\"left\">" + strFirstSub + "<a href=\"http://www.unitedcarexchange.com/Offers.aspx\" style=\"color: #FF1100; margin: 0 4px;font-weight: bold\">Click Now</a> to Advertise</td><td style=\"background: #e9e9e9;\" width=\"24\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"12\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"40\"><div style=\"width: 570px; height: 2px; margin: 0 auto 10px auto; border-bottom: #ccc 2px dashed\"></div></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"24\"></td><td style=\"background: #e9e9e9; font-family: arial, verdana; font-size: 25px; color: #393939;\" width=\"552\" align=\"left\">" + StrFlat80 + "</td><td style=\"background: #e9e9e9;\" width=\"24\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"600\"><tr><td style=\"background: #e9e9e9;\" width=\"30\"></td><td style=\"background: #e9e9e9;\" valign=\"top\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\"><tr><td style=\"background: #e9e9e9;\" width=\"320\" height=\"6\"></td></tr><tr><td style=\"background: #e9e9e9; font-family: arial, verdana; font-size: 15px; color: #707070;\" width=\"320\" align=\"left\">";
        strMail += strFirstBody + "<br><br>" + strSecondBody + "<br><br>Team <a href=\"http://www.unitedcarexchange.com\" style=\"color: #FF6600; margin: 0 4px; font-weight: bold; font-size: 12px;\" target=\"_blank\">UnitedCarExchange.com</a></td></tr><tr><td style=\"background: #e9e9e9;\" width=\"320\" height=\"14\"></td></tr></table></td><td style=\"background: #e9e9e9;\" width=\"30\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #e9e9e9;\" width=\"600\" height=\"25\"></td></tr></table>";
        strMail += "<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"background: #f5f5f5;\" width=\"600\" height=\"25\"><img style=\"display: block;\" src=\"http://www.unitedcarexchange.com/Offerimages/body_header_shadow.jpg\" /></td></tr></table>";
        strMail += "</td></tr></table></body></html>";
        return strMail;
    }
    public string SendSubscriptionMail(ref string strMailFormat, DataTable dtTotalCars, string EName, string EMake, string EModel, string EPrice)
    {

        string strMail = string.Empty;
        string SellerName = EName;
        string Price = string.Empty;
        if (EPrice == "1")
        {
            Price = "$ 0-5,000";
        }
        else if (EPrice == "2")
        {
            Price = "$ 5,000-10,000";
        }
        else if (EPrice == "3")
        {
            Price = "$ 10,000-25,000";
        }
        else if (EPrice == "4")
        {
            Price = "$ 25,000-50,000";
        }
        else if (EPrice == "5")
        {
            Price = "$ 50,000-75,000";
        }
        else if (EPrice == "6")
        {
            Price = "$ 75,000-100,000";
        }
        else
        {
            Price = "$ 100,000+";
        }

        strMail += "<table width=\"600\" cellspacing=\"0\" cellpadding=\"0\" style=\"background:#fff;border:4px solid #c5cdcf;border-bottom:none\" border=\"0\">";
        strMail += "<tbody><tr><td valign=\"top\" width=\"394\" style=\"padding-top:8px;padding-bottom:7px;padding-left:15px\"><img src=\"http://smartz.unitedcarexchange.com/images/logo2ESub.png\" border=\"0\"></td>";
        strMail += "<td width=\"183\" align=\"right\" valign=\"top\" style=\"font:normal 12px arial;color:#808383;padding-bottom:3px;padding-left:0; padding-top:6px;\"> Subscription: Weekly<br>";
        strMail += "<table width=\"140\" cellspacing=\"0\" cellpadding=\"0\" style=\"background:#f3f5f5\" border=\"0\"><tbody><tr>";
        strMail += "<td valign=\"bottom\" style=\"font:normal 12px arial;color:#9cb2b9;line-height:24px;text-align:center;padding-left:0\">" + System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString("MMMM dd, yyyy") + "</td></tr></tbody></table></td></tr><tr>";
        strMail += "<td colspan=\"2\" valign=\"top\" style=\"border-top:1px solid #c6cdd0;font:normal 14px arial;color:#999;padding-top:15px;padding-bottom:14px;padding-left:15px\">Hi " + SellerName + ", find a few cars matching your preferences.</td></tr></tbody></table>";
        strMail += "<table width=\"600\" cellpadding=\"0\" cellspacing=\"0\" style=\"background: #fff; border: 4px solid #c5cdcf;border-top: none\" border=\"0\"><tbody><tr><td valign=\"top\" align=\"center\">";
        for (int i = 0; i < dtTotalCars.Rows.Count; i++)
        {
            strMail += "<table width=\"566\" cellpadding=\"0\" cellspacing=\"0\" style=\"background: #f9f8e5\" border=\"0\"><tbody><tr>";
            strMail += "<td valign=\"top\" align=\"left\" width=\"131\" style=\"padding: 11px\"><table width=\"131\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>";
            strMail += "<td style=\"background: #fff; border: 1px solid #c8c9c2; padding: 3px; text-align: left\"><a href=\"#\" target=\"_blank\">";
            string path = string.Empty;
            int PriceAskGrid = Convert.ToInt32(dtTotalCars.Rows[i]["Price"]);
            string PriceGrid = string.Format("{0:C0}", PriceAskGrid);
            int MileageGivenGrid = Convert.ToInt32(dtTotalCars.Rows[i]["Mileage"]);
            System.Globalization.NumberFormatInfo nfi;
            nfi = new System.Globalization.NumberFormatInfo();
            nfi.CurrencySymbol = "";
            string MileageGrid = string.Format(nfi, "{0:C0}", MileageGivenGrid);
            if (dtTotalCars.Rows[i]["PIC0"].ToString() != "")
            {
                path = dtTotalCars.Rows[i]["PICLOC0"] + "/" + dtTotalCars.Rows[i]["PIC0"];
                for (int k = 0; k < 3; k++)
                {
                    path = path.Replace("\\", "/");
                }

                path = path.Replace("//", "/");

            }
            else
            {
                string carMake = dtTotalCars.Rows[i]["Make"].ToString();
                string carModel = dtTotalCars.Rows[i]["Model"].ToString();
                carMake = carMake.Replace(' ', '-');
                carModel = carModel.Replace(' ', '-');
                carModel = carModel.Replace('/', '@');
                //if (carModel.IndexOf('/') > 0)
                //{
                //    carModel = "Other";
                //}
                var MakeModel = carMake + "_" + carModel;
                MakeModel = MakeModel.Replace(' ', '-');

                path = "images/MakeModelThumbs/" + MakeModel + ".jpg";
            }

            strMail += "<img src='http://unitedcarexchange.com/" + path + "'" + "width=\"220\" height=\"134\" vspace=\"0\" border=\"0\"><br></a>";
            strMail += "</td></tr></tbody></table>";
            strMail += "<a href='http://unitedcarexchange.com/Buy-Sell-UsedCar/" + dtTotalCars.Rows[i]["YearOfMake"].ToString() + "-" + dtTotalCars.Rows[i]["Make"].ToString() + "-" + dtTotalCars.Rows[i]["Model"].ToString() + "-" + dtTotalCars.Rows[i]["CarUniqueID"].ToString() + "'><img src=\"http://smartz.unitedcarexchange.com/images/view-full-details.gif\" style=\"margin-top: 6px;\"></a></td>";
            strMail += "<td valign=\"top\" align=\"left\" width=\"413\" style=\"padding-top: 11px; padding-bottom: 11px;padding-left: 0\"><table width=\"240\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>";
            strMail += "<td valign=\"top\" align=\"left\" width=\"274\" style=\"padding-left: 0\"><table width=\"274\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr>";
            strMail += "<td colspan=\"3\" valign=\"top\" align=\"left\" style=\"font: normal 16px arial; padding-bottom: 7px;padding-left: 0\"><a href=\"#\" style=\"color: #0067ac; text-decoration: none; outline: none\" target=\"_blank\">" + dtTotalCars.Rows[i]["YearOfMake"].ToString() + " " + dtTotalCars.Rows[i]["Make"].ToString() + " " + dtTotalCars.Rows[i]["Model"].ToString() + "</a></td></tr>";
            strMail += "<tr><td valign=\"top\" width=\"90\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-left: 0\">Make</td>";
            strMail += "<td valign=\"top\" width=\"12\" style=\"padding-left: 0; text-align: center; font: normal 12px arial\">:</td>";
            strMail += "<td valign=\"top\" width=\"172\" style=\"padding-left: 0; text-align: left; font: normal 12px arial\">" + dtTotalCars.Rows[i]["Make"].ToString() + "</td></tr>";
            strMail += "<tr><td valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-top: 6px; padding-left: 0\">Model</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: center; font: normal 12px arial\">:</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: left; font: normal 12px arial\">" + dtTotalCars.Rows[i]["Model"].ToString() + "</td></tr>";
            strMail += "<tr><td valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-top: 6px; padding-left: 0\">Year</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: center; font: normal 12px arial\">:</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: left; font: normal 12px arial\">" + dtTotalCars.Rows[i]["YearOfMake"].ToString() + "</td></tr>";
            strMail += "<tr><td valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-top: 6px; padding-left: 0\">Price</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: center; font: normal 12px arial\">:</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: left; font: normal 12px arial\">" + PriceGrid + "</td></tr>";
            strMail += "<tr><td valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-top: 6px; padding-bottom: 10px; padding-left: 0\">Mileage</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: center; font: normal 12px arial;padding-bottom: 10px\">:</td>";
            strMail += "<td valign=\"top\" style=\"padding-left: 0; padding-top: 6px; text-align: left; font: normal 12px arial;padding-bottom: 10px\">" + MileageGrid + " ml</td></tr>";
            strMail += "</tbody></table></td></tr>";
            strMail += "<tr><td colspan=\"2\" valign=\"top\" style=\"padding-left: 0; padding-top: 10px; text-align: left;font: normal 12px arial; border-top: 1px dotted #84807f\">" + objGeneralFunc.WrapTextByMaxCharacters(dtTotalCars.Rows[i]["Description"].ToString(), 75) + "<a href=\"#\" style=\"text-decoration: none; color: #0066cc\" target=\"_blank\">&raquo;&raquo;</a></td></tr>";
            strMail += "</tbody></table></td></tr></tbody></table><br>";

        }
        strMail += "<br>";
        strMail += "<table width=\"566\" cellpadding=\"0\" cellspacing=\"0\" style=\"background: #1777d0; border: 1px solid #19588d\" border=\"0\"><tbody><tr>";
        strMail += "<td valign=\"middle\" height=\"45\" style=\"font: normal 16px arial; color: #ffffff; text-align: center;border-top: 1px solid #42a5ce; padding-left: 11px\">";
        strMail += "<a href=\"#\" style=\"color: #fff; text-decoration: none; outline: none\" target=\"_blank\"><span style=\"font-size: 24px; text-decoration: underline\">" + dtTotalCars.Rows.Count.ToString() + "</span> &nbsp;recently active matches</a>&nbsp;<a href=\"#\" style=\"outline: none\" target=\"_blank\"><img src=\"http://smartz.unitedcarexchange.com/images/white-arrow.gif\" width=\"7\" height=\"13\" border=\"0\" style=\"vertical-align: middle\"></a>";
        strMail += "</td></tr></tbody></table>";
        strMail += "<table width=\"566\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody><tr><td colspan=\"2\" height=\"12\"></td></tr><tr>";
        strMail += "<td valign=\"bottom\" style=\"width: 280px; font: bold 16px arial; color: #ff6640; text-align: left;padding-bottom: 8px; padding-left: 0\">Not happy with your preferences?</td>";
        strMail += "<td style=\"font: bold 16px arial; color: #ff6640; text-align: left; padding-bottom: 8px;padding-left: 0\"><a style=\"outline: none\" href=\"#\" target=\"_blank\"><img width=\"170\" height=\"30\" border=\"0\" src=\"http://smartz.unitedcarexchange.com/images/edit-preference.gif\" style=\"vertical-align: middle\"></a></td></tr>";
        strMail += "<tr><td colspan=\"2\" valign=\"top\" style=\"background: #f1f1f1; padding-top: 17px; padding-bottom: 8px;padding-left: 0\"><table width=\"566\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr>";
        strMail += "<td width=\"115\" valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-left: 16px\">Make</td>";
        strMail += "<td width=\"10\" valign=\"top\" style=\"text-align: center; font: normal 12px arial\">:</td><td width=\"441\" valign=\"top\" style=\"text-align: left; font: normal 12px arial\">" + EMake + "</td>";
        strMail += "</tr><tr><td colspan=\"3\" height=\"6\"></td></tr><tr>";
        strMail += "<td width=\"115\" valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-left: 16px\">Model</td>";
        strMail += "<td width=\"10\" valign=\"top\" style=\"text-align: center; font: normal 12px arial\">:</td><td width=\"441\" valign=\"top\" style=\"text-align: left; font: normal 12px arial\">" + EModel + "</td>";
        strMail += "</tr>";
        strMail += "<tr>";
        strMail += "<td colspan=\"3\" height=\"6\"></td></tr><tr><td width=\"115\" valign=\"top\" style=\"font: normal 12px arial; color: #818181; text-align: left;padding-left: 16px\">Price</td>";
        strMail += "<td width=\"10\" valign=\"top\" style=\"text-align: center; font: normal 12px arial\">:</td><td width=\"441\" valign=\"top\" style=\"text-align: left; font: normal 12px arial\">" + Price + "</td></tr>";
        strMail += "<tr><td colspan=\"3\" height=\"6\"></td></tr><tr><td colspan=\"3\" height=\"6\"></td></tr></tbody></table></td></tr></tbody></table>";
        strMail += "<table width=\"566\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\"><tbody><tr><td valign=\"top\" height=\"14\"></td></tr>";
        strMail += "<tr><td valign=\"top\" style=\"text-align: center; font: normal 12px arial; color: #585858;padding-left: 0\"><span style=\"font-size: 14px; color: #000\">Need Help?</span> &nbsp;Call 24/7 at <b>888-786-8307</b></td></tr>";
        strMail += "<tr><td valign=\"top\" height=\"14\"></td></tr></tbody></table>";
        strMail += "</td></tr></tbody></table>";
        return strMail;
    }

    public string AuthroizationLetter(ref string strMailFormat, string CBViewNoticeID, string Agentname)
    {
        DataSet dsDate = objdropdownBL.GetDatetime();
        DateTime ToDayDate = Convert.ToDateTime(dsDate.Tables[0].Rows[0]["Datetime"].ToString());
        test = new CCWordApp();
        string line = string.Empty;
        string strPath = string.Empty;
        string strPath2 = string.Empty;
        //DataSet dsInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter();
        strPath = HttpContext.Current.Server.MapPath("~/MailTemplate/AuthorizeLetter.docx");
        strPath2 = HttpContext.Current.Server.MapPath("~/NoticeCopies/" + CBViewNoticeID + "/AuthorizeLetter.doc");
        test.Open(strPath);
        string str = test.GetContent();
        string NewLine = string.Empty;
        line = str;

        if (line.Contains("#CustName#"))
        {
            line = line.Replace("#CustName#", "");
        }
        if (line.Contains("#VoiceFile#"))
        {
            line = line.Replace("#VoiceFile#", "");
        }
        if (line.Contains("#Recorddate#"))
        {
            line = line.Replace("#Recorddate#", "");
        }
        if (line.Contains("#AgentName#"))
        {
            line = line.Replace("#AgentName#", Agentname.ToString());
        }
        if (line.Contains("#TodayDate#"))
        {
            line = line.Replace("#TodayDate#", ToDayDate.ToString("MM/dd/yyyy"));
        }
        if (line.Contains("#CustName#"))
        {
            line = line.Replace("#CustName#", "");
        }
        if (line.Contains("#Phone#"))
        {
            line = line.Replace("#Phone#", "");
        }
        if (line.Contains("#Address#"))
        {
            line = line.Replace("#Address#", "");
        }
        if (line.Contains("#VehiclesCount#"))
        {
            line = line.Replace("#VehiclesCount#", "0");
        }
        if (line.Contains("#Amount#"))
        {
            line = line.Replace("#Amount#", "0.00");
        }
        if (line.Contains("#Payment#"))
        {
            line = line.Replace("#Payment#", "");
        }
        if (line.Contains("xxxxxxxxxxxx1015"))
        {
            line = line.Replace("xxxxxxxxxxxx1015", "");
        }
        if (line.Contains("XX/XX"))
        {
            line = line.Replace("XX/XX", "");
        }
        if (line.Contains("CVX"))
        {
            line = line.Replace("CVX", "");
        }
        if (line.Contains("#CustEmail#"))
        {
            line = line.Replace("#CustEmail#", "");
        }
        //address city, state zip
        test.Quit();
        return line;
    }
}