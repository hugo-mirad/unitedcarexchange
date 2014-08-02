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

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<MakesInfo> GetMakes()
    {
        var obj = new List<MakesInfo>();
        
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
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    [WebMethod(EnableSession = true)]
    public List<CategoryInfo> GetCategory()
    {
        var obj = new List<CategoryInfo>();

        //MakesInfo objMakes = new MakesInfo();
        CategoryBL objCategory = new CategoryBL();
        if (Session["CategoryInfo"] == null)
        {
            obj = (List<CategoryInfo>)objCategory.GetCategory();
            Session["CategoryInfo"] = obj;
        }
        else
        {
            obj = (List<CategoryInfo>)Session["CategoryInfo"];

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
        string VehicleType = Session["VehicleType"].ToString();
        string ZipCode = Session["ZipCode"].ToString();
        string WithinZip = Session["WithinZip"].ToString();
        string CategoryID = Session["CategoryID"].ToString();




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
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Price", "asc", VehicleType, CategoryID);
                //rderBy(person => person.LastName);

                break;
            case "2":
                Session["Orderby"] = "Price";
                Session["sort"] = "desc";

                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Price", "desc", VehicleType, CategoryID);
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Price).Reverse().ToList();
                //<option value="2">Price high to low</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Price desc");

                break;
            case "3":
                Session["Orderby"] = "YearOfMake";
                Session["sort"] = "asc";
                //<option value="3">Year old to new</option>
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "YearOfMake", "asc", VehicleType, CategoryID);
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.YearOfMake).ToList();
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake desc");

                break;
            case "4":
                Session["Orderby"] = "YearOfMake";
                Session["sort"] = "desc";
                //<option value="4">Year new to old</option>
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "YearOfMake", "desc", VehicleType, CategoryID);
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "YearOfMake asc");
                break;
            case "5":
                Session["Orderby"] = "Mileage";
                Session["sort"] = "asc";
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Mileage", "asc", VehicleType, CategoryID);
                //obUsedCarsInfo = obUsedCarsInfo.OrderBy(p => p.Mileage).ToList();
                //<option value="5">Mileage low to high</option>
                //Extensions.Extensions.OrderBy(obUsedCarsInfo, "Mileage desc");
                break;
            case "6":
                Session["Orderby"] = "Mileage";
                Session["sort"] = "desc";
                obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCarsSort(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, "Mileage", "desc", VehicleType, CategoryID);
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
    public List<CarsInfo.UsedCarsInfo> GetCarsSearch(string carMakeid, string CarModalId, string ZipCode, string WithinZip, string pageNo, string pageresultscount, string orderby, string VehicleType, string CategoryID)
    {

        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();

        var obj = new List<CarsInfo.UsedCarsInfo>();

        Session["carMake"] = carMakeid;
        Session["CarModalId"] = CarModalId;
        Session["ZipCode"] = ZipCode;
        Session["WithinZip"] = WithinZip;
        Session["VehicleType"] = VehicleType;
        if (CategoryID == "0")
        {
            Session["CategoryID"] = "Any Category";
        }
        else
        {
            Session["CategoryID"] = CategoryID;
        }


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
        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, pageNo, pageresultscount, orderby, sort, VehicleType, Session["CategoryID"].ToString());


        Session["SearchFullCarsdata"] = obj;
        Session["SearchCarsdata"] = obj;
        return obj;
    }

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

                obj = GetCarsFilterNext(AFilter, PageSize.ToString(), page);
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
            string VehicleType = Session["VehicleType"].ToString();
            string CategoryID = Session["CategoryID"].ToString();


            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, CurrentPage, pageresultscount, Orderby, sort, VehicleType, CategoryID);


            Session["SearchCarsdata"] = obj;
        }

        return obj;

    }
    [WebMethod(EnableSession = true)]
    private int sessionTimeout()
    {

        int timeout = 0;

        timeout = Session.Timeout;


        return timeout;
    }


    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UsedCarsInfo> GetCarsAds()
    {
        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();
        var obj = new List<CarsInfo.UsedCarsInfo>();

        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.GetCarAds();

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
    public void SearchCriteriaSave(string carMakeid, string CarModalId, string ZipCode, string WithinZip, string VehicleType, string CategoryID)
    {
        Session["carMake"] = carMakeid;
        Session["CarModalId"] = CarModalId;
        Session["ZipCode"] = ZipCode;
        Session["WithinZip"] = WithinZip;
        Session["Orderby"] = "";
        Session["VehicleType"] = VehicleType;

        if (CategoryID == "0")
        {
            Session["CategoryID"] = "Any Category";
        }
        else
        {
            Session["CategoryID"] = CategoryID;
        }


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
        objCarsFilter.VehicleType = Session["VehicleType"].ToString();
        objCarsFilter.Sort = sort;
        objCarsFilter.Category = Session["CategoryID"].ToString();


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
                case "Length1":
                    objCarsFilter.Length1 = "Length1";
                    break;
                case "Length2":
                    objCarsFilter.Length2 = "Length2";
                    break;
                case "Length3":
                    objCarsFilter.Length3 = "Length3";
                    break;
                case "Length4":
                    objCarsFilter.Length4 = "Length4";
                    break;
                case "Length5":
                    objCarsFilter.Length5 = "Length5";
                    break;
                case "Length6":
                    objCarsFilter.Length6 = "Length6";
                    break;
                case "Length7":
                    objCarsFilter.Length7 = "Length7";
                    break;
                case "Length8":
                    objCarsFilter.Length8 = "Length8";
                    break;
                case "Length9":
                    objCarsFilter.Length9 = "Length9";
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
        objCarsFilter.VehicleType = Session["VehicleType"].ToString();

        objCarsFilter.Category = Session["CategoryID"].ToString();


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
                case "Length1":
                    objCarsFilter.Length1 = "Length1";
                    break;
                case "Length2":
                    objCarsFilter.Length2 = "Length2";
                    break;
                case "Length3":
                    objCarsFilter.Length3 = "Length3";
                    break;
                case "Length4":
                    objCarsFilter.Length4 = "Length4";
                    break;
                case "Length5":
                    objCarsFilter.Length5 = "Length5";
                    break;
                case "Length6":
                    objCarsFilter.Length6 = "Length6";
                    break;
                case "Length7":
                    objCarsFilter.Length7 = "Length7";
                    break;
                case "Length8":
                    objCarsFilter.Length8 = "Length8";
                    break;
                case "Length9":
                    objCarsFilter.Length9 = "Length9";
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



    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
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
    public List<VehicleTypeInfo> GetVehicleType()
    {
        var obj = new List<VehicleTypeInfo>();

        VehicleTypeBL objVehicleTypeBL = new VehicleTypeBL();

        obj = (List<VehicleTypeInfo>)objVehicleTypeBL.GetVehicleType();

        return obj;
    }

    //


    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.CarPicturesInfo> GetCarPictures(string carid)
    {

        CarsBL.Transactions.CarsPictures objCarsPictures = new CarsBL.Transactions.CarsPictures();

        var obj = new List<CarsInfo.CarPicturesInfo>();


        obj = (List<CarsInfo.CarPicturesInfo>)objCarsPictures.GetCarPictures(Convert.ToInt32(carid));


        Session["SearchFullCarsdata"] = obj;
        Session["SearchCarsdata"] = obj;
        return obj;
    }

}

