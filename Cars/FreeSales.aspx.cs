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

public partial class FreeSales : System.Web.UI.Page
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
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();

                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showSpinner();", true);

                GetDetails();
                // GetDetails(PhoneNum, SellerName, Email, makeModelID, YearOfMake, PackageID, AgentName);
                lblResHead.Text = "Most recent 500 customers ";
                Session.Timeout = 180;
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "hideSpinner();", true); 
                // spinner1.Style["display"] = "none";
            }
        }
    }




    private void GetDetails()
    {
        try
        {
            DataSet dsCarData = objdropdownBL.SmartzSearchForFreePackages();
            Session["SearchData"] = dsCarData;
            if (dsCarData.Tables.Count > 0)
            {
                if (dsCarData.Tables[0].Rows.Count > 0)
                {
                    lblResCount.Visible = true;
                    lblRes.Visible = false;
                    grdIntroInfo.Visible = true;
                    lblResCount.Text = dsCarData.Tables[0].Rows.Count + " Records found";
                    grdIntroInfo.DataSource = dsCarData.Tables[0];
                    grdIntroInfo.DataBind();
                    string sTable = CreateTable();
                    lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
                }
                else
                {
                    lblRes.Text = "No records found";
                    grdIntroInfo.Visible = false;
                    lblRes.Visible = true;
                    lblResCount.Visible = false;
                }
            }
            else
            {
                lblRes.Text = "No records found";
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
                lblResCount.Visible = false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void grdIntroInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image ImgSaleType = (Image)e.Row.FindControl("ImgSaleType");
                HiddenField hdnSaleEnteredBy = (HiddenField)e.Row.FindControl("hdnSaleEnteredBy");
                HiddenField hdnAgentID = (HiddenField)e.Row.FindControl("hdnAgentID");
                Label lblAgent = (Label)e.Row.FindControl("lblAgent");
                HiddenField hdnAgentName = (HiddenField)e.Row.FindControl("hdnAgentName");
                HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                Label lblPhone = (Label)e.Row.FindControl("lblPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
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
                if (hdnAgentID.Value.ToString() != "0")
                {
                    lblAgent.Text = objGeneralFunc.WrapTextByMaxCharacters(hdnAgentName.Value.ToString(), 10);
                }
                else
                {
                    lblAgent.Text = "";
                }
                if (hdnSaleEnteredBy.Value == "")
                {
                    ImgSaleType.ImageUrl = "~/images/Internet-icon.png";
                }
                else
                {
                    ImgSaleType.ImageUrl = "~/images/phone_icon.png";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void grdIntroInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Session["RedirectFrom"] = 8;
                Response.Redirect("CustomerView.aspx");
            }          
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkCarIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchData"] as DataSet;
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

            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "American_Name";
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "phone";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Reg Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Reg Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPhoneSort.Text = "Reg Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Reg Phone &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkEmailSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "email";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkEmailSort.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkEmailSort.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkEmailSort.Text = "Email &#8659";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkEmailSort.Text = "Email &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Adstatus";
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchData"] as DataSet;
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
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
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

}
