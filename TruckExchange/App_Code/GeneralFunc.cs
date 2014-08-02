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
using System.Net;
using System.IO;
using System.Web.UI;
#endregion Microsoft Application Block References



public class GeneralFunc
{





    public static void CreateFile(string sourcePath, string targetPath)
    {
        string fileName = "Index.aspx";



        sourcePath = HttpContext.Current.Server.MapPath("staticdet");
        targetPath = HttpContext.Current.Server.MapPath(@targetPath);

        // Use Path class to manipulate file and directory paths.
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);

        // To copy a folder's contents to a new location:
        // Create a new target folder, if necessary.
        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }
        // To copy a file to another location and 
        // overwrite the destination file if it already exists.
        System.IO.File.Copy(sourceFile, destFile, true);
        // To copy all the files in one directory to another directory.
        // Get the files in the source folder. (To recursively iterate through
        // all subfolders under the current directory, see
        // "How to: Iterate Through a Directory Tree.")
        // Note: Check for target path was performed previously
        // in this code example.
        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            // Copy the files and overwrite destination files if they already exist.

            // Use static Path methods to extract only the file name from the path.
            string s = System.IO.Path.Combine(sourcePath, fileName);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }

        //else
        //{
        //    Console.WriteLine("Source path does not exist!");
        //}

        // Keep console window open in debug mode.
        //Console.WriteLine("Press any key to exit.");
        //Console.ReadKey();
    }
    public static void CreateFileCS(string sourcePath, string targetPath)
    {
        string fileName = "Index.aspx.cs";



        sourcePath = HttpContext.Current.Server.MapPath("staticdet");
        targetPath = HttpContext.Current.Server.MapPath(@targetPath);

        // Use Path class to manipulate file and directory paths.
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);

        // To copy a folder's contents to a new location:
        // Create a new target folder, if necessary.
        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }
        // To copy a file to another location and 
        // overwrite the destination file if it already exists.
        System.IO.File.Copy(sourceFile, destFile, true);
        // To copy all the files in one directory to another directory.
        // Get the files in the source folder. (To recursively iterate through
        // all subfolders under the current directory, see
        // "How to: Iterate Through a Directory Tree.")
        // Note: Check for target path was performed previously
        // in this code example.
        if (System.IO.Directory.Exists(sourcePath))
        {
            string[] files = System.IO.Directory.GetFiles(sourcePath);
            // Copy the files and overwrite destination files if they already exist.

            // Use static Path methods to extract only the file name from the path.
            string s = System.IO.Path.Combine(sourcePath, fileName);
            destFile = System.IO.Path.Combine(targetPath, fileName);
            System.IO.File.Copy(s, destFile, true);
        }

        //else
        //{
        //    Console.WriteLine("Source path does not exist!");
        //}

        // Keep console window open in debug mode.
        //Console.WriteLine("Press any key to exit.");
        //Console.ReadKey();
    }
    //public bool CreateWebPage()
    //{
    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://opi.yahoo.com/online");

    //    request.Timeout = 9 * 1000; // set request timeout = 9 second. if yahoo api failed to respond in 9 second request would get timed out. 

    //    request.Method = "Post"; // we will post the data using post method

    //    string postData = "u=" + TextBox1.Text + "&m=s&t=8";
    //    // data to be posted using HttpWebrequest post method 

    //    // we will post parameter u , m and t 

    //    // Convert this string into stream of bytes 

    //    byte[] arrPostDAta = System.Text.Encoding.GetEncoding(1252).GetBytes(postData);
    //    // set request content length = post data length 

    //    request.ContentLength = arrPostDAta.Length;

    //    System.IO.Stream strmPostData = request.GetRequestStream();
    //    // get request stream 

    //    // write post data to stream of request 

    //    strmPostData.Write(arrPostDAta, 0, arrPostDAta.Length);

    //    strmPostData.Close();

    //    // upload post data and Get Response from server 
    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

    //    StreamReader reader = new StreamReader(response.GetResponseStream());

    //    Label1.Text = reader.ReadToEnd();

    //    reader.Close();

    //    response.Close();

    //}

    public void SavePageASHtml(string location, Page pge)
    {
        StringWriter stringWriter = new StringWriter();

        HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);

        pge.RenderControl(htmlWriter);

        htmlWriter.Flush();

        FileStream fileStream = new FileStream(location, FileMode.Create);

        string siteString = stringWriter.ToString();

        byte[] byteArray = Encoding.UTF8.GetBytes(siteString);

        fileStream.Write(byteArray, 0, byteArray.Length);

        fileStream.Close();

        //Response.End();

        //Response.Redirect("~/PriceList.aspx");
    }

    //----------------------------------------------------------
    // Author        : SHRAVAN
    // PurPose       : Wraps the text by 10 characters and replaces the remaining text with ...
    // CreatedDate   : 25th April 2009
    //----------------------------------------------------------
    public static string ToProper(object s)
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
        string phone = PhNum.ToString();
        if (phone != "")
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
}

