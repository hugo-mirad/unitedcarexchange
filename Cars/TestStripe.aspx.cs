using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;


public partial class TestStripe : System.Web.UI.Page
{
    public static string appkey = System.Configuration.ConfigurationManager.AppSettings["StripeApiKey"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
          // setSecureProtocol(true);

           lblerror.Text = "";
    }
   

    public static void setSecureProtocol(bool bSecure)
    {

        string redirectUrl = null;
        HttpContext context = HttpContext.Current;


        // if we want HTTPS and it is currently HTTP
        if (bSecure && !context.Request.IsSecureConnection)
            redirectUrl = context.Request.Url.ToString().Replace("http:", "https:");

        else
            // if we want HTTP and it is currently HTTPS
            if (!bSecure && context.Request.IsSecureConnection)
                redirectUrl = context.Request.Url.ToString().Replace("https:", "http:");

        //else

        // in all other cases we don't need to redirect

        // check if we need to redirect, and if so use redirectUrl to do the job
        if (redirectUrl != null)
            context.Response.Redirect(redirectUrl);


    }
     
    protected void Button1_Click(object sender, EventArgs e)
    {
        //this is by using customer through
        //try
        //{
        //    StripeCustomer current = GetCustomer();

        //    int chargetotal = 200;//Convert.ToInt32((3.33*Convert.ToInt32(days)*100));
        //    var mycharge = new StripeChargeCreateOptions();
        //    mycharge.AmountInCents = chargetotal;
        //    mycharge.Currency = "USD";
        //    mycharge.CustomerId = current.Id;

        //    string key = "sk_test_fSK5PInUME0uPQnz7LatVoN0";
        //    var chargeservice = new StripeChargeService(key);
        //    StripeCharge currentcharge = chargeservice.Create(mycharge);


        //}
        //catch (StripeException ex)
        //{
        //    string s= (ex.Message);

        //}


        //this is through direct payment
        try
        {
            int chargetotal = 0;//Convert.ToInt32((3.33*Convert.ToInt32(days)*100));
            if (txtAmount.Text == "")
            {
                chargetotal = 0;
            }
            else
            {
                chargetotal = Convert.ToInt32(txtAmount.Text);
            }
            var mycharge = new StripeChargeCreateOptions();
            mycharge.AmountInCents = chargetotal;
            mycharge.Currency = txtcurrency.Text;
            mycharge.CardAddressCity = txtCardAddressCity.Text;
            mycharge.CardAddressCountry = txtCardAddressCountry.Text;
            mycharge.CardAddressLine1 = txtCardAddressLine1.Text;
            mycharge.CardAddressLine2 = txtCardAddressLine2.Text;
            mycharge.CardAddressState = txtCardAddressState.Text;
            mycharge.CardAddressZip = txtCardAddressZip.Text;
            mycharge.CardCvc = txtCardCvc.Text;
            mycharge.CardExpirationMonth = txtCardExpirationMonth.Text;
            mycharge.CardExpirationYear = txtCardExpirationYear.Text;
            mycharge.CardName = txtCardName.Text;
            mycharge.CardNumber = txtCardNumber.Text;

            string key = appkey;
            var chargeservice = new StripeChargeService(key);
            StripeCharge currentcharge = chargeservice.Create(mycharge);
            var response = chargeservice.Create(mycharge);

            lblfailuremessge.Text = response.FailureMessage;
            invoicenumber.Text = response.InvoiceId;
            idm.Text = response.Id;

        }
        catch (StripeException ex)
        {

            lblerror.Text = (ex.Message);

        }
        finally
        {
            if (lblerror.Text == "")
                lblerror.Text = "success";
        }

    }
    private StripeCustomer GetCustomer()
    {

        var mycust = new StripeCustomerCreateOptions();
        mycust.Email = "pankaj@hotmail.com";
        mycust.Description = "Rahul Pandey(rahul@gmail.com)";
        mycust.CardNumber = "4242424242424242";
        mycust.CardExpirationMonth = "11";
        mycust.CardExpirationYear = "2018";
        // mycust.PlanId = "100";
        mycust.CardCvc = "123";
        mycust.CardName = "Rahul Pandey";
        mycust.CardAddressCity = "ABC";
        mycust.CardAddressCountry = "USA";
        mycust.CardAddressLine1 = "asbcd";
        //mycust.TrialEnd = getrialend();
        var customerservice = new StripeCustomerService("sk_test_fSK5PInUME0uPQnz7LatVoN0");

        return customerservice.Create(mycust);


    }
}