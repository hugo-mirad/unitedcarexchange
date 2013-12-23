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

public partial class AddChargebackNewForm : System.Web.UI.Page
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
                FillDdlForNewNotice();
                divResults.Style["display"] = "none";
                tblForm.Style["display"] = "none";
                grdIntroInfo.Visible = false;
                lblResult.Visible = false;
                FillNoticeTypes();
            }
        }
    }

    private void FillNoticeTypes()
    {
        DataSet dsDropData = new DataSet();
        if ((Session["CBNoticeTypes"] == null) || (Session["CBNoticeTypes"].ToString() == ""))
        {
            dsDropData = objdropdownBL.GetNoticeTypes();
            Session["CBNoticeTypes"] = dsDropData;
        }
        else
        {
            dsDropData = Session["CBNoticeTypes"] as DataSet;
        }

        ddlNoticeType.DataSource = dsDropData.Tables[0];
        ddlNoticeType.DataTextField = "NoticeTypeName";
        ddlNoticeType.DataValueField = "NoticeTypeID";
        ddlNoticeType.DataBind();
        ddlNoticeType.Items.Insert(0, new ListItem("Select", "0"));

    }
    private void FillDdlForNewNotice()
    {
        try
        {
            DataSet dsDropData = new DataSet();
            if ((Session["CBProcessor"] == null) || (Session["CBProcessor"].ToString() == ""))
            {
                dsDropData = objdropdownBL.GetChargeBackProcessor();
                Session["CBProcessor"] = dsDropData;
            }
            else
            {
                dsDropData = Session["CBProcessor"] as DataSet;
            }

            ddlType.DataSource = dsDropData.Tables[0];
            ddlType.DataTextField = "ProcessorName";
            ddlType.DataValueField = "ProcessorID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSearchUserDetails_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsUserData = new DataSet();
            string CCNumber = txtCCNumber.Text.Trim();
            int CarID = 0;
            if (txtVehicleID.Text.Trim() != "")
            {
                CarID = Convert.ToInt32(txtVehicleID.Text.Trim());
            }
            else
            {
                CarID = 0;
            }
            dsUserData = objdropdownBL.SmartzSearchForChargeBackUSerByCCOrCarID(CarID, CCNumber);
            if (dsUserData.Tables.Count > 0)
            {
                if (dsUserData.Tables[0].Rows.Count > 0)
                {
                    divResults.Style["display"] = "block";
                    tblForm.Style["display"] = "block";
                    grdIntroInfo.Visible = true;
                    lblResult.Visible = false;
                    grdIntroInfo.DataSource = dsUserData.Tables[0];
                    grdIntroInfo.DataBind();
                }
                else
                {
                    divResults.Style["display"] = "none";
                    tblForm.Style["display"] = "none";
                    grdIntroInfo.Visible = false;
                    lblResult.Visible = true;
                    lblResult.Text = "Results not found";
                }
            }
            else
            {
                divResults.Style["display"] = "none";
                tblForm.Style["display"] = "none";
                grdIntroInfo.Visible = false;
                lblResult.Visible = true;
                lblResult.Text = "Results not found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSaveChargeback_Click(object sender, EventArgs e)
    {
        try
        {
            int UID = 0;
            for (int index = 0; index < grdIntroInfo.Items.Count; index++)
            {
                HiddenField hdnUID = (HiddenField)grdIntroInfo.Items[index].FindControl("hdnUID");
                CheckBox chkbx = (CheckBox)grdIntroInfo.Items[index].FindControl("chkbx");
                if (chkbx.Checked == true)
                {
                    UID = Convert.ToInt32(hdnUID.Value);
                    break;
                }
            }
            DateTime CustomerCantactDate = Convert.ToDateTime(txtCustomerContactDate.Text.ToString());
            DateTime ResponseDate = Convert.ToDateTime(txtResponseDate.Text.ToString());
            DateTime ChargebackDate = Convert.ToDateTime(txtChargebackDate.Text.ToString());
            int CBType = Convert.ToInt32(ddlType.SelectedItem.Value);
            string ReasonCode = txtReasonCode.Text.Trim();
            string ReasonCodeDescrip = txtReasonCodeDescription.Text.Trim();
            string Amount = txtPayAmount.Text.Trim();
            string Notes = txtCBNotes.Text.Trim();
            DataSet dsCBData = objdropdownBL.SmartzSaveUserCBData(UID, CustomerCantactDate, Convert.ToInt32(Session[Constants.USER_ID].ToString()),
                ResponseDate, Convert.ToInt32(Session[Constants.USER_ID].ToString()), ChargebackDate, CBType, ReasonCode, ReasonCodeDescrip,
               Amount, Notes);
            if (dsCBData.Tables[0].Rows.Count > 0)
            {
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = "Chargeback details added successfully";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BtnClsUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AddNewChargeback.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
