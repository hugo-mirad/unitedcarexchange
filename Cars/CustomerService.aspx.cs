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

public partial class CustomerService : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
    DataSet dsActiveSmartzUsers = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
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
                SmartzTicketDdlDs = objdropdownBL.USP_SmartzTicketDropDown();
                Session["TicketDdl"] = SmartzTicketDdlDs;
                dsActiveSmartzUsers = objCentralDBBL.GetSmartzUsersActiveData();
                Session["ActiveSmartzUsers"] = dsActiveSmartzUsers;
                FillDataCSCallDetails();
                Session.Timeout = 180;
            }
        }
    }

    private void FillDataCSCallDetails()
    {
        try
        {
            DataSet dsCSDetails = objdropdownBL.USP_SmartzGetCustmerServiceData();
            Session["SearchCustServiceCallData"] = dsCSDetails;
            DataSet dsRVCSDetails = objRvMainBL.SmartzGetCustmerServiceData();
            Session["SearchRVCustServiceCallData"] = dsRVCSDetails;
            tblTicketDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "block";
            divRVDetails.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCSDetails.Tables.Count > 0)
            {
                if (dsCSDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsCSDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    grdCSDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for Car(s)";
                    grdCSDetails.DataSource = dsCSDetails.Tables[0];
                    grdCSDetails.DataBind();
                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    grdCSDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for Car(s)";
                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                grdCSDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing results for Car(s)";
            }
            if (dsRVCSDetails.Tables.Count > 0)
            {
                if (dsRVCSDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRVCSDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
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
            DataSet dsCSDetails = Session["SearchCustServiceCallData"] as DataSet;
            DataSet dsRVCSDetails = Session["SearchRVCustServiceCallData"] as DataSet;
            tblTicketDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "block";
            divRVDetails.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCSDetails.Tables.Count > 0)
            {
                if (dsCSDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsCSDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    grdCSDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for Car(s)";
                    grdCSDetails.DataSource = dsCSDetails.Tables[0];
                    grdCSDetails.DataBind();
                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    grdCSDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for Car(s)";
                    //lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                grdCSDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing results for Car(s)";
                // lblResHead.Text = "Records not found";
            }
            if (dsRVCSDetails.Tables.Count > 0)
            {
                if (dsRVCSDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRVCSDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
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
            DataSet dsCSDetails = Session["SearchCustServiceCallData"] as DataSet;
            DataSet dsRVCSDetails = Session["SearchRVCustServiceCallData"] as DataSet;
            tblTicketDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "none";
            divRVDetails.Style["display"] = "block";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCSDetails.Tables.Count > 0)
            {
                if (dsCSDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsCSDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
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
            if (dsRVCSDetails.Tables.Count > 0)
            {
                if (dsRVCSDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRVCSDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
                    lnkbtnRVSResCount.Enabled = true;
                    grdRVCSDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for RV(s)";
                    grdRVCSDetails.DataSource = dsRVCSDetails.Tables[0];
                    grdRVCSDetails.DataBind();
                }
                else
                {
                    lnkbtnRVSResCount.Text = "0 RV(S)";
                    lnkbtnRVSResCount.Enabled = false;
                    grdRVCSDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for RV(s)";
                    // lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
                grdRVCSDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing results for RV(s)";
                //lblResHead.Text = "Records not found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void lnkbtnCSIDHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCSIDHead.Text = "CS CallID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCSIDHead.Text = "CS CallID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCSIDHead.Text = "CS CallID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCSIDHead.Text = "CS CallID &#8659";
            }

            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnCallDateHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallDateHead.Text = "Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallDateHead.Text = "Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCallDateHead.Text = "Call Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallDateHead.Text = "Call Dt &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void lnkBrand_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "BrandCode";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBrand.Text = "Brand &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBrand.Text = "Brand &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBrand.Text = "Brand &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBrand.Text = "Brand &#8659";
            }

            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnCarIDHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CarID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCarIDHead.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCarIDHead.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCarIDHead.Text = "Car ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCarIDHead.Text = "Car ID &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnCallByHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallAgentName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallByHead.Text = "Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallByHead.Text = "Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCallByHead.Text = "Call By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallByHead.Text = "Call By &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnCallTypeHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallTypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallTypeHead.Text = "Call Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallTypeHead.Text = "Call Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCallTypeHead.Text = "Call Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallTypeHead.Text = "Call Type &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnCallReasonHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallReasonName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallReasonHead.Text = "Call Reason &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallReasonHead.Text = "Call Reason &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCallReasonHead.Text = "Call Reason &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallReasonHead.Text = "Call Reason &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnSpokenWithHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SpokeWith";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnSpokenWithHead.Text = "Spoken With &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnSpokenWithHead.Text = "Spoken With &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnSpokenWithHead.Text = "Spoken With &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnSpokenWithHead.Text = "Spoken With &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnTicketIDHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnTicketIDHead.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnTicketIDHead.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnTicketIDHead.Text = "Ticket ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnTicketIDHead.Text = "Ticket ID &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            lnkbtnCallResolutionHead.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnCallResolutionHead_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CSResolutionName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallResolutionHead.Text = "Call Resolution &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallResolutionHead.Text = "Call Resolution &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCallResolutionHead.Text = "Call Resolution &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallResolutionHead.Text = "Call Resolution &#8659";
            }

            lnkbtnCSIDHead.Text = "CS CallID &darr; &uarr;";
            lnkbtnCallDateHead.Text = "Call Dt &darr; &uarr;";
            lnkbtnCarIDHead.Text = "Car ID &darr; &uarr;";
            lnkbtnCallByHead.Text = "Call By &darr; &uarr;";
            lnkbtnCallTypeHead.Text = "Call Type &darr; &uarr;";
            lnkbtnCallReasonHead.Text = "Call Reason &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnSpokenWithHead.Text = "Spoken With &darr; &uarr;";
            lnkbtnTicketIDHead.Text = "Ticket ID &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnRvCSCallIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCSCallIDSort.Text = "CS CallID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCSCallIDSort.Text = "CS CallID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvCSCallIDSort.Text = "CS CallID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCSCallIDSort.Text = "CS CallID &#8659";
            }

            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRvCallDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallDtSort.Text = "Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallDtSort.Text = "Call Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvCallDtSort.Text = "Call Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallDtSort.Text = "Call Dt &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRVIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CarID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVIDSort.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVIDSort.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRVIDSort.Text = "RV ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVIDSort.Text = "RV ID &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnCallBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallAgentName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallBySort.Text = "Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallBySort.Text = "Call By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCallBySort.Text = "Call By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCallBySort.Text = "Call By &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnCalltypeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallTypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCalltypeSort.Text = "Call Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCalltypeSort.Text = "Call Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCalltypeSort.Text = "Call Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCalltypeSort.Text = "Call Type &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvCallReaonSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallReasonName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallReaonSort.Text = "Call Reason &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallReaonSort.Text = "Call Reason &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvCallReaonSort.Text = "Call Reason &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallReaonSort.Text = "Call Reason &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnRvSpokenWithSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SpokeWith";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSpokenWithSort.Text = "Spoken With &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSpokenWithSort.Text = "Spoken With &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvSpokenWithSort.Text = "Spoken With &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSpokenWithSort.Text = "Spoken With &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRvTicketIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvTicketIDSort.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvTicketIDSort.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvTicketIDSort.Text = "Ticket ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvTicketIDSort.Text = "Ticket ID &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            lnkbtnRvCallResolutionSort.Text = "Call Resolution &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnRvCallResolutionSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVCustServiceCallData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CSResolutionName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallResolutionSort.Text = "Call Resolution &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallResolutionSort.Text = "Call Resolution &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvCallResolutionSort.Text = "Call Resolution &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvCallResolutionSort.Text = "Call Resolution &#8659";
            }

            lnkbtnRvCSCallIDSort.Text = "CS CallID &darr; &uarr;";
            lnkbtnRvCallDtSort.Text = "Call Dt &darr; &uarr;";
            lnkBtnRVIDSort.Text = "RV ID &darr; &uarr;";
            lnkbtnCallBySort.Text = "Call By &darr; &uarr;";
            lnkbtnCalltypeSort.Text = "Call Type &darr; &uarr;";
            lnkbtnRvCallReaonSort.Text = "Call Reason &darr; &uarr;";
            //lnkWcStatus.Text = "WC St &darr; &uarr;";
            lnkbtnRvSpokenWithSort.Text = "Spoken With &darr; &uarr;";
            lnkbtnRvTicketIDSort.Text = "Ticket ID &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVCSDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void grdCSDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCSID")
            {
                int CSCallID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet dsCSData = objdropdownBL.USP_SmartzGetCSDataByCSCallID(CSCallID);
                if (dsCSData.Tables[0].Rows.Count > 0)
                {
                    lblPopupCSCallID.Text = dsCSData.Tables[0].Rows[0]["CallID"].ToString();
                    lblPopupCSCarID.Text = dsCSData.Tables[0].Rows[0]["CarID"].ToString();
                    if (dsCSData.Tables[0].Rows[0]["CallDate"].ToString() != "")
                    {
                        DateTime dtCallDate = Convert.ToDateTime(dsCSData.Tables[0].Rows[0]["CallDate"].ToString());
                        lblPopupCSCallDate.Text = dtCallDate.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        lblPopupCSCallDate.Text = "";
                    }
                    lblPopupCSCallAgent.Text = dsCSData.Tables[0].Rows[0]["CallAgentName"].ToString();
                    lblPopupCSCallType.Text = dsCSData.Tables[0].Rows[0]["CallTypeName"].ToString();
                    lblPopupCSCallReason.Text = dsCSData.Tables[0].Rows[0]["CallReasonName"].ToString();
                    lblPopupCSCallStatus.Text = dsCSData.Tables[0].Rows[0]["CSResolutionName"].ToString();
                    lblPopupCSCallNotes.Text = dsCSData.Tables[0].Rows[0]["Notes"].ToString();
                    lblPopupCSCallSpokenWith.Text = dsCSData.Tables[0].Rows[0]["SpokeWith"].ToString();
                }
                mdepCSIDPopup.Show();
            }
            if (e.CommandName == "EditTicket")
            {
                Session["TicketFrom"] = "Cars";
                FillTicketDDLs();
                int TicketID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["UpTicketID"] = TicketID;
                DataSet dsTicketData = objdropdownBL.USP_SmartzGetDataByTicketID(TicketID);
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                txtPostDate.Text = dtNow.ToString("MM/dd/yyyy");
                txtCompletedDt.Text = dtNow.ToString("MM/dd/yyyy");
                if (dsTicketData.Tables[0].Rows.Count > 0)
                {
                    lblPopTicketID.Text = dsTicketData.Tables[0].Rows[0]["TicketID"].ToString();
                    lblPopCarID.Text = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    lblPopTicketType.Text = dsTicketData.Tables[0].Rows[0]["TicketTypeName"].ToString();
                    Session["UpTicketCarID"] = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                    {
                        DateTime CreateDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString());
                        lblPopTicketCreatedDt.Text = CreateDate.ToString("MM/dd/yyyy");
                    }

                    lblPopTicketCreatedBy.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["CreatedBy"].ToString());

                    lblPopPriority.Text = dsTicketData.Tables[0].Rows[0]["PriorityName"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["CallBackDate"].ToString() != "")
                    {
                        DateTime CallBackDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CallBackDate"].ToString());
                        txtPostDate.Text = CallBackDate.ToString("MM/dd/yyyy");
                    }
                    //else
                    //{
                    //    if (dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                    //    {
                    //        DateTime CreateDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString());
                    //        txtPostDate.Text = CreateDate.ToString("MM/dd/yyyy");
                    //    }
                    //}
                    if (dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString() != "")
                    {
                        DateTime SolvedDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString());
                        txtCompletedDt.Text = SolvedDate.ToString("MM/dd/yyyy");
                    }
                    lblPopTktDescrip.Text = dsTicketData.Tables[0].Rows[0]["TicketDescription"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["TicketStatusName"].ToString() != "")
                    {
                        ListItem liStatus = new ListItem();
                        liStatus.Value = dsTicketData.Tables[0].Rows[0]["TicketStatusID"].ToString();
                        liStatus.Text = dsTicketData.Tables[0].Rows[0]["TicketStatusName"].ToString();
                        ddlTicketStatus.SelectedIndex = ddlTicketStatus.Items.IndexOf(liStatus);
                    }
                    if (dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString() != "")
                    {
                        ListItem liAssigned = new ListItem();
                        liAssigned.Value = dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString();
                        liAssigned.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString());
                        ddlAssignedTo.SelectedIndex = ddlAssignedTo.Items.IndexOf(liAssigned);
                    }
                    if (dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString() != "")
                    {
                        ListItem liCompleted = new ListItem();
                        liCompleted.Value = dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString();
                        liCompleted.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString());
                        ddlCompletedBy.SelectedIndex = ddlCompletedBy.Items.IndexOf(liCompleted);
                    }
                    txtPopTktComments.Text = dsTicketData.Tables[0].Rows[0]["TicketComments"].ToString();
                    Session["UpTicketComments"] = dsTicketData.Tables[0].Rows[0]["TicketComments"].ToString();
                }
                Session.Timeout = 180;

                mdepTicketAlertView.Show();
            }
            if (e.CommandName == "EditCarID")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Session["RedirectFrom"] = 4;
                Response.Redirect("CustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdRVCSDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCSID")
            {
                int CSCallID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet dsCSData = objRvMainBL.SmartzGetCSDataByCSCallID(CSCallID);
                if (dsCSData.Tables[0].Rows.Count > 0)
                {
                    lblPopupCSCallID.Text = dsCSData.Tables[0].Rows[0]["CallID"].ToString();
                    lblPopupCSCarID.Text = dsCSData.Tables[0].Rows[0]["CarID"].ToString();
                    if (dsCSData.Tables[0].Rows[0]["CallDate"].ToString() != "")
                    {
                        DateTime dtCallDate = Convert.ToDateTime(dsCSData.Tables[0].Rows[0]["CallDate"].ToString());
                        lblPopupCSCallDate.Text = dtCallDate.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        lblPopupCSCallDate.Text = "";
                    }
                    lblPopupCSCallAgent.Text = dsCSData.Tables[0].Rows[0]["CallAgentName"].ToString();
                    lblPopupCSCallType.Text = dsCSData.Tables[0].Rows[0]["CallTypeName"].ToString();
                    lblPopupCSCallReason.Text = dsCSData.Tables[0].Rows[0]["CallReasonName"].ToString();
                    lblPopupCSCallStatus.Text = dsCSData.Tables[0].Rows[0]["CSResolutionName"].ToString();
                    lblPopupCSCallNotes.Text = dsCSData.Tables[0].Rows[0]["Notes"].ToString();
                    lblPopupCSCallSpokenWith.Text = dsCSData.Tables[0].Rows[0]["SpokeWith"].ToString();
                }
                mdepCSIDPopup.Show();
            }
            if (e.CommandName == "EditTicket")
            {
                Session["TicketFrom"] = "Rvs";
                FillTicketDDLs();
                int TicketID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["UpTicketID"] = TicketID;
                DataSet dsTicketData = objRvMainBL.SmartzGetDataByTicketID(TicketID);
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                txtPostDate.Text = dtNow.ToString("MM/dd/yyyy");
                txtCompletedDt.Text = dtNow.ToString("MM/dd/yyyy");
                if (dsTicketData.Tables[0].Rows.Count > 0)
                {
                    lblPopTicketID.Text = dsTicketData.Tables[0].Rows[0]["TicketID"].ToString();
                    lblPopCarID.Text = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    lblPopTicketType.Text = dsTicketData.Tables[0].Rows[0]["TicketTypeName"].ToString();
                    Session["UpTicketCarID"] = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                    {
                        DateTime CreateDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString());
                        lblPopTicketCreatedDt.Text = CreateDate.ToString("MM/dd/yyyy");
                    }

                    lblPopTicketCreatedBy.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["CreatedBy"].ToString());

                    lblPopPriority.Text = dsTicketData.Tables[0].Rows[0]["PriorityName"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["CallBackDate"].ToString() != "")
                    {
                        DateTime CallBackDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CallBackDate"].ToString());
                        txtPostDate.Text = CallBackDate.ToString("MM/dd/yyyy");
                    }

                    if (dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString() != "")
                    {
                        DateTime SolvedDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString());
                        txtCompletedDt.Text = SolvedDate.ToString("MM/dd/yyyy");
                    }
                    lblPopTktDescrip.Text = dsTicketData.Tables[0].Rows[0]["TicketDescription"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["TicketStatusName"].ToString() != "")
                    {
                        ListItem liStatus = new ListItem();
                        liStatus.Value = dsTicketData.Tables[0].Rows[0]["TicketStatusID"].ToString();
                        liStatus.Text = dsTicketData.Tables[0].Rows[0]["TicketStatusName"].ToString();
                        ddlTicketStatus.SelectedIndex = ddlTicketStatus.Items.IndexOf(liStatus);
                    }
                    if (dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString() != "")
                    {
                        ListItem liAssigned = new ListItem();
                        liAssigned.Value = dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString();
                        liAssigned.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString());
                        ddlAssignedTo.SelectedIndex = ddlAssignedTo.Items.IndexOf(liAssigned);
                    }
                    if (dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString() != "")
                    {
                        ListItem liCompleted = new ListItem();
                        liCompleted.Value = dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString();
                        liCompleted.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString());
                        ddlCompletedBy.SelectedIndex = ddlCompletedBy.Items.IndexOf(liCompleted);
                    }
                    txtPopTktComments.Text = dsTicketData.Tables[0].Rows[0]["TicketComments"].ToString();
                    Session["UpTicketComments"] = dsTicketData.Tables[0].Rows[0]["TicketComments"].ToString();
                }
                Session.Timeout = 180;

                mdepTicketAlertView.Show();
            }
            if (e.CommandName == "EditCarID")
            {
                string postingID = e.CommandArgument.ToString();
                Session["RvPostingID"] = postingID;
                Session["RedirectFrom"] = 4;
                Response.Redirect("RvCustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    protected void btnSaveTicketView_Click(object sender, EventArgs e)
    {
        try
        {
            mdepTicketAlertView.Hide();
            int TicketID = Convert.ToInt32(Session["UpTicketID"].ToString());
            DateTime CallBackDate = Convert.ToDateTime(txtPostDate.Text);
            int TicketStatus = Convert.ToInt32(ddlTicketStatus.SelectedItem.Value);
            int AssignedTo = Convert.ToInt32(ddlAssignedTo.SelectedItem.Value);
            int CompletedBy = Convert.ToInt32(ddlCompletedBy.SelectedItem.Value);
            DateTime CompletedDate = Convert.ToDateTime(txtCompletedDt.Text);
            string TicketComments = txtPopTktComments.Text;
            if (txtPopTktComments.Text.Trim() != "")
            {
                if (Session["UpTicketComments"].ToString() != txtPopTktComments.Text.Trim())
                {
                    int CarID = Convert.ToInt32(Session["UpTicketCarID"].ToString());
                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                    String UpdatedBy = Session[Constants.NAME].ToString();
                    string InternalNotesNew = txtPopTktComments.Text.Trim();
                    string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                    InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                    //Notes = InternalNotesNew;
                    if (Session["TicketFrom"].ToString() == "Rvs")
                    {
                        DataSet dsNewIntNotes = objRvMainBL.UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                    }
                    else if (Session["TicketFrom"].ToString() == "Cars")
                    {
                        DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                    }
                    Session.Timeout = 180;
                }
            }
            if (Session["TicketFrom"].ToString() == "Rvs")
            {
                bool bnew = objRvMainBL.SmartzUpdateTicketDetails(TicketID, CallBackDate, TicketStatus, AssignedTo, CompletedBy, CompletedDate, TicketComments);
            }
            else if (Session["TicketFrom"].ToString() == "Cars")
            {
                bool bnew = objdropdownBL.USP_SmartzUpdateTicketDetails(TicketID, CallBackDate, TicketStatus, AssignedTo, CompletedBy, CompletedDate, TicketComments);
            }
            Response.Redirect("CustomerService.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillTicketDDLs()
    {
        try
        {

            SmartzTicketDdlDs = Session["TicketDdl"] as DataSet;
            dsActiveSmartzUsers = Session["ActiveSmartzUsers"] as DataSet;
            ddlTicketStatus.DataSource = SmartzTicketDdlDs.Tables[5];
            ddlTicketStatus.DataTextField = "TicketStatusName";
            ddlTicketStatus.DataValueField = "TicketStatusID";
            ddlTicketStatus.DataBind();
            //ddlTicketStatus.Items.Insert(0, new ListItem("Select", "0"));

            ddlAssignedTo.DataSource = dsActiveSmartzUsers.Tables[0];
            ddlAssignedTo.DataTextField = "SmartzFirstName";
            ddlAssignedTo.DataValueField = "SmartzUID";
            ddlAssignedTo.DataBind();
            ddlAssignedTo.Items.Insert(0, new ListItem("Select", "0"));


            ddlCompletedBy.DataSource = dsActiveSmartzUsers.Tables[0];
            ddlCompletedBy.DataTextField = "SmartzFirstName";
            ddlCompletedBy.DataValueField = "SmartzUID";
            ddlCompletedBy.DataBind();
            ddlCompletedBy.Items.Insert(0, new ListItem("Select", "0"));

            ListItem liAssigned = new ListItem();
            liAssigned.Value = Session[Constants.USER_ID].ToString();
            liAssigned.Text = objGeneralFunc.GetSmartzUser(Session[Constants.USER_ID].ToString());
            ddlAssignedTo.SelectedIndex = ddlAssignedTo.Items.IndexOf(liAssigned);

            ListItem liCompleted = new ListItem();
            liCompleted.Value = Session[Constants.USER_ID].ToString();
            liCompleted.Text = objGeneralFunc.GetSmartzUser(Session[Constants.USER_ID].ToString());
            ddlCompletedBy.SelectedIndex = ddlCompletedBy.Items.IndexOf(liCompleted);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdCSDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBrand = (Label)e.Row.FindControl("lblBrand");
                if (lblBrand.Text.ToString().Trim() == "NULL" || lblBrand.Text.ToString().Trim() == "")
                {
                    lblBrand.Text = "UCE";
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
}
