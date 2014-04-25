﻿/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 04-Jan-2012
' DESCRIPTION  : Business Logic to search used cars.
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

namespace CarsBL
{
    public class UsedCarsSearch
    {



        public IList<UsedCarsInfo> SimialarCars(string MakeId, string ModelID, string zipcode, string Price)
        {
            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();



            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_SimilarCars]";
            DbCommand dbCommand = null;


            IDataReader UsedCarsDataReader = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbCommand.CommandTimeout = 10000;

              
                dbDatabase.AddInParameter(dbCommand, "@MakeID", DbType.String, MakeId);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", DbType.String, zipcode);
                dbDatabase.AddInParameter(dbCommand, "@Price", DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@ModelID", DbType.String, ModelID);

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                //DataSet  DS = dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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
        private string GetStockURL(string Make, string Model)
        {
            string StockUrl = string.Empty;

            {
                string StockMake = Make;
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";
            }




            return StockUrl;
        }

        public IList<UsedCarsInfo> GetRecentListings()
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "USP_GetTop20RecentPosts";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;



                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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

        public IList<UsedCarsInfo> GetRecentListingsMobile()
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "USP_GetTop20RecentPostsMobile";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;



                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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


        public IList<UsedCarsInfo> GetCarAds()
        {

            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[GetCarAds]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbCommand.CommandTimeout = 10000;

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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


        public IList<UsedCarsInfo> GetCarAdsNew()
        {

            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[GetCarAds_New]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbCommand.CommandTimeout = 10000;

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoListSpeed(UsedCarsDataReader, ObjCarsInfo_Info);
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

        public IList<UsedCarsInfo> GetCarBannerAds()
        {

            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[GetCarBannerAds1]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbCommand.CommandTimeout = 10000;

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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


        public IList<UsedCarsInfo> SearchUsedCars(string carMakeid, string CarModalId, string ZipCode, string WithinZip,
            string currentPage, string pageSize,
            string Orderby, string Sort)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[USP_SearchCarsNew]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, carMakeid);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, CarModalId);
                dbDatabase.AddInParameter(dbCommand, "@Nearby", DbType.Int64, WithinZip);
                dbDatabase.AddInParameter(dbCommand, "@Pin", DbType.Int64, ZipCode);
                dbDatabase.AddInParameter(dbCommand, "@currentPage", DbType.Int64, currentPage);
                dbDatabase.AddInParameter(dbCommand, "@pageSize", DbType.Int64, pageSize);
                dbDatabase.AddInParameter(dbCommand, "@Orderby", DbType.String, Orderby);
                dbDatabase.AddInParameter(dbCommand, "@Sort", DbType.String, Sort);


                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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



        //-----------------------Starts 25-07-2013--------------------//
        public IList<UsedCarsInfo> SearchUsedCarsSpeed(string carMakeid, string CarModalId, string ZipCode, string WithinZip,
            string currentPage, string pageSize,
            string Orderby, string Sort)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name
            // spNameString = "[USP_SearchCarsNew]";
            spNameString = "[USP_SearchCarsNewspeed]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, carMakeid);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, CarModalId);
                dbDatabase.AddInParameter(dbCommand, "@Nearby", DbType.Int64, WithinZip);
                dbDatabase.AddInParameter(dbCommand, "@Pin", DbType.Int64, ZipCode);
                dbDatabase.AddInParameter(dbCommand, "@currentPage", DbType.Int64, currentPage);
                dbDatabase.AddInParameter(dbCommand, "@pageSize", DbType.Int64, pageSize);
                dbDatabase.AddInParameter(dbCommand, "@Orderby", DbType.String, Orderby);
                dbDatabase.AddInParameter(dbCommand, "@Sort", DbType.String, Sort);


                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoListSpeed(UsedCarsDataReader, ObjCarsInfo_Info);
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

        //-----------------------Ends---------------------//



        //------------------------------MinandMaxValues 31-07-2013-----------//

        //-----------------------Starts 25-07-2013--------------------//
        public IList<UsedCarsInfo> MinandMaxValues(string carMakeid, string CarModalId, string ZipCode, string WithinZip)
        {
           
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;
            IDataReader UsedCarsDataReader = null;
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name
            // spNameString = "[USP_SearchCarsNew]";
            spNameString = "[USP_MinandMaxValues]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, carMakeid);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, CarModalId);
                dbDatabase.AddInParameter(dbCommand, "@Nearby", DbType.Int64, WithinZip);
                dbDatabase.AddInParameter(dbCommand, "@Pin", DbType.Int64, ZipCode);
        
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoListMinandMax(UsedCarsDataReader, ObjCarsInfo_Info);
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

        //-----------------------Ends---------------------//




        //------------- MatchedData  31-07-2013 ---------------//
        public IList<UsedCarsInfo> SearchMatchedCars(string MakeId, string ModelID, string zipcode, string Price)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name
            // spNameString = "[USP_SearchCarsNew]";
            spNameString = "[USP_SimilarCarsM]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@MakeID", DbType.String, MakeId);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", DbType.String, zipcode);
                dbDatabase.AddInParameter(dbCommand, "@Price", DbType.String, Price);
                dbDatabase.AddInParameter(dbCommand, "@ModelID", DbType.String, ModelID);

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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
        //------------- ENd ---------------------//




        public IList<UsedCarsInfo> SearchUsedCarsSort(string carMakeid, string CarModalId, string ZipCode, string WithinZip,
            string currentPage, string pageSize,
            string Orderby, string sortorder)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[USP_SearchCarsSort]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, carMakeid);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, CarModalId);
                dbDatabase.AddInParameter(dbCommand, "@Nearby", DbType.Int64, WithinZip);
                dbDatabase.AddInParameter(dbCommand, "@Pin", DbType.Int64, ZipCode);
                dbDatabase.AddInParameter(dbCommand, "@currentPage", DbType.Int64, currentPage);
                dbDatabase.AddInParameter(dbCommand, "@pageSize", DbType.Int64, pageSize);
                dbDatabase.AddInParameter(dbCommand, "@Orderby", DbType.String, Orderby);
                dbDatabase.AddInParameter(dbCommand, "@Sort", DbType.String, sortorder);


                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                //DataSet ds = dbDatabase.ExecuteDataSet (dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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
        public IList<UsedCarsInfo> productionFindCarID(string CarID)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name


