
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
public partial class DealerRegistrationEdit : System.Web.UI.Page
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
                Int64 SellerID = Convert.ToInt64(Session["DealerSellerID"].ToString());
                Int64 UID = Convert.ToInt64(Session["DealerUID"].ToString());
                Int64 UserPackID = Convert.ToInt64(Session["DealerUserPackID"].ToString());
                DataSet dsUserdetails = objdropdownBL.GetDealerDataAfterRegister(UID, SellerID, UserPackID);
                if (dsUserdetails.Tables.Count > 0)
                {
                    if (dsUserdetails.Tables[0].Rows.Count > 0)
                    {
                        Session["DealerPaymentID"] = dsUserdetails.Tables[0].Rows[0]["paymentID"].ToString();
                        Session["DealerPaymentStatus"] = dsUserdetails.Tables[0].Rows[0]["pmntStatus"].ToString();

                        DateTime dsSaleDate = Convert.ToDateTime(dsUserdetails.Tables[0].Rows[0]["CreatedDate"].ToString());

                        ListItem liSaleDate = new ListItem();
                        liSaleDate.Text = dsSaleDate.ToString("MM/dd/yyyy");
                        liSaleDate.Value = dsSaleDate.ToString("MM/dd/yyyy");
                        ddlSaleDate.SelectedIndex = ddlSaleDate.Items.IndexOf(liSaleDate);

                        ListItem liAgent = new ListItem();
                        liAgent.Text = dsUserdetails.Tables[0].Rows[0]["SaleAgentName"].ToString();
                        liAgent.Value = dsUserdetails.Tables[0].Rows[0]["SaleAgentID"].ToString();
                        ddlSalesAgent.SelectedIndex = ddlSalesAgent.Items.IndexOf(liAgent);

                        ListItem liVerifier = new ListItem();
                        liVerifier.Text = dsUserdetails.Tables[0].Rows[0]["VerifierName"].ToString();
                        liVerifier.Value = dsUserdetails.Tables[0].Rows[0]["VerifierID"].ToString();
                        ddlVerifier.SelectedIndex = ddlVerifier.Items.IndexOf(liVerifier);

                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(dsUserdetails.Tables[0].Rows[0]["Price"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = dsUserdetails.Tables[0].Rows[0]["Description"].ToString();
                        //lblPackage.Text = PackName + "($" + PackAmount + ")";

                        ListItem liPackage = new ListItem();
                        liPackage.Text = PackName + "($" + PackAmount + ")";
                        liPackage.Value = dsUserdetails.Tables[0].Rows[0]["PackageID"].ToString();
                        ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(liPackage);


                        txtSellerBusinessName.Text = dsUserdetails.Tables[0].Rows[0]["SellerBusinessName"].ToString();
                        txtCustPhoneNumber.Text = dsUserdetails.Tables[0].Rows[0]["phone"].ToString();
                        // txtCustAltNumber.Text = dsUserdetails.Tables[0].Rows[0]["SellerAltPhone"].ToString();
                        txtSellerEmail.Text = dsUserdetails.Tables[0].Rows[0]["email"].ToString();
                        // txtSellerAltEmail.Text = dsUserdetails.Tables[0].Rows[0]["SellerAltEmail"].ToString();
                        // txtCustAddress.Text = dsUserdetails.Tables[0].Rows[0]["address1"].ToString();
                        txtCity.Text = dsUserdetails.Tables[0].Rows[0]["SllerCity"].ToString();

                        string OldNotes = dsUserdetails.Tables[0].Rows[0]["SpecialNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtSpecialNotes.Text = OldNotes;

                        string UserNotes = dsUserdetails.Tables[0].Rows[0]["UserNotes"].ToString();
                        UserNotes = UserNotes.Replace("<br>", Environment.NewLine);
                        UserNotes = UserNotes.Replace("<br />", Environment.NewLine);
                        txtUserNotesOld.Text = UserNotes;


                        ListItem liSellerState = new ListItem();
                        liSellerState.Text = dsUserdetails.Tables[0].Rows[0]["state"].ToString();
                        liSellerState.Value = dsUserdetails.Tables[0].Rows[0]["state"].ToString();
                        ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(liSellerState);
                        txtZip.Text = dsUserdetails.Tables[0].Rows[0]["SellerZip"].ToString();

                        lblUserID.Text = dsUserdetails.Tables[0].Rows[0]["UserID"].ToString();
                        lblDealerID.Text = dsUserdetails.Tables[0].Rows[0]["DealerCode"].ToString();
                        txtLoginEmail.Text = dsUserdetails.Tables[0].Rows[0]["UserName"].ToString();
                        txtLoginPassword.Text = dsUserdetails.Tables[0].Rows[0]["Pwd"].ToString();
                        txtRegName.Text = dsUserdetails.Tables[0].Rows[0]["Name"].ToString();
                        txtRegBusinessName.Text = dsUserdetails.Tables[0].Rows[0]["BusinessName"].ToString();
                        txtRegAltEmail.Text = dsUserdetails.Tables[0].Rows[0]["AltEmail"].ToString();
                        txtRegPhNo.Text = dsUserdetails.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        txtRegAltPhoneNum.Text = dsUserdetails.Tables[0].Rows[0]["AltPhone"].ToString();
                        txtRegAddress.Text = dsUserdetails.Tables[0].Rows[0]["Address"].ToString();
                        txtRegCity.Text = dsUserdetails.Tables[0].Rows[0]["City"].ToString();
                        //lblRegState.Text = dsUserdetails.Tables[0].Rows[0]["RegState"].ToString();
                        ListItem liRegState = new ListItem();
                        liRegState.Text = dsUserdetails.Tables[0].Rows[0]["RegState"].ToString();
                        liRegState.Value = dsUserdetails.Tables[0].Rows[0]["RegStateID"].ToString();
                        ddlRegState.SelectedIndex = ddlRegState.Items.IndexOf(liRegState);
                        txtregZip.Text = dsUserdetails.Tables[0].Rows[0]["Zip"].ToString();
                        if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 1)
                        {
                            rdbtnPayVisa.Checked = true;
                        }
                        else if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 2)
                        {
                            rdbtnPayMasterCard.Checked = true;
                        }
                        else if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 3)
                        {
                            rdbtnPayAmex.Checked = true;
                        }
                        else if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 4)
                        {
                            rdbtnPayDiscover.Checked = true;
                        }
                        else if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 5)
                        {
                            rdbtnPayCheck.Checked = true;
                        }
                        else
                        {
                            rdbtnPayPaypal.Checked = true;
                        }

                        if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 5)
                        {
                            divcard.Style["display"] = "none";
                            divcheck.Style["display"] = "block";
                            divpaypal.Style["display"] = "none";
                            txtCustNameForCheck.Text = objGeneralFunc.ToProper(dsUserdetails.Tables[0].Rows[0]["bankAccountHolderName"].ToString());
                            txtAccNumberForCheck.Text = dsUserdetails.Tables[0].Rows[0]["bankAccountNumber"].ToString();
                            txtBankNameForCheck.Text = objGeneralFunc.ToProper(dsUserdetails.Tables[0].Rows[0]["bankName"].ToString());
                            txtRoutingNumberForCheck.Text = dsUserdetails.Tables[0].Rows[0]["bankRouting"].ToString();
                            //lblAccountType.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["AccountTypeName"].ToString());
                            ListItem liAccType = new ListItem();
                            liAccType.Text = dsUserdetails.Tables[0].Rows[0]["AccountTypeName"].ToString();
                            liAccType.Value = dsUserdetails.Tables[0].Rows[0]["bankAccountType"].ToString();
                            ddlAccType.SelectedIndex = ddlAccType.Items.IndexOf(liAccType);

                            //ListItem liCheckType = new ListItem();
                            //liCheckType.Text = Cardetais.Tables[0].Rows[0]["CheckTypeName"].ToString();
                            //liCheckType.Value = Cardetais.Tables[0].Rows[0]["CheckTypeID"].ToString();
                            //ddlCheckType.SelectedIndex = ddlCheckType.Items.IndexOf(liCheckType);
                            //txtCheckNumber.Text = Cardetais.Tables[0].Rows[0]["BankCheckNumber"].ToString();
                        }
                        else if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 6)
                        {
                            divcard.Style["display"] = "none";
                            divcheck.Style["display"] = "none";
                            divpaypal.Style["display"] = "block";
                            txtPaytransID.Text = dsUserdetails.Tables[0].Rows[0]["TransactionID"].ToString();
                            txtpayPalEmailAccount.Text = dsUserdetails.Tables[0].Rows[0]["PaypalEmail"].ToString();
                        }
                        else
                        {
                            divcard.Style["display"] = "block";
                            divcheck.Style["display"] = "none";
                            divpaypal.Style["display"] = "none";
                            txtCardholderName.Text = objGeneralFunc.ToProper(dsUserdetails.Tables[0].Rows[0]["cardholderName"].ToString());
                            //    lblCardType.Text = objGeneralFunc.ToProper(Cardetais.Tables[0].Rows[0]["cardType"].ToString());
                            txtCardholderLastName.Text = objGeneralFunc.ToProper(dsUserdetails.Tables[0].Rows[0]["cardholderLastName"].ToString());
                            CardNumber.Text = dsUserdetails.Tables[0].Rows[0]["cardNumber"].ToString();
                            string EXpDate = dsUserdetails.Tables[0].Rows[0]["cardExpDt"].ToString();
                            if (EXpDate != "")
                            {
                                string[] EXpDt = EXpDate.Split(new char[] { '/' });

                                ListItem liExpMnth = new ListItem();
                                liExpMnth.Text = EXpDt[0].ToString();
                                liExpMnth.Value = EXpDt[0].ToString();
                                ExpMon.SelectedIndex = ExpMon.Items.IndexOf(liExpMnth);


                                ListItem liExpyear = new ListItem();
                                liExpyear.Text = "20" + EXpDt[1].ToString();
                                liExpyear.Value = EXpDt[1].ToString();
                                CCExpiresYear.SelectedIndex = CCExpiresYear.Items.IndexOf(liExpyear);

                            }
                            cvv.Text = dsUserdetails.Tables[0].Rows[0]["cardCode"].ToString();

                            txtbillingaddress.Text = objGeneralFunc.ToProper(dsUserdetails.Tables[0].Rows[0]["billingAdd"].ToString());
                            txtbillingcity.Text = objGeneralFunc.ToProper(dsUserdetails.Tables[0].Rows[0]["billingCity"].ToString());

                            ListItem liBillST = new ListItem();
                            liBillST.Value = dsUserdetails.Tables[0].Rows[0]["billingState"].ToString();
                            liBillST.Text = dsUserdetails.Tables[0].Rows[0]["State_Code"].ToString();
                            ddlbillingstate.SelectedIndex = ddlbillingstate.Items.IndexOf(liBillST);

                            txtbillingzip.Text = dsUserdetails.Tables[0].Rows[0]["billingZip"].ToString();
                        }
                        txtVoicefileConfirmNo.Text = dsUserdetails.Tables[0].Rows[0]["VoiceRecord"].ToString();
                        //lblVoiceFileLocation.Text = dsUserdetails.Tables[0].Rows[0]["VoiceFileLocationName"].ToString();
                        ListItem liVoiceLoc = new ListItem();
                        liVoiceLoc.Value = dsUserdetails.Tables[0].Rows[0]["VoiceFileLocation"].ToString();
                        liVoiceLoc.Text = dsUserdetails.Tables[0].Rows[0]["VoiceFileLocationName"].ToString();
                        ddlVoiceFileLocation.SelectedIndex = ddlVoiceFileLocation.Items.IndexOf(liVoiceLoc);

                        ListItem liPayST = new ListItem();
                        liPayST.Value = dsUserdetails.Tables[0].Rows[0]["pmntStatus"].ToString();
                        liPayST.Text = dsUserdetails.Tables[0].Rows[0]["PmntStatusName"].ToString();
                        ddlPaymentStatus.SelectedIndex = ddlPaymentStatus.Items.IndexOf(liPayST);

                        if (dsUserdetails.Tables[0].Rows[0]["pmntStatus"].ToString() == "2")
                        {
                            ddlPaymentStatus.Enabled = false;
                            ddlPaymentDate.Enabled = false;
                            txtPaymentAmountIn.Enabled = false;
                            //btnUpdate.Visible = false;
                            //btnCCProcess.Visible = false;
                            //btnCheckProcess.Visible = false;
                            txtPaymentAmountIn.Text = dsUserdetails.Tables[0].Rows[0]["Amount"].ToString();
                            DateTime dtPaydate = Convert.ToDateTime(dsUserdetails.Tables[0].Rows[0]["PayDate"].ToString());
                            ListItem liPaydate = new ListItem();
                            liPaydate.Value = dtPaydate.ToString("MM/dd/yyyy");
                            liPaydate.Text = dtPaydate.ToString("MM/dd/yyyy");
                            ddlPaymentDate.SelectedIndex = ddlPaymentDate.Items.IndexOf(liPaydate);
                            divPaymentDate.Style["display"] = "block";
                            divPaymentAmount.Style["display"] = "block";
                            if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) != 6)
                            {
                                divTransID.Style["display"] = "block";
                                txtPayTransactionID.Enabled = false;
                                txtPayTransactionID.Text = dsUserdetails.Tables[0].Rows[0]["TransactionID"].ToString();
                            }
                            else
                            {
                                divTransID.Style["display"] = "none";
                                txtPayTransactionID.Enabled = false;
                            }
                            rdbtnPayVisa.Enabled = false;
                            rdbtnPayMasterCard.Enabled = false;
                            rdbtnPayDiscover.Enabled = false;
                            rdbtnPayAmex.Enabled = false;
                            rdbtnPayPaypal.Enabled = false;
                            rdbtnPayCheck.Enabled = false;
                            //lnkbtnCopySellerInfo.Visible = false;
                            txtCardholderName.Enabled = false;
                            txtCardholderLastName.Enabled = false;
                            CardNumber.Enabled = false;
                            ExpMon.Enabled = false;
                            CCExpiresYear.Enabled = false;
                            cvv.Enabled = false;
                            txtbillingaddress.Enabled = false;
                            txtbillingcity.Enabled = false;
                            ddlbillingstate.Enabled = false;
                            txtbillingzip.Enabled = false;
                            txtCustNameForCheck.Enabled = false;
                            txtAccNumberForCheck.Enabled = false;
                            txtBankNameForCheck.Enabled = false;
                            txtRoutingNumberForCheck.Enabled = false;
                            ddlAccType.Enabled = false;
                            txtPaytransID.Enabled = false;
                            txtpayPalEmailAccount.Enabled = false;
                            txtVoicefileConfirmNo.Enabled = false;
                            ddlVoiceFileLocation.Enabled = false;
                        }
                        else
                        {
                            ddlPaymentStatus.Enabled = true;
                            ddlPaymentDate.Enabled = true;
                            txtPaymentAmountIn.Enabled = true;
                            txtPayTransactionID.Enabled = true;
                            divPaymentDate.Style["display"] = "none";
                            divPaymentAmount.Style["display"] = "none";
                            divTransID.Style["display"] = "none";
                        }
                    }
                }
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
            ddlLocationState.DataValueField = "State_Code";
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

            int SellerID = Convert.ToInt32(Session["DealerSellerID"].ToString());
            int UID = Convert.ToInt32(Session["DealerUID"].ToString());
            int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
            int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
            int PaymentStatus = Convert.ToInt32(Session["DealerPaymentStatus"].ToString());

            DataSet dsPhoneExists = objdropdownBL.SmartzChkUserPhoneNumberExistsForUpdate(RegPhone, UID);

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

                    DataSet dsUserExists = objdropdownBL.USP_SmartzChkUserExistsForUpdate(RegUserName, UID);
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
                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists);
                        }
                    }
                    else
                    {
                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists);
                    }

                }
            }
            else
            {

                DataSet dsUserExists = objdropdownBL.USP_SmartzChkUserExistsForUpdate(RegUserName, UID);
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
                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists);
                    }
                }
                else
                {
                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SaveRegDetails(string RegName, string RegUserName, string Password, string RegPhone, int PackageID, int RegState, string RegCity, string RegAddress, string RegZip, string BusinessName, string AltEmail, string RegAltPhone, int SalesAgentID, int VerifierID, int EmailExists)
    {
        try
        {
            int SellerID = Convert.ToInt32(Session["DealerSellerID"].ToString());
            int UID = Convert.ToInt32(Session["DealerUID"].ToString());
            int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
            int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
            int PaymentStatus = Convert.ToInt32(Session["DealerPaymentStatus"].ToString());

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

            DataSet dsUserInfo = objdropdownBL.UpdateDealerRegData(RegName, RegUserName, Password, RegPhone, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists,
                Saledate, SellerName, SellerPhNum, SellerAltNum, SellerEmail, SellerAltEmail, SellerAddress, SellerCity, SellerState, SellerZip, UID, UserPackID, SellerID, SellerBusinessName, SpecialNotes, InternalNotesNew);

            if (PaymentStatus != 2)
            {
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
                    DataSet dspayData = objdropdownBL.UpdateCreditCardInfoForDealerPaid(PaymentDate, Amount, PaymentType, pmntStatus, strIp, VoiceRecord, VoiceFileLocation, CCCardNumber,
                                        Cardtype, CardExpDt, CardholderName, CardholderLastName, CardCode, BillingZip, BillingAdd, BillingCity, BillingState, UserPackID, UID, TransactionID, PaymentID);
                }
                if (rdbtnPayPaypal.Checked == true)
                {
                    string TransID = txtPaytransID.Text;
                    string PayPalEmailAcc = txtpayPalEmailAccount.Text;
                    DataSet dsSavePayPalInfo = objdropdownBL.UpdatePayPalDataForDealerPaid(PaymentDate, Amount, PaymentType, pmntStatus, strIp, VoiceRecord, VoiceFileLocation, TransID, PayPalEmailAcc, UserPackID, UID, PaymentID);
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
                    DataSet dsSaveCheckInfo = objdropdownBL.UpdateCheckDataFordealerPaid(PaymentDate, Amount, PaymentType, pmntStatus, strIp, VoiceRecord, VoiceFileLocation, AccType, BankRouting, bankName, AccNumber,
                        AccHolderName, CheckType, CheckNumber, TransactionID, UserPackID, UID, PaymentID);
                }

            }
            //MPEUpdate.Show();
            //Session.Timeout = 180;
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            //lblErrUpdated.Text = "Customer details saved successfully with dealer id " + DealerID.ToString() + "<br /> user id " + UserID.ToString() + " and password " + Password.ToString();
            lblErrUpdated.Text = "Customer details updated successfully";
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
            Response.Redirect("DealerRegistrationView.aspx");
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
