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
using CarsBL.Transactions;
using CarsInfo;
using System.Net.Mail;
using CarsBL.Masters;

using System.Collections.Generic;

public partial class EmailPreferences : System.Web.UI.Page
{
    NewCarsBl objNewCarsBl = new NewCarsBl();
    NewCarsInfo objNewCarsInfo = new NewCarsInfo();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //KeyWords.Addkeywordstags(Header);

            //GeneralFunc.SaveSiteVisit();

            Session["PageName"] = "Email Prefereces";

            Session["CurrentPageConfig"] = null;

            GeneralFunc.SaveSiteVisit();

            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            GeneralFunc.SetPageDefaults(Page);

            GetMakes();

            FillWithin();

            FillModels();

            if (Request.QueryString.Keys.Count > 0)
            {
                string URL = string.Empty;
                string URL1 = string.Empty;
                if (Request.QueryString.Keys.Count > 0)
                {
                    if (URL != null)
                    {

                        GetEmailPreferences(Request.QueryString["PreferID"]);

                    }
                }
                if (Request.QueryString.Keys.Count > 1)
                {
                    URL = Request.QueryString[0];

                    URL1 = Request.QueryString[1];

                    if (URL != null && URL1 != null)
                    {
                        GetEmailPreferences(Request.QueryString["PreferID"]);

                        lblTitle.Text = "Your Email Alerts Successfully Activated..";

                        lblTitle.Visible = true;
                    }
                }
            }
        }

    }

    private void FillModels()
    {

        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Session["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Session["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Session["Model"];
        }
    }

    #region SubScribe



    public void GetMakes()
    {

        try
        {
            var obj = new List<MakesInfo>();

            //MakesInfo objMakes = new MakesInfo();
            MakesBL objMakesBL = new MakesBL();

            obj = (List<MakesInfo>)objMakesBL.GetMakes();
            Session["Makes"] = obj;


            ddlMakes1.DataSource = obj;
            ddlMakes1.DataTextField = "Make";
            ddlMakes1.DataValueField = "MakeID";
            ddlMakes1.DataBind();
            ddlMakes1.Items.Insert(0, new ListItem("Select", "0"));


            ddlMakes2.DataSource = obj;
            ddlMakes2.DataTextField = "Make";
            ddlMakes2.DataValueField = "MakeID";
            ddlMakes2.DataBind();
            ddlMakes2.Items.Insert(0, new ListItem("Select", "0"));

            ddlMakes3.DataSource = obj;
            ddlMakes3.DataTextField = "Make";
            ddlMakes3.DataValueField = "MakeID";
            ddlMakes3.DataBind();
            ddlMakes3.Items.Insert(0, new ListItem("Select", "0"));

            ddlMakes4.DataSource = obj;
            ddlMakes4.DataTextField = "Make";
            ddlMakes4.DataValueField = "MakeID";
            ddlMakes4.DataBind();
            ddlMakes4.Items.Insert(0, new ListItem("Select", "0"));


            ddlMakes5.DataSource = obj;
            ddlMakes5.DataTextField = "Make";
            ddlMakes5.DataValueField = "MakeID";
            ddlMakes5.DataBind();
            ddlMakes5.Items.Insert(0, new ListItem("Select", "0"));


        }
        catch (Exception ex)
        {
        }
    }


    private void GetModelsInfo(string MakeID, DropDownList DdlModel)
    {
        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Session["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Session["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Session["Model"];
        }

        DdlModel.Items.Clear();

        DdlModel.Items.Insert(0, new ListItem("Select", "0"));

        DdlModel.DataSource = obj.FindAll(p => p.MakeID == Convert.ToInt32(MakeID)); ;

        DdlModel.DataTextField = "Model";
        DdlModel.DataValueField = "MakeModelID";
        DdlModel.DataBind();


    }



    protected void ddlMake1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMakes1.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMakes1.SelectedValue, ddlModels1);
        }
        else
        {
            ddlModels1.Items.Clear();
            ddlModels1.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    protected void ddlMake2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMakes2.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMakes2.SelectedValue, ddlModels2);
        }
        else
        {
            ddlModels2.Items.Clear();
            ddlModels2.Items.Insert(0, new ListItem("Select", "0"));

        }
    }

    protected void ddlMake3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMakes3.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMakes3.SelectedValue, ddlModels3);
        }
        else
        {
            ddlModels3.Items.Clear();
            ddlModels3.Items.Insert(0, new ListItem("Select", "0"));

        }
    }
    protected void ddlMake4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMakes4.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMakes4.SelectedValue, ddlModels4);
        }
        else
        {
            ddlModels4.Items.Clear();
            ddlModels4.Items.Insert(0, new ListItem("Select", "0"));

        }
    }

    protected void ddlMake5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMakes5.SelectedIndex > 0)
        {
            GetModelsInfo(ddlMakes5.SelectedValue, ddlModels5);
        }
        else
        {
            ddlModels5.Items.Clear();
            ddlModels5.Items.Insert(0, new ListItem("Select", "0"));

        }
    }



    protected void btnSubscribe_Click(object sender, EventArgs e)
    {

        PreferencesBL objPreferencesBL = new PreferencesBL();

        DataSet dssub = new DataSet();

        PreferenceInfo ObjPreferncesInfo = new PreferenceInfo();

        PreferncesItemsInfo ObjPreferncesItemsInfo = new PreferncesItemsInfo();


        ObjPreferncesInfo.PreferenceID = hdnUserPrefernceID.Value;

        if (txtZip.Text != "Zip")
        {
            ObjPreferncesInfo.Zip = txtZip.Text;
        }
        if (txtName.Text != "Your Name")
        {
            ObjPreferncesInfo.Name = txtName.Text;
        }

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

        DataSet dsPreferences = new DataSet();

        dsPreferences = objPreferencesBL.SaveSubscribe(ObjPreferncesInfo, 1);

        for (int i = 1; i < 6; i++)
        {
            string SelectedMake = string.Empty;
            string SelectedModel = string.Empty;
            string SelectedRange = string.Empty;

            if (i == 1)
            {
                SelectedMake = ddlMakes1.SelectedValue;
                SelectedModel = ddlModels1.SelectedValue;
                SelectedRange = ddlRanges1.SelectedValue;
            }
            else if (i == 2)
            {
                SelectedMake = ddlMakes2.SelectedValue;
                SelectedModel = ddlModels2.SelectedValue;
                SelectedRange = ddlRanges2.SelectedValue;
            }
            else if (i == 3)
            {
                SelectedMake = ddlMakes3.SelectedValue;
                SelectedModel = ddlModels3.SelectedValue;
                SelectedRange = ddlRanges3.SelectedValue;
            }
            else if (i == 4)
            {
                SelectedMake = ddlMakes4.SelectedValue;
                SelectedModel = ddlModels4.SelectedValue;
                SelectedRange = ddlRanges4.SelectedValue;
            }
            else if (i == 5)
            {
                SelectedMake = ddlMakes5.SelectedValue;
                SelectedModel = ddlModels5.SelectedValue;
                SelectedRange = ddlRanges5.SelectedValue;
            }
            if (SelectedMake != "0" && SelectedModel != "0")
            {

                ObjPreferncesItemsInfo.Makeid = SelectedMake;


                ObjPreferncesItemsInfo.ModelID = SelectedModel;

                ObjPreferncesItemsInfo.PriceRange = SelectedRange;

                ObjPreferncesItemsInfo.UserPreferID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();


                HiddenField hdnPreferenceID = (HiddenField)Page.FindControl("hdnPreferenceID" + i);

                ObjPreferncesItemsInfo.PreferenceID = hdnPreferenceID.Value;

                dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, true);
            }
            else
            {

                HiddenField hdnPreferenceID = (HiddenField)Page.FindControl("hdnPreferenceID" + i);

                if (hdnPreferenceID.Value != "")
                {
                    if (SelectedMake != "0" && SelectedModel != "0")
                    {
                        ObjPreferncesItemsInfo.Makeid = SelectedMake;

                        ObjPreferncesItemsInfo.ModelID = SelectedModel;

                        ObjPreferncesItemsInfo.PriceRange = SelectedRange;

                        ObjPreferncesItemsInfo.UserPreferID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();

                        ObjPreferncesItemsInfo.PreferenceID = hdnPreferenceID.Value;

                        dssub = objPreferencesBL.SaveSubScribeItems(ObjPreferncesItemsInfo, false);
                    }
                }
            }
        }

        clsMailFormats format = new clsMailFormats();
        MailMessage msg = new MailMessage();

        msg.From = new MailAddress(CommonVariable.FromInfoMail);


        msg.To.Add(txtEmailAlert.Text);

        //msg.Bcc.Add("shravan@datumglobal.net");

        msg.Subject = "Successfully modified your personalized weekly email alerts - United Car Exchange.";

        msg.IsBodyHtml = true;

        string text = string.Empty;

        string VerifyPreferences = string.Empty;

        string ModifyPreferences = string.Empty;

        string PreferencesID = string.Empty;

        //VerifyPreferences = "www.unitedcarexchange.com/VerifyPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

        //ModifyPreferences = "www.unitedcarexchange.com/EmailPreferences.aspx?Preferce=" + dssub.Tables[0].Rows[0]["ID"].ToString();

        PreferencesID = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();


        text = format.SendEMailPreferencesEdit(dsPreferences.Tables[0].Rows[0]["Name"].ToString(), dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString(), ref text);

        msg.Body = text.ToString();

        SmtpClient smtp = new SmtpClient();

        //smtp.Host = "smtp.gmail.com";
        //smtp.Port = 587;
        //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
        //smtp.EnableSsl = true;
        //smtp.Send(msg);

        smtp.Host = "127.0.0.1";
        smtp.Port = 25;
        smtp.Send(msg);

        lblalert.Text = "Your Preferences Has been Updated according to your selection";


        mpealteruser.Show();

        Page.ClientScript.RegisterStartupScript(typeof(Page), "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");


    }


    private void FillWithin()
    {

        ddlRanges1.Items.Clear();
        ddlRanges2.Items.Clear();
        ddlRanges3.Items.Clear();
        ddlRanges4.Items.Clear();
        ddlRanges5.Items.Clear();


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

        ddlRanges1.Items.Add(lim0);
        ddlRanges2.Items.Add(lim0);
        ddlRanges3.Items.Add(lim0);
        ddlRanges4.Items.Add(lim0);
        ddlRanges5.Items.Add(lim0);


        ddlRanges1.Items.Add(lim);
        ddlRanges1.Items.Add(lim1);
        ddlRanges1.Items.Add(lim2);
        ddlRanges1.Items.Add(lim3);
        ddlRanges1.Items.Add(lim4);
        ddlRanges1.Items.Add(lim5);
        ddlRanges1.Items.Add(lim6);


        ddlRanges2.Items.Add(lim);
        ddlRanges2.Items.Add(lim1);
        ddlRanges2.Items.Add(lim2);
        ddlRanges2.Items.Add(lim3);
        ddlRanges2.Items.Add(lim4);
        ddlRanges2.Items.Add(lim5);
        ddlRanges2.Items.Add(lim6);


        ddlRanges3.Items.Add(lim);
        ddlRanges3.Items.Add(lim1);
        ddlRanges3.Items.Add(lim2);
        ddlRanges3.Items.Add(lim3);
        ddlRanges3.Items.Add(lim4);
        ddlRanges3.Items.Add(lim5);
        ddlRanges3.Items.Add(lim6);

        ddlRanges4.Items.Add(lim);
        ddlRanges4.Items.Add(lim1);
        ddlRanges4.Items.Add(lim2);
        ddlRanges4.Items.Add(lim3);
        ddlRanges4.Items.Add(lim4);
        ddlRanges4.Items.Add(lim5);
        ddlRanges4.Items.Add(lim6);

        ddlRanges5.Items.Add(lim);
        ddlRanges5.Items.Add(lim1);
        ddlRanges5.Items.Add(lim2);
        ddlRanges5.Items.Add(lim3);
        ddlRanges5.Items.Add(lim4);
        ddlRanges5.Items.Add(lim5);
        ddlRanges5.Items.Add(lim6);





    }

    #endregion

    private void GetEmailPreferences(string PreferenceID)
    {
        PreferencesBL objPreferencesBL = new PreferencesBL();

        DataSet dsPreferences = new DataSet();

        dsPreferences = objPreferencesBL.GetEmailPreferences(PreferenceID);

        if (dsPreferences.Tables[0].Rows.Count > 0)
        {

            if (dsPreferences.Tables[0].Rows[0]["isactive"].ToString() == "0")
            {

                lblalert.Text = "Your email address Already Unsubscribed";


                mpealteruser.Show();

            }
            else
            {

                if (dsPreferences.Tables[0].Rows[0]["Zip"].ToString() != "")
                {
                    txtZip.Text = dsPreferences.Tables[0].Rows[0]["Zip"].ToString();
                }
                if (dsPreferences.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    txtName.Text = dsPreferences.Tables[0].Rows[0]["Name"].ToString();
                }

                if (dsPreferences.Tables[0].Rows[0]["Email"].ToString() != "Your Email")
                {
                    txtEmailAlert.Text = dsPreferences.Tables[0].Rows[0]["Email"].ToString();
                }

                if (dsPreferences.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    txtPhoneNo.Text = dsPreferences.Tables[0].Rows[0]["Phone"].ToString();
                }

                hdnUserPrefernceID.Value = dsPreferences.Tables[0].Rows[0]["UserPreferID"].ToString();





                if (dsPreferences.Tables[1].Rows.Count > 0)
                {

                    int k = 1;

                    TotalRowcount.Value = dsPreferences.Tables[1].Rows.Count.ToString();


                    for (int i = 0; i < dsPreferences.Tables[1].Rows.Count; i++)
                    {


                        DropDownList ddlDropddlMake = (DropDownList)Page.FindControl("ddlMakes" + k);
                        DropDownList ddlDropddlModel = (DropDownList)Page.FindControl("ddlModels" + k);
                        DropDownList ddlDropddlRange = (DropDownList)Page.FindControl("ddlRanges" + k);

                        HiddenField hdnPreferenceID = (HiddenField)Page.FindControl("hdnPreferenceID" + k);

                        ddlDropddlRange.SelectedIndex = -1;

                        ddlDropddlMake.SelectedIndex = ddlDropddlMake.Items.IndexOf(ddlDropddlMake.Items.FindByValue(dsPreferences.Tables[1].Rows[i]["Makeid"].ToString()));

                        GetModelsInfo(ddlDropddlMake.SelectedValue, ddlDropddlModel);

                        ddlDropddlModel.SelectedIndex = ddlDropddlModel.Items.IndexOf(ddlDropddlModel.Items.FindByValue(dsPreferences.Tables[1].Rows[i]["ModelID"].ToString()));

                        //ddlDropddlRange.SelectedIndex = ddlDropddlRange.Items.IndexOf(ddlDropddlRange.Items.FindByValue(dsPreferences.Tables[1].Rows[i]["PriceRange"].ToString()));

                        ddlDropddlRange.SelectedIndex = Convert.ToInt32(dsPreferences.Tables[1].Rows[i]["PriceRange"].ToString());

                        hdnPreferenceID.Value = dsPreferences.Tables[1].Rows[i]["PreferenceID"].ToString();


                        k = k + 1;
                    }
                }
                else
                {
                    TotalRowcount.Value = "1";
                }
            }
        }

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }
}
