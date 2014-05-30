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
    public class SmartzUserRegBL
    {
        public DataSet PerformLogin(string UserName, string sPassword)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_Perform_SmartzLogin";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SmartzUname", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@SmatzPassword", System.Data.DbType.String, sPassword);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetUsersDetails()
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet GetUsersModuleRites_All(int UserID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_All_GetUserModules_Rights";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzUpdateUserDetails(int SmartzUID, string SmartzName, string SmartzEmail, int SmartzIsActive)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_SmartzUpdateUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SmartzUID", System.Data.DbType.Int32, SmartzUID);
                dbDatabase.AddInParameter(dbCommand, "@SmartzName", System.Data.DbType.String, SmartzName);
                dbDatabase.AddInParameter(dbCommand, "@SmartzEmail", System.Data.DbType.String, SmartzEmail);
                dbDatabase.AddInParameter(dbCommand, "@SmartzIsActive", System.Data.DbType.Int32, SmartzIsActive);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzSaveNewUser(string SmartzName, string SmartzEmail, string SmartzUname, string SmatzPassword)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_SmartzSaveNewUser";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);                
                dbDatabase.AddInParameter(dbCommand, "@SmartzName", System.Data.DbType.String, SmartzName);
                dbDatabase.AddInParameter(dbCommand, "@SmartzEmail", System.Data.DbType.String, SmartzEmail);
                dbDatabase.AddInParameter(dbCommand, "@SmartzUname", System.Data.DbType.String, SmartzUname);
                dbDatabase.AddInParameter(dbCommand, "@SmatzPassword", System.Data.DbType.String, SmatzPassword);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzUpdateUserPassword(int SmartzUID, string SmatzPassword)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME3);
                spNameString = "USP_SmartzUpdateUserPassword";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SmartzUID", System.Data.DbType.Int32, SmartzUID);
                dbDatabase.AddInParameter(dbCommand, "@SmatzPassword", System.Data.DbType.String, SmatzPassword);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }




}
