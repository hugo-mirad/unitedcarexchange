
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
public partial class IntroMail : System.Web.UI.Page
{
    SmartzIntroMail objSmartzIntroBL = new SmartzIntroMail();
    SmartzIntroMailInfo objSmartzIntroInfo = new SmartzIntroMailInfo();
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
            DataSet dsGetData = objSmartzIntroBL.USP_GetIntroMailDetailsFor15Days();
            Session["IntroDetails"] = dsGetData;
            if (dsGetData.Tables.Count > 0)
            {
                if (dsGetData.Tables[0].Rows.Count > 0)
                {
                    lblRes.Visible = false;
                    grdIntroInfo.Visible = true;
                    grdIntroInfo.DataSource = dsGetData.Tables[0];
                    grdIntroInfo.DataBind();
                }
                else
                {
                    lblRes.Text = "No records found";
                    grdIntroInfo.Visible = false;
                    lblRes.Visible = true;
                }
            }
            else
            {
                lblRes.Text = "No records found";
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            GetResults();
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdbtnCarsDealer.Checked == true)
            {
                Session["IntroUserType"] = "Dealer";
                lblHeaderText.Text = "Dealer Intromail";
                ddlLanguage.Enabled = false;
            }
            else
            {
                Session["IntroUserType"] = "Single";
                lblHeaderText.Text = "Single User Intromail";
                ddlLanguage.Enabled = true;
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string StrRep = txtEmailAddress.Text.Replace("\r", "");
            string[] str12 = StrRep.Split('\n');
            ArrayList str = new ArrayList();
            foreach (string s in str12)
                str.Add(s);

            ArrayList strMatch = new ArrayList();



            var sList = new ArrayList();

            for (int i = 0; i < str.Count; i++)
            {
                if (sList.Contains(str[i].ToString().Trim()) == false)
                {
                    sList.Add(str[i].ToString().Trim());
                }
            }


            for (int c = 0; c < sList.Count; c++)
            {
                if (sList[c].ToString().Trim() == "")
                {
                    sList.RemoveAt(c);
                }
            }
            ArrayList sNewlist = new ArrayList();
            for (int d = 0; d < sList.Count; d++)
            {
                string[] strNew = sList[d].ToString().Split(' ');

                if (strNew.Length > 0)
                {
                    string sattach = string.Empty;
                    for (int s = 0; s < strNew.Length; s++)
                    {
                        if (s == 0)
                        {
                            sattach = strNew[s].Trim();
                        }
                        else
                        {
                            sattach = sattach + " " + strNew[s].Trim();
                        }
                    }
                    sNewlist.Add(sattach);
                }
                else
                {
                    sNewlist.Add(sList[d]);
                }
            }

            str = sNewlist;
            for (int i = 0; i < str.Count; i++)
            {
                string Username = str[i].ToString();
                string Agentname = objGeneralFunc.ToProper(txtAgentName.Text);
                SendIntromail(Agentname, Username);
            }
            Session.Timeout = 180;
            mpealteruser.Show();
            lblErr.Visible = true;
            lblErr.Text = "Email(s) successfully send";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SendIntromail(string Agentname, string Username)
    {
        try
        {
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("carsales@unitedcarexchange.com");
            msg.To.Add(Username);
            msg.IsBodyHtml = true;
            string text = string.Empty;
            string Language = string.Empty;
            if (ddlUserType.SelectedItem.Value == "2")
            {
                Language = "Eng(D)";
                msg.Subject = "Thank You For Your Interest In United Car Exchange";
                text = format.SendIntromaildetailsForDealers(Agentname, ref text);
                msg.Attachments.Add(new Attachment(Server.MapPath("~/MailTemplate/United Car Exchange -  Dealership Compass Brochure v2.pdf")));
                msg.From = new MailAddress("Dealerinfo@unitedcarexchange.com");
            }
            else
            {
                if (Convert.ToInt32(ddlLanguage.SelectedItem.Value) == 2)
                {
                    Language = "Esp";
                    msg.Subject = "Gracias por su interés en United Car Exchange";
                    text = format.SendSpanishIntromaildetails(Agentname, ref text);
                }
                else
                {
                    Language = "Eng";
                    msg.Subject = "Thank You For Your Interest In United Car Exchange";
                    text = format.SendIntromaildetails(Agentname, ref text);
                }
            }

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
            bool bnew = objSmartzIntroBL.USP_SaveIntroMailDetails(Agentname, Username, Language);
        }
        catch (Exception ex)
        {
            //throw ex;
            Response.Redirect("EmailServerError.aspx");
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("IntroMail.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["IntroDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SentDateTime";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkDateSort.Text = "Date &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkDateSort.Text = "Date &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkDateSort.Text = "Date &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkDateSort.Text = "Date &#8659";
            }

            lnkMarketSpecialist.Text = "Market Specialist &darr; &uarr;";
            lnkCustomerEmail.Text = "Customer Email &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";
            lnkLanguage.Text = "Language &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkMarketSpecialist_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["IntroDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "MarketSpecialist";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkMarketSpecialist.Text = "Market Specialist &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkMarketSpecialist.Text = "Market Specialist &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkMarketSpecialist.Text = "Market Specialist &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkMarketSpecialist.Text = "Market Specialist &#8659";
            }

            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkCustomerEmail.Text = "Customer Email &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";
            lnkLanguage.Text = "Language &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkCustomerEmail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["IntroDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];

            string SortExp = "CustomerEmail";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkCustomerEmail.Text = "Customer Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkCustomerEmail.Text = "Customer Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkCustomerEmail.Text = "Customer Email &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkCustomerEmail.Text = "Customer Email &#8659";
            }

            lnkMarketSpecialist.Text = "Market Specialist &darr; &uarr;";
            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";
            lnkLanguage.Text = "Language &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkLanguage_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["IntroDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];

            string SortExp = "Language";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkLanguage.Text = "Language &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkLanguage.Text = "Language &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkLanguage.Text = "Language &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkLanguage.Text = "Language &#8659";
            }

            lnkMarketSpecialist.Text = "Market Specialist &darr; &uarr;";
            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";
            lnkCustomerEmail.Text = "Customer Email &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["IntroDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "StatusName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkStatus.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkStatus.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkStatus.Text = "Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkStatus.Text = "Status &#8659";
            }

            lnkMarketSpecialist.Text = "Market Specialist &darr; &uarr;";
            lnkCustomerEmail.Text = "Customer Email &darr; &uarr;";
            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkLanguage.Text = "Language &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
