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
using CarsInfo.RvInfo;
using CarsBL.CentralDBTransactions;


public partial class ChargebackClaims : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
    DataSet dsActiveSaleAgents = new DataSet();
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
                FillCBStatus();
                int Status = Convert.ToInt32(ddlCBStatus.SelectedItem.Value);
                GetResults(Status);
            }
        }
    }

    private void GetResults(int Status)
    {
        try
        {
            DataSet dsData = objdropdownBL.SmartzGetChargebackData(Status);
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    lblResult.Visible = false;
                    grdIntroInfo.Visible = true;
                    grdIntroInfo.DataSource = dsData.Tables[0];
                    grdIntroInfo.DataBind();
                    div1.Style["display"] = "block";
                }
                else
                {
                    lblResult.Visible = true;
                    grdIntroInfo.Visible = false;
                    lblResult.Text = "Results not found";
                    div1.Style["display"] = "none";
                }
            }
            else
            {
                lblResult.Visible = true;
                grdIntroInfo.Visible = false;
                lblResult.Text = "Results not found";
                div1.Style["display"] = "none";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillCBStatus()
    {
        try
        {
            DataSet dsCBStatus = new DataSet();
            if ((Session["CBStatus"] == null) || (Session["CBStatus"].ToString() == ""))
            {
                dsCBStatus = objdropdownBL.SmartzGetMasterChargeBackStatus();
                Session["CBStatus"] = dsCBStatus;
            }
            else
            {
                dsCBStatus = Session["CBStatus"] as DataSet;
            }

            ddlCBStatus.DataSource = dsCBStatus.Tables[0];
            ddlCBStatus.DataTextField = "ChargeBackStatusName";
            ddlCBStatus.DataValueField = "ChargeBackStatusID";
            ddlCBStatus.DataBind();


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSearchCBDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int Status = Convert.ToInt32(ddlCBStatus.SelectedItem.Value);
            GetResults(Status);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdIntroInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCBData")
            {
                int UID = Convert.ToInt32(e.CommandArgument.ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
