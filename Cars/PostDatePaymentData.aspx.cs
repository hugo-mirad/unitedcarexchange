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

public partial class PostDatePaymentData : System.Web.UI.Page
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
                divRvs.Style["display"] = "none";
                DataSet dsPDData = objdropdownBL.GetPDPaymentData(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for cars open data";
                }
                else
                {
                    grdPDPayData.Visible = true;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for cars open data";
                }
            }
        }
    }
    protected void rdbtnCars_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            Session["PDPAYSEL"] = "Cars";
            int TypeID = 2;
            divCars.Style["display"] = "block";
            divRvs.Style["display"] = "none";
            DataSet dsPDData = objdropdownBL.GetPDPaymentData(TypeID);
            Session["dsCarPDData"] = dsPDData;
            if (dsPDData.Tables[0].Rows.Count > 0)
            {
                grdPDPayData.Visible = true;
                grdPDPayData.DataSource = dsPDData.Tables[0];
                grdPDPayData.DataBind();
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results shown for cars open data";
            }
            else
            {
                grdPDPayData.Visible = false;
                string sTable = CreateTable();
                lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results not found for cars open data";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnRvs_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            Session["PDPAYSEL"] = "Rvs";
            int TypeID = 2;
            divCars.Style["display"] = "none";
            divRvs.Style["display"] = "block";
            DataSet dsPDData = objRVMainBL.GetPDPaymentDataForRVs(TypeID);
            Session["dsRvPDData"] = dsPDData;
            if (dsPDData.Tables[0].Rows.Count > 0)
            {
                grdRvPDPayData.Visible = true;
                grdRvPDPayData.DataSource = dsPDData.Tables[0];
                grdRvPDPayData.DataBind();
                string sTable = CreateTable();
                lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results shown for rvs open data";
            }
            else
            {
                grdRvPDPayData.Visible = false;
                string sTable = CreateTable();
                lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                lblResHead.Text = "Results not found for rvs open data";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnPaid_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPAYSEL"].ToString() == "Rvs")
            {
                int TypeID = 1;
                divCars.Style["display"] = "none";
                divRvs.Style["display"] = "block";
                DataSet dsPDData = objRVMainBL.GetPDPaymentDataForRVs(TypeID);
                Session["dsRvPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdRvPDPayData.Visible = true;
                    grdRvPDPayData.DataSource = dsPDData.Tables[0];
                    grdRvPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for rvs paid data";
                }
                else
                {
                    grdRvPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for rvs paid data";
                }
            }
            else if (Session["PDPAYSEL"].ToString() == "Cars")
            {
                int TypeID = 1;
                divCars.Style["display"] = "block";
                divRvs.Style["display"] = "none";
                DataSet dsPDData = objdropdownBL.GetPDPaymentData(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for cars paid data";
                }
                else
                {
                    grdPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for cars paid data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnOpen_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPAYSEL"].ToString() == "Rvs")
            {
                int TypeID = 2;
                divCars.Style["display"] = "none";
                divRvs.Style["display"] = "block";
                DataSet dsPDData = objRVMainBL.GetPDPaymentDataForRVs(TypeID);
                Session["dsRvPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdRvPDPayData.Visible = true;
                    grdRvPDPayData.DataSource = dsPDData.Tables[0];
                    grdRvPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for rvs open data";
                }
                else
                {
                    grdRvPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for rvs open data";
                }
            }
            else if (Session["PDPAYSEL"].ToString() == "Cars")
            {
                int TypeID = 2;
                divCars.Style["display"] = "block";
                divRvs.Style["display"] = "none";
                DataSet dsPDData = objdropdownBL.GetPDPaymentData(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for cars open data";
                }
                else
                {
                    grdPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for cars open data";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnCancelled_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["PDPAYSEL"].ToString() == "Rvs")
            {
                int TypeID = 3;
                divCars.Style["display"] = "none";
                divRvs.Style["display"] = "block";
                DataSet dsPDData = objRVMainBL.GetPDPaymentDataForRVs(TypeID);
                Session["dsRvPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdRvPDPayData.Visible = true;
                    grdRvPDPayData.DataSource = dsPDData.Tables[0];
                    grdRvPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for rvs cancelled data";
                }
                else
                {
                    grdRvPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblRvAdSt.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblRvAdSt.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for rvs cancelled data";
                }
            }
            else if (Session["PDPAYSEL"].ToString() == "Cars")
            {
                int TypeID = 3;
                divCars.Style["display"] = "block";
                divRvs.Style["display"] = "none";
                DataSet dsPDData = objdropdownBL.GetPDPaymentData(TypeID);
                Session["dsCarPDData"] = dsPDData;
                if (dsPDData.Tables[0].Rows.Count > 0)
                {
                    grdPDPayData.Visible = true;
                    grdPDPayData.DataSource = dsPDData.Tables[0];
                    grdPDPayData.DataBind();
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results shown for cars cancelled data";
                }
                else
                {
                    grdPDPayData.Visible = false;
                    string sTable = CreateTable();
                    lblAdStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lblAdStatus.Attributes.Add("onmouseout", "return nd(4000);");
                    lblResHead.Text = "Results not found for cars cancelled data";
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
    protected void grdRvPDPayData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnRvPackName = (HiddenField)e.Row.FindControl("hdnRvPackName");
                HiddenField hdnRvPackCost = (HiddenField)e.Row.FindControl("hdnRvPackCost");
                Label lblPackage = (Label)e.Row.FindControl("lblRvPackage");
                Label lblPhone = (Label)e.Row.FindControl("lblRvPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("RvhdnStatus");
                Image ImgStatus = (Image)e.Row.FindControl("RvImgStatus");
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnRvPackCost.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnRvPackName.Value.ToString();
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

    protected void lblRvID_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvID.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvID.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvID.Text = "RV ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvID.Text = "RV ID &#8659";
            }

            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lblRvAdSt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "AdStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvAdSt.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvAdSt.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvAdSt.Text = "Ad St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvAdSt.Text = "Ad St &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lblRvSaleDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SaleDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvSaleDt.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvSaleDt.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvSaleDt.Text = "Sale Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvSaleDt.Text = "Sale Dt &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvpostedDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "dateOfPosting";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvpostedDt.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvpostedDt.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvpostedDt.Text = "Posted Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvpostedDt.Text = "Posted Dt &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvPDPayDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PDDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvPDPayDt.Text = "PD Pay Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvPDPayDt.Text = "PD Pay Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvPDPayDt.Text = "PD Pay Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvPDPayDt.Text = "PD Pay Dt &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvPaymentDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PaymentDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvPaymentDate.Text = "Payment Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvPaymentDate.Text = "Payment Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvPaymentDate.Text = "Payment Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvPaymentDate.Text = "Payment Dt &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvAgent_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Agent_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvAgent.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvAgent.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvAgent.Text = "Agent &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvAgent.Text = "Agent &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvYear_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "yearOfMake";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvYear.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvYear.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvYear.Text = "Year &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvYear.Text = "Year &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvType_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvType.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvType.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvType.Text = "Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvType.Text = "Type &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lblRvMake_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvMake.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvMake.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvMake.Text = "Make &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvMake.Text = "Make &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvPackage_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Price";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvPackage.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvPackage.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvPackage.Text = "Package &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvPackage.Text = "Package &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lblRvName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvName.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvName.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvName.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvName.Text = "Name &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvPhone_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PhoneNum";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvPhone.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvPhone.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvPhone.Text = "Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvPhone.Text = "Phone &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvEmail.Text = "Email &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lblRvEmail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["dsRvPDData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "email";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lblRvEmail.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lblRvEmail.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lblRvEmail.Text = "Email &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lblRvEmail.Text = "Email &#8659";
            }

            lblRvID.Text = "RV ID &darr; &uarr;";
            lblRvAdSt.Text = "Ad St &darr; &uarr;";
            lblRvSaleDt.Text = "Sale Dt &darr; &uarr;";
            lblRvpostedDt.Text = "Posted Dt &darr; &uarr;";
            lblRvPDPayDt.Text = "PD Pay Dt &darr; &uarr;";
            lblRvPaymentDate.Text = "Payment Dt &darr; &uarr;";
            lblRvAgent.Text = "Agent &darr; &uarr;";
            lblRvYear.Text = "Year &darr; &uarr;";
            lblRvType.Text = "Type &darr; &uarr;";
            lblRvMake.Text = "Make &darr; &uarr;";
            lblRvPackage.Text = "Package &darr; &uarr;";
            lblRvName.Text = "Name &darr; &uarr;";
            lblRvPhone.Text = "Phone &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvPDPayData, 0, dt, Session["SortDirec"].ToString());
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdRvPDPayData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["RvPostingID"] = postingID;
                Session["RedirectFrom"] = 5;
                Response.Redirect("RvCustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
