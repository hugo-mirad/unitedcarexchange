
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
using CarsBL.ESubscrition;

public partial class ESubscription : System.Web.UI.Page
{
    ESubscriptionBL objESubscriptionBL = new ESubscriptionBL();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
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

                Session["SortDirec"] = null;
                GetResults();
                Session.Timeout = 180;
            }
        }
    }
    private void GetResults()
    {
        try
        {
            DataSet dsGetESubData = objESubscriptionBL.GetUserEmailPreferences();
            if (dsGetESubData.Tables[0].Rows.Count > 0)
            {
                lblRes.Text = dsGetESubData.Tables[0].Rows.Count.ToString() + " Records found";
                grdESubInfo.Visible = true;
                grdESubInfo.DataSource = dsGetESubData.Tables[0];
                grdESubInfo.DataBind();
            }
            else
            {
                lblRes.Text = "No records found";
                grdESubInfo.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvr in grdESubInfo.Rows)
            {
                CheckBox chkIssue = (CheckBox)gvr.FindControl("chkIssue");
                HiddenField hdnPreferenceID = (HiddenField)gvr.FindControl("hdnPreferenceID");
                if (chkIssue.Checked == true)
                {
                    DataSet dsgetDataByPreferenceID = objESubscriptionBL.GetDataByPreferenceID(hdnPreferenceID.Value);
                    if (dsgetDataByPreferenceID.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsgetDataByPreferenceID.Tables[0].Rows.Count; i++)
                        {
                            if (dsgetDataByPreferenceID.Tables[0].Rows[i]["Makeid"].ToString() != "0")
                            {
                                string EName = dsgetDataByPreferenceID.Tables[0].Rows[i]["Name"].ToString();
                                string EMake = dsgetDataByPreferenceID.Tables[0].Rows[i]["make"].ToString();
                                string EModel = dsgetDataByPreferenceID.Tables[0].Rows[i]["model"].ToString();
                                string EPrice = dsgetDataByPreferenceID.Tables[0].Rows[i]["PriceRange"].ToString();
                                DataSet dsPrefercars = objESubscriptionBL.GetCarSubscription_Ads(dsgetDataByPreferenceID.Tables[0].Rows[i]["Makeid"].ToString(), dsgetDataByPreferenceID.Tables[0].Rows[i]["ModelID"].ToString(), dsgetDataByPreferenceID.Tables[0].Rows[i]["PriceRange"].ToString());
                                DataTable dtPreferTable = dsPrefercars.Tables[0];
                                clsMailFormats format = new clsMailFormats();
                                MailMessage msg = new MailMessage();
                                msg.From = new MailAddress("info@unitedcarexchange.com");
                                msg.To.Add(dsgetDataByPreferenceID.Tables[0].Rows[i]["Email"].ToString());
                                //msg.To.Add("dinesh@datumglobal.net");
                                msg.Subject = "10 Used cars " + EMake.ToString() + " " + EModel.ToString();
                                msg.IsBodyHtml = true;
                                string text = string.Empty;
                                text = format.SendSubscriptionMail(ref text, dtPreferTable, EName, EMake, EModel, EPrice);
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
                            }
                        }
                    }
                }
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "Email(s) successfully send";
            }

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ESubscription.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
