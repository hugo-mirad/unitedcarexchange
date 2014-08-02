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

namespace CarsBL.Masters
{
    public class CategoryBL
    {
        public IList<CategoryInfo> GetCategory()
        {
            //Decalaring MakesInfo division object collection
            IList<CategoryInfo> CategoryInfoIList = new List<CategoryInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader CategoryInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_GetAllCategories]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Category_id", DbType.Int64, 0);

                //Executing stored procedure
                CategoryInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (CategoryInfoDataReader.Read())
                {
                    //Assign values to the CategoryInfo object list
                    CategoryInfo ObjCategoryInfo_Info = new CategoryInfo();
                    AssignCategoryInfoList(CategoryInfoDataReader, ObjCategoryInfo_Info);
                    CategoryInfoIList.Add(ObjCategoryInfo_Info);
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
                CategoryInfoDataReader.Close();
            }

            return CategoryInfoIList;
        }



        private void AssignCategoryInfoList(IDataReader CategoryInfoDataReader, CategoryInfo categoryInfo)
        {
            try
            {
                categoryInfo.Category_id = int.Parse(CategoryInfoDataReader["Category_id"].ToString());
                categoryInfo.Category_Name = Convert.ToString(CategoryInfoDataReader["Category_Name"]);
                categoryInfo.VehicleTypeID = Convert.ToString(CategoryInfoDataReader["VehicleTypeID"]);
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

    }
}
