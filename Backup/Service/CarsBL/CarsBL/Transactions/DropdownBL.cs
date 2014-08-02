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

        public DataSet USP_SaveVehicleType(CarsInfo.CarsInfo objCarsInfo)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveVehicleType";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, objCarsInfo.BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.CarID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SaveVehicleInformation(CarsInfo.CarsInfo objCarsInfo)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveVehicleInformation";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.CarID);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, objCarsInfo.NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objCarsInfo.FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, objCarsInfo.Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objCarsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objCarsInfo.StateID);

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
        public bool USP_SaveCarFeaturesConditions(int CarID, string Description, string ConditionDescription)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCarFeaturesConditions";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SaveCarDetails(CarsInfo.CarsInfo objCarsInfo, string Description, string ConditionDescription, string Title)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCarDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, objCarsInfo.BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.CarID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, objCarsInfo.NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objCarsInfo.FuelTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, objCarsInfo.Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objCarsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objCarsInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, objCarsInfo.DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SaveSellerInfo(UsedCarsInfo objUsedCarsInfo, int CarID, int UID, int PackageID, int PaymentID, int UserPackID, int PostingID)
        {
            try
            {
                bool bnew = false;
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveSellerInfo";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, objUsedCarsInfo.SellerID);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, objUsedCarsInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, objUsedCarsInfo.Address1);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, objUsedCarsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, objUsedCarsInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUsedCarsInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objUsedCarsInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, objUsedCarsInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetIdsByUID(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetIdsByUID";
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
        public DataSet USP_GetCarDetailsByIds(int CarID, int SellerID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCarDetailsByIds";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@SellerID", System.Data.DbType.Int32, SellerID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetMakeAndModelByID(int makeModelID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetMakeAndModelByID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", System.Data.DbType.Int32, makeModelID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SavePictures(string picturelocation, string picturename, string picturetype, string PictureDescription, int UserID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePictures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@picturelocation", System.Data.DbType.String, picturelocation);
                dbDatabase.AddInParameter(dbCommand, "@picturename", System.Data.DbType.String, picturename);
                dbDatabase.AddInParameter(dbCommand, "@picturetype", System.Data.DbType.String, picturetype);
                dbDatabase.AddInParameter(dbCommand, "@PictureDescription", System.Data.DbType.String, PictureDescription);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool USP_UpdatePicturesById(CarsInfo.CarsInfo objCarsInfo)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePicturesById";
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

                dbDatabase.AddInParameter(dbCommand, "@pic21", System.Data.DbType.String, objCarsInfo.Pic21);
                dbDatabase.AddInParameter(dbCommand, "@pic22", System.Data.DbType.String, objCarsInfo.Pic22);
                dbDatabase.AddInParameter(dbCommand, "@pic23", System.Data.DbType.String, objCarsInfo.Pic23);
                dbDatabase.AddInParameter(dbCommand, "@pic24", System.Data.DbType.String, objCarsInfo.Pic24);
                dbDatabase.AddInParameter(dbCommand, "@pic25", System.Data.DbType.String, objCarsInfo.Pic25);
                dbDatabase.AddInParameter(dbCommand, "@pic26", System.Data.DbType.String, objCarsInfo.Pic26);
                dbDatabase.AddInParameter(dbCommand, "@pic27", System.Data.DbType.String, objCarsInfo.Pic27);
                dbDatabase.AddInParameter(dbCommand, "@pic28", System.Data.DbType.String, objCarsInfo.Pic28);
                dbDatabase.AddInParameter(dbCommand, "@pic29", System.Data.DbType.String, objCarsInfo.Pic29);
                dbDatabase.AddInParameter(dbCommand, "@pic30", System.Data.DbType.String, objCarsInfo.Pic30);
                dbDatabase.AddInParameter(dbCommand, "@pic31", System.Data.DbType.String, objCarsInfo.Pic31);
                dbDatabase.AddInParameter(dbCommand, "@pic32", System.Data.DbType.String, objCarsInfo.Pic32);
                dbDatabase.AddInParameter(dbCommand, "@pic33", System.Data.DbType.String, objCarsInfo.Pic33);
                dbDatabase.AddInParameter(dbCommand, "@pic34", System.Data.DbType.String, objCarsInfo.Pic34);
                dbDatabase.AddInParameter(dbCommand, "@pic35", System.Data.DbType.String, objCarsInfo.Pic35);
                dbDatabase.AddInParameter(dbCommand, "@pic36", System.Data.DbType.String, objCarsInfo.Pic36);
                dbDatabase.AddInParameter(dbCommand, "@pic37", System.Data.DbType.String, objCarsInfo.Pic37);
                dbDatabase.AddInParameter(dbCommand, "@pic38", System.Data.DbType.String, objCarsInfo.Pic38);
                dbDatabase.AddInParameter(dbCommand, "@pic39", System.Data.DbType.String, objCarsInfo.Pic39);
                dbDatabase.AddInParameter(dbCommand, "@pic40", System.Data.DbType.String, objCarsInfo.Pic40);
                dbDatabase.AddInParameter(dbCommand, "@pic41", System.Data.DbType.String, objCarsInfo.Pic41);
                dbDatabase.AddInParameter(dbCommand, "@pic42", System.Data.DbType.String, objCarsInfo.Pic42);
                dbDatabase.AddInParameter(dbCommand, "@pic43", System.Data.DbType.String, objCarsInfo.Pic43);
                dbDatabase.AddInParameter(dbCommand, "@pic44", System.Data.DbType.String, objCarsInfo.Pic44);
                dbDatabase.AddInParameter(dbCommand, "@pic45", System.Data.DbType.String, objCarsInfo.Pic45);
                dbDatabase.AddInParameter(dbCommand, "@pic46", System.Data.DbType.String, objCarsInfo.Pic46);
                dbDatabase.AddInParameter(dbCommand, "@pic47", System.Data.DbType.String, objCarsInfo.Pic47);
                dbDatabase.AddInParameter(dbCommand, "@pic48", System.Data.DbType.String, objCarsInfo.Pic48);
                dbDatabase.AddInParameter(dbCommand, "@pic49", System.Data.DbType.String, objCarsInfo.Pic49);
                dbDatabase.AddInParameter(dbCommand, "@pic50", System.Data.DbType.String, objCarsInfo.Pic50);


                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
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

        public DataSet USP_GetImages(int CarID, int PackageID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetImages";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet USP_GetPackageDetails(int PackageID, int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPackageDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
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

        public DataSet USP_GetUSerDetailsByUserIDForRegLog(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetUSerDetailsByUserIDForRegLog";
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
        public DataSet USP_GetAllMakes(int makeID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
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
        public DataSet USP_GetRegisterSellerIDByUID(int UID, int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetRegisterSellerIDByUID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool USP_UpdateListingStatus(int PostingID, int IsActive, int AdStatus)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateListingStatus";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@IsActive", System.Data.DbType.Int32, IsActive);
                dbDatabase.AddInParameter(dbCommand, "@AdStatus", System.Data.DbType.Int32, AdStatus);
                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
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

        public DataSet USP_SaveRVRegisterData(UserRegistrationInfo objUserregisInfo, CarsInfo.CarsInfo objCarsInfo, string state, string Ip)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveRVRegisterData";
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
                dbDatabase.AddInParameter(dbCommand, "@EngineType", System.Data.DbType.String, objCarsInfo.EngineType);

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


        public bool USP_UpdateRVEditData(SellerInfo objSellerInfo, CarsInfo.CarsInfo objCarsInfo, UsedCarsInfo objUsedCarsInfo)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateRVEditData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objSellerInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@State", System.Data.DbType.String, objSellerInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objSellerInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objSellerInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, objSellerInfo.Email);


                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@ModelName", System.Data.DbType.String, objCarsInfo.ModelName);
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

                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objCarsInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@SellerID", System.Data.DbType.Int32, objUsedCarsInfo.SellerID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, objUsedCarsInfo.PostingID);


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
