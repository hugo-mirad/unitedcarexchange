
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


public partial class RvCustomerEdit : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
    RvCarsInfo objRvCarsInfo = new RvCarsInfo();
    RvSellerInfo objRvSellerInfo = new RvSellerInfo();
    RvUsedcarsInfo objRvUsedCarsInfo = new RvUsedcarsInfo();
    RvUserRegistrationInfo objUserRegInfo = new RvUserRegistrationInfo();
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


                FillPayType();
                FillPayStatus();
                FillRegStates();
                FillYear();
                FillType();
                GetAllMakes();
                FillExteriorColor();
                FillInteriorColor();
                FillStates();
                FillPaymentDate();
                FillCondition();
                FillFuelTypes();
                FillDoors();
                FillEngineManufacturer();

                int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
                CarsDetails = objRvMainBL.GetCustomerDetailsByPostingID(PostingID);
                Session["EditRvDetailsDataset"] = CarsDetails;
                //int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());
                if (CarsDetails.Tables.Count > 0)
                {
                    if (CarsDetails.Tables[0].Rows.Count > 0)
                    {
                        Session["EditRvUID"] = CarsDetails.Tables[0].Rows[0]["uid"].ToString();
                        Session["EditRvID"] = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        Session["EditRvsellerID"] = CarsDetails.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["EditRvUserPackID"] = CarsDetails.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["EditRvPackageID"] = CarsDetails.Tables[0].Rows[0]["packageID"].ToString();
                        hdnPackageID.Value = CarsDetails.Tables[0].Rows[0]["packageID"].ToString();
                        lblCarID.Text = CarsDetails.Tables[0].Rows[0]["carid"].ToString();

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
                            Session["EditRvPDDate"] = PDDate;
                        }
                        txtAgent.Text = CarsDetails.Tables[0].Rows[0]["ReferCode"].ToString();
                        lblSalesAgent.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        txtVerifier.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["VerifierID"].ToString());
                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["PackagePrice"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = CarsDetails.Tables[0].Rows[0]["PackageName"].ToString();
                        lblPackage.Text = PackName + "($" + PackAmount + ")";
                        txtCustPhoneNumber.Text = CarsDetails.Tables[0].Rows[0]["phone"].ToString();
                        txtCustAltNumber.Text = CarsDetails.Tables[0].Rows[0]["altPhone"].ToString();
                        txtSellerEmail.Text = CarsDetails.Tables[0].Rows[0]["email"].ToString();
                        txtCity.Text = CarsDetails.Tables[0].Rows[0]["city"].ToString();

                        ListItem list5 = new ListItem();
                        list5.Value = CarsDetails.Tables[0].Rows[0]["state"].ToString();
                        list5.Text = CarsDetails.Tables[0].Rows[0]["state"].ToString();
                        ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(list5);

                        txtZip.Text = CarsDetails.Tables[0].Rows[0]["zip"].ToString();

                        ListItem liType = new ListItem();
                        liType.Value = CarsDetails.Tables[0].Rows[0]["RVTYPE"].ToString();
                        liType.Text = CarsDetails.Tables[0].Rows[0]["TypeName"].ToString();
                        ddlType.SelectedIndex = ddlType.Items.IndexOf(liType);

                        GetModelsInfo();

                        ListItem list2 = new ListItem();
                        list2.Value = CarsDetails.Tables[0].Rows[0]["makeModelID"].ToString();
                        list2.Text = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        ddlMake.SelectedIndex = ddlMake.Items.IndexOf(list2);


                        txtModel.Text = CarsDetails.Tables[0].Rows[0]["model"].ToString();



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


                        ListItem list10 = new ListItem();
                        list10.Value = CarsDetails.Tables[0].Rows[0]["NumberOfDoors"].ToString();
                        list10.Text = CarsDetails.Tables[0].Rows[0]["NumberOfDoors"].ToString();
                        ddlDoorCount.SelectedIndex = ddlDoorCount.Items.IndexOf(list10);

                        ListItem list6 = new ListItem();
                        list6.Value = CarsDetails.Tables[0].Rows[0]["fuelTypeID"].ToString();
                        list6.Text = CarsDetails.Tables[0].Rows[0]["fuelType"].ToString();
                        ddlFuelType.SelectedIndex = ddlFuelType.Items.IndexOf(list6);

                        txtLength.Text = CarsDetails.Tables[0].Rows[0]["Length"].ToString();
                        txtWaterCapacity.Text = CarsDetails.Tables[0].Rows[0]["WaterCapacity"].ToString();
                        txtTowingCapacity.Text = CarsDetails.Tables[0].Rows[0]["Towing_Capacity"].ToString();
                        txtDryWeight.Text = CarsDetails.Tables[0].Rows[0]["Dry_Weight"].ToString();

                        if (CarsDetails.Tables[0].Rows[0]["AirConditioners"].ToString() == "0")
                        {
                            ListItem list4 = new ListItem();
                            list4.Value = "0";
                            list4.Text = "Unspecified";
                            ddlAirConditioners.SelectedIndex = ddlAirConditioners.Items.IndexOf(list4);
                        }
                        else
                        {
                            ListItem list4 = new ListItem();
                            list4.Value = CarsDetails.Tables[0].Rows[0]["AirConditioners"].ToString();
                            list4.Text = CarsDetails.Tables[0].Rows[0]["AirConditioners"].ToString();
                            ddlAirConditioners.SelectedIndex = ddlAirConditioners.Items.IndexOf(list4);
                        }
                        if (CarsDetails.Tables[0].Rows[0]["SleepingCapacity"].ToString() == "0")
                        {
                            ListItem list9 = new ListItem();
                            list9.Value = "0";
                            list9.Text = "Unspecified";
                            ddlSleepingCapacity.SelectedIndex = ddlSleepingCapacity.Items.IndexOf(list9);
                        }
                        else
                        {
                            ListItem list9 = new ListItem();
                            list9.Value = CarsDetails.Tables[0].Rows[0]["SleepingCapacity"].ToString();
                            list9.Text = CarsDetails.Tables[0].Rows[0]["SleepingCapacity"].ToString();
                            ddlSleepingCapacity.SelectedIndex = ddlSleepingCapacity.Items.IndexOf(list9);
                        }

                        ListItem list11 = new ListItem();
                        list11.Value = CarsDetails.Tables[0].Rows[0]["EngineManufacturer"].ToString();
                        list11.Text = CarsDetails.Tables[0].Rows[0]["EngineManufacturer"].ToString();
                        ddlEngineManufacturer.SelectedIndex = ddlEngineManufacturer.Items.IndexOf(list11);

                        txtEngineModel.Text = CarsDetails.Tables[0].Rows[0]["EngineType"].ToString();


                        if (CarsDetails.Tables[0].Rows[0]["SlideOuts"].ToString() == "0")
                        {
                            ListItem list12 = new ListItem();
                            list12.Value = "0";
                            list12.Text = "Unspecified";
                            ddlSlideOuts.SelectedIndex = ddlSlideOuts.Items.IndexOf(list12);
                        }
                        else
                        {
                            ListItem list12 = new ListItem();
                            list12.Value = CarsDetails.Tables[0].Rows[0]["SlideOuts"].ToString();
                            list12.Text = CarsDetails.Tables[0].Rows[0]["SlideOuts"].ToString();
                            ddlSlideOuts.SelectedIndex = ddlSlideOuts.Items.IndexOf(list12);
                        }

                        txtVinNumber.Text = CarsDetails.Tables[0].Rows[0]["VIN"].ToString();

                        for (int i = 1; i < 4; i++)
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

                        HylinkUCE.NavigateUrl = "http://unitedrvexchange.com/SearchCarDetails.aspx?VehicleType=" + CarsDetails.Tables[0].Rows[0]["TypeName"].ToString() + "&Make=" + CarsDetails.Tables[0].Rows[0]["Make"].ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + CarsDetails.Tables[0].Rows[0]["carId"].ToString();
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

                        string OldNotes = CarsDetails.Tables[0].Rows[0]["InternalNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtOldIntNotes.Text = OldNotes;

                        Session["RegRvUserName"] = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        Session["RegRvPassword"] = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        Session["RegRvName"] = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        Session["CustViewRvID"] = CarsDetails.Tables[0].Rows[0]["carId"].ToString();
                        int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());


                        string StockMake = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        StockMake = StockMake.Replace(" ", "-");
                        StockMake = StockMake.Replace("/", "@");
                        string StockType = CarsDetails.Tables[0].Rows[0]["TypeName"].ToString();
                        StockType = StockType.Replace(" ", "-");
                        string StockUrl = "http://unitedrvexchange.com/images/MakeModelThumbs/" + StockType + "_" + StockMake + ".jpg";
                        ImgStockPhoto.ImageUrl = StockUrl;


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

                            Session["RvPaymentID"] = CarsDetails.Tables[2].Rows[0]["pmntID"].ToString();

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
                            Session["EditRvPayStatus"] = CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString();
                            hdnPayStatus.Value = Session["EditRvPayStatus"].ToString();
                            GetDataStatus();
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
                        }
                        else
                        {
                            trListingStatus.Style["display"] = "block";
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
                    }
                }
            }
        }
    }
    private void GetAllMakes()
    {
        try
        {
            DataSet dsAllMakes = new DataSet();
            if (Session["RvAllMakes"] == null)
            {
                dsAllMakes = objRvMainBL.USP_GetAllMakes(0);
                Session["RvAllMakes"] = dsAllMakes;
            }
            else
            {
                dsAllMakes = Session["RvAllMakes"] as DataSet;
            }
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
    private void FillYear()
    {
        try
        {
            DataSet dsYears = new DataSet();
            if (Session["RvYears"] == null)
            {
                dsYears = objRvMainBL.GetYears();
                Session["RvYears"] = dsYears;
            }
            else
            {
                dsYears = Session["RvYears"] as DataSet;
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
    private void FillType()
    {
        try
        {
            DataSet dsAllTypes = new DataSet();
            if (Session["RvAllTypes"] == null)
            {
                dsAllTypes = objRvMainBL.GetAllTypes();
                Session["RvAllTypes"] = dsAllTypes;
            }
            else
            {
                dsAllTypes = Session["RvAllTypes"] as DataSet;
            }

            ddlType.DataSource = dsAllTypes.Tables[0];
            ddlType.DataTextField = "TypeName";
            ddlType.DataValueField = "TypeID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillPayType()
    {
        try
        {
            DataSet dsPaymentMethod = new DataSet();
            if (Session["RvPayMethod"] == null)
            {
                dsPaymentMethod = objRvMainBL.GetPaymentMethod();
                Session["RvPayMethod"] = dsPaymentMethod;
            }
            else
            {
                dsPaymentMethod = Session["RvPayMethod"] as DataSet;
            }
            ddlPayMethod.DataSource = dsPaymentMethod.Tables[0];
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
            DataSet dsPayStatus = new DataSet();
            if (Session["RvPayStatus"] == null)
            {
                dsPayStatus = objRvMainBL.SmartzGetPaymentStatus();
                Session["RvPayStatus"] = dsPayStatus;
            }
            else
            {
                dsPayStatus = Session["RvPayStatus"] as DataSet;
            }
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
    private void FillInteriorColor()
    {
        try
        {
            DataSet dsGetInteriorColors = new DataSet();
            if (Session["RvInteriorColors"] == null)
            {
                dsGetInteriorColors = objRvMainBL.GetInteriorColors();
                Session["RvInteriorColors"] = dsGetInteriorColors;
            }
            else
            {
                dsGetInteriorColors = Session["RvInteriorColors"] as DataSet;
            }
            ddlInteriorColor.DataSource = dsGetInteriorColors.Tables[0];
            ddlInteriorColor.DataTextField = "InteriorColorName";
            ddlInteriorColor.DataValueField = "InteriorColorName";
            ddlInteriorColor.DataBind();
            ddlInteriorColor.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
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
    private void FillExteriorColor()
    {
        try
        {
            DataSet dsGetExteriorColors = new DataSet();
            if (Session["RvExteriorColors"] == null)
            {
                dsGetExteriorColors = objRvMainBL.GetExteriorColors();
                Session["RvExteriorColors"] = dsGetExteriorColors;
            }
            else
            {
                dsGetExteriorColors = Session["RvExteriorColors"] as DataSet;
            }
            ddlExteriorColor.DataSource = dsGetExteriorColors.Tables[0];
            ddlExteriorColor.DataTextField = "ExteriorColorName";
            ddlExteriorColor.DataValueField = "ExteriorColorName";
            ddlExteriorColor.DataBind();
            ddlExteriorColor.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
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


    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GetModelsInfo();
        }
        catch (Exception ex)
        {
        }
    }
    public void GetModelsInfo()
    {
        try
        {
            DataSet dsMakes = Session["RvAllMakes"] as DataSet;
            int RVTYPE = Convert.ToInt32(ddlType.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsMakes.Tables[0].DefaultView;
            dvModel.RowFilter = "RVTYPE='" + RVTYPE.ToString() + "'";
            dtModel = dvModel.ToTable();
            ddlMake.DataSource = dtModel;
            ddlMake.Items.Clear();
            ddlMake.DataTextField = "make";
            ddlMake.DataValueField = "makeID";
            ddlMake.DataBind();
            ddlMake.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }


    private void FillCondition()
    {
        try
        {
            DataSet dsGetCondition = new DataSet();
            if (Session["RvCondition"] == null)
            {
                dsGetCondition = objRvMainBL.GetVehicleCondition();
                Session["RvCondition"] = dsGetCondition;
            }
            else
            {
                dsGetCondition = Session["RvCondition"] as DataSet;
            }
            ddlCondition.DataSource = dsGetCondition.Tables[0];
            ddlCondition.DataTextField = "condition";
            ddlCondition.DataValueField = "conditionID";
            ddlCondition.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    private void FillFuelTypes()
    {
        try
        {
            DataSet dsGetFuelTypes = new DataSet();
            if (Session["RvFuelTypes"] == null)
            {
                dsGetFuelTypes = objRvMainBL.GetFuelTypes();
                Session["RvFuelTypes"] = dsGetFuelTypes;
            }
            else
            {
                dsGetFuelTypes = Session["RvFuelTypes"] as DataSet;
            }
            ddlFuelType.DataSource = dsGetFuelTypes.Tables[0];
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
            DataSet dsGetAllDoors = new DataSet();
            if (Session["RvAllDoors"] == null)
            {
                dsGetAllDoors = objRvMainBL.GetAllDoors();
                Session["RvAllDoors"] = dsGetAllDoors;
            }
            else
            {
                dsGetAllDoors = Session["RvAllDoors"] as DataSet;
            }
            ddlDoorCount.DataSource = dsGetAllDoors.Tables[0];
            ddlDoorCount.DataTextField = "DoorsCount";
            ddlDoorCount.DataValueField = "DoorsCount";
            ddlDoorCount.DataBind();
            ddlDoorCount.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillEngineManufacturer()
    {
        try
        {
            DataSet dsGetEngineManufacturers = new DataSet();
            if (Session["RvEngineManufacturer"] == null)
            {
                dsGetEngineManufacturers = objRvMainBL.GetEngineManufacturer();
                Session["RvEngineManufacturer"] = dsGetEngineManufacturers;
            }
            else
            {
                dsGetEngineManufacturers = Session["RvEngineManufacturer"] as DataSet;
            }
            ddlEngineManufacturer.DataSource = dsGetEngineManufacturers.Tables[0];
            ddlEngineManufacturer.DataTextField = "EngineName";
            ddlEngineManufacturer.DataValueField = "EngineName";
            ddlEngineManufacturer.DataBind();
            ddlEngineManufacturer.Items.Insert(0, new ListItem("Unspecified", "Unspecified"));
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
            //string LoginPassword = Session["RegRvPassword"].ToString();
            //string LoginName = Session["RegRvUserName"].ToString();
            //string UserDisName = Session["RegRvName"].ToString();
            //clsMailFormats format = new clsMailFormats();
            //string text = string.Empty;

            //if (Session["EditRvPayStatus"].ToString() == "5")
            //{
            //    DateTime PostDate = Convert.ToDateTime(Session["EditRvPDDate"].ToString());
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
            int CarID = Convert.ToInt32(Session["CustViewRvID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtNewIntNotes.Text.Trim();
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objRvMainBL.UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
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
            //string LoginPassword = Session["RegRvPassword"].ToString();
            //string LoginName = Session["RegRvUserName"].ToString();
            //string UserDisName = Session["RegRvName"].ToString();
            //clsMailFormats format = new clsMailFormats();
            //MailMessage msg = new MailMessage();
            //msg.From = new MailAddress("info@unitedcarexchange.com");
            //msg.To.Add(LoginName);
            //if (txtEmailTo.Text != "")
            //{ 
            //    msg.CC.Add(txtEmailTo.Text);
            //}
            //msg.Bcc.Add("archive@unitedcarexchange.com");
            //msg.Subject = "Registration Details From United Rv Exchange For RV ID# " + Session["EditRvID"].ToString();
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

            objRvUsedCarsInfo.PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            objUserRegInfo.UId = Convert.ToInt32(Session["EditRvUID"].ToString());
            int UID = Convert.ToInt32(Session["EditRvUID"].ToString());

            objRvUsedCarsInfo.SellerID = Convert.ToInt32(Session["EditRvsellerID"].ToString());
            objRvUsedCarsInfo.UserPackID = Convert.ToInt32(Session["EditRvUserPackID"].ToString());
            int UserPackID = Convert.ToInt32(Session["EditRvUserPackID"].ToString());

            objUserRegInfo.Name = objGeneralFunc.ToProper(txtRegName.Text).Trim();
            string RegUserName = objGeneralFunc.ToProper(txtRegName.Text).Trim();
            objUserRegInfo.PhoneNumber = txtRegPhNo.Text;
            objUserRegInfo.City = objGeneralFunc.ToProper(txtRegCity.Text).Trim();
            objUserRegInfo.StateID = Convert.ToInt32(ddlRegState.SelectedItem.Value);
            objUserRegInfo.Address = objGeneralFunc.ToProper(txtRegAddress.Text).Trim();
            objUserRegInfo.BusinessName = txtRegBusinessName.Text;
            objUserRegInfo.AltEmail = txtRegAltEmail.Text;
            objUserRegInfo.AltPhone = txtRegAltPhoneNum.Text;
            objUserRegInfo.Zip = txtregZip.Text;
            objUserRegInfo.UserName = txtLoginEmail.Text;
            objUserRegInfo.Pwd = txtLoginPassword.Text;
            objUserRegInfo.ReferCode = objGeneralFunc.ToProper(txtAgent.Text).Trim();


            objRvCarsInfo.YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Text);
            objRvCarsInfo.Model = objGeneralFunc.ToProper(txtModel.Text);
            objRvCarsInfo.Title = txtTitle.Text;
            objRvCarsInfo.MakeModelID = Convert.ToInt32(ddlMake.SelectedItem.Value);

            if (txtAskingPrice.Text == "")
            {
                objRvCarsInfo.Price = "0";
            }
            else
            {
                objRvCarsInfo.Price = txtAskingPrice.Text;
            }

            if (txtMileage.Text == "")
            {
                objRvCarsInfo.Mileage = "0";
            }
            else
            {
                objRvCarsInfo.Mileage = txtMileage.Text;
            }
            objRvCarsInfo.ExteriorColor = ddlExteriorColor.SelectedItem.Text;
            objRvCarsInfo.InteriorColor = ddlInteriorColor.SelectedItem.Text;
            objRvCarsInfo.NumberOfDoors = ddlDoorCount.SelectedItem.Value;
            objRvCarsInfo.VIN = txtVinNumber.Text;
            objRvCarsInfo.FuelTypeID = Convert.ToInt32(ddlFuelType.SelectedItem.Value);
            objRvCarsInfo.Description = txtDescription.Text;
            objRvCarsInfo.ConditionDescription = ddlCondition.SelectedItem.Text;
            objRvCarsInfo.AirConditioners = Convert.ToInt32(ddlAirConditioners.SelectedItem.Value);
            objRvCarsInfo.Length = txtLength.Text;
            objRvCarsInfo.WaterCapacity = txtWaterCapacity.Text;
            objRvCarsInfo.Towing_Capacity = txtTowingCapacity.Text;
            objRvCarsInfo.Dry_Weight = txtDryWeight.Text;
            objRvCarsInfo.SleepingCapacity = Convert.ToInt32(ddlSleepingCapacity.SelectedItem.Value);
            objRvCarsInfo.SlideOuts = Convert.ToInt32(ddlSlideOuts.SelectedItem.Value);
            objRvCarsInfo.EngineManufacturer = ddlEngineManufacturer.SelectedItem.Text;
            objRvCarsInfo.EngineType = txtEngineModel.Text;
            objRvCarsInfo.VehicleConditionID = Convert.ToInt32(ddlCondition.SelectedItem.Value);
            objRvCarsInfo.CarID = Convert.ToInt32(Session["EditRvID"].ToString());
            int CarID = Convert.ToInt32(Session["EditRvID"].ToString());


            objRvCarsInfo.StateID = Convert.ToInt32(ddlRegState.SelectedItem.Value);


            objRvSellerInfo.Phone = txtCustPhoneNumber.Text;
            objRvSellerInfo.City = objGeneralFunc.ToProper(txtCity.Text);
            objRvSellerInfo.AltPhone = txtCustAltNumber.Text;
            objRvSellerInfo.State = ddlLocationState.SelectedItem.Text;
            objRvSellerInfo.Email = txtSellerEmail.Text;
            objRvSellerInfo.Zip = txtZip.Text;

            objRvUsedCarsInfo.PackageID = Convert.ToInt32(Session["EditRvPackageID"].ToString());
            int PackageID = Convert.ToInt32(Session["EditRvPackageID"].ToString());
            objRvUsedCarsInfo.IsActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
            int IsActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
            int FeatureID;
            int IsactiveFea;
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtNewIntNotes.Text.Trim();
            InternalNotesNew = InternalNotesNew.Trim();
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            if (InternalNotesNew != "")
            {
                objRvCarsInfo.InternalNotes = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            }
            else
            {
                objRvCarsInfo.InternalNotes = InternalNotesNew.Trim();
            }

            int PmntType = Convert.ToInt32(ddlPayMethod.SelectedItem.Value);
            int PmntStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
            int PaymentID;
            DateTime PaymentDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
            string ConfirmNo = string.Empty;
            string VoiceFileName = string.Empty;

            if (Session["RvPaymentID"] == null)
            {
                PaymentID = Convert.ToInt32(0);
            }
            else if (Session["RvPaymentID"].ToString() == "")
            {
                PaymentID = Convert.ToInt32(0);
            }
            else
            {
                PaymentID = Convert.ToInt32(Session["RvPaymentID"]);
            }
            String strHostName = Request.UserHostAddress.ToString();
            objRvUsedCarsInfo.Ip = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            int ListingStatus;
            if (IsActive == 1)
            {
                objRvUsedCarsInfo.AdStatus = 1;
            }
            else
            {
                objRvUsedCarsInfo.AdStatus = Convert.ToInt32(ddlListingStatus.SelectedItem.Value);
            }
            DataSet dsUserExists = objRvMainBL.SmartzChkUserExistsForUpdate(RegUserName, UID);
            if (dsUserExists.Tables.Count > 0)
            {
                if (dsUserExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Email " + objGeneralFunc.ToProper(txtRegName.Text).Trim() + " already exists";
                }
                else
                {
                    if (PmntStatus == 2)
                    {
                        if (Session["EditRvPayStatus"].ToString() == "2")
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
                    bool bnew = objRvMainBL.SmartzUpdateRegUserDetails(objUserRegInfo, TranBy);
                    bool bnewcar = objRvMainBL.SmartzUpdateRVEditData(objRvSellerInfo, objRvCarsInfo, objRvUsedCarsInfo, TranBy);
                    for (int i = 1; i < 4; i++)
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
                        DataSet dsCarFeature = objRvMainBL.SmartzSaveRvFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                    }
                    if (PackageID != 1)
                    {
                        if (PmntStatus == 2)
                        {
                            bool BnewPay = objRvMainBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                        }
                        else
                        {
                            bool BnewPay = objRvMainBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                        }
                    }

                    int IsLocked = 0;
                    DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);
                    mpealteruserUpdated.Show();
                    lblErrUpdated.Visible = true;
                    lblErrUpdated.Text = "Updated successfully";
                }
            }
            else
            {
                if (PmntStatus == 2)
                {
                    if (Session["EditRvPayStatus"].ToString() == "2")
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
                bool bnew = objRvMainBL.SmartzUpdateRegUserDetails(objUserRegInfo, TranBy);
                bool bnewcar = objRvMainBL.SmartzUpdateRVEditData(objRvSellerInfo, objRvCarsInfo, objRvUsedCarsInfo, TranBy);
                for (int i = 1; i < 4; i++)
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
                    DataSet dsCarFeature = objRvMainBL.SmartzSaveRvFeatures(CarID, FeatureID, IsactiveFea, TranBy);
                }
                if (PackageID != 1)
                {
                    if (PmntStatus == 2)
                    {
                        bool BnewPay = objRvMainBL.USP_SmartzUpdatePayDetailsForPaid(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, PaymentDate, ConfirmNo, VoiceFileName, UserPackID);
                    }
                    else
                    {
                        bool BnewPay = objRvMainBL.USP_SmartzUpdatePayDetails(PmntType, PmntStatus, strIp, UID, PaymentID, TranBy, PostingID, UserPackID);
                    }
                }
                int IsLocked = 0;
                DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);
                mpealteruserUpdated.Show();
                lblErrUpdated.Visible = true;
                lblErrUpdated.Text = "Updated successfully";
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
            Response.Redirect("RvCustomerView.aspx");
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
            Response.Redirect("RvCustomerView.aspx");
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
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);

            //FillTicketDropdown();
            //Response.Redirect("RvCustomerView.aspx");
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
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);
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
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);
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
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);
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
                Response.Redirect("RvCustomerView.aspx");
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
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int IsLocked = 0;
            DataSet dsLockCust = objRvMainBL.USP_Lock_Customer(PostingID, IsLocked);
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

            txtSpokenWith.Text = Session["RvRegName"].ToString();

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
            int CarID = Convert.ToInt32(Session["CustViewRvID"].ToString());
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
                DataSet dsNewIntNotes = objRvMainBL.UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                Session.Timeout = 180;
            }

            if (TicketConfirm.Value == "false")
            {
                bool bnew = objRvMainBL.USP_SmartzSaveCSDetails(CarID, UID, CallType, CallReason, Notes, CallResolution, SpokeWith);
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
                    DataSet dsNewIntNotes = objRvMainBL.UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                    Session.Timeout = 180;
                }
                bool bnew = objRvMainBL.USP_SmartzSaveCSandTicketDetails(CarID, UID, CallType, CallReason, Notes, TicketType, Priority, CallBackID, TicketDescription, CallResolution, SpokeWith);
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
                Response.Redirect("RvCustomerView.aspx");
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
            }
            else
            {
                trListingStatus.Style["display"] = "block";
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
                if (Session["EditRvPayStatus"].ToString() == "2")
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
            int PostingID = Convert.ToInt32(Session["RvPostingID"].ToString());
            int UserPackID = Convert.ToInt32(Session["EditRvUserPackID"].ToString());
            int TranBY = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet UpData = objRvMainBL.SmartzUpdatePDDateRV(TranBY, PDDate, UserPackID, PostingID);
            DateTime dtdatePD = Convert.ToDateTime(UpData.Tables[0].Rows[0]["PDDate"].ToString());
            lblPDDate.Text = dtdatePD.ToString("MM/dd/yyyy");



            DateTime OldPdDateTime = Convert.ToDateTime(Session["EditRvPDDate"].ToString());
            string OldPDDate = OldPdDateTime.ToString("MM/dd/yyyy");
            int CarID = Convert.ToInt32(Session["EditRvID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = "PD Date changed  from " + OldPDDate + " to " + dtdatePD.ToString("MM/dd/yyyy");
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objRvMainBL.UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
            Session.Timeout = 180;
            if (dsNewIntNotes.Tables[0].Rows.Count > 0)
            {
                string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["InternalNotes"].ToString();
                OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                txtOldIntNotes.Text = OldNotes;
                txtNewIntNotes.Text = "";
            }
            Session["EditRvPDDate"] = dtdatePD;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}
