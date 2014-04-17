using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CarsBL.Transactions;

public partial class CarAdsByMakeModel : System.Web.UI.Page
{
    int rowcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["PageName"] = "PromotionbyMakeModel";

            if (Request.QueryString.Keys.Count > 1)
            {
                string URL = string.Empty;
                string URL1 = string.Empty;
                if (Request.QueryString[0].IndexOf("images") == -1)
                {
                    if (Request.QueryString.Keys.Count > 0)
                    {
                        FillCarsbyMakeModel(Request.QueryString[0], Request.QueryString[1]);
                        lblMake .Text = Request.QueryString[0];
                        lblModel.Text = Request.QueryString[1];
                        lblState1.Text = Request.QueryString[0];
                        lblCity1.Text = Request.QueryString[1];
                    }
                }
            }




        }

    }

    private void FillCarsbyMakeModel(string Make, string Model)
    {
        var obj = new List<CarsInfo.UsedCarsInfo>();

        AdsBL objAdsBL = new AdsBL();

        obj = objAdsBL.GetCarsAdsMakeAndModel();
        //Make , Model
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
            LinkButton lnkTitle = (LinkButton)e.Item.FindControl("lnkTitle");
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



            lnkTitle.PostBackUrl = "http://UnitedCarExchange.com/Buy-Sell-UsedCar/" + obj[rowcount].YearOfMake.ToString() + "-" + obj[rowcount].Make + '-' + obj[rowcount].Model.Replace("&", "-") + '-' + obj[rowcount].CarUniqueID;


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

}
