/**********************************************************************
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
    public class VehicleTypeBL
    {
        public IList<VehicleTypeInfo> GetVehicleType()
        {
            //Decalaring MakesInfo division object collection
            IList<VehicleTypeInfo> VehicleTypeInfoIList = new List<VehicleTypeInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader VehicleTypeInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_VehicleType]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object


                //if (System.Web.Caching.Cache["Zips"] == null)
                //{
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                //Executing stored procedure
                VehicleTypeInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (VehicleTypeInfoDataReader.Read())
                {
                    //Assign values to the MakesInfo object list
                    VehicleTypeInfo VehicleTypeInfo = new VehicleTypeInfo();
                    AssignMakesInfoList(VehicleTypeInfoDataReader, VehicleTypeInfo);
                    VehicleTypeInfoIList.Add(VehicleTypeInfo);
                }

                //}
                //else
                //{ 
                //objZips = (List<CarsInfo.ZipcodeDistancesInfo>)System.Web.Caching.Cache["Zips"] ;

                //}

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                VehicleTypeInfoDataReader.Close();
            }

            return VehicleTypeInfoIList;
        }


        private void AssignMakesInfoList(IDataReader VehicleTypeInfoDataReader, VehicleTypeInfo objVehicleTypeinfo)
        {
            try
            {
                objVehicleTypeinfo.TypeID = Convert.ToInt32(VehicleTypeInfoDataReader["TypeID"].ToString());
                objVehicleTypeinfo.TypeName = VehicleTypeInfoDataReader["TypeName"].ToString();

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

    }
}

