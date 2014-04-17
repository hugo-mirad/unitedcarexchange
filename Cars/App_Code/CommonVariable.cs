using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonVariable
/// </summary>
public static class CommonVariable
{

    public static string FromInfoMail = System.Configuration.ConfigurationManager.AppSettings["FromInfo"].ToString().Trim();
    public static string ArchieveMail = System.Configuration.ConfigurationManager.AppSettings["ArchieveMail"].ToString().Trim();
    public static string ContactUsEMail = System.Configuration.ConfigurationManager.AppSettings["ContactUsEMail"].ToString().Trim();
    public static string ContactUsEMailCC = System.Configuration.ConfigurationManager.AppSettings["ContactUsEMailCC"].ToString().Trim();

    
    
}
