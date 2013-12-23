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

public partial class WelcomeCalls : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
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
                int SelMode = 1;
                FillDataWCCallDetails(SelMode);
                Session.Timeout = 180;
            }
        }
    }

    private void FillDataWCCallDetails(int SelMode)
    {
        try
        {
            DataSet dsWcDetails = objdropdownBL.USP_SmartzWelcomeCallSearch(SelMode);
            Session["SearchWCCallData"] = dsWcDetails;
            if (dsWcDetails.Tables.Count > 0)
            {
                if (dsWcDetails.Tables[0].Rows.Count > 0)
                {
                    grdWelcomeDetails.Visible = true;
                    lblResHead.Visible = true;
                    lblResCount.Visible = true;
                    lblResHead.Text = "Showing up to latest 500 records";
                    lblResCount.Text = dsWcDetails.Tables[0].Rows.Count.ToString() + " Records found";
                    grdWelcomeDetails.DataSource = dsWcDetails.Tables[0];
                    grdWelcomeDetails.DataBind();
                }
                else
                {
                    grdWelcomeDetails.Visible = false;
                    lblResCount.Visible = false;
                    lblResHead.Visible = true;
                    lblResHead.Text = "Records not found";
                }
            }
            else
            {
                grdWelcomeDetails.Visible = false;
                lblResCount.Visible = false;
                lblResHead.Visible = true;
                lblResHead.Text = "Records not found";
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
    protected void grdWelcomeDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPhone = (Label)e.Row.FindControl("lblPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                Image ImgWCStatus = (Image)e.Row.FindControl("ImgWCStatus");
                HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnWCCallID = (HiddenField)e.Row.FindControl("hdnWCCallID");
                HiddenField hdnWCStatus = (HiddenField)e.Row.FindControl("hdnWCStatus");
                HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");

                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackName.Value.ToString();
                lblPrice.Text = PackName + "($" + PackAmount + ")";


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
                    //lblStatus.Text = "Active";
                    ImgWCStatus.ImageUrl = "~/images/star_green.png";
                    //lblWCStatus.Text = "Done";
                }
                else
                {
                    //lblStatus.Text = "Inactive";
                    ImgWCStatus.ImageUrl = "~/images/star_yellow.png";
                    //lblWCStatus.Text = "Pending";
                }
                if (hdnStatus.Value.ToString() == "True")
                {
                    //lblStatus.Text = "Active";
                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else
                {
                    //lblStatus.Text = "Inactive";
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
                Session["RedirectFrom"] = 2;
                Response.Redirect("CustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            int SelMode;
            if (rdbtnAll.Checked == true)
            {
                SelMode = 1;
            }
            else
            {
                SelMode = 0;
            }
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
        strTransaction = "<table width=\"120px\" id=\"SalesStatus\" style=\"display: block; background-color:#F3D9F6;border:2px;border-color:Black;height:60px \">";

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
        strTransaction += "Inactive:";
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
            ds = Session["SearchWCCallData"] as DataSet;
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
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "isActive";
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
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
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
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
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
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "ReferCode";
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
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
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
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
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
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWCDt.Text = "WC Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWCDt.Text = "WC Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWCDt.Text = "WC Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWCDt.Text = "WC Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SmartzFirstName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWCBy.Text = "WC By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWCBy.Text = "WC By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWCBy.Text = "WC By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWCBy.Text = "WC By &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
    protected void lnkPackageSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Price";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPackageSort.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPackageSort.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPackageSort.Text = "Package &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPackageSort.Text = "Package &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
    protected void lnkYearSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "yearOfMake";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkYearSort.Text = "Year &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkYearSort.Text = "Year &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
    protected void lnkMakeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkMakeSort.Text = "Make &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkMakeSort.Text = "Make &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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

    protected void lnkModelSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "model";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkModelSort.Text = "Model &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkModelSort.Text = "Model &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkModelSort.Text = "Model &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkModelSort.Text = "Model &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkWcStatus.Text = "WC St &darr; &uarr;";

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
            ds = Session["SearchWCCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "WCStatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWcStatus.Text = "WC St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWcStatus.Text = "WC St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWcStatus.Text = "WC St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWcStatus.Text = "WC St &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkWCDt.Text = "WC Dt &darr; &uarr;";
            lnkWCBy.Text = "WC By &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";

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
}
