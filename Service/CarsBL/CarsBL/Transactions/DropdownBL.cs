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


        public DataSet USP_SaveCarFeatures(int CarID, int FeatureID, int Isactive, int TranBy)
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
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
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

        public DataSet USP_SaveCarDetails(CarsInfo.CarsInfo objCarsInfo, string Description, string ConditionDescription, string Title, int TranBy)
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
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SaveSellerInfo(UsedCarsInfo objUsedCarsInfo, int CarID, int UID, int PackageID, int PaymentID, int UserPackID, int PostingID, string Ip)
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
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SaveCarAndSellerInfo(CarsInfo.CarsInfo objCarsInfo, string Description, string ConditionDescription, string Title, int TranBy,
            UsedCarsInfo objUsedCarsInfo, int UID, int PackageID, int PaymentID, int UserPackID, int PostingID, string Ip)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCarAndSellerInfo";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, objCarsInfo.BodyTypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Double, objCarsInfo.CarID);
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
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, objUsedCarsInfo.SellerID);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, objUsedCarsInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, objUsedCarsInfo.Address1);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, objUsedCarsInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUsedCarsInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objUsedCarsInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, objUsedCarsInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);


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
        public DataSet USP_GetCarDetailsBySellerID(int SellerID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCarDetailsBySellerID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

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

        public DataSet USP_SavePictures(string picturelocation, string picturename, string picturetype, int UserID)
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
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SavePicturesForSmartzUser(string picturelocation, string picturename, string picturetype, int UserID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePicturesForSmartzUser";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@picturelocation", System.Data.DbType.String, picturelocation);
                dbDatabase.AddInParameter(dbCommand, "@picturename", System.Data.DbType.String, picturename);
                dbDatabase.AddInParameter(dbCommand, "@picturetype", System.Data.DbType.String, picturetype);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPictureLocationByID1(string picID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPictureLocationByID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@picID", System.Data.DbType.String, picID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool USP_UpdatePicturesById(CarsInfo.CarsInfo objCarsInfo, int TranBy)
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
        public bool UpdatePicturesByIdForSmartzUserUpload(CarsInfo.CarsInfo objCarsInfo, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePicturesByIdForSmartzUserUpload";
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
        public DataSet GetImagesForCarID(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetImagesForCarID";
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
                spNameString = "USP_GetUSerDetailsByUserID1";
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
        public DataSet USP_GetUSerDetailsByUserIDold(int UID)
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

        public DataSet USP_SaveMultiCarSellerInfo(string SellerName, string Address1, string City, string State, string Zip, string Phone, string altPhone, string Email, int CarID, int UID, int PackageID, DateTime SaleDate)
        {
            try
            {
                bool bnew = false;
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveMultiCarSellerInfo";
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

        public DataSet USP_ExistRegisterDetails(int UserID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ExistRegisterDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@uid", System.Data.DbType.String, UserID);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet USP_caridExists(int carid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_caridExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@carid", System.Data.DbType.String, carid);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet GetMMY(string caruniqueid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USp_GetMMY";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@caruniquid", System.Data.DbType.String, caruniqueid);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet USP_SaveVehData(int regid, int pakid, int makeid, string Makename, int modelid, 
            string modelname, int year, int style, string stylename, string city,
            string phone, int stateid, string statename, string email, string zip,
            string vehicltitle, int askingprice, int drivetrainid, string drivtranname, int mileage, 
            int cylinderid, string cylindaername, int extcolorid, string extcolorname, int doorid, 
            string doorname, int intcoloid, string intcorname, int fuelid, string fueliname, 
            int transmid, string transmname, string vin, int conditionid, string conditname, 
            string vehcdesc)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveVehData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@regid", System.Data.DbType.Int32, regid);
                dbDatabase.AddInParameter(dbCommand, "@pakid", System.Data.DbType.Int32, pakid);
                dbDatabase.AddInParameter(dbCommand, "@makeid", System.Data.DbType.Int32, makeid);
                dbDatabase.AddInParameter(dbCommand, "@Makename", System.Data.DbType.String, Makename);
                dbDatabase.AddInParameter(dbCommand, "@modelid", System.Data.DbType.Int32, modelid);
                dbDatabase.AddInParameter(dbCommand, "@modelname", System.Data.DbType.String, modelname);
                dbDatabase.AddInParameter(dbCommand, "@year", System.Data.DbType.Int32, year);
                dbDatabase.AddInParameter(dbCommand, "@style", System.Data.DbType.Int32,style);
                dbDatabase.AddInParameter(dbCommand, "@stylename", System.Data.DbType.String, stylename);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, city);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@stateid", System.Data.DbType.Int32, stateid);
                dbDatabase.AddInParameter(dbCommand, "@statename", System.Data.DbType.String, statename);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@zip", System.Data.DbType.String, zip);
                dbDatabase.AddInParameter(dbCommand, "@vehicltitle", System.Data.DbType.String, vehicltitle);
                dbDatabase.AddInParameter(dbCommand, "@askingprice", System.Data.DbType.Int32, askingprice);
                dbDatabase.AddInParameter(dbCommand, "@drivetrainid", System.Data.DbType.Int32, drivetrainid);
                dbDatabase.AddInParameter(dbCommand, "@drivtranname", System.Data.DbType.String, drivtranname);
               
                dbDatabase.AddInParameter(dbCommand, "@mileage", System.Data.DbType.Int32, mileage);
                dbDatabase.AddInParameter(dbCommand, "@cylinderid", System.Data.DbType.Int32, cylinderid);
                dbDatabase.AddInParameter(dbCommand, "@cylindaername", System.Data.DbType.String, cylindaername);

                dbDatabase.AddInParameter(dbCommand, "@extcolorid", System.Data.DbType.Int32, extcolorid);
                dbDatabase.AddInParameter(dbCommand, "@extcolorname", System.Data.DbType.String, extcolorname);

                dbDatabase.AddInParameter(dbCommand, "@doorid", System.Data.DbType.Int32, doorid);
                dbDatabase.AddInParameter(dbCommand, "@doorname", System.Data.DbType.String, doorname);
                dbDatabase.AddInParameter(dbCommand, "@intcoloid", System.Data.DbType.Int32, intcoloid);

                dbDatabase.AddInParameter(dbCommand, "@intcorname", System.Data.DbType.String, intcorname);
                dbDatabase.AddInParameter(dbCommand, "@fuelid", System.Data.DbType.Int32, fuelid);

                dbDatabase.AddInParameter(dbCommand, "@fueliname", System.Data.DbType.String, fueliname);
                dbDatabase.AddInParameter(dbCommand, "@transmid", System.Data.DbType.Int32, transmid);

                dbDatabase.AddInParameter(dbCommand, "@transmname", System.Data.DbType.String, transmname);
                dbDatabase.AddInParameter(dbCommand, "@vin", System.Data.DbType.String, vin);

                dbDatabase.AddInParameter(dbCommand, "@conditionid", System.Data.DbType.Int32, conditionid);
                dbDatabase.AddInParameter(dbCommand, "@conditname", System.Data.DbType.String, conditname);
                dbDatabase.AddInParameter(dbCommand, "@vehcdesc", System.Data.DbType.String, vehcdesc);


                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet USP_VehGetDetails(int  regid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_VehGetDetails";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@reguid", System.Data.DbType.Int32, regid);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetFeatures(int carid)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@carid", System.Data.DbType.Int32, carid);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //USP_UpdateVehData

            public DataSet USP_UpdateVehData(int regid, int pakid, int makeid, string Makename, int modelid,
            string modelname, int year, int style, string stylename, string city,
            string phone, int stateid, string statename, string email, string zip,
            string vehicltitle, int askingprice, int drivetrainid, string drivtranname, int mileage,
            int cylinderid, string cylindaername, int extcolorid, string extcolorname, int doorid,
            string doorname, int intcoloid, string intcorname, int fuelid, string fueliname,
            int transmid, string transmname, string vin, int conditionid, string conditname,
            string vehcdesc)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdateVehData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@regid", System.Data.DbType.Int32, regid);
                dbDatabase.AddInParameter(dbCommand, "@pakid", System.Data.DbType.Int32, pakid);
                dbDatabase.AddInParameter(dbCommand, "@makeid", System.Data.DbType.Int32, makeid);
                dbDatabase.AddInParameter(dbCommand, "@Makename", System.Data.DbType.String, Makename);
                dbDatabase.AddInParameter(dbCommand, "@modelid", System.Data.DbType.Int32, modelid);
                dbDatabase.AddInParameter(dbCommand, "@modelname", System.Data.DbType.String, modelname);
                dbDatabase.AddInParameter(dbCommand, "@year", System.Data.DbType.Int32, year);
                dbDatabase.AddInParameter(dbCommand, "@style", System.Data.DbType.Int32, style);
                dbDatabase.AddInParameter(dbCommand, "@stylename", System.Data.DbType.String, stylename);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, city);
                dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                dbDatabase.AddInParameter(dbCommand, "@stateid", System.Data.DbType.Int32, stateid);
                dbDatabase.AddInParameter(dbCommand, "@statename", System.Data.DbType.String, statename);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                dbDatabase.AddInParameter(dbCommand, "@zip", System.Data.DbType.String, zip);
                dbDatabase.AddInParameter(dbCommand, "@vehicltitle", System.Data.DbType.String, vehicltitle);
                dbDatabase.AddInParameter(dbCommand, "@askingprice", System.Data.DbType.Int32, askingprice);
                dbDatabase.AddInParameter(dbCommand, "@drivetrainid", System.Data.DbType.Int32, drivetrainid);
                dbDatabase.AddInParameter(dbCommand, "@drivtranname", System.Data.DbType.String, drivtranname);

                dbDatabase.AddInParameter(dbCommand, "@mileage", System.Data.DbType.Int32, mileage);
                dbDatabase.AddInParameter(dbCommand, "@cylinderid", System.Data.DbType.Int32, cylinderid);
                dbDatabase.AddInParameter(dbCommand, "@cylindaername", System.Data.DbType.String, cylindaername);

                dbDatabase.AddInParameter(dbCommand, "@extcolorid", System.Data.DbType.Int32, extcolorid);
                dbDatabase.AddInParameter(dbCommand, "@extcolorname", System.Data.DbType.String, extcolorname);

                dbDatabase.AddInParameter(dbCommand, "@doorid", System.Data.DbType.Int32, doorid);
                dbDatabase.AddInParameter(dbCommand, "@doorname", System.Data.DbType.String, doorname);
                dbDatabase.AddInParameter(dbCommand, "@intcoloid", System.Data.DbType.Int32, intcoloid);

                dbDatabase.AddInParameter(dbCommand, "@intcorname", System.Data.DbType.String, intcorname);
                dbDatabase.AddInParameter(dbCommand, "@fuelid", System.Data.DbType.Int32, fuelid);

                dbDatabase.AddInParameter(dbCommand, "@fueliname", System.Data.DbType.String, fueliname);
                dbDatabase.AddInParameter(dbCommand, "@transmid", System.Data.DbType.Int32, transmid);

                dbDatabase.AddInParameter(dbCommand, "@transmname", System.Data.DbType.String, transmname);
                dbDatabase.AddInParameter(dbCommand, "@vin", System.Data.DbType.String, vin);

                dbDatabase.AddInParameter(dbCommand, "@conditionid", System.Data.DbType.Int32, conditionid);
                dbDatabase.AddInParameter(dbCommand, "@conditname", System.Data.DbType.String, conditname);
                dbDatabase.AddInParameter(dbCommand, "@vehcdesc", System.Data.DbType.String, vehcdesc);


                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //USp_UpdateMainVeh


            public DataSet USp_UpdateMainVeh(int carid, int MakeModelId, int yearofmake, int bodyTypeId, string title, int askingprice, int mileage,
            string extcol, string intcolr, string transmission, string condiDec, string drivetrain,
            string cylindera, string doors, int fuelTYpeId, string vin, string city,
           string state, string zip, string phone, string email)
            {
                try
                {
                    DataSet dsCars = new DataSet();
                    string spNameString = string.Empty;
                    Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                    spNameString = "USp_UpdateMainVeh";
                    DbCommand dbCommand = null;
                    dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                    dbDatabase.AddInParameter(dbCommand, "@carid", System.Data.DbType.Int32, carid);
                    dbDatabase.AddInParameter(dbCommand, "@MakeModelId", System.Data.DbType.Int32, @MakeModelId);
                    dbDatabase.AddInParameter(dbCommand, "@yearofmake", System.Data.DbType.Int32, yearofmake);
                    dbDatabase.AddInParameter(dbCommand, "@bodyTypeId", System.Data.DbType.Int32, bodyTypeId);
                    dbDatabase.AddInParameter(dbCommand, "@title", System.Data.DbType.String, title);
                    dbDatabase.AddInParameter(dbCommand, "@askingprice", System.Data.DbType.Int32, askingprice);
                    dbDatabase.AddInParameter(dbCommand, "@mileage", System.Data.DbType.Int32, mileage);
                    dbDatabase.AddInParameter(dbCommand, "@extcol", System.Data.DbType.String, extcol);
                    dbDatabase.AddInParameter(dbCommand, "@intcolr", System.Data.DbType.String, intcolr);
                    dbDatabase.AddInParameter(dbCommand, "@transmission", System.Data.DbType.String, transmission);
                    dbDatabase.AddInParameter(dbCommand, "@condiDec", System.Data.DbType.String, condiDec);
                    dbDatabase.AddInParameter(dbCommand, "@drivetrain", System.Data.DbType.String, drivetrain);
                    dbDatabase.AddInParameter(dbCommand, "@cylindera", System.Data.DbType.String, cylindera);
                    dbDatabase.AddInParameter(dbCommand, "@doors", System.Data.DbType.String, doors);
                    dbDatabase.AddInParameter(dbCommand, "@fuelTYpeId", System.Data.DbType.Int32, fuelTYpeId);
                    dbDatabase.AddInParameter(dbCommand, "@vin", System.Data.DbType.String, vin);

                    dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, city);
                    dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, state);

                    dbDatabase.AddInParameter(dbCommand, "@zip", System.Data.DbType.String, zip);
                    dbDatabase.AddInParameter(dbCommand, "@phone", System.Data.DbType.String, phone);
                    dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, email);
                   

                    dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                    return dsCars;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    }
}
