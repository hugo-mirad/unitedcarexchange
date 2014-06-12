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
using CarsInfo.RvInfo;

#endregion Microsoft Application Block References

namespace CarsBL.RvTransactions
{
    public class RvMainBL
    {
        public DataSet USP_GetAllMakes(int makeID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetAllMakes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetAllModels(int makeID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetAllModels";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetActivePackages()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetActivePackages";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPaymentMethod()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetPaymentType";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzGetPaymentStatus()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzGetPaymentStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool USP_CHANGE_PASSWORD(string NEWPASSWORD, int UID)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_CHANGE_PASSWORD";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@NEWPASSWORD", System.Data.DbType.String, NEWPASSWORD);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetYears";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetAllTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetExteriorColors";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetInteriorColors";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetAllDoors";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetFuelTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetAllPackages()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetAllPackages";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetEngineManufacturer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SmartzUpdateRegUserDetailsForMultiCar(UserRegistrationInfo objUserregisInfo, int TranBy)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
            spNameString = "[USP_SmartzUpdateRegUserDetailsForMultiCar]";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, objUserregisInfo.UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserregisInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserregisInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserregisInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserregisInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserregisInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserregisInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, objUserregisInfo.BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, objUserregisInfo.AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objUserregisInfo.AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetVehicleCondition()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetVehicleCondition";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserExists(string UserName)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_ChkUserExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzSave_RegisterLogUser(RvUserRegistrationInfo objRvUserRegInfo)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
            spNameString = "USP_SmartzSaveRVRegisterLog";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objRvUserRegInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objRvUserRegInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objRvUserRegInfo.Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objRvUserRegInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, objRvUserRegInfo.IsActive);
                dbDatabase.AddInParameter(dbCommand, "@CouponCode", System.Data.DbType.String, objRvUserRegInfo.CouponCode);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, objRvUserRegInfo.ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, objRvUserRegInfo.PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objRvUserRegInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objRvUserRegInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objRvUserRegInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objRvUserRegInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, objRvUserRegInfo.BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, objRvUserRegInfo.AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objRvUserRegInfo.AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, objRvUserRegInfo.SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@VerifierID", System.Data.DbType.Int32, objRvUserRegInfo.VerifierID);
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet SmartzSaveRVData(RvUsedcarsInfo objRvUsedCarsInfo, RvCarsInfo objRvCarsInfo, RvSellerInfo objRvSellerInfo)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveRVData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, objRvSellerInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@Address1", System.Data.DbType.String, objRvSellerInfo.Address1);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objRvSellerInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, objRvSellerInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objRvSellerInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objRvSellerInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, objRvSellerInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objRvSellerInfo.AltPhone);

                dbDatabase.AddInParameter(dbCommand, "@Carid", System.Data.DbType.Int32, objRvUsedCarsInfo.Carid);
                dbDatabase.AddInParameter(dbCommand, "@Uid", System.Data.DbType.Int32, objRvUsedCarsInfo.Uid);
                dbDatabase.AddInParameter(dbCommand, "@SaleDate", System.Data.DbType.DateTime, objRvUsedCarsInfo.SaleDate);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, objRvUsedCarsInfo.PackageID);
                dbDatabase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, objRvUsedCarsInfo.SaleEnteredBy);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, objRvUsedCarsInfo.Ip);

                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objRvCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objRvCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@Model", System.Data.DbType.String, objRvCarsInfo.Model);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objRvCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objRvCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objRvCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objRvCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objRvCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objRvCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objRvCarsInfo.FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objRvCarsInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, objRvCarsInfo.Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, objRvCarsInfo.ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.String, objRvCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, objRvCarsInfo.Title);
                dbDatabase.AddInParameter(dbCommand, "@AirConditioners", System.Data.DbType.Int32, objRvCarsInfo.AirConditioners);
                dbDatabase.AddInParameter(dbCommand, "@Length", System.Data.DbType.String, objRvCarsInfo.Length);
                dbDatabase.AddInParameter(dbCommand, "@WaterCapacity", System.Data.DbType.String, objRvCarsInfo.WaterCapacity);
                dbDatabase.AddInParameter(dbCommand, "@Towing_Capacity", System.Data.DbType.String, objRvCarsInfo.Towing_Capacity);
                dbDatabase.AddInParameter(dbCommand, "@Dry_Weight", System.Data.DbType.String, objRvCarsInfo.Dry_Weight);
                dbDatabase.AddInParameter(dbCommand, "@SleepingCapacity", System.Data.DbType.Int32, objRvCarsInfo.SleepingCapacity);
                dbDatabase.AddInParameter(dbCommand, "@SlideOuts", System.Data.DbType.Int32, objRvCarsInfo.SlideOuts);
                dbDatabase.AddInParameter(dbCommand, "@EngineManufacturer", System.Data.DbType.String, objRvCarsInfo.EngineManufacturer);
                dbDatabase.AddInParameter(dbCommand, "@EngineType", System.Data.DbType.String, objRvCarsInfo.EngineType);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SmartzSaveRvFeatures(int CarID, int FeatureID, int Isactive, int TranBy)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveRvFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@FeatureID", System.Data.DbType.Int32, FeatureID);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, Isactive);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SmartzSaveRvPmntDetails(int pmntType, int pmntStatus, string TransactionID, string IPAddress, int UID, int isActive, string Amount, DateTime PaymentDate, int ListingStatus, DateTime PDDate, int UserPackID, int PostingID, string VoiceRecord)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveRvPmntDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@ListingStatus", System.Data.DbType.Int32, ListingStatus);
                dbDatabase.AddInParameter(dbCommand, "@PDDate", System.Data.DbType.DateTime, PDDate);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SmartzSaveRvPmntDetailsForFreePackage(int UID, int isActive, int ListingStatus, int UserPackID, int PostingID)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveRvPmntDetailsForFreePackage";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@ListingStatus", System.Data.DbType.Int32, ListingStatus);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzSearchNewByRVUserDetails(string phone, string Name, string email, int AgentName)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSearchNewByRVUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@AgentName", System.Data.DbType.Int32, AgentName);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzSearchNewByRVVehicleDetails(int RVTYPE, int makeModelID, string yearOfMake)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSearchNewByRVVehicleDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@RVTYPE", System.Data.DbType.Int32, RVTYPE);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", System.Data.DbType.Int32, makeModelID);
                dbDatabase.AddInParameter(dbCommand, "@yearOfMake", System.Data.DbType.String, yearOfMake);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCustomerDetailsByPostingID(int PostingID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetCustomerDetailsByPostingID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateCustomerInternalNotes(int carId, string InternalNotes, int UID)
        {
            try
            {
                DataSet dsInternalNotes = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_UpdateCustomerInternalNotes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@carId", System.Data.DbType.Int32, carId);
                dbDatabase.AddInParameter(dbCommand, "@InternalNotes", System.Data.DbType.String, InternalNotes);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsInternalNotes = dbDatabase.ExecuteDataSet(dbCommand);
                return dsInternalNotes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_Customer_LockStatus(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "Get_Customer_LockStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_Lock_Customer(int PostingID, int IsLocked)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_Lock_Customer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@IsLocked", System.Data.DbType.Int32, IsLocked);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetTransactionDetailsForCustomer(int CarID, int PostingID, int SellerID, int pmntID)
        {
            try
            {
                DataSet dsCSData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetTransactionDetailsForCustomer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@SellerID", System.Data.DbType.Int32, SellerID);
                dbDatabase.AddInParameter(dbCommand, "@pmntID", System.Data.DbType.Int32, pmntID);

                dsCSData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCSData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetTransactionDetailsForUserDetails(int UID)
        {
            try
            {
                DataSet dsCSData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetTransactionDetailsForUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsCSData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCSData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SmartzSaveCSDetails(int CarID, int CallAgentID, int CallType, int CallReason, string Notes, int CSResolution, string SpokeWith)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveCSDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@CallAgentID", System.Data.DbType.Int32, CallAgentID);
                dbDatabase.AddInParameter(dbCommand, "@CallType", System.Data.DbType.Int32, CallType);
                dbDatabase.AddInParameter(dbCommand, "@CallReason", System.Data.DbType.Int32, CallReason);
                dbDatabase.AddInParameter(dbCommand, "@Notes", System.Data.DbType.String, Notes);
                dbDatabase.AddInParameter(dbCommand, "@CSResolution", System.Data.DbType.Int32, CSResolution);
                dbDatabase.AddInParameter(dbCommand, "@SpokeWith", System.Data.DbType.String, SpokeWith);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SmartzSaveCSandTicketDetails(int CarID, int CallAgentID, int CallType, int CallReason, string Notes, int TicketType, int TicketPriority, int CallbackID, string TicketDescription, int CSResolution, string SpokeWith)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveCSandTicketDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@CallAgentID", System.Data.DbType.Int32, CallAgentID);
                dbDatabase.AddInParameter(dbCommand, "@CallType", System.Data.DbType.Int32, CallType);
                dbDatabase.AddInParameter(dbCommand, "@CallReason", System.Data.DbType.Int32, CallReason);
                dbDatabase.AddInParameter(dbCommand, "@Notes", System.Data.DbType.String, Notes);
                dbDatabase.AddInParameter(dbCommand, "@TicketType", System.Data.DbType.Int32, TicketType);
                dbDatabase.AddInParameter(dbCommand, "@TicketPriority", System.Data.DbType.Int32, TicketPriority);
                dbDatabase.AddInParameter(dbCommand, "@CallbackID", System.Data.DbType.Int32, CallbackID);
                dbDatabase.AddInParameter(dbCommand, "@TicketDescription", System.Data.DbType.String, TicketDescription);
                dbDatabase.AddInParameter(dbCommand, "@CSResolution", System.Data.DbType.Int32, CSResolution);
                dbDatabase.AddInParameter(dbCommand, "@SpokeWith", System.Data.DbType.String, SpokeWith);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzChkUserExistsForUpdate(string UserName, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzChkUserExistsForUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SmartzUpdateRegUserDetails(RvUserRegistrationInfo objUserRegInfo, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzUpdateRegUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, objUserRegInfo.UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserRegInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserRegInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserRegInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserRegInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserRegInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserRegInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserRegInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objUserRegInfo.Pwd);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, objUserRegInfo.ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, objUserRegInfo.BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, objUserRegInfo.AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objUserRegInfo.AltPhone);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool SmartzUpdateRVEditData(RvSellerInfo objSellerInfo, RvCarsInfo objCarsInfo, RvUsedcarsInfo objUsedCarsInfo, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzUpdateRVEditData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objSellerInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objSellerInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, objSellerInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, objSellerInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objSellerInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objSellerInfo.AltPhone);

                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
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
                dbDatabase.AddInParameter(dbCommand, "@AirConditioners", System.Data.DbType.Int32, objCarsInfo.AirConditioners);
                dbDatabase.AddInParameter(dbCommand, "@Length", System.Data.DbType.String, objCarsInfo.Length);
                dbDatabase.AddInParameter(dbCommand, "@WaterCapacity", System.Data.DbType.String, objCarsInfo.WaterCapacity);
                dbDatabase.AddInParameter(dbCommand, "@Towing_Capacity", System.Data.DbType.String, objCarsInfo.Towing_Capacity);
                dbDatabase.AddInParameter(dbCommand, "@Dry_Weight", System.Data.DbType.String, objCarsInfo.Dry_Weight);
                dbDatabase.AddInParameter(dbCommand, "@SleepingCapacity", System.Data.DbType.Int32, objCarsInfo.SleepingCapacity);
                dbDatabase.AddInParameter(dbCommand, "@SlideOuts", System.Data.DbType.Int32, objCarsInfo.SlideOuts);
                dbDatabase.AddInParameter(dbCommand, "@EngineManufacturer", System.Data.DbType.String, objCarsInfo.EngineManufacturer);
                dbDatabase.AddInParameter(dbCommand, "@EngineType", System.Data.DbType.String, objCarsInfo.EngineType);
                dbDatabase.AddInParameter(dbCommand, "@InternalNotes", System.Data.DbType.String, objCarsInfo.InternalNotes);

                dbDatabase.AddInParameter(dbCommand, "@IsActive", System.Data.DbType.Int32, objUsedCarsInfo.IsActive);
                dbDatabase.AddInParameter(dbCommand, "@ListingStatus", System.Data.DbType.Int32, objUsedCarsInfo.AdStatus);
                dbDatabase.AddInParameter(dbCommand, "@SellerID", System.Data.DbType.Int32, objUsedCarsInfo.SellerID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, objUsedCarsInfo.PostingID);

                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);



                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SmartzUpdatePayDetails(int pmntType, int pmntStatus, string IPAddress, int UID, int pmntID, int TranBy, int PostingID, int UserPackID)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzUpdatePayDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@pmntID", System.Data.DbType.Int32, pmntID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool USP_SmartzUpdatePayDetailsForPaid(int pmntType, int pmntStatus, string IPAddress, int UID, int pmntID, int TranBy, int PostingID, DateTime PaymentDate, string TransactionID, string VoiceRecord, int UserPackID)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzUpdatePayDetailsForPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@pmntID", System.Data.DbType.Int32, pmntID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzTicketSearch(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzTicketSearch";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SelMode", System.Data.DbType.Int32, SelMode);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzTicketSearchDownload(int SelMode, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzTicketSearchDownload";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SelMode", System.Data.DbType.Int32, SelMode);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dsAgents = dbDatabase.ExecuteDataSet(dbCommand);
                return dsAgents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzGetDataByTicketID(int TicketID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzGetDataByTicketID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@TicketID", System.Data.DbType.Int32, TicketID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SmartzUpdateTicketDetails(int TicketID, DateTime CallBackDate, int TicketStatus, int AssignedTo, int SolvedBy, DateTime SolvedDate, string TicketComments)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzUpdateTicketDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@TicketID", System.Data.DbType.Int32, TicketID);
                dbDatabase.AddInParameter(dbCommand, "@CallBackDate", System.Data.DbType.DateTime, CallBackDate);
                dbDatabase.AddInParameter(dbCommand, "@TicketStatus", System.Data.DbType.Int32, TicketStatus);
                dbDatabase.AddInParameter(dbCommand, "@AssignedTo", System.Data.DbType.Int32, AssignedTo);
                dbDatabase.AddInParameter(dbCommand, "@SolvedBy", System.Data.DbType.Int32, SolvedBy);
                dbDatabase.AddInParameter(dbCommand, "@SolvedDate", System.Data.DbType.DateTime, SolvedDate);
                dbDatabase.AddInParameter(dbCommand, "@TicketComments", System.Data.DbType.String, TicketComments);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSearchNewByRVID(int CarID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSearchNewByRVID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSearchNewByRVUserDetailsForDealer(string phone, string Name, string email, int CustomerType)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSearchNewByRVUserDetailsForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@CustomerType", System.Data.DbType.Int32, CustomerType);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzWelcomeCallSearch(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzWelcomeCallSearch";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SelMode", System.Data.DbType.Int32, SelMode);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzGetCustmerServiceData()
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzGetCustmerServiceData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsAgents = dbDatabase.ExecuteDataSet(dbCommand);
                return dsAgents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzGetCSDataByCSCallID(int CallID)
        {
            try
            {
                DataSet dsCSData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzGetCSDataByCSCallID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CallID", System.Data.DbType.Int32, CallID);
                dsCSData = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCSData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzCheckCarIDExistsForMultiSiteUploads(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzCheckCarIDExistsForMultiSiteUploads";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzChaeckUrlExistsInMaster(string DomainUrl)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzChaeckUrlExistsInMaster";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@DomainUrl", System.Data.DbType.String, DomainUrl);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SmartzSaveUrlForCarID(int CarID, string URL, int SiteID, int PostedBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveUrlForCarID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@URL", System.Data.DbType.String, URL);
                dbDatabase.AddInParameter(dbCommand, "@SiteID", System.Data.DbType.Int32, SiteID);
                dbDatabase.AddInParameter(dbCommand, "@PostedBy", System.Data.DbType.Int32, PostedBy);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzCheckZipExists(string Zip)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzCheckZipExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPDPaymentDataForRVs(int TypeID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetPDPaymentDataForRVs";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@TypeID", System.Data.DbType.Int32, TypeID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GETNewSalesAgentReportForRvs(int Isactive, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GETNewSalesAgentReportForRvs";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, Isactive);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dsAgents = dbDatabase.ExecuteDataSet(dbCommand);
                return dsAgents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SmartzGetSalesDataForRvs()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzGetSalesDataForRvs";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzGetRvsAgentSalesBetweenDate(int Sale_Agent_Id, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzGetRvsAgentSalesBetweenDate";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Sale_Agent_Id", System.Data.DbType.Int32, Sale_Agent_Id);
                dbDatabase.AddInParameter(dbCommand, "@FromDate", System.Data.DbType.DateTime, FromDate);
                dbDatabase.AddInParameter(dbCommand, "@ToDate", System.Data.DbType.DateTime, ToDate);
                dsAgents = dbDatabase.ExecuteDataSet(dbCommand);
                return dsAgents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SmartzUpdatePDDateRV(int TranBy, DateTime PDDate, int UserPackID, int PostingID)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzUpdatePDDateRV";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@PDDate", System.Data.DbType.DateTime, PDDate);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dsAgents = dbDatabase.ExecuteDataSet(dbCommand);
                return dsAgents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Smartz30DaysReviewCallSearchRV(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_Smartz30DaysReviewCallSearchRV";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SelMode", System.Data.DbType.Int32, SelMode);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Smartz60DaysReviewCallSearchRVs(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_Smartz60DaysReviewCallSearchRVs";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@SelMode", System.Data.DbType.Int32, SelMode);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet FillCBDropdown()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_FillCBDropdown";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSaveCBNotice(int PostingID, int paymentID, ChargeBackInfo objChargeBackInfo)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_SmartzSaveCBNotice";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@paymentID", System.Data.DbType.Int32, paymentID);
                dbDatabase.AddInParameter(dbCommand, "@CustomerContactdate", System.Data.DbType.DateTime, objChargeBackInfo.CustomerContactdate);
                dbDatabase.AddInParameter(dbCommand, "@RequestType", System.Data.DbType.Int32, objChargeBackInfo.RequestType);
                dbDatabase.AddInParameter(dbCommand, "@ReasonCode", System.Data.DbType.String, objChargeBackInfo.ReasonCode);
                dbDatabase.AddInParameter(dbCommand, "@ReasonCodeDescription", System.Data.DbType.String, objChargeBackInfo.ReasonCodeDescription);
                dbDatabase.AddInParameter(dbCommand, "@CaseNumber", System.Data.DbType.String, objChargeBackInfo.CaseNumber);
                dbDatabase.AddInParameter(dbCommand, "@CBAmount", System.Data.DbType.String, objChargeBackInfo.CBAmount);
                dbDatabase.AddInParameter(dbCommand, "@ClaimantName", System.Data.DbType.String, objChargeBackInfo.ClaimantName);
                dbDatabase.AddInParameter(dbCommand, "@CustomerCBVoiceFile", System.Data.DbType.String, objChargeBackInfo.CustomerCBVoiceFile);
                dbDatabase.AddInParameter(dbCommand, "@Notes", System.Data.DbType.String, objChargeBackInfo.Notes);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<UsedCarsInfoRV> FindCarID(string CarID)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfoRV> UsedCarsIList = new List<UsedCarsInfoRV>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);

            //objUsedCars.Assign stored procedure name


            spNameString = "[USP_FindCarID]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.String, CarID);

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);
                // DataSet  ds =dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfoRV ObjCarsInfo_Info = new UsedCarsInfoRV();
                    AssignCarsInfoList(UsedCarsDataReader, ObjCarsInfo_Info);
                    UsedCarsIList.Add(ObjCarsInfo_Info);
                }
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                UsedCarsDataReader.Close();
            }

            return UsedCarsIList;
        }
        private void AssignCarsInfoList(IDataReader UsedCarsDataReader, UsedCarsInfoRV objUsedCars)
        {
            try
            {


                objUsedCars.PostingID = Convert.ToInt32(UsedCarsDataReader["PostingID"].ToString());
                objUsedCars.Carid = Convert.ToInt32(UsedCarsDataReader["Carid"].ToString());
                objUsedCars.SellerType = UsedCarsDataReader["SellerType"].ToString();
                objUsedCars.SellerID = Convert.ToInt32(UsedCarsDataReader["SellerID"].ToString());
                objUsedCars.DateOfPosting = Convert.ToDateTime(UsedCarsDataReader["DateOfPosting"].ToString());
                objUsedCars.ExpirtyDate = UsedCarsDataReader["ExpirtyDate"].ToString() == "" ? System.DateTime.Now : Convert.ToDateTime(UsedCarsDataReader["ExpirtyDate"].ToString());
                objUsedCars.PackageID = UsedCarsDataReader["PackageID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["PackageID"].ToString());
                objUsedCars.PaymentID = UsedCarsDataReader["PaymentID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["PaymentID"].ToString());
                objUsedCars.IsActive = UsedCarsDataReader["IsActive"].ToString() == "" ? true : Convert.ToBoolean(UsedCarsDataReader["IsActive"].ToString());
                objUsedCars.InternalreviewID = UsedCarsDataReader["InternalreviewID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["InternalreviewID"].ToString());
                objUsedCars.CancelledBy = UsedCarsDataReader["CancelledBy"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["CancelledBy"].ToString());
                objUsedCars.CancelledReason = UsedCarsDataReader["CancelledReason"].ToString();
                objUsedCars.CancelledDate = UsedCarsDataReader["CancelledDate"].ToString() == "" ? System.DateTime.Now : Convert.ToDateTime(UsedCarsDataReader["CancelledDate"].ToString());
                objUsedCars.Zipcode = UsedCarsDataReader["Zipcode"].ToString();
                objUsedCars.Uid = UsedCarsDataReader["Uid"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["Uid"].ToString());


                objUsedCars.SellerName = UsedCarsDataReader["SellerName"].ToString() == "" ? "Emp" : UsedCarsDataReader["SellerName"].ToString();

                objUsedCars.Address1 = UsedCarsDataReader["Address1"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address1"].ToString();
                objUsedCars.Address2 = UsedCarsDataReader["Address2"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address2"].ToString();
                objUsedCars.City = UsedCarsDataReader["City"].ToString() == "" ? "Emp" : UsedCarsDataReader["City"].ToString();
                objUsedCars.State = UsedCarsDataReader["State"].ToString();
                objUsedCars.Zip = UsedCarsDataReader["Zip"].ToString();
                objUsedCars.Country = UsedCarsDataReader["Country"].ToString() == "1" ? "USA" : UsedCarsDataReader["Country"].ToString();
                objUsedCars.Phone = UsedCarsDataReader["Phone"].ToString();
                objUsedCars.AltPhone = UsedCarsDataReader["AltPhone"].ToString();
                objUsedCars.Fax = UsedCarsDataReader["Fax"].ToString();
                objUsedCars.Email = UsedCarsDataReader["Email"].ToString() == "" ? "Emp" : UsedCarsDataReader["Email"].ToString();
                objUsedCars.AltEmail = UsedCarsDataReader["AltEmail"].ToString() == "" ? "Emp" : UsedCarsDataReader["Email"].ToString();
                objUsedCars.NotesForBuyers = UsedCarsDataReader["NotesForBuyers"].ToString();
                objUsedCars.Model = UsedCarsDataReader["model"].ToString();
                objUsedCars.Make = UsedCarsDataReader["make"].ToString();
                objUsedCars.YearOfMake = UsedCarsDataReader["yearOfMake"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["yearOfMake"].ToString());
                objUsedCars.Mileage = UsedCarsDataReader["mileage"].ToString() == "" ? 0 : Convert.ToInt32(Convert.ToDouble(UsedCarsDataReader["mileage"].ToString()));
                objUsedCars.MakeID = UsedCarsDataReader["makeID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeID"].ToString());
                objUsedCars.MakeModelID = UsedCarsDataReader["makeModelID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeModelID"].ToString());
                objUsedCars.Price = UsedCarsDataReader["price"].ToString() == "" ? 0.00 : Convert.ToDouble(UsedCarsDataReader["price"].ToString());
                objUsedCars.Description = UsedCarsDataReader["description"].ToString() == "" ? "Emp" : UsedCarsDataReader["description"].ToString();
                objUsedCars.Title = UsedCarsDataReader["Title"].ToString() == "" ? "Emp" : UsedCarsDataReader["Title"].ToString();

                objUsedCars.Bodytype = UsedCarsDataReader["bodytype"].ToString();
                objUsedCars.BodytypeID = Convert.ToInt32(UsedCarsDataReader["BodytypeID"].ToString() == "" ? "0" : UsedCarsDataReader["BodytypeID"].ToString().ToString());
                objUsedCars.FueltypeId = Convert.ToInt32(UsedCarsDataReader["FueltypeID"].ToString());
                objUsedCars.Fueltype = UsedCarsDataReader["Fueltype"].ToString();

                objUsedCars.ExteriorColor = UsedCarsDataReader["exteriorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["exteriorColor"].ToString();
                objUsedCars.NumberOfSeats = UsedCarsDataReader["numberOfSeats"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfSeats"].ToString();
                objUsedCars.NumberOfDoors = UsedCarsDataReader["numberOfDoors"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfDoors"].ToString();
                objUsedCars.NumberOfCylinder = UsedCarsDataReader["numberOfCylinder"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfCylinder"].ToString();
                objUsedCars.Transmission = UsedCarsDataReader["Transmission"].ToString() == "" ? "Emp" : UsedCarsDataReader["Transmission"].ToString();
                objUsedCars.InteriorColor = UsedCarsDataReader["interiorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["interiorColor"].ToString();
                objUsedCars.UserFeedback = UsedCarsDataReader["UserFeedback"].ToString();
                objUsedCars.VIN = UsedCarsDataReader["VIN"].ToString() == "" ? "Emp" : UsedCarsDataReader["VIN"].ToString();

                objUsedCars.PIC0 = UsedCarsDataReader["PIC0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC0"].ToString();
                objUsedCars.PIC1 = UsedCarsDataReader["PIC1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC1"].ToString();
                objUsedCars.PIC2 = UsedCarsDataReader["PIC2"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC2"].ToString();
                objUsedCars.PIC3 = UsedCarsDataReader["PIC3"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC3"].ToString();
                objUsedCars.PIC4 = UsedCarsDataReader["PIC4"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC4"].ToString();
                objUsedCars.PIC5 = UsedCarsDataReader["PIC5"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC5"].ToString();
                objUsedCars.PIC6 = UsedCarsDataReader["PIC6"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC6"].ToString();
                objUsedCars.PIC7 = UsedCarsDataReader["PIC7"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC7"].ToString();
                objUsedCars.PIC8 = UsedCarsDataReader["PIC8"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC8"].ToString();
                objUsedCars.PIC9 = UsedCarsDataReader["PIC9"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC9"].ToString();
                objUsedCars.PIC10 = UsedCarsDataReader["PIC10"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC10"].ToString();
                objUsedCars.PICLOC0 = UsedCarsDataReader["PICLOC0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC0"].ToString();
                objUsedCars.PICLOC1 = UsedCarsDataReader["PICLOC1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC1"].ToString();
                objUsedCars.PICLOC2 = UsedCarsDataReader["PICLOC2"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC2"].ToString();
                objUsedCars.PICLOC3 = UsedCarsDataReader["PICLOC3"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC3"].ToString();
                objUsedCars.PICLOC4 = UsedCarsDataReader["PICLOC4"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC4"].ToString();
                objUsedCars.PICLOC5 = UsedCarsDataReader["PICLOC5"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC5"].ToString();
                objUsedCars.PICLOC6 = UsedCarsDataReader["PICLOC6"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC6"].ToString();
                objUsedCars.PICLOC7 = UsedCarsDataReader["PICLOC7"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC7"].ToString();
                objUsedCars.PICLOC8 = UsedCarsDataReader["PICLOC8"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC8"].ToString();
                objUsedCars.PICLOC9 = UsedCarsDataReader["PICLOC9"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC9"].ToString();
                objUsedCars.PICLOC10 = UsedCarsDataReader["PICLOC10"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC10"].ToString();




                objUsedCars.ConditionDescription = UsedCarsDataReader["ConditionDescription"].ToString() == "" ? "Emp" : UsedCarsDataReader["ConditionDescription"].ToString();
                objUsedCars.DriveTrain = UsedCarsDataReader["DriveTrain"].ToString() == "" ? "Emp" : UsedCarsDataReader["DriveTrain"].ToString();
                objUsedCars.TypeName = UsedCarsDataReader["TypeName"].ToString() == "" ? "Emp" : UsedCarsDataReader["TypeName"].ToString();
                objUsedCars.TypeID = UsedCarsDataReader["TypeID"].ToString() == "" ? "Emp" : UsedCarsDataReader["TypeID"].ToString();

                objUsedCars.AirConditioners = UsedCarsDataReader["AirConditioners"].ToString() == "" ? "Emp" : UsedCarsDataReader["AirConditioners"].ToString(); ;
                objUsedCars.Length = UsedCarsDataReader["Length"].ToString() == "" ? "Emp" : UsedCarsDataReader["Length"].ToString(); ;
                objUsedCars.WaterCapacity = UsedCarsDataReader["WaterCapacity"].ToString() == "" ? "Emp" : UsedCarsDataReader["WaterCapacity"].ToString(); ;
                objUsedCars.Towing_Capacity = UsedCarsDataReader["Towing_Capacity"].ToString() == "" ? "Emp" : UsedCarsDataReader["Towing_Capacity"].ToString(); ;
                objUsedCars.Dry_Weight = UsedCarsDataReader["Dry_Weight"].ToString() == "" ? "Emp" : UsedCarsDataReader["Dry_Weight"].ToString(); ;
                objUsedCars.SleepingCapacity = UsedCarsDataReader["SleepingCapacity"].ToString() == "" ? "Emp" : UsedCarsDataReader["SleepingCapacity"].ToString(); ;
                objUsedCars.SlideOuts = UsedCarsDataReader["SlideOuts"].ToString() == "" ? "Emp" : UsedCarsDataReader["SlideOuts"].ToString(); ;
                objUsedCars.EngineManufacturer = UsedCarsDataReader["EngineManufacturer"].ToString() == "" ? "Emp" : UsedCarsDataReader["EngineManufacturer"].ToString();
                objUsedCars.EngineType = UsedCarsDataReader["EngineType"].ToString() == "" ? "Emp" : UsedCarsDataReader["EngineType"].ToString();

                objUsedCars.RowNumber = UsedCarsDataReader["RowNumber"].ToString() == "" ? "Emp" : UsedCarsDataReader["RowNumber"].ToString();
                objUsedCars.CarUniqueID = Convert.ToInt64(UsedCarsDataReader["CarUniqueID"].ToString());
                objUsedCars.TotalRecords = UsedCarsDataReader["TotalRecords"].ToString() == "" ? "Emp" : UsedCarsDataReader["TotalRecords"].ToString();
                objUsedCars.PageCount = UsedCarsDataReader["PageCount"].ToString() == "" ? "Emp" : UsedCarsDataReader["PageCount"].ToString();

                objUsedCars.PIC11 = UsedCarsDataReader["PIC11"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC11"].ToString();
                objUsedCars.PIC12 = UsedCarsDataReader["PIC12"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC12"].ToString();
                objUsedCars.PIC13 = UsedCarsDataReader["PIC13"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC13"].ToString();
                objUsedCars.PIC14 = UsedCarsDataReader["PIC14"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC14"].ToString();
                objUsedCars.PIC15 = UsedCarsDataReader["PIC15"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC15"].ToString();
                objUsedCars.PIC16 = UsedCarsDataReader["PIC16"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC16"].ToString();
                objUsedCars.PIC17 = UsedCarsDataReader["PIC17"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC17"].ToString();
                objUsedCars.PIC18 = UsedCarsDataReader["PIC18"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC18"].ToString();
                objUsedCars.PIC19 = UsedCarsDataReader["PIC19"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC19"].ToString();
                objUsedCars.PIC20 = UsedCarsDataReader["PIC20"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC20"].ToString();


                objUsedCars.PICLOC11 = UsedCarsDataReader["PICLOC11"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC11"].ToString();
                objUsedCars.PICLOC12 = UsedCarsDataReader["PICLOC12"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC12"].ToString();
                objUsedCars.PICLOC13 = UsedCarsDataReader["PICLOC13"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC13"].ToString();
                objUsedCars.PICLOC14 = UsedCarsDataReader["PICLOC14"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC14"].ToString();
                objUsedCars.PICLOC15 = UsedCarsDataReader["PICLOC15"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC15"].ToString();
                objUsedCars.PICLOC16 = UsedCarsDataReader["PICLOC16"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC16"].ToString();
                objUsedCars.PICLOC17 = UsedCarsDataReader["PICLOC17"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC17"].ToString();
                objUsedCars.PICLOC18 = UsedCarsDataReader["PICLOC18"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC18"].ToString();
                objUsedCars.PICLOC19 = UsedCarsDataReader["PICLOC19"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC19"].ToString();
                objUsedCars.PICLOC20 = UsedCarsDataReader["PICLOC20"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC20"].ToString();


                objUsedCars.PIC21 = UsedCarsDataReader["PIC21"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC21"].ToString();
                objUsedCars.PIC22 = UsedCarsDataReader["PIC22"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC22"].ToString();
                objUsedCars.PIC23 = UsedCarsDataReader["PIC23"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC23"].ToString();
                objUsedCars.PIC24 = UsedCarsDataReader["PIC24"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC24"].ToString();
                objUsedCars.PIC25 = UsedCarsDataReader["PIC25"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC25"].ToString();
                objUsedCars.PIC26 = UsedCarsDataReader["PIC26"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC26"].ToString();
                objUsedCars.PIC27 = UsedCarsDataReader["PIC27"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC27"].ToString();
                objUsedCars.PIC28 = UsedCarsDataReader["PIC28"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC28"].ToString();
                objUsedCars.PIC29 = UsedCarsDataReader["PIC29"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC29"].ToString();
                objUsedCars.PIC30 = UsedCarsDataReader["PIC30"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC30"].ToString();

                objUsedCars.PICLOC21 = UsedCarsDataReader["PICLOC21"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC21"].ToString();
                objUsedCars.PICLOC22 = UsedCarsDataReader["PICLOC22"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC22"].ToString();
                objUsedCars.PICLOC23 = UsedCarsDataReader["PICLOC23"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC23"].ToString();
                objUsedCars.PICLOC24 = UsedCarsDataReader["PICLOC24"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC24"].ToString();
                objUsedCars.PICLOC25 = UsedCarsDataReader["PICLOC25"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC25"].ToString();
                objUsedCars.PICLOC26 = UsedCarsDataReader["PICLOC26"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC26"].ToString();
                objUsedCars.PICLOC27 = UsedCarsDataReader["PICLOC27"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC27"].ToString();
                objUsedCars.PICLOC28 = UsedCarsDataReader["PICLOC28"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC28"].ToString();
                objUsedCars.PICLOC29 = UsedCarsDataReader["PICLOC29"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC29"].ToString();
                objUsedCars.PICLOC30 = UsedCarsDataReader["PICLOC30"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC30"].ToString();


                objUsedCars.PIC31 = UsedCarsDataReader["PIC31"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC31"].ToString();
                objUsedCars.PIC32 = UsedCarsDataReader["PIC32"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC32"].ToString();
                objUsedCars.PIC33 = UsedCarsDataReader["PIC33"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC33"].ToString();
                objUsedCars.PIC34 = UsedCarsDataReader["PIC34"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC34"].ToString();
                objUsedCars.PIC35 = UsedCarsDataReader["PIC35"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC35"].ToString();
                objUsedCars.PIC36 = UsedCarsDataReader["PIC36"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC36"].ToString();
                objUsedCars.PIC37 = UsedCarsDataReader["PIC37"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC37"].ToString();
                objUsedCars.PIC38 = UsedCarsDataReader["PIC38"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC38"].ToString();
                objUsedCars.PIC39 = UsedCarsDataReader["PIC39"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC39"].ToString();
                objUsedCars.PIC40 = UsedCarsDataReader["PIC40"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC40"].ToString();

                objUsedCars.PICLOC31 = UsedCarsDataReader["PICLOC31"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC31"].ToString();
                objUsedCars.PICLOC32 = UsedCarsDataReader["PICLOC32"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC32"].ToString();
                objUsedCars.PICLOC33 = UsedCarsDataReader["PICLOC33"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC33"].ToString();
                objUsedCars.PICLOC34 = UsedCarsDataReader["PICLOC34"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC34"].ToString();
                objUsedCars.PICLOC35 = UsedCarsDataReader["PICLOC35"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC35"].ToString();
                objUsedCars.PICLOC36 = UsedCarsDataReader["PICLOC36"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC36"].ToString();
                objUsedCars.PICLOC37 = UsedCarsDataReader["PICLOC37"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC37"].ToString();
                objUsedCars.PICLOC38 = UsedCarsDataReader["PICLOC38"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC38"].ToString();
                objUsedCars.PICLOC39 = UsedCarsDataReader["PICLOC39"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC39"].ToString();
                objUsedCars.PICLOC40 = UsedCarsDataReader["PICLOC40"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC40"].ToString();




                objUsedCars.PIC41 = UsedCarsDataReader["PIC41"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC41"].ToString();
                objUsedCars.PIC42 = UsedCarsDataReader["PIC42"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC42"].ToString();
                objUsedCars.PIC43 = UsedCarsDataReader["PIC43"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC43"].ToString();
                objUsedCars.PIC44 = UsedCarsDataReader["PIC44"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC44"].ToString();
                objUsedCars.PIC45 = UsedCarsDataReader["PIC45"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC45"].ToString();
                objUsedCars.PIC46 = UsedCarsDataReader["PIC46"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC46"].ToString();
                objUsedCars.PIC47 = UsedCarsDataReader["PIC47"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC47"].ToString();
                objUsedCars.PIC48 = UsedCarsDataReader["PIC48"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC48"].ToString();
                objUsedCars.PIC49 = UsedCarsDataReader["PIC49"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC49"].ToString();
                objUsedCars.PIC50 = UsedCarsDataReader["PIC50"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC50"].ToString();

                objUsedCars.PICLOC41 = UsedCarsDataReader["PICLOC41"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC41"].ToString();
                objUsedCars.PICLOC42 = UsedCarsDataReader["PICLOC42"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC42"].ToString();
                objUsedCars.PICLOC43 = UsedCarsDataReader["PICLOC43"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC43"].ToString();
                objUsedCars.PICLOC44 = UsedCarsDataReader["PICLOC44"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC44"].ToString();
                objUsedCars.PICLOC45 = UsedCarsDataReader["PICLOC45"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC45"].ToString();
                objUsedCars.PICLOC46 = UsedCarsDataReader["PICLOC46"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC46"].ToString();
                objUsedCars.PICLOC47 = UsedCarsDataReader["PICLOC47"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC47"].ToString();
                objUsedCars.PICLOC48 = UsedCarsDataReader["PICLOC48"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC48"].ToString();
                objUsedCars.PICLOC49 = UsedCarsDataReader["PICLOC49"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC49"].ToString();
                objUsedCars.PICLOC50 = UsedCarsDataReader["PICLOC50"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC50"].ToString();








                //objUsedCars.pic0 = UsedCarsDataReader["pic0"].ToString();


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }



        }
        public DataSet GetCarFeatures(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "GetCarFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetRvUserDetailsByUID(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetUSerDetailsByUserID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetPackageDetailsByUserPackID(int UserPackID)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME2);
                spNameString = "USP_GetPackageDetailsByUserPackID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dsAgents = dbDatabase.ExecuteDataSet(dbCommand);
                return dsAgents;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
