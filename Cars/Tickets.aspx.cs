
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

public partial class Tickets : System.Web.UI.Page
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
                if (Session["TicketDdl"] == null)
                {
                    SmartzTicketDdlDs = objdropdownBL.USP_SmartzTicketDropDown();
                    Session["TicketDdl"] = SmartzTicketDdlDs;
                }
                dsActiveSmartzUsers = objCentralDBBL.GetSmartzUsersActiveData();
                Session["ActiveSmartzUsers"] = dsActiveSmartzUsers;
                int SelMode = 1;
                FillDataTicketDetails(SelMode);
                Session.Timeout = 180;
            }
        }
    }

    private void FillDataTicketDetails(int SelMode)
    {
        try
        {
            DataSet dsTicketDetails = objdropdownBL.USP_SmartzTicketSearch(SelMode);
            Session["SearchTicketData"] = dsTicketDetails;
            DataSet dsRvTicketDetails = objRvMainBL.SmartzTicketSearch(SelMode);
            Session["SearchRVTicketData"] = dsRvTicketDetails;
            tblTicketDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "block";
            divRVDetails.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            ImgbtnExcelForCars.Visible = true;
            ImgbtnExcelForRvs.Visible = false;
            if (dsTicketDetails.Tables.Count > 0)
            {
                if (dsTicketDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsTicketDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    grdTicketDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing tickets for Car(s)";
                    grdTicketDetails.DataSource = dsTicketDetails.Tables[0];
                    grdTicketDetails.DataBind();
                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    grdTicketDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing tickets for Car(s)";
                    //lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                grdTicketDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing tickets for Car(s)";
                //lblResHead.Text = "Records not found";
            }
            if (dsRvTicketDetails.Tables.Count > 0)
            {
                if (dsRvTicketDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvTicketDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
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
            DataSet dsTicketDetails = Session["SearchTicketData"] as DataSet;
            DataSet dsRvTicketDetails = Session["SearchRVTicketData"] as DataSet;
            tblTicketDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "block";
            divRVDetails.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            ImgbtnExcelForCars.Visible = true;
            ImgbtnExcelForRvs.Visible = false;
            if (dsTicketDetails.Tables.Count > 0)
            {
                if (dsTicketDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsTicketDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    grdTicketDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing tickets for Car(s)";
                    grdTicketDetails.DataSource = dsTicketDetails.Tables[0];
                    grdTicketDetails.DataBind();
                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    grdTicketDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing tickets for Car(s)";
                    //lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                grdTicketDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing tickets for Car(s)";
                // lblResHead.Text = "Records not found";
            }
            if (dsRvTicketDetails.Tables.Count > 0)
            {
                if (dsRvTicketDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvTicketDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
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
            DataSet dsTicketDetails = Session["SearchTicketData"] as DataSet;
            DataSet dsRvTicketDetails = Session["SearchRVTicketData"] as DataSet;
            tblTicketDetails.Style["display"] = "block";
            divCarResults.Style["display"] = "none";
            divRVDetails.Style["display"] = "block";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            ImgbtnExcelForCars.Visible = false;
            ImgbtnExcelForRvs.Visible = true;
            if (dsTicketDetails.Tables.Count > 0)
            {
                if (dsTicketDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsTicketDetails.Tables[0].Rows.Count.ToString() + " Car(s)";
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
            if (dsRvTicketDetails.Tables.Count > 0)
            {
                if (dsRvTicketDetails.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvTicketDetails.Tables[0].Rows.Count.ToString() + " RV(s)";
                    lnkbtnRVSResCount.Enabled = true;
                    grdRVTicketDetails.Visible = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing tickets for RV(s)";
                    grdRVTicketDetails.DataSource = dsRvTicketDetails.Tables[0];
                    grdRVTicketDetails.DataBind();
                }
                else
                {
                    lnkbtnRVSResCount.Text = "0 RV(S)";
                    lnkbtnRVSResCount.Enabled = false;
                    grdRVTicketDetails.Visible = false;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing tickets for RV(s)";
                    // lblResHead.Text = "Records not found";
                }
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
                grdRVTicketDetails.Visible = false;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing tickets for RV(s)";
                //lblResHead.Text = "Records not found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void grdTicketDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPhone = (Label)e.Row.FindControl("lblPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");


                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if (hdnStatus.Value.ToString() == "")
                {
                    //lblStatus.Text = "Active";
                    //ImgStatus.ImageUrl = "~/images/check.gif";
                    lblStatus.Text = "Pending";
                }
                else
                {
                    //lblStatus.Text = "Inactive";
                    //ImgStatus.ImageUrl = "~/images/red_x.png";
                    lblStatus.Text = hdnStatus.Value.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdTicketDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Session["RedirectFrom"] = 3;
                Response.Redirect("CustomerView.aspx");
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
                    Session["UpTicketCarID"] = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    lblPopTicketType.Text = dsTicketData.Tables[0].Rows[0]["TicketTypeName"].ToString();

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

                mdepTicketAlert.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void grdRVTicketDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPhone = (Label)e.Row.FindControl("lblRVPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnRVPhoneNum");
                Label lblStatus = (Label)e.Row.FindControl("lblRVStatus");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnRVStatus");


                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if (hdnStatus.Value.ToString() == "")
                {
                    //lblStatus.Text = "Active";
                    //ImgStatus.ImageUrl = "~/images/check.gif";
                    lblStatus.Text = "Pending";
                }
                else
                {
                    //lblStatus.Text = "Inactive";
                    //ImgStatus.ImageUrl = "~/images/red_x.png";
                    lblStatus.Text = hdnStatus.Value.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdRVTicketDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["RvPostingID"] = postingID;
                Session["RedirectFrom"] = 3;
                Response.Redirect("RvCustomerView.aspx");
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
                    Session["UpTicketCarID"] = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    lblPopTicketType.Text = dsTicketData.Tables[0].Rows[0]["TicketTypeName"].ToString();

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
                    //    txtPostDate.Text = "";
                    //}

                    if (dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString() != "")
                    {
                        DateTime SolvedDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString());
                        txtCompletedDt.Text = SolvedDate.ToString("MM/dd/yyyy");
                    }
                    //else
                    //{
                    //    txtCompletedDt.Text = "";
                    //}

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

                mdepTicketAlert.Show();
            }
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

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {

            int SelMode;
            if (rdbtnProcessed.Checked == true)
            {
                SelMode = 3;
            }
            else if (rdbtnPending.Checked == true)
            {
                SelMode = 1;
            }
            else
            {
                SelMode = 0;
            }
            FillDataTicketDetails(SelMode);
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkTicketIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketIDSort.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketIDSort.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkTicketIDSort.Text = "Ticket ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketIDSort.Text = "Ticket ID &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkTicketDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CreatedDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketDateSort.Text = "Ticket Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketDateSort.Text = "Ticket Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkTicketDateSort.Text = "Ticket Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketDateSort.Text = "Ticket Dt &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkPrioritySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PriorityName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPrioritySort.Text = "Priority &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPrioritySort.Text = "Priority &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPrioritySort.Text = "Priority &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPrioritySort.Text = "Priority &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkCallBackDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallBackDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkCallBackDtSort.Text = "Cl Back Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkCallBackDtSort.Text = "Cl Back Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkCallBackDtSort.Text = "Cl Back Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkCallBackDtSort.Text = "Cl Back Dt &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkTicketTypeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketTypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketTypeSort.Text = "Ticket Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketTypeSort.Text = "Ticket Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkTicketTypeSort.Text = "Ticket Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketTypeSort.Text = "Ticket Type &#8659";
            }

            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketStatusName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkStatusSort.Text = "Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Status &#8659";
            }

            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
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
          
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
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
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkAssignedtoSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "AssignedTo";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkAssignedtoSort.Text = "Assigned To &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkAssignedtoSort.Text = "Assigned To &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkAssignedtoSort.Text = "Assigned To &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkAssignedtoSort.Text = "Assigned To &#8659";
            }

            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkComDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SolvedDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkComDtSort.Text = "Com Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkComDtSort.Text = "Com Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkComDtSort.Text = "Com Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkComDtSort.Text = "Com Dt &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkComBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SolvedBy";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkComBySort.Text = "Com By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkComBySort.Text = "Com By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkComBySort.Text = "Com By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkComBySort.Text = "Com By &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkCustNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkCustNameSort.Text = "Cust Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkCustNameSort.Text = "Cust Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkCustNameSort.Text = "Cust Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkCustNameSort.Text = "Cust Name &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "phone";
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
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
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
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
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
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
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
            ds = Session["SearchTicketData"] as DataSet;
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
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkTicketCreatedBySort.Text = "Created By &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkTicketCreatedBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CreatedBy";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketCreatedBySort.Text = "Created By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketCreatedBySort.Text = "Created By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkTicketCreatedBySort.Text = "Created By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketCreatedBySort.Text = "Created By &#8659";
            }
            lnkBrand.Text = "Brand  &darr; &uarr;";
            lnkTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkPrioritySort.Text = "Priority &darr; &uarr;";
            lnkCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkStatusSort.Text = "Status &darr; &uarr;";
            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAssignedtoSort.Text = "Assigned To &darr; &uarr;";
            lnkComDtSort.Text = "Com Dt &darr; &uarr;";
            lnkComBySort.Text = "Com By &darr; &uarr;";
            lnkCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkPhoneSort.Text = "Phone &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            mdepTicketAlert.Hide();
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
            int SelMode;
            if (rdbtnProcessed.Checked == true)
            {
                SelMode = 3;
            }
            else if (rdbtnPending.Checked == true)
            {
                SelMode = 1;
            }
            else
            {
                SelMode = 0;
            }
            FillDataTicketDetails(SelMode);
            Session.Timeout = 180;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ImgbtnExcelForCars_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            txtStartDate.Text = dtNow.AddDays(-6).ToString("MM/dd/yyyy");
            txtEndDate.Text = dtNow.ToString("MM/dd/yyyy");
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            Session["TicketsDownType"] = "Cars";
            mpeAskNewSale.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ImgbtnExcelForRvs_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            txtStartDate.Text = dtNow.AddDays(-6).ToString("MM/dd/yyyy");
            txtEndDate.Text = dtNow.ToString("MM/dd/yyyy");
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            Session["TicketsDownType"] = "Rvs";
            mpeAskNewSale.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnDownloadOk_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Hide();
            DataSet dsData = new DataSet();
            int SelMode;
            if (rdbtnProcessed.Checked == true)
            {
                SelMode = 3;
            }
            else if (rdbtnPending.Checked == true)
            {
                SelMode = 1;
            }
            else
            {
                SelMode = 0;
            }
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            if (Session["TicketsDownType"].ToString() == "Cars")
            {
                dsData = objdropdownBL.SmartzTicketSearchDownload(SelMode, StartDate, EndDate);
            }
            else
            {
                dsData = objRvMainBL.SmartzTicketSearchDownload(SelMode, StartDate, EndDate);
            }
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    string SelectedTyepe = "TicketsData";
                    if (dsData.Tables[0].Rows.Count > 0)
                    {
                        mpeAskNewSale.Hide();
                        DataSetToExcel.Convert(dsData, Response, SelectedTyepe);
                    }
                }
                else
                {
                    mpeAskNewSale.Hide();
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Tickets not found";
                }
            }
            else
            {
                mpeAskNewSale.Hide();
                mdepAlertExists.Show();
                lblErrorExists.Visible = true;
                lblErrorExists.Text = "Tickets not found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRVTicketIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVTicketIDSort.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVTicketIDSort.Text = "Ticket ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRVTicketIDSort.Text = "Ticket ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVTicketIDSort.Text = "Ticket ID &#8659";
            }

            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";



            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkBtnRVTicketDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CreatedDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVTicketDateSort.Text = "Ticket Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVTicketDateSort.Text = "Ticket Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRVTicketDateSort.Text = "Ticket Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVTicketDateSort.Text = "Ticket Dt &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";



            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvPrioritySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "PriorityName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvPrioritySort.Text = "Priority &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvPrioritySort.Text = "Priority &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvPrioritySort.Text = "Priority &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvPrioritySort.Text = "Priority &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvCallBackDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CallBackDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvTicketTypeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketTypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvTicketTypeSort.Text = "Ticket Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvTicketTypeSort.Text = "Ticket Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvTicketTypeSort.Text = "Ticket Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvTicketTypeSort.Text = "Ticket Type &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkBtnRvStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketStatusName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvStatusSort.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvStatusSort.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvStatusSort.Text = "Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvStatusSort.Text = "Status &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkBtnRvIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvIDSort.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvIDSort.Text = "RV ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvIDSort.Text = "RV ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvIDSort.Text = "RV ID &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRVAssignedToSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "AssignedTo";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVAssignedToSort.Text = "Assigned To &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVAssignedToSort.Text = "Assigned To &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRVAssignedToSort.Text = "Assigned To &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVAssignedToSort.Text = "Assigned To &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRVCompleteDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SolvedDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVCompleteDtSort.Text = "Com Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVCompleteDtSort.Text = "Com Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRVCompleteDtSort.Text = "Com Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVCompleteDtSort.Text = "Com Dt &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkBtnRvComBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SolvedBy";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvComBySort.Text = "Com By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvComBySort.Text = "Com By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvComBySort.Text = "Com By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvComBySort.Text = "Com By &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkBtnRvCustNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCustNameSort.Text = "Cust Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCustNameSort.Text = "Cust Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvCustNameSort.Text = "Cust Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCustNameSort.Text = "Cust Name &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRVPhoneSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "phone";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVPhoneSort.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVPhoneSort.Text = "Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRVPhoneSort.Text = "Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRVPhoneSort.Text = "Phone &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvYearSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "yearOfMake";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvYearSort.Text = "Year &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvYearSort.Text = "Year &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvMakeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvMakeSort.Text = "Make &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvMakeSort.Text = "Make &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvTypeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvTypeSort.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvTypeSort.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvTypeSort.Text = "Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvTypeSort.Text = "Type &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvCreatedBySort.Text = "Created By &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkBtnRvCreatedBySort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVTicketData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CreatedBy";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCreatedBySort.Text = "Created By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCreatedBySort.Text = "Created By &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvCreatedBySort.Text = "Created By &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvCreatedBySort.Text = "Created By &#8659";
            }

            lnkBtnRVTicketIDSort.Text = "Ticket ID &darr; &uarr;";
            lnkBtnRvTypeSort.Text = "Type &darr; &uarr;";
            lnkBtnRVTicketDateSort.Text = "Ticket Dt &darr; &uarr;";
            lnkBtnRvPrioritySort.Text = "Priority &darr; &uarr;";
            lnkBtnRvCallBackDtSort.Text = "Cl Back Dt &darr; &uarr;";
            lnkBtnRvTicketTypeSort.Text = "Ticket Type &darr; &uarr;";
            lnkBtnRvStatusSort.Text = "Status &darr; &uarr;";
            lnkBtnRvIDSort.Text = "RV ID &darr; &uarr;";
            lnkBtnRVAssignedToSort.Text = "Assigned To &darr; &uarr;";
            lnkBtnRVCompleteDtSort.Text = "Com Dt &darr; &uarr;";
            lnkBtnRvComBySort.Text = "Com By &darr; &uarr;";
            lnkBtnRvCustNameSort.Text = "Cust Name &darr; &uarr;";
            lnkBtnRVPhoneSort.Text = "Phone &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkBtnRvYearSort.Text = "Year &darr; &uarr;";


            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVTicketDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }





}
