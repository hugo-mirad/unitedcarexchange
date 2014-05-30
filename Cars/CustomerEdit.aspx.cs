
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
public partial class CustomerEdit : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
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
                if (Session["RedirectFrom"].ToString() == "1")
                {
                    lblViewCustDataHeading.Text = "Attending to a Customer Call";
                }
                if (Session["RedirectFrom"].ToString() == "2")
                {
                    lblViewCustDataHeading.Text = "Attending a Welcome Call";
                }
                if (Session["RedirectFrom"].ToString() == "3")
                {
                    lblViewCustDataHeading.Text = "Attending to a Ticket";
                }
                if (Session["RedirectFrom"].ToString() == "4")
                {
                    lblViewCustDataHeading.Text = "Attending to a Customer Service Call";
                }
                if (Session["RedirectFrom"].ToString() == "5")
                {
                    lblViewCustDataHeading.Text = "Attending to a Post Date Payment";
                }
                if (Session["RedirectFrom"].ToString() == "6")
                {
                    lblViewCustDataHeading.Text = "Attending to a 30 Days Review Call";
                }
                if (Session["RedirectFrom"].ToString() == "7")
                {
                    lblViewCustDataHeading.Text = "Attending to a 60 Days Review Call";
                }

                Session.Timeout = 180;
                SmartzTicketDdlDs = objdropdownBL.USP_SmartzTicketDropDown();
                Session["TicketDdl"] = SmartzTicketDdlDs;
                FillTicketDropdown();
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                GetAllModels();
                GetMakes();
                FillPackage();
                GetModelsInfo();
                FillStates();
                FillExteriorColor();
                FillInteriorColor();
                GetBody();
                FillYear();
                FillCylinders();
                FillCondition();
                FillFuelTypes();
                FillDoors();
                FillTransmissions();
                FillDriveTrain();
                FillPayStatus();
                FillPaymentDate();
                FillPayType();
                FillRegStates();
                int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                CarsDetails = objdropdownBL.USP_GetCustomerDetailsByPostingID(PostingID);
                Session["EditCarDetailsDataset"] = CarsDetails;
                //int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());
                if (CarsDetails.Tables.Count > 0)
                {
                    if (CarsDetails.Tables[0].Rows.Count > 0)
                    {
                        if (CarsDetails.Tables[0].Rows[0]["DealerCode"].ToString() != "")
                        {
                            divHeaderNote.Style["display"] = "block";
                            lblHeaderNote.Text = "It is a dealer car from " + CarsDetails.Tables[0].Rows[0]["DealerCode"].ToString();
                        }
                        else
                        {
                            divHeaderNote.Style["display"] = "none";
                        }
                        Session["EditUID"] = CarsDetails.Tables[0].Rows[0]["uid"].ToString();
                        Session["EditCarID"] = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        Session["EditsellerID"] = CarsDetails.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["EditUserPackID"] = CarsDetails.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["EditPackageID"] = CarsDetails.Tables[0].Rows[0]["packageID"].ToString();
                        hdnPackageID.Value = CarsDetails.Tables[0].Rows[0]["packageID"].ToString();
                        lblCarID.Text = CarsDetails.Tables[0].Rows[0]["carid"].ToString();

                        if (CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString().Trim() == "NULL" || CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString().Trim() == "")
                        {
                            lblBrand.Text = "UCE";
                        }
                        else
                        {
                            lblBrand.Text = CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString().Trim();
                        }
                        DateTime PostDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["dateOfPosting"].ToString());
                        lblPostingDate.Text = PostDate.ToString("MM/dd/yyyy");
                        DateTime SaleDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["SaleDate"].ToString());
                        lblSaleDate.Text = SaleDate.ToString("MM/dd/yyyy hh:mm:ss tt");

                        if (CarsDetails.Tables[0].Rows[0]["LastUpdatedDate"].ToString() != "")
                        {
                            DateTime LastUpdateDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["LastUpdatedDate"].ToString());
                            lblLastUpdated.Text = LastUpdateDate.ToString("MM/dd/yyyy hh:mm:ss tt");
                        }

                        if (CarsDetails.Tables[0].Rows[0]["PaymentDate"].ToString() != "")
                        {
                            DateTime PaymentDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["PaymentDate"].ToString());
                            lblPaymentDate.Text = PaymentDate.ToString("MM/dd/yyyy");
                        }
                        if (CarsDetails.Tables[0].Rows[0]["PDDate"].ToString() != "")
                        {
                            DateTime PDDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["PDDate"].ToString());
                            lblPDDate.Text = PDDate.ToString("MM/dd/yyyy");
                            Session["EditPDDate"] = PDDate;
                        }
                        if (CarsDetails.Tables[0].Rows[0]["CarsalesID"].ToString() != "")
                        {
                            lblCarsalesID.Text = CarsDetails.Tables[0].Rows[0]["CarsalesID"].ToString();
                        }
                        else
                        {
                            lblCarsalesID.Text = "0";
                        }
                        txtAgent.Text = CarsDetails.Tables[0].Rows[0]["ReferCode"].ToString();
                        lblSalesAgent.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        txtVerifier.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["VerifierID"].ToString());
                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["PackagePrice"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = CarsDetails.Tables[0].Rows[0]["PackageName"].ToString();

                        //ListItem listPack = new ListItem();
                        //listPack.Value = CarsDetails.Tables[0].Rows[0]["packageID"].ToString();
                        //listPack.Text = PackName + "($" + PackAmount + ")";
                        //ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(listPack);
                        lblPackage.Text = PackName + "($" + PackAmount + ")";

                        //txtCustName.Text = CarsDetails.Tables[0].Rows[0]["sellerName"].ToString();
                        txtCustPhoneNumber.Text = CarsDetails.Tables[0].Rows[0]["phone"].ToString();
                        txtCustAltNumber.Text = CarsDetails.Tables[0].Rows[0]["altPhone"].ToString();
                        txtSellerEmail.Text = CarsDetails.Tables[0].Rows[0]["email"].ToString();
                        //txtCustAddress.Text = CarsDetails.Tables[0].Rows[0]["address1"].ToString();
                        txtCity.Text = CarsDetails.Tables[0].Rows[0]["city"].ToString();

                        ListItem list5 = new ListItem();
                        list5.Value = CarsDetails.Tables[0].Rows[0]["state"].ToString();
                        list5.Text = CarsDetails.Tables[0].Rows[0]["state"].ToString();
                        ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(list5);

                        txtZip.Text = CarsDetails.Tables[0].Rows[0]["zip"].ToString();

                        ListItem list2 = new ListItem();
                        list2.Value = CarsDetails.Tables[0].Rows[0]["makeID"].ToString();
                        list2.Text = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        ddlMake.SelectedIndex = ddlMake.Items.IndexOf(list2);

                        GetModelsInfo();

                        ListItem list3 = new ListItem();
                        list3.Text = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                        list3.Value = CarsDetails.Tables[0].Rows[0]["makeModelID"].ToString();
                        ddlModel.SelectedIndex = ddlModel.Items.IndexOf(list3);

                        ListItem list1 = new ListItem();
                        list1.Text = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();
                        list1.Value = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();
                        ddlYear.SelectedIndex = ddlYear.Items.IndexOf(list1);

                        txtTitle.Text = CarsDetails.Tables[0].Rows[0]["Title"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["price"].ToString() == "0.0000")
                        {
                            txtAskingPrice.Text = "";
                        }
                        else
                        {
                            txtAskingPrice.Text = string.Format("{0:0}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["price"].ToString()));
                        }
                        if (txtAskingPrice.Text.Length > 6)
                        {
                            txtAskingPrice.Text = txtAskingPrice.Text.Substring(0, 6);
                        }

                        if (CarsDetails.Tables[0].Rows[0]["mileage"].ToString() == "0.00")
                        {
                            txtMileage.Text = "";
                        }
                        else
                        {
                            txtMileage.Text = string.Format("{0:0}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["mileage"].ToString()));
                        }
                        if (txtMileage.Text.Length > 6)
                        {
                            txtMileage.Text = txtMileage.Text.Substring(0, 6);
                        }

                        ListItem list7 = new ListItem();
                        list7.Value = CarsDetails.Tables[0].Rows[0]["exteriorColor"].ToString();
                        list7.Text = CarsDetails.Tables[0].Rows[0]["exteriorColor"].ToString();
                        ddlExteriorColor.SelectedIndex = ddlExteriorColor.Items.IndexOf(list7);

                        ListItem list8 = new ListItem();
                        list8.Text = CarsDetails.Tables[0].Rows[0]["interiorColor"].ToString();
                        list8.Value = CarsDetails.Tables[0].Rows[0]["interiorColor"].ToString();
                        ddlInteriorColor.SelectedIndex = ddlInteriorColor.Items.IndexOf(list8);

                        ListItem list4 = new ListItem();
                        list4.Value = CarsDetails.Tables[0].Rows[0]["bodyTypeID"].ToString();
                        list4.Text = CarsDetails.Tables[0].Rows[0]["bodyType"].ToString();
                        ddlBodyStyle.SelectedIndex = ddlBodyStyle.Items.IndexOf(list4);


                        ListItem list9 = new ListItem();
                        list9.Value = CarsDetails.Tables[0].Rows[0]["numberOfCylinder"].ToString();
                        list9.Text = CarsDetails.Tables[0].Rows[0]["numberOfCylinder"].ToString();
                        ddlCylinderCount.SelectedIndex = ddlCylinderCount.Items.IndexOf(list9);

                        ListItem list11 = new ListItem();
                        list11.Value = CarsDetails.Tables[0].Rows[0]["Transmission"].ToString();
                        list11.Text = CarsDetails.Tables[0].Rows[0]["Transmission"].ToString();
                        ddlTransmission.SelectedIndex = ddlTransmission.Items.IndexOf(list11);

                        ListItem list12 = new ListItem();
                        list12.Value = CarsDetails.Tables[0].Rows[0]["DriveTrain"].ToString();
                        list12.Text = CarsDetails.Tables[0].Rows[0]["DriveTrain"].ToString();
                        ddlDriveTrain.SelectedIndex = ddlDriveTrain.Items.IndexOf(list12);

                        ListItem list10 = new ListItem();
                        list10.Value = CarsDetails.Tables[0].Rows[0]["NumberOfDoors"].ToString();
                        list10.Text = CarsDetails.Tables[0].Rows[0]["NumberOfDoors"].ToString();
                        ddlDoorCount.SelectedIndex = ddlDoorCount.Items.IndexOf(list10);

                        ListItem list6 = new ListItem();
                        list6.Value = CarsDetails.Tables[0].Rows[0]["fuelTypeID"].ToString();
                        list6.Text = CarsDetails.Tables[0].Rows[0]["fuelType"].ToString();
                        ddlFuelType.SelectedIndex = ddlFuelType.Items.IndexOf(list6);

                        txtVinNumber.Text = CarsDetails.Tables[0].Rows[0]["VIN"].ToString();

                        for (int i = 1; i < 52; i++)
                        {
                            string ChkBoxID = "chkFeatures" + i.ToString();
                            CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                            if (CarsDetails.Tables[3].Rows.Count >= i)
                            {
                                if (CarsDetails.Tables[3].Rows[i - 1]["Isactive"].ToString() == "True")
                                {
                                    ChkedBox.Checked = true;
                                }
                                else
                                {
                                    ChkedBox.Checked = false;
                                }
                            }
                            else
                            {
                                ChkedBox.Checked = false;
                            }
                        }

                        ListItem list13 = new ListItem();
                        list13.Value = CarsDetails.Tables[0].Rows[0]["ConditionID"].ToString();
                        list13.Text = CarsDetails.Tables[0].Rows[0]["ConditionDescription"].ToString();
                        ddlCondition.SelectedIndex = ddlCondition.Items.IndexOf(list13);
                        string CarDescription = CarsDetails.Tables[0].Rows[0]["description"].ToString();
                        txtDescription.Text = CarDescription;

                        HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/SearchCarDetails.aspx?Make=" + CarsDetails.Tables[0].Rows[0]["make"].ToString() + "&Model=" + CarsDetails.Tables[0].Rows[0]["model"].ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + CarsDetails.Tables[0].Rows[0]["carId"].ToString();
                        HylinkUCE.Target = "blank";

                        txtLoginEmail.Text = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        txtLoginPassword.Text = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();

                        txtRegName.Text = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        txtRegBusinessName.Text = CarsDetails.Tables[0].Rows[0]["BusinessName"].ToString();
                        txtRegAltEmail.Text = CarsDetails.Tables[0].Rows[0]["AltEmail"].ToString();
                        txtRegPhNo.Text = CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        txtRegAltPhoneNum.Text = CarsDetails.Tables[0].Rows[0]["RegAltPhone"].ToString();

                        txtRegAddress.Text = CarsDetails.Tables[0].Rows[0]["Address"].ToString();
                        txtRegCity.Text = CarsDetails.Tables[0].Rows[0]["RegCity"].ToString();

                        ListItem listRegState = new ListItem();
                        listRegState.Value = CarsDetails.Tables[0].Rows[0]["StateID"].ToString();
                        listRegState.Text = CarsDetails.Tables[0].Rows[0]["State_Code"].ToString();
                        ddlRegState.SelectedIndex = ddlRegState.Items.IndexOf(listRegState);
                        txtregZip.Text = CarsDetails.Tables[0].Rows[0]["RegZip"].ToString();

                        txtRegUserID.Text = CarsDetails.Tables[0].Rows[0]["UserID"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                        {
                            chkbxEMailNA.Checked = true;
                            txtLoginEmail.Enabled = false;
                        }
                        else
                        {
                            chkbxEMailNA.Checked = false;
                            txtLoginEmail.Enabled = true;
                        }

                        string OldNotes = CarsDetails.Tables[0].Rows[0]["InternalNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtOldIntNotes.Text = OldNotes;

                        Session["RegUserName"] = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        Session["RegPassword"] = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        Session["RegName"] = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        Session["CustViewCarID"] = CarsDetails.Tables[0].Rows[0]["carId"].ToString();
                        int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());
                        tdThumb.Style["display"] = "block";
                        trShowPhotoCount.Style["display"] = "block";

                        string StockMake = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        StockMake = StockMake.Replace(" ", "-");
                        string StockModel = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                        StockModel = StockModel.Replace("/", "@");
                        StockModel = StockModel.Replace(" ", "-");
                        string StockUrl = "http://unitedcarexchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockModel + ".jpg";
                        ImgStockPhoto.ImageUrl = StockUrl;
                        int ImagesHaveCount = 0;
                        for (int i = 1; i < TotalImgCount + 1; i++)
                        {
                            string RowIDName = "trImg" + i.ToString();
                            System.Web.UI.HtmlControls.HtmlTableRow RowID = (System.Web.UI.HtmlControls.HtmlTableRow)form1.FindControl(RowIDName);
                            //RowID.Style["display"] = "block";
                            string ImgID = "Img" + i.ToString();
                            string lblID = "lblImg" + i.ToString();
                            string ColumnPic = "pic" + i.ToString();
                            string ColumnPicName = "PIC" + i.ToString();
                            string ColumnPicLocation = "PICLOC" + i.ToString();
                            System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                            System.Web.UI.WebControls.Label LabelName = (System.Web.UI.WebControls.Label)form1.FindControl(lblID);
                            string SelModelDis = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                            SelModelDis = SelModelDis.Replace("/", "@");
                            //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                            if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                            {
                                ImagesHaveCount = ImagesHaveCount + 1;
                            }
                            if (i < 4)
                            {
                                RowID.Style["display"] = "block";

                                if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                                {
                                    LabelName.Visible = false;
                                    ImageName.Visible = true;
                                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString() + CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                                }
                                else
                                {
                                    ImageName.Visible = false;
                                    LabelName.Visible = true;
                                }
                            }
                        }
                        lblTotPhotosUploaded.Text = ImagesHaveCount.ToString();
                        if (ImagesHaveCount > 3)
                        {
                            trShowall.Style["display"] = "block";
                        }
                        else
                        {
                            trShowall.Style["display"] = "none";
                        }

                        if (CarsDetails.Tables[2].Rows.Count > 0)
                        {
                            lblPayConfirmNo.Text = CarsDetails.Tables[2].Rows[0]["TransactionID"].ToString();
                            lblVoiceFileName.Text = CarsDetails.Tables[2].Rows[0]["VoiceRecord"].ToString();
                            lblPayAmount.Text = CarsDetails.Tables[2].Rows[0]["Amount"].ToString();
                            ListItem liPayStatus = new ListItem();
                            liPayStatus.Value = CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString();
                            liPayStatus.Text = CarsDetails.Tables[2].Rows[0]["pmntStatus"].ToString();
                            ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatus);

                            ListItem liPayMethod = new ListItem();
                            liPayMethod.Value = CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString();
                            liPayMethod.Text = CarsDetails.Tables[2].Rows[0]["pmntType"].ToString();
                            ddlPayMethod.SelectedIndex = ddlPayMethod.Items.IndexOf(liPayMethod);

                            Session["PaymentID"] = CarsDetails.Tables[2].Rows[0]["pmntID"].ToString();

                            if (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "2")
                            {
                                ListItem liPayStatusPend = new ListItem();
                                liPayStatusPend.Value = "1";
                                liPayStatusPend.Text = "Pending";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusPend);
                                ListItem liPayStatusPremli = new ListItem();
                                liPayStatusPremli.Value = "5";
                                liPayStatusPremli.Text = "Preliminary";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusPremli);
                                ListItem liPayStatusCancel = new ListItem();
                                liPayStatusCancel.Value = "6";
                                liPayStatusCancel.Text = "Admin Cancel";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusCancel);
                            }
                            if (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "5")
                            {
                                ListItem liPayStatusPend = new ListItem();
                                liPayStatusPend.Value = "1";
                                liPayStatusPend.Text = "Pending";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusPend);
                                ListItem liPayStatusRefund = new ListItem();
                                liPayStatusRefund.Value = "3";
                                liPayStatusRefund.Text = "Refund";
                                ddlPayStatus.Items.Remove(liPayStatusRefund);
                                ListItem liPayStatusChargeBack = new ListItem();
                                liPayStatusChargeBack.Value = "4";
                                liPayStatusChargeBack.Text = "Chargeback";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusChargeBack);
                            }

                            if (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "1")
                            {
                                ListItem liPayStatusPend = new ListItem();
                                liPayStatusPend.Value = "5";
                                liPayStatusPend.Text = "Preliminary";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusPend);
                                ListItem liPayStatusRefund = new ListItem();
                                liPayStatusRefund.Value = "3";
                                liPayStatusRefund.Text = "Refund";
                                ddlPayStatus.Items.Remove(liPayStatusRefund);
                                ListItem liPayStatusChargeBack = new ListItem();
                                liPayStatusChargeBack.Value = "4";
                                liPayStatusChargeBack.Text = "Chargeback";
                                //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                ddlPayStatus.Items.Remove(liPayStatusChargeBack);
                            }
                            if (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "3")
                            {
                                ddlPayStatus.Enabled = false;
                            }
                            if (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "4")
                            {
                                ddlPayStatus.Enabled = false;
                            }
                            if (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "6")
                            {
                                ddlPayStatus.Enabled = false;
                            }
                            Session["EditPayStatus"] = CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString();
                            hdnPayStatus.Value = Session["EditPayStatus"].ToString();
                            GetDataStatus();
                        }
                        if (CarsDetails.Tables[10].Rows.Count > 0)
                        {
                            hdnPDpayStatus.Value = CarsDetails.Tables[10].Rows[0]["pmntStatusID"].ToString();
                            hdnPDAmount.Value = CarsDetails.Tables[10].Rows[0]["Amount"].ToString();
                            hdnPDID.Value = CarsDetails.Tables[10].Rows[0]["pmntID"].ToString();
                        }
                        else
                        {
                            hdnPDpayStatus.Value = "";
                            hdnPDAmount.Value = "";
                            hdnPDID.Value = "";
                        }
                        //ddlPayMethod.Enabled = false;
                        if (CarsDetails.Tables[5].Rows.Count > 0)
                        {
                            if (CarsDetails.Tables[5].Rows[0]["CallDate"].ToString() != "")
                            {
                                DateTime WCCallDt = Convert.ToDateTime(CarsDetails.Tables[5].Rows[0]["CallDate"].ToString());
                                lblWCCallDate.Text = WCCallDt.ToString("MM/dd/yyyy");
                            }
                            lblWCCallBy.Text = objGeneralFunc.GetSmartzUser(CarsDetails.Tables[5].Rows[0]["CallAgentID"].ToString());
                        }
                        if (CarsDetails.Tables[0].Rows[0]["isActive"].ToString() == "True")
                        {
                            ListItem liAdActive = new ListItem();
                            liAdActive.Value = "1";
                            liAdActive.Text = "Active";
                            ddlAdStatus.SelectedIndex = ddlAdStatus.Items.IndexOf(liAdActive);

                        }
                        else
                        {
                            ListItem liAdActive = new ListItem();
                            liAdActive.Value = "0";
                            liAdActive.Text = "Inactive";
                            ddlAdStatus.SelectedIndex = ddlAdStatus.Items.IndexOf(liAdActive);
                        }
                        if (CarsDetails.Tables[0].Rows[0]["isActive"].ToString() == "True")
                        {
                            trListingStatus.Style["display"] = "none";
                            trUceStatus.Style["display"] = "block";
                            if (CarsDetails.Tables[0].Rows[0]["UceStatus"].ToString() == "1")
                            {
                                ListItem liUceStatus = new ListItem();
                                liUceStatus.Value = "1";
                                liUceStatus.Text = "Active";
                                ddlUceStatus.SelectedIndex = ddlUceStatus.Items.IndexOf(liUceStatus);
                            }
                            else
                            {
                                ListItem liUceStatus = new ListItem();
                                liUceStatus.Value = "0";
                                liUceStatus.Text = "Inactive";
                                ddlUceStatus.SelectedIndex = ddlUceStatus.Items.IndexOf(liUceStatus);
                            }
                            if (CarsDetails.Tables[0].Rows[0]["MultisiteStatus"].ToString() == "1")
                            {
                                ListItem liMultisiteStatus = new ListItem();
                                liMultisiteStatus.Value = "1";
                                liMultisiteStatus.Text = "Active";
                                ddlMultisiteStatus.SelectedIndex = ddlMultisiteStatus.Items.IndexOf(liMultisiteStatus);
                            }
                            else
                            {
                                ListItem liMultisiteStatus = new ListItem();
                                liMultisiteStatus.Value = "0";
                                liMultisiteStatus.Text = "Inactive";
                                ddlMultisiteStatus.SelectedIndex = ddlMultisiteStatus.Items.IndexOf(liMultisiteStatus);
                            }
                        }
                        else
                        {
                            trListingStatus.Style["display"] = "block";
                            trUceStatus.Style["display"] = "none";
                            ListItem liAdStatus = new ListItem();
                            liAdStatus.Value = CarsDetails.Tables[0].Rows[0]["AdStatus"].ToString();
                            liAdStatus.Text = CarsDetails.Tables[0].Rows[0]["AdStatusName"].ToString();
                            ddlListingStatus.SelectedIndex = ddlListingStatus.Items.IndexOf(liAdStatus);
                        }

                        if (CarsDetails.Tables[0].Rows[0]["PDDate"].ToString() != "")
                        {
                            if ((CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "1") || (CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString() == "5"))
                            {
                                if (CarsDetails.Tables[0].Rows[0]["AdStatus"].ToString() == "2")
                                {
                                    lnkbtnUpdatePdDate.Visible = true;
                                }
                                else
                                {
                                    lnkbtnUpdatePdDate.Visible = false;
                                }
                            }
                            else
                            {
                                lnkbtnUpdatePdDate.Visible = false;
                            }
                        }
                        else
                        {
                            lnkbtnUpdatePdDate.Visible = false;
                        }
                        if (CarsDetails.Tables[0].Rows[0]["DealerCode"].ToString() != "")
                        {
                            txtLoginPassword.Enabled = false;
                            txtLoginEmail.Enabled = false;
                            chkbxEMailNA.Enabled = false;
                            txtRegName.Enabled = false;
                            txtRegBusinessName.Enabled = false;
                            txtRegAltEmail.Enabled = false;
                            txtRegPhNo.Enabled = false;
                            txtRegAltPhoneNum.Enabled = false;
                            txtRegAddress.Enabled = false;
                            txtRegCity.Enabled = false;
                            ddlRegState.Enabled = false;
                            txtregZip.Enabled = false;
                            if (CarsDetails.Tables[9].Rows.Count > 0)
                            {
                                lblPayConfirmNo.Text = CarsDetails.Tables[9].Rows[0]["TransactionID"].ToString();
                                lblVoiceFileName.Text = CarsDetails.Tables[9].Rows[0]["VoiceRecord"].ToString();
                                lblPayAmount.Text = CarsDetails.Tables[9].Rows[0]["Amount"].ToString();
                                ListItem liPayStatus = new ListItem();
                                liPayStatus.Value = CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString();
                                liPayStatus.Text = CarsDetails.Tables[9].Rows[0]["pmntStatus"].ToString();
                                ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatus);

                                ListItem liPayMethod = new ListItem();
                                liPayMethod.Value = CarsDetails.Tables[9].Rows[0]["pmntTypeID"].ToString();
                                liPayMethod.Text = CarsDetails.Tables[9].Rows[0]["pmntType"].ToString();
                                ddlPayMethod.SelectedIndex = ddlPayMethod.Items.IndexOf(liPayMethod);

                                Session["PaymentID"] = CarsDetails.Tables[9].Rows[0]["pmntID"].ToString();

                                if (CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString() == "2")
                                {
                                    ListItem liPayStatusPend = new ListItem();
                                    liPayStatusPend.Value = "1";
                                    liPayStatusPend.Text = "Pending";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusPend);
                                    ListItem liPayStatusPremli = new ListItem();
                                    liPayStatusPremli.Value = "5";
                                    liPayStatusPremli.Text = "Preliminary";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusPremli);
                                    ListItem liPayStatusCancel = new ListItem();
                                    liPayStatusCancel.Value = "6";
                                    liPayStatusCancel.Text = "Admin Cancel";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusCancel);
                                }
                                if (CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString() == "5")
                                {
                                    ListItem liPayStatusPend = new ListItem();
                                    liPayStatusPend.Value = "1";
                                    liPayStatusPend.Text = "Pending";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusPend);
                                    ListItem liPayStatusRefund = new ListItem();
                                    liPayStatusRefund.Value = "3";
                                    liPayStatusRefund.Text = "Refund";
                                    ddlPayStatus.Items.Remove(liPayStatusRefund);
                                    ListItem liPayStatusChargeBack = new ListItem();
                                    liPayStatusChargeBack.Value = "4";
                                    liPayStatusChargeBack.Text = "Chargeback";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusChargeBack);
                                }

                                if (CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString() == "1")
                                {
                                    ListItem liPayStatusPend = new ListItem();
                                    liPayStatusPend.Value = "5";
                                    liPayStatusPend.Text = "Preliminary";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusPend);
                                    ListItem liPayStatusRefund = new ListItem();
                                    liPayStatusRefund.Value = "3";
                                    liPayStatusRefund.Text = "Refund";
                                    ddlPayStatus.Items.Remove(liPayStatusRefund);
                                    ListItem liPayStatusChargeBack = new ListItem();
                                    liPayStatusChargeBack.Value = "4";
                                    liPayStatusChargeBack.Text = "Chargeback";
                                    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                                    ddlPayStatus.Items.Remove(liPayStatusChargeBack);
                                }
                                if (CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString() == "3")
                                {
                                    ddlPayStatus.Enabled = false;
                                }
                                if (CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString() == "4")
                                {
                                    ddlPayStatus.Enabled = false;
                                }
                                if (CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString() == "6")
                                {
                                    ddlPayStatus.Enabled = false;
                                }
                                if (CarsDetails.Tables[9].Rows[0]["PayDate"].ToString() != "")
                                {
                                    DateTime PaymentDate = Convert.ToDateTime(CarsDetails.Tables[9].Rows[0]["PayDate"].ToString());
                                    lblPaymentDate.Text = PaymentDate.ToString("MM/dd/yyyy");
                                }
                                if (CarsDetails.Tables[9].Rows[0]["PDDate"].ToString() != "")
                                {
                                    DateTime PDDate = Convert.ToDateTime(CarsDetails.Tables[9].Rows[0]["PDDate"].ToString());
                                    lblPDDate.Text = PDDate.ToString("MM/dd/yyyy");
                                    Session["EditPDDate"] = PDDate;
                                }
                                Session["EditPayStatus"] = CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString();
                                hdnPayStatus.Value = Session["EditPayStatus"].ToString();
                                GetDataStatus();
                            }
                        }
                    }
                }
            }
        }
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

    private void FillPaymentDate()
    {
        try
        {
            for (int i = 0; i < 7; i++)
            {
                ListItem list = new ListItem();
                list.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
                list.Value = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
                ddlPaymentDate.Items.Add(list);
            }
            ddlPaymentDate.Items.Insert(0, new ListItem("Select", "0"));
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
            ddlRegState.DataSource = dsDropDown.Tables[1];
            ddlRegState.DataTextField = "State_Code";
            ddlRegState.DataValueField = "State_ID";
            ddlRegState.DataBind();
            ddlRegState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillPayType()
    {
        try
        {
            ddlPayMethod.DataSource = dsDropDown.Tables[10];
            ddlPayMethod.DataTextField = "pmntType";
            ddlPayMethod.DataValueField = "pmntTypeID";
            ddlPayMethod.DataBind();
            //ddlPayMethod.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillPayStatus()
    {
        try
        {
            ddlPayStatus.DataSource = dsDropDown.Tables[11];
            ddlPayStatus.DataTextField = "pmntStatus";
            ddlPayStatus.DataValueField = "pmntStatusID";
            ddlPayStatus.DataBind();
            //ddlPayStatus.Items.Insert(0, new ListItem("Unspecified", "0"));
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
            ddlLocationState.DataValueField = "State_Code";
            ddlLocationState.DataBind();
            ddlLocationState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillPackage()
    {
        try
        {
            //for (int i = 0; i < dsDropDown.Tables[2].Rows.Count; i++)
            //{
            //    Double PackCost = new Double();
            //    PackCost = Convert.ToDouble(dsDropDown.Tables[2].Rows[i]["Price"].ToString());
            //    string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
            //    string PackName = dsDropDown.Tables[2].Rows[i]["Description"].ToString();
            //    ListItem list = new ListItem();
            //    list.Text = PackName + "($" + PackAmount + ")";
            //    list.Value = dsDropDown.Tables[2].Rows[i]["PackageID"].ToString();
            //    ddlPackage.Items.Add(list);
            //}
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
            throw ex;
        }
    }
    private void FillCylinders()
    {
        try
        {
            ddlCylinderCount.DataSource = dsDropDown.Tables[5];
            ddlCylinderCount.DataTextField = "CylindersName";
            ddlCylinderCount.DataValueField = "CylindersName";
            ddlCylinderCount.DataBind();
            ddlCylinderCount.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillCondition()
    {
        try
        {
            ddlCondition.DataSource = dsDropDown.Tables[9];
            ddlCondition.DataTextField = "condition";
            ddlCondition.DataValueField = "conditionID";
            ddlCondition.DataBind();
            //ddlCondition.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillFuelTypes()
    {
        try
        {
            ddlFuelType.DataSource = dsDropDown.Tables[0];
            ddlFuelType.DataTextField = "FuelType";
            ddlFuelType.DataValueField = "FuelTypeID";
            ddlFuelType.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    private void FillDoors()
    {
        try
        {
            ddlDoorCount.DataSource = dsDropDown.Tables[8];
            ddlDoorCount.DataTextField = "DoorsCount";
            ddlDoorCount.DataValueField = "DoorsCount";
            ddlDoorCount.DataBind();
            ddlDoorCount.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillDriveTrain()
    {
        try
        {
            ddlDriveTrain.DataSource = dsDropDown.Tables[6];
            ddlDriveTrain.DataTextField = "NoOfDoorsName";
            ddlDriveTrain.DataValueField = "NoOfDoorsName";
            ddlDriveTrain.DataBind();
            ddlDriveTrain.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillTransmissions()
    {
        try
        {
            ddlTransmission.DataSource = dsDropDown.Tables[7];
            ddlTransmission.DataTextField = "TransmissionName";
            ddlTransmission.DataValueField = "TransmissionName";
            ddlTransmission.DataBind();
            ddlTransmission.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnResendWelMail_Click(object sender, EventArgs e)
    {
        try
        {
            //string PDDate = string.Empty;
            //string LoginPassword = Session["RegPassword"].ToString();
            //string LoginName = Session["RegUserName"].ToString();
            //string UserDisName = Session["RegName"].ToString();
            //clsMailFormats format = new clsMailFormats();
            //string text = string.Empty;

            //if (Session["EditPayStatus"].ToString() == "5")
            //{
            //    DateTime PostDate = Convert.ToDateTime(Session["EditPDDate"].ToString());
            //    PDDate = PostDate.ToString("MM/dd/yyyy");
            //    text = format.SendRegistrationdetailsForPDSales(LoginName, LoginPassword, UserDisName, ref text, PDDate);
            //}
            //else
            //{
            //    text = format.SendRegistrationdetails(LoginName, LoginPassword, UserDisName, ref text);
            //}
            //lblRegisMail.Text = text;
            //lblMailTo.Text = LoginName;
            //txtEmailTo.Text = "";
            //lblRegisMail.Visible = true;
            //mpeViewregisterMail.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSendregMail_Click(object sender, EventArgs e)
    {
        try
        {
            ResendRegMail();
            mpeViewregisterMail.Hide();
            mpealteruser.Show();
            lblErr.Visible = true;
            lblErr.Text = "Email(s) successfully send";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnIntUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["CustViewCarID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtNewIntNotes.Text.Trim();
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
            Session.Timeout = 180;
            if (dsNewIntNotes.Tables[0].Rows.Count > 0)
            {
                string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["InternalNotes"].ToString();
                OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                txtOldIntNotes.Text = OldNotes;
                txtNewIntNotes.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ResendRegMail()
    {
        try
        {
            //Session.Timeout = 180;
            //string LoginPassword = Session["RegPassword"].ToString();
            //string LoginName = Session["RegUserName"].ToString();
            //string UserDisName = Session["RegName"].ToString();
            //clsMailFormats format = new clsMailFormats();
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("info@unitedcarexchange.com");
            //msg.To.Add(LoginName);
            //if (txtEmailTo.Text != "")
            //{
            //    msg.CC.Add(txtEmailTo.Text);
            //}
            //msg.Bcc.Add("archive@unitedcarexchange.com");
            //msg.Subject = "Registration Details From United Car Exchange For Car ID# " + Session["EditCarID"].ToString();
            //msg.IsBodyHtml = true;
            //string text = string.Empty;
            //text = format.SendRegistrationdetails(LoginName, LoginPassword, UserDisName, ref text);
            //msg.Body = text.ToString();
            //SmtpClient smtp = new SmtpClient();
            ////smtp.Host = "smtp.gmail.com";
            ////smtp.Port = 587;
            ////smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
            ////smtp.EnableSsl = true;
            ////smtp.Send(msg);
            //smtp.Host = "127.0.0.1";
            //smtp.Port = 25;
            //smtp.Send(msg);
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
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int UID = Convert.ToInt32(Session["EditUID"].ToString());
            int CarID = Convert.ToInt32(Session["EditCarID"].ToString());
            int SellerID = Convert.ToInt32(Session["EditsellerID"].ToString());
            int UserPackID = Convert.ToInt32(Session["EditUserPackID"].ToString());

            string RegName = objGeneralFunc.ToProper(txtRegName.Text).Trim();
            string RegPhone = txtRegPhNo.Text;
            string RegCity = objGeneralFunc.ToProper(txtRegCity.Text).Trim();
            int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
            string RegAddress = objGeneralFunc.ToProper(txtRegAddress.Text).Trim();
            string BusinessName = txtRegBusinessName.Text;
            string RegAltEmail = txtRegAltEmail.Text;
            string RegAltPhone = txtRegAltPhoneNum.Text;
            string RegZip = string.Empty;

            RegZip = txtregZip.Text;

            String RegUserName = txtLoginEmail.Text;
            string Password = txtLoginPassword.Text;
            string ReferCode = objGeneralFunc.ToProper(txtAgent.Text).Trim();
            int Year = Convert.ToInt32(ddlYear.SelectedItem.Text);
            string Title = txtTitle.Text;
            int MakeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value);
            int BodyTypeID = Convert.ToInt32(ddlBodyStyle.SelectedItem.Value);
            int ConditionID = Convert.ToInt32(ddlCondition.SelectedItem.Value);
            string DriveTrain = ddlDriveTrain.SelectedItem.Text;
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
            string Transmission = ddlTransmission.SelectedItem.Text;
            string NumberOfDoors = ddlDoorCount.SelectedItem.Value;
            string Vin = txtVinNumber.Text;
            string NumberOfCylinder = ddlCylinderCount.SelectedItem.Value;
            int FuelTypeID = Convert.ToInt32(ddlFuelType.SelectedItem.Value);
            string Zipcode = string.Empty;
            //if (txtZip.Text.Length == 4)
            //{
            //    Zipcode = "0" + txtZip.Text;
            //}
            //else
            //{
            Zipcode = txtZip.Text;
            //}
            string City = objGeneralFunc.ToProper(txtCity.Text);
            // int StateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
            string Descrip = string.Empty;
            string CondiDescrip = string.Empty;
            Descrip = txtDescription.Text;
            CondiDescrip = ddlCondition.SelectedItem.Text;
            string SellerName = "";
            string Address1 = "";
            string CustPhone = txtCustPhoneNumber.Text;
            string AltCustPhone = txtCustAltNumber.Text;
            string CustState = ddlLocationState.SelectedItem.Text;
            string CustEmail = txtSellerEmail.Text;
            int PackageID = Convert.ToInt32(Session["EditPackageID"].ToString());
            int IsActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
            int FeatureID;
            int IsactiveFea;
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtNewIntNotes.Text.Trim();
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
            int PmntType = Convert.ToInt32(ddlPayMethod.SelectedItem.Value);
            int PmntStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
            int PaymentID;
            DateTime PaymentDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
            string ConfirmNo = string.Empty;
            string VoiceFileName = string.Empty;

            if (Session["PaymentID"] == null)
            {
                PaymentID = Convert.ToInt32(0);
            }
            else if (Session["PaymentID"].ToString() == "")
            {
                PaymentID = Convert.ToInt32(0);
            }
            else
            {
                PaymentID = Convert.ToInt32(Session["PaymentID"]);
            }
            String strHostName = Request.UserHostAddress.ToString();
            string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            int ListingStatus;
            int UceStatus;
            int MultisiteStatus;
            if (IsActive == 1)
            {
                ListingStatus = 1;
                UceStatus = Convert.ToInt32(ddlUceStatus.SelectedItem.Value);
                MultisiteStatus = Convert.ToInt32(ddlMultisiteStatus.SelectedItem.Value);
            }
            else
            {
                ListingStatus = Convert.ToInt32(ddlListingStatus.SelectedItem.Value);
                UceStatus = 0;
                MultisiteStatus = 0;
            }
            DataSet dsEditPhoneExists = objdropdownBL.SmartzChkUserPhoneNumberExistsForUpdate(RegPhone, UID);
            if (dsEditPhoneExists.Tables.Count > 0)
            {
                if (dsEditPhoneExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Phone number " + RegPhone + " already exists";
                }
                else
                {
                    //Email Check Starts
                    int EmailExists = 1;
                    if (chkbxEMailNA.Checked == false)
                    {
                        EmailExists = 1;
                        DataSet dsUserExists = objdropdownBL.USP_SmartzChkUserExistsForUpdate(RegUserName, UID);
                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + RegUserName + " already exists";
                            }
                            else
                            {
                                if (PmntStatus == 2)
                                {
                                    if (Session["EditPayStatus"].ToString() == "2")
                                    {
                                        PaymentDate = Convert.ToDateTime(lblPaymentDate.Text);
                                        ConfirmNo = lblPayConfirmNo.Text;
                                        VoiceFileName = lblVoiceFileName.Text;
                                    }
                                    else
                                    {
                                        PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                                        ConfirmNo = txtPayConfirmNum.Text;
                                        VoiceFileName = txtVoiceFileName.Text;
                                        //ddlPayMethod.Enabled = true;
                                    }
                                }
                                bool bnew = objdropdownBL.USP_SmartzUpdateRegUserDetails(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, ReferCode, TranBy, BusinessName, RegAltEmail, RegAltPhone, EmailExists);
                                bool bnewcar = objdropdownBL.USP_SmartzUpdateCardetails(Year, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price,
                                    Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, Vin, NumberOfCylinder, FuelTypeID, Zipcode, City, Descrip, CondiDescrip, InternalNotesNew, TranBy, Title);
                                bool bnewSeller = objdropdownBL.USP_SmartzUpdateSellerdetails(SellerName, Address1, City, CustState, Zipcode, CustPhone, CarID, UID, SellerID,
                                    PackageID, CustEmail, IsActive, AltCustPhone, TranBy, ListingStatus, PostingID, UceStatus, MultisiteStatus);

                                for (int i = 1; i < 52; i++)
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
                                    bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                                }
                                if (PackageID != 1)
                                {
                                    if (PmntStatus == 2)
                                    {
                                        bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                                    }
                                    else
                                    {
                                        bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                                    }
                                }

                                int IsLocked = 0;
                                DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                                mpealteruserUpdated.Show();
                                lblErrUpdated.Visible = true;
                                lblErrUpdated.Text = "Updated successfully";
                            }
                        }
                        else
                        {
                            if (PmntStatus == 2)
                            {
                                if (Session["EditPayStatus"].ToString() == "2")
                                {
                                    PaymentDate = Convert.ToDateTime(lblPaymentDate.Text);
                                    ConfirmNo = lblPayConfirmNo.Text;
                                    VoiceFileName = lblVoiceFileName.Text;
                                }
                                else
                                {
                                    PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                                    ConfirmNo = txtPayConfirmNum.Text;
                                    VoiceFileName = txtVoiceFileName.Text;
                                    //ddlPayMethod.Enabled = true;
                                }
                            }
                            bool bnew = objdropdownBL.USP_SmartzUpdateRegUserDetails(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, ReferCode, TranBy, BusinessName, RegAltEmail, RegAltPhone, EmailExists);
                            bool bnewcar = objdropdownBL.USP_SmartzUpdateCardetails(Year, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price,
                                Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, Vin, NumberOfCylinder, FuelTypeID, Zipcode, City, Descrip, CondiDescrip, InternalNotesNew, TranBy, Title);
                            bool bnewSeller = objdropdownBL.USP_SmartzUpdateSellerdetails(SellerName, Address1, City, CustState, Zipcode, CustPhone, CarID, UID, SellerID,
                                PackageID, CustEmail, IsActive, AltCustPhone, TranBy, ListingStatus, PostingID, UceStatus, MultisiteStatus);

                            for (int i = 1; i < 52; i++)
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
                                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                            }
                            if (PackageID != 1)
                            {
                                if (PmntStatus == 2)
                                {
                                    bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                                }
                                else
                                {
                                    bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                                }
                            }
                            int IsLocked = 0;
                            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                            mpealteruserUpdated.Show();
                            lblErrUpdated.Visible = true;
                            lblErrUpdated.Text = "Updated successfully";
                        }
                    }
                    else
                    {
                        EmailExists = 0;

                        if (PmntStatus == 2)
                        {
                            if (Session["EditPayStatus"].ToString() == "2")
                            {
                                PaymentDate = Convert.ToDateTime(lblPaymentDate.Text);
                                ConfirmNo = lblPayConfirmNo.Text;
                                VoiceFileName = lblVoiceFileName.Text;
                            }
                            else
                            {
                                PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                                ConfirmNo = txtPayConfirmNum.Text;
                                VoiceFileName = txtVoiceFileName.Text;
                                //ddlPayMethod.Enabled = true;
                            }
                        }
                        bool bnew = objdropdownBL.USP_SmartzUpdateRegUserDetails(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, ReferCode, TranBy, BusinessName, RegAltEmail, RegAltPhone, EmailExists);
                        bool bnewcar = objdropdownBL.USP_SmartzUpdateCardetails(Year, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price,
                            Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, Vin, NumberOfCylinder, FuelTypeID, Zipcode, City, Descrip, CondiDescrip, InternalNotesNew, TranBy, Title);
                        bool bnewSeller = objdropdownBL.USP_SmartzUpdateSellerdetails(SellerName, Address1, City, CustState, Zipcode, CustPhone, CarID, UID, SellerID,
                            PackageID, CustEmail, IsActive, AltCustPhone, TranBy, ListingStatus, PostingID, UceStatus, MultisiteStatus);

                        for (int i = 1; i < 52; i++)
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
                            bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                        }
                        if (PackageID != 1)
                        {
                            if (PmntStatus == 2)
                            {
                                bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                            }
                            else
                            {
                                bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                            }
                        }
                        int IsLocked = 0;
                        DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                        mpealteruserUpdated.Show();
                        lblErrUpdated.Visible = true;
                        lblErrUpdated.Text = "Updated successfully";
                    }
                    //Email Check Ends
                }
            }
            else
            {
                //Email Check Starts
                int EmailExists = 1;
                if (chkbxEMailNA.Checked == false)
                {
                    EmailExists = 1;
                    DataSet dsUserExists = objdropdownBL.USP_SmartzChkUserExistsForUpdate(RegUserName, UID);
                    if (dsUserExists.Tables.Count > 0)
                    {
                        if (dsUserExists.Tables[0].Rows.Count > 0)
                        {
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Email " + RegUserName + " already exists";
                        }
                        else
                        {
                            if (PmntStatus == 2)
                            {
                                if (Session["EditPayStatus"].ToString() == "2")
                                {
                                    PaymentDate = Convert.ToDateTime(lblPaymentDate.Text);
                                    ConfirmNo = lblPayConfirmNo.Text;
                                    VoiceFileName = lblVoiceFileName.Text;
                                }
                                else
                                {
                                    PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                                    ConfirmNo = txtPayConfirmNum.Text;
                                    VoiceFileName = txtVoiceFileName.Text;
                                    //ddlPayMethod.Enabled = true;
                                }
                            }
                            bool bnew = objdropdownBL.USP_SmartzUpdateRegUserDetails(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, ReferCode, TranBy, BusinessName, RegAltEmail, RegAltPhone, EmailExists);
                            bool bnewcar = objdropdownBL.USP_SmartzUpdateCardetails(Year, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price,
                                Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, Vin, NumberOfCylinder, FuelTypeID, Zipcode, City, Descrip, CondiDescrip, InternalNotesNew, TranBy, Title);
                            bool bnewSeller = objdropdownBL.USP_SmartzUpdateSellerdetails(SellerName, Address1, City, CustState, Zipcode, CustPhone, CarID, UID, SellerID,
                                PackageID, CustEmail, IsActive, AltCustPhone, TranBy, ListingStatus, PostingID, UceStatus, MultisiteStatus);

                            for (int i = 1; i < 52; i++)
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
                                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                            }
                            if (PackageID != 1)
                            {
                                if (PmntStatus == 2)
                                {
                                    bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                                }
                                else
                                {
                                    bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                                }
                            }

                            int IsLocked = 0;
                            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                            mpealteruserUpdated.Show();
                            lblErrUpdated.Visible = true;
                            lblErrUpdated.Text = "Updated successfully";
                        }
                    }
                    else
                    {
                        if (PmntStatus == 2)
                        {
                            if (Session["EditPayStatus"].ToString() == "2")
                            {
                                PaymentDate = Convert.ToDateTime(lblPaymentDate.Text);
                                ConfirmNo = lblPayConfirmNo.Text;
                                VoiceFileName = lblVoiceFileName.Text;
                            }
                            else
                            {
                                PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                                ConfirmNo = txtPayConfirmNum.Text;
                                VoiceFileName = txtVoiceFileName.Text;
                                //ddlPayMethod.Enabled = true;
                            }
                        }
                        bool bnew = objdropdownBL.USP_SmartzUpdateRegUserDetails(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, ReferCode, TranBy, BusinessName, RegAltEmail, RegAltPhone, EmailExists);
                        bool bnewcar = objdropdownBL.USP_SmartzUpdateCardetails(Year, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price,
                            Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, Vin, NumberOfCylinder, FuelTypeID, Zipcode, City, Descrip, CondiDescrip, InternalNotesNew, TranBy, Title);
                        bool bnewSeller = objdropdownBL.USP_SmartzUpdateSellerdetails(SellerName, Address1, City, CustState, Zipcode, CustPhone, CarID, UID, SellerID,
                            PackageID, CustEmail, IsActive, AltCustPhone, TranBy, ListingStatus, PostingID, UceStatus, MultisiteStatus);

                        for (int i = 1; i < 52; i++)
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
                            bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                        }
                        if (PackageID != 1)
                        {
                            if (PmntStatus == 2)
                            {
                                bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                            }
                            else
                            {
                                bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                            }
                        }
                        int IsLocked = 0;
                        DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                        mpealteruserUpdated.Show();
                        lblErrUpdated.Visible = true;
                        lblErrUpdated.Text = "Updated successfully";
                    }
                }
                else
                {
                    EmailExists = 0;

                    if (PmntStatus == 2)
                    {
                        if (Session["EditPayStatus"].ToString() == "2")
                        {
                            PaymentDate = Convert.ToDateTime(lblPaymentDate.Text);
                            ConfirmNo = lblPayConfirmNo.Text;
                            VoiceFileName = lblVoiceFileName.Text;
                        }
                        else
                        {
                            PaymentDate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                            ConfirmNo = txtPayConfirmNum.Text;
                            VoiceFileName = txtVoiceFileName.Text;
                            //ddlPayMethod.Enabled = true;
                        }
                    }
                    bool bnew = objdropdownBL.USP_SmartzUpdateRegUserDetails(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, ReferCode, TranBy, BusinessName, RegAltEmail, RegAltPhone, EmailExists);
                    bool bnewcar = objdropdownBL.USP_SmartzUpdateCardetails(Year, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price,
                        Mileage, ExteriorColor, InteriorColor, Transmission, NumberOfDoors, Vin, NumberOfCylinder, FuelTypeID, Zipcode, City, Descrip, CondiDescrip, InternalNotesNew, TranBy, Title);
                    bool bnewSeller = objdropdownBL.USP_SmartzUpdateSellerdetails(SellerName, Address1, City, CustState, Zipcode, CustPhone, CarID, UID, SellerID,
                        PackageID, CustEmail, IsActive, AltCustPhone, TranBy, ListingStatus, PostingID, UceStatus, MultisiteStatus);

                    for (int i = 1; i < 52; i++)
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
                        bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                    }
                    if (PackageID != 1)
                    {
                        if (PmntStatus == 2)
                        {
                            bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                        }
                        else
                        {
                            bool BnewPay = objdropdownBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                        }
                    }
                    int IsLocked = 0;
                    DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                    mpealteruserUpdated.Show();
                    lblErrUpdated.Visible = true;
                    lblErrUpdated.Text = "Updated successfully";
                }
                //Email Check Ends
            }
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnYesUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void BtnClsUpdated_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Click"] = "3";
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);

            //FillTicketDropdown();
            //Response.Redirect("CustomerView.aspx");
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerEdit.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Click"] = "2";
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
            //FillTicketDropdown();
            //Session.Abandon();
            //Response.Redirect("Login.aspx");
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkbtnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("index.aspx");
            Session["Click"] = "6";
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
            FillTicketDropdown();
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
        }
    }

    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("index.aspx");
            Session["Click"] = "1";
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
            //FillTicketDropdown();
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnJustChecking_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["Click"] == "1")
            {
                Response.Redirect("index.aspx");
            }
            if (Session["Click"] == "2")
            {
                CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
                objCentralDBBL.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), System.DateTime.Now, Convert.ToInt32(Session[Constants.USERLOG_ID]), 2);
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            if (Session["Click"] == "3")
            {
                Response.Redirect("CustomerView.aspx");
            }
            if (Session["Click"] == "4")
            {
                Response.Redirect("Index.aspx");
            }
            if (Session["Click"] == "6")
            {
                Response.Redirect("SearchNew.aspx");
            }
            //Response.Redirect("SearchNew.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ImgBtnLogo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["Click"] = "4";
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
            //FillTicketDropdown();
            // Response.Redirect("Index.aspx");
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillTicketDropdown()
    {
        try
        {
            SmartzTicketDdlDs = Session["TicketDdl"] as DataSet;

            ddlCallType.DataSource = SmartzTicketDdlDs.Tables[0];
            ddlCallType.DataTextField = "CallTypeName";
            ddlCallType.DataValueField = "CallTypeID";
            ddlCallType.DataBind();
            ddlCallType.Items.Insert(0, new ListItem("Select", "0"));


            ddlCallReason.DataSource = SmartzTicketDdlDs.Tables[1];
            ddlCallReason.DataTextField = "CallReasonName";
            ddlCallReason.DataValueField = "CallReasonID";
            ddlCallReason.DataBind();
            ddlCallReason.Items.Insert(0, new ListItem("Select", "0"));

            ddlTicketType.DataSource = SmartzTicketDdlDs.Tables[2];
            ddlTicketType.DataTextField = "TicketTypeName";
            ddlTicketType.DataValueField = "TicketTypeID";
            ddlTicketType.DataBind();
            ddlTicketType.Items.Insert(0, new ListItem("Select", "0"));

            ddlTicketPriority.DataSource = SmartzTicketDdlDs.Tables[3];
            ddlTicketPriority.DataTextField = "PriorityName";
            ddlTicketPriority.DataValueField = "PriorityID";
            ddlTicketPriority.DataBind();


            ddlCallBack.DataSource = SmartzTicketDdlDs.Tables[4];
            ddlCallBack.DataTextField = "CallBackName";
            ddlCallBack.DataValueField = "CallBackID";
            ddlCallBack.DataBind();
            ddlCallBack.Items.Insert(0, new ListItem("Select", "0"));

            ddlCallResolution.DataSource = SmartzTicketDdlDs.Tables[7];
            ddlCallResolution.DataTextField = "CSResolutionName";
            ddlCallResolution.DataValueField = "CSResolutionID";
            ddlCallResolution.DataBind();
            ddlCallResolution.Items.Insert(0, new ListItem("Select", "0"));

            txtSpokenWith.Text = Session["RegName"].ToString();

            if (Session["RedirectFrom"].ToString() == "2")
            {
                ListItem liCallType = new ListItem();
                liCallType.Value = "1";
                liCallType.Text = "Welcome call";
                ddlCallType.SelectedIndex = ddlCallType.Items.IndexOf(liCallType);
                ddlCallType.Enabled = false;

                ListItem liCallReason = new ListItem();
                liCallReason.Value = "2";
                liCallReason.Text = "Welcome call";
                ddlCallReason.SelectedIndex = ddlCallReason.Items.IndexOf(liCallReason);
                ddlCallReason.Enabled = false;
            }
            if (Session["RedirectFrom"].ToString() == "6")
            {
                ListItem liCallType = new ListItem();
                liCallType.Value = "9";
                liCallType.Text = "30 day review call";
                ddlCallType.SelectedIndex = ddlCallType.Items.IndexOf(liCallType);
                ddlCallType.Enabled = false;

                ListItem liCallReason = new ListItem();
                liCallReason.Value = "10";
                liCallReason.Text = "30 day review call";
                ddlCallReason.SelectedIndex = ddlCallReason.Items.IndexOf(liCallReason);
                ddlCallReason.Enabled = false;
            }
            if (Session["RedirectFrom"].ToString() == "7")
            {
                ListItem liCallType = new ListItem();
                liCallType.Value = "10";
                liCallType.Text = "60 day review call";
                ddlCallType.SelectedIndex = ddlCallType.Items.IndexOf(liCallType);
                ddlCallType.Enabled = false;

                ListItem liCallReason = new ListItem();
                liCallReason.Value = "11";
                liCallReason.Text = "60 day review call";
                ddlCallReason.SelectedIndex = ddlCallReason.Items.IndexOf(liCallReason);
                ddlCallReason.Enabled = false;
            }

            ListItem liddlTicketPriority = new ListItem();
            liddlTicketPriority.Text = "Low";
            liddlTicketPriority.Value = "3";
            ddlTicketPriority.SelectedIndex = ddlTicketPriority.Items.IndexOf(liddlTicketPriority);

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
            int CarID = Convert.ToInt32(Session["CustViewCarID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int CallType = Convert.ToInt32(ddlCallType.SelectedItem.Value);
            int CallReason = Convert.ToInt32(ddlCallReason.SelectedItem.Value);
            int CallResolution = Convert.ToInt32(ddlCallResolution.SelectedItem.Value);
            string SpokeWith = txtSpokenWith.Text;
            string Notes = txtTicketNotes.Text.Trim();
            if (txtTicketNotes.Text.Trim() != "")
            {
                String UpdatedBy = Session[Constants.NAME].ToString();
                string InternalNotesNew = txtTicketNotes.Text.Trim();
                string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                //Notes = InternalNotesNew;
                DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                Session.Timeout = 180;
            }

            if (TicketConfirm.Value == "false")
            {
                bool bnew = objdropdownBL.USP_SmartzSaveCSDetails(CarID, UID, CallType, CallReason, Notes, CallResolution, SpokeWith);
            }
            else
            {
                int TicketType = Convert.ToInt32(ddlTicketType.SelectedItem.Value);
                int Priority = Convert.ToInt32(ddlTicketPriority.SelectedItem.Value);
                int CallBackID = Convert.ToInt32(ddlCallBack.SelectedItem.Value);
                string TicketDescription = txtTicketDescription.Text;
                if (txtTicketDescription.Text.Trim() != "")
                {
                    String UpdatedBy = Session[Constants.NAME].ToString();
                    string InternalNotesNew = txtTicketDescription.Text.Trim();
                    string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                    InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                    //Notes = InternalNotesNew;
                    DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                    Session.Timeout = 180;
                }
                bool bnew = objdropdownBL.USP_SmartzSaveCSandTicketDetails(CarID, UID, CallType, CallReason, Notes, TicketType, Priority, CallBackID, TicketDescription, CallResolution, SpokeWith);
            }
            if (Session["Click"] == "1")
            {
                Response.Redirect("index.aspx");
            }
            if (Session["Click"] == "2")
            {
                CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
                objCentralDBBL.Perform_LogOut(Convert.ToInt32(Session[Constants.USER_ID]), System.DateTime.Now, Convert.ToInt32(Session[Constants.USERLOG_ID]), 2);
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
            if (Session["Click"] == "3")
            {
                Response.Redirect("CustomerView.aspx");
            }
            if (Session["Click"] == "4")
            {
                Response.Redirect("Index.aspx");
            }
            if (Session["Click"] == "6")
            {
                Response.Redirect("SearchNew.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlAdStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int AdStatus = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
            if (AdStatus == 1)
            {
                trListingStatus.Style["display"] = "none";
                trUceStatus.Style["display"] = "block";
            }
            else
            {
                trListingStatus.Style["display"] = "block";
                trUceStatus.Style["display"] = "none";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlPayStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetDataStatus();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetDataStatus()
    {
        try
        {
            int PayStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
            if (PayStatus == 1)
            {
                lblPaymentDate.Visible = true;
                ddlPaymentDate.Visible = false;
                txtPayConfirmNum.Visible = false;
                lblPayConfirmNo.Visible = true;
                txtVoiceFileName.Visible = false;
                lblVoiceFileName.Visible = true;
            }
            if (PayStatus == 5)
            {
                lblPaymentDate.Visible = true;
                ddlPaymentDate.Visible = false;
                txtPayConfirmNum.Visible = false;
                lblPayConfirmNo.Visible = true;
                txtVoiceFileName.Visible = false;
                lblVoiceFileName.Visible = true;
            }
            if (PayStatus == 2)
            {
                if (Session["EditPayStatus"].ToString() == "2")
                {
                    lblPaymentDate.Visible = true;
                    ddlPaymentDate.Visible = false;
                    txtPayConfirmNum.Visible = false;
                    lblPayConfirmNo.Visible = true;
                    txtVoiceFileName.Visible = false;
                    lblVoiceFileName.Visible = true;
                }
                else
                {
                    lblPaymentDate.Visible = false;
                    ddlPaymentDate.Visible = true;
                    txtPayConfirmNum.Visible = true;
                    lblPayConfirmNo.Visible = false;
                    txtVoiceFileName.Visible = true;
                    lblVoiceFileName.Visible = false;
                }

            }
            else
            {
                lblPaymentDate.Visible = true;
                ddlPaymentDate.Visible = false;
                txtPayConfirmNum.Visible = false;
                lblPayConfirmNo.Visible = true;
                txtVoiceFileName.Visible = false;
                lblVoiceFileName.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnShowAllPhotosUploaded_Click(object sender, EventArgs e)
    {
        try
        {
            CarsDetails = Session["EditCarDetailsDataset"] as DataSet;
            int TotPhotos = Convert.ToInt32(lblTotPhotosUploaded.Text);
            for (int i = 1; i < TotPhotos + 1; i++)
            {
                string RowIDName = "trImg" + i.ToString();
                System.Web.UI.HtmlControls.HtmlTableRow RowID = (System.Web.UI.HtmlControls.HtmlTableRow)form1.FindControl(RowIDName);
                //RowID.Style["display"] = "block";
                string ImgID = "Img" + i.ToString();
                string lblID = "lblImg" + i.ToString();
                string ColumnPic = "pic" + i.ToString();
                string ColumnPicName = "PIC" + i.ToString();
                string ColumnPicLocation = "PICLOC" + i.ToString();
                System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                System.Web.UI.WebControls.Label LabelName = (System.Web.UI.WebControls.Label)form1.FindControl(lblID);
                string SelModelDis = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                SelModelDis = SelModelDis.Replace("/", "@");
                //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);                

                RowID.Style["display"] = "block";

                if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                {
                    LabelName.Visible = false;
                    ImageName.Visible = true;
                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString() + CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                }
                else
                {
                    ImageName.Visible = false;
                    LabelName.Visible = true;
                }

            }

            trShowall.Style["display"] = "none";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnUpdatePdDate_Click(object sender, EventArgs e)
    {
        try
        {
            FillPDDropDown();
            mpeAskNewSale.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillPDDropDown()
    {
        try
        {
            ddlPdDateUp.Items.Clear();
            for (int i = 0; i < 21; i++)
            {
                ListItem list = new ListItem();
                list.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(+i).ToString("MM/dd/yyyy");
                list.Value = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(+i).ToString("MM/dd/yyyy");
                ddlPdDateUp.Items.Add(list);
            }
            ddlPdDateUp.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnPDUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Hide();
            DateTime PDDate = Convert.ToDateTime(ddlPdDateUp.SelectedItem.Text);
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int UserPackID = Convert.ToInt32(Session["EditUserPackID"].ToString());
            int TranBY = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet UpData = objdropdownBL.SmartzUpdatePDDate(TranBY, PDDate, UserPackID, PostingID);
            DateTime dtdatePD = Convert.ToDateTime(UpData.Tables[0].Rows[0]["PDDate"].ToString());
            lblPDDate.Text = dtdatePD.ToString("MM/dd/yyyy");

            DateTime OldPdDateTime = Convert.ToDateTime(Session["EditPDDate"].ToString());
            string OldPDDate = OldPdDateTime.ToString("MM/dd/yyyy");
            int CarID = Convert.ToInt32(Session["EditCarID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = "PD Date changed  from " + OldPDDate + " to " + dtdatePD.ToString("MM/dd/yyyy");
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
            Session.Timeout = 180;
            if (dsNewIntNotes.Tables[0].Rows.Count > 0)
            {
                string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["InternalNotes"].ToString();
                OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                txtOldIntNotes.Text = OldNotes;
                txtNewIntNotes.Text = "";
            }
            Session["EditPDDate"] = dtdatePD;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
