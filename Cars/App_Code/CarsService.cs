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
using System.Web;
using System.Web.Services;
using CarsInfo;
//using CarsBL;


#endregion System References
//using CarsInfo;

#region Application References
using CarsInfo;
using CarsBL;
using CarsBL.Transactions;
using CarsBL.Masters;
using System.Web.Script.Services;
using System.Net.Mail;
#endregion Application References

#region Microsoft Application Block References
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Common;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
//using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion Microsoft Application Block References

/// <summary>
/// Summary description for CarsService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
//[Gen]
[System.Web.Script.Services.ScriptService]
public class CarsService : System.Web.Services.WebService
{

    public CarsService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public List<MakesInfo> GetMakes()
    {
        var obj = new List<MakesInfo>();

        //MakesInfo objMakes = new MakesInfo();
        MakesBL objMakesBL = new MakesBL();
        if (Session["Makes"] == null)
        {
            obj = (List<MakesInfo>)objMakesBL.GetMakes();
            Session["Makes"] = obj;
        }
        else
        {
            obj = (List<MakesInfo>)Session["Makes"];

        }

        return obj;
    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<ModelsInfo> GetModelsInfo()
    {
        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Session["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Session["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Session["Model"];
        }

        return obj;

    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsMultiSearch(ArrayList SearchArray)
    {
        string Orderby = string.Empty;
        if (Session["Orderby"] != null)
        {
            Orderby = Session["Orderby"].ToString();
        }
        else
        {
            Orderby = "Price";
        }


        var obj = new List<CarsInfo.UsedCarsInfo>();

        List<CarsInfo.UsedCarsInfo> obj2 = new List<CarsInfo.UsedCarsInfo>();

        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
        string[] SerachType;
        string carMakeid = string.Empty;
        string CarModalId = string.Empty;
        string ZipCode = string.Empty;
        string WithinZip = string.Empty;

        for (int i = 0; i < SearchArray.Count; i++)
        {

            SerachType = SearchArray[i].ToString().Split(',');

            if (i == 0)
            {
                carMakeid = SerachType[0];
                CarModalId = SerachType[1];
                ZipCode = SerachType[2];
                WithinZip = SerachType[3];

            }
            else
            {
                //sLocationsRebill + ",'" + Items.Value + "'";
                carMakeid = carMakeid + "," + SerachType[0] + "";
                CarModalId = CarModalId + "," + SerachType[1] + "";


            }
        }
        Session["Orderby"] = Orderby;
        Session["carMake"] = carMakeid;
        Session["CarModalId"] = CarModalId;
        Session["ZipCode"] = ZipCode;
        Session["WithinZip"] = WithinZip;

        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchMultiUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, "1", "25", Orderby);

        Session["SearchFullCarsdata"] = obj;
        //Session["SearchCarsdata"] = obj2;
        Session["SearchCarsdata"] = obj;

        if (Session["FilterArray"] != null)
        {

            ArrayList FilterArray = (ArrayList)Session["FilterArray"];

            if (Session["PageSize"] != null)
            {
                obj2 = GetCarsFilterMulti(FilterArray, 25);
            }
            else
            {
                obj2 = GetCarsFilterMulti(FilterArray, Convert.ToInt32(Session["PageSize"]));
            }
        }

        obj2 = GetPageMultiData(25, 1);
        //carMakeid, CarModalId, ZipCode, WithinZip        

        //for (int k = 0; k < obj2.Count; k++)
        //{ 
        //obj2[k].pa 

        //}
        return obj2;

    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> FindCarID(string sCarid)
    {

        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfo>();
        UsedCarsSearch obj = new UsedCarsSearch();
        //if (Session["SearchCarsdata"] != null)
        //{
        //    obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchCarsdata"];

        //    obUsedCarsInfo = obUsedCarsInfo.FindAll(p => p.Carid == Convert.ToInt32(sCarid));

        //    Session["SearchedData"] = obUsedCarsInfo;
        //}
        //else
        //{
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)obj.FindCarID(sCarid);

        // }

        return obUsedCarsInfo;
    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> productionFindCarID(string sCarid)
    {

        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfo>();
        UsedCarsSearch obj = new UsedCarsSearch();
        //if (Session["SearchCarsdata"] != null)
        //{
        //    obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchCarsdata"];

        //    obUsedCarsInfo = obUsedCarsInfo.FindAll(p => p.Carid == Convert.ToInt32(sCarid));

        //    Session["SearchedData"] = obUsedCarsInfo;
        //}
        //else
        //{
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)obj.productionFindCarID(sCarid);

        // }

        return obUsedCarsInfo;
    }


    [WebMethod]
    public string EncryptedCarID(string sCarID)
    {
        sCarID = "Cars" + sCarID;

        return sCarID;
    }

    public string DeCryptedCarID(string sCarID)
    {

        return sCarID;

    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> SortMultiData(string sFilterType, int PageSize)
    {
        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchCarsdata"];

        switch (sFilterType)
        {
            case "1":

                //<option value="1">Price low to high</option>
                //obUsedCarsInfo.OrderBy(p => p.Price).ToList();// ("Name desc");   
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price asc");
                obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).ToList();// ("Name desc");  
                //rderBy(person => person.LastName);

                break;
            case "2":

                obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).Reverse().ToList();
                //<option value="2">Price high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price desc");

                break;
            case "3":
                //<option value="3">Year old to new</option>

                obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.YearOfMake).ToList();
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake desc");

                break;
            case "4":
                //<option value="4">Year new to old</option>
                obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.YearOfMake).Reverse().ToList();
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake asc");
                break;
            case "5":
                obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Mileage).ToList();
                //<option value="5">Mileage low to high</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage desc");
                break;
            case "6":
                obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Mileage).Reverse().ToList();
                //<option value="6">Mileage high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage asc");
                break;
        }

        decimal pagecount = Math.Ceiling(Convert.ToDecimal(Convert.ToDecimal(obUsedCarsInfo[0].TotalRecords) / PageSize));

        for (int i = 0; i < obUsedCarsInfo.Count; i++)
        {
            obUsedCarsInfo[i].PageCount = pagecount.ToString();
        }

        Session["SearchCarsdata"] = obUsedCarsInfo;

        Session["SortType"] = sFilterType;
        obUsedCarsInfo = GetPageMultiData(PageSize, 1);

        return obUsedCarsInfo;


    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> SortData(string sFilterType, int PageSize)
    {
        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        string CurrentPage = "1";
        string pageresultscount = PageSize.ToString();
        string Orderby = Session["Orderby"].ToString();
        string carMakeid = Session["carMake"].ToString();
        string CarModalId = Session["CarModalId"].ToString();
        string ZipCode = Session["ZipCode"].ToString();
        string WithinZip = Session["WithinZip"].ToString();



        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();

        switch (sFilterType)
        {
            case "1":
                Session["Orderby"] = "Price";
                Session["sort"] = "asc";
                //<option value="1">Price low to high</option>
                //obUsedCarsInfo.OrderBy(p => p.Price).ToList();// ("Name desc");   
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price asc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).ToList();// ("Name desc");  
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Price", "asc");
                //rderBy(person => person.LastName);

                break;
            case "2":
                Session["Orderby"] = "Price";
                Session["sort"] = "desc";

                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Price", "desc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).Reverse().ToList();
                //<option value="2">Price high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price desc");

                break;
            case "3":
                Session["Orderby"] = "YearOfMake";
                Session["sort"] = "asc";
                //<option value="3">Year old to new</option>
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "YearOfMake", "asc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.YearOfMake).ToList();
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake desc");

                break;
            case "4":
                Session["Orderby"] = "YearOfMake";
                Session["sort"] = "desc";
                //<option value="4">Year new to old</option>
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "YearOfMake", "desc");
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake asc");
                break;
            case "5":
                Session["Orderby"] = "Mileage";
                Session["sort"] = "asc";
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Mileage", "asc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Mileage).ToList();
                //<option value="5">Mileage low to high</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage desc");
                break;
            case "6":
                Session["Orderby"] = "Mileage";
                Session["sort"] = "desc";
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Mileage", "desc");
                //<option value="6">Mileage high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage asc");
                break;
        }

        Session["SearchCarsdata"] = obUsedCarsInfo;

        Session["SortType"] = sFilterType;
        //obUsedCarsInfo = pagingdata(PageSize, 1, obUsedCarsInfo);




        return obUsedCarsInfo;


    }


    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public bool SortDataBool(string sFilterType, int PageSize)
    {
        //List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        string CurrentPage = "1";
        string pageresultscount = PageSize.ToString();
        string Orderby = Session["Orderby"].ToString();
        /*string carMakeid = Session["carMake"].ToString();
        string CarModalId = Session["CarModalId"].ToString();
        string ZipCode = Session["ZipCode"].ToString();
        string WithinZip = Session["WithinZip"].ToString();
         */



        // CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();

        switch (sFilterType)
        {
            case "1":
                Session["Orderby"] = "Price";
                Session["sort"] = "asc";
                //<option value="1">Price low to high</option>
                //obUsedCarsInfo.OrderBy(p => p.Price).ToList();// ("Name desc");   
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price asc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).ToList();// ("Name desc");  
                //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Price", "asc");
                //rderBy(person => person.LastName);

                break;
            case "2":
                Session["Orderby"] = "Price";
                Session["sort"] = "desc";

                //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Price", "desc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).Reverse().ToList();
                //<option value="2">Price high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price desc");

                break;
            case "3":
                Session["Orderby"] = "YearOfMake";
                Session["sort"] = "asc";
                //<option value="3">Year old to new</option>
                //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "YearOfMake", "asc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.YearOfMake).ToList();
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake desc");

                break;
            case "4":
                Session["Orderby"] = "YearOfMake";
                Session["sort"] = "desc";
                //<option value="4">Year new to old</option>
                //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "YearOfMake", "desc");
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake asc");
                break;
            case "5":
                Session["Orderby"] = "Mileage";
                Session["sort"] = "asc";
                //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Mileage", "asc");
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Mileage).ToList();
                //<option value="5">Mileage low to high</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage desc");
                break;
            case "6":
                Session["Orderby"] = "Mileage";
                Session["sort"] = "desc";
                //obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Mileage", "desc");
                //<option value="6">Mileage high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage asc");
                break;
        }

        //Session["SearchCarsdata"] = obUsedCarsInfo;

        //Session["SortType"] = sFilterType;
        //obUsedCarsInfo = pagingdata(PageSize, 1, obUsedCarsInfo);



        var tt = true;
        return tt;


    }



    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsSearch(string carMakeid, string CarModalId, string ZipCode, string WithinZip, string pageNo, string pageresultscount, string orderby)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        try
        {

            CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();


            Session["carMake"] = carMakeid;
            Session["CarModalId"] = CarModalId;
            Session["ZipCode"] = ZipCode;
            Session["WithinZip"] = WithinZip;
            string sort = string.Empty;
            if (Session["Orderby"] != null && Session["Orderby"] != "")
            {
                orderby = Session["Orderby"].ToString();
            }
            else
            {
                Session["Orderby"] = "price";
            }
            if (Session["sort"] != null)
            {
                sort = Session["sort"].ToString();
            }
            else
            {
                sort = "desc";
            }

            string IPAddress = string.Empty;
            string SearchName = string.Empty;

            String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();

            IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


            GeneralFunc.SaveSearchLog(IPAddress, carMakeid, CarModalId, WithinZip, ZipCode, "Genral");

            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, pageNo, pageresultscount, orderby, sort);


            Session["SearchFullCarsdata"] = obj;
            Session["SearchCarsdata"] = obj;
        }
        catch (Exception EX)
        {
        }

        return obj;
    }


    //------------------------Starts 25-07-2013-----------------//


    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsSearchSpeed(string carMakeid, string CarModalId, string ZipCode, string WithinZip, string pageNo, string pageresultscount, string orderby)
    {
         
        var obj = new List<CarsInfo.UsedCarsInfo>();

        try
        {

            CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();


            Session["carMake"] = carMakeid;
            Session["CarModalId"] = CarModalId;
            Session["ZipCode"] = ZipCode;
            Session["WithinZip"] = WithinZip;
            string sort = string.Empty;
            if (Session["Orderby"] != null && Session["Orderby"] != "")
            {
                orderby = Session["Orderby"].ToString();
            }
            else
            {
                Session["Orderby"] = "price";
            }
            if (Session["sort"] != null)
            {
                sort = Session["sort"].ToString();
            }
            else
            {
                sort = "desc";
            }

            string IPAddress = string.Empty;
            string SearchName = string.Empty;

            String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();

            IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


            GeneralFunc.SaveSearchLog(IPAddress, carMakeid, CarModalId, WithinZip, ZipCode, "Genral");

            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSpeed(carMakeid, CarModalId, ZipCode, WithinZip, pageNo, pageresultscount, orderby, sort);


            Session["SearchFullCarsdata"] = obj;
            Session["SearchCarsdata"] = obj;
        }
        catch (Exception EX)
        {
        }

        return obj;
    
    }

    //------------------------End------------------------------//







    //-----------Starts Min and Max VAlues-------------------//

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> MinandMax(string carMakeid, string CarModalId, string ZipCode, string WithinZip)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        try
        {

            CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.MinandMaxValues(carMakeid, CarModalId, ZipCode, WithinZip);


            Session["SearchFullCarsdata"] = obj;
            Session["SearchCarsdata"] = obj;
        }
        catch (Exception EX)
        {
        }

        return obj;
    }
    //-----------------------Ends---------------------------//




    //----------------Matched cars Starts 30-07-2013---------------//
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsMatchedData(string carMakeid, string CarModalId, string ZipCode, string Price)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();
        try
        {

            CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
            //Session["carMake"] = carMakeid;
            //Session["CarModalId"] = CarModalId;
            //Session["ZipCode"] = ZipCode;
            //Session["Price"] = Price;
            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchMatchedCars(carMakeid, CarModalId, ZipCode, Price);


            Session["SearchFullCarsdata"] = obj;
            Session["SearchCarsdata"] = obj;
        }
        catch (Exception EX)
        {
        }
        return obj;
    }
    //*************End*******(Padma)********************//



    //--------------------End--------------------------------------//

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetPageMultiData(int PageSize, int page)
    {
        Session["PageSize"] = PageSize;

        List<CarsInfo.UsedCarsInfo> objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchCarsdata"];



        objUsedCarsInfo = objUsedCarsInfo.Skip(PageSize * (page - 1)).Take(PageSize).ToList();

        decimal pagecount = Math.Ceiling(Convert.ToDecimal(Convert.ToDecimal(objUsedCarsInfo[0].TotalRecords) / PageSize));

        for (int i = 0; i < objUsedCarsInfo.Count; i++)
        {
            objUsedCarsInfo[i].PageCount = pagecount.ToString();
        }

        return objUsedCarsInfo;
    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetPageData(int PageSize, int page)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        if (Session["FilterOn"] != null)
        {
            if (Convert.ToInt32(Session["FilterOn"].ToString()) == 1)
            {
                ArrayList AFilter = (ArrayList)Session["Filter"];

                obj = GetCarsFilterNextSpeed(AFilter, PageSize.ToString(), page);
            }
        }
        else
        {
            CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
            string CurrentPage = page.ToString();
            string pageresultscount = PageSize.ToString();
            string Orderby = string.Empty;
            string sort = string.Empty;

            if (Session["Orderby"] != null && Session["Orderby"] != "")
            {
                Orderby = Session["Orderby"].ToString();
            }
            else
            {
                Session["Orderby"] = "price";
            }
            if (Session["sort"] != null)
            {
                sort = Session["sort"].ToString();
            }
            else
            {
                sort = "desc";
            }
            string carMakeid = Session["carMake"].ToString();
            string CarModalId = Session["CarModalId"].ToString();
            string ZipCode = Session["ZipCode"].ToString();
            string WithinZip = Session["WithinZip"].ToString();

            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, Orderby, sort);

            Session["SearchCarsdata"] = obj;
        }

        return obj;

    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetPageDataSpeed(int PageSize, int page)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        if (Session["FilterOn"] != null)
        {
            if (Convert.ToInt32(Session["FilterOn"].ToString()) == 1)
            {
                ArrayList AFilter = (ArrayList)Session["Filter"];

                obj = GetCarsFilterNextSpeed(AFilter, PageSize.ToString(), page);
            }
        }
        else
        {
            CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
            string CurrentPage = page.ToString();
            string pageresultscount = PageSize.ToString();
            string Orderby = string.Empty;
            string sort = string.Empty;

            if (Session["Orderby"] != null && Session["Orderby"] != "")
            {
                Orderby = Session["Orderby"].ToString();
            }
            else
            {
                Session["Orderby"] = "price";
            }
            if (Session["sort"] != null)
            {
                sort = Session["sort"].ToString();
            }
            else
            {
                sort = "desc";
            }
            string carMakeid = Session["carMake"].ToString();
            string CarModalId = Session["CarModalId"].ToString();
            string ZipCode = Session["ZipCode"].ToString();
            string WithinZip = Session["WithinZip"].ToString();

            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSpeed(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, Orderby, sort);

            Session["SearchCarsdata"] = obj;
        }

        return obj;

    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsAds()
    {
        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
        var obj = new List<CarsInfo.UsedCarsInfo>();

        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.GetCarAdsNew();

        return obj;

    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarBannerAds()
    {
        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
        var obj = new List<CarsInfo.UsedCarsInfo>();

        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.GetCarBannerAds();

        return obj;

    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsSearchPage()
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        obj = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        return obj;

    }
    [WebMethod(EnableSession = true)]
    public void SearchCriteriaSave(string carMakeid, string CarModalId, string ZipCode, string WithinZip)
    {
        Session["carMake"] = carMakeid;
        Session["CarModalId"] = CarModalId;
        Session["ZipCode"] = ZipCode;
        Session["WithinZip"] = WithinZip;
        Session["Orderby"] = "";
    }


    [WebMethod(EnableSession = true)]
    public ArrayList GetSearchCriteria()
    {
        ArrayList alist = new ArrayList();



        alist.Add(Session["carMake"].ToString());
        alist.Add(Session["CarModalId"].ToString());
        alist.Add(Session["ZipCode"].ToString());
        alist.Add(Session["WithinZip"].ToString());
        alist.Add(Session["Orderby"].ToString());

        return alist;


    }

    #region DataFilter


    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsFilterNext(ArrayList AFilter, string PageResultsCount, int CurrentPage)
    {
        //List<CarsInfo.UsedCarsInfo> obj = null;        
        //Session["FilterArray"] = AFilter;

        CarsFilter objCarsFilter = new CarsFilter();


        Filter objFilter = new Filter();

        List<CarsInfo.UsedCarsInfo> objFilterdata = new List<CarsInfo.UsedCarsInfo>();

        //var = new List<CarsInfo.UsedCarsInfo>();

        //List<CarsInfo.UsedCarsInfo> objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        CarsInfo.UsedCarsInfo OBJ = new CarsInfo.UsedCarsInfo();

        //IList <CarsInfo.UsedCarsInfo>  = new List<CarsInfo.UsedCarsInfo>();


        string Orderby = string.Empty;

        string sort = string.Empty;

        if (Session["Orderby"] != null && Session["Orderby"] != "")
        {
            Orderby = Session["Orderby"].ToString();
        }
        else
        {
            Session["Orderby"] = "price";
        }
        if (Session["sort"] != null)
        {
            sort = Session["sort"].ToString();
        }
        else
        {
            sort = "desc";
        }


        objCarsFilter.CurrentPage = CurrentPage.ToString();
        objCarsFilter.PageSize = PageResultsCount;
        objCarsFilter.CarMakeid = Session["carMake"].ToString();
        objCarsFilter.CarModalId = Session["CarModalId"].ToString();
        objCarsFilter.ZipCode = Session["ZipCode"].ToString();
        objCarsFilter.WithinZip = Session["WithinZip"].ToString();
        objCarsFilter.Orderby = Orderby;
        objCarsFilter.Sort = sort;



        for (int i = 0; i < AFilter.Count; i++)
        {
            switch (AFilter[i].ToString())
            {
                case "Mileage1":
                    objCarsFilter.Mileage1 = "Mileage1";
                    break;
                case "Mileage2":
                    objCarsFilter.Mileage2 = "Mileage2";
                    break;
                case "Mileage3":
                    objCarsFilter.Mileage3 = "Mileage3";
                    break;
                case "Mileage4":
                    objCarsFilter.Mileage4 = "Mileage4";
                    break;
                case "Mileage5":
                    objCarsFilter.Mileage5 = "Mileage5";
                    break;
                case "Mileage6":
                    objCarsFilter.Mileage6 = "Mileage6";
                    break;
                case "Mileage7":
                    objCarsFilter.Mileage7 = "Mileage7";
                    break;
                case "Year1a":
                    objCarsFilter.Year1a = "Year1a";
                    break;
                case "Year1b":
                    objCarsFilter.Year1b = "Year1b";
                    break;
                case "Year1":
                    objCarsFilter.Year1 = "Year1";
                    break;
                case "Year2":
                    objCarsFilter.Year2 = "Year2";
                    break;
                case "Year3":
                    objCarsFilter.Year3 = "Year3";
                    break;
                case "Year4":
                    objCarsFilter.Year4 = "Year4";
                    break;
                case "Year5":
                    objCarsFilter.Year5 = "Year5";
                    break;
                case "Year6":
                    objCarsFilter.Year6 = "Year6";
                    break;
                case "Year7":
                    objCarsFilter.Year7 = "Year7";
                    break;
                case "Price1":
                    objCarsFilter.Price1 = "Price1";
                    break;
                case "Price2":
                    objCarsFilter.Price2 = "Price2";
                    break;
                case "Price3":
                    objCarsFilter.Price3 = "Price3";
                    break;
                case "Price4":
                    objCarsFilter.Price4 = "Price4";
                    break;
                case "Price5":
                    objCarsFilter.Price5 = "Price5";
                    break;
                case "Body1":
                    objCarsFilter.Body1 = "Body1";
                    break;
                case "Body2":
                    objCarsFilter.Body2 = "Body2";
                    break;
                case "Body3":
                    objCarsFilter.Body3 = "Body3";
                    break;
                case "Body4":
                    objCarsFilter.Body4 = "Body4";
                    break;
                case "Body5":
                    objCarsFilter.Body5 = "Body5";
                    break;
                case "Body6":
                    objCarsFilter.Body6 = "Body6";
                    break;
                case "Body7":
                    objCarsFilter.Body7 = "Body7";
                    break;
                case "Body8":
                    objCarsFilter.Body8 = "Body8";
                    break;
                case "Body9":
                    objCarsFilter.Body9 = "Body9";
                    break;
                case "Fuel1":
                    objCarsFilter.Fuel1 = "Fuel1";
                    break;
                case "Fuel2":
                    objCarsFilter.Fuel2 = "Fuel2";
                    break;
                case "Fuel3":
                    objCarsFilter.Fuel3 = "Fuel3";
                    break;
                case "Fuel4":
                    objCarsFilter.Fuel4 = "Fuel4";
                    break;
                case "Fuel5":
                    objCarsFilter.Fuel5 = "Fuel5";
                    break;
                case "Seller1":
                    objCarsFilter.Seller1 = "Seller1";
                    break;
                case "Seller2":
                    objCarsFilter.Seller2 = "Seller2";
                    break;
                case "withpic":
                    objCarsFilter.WithPic = true;
                    break;
                case "withoutpic":
                    objCarsFilter.WithPic = false;
                    break;
            };
        }
        FilterCars objFilterCars = new FilterCars();

        objFilterdata = (List<CarsInfo.UsedCarsInfo>)objFilterCars.FilterSearch(objCarsFilter);

        Session["SearchCarsdata"] = objFilterdata;

        return objFilterdata;
        //
    }


   // ----------------------30-07-2013---------------//

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsFilterNextSpeed(ArrayList AFilter, string PageResultsCount, int CurrentPage)
    {
        //List<CarsInfo.UsedCarsInfo> obj = null;        
        //Session["FilterArray"] = AFilter;

        CarsFilter objCarsFilter = new CarsFilter();


        Filter objFilter = new Filter();

        List<CarsInfo.UsedCarsInfo> objFilterdata = new List<CarsInfo.UsedCarsInfo>();

        //var = new List<CarsInfo.UsedCarsInfo>();

        //List<CarsInfo.UsedCarsInfo> objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        CarsInfo.UsedCarsInfo OBJ = new CarsInfo.UsedCarsInfo();

        //IList <CarsInfo.UsedCarsInfo>  = new List<CarsInfo.UsedCarsInfo>();


        string Orderby = string.Empty;

        string sort = string.Empty;

        if (Session["Orderby"] != null && Session["Orderby"] != "")
        {
            Orderby = Session["Orderby"].ToString();
        }
        else
        {
            Session["Orderby"] = "price";
        }
        if (Session["sort"] != null)
        {
            sort = Session["sort"].ToString();
        }
        else
        {
            sort = "desc";
        }


        objCarsFilter.CurrentPage = CurrentPage.ToString();
        objCarsFilter.PageSize = PageResultsCount;
        objCarsFilter.CarMakeid = Session["carMake"].ToString();
        objCarsFilter.CarModalId = Session["CarModalId"].ToString();
        objCarsFilter.ZipCode = Session["ZipCode"].ToString();
        objCarsFilter.WithinZip = Session["WithinZip"].ToString();
        objCarsFilter.Orderby = Orderby;
        objCarsFilter.Sort = sort;

        objCarsFilter.Mileage1 = AFilter[0].ToString();
        objCarsFilter.Mileage2 = AFilter[1].ToString();

        objCarsFilter.Year1a = AFilter[2].ToString();
        objCarsFilter.Year1b = AFilter[3].ToString();

        objCarsFilter.Price1 = AFilter[4].ToString();
        objCarsFilter.Price2 = AFilter[5].ToString();

        for (int i = 0; i < AFilter.Count; i++)
        {
            switch (AFilter[i].ToString())
            {
                //case "Mileage1":
                //    objCarsFilter.Mileage1 = "Mileage1";
                //    break;
                //case "Mileage2":
                //    objCarsFilter.Mileage2 = "Mileage2";
                //    break;
                //case "Mileage3":
                //    objCarsFilter.Mileage3 = "Mileage3";
                //    break;
                //case "Mileage4":
                //    objCarsFilter.Mileage4 = "Mileage4";
                //    break;
                //case "Mileage5":
                //    objCarsFilter.Mileage5 = "Mileage5";
                //    break;
                //case "Mileage6":
                //    objCarsFilter.Mileage6 = "Mileage6";
                //    break;
                //case "Mileage7":
                //    objCarsFilter.Mileage7 = "Mileage7";
                //    break;
                //case "Year1a":
                //    objCarsFilter.Year1a = "Year1a";
                //    break;
                //case "Year1b":
                //    objCarsFilter.Year1b = "Year1b";
                //    break;
                //case "Year1":
                //    objCarsFilter.Year1 = "Year1";
                //    break;
                //case "Year2":
                //    objCarsFilter.Year2 = "Year2";
                //    break;
                //case "Year3":
                //    objCarsFilter.Year3 = "Year3";
                //    break;
                //case "Year4":
                //    objCarsFilter.Year4 = "Year4";
                //    break;
                //case "Year5":
                //    objCarsFilter.Year5 = "Year5";
                //    break;
                //case "Year6":
                //    objCarsFilter.Year6 = "Year6";
                //    break;
                //case "Year7":
                //    objCarsFilter.Year7 = "Year7";
                //    break;
                //case "Price1":
                //    objCarsFilter.Price1 = "Price1";
                //    break;
                //case "Price2":
                //    objCarsFilter.Price2 = "Price2";
                //    break;
                //case "Price3":
                //    objCarsFilter.Price3 = "Price3";
                //    break;
                //case "Price4":
                //    objCarsFilter.Price4 = "Price4";
                //    break;
                //case "Price5":
                //    objCarsFilter.Price5 = "Price5";
                //    break;
                case "Body1":
                    objCarsFilter.Body1 = "Body1";
                    break;
                case "Body2":
                    objCarsFilter.Body2 = "Body2";
                    break;
                case "Body3":
                    objCarsFilter.Body3 = "Body3";
                    break;
                case "Body4":
                    objCarsFilter.Body4 = "Body4";
                    break;
                case "Body5":
                    objCarsFilter.Body5 = "Body5";
                    break;
                case "Body6":
                    objCarsFilter.Body6 = "Body6";
                    break;
                case "Body7":
                    objCarsFilter.Body7 = "Body7";
                    break;
                case "Body8":
                    objCarsFilter.Body8 = "Body8";
                    break;
                case "Body9":
                    objCarsFilter.Body9 = "Body9";
                    break;
                case "Fuel1":
                    objCarsFilter.Fuel1 = "Fuel1";
                    break;
                case "Fuel2":
                    objCarsFilter.Fuel2 = "Fuel2";
                    break;
                case "Fuel3":
                    objCarsFilter.Fuel3 = "Fuel3";
                    break;
                case "Fuel4":
                    objCarsFilter.Fuel4 = "Fuel4";
                    break;
                case "Fuel5":
                    objCarsFilter.Fuel5 = "Fuel5";
                    break;
                case "Seller1":
                    objCarsFilter.Seller1 = "Seller1";
                    break;
                case "Seller2":
                    objCarsFilter.Seller2 = "Seller2";
                    break;
                case "withpic":
                    objCarsFilter.WithPic = true;
                    break;
                case "withoutpic":
                    objCarsFilter.WithPic = false;
                    break;
            };
        }
        FilterCars objFilterCars = new FilterCars();

        objFilterdata = (List<CarsInfo.UsedCarsInfo>)objFilterCars.FilterSearchSpeed(objCarsFilter);

        Session["SearchCarsdata"] = objFilterdata;

        return objFilterdata;
        //
    }


    //-----------------------End--------------------//

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsFilter(ArrayList AFilter, string PageResultsCount)
    {
        //List<CarsInfo.UsedCarsInfo> obj = null;        
        //Session["FilterArray"] = AFilter;

        CarsFilter objCarsFilter = new CarsFilter();

        if (Session["FilterOn"] == null)
        {
            Session["FilterOn"] = 1;
        }

        Session["Filter"] = AFilter;

        Filter objFilter = new Filter();

        List<CarsInfo.UsedCarsInfo> objFilterdata = new List<CarsInfo.UsedCarsInfo>();

        //var = new List<CarsInfo.UsedCarsInfo>();

        //List<CarsInfo.UsedCarsInfo> objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        CarsInfo.UsedCarsInfo OBJ = new CarsInfo.UsedCarsInfo();

        //IList <CarsInfo.UsedCarsInfo>  = new List<CarsInfo.UsedCarsInfo>();


        string Orderby = string.Empty;

        string sort = string.Empty;

        if (Session["Orderby"] != null && Session["Orderby"] != "")
        {
            Orderby = Session["Orderby"].ToString();
        }
        else
        {
            Session["Orderby"] = "price";
        }
        if (Session["sort"] != null)
        {
            sort = Session["sort"].ToString();
        }
        else
        {
            sort = "desc";
        }


        objCarsFilter.CurrentPage = "1";
        objCarsFilter.PageSize = PageResultsCount;
        objCarsFilter.CarMakeid = Session["carMake"].ToString();
        objCarsFilter.CarModalId = Session["CarModalId"].ToString();
        objCarsFilter.ZipCode = Session["ZipCode"].ToString();
        objCarsFilter.WithinZip = Session["WithinZip"].ToString();
        objCarsFilter.Orderby = Orderby;
        objCarsFilter.Sort = sort;



        for (int i = 0; i < AFilter.Count; i++)
        {
            switch (AFilter[i].ToString())
            {
                case "Mileage1":
                    objCarsFilter.Mileage1 = "Mileage1";
                    break;
                case "Mileage2":
                    objCarsFilter.Mileage2 = "Mileage2";
                    break;
                case "Mileage3":
                    objCarsFilter.Mileage3 = "Mileage3";
                    break;
                case "Mileage4":
                    objCarsFilter.Mileage4 = "Mileage4";
                    break;
                case "Mileage5":
                    objCarsFilter.Mileage5 = "Mileage5";
                    break;
                case "Mileage6":
                    objCarsFilter.Mileage6 = "Mileage6";
                    break;
                case "Mileage7":
                    objCarsFilter.Mileage7 = "Mileage7";
                    break;
                case "Year1a":
                    objCarsFilter.Year1a = "Year1a";
                    break;
                case "Year1b":
                    objCarsFilter.Year1b = "Year1b";
                    break;
                case "Year1":
                    objCarsFilter.Year1 = "Year1";
                    break;
                case "Year2":
                    objCarsFilter.Year2 = "Year2";
                    break;
                case "Year3":
                    objCarsFilter.Year3 = "Year3";
                    break;
                case "Year4":
                    objCarsFilter.Year4 = "Year4";
                    break;
                case "Year5":
                    objCarsFilter.Year5 = "Year5";
                    break;
                case "Year6":
                    objCarsFilter.Year6 = "Year6";
                    break;
                case "Year7":
                    objCarsFilter.Year7 = "Year7";
                    break;
                case "Price1":
                    objCarsFilter.Price1 = "Price1";
                    break;
                case "Price2":
                    objCarsFilter.Price2 = "Price2";
                    break;
                case "Price3":
                    objCarsFilter.Price3 = "Price3";
                    break;
                case "Price4":
                    objCarsFilter.Price4 = "Price4";
                    break;
                case "Price5":
                    objCarsFilter.Price5 = "Price5";
                    break;
                case "Body1":
                    objCarsFilter.Body1 = "Body1";
                    break;
                case "Body2":
                    objCarsFilter.Body2 = "Body2";
                    break;
                case "Body3":
                    objCarsFilter.Body3 = "Body3";
                    break;
                case "Body4":
                    objCarsFilter.Body4 = "Body4";
                    break;
                case "Body5":
                    objCarsFilter.Body5 = "Body5";
                    break;
                case "Body6":
                    objCarsFilter.Body6 = "Body6";
                    break;
                case "Body7":
                    objCarsFilter.Body7 = "Body7";
                    break;
                case "Body8":
                    objCarsFilter.Body8 = "Body8";
                    break;
                case "Body9":
                    objCarsFilter.Body9 = "Body9";
                    break;
                case "Fuel1":
                    objCarsFilter.Fuel1 = "Fuel1";
                    break;
                case "Fuel2":
                    objCarsFilter.Fuel2 = "Fuel2";
                    break;
                case "Fuel3":
                    objCarsFilter.Fuel3 = "Fuel3";
                    break;
                case "Fuel4":
                    objCarsFilter.Fuel4 = "Fuel4";
                    break;
                case "Fuel5":
                    objCarsFilter.Fuel5 = "Fuel5";
                    break;
                case "Seller1":
                    objCarsFilter.Seller1 = "Seller1";
                    break;
                case "Seller2":
                    objCarsFilter.Seller2 = "Seller2";
                    break;
                case "withpic":
                    objCarsFilter.WithPic = true;
                    break;
                case "withoutpic":
                    objCarsFilter.WithPic = false;
                    break;
            };
        }
        FilterCars objFilterCars = new FilterCars();

        objFilterdata = (List<CarsInfo.UsedCarsInfo>)objFilterCars.FilterSearch(objCarsFilter);

        Session["SearchCarsdata"] = objFilterdata;

        return objFilterdata;
        //
    }


    //-----------------------------Starts---- 30-07-2013--------------------------//
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsFilterSpeed(ArrayList AFilter, string PageResultsCount)
    {
        //List<CarsInfo.UsedCarsInfo> obj = null;        
        //Session["FilterArray"] = AFilter;

        CarsFilter objCarsFilter = new CarsFilter();

        if (Session["FilterOn"] == null)
        {
            Session["FilterOn"] = 1;
        }

        Session["Filter"] = AFilter;

        Filter objFilter = new Filter();

        List<CarsInfo.UsedCarsInfo> objFilterdata = new List<CarsInfo.UsedCarsInfo>();

        //var = new List<CarsInfo.UsedCarsInfo>();

        //List<CarsInfo.UsedCarsInfo> objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        CarsInfo.UsedCarsInfo OBJ = new CarsInfo.UsedCarsInfo();

        //IList <CarsInfo.UsedCarsInfo>  = new List<CarsInfo.UsedCarsInfo>();


        string Orderby = string.Empty;

        string sort = string.Empty;

        if (Session["Orderby"] != null && Session["Orderby"] != "")
        {
            Orderby = Session["Orderby"].ToString();
        }
        else
        {
            Session["Orderby"] = "price";
        }
        if (Session["sort"] != null)
        {
            sort = Session["sort"].ToString();
        }
        else
        {
            sort = "desc";
        }


        objCarsFilter.CurrentPage = "1";
        objCarsFilter.PageSize = PageResultsCount;
        objCarsFilter.CarMakeid = Session["carMake"].ToString();
        objCarsFilter.CarModalId = Session["CarModalId"].ToString();
        objCarsFilter.ZipCode = Session["ZipCode"].ToString();
        objCarsFilter.WithinZip = Session["WithinZip"].ToString();
        objCarsFilter.Orderby = Orderby;
        objCarsFilter.Sort = sort;
        //objCarsFilter.Mileage1 = AFilter[4];

        //string A1 = AFilter[4].ToString();
        objCarsFilter.Mileage1 = AFilter[0].ToString();
        objCarsFilter.Mileage2 = AFilter[1].ToString();

        objCarsFilter.Year1a = AFilter[2].ToString();
        objCarsFilter.Year1b = AFilter[3].ToString();

        objCarsFilter.Price1 = AFilter[4].ToString();
        objCarsFilter.Price2 = AFilter[5].ToString();

        for (int i = 0; i < AFilter.Count; i++)
        {
            switch (AFilter[i].ToString())
            {
                //case "Mileage1":
                //    objCarsFilter.Mileage1 = "Mileage1";
                //    break;
                //case "Mileage2":
                //    objCarsFilter.Mileage2 = "Mileage2";
                //    break;
                //case "Mileage3":
                //    objCarsFilter.Mileage3 = "Mileage3";
                //    break;
                //case "Mileage4":
                //    objCarsFilter.Mileage4 = "Mileage4";
                //    break;
                //case "Mileage5":
                //    objCarsFilter.Mileage5 = "Mileage5";
                //    break;
                //case "Mileage6":
                //    objCarsFilter.Mileage6 = "Mileage6";
                //    break;
                //case "Mileage7":
                //    objCarsFilter.Mileage7 = "Mileage7";
                //    break;
                //case "Year1a":
                //    objCarsFilter.Year1a = "Year1a";
                //    break;
                //case "Year1b":
                //    objCarsFilter.Year1b = "Year1b";
                //    break;
                //case "Year1":
                //    objCarsFilter.Year1 = "Year1";
                //    break;
                //case "Year2":
                //    objCarsFilter.Year2 = "Year2";
                //    break;
                //case "Year3":
                //    objCarsFilter.Year3 = "Year3";
                //    break;
                //case "Year4":
                //    objCarsFilter.Year4 = "Year4";
                //    break;
                //case "Year5":
                //    objCarsFilter.Year5 = "Year5";
                //    break;
                //case "Year6":
                //    objCarsFilter.Year6 = "Year6";
                //    break;
                //case "Year7":
                //    objCarsFilter.Year7 = "Year7";
                //    break;
                //case "Price1":
                //    objCarsFilter.Price1 = "Price1";
                //    break;
                //case "Price2":
                //    objCarsFilter.Price2 = "Price2";
                //    break;
                //case "Price3":
                //    objCarsFilter.Price3 = "Price3";
                //    break;
                //case "Price4":
                //    objCarsFilter.Price4 = "Price4";
                //    break;
                //case "Price5":
                //    objCarsFilter.Price5 = "Price5";
                //    break;
                case "Body1":
                    objCarsFilter.Body1 = "Body1";
                    break;
                case "Body2":
                    objCarsFilter.Body2 = "Body2";
                    break;
                case "Body3":
                    objCarsFilter.Body3 = "Body3";
                    break;
                case "Body4":
                    objCarsFilter.Body4 = "Body4";
                    break;
                case "Body5":
                    objCarsFilter.Body5 = "Body5";
                    break;
                case "Body6":
                    objCarsFilter.Body6 = "Body6";
                    break;
                case "Body7":
                    objCarsFilter.Body7 = "Body7";
                    break;
                case "Body8":
                    objCarsFilter.Body8 = "Body8";
                    break;
                case "Body9":
                    objCarsFilter.Body9 = "Body9";
                    break;
                case "Fuel1":
                    objCarsFilter.Fuel1 = "Fuel1";
                    break;
                case "Fuel2":
                    objCarsFilter.Fuel2 = "Fuel2";
                    break;
                case "Fuel3":
                    objCarsFilter.Fuel3 = "Fuel3";
                    break;
                case "Fuel4":
                    objCarsFilter.Fuel4 = "Fuel4";
                    break;
                case "Fuel5":
                    objCarsFilter.Fuel5 = "Fuel5";
                    break;
                case "Seller1":
                    objCarsFilter.Seller1 = "Seller1";
                    break;
                case "Seller2":
                    objCarsFilter.Seller2 = "Seller2";
                    break;
                case "withpic":
                    objCarsFilter.WithPic = true;
                    break;
                case "withoutpic":
                    objCarsFilter.WithPic = false;
                    break;
            };
        }
        FilterCars objFilterCars = new FilterCars();

        objFilterdata = (List<CarsInfo.UsedCarsInfo>)objFilterCars.FilterSearchSpeed(objCarsFilter);

        Session["SearchCarsdata"] = objFilterdata;

        return objFilterdata;
        //
    }



    //------------------------------End---------------------------------//

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsFilterMulti(ArrayList AFilter, int PageResultsCount)
    {
        //List<CarsInfo.UsedCarsInfo> obj = null;        
        Session["FilterArray"] = AFilter;

        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();

        List<CarsInfo.UsedCarsInfo> obAddedItems = new List<CarsInfo.UsedCarsInfo>();

        List<CarsInfo.UsedCarsInfo> objMileage = new List<CarsInfo.UsedCarsInfo>();
        List<CarsInfo.UsedCarsInfo> objYear = new List<CarsInfo.UsedCarsInfo>();
        List<CarsInfo.UsedCarsInfo> objPrice = new List<CarsInfo.UsedCarsInfo>();
        List<CarsInfo.UsedCarsInfo> objBodytype = new List<CarsInfo.UsedCarsInfo>();
        List<CarsInfo.UsedCarsInfo> objFuelType = new List<CarsInfo.UsedCarsInfo>();
        List<CarsInfo.UsedCarsInfo> objSellerType = new List<CarsInfo.UsedCarsInfo>();


        Filter objFilter = new Filter();
        string carMakeid = string.Empty;
        string CarModalId = string.Empty;
        string ZipCode = string.Empty;
        string WithinZip = string.Empty;
        //Session["Orderby"] = Orderby;
        carMakeid = Session["carMake"].ToString();
        CarModalId = Session["CarModalId"].ToString();
        ZipCode = Session["ZipCode"].ToString();
        WithinZip = Session["WithinZip"].ToString();

        List<CarsInfo.UsedCarsInfo> objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchFullCarsdata"];

        ///objUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchMultiUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, "1", "25", "Price");


        CarsInfo.UsedCarsInfo OBJ = new CarsInfo.UsedCarsInfo();

        List<CarsInfo.UsedCarsInfo> objFilterdata = new List<CarsInfo.UsedCarsInfo>();

        for (int i = 0; i < AFilter.Count; i++)
        {

            //objMileage = objFilter.FilterData(obj, arr[i].ToString());

            switch (AFilter[i].ToString())
            {
                case "Mileage1":


                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) < Convert.ToDecimal(5000));
                    obAddedItems = objMileage;

                    break;

                case "Mileage2":

                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) >= 5000 && Convert.ToDecimal(x.Mileage) < 10000);
                    obAddedItems.AddRange(objMileage);
                    //obAddedItems.AddRange(objMileage[0]);

                    break;

                case "Mileage3":

                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) >= 10000 && Convert.ToDecimal(x.Mileage) < 25000);
                    obAddedItems.AddRange(objMileage);
                    break;


                case "Mileage4":
                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) >= 25000 && Convert.ToDecimal(x.Mileage) < 50000);
                    obAddedItems.AddRange(objMileage);
                    break;

                case "Mileage5":
                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) >= 50000 && Convert.ToDecimal(x.Mileage) < 75000);
                    obAddedItems.AddRange(objMileage);

                    break;

                case "Mileage6":

                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) >= 75000 && Convert.ToDecimal(x.Mileage) < 100000);
                    obAddedItems.AddRange(objMileage);
                    break;

                case "Mileage7":

                    objMileage = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Mileage) >= 100000);
                    obAddedItems.AddRange(objMileage);
                    break;//--30
                case "Year1a":

                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2011);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2013);
                        objYear.AddRange(objFilterdata);
                    }
                    break;

                case "Year1b":

                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2011);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2012);
                        objYear.AddRange(objFilterdata);
                    }




                    //objYear = objUsedCarsInfoFiltered;

                    break;

                case "Year1":

                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2011);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2011);
                        objYear.AddRange(objFilterdata);
                    }




                    //objYear = objUsedCarsInfoFiltered;

                    break;

                case "Year2":
                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2010);
                    //    objYear.AddRange(objFilterdata);

                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2010);
                        objYear.AddRange(objFilterdata);
                    }


                    //obAddedItems = Additem(objYear);
                    break;

                case "Year3":
                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2009);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2009);
                        objYear.AddRange(objFilterdata);
                    }

                    break;


                case "Year4":
                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2008);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2008);
                        objYear.AddRange(objFilterdata);
                    }
                    break;

                case "Year5":
                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2007);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) == 2007);
                        objYear.AddRange(objFilterdata);
                    }
                    break;

                case "Year6":
                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) >= 2002 && Convert.ToInt32(x.YearOfMake) <= 2006);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) >= 2002 && Convert.ToInt32(x.YearOfMake) <= 2006);
                        objYear.AddRange(objFilterdata);
                    }


                    break;

                case "Year7":


                    //if (obAddedItems.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToInt32(x.YearOfMake) < 2002);
                    //    objYear.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = obAddedItems.FindAll(x => Convert.ToInt32(x.YearOfMake) < 2002);
                        objYear.AddRange(objFilterdata);
                    }

                    break;

                case "Price1":

                    //if (objYear.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Price) < 20000);
                    //    objPrice.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objYear.FindAll(x => Convert.ToDecimal(x.Price) < 20000);
                        objPrice.AddRange(objFilterdata);
                    }


                    break;

                case "Price2":

                    //if (objYear.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Price) >= 20000 && Convert.ToDecimal(x.Price) < 50000);
                    //    objPrice.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objYear.FindAll(x => Convert.ToDecimal(x.Price) >= 20000 && Convert.ToDecimal(x.Price) < 50000);
                        objPrice.AddRange(objFilterdata);

                    }

                    break;

                case "Price3":
                    //if (objYear.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Price) >= 50000 && Convert.ToDecimal(x.Price) < 75000);
                    //    objPrice.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objYear.FindAll(x => Convert.ToDecimal(x.Price) >= 50000 && Convert.ToDecimal(x.Price) < 75000);
                        objPrice.AddRange(objFilterdata);
                    }

                    break;


                case "Price4":
                    if (objYear.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Price) >= 75000 && Convert.ToDecimal(x.Price) < 100000);
                    //    objPrice.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objYear.FindAll(x => Convert.ToDecimal(x.Price) >= 75000 && Convert.ToDecimal(x.Price) < 100000);
                        objPrice.AddRange(objFilterdata);
                    }

                    break;

                case "Price5":
                    //if (objYear.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => Convert.ToDecimal(x.Price) >= 100000);
                    //    objPrice = objFilterdata;
                    //}
                    //else
                    {
                        objFilterdata = objYear.FindAll(x => Convert.ToDecimal(x.Price) >= 100000);
                        objPrice.AddRange(objFilterdata);
                    }

                    break;

                case "Body1":
                    //if (objPrice.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Convertible");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Convertible");
                        objBodytype.AddRange(objFilterdata);
                    }
                    break;

                case "Body2":
                    //if (objPrice.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Coupe");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Coupe");
                        objBodytype.AddRange(objFilterdata);
                    }

                    break;

                case "Body3":
                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Hatchback");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    // else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Hatchback");
                        objBodytype.AddRange(objFilterdata);
                    }

                    break;


                case "Body4":
                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Sedan");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Sedan");
                        objBodytype.AddRange(objFilterdata);
                    }
                    break;

                case "Body5":
                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "SUV");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "SUV");
                        objBodytype.AddRange(objFilterdata);
                    }


                    break;

                case "Body6":

                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Truck");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Truck");
                        objBodytype.AddRange(objFilterdata);
                    }


                    break;

                case "Body7":

                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Van");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Van");
                        objBodytype.AddRange(objFilterdata);
                    }


                    break;

                case "Body8":

                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Wagon");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Wagon");
                        objBodytype.AddRange(objFilterdata);
                    }

                    break;


                case "Body9":

                    //if (objPrice.Count == 0)
                    //{

                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Bodytype.Trim()) == "Other");
                    //    objBodytype.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objPrice.FindAll(x => (x.Bodytype.Trim()) == "Other");
                        objBodytype.AddRange(objFilterdata);
                    }


                    break;

                case "Fuel1":
                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Fueltype.Trim()) == "Diesel");
                    //    objFuelType.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objBodytype.FindAll(x => (x.Fueltype.Trim()) == "Diesel");
                        objFuelType.AddRange(objFilterdata);
                    }
                    break;

                case "Fuel2":
                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Fueltype.Trim()) == "Petrol");
                    //    objFuelType.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objBodytype.FindAll(x => (x.Fueltype.Trim()) == "Petrol");
                        objFuelType.AddRange(objFilterdata);
                    }
                    //objFilterdata = objBodytype.FindAll(x => (x.Fueltype.Trim()) == "Petrol");

                    break;

                case "Fuel3":
                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Fueltype.Trim()) == "Hybrid");
                    //    objFuelType.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objBodytype.FindAll(x => (x.Fueltype.Trim()) == "Hybrid");
                        objFuelType.AddRange(objFilterdata);
                    }

                    break;
                case "Fuel4":

                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Fueltype.Trim()) == "Electric");
                    //    objFuelType.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objBodytype.FindAll(x => (x.Fueltype.Trim()) == "Electric");
                        objFuelType.AddRange(objFilterdata);
                    }

                    //objFuelType.AddRange(objFilterdata);
                    break;

                case "Fuel5":

                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.Fueltype.Trim()) == "Other");
                    //    objFuelType.AddRange(objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objBodytype.FindAll(x => (x.Fueltype.Trim()) == "Other");
                        objFuelType.AddRange(objFilterdata);
                    }

                    break;

                case "Seller1":
                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.SellerType.Trim()) == "Invidual");

                    //    objSellerType .AddRange( objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objFuelType.FindAll(x => (x.SellerType.Trim()) == "Private Seller");

                        objSellerType.AddRange(objFilterdata);
                    }

                    break;

                case "Seller2":
                    //if (objBodytype.Count == 0)
                    //{
                    //    objFilterdata = objUsedCarsInfo.FindAll(x => (x.SellerType.Trim()) == "Dealers");

                    //    objSellerType .AddRange( objFilterdata);
                    //}
                    //else
                    {
                        objFilterdata = objFuelType.FindAll(x => (x.SellerType.Trim()) == "Dealers");

                        objSellerType.AddRange(objFilterdata);
                    }

                    //objFilterdata = objFuelType.FindAll(x => (x.SellerType.Trim()) == "");

                    break;
            };
            //objMileage
        }
        Session["SearchCarsdata"] = objSellerType;

        //if (Session["SortType"] != null)
        //{
        //    objSellerType = SortData(Session["SortType"].ToString(), PageResultsCount);
        //}

        //objSellerType = pagingdata(PageResultsCount, 1, objSellerType);

        return objSellerType;
        //
    }

    #endregion DataFilter

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sCarid"></param>
    /// <returns></returns>


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> SearchedCar()
    {
        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchedData"];

        return obUsedCarsInfo;
    }

    [WebMethod(EnableSession = true)]
    public bool CheckZips(string zipId)
    {
        ZipCodesBL objZipCodesBL = new ZipCodesBL();

        List<ZipcodeDistancesInfo> objZipCode = (List<CarsInfo.ZipcodeDistancesInfo>)objZipCodesBL.GetZips(zipId);


        if (objZipCode.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    [WebMethod(EnableSession = true)]
    public ArrayList GetCarFeatures(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();
        ArrayList arr = new ArrayList();
        ds = objCarFeatures.GetCarFeatures(sCarId);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr.Add(ds.Tables[0].Rows[i]["FeatureTypeName"].ToString() + "," + ds.Tables[0].Rows[i]["FeatureName"].ToString());
            }
        }
        return arr;
    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetRecentListings()
    {
        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
        var obj = new List<CarsInfo.UsedCarsInfo>();

        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.GetRecentListings();

        return obj;

    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public bool SaveZip(string zipId)
    {
        Session["zipId"] = zipId;

        return true;
    }



    [WebMethod(EnableSession = true)]
    public ArrayList GetNearCities()
    {
        ArrayList Al = new ArrayList();
        DataSet dsCities = new DataSet();
        CarsBL.Transactions.NearZonesBL objNearZonesBL = new CarsBL.Transactions.NearZonesBL();
        if (Session["zipId"] != null)
        {
            dsCities = objNearZonesBL.GetNearCities(Session["zipId"].ToString());

            if (dsCities.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsCities.Tables[0].Rows.Count; i++)
                {
                    Al.Add(dsCities.Tables[0].Rows[i][0].ToString() + ',' + dsCities.Tables[0].Rows[i][1].ToString() + ',' + dsCities.Tables[0].Rows[i][2].ToString());
                }
            }



        }

        //CarsBL.Transactions. objCarsearch = new CarsBL.UsedCarsSearch();
        return Al;
    }


    [WebMethod(EnableSession = true)]
    public ArrayList GetNearStates()
    {
        ArrayList Al = new ArrayList();
        DataSet dsCities = new DataSet();
        CarsBL.Transactions.NearZonesBL objNearZonesBL = new CarsBL.Transactions.NearZonesBL();
        if (Session["zipId"] != null)
        {
            dsCities = objNearZonesBL.GetNearStates(Session["zipId"].ToString());

            if (dsCities.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsCities.Tables[0].Rows.Count; i++)
                {
                    Al.Add(dsCities.Tables[0].Rows[i][0].ToString() + ',' + dsCities.Tables[0].Rows[i][1].ToString() + ',' + dsCities.Tables[0].Rows[i][2].ToString() + ',' + dsCities.Tables[0].Rows[i][3].ToString());
                }

            }
        }
        ///XmlWriteMode OBJ = new XmlWriteMode();    

        //CarsBL.Transactions. objCarsearch = new CarsBL.UsedCarsSearch();
        return Al;
    }

    [WebMethod(EnableSession = true)]
    public ArrayList GetCarFeatures_New(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();

        ArrayList arr = new ArrayList();
        ds = objCarFeatures.GetCarFeatures_New(sCarId);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr.Add(ds.Tables[0].Rows[i]["FeatureTypeName"].ToString() + "," + ds.Tables[0].Rows[i]["FeatureName"].ToString());
            }
        }

        return arr;
    }

    [WebMethod(EnableSession = true)]
    public ArrayList GetCarFeaturesDealer(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();
        ArrayList arr = new ArrayList();
        ds = objCarFeatures.GetCarFeaturesDealer(sCarId);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr.Add(ds.Tables[0].Rows[i]["FeatureTypeName"].ToString() + "," + ds.Tables[0].Rows[i]["FeatureName"].ToString());
            }
        }
        return arr;
    }
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> FindCarIDNew(string sCarid)
    {

        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfo>();
        UsedCarsSearch obj = new UsedCarsSearch();
        //if (Session["SearchCarsdata"] != null)
        //{
        //    obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchCarsdata"];

        //    obUsedCarsInfo = obUsedCarsInfo.FindAll(p => p.Carid == Convert.ToInt32(sCarid));

        //    Session["SearchedData"] = obUsedCarsInfo;
        //}
        //else
        //{
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)obj.FindCarIDNew(sCarid);

        // }

        return obUsedCarsInfo;
    }

    [WebMethod(EnableSession = true)]
    public void SubScribeNoShow()
    {
        Session[Constants.Subscribe] = 1;
    }


    [WebMethod(EnableSession = true)]
    public string SubScribe(string PreferenceID, string sZip, string sName, string sEmail, string sPhoneNo)
    {

        Session[Constants.Subscribe] = 1;

        PreferencesBL objPreferencesBL = new PreferencesBL();

        DataSet dssub = new DataSet();

        PreferenceInfo ObjPreferncesInfo = new PreferenceInfo();

        PreferncesItemsInfo ObjPreferncesItemsInfo = new PreferncesItemsInfo();


        dssub = objPreferencesBL.GetEmailPreferencesbyEmail(sEmail);

        string sPreferenceID = string.Empty;


        if (dssub.Tables[0].Rows.Count == 0)
        {
            ObjPreferncesInfo.PreferenceID = PreferenceID;

            if (sZip != "Zip")
            {
                ObjPreferncesInfo.Zip = sZip;
            }
            if (sName != "Your Name")
            {
                ObjPreferncesInfo.Name = sName;
            }

            if (sEmail != "Your Email")
            {
                ObjPreferncesInfo.Email = sEmail;
            }

            if (sPhoneNo != "Your Phone")
            {
                ObjPreferncesInfo.Phone = sPhoneNo;
            }


            String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();

            ObjPreferncesInfo.IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


            if (HttpContext.Current.Request.Cookies["UserSettings"] == null)
            {
                HttpCookie myCookie = new HttpCookie("UserSettings");

                myCookie.Expires = DateTime.Now.AddDays(500);

                myCookie.Values.Add("Email", ObjPreferncesInfo.Email);
                myCookie.Values.Add("Name", ObjPreferncesInfo.Name);
                myCookie.Values.Add("Phone", ObjPreferncesInfo.Phone);

                HttpContext.Current.Response.Cookies.Add(myCookie);
            }


            DataSet dsPreferences = new DataSet();

            dsPreferences = objPreferencesBL.SaveSubscribe(ObjPreferncesInfo, 1);



            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(CommonVariable.FromInfoMail);


            msg.To.Add(sEmail);

            //msg.Bcc.Add("shravan@datumglobal.net");

            msg.Subject = "Successfully modified your personalized weekly email alerts - United Car Exchange.";

            msg.IsBodyHtml = true;

            string text = string.Empty;

            string VerifyPreferences = string.Empty;

            string ModifyPreferences = string.Empty;

            string PreferencesID = string.Empty;

            //VerifyPreferences = "www.unitedcarexchange.com/VerifyPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

            //ModifyPreferences = "www.unitedcarexchange.com/EmailPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

            PreferencesID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

            text = format.SendEMailPreferencesEdit(dsPreferences.Tables[0].Rows[0]["Name"].ToString(), dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString(), ref text);


            msg.Body = text.ToString();

            SmtpClient smtp = new SmtpClient();

            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
            //smtp.EnableSsl = true;
            //smtp.Send(msg);

            smtp.Host = "127.0.0.1";
            smtp.Port = 25;
            smtp.Send(msg);

            return PreferencesID;
        }
        else
        {
            return "true";

        }
    }


    [WebMethod(EnableSession = true)]
    public string SubscribeItems(string SelectedMake, string SelectedModel, string SelectedRange, string sPrefernceID, string sPrefernceItem, int i)
    {

        PreferencesBL objPreferencesBL = new PreferencesBL();

        Session[Constants.Subscribe] = 1;

        PreferncesItemsInfo ObjPreferncesItemsInfo = new PreferncesItemsInfo();

        DataSet dssub = new DataSet();

        if (SelectedMake != "0" && SelectedModel != "0")
        {

            ObjPreferncesItemsInfo.Makeid = SelectedMake;


            ObjPreferncesItemsInfo.ModelID = SelectedModel;

            ObjPreferncesItemsInfo.PriceRange = SelectedRange;

            ObjPreferncesItemsInfo.UserPreferID = sPrefernceID;


            //HiddenField hdnPreferenceID = (HiddenField)Page.FindControl("hdnPreferenceID" + i);

            ObjPreferncesItemsInfo.PreferenceID = sPrefernceItem;

            dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, true);
        }
        else
        {
            if (sPrefernceID != "")
            {
                if (SelectedMake != "0" && SelectedModel != "0")
                {
                    ObjPreferncesItemsInfo.Makeid = SelectedMake;

                    ObjPreferncesItemsInfo.ModelID = SelectedModel;

                    ObjPreferncesItemsInfo.PriceRange = SelectedRange;

                    ObjPreferncesItemsInfo.UserPreferID = sPrefernceID;

                    ObjPreferncesItemsInfo.PreferenceID = sPrefernceID;

                    dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, false);
                }
            }
        }
        return i.ToString();
    }
    [WebMethod(EnableSession = true)]
    public bool ReferFriend(string txtReferfrn)
    {

        MailMessage message = new MailMessage();
        clsMailFormats objMail = new clsMailFormats();

        message.From = new MailAddress(CommonVariable.FromInfoMail);

        message.To.Add(Convert.ToString(txtReferfrn.Trim()));

        message.Subject = "Welcome to United Car Exchange";

        message.IsBodyHtml = true;
        string strMail = string.Empty;

        objMail.SendReferFriend(txtReferfrn.Trim(), ref   strMail);

        message.Body = strMail.ToString();

        SmtpClient smtp = new SmtpClient();

        ////smtp.Host = "smtp.gmail.com";
        ////smtp.Port = 587;
        ////smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
        ////smtp.EnableSsl = true;
        ////smtp.Send(message);

        smtp.Host = "127.0.0.1";
        smtp.Port = 25;
        smtp.Send(message);


        return true;
    }
    [WebMethod]
    public string CheckAlreadySubscribeEmail(string sEmail)
    {
        PreferencesBL objPreferencesBL = new PreferencesBL();
        DataSet dssub = new DataSet();

        dssub = objPreferencesBL.GetEmailPreferencesbyEmail(sEmail);
        string sPreferenceID = string.Empty;


        if (dssub.Tables[0].Rows.Count > 0)
        {
            sPreferenceID = dssub.Tables[0].Rows[0]["UserPreferID"].ToString();
        }
        else
        {
            sPreferenceID = "";
        }

        return sPreferenceID;




    }
    

}

