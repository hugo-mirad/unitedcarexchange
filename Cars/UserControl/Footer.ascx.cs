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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            HttpCookie UserCookies = Request.Cookies["UserSettings"];

            if (UserCookies == null)
            {
                //FillMakes();

                //FillModels();

                //FillWithin();

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

            //MakesInfo objMakes = new MakesInfo();


            MakesBL objMakesBL = new MakesBL();
            if (Cache["Makes"] == null)
            {
                obj = (List<MakesInfo>)objMakesBL.GetMakes();
            }
            else
            {
                obj = (List<MakesInfo>)Cache["Makes"];
            }

            //XmlDataDocument doc = new XmlDataDocument(obj.toda);

            //return doc.DocumentElement;

            Session["Makes"] = obj;


            ddlMake1.DataSource = obj;
            ddlMake1.DataTextField = "Make";
            ddlMake1.DataValueField = "MakeID";
            ddlMake1.DataBind();
            ddlMake1.Items.Insert(0, new ListItem("Select", "0"));


            ddlMake2.DataSource = obj;
            ddlMake2.DataTextField = "Make";
            ddlMake2.DataValueField = "MakeID";
            ddlMake2.DataBind();
            ddlMake2.Items.Insert(0, new ListItem("Select", "0"));

            ddlMake3.DataSource = obj;
            ddlMake3.DataTextField = "Make";
            ddlMake3.DataValueField = "MakeID";
            ddlMake3.DataBind();
            ddlMake3.Items.Insert(0, new ListItem("Select", "0"));

            ddlMake4.DataSource = obj;
            ddlMake4.DataTextField = "Make";
            ddlMake4.DataValueField = "MakeID";
            ddlMake4.DataBind();
            ddlMake4.Items.Insert(0, new ListItem("Select", "0"));


            ddlMake5.DataSource = obj;
            ddlMake5.DataTextField = "Make";
            ddlMake5.DataValueField = "MakeID";
            ddlMake5.DataBind();
            ddlMake5.Items.Insert(0, new ListItem("Select", "0"));


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

        DdlModel.Items.Clear();

        DdlModel.Items.Insert(0, new ListItem("Select", "0"));

        DdlModel.DataSource = obj.FindAll(p => p.MakeID == Convert.ToInt32(MakeID));
        DdlModel.DataTextField = "Model";
        DdlModel.DataValueField = "MakeModelID";
        DdlModel.DataBind();


    }
    protected void ddlMake1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake1.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMake1.SelectedValue, ddlModel1);
        }
        //else
        //{   ddlModel1.Items.Clear();
        //    ddlModel1.Items.Insert(0, new ListItem("Select", "0"));

        //}
    }
    protected void ddlMake2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake2.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMake2.SelectedValue, ddlModel2);
        }
        //else
        //{
        //    ddlModel2.Items.Clear();
        //    ddlModel2.Items.Insert(0, new ListItem("Select", "0"));

        //}
    }

    protected void ddlMake3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake3.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMake3.SelectedValue, ddlModel3);
        }
        //else
        //{
        //    ddlModel3.Items.Clear();
        //    ddlModel3.Items.Insert(0, new ListItem("Select", "0"));

        //}
    }
    protected void ddlMake4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake4.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMake4.SelectedValue, ddlModel4);
        }
        //else
        //{
        //    ddlModel4.Items.Clear();
        //    ddlModel4.Items.Insert(0, new ListItem("Select", "0"));

        //}
    }

    protected void ddlMake5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMake5.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMake5.SelectedValue, ddlModel5);
        }
        //else
        //{
        //    ddlModel5.Items.Clear();
        //    ddlModel5.Items.Insert(0, new ListItem("Select", "0"));

        //}
    }
    protected void btnSubscribe_Click(object sender, EventArgs e)
    {

        mpesubscribe.Hide();

        PreferencesBL objPreferencesBL = new PreferencesBL();

        DataSet dssub = new DataSet();

        PreferenceInfo ObjPreferncesInfo = new PreferenceInfo();

        PreferncesItemsInfo ObjPreferncesItemsInfo = new PreferncesItemsInfo();


        ObjPreferncesInfo.PreferenceID = "0";

        ObjPreferncesInfo.Zip = txtZip.Text;

        ObjPreferncesInfo.Name = txtName.Text;

        if (txtEmailAlert.Text != "Your Email")
        {
            ObjPreferncesInfo.Email = txtEmailAlert.Text;
        }

        if (txtPhoneNo.Text != "Your Phone")
        {
            ObjPreferncesInfo.Phone = txtPhoneNo.Text;
        }

        String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();

        ObjPreferncesInfo.IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


        if (Request.Cookies["UserSettings"] == null)
        {
            HttpCookie myCookie = new HttpCookie("UserSettings");

            myCookie.Expires = DateTime.Now.AddDays(500);

            myCookie.Values.Add("Email", ObjPreferncesInfo.Email);
            myCookie.Values.Add("Name", ObjPreferncesInfo.Name);
            myCookie.Values.Add("Phone", ObjPreferncesInfo.Phone);

            Response.Cookies.Add(myCookie);
        }


        ObjPreferncesItemsInfo.Makeid = ddlMake1.SelectedValue;
        ObjPreferncesItemsInfo.ModelID = ddlModel1.SelectedValue;
        ObjPreferncesItemsInfo.PriceRange = ddlRange1.SelectedValue;


        DataSet dsEmailExist = new DataSet();

        DataSet dsPreferences = new DataSet();

        dsEmailExist = objPreferencesBL.GetEmailPreferencesbyEmail(txtEmailAlert.Text);

        if (dsEmailExist.Tables[0].Rows.Count == 0)
        {
            dsPreferences = objPreferencesBL.SaveSubscribe(ObjPreferncesInfo, 1);


            for (int i = 1; i < 6; i++)
            {
                string SelectedMake = string.Empty;
                string SelectedModel = string.Empty;
                string SelectedRange = string.Empty;

                if (i == 1)
                {
                    SelectedMake = ddlMake1.SelectedValue;
                    SelectedModel = ddlModel1.SelectedValue;
                    SelectedRange = ddlRange1.SelectedValue;
                }
                else if (i == 2)
                {
                    SelectedMake = ddlMake2.SelectedValue;
                    SelectedModel = ddlModel2.SelectedValue;
                    SelectedRange = ddlRange2.SelectedValue;
                }
                else if (i == 3)
                {
                    SelectedMake = ddlMake3.SelectedValue;
                    SelectedModel = ddlModel3.SelectedValue;
                    SelectedRange = ddlRange3.SelectedValue;
                }
                else if (i == 4)
                {
                    SelectedMake = ddlMake4.SelectedValue;
                    SelectedModel = ddlModel4.SelectedValue;
                    SelectedRange = ddlRange4.SelectedValue;
                }
                else if (i == 5)
                {
                    SelectedMake = ddlMake5.SelectedValue;
                    SelectedModel = ddlModel5.SelectedValue;
                    SelectedRange = ddlRange5.SelectedValue;
                }
                if (SelectedMake != "0" && SelectedModel != "0")
                {

                    ObjPreferncesItemsInfo.Makeid = SelectedMake;


                    ObjPreferncesItemsInfo.ModelID = SelectedModel;

                    ObjPreferncesItemsInfo.PreferenceID = "0";

                    ObjPreferncesItemsInfo.PriceRange = SelectedRange;

                    ObjPreferncesItemsInfo.UserPreferID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

                    dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, true);
                }
            }
            clsMailFormats format = new clsMailFormats();

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(txtEmailAlert.Text);


            msg.To.Add("shravan@datumglobal.net");

            //msg.Bcc.Add();

            msg.Subject = "Welcome to your personalized weekly email alerts preferences.";

            msg.IsBodyHtml = true;

            string text = string.Empty;

            string VerifyPreferences = string.Empty;

            string ModifyPreferences = string.Empty;

            string PreferencesID = string.Empty;

            //VerifyPreferences = "www.unitedcarexchange.com/VerifyPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

            //ModifyPreferences = "www.unitedcarexchange.com/EmailPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

            PreferencesID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

            GeneralFunc obj = new GeneralFunc();

            text = format.SendEMailPreferences(GeneralFunc.ToProper(dsPreferences.Tables[0].Rows[0]["Name"].ToString()), dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString(), ref text);

            msg.Body = text.ToString();

            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
            smtp.EnableSsl = true;
            smtp.Send(msg);
            
            
            //smtp.Host = "127.0.0.1";
            //smtp.Port = 25;
            //smtp.Send(msg);
            

            // Progress111.Visible = false;
            

            Type cstype = GetType();

            ClientScriptManager cs = Page.ClientScript;

            cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

            lblAlertMsg.Text = "Thank you for signing up for automatic email alerts..";
            //mpealert.Show();
        }
        else
        {

            Type cstype = GetType();

            ClientScriptManager cs = Page.ClientScript;

            cs.RegisterStartupScript(cstype, "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");


            lblAlertMsg.Text = "Email ID Already Subscribed..";
            //mpealert.Show();

        }
    }

    private void FillWithin()
    {

        ddlRange1.Items.Clear();
        ddlRange2.Items.Clear();
        ddlRange3.Items.Clear();
        ddlRange4.Items.Clear();
        ddlRange5.Items.Clear();


        ListItem lim = new ListItem();
        ListItem lim1 = new ListItem();
        ListItem lim2 = new ListItem();
        ListItem lim3 = new ListItem();
        ListItem lim4 = new ListItem();
        ListItem lim5 = new ListItem();
        ListItem lim6 = new ListItem();

        ListItem lim0 = new ListItem();

        lim0.Text = "Best offer";
        lim0.Value = "0";

        lim.Text = "1-5000";
        lim.Value = "1";

        lim1.Text = "5001-10000";
        lim1.Value = "2";
        lim2.Text = "10001-25000";
        lim2.Value = "3";
        lim3.Text = "25001-50000";
        lim3.Value = "4";
        lim4.Text = "50001-75000";
        lim4.Value = "5";
        lim5.Text = "75001-100000";
        lim5.Value = "6";
        lim6.Text = "100000+ ";
        lim6.Value = "7";

        ddlRange1.Items.Add(lim0);
        ddlRange2.Items.Add(lim0);
        ddlRange3.Items.Add(lim0);
        ddlRange4.Items.Add(lim0);
        ddlRange5.Items.Add(lim0);


        ddlRange1.Items.Add(lim);
        ddlRange1.Items.Add(lim1);
        ddlRange1.Items.Add(lim2);
        ddlRange1.Items.Add(lim3);
        ddlRange1.Items.Add(lim4);
        ddlRange1.Items.Add(lim5);
        ddlRange1.Items.Add(lim6);


        ddlRange2.Items.Add(lim);
        ddlRange2.Items.Add(lim1);
        ddlRange2.Items.Add(lim2);
        ddlRange2.Items.Add(lim3);
        ddlRange2.Items.Add(lim4);
        ddlRange2.Items.Add(lim5);
        ddlRange2.Items.Add(lim6);


        ddlRange3.Items.Add(lim);
        ddlRange3.Items.Add(lim1);
        ddlRange3.Items.Add(lim2);
        ddlRange3.Items.Add(lim3);
        ddlRange3.Items.Add(lim4);
        ddlRange3.Items.Add(lim5);
        ddlRange3.Items.Add(lim6);

        ddlRange4.Items.Add(lim);
        ddlRange4.Items.Add(lim1);
        ddlRange4.Items.Add(lim2);
        ddlRange4.Items.Add(lim3);
        ddlRange4.Items.Add(lim4);
        ddlRange4.Items.Add(lim5);
        ddlRange4.Items.Add(lim6);

        ddlRange5.Items.Add(lim);
        ddlRange5.Items.Add(lim1);
        ddlRange5.Items.Add(lim2);
        ddlRange5.Items.Add(lim3);
        ddlRange5.Items.Add(lim4);
        ddlRange5.Items.Add(lim5);
        ddlRange5.Items.Add(lim6);





    }
    #endregion
    protected void imgBtnSubscribe_Click(object sender, ImageClickEventArgs e)
    {

        PreferencesBL objPreferencesBL = new PreferencesBL();

        DataSet dssub = new DataSet();

        dssub = objPreferencesBL.GetEmailPreferencesbyEmail(txtSub.Text);

        if (dssub.Tables[0].Rows.Count > 0)
        {
            Response.Redirect("EmailPreferences.aspx?PreferID=" + dssub.Tables[0].Rows[0]["UserPreferID"].ToString() + "");
        }
        else
        {
            FillMakes();

            FillWithin();

            txtEmailAlert.Text = txtSub.Text;

            mpesubscribe.Show();
        }
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

        message.Subject = "Welcome to United Car Exchange";

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
}
