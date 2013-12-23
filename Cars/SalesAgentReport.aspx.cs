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

public partial class SalesAgentReport : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    int TotalBasic;
    int TotalStandard;
    int TotalEnhanced;
    int TotalSilver;
    int TotalGold;
    int TotalPlatinum;
    int TotalTotal;
    Double TotalMoney;
    Double ActiveMoney;
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
                txtStartDate.Text = System.DateTime.Now.AddDays(-6).ToString("MM/dd/yyyy");
                txtEndDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                int Active = 0;
                GetResults(StartDate, EndDate, Active);
            }
        }
    }

    private void GetResults(DateTime StartDate, DateTime EndDate, int Active)
    {
        try
        {
            // DateTime StartingDate = Convert.ToDateTime(StartDate.AddDays(-1).ToString("MM/dd/yyyy"));
            //DateTime EndingDate = Convert.ToDateTime(EndDate.AddDays(1).ToString("MM/dd/yyyy"));
            DateTime StartingDate = StartDate;
            DateTime EndingDate = EndDate;
            DataSet dsAgentsData = objdropdownBL.USP_SmartzGetSalesAgentReportFullReport(Active, StartingDate, EndingDate);
            Session["AgentReportData"] = dsAgentsData;
            TotalBasic = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(Other)", ""));
            //TotalStandard = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(StandardPackage)", ""));
            //TotalEnhanced = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(EnhancedPackage)", ""));
            TotalSilver = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(SilverDelux)", ""));
            TotalGold = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(GoldDelux)", ""));
            TotalPlatinum = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(PlatinumDelux)", ""));
            TotalTotal = Convert.ToInt32(dsAgentsData.Tables[0].Compute("sum(Total)", ""));

            TotalMoney = Convert.ToDouble(dsAgentsData.Tables[0].Compute("sum(Amount)", ""));
            ActiveMoney = Convert.ToDouble(dsAgentsData.Tables[0].Compute("sum(ActiveAmount)", ""));


            lblResHead.Text = "Agent performance report for period " + StartDate.ToString("MM/dd/yyyy") + " to " + EndDate.ToString("MM/dd/yyyy");
            lblResCount.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            if (dsAgentsData.Tables[0].Rows.Count > 0)
            {
                grdAgentData.DataSource = dsAgentsData.Tables[0];
                grdAgentData.DataBind();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSearchMonth_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active;
            if (rdbtnActive.Checked == true)
            {
                Active = 1;
            }
            else
            {
                Active = 0;
            }
            GetResults(StartDate, EndDate, Active);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbtnActive_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active = 1;
            GetResults(StartDate, EndDate, Active);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void rdbtnAll_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active = 0;
            GetResults(StartDate, EndDate, Active);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }


    protected void grdAgentData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            DataSet dsUser = new DataSet();
            dsUser = (DataSet)Session["AgentReportData"];

            if (e.CommandName == "ShowSales")
            {
                int AgentID = Convert.ToInt32(e.CommandArgument);
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                DateTime StartingDate = StartDate; //Convert.ToDateTime(StartDate.AddDays(-1).ToString("MM/dd/yyyy"));
                DateTime EndingDate = EndDate;//Convert.ToDateTime(EndDate.AddDays(1).ToString("MM/dd/yyyy"));
                DataSet dsIndvidualAgentData = objdropdownBL.USP_SmartzGetAgentSalesBetweenDate(AgentID, StartingDate, EndingDate);
                string AgentName;
                if (dsIndvidualAgentData.Tables[0].Rows[0]["American_Name"].ToString() != "")
                {
                    AgentName = dsIndvidualAgentData.Tables[0].Rows[0]["American_Name"].ToString();
                }
                else
                {
                    AgentName = "Unknown";
                }
                lblSelAgentname.Text = AgentName;
                lblPopupResults.Text = "Performance report for period " + StartDate.ToString("MM/dd/yyyy") + " to " + EndDate.ToString("MM/dd/yyyy");
                lblPopReportDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                if (dsIndvidualAgentData.Tables[0].Rows.Count > 0)
                {
                    grdIntroInfo.DataSource = dsIndvidualAgentData.Tables[0];
                    grdIntroInfo.DataBind();
                }
                mpeaSalesData.Show();
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
    protected void grdAgentData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnAllAmount = (HiddenField)e.Row.FindControl("hdnAllAmount");
                Label lblAllAmount = (Label)e.Row.FindControl("lblAllAmount");
                HiddenField hdnActiveAmount = (HiddenField)e.Row.FindControl("hdnActiveAmount");
                Label lblActiveAmount = (Label)e.Row.FindControl("lblActiveAmount");
                HiddenField hdnCountTotal = (HiddenField)e.Row.FindControl("hdnCountTotal");
                LinkButton lnkbtnAgentCode = (LinkButton)e.Row.FindControl("lnkbtnAgentCode");
                if (hdnCountTotal.Value == "0")
                {
                    lnkbtnAgentCode.Enabled = false;
                }
                if (hdnAllAmount.Value == "")
                {
                    lblAllAmount.Text = "0.00";
                }
                else
                {
                    Double AllTotalAmt = Convert.ToDouble(hdnAllAmount.Value);
                    lblAllAmount.Text = string.Format("{0:0.00}", AllTotalAmt).ToString();
                }
                if (hdnActiveAmount.Value == "")
                {
                    lblActiveAmount.Text = "0.00";
                }
                else
                {
                    Double ActiveTotalAmt = Convert.ToDouble(hdnActiveAmount.Value);
                    lblActiveAmount.Text = string.Format("{0:0.00}", ActiveTotalAmt).ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblFooterCountBasic = (Label)e.Row.FindControl("lblFooterCountBasic");
                //Label lblFooterCountStandard = (Label)e.Row.FindControl("lblFooterCountStandard");
                //Label lblFooterCountEnhanced = (Label)e.Row.FindControl("lblFooterCountEnhanced");
                Label lblFooterCountSilver = (Label)e.Row.FindControl("lblFooterCountSilver");
                Label lblFooterCountGold = (Label)e.Row.FindControl("lblFooterCountGold");
                Label lblFooterCountPlatinum = (Label)e.Row.FindControl("lblFooterCountPlatinum");
                Label lblFooterCountTotal = (Label)e.Row.FindControl("lblFooterCountTotal");
                Label lblFooterAllAmount = (Label)e.Row.FindControl("lblFooterAllAmount");
                Label lblFooterActiveAmount = (Label)e.Row.FindControl("lblFooterActiveAmount");


                lblFooterCountBasic.Text = TotalBasic.ToString();
                //lblFooterCountStandard.Text = TotalStandard.ToString();
                //lblFooterCountEnhanced.Text = TotalEnhanced.ToString();
                lblFooterCountSilver.Text = TotalSilver.ToString();
                lblFooterCountGold.Text = TotalGold.ToString();
                lblFooterCountPlatinum.Text = TotalPlatinum.ToString();
                lblFooterCountTotal.Text = TotalTotal.ToString();
                lblFooterAllAmount.Text = string.Format("{0:0.00}", TotalMoney).ToString();
                lblFooterActiveAmount.Text = string.Format("{0:0.00}", ActiveMoney).ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
