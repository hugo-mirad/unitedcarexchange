/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 31-Jan-2012
' DESCRIPTION  : Business Logic to manipulate .
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

#region Application References
using CarsInfo;
#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
#endregion Microsoft Application Block References

namespace CarsBL.Transactions
{
    public class BuyerTranBL
    {

        public bool SaveBuyerRequest(string BuyerEmail, string BuyerCity,
            string BuyerPhone, string BuyerFirstName, string BuyerLastName, string BuyerComments,
            string IpAddress, string Sellerphone, string Sellerprice, string Carid)
        {
            string spNameString = string.Empty;
            bool bsucess = false;
            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_Save_BuyerRequest]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@BuyerEmail", DbType.String, BuyerEmail);
                dbDatabase.AddInParameter(dbCommand, "@BuyerCity", DbType.String, BuyerCity);
                dbDatabase.AddInParameter(dbCommand, "@BuyerPhone", DbType.String, BuyerPhone);
                dbDatabase.AddInParameter(dbCommand, "@BuyerFirstName", DbType.String, BuyerFirstName);
                dbDatabase.AddInParameter(dbCommand, "@BuyerLastName", DbType.String, BuyerLastName);
                dbDatabase.AddInParameter(dbCommand, "@BuyerComments", DbType.String, BuyerComments);
                dbDatabase.AddInParameter(dbCommand, "@IpAddress", DbType.String, IpAddress);
                dbDatabase.AddInParameter(dbCommand, "@Sellerphone", DbType.String, Sellerphone);
                dbDatabase.AddInParameter(dbCommand, "@Sellerprice", DbType.String, Sellerprice);
                dbDatabase.AddInParameter(dbCommand, "@Carid", DbType.String, Carid);


                //Executing stored procedure
                dbDatabase.ExecuteNonQuery(dbCommand);


                bsucess = true;

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }

            return bsucess;
        }
    }
}
