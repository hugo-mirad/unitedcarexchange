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
using CarsBL.Transactions;
using System.Net.Mail;

public partial class PaymentMode : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    BankDetailsBL objBankDetailsBL = new BankDetailsBL();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RegUserName"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {



                if (Session["PackageID"] != null && Session["PackgeName"] != null && Session["PackgePrice"] != null)
                {
                    lblpackagename2.Text = Session["PackgeName"].ToString();
                    lblpckgprice.Text = Session["PackgePrice"].ToString();

                    lblSname.Text = Session["sName"].ToString();
                    lblSmail.Text = Session["sEmail"].ToString();
                    lblSphone.Text = Session["sPhone"].ToString();

                    lblSyear.Text = Session["SelYear"].ToString();
                    lblSmake.Text = Session["SelMake"].ToString();
                    lblSmodel.Text = Session["SelModel"].ToString();
                    lblSprice.Text = Session["SelPrice"].ToString();

                    //lblSphotos.Text = Session["SelUploadedImg"].ToString() + "/" + Session["MaxPhotos"].ToString(); ;
                    lblSphotos.Text =  Session["MaxPhotos"].ToString(); ;

                }
                else
                {
                    Response.Redirect("SellRegi.aspx");

                }


                GeneralFunc.SaveSiteVisit();
                GeneralFunc.SetPageDefaults(Page);
                Session["CurrentPage"] = "Payment Mode";
                Session["PageName"] = "";
                Session["CurrentPageConfig"] = null;


                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";



                //scrptmgr.Services.Add(objServiceReference);
                //scrptmgr.Scripts.Add(objScriptReference);
                //DataSet dsYears = objBankDetailsBL.USP_GetNext12years();

                //fillYears(dsYears);

                //if (Session["RegName"].ToString().Length > 10)
                //{
                //    lblHeadName.Text = "Welcome " + Session["RegName"].ToString().Substring(0, 10) + " ";
                //}
                //else
                //{
                //    lblHeadName.Text = "Welcome " + Session["RegName"].ToString() + " ";
                //}

                //dsDropDown = objdropdownBL.Usp_Get_DropDown();
                //Session["DsDropDown"] = dsDropDown;
                //FillStates();
                //int UID = Convert.ToInt32(Session["RegUSER_ID"].ToString());
                //DataSet dsGetIDs = objdropdownBL.USP_GetIdsByUID(UID);
                //if (dsGetIDs.Tables.Count > 0)
                //{
                //    if (dsGetIDs.Tables[0].Rows.Count > 0)
                //    {
                //        Session["PaymentID"] = dsGetIDs.Tables[0].Rows[0]["paymentID"].ToString();
                //        Session["isActive"] = dsGetIDs.Tables[0].Rows[0]["isActive"].ToString();

                //    }
                //}

                /////http://www.mobicarz.com/PaymentSucces.aspx?
                /////tx=09X07842XS736843C&st=Completed&
                /////amt=0.10&
                /////cc=USD&cm=&
                /////item_number=


                //if ((Session["isActive"].ToString() != "True") && (Session["PackageID"].ToString() == "1"))
                //{
                //    int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                //    int UserPackID = Convert.ToInt32(Session["RegUserPackID"].ToString());
                //    bool bnew = objBankDetailsBL.USP_UpdateInfoForFreePackage(PostingID, UserPackID, UID);
                //    string LoginPassword = Session["RegPassword"].ToString();
                //    string LoginName = Session["RegUserName"].ToString();
                //    SendRegisterMail(LoginName, LoginPassword);
                //    mdepAlertExists.Show();
                //    lblErrorExists.Visible = true;
                //    lblErrorExists.Text = "No payment details are required as you have selected a free package. Please Click Next to continue.";
                //}

                //else if (Session["isActive"].ToString() == "True")
                //{
                //    Response.Redirect("account.aspx");
                //}

            }
        }
    }

    private void fillYears(DataSet dsYears)
    {
        try
        {
            //CCExpiresYear.DataSource = dsYears.Tables[0];
            //CCExpiresYear.DataTextField = "YearNum";
            //CCExpiresYear.DataValueField = "YearValue";
            //CCExpiresYear.DataBind();
            //CCExpiresYear.Items.Insert(0, new ListItem("Select Year", "0"));
        }
        catch (Exception ex)
        {
        }
    }


    
    private void FillStates()
    {
        try
        {
            //ddlBillState.DataSource = dsDropDown.Tables[1];
            //ddlBillState.DataTextField = "State_Code";
            //ddlBillState.DataValueField = "State_ID";
            //ddlBillState.DataBind();
            //ddlBillState.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        int PackageID = Convert.ToInt32(Session["PackageID"].ToString());
        int UserID = Convert.ToInt32(Session["RegUSER_ID"].ToString());
        //SavePmntDetails();
        SavePmntDetails(PackageID, UserID);
        string LoginPassword = Session["RegPassword"].ToString();
        string LoginName = Session["RegUserName"].ToString();
        SendRegisterMail(LoginName, LoginPassword);
        mpealteruser.Show();
        

    }

    private void SavePmntDetails(int PackageID, int UserID)
    {
        try
        {
            PmntDetailsinfo objPmntDetailsinfo = new PmntDetailsinfo();
            objPmntDetailsinfo.PmntType = 1;
            
        }
        catch (Exception ex)
        {

        }

    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            //Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void BtnCls_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("account.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            //Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnExustCls_Click(object sender, EventArgs e)
    {
        try
        {
            mdepAlertExists.Hide();
            mpealteruser.Show();
            //  lblErr.Visible = true;
            //lblErr.Text = "Congratulations<br />You are one step closer to selling your car.<br />You will recieve mail from our's shortly. Mean while you can login check details of your and edit any information required including uploading new photographs."; Response.Redirect("account.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        try
        {
            mdepAlertExists.Hide();
            mpealteruser.Show();
            // lblErr.Visible = true;
            //  lblErr.Text = "Congratulations<br />You are one step closer to selling your car.<br />You will recieve mail from our's shortly. Mean while you can login check details of your and edit any information required including uploading new photographs.";
        }
        catch (Exception ex)
        {
        }
    }
    private void SendRegisterMail(string LoginName, string LoginPassword)
    {
        try
        {
            string UserDisName = Session["RegName"].ToString();
            string UserLoginID = Session["RegLogUserID"].ToString();
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(CommonVariable.FromInfoMail);
            msg.To.Add(LoginName);
            msg.Bcc.Add(CommonVariable.ArchieveMail);
            msg.Subject = "Registration details from MobiCarz";
            msg.IsBodyHtml = true;
            string text = string.Empty;
            text = format.SendRegistrationdetails(UserLoginID, LoginPassword, UserDisName, ref text);
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
        catch (Exception ex)
        {
        }
    }
    protected void btnPay_Click(object sender, EventArgs e)
    {

    }
}
