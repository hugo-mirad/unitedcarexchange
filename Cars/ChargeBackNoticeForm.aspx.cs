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
using System.Drawing.Imaging;


public partial class ChargeBackNoticeForm : System.Web.UI.Page
{
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
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                FillNoticeTypes();
                FillReplyMethods();
                FillRegStates();
            }
        }
    }

    private void FillReplyMethods()
    {
        try
        {
            DataSet dsDropData = new DataSet();
            if ((Session["CBReplyMethods"] == null) || (Session["CBReplyMethods"].ToString() == ""))
            {
                dsDropData = objdropdownBL.GetReplyMethods();
                Session["CBReplyMethods"] = dsDropData;
            }
            else
            {
                dsDropData = Session["CBReplyMethods"] as DataSet;
            }

            ddlReplyMethod.DataSource = dsDropData.Tables[0];
            ddlReplyMethod.DataTextField = "ReplyMethodName";
            ddlReplyMethod.DataValueField = "ReplyMethodID";
            ddlReplyMethod.DataBind();
            ddlReplyMethod.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillRegStates()
    {
        try
        {
            ddlState.DataSource = dsDropDown.Tables[1];
            ddlState.DataTextField = "State_Code";
            ddlState.DataValueField = "State_ID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillNoticeTypes()
    {
        DataSet dsDropData = new DataSet();
        if ((Session["CBNoticeTypes"] == null) || (Session["CBNoticeTypes"].ToString() == ""))
        {
            dsDropData = objdropdownBL.GetNoticeTypes();
            Session["CBNoticeTypes"] = dsDropData;
        }
        else
        {
            dsDropData = Session["CBNoticeTypes"] as DataSet;
        }

        ddlNoticeType.DataSource = dsDropData.Tables[0];
        ddlNoticeType.DataTextField = "NoticeTypeName";
        ddlNoticeType.DataValueField = "NoticeTypeID";
        ddlNoticeType.DataBind();
        ddlNoticeType.Items.Insert(0, new ListItem("Select", "0"));

    }
    protected void btnSearchUserDetails_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsUserData = new DataSet();
            string CCNumber = txtCCNumber.Text.Trim();
            int CarID = 0;
            if (txtVehicleID.Text.Trim() != "")
            {
                CarID = Convert.ToInt32(txtVehicleID.Text.Trim());
            }
            else
            {
                CarID = 0;
            }
            dsUserData = objdropdownBL.SmartzSearchForChargeBackUSerByCCOrCarID(CarID, CCNumber);
            if (dsUserData.Tables.Count > 0)
            {
                if (dsUserData.Tables[0].Rows.Count > 0)
                {
                    divResults.Style["display"] = "block";
                    grdIntroInfo.Visible = true;
                    lblResult.Visible = false;
                    grdIntroInfo.DataSource = dsUserData.Tables[0];
                    grdIntroInfo.DataBind();
                }
                else
                {
                    divResults.Style["display"] = "none";
                    grdIntroInfo.Visible = false;
                    lblResult.Visible = true;
                    lblResult.Text = "Results not found";
                }
            }
            else
            {
                divResults.Style["display"] = "none";
                grdIntroInfo.Visible = false;
                lblResult.Visible = true;
                lblResult.Text = "Results not found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnPrevousNoticesCheck_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsNoticeData = new DataSet();
            string CaseNumber = txtCaseNumber.Text.Trim();
            int NoticeID = 0;
            if (txtPreviousNoticeID.Text.Trim() != "")
            {
                NoticeID = Convert.ToInt32(txtPreviousNoticeID.Text.Trim());
            }
            else
            {
                NoticeID = 0;
            }
            dsNoticeData = objdropdownBL.SmartzSearchForCBForPreviousNotice(NoticeID, CaseNumber);
            if (dsNoticeData.Tables.Count > 0)
            {
                if (dsNoticeData.Tables[0].Rows.Count > 0)
                {
                    divNoticeRes.Style["display"] = "block";
                    repNotices.Visible = true;
                    lblNoticeResults.Visible = false;
                    repNotices.DataSource = dsNoticeData.Tables[0];
                    repNotices.DataBind();
                }
                else
                {
                    divNoticeRes.Style["display"] = "none";
                    repNotices.Visible = false;
                    lblNoticeResults.Visible = true;
                    lblNoticeResults.Text = "Results not found";
                }
            }
            else
            {
                divNoticeRes.Style["display"] = "none";
                repNotices.Visible = false;
                lblNoticeResults.Visible = true;
                lblNoticeResults.Text = "Results not found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int NoticeTypeID = Convert.ToInt32(ddlNoticeType.SelectedItem.Value);
            DateTime NoticeDate = Convert.ToDateTime(txtNoticeDate.Text.Trim());
            string caseNumber = txtCaseNumber.Text.Trim();
            string DisputeAmount = txtPayAmount.Text.Trim();
            DateTime ReplyDate = new DateTime();
            if (txtReplyDt.Text.Trim() == "")
            {
                ReplyDate = Convert.ToDateTime("1/1/1900");
            }
            else
            {
                ReplyDate = Convert.ToDateTime(txtReplyDt.Text.Trim());
            }
            DateTime receiveddate = Convert.ToDateTime(txtReceivedDate.Text.Trim());
            int ReplyMethod = Convert.ToInt32(ddlReplyMethod.SelectedItem.Value);
            string Email = txtSellerEmail.Text.Trim();
            string FaxNumber = txtFaxNo.Text.Trim();
            string City = txtCity.Text.Trim();
            string Address = txtAddress.Text.Trim();
            string zip = txtZip.Text.Trim();
            int State = Convert.ToInt32(ddlState.SelectedItem.Value);
            string Notes = txtNotes.Text.Trim();
            int UID = 0;
            for (int index = 0; index < grdIntroInfo.Items.Count; index++)
            {
                HiddenField hdnUID = (HiddenField)grdIntroInfo.Items[index].FindControl("hdnUID");
                CheckBox chkbx = (CheckBox)grdIntroInfo.Items[index].FindControl("chkbx");
                if (chkbx.Checked == true)
                {
                    UID = Convert.ToInt32(hdnUID.Value);
                    break;
                }
            }
            int PrevNoticeID = 0;
            for (int index = 0; index < repNotices.Items.Count; index++)
            {
                HiddenField hdnUID = (HiddenField)repNotices.Items[index].FindControl("hdnNoticeID");
                CheckBox chkbx = (CheckBox)repNotices.Items[index].FindControl("chkbx");
                if (chkbx.Checked == true)
                {
                    PrevNoticeID = Convert.ToInt32(hdnUID.Value);
                    break;
                }
            }
            int NoticeStatusID = 1;
            DataSet dsCBData = objdropdownBL.SaveChargeBackNotice(NoticeTypeID, NoticeDate, receiveddate, caseNumber, DisputeAmount, ReplyDate, NoticeStatusID, Notes,
                UID, ReplyMethod, FaxNumber, Email, Address, City, State, zip, PrevNoticeID, Convert.ToInt32(Session[Constants.USER_ID].ToString()));
            int NoticeID = Convert.ToInt32(dsCBData.Tables[0].Rows[0]["NoticeID"].ToString());
            Session["NewNoticeID"] = NoticeID;
            if (flupNoticeCopy.HasFile)
            {
                string sFilePath = string.Empty;
                string Directorypath = string.Empty;
                Directorypath = "NoticeCopies";
                Directorypath = Server.MapPath(Directorypath);
                if (System.IO.Directory.Exists(Directorypath))
                {
                    sFilePath = "NoticeCopies" + "/" + NoticeID.ToString();
                    string sFilePathDir = Server.MapPath(sFilePath);
                    if (System.IO.Directory.Exists(sFilePathDir) == false)
                    {
                        System.IO.Directory.CreateDirectory(sFilePathDir);
                    }
                    SaveFileCopy(sFilePath);
                }
                else
                {
                    if (System.IO.Directory.Exists(Directorypath) == false)
                    {
                        System.IO.Directory.CreateDirectory(Directorypath);
                    }
                    sFilePath = "NoticeCopies" + "/" + NoticeID.ToString();
                    string sFilePathDir = Server.MapPath(sFilePath);
                    if (System.IO.Directory.Exists(sFilePathDir) == false)
                    {
                        System.IO.Directory.CreateDirectory(sFilePathDir);
                    }
                    SaveFileCopy(sFilePath);
                }
            }

            if (chkReason1.Checked == true)
            {
                int NoticeReasonID = 1;
                int IsActive = 1;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            else
            {
                int NoticeReasonID = 1;
                int IsActive = 0;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            if (chkReason2.Checked == true)
            {
                int NoticeReasonID = 2;
                int IsActive = 1;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            else
            {
                int NoticeReasonID = 2;
                int IsActive = 0;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            if (chkReason3.Checked == true)
            {
                int NoticeReasonID = 3;
                int IsActive = 1;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            else
            {
                int NoticeReasonID = 3;
                int IsActive = 0;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            if (chkReason4.Checked == true)
            {
                int NoticeReasonID = 4;
                int IsActive = 1;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            else
            {
                int NoticeReasonID = 4;
                int IsActive = 0;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            if (chkReason5.Checked == true)
            {
                int NoticeReasonID = 5;
                int IsActive = 1;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            else
            {
                int NoticeReasonID = 5;
                int IsActive = 0;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            if (chkReason6.Checked == true)
            {
                int NoticeReasonID = 6;
                int IsActive = 1;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            else
            {
                int NoticeReasonID = 6;
                int IsActive = 0;
                DataSet dsReasons = objdropdownBL.SaveCBNoticeReasons(NoticeID, NoticeReasonID, IsActive);
            }
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = "CB Notice added successfully";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SaveFileCopy(string sFilePath)
    {
        try
        {
            string FileName = "PrevNoticeCopy.jpg";
            string FileNameFull = Server.MapPath(sFilePath);
            double FlSize = flupNoticeCopy.PostedFile.ContentLength;
            double FlSize2 = FlSize / 1024;
            double FlSize3 = FlSize2 / 1024;
            double limit = 0.5;
            if (FlSize3 > limit)
            {
                string path = FileNameFull + FileName;
                string ext = System.IO.Path.GetExtension(this.flupNoticeCopy.PostedFile.FileName);
                ext = ext.ToLower();
                System.Drawing.Image Img1 = System.Drawing.Image.FromStream(flupNoticeCopy.PostedFile.InputStream);
                compress(Img1, path, ext);
            }
            else
            {
                flupNoticeCopy.PostedFile.SaveAs(FileNameFull + "/" + FileName);
            }
            int FiletypeID = 5;
            string FilePath = sFilePath + "/" + FileName;
            int DocumentTypeID = 8;
            int IsEditable = 0;
            DataSet dsData = objdropdownBL.SaveCBDocumnets(Convert.ToInt32(Session["NewNoticeID"]), FiletypeID, FilePath, Convert.ToInt32(Session[Constants.USER_ID].ToString()), DocumentTypeID, IsEditable);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void compress(System.Drawing.Image img, string path, string Extension)
    {
        try
        {
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 60L);

            ImageCodecInfo jpegCodec = null;
            if (Extension == ".jpeg")
            {
                jpegCodec = GetEncoderInfo("image/jpeg");
            }
            if (Extension == ".bmp")
            {
                jpegCodec = GetEncoderInfo("image/bmp");
            }
            if (Extension == ".gif")
            {
                jpegCodec = GetEncoderInfo("image/gif");
            }
            if (Extension == ".png")
            {
                jpegCodec = GetEncoderInfo("image/png");
            }
            if (Extension == ".jpg")
            {
                jpegCodec = GetEncoderInfo("image/jpeg");
            }
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        // Get image codecs for all image formats 
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        // Find the correct image codec 
        for (int i = 0; i < codecs.Length; i++)
            if (codecs[i].MimeType == mimeType)
                return codecs[i];
        return null;
    }

    protected void BtnClsUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("ChargeBackNoticeForm.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