            spNameString = "[USP_FindCarIDproduction]";
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
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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
        public IList<UsedCarsInfo> FindCarID(string CarID)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

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
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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





        public IList<UsedCarsInfo> SearchMultiUsedCars(string carMakeid, string CarModalId, string ZipCode, string WithinZip,
            string currentPage, string pageSize,
            string Orderby)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[USP_SearchMultiCars]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, carMakeid);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, CarModalId);
                dbDatabase.AddInParameter(dbCommand, "@Nearby", DbType.String, WithinZip);
                dbDatabase.AddInParameter(dbCommand, "@Pin", DbType.String, ZipCode);
                dbDatabase.AddInParameter(dbCommand, "@currentPage", DbType.Int64, currentPage);
                dbDatabase.AddInParameter(dbCommand, "@pageSize", DbType.Int64, pageSize);
                dbDatabase.AddInParameter(dbCommand, "@Orderby", DbType.String, Orderby);


                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);
                // DataSet  ds =dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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

        private void AssignCarsInfoList(IDataReader UsedCarsDataReader, UsedCarsInfo objUsedCars)
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
                objUsedCars.Zipcode = UsedCarsDataReader["Zipcode"].ToString() == "" ? "Emp" : UsedCarsDataReader["Zipcode"].ToString();



                objUsedCars.Uid = UsedCarsDataReader["Uid"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["Uid"].ToString());


                objUsedCars.SellerName = UsedCarsDataReader["SellerName"].ToString() == "" ? "Emp" : UsedCarsDataReader["SellerName"].ToString();

                objUsedCars.Address1 = UsedCarsDataReader["Address1"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address1"].ToString();
                objUsedCars.Address2 = UsedCarsDataReader["Address2"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address2"].ToString();
                objUsedCars.City = UsedCarsDataReader["City"].ToString() == "" ? "Emp" : UsedCarsDataReader["City"].ToString();
                objUsedCars.State = UsedCarsDataReader["State"].ToString();
                objUsedCars.Zip = UsedCarsDataReader["Zip"].ToString() == "" ? "Emp" : UsedCarsDataReader["Zip"].ToString();
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
                objUsedCars.Mileage = UsedCarsDataReader["mileage"].ToString() == "" ? "0" : UsedCarsDataReader["mileage"].ToString();
                objUsedCars.MakeID = UsedCarsDataReader["makeID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeID"].ToString());
                objUsedCars.MakeModelID = UsedCarsDataReader["makeModelID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeModelID"].ToString());
                objUsedCars.Price = UsedCarsDataReader["price"].ToString() == "" ? 0.00 : Convert.ToDouble(UsedCarsDataReader["price"].ToString());
                objUsedCars.Description = UsedCarsDataReader["description"].ToString() == "" ? "Emp" : UsedCarsDataReader["description"].ToString();

                objUsedCars.Bodytype = UsedCarsDataReader["bodytype"].ToString();
                
                objUsedCars.BodytypeID = Convert.ToInt32(UsedCarsDataReader["BodytypeID"].ToString() == "" ? "0" : UsedCarsDataReader["BodytypeID"].ToString());
                objUsedCars.FueltypeId = Convert.ToInt32(UsedCarsDataReader["FueltypeID"].ToString() == "" ? "0" : UsedCarsDataReader["FueltypeID"].ToString());
                objUsedCars.Fueltype = UsedCarsDataReader["Fueltype"].ToString();


                objUsedCars.ExteriorColor = UsedCarsDataReader["exteriorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["exteriorColor"].ToString();
                objUsedCars.NumberOfSeats = UsedCarsDataReader["numberOfSeats"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfSeats"].ToString();
                objUsedCars.NumberOfDoors = UsedCarsDataReader["numberOfDoors"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfDoors"].ToString();
                objUsedCars.NumberOfCylinder = UsedCarsDataReader["numberOfCylinder"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfCylinder"].ToString();
                objUsedCars.Transmission = UsedCarsDataReader["Transmission"].ToString() == "" ? "Emp" : UsedCarsDataReader["Transmission"].ToString();
                objUsedCars.InteriorColor = UsedCarsDataReader["interiorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["interiorColor"].ToString();

                objUsedCars.VIN = UsedCarsDataReader["VIN"].ToString() == "" ? "Emp" : UsedCarsDataReader["VIN"].ToString();

                objUsedCars.ConditionDescription = UsedCarsDataReader["ConditionDescription"].ToString() == "" ? "Emp" : UsedCarsDataReader["ConditionDescription"].ToString();

                objUsedCars.DriveTrain = UsedCarsDataReader["DriveTrain"].ToString() == "" ? "Emp" : UsedCarsDataReader["DriveTrain"].ToString();

                try
                {
                    objUsedCars.Title = UsedCarsDataReader["Title"].ToString() == "" ? "Emp" : UsedCarsDataReader["Title"].ToString();
                    
                    objUsedCars.AdStatus = UsedCarsDataReader["AdStatusName"].ToString() == "" ? "Emp" : UsedCarsDataReader["AdStatusName"].ToString();
                }
                catch { }
                try
                {
                    objUsedCars.CarUniqueID = UsedCarsDataReader["CarUniqueID"].ToString() == "" ? "Emp" : UsedCarsDataReader["CarUniqueID"].ToString();
                }
                catch { }
                

                


                objUsedCars.PIC0 = UsedCarsDataReader["PIC0"].ToString() == "" ? GetStockURL(objUsedCars.Make, objUsedCars.Model) : UsedCarsDataReader["PIC0"].ToString();
                objUsedCars.PICLOC0 = UsedCarsDataReader["PICLOC0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC0"].ToString();
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





                objUsedCars.RowNumber = UsedCarsDataReader["RowNumber"].ToString() == "" ? "Emp" : UsedCarsDataReader["RowNumber"].ToString();
                objUsedCars.TotalRecords = UsedCarsDataReader["TotalRecords"].ToString() == "" ? "Emp" : UsedCarsDataReader["TotalRecords"].ToString();
                objUsedCars.PageCount = UsedCarsDataReader["PageCount"].ToString() == "" ? "Emp" : UsedCarsDataReader["PageCount"].ToString();

                objUsedCars.UserFeedback = UsedCarsDataReader["UserFeedback"].ToString();






                //objUsedCars.pic0 = UsedCarsDataReader["pic0"].ToString();


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }



        }
        private void AssignCarsInfoListSpeed(IDataReader UsedCarsDataReader, UsedCarsInfo objUsedCars)
        {
            try
            {
                objUsedCars.PostingID = Convert.ToInt32(UsedCarsDataReader["PostingID"].ToString());
                objUsedCars.Carid = Convert.ToInt32(UsedCarsDataReader["Carid"].ToString());
                objUsedCars.SellerType = UsedCarsDataReader["SellerType"].ToString();
                objUsedCars.SellerID = Convert.ToInt32(UsedCarsDataReader["SellerID"].ToString());



                objUsedCars.PackageID = UsedCarsDataReader["PackageID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["PackageID"].ToString());

                objUsedCars.IsActive = UsedCarsDataReader["IsActive"].ToString() == "" ? true : Convert.ToBoolean(UsedCarsDataReader["IsActive"].ToString());




                objUsedCars.Uid = UsedCarsDataReader["Uid"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["Uid"].ToString());




                objUsedCars.Address1 = UsedCarsDataReader["Address1"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address1"].ToString();
                objUsedCars.Address2 = UsedCarsDataReader["Address2"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address2"].ToString();
                objUsedCars.City = UsedCarsDataReader["City"].ToString() == "" ? "Emp" : UsedCarsDataReader["City"].ToString();
                objUsedCars.State = UsedCarsDataReader["State"].ToString();
                objUsedCars.Zip = UsedCarsDataReader["Zip"].ToString() == "" ? "Emp" : UsedCarsDataReader["Zip"].ToString();

                objUsedCars.Phone = UsedCarsDataReader["Phone"].ToString();

                objUsedCars.Email = UsedCarsDataReader["Email"].ToString() == "" ? "Emp" : UsedCarsDataReader["Email"].ToString();

                objUsedCars.Model = UsedCarsDataReader["model"].ToString();
                objUsedCars.Make = UsedCarsDataReader["make"].ToString();
                objUsedCars.YearOfMake = UsedCarsDataReader["yearOfMake"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["yearOfMake"].ToString());
                objUsedCars.Mileage = UsedCarsDataReader["mileage"].ToString() == "" ? "0" : UsedCarsDataReader["mileage"].ToString();

                objUsedCars.Price = UsedCarsDataReader["price"].ToString() == "" ? 0.00 : Convert.ToDouble(UsedCarsDataReader["price"].ToString());
                objUsedCars.Description = UsedCarsDataReader["description"].ToString() == "" ? "Emp" : UsedCarsDataReader["description"].ToString();

                objUsedCars.Bodytype = UsedCarsDataReader["bodytype"].ToString();
                objUsedCars.BodytypeID = Convert.ToInt32(UsedCarsDataReader["BodytypeID"].ToString());
                objUsedCars.FueltypeId = Convert.ToInt32(UsedCarsDataReader["FueltypeID"].ToString());
                objUsedCars.Fueltype = UsedCarsDataReader["Fueltype"].ToString();

                objUsedCars.Title = UsedCarsDataReader["Title"].ToString() == "" ? "Emp" : UsedCarsDataReader["Title"].ToString();

                objUsedCars.CarUniqueID = UsedCarsDataReader["CarUniqueID"].ToString() == "" ? "Emp" : UsedCarsDataReader["CarUniqueID"].ToString();

                objUsedCars.AdStatus = UsedCarsDataReader["AdStatusName"].ToString() == "" ? "Emp" : UsedCarsDataReader["AdStatusName"].ToString();

                objUsedCars.ExteriorColor = UsedCarsDataReader["exteriorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["exteriorColor"].ToString();
                objUsedCars.NumberOfSeats = UsedCarsDataReader["numberOfSeats"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfSeats"].ToString();
                objUsedCars.NumberOfDoors = UsedCarsDataReader["numberOfDoors"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfDoors"].ToString();
                objUsedCars.NumberOfCylinder = UsedCarsDataReader["numberOfCylinder"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfCylinder"].ToString();
                objUsedCars.Transmission = UsedCarsDataReader["Transmission"].ToString() == "" ? "Emp" : UsedCarsDataReader["Transmission"].ToString();
                objUsedCars.InteriorColor = UsedCarsDataReader["interiorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["interiorColor"].ToString();
                objUsedCars.SellerName = UsedCarsDataReader["SellerName"].ToString() == "" ? "Emp" : UsedCarsDataReader["SellerName"].ToString();


                objUsedCars.PIC0 = UsedCarsDataReader["PIC0"].ToString() == "" ? GetStockURL(objUsedCars.Make, objUsedCars.Model) : UsedCarsDataReader["PIC0"].ToString();
                objUsedCars.PICLOC0 = UsedCarsDataReader["PICLOC0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC0"].ToString();
                try
                {
                    objUsedCars.PaymentID = UsedCarsDataReader["pmntStatus"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["pmntStatus"].ToString());
                   
                }
                catch { }
                try
                {
                    objUsedCars.DateOfPosting = Convert.ToDateTime(UsedCarsDataReader["DateOfPosting"].ToString());
                    objUsedCars.ExpirtyDate = UsedCarsDataReader["ExpirtyDate"].ToString() == "" ? System.DateTime.Now : Convert.ToDateTime(UsedCarsDataReader["ExpirtyDate"].ToString());
                   
                    objUsedCars.InternalreviewID = UsedCarsDataReader["InternalreviewID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["InternalreviewID"].ToString());
                    objUsedCars.CancelledBy = UsedCarsDataReader["CancelledBy"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["CancelledBy"].ToString());
                    objUsedCars.CancelledReason = UsedCarsDataReader["CancelledReason"].ToString();
                    objUsedCars.CancelledDate = UsedCarsDataReader["CancelledDate"].ToString() == "" ? System.DateTime.Now : Convert.ToDateTime(UsedCarsDataReader["CancelledDate"].ToString());
                    objUsedCars.Zipcode = UsedCarsDataReader["Zipcode"].ToString() == "" ? "Emp" : UsedCarsDataReader["Zipcode"].ToString();

                    objUsedCars.Country = UsedCarsDataReader["Country"].ToString() == "1" ? "USA" : UsedCarsDataReader["Country"].ToString();
                    objUsedCars.AltPhone = UsedCarsDataReader["AltPhone"].ToString();
                    objUsedCars.Fax = UsedCarsDataReader["Fax"].ToString();
                    objUsedCars.AltEmail = UsedCarsDataReader["AltEmail"].ToString() == "" ? "Emp" : UsedCarsDataReader["Email"].ToString();
                    objUsedCars.NotesForBuyers = UsedCarsDataReader["NotesForBuyers"].ToString();
                    objUsedCars.MakeID = UsedCarsDataReader["makeID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeID"].ToString());
                    objUsedCars.MakeModelID = UsedCarsDataReader["makeModelID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeModelID"].ToString());
                    objUsedCars.VIN = UsedCarsDataReader["VIN"].ToString() == "" ? "Emp" : UsedCarsDataReader["VIN"].ToString();
                   // objUsedCars.PaymentID = UsedCarsDataReader["PaymentID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["PaymentID"].ToString());
                    objUsedCars.ConditionDescription = UsedCarsDataReader["ConditionDescription"].ToString() == "" ? "Emp" : UsedCarsDataReader["ConditionDescription"].ToString();

                    objUsedCars.DriveTrain = UsedCarsDataReader["DriveTrain"].ToString() == "" ? "Emp" : UsedCarsDataReader["DriveTrain"].ToString();


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


                }
                catch { }


                try
                {
                    objUsedCars.RowNumber = UsedCarsDataReader["RowNumber"].ToString() == "" ? "Emp" : UsedCarsDataReader["RowNumber"].ToString();
                }
                catch { }
                try
                {
                    objUsedCars.TotalRecords = UsedCarsDataReader["TotalRecords"].ToString() == "" ? "Emp" : UsedCarsDataReader["TotalRecords"].ToString();
                }
                catch { }
                try
                {
                    objUsedCars.PageCount = UsedCarsDataReader["PageCount"].ToString() == "" ? "Emp" : UsedCarsDataReader["PageCount"].ToString();
                }
                catch { }

                try
                {
                    objUsedCars.UserFeedback = UsedCarsDataReader["UserFeedback"].ToString();
                }
                catch { }

                // objUsedCars.TotalRecords = UsedCarsDataReader["DiffYear"].ToString() == "" ? "Emp" : UsedCarsDataReader["DiffYear"].ToString();




                //objUsedCars.pic0 = UsedCarsDataReader["pic0"].ToString();


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }



        }



        //--------------------------MinandMaxValues---------31-07-2013------------//

        private void AssignCarsInfoListMinandMax(IDataReader UsedCarsDataReader, UsedCarsInfo objUsedCars)
        {
            try
            {

                objUsedCars.Email = UsedCarsDataReader["MinP"].ToString() == "" ? "Emp" : UsedCarsDataReader["MinP"].ToString();
                objUsedCars.Address1 = UsedCarsDataReader["MaxP"].ToString() == "" ? "Emp" : UsedCarsDataReader["MaxP"].ToString();
                objUsedCars.Address2 = UsedCarsDataReader["MinY"].ToString() == "" ? "Emp" : UsedCarsDataReader["MinY"].ToString();
                objUsedCars.City = UsedCarsDataReader["MaxY"].ToString() == "" ? "Emp" : UsedCarsDataReader["MaxY"].ToString();
                objUsedCars.State = UsedCarsDataReader["MinM"].ToString();
                objUsedCars.Description = UsedCarsDataReader["MaxM"].ToString() == "" ? "Emp" : UsedCarsDataReader["MaxM"].ToString();

             
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }



        }
        //-------------------------------End-------------------------------------//
        public IList<UsedCarsInfo> FindCarIDNew(string CarID)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name


            spNameString = "[USP_FindCarID_New]";
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
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
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


        public IList<UsedCarsInfo> FindLoginCarID(string CarId)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name


            spNameString = "[USP_FindLoginCarID]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.String, CarId);
                //dbDatabase.AddInParameter(dbCommand, "@DealerCode", DbType.String, DealerCode);

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);
                // DataSet  ds =dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoList1(UsedCarsDataReader, ObjCarsInfo_Info);
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



        public IList<UsedCarsInfo> FindLoginCarIDReg(string CarId)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name


            spNameString = "[USP_FindRegCarID]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.String, CarId);
                //dbDatabase.AddInParameter(dbCommand, "@DealerCode", DbType.String, DealerCode);

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);
                // DataSet  ds =dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoList1(UsedCarsDataReader, ObjCarsInfo_Info);
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



        private void AssignCarsInfoList1(IDataReader UsedCarsDataReader, UsedCarsInfo objUsedCars)
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
                objUsedCars.Zipcode = UsedCarsDataReader["Zipcode"].ToString() == "" ? "Emp" : UsedCarsDataReader["Zipcode"].ToString();



                objUsedCars.Uid = UsedCarsDataReader["Uid"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["Uid"].ToString());


                objUsedCars.SellerName = UsedCarsDataReader["SellerName"].ToString() == "" ? "Emp" : UsedCarsDataReader["SellerName"].ToString();

                objUsedCars.Address1 = UsedCarsDataReader["Address1"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address1"].ToString();
                objUsedCars.Address2 = UsedCarsDataReader["Address2"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address2"].ToString();
                objUsedCars.City = UsedCarsDataReader["City"].ToString() == "" ? "Emp" : UsedCarsDataReader["City"].ToString();
                objUsedCars.State = UsedCarsDataReader["State"].ToString();
                //objUsedCars.StateName  = GetStateName(UsedCarsDataReader["State"].ToString());
                objUsedCars.Zip = UsedCarsDataReader["Zip"].ToString() == "" ? "Emp" : UsedCarsDataReader["Zip"].ToString();
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
                objUsedCars.Mileage = UsedCarsDataReader["mileage"].ToString() == "" ? "0" : (UsedCarsDataReader["mileage"].ToString());
                objUsedCars.MakeID = UsedCarsDataReader["makeID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeID"].ToString());
                objUsedCars.MakeModelID = UsedCarsDataReader["makeModelID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeModelID"].ToString());
                objUsedCars.Price = UsedCarsDataReader["price"].ToString() == "" ? 0.00 : Convert.ToDouble(UsedCarsDataReader["price"].ToString());
                objUsedCars.Description = UsedCarsDataReader["description"].ToString() == "" ? "Emp" : UsedCarsDataReader["description"].ToString();

                objUsedCars.Bodytype = UsedCarsDataReader["bodytype"].ToString();
                objUsedCars.BodytypeID = Convert.ToInt32(UsedCarsDataReader["BodytypeID"].ToString() == "" ? "0" : UsedCarsDataReader["BodytypeID"].ToString());
                objUsedCars.FueltypeId = Convert.ToInt32(UsedCarsDataReader["FueltypeID"].ToString() == "" ? "0" : UsedCarsDataReader["FueltypeID"].ToString());
                objUsedCars.Fueltype = UsedCarsDataReader["Fueltype"].ToString();

                objUsedCars.ExteriorColor = UsedCarsDataReader["exteriorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["exteriorColor"].ToString();
                objUsedCars.NumberOfSeats = UsedCarsDataReader["numberOfSeats"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfSeats"].ToString();
                objUsedCars.NumberOfDoors = UsedCarsDataReader["numberOfDoors"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfDoors"].ToString();
                objUsedCars.NumberOfCylinder = UsedCarsDataReader["numberOfCylinder"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfCylinder"].ToString();
                objUsedCars.Transmission = UsedCarsDataReader["Transmission"].ToString() == "" ? "Emp" : UsedCarsDataReader["Transmission"].ToString();
                objUsedCars.InteriorColor = UsedCarsDataReader["interiorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["interiorColor"].ToString();

                objUsedCars.VIN = UsedCarsDataReader["VIN"].ToString() == "" ? "Emp" : UsedCarsDataReader["VIN"].ToString();

                objUsedCars.ConditionDescription = UsedCarsDataReader["ConditionDescription"].ToString() == "" ? "Emp" : UsedCarsDataReader["ConditionDescription"].ToString();

                objUsedCars.DriveTrain = UsedCarsDataReader["DriveTrain"].ToString() == "" ? "Emp" : UsedCarsDataReader["DriveTrain"].ToString();

                objUsedCars.Title = UsedCarsDataReader["Title"].ToString() == "" ? "Emp" : UsedCarsDataReader["Title"].ToString();

                objUsedCars.CarUniqueID = UsedCarsDataReader["CarUniqueID"].ToString() == "" ? "Emp" : UsedCarsDataReader["CarUniqueID"].ToString();

                objUsedCars.AdStatus = UsedCarsDataReader["AdStatusName"].ToString() == "" ? "Emp" : UsedCarsDataReader["AdStatusName"].ToString();
                objUsedCars.ActiveSince = UsedCarsDataReader["ActiveSince"].ToString() == "" ? "Emp" : UsedCarsDataReader["ActiveSince"].ToString();
                objUsedCars.DealerUniqueID = UsedCarsDataReader["DealerUniqueID"].ToString() == "" ? "Emp" : UsedCarsDataReader["DealerUniqueID"].ToString();

                objUsedCars.CurrentPrice = UsedCarsDataReader["CurrentPrice"].ToString() == "" ? "Emp" : UsedCarsDataReader["CurrentPrice"].ToString();

                objUsedCars.PublishedDt = UsedCarsDataReader["PublishedDt"].ToString() == "" ? "Emp" : UsedCarsDataReader["PublishedDt"].ToString();

                objUsedCars.PurchaseCost = UsedCarsDataReader["PurchaseCost"].ToString() == "" ? "Emp" : UsedCarsDataReader["PurchaseCost"].ToString();

                objUsedCars.PIC0 = UsedCarsDataReader["PIC0"].ToString() == "" ? GetStockURL(objUsedCars.Make, objUsedCars.Model) : UsedCarsDataReader["PIC0"].ToString();

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

                objUsedCars.PICID0 = UsedCarsDataReader["PICID0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID0"].ToString();
                objUsedCars.PICID1 = UsedCarsDataReader["PICID1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID1"].ToString();
                objUsedCars.PICID2 = UsedCarsDataReader["PICID2"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID2"].ToString();
                objUsedCars.PICID3 = UsedCarsDataReader["PICID3"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID3"].ToString();
                objUsedCars.PICID4 = UsedCarsDataReader["PICID4"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID4"].ToString();
                objUsedCars.PICID5 = UsedCarsDataReader["PICID5"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID5"].ToString();
                objUsedCars.PICID6 = UsedCarsDataReader["PICID6"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID6"].ToString();
                objUsedCars.PICID7 = UsedCarsDataReader["PICID7"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID7"].ToString();
                objUsedCars.PICID8 = UsedCarsDataReader["PICID8"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID8"].ToString();
                objUsedCars.PICID9 = UsedCarsDataReader["PICID9"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID9"].ToString();
                objUsedCars.PICID10 = UsedCarsDataReader["PICID10"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID10"].ToString();
                objUsedCars.PICID11 = UsedCarsDataReader["PICID11"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID11"].ToString();
                objUsedCars.PICID12 = UsedCarsDataReader["PICID12"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID12"].ToString();
                objUsedCars.PICID13 = UsedCarsDataReader["PICID13"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID13"].ToString();
                objUsedCars.PICID14 = UsedCarsDataReader["PICID14"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID14"].ToString();
                objUsedCars.PICID15 = UsedCarsDataReader["PICID15"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID15"].ToString();
                objUsedCars.PICID16 = UsedCarsDataReader["PICID16"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID16"].ToString();
                objUsedCars.PICID17 = UsedCarsDataReader["PICID17"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID17"].ToString();
                objUsedCars.PICID18 = UsedCarsDataReader["PICID18"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID18"].ToString();
                objUsedCars.PICID19 = UsedCarsDataReader["PICID19"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID19"].ToString();
                objUsedCars.PICID20 = UsedCarsDataReader["PICID20"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICID20"].ToString();

                //objUsedCars.LastUpdatedDate = UsedCarsDataReader["LastUpdatedDate"].ToString() == "" ? "" : UsedCarsDataReader["LastUpdatedDate"].ToString();
                //objUsedCars.BusinessName = UsedCarsDataReader["BusinessName"].ToString() == "" ? "" : UsedCarsDataReader["BusinessName"].ToString();

                //objUsedCars.RowNumber = UsedCarsDataReader["RowNumber"].ToString() == "" ? "Emp" : UsedCarsDataReader["RowNumber"].ToString();
                //objUsedCars.TotalRecords = UsedCarsDataReader["TotalRecords"].ToString() == "" ? "Emp" : UsedCarsDataReader["TotalRecords"].ToString();
                //objUsedCars.PageCount = UsedCarsDataReader["PageCount"].ToString() == "" ? "Emp" : UsedCarsDataReader["PageCount"].ToString();

                //objUsedCars.UserFeedback = UsedCarsDataReader["UserFeedback"].ToString();

                //objUsedCars.pic0 = UsedCarsDataReader["pic0"].ToString();


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

    }
}
