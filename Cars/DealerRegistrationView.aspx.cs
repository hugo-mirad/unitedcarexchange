
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
using System.Net;
using System.IO;

public partial class DealerRegistrationView : System.Web.UI.Page
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

                //FillSaleDate();
                //FillSaleAgents();
                //FillVerifier();
                //FillRegStates();
                //FillStates();
                FillBillingStates();
                DataSet dsYears = objdropdownBL.USP_GetNext12years();
                fillYears(dsYears);
                //FillVoiceFileLocation();
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
                        DateTime dsSaleDate = Convert.ToDateTime(dsUserdetails.Tables[0].Rows[0]["CreatedDate"].ToString());
                        lblSaleDate.Text = dsSaleDate.ToString("MM/dd/yyyy");
                        lblSaleAgent.Text = dsUserdetails.Tables[0].Rows[0]["SaleAgentName"].ToString();
                        lblSaleVerifier.Text = dsUserdetails.Tables[0].Rows[0]["VerifierName"].ToString();

                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(dsUserdetails.Tables[0].Rows[0]["Price"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = dsUserdetails.Tables[0].Rows[0]["Description"].ToString();
                        lblPackage.Text = PackName + "($" + PackAmount + ")";

                        hdnPackagePrice.Value = PackAmount;

                        lblSellerBusinessName.Text = dsUserdetails.Tables[0].Rows[0]["SellerBusinessName"].ToString();
                        lblSellerPhone.Text = dsUserdetails.Tables[0].Rows[0]["phone"].ToString();
                        //lblSellerAltPhone.Text = dsUserdetails.Tables[0].Rows[0]["SellerAltPhone"].ToString();
                        lblSellerEmail.Text = dsUserdetails.Tables[0].Rows[0]["email"].ToString();
                        // lblSellerAltEmail.Text = dsUserdetails.Tables[0].Rows[0]["SellerAltEmail"].ToString();
                        // lblSellerAddress.Text = dsUserdetails.Tables[0].Rows[0]["address1"].ToString();
                        lblSellerCity.Text = dsUserdetails.Tables[0].Rows[0]["SllerCity"].ToString();
                        lblSellerState.Text = dsUserdetails.Tables[0].Rows[0]["state"].ToString();
                        lblSellerZip.Text = dsUserdetails.Tables[0].Rows[0]["SellerZip"].ToString();

                        string OldNotes = dsUserdetails.Tables[0].Rows[0]["SpecialNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtSpecialNotes.Text = OldNotes;

                        string UserNotes = dsUserdetails.Tables[0].Rows[0]["UserNotes"].ToString();
                        UserNotes = UserNotes.Replace("<br>", Environment.NewLine);
                        UserNotes = UserNotes.Replace("<br />", Environment.NewLine);

                        txtUserNotes.Text = UserNotes;

                        lblUserID.Text = dsUserdetails.Tables[0].Rows[0]["UserID"].ToString();
                        lblDealerID.Text = dsUserdetails.Tables[0].Rows[0]["DealerCode"].ToString();
                        lblRegEmail.Text = dsUserdetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblPassword.Text = dsUserdetails.Tables[0].Rows[0]["Pwd"].ToString();
                        lblRegName.Text = dsUserdetails.Tables[0].Rows[0]["Name"].ToString();
                        lblBusinessName.Text = dsUserdetails.Tables[0].Rows[0]["BusinessName"].ToString();
                        lblRegAltEmail.Text = dsUserdetails.Tables[0].Rows[0]["AltEmail"].ToString();
                        lblRegPhoneNumber.Text = dsUserdetails.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        lblRegAltPhoneNumber.Text = dsUserdetails.Tables[0].Rows[0]["AltPhone"].ToString();
                        lblRegAddress.Text = dsUserdetails.Tables[0].Rows[0]["Address"].ToString();
                        lblRegCity.Text = dsUserdetails.Tables[0].Rows[0]["City"].ToString();
                        lblRegState.Text = dsUserdetails.Tables[0].Rows[0]["RegState"].ToString();
                        lblRegZip.Text = dsUserdetails.Tables[0].Rows[0]["Zip"].ToString();


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
                        lblVoiceFile.Text = dsUserdetails.Tables[0].Rows[0]["VoiceRecord"].ToString();
                        lblVoiceFileLocation.Text = dsUserdetails.Tables[0].Rows[0]["VoiceFileLocationName"].ToString();

                        ListItem liPayST = new ListItem();
                        liPayST.Value = dsUserdetails.Tables[0].Rows[0]["pmntStatus"].ToString();
                        liPayST.Text = dsUserdetails.Tables[0].Rows[0]["PmntStatusName"].ToString();
                        ddlPaymentStatus.SelectedIndex = ddlPaymentStatus.Items.IndexOf(liPayST);

                        if (dsUserdetails.Tables[0].Rows[0]["pmntStatus"].ToString() == "2")
                        {
                            ddlPaymentStatus.Enabled = false;
                            ddlPaymentDate.Enabled = false;
                            txtPaymentAmountIn.Enabled = false;
                            btnUpdate.Visible = false;
                            btnCCProcess.Visible = false;
                            btnCheckProcess.Visible = false;
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
                        }
                        else
                        {
                            if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 5)
                            {
                                btnUpdate.Visible = true;
                                btnCCProcess.Visible = false;
                                btnCheckProcess.Visible = true;
                            }
                            else if (Convert.ToInt32(dsUserdetails.Tables[0].Rows[0]["pmntType"].ToString()) == 6)
                            {
                                btnUpdate.Visible = true;
                                btnCCProcess.Visible = false;
                                btnCheckProcess.Visible = false;
                            }
                            else
                            {
                                btnUpdate.Visible = true;
                                btnCCProcess.Visible = true;
                                btnCheckProcess.Visible = false;
                            }
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

    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("DealerRegistrationEdit.aspx");
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

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Index.aspx");
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
            int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
            int UID = Convert.ToInt32(Session["DealerUID"].ToString());
            int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
            int PmntStatus = Convert.ToInt32(ddlPaymentStatus.SelectedItem.Value);
            string Amount = string.Empty;
            string TransactionID = string.Empty;
            string strIp;
            string strHostName = Request.UserHostAddress.ToString();
            strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            DateTime PaymentDate = new DateTime();
            string PayNotes;
            string Result;
            if (PmntStatus == 2)
            {
                if (rdbtnPayPaypal.Checked == true)
                {
                    TransactionID = txtPaytransID.Text;
                }
                else
                {
                    TransactionID = txtPayTransactionID.Text;
                }
                Amount = txtPaymentAmountIn.Text;
                PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Value);
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime PaymentDate1 = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());              
                String UpdatedBy = Session[Constants.NAME].ToString();
                PayNotes = UpdatedBy + "-" + PaymentDate1.ToString("MM/dd/yyyy hh:mm tt") + " <br>Payment Successfully processed for $" + hdnPackagePrice.Value + " <br> TransID=" + TransactionID + "<br> " + "-------------------------------------------------"; // Returned Authorisation Code;                
                Result = "Paid";
            }
            else
            {
                TransactionID = "";
                Amount = "";
                PaymentDate = Convert.ToDateTime("1/1/1900");
                Result = "Pending";
                PayNotes = "";
            }
            DataSet dspaymentUpdate = objdropdownBL.UpdatePaymentDetailsForDealerRegister(PaymentDate, Amount, PmntStatus, strIp, TransactionID,
                UserPackID, UID, PaymentID, PayNotes);
            if ((rdbtnPayVisa.Checked == true)|| (rdbtnPayMasterCard.Checked == true)|| (rdbtnPayDiscover.Checked == true)||(rdbtnPayAmex.Checked == true))
            {
                SavePayTransInfo(TransactionID, Result);
            }
            if (rdbtnPayCheck.Checked == true)
            {
                SavePayTransInfoForChecks(TransactionID, Result);
            }
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = "Payment details updated successfully";
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
            AuthorizePayment();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private bool AuthorizePayment()
    {
        //CustomValidator1.ErrorMessage = "";
        string AuthNetVersion = "3.1"; // Contains CCV support
        string AuthNetLoginID = "9FtTpx88g879"; //Set your AuthNetLoginID here
        string AuthNetTransKey = "9Gp3Au9t97Wvb784";  // Get this from your authorize.net merchant interface

        WebClient webClientRequest = new WebClient();
        System.Collections.Specialized.NameValueCollection InputObject = new System.Collections.Specialized.NameValueCollection(30);
        System.Collections.Specialized.NameValueCollection ReturnObject = new System.Collections.Specialized.NameValueCollection(30);

        byte[] ReturnBytes;
        string[] ReturnValues;
        string ErrorString;
        //(TESTMODE) Bill To Company is required. (33) 

        InputObject.Add("x_version", AuthNetVersion);
        InputObject.Add("x_delim_data", "True");
        InputObject.Add("x_login", AuthNetLoginID);
        InputObject.Add("x_tran_key", AuthNetTransKey);
        InputObject.Add("x_relay_response", "False");

        //----------------------Set to False to go Live--------------------
        InputObject.Add("x_test_request", "False");
        //---------------------------------------------------------------------
        InputObject.Add("x_delim_char", ",");
        InputObject.Add("x_encap_char", "|");

        //Billing Address
        InputObject.Add("x_first_name", txtCardholderName.Text);
        InputObject.Add("x_last_name", txtCardholderLastName.Text);
        InputObject.Add("x_phone", lblRegPhoneNumber.Text);
        InputObject.Add("x_address", txtbillingaddress.Text);
        InputObject.Add("x_city", txtbillingcity.Text);
        InputObject.Add("x_state", ddlbillingstate.SelectedItem.Value.ToString());
        InputObject.Add("x_zip", txtbillingzip.Text);

        if (lblRegEmail.Text != "")
        {
            InputObject.Add("x_email", lblRegEmail.Text);
        }
        else
        {
            InputObject.Add("x_email", "info@unitedcarexchange.com");
        }

        InputObject.Add("x_email_customer", "TRUE");                     //Emails Customer
        InputObject.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
        InputObject.Add("x_country", "USA");
        InputObject.Add("x_customer_ip", Request.UserHostAddress);  //Store Customer IP Address

        //Amount
        string Package = string.Empty;

        // Package = "Gold Deluxe Promo Package – No cancellations allowed; All sales are final";

        Package = lblPackage.Text;

        //var string = $('#ddlPackage option:selected').text();
        //var p =string.split('$');
        //var pp = p[1].split(')');
        ////alert(pp[0]);
        ////pp[0] = parseInt(pp[0]);
        //pp[0] = parseFloat(pp[0]);
        //var selectedPack = pp[0].toFixed(2);       

        InputObject.Add("x_description", "Payment to " + Package);
        InputObject.Add("x_invoice_num", lblVoiceFile.Text);
        //string.Format("{0:00}", Convert.ToDecimal(lblAdPrice2.Text))) + "Dollars
        //Description of Purchase

        //lblPackDescrip.Text 
        //Card Details
        InputObject.Add("x_card_num", CardNumber.Text);
        InputObject.Add("x_exp_date", ExpMon.SelectedItem.Text + "/" + CCExpiresYear.SelectedItem.Text);
        InputObject.Add("x_card_code", cvv.Text);

        InputObject.Add("x_method", "CC");
        InputObject.Add("x_type", "AUTH_CAPTURE");

        InputObject.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(hdnPackagePrice.Value)));

        //InputObject.Add("x_amount", string.Format("{0:c2}", lblAdPrice2));
        // Currency setting. Check the guide for other supported currencies
        InputObject.Add("x_currency_code", "USD");


        try
        {
            //Actual Server
            //Set above Testmode=off to go live
            webClientRequest.BaseAddress = "https://secure.authorize.net/gateway/transact.dll";

            ReturnBytes = webClientRequest.UploadValues(webClientRequest.BaseAddress, "POST", InputObject);
            ReturnValues = System.Text.Encoding.ASCII.GetString(ReturnBytes).Split(",".ToCharArray());

            if (ReturnValues[0].Trim(char.Parse("|")) == "1")
            {

                ///Successs 

                string AuthNetCode = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                string AuthNetTransID = ReturnValues[6].Trim(char.Parse("|")); // Returned Transaction ID

                //Response.Redirect("PaymentSucces.aspx?NetCode=" + ReturnValues[4].Trim(char.Parse("|")) + "&tx=" + ReturnValues[6].Trim(char.Parse("|")) + "&amt=" + txtPDAmountNow.Text + "&item_number=" + Session["PackageID"].ToString() + "");

                //string PayInfo = "Payment paid for amount $" + hdnPackagePrice.Value + " <br />Authorisation Code" + ReturnValues[4].Trim(char.Parse("|")) + "<br />TransID=" + ReturnValues[6].Trim(char.Parse("|")); // Returned Authorisation Code;

                int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
                int UID = Convert.ToInt32(Session["DealerUID"].ToString());
                int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
                int PmntStatus = Convert.ToInt32(2);
                string Amount = string.Empty;
                string TransactionID = string.Empty;
                string strIp;
                string strHostName = Request.UserHostAddress.ToString();
                strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                DateTime PaymentDate = new DateTime();
                Amount = hdnPackagePrice.Value;
                //PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Value);
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                PaymentDate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                TransactionID = AuthNetTransID;
                String UpdatedBy = Session[Constants.NAME].ToString();
                string PayNotes = UpdatedBy + "-" + PaymentDate.ToString("MM/dd/yyyy hh:mm tt") + " <br>Payment Successfully processed for $" + hdnPackagePrice.Value + "  <br>Authorisation Code " + ReturnValues[4].Trim(char.Parse("|")) + " <br> TransID=" + ReturnValues[6].Trim(char.Parse("|")) + "<br> " + "-------------------------------------------------"; // Returned Authorisation Code;                
                DataSet dspaymentUpdate = objdropdownBL.UpdatePaymentDetailsForDealerRegister(PaymentDate, Amount, PmntStatus, strIp, TransactionID,
                    UserPackID, UID, PaymentID, PayNotes);
                string Result = "Paid";
                SavePayTransInfo(AuthNetTransID, Result);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = "Payment paid for amount $" + hdnPackagePrice.Value + " <br />Authorisation Code" + ReturnValues[4].Trim(char.Parse("|")) + "<br />TransID=" + ReturnValues[6].Trim(char.Parse("|")); // Returned Authorisation Code;
                return true;

            }
            else
            {

                ///Failure
                // Error!
                ErrorString = ReturnValues[3].Trim(char.Parse("|")) + " (" + ReturnValues[2].Trim(char.Parse("|")) + ") " + ReturnValues[4].Trim(char.Parse("|"));

                if (ReturnValues[2].Trim(char.Parse("|")) == "44")
                {
                    // CCV transaction decline
                    ErrorString += "Credit Card Code Verification (CCV) returned the following error: ";

                    switch (ReturnValues[38].Trim(char.Parse("|")))
                    {
                        case "N":
                            ErrorString += "Card Code does not match.";
                            break;
                        case "P":
                            ErrorString += "Card Code was not processed.";
                            break;
                        case "S":
                            ErrorString += "Card Code should be on card but was not indicated.";
                            break;
                        case "U":
                            ErrorString += "Issuer was not certified for Card Code.";
                            break;
                    }
                }

                if (ReturnValues[2].Trim(char.Parse("|")) == "45")
                {
                    if (ErrorString.Length > 1)
                        ErrorString += "<br />n";

                    // AVS transaction decline
                    ErrorString += "Address Verification System (AVS) " +
                      "returned the following error: ";

                    switch (ReturnValues[5].Trim(char.Parse("|")))
                    {
                        case "A":
                            ErrorString += " the zip code entered does not match the billing address.";
                            break;
                        case "B":
                            ErrorString += " no information was provided for the AVS check.";
                            break;
                        case "E":
                            ErrorString += " a general error occurred in the AVS system.";
                            break;
                        case "G":
                            ErrorString += " the credit card was issued by a non-US bank.";
                            break;
                        case "N":
                            ErrorString += " neither the entered street address nor zip code matches the billing address.";
                            break;
                        case "P":
                            ErrorString += " AVS is not applicable for this transaction.";
                            break;
                        case "R":
                            ErrorString += " please retry the transaction; the AVS system was unavailable or timed out.";
                            break;
                        case "S":
                            ErrorString += " the AVS service is not supported by your credit card issuer.";
                            break;
                        case "U":
                            ErrorString += " address information is unavailable for the credit card.";
                            break;
                        case "W":
                            ErrorString += " the 9 digit zip code matches, but the street address does not.";
                            break;
                        case "Z":
                            ErrorString += " the zip code matches, but the address does not.";
                            break;
                    }
                }

                ErrorString = "Payment is DECLINED <br /> " + ErrorString;
                int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
                int UID = Convert.ToInt32(Session["DealerUID"].ToString());
                int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
                int PmntStatus = Convert.ToInt32(1);
                string Amount = string.Empty;
                string TransactionID = string.Empty;
                string strIp;
                string strHostName = Request.UserHostAddress.ToString();
                strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                DateTime PaymentDate = new DateTime();
                Amount = "";
                PaymentDate = Convert.ToDateTime("1/1/1900");
                //DataSet dsDatetime = objdropdownBL.GetDatetime();
                //PaymentDate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                TransactionID = "";
                DataSet dspaymentUpdate = objdropdownBL.UpdatePaymentDetailsForDealerRegister(PaymentDate, Amount, PmntStatus, strIp, TransactionID,
                    UserPackID, UID, PaymentID, ErrorString);
                string Result = "Paid";
                SavePayTransInfo(TransactionID, Result);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = ErrorString;

                return false;
            }
        }
        catch (Exception ex)
        {
            //CustomValidator1.ErrorMessage = ex.Message;
            return false;
        }
    }
    private void SavePayTransInfo(string AuthNetTransID, string Result)
    {
        try
        {
            int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
            int PayTryBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            string CardType = string.Empty;
            if (rdbtnPayVisa.Checked == true)
            {
                CardType = "Visa";
            }
            else if (rdbtnPayMasterCard.Checked == true)
            {
                CardType = "Mastercard";
            }
            else if (rdbtnPayDiscover.Checked == true)
            {
                CardType = "Discover";
            }
            else
            {
                CardType = "Amex";
            }

            string CCardNumber = CardNumber.Text;
            string Address = txtbillingaddress.Text;
            string City = txtbillingcity.Text;
            string State = ddlbillingstate.SelectedItem.Text;
            string Zip = txtbillingzip.Text;
            string Amount = hdnPackagePrice.Value;
            string CCExpiryDate = ExpMon.SelectedItem.Text + "/" + CCExpiresYear.SelectedItem.Text;
            string CardCvv = cvv.Text;
            string CCFirstName = txtCardholderName.Text;
            string CCLastName = txtCardholderLastName.Text;
            DataSet dsSavePayTrans = objdropdownBL.SavePaymentHistoryData(PaymentID, PayTryBy, CardType, CCardNumber, Address, City, State,
                Zip, Amount, Result, AuthNetTransID, CCExpiryDate, CardCvv, CCFirstName, CCLastName);

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
            GoWithCheck();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GoWithCheck()
    {
        try
        {
            // By default, this sample code is designed to post to our test server for
            // developer accounts: https://test.authorize.net/gateway/transact.dll
            // for real accounts (even in test mode), please make sure that you are
            string post_url = "https://secure.authorize.net/gateway/transact.dll";
            //String post_url = "https://test.authorize.net/gateway/transact.dll";

            //The valid routing number of the customer’s bank 9 digits
            string sBankCode = string.Empty;
            sBankCode = txtRoutingNumberForCheck.Text;

            //The customer’s valid bank account number Up to 20 digits The customer’s checking,
            string sBankaccountnumber = string.Empty;
            sBankaccountnumber = txtAccNumberForCheck.Text;
            //The type of bank account CHECKING,BUSINESSCHECKING,SAVINGS
            string sBankType = ddlAccType.SelectedItem.Text;


            //The name of the bank that holds the customer’s account Up to 50 characters
            string sbank_name = txtBankNameForCheck.Text;

            //The name of the bank that holds the customer’s account Up to 50 characters
            string sbank_acct_name = txtCustNameForCheck.Text;
            //The type of electronic check payment request.Types," page 10 of this document.
            //ARC, BOC, CCD, PPD, TEL,WEB
            string echeck_type = "TEL";

            string sbank_check_number = "";




            string AuthNetVersion = "3.1"; // Contains CCV support
            string AuthNetLoginID = "9FtTpx88g879"; //Set your AuthNetLoginID here
            string AuthNetTransKey = "9Gp3Au9t97Wvb784";  // Get this from your authorize.net merchant interface


            Dictionary<string, string> post_values = new Dictionary<string, string>();
            //the API Login ID and Transaction Key must be replaced with valid values

            post_values.Add("x_login", AuthNetLoginID);
            post_values.Add("x_tran_key", AuthNetTransKey);
            post_values.Add("x_delim_data", "TRUE");
            post_values.Add("x_delim_char", "|");
            post_values.Add("x_relay_response", "FALSE");

            post_values.Add("x_type", "AUTH_CAPTURE");
            post_values.Add("x_method", "ECHECK");
            post_values.Add("x_bank_aba_code", sBankCode);
            post_values.Add("x_bank_acct_num", sBankaccountnumber);
            post_values.Add("x_bank_acct_type", sBankType);

            post_values.Add("x_bank_name", sbank_name);
            post_values.Add("x_bank_acct_name", sbank_acct_name);
            post_values.Add("x_echeck_type", echeck_type);
            post_values.Add("x_bank_check_number", sbank_check_number);

            post_values.Add("x_recurring_billing", "False");

            string Package = string.Empty;

            Package = lblPackage.Text;



            post_values.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(hdnPackagePrice.Value)));
            //post_values.Add("x_amount", txtPDAmountNow.Text);
            post_values.Add("x_description", Package);
            post_values.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
            post_values.Add("x_first_name", lblRegName.Text);
            post_values.Add("x_last_name", lblRegName.Text);
            post_values.Add("x_address", lblRegAddress.Text);
            post_values.Add("x_state", lblRegState.Text);
            post_values.Add("x_zip", lblRegZip.Text);
            post_values.Add("x_city", lblRegCity.Text);
            post_values.Add("x_phone", lblRegPhoneNumber.Text);
            // Additional fields can be added here as outlined in the AIM integration
            // guide at: http://developer.authorize.net

            // This section takes the input fields and converts them to the proper format
            // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
            String post_string = "";

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');

            // The following section provides an example of how to add line item details to
            // the post string.  Because line items may consist of multiple values with the
            // same key/name, they cannot be simply added into the above array.
            //
            // This section is commented out by default.
            /*
            string[] line_items = {
                "item1<|>golf balls<|><|>2<|>18.95<|>Y",
                "item2<|>golf bag<|>Wilson golf carry bag, red<|>1<|>39.99<|>Y",
                "item3<|>book<|>Golf for Dummies<|>1<|>21.99<|>Y"};
            foreach( string value in line_items )
            {
                post_string += "&x_line_item=" + HttpUtility.UrlEncode(value);
            }
            */

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            // returned values are returned as a stream, then read into a string
            String post_response;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                post_response = responseStream.ReadToEnd();
                responseStream.Close();
            }

            // the response string is broken into an array
            // The split character specified here must match the delimiting character specified above
            Array response_array = post_response.Split('|');
            string resultSpan = string.Empty;
            // the results are output to the screen in the form of an html numbered list.
            resultSpan += response_array.GetValue(3) + "(Response Code " + response_array.GetValue(0) + ")" + "(Response Reason Code " + response_array.GetValue(2) + ")";
            //foreach (string value in response_array)
            //{
            //    resultSpan += "<LI>" + value + "&nbsp;</LI> \n";
            //}
            //resultSpan += "</OL> \n";
            // individual elements of the array could be accessed to read certain response
            // fields.  For example, response_array[0] would return the Response Code,
            // response_array[2] would return the Response Reason Code.
            // for a list of response fields, please review the AIM Implementation Guide
            if (response_array.GetValue(0).ToString() == "1")
            {
                //Success
                //string AuthNetCode = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                string AuthNetTransID = response_array.GetValue(6).ToString(); // Returned Transaction ID

                //Response.Redirect("PaymentSucces.aspx?NetCode=" + ReturnValues[4].Trim(char.Parse("|")) + "&tx=" + ReturnValues[6].Trim(char.Parse("|")) + "&amt=" + txtPDAmountNow.Text + "&item_number=" + Session["PackageID"].ToString() + "");

                //  string PayInfo = "TransID=" + AuthNetTransID + "<br /> Do you want to move the sale to smartz?"; // Returned Authorisation Code;
                string PayNotes = "TransID=" + AuthNetTransID; // Returned Authorisation Code;                          

                string PayInfo = "Payment paid for amount $" + hdnPackagePrice.Value + "<br /> TransID=" + AuthNetTransID; // Returned Authorisation Code;

                int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
                int UID = Convert.ToInt32(Session["DealerUID"].ToString());
                int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
                int PmntStatus = Convert.ToInt32(2);
                string Amount = string.Empty;
                string TransactionID = string.Empty;
                string strIp;
                string strHostName = Request.UserHostAddress.ToString();
                strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                DateTime PaymentDate = new DateTime();
                Amount = hdnPackagePrice.Value;
                //PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Value);
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                PaymentDate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                TransactionID = AuthNetTransID;
                DataSet dspaymentUpdate = objdropdownBL.UpdatePaymentDetailsForDealerRegister(PaymentDate, Amount, PmntStatus, strIp, TransactionID,
                    UserPackID, UID, PaymentID, PayNotes);
                string Result = "Paid";
                SavePayTransInfoForChecks(AuthNetTransID, Result);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = "Payment paid for amount $" + hdnPackagePrice.Value + "<br /> TransID=" + AuthNetTransID; // Returned Authorisation Code;
                //return true;               
                //return true;
            }
            else
            {

                // SavePayTransInfo(AuthNetTransID, Result);
                resultSpan = "Payment is DECLINED <br /> " + resultSpan;
                int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
                int UID = Convert.ToInt32(Session["DealerUID"].ToString());
                int UserPackID = Convert.ToInt32(Session["DealerUserPackID"].ToString());
                int PmntStatus = Convert.ToInt32(1);
                string Amount = string.Empty;
                string TransactionID = string.Empty;
                string strIp;
                string strHostName = Request.UserHostAddress.ToString();
                strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
                DateTime PaymentDate = new DateTime();
                Amount = "";
                PaymentDate = Convert.ToDateTime("1/1/1900");
                //DataSet dsDatetime = objdropdownBL.GetDatetime();
                //PaymentDate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                TransactionID = "";
                DataSet dspaymentUpdate = objdropdownBL.UpdatePaymentDetailsForDealerRegister(PaymentDate, Amount, PmntStatus, strIp, TransactionID,
                    UserPackID, UID, PaymentID, resultSpan);
                string Result = "Pending";
                SavePayTransInfoForChecks(TransactionID, Result);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = resultSpan;
                //return false;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SavePayTransInfoForChecks(string AuthNetTransID, string Result)
    {
        try
        {
            int PaymentID = Convert.ToInt32(Session["DealerPaymentID"].ToString());
            int PayTryBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            string CardType = string.Empty;
            CardType = "Check";
            string Address = lblRegAddress.Text;
            string City = lblRegCity.Text;
            string State = lblRegState.Text;
            string Zip = lblRegZip.Text;
            string Amount = hdnPackagePrice.Value;
            string AccountHolderName = txtCustNameForCheck.Text;
            string AccountNumber = txtAccNumberForCheck.Text;
            string BankName = txtBankNameForCheck.Text;
            string RoutingNumber = txtRoutingNumberForCheck.Text;
            string AccountType = ddlAccType.SelectedItem.Text;

            DataSet dsSavePayTrans = objdropdownBL.SavePaymentHistoryDataForChecks(PaymentID, PayTryBy, CardType, Address, City, State,
                Zip, Amount, Result, AuthNetTransID, AccountHolderName, AccountNumber, BankName, RoutingNumber, AccountType);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
