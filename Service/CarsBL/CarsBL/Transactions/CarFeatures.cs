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
    public class CarFeatures
    {
        public DataSet GetCarFeatures(string  sCarID)
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

        public DataSet GetCarFeatures_New(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarFeatures_New]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int64, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCarFeaturesDealer(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarFeatures_New]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int64, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        //Question Repeater
        public DataSet GetCarDiscussions(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarDiscussions]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.String, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCarDiscussionsAllData(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarDiscussionsAllData]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.String, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Questions
        public DataSet GetCarDiscussionsByQuestionId(int QuestionId)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarDiscussionsByQuestionId]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@QuestionId", System.Data.DbType.String, QuestionId);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Answered Questions
        public DataSet GetCarDiscussionsAnswerdata(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarDiscussionsAnswerdata]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.String, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateQuestion(int QuestionId, string QuestionAnswer, DateTime PublishedDate)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "Usp_UpdateQuestion";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@QuestionId", System.Data.DbType.String, QuestionId);
                dbDatabase.AddInParameter(dbCommand, "@Answer", System.Data.DbType.String, QuestionAnswer);
                dbDatabase.AddInParameter(dbCommand, "@PublishedDate", System.Data.DbType.DateTime, PublishedDate);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DataSet UpdateDeletetoQuestion(int QuestionId, DateTime deletedate)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "Usp_UpdateDeletetoQuestion";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@QuestionId", System.Data.DbType.String, QuestionId);
                dbDatabase.AddInParameter(dbCommand, "@deletedate", System.Data.DbType.String, deletedate);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataSet GetCarDiscussionsDelete(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetCarDiscussionsDelete]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.String, sCarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //[GetFinalAnswers]

        public DataSet GetFinalAnswers(string sCarID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[GetFinalAnswers]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.String, sCarID);

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
