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

public partial class CarCustomerEditNewForm : System.Web.UI.Page
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
                FillPackage();
                FillVoiceFileLocation();
                // FillCheckTypes();
                FillPopPaymentDate();
                int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                CarsDetails = objdropdownBL.GetCustomerDetailsByPostingIDForNewView(PostingID);
                Session["EditCarDetailsDataset"] = CarsDetails;
                if (CarsDetails.Tables.Count > 0)
                {
                    if (CarsDetails.Tables[0].Rows.Count > 0)
                    {
                        Session["EditUID"] = CarsDetails.Tables[0].Rows[0]["uid"].ToString();
                        Session["EditCarID"] = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        Session["EditsellerID"] = CarsDetails.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["EditUserPackID"] = CarsDetails.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["EditPackageID"] = CarsDetails.Tables[0].Rows[0]["packageID"].ToString();
                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["PackagePrice"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = CarsDetails.Tables[0].Rows[0]["PackageName"].ToString();
                        ListItem listPack = new ListItem();
                        listPack.Value = CarsDetails.Tables[0].Rows[0]["PackageID"].ToString();
                        listPack.Text = PackName + " ($" + PackAmount + ")";
                        ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(listPack);

                        Session["EditPackageName"] = PackName.ToString();

                        lblSalesAgent.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        lblVerifier.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["VerifierID"].ToString());
                        txtFirstName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[0].Rows[0]["Name"].ToString());
                        txtLastName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[0].Rows[0]["SellerLastName"].ToString());
                        if (CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString() == "")
                        {
                            txtPhone.Text = "";
                        }
                        else
                        {
                            txtPhone.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                        }
                        if (CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                        {
                            Session["EditCarEmailExists"] = 0;
                            chkbxEMailNA.Checked = true;
                            txtEmail.Text = "";
                        }
                        else
                        {
                            Session["EditCarEmailExists"] = 1;
                            chkbxEMailNA.Checked = false;
                            txtEmail.Text = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        }
                        txtAddress.Text = CarsDetails.Tables[0].Rows[0]["Address"].ToString();
                        txtCity.Text = CarsDetails.Tables[0].Rows[0]["RegCity"].ToString();
                        ListItem listRegState = new ListItem();
                        listRegState.Value = CarsDetails.Tables[0].Rows[0]["StateID"].ToString();
                        listRegState.Text = CarsDetails.Tables[0].Rows[0]["State_Code"].ToString();
                        ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(listRegState);
                        txtZip.Text = CarsDetails.Tables[0].Rows[0]["RegZip"].ToString();


                        ListItem list2 = new ListItem();
                        list2.Value = CarsDetails.Tables[0].Rows[0]["MakeID"].ToString();
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

                        ListItem listBody = new ListItem();
                        listBody.Value = CarsDetails.Tables[0].Rows[0]["bodyTypeID"].ToString();
                        listBody.Text = CarsDetails.Tables[0].Rows[0]["bodyType"].ToString();
                        ddlBodyStyle.SelectedIndex = ddlBodyStyle.Items.IndexOf(listBody);
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

                        string NumberOfCylinder = CarsDetails.Tables[0].Rows[0]["numberOfCylinder"].ToString();
                        if (NumberOfCylinder == "3 Cylinder")
                        {
                            rdbtnCylinders1.Checked = true;
                            rdbtnCylinders7.Checked = false;
                        }
                        else if (NumberOfCylinder == "4 Cylinder")
                        {
                            rdbtnCylinders2.Checked = true;
                            rdbtnCylinders7.Checked = false;
                        }
                        else if (NumberOfCylinder == "5 Cylinder")
                        {
                            rdbtnCylinders3.Checked = true;
                            rdbtnCylinders7.Checked = false;
                        }
                        else if (NumberOfCylinder == "6 Cylinder")
                        {
                            rdbtnCylinders4.Checked = true;
                            rdbtnCylinders7.Checked = false;
                        }
                        else if (NumberOfCylinder == "7 Cylinder")
                        {
                            rdbtnCylinders5.Checked = true;
                            rdbtnCylinders7.Checked = false;
                        }
                        else if (NumberOfCylinder == "8 Cylinder")
                        {
                            rdbtnCylinders6.Checked = true;
                            rdbtnCylinders7.Checked = false;
                        }
                        else
                        {
                            rdbtnCylinders7.Checked = true;
                        }
                        ListItem list7 = new ListItem();
                        list7.Value = CarsDetails.Tables[0].Rows[0]["exteriorColor"].ToString();
                        list7.Text = CarsDetails.Tables[0].Rows[0]["exteriorColor"].ToString();
                        ddlExteriorColor.SelectedIndex = ddlExteriorColor.Items.IndexOf(list7);


                        ListItem list8 = new ListItem();
                        list8.Text = CarsDetails.Tables[0].Rows[0]["interiorColor"].ToString();
                        list8.Value = CarsDetails.Tables[0].Rows[0]["interiorColor"].ToString();
                        ddlInteriorColor.SelectedIndex = ddlInteriorColor.Items.IndexOf(list8);

                        string Transmission = CarsDetails.Tables[0].Rows[0]["Transmission"].ToString();
                        if (Transmission == "Automatic")
                        {
                            rdbtnTrans1.Checked = true;
                            rdbtnTrans4.Checked = false;
                        }
                        else if (Transmission == "Manual")
                        {
                            rdbtnTrans2.Checked = true;
                            rdbtnTrans4.Checked = false;
                        }
                        else if (Transmission == "Tiptronic")
                        {
                            rdbtnTrans3.Checked = true;
                            rdbtnTrans4.Checked = false;
                        }
                        else
                        {
                            rdbtnTrans4.Checked = true;
                        }
                        string NumberOfDoors = CarsDetails.Tables[0].Rows[0]["numberOfDoors"].ToString();
                        if (NumberOfDoors == "Two Door")
                        {
                            rdbtnDoor2.Checked = true;
                            rdbtnDoor6.Checked = false;
                        }
                        else if (NumberOfDoors == "Three Door")
                        {
                            rdbtnDoor3.Checked = true;
                            rdbtnDoor6.Checked = false;
                        }
                        else if (NumberOfDoors == "Four Door")
                        {
                            rdbtnDoor4.Checked = true;
                            rdbtnDoor6.Checked = false;
                        }

                        else if (NumberOfDoors == "Five Door")
                        {
                            rdbtnDoor5.Checked = true;
                            rdbtnDoor6.Checked = false;
                        }
                        else
                        {
                            rdbtnDoor6.Checked = true;
                        }
                        string DriveTrain = CarsDetails.Tables[0].Rows[0]["DriveTrain"].ToString();
                        if (DriveTrain == "2 wheel drive")
                        {
                            rdbtnDriveTrain1.Checked = true;
                            rdbtnDriveTrain5.Checked = false;
                        }
                        else if (DriveTrain == "2 wheel drive - front")
                        {
                            rdbtnDriveTrain2.Checked = true;
                            rdbtnDriveTrain5.Checked = false;
                        }
                        else if (DriveTrain == "All wheel drive")
                        {
                            rdbtnDriveTrain3.Checked = true;
                            rdbtnDriveTrain5.Checked = false;
                        }
                        else if (DriveTrain == "Rear wheel drive")
                        {
                            rdbtnDriveTrain4.Checked = true;
                            rdbtnDriveTrain5.Checked = false;
                        }
                        else
                        {
                            rdbtnDriveTrain5.Checked = true;
                        }
                        txtVin.Text = CarsDetails.Tables[0].Rows[0]["VIN"].ToString();

                        int FuelTypeID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["fuelTypeID"].ToString());
                        if (FuelTypeID == 1)
                        {
                            rdbtnFuelType1.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else if (FuelTypeID == 2)
                        {
                            rdbtnFuelType2.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else if (FuelTypeID == 3)
                        {
                            rdbtnFuelType3.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else if (FuelTypeID == 4)
                        {
                            rdbtnFuelType4.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else if (FuelTypeID == 5)
                        {
                            rdbtnFuelType5.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else if (FuelTypeID == 6)
                        {
                            rdbtnFuelType6.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else if (FuelTypeID == 7)
                        {
                            rdbtnFuelType7.Checked = true;
                            rdbtnFuelType8.Checked = false;
                        }
                        else
                        {
                            rdbtnFuelType8.Checked = true;
                        }
                        int ConditionID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["conditionID"].ToString());
                        if (ConditionID == 1)
                        {
                            rdbtnCondition1.Checked = true;
                            rdbtnCondition7.Checked = false;
                        }
                        else if (ConditionID == 2)
                        {
                            rdbtnCondition2.Checked = true;
                            rdbtnCondition7.Checked = false;
                        }
                        else if (ConditionID == 3)
                        {
                            rdbtnCondition3.Checked = true;
                            rdbtnCondition7.Checked = false;
                        }
                        else if (ConditionID == 4)
                        {
                            rdbtnCondition4.Checked = true;
                            rdbtnCondition7.Checked = false;
                        }
                        else if (ConditionID == 5)
                        {
                            rdbtnCondition5.Checked = true;
                            rdbtnCondition7.Checked = false;
                        }
                        else if (ConditionID == 6)
                        {
                            rdbtnCondition6.Checked = true;
                            rdbtnCondition7.Checked = false;
                        }
                        else
                        {
                            rdbtnCondition7.Checked = true;
                        }
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
                                }
                            }
                        }
                        if (CarsDetails.Tables[3].Rows[9]["Isactive"].ToString() == "True")
                        {
                            rdbtnLeather.Checked = true;
                            rdbtnInteriorNA.Checked = false;
                        }
                        if (CarsDetails.Tables[3].Rows[36]["Isactive"].ToString() == "True")
                        {
                            rdbtnVinyl.Checked = true;
                            rdbtnInteriorNA.Checked = false;
                        }
                        if (CarsDetails.Tables[3].Rows[37]["Isactive"].ToString() == "True")
                        {
                            rdbtnCloth.Checked = true;
                            rdbtnInteriorNA.Checked = false;
                        }
                        if (CarsDetails.Tables[3].Rows.Count.ToString() == "53")
                        {
                            if (CarsDetails.Tables[3].Rows[53]["Isactive"].ToString() == "True")
                            {
                                rdbtnInteriorNA.Checked = true;
                            }
                        }

                        txtDescription.Text = CarsDetails.Tables[0].Rows[0]["description"].ToString();
                        string OldNotes = CarsDetails.Tables[0].Rows[0]["InternalNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtSaleNotes.Text = OldNotes;

                        ListItem liSourceofPhotos = new ListItem();
                        liSourceofPhotos.Text = CarsDetails.Tables[0].Rows[0]["SourceOfPhotosName"].ToString();
                        liSourceofPhotos.Value = CarsDetails.Tables[0].Rows[0]["SourceOfPhotosID"].ToString();
                        ddlPhotosSource.SelectedIndex = ddlPhotosSource.Items.IndexOf(liSourceofPhotos);

                        ListItem liSourceofDescription = new ListItem();
                        liSourceofDescription.Text = CarsDetails.Tables[0].Rows[0]["SourceOfDescriptionName"].ToString();
                        liSourceofDescription.Value = CarsDetails.Tables[0].Rows[0]["SourceOfDescriptionID"].ToString();
                        ddlDescriptionSource.SelectedIndex = ddlDescriptionSource.Items.IndexOf(liSourceofDescription);
                        if (CarsDetails.Tables[2].Rows.Count > 0)
                        {
                            Session["ViewPayStatus"] = CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString();
                            if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 1)
                            {
                                rdbtnPayVisa.Checked = true;
                            }
                            else if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 2)
                            {
                                rdbtnPayMasterCard.Checked = true;
                            }
                            else if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 3)
                            {
                                rdbtnPayAmex.Checked = true;
                            }
                            else if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 4)
                            {
                                rdbtnPayDiscover.Checked = true;
                            }
                            else if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 5)
                            {
                                rdbtnPayCheck.Checked = true;
                            }
                            else
                            {
                                rdbtnPayPaypal.Checked = true;
                            }
                            if ((Session["ViewPayStatus"].ToString() == "1") || (Session["ViewPayStatus"].ToString() == "5"))
                            {
                                rdbtnPayVisa.Enabled = true;
                                rdbtnPayMasterCard.Enabled = true;
                                rdbtnPayAmex.Enabled = true;
                                rdbtnPayDiscover.Enabled = true;
                                rdbtnPayCheck.Enabled = true;
                                rdbtnPayPaypal.Enabled = true;
                            }
                            else
                            {
                                rdbtnPayVisa.Enabled = false;
                                rdbtnPayMasterCard.Enabled = false;
                                rdbtnPayAmex.Enabled = false;
                                rdbtnPayDiscover.Enabled = false;
                                rdbtnPayCheck.Enabled = false;
                                rdbtnPayPaypal.Enabled = false;
                            }
                            if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 5)
                            {
                                divcard.Style["display"] = "none";
                                divcheck.Style["display"] = "block";
                                divpaypal.Style["display"] = "none";
                                txtCustNameForCheck.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["bankAccountHolderName"].ToString());
                                txtAccNumberForCheck.Text = CarsDetails.Tables[2].Rows[0]["bankAccountNumber"].ToString();
                                txtBankNameForCheck.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["bankName"].ToString());
                                txtRoutingNumberForCheck.Text = CarsDetails.Tables[2].Rows[0]["bankRouting"].ToString();
                                //lblAccountType.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["AccountTypeName"].ToString());
                                ListItem liAccType = new ListItem();
                                liAccType.Text = CarsDetails.Tables[2].Rows[0]["AccountTypeName"].ToString();
                                liAccType.Value = CarsDetails.Tables[2].Rows[0]["bankAccountType"].ToString();
                                ddlAccType.SelectedIndex = ddlAccType.Items.IndexOf(liAccType);

                                //ListItem liCheckType = new ListItem();
                                //liCheckType.Text = CarsDetails.Tables[2].Rows[0]["CheckTypeName"].ToString();
                                //liCheckType.Value = CarsDetails.Tables[2].Rows[0]["CheckTypeID"].ToString();
                                //ddlCheckType.SelectedIndex = ddlCheckType.Items.IndexOf(liCheckType);
                                //txtCheckNumber.Text = CarsDetails.Tables[2].Rows[0]["BankCheckNumber"].ToString();
                                if ((Session["ViewPayStatus"].ToString() == "1") || (Session["ViewPayStatus"].ToString() == "5"))
                                {
                                    txtCustNameForCheck.Enabled = true;
                                    txtAccNumberForCheck.Enabled = true;
                                    txtBankNameForCheck.Enabled = true;
                                    txtRoutingNumberForCheck.Enabled = true;
                                    ddlAccType.Enabled = true;
                                    txtPaymentDate.Enabled = true;
                                    txtPDAmountNow.Enabled = true;
                                    chkboxlstPDsale.Enabled = true;
                                    ddlPDDate.Enabled = true;
                                    txtPDAmountLater.Enabled = true;
                                }
                                else
                                {
                                    txtCustNameForCheck.Enabled = false;
                                    txtAccNumberForCheck.Enabled = false;
                                    txtBankNameForCheck.Enabled = false;
                                    txtRoutingNumberForCheck.Enabled = false;
                                    ddlAccType.Enabled = false;
                                    txtPaymentDate.Enabled = false;
                                    txtPDAmountNow.Enabled = false;
                                    chkboxlstPDsale.Enabled = false;
                                    ddlPDDate.Enabled = false;
                                    txtPDAmountLater.Enabled = false;
                                }
                            }
                            else if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 6)
                            {
                                divcard.Style["display"] = "none";
                                divcheck.Style["display"] = "none";
                                divpaypal.Style["display"] = "block";
                                txtPaytransID.Text = CarsDetails.Tables[2].Rows[0]["TransactionID"].ToString();
                                txtpayPalEmailAccount.Text = CarsDetails.Tables[2].Rows[0]["cardholderLastName"].ToString();
                                if ((Session["ViewPayStatus"].ToString() == "1") || (Session["ViewPayStatus"].ToString() == "5"))
                                {
                                    txtPaytransID.Enabled = true;
                                    txtpayPalEmailAccount.Enabled = true;
                                    txtPaymentDate.Enabled = true;
                                    txtPDAmountNow.Enabled = true;
                                    chkboxlstPDsale.Enabled = true;
                                    ddlPDDate.Enabled = true;
                                    txtPDAmountLater.Enabled = true;
                                }
                                else
                                {
                                    txtPaytransID.Enabled = false;
                                    txtpayPalEmailAccount.Enabled = false;
                                    txtPaymentDate.Enabled = false;
                                    txtPDAmountNow.Enabled = false;
                                    chkboxlstPDsale.Enabled = false;
                                    ddlPDDate.Enabled = false;
                                    txtPDAmountLater.Enabled = false;
                                }
                            }
                            else
                            {
                                divcard.Style["display"] = "block";
                                divcheck.Style["display"] = "none";
                                divpaypal.Style["display"] = "none";
                                txtCardholderName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["cardholderName"].ToString());
                                //    lblCardType.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["cardType"].ToString());
                                txtCardholderLastName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["cardholderLastName"].ToString());
                                CardNumber.Text = CarsDetails.Tables[2].Rows[0]["cardNumber"].ToString();
                                string EXpDate = CarsDetails.Tables[2].Rows[0]["cardExpDt"].ToString();
                                string[] EXpDt = EXpDate.Split(new char[] { '/' });

                                ListItem liExpMnth = new ListItem();
                                liExpMnth.Text = EXpDt[0].ToString();
                                liExpMnth.Value = EXpDt[0].ToString();
                                ExpMon.SelectedIndex = ExpMon.Items.IndexOf(liExpMnth);

                                if (EXpDate.ToString() != "")
                                {
                                    ListItem liExpyear = new ListItem();
                                    liExpyear.Text = "20" + EXpDt[1].ToString();
                                    liExpyear.Value = EXpDt[1].ToString();
                                    CCExpiresYear.SelectedIndex = CCExpiresYear.Items.IndexOf(liExpyear);
                                }

                                cvv.Text = CarsDetails.Tables[2].Rows[0]["cardCode"].ToString();

                                txtbillingaddress.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["billingAdd"].ToString());
                                txtbillingcity.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["billingCity"].ToString());

                                ListItem liBillST = new ListItem();
                                liBillST.Value = CarsDetails.Tables[2].Rows[0]["billingState"].ToString();
                                liBillST.Text = CarsDetails.Tables[2].Rows[0]["State_Code"].ToString();
                                ddlbillingstate.SelectedIndex = ddlbillingstate.Items.IndexOf(liBillST);

                                txtbillingzip.Text = CarsDetails.Tables[2].Rows[0]["billingZip"].ToString();
                                if ((Session["ViewPayStatus"].ToString() == "1") || (Session["ViewPayStatus"].ToString() == "5"))
                                {
                                    txtCardholderName.Enabled = true;
                                    txtCardholderLastName.Enabled = true;
                                    CardNumber.Enabled = true;
                                    ExpMon.Enabled = true;
                                    CCExpiresYear.Enabled = true;
                                    cvv.Enabled = true;
                                    txtbillingaddress.Enabled = true;
                                    txtbillingcity.Enabled = true;
                                    ddlbillingstate.Enabled = true;
                                    txtbillingzip.Enabled = true;
                                    txtPaymentDate.Enabled = true;
                                    txtPDAmountNow.Enabled = true;
                                    chkboxlstPDsale.Enabled = true;
                                    ddlPDDate.Enabled = true;
                                    txtPDAmountLater.Enabled = true;
                                }
                                else
                                {
                                    txtCardholderName.Enabled = false;
                                    txtCardholderLastName.Enabled = false;
                                    CardNumber.Enabled = false;
                                    ExpMon.Enabled = false;
                                    CCExpiresYear.Enabled = false;
                                    cvv.Enabled = false;
                                    txtbillingaddress.Enabled = false;
                                    txtbillingcity.Enabled = false;
                                    ddlbillingstate.Enabled = false;
                                    txtbillingzip.Enabled = false;
                                    txtPaymentDate.Enabled = false;
                                    txtPDAmountNow.Enabled = false;
                                    chkboxlstPDsale.Enabled = false;
                                    ddlPDDate.Enabled = false;
                                    txtPDAmountLater.Enabled = false;
                                }
                            }

                            if (CarsDetails.Tables[0].Rows[0]["PaymentDate"].ToString() != "")
                            {
                                DateTime PayDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["PaymentDate"].ToString());
                                txtPaymentDate.Text = PayDate.ToString("MM/dd/yyyy");
                            }
                            txtPDAmountNow.Text = CarsDetails.Tables[2].Rows[0]["Amount"].ToString();
                            if (CarsDetails.Tables[0].Rows[0]["PDDate"].ToString() != "")
                            {
                                chkboxlstPDsale.Checked = true;
                                DateTime PDDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["PDDate"].ToString());
                                ListItem liPDDate = new ListItem();
                                liPDDate.Text = PDDate.ToString("MM/dd/yyyy");
                                liPDDate.Value = PDDate.ToString("MM/dd/yyyy");
                                ddlPDDate.SelectedIndex = ddlPDDate.Items.IndexOf(liPDDate);
                            }

                            txtPDAmountLater.Text = CarsDetails.Tables[2].Rows[0]["PDAmount"].ToString();
                            txtVoicefileConfirmNo.Text = CarsDetails.Tables[2].Rows[0]["VoiceRecord"].ToString();


                            ListItem liVoiceLocation = new ListItem();
                            liVoiceLocation.Text = CarsDetails.Tables[2].Rows[0]["VoiceFileLocationName"].ToString();
                            liVoiceLocation.Value = CarsDetails.Tables[2].Rows[0]["VoiceFileLocation"].ToString();
                            ddlVoiceFileLocation.SelectedIndex = ddlVoiceFileLocation.Items.IndexOf(liVoiceLocation);

                            double TotalAmount;
                            if (txtPDAmountLater.Text != "")
                            {
                                TotalAmount = Convert.ToDouble(txtPDAmountNow.Text) + Convert.ToDouble(txtPDAmountLater.Text);
                                txtTotalAmount.Text = string.Format("{0:0.00}", TotalAmount);
                            }
                            else
                            {
                                txtTotalAmount.Text = txtPDAmountNow.Text;
                            }
                        }
                        else
                        {
                            if (CarsDetails.Tables[0].Rows[0]["packageID"].ToString() == "1")
                            {
                                txtPDAmountNow.Text = "0.00";
                            }
                            double TotalAmount;
                            if (txtPDAmountLater.Text != "")
                            {
                                TotalAmount = Convert.ToDouble(txtPDAmountNow.Text) + Convert.ToDouble(txtPDAmountLater.Text);
                                txtTotalAmount.Text = string.Format("{0:0.00}", TotalAmount);
                            }
                            else
                            {
                                txtTotalAmount.Text = txtPDAmountNow.Text;
                            }
                        }
                    }
                }
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerViewNewForm.aspx");
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

            }
            if (Session["SavePaymentType"].ToString() == "5")
            {

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

        }
        catch (Exception ex)
        {
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
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
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
