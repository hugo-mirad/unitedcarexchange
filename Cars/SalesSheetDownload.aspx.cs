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
using CarsBL.RvTransactions;

public partial class SalesSheetDownload : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
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

            }
        }
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdbtncarSales.Checked == true)
            {
                Session["SalesFrom"] = "Cars";
            }
            else if (rdbtnRVSales.Checked == true)
            {
                Session["SalesFrom"] = "Rvs";
            }
            GetSales();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetSales()
    {
        try
        {
            DataSet dsSalesData = new DataSet();
            string SelectedTyepe = string.Empty;
            if (Session["SalesFrom"] == "Cars")
            {
                SelectedTyepe = "CarSales";
                dsSalesData = objdropdownBL.SmartzGetSalesDataForCars();
            }
            else if (Session["SalesFrom"] == "Rvs")
            {
                SelectedTyepe = "RvSales";
                dsSalesData = objRvMainBL.USP_SmartzGetSalesDataForRvs();
            }
            if (dsSalesData.Tables[0].Rows.Count > 0)
            {
                DataSetToExcel.Convert(dsSalesData, Response, SelectedTyepe);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
