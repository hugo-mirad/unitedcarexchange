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
using CarsInfo;
using CarsBL.Masters;
using System.Collections.Generic;
using System.Net.Mail;
using CarsBL.Transactions;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Xml;


public partial class UserControl_Footer : System.Web.UI.UserControl
{
    DropdownBL objdropdownBL = new DropdownBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            HttpCookie UserCookies = Request.Cookies["UserSettings"];

            if (UserCookies == null)
            {
                 FillMakes();
                 FillModels();
                 FillWithin();
                // mpesubscribe.Show();
              

                

                if (Session["PageName"] != "Email Prefereces" && Session["PageName"] != "Unsubscribe")
                {
                    if (Session[Constants.Subscribe] == null)
                    {
                        //SetPostalCodeJavascript();
                    }
                }
            }
        }
    }


    #region SubScribe
    private void FillModels()
    {

        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Cache["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Cache["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Cache["Model"];
        }

    }

    private void SetPostalCodeJavascript()
    {

        // Define the name and type of the client scripts on the page.

        const string csname = "PostalCodeLabelScript";

        Type cstype = GetType();



        // Get a ClientScriptManager reference from the Page class.

        ClientScriptManager cs = Page.ClientScript;



        // Check to see if the client script is already registered.

        if (!cs.IsClientScriptBlockRegistered(cstype, csname))
        {
            StringBuilder cstext = new StringBuilder();

            cstext.AppendFormat("<script type=\"text/javascript\">{0}", Environment.NewLine);

            cstext.AppendFormat("\t $(window).load(function(){0}", Environment.NewLine);

            cstext.AppendFormat("\t{{{0} setTimeout(function(){0} {{{0}$find('Footer1_mpesubscribe').show()}}{0},10000)", Environment.NewLine);

            cstext.AppendFormat("\t}});{0}", Environment.NewLine);

            cstext.Append(Environment.NewLine);

            cstext.AppendFormat("</script>{0}", Environment.NewLine);

            cs.RegisterClientScriptBlock(cstype, csname, cstext.ToString(), false);
        }
    }

    public void FillMakes()
    {

        try
        {
            var obj = new List<MakesInfo>();

          
            MakesBL objMakesBL = new MakesBL();
            if (Cache["Makes"] == null)
            {
                obj = (List<MakesInfo>)objMakesBL.GetMakes();
            }
            else
            {
                obj = (List<MakesInfo>)Cache["Makes"];
            }

          

            Session["Makes"] = obj;


            ddlmakesp.DataSource = obj;
            ddlmakesp.DataTextField = "Make";
            ddlmakesp.DataValueField = "MakeID";
            ddlmakesp.DataBind();
            ddlmakesp.Items.Insert(0, new ListItem("Select", "0"));



        }
        catch (Exception ex)
        {
        }
    }


    private void GetModelsInfo(string MakeID, DropDownList DdlModel)
    {
        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Cache["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Cache["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Cache["Model"];
        }

        ddlmodelsp.Items.Clear();

        ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));

        ddlmodelsp.DataSource = obj.FindAll(p => p.MakeID == Convert.ToInt32(MakeID));
        ddlmodelsp.DataTextField = "Model";
        ddlmodelsp.DataValueField = "MakeModelID";
        ddlmodelsp.DataBind();


    }
   
 
    protected void btnSubscribe_Click(object sender, EventArgs e)
    {

        //mpesubscribe.Hide();

        //PreferencesBL objPreferencesBL = new PreferencesBL();

        //DataSet dssub = new DataSet();

        //PreferenceInfo ObjPreferncesInfo = new PreferenceInfo();

        //PreferncesItemsInfo ObjPreferncesItemsInfo = new PreferncesItemsInfo();


        //ObjPreferncesInfo.PreferenceID = "0";

        //ObjPreferncesInfo.Zip = txtZip.Text;

        //ObjPreferncesInfo.Name = txtName.Text;

        //if (txtEmailAlert.Text != "Your Email")
        //{
        //    ObjPreferncesInfo.Email = txtEmailAlert.Text;
        //}

        //if (txtPhoneNo.Text != "Your Phone")
        //{
        //    ObjPreferncesInfo.Phone = txtPhoneNo.Text;
        //}

        //String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();

        //ObjPreferncesInfo.IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


        //if (Request.Cookies["UserSettings"] == null)
        //{
        //    HttpCookie myCookie = new HttpCookie("UserSettings");

        //    myCookie.Expires = DateTime.Now.AddDays(500);

        //    myCookie.Values.Add("Email", ObjPreferncesInfo.Email);
        //    myCookie.Values.Add("Name", ObjPreferncesInfo.Name);
        //    myCookie.Values.Add("Phone", ObjPreferncesInfo.Phone);

        //    Response.Cookies.Add(myCookie);
        //}


        //ObjPreferncesItemsInfo.Makeid = ddlMake1.SelectedValue;
        //ObjPreferncesItemsInfo.ModelID = ddlModel1.SelectedValue;
        //ObjPreferncesItemsInfo.PriceRange = ddlRange1.SelectedValue;


        //DataSet dsEmailExist = new DataSet();

        //DataSet dsPreferences = new DataSet();

        //dsEmailExist = objPreferencesBL.GetEmailPreferencesbyEmail(txtEmailAlert.Text);

        //if (dsEmailExist.Tables[0].Rows.Count == 0)
        //{
        //    dsPreferences = objPreferencesBL.SaveSubscribe(ObjPreferncesInfo, 1);


        //    for (int i = 1; i < 6; i++)
        //    {
        //        string SelectedMake = string.Empty;
        //        string SelectedModel = string.Empty;
        //        string SelectedRange = string.Empty;

        //        if (i == 1)
        //        {
        //            SelectedMake = ddlMake1.SelectedValue;
        //            SelectedModel = ddlModel1.SelectedValue;
        //            SelectedRange = ddlRange1.SelectedValue;
        //        }
        //        else if (i == 2)
        //        {
        //            SelectedMake = ddlMake2.SelectedValue;
        //            SelectedModel = ddlModel2.SelectedValue;
        //            SelectedRange = ddlRange2.SelectedValue;
        //        }
        //        else if (i == 3)
        //        {
        //            SelectedMake = ddlMake3.SelectedValue;
        //            SelectedModel = ddlModel3.SelectedValue;
        //            SelectedRange = ddlRange3.SelectedValue;
        //        }
        //        else if (i == 4)
        //        {
        //            SelectedMake = ddlMake4.SelectedValue;
        //            SelectedModel = ddlModel4.SelectedValue;
        //            SelectedRange = ddlRange4.SelectedValue;
        //        }
        //        else if (i == 5)
        //        {
        //            SelectedMake = ddlMake5.SelectedValue;
        //            SelectedModel = ddlModel5.SelectedValue;
        //            SelectedRange = ddlRange5.SelectedValue;
        //        }
        //        if (SelectedMake != "0" && SelectedModel != "0")
        //        {

        //            ObjPreferncesItemsInfo.Makeid = SelectedMake;


        //            ObjPreferncesItemsInfo.ModelID = SelectedModel;

        //            ObjPreferncesItemsInfo.PreferenceID = "0";

        //            ObjPreferncesItemsInfo.PriceRange = SelectedRange;

        //            ObjPreferncesItemsInfo.UserPreferID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

        //            dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, true);
        //        }
        //    }
        //    clsMailFormats format = new clsMailFormats();

        //    MailMessage msg = new MailMessage();

        //    msg.From = new MailAddress(txtEmailAlert.Text);


        //    msg.To.Add("shravan@datumglobal.net");

        //    //msg.Bcc.Add();

        //    msg.Subject = "Welcome to your personalized weekly email alerts preferences.";

        //    msg.IsBodyHtml = true;

        //    string text = string.Empty;

        //    string VerifyPreferences = string.Empty;

        //    string ModifyPreferences = string.Empty;

        //    string PreferencesID = string.Empty;

        //    //VerifyPreferences = "mobicarz.com/VerifyPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

        //    //ModifyPreferences = "mobicarz.com/EmailPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

        //    PreferencesID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

        //    GeneralFunc obj = new GeneralFunc();

        //    text = format.SendEMailPreferences(GeneralFunc.ToProper(dsPreferences.Tables[0].Rows[0]["Name"].ToString()), dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString(), ref text);

        //    msg.Body = text.ToString();

        //    SmtpClient smtp = new SmtpClient();

        //    smtp.Host = "smtp.gmail.com";
        //    smtp.Port = 587;
        //    smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
        //    smtp.EnableSsl = true;
        //    smtp.Send(msg);
            
            
        //    //smtp.Host = "127.0.0.1";
        //    //smtp.Port = 25;
        //    //smtp.Send(msg);
            

        //    // Progress111.Visible = false;
            

        //    Type cstype = GetType();

        //    ClientScriptManager cs = Page.ClientScript;

        //    cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

        //    lblAlertMsg.Text = "Thank you for signing up for automatic email alerts..";
        //    //mpealert.Show();
        //}
        //else
        //{

        //    Type cstype = GetType();

        //    ClientScriptManager cs = Page.ClientScript;

        //    cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");


        //    lblAlertMsg.Text = "Email ID Already Subscribed..";
        //    //mpealert.Show();

        //}
    }

    private void FillWithin()
    {

        try
        {
            DataSet dsYears = new DataSet();
            if (Session["CarsYears"] == null)
            {
                dsYears = objdropdownBL.GetYears();
                Session["CarsYears"] = dsYears;
            }
            else
            {
                dsYears = Session["CarsYears"] as DataSet;
            }
            ddlyearp.DataSource = dsYears.Tables[0];
            ddlyearp.DataTextField = "Year";
            ddlyearp.DataValueField = "Year";
            ddlyearp.DataBind();
            ddlyearp.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    #endregion
    protected void imgBtnSubscribe_Click(object sender, ImageClickEventArgs e)
    {

        //PreferencesBL objPreferencesBL = new PreferencesBL();

        //DataSet dssub = new DataSet();

        //dssub = objPreferencesBL.GetEmailPreferencesbyEmail(txtSub.Text);

        //if (dssub.Tables[0].Rows.Count > 0)
        //{
        //    Response.Redirect("EmailPreferences.aspx?PreferID=" + dssub.Tables[0].Rows[0]["UserPreferID"].ToString() + "");
        //}
        //else
        //{
        //    FillMakes();

        //    FillWithin();

        //    txtEmailAlert.Text = txtSub.Text;

        //    mpesubscribe.Show();
        //}
    }

    protected void btnSubscribeCancel_Click(object sender, EventArgs e)
    {
        Type cstype = GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

        Session[Constants.Subscribe] = 1;
        mpesubscribe.Hide();
    }
    protected void btnsubScribUs_Click(object sender, EventArgs e)
    {

        Type cstype = GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

        Session[Constants.Subscribe] = 1;
        mpesubscribe.Hide();
    }
    protected void btnRefer_Click(object sender, EventArgs e)
    {

        MailMessage message = new MailMessage();
        clsMailFormats objMail = new clsMailFormats();

        message.From = new MailAddress(CommonVariable.FromInfoMail);

        message.To.Add(Convert.ToString(txtReferfrn.Text.Trim()));

        message.Subject = "Welcome to MobiCarz";

        message.IsBodyHtml = true;
        string strMail = string.Empty;

        objMail.SendReferFriend(txtReferfrn.Text.Trim(), ref   strMail);

        message.Body = strMail.ToString();

        SmtpClient smtp = new SmtpClient();

        //smtp.Host = "smtp.gmail.com";
        //smtp.Port = 587;
        //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
        //smtp.EnableSsl = true;
        //smtp.Send(message);

        smtp.Host = "127.0.0.1";
        smtp.Port = 25;
        smtp.Send(message);



        txtReferfrn.Text = "";


        lblAlertMsg.Text = "Thank You For Referring!"; ;
        //mpealert.Show();



        Type cstype = GetType();

        ClientScriptManager cs = Page.ClientScript;

        cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

        txtReferfrn.Text = "Refer friend";  


    }
    protected void btnOk1_Click(object sender, EventArgs e)
    {
        Type cstype = GetType();
        ClientScriptManager cs = Page.ClientScript;
        cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

        //mpealert.Hide();


    }
    protected void ddlmakesp_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlmakesp.SelectedIndex > 0)
        {
            GetModelsInfo(ddlmakesp.SelectedValue, ddlmodelsp);
        }
        else
        {
            ddlmodelsp.Items.Clear();
            ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
}
