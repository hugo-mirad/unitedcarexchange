
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

public partial class Dealerregistration : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
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
                Session.Timeout = 180;

                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                dsActiveSaleAgents = objCentralDBBL.GetSmartzSalesAgentsActiveData();
                Session["ActiveSalesAgents"] = dsActiveSaleAgents;

                FillSaleDate();
                FillSaleAgents();
                FillVerifier();
                FillRegStates();
                FillStates();
                FillBillingStates();
                DataSet dsYears = objdropdownBL.USP_GetNext12years();
                fillYears(dsYears);
                FillVoiceFileLocation();
                FillPaymentDate();
            }
        }
    }
    private void FillRegStates()
    {
        try
        {
            ddlRegState.DataSource = dsDropDown.Tables[1];
            ddlRegState.DataTextField = "State_Code";
            ddlRegState.DataValueField = "State_ID";
            ddlRegState.DataBind();
            ddlRegState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillStates()
    {
        try
        {
            ddlLocationState.DataSource = dsDropDown.Tables[1];
            ddlLocationState.DataTextField = "State_Code";
            ddlLocationState.DataValueField = "State_ID";
            ddlLocationState.DataBind();
            ddlLocationState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillVerifier()
    {
        try
        {
            dsActiveSaleAgents = Session["ActiveSalesAgents"] as DataSet;
            ddlVerifier.DataSource = dsActiveSaleAgents.Tables[0];
            ddlVerifier.DataTextField = "American_Name";
            ddlVerifier.DataValueField = "Sale_Agent_Id";
            ddlVerifier.DataBind();
            ddlVerifier.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillPaymentDate()
    {
        try
        {
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            ddlPaymentDate.Items.Clear();
            for (int i = 0; i < 14; i++)
            {
                ListItem list = new ListItem();
                list.Text = dtNow.AddDays(-i).ToString("MM/dd/yyyy");
                list.Value = dtNow.AddDays(-i).ToString("MM/dd/yyyy");
                ddlPaymentDate.Items.Add(list);
            }
            ddlPaymentDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillSaleAgents()
    {
        try
        {
            dsActiveSaleAgents = Session["ActiveSalesAgents"] as DataSet;
            ddlSalesAgent.DataSource = dsActiveSaleAgents.Tables[0];
            ddlSalesAgent.DataTextField = "American_Name";
            ddlSalesAgent.DataValueField = "Sale_Agent_Id";
            ddlSalesAgent.DataBind();
            ddlSalesAgent.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillSaleDate()
    {
        try
        {
            for (int i = 0; i < 7; i++)
            {
                ListItem list = new ListItem();
                list.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
                list.Value = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
                ddlSaleDate.Items.Add(list);
            }
            ddlSaleDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillBillingStates()
    {
        try
        {
            ddlbillingstate.Items.Clear();
            if (Session["DsDropDown"] == null)
            {
                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                Session["DsDropDown"] = dsDropDown;
            }
            else
            {
                dsDropDown = (DataSet)Session["DsDropDown"];
            }

            ddlbillingstate.DataSource = dsDropDown.Tables[1];
            ddlbillingstate.DataTextField = "State_Code";
            ddlbillingstate.DataValueField = "State_ID";
            ddlbillingstate.DataBind();
            ddlbillingstate.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void fillYears(DataSet dsYears)
    {
        try
        {
            CCExpiresYear.Items.Clear();
            CCExpiresYear.DataSource = dsYears.Tables[0];
            CCExpiresYear.DataTextField = "YearNum";
            CCExpiresYear.DataValueField = "YearValue";
            CCExpiresYear.DataBind();
            CCExpiresYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillVoiceFileLocation()
    {
        try
        {
            DataSet dsVoiceFileLocation = objCentralDBBL.GetVoiceFileLocation();
            ddlVoiceFileLocation.DataSource = dsVoiceFileLocation.Tables[0];
            ddlVoiceFileLocation.DataTextField = "VoiceFileLocationName";
            ddlVoiceFileLocation.DataValueField = "VoiceFileLocationID";
            ddlVoiceFileLocation.DataBind();
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
            string RegName = objGeneralFunc.ToProper(txtRegName.Text).Trim();
            string RegUserName = txtLoginEmail.Text;
            string Password = txtLoginPassword.Text;
            string RegPhone = txtRegPhNo.Text;
            string RegAddress = objGeneralFunc.ToProper(txtRegAddress.Text).Trim();
            string RegCity = objGeneralFunc.ToProper(txtRegCity.Text).Trim();
            int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
            string RegZip = string.Empty;
            string BusinessName = txtRegBusinessName.Text;
            string AltEmail = txtRegAltEmail.Text;
            string RegAltPhone = txtRegAltPhoneNum.Text;
            int SalesAgentID = Convert.ToInt32(ddlSalesAgent.SelectedItem.Value);
            int VerifierID = Convert.ToInt32(ddlVerifier.SelectedItem.Value);
            RegZip = txtregZip.Text;
            string UserID;
            string FistName = RegName;
            if (FistName.Length > 3)
            {
                FistName = FistName.Substring(0, 3);
            }
            string s = "";
            int j;
            Random random1 = new Random();
            for (j = 1; j < 4; j++)
            {
                s += random1.Next(0, 9).ToString();
            }
            UserID = FistName + RegPhone;
            int EmailExists = 1;
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value);
            string DealerID = txtDealerID.Text.Trim();
            DataSet dsDealerIDExists = objdropdownBL.ChkUserExistsDealerCode(DealerID);
            DataSet dsPhoneExists = objdropdownBL.ChkUserExistsPhoneNumber(RegPhone);
            if (dsDealerIDExists.Tables.Count > 0)
            {
                if (dsDealerIDExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Dealer id " + DealerID + " already exists";
                }
                else
                {
                    if (dsPhoneExists.Tables.Count > 0)
                    {
                        if (dsPhoneExists.Tables[0].Rows.Count > 0)
                        {
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Phone number " + RegPhone + " already exists";
                        }
                        else
                        {

                            DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(txtLoginEmail.Text);
                            if (dsUserExists.Tables.Count > 0)
                            {
                                if (dsUserExists.Tables[0].Rows.Count > 0)
                                {
                                    Session.Timeout = 180;
                                    mdepAlertExists.Show();
                                    lblErrorExists.Visible = true;
                                    lblErrorExists.Text = "Email " + RegUserName + " already exists";
                                }
                                else
                                {
                                    DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                    if (dsUserIDExists.Tables.Count > 0)
                                    {
                                        if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                        {
                                            UserID = UserID + s.ToString();
                                            DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                            string m = "";
                                            int l;
                                            if (dsUserIDExists2.Tables.Count > 0)
                                            {
                                                if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                                {
                                                    for (l = 1; l < 2; l++)
                                                    {
                                                        m += random1.Next(0, 9).ToString();
                                                    }
                                                    UserID = UserID + m.ToString();
                                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                                }
                                                else
                                                {
                                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                                }
                                            }
                                            else
                                            {
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                            }
                            else
                            {
                                DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                if (dsUserIDExists.Tables.Count > 0)
                                {
                                    if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                    {
                                        UserID = UserID + s.ToString();
                                        DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                        string m = "";
                                        int l;
                                        if (dsUserIDExists2.Tables.Count > 0)
                                        {
                                            if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                            {
                                                for (l = 1; l < 2; l++)
                                                {
                                                    m += random1.Next(0, 9).ToString();
                                                }
                                                UserID = UserID + m.ToString();
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                            else
                                            {
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }

                        }
                    }
                    else
                    {

                        DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(txtLoginEmail.Text);
                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                Session.Timeout = 180;
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + RegUserName + " already exists";
                            }
                            else
                            {
                                DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                if (dsUserIDExists.Tables.Count > 0)
                                {
                                    if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                    {
                                        UserID = UserID + s.ToString();
                                        DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                        string m = "";
                                        int l;
                                        if (dsUserIDExists2.Tables.Count > 0)
                                        {
                                            if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                            {
                                                for (l = 1; l < 2; l++)
                                                {
                                                    m += random1.Next(0, 9).ToString();
                                                }
                                                UserID = UserID + m.ToString();
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                            else
                                            {
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                    string m = "";
                                    int l;
                                    if (dsUserIDExists2.Tables.Count > 0)
                                    {
                                        if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                        {
                                            for (l = 1; l < 2; l++)
                                            {
                                                m += random1.Next(0, 9).ToString();
                                            }
                                            UserID = UserID + m.ToString();
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                            }
                        }
                    }
                }
            }
            else
            {
                if (dsPhoneExists.Tables.Count > 0)
                {
                    if (dsPhoneExists.Tables[0].Rows.Count > 0)
                    {
                        mdepAlertExists.Show();
                        lblErrorExists.Visible = true;
                        lblErrorExists.Text = "Phone number " + RegPhone + " already exists";
                    }
                    else
                    {

                        DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(txtLoginEmail.Text);
                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                Session.Timeout = 180;
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + RegUserName + " already exists";
                            }
                            else
                            {
                                DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                if (dsUserIDExists.Tables.Count > 0)
                                {
                                    if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                    {
                                        UserID = UserID + s.ToString();
                                        DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                        string m = "";
                                        int l;
                                        if (dsUserIDExists2.Tables.Count > 0)
                                        {
                                            if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                            {
                                                for (l = 1; l < 2; l++)
                                                {
                                                    m += random1.Next(0, 9).ToString();
                                                }
                                                UserID = UserID + m.ToString();
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                            else
                                            {
                                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                            }
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                    string m = "";
                                    int l;
                                    if (dsUserIDExists2.Tables.Count > 0)
                                    {
                                        if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                        {
                                            for (l = 1; l < 2; l++)
                                            {
                                                m += random1.Next(0, 9).ToString();
                                            }
                                            UserID = UserID + m.ToString();
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                            }
                        }
                    }

                }
                else
                {

                    DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(txtLoginEmail.Text);
                    if (dsUserExists.Tables.Count > 0)
                    {
                        if (dsUserExists.Tables[0].Rows.Count > 0)
                        {
                            Session.Timeout = 180;
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Email " + RegUserName + " already exists";
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                    string m = "";
                                    int l;
                                    if (dsUserIDExists2.Tables.Count > 0)
                                    {
                                        if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                        {
                                            for (l = 1; l < 2; l++)
                                            {
                                                m += random1.Next(0, 9).ToString();
                                            }
                                            UserID = UserID + m.ToString();
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                        else
                                        {
                                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                        }
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                            }
                        }
                    }
                    else
                    {
                        DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                        if (dsUserIDExists.Tables.Count > 0)
                        {
                            if (dsUserIDExists.Tables[0].Rows.Count > 0)
                            {
                                UserID = UserID + s.ToString();
                                DataSet dsUserIDExists2 = objdropdownBL.ChkUserExistsUserID(UserID);
                                string m = "";
                                int l;
                                if (dsUserIDExists2.Tables.Count > 0)
                                {
                                    if (dsUserIDExists2.Tables[0].Rows.Count > 0)
                                    {
                                        for (l = 1; l < 2; l++)
                                        {
                                            m += random1.Next(0, 9).ToString();
                                        }
                                        UserID = UserID + m.ToString();
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                                }
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                            }
                        }
                        else
                        {
                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID);
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SaveRegDetails(string RegName, string RegUserName, string Password, string RegPhone, int PackageID, int RegState, string RegCity, string RegAddress, string RegZip, string BusinessName, string AltEmail, string RegAltPhone, int SalesAgentID, int VerifierID, int EmailExists, string UserID, string DealerID)
    {
        try
        {
            DateTime Saledate = Convert.ToDateTime(ddlSaleDate.SelectedItem.Text);
            string SellerName = "";
            string SellerBusinessName = txtSellerBusinessName.Text;
            string SellerPhNum = txtCustPhoneNumber.Text;
            string SellerAltNum = "";
            string SellerEmail = txtSellerEmail.Text;
            string SellerAltEmail = "";
            string SellerAddress = "";
            string SellerCity = txtCity.Text;
            string SellerState = ddlLocationState.SelectedItem.Text;
            string SellerZip = txtZip.Text;
            string strIp;
            string strHostName = Request.UserHostAddress.ToString();
            strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            string SpecialNotes = txtSpecialNotes.Text.Trim();
            string UserNotes = txtUserNotes.Text.Trim();

            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = UserNotes;
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";

            DataSet dsUserInfo = objdropdownBL.USP_SaveDealerRegData(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID, DealerID,
                Saledate, SellerName, SellerPhNum, SellerAltNum, SellerEmail, SellerAltEmail, SellerAddress, SellerCity, SellerState, SellerZip, SellerBusinessName, SpecialNotes, InternalNotesNew);
            int UID = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UID"].ToString());
            Session["DealerUID"] = UID;
            int UserPackID = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString());
            Session["DealerUserPackID"] = UserPackID;
            int SellerID = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["SellerID"].ToString());
            Session["DealerSellerID"] = SellerID;

            int PaymentType = 0;
            string Cardtype = string.Empty;
            if (rdbtnPayVisa.Checked == true)
            {
                PaymentType = 1;
                Cardtype = "VisaCard";
                Session["SavePaymentType"] = 1;
            }
            else if (rdbtnPayMasterCard.Checked == true)
            {
                PaymentType = 2;
                Cardtype = "MasterCard";
                Session["SavePaymentType"] = 2;
            }
            else if (rdbtnPayDiscover.Checked == true)
            {
                PaymentType = 4;
                Cardtype = "DiscoverCard";
                Session["SavePaymentType"] = 4;
            }
            else if (rdbtnPayAmex.Checked == true)
            {
                PaymentType = 3;
                Cardtype = "AmExCard";
                Session["SavePaymentType"] = 3;
            }
            else if (rdbtnPayPaypal.Checked == true)
            {
                PaymentType = 6;
                Session["SavePaymentType"] = 6;
            }
            else if (rdbtnPayCheck.Checked == true)
            {
                PaymentType = 5;
                Session["SavePaymentType"] = 5;
            }

            string VoiceRecord = txtVoicefileConfirmNo.Text.Trim();
            int VoiceFileLocation = Convert.ToInt32(ddlVoiceFileLocation.SelectedItem.Value);
            int pmntStatus = Convert.ToInt32(ddlPaymentStatus.SelectedItem.Value);
            String TransactionID = String.Empty;
            DateTime PaymentDate = new DateTime();
            if (pmntStatus == 2)
            {
                PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Value);
                TransactionID = txtPayTransactionID.Text;
            }
            else
            {
                PaymentDate = Convert.ToDateTime("1/1/1990");
                TransactionID = "";
            }
            string Amount = txtPaymentAmountIn.Text;

            if ((rdbtnPayVisa.Checked == true) || (rdbtnPayMasterCard.Checked == true) || (rdbtnPayDiscover.Checked == true) || (rdbtnPayAmex.Checked == true))
            {
                //PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Value);
                //string Amount = txtPaymentAmountIn.Text;
                string CCCardNumber = CardNumber.Text;
                string CardExpDt = ExpMon.SelectedValue + "/" + CCExpiresYear.SelectedValue;
                string CardholderName = objGeneralFunc.ToProper(txtCardholderName.Text);
                string CardholderLastName = objGeneralFunc.ToProper(txtCardholderLastName.Text);
                string CardCode = cvv.Text;
                string BillingAdd = objGeneralFunc.ToProper(txtbillingaddress.Text);
                string BillingCity = objGeneralFunc.ToProper(txtbillingcity.Text);
                string BillingState = ddlbillingstate.SelectedItem.Value;
                string BillingZip = txtbillingzip.Text;
                DataSet dspayData = objdropdownBL.SaveCreditCardInfoForDealerPaid(PaymentDate, Amount, PaymentType, pmntStatus, strIp, VoiceRecord, VoiceFileLocation, CCCardNumber,
                                    Cardtype, CardExpDt, CardholderName, CardholderLastName, CardCode, BillingZip, BillingAdd, BillingCity, BillingState, UserPackID, UID, TransactionID);
            }
            if (rdbtnPayPaypal.Checked == true)
            {
                string TransID = txtPaytransID.Text;
                string PayPalEmailAcc = txtpayPalEmailAccount.Text;
                DataSet dsSavePayPalInfo = objdropdownBL.SavePayPalDataForDealerPaid(PaymentDate, Amount, PaymentType, pmntStatus, strIp, VoiceRecord, VoiceFileLocation, TransID, PayPalEmailAcc, UserPackID, UID);
            }
            if (rdbtnPayCheck.Checked == true)
            {
                int AccType = Convert.ToInt32(ddlAccType.SelectedItem.Value);
                string BankRouting = txtRoutingNumberForCheck.Text;
                string bankName = txtBankNameForCheck.Text;
                string AccNumber = txtAccNumberForCheck.Text;
                string AccHolderName = txtCustNameForCheck.Text;
                string CheckNumber = "";
                int CheckType = Convert.ToInt32(5);
                DataSet dsSaveCheckInfo = objdropdownBL.SaveCheckDataFordealerPaid(PaymentDate, Amount, PaymentType, pmntStatus, strIp, VoiceRecord, VoiceFileLocation, AccType, BankRouting, bankName, AccNumber,
                    AccHolderName, CheckType, CheckNumber, TransactionID, UserPackID, UID);
            }

            //MPEUpdate.Show();
            //Session.Timeout = 180;
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = "Customer details saved successfully<br />Dealer id: " + DealerID.ToString() + "<br />User id: " + UserID.ToString() + "<br />Password: " + Password.ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Dealerregistration.aspx");
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
            Response.Redirect("DealerRegistrationView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnPayUpdate_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCCProcess_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCheckProcess_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
