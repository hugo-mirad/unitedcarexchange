#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.IO;
#endregion Microsoft Application Block References

/// <summary>
/// Summary description for Constants
/// </summary>
public static class Constants
{
    public static string USER_ID = "UserID";

    public static string USER_NAME = "USER_NAME";

    public static string USER_Rights = "USER_Rights";
    public static string PhoneNumber = "PhoneNumber";
    public static string SellerID = "SellerID";
    public static string NAME = "NAME";
    public static string DealerCode = "DealerCode";
    public static string Salutation = "Salutation";
    public static string States = "States";

    public static string USERLOG_ID = "USERLOG_ID";

    public static string USER_TYPE_ID = "USER_TYPE_ID";

    public static string USER_LocationID = "USER_LocationID";

    public static string Subscribe = "Subscribe";
    public static string BusinessName = "BusinessName";
    

    public static void Rename(this FileInfo file, string newName)
    {
        // Validate arguments.
        if (file == null)
        {
            throw new ArgumentNullException("file");
        }
        else if (newName == null)
        {
            throw new ArgumentNullException("newName");
        }
        else if (newName.Length == 0)
        {
            throw new ArgumentException("The name is empty.", "newName");
        }
        else if (newName.IndexOf(Path.DirectorySeparatorChar) >= 0
            || newName.IndexOf(Path.AltDirectorySeparatorChar) >= 0)
        {
            throw new ArgumentException("The name contains path separators. The file would be moved.", "newName");
        }

        // Rename file.
        string newPath = Path.Combine(file.DirectoryName, newName);
        file.MoveTo(newPath);
    }


    public const string StrFormatException = "Parameter ArrayList empty";
    /// String constant for Ascending
    /// </summary>
    public const string StrAscending = "Ascending";

    /// <summary>
    /// String constant for Descending
    /// </summary>
    public const string StrDescending = "Descending";
    public static string SESSIONEXPIRATIONTIME = System.Configuration.ConfigurationManager.AppSettings["SessionExprirationTime"].ToString().Trim();

}
