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
using CarsBL.CentralDBTransactions;
using CarsBL.RvTransactions;
public partial class ChargeBackNoticesReport : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    RvMainBL ObjRVMainBL = new RvMainBL();
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


    private void FillDdlForNewNotice()
    {
        try
        {
            DataSet dsDropData = new DataSet();
            if ((Session["CBNoticeDropDown"] == null) || (Session["CBNoticeDropDown"].ToString() == ""))
            {
                dsDropData = objdropdownBL.FillCBDropdown();
                Session["CBNoticeDropDown"] = dsDropData;
            }
            else
            {
                dsDropData = Session["CBNoticeDropDown"] as DataSet;
            }

            //ddlProcessor.DataSource = dsDropData.Tables[0];
            //ddlProcessor.DataTextField = "ProcessorName";
            //ddlProcessor.DataValueField = "ProcessorID";
            //ddlProcessor.DataBind();

            //ddlType.DataSource = dsDropData.Tables[1];
            //ddlType.DataTextField = "RequestTypeName";
            //ddlType.DataValueField = "RequestTypeID";
            //ddlType.DataBind();
            //ddlType.Items.Insert(0, new ListItem("Select", "0"));

            //ddlCBStatus.DataSource = dsDropData.Tables[2];
            //ddlCBStatus.DataTextField = "ChargeBackStatusName";
            //ddlCBStatus.DataValueField = "ChargeBackStatusID";
            //ddlCBStatus.DataBind();
            //ddlCBStatus.Items.Insert(0, new ListItem("Select", "0"));


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
