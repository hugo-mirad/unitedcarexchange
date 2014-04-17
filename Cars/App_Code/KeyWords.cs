using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for KeyWords
/// </summary>
public class KeyWords
{



    public static void AddMetatags(HtmlHead  Header)
    {
        HtmlMeta tag = new HtmlMeta();
        tag.Name = "description";
        tag.Content = "My description for this page";
        Header.Controls.Add(tag);         
    }
    public static void Addkeywordstags(HtmlHead Header)
    {

        if (HttpContext.Current.Session["CurrentPage"] == "Home")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online";
            Header.Controls.Add(tag);
        }

        else  if (HttpContext.Current.Session["CurrentPage"] == "Account")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Contact Us")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Used Cars")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "New Cars")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Packages")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "DealerReg")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Search Results Page")
        {
            /*
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
             */
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Finance Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Auto Finance, Auto Lending, Auto Finance for Cars, Auto Loan Financing, Used Car Loans, Used Car Finance, Used Auto Loans";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "How it Works Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Testimonials")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "T & C Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Return Policy Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = "Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars";
            Header.Controls.Add(tag);
        }

        // DESCRIPTION

        if (HttpContext.Current.Session["CurrentPage"] == "Home")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Search all your favorite cars at UnitedCarExchange.com. Buy & Sell best quality used cars and new cars online.";
            Header.Controls.Add(tag);
        }

        else if (HttpContext.Current.Session["CurrentPage"] == "Account")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "United Car Exchange is the most trusted online used car agency. We help in providing an online platform where car buyers and sellers can search, buy, sell their Used/ New cars.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Contact Us")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "United Car Exchange is the most trusted online used car agency. We help in providing an online platform where car buyers and sellers can search, buy, sell their Used/ New cars.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Used Cars")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "United Car Exchange is the most trusted online used car agency. We help in providing an online platform where car buyers and sellers can search, buy, sell their Used/ New cars.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "New Cars")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "We provide detailed car information about each and every car make, model, pricing info, monthly calculator tools with reviews which help to take confident decisions to buy your new car.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Packages")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Select our best package which includes Ads, photo uploading, and Ad traffic reports with money back guarantee options to sell your car online without risk.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "DealerReg")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "If you are a car dealer, this is the right place to connect with people who want to buy used cars online. We connect dealers and car customers online to make online car sale without risk.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Search Results Page")
        {
            /*
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Search and buy used cars. Enter your zip code and specifications like car make and model to find your favorite car to buy online.";
            Header.Controls.Add(tag);
             */
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Finance Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "We at United Car Exchange provide your various Financing options like Auto Finance and Auto Lending options for our customers.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "How it Works Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Buy or Sell - New & Used Cars Online at United Car Exchange for best prices with best financial options.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Testimonials")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Find Customers testimonials after using United Car Exchange’s buying and selling services online.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "T & C Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Our terms and conditions to buy or sell – new & used cars online at UnitedCarExchange.com";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Return Policy Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Description";
            tag.Content = "Our money return policy to buy or sell – new and used cars online at United Car Exchange.";
            Header.Controls.Add(tag);
        }


        // Titles

        if (HttpContext.Current.Session["CurrentPage"] == "Home")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            //tag.Content 
            Header.Title  = "Search Used Cars, Buy & Sell Used Cars and New Cars Online at UnitedCarExchange.com ";
        }

        else if (HttpContext.Current.Session["CurrentPage"] == "Account")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "United Car Exchange is the most trusted online used car agency. We help in providing an online platform where car buyers and sellers can search, buy, sell their Used/ New cars.";
            //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Contact Us")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            tag.Content = "United Car Exchange is the most trusted online used car agency. We help in providing an online platform where car buyers and sellers can search, buy, sell their Used/ New cars.";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Used Cars")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "Search and Find all Branded Used Cars Online for Sale at UnitedCarExchange.com";
            //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "New Cars")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            tag.Content = "Search & Find New Cars for Sale, Compare Prices at UnitedCarExchange.com";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Packages")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "Best Car Selling Packages to Sell your Car Online at UnitedCarExchange.com";
            //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "DealerReg")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "Are You a Car Dealer–Buy or Sell Your Used Cars Online at UnitedCarExchange.com";
           //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Search Results Page")
        {
            /*
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "Search and buy used cars. Enter your zip code and specifications like car make and model to find your favorite car to buy online.";
            */     
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Finance Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "United Car Exchange Financial Options to Buy or Sell Used Cars Online";
            //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "How it Works Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "United Car Exchange Process to Buy or Sell Used Cars Online";
            //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Testimonials")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            tag.Content = "Buy or Sell Used Cars Online at United Car Exchange – Testimonials";
            Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "T & C Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "United Car Exchange – Terms and Conditions";
            //Header.Controls.Add(tag);
        }
        else if (HttpContext.Current.Session["CurrentPage"] == "Return Policy Page")
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "Title";
            Header.Title = "United Car Exchange –Return Policy to Buy or Sell Used Cars";
            //Header.Controls.Add(tag);
        }
        
        
        
        
    }

    public static void AddDescritpintags(HtmlHead Header)
    {
        HtmlMeta tag = new HtmlMeta();
        tag.Name = "Title";
        tag.Content = "Best Car Selling Packages to Sell your Car Online at UnitedCarExchange.com";
        Header.Controls.Add(tag);
    }

    //tag.Name = ""

        //
        // TODO: Add constructor logic here
        //
    
}
