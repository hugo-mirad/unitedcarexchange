/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 04-Jan-2012
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
    public class TruckMainBL
    {
        //    public IList<PackagesInfo> GetActivePackages()
        //    {
        //        ///objUsedCars.Decalaring CarsInfo division object collection
        //    IList<PackagesInfo> UsedCarsIList = new List<PackagesInfo>();

        //    string spNameString = string.Empty;


        //    //objUsedCars.Setting Connection
        //    //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

        //    IDataReader UsedCarsDataReader = null;


        //    //objUsedCars.Connect to the database
        //    Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

        //    //objUsedCars.Assign stored procedure name

        //    spNameString = "[USP_GetActivePackages]";
        //    DbCommand dbCommand = null;

        //    try
        //    {
        //        //objUsedCars.Set stored procedure to the command object
        //        dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
        //        dbCommand.CommandTimeout = 10000;

        //        dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String , carId);

        //        //objUsedCars.Executing stored procedure
        //        UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

        //        while (UsedCarsDataReader.Read())
        //        {
        //            //  objUsedCars.Assign values to the CarsInfo object list
        //            PackagesInfo ObjPackagesInfo= new PackagesInfo();
        //            AssignActivePackages(UsedCarsDataReader, ObjPackagesInfo);
        //            UsedCarsIList.Add(ObjCarsInfo_Info);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

        //        if (rethrow)
        //            throw;
        //    }
        //    finally
        //    {
        //        UsedCarsDataReader.Close();
        //    }

        //    return UsedCarsIList;
        //}
        //    private void AssignActivePackages(IDataReader  UsedCarsDataReader, ObjCarsInfo_Info)
        //{
        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 

        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 
        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 
        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 
        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 
        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 
        //    ObjPackagesInfo.PackageID=UsedCarsDataReader["PackageID"].ToString(); 

        //    //,Description,Price,isActive,ValidityPeriod,ProcessingFee,Maxphotos,Maxvideos,Maxcars 


        //}

        public DataSet GetActivePackages()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetActivePackages";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllStates()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetAllStates";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetYears()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetYears";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllTypes()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetAllTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllCategories(int Category_id)
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetAllCategories";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Category_id", System.Data.DbType.Int32, Category_id);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllMakes(int makeID)
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetAllMakes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllDoors()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetAllDoors";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetFuelTypes()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetFuelTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetConditions()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetConditions";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetInteriorColors()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetInteriorColors";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExteriorColors()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetExteriorColors";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEngineManufacturer()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetEngineManufacturer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTransmission()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetTransmission";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSuspension()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetSuspension";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetHorsepower()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetHorsepower";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetFeaturesAndTypes()
        {
            try
            {
                DataSet dsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetFeaturesAndTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveCarFeatures(int CarID, int FeatureID, int Isactive)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCarFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@FeatureID", System.Data.DbType.Int32, FeatureID);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, Isactive);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveTruckRegisterData(UserRegistrationInfo objUserregisInfo, CarsInfo.CarsInfo objCarsInfo, string state, string Ip)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveTruckRegisterData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserregisInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserregisInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objUserregisInfo.Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserregisInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, objUserregisInfo.IsActive);
                dbDatabase.AddInParameter(dbCommand, "@CouponCode", System.Data.DbType.String, objUserregisInfo.CouponCode);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, objUserregisInfo.ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserregisInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserregisInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserregisInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserregisInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, objUserregisInfo.PackageID);

                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeID", System.Data.DbType.Int32, objCarsInfo.MakeID);
                dbDatabase.AddInParameter(dbCommand, "@CategoryID", System.Data.DbType.Int32, objCarsInfo.CategoryID);
                dbDatabase.AddInParameter(dbCommand, "@Model", System.Data.DbType.String, objCarsInfo.Model);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.String, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.CarID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objCarsInfo.FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, objCarsInfo.Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, objCarsInfo.ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, objCarsInfo.Title);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.Int32, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@TransmissionMake", System.Data.DbType.String, objCarsInfo.TransmissionMake);
                dbDatabase.AddInParameter(dbCommand, "@Suspensionid", System.Data.DbType.Int32, objCarsInfo.Suspensionid);
                dbDatabase.AddInParameter(dbCommand, "@HorsePower", System.Data.DbType.Int32, objCarsInfo.HorsePower);
                dbDatabase.AddInParameter(dbCommand, "@Rear", System.Data.DbType.String, objCarsInfo.Rear);
                dbDatabase.AddInParameter(dbCommand, "@Axle", System.Data.DbType.String, objCarsInfo.Axle);
                dbDatabase.AddInParameter(dbCommand, "@EngineManufacturer", System.Data.DbType.String, objCarsInfo.EngineManufacturer);
                dbDatabase.AddInParameter(dbCommand, "@EngineType", System.Data.DbType.Int32, objCarsInfo.EngineType);

                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateTruckEditData(SellerInfo objSellerInfo, CarsInfo.CarsInfo objCarsInfo)
        {
            try
            {
                bool bnew = false;
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateTruckEditData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objSellerInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, objSellerInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objSellerInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objSellerInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, objSellerInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@SellerID", System.Data.DbType.Int32, objSellerInfo.SellerID);

                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeID", System.Data.DbType.Int32, objCarsInfo.MakeID);
                dbDatabase.AddInParameter(dbCommand, "@CategoryID", System.Data.DbType.Int32, objCarsInfo.CategoryID);
                dbDatabase.AddInParameter(dbCommand, "@Model", System.Data.DbType.String, objCarsInfo.Model);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.String, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.CarID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objCarsInfo.FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, objCarsInfo.Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, objCarsInfo.ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, objCarsInfo.Title);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.Int32, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@TransmissionMake", System.Data.DbType.String, objCarsInfo.TransmissionMake);
                dbDatabase.AddInParameter(dbCommand, "@Suspensionid", System.Data.DbType.Int32, objCarsInfo.Suspensionid);
                dbDatabase.AddInParameter(dbCommand, "@HorsePower", System.Data.DbType.Int32, objCarsInfo.HorsePower);
                dbDatabase.AddInParameter(dbCommand, "@Rear", System.Data.DbType.String, objCarsInfo.Rear);
                dbDatabase.AddInParameter(dbCommand, "@Axle", System.Data.DbType.String, objCarsInfo.Axle);
                dbDatabase.AddInParameter(dbCommand, "@EngineManufacturer", System.Data.DbType.String, objCarsInfo.EngineManufacturer);
                dbDatabase.AddInParameter(dbCommand, "@EngineType", System.Data.DbType.Int32, objCarsInfo.EngineType);

                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
