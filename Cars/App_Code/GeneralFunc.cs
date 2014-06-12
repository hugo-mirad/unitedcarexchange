#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References
#region Application References
#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Web.UI.WebControls;
using CarsBL.CentralDBTransactions;
#endregion Microsoft Application Block References



public class GeneralFunc
{

    //----------------------------------------------------------
    // Author        : SHRAVAN
    // PurPose       : Wraps the text by 10 characters and replaces the remaining text with ...
    // CreatedDate   : 25th April 2009
    //----------------------------------------------------------
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    public string ToProper(object s)
    {
        s = s.ToString().ToLower();
        string sProper = "";

        char[] seps = new char[] { ' ' };
        foreach (string ss in s.ToString().Split(seps))
        {
            if (ss.Length > 0)
            {
                sProper += char.ToUpper(ss[0]);
                sProper +=
                (ss.Substring(1, ss.Length - 1) + ' ');
            }

        }
        return sProper;
    }
    public string filPhnm(object PhNum)
    {
        string phone = PhNum.ToString().Trim();
        if (phone.Trim() != "")
        {
            string area = phone.Substring(0, 3);
            string major = phone.Substring(3, 3);
            string minor = phone.Substring(6);
            string formatted = string.Format("{0}-{1}-{2}", area, major, minor);
            return formatted;
        }
        else
        {
            return phone;
        }
    }
    //public string ToProper(object strText)
    //{
    //    string rText = "";
    //    try
    //    {
    //        if (strText.ToString() != "")
    //        {
    //            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
    //            System.Globalization.TextInfo TextInfo = cultureInfo.TextInfo;
    //            rText = TextInfo.ToTitleCase(strText.ToString());
    //        }
    //    }
    //    catch
    //    {
    //        rText = strText.ToString();
    //    }
    //    return rText;
    //}
    public string WrapTextByMaxCharacters(object objText, int intMaxChars)
    {
        string strReturnValue = "";

        if (objText != null)
        {
            if (objText.ToString().Trim() != "")
            {
                if (objText.ToString().Trim().Length > intMaxChars)
                {
                    strReturnValue = objText.ToString().Trim().Substring(0, intMaxChars) + "...";
                }
                else
                {
                    strReturnValue = objText.ToString().Trim();
                }
            }
        }
        return strReturnValue;
    }
    public string WrapText(string objText, int intMaxChars)
    {
        string strReturnValue = "";

        if (objText != null)
        {
            if (objText.ToString().Trim() != "")
            {
                if (objText.ToString().Trim().Length > intMaxChars)
                {
                    strReturnValue = objText.ToString().Trim().Substring(0, intMaxChars) + "...";
                }
                else
                {
                    strReturnValue = objText.ToString().Trim();
                }
            }
        }
        return strReturnValue;
    }
    public static bool ValidateDate(string strDate)
    {
        string sMonth;
        string sday;
        string[] sDate;

        sDate = strDate.Split('/');
        sMonth = sDate[0];
        if (sDate.Length > 1)
        {
            sday = sDate[1];
        }
        else
        {
            sday = "";
        }
        if (IsNumeric(sMonth))
        {
            if (Convert.ToInt32(sMonth.ToString()) > 13 || Convert.ToInt32(sMonth.ToString()) == 0)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        if (IsNumeric(sday))
        {
            if (Convert.ToInt32(sday.ToString()) > 31 || Convert.ToInt32(sday.ToString()) == 0)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }
    public static bool ValidateDate(String date, String format)
    {
        try
        {
            System.Globalization.DateTimeFormatInfo dtfi = new
            System.Globalization.DateTimeFormatInfo();
            dtfi.ShortDatePattern = format;
            DateTime dt = DateTime.ParseExact(date, "d", dtfi);
        }
        catch (Exception)
        {
            return false;
        }
        return true;
    }
    public static string DateFormat(string strFormat)
    {
        DateTime Date;
        if (strFormat != "")
        {
            if (GeneralFunc.ValidateDate(strFormat.ToString()))
            {
                Date = Convert.ToDateTime(strFormat.ToString());

                strFormat = String.Format("{0:MMM dd, yyyy}", Date);
                //strFormat = Date.GetDateTimeFormats().GetValue(8).ToString() ;
                return strFormat.ToString();
            }
            else
            {
                return strFormat;
            }
        }
        else
        {
            return strFormat;
        }
    }
    public string DateTimeFormat(string strFormat)
    {
        DateTime Date;
        if (strFormat != "")
        {
            if (ValidateDate(strFormat.ToString()))
            {
                Date = Convert.ToDateTime(strFormat.ToString());

                strFormat = String.Format("{0:MMM dd, yyyy hh:mm:ss tt}", Date);
                //strFormat = Date.GetDateTimeFormats().GetValue(8).ToString() ;
                return strFormat.ToString();
            }
            else
            {
                return strFormat;
            }
        }
        else
        {
            return strFormat;
        }
    }
    public static object DateTimeFormat(object strFormat)
    {
        DateTime Date;
        if (strFormat.ToString() != "")
        {
            if (ValidateDate(strFormat.ToString()))
            {
                Date = Convert.ToDateTime(strFormat.ToString());

                strFormat = String.Format("{0:MMM dd, yyyy hh:mm:ss tt}", Date);
                //strFormat = Date.GetDateTimeFormats().GetValue(8).ToString() ;
                return strFormat.ToString();
            }
            else
            {
                return strFormat;
            }
        }
        else
        {
            return strFormat;
        }
    }
    public static object DateFormat(object strFormat)
    {
        DateTime Date;
        if (strFormat != null)
        {
            if (strFormat.ToString() != "")
            {
                if (ValidateDate(strFormat.ToString()))
                {
                    Date = Convert.ToDateTime(strFormat.ToString());

                    strFormat = String.Format("{0:MMM dd, yyyy}", Date);
                    //strFormat = Date.GetDateTimeFormats().GetValue(8).ToString() ;
                    return strFormat.ToString();
                }
                else
                {
                    return strFormat;
                }
            }
        }

        return strFormat;

    }
    public static string DateOnly(string strFormat)
    {
        DateTime Date;
        if (strFormat != "")
        {

            Date = Convert.ToDateTime(strFormat.ToString());

            strFormat = String.Format("{0:MM/dd/yyyy}", Date);
            //strFormat = Date.GetDateTimeFormats().GetValue(8).ToString() ;
            return strFormat.ToString();

        }
        else
        {
            return strFormat;
        }

    }
    public static bool IsNumeric(string str)
    {
        Regex objNotWholePattern = new Regex("[^0-9]");
        return !objNotWholePattern.IsMatch(str) && (str != "");
    }
    public string GetSmartzUser(object ID)
    {
        string UserID = ID.ToString();
        if (UserID != "")
        {
            DataSet dsUsers = new DataSet();
            string Name = "";
            if (HttpContext.Current.Session["SmartzUsers"] == null)
            {
                dsUsers = objCentralDBBL.GetSmartzUserDetails();
                HttpContext.Current.Session["SmartzUsers"] = dsUsers;
            }
            else
            {
                dsUsers = HttpContext.Current.Session["SmartzUsers"] as DataSet;
            }
            DataView dvUsers = new DataView();
            DataTable dtUsers = new DataTable();
            dvUsers = dsUsers.Tables[0].DefaultView;
            dvUsers.RowFilter = "SmartzUID='" + ID.ToString() + "'";
            dtUsers = dvUsers.ToTable();
            Name = dtUsers.Rows[0]["SmartzFirstName"].ToString();
            dvUsers.RowFilter = "";
            return Name;
        }
        else
        {
            return UserID;
        }
    }
    public string GetSalesAgent(object ID)
    {
        string AgentID = ID.ToString();
        if (AgentID != "")
        {
            DataSet dsAgents = new DataSet();
            string Name = "";
            if (HttpContext.Current.Session["SmartzSalesAgents"] == null)
            {
                dsAgents = objCentralDBBL.GetSmartzSalesAgentsDetails();
                HttpContext.Current.Session["SmartzSalesAgents"] = dsAgents;
            }
            else
            {
                dsAgents = HttpContext.Current.Session["SmartzSalesAgents"] as DataSet;
            }
            DataView dvAgents = new DataView();
            DataTable dtAgents = new DataTable();
            dvAgents = dsAgents.Tables[0].DefaultView;
            dvAgents.RowFilter = "Sale_Agent_Id='" + ID.ToString() + "'";
            dtAgents = dvAgents.ToTable();
            Name = dtAgents.Rows[0]["American_Name"].ToString();
            dvAgents.RowFilter = "";
            return Name;
        }
        else
        {
            return AgentID;
        }
    }

}

