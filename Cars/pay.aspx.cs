using System;
using System.Collections;
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
using System.Net;
using CarsBL.Transactions;

public partial class pay : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    BankDetailsBL objBankDetailsBL = new BankDetailsBL();
    public GeneralFunc objGeneralFunc = new GeneralFunc();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {



            if (Session["CarID"] != null)
            {
                DataSet dsYears = objBankDetailsBL.USP_GetNext12years();

                fillYears(dsYears);

                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                Session["DsDropDown"] = dsDropDown;

                FillStates();

                showsaledetails();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    private void showsaledetails()
    {
        DataSet dsCarDetailsInfo = new DataSet();



        dsCarDetailsInfo = objdropdownBL.USP_GetCarDetailsByIds(Convert.ToInt32(Session["CarID"].ToString()), Convert.ToInt32(Session["RegUSER_ID"].ToString()));

        Session["SelYear"] = dsCarDetailsInfo.Tables[0].Rows[0]["yearOfMake"].ToString();
        Session["SelMake"] = dsCarDetailsInfo.Tables[0].Rows[0]["make"].ToString();
        Session["SelModel"] = dsCarDetailsInfo.Tables[0].Rows[0]["model"].ToString();
        DataSet dsImages = objdropdownBL.USP_GetImages(Convert.ToInt32(Session["CarID"].ToString()), Convert.ToInt32(Session["PackageID"].ToString()));
        Session["GetImages"] = dsImages;


        if (dsImages.Tables[0].Rows[0]["Pic0"].ToString() != "0" && dsImages.Tables[0].Rows[0]["Pic0"].ToString() != "")
        {
            divAdStock.Style["display"] = "none";
            ImageName.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic0Name"].ToString();
        }
        else
        {
            ImageName.ImageUrl = "~/images/stockMakes/" + Session["SelMake"].ToString() + ".jpg";
            divAdStock.Style["display"] = "block";
        }
        lbladmilleage.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Mileage"].ToString();
        lbladPrice.Text = dsCarDetailsInfo.Tables[0].Rows[0]["price"].ToString();
        lblAdBody.Text = dsCarDetailsInfo.Tables[0].Rows[0]["bodytype"].ToString();
        lblAdFuel.Text = dsCarDetailsInfo.Tables[0].Rows[0]["fueltype"].ToString();
        lblCarName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["yearOfMake"].ToString() + " " + dsCarDetailsInfo.Tables[0].Rows[0]["make"].ToString() + " " + dsCarDetailsInfo.Tables[0].Rows[0]["model"].ToString();

        DataSet dsPackDetails = objdropdownBL.USP_GetPackageDetails(Convert.ToInt32(Session["PackageID"]), Convert.ToInt32(Session["RegUSER_ID"]));
        if (dsPackDetails.Tables[0].Rows.Count > 0)
        {
            lblPackDescrip.Text = dsPackDetails.Tables[0].Rows[0]["Description"].ToString();

            Session["Package"] = lblPackDescrip.Text;

            lblMaxPhotos.Text = dsPackDetails.Tables[0].Rows[0]["Maxphotos"].ToString();

            Session["MaxPhotos"] = dsPackDetails.Tables[0].Rows[0]["Maxphotos"];

            lblAdPrice2.Text = dsPackDetails.Tables[0].Rows[0]["Price"].ToString();


            if (lblPhotoUploaded.Text == "")
            {
                lblPhotoUploaded.Text = "0";
            }
        }
        Session["PayBy"] = "Authorize.net";


    }

    //PaymentSucces.aspx
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
        InputObject.Add("x_first_name", FirstNameTextBox.Text);
        InputObject.Add("x_last_name", LastNameTextBox.Text);
        InputObject.Add("x_phone", txtBillPhone.Text);
        InputObject.Add("x_address", AddressTextBox.Text);
        InputObject.Add("x_city", CityTextBox.Text);
        InputObject.Add("x_state", ddlBillState.SelectedItem.Text);
        InputObject.Add("x_zip", txtBillZip.Text);
        InputObject.Add("x_email", EmailTextBox.Text);
        InputObject.Add("x_email_customer", "TRUE");                     //Emails Customer
        InputObject.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
        InputObject.Add("x_country", CountryTextBox.Text);
        InputObject.Add("x_customer_ip", Request.UserHostAddress);  //Store Customer IP Address

        //Amount
        InputObject.Add("x_description", "Payment to " + Session["Package"].ToString());

        //string.Format("{0:00}", Convert.ToDecimal(lblAdPrice2.Text))) + "Dollars
        //Description of Purchase

        //lblPackDescrip.Text 
        //Card Details
        InputObject.Add("x_card_num", txtCardNumber.Text);
        InputObject.Add("x_exp_date", ExpMon.SelectedItem.Text + "/" + CCExpiresYear.SelectedItem.Text);
        InputObject.Add("x_card_code", cvv.Text);

        InputObject.Add("x_method", "CC");
        InputObject.Add("x_type", "AUTH_CAPTURE");
        
        InputObject.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(lblAdPrice2.Text)));

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
                //AuthNetCodeLabel.Text = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                //AuthNetTransIDLabel.Text = ReturnValues[6].Trim(char.Parse("|")); // Returned Transaction ID

                Response.Redirect("PaymentSucces.aspx?NetCode=" + ReturnValues[4].Trim(char.Parse("|")) + "&tx=" + ReturnValues[6].Trim(char.Parse("|")) + "&amt=" + lblAdPrice2.Text + "&item_number=" + Session["PackageID"].ToString() + "");

                lblErr.Text = "Authorisation Code" + ReturnValues[4].Trim(char.Parse("|")) + "</br>TransID=" + ReturnValues[6].Trim(char.Parse("|")); // Returned Authorisation Code;
                mpealteruser.Show();
                return true;
            }
            else
            {
                // Error!
                ErrorString = ReturnValues[3].Trim(char.Parse("|")) + " (" + ReturnValues[2].Trim(char.Parse("|")) + ")";

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
                lblErr.Text = ErrorString;
                mpealteruser.Show();
                // ErrorString contains the actual error
                //CustomValidator1.ErrorMessage = ErrorString;
                return false;
            }
        }
        catch (Exception ex)
        {
            //CustomValidator1.ErrorMessage = ex.Message;
            return false;
        }
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;

        AuthorizePayment();
        //if (CustomValidator1.ErrorMessage.Length > 0)
        //{
        //    args.IsValid = false;
        //}
        //else
        //{
        //    //Processed so send the user to a Thank You Page
        //    ///Response.Redirect("http:ThankYouPayment.aspx");
        //}
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        //dummy postback event authorize validation is done during this postback
        AuthorizePayment();
    }
    private void fillYears(DataSet dsYears)
    {
        try
        {
            CCExpiresYear.DataSource = dsYears.Tables[0];
            CCExpiresYear.DataTextField = "YearNum";
            CCExpiresYear.DataValueField = "YearValue";
            CCExpiresYear.DataBind();
            CCExpiresYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillStates()
    {
        try
        {
            ddlBillState.DataSource = dsDropDown.Tables[1];
            ddlBillState.DataTextField = "State_Code";
            ddlBillState.DataValueField = "State_ID";
            ddlBillState.DataBind();
            ddlBillState.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }
}
