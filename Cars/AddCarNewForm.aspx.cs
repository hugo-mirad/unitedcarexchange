
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
using CarsBL.CentralDBTransactions;
using System.Net;
using System.IO;
public partial class AddCarNewForm : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserregInfo = new UserRegistrationInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
            if (!IsPostBack)
            {

                lnkBtnLogout.Visible = true;
                lblUserName.Visible = true;
                string LogUsername = Session[Constants.NAME].ToString();
                if (LogUsername.Length > 10)
                {
                    lblUserName.Text = LogUsername.ToString().Substring(0, 10);
                }
                else
                {
                    lblUserName.Text = LogUsername;
                }

                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                Session["NewSaleCarID"] = null;
                Session["NewSaleUID"] = null;
                Session["NewSalePostingID"] = null;
                Session["NewSaleUserPackID"] = null;
                Session["NewSaleSellerID"] = null;
                Session["NewSalePSID1"] = null;
                Session["NewSalePSID2"] = null;
                Session["NewSalePaymentID"] = null;

                dsActiveSaleAgents = objCentralDBBL.GetSmartzSalesAgentsActiveData();
                Session["ActiveSalesAgents"] = dsActiveSaleAgents;
                DataSet dsYears = objdropdownBL.USP_GetNext12years();

                fillYears(dsYears);
                FillYear();
                FillPackage();
                FillStates();
                GetAllModels();
                GetMakes();
                GetModelsInfo();
                FillExteriorColor();
                FillInteriorColor();
                GetBody();
                //FillPaymentDate();
                FillPDDate();
                FillBillingStates();
                FillPhotoSource();
                FillDescriptionSource();
                FillSaleAgents();
                FillVerifier();
                FillVoiceFileLocation();
                // FillCheckTypes();
                FillPopPaymentDate();
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                txtPaymentDate.Text = dtNow.ToString("MM/dd/yyyy");
            }
        }
    }

    private void FillVoiceFileLocation()
    {
        try
        {
            DataSet dsVoiceFileLocation = objCentralDBBL.GetVoiceFileLocation();
            ddlVoiceFileLocation.DataSource = dsVoiceFileLocation.Tables[0];
            ddlVoiceFileLocation.DataTextField = "VoiceFileLocationName";
            ddlVoiceFileLocation.DataValueField = "VoiceFileLocationID";
            ddlVoiceFileLocation.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    private void FillVerifier()
    {
        try
        {
            dsActiveSaleAgents = Session["ActiveSalesAgents"] as DataSet;
            ddlVerifier.DataSource = dsActiveSaleAgents.Tables[0];
            ddlVerifier.DataTextField = "American_Name";
            ddlVerifier.DataValueField = "Sale_Agent_Id";
            ddlVerifier.DataBind();
            ddlVerifier.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillSaleAgents()
    {
        try
        {
            dsActiveSaleAgents = Session["ActiveSalesAgents"] as DataSet;
            ddlSaleAgent.DataSource = dsActiveSaleAgents.Tables[0];
            ddlSaleAgent.DataTextField = "American_Name";
            ddlSaleAgent.DataValueField = "Sale_Agent_Id";
            ddlSaleAgent.DataBind();
            ddlSaleAgent.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillDescriptionSource()
    {
        try
        {
            DataSet dsDescripSource = objdropdownBL.GetMasterSourceOfDescription();
            ddlDescriptionSource.DataSource = dsDescripSource.Tables[0];
            ddlDescriptionSource.DataTextField = "SourceOfDescriptionName";
            ddlDescriptionSource.DataValueField = "SourceOfDescriptionID";
            ddlDescriptionSource.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillPhotoSource()
    {
        try
        {
            DataSet dsDescripPhotos = objdropdownBL.GetMasterSourceOfPhotos();
            ddlPhotosSource.DataSource = dsDescripPhotos.Tables[0];
            ddlPhotosSource.DataTextField = "SourceOfPhotosName";
            ddlPhotosSource.DataValueField = "SourceOfPhotosID";
            ddlPhotosSource.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // your code!
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
    }


    private void FillYear()
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
            ddlYear.DataSource = dsYears.Tables[0];
            ddlYear.DataTextField = "Year";
            ddlYear.DataValueField = "Year";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void fillYears(DataSet dsYears)
    {
        try
        {
            CCExpiresYear.Items.Clear();
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
            ddlLocationState.DataSource = dsDropDown.Tables[1];
            ddlLocationState.DataTextField = "State_Code";
            ddlLocationState.DataValueField = "State_ID";
            ddlLocationState.DataBind();
            ddlLocationState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillBillingStates()
    {
        try
        {
            ddlbillingstate.Items.Clear();
            if (Session["DsDropDown"] == null)
            {
                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                Session["DsDropDown"] = dsDropDown;
            }
            else
            {
                dsDropDown = (DataSet)Session["DsDropDown"];
            }

            ddlbillingstate.DataSource = dsDropDown.Tables[1];
            ddlbillingstate.DataTextField = "State_Code";
            ddlbillingstate.DataValueField = "State_ID";
            ddlbillingstate.DataBind();
            ddlbillingstate.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    //private void FillCheckTypes()
    //{
    //    try
    //    {
    //        DataSet dsCheckTypes = new DataSet();
    //        dsCheckTypes = objHotLeadBL.GetAllCheckTypes();
    //        ddlCheckType.DataSource = dsCheckTypes.Tables[0];
    //        ddlCheckType.DataTextField = "CheckTypeName";
    //        ddlCheckType.DataValueField = "CheckTypeID";
    //        ddlCheckType.DataBind();
    //        ddlCheckType.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    private void FillPackage()
    {
        try
        {
            for (int i = 1; i < dsDropDown.Tables[2].Rows.Count; i++)
            {
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsDropDown.Tables[2].Rows[i]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = dsDropDown.Tables[2].Rows[i]["Description"].ToString();
                ListItem list = new ListItem();
                list.Text = PackName + " ($" + PackAmount + ")";
                list.Value = dsDropDown.Tables[2].Rows[i]["PackageID"].ToString();
                ddlPackage.Items.Add(list);
            }
            ddlPackage.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetAllModels()
    {
        try
        {
            DataSet dsAllModels = new DataSet();

            if (Session[Constants.AllModel] == null)
            {

                dsAllModels = objdropdownBL.USP_GetAllModels(0);
                Session[Constants.AllModel] = dsAllModels;
            }
            else
            {
                dsAllModels = (DataSet)Session[Constants.AllModel];
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void GetMakes()
    {
        try
        {
            var obj = new List<MakesInfo>();


            MakesBL objMakesBL = new MakesBL();

            if (Session[Constants.Makes] == null)
            {
                obj = (List<MakesInfo>)objMakesBL.GetMakes();
                Session[Constants.Makes] = obj;
            }
            else
            {
                obj = (List<MakesInfo>)Session[Constants.Makes];
            }
            ddlMake.DataSource = obj;
            ddlMake.DataTextField = "Make";
            ddlMake.DataValueField = "MakeID";
            ddlMake.DataBind();
            ddlMake.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void GetModelsInfo()
    {
        try
        {
            //var objModel = new List<MakesInfo>();
            //objModel = Session["AllModel"] as List<MakesInfo>;
            DataSet dsModels = Session[Constants.AllModel] as DataSet;
            int makeid = Convert.ToInt32(ddlMake.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsModels.Tables[0].DefaultView;
            dvModel.RowFilter = "MakeID='" + makeid.ToString() + "'";
            dtModel = dvModel.ToTable();
            ddlModel.DataSource = dtModel;
            ddlModel.Items.Clear();
            ddlModel.DataTextField = "Model";
            ddlModel.DataValueField = "MakeModelID";
            ddlModel.DataBind();
            ddlModel.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillInteriorColor()
    {
        try
        {
            ddlInteriorColor.DataSource = dsDropDown.Tables[4];
            ddlInteriorColor.DataTextField = "InteriorColorName";
            ddlInteriorColor.DataValueField = "InteriorColorName";
            ddlInteriorColor.DataBind();
            ddlInteriorColor.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillExteriorColor()
    {
        try
        {
            ddlExteriorColor.DataSource = dsDropDown.Tables[3];
            ddlExteriorColor.DataTextField = "ExteriorColorName";
            ddlExteriorColor.DataValueField = "ExteriorColorName";
            ddlExteriorColor.DataBind();
            ddlExteriorColor.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }

    public void GetBody()
    {
        try
        {
            var obj = new List<BodyInfo>();

            //MakesInfo objMakes = new MakesInfo();
            MakesBL objMakesBL = new MakesBL();

            if (Session[Constants.Bodys] == null)
            {
                obj = (List<BodyInfo>)objMakesBL.GetBodys();
                Session["Bodys"] = obj;
            }
            else
            {
                obj = (List<BodyInfo>)Session[Constants.Bodys];
            }


            ddlBodyStyle.DataSource = obj;
            ddlBodyStyle.DataTextField = "bodyType";
            ddlBodyStyle.DataValueField = "bodyTypeID";
            ddlBodyStyle.DataBind();
            ddlBodyStyle.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    ////private void FillCylinders()
    ////{
    ////    try
    ////    {
    ////        ddlCylinderCount.DataSource = dsDropDown.Tables[5];
    ////        ddlCylinderCount.DataTextField = "CylindersName";
    ////        ddlCylinderCount.DataValueField = "CylindersName";
    ////        ddlCylinderCount.DataBind();
    ////        ddlCylinderCount.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////    }
    ////}
    private void FillPDDate()
    {
        try
        {
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            ddlPDDate.Items.Clear();
            for (int i = 0; i < 21; i++)
            {
                ListItem list = new ListItem();
                list.Text = dtNow.AddDays(i).ToString("MM/dd/yyyy");
                list.Value = dtNow.AddDays(i).ToString("MM/dd/yyyy");
                ddlPDDate.Items.Add(list);
            }
            ddlPDDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillPopPaymentDate()
    {
        try
        {
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            ddlPayPopPaymentDate.Items.Clear();
            for (int i = 0; i < 21; i++)
            {
                ListItem list = new ListItem();
                list.Text = dtNow.AddDays(-i).ToString("MM/dd/yyyy");
                list.Value = dtNow.AddDays(-i).ToString("MM/dd/yyyy");
                ddlPayPopPaymentDate.Items.Add(list);
            }
            ddlPayPopPaymentDate.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetModelsInfo();
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //private void FillDriveTrain()
    //{
    //    try
    //    {
    //        ddlDriveTrain.DataSource = dsDropDown.Tables[6];
    //        ddlDriveTrain.DataTextField = "NoOfDoorsName";
    //        ddlDriveTrain.DataValueField = "NoOfDoorsName";
    //        ddlDriveTrain.DataBind();
    //        ddlDriveTrain.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //private void FillTransmissions()
    //{
    //    try
    //    {
    //        ddlTransmission.DataSource = dsDropDown.Tables[7];
    //        ddlTransmission.DataTextField = "TransmissionName";
    //        ddlTransmission.DataValueField = "TransmissionName";
    //        ddlTransmission.DataBind();
    //        ddlTransmission.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}


    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
            objCentralDBBL.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), System.DateTime.Now, Convert.ToInt32(Session[Constants.USERLOG_ID]), 2);
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("index.aspx");
        }
        catch (Exception ex)
        {
        }
    }


    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AddCarNewForm.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnPayPopUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string AuthNetTransID = txtPayPoptransactionID.Text;
            string PayInfo = "TransID=" + AuthNetTransID + "</br>"; // Returned Authorisation Code;
            string PayNotes = "TransID=" + AuthNetTransID; // Returned Authorisation Code;                
            string Result = "Paid";
            string PackCost1 = hdnPayPopPackage.Value;
            string[] Pack1 = PackCost1.Split('$');
            string[] FinalAmountSpl1 = Pack1[1].Split(')');
            string FinalAmount1 = FinalAmountSpl1[0].ToString();
            int PmntStatus = 1;
            int AdActive;
            int UceStatus;
            int MultisiteStatus;
            int ListingStatus;
            if (Convert.ToDouble(hdnPayPopAmountNow.Value).ToString() == "0.00")
            {
                Result = "NoPayDue";
                PmntStatus = 8;
                AdActive = 0;
                UceStatus = 0;
                ListingStatus = 2;
                MultisiteStatus = 0;
            }
            else if (Convert.ToDouble(FinalAmount1) != Convert.ToDouble(hdnPayPopAmountNow.Value))
            {
                Result = "PartialPaid";
                PmntStatus = 7;
                AdActive = 0;
                UceStatus = 0;
                ListingStatus = 2;
                MultisiteStatus = 0;
            }
            else
            {
                Result = "Paid";
                PmntStatus = 2;
                AdActive = 1;
                UceStatus = 0;
                ListingStatus = 1;
                if ((hdnPayPopPackageID.Value == "4") || (hdnPayPopPackageID.Value == "5") || (hdnPayPopPackageID.Value == "6"))
                {
                    MultisiteStatus = 1;
                }
                else
                {
                    MultisiteStatus = 0;
                }
            }
            int PaymentID = Convert.ToInt32(Session["NewSalePaymentID1"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int CarID = Convert.ToInt32(Session["CarID"].ToString());
            DateTime PaymentDate = Convert.ToDateTime(ddlPayPopPaymentDate.SelectedItem.Text);
            DataSet dsPaymentSave = objdropdownBL.SavePaymentInfoForPayPopUpdate(txtPDAmountNow.Text, PaymentID, PmntStatus, AuthNetTransID, PostingID, CarID,
                PayNotes, AdActive, ListingStatus, UceStatus, MultisiteStatus, PaymentDate);
            MPEUpdate.Hide();
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = PayInfo + "Customer details saved successfully with carid " + Session["CarID"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnPending_Click(object sender, EventArgs e)
    {
        try
        {
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = "Customer details saved successfully with carid " + Session["CarID"].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnCancelUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            MPEUpdate.Hide();
            MdepPaymentAskPopup.Show();
            if (Session["SavePaymentType"].ToString() == "6")
            {
                btnProcessNow.Visible = false;
            }
            lblPayAskPop.Visible = true;
            lblPayAskPop.Text = "Enter payment details";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnPaymentDone_Click(object sender, EventArgs e)
    {
        try
        {
            MPEUpdate.Show();
            hdnPayPopAmountNow.Value = txtPDAmountNow.Text;
            hdnPayPopPackage.Value = ddlPackage.SelectedItem.Text;
            hdnPayPopPackageID.Value = ddlPackage.SelectedItem.Value;
            txtPayPoptransactionID.Text = "";
            ListItem liPayDate = new ListItem();
            liPayDate.Value = "0";
            liPayDate.Text = "Select";
            ddlPayPopPaymentDate.SelectedIndex = ddlPayPopPaymentDate.Items.IndexOf(liPayDate);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnProcessNow_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Session["SavePaymentType"].ToString() == "1") || (Session["SavePaymentType"].ToString() == "2") || (Session["SavePaymentType"].ToString() == "3") || (Session["SavePaymentType"].ToString() == "4"))
            {
                AuthorizePayment();
            }
            if (Session["SavePaymentType"].ToString() == "5")
            {
                GoWithCheck();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string SellerPhone = txtPhone.Text;
            SellerPhone = SellerPhone.Replace("-", "");
            SellerPhone = SellerPhone.Replace("-", "");
            string RegPhone = SellerPhone;
            DataSet dsPhoneExists = objdropdownBL.ChkUserExistsPhoneNumber(RegPhone);
            string Email = txtEmail.Text;
            string UserID;
            string FistName = objGeneralFunc.ToProper(txtLastName.Text);
            if (FistName.Length > 3)
            {
                FistName = FistName.Substring(0, 3);
            }
            string s = "";
            int j;
            Random random1 = new Random();
            for (j = 1; j < 4; j++)
            {
                s += random1.Next(0, 9).ToString();
            }
            UserID = FistName + RegPhone.ToString();
            int EmailExists = 1;
            if (chkbxEMailNA.Checked == true)
            {
                EmailExists = 0;
            }
            if (dsPhoneExists.Tables.Count > 0)
            {
                if (dsPhoneExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Phone number " + RegPhone + " already exists";
                }
                else
                {
                    if (EmailExists == 1)
                    {
                        DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(Email);
                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + Email + " already exists";
                            }
                            else
                            {
                                DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                if (dsUserIDExists.Tables.Count > 0)
                                {
                                    if (dsUserExists.Tables[0].Rows.Count > 0)
                                    {
                                        UserID = UserID + s.ToString();
                                        SaveRegData(UserID, Email, EmailExists);
                                    }
                                    else
                                    {
                                        SaveRegData(UserID, Email, EmailExists);
                                    }
                                }
                                else
                                {
                                    SaveRegData(UserID, Email, EmailExists);
                                }
                            }
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    SaveRegData(UserID, Email, EmailExists);
                                }
                                else
                                {
                                    SaveRegData(UserID, Email, EmailExists);
                                }
                            }
                            else
                            {
                                SaveRegData(UserID, Email, EmailExists);
                            }
                        }
                    }
                    else
                    {
                        DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                        if (dsUserIDExists.Tables.Count > 0)
                        {
                            if (dsUserIDExists.Tables[0].Rows.Count > 0)
                            {
                                UserID = UserID + s.ToString();
                                SaveRegData(UserID, Email, EmailExists);
                            }
                            else
                            {
                                SaveRegData(UserID, Email, EmailExists);
                            }
                        }
                        else
                        {
                            SaveRegData(UserID, Email, EmailExists);
                        }
                    }
                }
            }
            else
            {
                if (EmailExists == 1)
                {
                    DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(Email);
                    if (dsUserExists.Tables.Count > 0)
                    {
                        if (dsUserExists.Tables[0].Rows.Count > 0)
                        {
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Email " + Email + " already exists";
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    SaveRegData(UserID, Email, EmailExists);
                                }
                                else
                                {
                                    SaveRegData(UserID, Email, EmailExists);
                                }
                            }
                            else
                            {
                                SaveRegData(UserID, Email, EmailExists);
                            }

                        }
                    }
                    else
                    {
                        DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                        if (dsUserIDExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                UserID = UserID + s.ToString();
                                SaveRegData(UserID, Email, EmailExists);
                            }
                            else
                            {
                                SaveRegData(UserID, Email, EmailExists);
                            }
                        }
                        else
                        {
                            SaveRegData(UserID, Email, EmailExists);
                        }

                    }
                }
                else
                {
                    DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                    if (dsUserIDExists.Tables.Count > 0)
                    {
                        if (dsUserIDExists.Tables[0].Rows.Count > 0)
                        {
                            UserID = UserID + s.ToString();
                            SaveRegData(UserID, Email, EmailExists);
                        }
                        else
                        {
                            SaveRegData(UserID, Email, EmailExists);
                        }
                    }
                    else
                    {
                        SaveRegData(UserID, Email, EmailExists);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void SaveRegData(string UserID, string Email, int EmailExists)
    {
        try
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 5; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            string RegName = objGeneralFunc.ToProper(txtFirstName.Text + " " + txtLastName.Text).Trim();
            string RegUserName = Email;
            string LastName = objGeneralFunc.ToProper(txtLastName.Text).Trim();
            if (LastName.Length > 4)
            {
                LastName = LastName.Substring(0, 4);
            }
            string Password = LastName + r.ToString();
            string RegPhone = txtPhone.Text;
            RegPhone = RegPhone.Replace("-", "");
            RegPhone = RegPhone.Replace("-", "");
            string CouponCode = "";
            string ReferCode = "";
            string RegAddress = objGeneralFunc.ToProper(txtAddress.Text).Trim();
            string RegCity = objGeneralFunc.ToProper(txtCity.Text).Trim();
            int RegState = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
            string RegZip = txtZip.Text;
            string BusinessName = "";
            string AltEmail = "";
            string RegAltPhone = "";
            int SalesAgentID = Convert.ToInt32(ddlSaleAgent.SelectedItem.Value);
            int VerifierID = Convert.ToInt32(ddlVerifier.SelectedItem.Value);
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value);
            DataSet dsUserInfo = objdropdownBL.Usp_SmartzSave_RegisterLogUser(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
            Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
            Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
            Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
            Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
            Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
            Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
            Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
            Session["RegEmailExists"] = dsUserInfo.Tables[0].Rows[0]["EmailExists"].ToString();
            Session["RegLogUserID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
            SaveData();
            MdepPaymentAskPopup.Show();
            if (Session["SavePaymentType"].ToString() == "6")
            {
                btnProcessNow.Visible = false;
            }
            lblPayAskPop.Visible = true;
            lblPayAskPop.Text = "Enter payment details";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SaveData()
    {
        try
        {
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value);
            string strIp;
            string strHostName = Request.UserHostAddress.ToString();
            strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            int YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Text);
            Session["SelYear"] = ddlYear.SelectedItem.Text;
            Session["SelMake"] = ddlMake.SelectedItem.Text;
            Session["SelModel"] = ddlModel.SelectedItem.Text;
            int MakeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value);
            int BodyTypeID = Convert.ToInt32(ddlBodyStyle.SelectedItem.Value);
            int CarID;
            string Price = string.Empty;
            if (txtAskingPrice.Text == "")
            {
                Price = "0";
            }
            else
            {
                Price = txtAskingPrice.Text;
            }
            string Mileage = string.Empty;
            if (txtMileage.Text == "")
            {
                Mileage = "0";
            }
            else
            {
                Mileage = txtMileage.Text;
            }
            string ExteriorColor = ddlExteriorColor.SelectedItem.Text;
            string InteriorColor = ddlInteriorColor.SelectedItem.Text;
            string Transmission = "Unspecified";
            if (rdbtnTrans1.Checked == true)
            {
                Transmission = "Automatic";
            }
            else if (rdbtnTrans2.Checked == true)
            {
                Transmission = "Manual";
            }
            else if (rdbtnTrans3.Checked == true)
            {
                Transmission = "Tiptronic";
            }
            else if (rdbtnTrans4.Checked == true)
            {
                Transmission = "Unspecified";
            }
            string NumberOfDoors = string.Empty;
            if (rdbtnDoor2.Checked == true)
            {
                NumberOfDoors = "Two Door";
            }
            else if (rdbtnDoor3.Checked == true)
            {
                NumberOfDoors = "Three Door";
            }
            else if (rdbtnDoor4.Checked == true)
            {
                NumberOfDoors = "Four Door";
            }
            else if (rdbtnDoor5.Checked == true)
            {
                NumberOfDoors = "Five Door";
            }
            else
            {
                NumberOfDoors = "Unspecified";
            }
            string DriveTrain = "Unspecified";
            if (rdbtnDriveTrain1.Checked == true)
            {
                DriveTrain = "2 wheel drive";
            }
            else if (rdbtnDriveTrain2.Checked == true)
            {
                DriveTrain = "2 wheel drive - front";
            }
            else if (rdbtnDriveTrain3.Checked == true)
            {
                DriveTrain = "All wheel drive";
            }
            else if (rdbtnDriveTrain4.Checked == true)
            {
                DriveTrain = "Rear wheel drive";
            }
            else if (rdbtnDriveTrain5.Checked == true)
            {
                DriveTrain = "Unspecified";
            }


            string VIN = txtVin.Text;
            string NumberOfCylinder = "Unspecified";
            if (rdbtnCylinders1.Checked == true)
            {
                NumberOfCylinder = "3 Cylinder";
            }
            else if (rdbtnCylinders2.Checked == true)
            {
                NumberOfCylinder = "4 Cylinder";
            }
            else if (rdbtnCylinders3.Checked == true)
            {
                NumberOfCylinder = "5 Cylinder";
            }
            else if (rdbtnCylinders4.Checked == true)
            {
                NumberOfCylinder = "6 Cylinder";
            }
            else if (rdbtnCylinders5.Checked == true)
            {
                NumberOfCylinder = "7 Cylinder";
            }
            else if (rdbtnCylinders6.Checked == true)
            {
                NumberOfCylinder = "8 Cylinder";
            }
            int FuelTypeID = Convert.ToInt32(0);
            if (rdbtnFuelType1.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(1);
            }
            else if (rdbtnFuelType2.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(2);
            }
            else if (rdbtnFuelType3.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(3);
            }
            else if (rdbtnFuelType4.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(4);
            }
            else if (rdbtnFuelType5.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(5);
            }
            else if (rdbtnFuelType6.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(6);
            }
            else if (rdbtnFuelType7.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(7);
            }
            else if (rdbtnFuelType8.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(0);
            }

            int ConditionID = Convert.ToInt32(0);
            string Condition = "Unspecified";
            if (rdbtnCondition1.Checked == true)
            {
                ConditionID = Convert.ToInt32(1);
                Condition = "Excellent";
            }
            else if (rdbtnCondition2.Checked == true)
            {
                ConditionID = Convert.ToInt32(2);
                Condition = "Very Good";
            }
            else if (rdbtnCondition3.Checked == true)
            {
                ConditionID = Convert.ToInt32(3);
                Condition = "Good";
            }
            else if (rdbtnCondition4.Checked == true)
            {
                ConditionID = Convert.ToInt32(4);
                Condition = "Fair";
            }
            else if (rdbtnCondition5.Checked == true)
            {
                ConditionID = Convert.ToInt32(5);
                Condition = "Poor";
            }
            else if (rdbtnCondition6.Checked == true)
            {
                ConditionID = Convert.ToInt32(6);
                Condition = "Parts or Salvage";
            }
            else if (rdbtnCondition7.Checked == true)
            {
                ConditionID = Convert.ToInt32(0);
                Condition = "Unspecified";
            }

            string SellerZip = string.Empty;
            //if (txtZip.Text.Length == 4)
            //{
            //    SellerZip = "0" + txtZip.Text;
            //}
            //else
            //{
            SellerZip = txtZip.Text;
            //}
            string SellCity = objGeneralFunc.ToProper(txtCity.Text);
            int SellStateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);

            string Description = string.Empty;
            Description = txtDescription.Text;
            int SourceOfPhotos = Convert.ToInt32(ddlPhotosSource.SelectedItem.Value);
            int SourceOfDescription = Convert.ToInt32(ddlDescriptionSource.SelectedItem.Value);

            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtSaleNotes.Text.Trim();
            InternalNotesNew = InternalNotesNew.Trim();
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            if (InternalNotesNew != "")
            {
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            }
            else
            {
                InternalNotesNew = InternalNotesNew.Trim();
            }
            string Title = "";

            DataSet dsCarsDetails = objdropdownBL.SmartzSaveCarDetailsForNewForm(YearOfMake, MakeModelID, BodyTypeID, ConditionID, Price, Mileage, ExteriorColor, Transmission, InteriorColor, NumberOfDoors, VIN, NumberOfCylinder, FuelTypeID, SellerZip, SellCity, SellStateID, DriveTrain, Description, Condition, InternalNotesNew, Title, SourceOfPhotos, SourceOfDescription);
            Session["CarID"] = Convert.ToInt32(dsCarsDetails.Tables[0].Rows[0]["CarID"].ToString());
            Session["UniqueID"] = dsCarsDetails.Tables[0].Rows[0]["CarUniqueID"].ToString();
            CarID = Convert.ToInt32(Session["CarID"].ToString());
            int RegUID = Convert.ToInt32(Session["RegUSER_ID"].ToString());
            int UserPackID = Convert.ToInt32(Session["RegUserPackID"].ToString());
            int FeatureID;
            int IsactiveFea;
            string SellerName = objGeneralFunc.ToProper(txtFirstName.Text);
            string SellerLastName = objGeneralFunc.ToProper(txtLastName.Text);
            string Address1 = txtAddress.Text;
            string CustPhone = txtPhone.Text;
            CustPhone = CustPhone.Replace("-", "");
            CustPhone = CustPhone.Replace("-", "");
            string AltCustPhone = "";
            DataSet dsDatetime = objdropdownBL.GetDatetime();
            DateTime SaleDate = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
            string CustState = ddlLocationState.SelectedItem.Text;
            string CustEmail = txtEmail.Text;
            int SaleEnteredBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet dsPosting = new DataSet();
            Session["CarSellerZip"] = SellerZip;
            dsPosting = objdropdownBL.SmartzSaveSellerInfoForNewForm(SellerName, Address1, SellCity, CustState, SellerZip, CustPhone, AltCustPhone, CustEmail, CarID, RegUID, PackageID, SaleDate, SaleEnteredBy, strIp, SellerLastName);
            Session["PostingID"] = Convert.ToInt32(dsPosting.Tables[0].Rows[0]["PostingID"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            for (int i = 1; i < 54; i++)
            {
                if (i != 10)
                {
                    if (i != 37)
                    {
                        if (i != 38)
                        {
                            string ChkBoxID = "chkFeatures" + i.ToString();
                            CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                            if (ChkedBox.Checked == true)
                            {
                                IsactiveFea = 1;
                            }
                            else
                            {
                                IsactiveFea = 0;
                            }
                            FeatureID = i;
                            bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
                        }
                    }
                }
            }
            if (rdbtnLeather.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 10;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 10;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            if (rdbtnVinyl.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 37;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 37;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            if (rdbtnCloth.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 38;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 38;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }

            if (rdbtnInteriorNA.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 54;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 54;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            int PaymentType = 0;
            string Cardtype = string.Empty;
            if (rdbtnPayVisa.Checked == true)
            {
                PaymentType = 1;
                Cardtype = "VisaCard";
                Session["SavePaymentType"] = 1;
            }
            else if (rdbtnPayMasterCard.Checked == true)
            {
                PaymentType = 2;
                Cardtype = "MasterCard";
                Session["SavePaymentType"] = 2;
            }
            else if (rdbtnPayDiscover.Checked == true)
            {
                PaymentType = 4;
                Cardtype = "DiscoverCard";
                Session["SavePaymentType"] = 4;
            }
            else if (rdbtnPayAmex.Checked == true)
            {
                PaymentType = 3;
                Cardtype = "AmExCard";
                Session["SavePaymentType"] = 3;
            }
            else if (rdbtnPayPaypal.Checked == true)
            {
                PaymentType = 6;
                Session["SavePaymentType"] = 6;
            }
            else if (rdbtnPayCheck.Checked == true)
            {
                PaymentType = 5;
                Session["SavePaymentType"] = 5;
            }
            int AdActive;
            int UceStatus;
            int MultisiteStatus;
            int ListingStatus;
            string VoiceRecord = txtVoicefileConfirmNo.Text.Trim();
            int pmntStatus = Convert.ToInt32(1);
            String TransactionID = String.Empty;
            TransactionID = "";
            AdActive = 0;
            UceStatus = 0;
            MultisiteStatus = 0;
            int VoiceFileLocation = Convert.ToInt32(ddlVoiceFileLocation.SelectedItem.Value);
            int PaymentID1 = 0;
            int PaymentID2 = 0;
            if ((rdbtnPayVisa.Checked == true) || (rdbtnPayMasterCard.Checked == true) || (rdbtnPayDiscover.Checked == true) || (rdbtnPayAmex.Checked == true))
            {
                if (chkboxlstPDsale.Checked == true)
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    //int PSStatusID = 4;
                    //int pmntStatus = 1;
                    if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0.00")
                    {
                        pmntStatus = 8;
                    }
                    else
                    {
                        pmntStatus = 1;
                    }
                    string CCCardNumber = CardNumber.Text;
                    string CardExpDt = ExpMon.SelectedValue + "/" + CCExpiresYear.SelectedValue;
                    string CardholderName = objGeneralFunc.ToProper(txtCardholderName.Text);
                    string CardholderLastName = objGeneralFunc.ToProper(txtCardholderLastName.Text);
                    string CardCode = cvv.Text;
                    string BillingAdd = objGeneralFunc.ToProper(txtbillingaddress.Text);
                    string BillingCity = objGeneralFunc.ToProper(txtbillingcity.Text);
                    string BillingState = ddlbillingstate.SelectedItem.Value;
                    string BillingZip = txtbillingzip.Text;
                    DateTime PDDate = Convert.ToDateTime(ddlPDDate.SelectedItem.Text);
                    string PDPayAmountLater = txtPDAmountLater.Text;
                    DataSet dsSaveCCInfo = objdropdownBL.SaveCreditCardDataForPDSale(PackageID, CarID, PaymentScheduleDate, Amount, PDDate, PDPayAmountLater, PaymentID1, PaymentID2, PaymentType,
                                            pmntStatus, strIp, VoiceRecord, VoiceFileLocation, CCCardNumber, Cardtype, CardExpDt, CardholderName, CardholderLastName, CardCode, BillingZip, BillingAdd,
                                            BillingCity, BillingState, PostingID, UserPackID, RegUID);
                    Session["NewSalePaymentID1"] = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PaymentID1"].ToString());
                    Session["NewSalePaymentID2"] = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PaymentID2"].ToString());
                }
                else
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    //int PSStatusID = 4;
                    //int pmntStatus = 1;
                    if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0.00")
                    {
                        pmntStatus = 8;
                    }
                    else
                    {
                        pmntStatus = 1;
                    }
                    string CCCardNumber = CardNumber.Text;
                    string CardExpDt = ExpMon.SelectedValue + "/" + CCExpiresYear.SelectedValue;
                    string CardholderName = objGeneralFunc.ToProper(txtCardholderName.Text);
                    string CardholderLastName = objGeneralFunc.ToProper(txtCardholderLastName.Text);
                    string CardCode = cvv.Text;
                    string BillingAdd = objGeneralFunc.ToProper(txtbillingaddress.Text);
                    string BillingCity = objGeneralFunc.ToProper(txtbillingcity.Text);
                    string BillingState = ddlbillingstate.SelectedItem.Value;
                    string BillingZip = txtbillingzip.Text;
                    DataSet dsSaveCCInfo = objdropdownBL.SaveCreditCardData(PackageID, CarID, PaymentScheduleDate, Amount, PaymentID1, PaymentType, pmntStatus, strIp,
                                            VoiceRecord, VoiceFileLocation, CCCardNumber, Cardtype, CardExpDt, CardholderName, CardholderLastName, CardCode, BillingZip,
                                            BillingAdd, BillingCity, BillingState, PostingID, UserPackID, RegUID);
                    Session["NewSalePaymentID1"] = Convert.ToInt32(dsSaveCCInfo.Tables[0].Rows[0]["PaymentID1"].ToString());
                    Session["NewSalePaymentID2"] = null;
                }
            }
            if (rdbtnPayPaypal.Checked == true)
            {
                DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                string Amount = txtPDAmountNow.Text;
                pmntStatus = 2;
                string TransID = txtPaytransID.Text;
                string PayPalEmailAcc = txtpayPalEmailAccount.Text;
                DataSet dsSavePayPalInfo = objdropdownBL.SavePayPalData(PackageID, CarID, PaymentScheduleDate, Amount, PaymentID1, PaymentType,
                                        pmntStatus, strIp, VoiceRecord, VoiceFileLocation, TransID, PayPalEmailAcc, PostingID, UserPackID, RegUID);
                Session["NewSalePaymentID1"] = Convert.ToInt32(dsSavePayPalInfo.Tables[0].Rows[0]["PaymentID"].ToString());
                Session["NewSalePaymentID2"] = null;
            }
            if (rdbtnPayCheck.Checked == true)
            {
                if (chkboxlstPDsale.Checked == true)
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;

                    //int PSStatusID = 4;
                    //int pmntStatus = 1;
                    if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0.00")
                    {
                        pmntStatus = 8;
                    }
                    else
                    {
                        pmntStatus = 1;
                    }
                    int AccType = Convert.ToInt32(ddlAccType.SelectedItem.Value);
                    string BankRouting = txtRoutingNumberForCheck.Text;
                    string bankName = txtBankNameForCheck.Text;
                    string AccNumber = txtAccNumberForCheck.Text;
                    string AccHolderName = txtCustNameForCheck.Text;
                    DateTime PDDate = Convert.ToDateTime(ddlPDDate.SelectedItem.Text);
                    //string PDPayAmountNow = txtPDAmountNow.Text;
                    string PDPayAmountLater = txtPDAmountLater.Text;
                    string CheckNumber = "";
                    int CheckType = Convert.ToInt32(5);
                    DataSet dsSaveCheckInfo = objdropdownBL.SaveCheckDataForPDSale(PackageID, CarID, PaymentScheduleDate, Amount, PDDate, PDPayAmountLater, PaymentID1, PaymentID2, PaymentType,
                                            pmntStatus, strIp, VoiceRecord, VoiceFileLocation, AccType, BankRouting, bankName, AccNumber, AccHolderName, PostingID, CheckType, CheckNumber, UserPackID, RegUID);

                    Session["NewSalePaymentID1"] = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PaymentID1"].ToString());
                    Session["NewSalePaymentID2"] = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PaymentID2"].ToString());
                }
                else
                {
                    DateTime PaymentScheduleDate = Convert.ToDateTime(txtPaymentDate.Text);
                    string Amount = txtPDAmountNow.Text;
                    if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0.00")
                    {
                        pmntStatus = 8;
                    }
                    else
                    {
                        pmntStatus = 1;
                    }
                    int AccType = Convert.ToInt32(ddlAccType.SelectedItem.Value);
                    string BankRouting = txtRoutingNumberForCheck.Text;
                    string bankName = txtBankNameForCheck.Text;
                    string AccNumber = txtAccNumberForCheck.Text;
                    string AccHolderName = txtCustNameForCheck.Text;
                    string CheckNumber = "";
                    int CheckType = Convert.ToInt32(5);
                    DataSet dsSaveCheckInfo = objdropdownBL.SaveCheckData(PackageID, CarID, PaymentScheduleDate, Amount, PaymentID1, PaymentType, pmntStatus, strIp, VoiceRecord,
                        VoiceFileLocation, AccType, BankRouting, bankName, AccNumber, AccHolderName, PostingID, CheckType, CheckNumber, UserPackID, RegUID);

                    Session["NewSalePaymentID1"] = Convert.ToInt32(dsSaveCheckInfo.Tables[0].Rows[0]["PaymentID1"].ToString());
                    Session["NewSalePaymentID2"] = null;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
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
        InputObject.Add("x_first_name", txtCardholderName.Text);
        InputObject.Add("x_last_name", txtCardholderLastName.Text);
        InputObject.Add("x_phone", txtPhone.Text);
        InputObject.Add("x_address", txtbillingaddress.Text);
        InputObject.Add("x_city", txtbillingcity.Text);
        InputObject.Add("x_state", ddlbillingstate.SelectedItem.Text);
        InputObject.Add("x_zip", txtbillingzip.Text);

        if (txtEmail.Text != "")
        {
            InputObject.Add("x_email", txtEmail.Text);
        }
        else
        {
            InputObject.Add("x_email", "info@unitedcarexchange.com");
        }

        InputObject.Add("x_email_customer", "TRUE");                     //Emails Customer
        InputObject.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
        InputObject.Add("x_country", "USA");
        InputObject.Add("x_customer_ip", Request.UserHostAddress);  //Store Customer IP Address

        //Amount
        string Package = string.Empty;
        if (ddlPackage.SelectedItem.Value.ToString() == "5")
        {
            Package = "Gold Deluxe Promo Package – No cancellations allowed; All sales are final";
        }
        else if (ddlPackage.SelectedItem.Value.ToString() == "4")
        {
            Package = "Silver Deluxe Promo Package – no cancellations and no refunds allowed; All sales are final";
        }
        else
        {
            Package = ddlPackage.SelectedItem.Text;
        }
        //var string = $('#ddlPackage option:selected').text();
        //var p =string.split('$');
        //var pp = p[1].split(')');
        ////alert(pp[0]);
        ////pp[0] = parseInt(pp[0]);
        //pp[0] = parseFloat(pp[0]);
        //var selectedPack = pp[0].toFixed(2);
        string PackCost = ddlPackage.SelectedItem.Text;
        string[] Pack = PackCost.Split('$');
        string[] FinalAmountSpl = Pack[1].Split(')');
        string FinalAmount = FinalAmountSpl[0].ToString();
        if (Convert.ToDouble(FinalAmount) != Convert.ToDouble(txtPDAmountNow.Text))
        {
            Package = Package + "- Partial payment -";
        }

        InputObject.Add("x_description", "Payment to " + Package);
        InputObject.Add("x_invoiceNumber", txtVoicefileConfirmNo.Text);
        //string.Format("{0:00}", Convert.ToDecimal(lblAdPrice2.Text))) + "Dollars
        //Description of Purchase

        //lblPackDescrip.Text 
        //Card Details
        InputObject.Add("x_card_num", CardNumber.Text);
        InputObject.Add("x_exp_date", ExpMon.SelectedItem.Text + "/" + CCExpiresYear.SelectedItem.Text);
        InputObject.Add("x_card_code", cvv.Text);

        InputObject.Add("x_method", "CC");
        InputObject.Add("x_type", "AUTH_CAPTURE");

        InputObject.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(txtPDAmountNow.Text)));

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

                ///Successs 

                string AuthNetCode = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                string AuthNetTransID = ReturnValues[6].Trim(char.Parse("|")); // Returned Transaction ID

                //Response.Redirect("PaymentSucces.aspx?NetCode=" + ReturnValues[4].Trim(char.Parse("|")) + "&tx=" + ReturnValues[6].Trim(char.Parse("|")) + "&amt=" + txtPDAmountNow.Text + "&item_number=" + Session["PackageID"].ToString() + "");

                string PayInfo = "Authorisation Code" + ReturnValues[4].Trim(char.Parse("|")) + "</br>TransID=" + ReturnValues[6].Trim(char.Parse("|")) + "</br>"; // Returned Authorisation Code;
                string PayNotes = "Authorisation Code " + ReturnValues[4].Trim(char.Parse("|")) + " <br> TransID=" + ReturnValues[6].Trim(char.Parse("|")); // Returned Authorisation Code;                
                string Result = "Paid";
                string PackCost1 = ddlPackage.SelectedItem.Text;
                string[] Pack1 = PackCost1.Split('$');
                string[] FinalAmountSpl1 = Pack1[1].Split(')');
                string FinalAmount1 = FinalAmountSpl1[0].ToString();
                int PmntStatus = 1;
                int AdActive;
                int UceStatus;
                int MultisiteStatus;
                int ListingStatus;
                if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0.00")
                {
                    Result = "NoPayDue";
                    PmntStatus = 8;
                    AdActive = 0;
                    UceStatus = 0;
                    ListingStatus = 2;
                    MultisiteStatus = 0;
                }
                else if (Convert.ToDouble(FinalAmount1) != Convert.ToDouble(txtPDAmountNow.Text))
                {
                    Result = "PartialPaid";
                    PmntStatus = 7;
                    AdActive = 0;
                    UceStatus = 0;
                    ListingStatus = 2;
                    MultisiteStatus = 0;
                }
                else
                {
                    Result = "Paid";
                    PmntStatus = 2;
                    AdActive = 1;
                    UceStatus = 0;
                    ListingStatus = 1;
                    if ((ddlPackage.SelectedItem.Value == "4") || (ddlPackage.SelectedItem.Value == "5") || (ddlPackage.SelectedItem.Value == "6"))
                    {
                        MultisiteStatus = 1;
                    }
                    else
                    {
                        MultisiteStatus = 0;
                    }
                }
                int PaymentID = Convert.ToInt32(Session["NewSalePaymentID1"].ToString());
                int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                int CarID = Convert.ToInt32(Session["CarID"].ToString());
                DataSet dsPaymentSave = objdropdownBL.SavePaymentInfoForNewSaleProcess(txtPDAmountNow.Text, PaymentID, PmntStatus, AuthNetTransID, PostingID, CarID,
                    PayNotes, AdActive, ListingStatus, UceStatus, MultisiteStatus);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = PayInfo + "Customer details saved successfully with carid " + Session["CarID"].ToString();
                return true;
            }
            else
            {
                ///Failure
                // Error!
                ErrorString = ReturnValues[3].Trim(char.Parse("|")) + " (" + ReturnValues[2].Trim(char.Parse("|")) + ") " + ReturnValues[4].Trim(char.Parse("|"));

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

                Session["PayCancelError"] = ErrorString;
                ErrorString = "Payment is DECLINED <br /> " + ErrorString;
                int CarID = Convert.ToInt32(Session["CarID"].ToString());
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                String UpdatedBy = Session[Constants.NAME].ToString();
                string InternalNotesNew = ErrorString;
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = ErrorString + " <br />Customer details saved successfully with carid " + Session["CarID"].ToString();
                return false;
            }
        }
        catch (Exception ex)
        {
            //CustomValidator1.ErrorMessage = ex.Message;
            return false;
        }
    }

    private void GoWithCheck()
    {
        try
        {
            // By default, this sample code is designed to post to our test server for
            // developer accounts: https://test.authorize.net/gateway/transact.dll
            // for real accounts (even in test mode), please make sure that you are
            string post_url = "https://secure.authorize.net/gateway/transact.dll";
            //String post_url = "https://test.authorize.net/gateway/transact.dll";

            //The valid routing number of the customer’s bank 9 digits
            string sBankCode = string.Empty;
            sBankCode = txtRoutingNumberForCheck.Text;

            //The customer’s valid bank account number Up to 20 digits The customer’s checking,
            string sBankaccountnumber = string.Empty;
            sBankaccountnumber = txtAccNumberForCheck.Text;
            //The type of bank account CHECKING,BUSINESSCHECKING,SAVINGS
            string sBankType = ddlAccType.SelectedItem.Text;


            //The name of the bank that holds the customer’s account Up to 50 characters
            string sbank_name = txtBankNameForCheck.Text;

            //The name of the bank that holds the customer’s account Up to 50 characters
            string sbank_acct_name = txtCustNameForCheck.Text;
            //The type of electronic check payment request.Types," page 10 of this document.
            //ARC, BOC, CCD, PPD, TEL,WEB
            string echeck_type = "TEL";

            string sbank_check_number = "";




            string AuthNetVersion = "3.1"; // Contains CCV support
            string AuthNetLoginID = "9FtTpx88g879"; //Set your AuthNetLoginID here
            string AuthNetTransKey = "9Gp3Au9t97Wvb784";  // Get this from your authorize.net merchant interface


            Dictionary<string, string> post_values = new Dictionary<string, string>();
            //the API Login ID and Transaction Key must be replaced with valid values

            post_values.Add("x_login", AuthNetLoginID);
            post_values.Add("x_tran_key", AuthNetTransKey);
            post_values.Add("x_delim_data", "TRUE");
            post_values.Add("x_delim_char", "|");
            post_values.Add("x_relay_response", "FALSE");

            post_values.Add("x_type", "AUTH_CAPTURE");
            post_values.Add("x_method", "ECHECK");
            post_values.Add("x_bank_aba_code", sBankCode);
            post_values.Add("x_bank_acct_num", sBankaccountnumber);
            post_values.Add("x_bank_acct_type", sBankType);

            post_values.Add("x_bank_name", sbank_name);
            post_values.Add("x_bank_acct_name", sbank_acct_name);
            post_values.Add("x_echeck_type", echeck_type);
            post_values.Add("x_bank_check_number", sbank_check_number);

            post_values.Add("x_recurring_billing", "False");

            string Package = string.Empty;
            if (ddlPackage.SelectedItem.Value.ToString() == "5")
            {
                Package = "Gold Deluxe Promo Package – No cancellations allowed; All sales are final";
            }
            else if (ddlPackage.SelectedItem.Value.ToString() == "4")
            {
                Package = "Silver Deluxe Promo Package – no cancellations and no refunds allowed; All sales are final";
            }
            else
            {
                Package = ddlPackage.SelectedItem.Text;
            }

            string PackCost = ddlPackage.SelectedItem.Text;
            string[] Pack = PackCost.Split('$');
            string[] FinalAmountSpl = Pack[1].Split(')');
            string FinalAmount = FinalAmountSpl[0].ToString();
            if (Convert.ToDouble(FinalAmount) != Convert.ToDouble(txtPDAmountNow.Text))
            {
                Package = Package + "- Partial payment -";
            }

            post_values.Add("x_amount", string.Format("{0:c2}", Convert.ToDouble(txtPDAmountNow.Text)));
            //post_values.Add("x_amount", txtPDAmountNow.Text);
            post_values.Add("x_description", Package);
            post_values.Add("x_merchant_email", "shravan@datumglobal.net");  //Emails Merchant
            post_values.Add("x_first_name", txtFirstName.Text);
            post_values.Add("x_last_name", txtLastName.Text);
            post_values.Add("x_address", txtAddress.Text);
            post_values.Add("x_state", ddlLocationState.SelectedItem.Text);
            post_values.Add("x_zip", txtZip.Text);
            post_values.Add("x_city", txtCity.Text);
            post_values.Add("x_phone", txtPhone.Text);
            // Additional fields can be added here as outlined in the AIM integration
            // guide at: http://developer.authorize.net

            // This section takes the input fields and converts them to the proper format
            // for an http post.  For example: "x_login=username&x_tran_key=a1B2c3D4"
            String post_string = "";

            foreach (KeyValuePair<string, string> post_value in post_values)
            {
                post_string += post_value.Key + "=" + HttpUtility.UrlEncode(post_value.Value) + "&";
            }
            post_string = post_string.TrimEnd('&');

            // The following section provides an example of how to add line item details to
            // the post string.  Because line items may consist of multiple values with the
            // same key/name, they cannot be simply added into the above array.
            //
            // This section is commented out by default.
            /*
            string[] line_items = {
                "item1<|>golf balls<|><|>2<|>18.95<|>Y",
                "item2<|>golf bag<|>Wilson golf carry bag, red<|>1<|>39.99<|>Y",
                "item3<|>book<|>Golf for Dummies<|>1<|>21.99<|>Y"};
            foreach( string value in line_items )
            {
                post_string += "&x_line_item=" + HttpUtility.UrlEncode(value);
            }
            */

            // create an HttpWebRequest object to communicate with Authorize.net
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(post_url);
            objRequest.Method = "POST";
            objRequest.ContentLength = post_string.Length;
            objRequest.ContentType = "application/x-www-form-urlencoded";

            // post data is sent as a stream
            StreamWriter myWriter = null;
            myWriter = new StreamWriter(objRequest.GetRequestStream());
            myWriter.Write(post_string);
            myWriter.Close();

            // returned values are returned as a stream, then read into a string
            String post_response;
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                post_response = responseStream.ReadToEnd();
                responseStream.Close();
            }

            // the response string is broken into an array
            // The split character specified here must match the delimiting character specified above
            Array response_array = post_response.Split('|');
            string resultSpan = string.Empty;
            // the results are output to the screen in the form of an html numbered list.
            resultSpan += response_array.GetValue(3) + "(Response Code " + response_array.GetValue(0) + ")" + "(Response Reason Code " + response_array.GetValue(2) + ")";
            //foreach (string value in response_array)
            //{
            //    resultSpan += "<LI>" + value + "&nbsp;</LI> \n";
            //}
            //resultSpan += "</OL> \n";
            // individual elements of the array could be accessed to read certain response
            // fields.  For example, response_array[0] would return the Response Code,
            // response_array[2] would return the Response Reason Code.
            // for a list of response fields, please review the AIM Implementation Guide
            if (response_array.GetValue(0).ToString() == "1")
            {
                //Success
                //string AuthNetCode = ReturnValues[4].Trim(char.Parse("|")); // Returned Authorisation Code
                string AuthNetTransID = response_array.GetValue(6).ToString(); // Returned Transaction ID
                string PayInfo = "TransID=" + AuthNetTransID + "</br>"; // Returned Authorisation Code;
                string PayNotes = "TransID=" + AuthNetTransID; // Returned Authorisation Code;                
                string Result = "Paid";
                string PackCost1 = ddlPackage.SelectedItem.Text;
                string[] Pack1 = PackCost1.Split('$');
                string[] FinalAmountSpl1 = Pack1[1].Split(')');
                string FinalAmount1 = FinalAmountSpl1[0].ToString();
                int PmntStatus = 1;
                int AdActive;
                int UceStatus;
                int MultisiteStatus;
                int ListingStatus;
                if (Convert.ToDouble(txtPDAmountNow.Text).ToString() == "0.00")
                {
                    Result = "NoPayDue";
                    PmntStatus = 8;
                    AdActive = 0;
                    UceStatus = 0;
                    ListingStatus = 2;
                    MultisiteStatus = 0;
                }
                else if (Convert.ToDouble(FinalAmount1) != Convert.ToDouble(txtPDAmountNow.Text))
                {
                    Result = "PartialPaid";
                    PmntStatus = 7;
                    AdActive = 0;
                    UceStatus = 0;
                    ListingStatus = 2;
                    MultisiteStatus = 0;
                }
                else
                {
                    Result = "Paid";
                    PmntStatus = 2;
                    AdActive = 1;
                    UceStatus = 0;
                    ListingStatus = 1;
                    if ((ddlPackage.SelectedItem.Value == "4") || (ddlPackage.SelectedItem.Value == "5") || (ddlPackage.SelectedItem.Value == "6"))
                    {
                        MultisiteStatus = 1;
                    }
                    else
                    {
                        MultisiteStatus = 0;
                    }
                }
                int PaymentID = Convert.ToInt32(Session["NewSalePaymentID1"].ToString());
                int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                int CarID = Convert.ToInt32(Session["CarID"].ToString());
                DataSet dsPaymentSave = objdropdownBL.SavePaymentInfoForNewSaleProcess(txtPDAmountNow.Text, PaymentID, PmntStatus, AuthNetTransID, PostingID, CarID,
                    PayNotes, AdActive, ListingStatus, UceStatus, MultisiteStatus);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = PayInfo + "Customer details saved successfully with carid " + Session["CarID"].ToString();

            }
            else
            {
                Session["PayCancelError"] = resultSpan;
                string ErrorString = "Payment is DECLINED <br /> " + resultSpan;
                int CarID = Convert.ToInt32(Session["CarID"].ToString());
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                String UpdatedBy = Session[Constants.NAME].ToString();
                string InternalNotesNew = ErrorString;
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = ErrorString + " <br />Customer details saved successfully with carid " + Session["CarID"].ToString();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("SearchNew.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void ImgBtnLogo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Response.Redirect("Index.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDraftPhNoYes_Click(object sender, EventArgs e)
    {
        try
        {
            int LeadStatus;
            if (Session["NewAbandonRedirect"].ToString() == "Draft")
            {
                LeadStatus = Convert.ToInt32(3);
                DataSet dsUsers = Session["dsUserExists"] as DataSet;
                Session["NewSaleCarID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["carid"].ToString());
                Session["NewSaleUID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["uid"].ToString());
                Session["NewSalePostingID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["postingID"].ToString());
                Session["NewSaleUserPackID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["UserPackID"].ToString());
                Session["NewSaleSellerID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["sellerID"].ToString());
                Session["NewSalePSID1"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["PSID1"].ToString());
                Session["NewSalePSID2"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["PSID2"].ToString());
                Session["NewSalePaymentID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["PaymentID"].ToString());
                int SaleAgentID = 0;

            }
            if (Session["NewAbandonRedirect"].ToString() == "Abandon")
            {
                LeadStatus = Convert.ToInt32(2);
                DataSet dsUsers = Session["dsUserExists"] as DataSet;
                Session["NewSaleCarID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["carid"].ToString());
                Session["NewSaleUID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["uid"].ToString());
                Session["NewSalePostingID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["postingID"].ToString());
                Session["NewSaleUserPackID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["UserPackID"].ToString());
                Session["NewSaleSellerID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["sellerID"].ToString());
                Session["NewSalePSID1"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["PSID1"].ToString());
                Session["NewSalePSID2"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["PSID2"].ToString());
                Session["NewSalePaymentID"] = Convert.ToInt32(dsUsers.Tables[0].Rows[0]["PaymentID"].ToString());
                int SaleAgentID = 0;

                Response.Redirect("NewSale.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //protected void btnDraftPhNoNo_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected void BtnClsUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("AddCarNewForm.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbtnPayVisa_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                // divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            CardType.Value = "VisaCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objdropdownBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            //txtBillingname.Text = "";
            //txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();

            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayMasterCard_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                // divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            CardType.Value = "MasterCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objdropdownBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            // txtBillingname.Text = "";
            // txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayDiscover_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                //divpdDate.Style["display"] = "block";
            }
            else
            {
                //divpdDate.Style["display"] = "none";
            }
            CardType.Value = "DiscoverCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objdropdownBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            //txtBillingname.Text = "";
            //  txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();
            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayAmex_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "block";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                //divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            CardType.Value = "AmExCard";
            CardNumber.Text = "";
            txtCardholderName.Text = "";
            CardNumber.Text = "";
            ListItem limonth = new ListItem();
            limonth.Text = "Select Month";
            limonth.Value = "0";
            ExpMon.SelectedIndex = ExpMon.Items.IndexOf(limonth);
            DataSet dsYears = objdropdownBL.USP_GetNext12years();
            fillYears(dsYears);
            cvv.Text = "";
            //txtBillingname.Text = "";
            //txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";
            FillBillingStates();

            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayPaypal_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "none";
            divcheck.Style["display"] = "none";
            divpaypal.Style["display"] = "block";
            if (chkboxlstPDsale.Checked == true)
            {
                // divpdDate.Style["display"] = "block";
            }
            else
            {
                //divpdDate.Style["display"] = "none";
            }
            //FillPaymentDate();
            txtPaytransID.Text = "";
            //txtPayAmount.Text = "";
            txtpayPalEmailAccount.Text = "";

            chkboxlstPDsale.Enabled = false;
            ddlPDDate.Enabled = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnPayCheck_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            divcard.Style["display"] = "none";
            divcheck.Style["display"] = "block";
            divpaypal.Style["display"] = "none";
            if (chkboxlstPDsale.Checked == true)
            {
                //divpdDate.Style["display"] = "block";
            }
            else
            {
                // divpdDate.Style["display"] = "none";
            }
            txtBankNameForCheck.Text = "";
            ListItem liAccType = new ListItem();
            liAccType.Text = "Select";
            liAccType.Value = "0";
            ddlAccType.SelectedIndex = ddlAccType.Items.IndexOf(liAccType);
            ListItem liCheckType = new ListItem();
            liCheckType.Text = "Select";
            liCheckType.Value = "0";
            //ddlCheckType.SelectedIndex = ddlCheckType.Items.IndexOf(liCheckType);
            //txtCheckNumber.Text = "";
            txtCustNameForCheck.Text = "";
            txtAccNumberForCheck.Text = "";
            txtRoutingNumberForCheck.Text = "";

            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void chkboxlstPDsale_CheckedChanged(object sender, EventArgs e)
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
