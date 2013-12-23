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

public partial class Days60CallsReview : System.Web.UI.Page
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
                int SelMode = 0;
                FillDataWCCallDetails(SelMode);
                Session.Timeout = 180;
            }
        }
    }

    private void FillDataWCCallDetails(int SelMode)
    {
        try
        {
            DataSet dsWcDetails = objdropdownBL.Smartz60DaysReviewCallSearchCars(SelMode);
            Session["Search60DCCallDataCars"] = dsWcDetails;
            DataSet dsRvWcDetails = objRvMainBL.Smartz60DaysReviewCallSearchRVs(SelMode);
            Session["Search60DCCallDataRVs"] = dsRvWcDetails;
            tblWelcomeCallDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "block";
            divRVDetails.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsWcDetails.Tables.Count > 0)
            {
                if (dsWcDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsWcDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    grdWelcomeDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing 60 days review calls for Car(s)";
                    grdWelcomeDetails.DataSource = dsWcDetails.Tables[0];
                    grdWelcomeDetails.DataBind();
                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    grdWelcomeDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing 60 days review calls for Car(s)";
                    //lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                grdWelcomeDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing 60 days review calls for Car(s)";
            }
            if (dsRvWcDetails.Tables.Count > 0)
            {
                if (dsRvWcDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvWcDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
                    lnkbtnRVSResCount.Enabled = true;
                }
                else
                {
                    lnkbtnRVSResCount.Text = "0 RV(S)";
                    lnkbtnRVSResCount.Enabled = false;
                }
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
            }
            string sTable = CreateTable();
            lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
            lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
            string StableWC = CreateTableWC();
            lnkWcStatus.Attributes.Add("onmouseover", "return overlib1('" + StableWC + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
            lnkWcStatus.Attributes.Add("onmouseout", "return nd(4000);");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnCarsResCount_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarWCDetails = Session["Search60DCCallDataCars"] as DataSet;
            DataSet dsRvWCDetails = Session["Search60DCCallDataRVs"] as DataSet;
            tblWelcomeCallDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "block";
            divRVDetails.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCarWCDetails.Tables.Count > 0)
            {
                if (dsCarWCDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsCarWCDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    grdWelcomeDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing 60 days review calls for Car(s)";
                    grdWelcomeDetails.DataSource = dsCarWCDetails.Tables[0];
                    grdWelcomeDetails.DataBind();
                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    grdWelcomeDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing 60 days review calls for Car(s)";
                    //lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                grdWelcomeDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing 60 days review calls for Car(s)";
                // lblResHead.Text = "Records not found";
            }
            if (dsRvWCDetails.Tables.Count > 0)
            {
                if (dsRvWCDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvWCDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
                    lnkbtnRVSResCount.Enabled = true;
                }
                else
                {
                    lnkbtnRVSResCount.Text = "0 RV(S)";
                    lnkbtnRVSResCount.Enabled = false;
                }
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
            }
            string sTable = CreateTable();
            lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
            lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
            string StableWC = CreateTableWC();
            lnkWcStatus.Attributes.Add("onmouseover", "return overlib1('" + StableWC + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
            lnkWcStatus.Attributes.Add("onmouseout", "return nd(4000);");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRVSResCount_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarWCDetails = Session["Search60DCCallDataCars"] as DataSet;
            DataSet dsRvWCDetails = Session["Search60DCCallDataRVs"] as DataSet;
            tblWelcomeCallDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "none";
            divRVDetails.Style["display"] = "block";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCarWCDetails.Tables.Count > 0)
            {
                if (dsCarWCDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsCarWCDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;

                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;

                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;

            }
            if (dsRvWCDetails.Tables.Count > 0)
            {
                if (dsRvWCDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvWCDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
                    lnkbtnRVSResCount.Enabled = true;
                    grdRvWelcomeCals.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing 60 days review calls for RV(s)";
                    grdRvWelcomeCals.DataSource = dsRvWCDetails.Tables[0];
                    grdRvWelcomeCals.DataBind();
                }
                else
                {
                    lnkbtnRVSResCount.Text = "0 RV(S)";
                    lnkbtnRVSResCount.Enabled = false;
                    grdRvWelcomeCals.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing 60 days review calls for RV(s)";
                    // lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
                grdRvWelcomeCals.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing 60 days review calls for RV(s)";
                //lblResHead.Text = "Records not found";
            }
            string sTable = CreateTable();
            lnkbtnRvAdStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
            lnkbtnRvAdStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
            string StableWC = CreateTableWC();
            lnkbtnRvWCStatusSort.Attributes.Add("onmouseover", "return overlib1('" + StableWC + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
            lnkbtnRvWCStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void grdWelcomeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPhone = (Label)e.Row.FindControl("lblPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                Image ImgWCStatus = (Image)e.Row.FindControl("ImgWCStatus");
                //HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                //Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnWCCallID = (HiddenField)e.Row.FindControl("hdnWCCallID");
                HiddenField hdnWCStatus = (HiddenField)e.Row.FindControl("hdnWCStatus");
                // HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");

                //Double PackCost = new Double();
                //PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                //string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                //string PackName = hdnPackName.Value.ToString();
                //lblPrice.Text = PackName + "($" + PackAmount + ")";


                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if ((hdnWCCallID.Value.ToString() != "") && (hdnWCStatus.Value.ToString() == "1"))
                {
                    ImgWCStatus.ImageUrl = "~/images/star_green.png";
                }
                else
                {

                    ImgWCStatus.ImageUrl = "~/images/star_yellow.png";

                }
                if (hdnStatus.Value.ToString() == "1")
                {
                    //lblStatus.Text = "Active";
                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else if (hdnStatus.Value.ToString() == "2")
                {
                    //lblStatus.Text = "Inactive";
                    ImgStatus.ImageUrl = "~/images/lock.gif";
                }
                else if (hdnStatus.Value.ToString() == "3")
                {
                    //lblStatus.Text = "Inactive";
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
    protected void grdWelcomeDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Session["RedirectFrom"] = 7;
                Response.Redirect("CustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdRvWelcomeCals_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPhone = (Label)e.Row.FindControl("lblRvPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnRvPhoneNum");
                Image ImgWCStatus = (Image)e.Row.FindControl("ImgRvWCStatus");
                //HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                //Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnWCCallID = (HiddenField)e.Row.FindControl("hdnRvWCCallID");
                HiddenField hdnWCStatus = (HiddenField)e.Row.FindControl("hdnRvWCStatus");
                // HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnRvStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgRvStatus");

                //Double PackCost = new Double();
                //PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                //string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                //string PackName = hdnPackName.Value.ToString();
                //lblPrice.Text = PackName + "($" + PackAmount + ")";


                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if ((hdnWCCallID.Value.ToString() != "") && (hdnWCStatus.Value.ToString() == "1"))
                {
                    ImgWCStatus.ImageUrl = "~/images/star_green.png";
                }
                else
                {

                    ImgWCStatus.ImageUrl = "~/images/star_yellow.png";

                }
                if (hdnStatus.Value.ToString() == "1")
                {
                    //lblStatus.Text = "Active";
                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else if (hdnStatus.Value.ToString() == "2")
                {
                    //lblStatus.Text = "Inactive";
                    ImgStatus.ImageUrl = "~/images/lock.gif";
                }
                else if (hdnStatus.Value.ToString() == "3")
                {
                    //lblStatus.Text = "Inactive";
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
    protected void grdRvWelcomeCals_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditRv")
            {
                string postingID = e.CommandArgument.ToString();
                Session["RvPostingID"] = postingID;
                Session["RedirectFrom"] = 7;
                Response.Redirect("RvCustomerView.aspx");
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
            int SelMode = 1;
            FillDataWCCallDetails(SelMode);
            Session.Timeout = 180;
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
            int SelMode = 0;
            FillDataWCCallDetails(SelMode);
            Session.Timeout = 180;
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
    private string CreateTableWC()
    {
        string strTransaction = string.Empty;
        strTransaction = "<table width=\"120px\" id=\"SalesStatus\" style=\"display: block; background-color:#F3D9F6;border:2px;border-color:Black;height:60px \">";

        strTransaction += "<tr id=\"CampaignsBody3\">";
        strTransaction += "<td  style=\"padding-left:10px;\" >";
        strTransaction += "Done:";
        strTransaction += "</td>";
        strTransaction += "<td>";
        strTransaction += "<img src=\"images/star_green.png\" />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Pending:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/star_yellow.png\" />";
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


    protected void lnkCarIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkCarIDSort.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkCarIDSort.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkCarIDSort.Text = "Car ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkCarIDSort.Text = "Car ID &#8659";
            }

            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";

            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "AdStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkStatusSort.Text = "Ad St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Ad St &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";

            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkSaleDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SaleDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkSaleDateSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkSaleDateSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkSaleDateSort.Text = "Sale Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkSaleDateSort.Text = "Sale Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkPostedSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "dateOfPosting";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPostedSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPostedSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPostedSort.Text = "Posted Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPostedSort.Text = "Posted Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkAgentSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "First_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkAgentSort.Text = "Agent &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentSort.Text = "Agent &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";

            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkNameSort.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkNameSort.Text = "Name &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";

            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkPhoneSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PhoneNumber";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPhoneSort.Text = "Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Phone &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";

            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkWCDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWCDt.Text = "60DC Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWCDt.Text = "60DC Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWCDt.Text = "60DC Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWCDt.Text = "60DC Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkWCBy_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SmartzFirstName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWCBy.Text = "60DC By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWCBy.Text = "60DC By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWCBy.Text = "60DC By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWCBy.Text = "60DC By &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";

            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkLastCallBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "LastAttemptBy";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallBySort.Text = "Last Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallBySort.Text = "Last Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkLastCallBySort.Text = "Last Call By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallBySort.Text = "Last Call By &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkLastCallDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "LastAttemptDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallDtSort.Text = "Last Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallDtSort.Text = "Last Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkLastCallDtSort.Text = "Last Call Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallDtSort.Text = "Last Call Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";
            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkLastCallStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "LastAttemptStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallStatusSort.Text = "Last Call Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallStatusSort.Text = "Last Call Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkLastCallStatusSort.Text = "Last Call Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkLastCallStatusSort.Text = "Last Call Status &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";
            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkNoOfAttemptSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "COUNT";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkNoOfAttemptSort.Text = "No Of Calls &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkNoOfAttemptSort.Text = "No Of Calls &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkNoOfAttemptSort.Text = "No Of Calls &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkNoOfAttemptSort.Text = "No Of Calls &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";
            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkWcStatus.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkWcStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Days60Status";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWcStatus.Text = "60DC St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWcStatus.Text = "60DC St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWcStatus.Text = "60DC St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWcStatus.Text = "60DC St &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "60DC Dt &darr; &uarr;";
            lnkWCBy.Text = "60DC By &darr; &uarr;";

            lnkLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkNoOfAttemptSort.Text = "No Of Calls &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdWelcomeDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRvIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvIDSort.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvIDSort.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvIDSort.Text = "RV ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvIDSort.Text = "RV ID &#8659";
            }

            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvAdStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "AdStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvAdStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvAdStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvAdStatusSort.Text = "Ad St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvAdStatusSort.Text = "Ad St &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvSaleDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SaleDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSaleDtSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSaleDtSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvSaleDtSort.Text = "Sale Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSaleDtSort.Text = "Sale Dt &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvPostedDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "dateOfPosting";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPostedDtSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPostedDtSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvPostedDtSort.Text = "Posted Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPostedDtSort.Text = "Posted Dt &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRVAgentSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "First_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRVAgentSort.Text = "Agent &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVAgentSort.Text = "Agent &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvNameSort.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvNameSort.Text = "Name &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvPhoneSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PhoneNumber";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPhoneSort.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPhoneSort.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvPhoneSort.Text = "Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPhoneSort.Text = "Phone &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRVWCDTSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVWCDTSort.Text = "60DC Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVWCDTSort.Text = "60DC Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRVWCDTSort.Text = "60DC Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVWCDTSort.Text = "60DC Dt &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRVWCBYSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SmartzFirstName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVWCBYSort.Text = "60DC By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVWCBYSort.Text = "60DC By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRVWCBYSort.Text = "60DC By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVWCBYSort.Text = "60DC By &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";

            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvLastCallBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "LastAttemptBy";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvLastCallBySort.Text = "Last Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvLastCallBySort.Text = "Last Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvLastCallBySort.Text = "Last Call By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvLastCallBySort.Text = "Last Call By &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";

            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvLastCallDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "LastAttemptDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvLastCallDtSort.Text = "Last Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvLastCallDtSort.Text = "Last Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvLastCallDtSort.Text = "Last Call Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvLastCallDtSort.Text = "Last Call Dt &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";

            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";
            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkBtnRvLastCallStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "LastAttemptStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvLastCallStatusSort.Text = "Last Call Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvLastCallStatusSort.Text = "Last Call Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvLastCallStatusSort.Text = "Last Call Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvLastCallStatusSort.Text = "Last Call Status &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";

            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";
            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnNOOFCallsSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataCars"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "COUNT";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnNOOFCallsSort.Text = "No Of Calls &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnNOOFCallsSort.Text = "No Of Calls &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnNOOFCallsSort.Text = "No Of Calls &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnNOOFCallsSort.Text = "No Of Calls &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";

            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";
            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";

            lnkbtnRvWCStatusSort.Text = "60DC St &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRvWCStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["Search60DCCallDataRVs"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Days60Status";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvWCStatusSort.Text = "60DC St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvWCStatusSort.Text = "60DC St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvWCStatusSort.Text = "60DC St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvWCStatusSort.Text = "60DC St &#8659";
            }

            lnkbtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnRvAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDtSort.Text = "Sale Dt &darr; &uarr;";
            lnkbtnRvPostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRVAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "60DC St &darr; &uarr;";
            lnkbtnRvPhoneSort.Text = "Phone &darr; &uarr;";
            lnkbtnRVWCDTSort.Text = "60DC Dt &darr; &uarr;";

            lnkbtnRVWCBYSort.Text = "60DC By &darr; &uarr;";
            lnkbtnRvLastCallBySort.Text = "Last Call By &darr; &uarr;";
            lnkbtnRvLastCallDtSort.Text = "Last Call Dt &darr; &uarr;";
            lnkBtnRvLastCallStatusSort.Text = "Last Call Status &darr; &uarr;";

            lnkbtnNOOFCallsSort.Text = "No Of Calls &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRvWelcomeCals, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
