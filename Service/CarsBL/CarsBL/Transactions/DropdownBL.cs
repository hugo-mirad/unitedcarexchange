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
    public class DropdownBL
    {

        public DataSet Usp_Get_DropDown()
        {
            try
            {
                DataSet dsFuelTypes = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "Usp_Get_DropDown";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsFuelTypes = dbDatabase.ExecuteDataSet(dbCommand);
                return dsFuelTypes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetNext12years()
        {
            try
            {
                DataSet dsFuelTypes = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetNext12years";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsFuelTypes = dbDatabase.ExecuteDataSet(dbCommand);
                return dsFuelTypes;
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_SmartzSearchDetails(string phone, string sellerName, string email, int makeModelID, string yearOfMake, int packageID, int makeID, int AgentName)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, sellerName);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", System.Data.DbType.Int32, makeModelID);
                dbDatabase.AddInParameter(dbCommand, "@yearOfMake", System.Data.DbType.String, yearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@packageID", System.Data.DbType.Int32, packageID);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
                dbDatabase.AddInParameter(dbCommand, "@AgentName", System.Data.DbType.Int32, AgentName);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SmartzSearchAbandonSalesDetails(string phone, string sellerName, string email, int makeModelID, string yearOfMake, int packageID, int makeID, string AgentName)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchAbandonSalesDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, sellerName);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", System.Data.DbType.Int32, makeModelID);
                dbDatabase.AddInParameter(dbCommand, "@yearOfMake", System.Data.DbType.String, yearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@packageID", System.Data.DbType.Int32, packageID);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
                dbDatabase.AddInParameter(dbCommand, "@AgentName", System.Data.DbType.String, AgentName);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetCustomerDetailsByPostingID(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCustomerDetailsByPostingID";
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
        public DataSet GetYears()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_GetCustomerDetailsByPostingIDForLocking(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCustomerDetailsByPostingIDForLocking";
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


        public DataSet Get_Customer_LockStatus(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_SmartzSearchByCarID(int CarID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchByCarID";
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

        public DataSet USP_SmartzSearchAbandonSalesByCarID(int CarID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchAbandonSalesByCarID";
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

        public DataSet GetCarFeatures(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_UpdateCustomerInternalNotes(int carId, string InternalNotes, int UID)
        {
            try
            {
                DataSet dsInternalNotes = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet UpdateCustomerSpecialNotes(int CustUID, string SpecialNotes, int UID)
        {
            try
            {
                DataSet dsInternalNotes = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateCustomerSpecialNotes";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CustUID", System.Data.DbType.Int32, CustUID);
                dbDatabase.AddInParameter(dbCommand, "@SpecialNotes", System.Data.DbType.String, SpecialNotes);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsInternalNotes = dbDatabase.ExecuteDataSet(dbCommand);
                return dsInternalNotes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool USP_SmartzUpdateRegUserDetails(int UId, string Name, string PhoneNumber, string City, int StateID, string Address, string Zip, string UserName, string Pwd, string ReferCode, int TranBy, string BusinessName, string AltEmail, string AltPhone, int EmailExists)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateRegUserDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SmartzChkUserExistsForUpdate(string UserName, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet SmartzChkUserPhoneNumberExistsForUpdate(string PhoneNumber, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzChkUserPhoneNumberExistsForUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SmartzUpdateCardetails(int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string DriveTrain, int CarID, string Price, string Mileage, string ExteriorColor, string InteriorColor, string Transmission,
            string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Zipcode, string City, string Description, string ConditionDescription, string InternalNotes, int TranBy, string Title)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateCardetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@InternalNotes", System.Data.DbType.String, InternalNotes);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);

                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool USP_SmartzUpdateSellerdetails(string sellerName, string address1, string city, string state, string Zip, string Phone, int CarID, int UID, int sellerID, int PackageID, string email, int isActive, string AltPhone, int TranBy, int ListingStatus, int PostingID, int UceStatus, int MultisiteStatus)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateSellerdetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, sellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, address1);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, city);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, Phone);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@ListingStatus", System.Data.DbType.Int32, ListingStatus);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UceStatus", System.Data.DbType.Int32, UceStatus);
                dbDatabase.AddInParameter(dbCommand, "@MultisiteStatus", System.Data.DbType.Int32, MultisiteStatus);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SmartzUpdateFeatures(int CarID, int FeatureID, int Isactive, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@FeatureID", System.Data.DbType.Int32, FeatureID);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, Isactive);
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

        public DataSet USP_ChkUserExists(string UserName)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet Usp_Save_RegisterLogUser(string Name, string UserName, string Pwd, string PhoneNumber, string CouponCode, string ReferCode, int PackageID,
            int StateID, string City, string Address, string Zip, string BusinessName, string AltEmail, string AltPhone)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "Usp_Save_RegisterLogUser";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, 1);
                dbDatabase.AddInParameter(dbCommand, "@CouponCode", System.Data.DbType.String, CouponCode);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Usp_SmartzSave_RegisterLogUser(string Name, string UserName, string Pwd, string PhoneNumber, string CouponCode, string ReferCode, int PackageID,
          int StateID, string City, string Address, string Zip, string BusinessName, string AltEmail, string AltPhone, int SaleAgentID, int VerifierID, int EmailExists, string UserID)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "Usp_SmartzSave_RegisterLogUser";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, 1);
                dbDatabase.AddInParameter(dbCommand, "@CouponCode", System.Data.DbType.String, CouponCode);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@VerifierID", System.Data.DbType.Int32, VerifierID);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.String, UserID);
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet USP_SmartzSaveCarDetails(int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string Price, string Mileage, string ExteriorColor,
            string Transmission, string InteriorColor, string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Zipcode, string City, int StateID,
           string DriveTrain, string Description, string ConditionDescription, string InternalNotes, string Title)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSaveCarDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@InternalNotes", System.Data.DbType.String, InternalNotes);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzSaveCarDetailsForNewForm(int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string Price, string Mileage, string ExteriorColor,
          string Transmission, string InteriorColor, string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string Zipcode, string City, int StateID,
         string DriveTrain, string Description, string ConditionDescription, string InternalNotes, string Title, int SourceOfPhotosID, int SourceOfDescriptionID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSaveCarDetailsForNewForm";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@InternalNotes", System.Data.DbType.String, InternalNotes);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfPhotosID", System.Data.DbType.Int32, SourceOfPhotosID);
                dbDatabase.AddInParameter(dbCommand, "@SourceOfDescriptionID", System.Data.DbType.Int32, SourceOfDescriptionID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SmartzSaveSellerInfo(string SellerName, string Address1, string City, string State, string Zip, string Phone, string altPhone, string Email, int CarID, int UID, int PackageID, DateTime SaleDate, int SaleEnteredBy, string Ip)
        {
            try
            {
                bool bnew = false;
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSaveSellerInfo";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, SellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, Address1);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, Phone);
                dbDatabase.AddInParameter(dbCommand, "@altPhone", System.Data.DbType.String, altPhone);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, Email);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@SaleDate", System.Data.DbType.DateTime, SaleDate);
                dbDatabase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, SaleEnteredBy);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSaveSellerInfoForNewForm(string SellerName, string Address1, string City, string State, string Zip, string Phone, string altPhone, string Email, int CarID, int UID, int PackageID, DateTime SaleDate, int SaleEnteredBy, string Ip, string SellerLastName)
        {
            try
            {
                bool bnew = false;
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSaveSellerInfoForNewForm";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, SellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, Address1);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, Phone);
                dbDatabase.AddInParameter(dbCommand, "@altPhone", System.Data.DbType.String, altPhone);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, Email);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@SaleDate", System.Data.DbType.DateTime, SaleDate);
                dbDatabase.AddInParameter(dbCommand, "@SaleEnteredBy", System.Data.DbType.Int32, SaleEnteredBy);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDatabase.AddInParameter(dbCommand, "@SellerLastName", System.Data.DbType.String, SellerLastName);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SaveCarFeatures(int CarID, int FeatureID, int Isactive)
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

        public bool USP_SmartzSavePmntDetails(int pmntType, int pmntStatus, string TransactionID, string IPAddress, int UID, int isActive, string Amount, DateTime PaymentDate, int ListingStatus, DateTime PDDate, int UserPackID, int PostingID, string VoiceRecord, int UceStatus, int MultisiteStatus)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSavePmntDetails";
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
                dbDatabase.AddInParameter(dbCommand, "@UceStatus", System.Data.DbType.Int32, UceStatus);
                dbDatabase.AddInParameter(dbCommand, "@MultisiteStatus", System.Data.DbType.Int32, MultisiteStatus);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_SmartzSavePmntDetailsForFreePackage(int UID, int isActive, int ListingStatus, int UserPackID, int PostingID, int UceStatus, int MultisiteStatus)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSavePmntDetailsForFreePackage";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@ListingStatus", System.Data.DbType.Int32, ListingStatus);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UceStatus", System.Data.DbType.Int32, UceStatus);
                dbDatabase.AddInParameter(dbCommand, "@MultisiteStatus", System.Data.DbType.Int32, MultisiteStatus);
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet SmartzSalesReport()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "SmartzSalesReport";
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

        public DataSet USP_SmartzPendingMultiSiteListing()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzPendingMultiSiteListing";
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
        public DataSet USP_SmartzPendListSearchByCarID(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzPendListSearchByCarID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@carid", System.Data.DbType.Int32, CarID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SmartzChaeckUrlExistsInMaster(string DomainUrl)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public bool USP_SmartzSaveUrlForCarID(int CarID, string URL, int SiteID, int PostedBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public bool USP_SmartzUpdateSiteUrlStatus(int UrlStatus, int URLID)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateSiteUrlStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UrlStatus", System.Data.DbType.Int32, UrlStatus);
                dbDatabase.AddInParameter(dbCommand, "@URLID", System.Data.DbType.Int32, URLID);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SmartzTicketDropDown()
        {
            try
            {
                DataSet dsSmartzdropdown = new DataSet();
                string spNameString = string.Empty;
                Database dbdatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzTicketDropDown";
                DbCommand dbcommand = null;
                dbcommand = dbdatabase.GetStoredProcCommand(spNameString);
                dsSmartzdropdown = dbdatabase.ExecuteDataSet(dbcommand);
                return dsSmartzdropdown;
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public bool USP_SmartzSaveCSDetails(int CarID, int CallAgentID, int CallType, int CallReason, string Notes, int CSResolution, string SpokeWith)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_SmartzRefundsReport()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzRefundsReport";
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

        public DataSet USP_SmartzWelcomeCallSearch(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_SmartzTicketSearch(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_SmartzGetDataByTicketID(int TicketID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public bool USP_SmartzUpdateTicketDetails(int TicketID, DateTime CallBackDate, int TicketStatus, int AssignedTo, int SolvedBy, DateTime SolvedDate, string TicketComments)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_SmartzGetAgentReport(int AgentID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetAgentReport";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@AgentID", System.Data.DbType.Int32, AgentID);
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
        public DataSet USP_GetUSerDetailsByUserID(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_UpdateRegUserDetails(UserRegistrationInfo objUserregisInfo)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_UpdateRegUserDetails";
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


                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_ChkPackageForAddCar(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkPackageForAddCar";
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

        public DataSet USP_AddPackageForMultiCars(int UID, int PackageID, int pmntType, string IPAddress, DateTime PaymentDate, string TransactionID, string Amount, string VoiceRecord)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_AddPackageForMultiCars";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetDataByUserPackID(int UserPackID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetDataByUserPackID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool USP_SmartzSavePayForMultiCars(int PaymentID, int isActive, DateTime PaymentDate, int ListingStatus, int UserPackID, int PostingID)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSavePayForMultiCars";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
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

        public DataSet USP_SmartzUpdateRegUserDetailsForMultiCar(UserRegistrationInfo objUserregisInfo, int TranBy)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_SmartzUpdateRegUserDetailsForMultiCar";
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
        public DataSet USP_SmartzGetSalesAgentReport(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetSalesAgentReport";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
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
        public DataSet USP_SmartzGetAgentSalesBetweenDate(int Sale_Agent_Id, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetAgentSalesBetweenDate";
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


        public DataSet SmartzSearchForRecentUpdates(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchForRecentUpdates";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

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
        public DataSet USP_SmartzSalesBySourceReport()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSalesBySourceReport";
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

        public DataSet USP_GetPackageDetailsByUserPackID(int UserPackID)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_SmartzGetSalesAgentReportFullReport(int Isactive, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetSalesAgentReportFullReport";
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

        public DataSet USP_SmartzGetCustmerServiceData()
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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



        public DataSet USP_SmartzGetCSDataByCSCallID(int CallID)
        {
            try
            {
                DataSet dsCSData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet USP_GetTransactionDetailsForCustomer(int CarID, int PostingID, int SellerID, int pmntID)
        {
            try
            {
                DataSet dsCSData = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet SmartzSearchNewByUserDetails(string phone, string Name, string email, int AgentName)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchNewByUserDetails";
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

        public DataSet SmartzSearchNewByUserDetailsForDealer(string phone, string Name, string email, int CustomerType, int BrandType)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchNewByUserDetailsForDealer";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@CustomerType", System.Data.DbType.Int32, CustomerType);
                dbDatabase.AddInParameter(dbCommand, "@BrandType", System.Data.DbType.Int32, BrandType);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSearchNewByCarDetails(int makeID, int makeModelID, string yearOfMake)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchNewByCarDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
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

        public DataSet SmartzCheckCarIDExistsForMultiSiteUploads(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet UpdateCarStatusForPDPaid(int PostingID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateCarStatusForPDPaid";
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

        public DataSet SmartzCheckZipExists(string Zip)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet GetPDPaymentData(int TypeID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPDPaymentData";
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
        public DataSet GetPDPaymentDataInformation(int TypeID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPDPaymentDataInformation";
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
        public DataSet GETNewSalesAgentReport(int Isactive, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GETNewSalesAgentReport";
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

        public DataSet SmartzGetCarsAllPackages()
        {
            try
            {
                DataSet dsPackages = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetCarsAllPackages";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsPackages = dbDatabase.ExecuteDataSet(dbCommand);
                return dsPackages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzGetSalesDataForCars()
        {
            try
            {
                DataSet dsCarsSales = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetSalesDataForCars";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsCarsSales = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCarsSales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet SmartzUpdatePDDate(int TranBy, DateTime PDDate, int UserPackID, int PostingID)
        {
            try
            {
                DataSet dsAgents = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdatePDDate";
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

        public DataSet Smartz30DaysReviewCallSearch(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_Smartz30DaysReviewCallSearch";
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
        public DataSet Smartz60DaysReviewCallSearchCars(int SelMode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_Smartz60DaysReviewCallSearchCars";
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

        public DataSet GetMasterSourceOfDescription()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetMasterSourceOfDescription";
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

        public DataSet GetMasterSourceOfPhotos()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetMasterSourceOfPhotos";
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

        public DataSet SmartzSearchForFreePackages()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchForFreePackages";
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

        public DataSet FillCBDropdown()
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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

        public DataSet GetPicIDsByCarID(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPicIDsByCarID";
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

        public DataSet GetDatetime()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetDatetime";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatePicturesByIdForSmartz(CarsInfo.CarsInfo objCarsInfo, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePicturesByIdForSmartz";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@pic1", System.Data.DbType.String, objCarsInfo.Pic1);
                dbDatabase.AddInParameter(dbCommand, "@pic2", System.Data.DbType.String, objCarsInfo.Pic2);
                dbDatabase.AddInParameter(dbCommand, "@pic3", System.Data.DbType.String, objCarsInfo.Pic3);
                dbDatabase.AddInParameter(dbCommand, "@pic4", System.Data.DbType.String, objCarsInfo.Pic4);
                dbDatabase.AddInParameter(dbCommand, "@pic5", System.Data.DbType.String, objCarsInfo.Pic5);
                dbDatabase.AddInParameter(dbCommand, "@pic6", System.Data.DbType.String, objCarsInfo.Pic6);
                dbDatabase.AddInParameter(dbCommand, "@pic7", System.Data.DbType.String, objCarsInfo.Pic7);
                dbDatabase.AddInParameter(dbCommand, "@pic8", System.Data.DbType.String, objCarsInfo.Pic8);
                dbDatabase.AddInParameter(dbCommand, "@pic9", System.Data.DbType.String, objCarsInfo.Pic9);
                dbDatabase.AddInParameter(dbCommand, "@pic10", System.Data.DbType.String, objCarsInfo.Pic10);
                dbDatabase.AddInParameter(dbCommand, "@Pic11", System.Data.DbType.String, objCarsInfo.Pic11);
                dbDatabase.AddInParameter(dbCommand, "@pic12", System.Data.DbType.String, objCarsInfo.Pic12);
                dbDatabase.AddInParameter(dbCommand, "@pic13", System.Data.DbType.String, objCarsInfo.Pic13);
                dbDatabase.AddInParameter(dbCommand, "@pic14", System.Data.DbType.String, objCarsInfo.Pic14);
                dbDatabase.AddInParameter(dbCommand, "@pic15", System.Data.DbType.String, objCarsInfo.Pic15);
                dbDatabase.AddInParameter(dbCommand, "@pic16", System.Data.DbType.String, objCarsInfo.Pic16);
                dbDatabase.AddInParameter(dbCommand, "@pic17", System.Data.DbType.String, objCarsInfo.Pic17);
                dbDatabase.AddInParameter(dbCommand, "@pic18", System.Data.DbType.String, objCarsInfo.Pic18);
                dbDatabase.AddInParameter(dbCommand, "@pic19", System.Data.DbType.String, objCarsInfo.Pic19);
                dbDatabase.AddInParameter(dbCommand, "@pic20", System.Data.DbType.String, objCarsInfo.Pic20);
                dbDatabase.AddInParameter(dbCommand, "@Pic0", System.Data.DbType.String, objCarsInfo.Pic0);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.CarID);
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
        public DataSet ChkUserExistsPhoneNumber(string PhoneNumber)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkUserExistsPhoneNumber";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserExistsDealerCode(string DealerCode)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkUserExistsDealerCode";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet ChkUserExistsUserID(string UserID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkUserExistsUserID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.String, UserID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveCreditCardData(int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PaymentID1, int pmntType,
            int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, string cardNumber, string cardType, string cardExpDt, string cardholderName,
        string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity, string billingState, int PostingID, int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCreditCardData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID1", System.Data.DbType.Int32, PaymentID1);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveCreditCardInfoForDealerPaid(DateTime PaymentDate, string Amount, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation,
            string cardNumber, string cardType, string cardExpDt, string cardholderName, string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity,
            string billingState, int UserPackID, int UID, string TransactionID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCreditCardInfoForDealerPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateCreditCardInfoForDealerPaid(DateTime PaymentDate, string Amount, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation,
          string cardNumber, string cardType, string cardExpDt, string cardholderName, string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity,
          string billingState, int UserPackID, int UID, string TransactionID, int PaymentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateCreditCardInfoForDealerPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCreditCardDataForPDSale(int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, DateTime PDScheduleDate, string PDAmount, int PaymentID1,
        int PaymentID2, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, string cardNumber, string cardType, string cardExpDt, string cardholderName,
        string cardholderLastName, string cardCode, string BillingZip, string billingAdd, string billingCity, string billingState, int PostingID, int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCreditCardDataForPDSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PDScheduleDate", System.Data.DbType.DateTime, PDScheduleDate);
                dbDatabase.AddInParameter(dbCommand, "@PDAmount", System.Data.DbType.String, PDAmount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID1", System.Data.DbType.Int32, PaymentID1);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID2", System.Data.DbType.Int32, PaymentID2);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@cardNumber", System.Data.DbType.String, cardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", System.Data.DbType.String, cardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", System.Data.DbType.String, cardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", System.Data.DbType.String, cardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardholderLastName", System.Data.DbType.String, cardholderLastName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", System.Data.DbType.String, cardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", System.Data.DbType.String, BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", System.Data.DbType.String, billingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", System.Data.DbType.String, billingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", System.Data.DbType.String, billingState);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePayPalData(int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PaymentID,
        int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, string TransactionID, string PaypalEmail,
            int PostingID, int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePayPalData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaypalEmail", System.Data.DbType.String, PaypalEmail);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet SavePayPalDataForDealerPaid(DateTime PaymentDate, string Amount, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, string TransactionID, string PaypalEmail,
            int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePayPalDataForDealerPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaypalEmail", System.Data.DbType.String, PaypalEmail);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdatePayPalDataForDealerPaid(DateTime PaymentDate, string Amount, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, string TransactionID, string PaypalEmail,
        int UserPackID, int UID, int PaymentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePayPalDataForDealerPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PaypalEmail", System.Data.DbType.String, PaypalEmail);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCheckData(int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, int PaymentID1, int pmntType, int pmntStatus, string IPAddress,
            string VoiceRecord, int VoiceFileLocation, int bankAccountType, string bankRouting, string bankName,
          string bankAccountNumber, string bankAccountHolderName, int PostingID, int CheckTypeID, string BankCheckNumber, int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCheckData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);

                dbDatabase.AddInParameter(dbCommand, "@PaymentID1", System.Data.DbType.Int32, PaymentID1);

                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCheckDataFordealerPaid(DateTime PaymentDate, string Amount, int pmntType, int pmntStatus, string IPAddress,
          string VoiceRecord, int VoiceFileLocation, int bankAccountType, string bankRouting, string bankName,
        string bankAccountNumber, string bankAccountHolderName, int CheckTypeID, string BankCheckNumber, string TransactionID, int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCheckDataFordealerPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);

                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet UpdateCheckDataFordealerPaid(DateTime PaymentDate, string Amount, int pmntType, int pmntStatus, string IPAddress,
         string VoiceRecord, int VoiceFileLocation, int bankAccountType, string bankRouting, string bankName,
         string bankAccountNumber, string bankAccountHolderName, int CheckTypeID, string BankCheckNumber, string TransactionID, int UserPackID, int UID, int PaymentID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateCheckDataFordealerPaid";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);

                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCheckDataForPDSale(int PackageID, int CarID, DateTime PaymentScheduledDate, string Amount, DateTime PDScheduleDate, string PDAmount, int PaymentID1,
            int PaymentID2, int pmntType, int pmntStatus, string IPAddress, string VoiceRecord, int VoiceFileLocation, int bankAccountType, string bankRouting, string bankName,
          string bankAccountNumber, string bankAccountHolderName, int PostingID, int CheckTypeID, string BankCheckNumber, int UserPackID, int UID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCheckDataForPDSale";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentScheduledDate", System.Data.DbType.DateTime, PaymentScheduledDate);
                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PDScheduleDate", System.Data.DbType.DateTime, PDScheduleDate);
                dbDatabase.AddInParameter(dbCommand, "@PDAmount", System.Data.DbType.String, PDAmount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID1", System.Data.DbType.Int32, PaymentID1);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID2", System.Data.DbType.Int32, PaymentID2);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", System.Data.DbType.Int32, pmntType);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@VoiceRecord", System.Data.DbType.String, VoiceRecord);
                dbDatabase.AddInParameter(dbCommand, "@VoiceFileLocation", System.Data.DbType.Int32, VoiceFileLocation);

                dbDatabase.AddInParameter(dbCommand, "@bankAccountType", System.Data.DbType.Int32, bankAccountType);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", System.Data.DbType.String, bankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", System.Data.DbType.String, bankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", System.Data.DbType.String, bankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountHolderName", System.Data.DbType.String, bankAccountHolderName);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@BankCheckNumber", System.Data.DbType.String, BankCheckNumber);
                dbDatabase.AddInParameter(dbCommand, "@CheckTypeID", System.Data.DbType.Int32, CheckTypeID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SavePaymentInfoForNewSaleProcess(string Amount, int PaymentID, int pmntStatus, string TransactionID, int PostingID,
            int CarId, string PaymentNotes, int isActive, int AdStatus, int UceStatus, int MultisiteStatus)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePaymentInfoForNewSaleProcess";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.Int32, CarId);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@AdStatus", System.Data.DbType.Int32, AdStatus);
                dbDatabase.AddInParameter(dbCommand, "@UceStatus", System.Data.DbType.Int32, UceStatus);
                dbDatabase.AddInParameter(dbCommand, "@MultisiteStatus", System.Data.DbType.Int32, MultisiteStatus);


                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePaymentInfoForPayPopUpdate(string Amount, int PaymentID, int pmntStatus, string TransactionID, int PostingID,
            int CarId, string PaymentNotes, int isActive, int AdStatus, int UceStatus, int MultisiteStatus, DateTime PaymentDate)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePaymentInfoForPayPopUpdate";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@CarId", System.Data.DbType.Int32, CarId);
                dbDatabase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@AdStatus", System.Data.DbType.Int32, AdStatus);
                dbDatabase.AddInParameter(dbCommand, "@UceStatus", System.Data.DbType.Int32, UceStatus);
                dbDatabase.AddInParameter(dbCommand, "@MultisiteStatus", System.Data.DbType.Int32, MultisiteStatus);
                dbDatabase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);


                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCustomerDetailsByPostingIDForNewView(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCustomerDetailsByPostingIDForNewView";
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

        public DataSet GetPaymentInfoByPostingID(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPaymentInfoByPostingID";
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
        public DataSet UpdatePDPaymentStatus(int PostingID, int pmntID, int PDID, int pmntStatus, string TransactionID,
                                    DateTime PDDate, string Amount)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePDPaymentStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDataBase.AddInParameter(dbCommand, "@pmntID", System.Data.DbType.Int32, pmntID);
                dbDataBase.AddInParameter(dbCommand, "@PDID", System.Data.DbType.Int32, PDID);
                dbDataBase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@PDDate", System.Data.DbType.DateTime, PDDate);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetUCEUserLogByUID(int UCEUID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetUCEUserLogByUID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UCEUID", System.Data.DbType.Int32, UCEUID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SmartzUpdateRegUserDetailsForNewForm(int UId, string Name, string PhoneNumber, string City, int StateID, string Address, string Zip, string UserName, string Pwd, int TranBy, string AltPhone)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateRegUserDetailsForNewForm";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool SmartzUpdateStatusDetailsForNewForm(int PostingID, int TranBy, int isActive, int AdStatus, int UceStatus, int MultisiteStatus)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateStatusDetailsForNewForm";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, isActive);
                dbDatabase.AddInParameter(dbCommand, "@AdStatus", System.Data.DbType.Int32, AdStatus);
                dbDatabase.AddInParameter(dbCommand, "@UceStatus", System.Data.DbType.Int32, UceStatus);
                dbDatabase.AddInParameter(dbCommand, "@MultisiteStatus", System.Data.DbType.Int32, MultisiteStatus);

                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SmartzUpdateSellerDetailsForNewForm(string city, string state, string Zip, string Phone, int sellerID, string email, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateSellerDetailsForNewForm";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, city);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, Phone);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
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

        public bool SmartzUpdateCardetailsForNewForm(int YearOfMake, int MakeModelID, int BodyTypeID, int VehicleConditionID, string DriveTrain, int CarID, string Price, string Mileage, string ExteriorColor, string InteriorColor, string Transmission,
                 string NumberOfDoors, string VIN, string NumberOfCylinder, int FuelTypeID, string ConditionDescription, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateCardetailsForNewForm";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
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


        public DataSet USP_SaveDealerRegData(string Name, string UserName, string Pwd, string PhoneNumber, int PackageID, int StateID, string City, string Address, string Zip, string BusinessName, string AltEmail, string AltPhone, int SaleAgentID, int VerifierID,
            int EmailExists, string UserID, string DealerCode, DateTime Saledate, string SellerName, string SellerPhNum, string SellerAltNum, string SellerEmail, string SellerAltEmail, string SellerAddress,
            string SellerCity, string SellerState, string SellerZip, string SellerBusinessName, string SpecialNotes, string UserNotes)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_SaveDealerRegData";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@VerifierID", System.Data.DbType.Int32, VerifierID);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.String, UserID);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@Saledate", System.Data.DbType.DateTime, Saledate);
                dbDatabase.AddInParameter(dbCommand, "@SellerName", System.Data.DbType.String, SellerName);
                dbDatabase.AddInParameter(dbCommand, "@SellerPhNum", System.Data.DbType.String, SellerPhNum);
                dbDatabase.AddInParameter(dbCommand, "@SellerAltNum", System.Data.DbType.String, SellerAltNum);
                dbDatabase.AddInParameter(dbCommand, "@SellerEmail", System.Data.DbType.String, SellerEmail);
                dbDatabase.AddInParameter(dbCommand, "@SellerAltEmail", System.Data.DbType.String, SellerAltEmail);
                dbDatabase.AddInParameter(dbCommand, "@SellerAddress", System.Data.DbType.String, SellerAddress);
                dbDatabase.AddInParameter(dbCommand, "@SellerCity", System.Data.DbType.String, SellerCity);
                dbDatabase.AddInParameter(dbCommand, "@SellerState", System.Data.DbType.String, SellerState);
                dbDatabase.AddInParameter(dbCommand, "@SellerZip", System.Data.DbType.String, SellerZip);
                dbDatabase.AddInParameter(dbCommand, "@SellerBusinessName", System.Data.DbType.String, SellerBusinessName);
                dbDatabase.AddInParameter(dbCommand, "@SpecialNotes", System.Data.DbType.String, SpecialNotes);
                dbDatabase.AddInParameter(dbCommand, "@UserNotes", System.Data.DbType.String, UserNotes);

                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet UpdateDealerRegData(string Name, string UserName, string Pwd, string PhoneNumber, int PackageID, int StateID, string City, string Address, string Zip, string BusinessName, string AltEmail, string AltPhone, int SaleAgentID, int VerifierID,
            int EmailExists, DateTime Saledate, string SellerName, string SellerPhNum, string SellerAltNum, string SellerEmail, string SellerAltEmail, string SellerAddress, string SellerCity, string SellerState, string SellerZip, int UId, int UserPackID, int sellerID,
            string SellerBusinessName, string SpecialNotes, string UserNotes)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_UpdateDealerRegData";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@SaleAgentID", System.Data.DbType.Int32, SaleAgentID);
                dbDatabase.AddInParameter(dbCommand, "@VerifierID", System.Data.DbType.Int32, VerifierID);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);
                dbDatabase.AddInParameter(dbCommand, "@Saledate", System.Data.DbType.DateTime, Saledate);
                dbDatabase.AddInParameter(dbCommand, "@SellerName", System.Data.DbType.String, SellerName);
                dbDatabase.AddInParameter(dbCommand, "@SellerPhNum", System.Data.DbType.String, SellerPhNum);
                dbDatabase.AddInParameter(dbCommand, "@SellerAltNum", System.Data.DbType.String, SellerAltNum);
                dbDatabase.AddInParameter(dbCommand, "@SellerEmail", System.Data.DbType.String, SellerEmail);
                dbDatabase.AddInParameter(dbCommand, "@SellerAltEmail", System.Data.DbType.String, SellerAltEmail);
                dbDatabase.AddInParameter(dbCommand, "@SellerAddress", System.Data.DbType.String, SellerAddress);
                dbDatabase.AddInParameter(dbCommand, "@SellerCity", System.Data.DbType.String, SellerCity);
                dbDatabase.AddInParameter(dbCommand, "@SellerState", System.Data.DbType.String, SellerState);
                dbDatabase.AddInParameter(dbCommand, "@SellerZip", System.Data.DbType.String, SellerZip);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, sellerID);
                dbDatabase.AddInParameter(dbCommand, "@SellerBusinessName", System.Data.DbType.String, SellerBusinessName);
                dbDatabase.AddInParameter(dbCommand, "@SpecialNotes", System.Data.DbType.String, SpecialNotes);
                dbDatabase.AddInParameter(dbCommand, "@UserNotes", System.Data.DbType.String, UserNotes);

                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet GetDealerDataAfterRegister(Int64 UId, Int64 SellerID, Int64 UserPackID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetDealerDataAfterRegister";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int64, UId);
                dbDataBase.AddInParameter(dbCommand, "@SellerID", System.Data.DbType.Int64, SellerID);
                dbDataBase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int64, UserPackID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdatePaymentDetailsForDealerRegister(DateTime PaymentDate, string Amount, int pmntStatus, string IPAddress, string TransactionID,
            int UserPackID, int UID, int PaymentID, string PaymentNotes)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePaymentDetailsForDealerRegister";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PaymentDate", System.Data.DbType.DateTime, PaymentDate);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@pmntStatus", System.Data.DbType.Int32, pmntStatus);
                dbDataBase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDataBase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDataBase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDataBase.AddInParameter(dbCommand, "@PaymentNotes", System.Data.DbType.String, PaymentNotes);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SavePaymentHistoryData(int PaymentID, int PayTryBy, string CardType, string CardNumber, string Address, string City,
            string State, string Zip, string Amount, string Result, string TransactionID, string CCExpiryDate, string Cvv, string CCFirstName, string CCLastName)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePaymentHistoryData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDataBase.AddInParameter(dbCommand, "@PayTryBy", System.Data.DbType.Int32, PayTryBy);
                dbDataBase.AddInParameter(dbCommand, "@CardType", System.Data.DbType.String, CardType);
                dbDataBase.AddInParameter(dbCommand, "@CardNumber", System.Data.DbType.String, CardNumber);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@CCExpiryDate", System.Data.DbType.String, CCExpiryDate);
                dbDataBase.AddInParameter(dbCommand, "@Cvv", System.Data.DbType.String, Cvv);
                dbDataBase.AddInParameter(dbCommand, "@CCFirstName", System.Data.DbType.String, CCFirstName);
                dbDataBase.AddInParameter(dbCommand, "@CCLastName", System.Data.DbType.String, CCLastName);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SavePaymentHistoryDataForChecks(int PaymentID, int PayTryBy, string CardType, string Address, string City,
     string State, string Zip, string Amount, string Result, string TransactionID, string AccountHolderName, string AccountNumber,
     string BankName, string RoutingNumber, string AccountType)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePaymentHistoryDataForChecks";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDataBase.AddInParameter(dbCommand, "@PayTryBy", System.Data.DbType.Int32, PayTryBy);
                dbDataBase.AddInParameter(dbCommand, "@CardType", System.Data.DbType.String, CardType);
                dbDataBase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, Address);
                dbDataBase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, City);
                dbDataBase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, State);
                dbDataBase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, Zip);
                dbDataBase.AddInParameter(dbCommand, "@Amount", System.Data.DbType.String, Amount);
                dbDataBase.AddInParameter(dbCommand, "@Result", System.Data.DbType.String, Result);
                dbDataBase.AddInParameter(dbCommand, "@TransactionID", System.Data.DbType.String, TransactionID);
                dbDataBase.AddInParameter(dbCommand, "@AccountHolderName", System.Data.DbType.String, AccountHolderName);
                dbDataBase.AddInParameter(dbCommand, "@AccountNumber", System.Data.DbType.String, AccountNumber);
                dbDataBase.AddInParameter(dbCommand, "@BankName", System.Data.DbType.String, BankName);
                dbDataBase.AddInParameter(dbCommand, "@RoutingNumber", System.Data.DbType.String, RoutingNumber);
                dbDataBase.AddInParameter(dbCommand, "@AccountType", System.Data.DbType.String, AccountType);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSearchForChargeBackUSer(string phone, string Name, int CarID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchForChargeBackUSer";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDataBase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int64, CarID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetChargeBackProcessor()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetChargeBackProcessor";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSaveUserCBData(int UID, DateTime CustomerContactdate, int CBEnteredBy, DateTime ResponseDate, int ResponsedBy,
            DateTime ChargeBackDate, int ProcessorID, string ReasonCode, string ReasonCodeDescription, string CBAmount, string Notes)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSaveUserCBData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDataBase.AddInParameter(dbCommand, "@CustomerContactdate", System.Data.DbType.DateTime, CustomerContactdate);
                dbDataBase.AddInParameter(dbCommand, "@CBEnteredBy", System.Data.DbType.Int32, CBEnteredBy);
                dbDataBase.AddInParameter(dbCommand, "@ResponseDate", System.Data.DbType.DateTime, ResponseDate);
                dbDataBase.AddInParameter(dbCommand, "@ResponsedBy", System.Data.DbType.Int32, ResponsedBy);
                dbDataBase.AddInParameter(dbCommand, "@ChargeBackDate", System.Data.DbType.DateTime, ChargeBackDate);
                dbDataBase.AddInParameter(dbCommand, "@ProcessorID", System.Data.DbType.Int32, ProcessorID);
                dbDataBase.AddInParameter(dbCommand, "@ReasonCode", System.Data.DbType.String, ReasonCode);
                dbDataBase.AddInParameter(dbCommand, "@ReasonCodeDescription", System.Data.DbType.String, ReasonCodeDescription);
                dbDataBase.AddInParameter(dbCommand, "@CBAmount", System.Data.DbType.String, CBAmount);
                dbDataBase.AddInParameter(dbCommand, "@Notes", System.Data.DbType.String, Notes);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzGetMasterChargeBackStatus()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetMasterChargeBackStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzGetChargebackData(int ChargeBackStatus)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetChargebackData";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@ChargeBackStatus", System.Data.DbType.Int32, ChargeBackStatus);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SmartzSearchForChargeBackUSerByCCOrCarID(int CarID, string CCNumber)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchForChargeBackUSerByCCOrCarID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDataBase.AddInParameter(dbCommand, "@CCNumber", System.Data.DbType.String, CCNumber);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetNoticeTypes()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetNoticeTypes";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetReplyMethods()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetReplyMethods";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzSearchForCBForPreviousNotice(int PreviousNoticeID, string CaseNumber)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzSearchForCBForPreviousNotice";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@CaseNumber", System.Data.DbType.String, CaseNumber);
                dbDataBase.AddInParameter(dbCommand, "@PreviousNoticeID", System.Data.DbType.Int32, PreviousNoticeID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveChargeBackNotice(int NoticeTypeID, DateTime NoticeDate, DateTime ReceivedDate, string CaseNumber, string DisputeAmount, DateTime ReplyByDt, int NoticeStatusID, string Notes,
            int CustID, int ReplyMethodID, string ReplyFaxNumber, string ReplyEmail, string ReplyAddress, string ReplyCity, int ReplyStateID, string ReplyZip, int PrevNoticeID, int EnteredBy)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveChargeBackNotice";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeTypeID", System.Data.DbType.Int32, NoticeTypeID);
                dbDataBase.AddInParameter(dbCommand, "@NoticeDate", System.Data.DbType.DateTime, NoticeDate);
                dbDataBase.AddInParameter(dbCommand, "@ReceivedDate", System.Data.DbType.DateTime, ReceivedDate);
                dbDataBase.AddInParameter(dbCommand, "@CaseNumber", System.Data.DbType.String, CaseNumber);
                dbDataBase.AddInParameter(dbCommand, "@DisputeAmount", System.Data.DbType.String, DisputeAmount);
                dbDataBase.AddInParameter(dbCommand, "@ReplyByDt", System.Data.DbType.DateTime, ReplyByDt);
                dbDataBase.AddInParameter(dbCommand, "@NoticeStatusID", System.Data.DbType.Int32, NoticeStatusID);
                dbDataBase.AddInParameter(dbCommand, "@Notes", System.Data.DbType.String, Notes);
                dbDataBase.AddInParameter(dbCommand, "@CustID", System.Data.DbType.Int32, CustID);
                dbDataBase.AddInParameter(dbCommand, "@ReplyMethodID", System.Data.DbType.Int32, ReplyMethodID);
                dbDataBase.AddInParameter(dbCommand, "@ReplyFaxNumber", System.Data.DbType.String, ReplyFaxNumber);
                dbDataBase.AddInParameter(dbCommand, "@ReplyEmail", System.Data.DbType.String, ReplyEmail);
                dbDataBase.AddInParameter(dbCommand, "@ReplyAddress", System.Data.DbType.String, ReplyAddress);
                dbDataBase.AddInParameter(dbCommand, "@ReplyCity", System.Data.DbType.String, ReplyCity);
                dbDataBase.AddInParameter(dbCommand, "@ReplyStateID", System.Data.DbType.Int32, ReplyStateID);
                dbDataBase.AddInParameter(dbCommand, "@ReplyZip", System.Data.DbType.String, ReplyZip);
                dbDataBase.AddInParameter(dbCommand, "@PrevNoticeID", System.Data.DbType.Int32, PrevNoticeID);
                dbDataBase.AddInParameter(dbCommand, "@EnteredBy", System.Data.DbType.Int32, EnteredBy);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet UpdateChargeBackNotice(int NoticeID, int NoticeTypeID, DateTime NoticeDate, DateTime ReceivedDate, string CaseNumber, string DisputeAmount, DateTime ReplyByDt, int NoticeStatusID, string Notes,
           int CustID, int ReplyMethodID, string ReplyFaxNumber, string ReplyEmail, string ReplyAddress, string ReplyCity, int ReplyStateID, string ReplyZip, int PrevNoticeID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateChargeBackNotice";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeTypeID", System.Data.DbType.Int32, NoticeTypeID);
                dbDataBase.AddInParameter(dbCommand, "@NoticeDate", System.Data.DbType.DateTime, NoticeDate);
                dbDataBase.AddInParameter(dbCommand, "@ReceivedDate", System.Data.DbType.DateTime, ReceivedDate);
                dbDataBase.AddInParameter(dbCommand, "@CaseNumber", System.Data.DbType.String, CaseNumber);
                dbDataBase.AddInParameter(dbCommand, "@DisputeAmount", System.Data.DbType.String, DisputeAmount);
                dbDataBase.AddInParameter(dbCommand, "@ReplyByDt", System.Data.DbType.DateTime, ReplyByDt);
                dbDataBase.AddInParameter(dbCommand, "@NoticeStatusID", System.Data.DbType.Int32, NoticeStatusID);
                dbDataBase.AddInParameter(dbCommand, "@Notes", System.Data.DbType.String, Notes);
                dbDataBase.AddInParameter(dbCommand, "@CustID", System.Data.DbType.Int32, CustID);
                dbDataBase.AddInParameter(dbCommand, "@ReplyMethodID", System.Data.DbType.Int32, ReplyMethodID);
                dbDataBase.AddInParameter(dbCommand, "@ReplyFaxNumber", System.Data.DbType.String, ReplyFaxNumber);
                dbDataBase.AddInParameter(dbCommand, "@ReplyEmail", System.Data.DbType.String, ReplyEmail);
                dbDataBase.AddInParameter(dbCommand, "@ReplyAddress", System.Data.DbType.String, ReplyAddress);
                dbDataBase.AddInParameter(dbCommand, "@ReplyCity", System.Data.DbType.String, ReplyCity);
                dbDataBase.AddInParameter(dbCommand, "@ReplyStateID", System.Data.DbType.Int32, ReplyStateID);
                dbDataBase.AddInParameter(dbCommand, "@ReplyZip", System.Data.DbType.String, ReplyZip);
                dbDataBase.AddInParameter(dbCommand, "@PrevNoticeID", System.Data.DbType.Int32, PrevNoticeID);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCBDocumnets(int NoticeID, int FileTypeID, string FilePath, int SavedBy, int DocumentTypeID, int isEditable)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCBDocumnets";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dbDataBase.AddInParameter(dbCommand, "@FileTypeID", System.Data.DbType.Int32, FileTypeID);
                dbDataBase.AddInParameter(dbCommand, "@FilePath", System.Data.DbType.String, FilePath);
                dbDataBase.AddInParameter(dbCommand, "@SavedBy", System.Data.DbType.Int32, SavedBy);
                dbDataBase.AddInParameter(dbCommand, "@DocumentTypeID", System.Data.DbType.Int32, DocumentTypeID);
                dbDataBase.AddInParameter(dbCommand, "@isEditable", System.Data.DbType.Int32, isEditable);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateCBDocumnets(int DocumentID, string FilePath, int SavedBy)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateCBDocumnets";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@DocumentID", System.Data.DbType.Int32, DocumentID);
                dbDataBase.AddInParameter(dbCommand, "@FilePath", System.Data.DbType.String, FilePath);
                dbDataBase.AddInParameter(dbCommand, "@SavedBy", System.Data.DbType.Int32, SavedBy);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SaveCBNoticeReasons(int NoticeID, int NoticeReasonID, int IsActive)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCBNoticeReasons";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dbDataBase.AddInParameter(dbCommand, "@NoticeReasonID", System.Data.DbType.Int32, NoticeReasonID);
                dbDataBase.AddInParameter(dbCommand, "@IsActive", System.Data.DbType.Int32, IsActive);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DeleteExistReason(int NoticeID, int NoticeReasonID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_DeleteExistReason";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dbDataBase.AddInParameter(dbCommand, "@NoticeReasonID", System.Data.DbType.Int32, NoticeReasonID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzGetMasterCBNoticeStatus()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzGetMasterCBNoticeStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetNoticeDetailsByStatus(int NoticeStatusID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetNoticeDetailsByStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeStatusID", System.Data.DbType.Int32, NoticeStatusID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetNoticeDetailsByNoticeIDForEdit(int NoticeID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetNoticeDetailsByNoticeIDForEdit";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCBNoticeUserByUID(int UId)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCBNoticeUserByUID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, UId);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPackageDetailsByUID(int UID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPackageDetailsByUID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSmartzNoticeStatus()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetSmartzNoticeStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SmartzUpdateCBNoticeStatus(int NoticeID, int NoticeStatusID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SmartzUpdateCBNoticeStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dbDataBase.AddInParameter(dbCommand, "@NoticeStatusID", System.Data.DbType.Int32, NoticeStatusID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPackageDetailsByUIDForAuthLetter(int UID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPackageDetailsByUIDForAuthLetter";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SaveCBDocumnetsForProcess(int NoticeID, int FileTypeID, string FilePath, int SavedBy, int DocumentTypeID, int isEditable)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCBDocumnetsForProcess";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dbDataBase.AddInParameter(dbCommand, "@FileTypeID", System.Data.DbType.Int32, FileTypeID);
                dbDataBase.AddInParameter(dbCommand, "@FilePath", System.Data.DbType.String, FilePath);
                dbDataBase.AddInParameter(dbCommand, "@SavedBy", System.Data.DbType.Int32, SavedBy);
                dbDataBase.AddInParameter(dbCommand, "@DocumentTypeID", System.Data.DbType.Int32, DocumentTypeID);
                dbDataBase.AddInParameter(dbCommand, "@isEditable", System.Data.DbType.Int32, isEditable);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetNoticeDocumentsByNoticeID(int NoticeID, int DocumentTypeID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetNoticeDocumentsByNoticeID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@NoticeID", System.Data.DbType.Int32, NoticeID);
                dbDataBase.AddInParameter(dbCommand, "@DocumentTypeID", System.Data.DbType.Int32, DocumentTypeID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetWelcomeMailInfoByID(int TempWelID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetWelcomeMailInfoByID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@TempWelID", System.Data.DbType.Int32, TempWelID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //********************GetSalesSearchBycustomer(sobha)*********

        public DataSet SmartzSearchNewBySalesDetailsForDealer(string phone, string Name, string email, int CustomerType)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.TESTDB);
                spNameString = "[USP_GetCarsalesSearchToSmartz]";
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

        //********************GetSalesSearchByCarId(sobha)*********

        public DataSet SmartzSearchNewBySalesDetailsForVehicle(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.TESTDB);
                spNameString = "[USP_GetCarSalesSearchByCarIDToSmartz]";
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


        //********************GetSalesSearchByVehicleDetails(sobha)*********

        public DataSet SmartzSearchNewBySalesDetailsByVehicle(int makeID, int makeModelID, string yearOfMake)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.TESTDB);
                spNameString = "USP_GetCarsalesSearchByCarDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makeID", System.Data.DbType.Int32, makeID);
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


        //********************GetAllBrands(sobha) 05/24/2014*********

        public DataSet GetAllBrands()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetBrandNames";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}



