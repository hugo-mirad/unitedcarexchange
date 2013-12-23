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
using CarsBL.CentralDBTransactions;
using CarsInfo;
using System.Net.Mail;
using CarsBL.Masters;
using CarsBL.RvTransactions;
using System.Net;
using System.IO;

public partial class PDDateDetails : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSmartzUsers = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    RvMainBL objRVMainBL = new RvMainBL();
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
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                Session["PDPAYSEL"] = "Cars";
                int TypeID = 2;
                divCars.Style["display"] = "block";
                DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Top 500 results shown for all post date payment sales data";
                }
                else
                {
                    grdPDPayData.Visible = true;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for all post date payment sales data";
                }
            }
        }
    }


    protected void rdbtnPaid_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            int TypeID = 3;
            divCars.Style["display"] = "block";
            DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
            Session["dsCarPDData"] = dsPDData;
            if (dsPDData.Tables[0].Rows.Count > 0)
            {
                grdPDPayData.Visible = true;
                grdPDPayData.DataSource = dsPDData.Tables[0];
                grdPDPayData.DataBind();
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Top 500 results shown for paid status post date payment sales data";
            }
            else
            {
                grdPDPayData.Visible = false;
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results not found for paid status post date payment sales data";
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPending_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPAYSEL"].ToString() == "Cars")
            {
                int TypeID = 2;
                divCars.Style["display"] = "block";

                DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Top 500 results shown for pending status post date payment sales data";
                }
                else
                {
                    grdPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for pending status post date payment sales data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnAll_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPAYSEL"].ToString() == "Cars")
            {
                int TypeID = 1;
                divCars.Style["display"] = "block";

                DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Top 500 results shown for all post date payment sales data";
                }
                else
                {
                    grdPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for all post date payment sales data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbtnAdminCancel_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPAYSEL"].ToString() == "Cars")
            {
                int TypeID = 4;
                divCars.Style["display"] = "block";

                DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Top 500 results shown for all post date admin cancel sales data";
                }
                else
                {
                    grdPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for all post date admin cancel sales data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdPDPayData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                Label lblPhone = (Label)e.Row.FindControl("lblPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackName.Value.ToString();
                lblPackage.Text = PackName + "($" + PackAmount + ")";
                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if (hdnStatus.Value.ToString() == "1")
                {

                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else if (hdnStatus.Value.ToString() == "2")
                {

                    ImgStatus.ImageUrl = "~/images/lock.gif";
                }
                else if (hdnStatus.Value.ToString() == "3")
                {

                    ImgStatus.ImageUrl = "~/images/icon13.png";
                }
                else if (hdnStatus.Value.ToString() == "4")
                {
                    ImgStatus.ImageUrl = "~/images/icon14.gif";
                }
                else if (hdnStatus.Value.ToString() == "5")
                {
                    ImgStatus.ImageUrl = "~/images/red_x.png";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    private string CreateTable()
    {
        string strTransaction = string.Empty;
        strTransaction = "<table width=\"120px\" id=\"SalesStatus\" style=\"display: block; background-color:#F3D9F6;border:2px;border-color:Black;height:110px \">";

        strTransaction += "<tr id=\"CampaignsBody3\">";
        strTransaction += "<td  style=\"padding-left:10px;\" >";
        strTransaction += "Active:";
        strTransaction += "</td>";
        strTransaction += "<td>";
        strTransaction += "<img src=\"images/check.gif\" />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Preliminary:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/lock.gif\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Withdraw:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/icon13.png\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Sold:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/icon14.gif\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";

        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Admin Cancel:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/red_x.png\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";


        strTransaction += "<tr id=\"CampaignsTitle11\">";
        strTransaction += "<td colspan=\"2\">";
        strTransaction += "<br />";
        strTransaction += "<br />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += "</table>";

        return strTransaction;

    }
    protected void lblCarID_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblCarID.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblCarID.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblCarID.Text = "Car ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblCarID.Text = "Car ID &#8659";
            }

            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblAdStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "AdStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblAdStatus.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblAdStatus.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblAdStatus.Text = "Ad St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblAdStatus.Text = "Ad St &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblSaleDate_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SaleDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblSaleDate.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblSaleDate.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblSaleDate.Text = "Sale Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblSaleDate.Text = "Sale Dt &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblPostDate_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "dateOfPosting";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblPostDate.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblPostDate.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblPostDate.Text = "Posted Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblPostDate.Text = "Posted Dt &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblPDDate_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PDDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblPDDate.Text = "PD Pay Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblPDDate.Text = "PD Pay Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblPDDate.Text = "PD Pay Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblPDDate.Text = "PD Pay Dt &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblPaymentDate_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PaymentDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblPaymentDate.Text = "Payment Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblPaymentDate.Text = "Payment Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblPaymentDate.Text = "Payment Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblPaymentDate.Text = "Payment Dt &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblAgent_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Agent_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblAgent.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblAgent.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblAgent.Text = "Agent &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblAgent.Text = "Agent &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblYear_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "yearOfMake";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblYear.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblYear.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblYear.Text = "Year &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblYear.Text = "Year &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblMake_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblMake.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblMake.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblMake.Text = "Make &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblMake.Text = "Make &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblModel_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "model";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblModel.Text = "Model &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblModel.Text = "Model &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblModel.Text = "Model &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblModel.Text = "Model &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblPackage_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Price";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblPackage.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblPackage.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblPackage.Text = "Package &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblPackage.Text = "Package &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblName.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblName.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblName.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblName.Text = "Name &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblPhone_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PhoneNum";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblPhone.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblPhone.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblPhone.Text = "Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblPhone.Text = "Phone &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblEmail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "email";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblEmail.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblEmail.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblEmail.Text = "Email &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblEmail.Text = "Email &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkPDAmount_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PDAmount";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPDAmount.Text = "PD Amount &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPDAmount.Text = "PD Amount &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPDAmount.Text = "PD Amount &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPDAmount.Text = "PD Amount &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPaidAmount.Text = "Paid Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkPaidAmount_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Amount";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPaidAmount.Text = "Paid Amount &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPaidAmount.Text = "Paid Amount &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPaidAmount.Text = "Paid Amount &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPaidAmount.Text = "Paid Amount &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkPDAmount.Text = "PD Amount &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnPDStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PDPmntStatusName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnPDStatus.Text = "PD Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnPDStatus.Text = "PD Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnPDStatus.Text = "PD Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnPDStatus.Text = "PD Status &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkbtnPayStatus.Text = "Pay Status &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnPayStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsCarPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PmntStatusName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnPayStatus.Text = "Pay Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnPayStatus.Text = "Pay Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnPayStatus.Text = "Pay Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnPayStatus.Text = "Pay Status &#8659";
            }

            lblCarID.Text = "Car ID &darr; &uarr;";
            lblAdStatus.Text = "Ad St &darr; &uarr;";
            lblSaleDate.Text = "Sale Dt &darr; &uarr;";
            lblPostDate.Text = "Posted Dt &darr; &uarr;";
            lblPDDate.Text = "PD Pay Dt &darr; &uarr;";
            lblPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblAgent.Text = "Agent &darr; &uarr;";
            lblYear.Text = "Year &darr; &uarr;";
            lblMake.Text = "Make &darr; &uarr;";
            lblModel.Text = "Model &darr; &uarr;";
            lblPackage.Text = "Package &darr; &uarr;";
            lblName.Text = "Name &darr; &uarr;";
            lblPhone.Text = "Phone &darr; &uarr;";
            lblEmail.Text = "Email &darr; &uarr;";
            lnkbtnPDStatus.Text = "PD Status &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int PmntStatus = Convert.ToInt32(ddlPaymentStatus.SelectedItem.Value);
            int PDID = Convert.ToInt32(Session["QCPayUpPDID"].ToString());
            int PaymentID = Convert.ToInt32(Session["QCPayUpPmntID"].ToString());
            int PostingID = Convert.ToInt32(Session["PDPostingID"].ToString());
            string Amount = txtPaymentAmountInPop.Text;
            string TransactionID = txtPaytransID.Text;
            DateTime PDdate;
            if (PmntStatus == 2)
            {
                PDdate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
            }
            else
            {
                PDdate = Convert.ToDateTime("1/1/1990");
            }
            DataSet dsUpdatePayInfo = objdropdownBL.UpdatePDPaymentStatus(PostingID, PaymentID, PDID, PmntStatus, TransactionID, PDdate, Amount);
            int CarID = Convert.ToInt32(Session["QCPayUpCarIDID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = "PD payment status changed to " + ddlPaymentStatus.SelectedItem.Text;
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
            MPEUpdate.Hide();
            Session["PDPopType"] = "Manual";
            if (PmntStatus == 2)
            {
                mdepAlertStatusUpdated.Show();
                lblCBAlertMsg.Visible = true;
                lblCBAlertMsg.Text = "Do you want to active all car(s) belonging to this package?";
            }
            else
            {
                int TypeID = 2;
                divCars.Style["display"] = "block";
                DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
                Session["dsCarPDData"] = dsPDData;
                rdbtnPending.Checked = true;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Top 500 results shown for all post date payment sales data";
                }
                else
                {
                    grdPDPayData.Visible = true;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for all post date payment sales data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAlertStatusYes_Click(object sender, EventArgs e)
    {
        try
        {
            int PostingID = Convert.ToInt32(Session["PDPostingID"].ToString());
            DataSet ds = objdropdownBL.UpdateCarStatusForPDPaid(PostingID);
            mdepAlertStatusUpdated.Hide();
            int TypeID = 2;
            divCars.Style["display"] = "block";
            DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
            Session["dsCarPDData"] = dsPDData;
            rdbtnPending.Checked = true;
            if (dsPDData.Tables[0].Rows.Count > 0)
            {
                grdPDPayData.Visible = true;
                grdPDPayData.DataSource = dsPDData.Tables[0];
                grdPDPayData.DataBind();
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Top 500 results shown for all post date payment sales data";
            }
            else
            {
                grdPDPayData.Visible = true;
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results not found for all post date payment sales data";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAlertStatusNo_Click(object sender, EventArgs e)
    {
        try
        {
            mdepAlertStatusUpdated.Hide();
            int TypeID = 2;
            divCars.Style["display"] = "block";
            DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
            Session["dsCarPDData"] = dsPDData;
            rdbtnPending.Checked = true;
            if (dsPDData.Tables[0].Rows.Count > 0)
            {
                grdPDPayData.Visible = true;
                grdPDPayData.DataSource = dsPDData.Tables[0];
                grdPDPayData.DataBind();
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Top 500 results shown for all post date payment sales data";
            }
            else
            {
                grdPDPayData.Visible = true;
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results not found for all post date payment sales data";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnCCProcess_Click(object sender, EventArgs e)
    {
        try
        {
            btnCCProcess.Enabled = false;
            btnUpdate.Enabled=false;
            btnCancelUpdate.Enabled = false;
            AuthorizePayment();
            btnCCProcess.Enabled = true;
            btnUpdate.Enabled = true;
            btnCancelUpdate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private bool AuthorizePayment()
    {
        //CustomValidator1.ErrorMessage = "";
        string AuthNetVersion = "3.1"; // Contains CCV support
        string AuthNetLoginID = "9FtTpx88g879"; //Set your AuthNetLoginID here
        string AuthNetTransKey = "9Gp3Au9t97Wvb784";  // Get this from your authorize.net merchant interface

        WebClient webClientRequest = new WebClient();
        System.Collections.Specialized.NameValueCollection InputObject = new System.Collections.Specialized.NameValueCollection(30);
        System.Collections.Specialized.NameValueCollection ReturnObject = new System.Collections.Specialized.NameValueCollection(30);

        byte[] ReturnBytes;
        string[] ReturnValues;
        string ErrorString;
        //(TESTMODE) Bill To Company is required. (33) 

        InputObject.Add("x_version", AuthNetVersion);
        InputObject.Add("x_delim_data", "True");
        InputObject.Add("x_login", AuthNetLoginID);
        InputObject.Add("x_tran_key", AuthNetTransKey);
        InputObject.Add("x_relay_response", "False");

        //----------------------Set to False to go Live--------------------
        InputObject.Add("x_test_request", "False");
        //---------------------------------------------------------------------
        InputObject.Add("x_delim_char", ",");
        InputObject.Add("x_encap_char", "|");

        //Billing Address
        InputObject.Add("x_first_name", lblCardHolderName.Text);
        InputObject.Add("x_last_name", lblCardHolderLastName.Text);
        InputObject.Add("x_phone", lblPayInfoPhone.Text);
        InputObject.Add("x_address", lblBillingAddress.Text);
        InputObject.Add("x_city", lblBillingCity.Text);
        InputObject.Add("x_state", lblBillingState.Text);
        InputObject.Add("x_zip", lblBillingZip.Text);

        if (lblPayInfoEmail.Text != "")
        {
            InputObject.Add("x_email", lblPayInfoEmail.Text);
        }
        else
        {
            InputObject.Add("x_email", "info@unitedcarexchange.com");
        }

        InputObject.Add("x_email_customer", "TRUE");                     //Emails Customer
        InputObject.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
        InputObject.Add("x_country", "USA");
        InputObject.Add("x_customer_ip", Request.UserHostAddress);  //Store Customer IP Address

        //Amount
        string Package = string.Empty;
        if (Session["QCPayUpPackageID"].ToString() == "5")
        {
            Package = "Gold Deluxe Promo Package – No cancellations allowed; All sales are final";
        }
        else if (Session["QCPayUpPackageID"].ToString() == "4")
        {
            Package = "Silver Deluxe Promo Package – no cancellations and no refunds allowed; All sales are final";
        }
        else
        {
            Package = lblPoplblPackage.Text;
        }
        //var string = $('#ddlPackage option:selected').text();
        //var p =string.split('$');
        //var pp = p[1].split(')');
        ////alert(pp[0]);
        ////pp[0] = parseInt(pp[0]);
        //pp[0] = parseFloat(pp[0]);
        //var selectedPack = pp[0].toFixed(2);       

        InputObject.Add("x_description", "Payment to " + Package);
        InputObject.Add("x_invoice_num", lblPayInfoVoiceConfNo.Text);
        //string.Format("{0:00}", Convert.ToDecimal(lblAdPrice2.Text))) + "Dollars
        //Description of Purchase

        //lblPackDescrip.Text 
        //Card Details
        InputObject.Add("x_card_num", lblCCNumber.Text);
        InputObject.Add("x_exp_date", lblCCExpiryDate.Text);
        InputObject.Add("x_card_code", lblCvv.Text);

        InputObject.Add("x_method", "CC");
        InputObject.Add("x_type", "AUTH_CAPTURE");

        InputObject.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(hdnPophdnAmount.Value)));

        //InputObject.Add("x_amount", string.Format("{0:c2}", lblAdPrice2));
        // Currency setting. Check the guide for other supported currencies
        InputObject.Add("x_currency_code", "USD");


        try
        {
            //Actual Server
            //Set above Testmode=off to go live
            webClientRequest.BaseAddress = "https://secure.authorize.net/gateway/transact.dll";

            ReturnBytes = webClientRequest.UploadValues(webClientRequest.BaseAddress, "POST", InputObject);
            ReturnValues = System.Text.Encoding.ASCII.GetString(ReturnBytes).Split(",".ToCharArray());

            if (ReturnValues[0].Trim(char.Parse("|")) == "1")
            {

                ///Successs 

                string AuthNetCode = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                string AuthNetTransID = ReturnValues[6].Trim(char.Parse("|")); // Returned Transaction ID

                //Response.Redirect("PaymentSucces.aspx?NetCode=" + ReturnValues[4].Trim(char.Parse("|")) + "&tx=" + ReturnValues[6].Trim(char.Parse("|")) + "&amt=" + txtPDAmountNow.Text + "&item_number=" + Session["PackageID"].ToString() + "");

                string PayInfo = "Payment paid for amount $" + hdnPophdnAmount.Value + " <br />Authorisation Code" + ReturnValues[4].Trim(char.Parse("|")) + "<br />TransID=" + ReturnValues[6].Trim(char.Parse("|")); // Returned Authorisation Code;
                // String UpdatedBy = Session[Constants.NAME].ToString();
                //DataSet dsDatetime = objHotLeadBL.GetDatetime();
                //DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                //string PayNotes = "Payment Successfully processed for $" + txtPDAmountNow.Text + "  <br>Authorisation Code " + ReturnValues[4].Trim(char.Parse("|")) + " <br> TransID=" + ReturnValues[6].Trim(char.Parse("|")) + "<br> By " + UpdatedBy + "-" + dtNow.ToString("MM/dd/yyyy hh:mm tt"); // Returned Authorisation Code;                
                string Result = "Paid";
                //string PackCost1 = ddlPackage.SelectedItem.Text;
                //string[] Pack1 = PackCost1.Split('$');
                //string[] FinalAmountSpl1 = Pack1[1].Split(')');
                //string FinalAmount1 = FinalAmountSpl1[0].ToString();
                //Result = "Paid";
                int PmntStatus = Convert.ToInt32(2);
                int PDID = Convert.ToInt32(Session["QCPayUpPDID"].ToString());
                int PaymentID = Convert.ToInt32(Session["QCPayUpPmntID"].ToString());
                int PostingID = Convert.ToInt32(Session["PDPostingID"].ToString());
                string Amount = hdnPophdnAmount.Value;
                string TransactionID = AuthNetTransID;
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime PDdate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                DataSet dsUpdatePayInfo = objdropdownBL.UpdatePDPaymentStatus(PostingID, PaymentID, PDID, PmntStatus, TransactionID, PDdate, Amount);

                int CarID = Convert.ToInt32(Session["QCPayUpCarIDID"].ToString());
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                String UpdatedBy = Session[Constants.NAME].ToString();
                string InternalNotesNew = "Payment paid for amount $" + hdnPophdnAmount.Value + " <br>Authorisation Code" + ReturnValues[4].Trim(char.Parse("|")) + "<br>TransID=" + ReturnValues[6].Trim(char.Parse("|")); // Returned Authorisation Code;
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                Session["PDPopType"] = "Process";
                lblErrUpdated.Text = PayInfo;
                lblErrUpdated.Visible = true;
                MPEUpdate.Hide();
                mpealteruserUpdated.Show();

                return true;
            }
            else
            {

                ///Failure
                // Error!
                ErrorString = ReturnValues[3].Trim(char.Parse("|")) + " (" + ReturnValues[2].Trim(char.Parse("|")) + ") " + ReturnValues[4].Trim(char.Parse("|"));

                if (ReturnValues[2].Trim(char.Parse("|")) == "44")
                {
                    // CCV transaction decline
                    ErrorString += "Credit Card Code Verification (CCV) returned the following error: ";

                    switch (ReturnValues[38].Trim(char.Parse("|")))
                    {
                        case "N":
                            ErrorString += "Card Code does not match.";
                            break;
                        case "P":
                            ErrorString += "Card Code was not processed.";
                            break;
                        case "S":
                            ErrorString += "Card Code should be on card but was not indicated.";
                            break;
                        case "U":
                            ErrorString += "Issuer was not certified for Card Code.";
                            break;
                    }
                }

                if (ReturnValues[2].Trim(char.Parse("|")) == "45")
                {
                    if (ErrorString.Length > 1)
                        ErrorString += "<br />n";

                    // AVS transaction decline
                    ErrorString += "Address Verification System (AVS) " +
                      "returned the following error: ";

                    switch (ReturnValues[5].Trim(char.Parse("|")))
                    {
                        case "A":
                            ErrorString += " the zip code entered does not match the billing address.";
                            break;
                        case "B":
                            ErrorString += " no information was provided for the AVS check.";
                            break;
                        case "E":
                            ErrorString += " a general error occurred in the AVS system.";
                            break;
                        case "G":
                            ErrorString += " the credit card was issued by a non-US bank.";
                            break;
                        case "N":
                            ErrorString += " neither the entered street address nor zip code matches the billing address.";
                            break;
                        case "P":
                            ErrorString += " AVS is not applicable for this transaction.";
                            break;
                        case "R":
                            ErrorString += " please retry the transaction; the AVS system was unavailable or timed out.";
                            break;
                        case "S":
                            ErrorString += " the AVS service is not supported by your credit card issuer.";
                            break;
                        case "U":
                            ErrorString += " address information is unavailable for the credit card.";
                            break;
                        case "W":
                            ErrorString += " the 9 digit zip code matches, but the street address does not.";
                            break;
                        case "Z":
                            ErrorString += " the zip code matches, but the address does not.";
                            break;
                    }
                }

                Session["PayCancelError"] = ErrorString;
                //int PSID = Convert.ToInt32(Session["AgentQCPSID1"].ToString());
                //int PaymentID = Convert.ToInt32(Session["AgentQCPaymentID"].ToString());
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                int PSStatusID = Convert.ToInt32(3);
                int PmntStatus = 1;
                //DataSet dsUpdatePaynotes = objHotLeadBL.UpdateQCPayNotesForProcessButton(PSID, UID, ErrorString, PSStatusID, PmntStatus, PaymentID);
                string AuthNetTransID = "";
                string Result = "Pending";
                // SavePayTransInfo(AuthNetTransID, Result);
                ErrorString = "Payment is DECLINED <br /> " + ErrorString;

                int CarID = Convert.ToInt32(Session["QCPayUpCarIDID"].ToString());

                String UpdatedBy = Session[Constants.NAME].ToString();
                string ErrorText = ErrorString;
                string ErrorMsg = ErrorString.Replace("<br />", "<br>");
                string InternalNotesNew = "Payment is DECLINED <br> " + ErrorString;
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                Session["PDPopType"] = "ProcessFailed";
                lblErrUpdated.Text = ErrorText;
                lblErrUpdated.Visible = true;
                MPEUpdate.Hide();
                mpealteruserUpdated.Show();

                // ErrorString contains the actual error
                //CustomValidator1.ErrorMessage = ErrorString;
                return false;
            }
        }
        catch (Exception ex)
        {
            //CustomValidator1.ErrorMessage = ex.Message;
            return false;
        }
    }
    protected void BtnClsUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPopType"].ToString() == "Process")
            {
                mpealteruserUpdated.Hide();
                mdepAlertStatusUpdated.Show();
                lblCBAlertMsg.Visible = true;
                lblCBAlertMsg.Text = "Do you want to active all car(s) belonging to this package?";
            }
            else
            {
                mpealteruserUpdated.Hide();
                int TypeID = 2;
                divCars.Style["display"] = "block";
                DataSet dsPDData = objdropdownBL.GetPDPaymentDataInformation(TypeID);
                Session["dsCarPDData"] = dsPDData;
                rdbtnPending.Checked = true;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Top 500 results shown for all post date payment sales data";
                }
                else
                {
                    grdPDPayData.Visible = true;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for all post date payment sales data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCheckProcess_Click(object sender, EventArgs e)
    {
        try
        {
            GoWithCheck();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GoWithCheck()
    {
        try
        {
            // By default, this sample code is designed to post to our test server for
            // developer accounts: https://test.authorize.net/gateway/transact.dll
            // for real accounts (even in test mode), please make sure that you are
            string post_url = "https://secure.authorize.net/gateway/transact.dll";
            //String post_url = "https://test.authorize.net/gateway/transact.dll";

            //The valid routing number of the customer’s bank 9 digits
            string sBankCode = string.Empty;
            sBankCode = lblRouting.Text;

            //The customer’s valid bank account number Up to 20 digits The customer’s checking,
            string sBankaccountnumber = string.Empty;
            sBankaccountnumber = lblAccNumber.Text;
            //The type of bank account CHECKING,BUSINESSCHECKING,SAVINGS
            string sBankType = lblAccType.Text;


            //The name of the bank that holds the customer’s account Up to 50 characters
            string sbank_name = lblBankName.Text;

            //The name of the bank that holds the customer’s account Up to 50 characters
            string sbank_acct_name = lblAccHolderName.Text;
            //The type of electronic check payment request.Types," page 10 of this document.
            //ARC, BOC, CCD, PPD, TEL,WEB
            string echeck_type = "TEL";

            string sbank_check_number = "";




            string AuthNetVersion = "3.1"; // Contains CCV support
            string AuthNetLoginID = "9FtTpx88g879"; //Set your AuthNetLoginID here
            string AuthNetTransKey = "9Gp3Au9t97Wvb784";  // Get this from your authorize.net merchant interface


            Dictionary<string, string> post_values = new Dictionary<string, string>();
            //the API Login ID and Transaction Key must be replaced with valid values

            post_values.Add("x_login", AuthNetLoginID);
            post_values.Add("x_tran_key", AuthNetTransKey);
            post_values.Add("x_delim_data", "TRUE");
            post_values.Add("x_delim_char", "|");
            post_values.Add("x_relay_response", "FALSE");

            post_values.Add("x_type", "AUTH_CAPTURE");
            post_values.Add("x_method", "ECHECK");
            post_values.Add("x_bank_aba_code", sBankCode);
            post_values.Add("x_bank_acct_num", sBankaccountnumber);
            post_values.Add("x_bank_acct_type", sBankType);

            post_values.Add("x_bank_name", sbank_name);
            post_values.Add("x_bank_acct_name", sbank_acct_name);
            post_values.Add("x_echeck_type", echeck_type);
            post_values.Add("x_bank_check_number", sbank_check_number);

            post_values.Add("x_recurring_billing", "False");

            string Package = string.Empty;
            if (Session["QCPayUpPackageID"].ToString() == "5")
            {
                Package = "Gold Deluxe Promo Package – No cancellations allowed; All sales are final";
            }
            else if (Session["QCPayUpPackageID"].ToString() == "4")
            {
                Package = "Silver Deluxe Promo Package – no cancellations and no refunds allowed; All sales are final";
            }
            else
            {
                Package = lblPoplblPackage.Text;
            }


            post_values.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(hdnPophdnAmount.Value)));
            //post_values.Add("x_amount", txtPDAmountNow.Text);
            post_values.Add("x_description", Package);
            post_values.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
            post_values.Add("x_first_name", hdnRegName.Value);
            post_values.Add("x_last_name", hdnRegLastName.Value);
            post_values.Add("x_address", hdnRegAddress.Value);
            post_values.Add("x_state", hdnRegState.Value);
            post_values.Add("x_zip", hdnRegZip.Value);
            post_values.Add("x_city", hdnRegCity.Value);
            post_values.Add("x_phone", lblPayInfoPhone.Text);
            // Additional fields can be added here as outlined in the AIM integration
            // guide at: http://developer.authorize.net

            // This section takes the input fields and converts them to the proper format
            // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
            String post_string = "";

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');

            // The following section provides an example of how to add line item details to
            // the post string.  Because line items may consist of multiple values with the
            // same key/name, they cannot be simply added into the above array.
            //
            // This section is commented out by default.
            /*
            string[] line_items = {
                "item1<|>golf balls<|><|>2<|>18.95<|>Y",
                "item2<|>golf bag<|>Wilson golf carry bag, red<|>1<|>39.99<|>Y",
                "item3<|>book<|>Golf for Dummies<|>1<|>21.99<|>Y"};
            foreach( string value in line_items )
            {
                post_string += "&x_line_item=" + HttpUtility.UrlEncode(value);
            }
            */

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            // returned values are returned as a stream, then read into a string
            String post_response;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                post_response = responseStream.ReadToEnd();
                responseStream.Close();
            }

            // the response string is broken into an array
            // The split character specified here must match the delimiting character specified above
            Array response_array = post_response.Split('|');
            string resultSpan = string.Empty;
            // the results are output to the screen in the form of an html numbered list.
            resultSpan += response_array.GetValue(3) + "(Response Code " + response_array.GetValue(0) + ")" + "(Response Reason Code " + response_array.GetValue(2) + ")";
            //foreach (string value in response_array)
            //{
            //    resultSpan += "<LI>" + value + "&nbsp;</LI> \n";
            //}
            //resultSpan += "</OL> \n";
            // individual elements of the array could be accessed to read certain response
            // fields.  For example, response_array[0] would return the Response Code,
            // response_array[2] would return the Response Reason Code.
            // for a list of response fields, please review the AIM Implementation Guide
            if (response_array.GetValue(0).ToString() == "1")
            {
                //Success
                //string AuthNetCode = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                string AuthNetTransID = response_array.GetValue(6).ToString(); // Returned Transaction ID

                //Response.Redirect("PaymentSucces.aspx?NetCode=" + ReturnValues[4].Trim(char.Parse("|")) + "&tx=" + ReturnValues[6].Trim(char.Parse("|")) + "&amt=" + txtPDAmountNow.Text + "&item_number=" + Session["PackageID"].ToString() + "");

                //  string PayInfo = "TransID=" + AuthNetTransID + "<br /> Do you want to move the sale to smartz?"; // Returned Authorisation Code;
                string PayNotes = "TransID=" + AuthNetTransID; // Returned Authorisation Code;                
                string Result = "Paid";

                string PayInfo = "Payment paid for amount $" + hdnPophdnAmount.Value + "<br /> TransID=" + AuthNetTransID; // Returned Authorisation Code;

                int PmntStatus = Convert.ToInt32(2);
                int PDID = Convert.ToInt32(Session["QCPayUpPDID"].ToString());
                int PaymentID = Convert.ToInt32(Session["QCPayUpPmntID"].ToString());
                int PostingID = Convert.ToInt32(Session["PDPostingID"].ToString());
                string Amount = hdnPophdnAmount.Value;
                string TransactionID = AuthNetTransID;
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime PDdate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                DataSet dsUpdatePayInfo = objdropdownBL.UpdatePDPaymentStatus(PostingID, PaymentID, PDID, PmntStatus, TransactionID, PDdate, Amount);

                int CarID = Convert.ToInt32(Session["QCPayUpCarIDID"].ToString());
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                String UpdatedBy = Session[Constants.NAME].ToString();
                string InternalNotesNew = "Payment paid for amount $" + hdnPophdnAmount.Value + "<br>TransID=" + AuthNetTransID; // Returned Authorisation Code;
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                Session["PDPopType"] = "Process";
                lblErrUpdated.Text = PayInfo;
                lblErrUpdated.Visible = true;
                MPEUpdate.Hide();
                mpealteruserUpdated.Show();

                //return true;
            }
            else
            {
                Session["PayCancelError"] = resultSpan;
                //int PSID = Convert.ToInt32(Session["AgentQCPSID1"].ToString());
                //int PaymentID = Convert.ToInt32(Session["AgentQCPaymentID"].ToString());

                int PSStatusID = Convert.ToInt32(3);
                int PmntStatus = 1;
                //DataSet dsUpdatePaynotes = objHotLeadBL.UpdateQCPayNotesForProcessButton(PSID, UID, ErrorString, PSStatusID, PmntStatus, PaymentID);
                string AuthNetTransID = "";
                string Result = "Pending";
                // SavePayTransInfo(AuthNetTransID, Result);
                resultSpan = "Payment is DECLINED <br /> " + resultSpan;
                Session["PDPopType"] = "ProcessFailed";
                int CarID = Convert.ToInt32(Session["QCPayUpCarIDID"].ToString());
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                String UpdatedBy = Session[Constants.NAME].ToString();
                string InternalNotesNew = "Payment is DECLINED <br> " + resultSpan;
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);

                lblErrUpdated.Text = resultSpan;
                lblErrUpdated.Visible = true;
                MPEUpdate.Hide();
                mpealteruserUpdated.Show();

                // ErrorString contains the actual error
                //CustomValidator1.ErrorMessage = ErrorString;
                //return false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdPDPayData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Session["RedirectFrom"] = 5;
                Response.Redirect("CustomerView.aspx");
            }
            if (e.CommandName == "EditPay")
            {
                int postingID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["PDPostingID"] = postingID;
                FillPaymentDate();
                DataSet Cardetais = objdropdownBL.GetPaymentInfoByPostingID(postingID);
                Session["QCPayUpPmntTypeID"] = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["pmntType"].ToString());
                Session["QCPayUpPmntID"] = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PaymentID"].ToString());
                Session["QCPayUpPDID"] = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDID"].ToString());
                Session["QCPayUpCarIDID"] = Convert.ToInt32(Cardetais.Tables[0].Rows[0]["CarID"].ToString());
                lblpaymentPopSaleID.Text = Cardetais.Tables[0].Rows[0]["CarID"].ToString();
                if (Cardetais.Tables[0].Rows[0]["PhoneNumber"].ToString() == "")
                {
                    lblPayInfoPhone.Text = "";
                }
                else
                {
                    lblPayInfoPhone.Text = objGeneralFunc.filPhnm(Cardetais.Tables[0].Rows[0]["PhoneNumber"].ToString());
                }
                lblPayInfoVoiceConfNo.Text = Cardetais.Tables[0].Rows[0]["VoiceRecord"].ToString();
                lblPayInfoEmail.Text = Cardetais.Tables[0].Rows[0]["email"].ToString();
                if (Cardetais.Tables[0].Rows[0]["PaymentDate"].ToString() != "")
                {
                    DateTime PaymentDate = Convert.ToDateTime(Cardetais.Tables[0].Rows[0]["PaymentDate"].ToString());
                    lblPoplblPayDate.Text = PaymentDate.ToString("MM/dd/yyyy");
                    Session["QCPayUpPmntDate"] = PaymentDate.ToString("MM/dd/yyyy");
                }
                lblPoplblPayAmount.Text = Cardetais.Tables[0].Rows[0]["Amount"].ToString();
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(Cardetais.Tables[0].Rows[0]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = Cardetais.Tables[0].Rows[0]["Description"].ToString();
                lblPoplblPackage.Text = PackName + "($" + PackAmount + ")";
                hdnPophdnAmount.Value = Cardetais.Tables[0].Rows[0]["PDAmount"].ToString();
                Session["QCPayUpPackageID"] = Cardetais.Tables[0].Rows[0]["PackageID"].ToString();
                if (Cardetais.Tables[0].Rows[0]["PDDate"].ToString() != "")
                {
                    DateTime PDDate = Convert.ToDateTime(Cardetais.Tables[0].Rows[0]["PDDate"].ToString());
                    lblPDDateForPop.Text = PDDate.ToString("MM/dd/yyyy");
                    trPopPDData.Style["display"] = "block";
                    lblPDAmountForPop.Text = Cardetais.Tables[0].Rows[0]["PDAmount"].ToString();
                }
                else
                {
                    lblPDDateForPop.Text = "";
                    trPopPDData.Style["display"] = "none";
                    lblPDAmountForPop.Text = "";
                }

                hdnRegName.Value = Cardetais.Tables[0].Rows[0]["Name"].ToString();
                hdnRegLastName.Value = Cardetais.Tables[0].Rows[0]["Name"].ToString();
                hdnRegAddress.Value = Cardetais.Tables[0].Rows[0]["Address"].ToString();
                hdnRegState.Value = Cardetais.Tables[0].Rows[0]["RegState"].ToString();
                hdnRegZip.Value = Cardetais.Tables[0].Rows[0]["RegZip"].ToString();
                hdnRegCity.Value = Cardetais.Tables[0].Rows[0]["RegCity"].ToString();
                //FillPayCancelReason();
                hdnPopPayType.Value = Cardetais.Tables[0].Rows[0]["pmntType"].ToString();
                if (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["pmntType"].ToString()) == 5)
                {
                    divcard.Style["display"] = "none";
                    divcheck.Style["display"] = "block";
                    divpaypal.Style["display"] = "none";
                    btnCCProcess.Visible = false;
                    if ((Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 2) || (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 7) || (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 8))
                    {
                        divTransID.Style["display"] = "block";
                        divPaymentDate.Style["display"] = "block";
                        divPaymentAmount.Style["display"] = "block";
                        // divReason.Style["display"] = "none";
                        if (Cardetais.Tables[0].Rows[0]["PDDate"].ToString() != "")
                        {
                            DateTime PaymentDate = Convert.ToDateTime(Cardetais.Tables[0].Rows[0]["PDDate"].ToString());
                            //ListItem liPayDate = new ListItem();
                            //liPayDate.Text = PaymentDate.ToString("MM/dd/yyyy");
                            //liPayDate.Value = PaymentDate.ToString("MM/dd/yyyy");
                            //ddlPaymentDate.SelectedIndex = ddlPaymentDate.Items.IndexOf(liPayDate);
                            ddlPaymentDate.Items.Clear();
                            ddlPaymentDate.Items.Insert(0, new ListItem(PaymentDate.ToString("MM/dd/yyyy"), PaymentDate.ToString("MM/dd/yyyy")));
                        }

                        txtPaytransID.Text = Cardetais.Tables[0].Rows[0]["PDTransactionID"].ToString();
                        txtPaymentAmountInPop.Text = Cardetais.Tables[0].Rows[0]["PDAmount"].ToString();
                        txtPaytransID.Enabled = false;
                        ddlPaymentDate.Enabled = false;
                        ddlPaymentStatus.Enabled = false;
                        btnUpdate.Enabled = false;
                        txtPaymentAmountInPop.Enabled = false;
                        // txtPaymentNewNotes.Enabled = false;
                    }
                    else
                    {
                        // txtPaymentNewNotes.Enabled = true;
                        ddlPaymentStatus.Enabled = true;
                        btnUpdate.Enabled = true;
                        divTransID.Style["display"] = "none";
                        divPaymentDate.Style["display"] = "none";
                        divPaymentAmount.Style["display"] = "none";
                        txtPaytransID.Text = "";

                        txtPaytransID.Enabled = true;
                        ddlPaymentDate.Enabled = true;
                        txtPaymentAmountInPop.Text = "";
                        txtPaymentAmountInPop.Enabled = true;
                    }
                    lblAccHolderName.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["bankAccountHolderName"].ToString());
                    lblAccNumber.Text = Cardetais.Tables[0].Rows[0]["bankAccountNumber"].ToString();
                    lblBankName.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["bankName"].ToString());
                    lblRouting.Text = Cardetais.Tables[0].Rows[0]["bankRouting"].ToString();
                    lblAccType.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["AccountTypeName"].ToString());
                    ListItem liPayStatus = new ListItem();
                    liPayStatus.Text = Cardetais.Tables[0].Rows[0]["PDPmntStatusName"].ToString();
                    liPayStatus.Value = Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString();
                    ddlPaymentStatus.SelectedIndex = ddlPaymentStatus.Items.IndexOf(liPayStatus);
                    //lblCheckNumber.Text = Cardetais.Tables[0].Rows[0]["BankCheckNumber"].ToString();
                    //lblCheckType.Text = Cardetais.Tables[0].Rows[0]["CheckTypeName"].ToString();
                    if ((Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString() == "1") || (Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString() == "5"))
                    {
                        btnCheckProcess.Visible = true;
                    }
                    else
                    {
                        btnCheckProcess.Visible = false;
                    }

                }
                else if (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["pmntType"].ToString()) == 6)
                {
                    divcard.Style["display"] = "none";
                    divcheck.Style["display"] = "none";
                    divpaypal.Style["display"] = "block";
                    divTransID.Style["display"] = "none";
                    divPaymentDate.Style["display"] = "none";
                    divPaymentAmount.Style["display"] = "none";
                    lblPaypalTranID.Text = Cardetais.Tables[0].Rows[0]["PDTransactionID"].ToString();
                    lblPaypalEmail.Text = Cardetais.Tables[0].Rows[0]["PDPaypalEmail"].ToString();
                    ListItem liPayStatus = new ListItem();
                    liPayStatus.Text = Cardetais.Tables[0].Rows[0]["PDPmntStatusName"].ToString();
                    liPayStatus.Value = Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString();
                    ddlPaymentStatus.SelectedIndex = ddlPaymentStatus.Items.IndexOf(liPayStatus);

                    if ((Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 2) || (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 7) || (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 8))
                    {
                        ddlPaymentStatus.Enabled = false;
                        btnUpdate.Enabled = false;
                    }
                    else
                    {
                        ddlPaymentStatus.Enabled = true;
                        btnUpdate.Enabled = true;
                    }
                    btnCCProcess.Visible = false;
                    btnCheckProcess.Visible = false;
                }
                else
                {
                    divcard.Style["display"] = "block";
                    divcheck.Style["display"] = "none";
                    divpaypal.Style["display"] = "none";
                    btnCheckProcess.Visible = false;
                    if ((Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 2) || (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 7) || (Convert.ToInt32(Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString()) == 8))
                    {
                        divTransID.Style["display"] = "block";
                        divPaymentDate.Style["display"] = "block";
                        divPaymentAmount.Style["display"] = "block";
                        if (Cardetais.Tables[0].Rows[0]["PDDate"].ToString() != "")
                        {
                            DateTime PaymentDate = Convert.ToDateTime(Cardetais.Tables[0].Rows[0]["PDDate"].ToString());
                            ddlPaymentDate.Items.Clear();
                            ddlPaymentDate.Items.Insert(0, new ListItem(PaymentDate.ToString("MM/dd/yyyy"), PaymentDate.ToString("MM/dd/yyyy")));
                        }
                        txtPaytransID.Text = Cardetais.Tables[0].Rows[0]["PDTransactionID"].ToString();
                        txtPaymentAmountInPop.Text = Cardetais.Tables[0].Rows[0]["PDAmount"].ToString();
                        txtPaytransID.Enabled = false;
                        ddlPaymentDate.Enabled = false;
                        ddlPaymentStatus.Enabled = false;
                        btnUpdate.Enabled = false;
                        txtPaymentAmountInPop.Enabled = false;

                    }
                    else
                    {
                        ddlPaymentStatus.Enabled = true;

                        btnUpdate.Enabled = true;
                        divTransID.Style["display"] = "none";
                        divPaymentDate.Style["display"] = "none";
                        divPaymentAmount.Style["display"] = "none";
                        txtPaytransID.Text = "";
                        txtPaymentAmountInPop.Text = "";
                        txtPaymentAmountInPop.Enabled = true;

                        txtPaytransID.Enabled = true;
                        ddlPaymentDate.Enabled = true;
                    }
                    //lblCCCardType.Text = Cardetais.Tables[0].Rows[0]["lblCCCardType"].ToString();
                    lblCardHolderName.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["cardholderName"].ToString());

                    lblCCCardType.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["cardType"].ToString());
                    lblCardHolderLastName.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["cardholderLastName"].ToString());
                    lblCCNumber.Text = Cardetais.Tables[0].Rows[0]["cardNumber"].ToString();
                    string EXpDate = Cardetais.Tables[0].Rows[0]["cardExpDt"].ToString();
                    string[] EXpDt = EXpDate.Split(new char[] { '/' });

                    lblCCExpiryDate.Text = EXpDt[0].ToString() + "/" + "20" + EXpDt[1].ToString();

                    lblCvv.Text = Cardetais.Tables[0].Rows[0]["cardCode"].ToString();
                    lblBillingAddress.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["billingAdd"].ToString());
                    lblBillingCity.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["billingCity"].ToString());
                    lblBillingState.Text = Cardetais.Tables[0].Rows[0]["State_Code"].ToString();
                    lblBillingZip.Text = Cardetais.Tables[0].Rows[0]["billingZip"].ToString();
                    ListItem liPayStatus = new ListItem();
                    liPayStatus.Text = Cardetais.Tables[0].Rows[0]["PDPmntStatusName"].ToString();
                    liPayStatus.Value = Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString();
                    ddlPaymentStatus.SelectedIndex = ddlPaymentStatus.Items.IndexOf(liPayStatus);
                    if ((Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString() == "1") || (Cardetais.Tables[0].Rows[0]["PDPmntStatusID"].ToString() == "5"))
                    {
                        btnCCProcess.Visible = true;
                    }
                    else
                    {
                        btnCCProcess.Visible = false;
                    }
                }
                if (hdnPophdnAmount.Value == "0")
                {
                    divTransID.Style["display"] = "none";
                    divPaymentDate.Style["display"] = "none";
                    divPaymentAmount.Style["display"] = "none";
                }
                MPEUpdate.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillPaymentDate()
    {
        try
        {
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            ddlPaymentDate.Items.Clear();
            for (int i = 0; i < 14; i++)
            {
                ListItem list = new ListItem();
                list.Text = dtNow.AddDays(-i).ToString("MM/dd/yyyy");
                list.Value = dtNow.AddDays(-i).ToString("MM/dd/yyyy");
                ddlPaymentDate.Items.Add(list);
            }
            ddlPaymentDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
