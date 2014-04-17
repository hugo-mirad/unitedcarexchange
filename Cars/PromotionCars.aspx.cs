using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarsBL.Transactions;
using System.Web.UI.HtmlControls;

public partial class PromotionCars : System.Web.UI.Page
{
    int rowcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["PageName"] = "PromotionbyStatecity";


            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "../../CarsService.asmx";

            objScriptReference.Path = "../../Static/Js/CarsJScriptNew.js";


            //objServiceReference.Path = "~/CarsService.asmx";

            //objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptMgr.Scripts.Add(objScriptReference);
            scrptMgr.Services.Add(objServiceReference);

            if (Request.QueryString.Keys.Count > 1)
            {


                //UserControl UC = (UserControl)Page.LoadControl("~/UserControl/LoginName.ascx"); 

                //Label lblLang=(Label)UC.FindControl("lblLang");

                //lblLang.Visible = false;  

                //LinkButton lnbtnLang = (LinkButton)UC.FindControl("lnbtnLang");
                //lnbtnLang.Visible = false;



                //ChangeLanguage

                string URL = string.Empty;
                string URL1 = string.Empty;
                if (Request.QueryString[0].IndexOf("images") == -1)
                {
                    if (Request.QueryString.Keys.Count > 0)
                    {
                        FillCarsbyState(Request.QueryString[1], Request.QueryString[0]);
                        lblState.Text = Request.QueryString[1];
                        lblCity.Text = Request.QueryString[0];
                        lblState1.Text = Request.QueryString[1];
                        lblCity1.Text = Request.QueryString[0];

                        lblState2.Text  = Request.QueryString[1];
                        lblCity2.Text = Request.QueryString[0];

                        Title = "Sell Used Cars in " + Request.QueryString[0] + ", " + Request.QueryString[1] + "";

                        HtmlMeta tag = new HtmlMeta();

                        tag.Name = "keywords";
                        //tag.Content = "Buy " + lblTitle.Text.ToString() + " at UnitedCarExchange.com";
                        tag.Content = "Sell, Used Cars, Buy, " + Request.QueryString[0] + ", " + Request.QueryString[1] + ".";

                        Header.Controls.Add(tag);


                        HtmlMeta tag1 = new HtmlMeta();
                        tag1.Name = "description";
                        //tag1.Content = EmptyCheck(objCarInfo[0].Description);
                        tag1.Content = "Sell or Buy Used Cars in " + Request.QueryString[0] + ", " + Request.QueryString[1] + " with unitedcarexchange.com - The fastest way to sell your Used car.";
                        Header.Controls.Add(tag1);


                        //Sell or Buy Used Cars in Region, State with unitedcarexchange.com - The fastest way to sell your car.
                    }
                }
            }




        }

    }

    private void FillCarsbyState(string State, string city)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        AdsBL objAdsBL = new AdsBL();

        obj = objAdsBL.GetAdsByState(State, city);
        Session["CarAdsbyState"] = obj;
        rptrCarsbyState.DataSource = obj;
        rptrCarsbyState.DataBind();


    }

    private string EmptyCheck(string sEmp)
    {
        if (sEmp == "Emp" || sEmp == "emp")
        {
            sEmp = "";
        }
        return sEmp;
    }

    protected void rptrModels_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            var obj = new List<CarsInfo.UsedCarsInfo>();

            obj = (List<CarsInfo.UsedCarsInfo>)Session["CarAdsbyState"];

            Label sTitle = (Label)e.Item.FindControl("sTitle");
            Label lnkTitle = (Label)e.Item.FindControl("lnkTitle");

            HyperLink lnbtnTitle = (HyperLink)e.Item.FindControl("lnbtnTitle");
            Label lblprice = (Label)e.Item.FindControl("lblprice");


            lblprice.Text = "$" + (EmptyCheck(obj[0].Price.ToString()) == "" ? "0" : EmptyCheck(obj[0].Price.ToString()));


            if (obj[rowcount].Title != "Emp")
            {
                lnkTitle.Text = EmptyCheck(obj[rowcount].Title);

            }
            else
            {
                lnkTitle.Text = GeneralFunc.WrapTextByMaxCharacters((obj[rowcount].YearOfMake.ToString() + ' ' + obj[rowcount].Make + ' ' + obj[rowcount].Model).ToString().ToUpper(), 30);
            }


            lnkTitle.ToolTip = "Buy " + obj[rowcount].YearOfMake.ToString() + " " + obj[rowcount].Make + " " + obj[rowcount].Model + " cars in " + Request.QueryString[0] + ", " + Request.QueryString[1] + " ";

           //lnkTitle.PostBackUrl = "http://UnitedCarExchange.com/Buy-Sell-UsedCar/" + obj[rowcount].YearOfMake.ToString() + "-" + obj[rowcount].Make + '-' + obj[rowcount].Model.Replace("&", "-") + '-' + obj[rowcount].CarUniqueID;

           lnbtnTitle.NavigateUrl= "http://UnitedCarExchange.com/Buy-Sell-UsedCar/" + obj[rowcount].YearOfMake.ToString() + "-" + obj[rowcount].Make + '-' + obj[rowcount].Model.Replace("&", "-") + '-' + obj[rowcount].CarUniqueID;           
            


            string StockUrl = string.Empty;

            if (obj[rowcount].PIC0.ToString().Trim() == "" && obj[rowcount].PICLOC0.ToString().Trim() == "")
            {
                string StockMake = obj[rowcount].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obj[rowcount].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";
            }

            else
            {

                var path = obj[rowcount].PICLOC0.ToString() + "/" + obj[rowcount].PIC0.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;
            }
            Image imgSimliar = (Image)e.Item.FindControl("imgSimliar");

            imgSimliar.ImageUrl = StockUrl;

            imgSimliar.DescriptionUrl = "http://UnitedCarExchange.com/Buy-Sell-UsedCar/" + obj[rowcount].YearOfMake.ToString() + "-" + obj[rowcount].Make + '-' + obj[rowcount].Model.Replace("&", "-") + '-' + obj[rowcount].CarUniqueID;

            string m = string.Empty;

            string p = obj[rowcount].ExteriorColor;

            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].ExteriorColor;
                m += ", ";
            }
            p = obj[rowcount].NumberOfDoors;
            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].NumberOfDoors;
                m += ", ";
            }
            p = obj[rowcount].NumberOfSeats;
            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].NumberOfSeats;
                m += ", ";
            }
            p = obj[rowcount].NumberOfCylinder;
            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].NumberOfCylinder;
                m += ", ";
            }
            p = obj[rowcount].Transmission;

            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].Transmission;
            }

            rowcount += 1;
        }

    }



    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Unitedcarexchange.com", true);
    }
}
