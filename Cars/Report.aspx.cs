
using System;
using System.Collections;
using System.Collections.Generic;
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
using CarsBL.Transactions;
using CarsInfo;
using System.Net.Mail;
using CarsBL.Masters;

public partial class Report : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                lblRepDate.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString("MM/dd/yyyy");
                DataSet dsSalesReport = objdropdownBL.SmartzSalesReport();
                TotalSalesReport(dsSalesReport);
                DataSet dsRefundsReport = objdropdownBL.USP_SmartzRefundsReport();
                TotalRefundReport(dsRefundsReport);
                DataSet dsSalesBySource = objdropdownBL.USP_SmartzSalesBySourceReport();
                TotalSalesBySourceReport(dsSalesBySource);
                Session.Timeout = 180;
            }
        }
    }

    private void TotalSalesBySourceReport(DataSet dsSalesBySource)
    {
        try
        {
            int SalesTotCount = 0;
            int SalesPrevYearCount = 0;
            int SalesThisYearCount = 0;
            int SalesPrevMonthCount = 0;
            int SalesThisMonthCount = 0;
            int SalesPrevWeekCount = 0;
            int SalesThisWeekCount = 0;
            int SalesMonCount = 0;
            int SalesTueCount = 0;
            int SalesWedCount = 0;
            int SalesThuCount = 0;
            int SalesFriCount = 0;
            int SalesSatCount = 0;
            int SalesSunCount = 0;
            //...........Total Sales Start...........
            if (dsSalesBySource.Tables[0].Rows.Count > 0)
            {
                lblTotalOnline.Text = dsSalesBySource.Tables[0].Rows[0]["SlaesByOnline"].ToString();
                lblTotalSmartz.Text = dsSalesBySource.Tables[0].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesTotCount = Convert.ToInt32(lblTotalOnline.Text) + Convert.ToInt32(lblTotalSmartz.Text);

            lblTotalTotal.Text = SalesTotCount.ToString();
            //..........Total Sales End..............
            //..........Total Sales Prev Year Start...........

            if (dsSalesBySource.Tables[1].Rows.Count > 0)
            {
                lblPrevYearOnline.Text = dsSalesBySource.Tables[1].Rows[0]["SlaesByOnline"].ToString();
                lblPrevYearSmartz.Text = dsSalesBySource.Tables[1].Rows[0]["SlaesBySmartz"].ToString();
            }
            SalesPrevYearCount = Convert.ToInt32(lblPrevYearOnline.Text) + Convert.ToInt32(lblPrevYearSmartz.Text);
            lblPrevYearTotal.Text = SalesPrevYearCount.ToString();
            //............Total Sales Prev Year End...........
            //..........Total Sales This Year Start...........

            if (dsSalesBySource.Tables[2].Rows.Count > 0)
            {
                lblThisYearOnline.Text = dsSalesBySource.Tables[2].Rows[0]["SlaesByOnline"].ToString();
                lblThisYearSmartz.Text = dsSalesBySource.Tables[2].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesThisYearCount = Convert.ToInt32(lblThisYearOnline.Text) + Convert.ToInt32(lblThisYearSmartz.Text);

            lblThisYearTotal.Text = SalesThisYearCount.ToString();
            //............Total Sales This Year End...........

            //..........Total Sales prev Month Start...........

            if (dsSalesBySource.Tables[3].Rows.Count > 0)
            {
                lblPrevMonthOnline.Text = dsSalesBySource.Tables[3].Rows[0]["SlaesByOnline"].ToString();
                lblPrevMonthSmartz.Text = dsSalesBySource.Tables[3].Rows[0]["SlaesBySmartz"].ToString();
            }


            SalesPrevMonthCount = Convert.ToInt32(lblPrevMonthOnline.Text) + Convert.ToInt32(lblPrevMonthSmartz.Text);
            lblPrevMonthTotal.Text = SalesPrevMonthCount.ToString();
            //............Total Sales Prev Month End...........


            //..........Total Sales This Month Start...........

            if (dsSalesBySource.Tables[4].Rows.Count > 0)
            {
                lblThisMonthOnline.Text = dsSalesBySource.Tables[4].Rows[0]["SlaesByOnline"].ToString();
                lblThisMonthSmartz.Text = dsSalesBySource.Tables[4].Rows[0]["SlaesBySmartz"].ToString();
            }


            SalesThisMonthCount = Convert.ToInt32(lblThisMonthOnline.Text) + Convert.ToInt32(lblThisMonthSmartz.Text);

            lblThisMonthTotal.Text = SalesThisMonthCount.ToString();
            //............Total Sales This Month End...........
                       

            //..........Total Sales prev Week Start...........

            if (dsSalesBySource.Tables[5].Rows.Count > 0)
            {
                lblPrevWeekOnline.Text = dsSalesBySource.Tables[5].Rows[0]["SlaesByOnline"].ToString();
                lblPrevWeekSmartz.Text = dsSalesBySource.Tables[5].Rows[0]["SlaesBySmartz"].ToString();
            }


            SalesPrevWeekCount = Convert.ToInt32(lblPrevWeekOnline.Text) + Convert.ToInt32(lblPrevWeekSmartz.Text);

            lblPrevWeekTotal.Text = SalesPrevWeekCount.ToString();
            //............Total Sales Prev Week End...........



            //..........Total Sales This Week Start...........

            if (dsSalesBySource.Tables[6].Rows.Count > 0)
            {
                lblThisWeekOnline.Text = dsSalesBySource.Tables[6].Rows[0]["SlaesByOnline"].ToString();
                lblThisWeekSmartz.Text = dsSalesBySource.Tables[6].Rows[0]["SlaesBySmartz"].ToString();
            }


            SalesThisWeekCount = Convert.ToInt32(lblThisWeekOnline.Text) + Convert.ToInt32(lblThisWeekSmartz.Text);

            lblThisWeekTotal.Text = SalesThisWeekCount.ToString();
            //............Total Sales This Week End...........


            //..........Total Sales On Monday Start...........

            if (dsSalesBySource.Tables[7].Rows.Count > 0)
            {
                lblMonOnline.Text = dsSalesBySource.Tables[7].Rows[0]["SlaesByOnline"].ToString();
                lblMonSmartz.Text = dsSalesBySource.Tables[7].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesMonCount = Convert.ToInt32(lblMonOnline.Text) + Convert.ToInt32(lblMonSmartz.Text);

            lblSalesByMonTotal.Text = SalesMonCount.ToString();
            //............Total Sales On Monday End...........


            //..........Total Sales On Tuesday Start...........

            if (dsSalesBySource.Tables[8].Rows.Count > 0)
            {
                lblTueOnline.Text = dsSalesBySource.Tables[8].Rows[0]["SlaesByOnline"].ToString();
                lblTueSmartz.Text = dsSalesBySource.Tables[8].Rows[0]["SlaesBySmartz"].ToString();
            }
            SalesTueCount = Convert.ToInt32(lblTueOnline.Text) + Convert.ToInt32(lblTueSmartz.Text);
            lblSalesByTueTotal.Text = SalesTueCount.ToString();
            //............Total Sales On Tuesday End...........



            //..........Total Sales On Wednesday Start...........

            if (dsSalesBySource.Tables[9].Rows.Count > 0)
            {
                lblWedOnline.Text = dsSalesBySource.Tables[9].Rows[0]["SlaesByOnline"].ToString();
                lblWedSmartz.Text = dsSalesBySource.Tables[9].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesWedCount = Convert.ToInt32(lblWedOnline.Text) + Convert.ToInt32(lblWedSmartz.Text);

            lblSalesByWedTotal.Text = SalesWedCount.ToString();
            //............Total Sales On Wednesday End...........

            //..........Total Sales On Thursday Start...........

            if (dsSalesBySource.Tables[10].Rows.Count > 0)
            {
                lblThuOnline.Text = dsSalesBySource.Tables[10].Rows[0]["SlaesByOnline"].ToString();
                lblThuSmartz.Text = dsSalesBySource.Tables[10].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesThuCount = Convert.ToInt32(lblThuOnline.Text) + Convert.ToInt32(lblThuSmartz.Text);

            lblSalesByThuTotal.Text = SalesThuCount.ToString();
            //............Total Sales On Thursday End...........
            //..........Total Sales On Friday Start...........

            if (dsSalesBySource.Tables[11].Rows.Count > 0)
            {
                lblFriOnline.Text = dsSalesBySource.Tables[11].Rows[0]["SlaesByOnline"].ToString();
                lblFriSmartz.Text = dsSalesBySource.Tables[11].Rows[0]["SlaesBySmartz"].ToString();
            }


            SalesFriCount = Convert.ToInt32(lblFriOnline.Text) + Convert.ToInt32(lblFriSmartz.Text);

            lblSalesByFriTotal.Text = SalesFriCount.ToString();
            //............Total Sales On Friday End...........

            //..........Total Sales On Saturday Start...........

            if (dsSalesBySource.Tables[12].Rows.Count > 0)
            {
                lblSatOnline.Text = dsSalesBySource.Tables[12].Rows[0]["SlaesByOnline"].ToString();
                lblSatSmartz.Text = dsSalesBySource.Tables[12].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesSatCount = Convert.ToInt32(lblSatOnline.Text) + Convert.ToInt32(lblSatSmartz.Text);

            lblSalesBySatTotal.Text = SalesSatCount.ToString();
            //............Total Sales On Saturday End...........

            //..........Total Sales On Sunday Start...........

            if (dsSalesBySource.Tables[13].Rows.Count > 0)
            {
                lblSunOnline.Text = dsSalesBySource.Tables[12].Rows[0]["SlaesByOnline"].ToString();
                lblSunSmartz.Text = dsSalesBySource.Tables[12].Rows[0]["SlaesBySmartz"].ToString();
            }

            SalesSunCount = Convert.ToInt32(lblSunOnline.Text) + Convert.ToInt32(lblSunSmartz.Text);

            lblSalesBySunTotal.Text = SalesSunCount.ToString();
            //............Total Sales On Sunday End...........

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private void TotalSalesReport(DataSet dsSalesReport)
    {
        try
        {
            int SalesTotCount = 0;
            int SalesPrevYearCount = 0;
            int SalesThisYearCount = 0;
            int SalesPrevMonthCount = 0;
            int SalesThisMonthCount = 0;
            int SalesPrevWeekCount = 0;
            int SalesThisWeekCount = 0;
            int SalesMonCount = 0;
            int SalesTueCount = 0;
            int SalesWedCount = 0;
            int SalesThuCount = 0;
            int SalesFriCount = 0;
            int SalesSatCount = 0;
            int SalesSunCount = 0;
            //...........Total Sales Start...........
            if (dsSalesReport.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[0].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[0].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesTotalPkgBasic.Text = dsSalesReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[0].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesTotalPkgStandard.Text = dsSalesReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[0].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesTotalPkgEnhanced.Text = dsSalesReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[0].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesTotalPkgSilver.Text = dsSalesReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[0].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesTotalPkgGold.Text = dsSalesReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[0].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesTotalPkgPlatinum.Text = dsSalesReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesTotalPkgBasic.Text != "")
            {
                SalesTotCount = SalesTotCount + Convert.ToInt32(lblSalesTotalPkgBasic.Text);
            }
            else
            {
                lblSalesTotalPkgBasic.Text = "0";
            }
            if (lblSalesTotalPkgStandard.Text != "")
            {
                SalesTotCount = SalesTotCount + Convert.ToInt32(lblSalesTotalPkgStandard.Text);
            }
            else
            {
                lblSalesTotalPkgStandard.Text = "0";
            }
            if (lblSalesTotalPkgEnhanced.Text != "")
            {
                SalesTotCount = SalesTotCount + Convert.ToInt32(lblSalesTotalPkgEnhanced.Text);
            }
            else
            {
                lblSalesTotalPkgEnhanced.Text = "0";
            }
            if (lblSalesTotalPkgSilver.Text != "")
            {
                SalesTotCount = SalesTotCount + Convert.ToInt32(lblSalesTotalPkgSilver.Text);
            }
            else
            {
                lblSalesTotalPkgSilver.Text = "0";
            }
            if (lblSalesTotalPkgGold.Text != "")
            {
                SalesTotCount = SalesTotCount + Convert.ToInt32(lblSalesTotalPkgGold.Text);
            }
            else
            {
                lblSalesTotalPkgGold.Text = "0";
            }
            if (lblSalesTotalPkgPlatinum.Text != "")
            {
                SalesTotCount = SalesTotCount + Convert.ToInt32(lblSalesTotalPkgPlatinum.Text);
            }
            else
            {
                lblSalesTotalPkgPlatinum.Text = "0";
            }
            lblSalesTotTotal.Text = SalesTotCount.ToString();
            //..........Total Sales End..............
            //..........Total Sales Prev Year Start...........

            if (dsSalesReport.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[1].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[1].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesPrevYearPkgBasic.Text = dsSalesReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[1].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesPrevYearPkgStandard.Text = dsSalesReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[1].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesPrevYearPkgEnhanced.Text = dsSalesReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[1].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesPrevYearPkgSilver.Text = dsSalesReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[1].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesPrevYearPkgGold.Text = dsSalesReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[1].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesPrevYearPkgPlatinum.Text = dsSalesReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesPrevYearPkgBasic.Text != "")
            {
                SalesPrevYearCount = SalesPrevYearCount + Convert.ToInt32(lblSalesPrevYearPkgBasic.Text);
            }
            else
            {
                lblSalesPrevYearPkgBasic.Text = "0";
            }
            if (lblSalesPrevYearPkgStandard.Text != "")
            {
                SalesPrevYearCount = SalesPrevYearCount + Convert.ToInt32(lblSalesPrevYearPkgStandard.Text);
            }
            else
            {
                lblSalesPrevYearPkgStandard.Text = "0";
            }
            if (lblSalesPrevYearPkgEnhanced.Text != "")
            {
                SalesPrevYearCount = SalesPrevYearCount + Convert.ToInt32(lblSalesPrevYearPkgEnhanced.Text);
            }
            else
            {
                lblSalesPrevYearPkgEnhanced.Text = "0";
            }
            if (lblSalesPrevYearPkgSilver.Text != "")
            {
                SalesPrevYearCount = SalesPrevYearCount + Convert.ToInt32(lblSalesPrevYearPkgSilver.Text);
            }
            else
            {
                lblSalesPrevYearPkgSilver.Text = "0";
            }
            if (lblSalesPrevYearPkgGold.Text != "")
            {
                SalesPrevYearCount = SalesPrevYearCount + Convert.ToInt32(lblSalesPrevYearPkgGold.Text);
            }
            else
            {
                lblSalesPrevYearPkgGold.Text = "0";
            }
            if (lblSalesPrevYearPkgPlatinum.Text != "")
            {
                SalesPrevYearCount = SalesPrevYearCount + Convert.ToInt32(lblSalesPrevYearPkgPlatinum.Text);
            }
            else
            {
                lblSalesPrevYearPkgPlatinum.Text = "0";
            }
            lblSalesPrevYearTotal.Text = SalesPrevYearCount.ToString();
            //............Total Sales Prev Year End...........
            //..........Total Sales This Year Start...........

            if (dsSalesReport.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[2].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[2].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesThisYearPkgBasic.Text = dsSalesReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[2].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesThisYearPkgStandard.Text = dsSalesReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[2].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesThisYearPkgEnhanced.Text = dsSalesReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[2].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesThisYearPkgSilver.Text = dsSalesReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[2].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesThisYearPkgGold.Text = dsSalesReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[2].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesThisYearPkgPlatinum.Text = dsSalesReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesThisYearPkgBasic.Text != "")
            {
                SalesThisYearCount = SalesThisYearCount + Convert.ToInt32(lblSalesThisYearPkgBasic.Text);
            }
            else
            {
                lblSalesThisYearPkgBasic.Text = "0";
            }
            if (lblSalesThisYearPkgStandard.Text != "")
            {
                SalesThisYearCount = SalesThisYearCount + Convert.ToInt32(lblSalesThisYearPkgStandard.Text);
            }
            else
            {
                lblSalesThisYearPkgStandard.Text = "0";
            }
            if (lblSalesThisYearPkgEnhanced.Text != "")
            {
                SalesThisYearCount = SalesThisYearCount + Convert.ToInt32(lblSalesThisYearPkgEnhanced.Text);
            }
            else
            {
                lblSalesThisYearPkgEnhanced.Text = "0";
            }
            if (lblSalesThisYearPkgSilver.Text != "")
            {
                SalesThisYearCount = SalesThisYearCount + Convert.ToInt32(lblSalesThisYearPkgSilver.Text);
            }
            else
            {
                lblSalesThisYearPkgSilver.Text = "0";
            }
            if (lblSalesThisYearPkgGold.Text != "")
            {
                SalesThisYearCount = SalesThisYearCount + Convert.ToInt32(lblSalesThisYearPkgGold.Text);
            }
            else
            {
                lblSalesThisYearPkgGold.Text = "0";
            }
            if (lblSalesThisYearPkgPlatinum.Text != "")
            {
                SalesThisYearCount = SalesThisYearCount + Convert.ToInt32(lblSalesThisYearPkgPlatinum.Text);
            }
            else
            {
                lblSalesThisYearPkgPlatinum.Text = "0";
            }
            lblSalesThisYearTotal.Text = SalesThisYearCount.ToString();
            //............Total Sales This Year End...........

            //..........Total Sales prev Month Start...........

            if (dsSalesReport.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[3].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[3].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesPrevMonthPkgBasic.Text = dsSalesReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[3].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesPrevMonthPkgStandard.Text = dsSalesReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[3].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesPrevMonthPkgEnhanced.Text = dsSalesReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[3].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesPrevMonthPkgSilver.Text = dsSalesReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[3].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesPrevMonthPkgGold.Text = dsSalesReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[3].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesPrevMonthPkgPlatinum.Text = dsSalesReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesPrevMonthPkgBasic.Text != "")
            {
                SalesPrevMonthCount = SalesPrevMonthCount + Convert.ToInt32(lblSalesPrevMonthPkgBasic.Text);
            }
            else
            {
                lblSalesPrevMonthPkgBasic.Text = "0";
            }
            if (lblSalesPrevMonthPkgStandard.Text != "")
            {
                SalesPrevMonthCount = SalesPrevMonthCount + Convert.ToInt32(lblSalesPrevMonthPkgStandard.Text);
            }
            else
            {
                lblSalesPrevMonthPkgStandard.Text = "0";
            }
            if (lblSalesPrevMonthPkgEnhanced.Text != "")
            {
                SalesPrevMonthCount = SalesPrevMonthCount + Convert.ToInt32(lblSalesPrevMonthPkgEnhanced.Text);
            }
            else
            {
                lblSalesPrevMonthPkgEnhanced.Text = "0";
            }
            if (lblSalesPrevMonthPkgSilver.Text != "")
            {
                SalesPrevMonthCount = SalesPrevMonthCount + Convert.ToInt32(lblSalesPrevMonthPkgSilver.Text);
            }
            else
            {
                lblSalesPrevMonthPkgSilver.Text = "0";
            }
            if (lblSalesPrevMonthPkgGold.Text != "")
            {
                SalesPrevMonthCount = SalesPrevMonthCount + Convert.ToInt32(lblSalesPrevMonthPkgGold.Text);
            }
            else
            {
                lblSalesPrevMonthPkgGold.Text = "0";
            }
            if (lblSalesPrevMonthPkgPlatinum.Text != "")
            {
                SalesPrevMonthCount = SalesPrevMonthCount + Convert.ToInt32(lblSalesPrevMonthPkgPlatinum.Text);
            }
            else
            {
                lblSalesPrevMonthPkgPlatinum.Text = "0";
            }
            lblSalesPrevMonthTotal.Text = SalesPrevMonthCount.ToString();
            //............Total Sales Prev Month End...........


            //..........Total Sales This Month Start...........

            if (dsSalesReport.Tables[4].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[4].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[4].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesThisMonthPkgBasic.Text = dsSalesReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[4].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesThisMonthPkgStandard.Text = dsSalesReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[4].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesThisMonthPkgEnhanced.Text = dsSalesReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[4].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesThisMonthPkgSilver.Text = dsSalesReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[4].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesThisMonthPkgGold.Text = dsSalesReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[4].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesThisMonthPkgPlatinum.Text = dsSalesReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesThisMonthPkgBasic.Text != "")
            {
                SalesThisMonthCount = SalesThisMonthCount + Convert.ToInt32(lblSalesThisMonthPkgBasic.Text);
            }
            else
            {
                lblSalesThisMonthPkgBasic.Text = "0";
            }
            if (lblSalesThisMonthPkgStandard.Text != "")
            {
                SalesThisMonthCount = SalesThisMonthCount + Convert.ToInt32(lblSalesThisMonthPkgStandard.Text);
            }
            else
            {
                lblSalesThisMonthPkgStandard.Text = "0";
            }
            if (lblSalesThisMonthPkgEnhanced.Text != "")
            {
                SalesThisMonthCount = SalesThisMonthCount + Convert.ToInt32(lblSalesThisMonthPkgEnhanced.Text);
            }
            else
            {
                lblSalesThisMonthPkgEnhanced.Text = "0";
            }
            if (lblSalesThisMonthPkgSilver.Text != "")
            {
                SalesThisMonthCount = SalesThisMonthCount + Convert.ToInt32(lblSalesThisMonthPkgSilver.Text);
            }
            else
            {
                lblSalesThisMonthPkgSilver.Text = "0";
            }
            if (lblSalesThisMonthPkgGold.Text != "")
            {
                SalesThisMonthCount = SalesThisMonthCount + Convert.ToInt32(lblSalesThisMonthPkgGold.Text);
            }
            else
            {
                lblSalesThisMonthPkgGold.Text = "0";
            }
            if (lblSalesThisMonthPkgPlatinum.Text != "")
            {
                SalesThisMonthCount = SalesThisMonthCount + Convert.ToInt32(lblSalesThisMonthPkgPlatinum.Text);
            }
            else
            {
                lblSalesThisMonthPkgPlatinum.Text = "0";
            }
            lblSalesThisMonthTotal.Text = SalesThisMonthCount.ToString();
            //............Total Sales This Month End...........




            //..........Total Sales prev Week Start...........

            if (dsSalesReport.Tables[5].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[5].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[5].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesPrevWeekPkgBasic.Text = dsSalesReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[5].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesPrevWeekPkgStandard.Text = dsSalesReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[5].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesPrevWeekPkgEnhanced.Text = dsSalesReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[5].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesPrevWeekPkgSilver.Text = dsSalesReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[5].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesPrevWeekPkgGold.Text = dsSalesReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[5].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesPrevWeekPkgPlatinum.Text = dsSalesReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesPrevWeekPkgBasic.Text != "")
            {
                SalesPrevWeekCount = SalesPrevWeekCount + Convert.ToInt32(lblSalesPrevWeekPkgBasic.Text);
            }
            else
            {
                lblSalesPrevWeekPkgBasic.Text = "0";
            }
            if (lblSalesPrevWeekPkgStandard.Text != "")
            {
                SalesPrevWeekCount = SalesPrevWeekCount + Convert.ToInt32(lblSalesPrevWeekPkgStandard.Text);
            }
            else
            {
                lblSalesPrevWeekPkgStandard.Text = "0";
            }
            if (lblSalesPrevWeekPkgEnhanced.Text != "")
            {
                SalesPrevWeekCount = SalesPrevWeekCount + Convert.ToInt32(lblSalesPrevWeekPkgEnhanced.Text);
            }
            else
            {
                lblSalesPrevWeekPkgEnhanced.Text = "0";
            }
            if (lblSalesPrevWeekPkgSilver.Text != "")
            {
                SalesPrevWeekCount = SalesPrevWeekCount + Convert.ToInt32(lblSalesPrevWeekPkgSilver.Text);
            }
            else
            {
                lblSalesPrevWeekPkgSilver.Text = "0";
            }
            if (lblSalesPrevWeekPkgGold.Text != "")
            {
                SalesPrevWeekCount = SalesPrevWeekCount + Convert.ToInt32(lblSalesPrevWeekPkgGold.Text);
            }
            else
            {
                lblSalesPrevWeekPkgGold.Text = "0";
            }
            if (lblSalesPrevWeekPkgPlatinum.Text != "")
            {
                SalesPrevWeekCount = SalesPrevWeekCount + Convert.ToInt32(lblSalesPrevWeekPkgPlatinum.Text);
            }
            else
            {
                lblSalesPrevWeekPkgPlatinum.Text = "0";
            }
            lblSalesPrevWeekTotal.Text = SalesPrevWeekCount.ToString();
            //............Total Sales Prev Week End...........



            //..........Total Sales This Week Start...........

            if (dsSalesReport.Tables[6].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[6].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[6].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSalesThisWeekPkgBasic.Text = dsSalesReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[6].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSalesThisWeekPkgStandard.Text = dsSalesReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[6].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSalesThisWeekPkgEnhanced.Text = dsSalesReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[6].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSalesThisWeekPkgSilver.Text = dsSalesReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[6].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSalesThisWeekPkgGold.Text = dsSalesReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[6].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSalesThisWeekPkgPlatinum.Text = dsSalesReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSalesThisWeekPkgBasic.Text != "")
            {
                SalesThisWeekCount = SalesThisWeekCount + Convert.ToInt32(lblSalesThisWeekPkgBasic.Text);
            }
            else
            {
                lblSalesThisWeekPkgBasic.Text = "0";
            }
            if (lblSalesThisWeekPkgStandard.Text != "")
            {
                SalesThisWeekCount = SalesThisWeekCount + Convert.ToInt32(lblSalesThisWeekPkgStandard.Text);
            }
            else
            {
                lblSalesThisWeekPkgStandard.Text = "0";
            }
            if (lblSalesThisWeekPkgEnhanced.Text != "")
            {
                SalesThisWeekCount = SalesThisWeekCount + Convert.ToInt32(lblSalesThisWeekPkgEnhanced.Text);
            }
            else
            {
                lblSalesThisWeekPkgEnhanced.Text = "0";
            }
            if (lblSalesThisWeekPkgSilver.Text != "")
            {
                SalesThisWeekCount = SalesThisWeekCount + Convert.ToInt32(lblSalesThisWeekPkgSilver.Text);
            }
            else
            {
                lblSalesThisWeekPkgSilver.Text = "0";
            }
            if (lblSalesThisWeekPkgGold.Text != "")
            {
                SalesThisWeekCount = SalesThisWeekCount + Convert.ToInt32(lblSalesThisWeekPkgGold.Text);
            }
            else
            {
                lblSalesThisWeekPkgGold.Text = "0";
            }
            if (lblSalesThisWeekPkgPlatinum.Text != "")
            {
                SalesThisWeekCount = SalesThisWeekCount + Convert.ToInt32(lblSalesThisWeekPkgPlatinum.Text);
            }
            else
            {
                lblSalesThisWeekPkgPlatinum.Text = "0";
            }
            lblSalesThisWeekTotal.Text = SalesThisWeekCount.ToString();
            //............Total Sales This Week End...........



            //..........Total Sales On Monday Start...........

            if (dsSalesReport.Tables[7].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[7].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[7].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblMonPkgBasic.Text = dsSalesReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[7].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblMonPkgStandard.Text = dsSalesReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[7].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblMonPkgEnhanced.Text = dsSalesReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[7].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblMonPkgSilver.Text = dsSalesReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[7].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblMonPkgGold.Text = dsSalesReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[7].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblMonPkgPlatinum.Text = dsSalesReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblMonPkgBasic.Text != "")
            {
                SalesMonCount = SalesMonCount + Convert.ToInt32(lblMonPkgBasic.Text);
            }
            else
            {
                lblMonPkgBasic.Text = "0";
            }
            if (lblMonPkgStandard.Text != "")
            {
                SalesMonCount = SalesMonCount + Convert.ToInt32(lblMonPkgStandard.Text);
            }
            else
            {
                lblMonPkgStandard.Text = "0";
            }
            if (lblMonPkgEnhanced.Text != "")
            {
                SalesMonCount = SalesMonCount + Convert.ToInt32(lblMonPkgEnhanced.Text);
            }
            else
            {
                lblMonPkgEnhanced.Text = "0";
            }
            if (lblMonPkgSilver.Text != "")
            {
                SalesMonCount = SalesMonCount + Convert.ToInt32(lblMonPkgSilver.Text);
            }
            else
            {
                lblMonPkgSilver.Text = "0";
            }
            if (lblMonPkgGold.Text != "")
            {
                SalesMonCount = SalesMonCount + Convert.ToInt32(lblMonPkgGold.Text);
            }
            else
            {
                lblMonPkgGold.Text = "0";
            }
            if (lblMonPkgPlatinum.Text != "")
            {
                SalesMonCount = SalesMonCount + Convert.ToInt32(lblMonPkgPlatinum.Text);
            }
            else
            {
                lblMonPkgPlatinum.Text = "0";
            }
            lblMonTotal.Text = SalesMonCount.ToString();
            //............Total Sales On Monday End...........


            //..........Total Sales On Tuesday Start...........

            if (dsSalesReport.Tables[8].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[8].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[8].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblTuePkgBasic.Text = dsSalesReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[8].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblTuePkgStandard.Text = dsSalesReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[8].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblTuePkgEnhanced.Text = dsSalesReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[8].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblTuePkgSilver.Text = dsSalesReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[8].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblTuePkgGold.Text = dsSalesReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[8].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblTuePkgPlatinum.Text = dsSalesReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblTuePkgBasic.Text != "")
            {
                SalesTueCount = SalesTueCount + Convert.ToInt32(lblTuePkgBasic.Text);
            }
            else
            {
                lblTuePkgBasic.Text = "0";
            }
            if (lblTuePkgStandard.Text != "")
            {
                SalesTueCount = SalesTueCount + Convert.ToInt32(lblTuePkgStandard.Text);
            }
            else
            {
                lblTuePkgStandard.Text = "0";
            }
            if (lblTuePkgEnhanced.Text != "")
            {
                SalesTueCount = SalesTueCount + Convert.ToInt32(lblTuePkgEnhanced.Text);
            }
            else
            {
                lblTuePkgEnhanced.Text = "0";
            }
            if (lblTuePkgSilver.Text != "")
            {
                SalesTueCount = SalesTueCount + Convert.ToInt32(lblTuePkgSilver.Text);
            }
            else
            {
                lblTuePkgSilver.Text = "0";
            }
            if (lblTuePkgGold.Text != "")
            {
                SalesTueCount = SalesTueCount + Convert.ToInt32(lblTuePkgGold.Text);
            }
            else
            {
                lblTuePkgGold.Text = "0";
            }
            if (lblTuePkgPlatinum.Text != "")
            {
                SalesTueCount = SalesTueCount + Convert.ToInt32(lblTuePkgPlatinum.Text);
            }
            else
            {
                lblTuePkgPlatinum.Text = "0";
            }
            lblTueTotal.Text = SalesTueCount.ToString();
            //............Total Sales On Tuesday End...........



            //..........Total Sales On Wednesday Start...........

            if (dsSalesReport.Tables[9].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[9].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[9].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblWedPkgBasic.Text = dsSalesReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[9].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblWedPkgStandard.Text = dsSalesReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[9].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblWedPkgEnhanced.Text = dsSalesReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[9].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblWedPkgSilver.Text = dsSalesReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[9].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblWedPkgGold.Text = dsSalesReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[9].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblWedPkgPlatinum.Text = dsSalesReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblWedPkgBasic.Text != "")
            {
                SalesWedCount = SalesWedCount + Convert.ToInt32(lblWedPkgBasic.Text);
            }
            else
            {
                lblWedPkgBasic.Text = "0";
            }
            if (lblWedPkgStandard.Text != "")
            {
                SalesWedCount = SalesWedCount + Convert.ToInt32(lblWedPkgStandard.Text);
            }
            else
            {
                lblWedPkgStandard.Text = "0";
            }
            if (lblWedPkgEnhanced.Text != "")
            {
                SalesWedCount = SalesWedCount + Convert.ToInt32(lblWedPkgEnhanced.Text);
            }
            else
            {
                lblWedPkgEnhanced.Text = "0";
            }
            if (lblWedPkgSilver.Text != "")
            {
                SalesWedCount = SalesWedCount + Convert.ToInt32(lblWedPkgSilver.Text);
            }
            else
            {
                lblWedPkgSilver.Text = "0";
            }
            if (lblWedPkgGold.Text != "")
            {
                SalesWedCount = SalesWedCount + Convert.ToInt32(lblWedPkgGold.Text);
            }
            else
            {
                lblWedPkgGold.Text = "0";
            }
            if (lblWedPkgPlatinum.Text != "")
            {
                SalesWedCount = SalesWedCount + Convert.ToInt32(lblWedPkgPlatinum.Text);
            }
            else
            {
                lblWedPkgPlatinum.Text = "0";
            }
            lblWedTotal.Text = SalesWedCount.ToString();
            //............Total Sales On Wednesday End...........

            //..........Total Sales On Thursday Start...........

            if (dsSalesReport.Tables[10].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[10].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[10].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblThuPkgBasic.Text = dsSalesReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[10].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblThuPkgStandard.Text = dsSalesReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[10].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblThuPkgEnhanced.Text = dsSalesReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[10].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblThuPkgSilver.Text = dsSalesReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[10].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblThuPkgGold.Text = dsSalesReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[10].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblThuPkgPlatinum.Text = dsSalesReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblThuPkgBasic.Text != "")
            {
                SalesThuCount = SalesThuCount + Convert.ToInt32(lblThuPkgBasic.Text);
            }
            else
            {
                lblThuPkgBasic.Text = "0";
            }
            if (lblThuPkgStandard.Text != "")
            {
                SalesThuCount = SalesThuCount + Convert.ToInt32(lblThuPkgStandard.Text);
            }
            else
            {
                lblThuPkgStandard.Text = "0";
            }
            if (lblThuPkgEnhanced.Text != "")
            {
                SalesThuCount = SalesThuCount + Convert.ToInt32(lblThuPkgEnhanced.Text);
            }
            else
            {
                lblThuPkgEnhanced.Text = "0";
            }
            if (lblThuPkgSilver.Text != "")
            {
                SalesThuCount = SalesThuCount + Convert.ToInt32(lblThuPkgSilver.Text);
            }
            else
            {
                lblThuPkgSilver.Text = "0";
            }
            if (lblThuPkgGold.Text != "")
            {
                SalesThuCount = SalesThuCount + Convert.ToInt32(lblThuPkgGold.Text);
            }
            else
            {
                lblThuPkgGold.Text = "0";
            }
            if (lblThuPkgPlatinum.Text != "")
            {
                SalesThuCount = SalesThuCount + Convert.ToInt32(lblThuPkgPlatinum.Text);
            }
            else
            {
                lblThuPkgPlatinum.Text = "0";
            }
            lblThuTotal.Text = SalesThuCount.ToString();
            //............Total Sales On Thursday End...........
            //..........Total Sales On Friday Start...........

            if (dsSalesReport.Tables[11].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[11].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[11].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblFriPkgBasic.Text = dsSalesReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[11].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblFriPkgStandard.Text = dsSalesReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[11].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblFriPkgEnhanced.Text = dsSalesReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[11].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblFriPkgSilver.Text = dsSalesReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[11].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblFriPkgGold.Text = dsSalesReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[11].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblFriPkgPlatinum.Text = dsSalesReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblFriPkgBasic.Text != "")
            {
                SalesFriCount = SalesFriCount + Convert.ToInt32(lblFriPkgBasic.Text);
            }
            else
            {
                lblFriPkgBasic.Text = "0";
            }
            if (lblFriPkgStandard.Text != "")
            {
                SalesFriCount = SalesFriCount + Convert.ToInt32(lblFriPkgStandard.Text);
            }
            else
            {
                lblFriPkgStandard.Text = "0";
            }
            if (lblFriPkgEnhanced.Text != "")
            {
                SalesFriCount = SalesFriCount + Convert.ToInt32(lblFriPkgEnhanced.Text);
            }
            else
            {
                lblFriPkgEnhanced.Text = "0";
            }
            if (lblFriPkgSilver.Text != "")
            {
                SalesFriCount = SalesFriCount + Convert.ToInt32(lblFriPkgSilver.Text);
            }
            else
            {
                lblFriPkgSilver.Text = "0";
            }
            if (lblFriPkgGold.Text != "")
            {
                SalesFriCount = SalesFriCount + Convert.ToInt32(lblFriPkgGold.Text);
            }
            else
            {
                lblFriPkgGold.Text = "0";
            }
            if (lblFriPkgPlatinum.Text != "")
            {
                SalesFriCount = SalesFriCount + Convert.ToInt32(lblFriPkgPlatinum.Text);
            }
            else
            {
                lblFriPkgPlatinum.Text = "0";
            }
            lblFriTotal.Text = SalesFriCount.ToString();
            //............Total Sales On Friday End...........

            //..........Total Sales On Saturday Start...........

            if (dsSalesReport.Tables[12].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[12].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[12].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSatPkgBasic.Text = dsSalesReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[12].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSatPkgStandard.Text = dsSalesReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[12].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSatPkgEnhanced.Text = dsSalesReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[12].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSatPkgSilver.Text = dsSalesReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[12].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSatPkgGold.Text = dsSalesReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[12].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSatPkgPlatinum.Text = dsSalesReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSatPkgBasic.Text != "")
            {
                SalesSatCount = SalesSatCount + Convert.ToInt32(lblSatPkgBasic.Text);
            }
            else
            {
                lblSatPkgBasic.Text = "0";
            }
            if (lblSatPkgStandard.Text != "")
            {
                SalesSatCount = SalesSatCount + Convert.ToInt32(lblSatPkgStandard.Text);
            }
            else
            {
                lblSatPkgStandard.Text = "0";
            }
            if (lblSatPkgEnhanced.Text != "")
            {
                SalesSatCount = SalesSatCount + Convert.ToInt32(lblSatPkgEnhanced.Text);
            }
            else
            {
                lblSatPkgEnhanced.Text = "0";
            }
            if (lblSatPkgSilver.Text != "")
            {
                SalesSatCount = SalesSatCount + Convert.ToInt32(lblSatPkgSilver.Text);
            }
            else
            {
                lblSatPkgSilver.Text = "0";
            }
            if (lblSatPkgGold.Text != "")
            {
                SalesSatCount = SalesSatCount + Convert.ToInt32(lblSatPkgGold.Text);
            }
            else
            {
                lblSatPkgGold.Text = "0";
            }
            if (lblSatPkgPlatinum.Text != "")
            {
                SalesSatCount = SalesSatCount + Convert.ToInt32(lblSatPkgPlatinum.Text);
            }
            else
            {
                lblSatPkgPlatinum.Text = "0";
            }
            lblSatTotal.Text = SalesSatCount.ToString();
            //............Total Sales On Saturday End...........

            //..........Total Sales On Sunday Start...........

            if (dsSalesReport.Tables[13].Rows.Count > 0)
            {
                for (int i = 0; i < dsSalesReport.Tables[13].Rows.Count; i++)
                {
                    if (dsSalesReport.Tables[13].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblSunPkgBasic.Text = dsSalesReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[13].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblSunPkgStandard.Text = dsSalesReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[13].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblSunPkgEnhanced.Text = dsSalesReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[13].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblSunPkgSilver.Text = dsSalesReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[13].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblSunPkgGold.Text = dsSalesReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsSalesReport.Tables[13].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblSunPkgPlatinum.Text = dsSalesReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblSunPkgBasic.Text != "")
            {
                SalesSunCount = SalesSunCount + Convert.ToInt32(lblSunPkgBasic.Text);
            }
            else
            {
                lblSunPkgBasic.Text = "0";
            }
            if (lblSunPkgStandard.Text != "")
            {
                SalesSunCount = SalesSunCount + Convert.ToInt32(lblSunPkgStandard.Text);
            }
            else
            {
                lblSunPkgStandard.Text = "0";
            }
            if (lblSunPkgEnhanced.Text != "")
            {
                SalesSunCount = SalesSunCount + Convert.ToInt32(lblSunPkgEnhanced.Text);
            }
            else
            {
                lblSunPkgEnhanced.Text = "0";
            }
            if (lblSunPkgSilver.Text != "")
            {
                SalesSunCount = SalesSunCount + Convert.ToInt32(lblSunPkgSilver.Text);
            }
            else
            {
                lblSunPkgSilver.Text = "0";
            }
            if (lblSunPkgGold.Text != "")
            {
                SalesSunCount = SalesSunCount + Convert.ToInt32(lblSunPkgGold.Text);
            }
            else
            {
                lblSunPkgGold.Text = "0";
            }
            if (lblSunPkgPlatinum.Text != "")
            {
                SalesSunCount = SalesSunCount + Convert.ToInt32(lblSunPkgPlatinum.Text);
            }
            else
            {
                lblSunPkgPlatinum.Text = "0";
            }
            lblSunTotal.Text = SalesSunCount.ToString();
            //............Total Sales On Sunday End...........



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void TotalRefundReport(DataSet dsRefundsReport)
    {
        try
        {
            int RefundTotCount = 0;
            int RefundPrevYearCount = 0;
            int RefundThisYearCount = 0;
            int RefundPrevMonthCount = 0;
            int RefundThisMonthCount = 0;
            int RefundPrevWeekCount = 0;
            int RefundThisWeekCount = 0;
            int RefundMonCount = 0;
            int RefundTueCount = 0;
            int RefundWedCount = 0;
            int RefundThuCount = 0;
            int RefundFriCount = 0;
            int RefundSatCount = 0;
            int RefundSunCount = 0;
            //...........Total Refund Start...........
            if (dsRefundsReport.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[0].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[0].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsTotalPkgBasic.Text = dsRefundsReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[0].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsTotalPkgStandard.Text = dsRefundsReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[0].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsTotalPkgEnhanced.Text = dsRefundsReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[0].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsTotalPkgSilver.Text = dsRefundsReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[0].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsTotalPkgGold.Text = dsRefundsReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[0].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsTotalPkgPlatinum.Text = dsRefundsReport.Tables[0].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsTotalPkgBasic.Text != "")
            {
                RefundTotCount = RefundTotCount + Convert.ToInt32(lblRefundsTotalPkgBasic.Text);
            }
            else
            {
                lblRefundsTotalPkgBasic.Text = "0";
            }
            if (lblRefundsTotalPkgStandard.Text != "")
            {
                RefundTotCount = RefundTotCount + Convert.ToInt32(lblRefundsTotalPkgStandard.Text);
            }
            else
            {
                lblRefundsTotalPkgStandard.Text = "0";
            }
            if (lblRefundsTotalPkgEnhanced.Text != "")
            {
                RefundTotCount = RefundTotCount + Convert.ToInt32(lblRefundsTotalPkgEnhanced.Text);
            }
            else
            {
                lblRefundsTotalPkgEnhanced.Text = "0";
            }
            if (lblRefundsTotalPkgSilver.Text != "")
            {
                RefundTotCount = RefundTotCount + Convert.ToInt32(lblRefundsTotalPkgSilver.Text);
            }
            else
            {
                lblRefundsTotalPkgSilver.Text = "0";
            }
            if (lblRefundsTotalPkgGold.Text != "")
            {
                RefundTotCount = RefundTotCount + Convert.ToInt32(lblRefundsTotalPkgGold.Text);
            }
            else
            {
                lblRefundsTotalPkgGold.Text = "0";
            }
            if (lblRefundsTotalPkgPlatinum.Text != "")
            {
                RefundTotCount = RefundTotCount + Convert.ToInt32(lblRefundsTotalPkgPlatinum.Text);
            }
            else
            {
                lblRefundsTotalPkgPlatinum.Text = "0";
            }
            lblRefundsTotTotal.Text = RefundTotCount.ToString();
            //..........Total Refund End..............
            //..........Total Refund Prev Year Start...........

            if (dsRefundsReport.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[1].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[1].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsPrevYearPkgBasic.Text = dsRefundsReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[1].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsPrevYearPkgStandard.Text = dsRefundsReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[1].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsPrevYearPkgEnhanced.Text = dsRefundsReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[1].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsPrevYearPkgSilver.Text = dsRefundsReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[1].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsPrevYearPkgGold.Text = dsRefundsReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[1].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsPrevYearPkgPlatinum.Text = dsRefundsReport.Tables[1].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsPrevYearPkgBasic.Text != "")
            {
                RefundPrevYearCount = RefundPrevYearCount + Convert.ToInt32(lblRefundsPrevYearPkgBasic.Text);
            }
            else
            {
                lblRefundsPrevYearPkgBasic.Text = "0";
            }
            if (lblRefundsPrevYearPkgStandard.Text != "")
            {
                RefundPrevYearCount = RefundPrevYearCount + Convert.ToInt32(lblRefundsPrevYearPkgStandard.Text);
            }
            else
            {
                lblRefundsPrevYearPkgStandard.Text = "0";
            }
            if (lblRefundsPrevYearPkgEnhanced.Text != "")
            {
                RefundPrevYearCount = RefundPrevYearCount + Convert.ToInt32(lblRefundsPrevYearPkgEnhanced.Text);
            }
            else
            {
                lblRefundsPrevYearPkgEnhanced.Text = "0";
            }
            if (lblRefundsPrevYearPkgSilver.Text != "")
            {
                RefundPrevYearCount = RefundPrevYearCount + Convert.ToInt32(lblRefundsPrevYearPkgSilver.Text);
            }
            else
            {
                lblRefundsPrevYearPkgSilver.Text = "0";
            }
            if (lblRefundsPrevYearPkgGold.Text != "")
            {
                RefundPrevYearCount = RefundPrevYearCount + Convert.ToInt32(lblRefundsPrevYearPkgGold.Text);
            }
            else
            {
                lblRefundsPrevYearPkgGold.Text = "0";
            }
            if (lblRefundsPrevYearPkgPlatinum.Text != "")
            {
                RefundPrevYearCount = RefundPrevYearCount + Convert.ToInt32(lblRefundsPrevYearPkgPlatinum.Text);
            }
            else
            {
                lblRefundsPrevYearPkgPlatinum.Text = "0";
            }
            lblRefundsPrevYearTotal.Text = RefundPrevYearCount.ToString();
            //............Total Refund Prev Year End...........
            //..........Total Refund This Year Start...........

            if (dsRefundsReport.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[2].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[2].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsThisYearPkgBasic.Text = dsRefundsReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[2].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsThisYearPkgStandard.Text = dsRefundsReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[2].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsThisYearPkgEnhanced.Text = dsRefundsReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[2].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsThisYearPkgSilver.Text = dsRefundsReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[2].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsThisYearPkgGold.Text = dsRefundsReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[2].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsThisYearPkgPlatinum.Text = dsRefundsReport.Tables[2].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsThisYearPkgBasic.Text != "")
            {
                RefundThisYearCount = RefundThisYearCount + Convert.ToInt32(lblRefundsThisYearPkgBasic.Text);
            }
            else
            {
                lblRefundsThisYearPkgBasic.Text = "0";
            }
            if (lblRefundsThisYearPkgStandard.Text != "")
            {
                RefundThisYearCount = RefundThisYearCount + Convert.ToInt32(lblRefundsThisYearPkgStandard.Text);
            }
            else
            {
                lblRefundsThisYearPkgStandard.Text = "0";
            }
            if (lblRefundsThisYearPkgEnhanced.Text != "")
            {
                RefundThisYearCount = RefundThisYearCount + Convert.ToInt32(lblRefundsThisYearPkgEnhanced.Text);
            }
            else
            {
                lblRefundsThisYearPkgEnhanced.Text = "0";
            }
            if (lblRefundsThisYearPkgSilver.Text != "")
            {
                RefundThisYearCount = RefundThisYearCount + Convert.ToInt32(lblRefundsThisYearPkgSilver.Text);
            }
            else
            {
                lblRefundsThisYearPkgSilver.Text = "0";
            }
            if (lblRefundsThisYearPkgGold.Text != "")
            {
                RefundThisYearCount = RefundThisYearCount + Convert.ToInt32(lblRefundsThisYearPkgGold.Text);
            }
            else
            {
                lblRefundsThisYearPkgGold.Text = "0";
            }
            if (lblRefundsThisYearPkgPlatinum.Text != "")
            {
                RefundThisYearCount = RefundThisYearCount + Convert.ToInt32(lblRefundsThisYearPkgPlatinum.Text);
            }
            else
            {
                lblRefundsThisYearPkgPlatinum.Text = "0";
            }
            lblRefundsThisYearTotal.Text = RefundThisYearCount.ToString();
            //............Total Refund This Year End...........

            //..........Total Refund prev Month Start...........

            if (dsRefundsReport.Tables[3].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[3].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[3].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsPrevMonthPkgBasic.Text = dsRefundsReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[3].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsPrevMonthPkgStandard.Text = dsRefundsReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[3].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsPrevMonthPkgEnhanced.Text = dsRefundsReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[3].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsPrevMonthPkgSilver.Text = dsRefundsReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[3].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsPrevMonthPkgGold.Text = dsRefundsReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[3].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsPrevMonthPkgPlatinum.Text = dsRefundsReport.Tables[3].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsPrevMonthPkgBasic.Text != "")
            {
                RefundPrevMonthCount = RefundPrevMonthCount + Convert.ToInt32(lblRefundsPrevMonthPkgBasic.Text);
            }
            else
            {
                lblRefundsPrevMonthPkgBasic.Text = "0";
            }
            if (lblRefundsPrevMonthPkgStandard.Text != "")
            {
                RefundPrevMonthCount = RefundPrevMonthCount + Convert.ToInt32(lblRefundsPrevMonthPkgStandard.Text);
            }
            else
            {
                lblRefundsPrevMonthPkgStandard.Text = "0";
            }
            if (lblRefundsPrevMonthPkgEnhanced.Text != "")
            {
                RefundPrevMonthCount = RefundPrevMonthCount + Convert.ToInt32(lblRefundsPrevMonthPkgEnhanced.Text);
            }
            else
            {
                lblRefundsPrevMonthPkgEnhanced.Text = "0";
            }
            if (lblRefundsPrevMonthPkgSilver.Text != "")
            {
                RefundPrevMonthCount = RefundPrevMonthCount + Convert.ToInt32(lblRefundsPrevMonthPkgSilver.Text);
            }
            else
            {
                lblRefundsPrevMonthPkgSilver.Text = "0";
            }
            if (lblRefundsPrevMonthPkgGold.Text != "")
            {
                RefundPrevMonthCount = RefundPrevMonthCount + Convert.ToInt32(lblRefundsPrevMonthPkgGold.Text);
            }
            else
            {
                lblRefundsPrevMonthPkgGold.Text = "0";
            }
            if (lblRefundsPrevMonthPkgPlatinum.Text != "")
            {
                RefundPrevMonthCount = RefundPrevMonthCount + Convert.ToInt32(lblRefundsPrevMonthPkgPlatinum.Text);
            }
            else
            {
                lblRefundsPrevMonthPkgPlatinum.Text = "0";
            }
            lblRefundsPrevMonthTotal.Text = RefundPrevMonthCount.ToString();
            //............Total Refund Prev Month End...........


            //..........Total Refund This Month Start...........

            if (dsRefundsReport.Tables[4].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[4].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[4].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsThisMonthPkgBasic.Text = dsRefundsReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[4].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsThisMonthPkgStandard.Text = dsRefundsReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[4].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsThisMonthPkgEnhanced.Text = dsRefundsReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[4].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsThisMonthPkgSilver.Text = dsRefundsReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[4].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsThisMonthPkgGold.Text = dsRefundsReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[4].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsThisMonthPkgPlatinum.Text = dsRefundsReport.Tables[4].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsThisMonthPkgBasic.Text != "")
            {
                RefundThisMonthCount = RefundThisMonthCount + Convert.ToInt32(lblRefundsThisMonthPkgBasic.Text);
            }
            else
            {
                lblRefundsThisMonthPkgBasic.Text = "0";
            }
            if (lblRefundsThisMonthPkgStandard.Text != "")
            {
                RefundThisMonthCount = RefundThisMonthCount + Convert.ToInt32(lblRefundsThisMonthPkgStandard.Text);
            }
            else
            {
                lblRefundsThisMonthPkgStandard.Text = "0";
            }
            if (lblRefundsThisMonthPkgEnhanced.Text != "")
            {
                RefundThisMonthCount = RefundThisMonthCount + Convert.ToInt32(lblRefundsThisMonthPkgEnhanced.Text);
            }
            else
            {
                lblRefundsThisMonthPkgEnhanced.Text = "0";
            }
            if (lblRefundsThisMonthPkgSilver.Text != "")
            {
                RefundThisMonthCount = RefundThisMonthCount + Convert.ToInt32(lblRefundsThisMonthPkgSilver.Text);
            }
            else
            {
                lblRefundsThisMonthPkgSilver.Text = "0";
            }
            if (lblRefundsThisMonthPkgGold.Text != "")
            {
                RefundThisMonthCount = RefundThisMonthCount + Convert.ToInt32(lblRefundsThisMonthPkgGold.Text);
            }
            else
            {
                lblRefundsThisMonthPkgGold.Text = "0";
            }
            if (lblRefundsThisMonthPkgPlatinum.Text != "")
            {
                RefundThisMonthCount = RefundThisMonthCount + Convert.ToInt32(lblRefundsThisMonthPkgPlatinum.Text);
            }
            else
            {
                lblRefundsThisMonthPkgPlatinum.Text = "0";
            }
            lblRefundsThisMonthTotal.Text = RefundThisMonthCount.ToString();
            //............Total Refund This Month End...........




            //..........Total Refund prev Week Start...........

            if (dsRefundsReport.Tables[5].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[5].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[5].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsPrevWeekPkgBasic.Text = dsRefundsReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[5].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsPrevWeekPkgStandard.Text = dsRefundsReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[5].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsPrevWeekPkgEnhanced.Text = dsRefundsReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[5].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsPrevWeekPkgSilver.Text = dsRefundsReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[5].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsPrevWeekPkgGold.Text = dsRefundsReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[5].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsPrevWeekPkgPlatinum.Text = dsRefundsReport.Tables[5].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsPrevWeekPkgBasic.Text != "")
            {
                RefundPrevWeekCount = RefundPrevWeekCount + Convert.ToInt32(lblRefundsPrevWeekPkgBasic.Text);
            }
            else
            {
                lblRefundsPrevWeekPkgBasic.Text = "0";
            }
            if (lblRefundsPrevWeekPkgStandard.Text != "")
            {
                RefundPrevWeekCount = RefundPrevWeekCount + Convert.ToInt32(lblRefundsPrevWeekPkgStandard.Text);
            }
            else
            {
                lblRefundsPrevWeekPkgStandard.Text = "0";
            }
            if (lblRefundsPrevWeekPkgEnhanced.Text != "")
            {
                RefundPrevWeekCount = RefundPrevWeekCount + Convert.ToInt32(lblRefundsPrevWeekPkgEnhanced.Text);
            }
            else
            {
                lblRefundsPrevWeekPkgEnhanced.Text = "0";
            }
            if (lblRefundsPrevWeekPkgSilver.Text != "")
            {
                RefundPrevWeekCount = RefundPrevWeekCount + Convert.ToInt32(lblRefundsPrevWeekPkgSilver.Text);
            }
            else
            {
                lblRefundsPrevWeekPkgSilver.Text = "0";
            }
            if (lblRefundsPrevWeekPkgGold.Text != "")
            {
                RefundPrevWeekCount = RefundPrevWeekCount + Convert.ToInt32(lblRefundsPrevWeekPkgGold.Text);
            }
            else
            {
                lblRefundsPrevWeekPkgGold.Text = "0";
            }
            if (lblRefundsPrevWeekPkgPlatinum.Text != "")
            {
                RefundPrevWeekCount = RefundPrevWeekCount + Convert.ToInt32(lblRefundsPrevWeekPkgPlatinum.Text);
            }
            else
            {
                lblRefundsPrevWeekPkgPlatinum.Text = "0";
            }
            lblRefundsPrevWeekTotal.Text = RefundPrevWeekCount.ToString();
            //............Total Refund Prev Week End...........



            //..........Total Refund This Week Start...........

            if (dsRefundsReport.Tables[6].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[6].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[6].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundsThisWeekPkgBasic.Text = dsRefundsReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[6].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundsThisWeekPkgStandard.Text = dsRefundsReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[6].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundsThisWeekPkgEnhanced.Text = dsRefundsReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[6].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundsThisWeekPkgSilver.Text = dsRefundsReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[6].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundsThisWeekPkgGold.Text = dsRefundsReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[6].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundsThisWeekPkgPlatinum.Text = dsRefundsReport.Tables[6].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundsThisWeekPkgBasic.Text != "")
            {
                RefundThisWeekCount = RefundThisWeekCount + Convert.ToInt32(lblRefundsThisWeekPkgBasic.Text);
            }
            else
            {
                lblRefundsThisWeekPkgBasic.Text = "0";
            }
            if (lblRefundsThisWeekPkgStandard.Text != "")
            {
                RefundThisWeekCount = RefundThisWeekCount + Convert.ToInt32(lblRefundsThisWeekPkgStandard.Text);
            }
            else
            {
                lblRefundsThisWeekPkgStandard.Text = "0";
            }
            if (lblRefundsThisWeekPkgEnhanced.Text != "")
            {
                RefundThisWeekCount = RefundThisWeekCount + Convert.ToInt32(lblRefundsThisWeekPkgEnhanced.Text);
            }
            else
            {
                lblRefundsThisWeekPkgEnhanced.Text = "0";
            }
            if (lblRefundsThisWeekPkgSilver.Text != "")
            {
                RefundThisWeekCount = RefundThisWeekCount + Convert.ToInt32(lblRefundsThisWeekPkgSilver.Text);
            }
            else
            {
                lblRefundsThisWeekPkgSilver.Text = "0";
            }
            if (lblRefundsThisWeekPkgGold.Text != "")
            {
                RefundThisWeekCount = RefundThisWeekCount + Convert.ToInt32(lblRefundsThisWeekPkgGold.Text);
            }
            else
            {
                lblRefundsThisWeekPkgGold.Text = "0";
            }
            if (lblRefundsThisWeekPkgPlatinum.Text != "")
            {
                RefundThisWeekCount = RefundThisWeekCount + Convert.ToInt32(lblRefundsThisWeekPkgPlatinum.Text);
            }
            else
            {
                lblRefundsThisWeekPkgPlatinum.Text = "0";
            }
            lblRefundsThisWeekTotal.Text = RefundThisWeekCount.ToString();
            //............Total Refund This Week End...........



            //..........Total Refund On Monday Start...........

            if (dsRefundsReport.Tables[7].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[7].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[7].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundMonPkgBasic.Text = dsRefundsReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[7].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundMonPkgStandard.Text = dsRefundsReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[7].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundMonPkgEnhanced.Text = dsRefundsReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[7].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundMonPkgSilver.Text = dsRefundsReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[7].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundMonPkgGold.Text = dsRefundsReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[7].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundMonPkgPlatinum.Text = dsRefundsReport.Tables[7].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundMonPkgBasic.Text != "")
            {
                RefundMonCount = RefundMonCount + Convert.ToInt32(lblRefundMonPkgBasic.Text);
            }
            else
            {
                lblRefundMonPkgBasic.Text = "0";
            }
            if (lblRefundMonPkgStandard.Text != "")
            {
                RefundMonCount = RefundMonCount + Convert.ToInt32(lblRefundMonPkgStandard.Text);
            }
            else
            {
                lblRefundMonPkgStandard.Text = "0";
            }
            if (lblRefundMonPkgEnhanced.Text != "")
            {
                RefundMonCount = RefundMonCount + Convert.ToInt32(lblRefundMonPkgEnhanced.Text);
            }
            else
            {
                lblRefundMonPkgEnhanced.Text = "0";
            }
            if (lblRefundMonPkgSilver.Text != "")
            {
                RefundMonCount = RefundMonCount + Convert.ToInt32(lblRefundMonPkgSilver.Text);
            }
            else
            {
                lblRefundMonPkgSilver.Text = "0";
            }
            if (lblRefundMonPkgGold.Text != "")
            {
                RefundMonCount = RefundMonCount + Convert.ToInt32(lblRefundMonPkgGold.Text);
            }
            else
            {
                lblRefundMonPkgGold.Text = "0";
            }
            if (lblRefundMonPkgPlatinum.Text != "")
            {
                RefundMonCount = RefundMonCount + Convert.ToInt32(lblRefundMonPkgPlatinum.Text);
            }
            else
            {
                lblRefundMonPkgPlatinum.Text = "0";
            }
            lblRefundMonTotal.Text = RefundMonCount.ToString();
            //............Total Refund On Monday End...........


            //..........Total Refund On Tuesday Start...........

            if (dsRefundsReport.Tables[8].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[8].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[8].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundTuePkgBasic.Text = dsRefundsReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[8].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundTuePkgStandard.Text = dsRefundsReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[8].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundTuePkgEnhanced.Text = dsRefundsReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[8].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundTuePkgSilver.Text = dsRefundsReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[8].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundTuePkgGold.Text = dsRefundsReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[8].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundTuePkgPlatinum.Text = dsRefundsReport.Tables[8].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundTuePkgBasic.Text != "")
            {
                RefundTueCount = RefundTueCount + Convert.ToInt32(lblRefundTuePkgBasic.Text);
            }
            else
            {
                lblRefundTuePkgBasic.Text = "0";
            }
            if (lblRefundTuePkgStandard.Text != "")
            {
                RefundTueCount = RefundTueCount + Convert.ToInt32(lblRefundTuePkgStandard.Text);
            }
            else
            {
                lblRefundTuePkgStandard.Text = "0";
            }
            if (lblRefundTuePkgEnhanced.Text != "")
            {
                RefundTueCount = RefundTueCount + Convert.ToInt32(lblRefundTuePkgEnhanced.Text);
            }
            else
            {
                lblRefundTuePkgEnhanced.Text = "0";
            }
            if (lblRefundTuePkgSilver.Text != "")
            {
                RefundTueCount = RefundTueCount + Convert.ToInt32(lblRefundTuePkgSilver.Text);
            }
            else
            {
                lblRefundTuePkgSilver.Text = "0";
            }
            if (lblRefundTuePkgGold.Text != "")
            {
                RefundTueCount = RefundTueCount + Convert.ToInt32(lblRefundTuePkgGold.Text);
            }
            else
            {
                lblRefundTuePkgGold.Text = "0";
            }
            if (lblRefundTuePkgPlatinum.Text != "")
            {
                RefundTueCount = RefundTueCount + Convert.ToInt32(lblRefundTuePkgPlatinum.Text);
            }
            else
            {
                lblRefundTuePkgPlatinum.Text = "0";
            }
            lblRefundTueTotal.Text = RefundTueCount.ToString();
            //............Total Refund On Tuesday End...........



            //..........Total Refund On Wednesday Start...........

            if (dsRefundsReport.Tables[9].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[9].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[9].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundWedPkgBasic.Text = dsRefundsReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[9].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundWedPkgStandard.Text = dsRefundsReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[9].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundWedPkgEnhanced.Text = dsRefundsReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[9].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundWedPkgSilver.Text = dsRefundsReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[9].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundWedPkgGold.Text = dsRefundsReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[9].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundWedPkgPlatinum.Text = dsRefundsReport.Tables[9].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundWedPkgBasic.Text != "")
            {
                RefundWedCount = RefundWedCount + Convert.ToInt32(lblRefundWedPkgBasic.Text);
            }
            else
            {
                lblRefundWedPkgBasic.Text = "0";
            }
            if (lblRefundWedPkgStandard.Text != "")
            {
                RefundWedCount = RefundWedCount + Convert.ToInt32(lblRefundWedPkgStandard.Text);
            }
            else
            {
                lblRefundWedPkgStandard.Text = "0";
            }
            if (lblRefundWedPkgEnhanced.Text != "")
            {
                RefundWedCount = RefundWedCount + Convert.ToInt32(lblRefundWedPkgEnhanced.Text);
            }
            else
            {
                lblRefundWedPkgEnhanced.Text = "0";
            }
            if (lblRefundWedPkgSilver.Text != "")
            {
                RefundWedCount = RefundWedCount + Convert.ToInt32(lblRefundWedPkgSilver.Text);
            }
            else
            {
                lblRefundWedPkgSilver.Text = "0";
            }
            if (lblRefundWedPkgGold.Text != "")
            {
                RefundWedCount = RefundWedCount + Convert.ToInt32(lblRefundWedPkgGold.Text);
            }
            else
            {
                lblRefundWedPkgGold.Text = "0";
            }
            if (lblRefundWedPkgPlatinum.Text != "")
            {
                RefundWedCount = RefundWedCount + Convert.ToInt32(lblRefundWedPkgPlatinum.Text);
            }
            else
            {
                lblRefundWedPkgPlatinum.Text = "0";
            }
            lblRefundWedTotal.Text = RefundWedCount.ToString();
            //............Total Refund On Wednesday End...........

            //..........Total Refund On Thursday Start...........

            if (dsRefundsReport.Tables[10].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[10].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[10].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundThuPkgBasic.Text = dsRefundsReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[10].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundThuPkgStandard.Text = dsRefundsReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[10].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundThuPkgEnhanced.Text = dsRefundsReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[10].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundThuPkgSilver.Text = dsRefundsReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[10].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundThuPkgGold.Text = dsRefundsReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[10].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundThuPkgPlatinum.Text = dsRefundsReport.Tables[10].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundThuPkgBasic.Text != "")
            {
                RefundThuCount = RefundThuCount + Convert.ToInt32(lblRefundThuPkgBasic.Text);
            }
            else
            {
                lblRefundThuPkgBasic.Text = "0";
            }
            if (lblRefundThuPkgStandard.Text != "")
            {
                RefundThuCount = RefundThuCount + Convert.ToInt32(lblRefundThuPkgStandard.Text);
            }
            else
            {
                lblRefundThuPkgStandard.Text = "0";
            }
            if (lblRefundThuPkgEnhanced.Text != "")
            {
                RefundThuCount = RefundThuCount + Convert.ToInt32(lblRefundThuPkgEnhanced.Text);
            }
            else
            {
                lblRefundThuPkgEnhanced.Text = "0";
            }
            if (lblRefundThuPkgSilver.Text != "")
            {
                RefundThuCount = RefundThuCount + Convert.ToInt32(lblRefundThuPkgSilver.Text);
            }
            else
            {
                lblRefundThuPkgSilver.Text = "0";
            }
            if (lblRefundThuPkgGold.Text != "")
            {
                RefundThuCount = RefundThuCount + Convert.ToInt32(lblRefundThuPkgGold.Text);
            }
            else
            {
                lblRefundThuPkgGold.Text = "0";
            }
            if (lblRefundThuPkgPlatinum.Text != "")
            {
                RefundThuCount = RefundThuCount + Convert.ToInt32(lblRefundThuPkgPlatinum.Text);
            }
            else
            {
                lblRefundThuPkgPlatinum.Text = "0";
            }
            lblRefundThuTotal.Text = RefundThuCount.ToString();
            //............Total Refund On Thursday End...........
            //..........Total Refund On Friday Start...........

            if (dsRefundsReport.Tables[11].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[11].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[11].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundFriPkgBasic.Text = dsRefundsReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[11].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundFriPkgStandard.Text = dsRefundsReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[11].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundFriPkgEnhanced.Text = dsRefundsReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[11].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundFriPkgSilver.Text = dsRefundsReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[11].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundFriPkgGold.Text = dsRefundsReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[11].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundFriPkgPlatinum.Text = dsRefundsReport.Tables[11].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundFriPkgBasic.Text != "")
            {
                RefundFriCount = RefundFriCount + Convert.ToInt32(lblRefundFriPkgBasic.Text);
            }
            else
            {
                lblRefundFriPkgBasic.Text = "0";
            }
            if (lblRefundFriPkgStandard.Text != "")
            {
                RefundFriCount = RefundFriCount + Convert.ToInt32(lblRefundFriPkgStandard.Text);
            }
            else
            {
                lblRefundFriPkgStandard.Text = "0";
            }
            if (lblRefundFriPkgEnhanced.Text != "")
            {
                RefundFriCount = RefundFriCount + Convert.ToInt32(lblRefundFriPkgEnhanced.Text);
            }
            else
            {
                lblRefundFriPkgEnhanced.Text = "0";
            }
            if (lblRefundFriPkgSilver.Text != "")
            {
                RefundFriCount = RefundFriCount + Convert.ToInt32(lblRefundFriPkgSilver.Text);
            }
            else
            {
                lblRefundFriPkgSilver.Text = "0";
            }
            if (lblRefundFriPkgGold.Text != "")
            {
                RefundFriCount = RefundFriCount + Convert.ToInt32(lblRefundFriPkgGold.Text);
            }
            else
            {
                lblRefundFriPkgGold.Text = "0";
            }
            if (lblRefundFriPkgPlatinum.Text != "")
            {
                RefundFriCount = RefundFriCount + Convert.ToInt32(lblRefundFriPkgPlatinum.Text);
            }
            else
            {
                lblRefundFriPkgPlatinum.Text = "0";
            }
            lblRefundFriTotal.Text = RefundFriCount.ToString();
            //............Total Refund On Friday End...........

            //..........Total Refund On Saturday Start...........

            if (dsRefundsReport.Tables[12].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[12].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[12].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundSatPkgBasic.Text = dsRefundsReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[12].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundSatPkgStandard.Text = dsRefundsReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[12].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundSatPkgEnhanced.Text = dsRefundsReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[12].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundSatPkgSilver.Text = dsRefundsReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[12].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundSatPkgGold.Text = dsRefundsReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[12].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundSatPkgPlatinum.Text = dsRefundsReport.Tables[12].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundSatPkgBasic.Text != "")
            {
                RefundSatCount = RefundSatCount + Convert.ToInt32(lblRefundSatPkgBasic.Text);
            }
            else
            {
                lblRefundSatPkgBasic.Text = "0";
            }
            if (lblRefundSatPkgStandard.Text != "")
            {
                RefundSatCount = RefundSatCount + Convert.ToInt32(lblRefundSatPkgStandard.Text);
            }
            else
            {
                lblRefundSatPkgStandard.Text = "0";
            }
            if (lblRefundSatPkgEnhanced.Text != "")
            {
                RefundSatCount = RefundSatCount + Convert.ToInt32(lblRefundSatPkgEnhanced.Text);
            }
            else
            {
                lblRefundSatPkgEnhanced.Text = "0";
            }
            if (lblRefundSatPkgSilver.Text != "")
            {
                RefundSatCount = RefundSatCount + Convert.ToInt32(lblRefundSatPkgSilver.Text);
            }
            else
            {
                lblRefundSatPkgSilver.Text = "0";
            }
            if (lblRefundSatPkgGold.Text != "")
            {
                RefundSatCount = RefundSatCount + Convert.ToInt32(lblRefundSatPkgGold.Text);
            }
            else
            {
                lblRefundSatPkgGold.Text = "0";
            }
            if (lblRefundSatPkgPlatinum.Text != "")
            {
                RefundSatCount = RefundSatCount + Convert.ToInt32(lblRefundSatPkgPlatinum.Text);
            }
            else
            {
                lblRefundSatPkgPlatinum.Text = "0";
            }
            lblRefundSatTotal.Text = RefundSatCount.ToString();
            //............Total Refund On Saturday End...........

            //..........Total Refund On Sunday Start...........

            if (dsRefundsReport.Tables[13].Rows.Count > 0)
            {
                for (int i = 0; i < dsRefundsReport.Tables[13].Rows.Count; i++)
                {
                    if (dsRefundsReport.Tables[13].Rows[i]["PackageID"].ToString() == "1")
                    {
                        lblRefundSunPkgBasic.Text = dsRefundsReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[13].Rows[i]["PackageID"].ToString() == "2")
                    {
                        lblRefundSunPkgStandard.Text = dsRefundsReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[13].Rows[i]["PackageID"].ToString() == "3")
                    {
                        lblRefundSunPkgEnhanced.Text = dsRefundsReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[13].Rows[i]["PackageID"].ToString() == "4")
                    {
                        lblRefundSunPkgSilver.Text = dsRefundsReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[13].Rows[i]["PackageID"].ToString() == "5")
                    {
                        lblRefundSunPkgGold.Text = dsRefundsReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                    if (dsRefundsReport.Tables[13].Rows[i]["PackageID"].ToString() == "6")
                    {
                        lblRefundSunPkgPlatinum.Text = dsRefundsReport.Tables[13].Rows[i]["Total"].ToString();
                    }
                }
            }
            if (lblRefundSunPkgBasic.Text != "")
            {
                RefundSunCount = RefundSunCount + Convert.ToInt32(lblRefundSunPkgBasic.Text);
            }
            else
            {
                lblRefundSunPkgBasic.Text = "0";
            }
            if (lblRefundSunPkgStandard.Text != "")
            {
                RefundSunCount = RefundSunCount + Convert.ToInt32(lblRefundSunPkgStandard.Text);
            }
            else
            {
                lblRefundSunPkgStandard.Text = "0";
            }
            if (lblRefundSunPkgEnhanced.Text != "")
            {
                RefundSunCount = RefundSunCount + Convert.ToInt32(lblRefundSunPkgEnhanced.Text);
            }
            else
            {
                lblRefundSunPkgEnhanced.Text = "0";
            }
            if (lblRefundSunPkgSilver.Text != "")
            {
                RefundSunCount = RefundSunCount + Convert.ToInt32(lblRefundSunPkgSilver.Text);
            }
            else
            {
                lblRefundSunPkgSilver.Text = "0";
            }
            if (lblRefundSunPkgGold.Text != "")
            {
                RefundSunCount = RefundSunCount + Convert.ToInt32(lblRefundSunPkgGold.Text);
            }
            else
            {
                lblRefundSunPkgGold.Text = "0";
            }
            if (lblRefundSunPkgPlatinum.Text != "")
            {
                RefundSunCount = RefundSunCount + Convert.ToInt32(lblRefundSunPkgPlatinum.Text);
            }
            else
            {
                lblRefundSunPkgPlatinum.Text = "0";
            }
            lblRefundSunTotal.Text = RefundSunCount.ToString();
            //............Total Refund On Sunday End...........

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
