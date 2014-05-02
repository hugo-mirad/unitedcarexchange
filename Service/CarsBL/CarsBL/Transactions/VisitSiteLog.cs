﻿/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 18-Jan-2012
' DESCRIPTION  : Business Logic to manipulate zipCodes.
'*********************************************************************/

#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References
using CarsInfo;
#region Application References

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion Microsoft Application Block References


namespace CarsBL.Transactions
{
    public class VisitSiteLog
    {
        public bool SaveSiteVisits(string IPAddress, string ReturningURL, string CurrentPage)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SiteVisits";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@ReturningURL", System.Data.DbType.String, ReturningURL);
                dbDatabase.AddInParameter(dbCommand, "@CurrentPage", System.Data.DbType.String, CurrentPage);


                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool OfferPageVisits(string IPAddress, string ReturningURL, string CurrentPage)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_OfferPageVisits";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@ReturningURL", System.Data.DbType.String, ReturningURL);
                dbDatabase.AddInParameter(dbCommand, "@CurrentPage", System.Data.DbType.String, CurrentPage);


                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SaveSearchLog(string IPAddress, string MakeID, string ModelID, string within, string zip, string SearchName)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_SearchLog]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@SearchName", System.Data.DbType.String, SearchName);
                dbDatabase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@MakeID ", System.Data.DbType.String, MakeID);
                dbDatabase.AddInParameter(dbCommand, "@ModelID ", System.Data.DbType.String, ModelID);
                dbDatabase.AddInParameter(dbCommand, "@within ", System.Data.DbType.String, within);
                dbDatabase.AddInParameter(dbCommand, "@zip", System.Data.DbType.String, zip);


                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //saving information about ask question
        public bool SaveAskQuestion(string DiscQuestion, string DiscName, string DiscIPaddress, DateTime DiscDateTime, string DiscAnswer, string DiscAnswerderBy, DateTime DiscAnswerDate, string DiscCarid, string DisMake, string DiscModel, string DiscYear, Boolean DskDelete)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_SaveAskQuestion]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DiscQuestion", System.Data.DbType.String, DiscQuestion);
                dbDatabase.AddInParameter(dbCommand, "@DiscName", System.Data.DbType.String, DiscName);
                dbDatabase.AddInParameter(dbCommand, "@DiscIPaddress ", System.Data.DbType.String, DiscIPaddress);
                dbDatabase.AddInParameter(dbCommand, "@DiscDateTime ", System.Data.DbType.DateTime, DiscDateTime);
                dbDatabase.AddInParameter(dbCommand, "@DiscAnswer ", System.Data.DbType.String, DiscAnswer);
                dbDatabase.AddInParameter(dbCommand, "@DiscAnswerderBy", System.Data.DbType.String, DiscAnswerderBy);
                dbDatabase.AddInParameter(dbCommand, "@DiscAnswerDate", System.Data.DbType.DateTime, DiscAnswerDate);
                dbDatabase.AddInParameter(dbCommand, "@DiscCarid", System.Data.DbType.String, DiscCarid);
                dbDatabase.AddInParameter(dbCommand, "@DisMake ", System.Data.DbType.String, DisMake);
                dbDatabase.AddInParameter(dbCommand, "@DiscModel ", System.Data.DbType.String, DiscModel);
                dbDatabase.AddInParameter(dbCommand, "@DiscYear ", System.Data.DbType.String, DiscYear);
                dbDatabase.AddInParameter(dbCommand, "@DSkdelete ", System.Data.DbType.String, DskDelete);

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //New Cookie Baased methods (string cookievalue, string IPAddress, DateTime SatrtTime, DateTime EndTime, bool Islogin, bool Result, string zip, string cookieName)
        public bool CookieDetails(string cookievalue, string IPAddress, DateTime SatrtTime, DateTime EndTime, bool Islogin, string Result, string zip, string cookieName)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_CookieDetails]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@cookievalue", System.Data.DbType.String, cookievalue);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@SatrtTime", System.Data.DbType.DateTime, SatrtTime);
                dbDatabase.AddInParameter(dbCommand, "@EndTime", System.Data.DbType.DateTime, EndTime);
                dbDatabase.AddInParameter(dbCommand, "@Islogin", System.Data.DbType.Boolean, Islogin);
                dbDatabase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDatabase.AddInParameter(dbCommand, "@zip", System.Data.DbType.String, zip);
                dbDatabase.AddInParameter(dbCommand, "@cookieName", System.Data.DbType.String, cookieName);


                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatetimeCookie(string IPAddress, DateTime EndTime)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USp_UpdatetimeCookie]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //   dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@EndTime", System.Data.DbType.DateTime, EndTime);

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public bool UpdatetimeCookie1(DateTime EndTime)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USp_UpdatetimeCookie1]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@EndTime", System.Data.DbType.DateTime, EndTime);

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public bool UpdateLoginCookie()
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USp_UpdateLoginCookie]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


             

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public bool SaveSubInformation(int make,int model,int year,string firstname,string lastname,string email,string ip,DateTime dt,string Pref)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_SaveSubInformation]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@make", System.Data.DbType.Int32, make);
                dbDatabase.AddInParameter(dbCommand, "@model", System.Data.DbType.Int32, model);
                dbDatabase.AddInParameter(dbCommand, "@year", System.Data.DbType.Int32, year);
                dbDatabase.AddInParameter(dbCommand, "@firstname", System.Data.DbType.String, firstname);
                dbDatabase.AddInParameter(dbCommand, "@lastname", System.Data.DbType.String, lastname);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@ipcon", System.Data.DbType.String, ip);
                dbDatabase.AddInParameter(dbCommand, "@eldate", System.Data.DbType.DateTime, dt);
                dbDatabase.AddInParameter(dbCommand, "@Pref", System.Data.DbType.String, Pref);



                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DataSet RetriveSubInformation( string Pref)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_RetriveSubInformation";
            DbCommand dbCommand = null;

            try
            {


                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Pref", System.Data.DbType.String, Pref);
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet RetriveSubInformation1(int uid)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_RetriveSubInformation1";
            DbCommand dbCommand = null;

            try
            {


                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.String, uid);
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
