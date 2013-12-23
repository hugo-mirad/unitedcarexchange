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
using CarsBL.RvTransactions;
using CarsInfo.RvInfo;
using CarsBL.CentralDBTransactions;
using Word;
using System.Text;
using WordApplication;
using System.IO;


public partial class ChargebackProcess : System.Web.UI.Page
{
    private CCWordApp test;
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
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
                Session["CBClaimsCustID"] = null;
                if ((Session["CBViewNoticeID"] != null) || (Session["CBViewNoticeID"] != ""))
                {
                    int NoticeID = Convert.ToInt32(Session["CBViewNoticeID"].ToString());
                    Session["CBProcessNoticeID"] = NoticeID;
                    DataSet dsNoticeData = objdropdownBL.GetNoticeDetailsByNoticeIDForEdit(NoticeID);
                    if (dsNoticeData.Tables.Count > 0)
                    {
                        if (dsNoticeData.Tables[0].Rows.Count > 0)
                        {
                            lblNoticeID.Text = dsNoticeData.Tables[0].Rows[0]["NoticeID"].ToString();
                            lblPopNoticeID.Text = dsNoticeData.Tables[0].Rows[0]["NoticeID"].ToString();
                            lblPopNoticeType.Text = dsNoticeData.Tables[0].Rows[0]["NoticeTypeName"].ToString();
                            lblNoticeType.Text = dsNoticeData.Tables[0].Rows[0]["NoticeTypeName"].ToString();
                            if (dsNoticeData.Tables[0].Rows[0]["NoticeDate"].ToString() != "")
                            {
                                DateTime Dt = Convert.ToDateTime(dsNoticeData.Tables[0].Rows[0]["NoticeDate"].ToString());
                                if (Dt.ToString("MM/dd/yyyy") != "1/1/1900")
                                {
                                    lblNoticeDate.Text = Dt.ToString("MM/dd/yyyy");
                                    lblPopNoticeDt.Text = Dt.ToString("MM/dd/yyyy");
                                }
                            }
                            lblCaseNumber.Text = dsNoticeData.Tables[0].Rows[0]["CaseNumber"].ToString();
                            lblPopCaseNum.Text = dsNoticeData.Tables[0].Rows[0]["CaseNumber"].ToString();
                            if (dsNoticeData.Tables[0].Rows[0]["ReplyByDt"].ToString() != "")
                            {
                                DateTime Dt = Convert.ToDateTime(dsNoticeData.Tables[0].Rows[0]["ReplyByDt"].ToString());
                                if (Dt.ToString("MM/dd/yyyy") != "1/1/1900")
                                {
                                    lblReplyByDt.Text = Dt.ToString("MM/dd/yyyy");
                                    lblPopReplyByDt.Text = Dt.ToString("MM/dd/yyyy");
                                }
                            }
                            if (dsNoticeData.Tables[0].Rows[0]["ReplySentDt"].ToString() != "")
                            {
                                DateTime Dt = Convert.ToDateTime(dsNoticeData.Tables[0].Rows[0]["ReplySentDt"].ToString());
                                if (Dt.ToString("MM/dd/yyyy") != "1/1/1900")
                                {
                                    lblRepliedDt.Text = Dt.ToString("MM/dd/yyyy");
                                    lblPopReplyDt.Text = Dt.ToString("MM/dd/yyyy");
                                }
                            }
                            if (dsNoticeData.Tables[0].Rows[0]["DisputeAmount"].ToString() != "")
                            {
                                Double PackCost = new Double();
                                PackCost = Convert.ToDouble(dsNoticeData.Tables[0].Rows[0]["DisputeAmount"].ToString());
                                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                                lblDisputeAmt.Text = PackAmount;
                                lblpopAmt.Text = PackAmount;
                            }
                            lblStatus.Text = dsNoticeData.Tables[0].Rows[0]["NoticeStatusName"].ToString();
                            lblPopStatus.Text = dsNoticeData.Tables[0].Rows[0]["NoticeStatusName"].ToString();
                            Session["CBEditStatusName"] = dsNoticeData.Tables[0].Rows[0]["NoticeStatusName"].ToString();
                            Session["CBEditStatusID"] = dsNoticeData.Tables[0].Rows[0]["NoticeStatusID"].ToString();
                            lblPrevNoticeID.Text = dsNoticeData.Tables[0].Rows[0]["PrevNoticeID"].ToString();
                            lblPopPrevNoticeID.Text = dsNoticeData.Tables[0].Rows[0]["PrevNoticeID"].ToString();
                            lblPopCBNotes.Text = dsNoticeData.Tables[0].Rows[0]["Notes"].ToString();
                            lblPopreplyMethod.Text = dsNoticeData.Tables[0].Rows[0]["ReplyMethodName"].ToString();
                            lblPopReplyEmail.Text = dsNoticeData.Tables[0].Rows[0]["ReplyEmail"].ToString();
                            lblPopreplyFaxNum.Text = dsNoticeData.Tables[0].Rows[0]["ReplyFaxNumber"].ToString();
                            lblPopReplyAddress.Text = dsNoticeData.Tables[0].Rows[0]["ReplyAddress"].ToString();
                            lblPopReplyCity.Text = dsNoticeData.Tables[0].Rows[0]["ReplyCity"].ToString();
                            lblPopreplyZip.Text = dsNoticeData.Tables[0].Rows[0]["ReplyZip"].ToString();
                            lblPopreplyState.Text = dsNoticeData.Tables[0].Rows[0]["State_Code"].ToString();
                            if (dsNoticeData.Tables[2].Rows.Count > 0)
                            {
                                lnkbtnNoticeCopy.Enabled = true;
                                imgNoticeCopy.ImageUrl = "http://smartz.unitedcarexchange.com/" + dsNoticeData.Tables[2].Rows[0]["FilePath"].ToString();
                            }
                            if (dsNoticeData.Tables[1].Rows.Count > 0)
                            {
                                string strReasons = "";
                                for (int i = 0; i < dsNoticeData.Tables[1].Rows.Count; i++)
                                {
                                    if (dsNoticeData.Tables[1].Rows[i]["IsActive"].ToString() == "1")
                                    {
                                        if (strReasons == "")
                                        {
                                            strReasons = dsNoticeData.Tables[1].Rows[i]["NoticeReasonName"].ToString();
                                        }
                                        else
                                        {
                                            strReasons = strReasons + ", " + dsNoticeData.Tables[1].Rows[i]["NoticeReasonName"].ToString();
                                        }
                                    }
                                }
                                lblReasons.Text = strReasons;
                                lblPopReasons.Text = strReasons;
                            }
                            if (dsNoticeData.Tables[0].Rows[0]["CustID"].ToString() != "")
                            {
                                Session["CBClaimsCustID"] = dsNoticeData.Tables[0].Rows[0]["CustID"].ToString();
                                DataSet dsUserData = new DataSet();
                                dsUserData = objdropdownBL.GetCBNoticeUserByUID(Convert.ToInt32(dsNoticeData.Tables[0].Rows[0]["CustID"].ToString()));
                                if (dsUserData.Tables.Count > 0)
                                {
                                    if (dsUserData.Tables[0].Rows.Count > 0)
                                    {
                                        lnkbtnCustomerData.Enabled = true;
                                        divResults.Style["display"] = "block";
                                        grdIntroInfo.Visible = true;
                                        lblResult.Visible = false;
                                        grdIntroInfo.DataSource = dsUserData.Tables[0];
                                        grdIntroInfo.DataBind();
                                    }
                                    else
                                    {
                                        lnkbtnCustomerData.Enabled = false;
                                    }
                                }
                                else
                                {
                                    lnkbtnCustomerData.Enabled = false;
                                }
                                DataSet dsPackageInfo = objdropdownBL.GetPackageDetailsByUID(Convert.ToInt32(dsNoticeData.Tables[0].Rows[0]["CustID"].ToString()));
                                if (dsPackageInfo.Tables.Count > 0)
                                {
                                    if (dsPackageInfo.Tables[0].Rows.Count > 0)
                                    {
                                        grdPackagDetails.Visible = true;
                                        grdPackagDetails.DataSource = dsPackageInfo.Tables[0];
                                        grdPackagDetails.DataBind();
                                        lblPopPayData.Visible = false;
                                        lnkbtnPaymentData.Enabled = true;
                                    }
                                    else
                                    {
                                        lnkbtnPaymentData.Enabled = false;
                                    }
                                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
                                    {
                                        grdCarDetails.Visible = true;
                                        grdCarDetails.DataSource = dsPackageInfo.Tables[1];
                                        grdCarDetails.DataBind();
                                        lblErrVehicle.Visible = false;
                                        lnkbtnVehicleData.Enabled = true;
                                    }
                                    else
                                    {
                                        lnkbtnVehicleData.Enabled = false;
                                    }
                                }
                                else
                                {
                                    lnkbtnPaymentData.Enabled = false;
                                    lnkbtnVehicleData.Enabled = false;
                                }
                            }
                            else
                            {
                                lnkbtnCustomerData.Enabled = false;
                                lnkbtnPaymentData.Enabled = false;
                                lnkbtnVehicleData.Enabled = false;
                            }
                        }
                    }
                }
            }
        }
    }
    protected void grdPackagDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnPackDescrip = (HiddenField)e.Row.FindControl("hdnPackDescrip");
                HiddenField hdnUserPackID = (HiddenField)e.Row.FindControl("hdnUserPackID");
                //Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                Label lnkbtnPackage = (Label)e.Row.FindControl("lnkbtnPackage");
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnUserPackID.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackDescrip.Value.ToString();
                lnkbtnPackage.Text = PackName + "($" + PackAmount + ")";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdCarDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");
                HiddenField hdnPackDescription = (HiddenField)e.Row.FindControl("hdnPackDescription");
                HiddenField hdnPackUserPackID = (HiddenField)e.Row.FindControl("hdnPackUserPackID");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                HiddenField hdncarPrice = (HiddenField)e.Row.FindControl("hdncarPrice");
                Label lblPrice = (Label)e.Row.FindControl("lblPrice");

                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnPackUserPackID.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackDescription.Value.ToString();
                lblPackage.Text = PackName + "($" + PackAmount + ")";
                if (hdncarPrice.Value != "")
                {
                    Double CarP = new Double();
                    CarP = Convert.ToDouble(hdncarPrice.Value.ToString());
                    lblPrice.Text = string.Format("{0:0.00}", CarP).ToString();
                }
                if (hdnStatus.Value.ToString() == "True")
                {
                    //lblStatus.Text = "Active";
                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else
                {
                    //lblStatus.Text = "Inactive";
                    ImgStatus.ImageUrl = "~/images/red_x.png";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnNoticeCopy_Click(object sender, EventArgs e)
    {
        try
        {
            mpeViewNoticeCopy.Show();
            imgNoticeCopy.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnNoticeData_Click(object sender, EventArgs e)
    {
        try
        {
            MdepNoticeData.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnCustomerData_Click(object sender, EventArgs e)
    {
        try
        {
            MdepCustDetails.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnPaymentData_Click(object sender, EventArgs e)
    {
        try
        {
            mdepPayData.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnVehicleData_Click(object sender, EventArgs e)
    {
        try
        {
            mdepCarDetails.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnresponseInfo_Click(object sender, EventArgs e)
    {
        try
        {
            mdepReplyInfo.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnUpdateNotice_Click(object sender, EventArgs e)
    {
        try
        {
            FillStatus();
            ListItem li = new ListItem();
            li.Text = Session["CBEditStatusName"].ToString();
            li.Value = Session["CBEditStatusID"].ToString();
            ddlPopStatus.SelectedIndex = ddlPopStatus.Items.IndexOf(li);
            mpeAskNewSale.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillStatus()
    {
        try
        {
            DataSet dsStatus = new DataSet();
            if ((Session["CBNotSts"] == null) || (Session["CBNotSts"].ToString() == ""))
            {
                dsStatus = objdropdownBL.GetSmartzNoticeStatus();
            }
            else
            {
                dsStatus = Session["CBNotSts"] as DataSet;
            }
            ddlPopStatus.DataSource = dsStatus.Tables[0];
            ddlPopStatus.DataTextField = "NoticeStatusName";
            ddlPopStatus.DataValueField = "NoticeStatusID";
            ddlPopStatus.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnPopNoticeStatusUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int NoticeID = Convert.ToInt32(Session["CBProcessNoticeID"]);
            int NoticeStatusID = Convert.ToInt32(ddlPopStatus.SelectedItem.Value);
            DataSet dsUpNoticeSt = objdropdownBL.SmartzUpdateCBNoticeStatus(NoticeID, NoticeStatusID);
            Session["CBEditStatusName"] = dsUpNoticeSt.Tables[0].Rows[0]["NoticeStatusName"].ToString();
            Session["CBEditStatusID"] = dsUpNoticeSt.Tables[0].Rows[0]["NoticeStatusID"].ToString();
            lblStatus.Text = dsUpNoticeSt.Tables[0].Rows[0]["NoticeStatusName"].ToString();
            lblPopStatus.Text = dsUpNoticeSt.Tables[0].Rows[0]["NoticeStatusName"].ToString();
            mpeAskNewSale.Hide();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnAuthorizationLetter_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsDate = objdropdownBL.GetDatetime();
            DateTime ToDayDate = Convert.ToDateTime(dsDate.Tables[0].Rows[0]["Datetime"].ToString());
            if ((Session["CBClaimsCustID"] == null) || (Session["CBClaimsCustID"].ToString() == ""))
            {
                //mdepCBAlert.Show();
                //lblCBAlertMsg.Visible = true;
                //lblCBAlertMsg.Text = "User information not available for this notice";
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
                clsMailFormats format = new clsMailFormats();
                string text = string.Empty;
                string strPath2 = string.Empty;
                CCWordApp testNew = new CCWordApp();
                string line = string.Empty;
                string strPath = string.Empty;
                string strPath1 = string.Empty;
                //DataSet dsInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter();
                strPath = HttpContext.Current.Server.MapPath("~/MailTemplate/") + "AuthorizeLetter.docx";
                strPath2 = HttpContext.Current.Server.MapPath("~/NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/") + "AuthorizeLetter.doc";

                testNew.Open(strPath);
                string str = testNew.GetContent();
                string NewLine = string.Empty;
                line = str;

                if (line.Contains("#CustName#"))
                {
                    line = line.Replace("#CustName#", "");
                }
                if (line.Contains("#VoiceFile#"))
                {
                    line = line.Replace("#VoiceFile#", "");
                }
                if (line.Contains("#Recorddate#"))
                {
                    line = line.Replace("#Recorddate#", "");
                }
                if (line.Contains("#AgentName#"))
                {
                    line = line.Replace("#AgentName#", Session[Constants.NAME].ToString());
                }
                if (line.Contains("#TodayDate#"))
                {
                    line = line.Replace("#TodayDate#", ToDayDate.ToString("MM/dd/yyyy"));
                }
                if (line.Contains("#CustName#"))
                {
                    line = line.Replace("#CustName#", "");
                }
                if (line.Contains("#Phone#"))
                {
                    line = line.Replace("#Phone#", "");
                }
                if (line.Contains("#Address#"))
                {
                    line = line.Replace("#Address#", "");
                }
                if (line.Contains("#VehiclesCount#"))
                {
                    line = line.Replace("#VehiclesCount#", "0");
                }
                if (line.Contains("#Amount#"))
                {
                    line = line.Replace("#Amount#", "0.00");
                }
                if (line.Contains("#Payment#"))
                {
                    line = line.Replace("#Payment#", "");
                }
                if (line.Contains("xxxxxxxxxxxx1015"))
                {
                    line = line.Replace("xxxxxxxxxxxx1015", "");
                }
                if (line.Contains("XX/XX"))
                {
                    line = line.Replace("XX/XX", "");
                }
                if (line.Contains("CVX"))
                {
                    line = line.Replace("CVX", "");
                }
                if (line.Contains("#CustEmail#"))
                {
                    line = line.Replace("#CustEmail#", "");
                }
                //address city, state zip
                testNew.Quit();
                txtgenMailText.Text = line;
                mdepAuthorizeLetter.Show();
            }
            else
            {
                Session.Timeout = 180;
                clsMailFormats format = new clsMailFormats();
                string text = string.Empty;
                string strPath2 = string.Empty;
                CCWordApp testNew = new CCWordApp();
                string line = string.Empty;
                string strPath = string.Empty;
                string strPath1 = string.Empty;
                //DataSet dsInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter();
                strPath = HttpContext.Current.Server.MapPath("~/MailTemplate/") + "AuthorizeLetter.docx";
                strPath2 = HttpContext.Current.Server.MapPath("~/NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/") + "AuthorizeLetter.doc";
                if (System.IO.File.Exists(strPath2))
                {
                    testNew.Open(strPath2);
                    string str = testNew.GetContent();
                    string NewLine = string.Empty;
                    line = str;
                    testNew.Quit();
                    txtgenMailText.Text = line;
                }
                else
                {
                    DataSet dsPackageInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter(Convert.ToInt32(Session["CBClaimsCustID"].ToString()));
                    if (dsPackageInfo.Tables.Count > 0)
                    {
                        if (dsPackageInfo.Tables[0].Rows.Count > 0)
                        {
                            testNew.Open(strPath);
                            string str = testNew.GetContent();
                            string NewLine = string.Empty;
                            line = str;
                            string recordDate = string.Empty;
                            if (dsPackageInfo.Tables[0].Rows[0]["PayDate"].ToString() != "")
                            {
                                DateTime dtRD = Convert.ToDateTime(dsPackageInfo.Tables[0].Rows[0]["PayDate"].ToString());
                                recordDate = dtRD.ToString("MM/dd/yyyy");
                            }
                            else
                            {
                                recordDate = "";
                            }
                            if (line.Contains("#CustName#"))
                            {
                                line = line.Replace("#CustName#", dsPackageInfo.Tables[0].Rows[0]["Name"].ToString());
                            }
                            if (line.Contains("#VoiceFile#"))
                            {
                                line = line.Replace("#VoiceFile#", dsPackageInfo.Tables[0].Rows[0]["VoiceRecord"].ToString());
                            }
                            if (line.Contains("#Recorddate#"))
                            {
                                line = line.Replace("#Recorddate#", recordDate);
                            }
                            if (line.Contains("#AgentName#"))
                            {
                                line = line.Replace("#AgentName#", Session[Constants.NAME].ToString());
                            }
                            if (line.Contains("#TodayDate#"))
                            {
                                line = line.Replace("#TodayDate#", ToDayDate.ToString("MM/dd/yyyy"));
                            }
                            if (line.Contains("#Phone#"))
                            {
                                line = line.Replace("#Phone#", dsPackageInfo.Tables[0].Rows[0]["phoneNumber"].ToString());
                            }

                            string Address = dsPackageInfo.Tables[0].Rows[0]["Address"].ToString();
                            string City = dsPackageInfo.Tables[0].Rows[0]["City"].ToString();
                            string State = dsPackageInfo.Tables[0].Rows[0]["State_Code"].ToString();
                            string Zip = dsPackageInfo.Tables[0].Rows[0]["Zip"].ToString();
                            string FullAddress = string.Empty;
                            FullAddress = Address;
                            if (FullAddress != "")
                            {
                                FullAddress = FullAddress + " " + City;
                            }
                            else
                            {
                                FullAddress = City;
                            }
                            if (FullAddress != "")
                            {
                                FullAddress = FullAddress + ", " + State;
                            }
                            else
                            {
                                FullAddress = State;
                            }
                            if (FullAddress != "")
                            {
                                FullAddress = FullAddress + " " + Zip;
                            }
                            else
                            {
                                FullAddress = Zip;
                            }
                            if (line.Contains("#Address#"))
                            {
                                line = line.Replace("#Address#", FullAddress);
                            }
                            if (line.Contains("#VehiclesCount#"))
                            {
                                line = line.Replace("#VehiclesCount#", dsPackageInfo.Tables[1].Rows.Count.ToString());
                            }
                            if (line.Contains("#Amount#"))
                            {
                                line = line.Replace("#Amount#", string.Format("{0:0.00}", Convert.ToDouble(dsPackageInfo.Tables[0].Rows[0]["Price"].ToString())));
                            }
                            if (line.Contains("#Payment#"))
                            {
                                line = line.Replace("#Payment#", dsPackageInfo.Tables[0].Rows[0]["cardType"].ToString());
                            }
                            string CardNum = dsPackageInfo.Tables[0].Rows[0]["cardNumber"].ToString();
                            if (CardNum.Length > 0)
                            {
                                CardNum = CardNum.Substring(Convert.ToInt32(CardNum.Length - 4), 4);
                                CardNum = "xxxxxxxxxxxx" + CardNum.ToString();
                            }
                            else
                            {
                                CardNum = "xxxxxxxxxxxxxxxx";
                            }
                            if (line.Contains("xxxxxxxxxxxx1015"))
                            {
                                line = line.Replace("xxxxxxxxxxxx1015", CardNum);
                            }

                            string EXpDate = dsPackageInfo.Tables[0].Rows[0]["cardExpDt"].ToString();
                            string expirtdt = string.Empty;
                            if (EXpDate != "")
                            {
                                string[] EXpDt = EXpDate.Split(new char[] { '/' });
                                expirtdt = EXpDt[0].ToString() + "/" + "20" + EXpDt[1].ToString();
                            }
                            else
                            {
                                expirtdt = EXpDate;
                            }
                            if (line.Contains("XX/XX"))
                            {
                                line = line.Replace("XX/XX", expirtdt);
                            }
                            if (line.Contains("CVX"))
                            {
                                line = line.Replace("CVX", dsPackageInfo.Tables[0].Rows[0]["cardCode"].ToString());
                            }
                            if (line.Contains("#CustEmail#"))
                            {
                                line = line.Replace("#CustEmail#", dsPackageInfo.Tables[0].Rows[0]["UserName"].ToString());
                            }
                            //test.SaveAs(strPath2);
                            testNew.Quit();
                        }
                        else
                        {
                            testNew.Open(strPath);
                            string str = testNew.GetContent();
                            string NewLine = string.Empty;
                            line = str;

                            if (line.Contains("#CustName#"))
                            {
                                line = line.Replace("#CustName#", "");
                            }
                            if (line.Contains("#VoiceFile#"))
                            {
                                line = line.Replace("#VoiceFile#", "");
                            }
                            if (line.Contains("#Recorddate#"))
                            {
                                line = line.Replace("#Recorddate#", "");
                            }
                            if (line.Contains("#AgentName#"))
                            {
                                line = line.Replace("#AgentName#", Session[Constants.NAME].ToString());
                            }
                            if (line.Contains("#TodayDate#"))
                            {
                                line = line.Replace("#TodayDate#", ToDayDate.ToString("MM/dd/yyyy"));
                            }
                            if (line.Contains("#CustName#"))
                            {
                                line = line.Replace("#CustName#", "");
                            }
                            if (line.Contains("#Phone#"))
                            {
                                line = line.Replace("#Phone#", "");
                            }
                            if (line.Contains("#Address#"))
                            {
                                line = line.Replace("#Address#", "");
                            }
                            if (line.Contains("#VehiclesCount#"))
                            {
                                line = line.Replace("#VehiclesCount#", "0");
                            }
                            if (line.Contains("#Amount#"))
                            {
                                line = line.Replace("#Amount#", "0.00");
                            }
                            if (line.Contains("#Payment#"))
                            {
                                line = line.Replace("#Payment#", "");
                            }
                            if (line.Contains("xxxxxxxxxxxx1015"))
                            {
                                line = line.Replace("xxxxxxxxxxxx1015", "");
                            }
                            if (line.Contains("XX/XX"))
                            {
                                line = line.Replace("XX/XX", "");
                            }
                            if (line.Contains("CVX"))
                            {
                                line = line.Replace("CVX", "");
                            }
                            if (line.Contains("#CustEmail#"))
                            {
                                line = line.Replace("#CustEmail#", "");
                            }
                            //address city, state zip
                            testNew.Quit();

                        }
                    }
                    else
                    {
                        testNew.Open(strPath);
                        string str = testNew.GetContent();
                        string NewLine = string.Empty;
                        line = str;

                        if (line.Contains("#CustName#"))
                        {
                            line = line.Replace("#CustName#", "");
                        }
                        if (line.Contains("#VoiceFile#"))
                        {
                            line = line.Replace("#VoiceFile#", "");
                        }
                        if (line.Contains("#Recorddate#"))
                        {
                            line = line.Replace("#Recorddate#", "");
                        }
                        if (line.Contains("#AgentName#"))
                        {
                            line = line.Replace("#AgentName#", Session[Constants.NAME].ToString());
                        }
                        if (line.Contains("#TodayDate#"))
                        {
                            line = line.Replace("#TodayDate#", ToDayDate.ToString("MM/dd/yyyy"));
                        }
                        if (line.Contains("#CustName#"))
                        {
                            line = line.Replace("#CustName#", "");
                        }
                        if (line.Contains("#Phone#"))
                        {
                            line = line.Replace("#Phone#", "");
                        }
                        if (line.Contains("#Address#"))
                        {
                            line = line.Replace("#Address#", "");
                        }
                        if (line.Contains("#VehiclesCount#"))
                        {
                            line = line.Replace("#VehiclesCount#", "0");
                        }
                        if (line.Contains("#Amount#"))
                        {
                            line = line.Replace("#Amount#", "0.00");
                        }
                        if (line.Contains("#Payment#"))
                        {
                            line = line.Replace("#Payment#", "");
                        }
                        if (line.Contains("xxxxxxxxxxxx1015"))
                        {
                            line = line.Replace("xxxxxxxxxxxx1015", "");
                        }
                        if (line.Contains("XX/XX"))
                        {
                            line = line.Replace("XX/XX", "");
                        }
                        if (line.Contains("CVX"))
                        {
                            line = line.Replace("CVX", "");
                        }
                        if (line.Contains("#CustEmail#"))
                        {
                            line = line.Replace("#CustEmail#", "");
                        }
                        //address city, state zip
                        testNew.Quit();
                    }
                    //test = new CCWordApp();

                    //test.Open(strPath1);

                    //test.InsertText(NewLine);

                    //test.SaveAs(strPath2);

                    //test.Quit();
                    txtgenMailText.Text = line;
                }
                mdepAuthorizeLetter.Show();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSaveAuthorizeLetter_Click(object sender, EventArgs e)
    {
        try
        {
            string strPath = string.Empty;
            strPath = Server.MapPath("~/MailTemplate" + "/AuthorizeLetter.docx");
            string strPath2 = string.Empty;
            string SaveLoc = Server.MapPath("~/NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/");
            strPath2 = Server.MapPath("~/NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/AuthorizeLetter.doc");
            test = new CCWordApp();
            test.Open();
            string str = test.GetContent();
            string NewLine = string.Empty;
            NewLine = txtgenMailText.Text;
            test.InsertText(NewLine);
            if (System.IO.Directory.Exists(SaveLoc) == false)
            {
                // Try to create the directory. 
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(SaveLoc);

            }
            if (System.IO.File.Exists(strPath2))
            {
                System.IO.File.Delete(strPath2);
            }
            test.SaveAs(strPath2);
            int FiletypeID = 1;
            string FilePath = "NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/AuthorizeLetter.doc";
            int DocumentTypeID = 1;
            int IsEditable = 1;
            DataSet dsData = objdropdownBL.SaveCBDocumnetsForProcess(Convert.ToInt32(Session["CBViewNoticeID"]), FiletypeID, FilePath, Convert.ToInt32(Session[Constants.USER_ID].ToString()), DocumentTypeID, IsEditable);
            test.Quit();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //protected void lnkbtnWelcomeEmail_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataSet dsexistFile = objdropdownBL.GetNoticeDocumentsByNoticeID(Convert.ToInt32(Session["CBViewNoticeID"].ToString().ToString()), 2);
    //        if (dsexistFile.Tables[0].Rows.Count > 0)
    //        {
    //            //lblExpErr.Text = "Empty Binded1";
    //            clsMailFormats format = new clsMailFormats();
    //            string text = string.Empty;
    //            string strPath2 = string.Empty;
    //            //test = new CCWordApp();
    //            string line = string.Empty;
    //            string strPath = string.Empty;
    //            string strPath1 = string.Empty;
    //            //lblExpErr.Text = "Empty Binded2";
    //            strPath2 = HttpContext.Current.Server.MapPath(dsexistFile.Tables[0].Rows[0]["FilePath"].ToString());
    //            //lblExpErr.Text = strPath2.ToString();
    //            string strMailFormat = string.Empty;
    //            string OpenPath, contents;
    //            string[] arInfo;
    //            StringBuilder sbQuery;
    //            string line1;
    //            string SalesMailFile = strPath2;
    //            FileStream Newfs = new FileStream(SalesMailFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    //            StreamReader objStreamReader = new StreamReader(Newfs, Encoding.Default);
    //            sbQuery = new StringBuilder();
    //            //lblExpErr.Text = "reader";
    //            while ((line1 = objStreamReader.ReadLine()) != null)
    //            {
    //                string strMail = string.Empty;
    //                strMail = line1 + "<br />";
    //                strMailFormat = strMailFormat + strMail;

    //            }
    //            string text2 = string.Empty;
    //            text2 = strMailFormat;
    //            text2 = text2.Replace("<br />", Environment.NewLine);
    //            lblRegisMail.Text = text2;
    //            lblRegisMail.Visible = true;
    //        }
    //        else
    //        {
    //            DataSet dsDate = objdropdownBL.GetDatetime();
    //            DateTime ToDayDate = Convert.ToDateTime(dsDate.Tables[0].Rows[0]["Datetime"].ToString());
    //            if ((Session["CBClaimsCustID"] == null) || (Session["CBClaimsCustID"].ToString() == ""))
    //            {
    //                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
    //                Session.Timeout = 180;
    //                string PDDate = string.Empty;
    //                string LoginPassword = "";
    //                string LoginName = "";
    //                string UserDisName = "";
    //                string Year = "";
    //                string Model = "";
    //                string Make = "";
    //                string UniqueID = "";
    //                string LoginUserID = "";
    //                Make = Make.Replace(" ", "%20");
    //                Model = Model.Replace(" ", "%20");
    //                Model = Model.Replace("&", "@");
    //                string Link = "http://unitedcarexchange.com";
    //                string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
    //                clsMailFormats format = new clsMailFormats();
    //                string text = string.Empty;
    //                text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink);
    //                text = text.Replace("<br />", Environment.NewLine);
    //                lblRegisMail.Text = text;
    //                lblRegisMail.Visible = true;
    //            }
    //            else
    //            {
    //                clsMailFormats format = new clsMailFormats();
    //                string text = string.Empty;
    //                string strPath2 = string.Empty;
    //                test = new CCWordApp();
    //                string line = string.Empty;
    //                string strPath = string.Empty;
    //                string strPath1 = string.Empty;
    //                DataSet dsPackageInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter(Convert.ToInt32(Session["CBClaimsCustID"].ToString()));
    //                if (dsPackageInfo.Tables[0].Rows.Count > 0)
    //                {
    //                    Session.Timeout = 180;
    //                    string PDDate = string.Empty;
    //                    string LoginPassword = dsPackageInfo.Tables[0].Rows[0]["Pwd"].ToString();
    //                    string LoginName = dsPackageInfo.Tables[0].Rows[0]["UserName"].ToString();
    //                    string UserDisName = dsPackageInfo.Tables[0].Rows[0]["Name"].ToString();

    //                    string Year = string.Empty;
    //                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
    //                    {
    //                        Year = dsPackageInfo.Tables[1].Rows[0]["yearOfMake"].ToString();
    //                    }
    //                    else
    //                    {
    //                        Year = "";
    //                    }
    //                    string Model = string.Empty;
    //                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
    //                    {
    //                        Model = dsPackageInfo.Tables[1].Rows[0]["model"].ToString();
    //                    }
    //                    else
    //                    {
    //                        Model = "";
    //                    }
    //                    string Make = string.Empty;
    //                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
    //                    {
    //                        Make = dsPackageInfo.Tables[1].Rows[0]["make"].ToString();
    //                    }
    //                    else
    //                    {
    //                        Make = "";
    //                    }
    //                    string UniqueID = string.Empty;
    //                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
    //                    {
    //                        UniqueID = dsPackageInfo.Tables[1].Rows[0]["CarUniqueID"].ToString();
    //                    }
    //                    else
    //                    {
    //                        UniqueID = "";
    //                    }
    //                    string LoginUserID = dsPackageInfo.Tables[0].Rows[0]["UserID"].ToString();
    //                    Make = Make.Replace(" ", "%20");
    //                    Model = Model.Replace(" ", "%20");
    //                    Model = Model.Replace("&", "@");
    //                    string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
    //                    string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
    //                    string text1 = string.Empty;
    //                    text1 = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text1, Link, TermsLink);
    //                    text1 = text1.Replace("<br />", Environment.NewLine);
    //                    lblRegisMail.Text = text1;
    //                    lblRegisMail.Visible = true;
    //                }
    //                else
    //                {
    //                    Session.Timeout = 180;
    //                    string PDDate = string.Empty;
    //                    string LoginPassword = "";
    //                    string LoginName = "";
    //                    string UserDisName = "";
    //                    string Year = "";
    //                    string Model = "";
    //                    string Make = "";
    //                    string UniqueID = "";
    //                    string LoginUserID = "";
    //                    Make = Make.Replace(" ", "%20");
    //                    Model = Model.Replace(" ", "%20");
    //                    Model = Model.Replace("&", "@");
    //                    string Link = "http://unitedcarexchange.com";
    //                    string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
    //                    string textes = string.Empty;
    //                    textes = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref textes, Link, TermsLink);
    //                    textes = textes.Replace("<br />", Environment.NewLine);
    //                    lblRegisMail.Text = textes;
    //                    lblRegisMail.Visible = true;
    //                }
    //            }
    //        }
    //        mpeViewregisterMail.Show();
    //    }
    //    catch (Exception ex)
    //    {
    //        //lblExpErr.Text = ex.ToString();
    //        throw ex;
    //    }
    //}
    protected void btnSaveregMail_Click(object sender, EventArgs e)
    {
        try
        {
            string strPath2 = string.Empty;
            string SaveLoc = Server.MapPath("NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/");
            strPath2 = Request.PhysicalApplicationPath + "\\NoticeCopies\\" + Session["CBViewNoticeID"].ToString() + "\\WelcomeMail.txt";
            string NewLine = string.Empty;
            NewLine = lblRegisMail.Text;
            if (System.IO.Directory.Exists(SaveLoc) == false)
            {
                // Try to create the directory. 
                System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(SaveLoc);

            }
            if (!File.Exists((strPath2)))
            {
                FileStream txtFile = File.Create(strPath2);
                txtFile.Close();
                System.IO.StreamWriter file = new System.IO.StreamWriter(strPath2);
                file.WriteLine(NewLine);
                file.Close();
            }
            else
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(strPath2);
                file.WriteLine(NewLine);
                file.Close();
            }
            int FiletypeID = 6;
            string FilePath = "NoticeCopies/" + Session["CBViewNoticeID"].ToString() + "/WelcomeMail.txt";
            int DocumentTypeID = 2;
            int IsEditable = 1;
            DataSet dsData = objdropdownBL.SaveCBDocumnetsForProcess(Convert.ToInt32(Session["CBViewNoticeID"]), FiletypeID, FilePath, Convert.ToInt32(Session[Constants.USER_ID].ToString()), DocumentTypeID, IsEditable);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnUCEAdv_Click(object sender, EventArgs e)
    {
        string url = @"http://www.google.com";
        try
        {
            //Create stringBuilder to write formatted 
            //Text to word file
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("<h1 title='Header' align='Center'>Writing To Word Using ASP.NET</h1> ".ToString());

            strBuilder.Append("<br>".ToString());
            strBuilder.Append("<table align='Center'>".ToString());
            strBuilder.Append("<tr>".ToString());

            strBuilder.Append("<td style='width:100px;color:green'><b>amiT</b></td>".ToString());

            strBuilder.Append("<td style='width:100px;color:red'>India</td>".ToString());
            strBuilder.Append("</tr>".ToString());
            strBuilder.Append("</table>".ToString());

        }
        catch (Exception ee)
        {
            //logging
        }
    }

    protected void lnkbtnWelcomeEmail_Click(object sender, EventArgs e)
    {
        try
        {
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);           
            DataSet dsexistFile = objdropdownBL.GetNoticeDocumentsByNoticeID(Convert.ToInt32(Session["CBViewNoticeID"].ToString().ToString()), 2);
            if (dsexistFile.Tables[0].Rows.Count > 0)
            {
                if (dsexistFile.Tables[0].Rows[0]["TemplateID"].ToString() != "")
                {
                    DataSet dsTemplateData = objdropdownBL.GetWelcomeMailInfoByID(Convert.ToInt32(dsexistFile.Tables[0].Rows[0]["TemplateID"].ToString()));
                    lblCustName.Text = dsTemplateData.Tables[0].Rows[0]["TempWelCustName"].ToString();
                    lblUserID.Text = dsTemplateData.Tables[0].Rows[0]["TempWelUserName"].ToString();
                    lblUserPassword.Text = dsTemplateData.Tables[0].Rows[0]["TempWelPassword"].ToString();
                    lblUceAdLink.Text = dsTemplateData.Tables[0].Rows[0]["TempWelAdURL"].ToString();
                }
                else
                {
                    if ((Session["CBClaimsCustID"] == null) || (Session["CBClaimsCustID"].ToString() == ""))
                    {
                        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
                    }
                    else
                    {
                        DataSet dsPackageInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter(Convert.ToInt32(Session["CBClaimsCustID"].ToString()));
                        lblUserPassword.Text = dsPackageInfo.Tables[0].Rows[0]["Pwd"].ToString();
                     
                        lblCustName.Text = dsPackageInfo.Tables[0].Rows[0]["Name"].ToString();
                        string Year2 = string.Empty;
                        if (dsPackageInfo.Tables[1].Rows.Count > 0)
                        {
                            Year2 = dsPackageInfo.Tables[1].Rows[0]["yearOfMake"].ToString();
                        }
                        else
                        {
                            Year2 = "";
                        }
                        string Model2 = string.Empty;
                        if (dsPackageInfo.Tables[1].Rows.Count > 0)
                        {
                            Model2 = dsPackageInfo.Tables[1].Rows[0]["model"].ToString();
                        }
                        else
                        {
                            Model2 = "";
                        }
                        string Make2 = string.Empty;
                        if (dsPackageInfo.Tables[1].Rows.Count > 0)
                        {
                            Make2 = dsPackageInfo.Tables[1].Rows[0]["make"].ToString();
                        }
                        else
                        {
                            Make2 = "";
                        }
                        string UniqueID2 = string.Empty;
                        if (dsPackageInfo.Tables[1].Rows.Count > 0)
                        {
                            UniqueID2 = dsPackageInfo.Tables[1].Rows[0]["CarUniqueID"].ToString();
                        }
                        else
                        {
                            UniqueID2 = "";
                        }
                        lblUserID.Text = dsPackageInfo.Tables[0].Rows[0]["UserID"].ToString();
                        Make2 = Make2.Replace(" ", "%20");
                        Model2 = Model2.Replace(" ", "%20");
                        Model2 = Model2.Replace("&", "@");
                        lblUceAdLink.Text = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year2 + "-" + Make2 + "-" + Model2 + "-" + UniqueID2;
                        string TermsLink2 = "http://unitedcarexchange.com/TermsandConditions.aspx";
                    }
                }
            }
            else
            {
                if ((Session["CBClaimsCustID"] == null) || (Session["CBClaimsCustID"].ToString() == ""))
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
                }
                else
                {
                    DataSet dsPackageInfo = objdropdownBL.GetPackageDetailsByUIDForAuthLetter(Convert.ToInt32(Session["CBClaimsCustID"].ToString()));
                    lblUserPassword.Text = dsPackageInfo.Tables[0].Rows[0]["Pwd"].ToString();
                  
                    lblCustName.Text = dsPackageInfo.Tables[0].Rows[0]["Name"].ToString();
                    string Year1 = string.Empty;
                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
                    {
                        Year1 = dsPackageInfo.Tables[1].Rows[0]["yearOfMake"].ToString();
                    }
                    else
                    {
                        Year1 = "";
                    }
                    string Model1 = string.Empty;
                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
                    {
                        Model1 = dsPackageInfo.Tables[1].Rows[0]["model"].ToString();
                    }
                    else
                    {
                        Model1 = "";
                    }
                    string Make1 = string.Empty;
                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
                    {
                        Make1 = dsPackageInfo.Tables[1].Rows[0]["make"].ToString();
                    }
                    else
                    {
                        Make1 = "";
                    }
                    string UniqueID1 = string.Empty;
                    if (dsPackageInfo.Tables[1].Rows.Count > 0)
                    {
                        UniqueID1 = dsPackageInfo.Tables[1].Rows[0]["CarUniqueID"].ToString();
                    }
                    else
                    {
                        UniqueID1 = "";
                    }
                    lblUserID.Text = dsPackageInfo.Tables[0].Rows[0]["UserID"].ToString();
                    Make1 = Make1.Replace(" ", "%20");
                    Model1 = Model1.Replace(" ", "%20");
                    Model1 = Model1.Replace("&", "@");
                    lblUceAdLink.Text = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year1 + "-" + Make1 + "-" + Model1 + "-" + UniqueID1;
                    string TermsLink1 = "http://unitedcarexchange.com/TermsandConditions.aspx";
                }
            }
            //text = text.Replace("<br />", Environment.NewLine);
            //lblWelcomeViewText.Text = text;
            //lblWelcomeViewText.Visible = true;

            mdepWelcomeCheckpop.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSaveWelcomeCheckpop_Click(object sender, EventArgs e)
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
