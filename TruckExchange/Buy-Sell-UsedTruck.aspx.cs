using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using CarsBL.Transactions;


public partial class SearchCarDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CurrentPage"] = "Home";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;


            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScript.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            //http://localhost:1414/TruckExchange/SearchCarDetails.aspx?VehicleType=TRAILER&Make=Mac-Lander&ZipCode=92404&WithinZip=3&C=QPNwb63d5

            string VehicleType = Request.QueryString["VehicleType"];
            string WithinZip = Request.QueryString["WithinZip"];
            string Make = Request.QueryString["Make"];
            string ZipCode = Request.QueryString["ZipCode"];

            string C = Request.QueryString["C"];
            CarsService obj = new CarsService();

            List<CarsInfo.UsedCarsInfo> objCarInfo = new List<CarsInfo.UsedCarsInfo>();

            objCarInfo = obj.FindCarID(C.Substring(8));




            Session["zipId"] = objCarInfo[0].Zip;
            if (objCarInfo[0].Title == "")
            {
                lblTitle.Text = EmptyCheck(objCarInfo[0].Title);
                lblTitle1.Text = EmptyCheck(objCarInfo[0].Title);
                lblTitlePopUp.Text = EmptyCheck(objCarInfo[0].Title);
            }
            else
            {
                lblTitle.Text = (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper();
                lblTitle1.Text = (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper();

                lblTitlePopUp.Text = (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper();
            }

            lblPrice1.Text = "$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));

            string city = GeneralFunc.ToProper(objCarInfo[0].City);
            string address = objCarInfo[0].Address1.ToLower();
            address = GeneralFunc.ToProper(address);

            string state = objCarInfo[0].State.ToLower();

            hdnzip.Value = objCarInfo[0].Zipcode; 


            if (address != "" && address != " " && address != "  " && (city != "" || state != ""))
            {
                address = (address).Trim();
                address += "";
            }
            else
            {
                address = "";
            }

            HtmlMeta tag = new HtmlMeta();

            tag.Name = "keywords";
            tag.Content = "Buy " + lblTitle.Text.ToString() + " at unitedtruckexchange.com";
            Header.Controls.Add(tag);


            HtmlMeta tag1 = new HtmlMeta();
            tag1.Name = "description";
            tag1.Content = EmptyCheck(objCarInfo[0].Description);
            Header.Controls.Add(tag1);


            Title = "Buy " + lblTitle.Text.ToString() + " at unitedtruckexchange.com";


            // Page.Controls.Add(header); 

            if (city != "" && state != "")
            {
                city = (city).Trim();
                city += ", ";
            }
            else
            {
                city = "";
            }

            if (state != "" && state != "UN")
            {
                state += ' ';
            }




            lblSellerAddress.Text = address + "<br>" + EmptyCheck(city + "" + state.ToUpper() + "" + objCarInfo[0].Zip.ToString() + "<br>");
            lblSellerAddress1.Text = EmptyCheck(objCarInfo[0].Address2);
            lblSellerNo.Text = EmptyCheck(objCarInfo[0].Phone);
            lblSellerEmail.Text = EmptyCheck(objCarInfo[0].Email);

            lblSellerType.Text = EmptyCheck(objCarInfo[0].SellerType);

            lblSellerName.Text = EmptyCheck(objCarInfo[0].SellerName);



            //lblSellerAddress.Text = EmptyCheck(objCarInfo[0].Address1);

            lblAxle.Text = (EmptyCheck(objCarInfo[0].Axle.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Axle.ToString()));
            
            lblMake.Text = EmptyCheck(objCarInfo[0].Make);
            lblMake1.Text = EmptyCheck(objCarInfo[0].Make);
            lblModel.Text = EmptyCheck(objCarInfo[0].Model);
            lblModel1.Text = EmptyCheck(objCarInfo[0].Model);

            lblYear.Text = EmptyCheck(objCarInfo[0].YearOfMake.ToString());
            lblYear1.Text = EmptyCheck(objCarInfo[0].YearOfMake.ToString());
            lblMileage.Text = EmptyCheck(objCarInfo[0].Mileage.ToString());

            
                        
                        
                        
                        
                        


            //lblAxle.Text = EmptyCheck(objCarInfo[0].Axle);

            lblType.Text = EmptyCheck(objCarInfo[0].TypeName);
            lblType1.Text = EmptyCheck(objCarInfo[0].TypeName);
            lblCategory.Text = EmptyCheck(objCarInfo[0].Category);
            lblCategory1.Text = EmptyCheck(objCarInfo[0].Category);

            lblExteriorColor.Text = EmptyCheck(objCarInfo[0].ExteriorColor);

            lblInteriorColor.Text = EmptyCheck(objCarInfo[0].InteriorColor);

            lblVehicleCondition.Text = EmptyCheck(objCarInfo[0].ConditionDescription);
            lblCondition1.Text = EmptyCheck(objCarInfo[0].ConditionDescription);

            lblVIN.Text = EmptyCheck(objCarInfo[0].VIN);

            lblRear.Text = (EmptyCheck(objCarInfo[0].Rear.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Rear.ToString()));

            lblDescription.Text = EmptyCheck(objCarInfo[0].Description);

            CarsBL.Transactions.NearZonesBL objNearZonesBL = new CarsBL.Transactions.NearZonesBL();

            GetCarPictures(C.Substring(8));

            ClientScript.RegisterStartupScript(typeof(Page), "KyAUIDFCS", "<script language='javascript' type='text/javascript'>ShowSlider();</script>");

            CarFeatures objCarFeatures = new CarFeatures();

            DataSet ds = GetCarFeatures(C.Substring(8));

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlFeature.DataSource = ds.Tables[0];

                    dlFeature.DataBind();
                }

            }
        }
    }


    public DataSet GetCarFeatures(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();
        ArrayList arr = new ArrayList();
        DataSet dsNewFeatures = new DataSet();

        dsNewFeatures.Tables.Add();
        dsNewFeatures.Tables[0].Columns.Add("FeatureTypeName");
        dsNewFeatures.Tables[0].Columns.Add("FeatureName");

        ds = objCarFeatures.GetCarFeatures(sCarId);


        if (ds.Tables[0].Rows.Count > 0)
        {
            dsNewFeatures.Tables[0].Rows.Add();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {


                    dsNewFeatures.Tables[0].Rows.Add();
                    dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0] = ds.Tables[0].Rows[i]["FeatureTypeName"].ToString();
                    dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1] = ds.Tables[0].Rows[i]["FeatureName"].ToString();
                }
                else
                {
                    if (dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0] != dsNewFeatures.Tables[0].Rows[i][0])
                    {
                        dsNewFeatures.Tables[0].Rows.Add();
                        dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0] = ds.Tables[0].Rows[i]["FeatureTypeName"].ToString();
                        dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1] = ds.Tables[0].Rows[i]["FeatureName"].ToString();
                    }
                    else if (dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][0] == dsNewFeatures.Tables[0].Rows[i][0])
                    {

                        dsNewFeatures.Tables[0].Rows[ds.Tables[0].Rows.Count - 1][1] = "," + ds.Tables[0].Rows[i]["FeatureName"].ToString();

                    }
                }

            }
        }
        return dsNewFeatures;
    }

    public void GetCarPictures(string carid)
    {

        CarsBL.Transactions.CarsPictures objCarsPictures = new CarsBL.Transactions.CarsPictures();

        //var obj = new List<CarsInfo.CarPicturesInfo>();
        DataSet dsPics = new DataSet();
        DataSet dsPicsNew = new DataSet();
        //    DataSet dsPicsNew = new DataSet();

        dsPicsNew.Tables.Add();

        dsPicsNew.Tables[0].Columns.Add("PIC");
        dsPicsNew.Tables[0].Columns.Add("PICLOC");
        dsPicsNew.Tables[0].Columns.Add("PICPATH");
        dsPicsNew.Tables[0].Columns.Add("PICDesc");


        dsPics = objCarsPictures.GetCarPictures((carid));

        for (int i = 0; i < 21; i++)
        {
            if (i == 0)
            {
                if (dsPics.Tables[0].Rows[0]["PIC" + i].ToString().Trim() == "" && dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString().Trim() == "")
                {
                    string StockMake = dsPics.Tables[0].Rows[0]["make"].ToString();
                    StockMake = StockMake.Replace(" ", "-");
                    StockMake = StockMake.Replace("/", "@");
                    string StockType = dsPics.Tables[0].Rows[0]["TypeName"].ToString();
                    StockType = StockType.Replace(" ", "-");
                    //string StockUrl = "http://UnitedTruckExchange.com/images/MakeModelThumbs/" + StockType + "_" + StockMake + ".jpg";


                    dsPicsNew.Tables[0].Rows.Add();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = "";
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = "";
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = "http://www.unitedtruckexchange.com/images/no-image.jpg";
                    imgsrc.ImageUrl = "http://www.unitedtruckexchange.com/images/no-image.jpg";
                }
                else
                {
                    dsPicsNew.Tables[0].Rows.Add();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = dsPics.Tables[0].Rows[0]["PIC" + i].ToString();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICDesc"] = dsPics.Tables[0].Rows[0]["PICDesc" + i].ToString();



                    var path = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString() + "/" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();


                    path = path.Replace("//", "/");

                    path = "http://www.unitedtruckexchange.com/" + path;

                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = path;

                    imgsrc.ImageUrl = path;
                }
            }
            else
            {
                var path = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString() + "/" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();


                path = path.Replace("//", "/");
                path = "http://www.unitedtruckexchange.com/" + path;

                if (path != "http://www.unitedtruckexchange.com//")
                {

                    dsPicsNew.Tables[0].Rows.Add();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = dsPics.Tables[0].Rows[0]["PIC" + i].ToString();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString();
                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICDesc"] = dsPics.Tables[0].Rows[0]["PICDesc" + i].ToString();


                    dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = path;
                }
            }
        }
        Repeater2.DataSource = dsPicsNew;
        Repeater2.DataBind();
        Repeater1.DataSource = dsPicsNew;
        Repeater1.DataBind();


    }
    private string EmptyCheck(string sEmp)
    {
        if (sEmp == "Emp")
        {
            sEmp = "";
        }
        return sEmp;
    }
}

