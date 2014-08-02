using System;
using System.Data;
using System.Configuration;
//using System.Linq;
using System.Web;
//using System.Xml.Linq;
using System.Data.OleDb;


/// <summary>
/// Summary description for ExcelReading
/// </summary>
public class ExcelReading
{
    public DataSet GetSalesExcelToDataset(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        DataSet objDataset2 = new DataSet();
        OleDbConnection objConn = new OleDbConnection();

        try
        {
            //Excell connection 
            //string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties="Excel 8.0;HDR=Yes;IMEX=1"; 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";

            objConn.ConnectionString = Xls_Con;

            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";

            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT * FROM " + SpreadSheetName + " order by cname", objConn);

            objAdapter1.Fill(objDataset1, "XLData");

            objConn.Close();
        }
        catch (Exception ex)
        {

        }


        return objDataset1;

    }

    public DataSet GetSalesExcelToDatasetLeads(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        DataSet objDataset2 = new DataSet();
        OleDbConnection objConn = new OleDbConnection();

        try
        {
            //Excell connection 
            //string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties="Excel 8.0;HDR=Yes;IMEX=1"; 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";

            objConn.ConnectionString = Xls_Con;

            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";

            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT * FROM " + SpreadSheetName + "", objConn);

            objAdapter1.Fill(objDataset1, "XLData");

            objConn.Close();
        }
        catch (Exception ex)
        {

        }


        return objDataset1;

    }
    public DataSet GetExcelToDatasetQC(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        DataSet objDataset2 = new DataSet();
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            //Excell connection 

            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
            objConn.ConnectionString = Xls_Con;
            //Dim objConn As New OleDbConnection(Xls_Con) 
            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";
            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT * FROM " + SpreadSheetName, objConn);
            objAdapter1.Fill(objDataset1, "XLData");


            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        return objDataset1;
    }



    public DataSet GetExcelDistictBTNCOunt_Sales(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            //Excell connection 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
            objConn.ConnectionString = Xls_Con;
            //Dim objConn As New OleDbConnection(Xls_Con) 
            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct([CPhone]),SaleDate FROM " + SpreadSheetName + "", objConn);

            objAdapter1.Fill(objDataset1, "XLData");

            //count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        return objDataset1;
    }

    private bool getCountMatch(DataSet dsNormal, DataSet dsDistinct)
    {
        bool bnew = false;
        if (dsNormal.Tables.Count > 0)
        {
            if (dsNormal.Tables[0].Rows.Count > 0)
            {
                if (dsNormal.Tables[0].Rows.Count.ToString() == dsDistinct.Tables[0].Rows[0][0].ToString())
                {
                    bnew = true;
                }
            }
        }
        return bnew;

    }

    public int GetExcelDistictURLCOunt(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            //Excell connection 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
            objConn.ConnectionString = Xls_Con;
            //Dim objConn As New OleDbConnection(Xls_Con) 
            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct(URL) FROM " + SpreadSheetName, objConn);
            objAdapter1.Fill(objDataset1, "XLData");

            count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        return count;
    }

    public int GetExcelDistictBTNCOunt_URLs(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            //Excell connection 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
            objConn.ConnectionString = Xls_Con;
            //Dim objConn As New OleDbConnection(Xls_Con) 
            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct(Phoneno) FROM " + SpreadSheetName, objConn);
            objAdapter1.Fill(objDataset1, "XLData");

            count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        return count;
    }

    public DataSet GetExcelDistictBTNCOunt_SalesLeads(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            //Excell connection 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
            objConn.ConnectionString = Xls_Con;
            //Dim objConn As New OleDbConnection(Xls_Con) 
            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT distinct([Phone]),State FROM " + SpreadSheetName + "", objConn);

            objAdapter1.Fill(objDataset1, "XLData");

            //count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        return objDataset1;
    }
    public DataSet GetExcelAllBTNCOunt_SalesLeads(string sFileName)
    {
        Int32 NORec;
        DataSet objDataset1 = new DataSet();
        int count = 0;
        OleDbConnection objConn = new OleDbConnection();
        try
        {
            //Excell connection 
            string Xls_Con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sFileName + ";Extended Properties=\"Excel 8.0;HDR=YES; IMEX=1;ImportMixedTypes=Text\"";
            objConn.ConnectionString = Xls_Con;
            //Dim objConn As New OleDbConnection(Xls_Con) 
            objConn.Open();
            DataTable ExcelSheets = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string SpreadSheetName = "[" + ExcelSheets.Rows[0]["TABLE_NAME"].ToString() + "]";


            OleDbDataAdapter objAdapter1 = new OleDbDataAdapter("SELECT Phone,State FROM " + SpreadSheetName + "", objConn);

            objAdapter1.Fill(objDataset1, "XLData");

            //count = Convert.ToInt32(objDataset1.Tables[0].Rows.Count);
            objConn.Close();
        }
        catch (Exception ex)
        {

        }
        return objDataset1;
    }
}
