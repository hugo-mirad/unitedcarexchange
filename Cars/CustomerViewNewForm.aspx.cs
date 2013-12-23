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

public partial class CustomerViewNewForm : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserregInfo = new UserRegistrationInfo();
    DataSet SmartzTicketDdlDs = new DataSet();
    DataSet dsActiveSmartzUsers = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
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
                if (Session["TicketDdl"] == null)
                {
                    SmartzTicketDdlDs = objdropdownBL.USP_SmartzTicketDropDown();
                    Session["TicketDdl"] = SmartzTicketDdlDs;
                }
                dsActiveSmartzUsers = objCentralDBBL.GetSmartzUsersActiveData();
                Session["ActiveSmartzUsers"] = dsActiveSmartzUsers;
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

                //fillYears(dsYears);
                FillYear();

                GetAllModels();
                GetMakes();
                GetModelsInfo();

                FillExteriorColor();
                FillInteriorColor();
                GetBody();
                //FillPaymentDate();
                //FillBillingStates();
                //FillPhotoSource();
                //FillDescriptionSource();
                FillRegStates();
                FillSellerStates();
                // FillVoiceFileLocation();


                int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                CarsDetails = objdropdownBL.GetCustomerDetailsByPostingIDForNewView(PostingID);
                Session["ViewCarDetailsDataset"] = CarsDetails;
                if (CarsDetails.Tables.Count > 0)
                {
                    if (CarsDetails.Tables[0].Rows.Count > 0)
                    {
                        lblCarID.Text = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        Session["ViewCarID"] = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        Session["ViewUID"] = CarsDetails.Tables[0].Rows[0]["uid"].ToString();
                        Session["ViewsellerID"] = CarsDetails.Tables[0].Rows[0]["sellerID"].ToString();
                        Session["ViewpaymentID"] = CarsDetails.Tables[0].Rows[0]["paymentID"].ToString();
                        Session["RegUserName"] = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        Session["RegPassword"] = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        Session["RegName"] = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        Session["RegLoginUserID"] = CarsDetails.Tables[0].Rows[0]["UserID"].ToString();
                        Session["RegEmailExists"] = CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString();
                        Session["CustViewCarID"] = CarsDetails.Tables[0].Rows[0]["carId"].ToString();

                        int UID = Convert.ToInt32(Session["ViewUID"].ToString());
                        DataSet dsUserInfoDetails = objdropdownBL.USP_GetUSerDetailsByUserID(UID);
                        DataSet dsUserLog = objdropdownBL.GetUCEUserLogByUID(UID);
                        //lblUserLogresults
                        if (dsUserLog.Tables[0].Rows.Count > 0)
                        {
                            lblUserLogresults.Visible = false;
                            grdUserLog.DataSource = dsUserLog.Tables[0];
                            grdUserLog.DataBind();
                        }
                        else
                        {
                            lblUserLogresults.Visible = true;
                            lblUserLogresults.Text = "No results found";
                        }
                        if (dsUserInfoDetails.Tables[2].Rows.Count > 0)
                        {
                            grdPackagDetails.DataSource = dsUserInfoDetails.Tables[2];
                            grdPackagDetails.DataBind();
                            lblSalePackageSummary.Text = dsUserInfoDetails.Tables[2].Rows.Count.ToString() + " Packages, ";
                        }
                        else
                        {
                            lblSalePackageSummary.Text = "0 Packages, ";
                        }
                        if (dsUserInfoDetails.Tables[1].Rows.Count > 0)
                        {
                            grdCarDetails.DataSource = dsUserInfoDetails.Tables[1];
                            grdCarDetails.DataBind();
                            lblSalePackageSummary.Text = lblSalePackageSummary.Text + dsUserInfoDetails.Tables[1].Rows.Count.ToString() + " Vehicles";
                        }
                        else
                        {
                            lblSalePackageSummary.Text = lblSalePackageSummary.Text + "0 Vehicles";
                        }

                        string sTable = CreateTable();
                        lblStatusHeader.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                        lblStatusHeader.Attributes.Add("onmouseout", "return nd(4000);");

                        lblAdStatus.Text = CarsDetails.Tables[0].Rows[0]["AdStatusName"].ToString();

                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["PackagePrice"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = CarsDetails.Tables[0].Rows[0]["PackageName"].ToString();
                        Session["ViewPackageName"] = PackName.ToString();

                        DateTime SaleDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["SaleDate"].ToString());
                        lblSaleDate.Text = SaleDate.ToString("MM/dd/yyyy hh:mm tt");

                        lblUserID.Text = CarsDetails.Tables[0].Rows[0]["UserID"].ToString();
                        lblPassword.Text = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        lblPackage.Text = PackName + "($" + PackAmount + ")";
                        //lblSalesAgent.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        //lblVerifier.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["VerifierID"].ToString());
                        lblRegName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[0].Rows[0]["Name"].ToString());
                        lblMainHeadName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[0].Rows[0]["Name"].ToString()) + ", " + CarsDetails.Tables[0].Rows[0]["sellerType"].ToString();
                        lblSellerFirstName.Text = CarsDetails.Tables[0].Rows[0]["sellerName"].ToString();
                        lblLastName.Text = objGeneralFunc.ToProper(CarsDetails.Tables[0].Rows[0]["SellerLastName"].ToString());
                        if (CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString() == "")
                        {
                            lblRegPhoneNumber.Text = "";
                        }
                        else
                        {
                            lblRegPhoneNumber.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                        }

                        if (CarsDetails.Tables[0].Rows[0]["RegAltPhone"].ToString() == "")
                        {
                            lblRegAltPhone.Text = "";
                        }
                        else
                        {
                            lblRegAltPhone.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["RegAltPhone"].ToString());
                        }
                        if (CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                        {
                            Session["ViewCarEmailExists"] = 0;
                            chkbxEMailNA.Checked = true;
                            lblRegEmail.Text = "";
                        }
                        else
                        {
                            Session["ViewCarEmailExists"] = 1;
                            chkbxEMailNA.Checked = false;
                            lblRegEmail.Text = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        }
                        lblRegAddress.Text = CarsDetails.Tables[0].Rows[0]["Address"].ToString();
                        lblRegCity.Text = CarsDetails.Tables[0].Rows[0]["RegCity"].ToString();
                        string RegSummary = string.Empty;
                        RegSummary = objGeneralFunc.ToProper(CarsDetails.Tables[0].Rows[0]["Name"].ToString().Trim()).Trim();
                        if (RegSummary != "")
                        {
                            if (CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "UN" || CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "")
                            {
                                RegSummary = RegSummary.Trim() + ", " + "Unspecified";
                            }
                            else
                            {
                                RegSummary = RegSummary.Trim() + ", " + CarsDetails.Tables[0].Rows[0]["State_Code"].ToString();
                            }

                            if (CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString() == "")
                            {
                                RegSummary = RegSummary + ", " + "Unspecified";
                            }
                            else
                            {
                                RegSummary = RegSummary + ", " + objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                            }
                            if (CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                            {
                                RegSummary = RegSummary + ", " + "Unspecified";
                            }
                            else
                            {
                                RegSummary = RegSummary + ", " + CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                            }
                        }
                        else
                        {
                            RegSummary = "Unspecified";
                            if (CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "UN" || CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "")
                            {
                                RegSummary = RegSummary + ", " + "Unspecified";
                            }
                            else
                            {
                                RegSummary = RegSummary + ", " + CarsDetails.Tables[0].Rows[0]["State_Code"].ToString();
                            }
                            if (CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString() == "")
                            {
                                RegSummary = RegSummary + ", " + "Unspecified";
                            }
                            else
                            {
                                RegSummary = RegSummary + ", " + objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                            }
                            if (CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                            {
                                RegSummary = RegSummary + ", " + "Unspecified";
                            }
                            else
                            {
                                RegSummary = RegSummary + ", " + CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                            }
                        }
                        lblRegistrantSummary.Text = RegSummary;
                        lblAddress.Text = CarsDetails.Tables[0].Rows[0]["address1"].ToString();
                        lblCity.Text = CarsDetails.Tables[0].Rows[0]["city"].ToString();
                        lblSellerEmail.Text = CarsDetails.Tables[0].Rows[0]["email"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["phone"].ToString() == "")
                        {
                            lblSellerPhone.Text = "";
                        }
                        else
                        {
                            lblSellerPhone.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["phone"].ToString());
                        }
                        if (CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "UN" || CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "")
                        {
                            lblRegState.Text = "Unspecified";
                        }
                        else
                        {
                            lblRegState.Text = CarsDetails.Tables[0].Rows[0]["State_Code"].ToString();
                        }

                        if (CarsDetails.Tables[0].Rows[0]["state"].ToString() == "UN" || CarsDetails.Tables[0].Rows[0]["state"].ToString() == "")
                        {
                            lblSellerState.Text = "Unspecified";
                        }
                        else
                        {
                            lblSellerState.Text = CarsDetails.Tables[0].Rows[0]["state"].ToString();
                        }


                        if (CarsDetails.Tables[0].Rows[0]["isActive"].ToString() == "True")
                        {
                            lblISActiveStatus.Text = "Active";
                            addStatDisp.Style["display"] = "none";
                        }
                        else
                        {
                            lblISActiveStatus.Text = "Inactive";
                            addStatDisp.Style["display"] = "block";
                        }
                        if (CarsDetails.Tables[0].Rows[0]["UceStatus"].ToString() == "1")
                        {
                            lblUceStatus.Text = "Active";
                        }
                        else
                        {
                            lblUceStatus.Text = "Inactive";
                        }
                        if (CarsDetails.Tables[0].Rows[0]["MultisiteStatus"].ToString() == "1")
                        {
                            lblMultiSiteStatus.Text = "Active";
                        }
                        else
                        {
                            lblMultiSiteStatus.Text = "Inactive";
                        }
                        lblListingStatus.Text = CarsDetails.Tables[0].Rows[0]["AdStatusName"].ToString();


                        lblRegZip.Text = CarsDetails.Tables[0].Rows[0]["RegZip"].ToString();
                        lblSellerZip.Text = CarsDetails.Tables[0].Rows[0]["zip"].ToString();
                        //ListItem list2 = new ListItem();
                        //list2.Value = CarsDetails.Tables[0].Rows[0]["makeID"].ToString();
                        //list2.Text = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        //ddlMake.SelectedIndex = ddlMake.Items.IndexOf(list2);
                        lblVehMake.Text = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        //GetModelsInfo();

                        //ListItem list3 = new ListItem();
                        //list3.Text = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                        //list3.Value = CarsDetails.Tables[0].Rows[0]["makeModelID"].ToString();
                        //ddlModel.SelectedIndex = ddlModel.Items.IndexOf(list3);
                        lblVehModel.Text = CarsDetails.Tables[0].Rows[0]["model"].ToString();

                        //ListItem list1 = new ListItem();
                        //list1.Text = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();
                        //list1.Value = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();
                        //ddlYear.SelectedIndex = ddlYear.Items.IndexOf(list1);
                        lblVehYear.Text = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();

                        string Year = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();
                        Session["ViewCarYear"] = Year;
                        string Model = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                        Session["ViewCarModel"] = Model;
                        string Make = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        Session["ViewCarMake"] = Make;
                        string UniqueID = CarsDetails.Tables[0].Rows[0]["CarUniqueID"].ToString();
                        Session["CarViewUniqueID"] = UniqueID;
                        Make = Make.Replace(" ", "%20");
                        Model = Model.Replace(" ", "%20");
                        Model = Model.Replace("&", "@");
                        //lblZip.Text == "" ? "0" : lblZip.Text 
                        //HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/SearchCarDetails.aspx?Make=" + CarsDetails.Tables[0].Rows[0]["make"].ToString() + "&Model=" + CarsDetails.Tables[0].Rows[0]["model"].ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + CarsDetails.Tables[0].Rows[0]["carId"].ToString();                        
                        HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
                        HylinkUCE.Target = "blank";
                        if (CarsDetails.Tables[0].Rows[0]["mileage"].ToString() != "0.00")
                        {
                            txtMileage.Visible = true;
                            txtMileage.Text = string.Format("{0:0}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["mileage"].ToString()));
                        }
                        else
                        {
                            txtMileage.Visible = true;
                            txtMileage.Text = "";
                        }
                        if (CarsDetails.Tables[0].Rows[0]["Title"].ToString() != "")
                        {
                            lblTitle.Text = CarsDetails.Tables[0].Rows[0]["Title"].ToString();
                        }
                        else
                        {
                            lblTitle.Text = CarsDetails.Tables[0].Rows[0]["make"].ToString() + "-" + CarsDetails.Tables[0].Rows[0]["model"].ToString() + "-" + Year;
                        }
                        if (CarsDetails.Tables[0].Rows[0]["price"].ToString() != "0.0000")
                        {
                            txtAskingPrice.Visible = true;
                            txtAskingPrice.Text = string.Format("{0:0}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["price"].ToString()));
                        }
                        else
                        {
                            txtAskingPrice.Visible = true;
                            txtAskingPrice.Text = "";
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
                        lblBodyStyle.Text = CarsDetails.Tables[0].Rows[0]["bodyType"].ToString();
                        lblExteriorColor.Text = CarsDetails.Tables[0].Rows[0]["exteriorColor"].ToString();
                        lblInteriorColor.Text = CarsDetails.Tables[0].Rows[0]["interiorColor"].ToString();
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
                        lblVin.Text = CarsDetails.Tables[0].Rows[0]["VIN"].ToString();
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
                        lblVehDescripSummary.Text = objGeneralFunc.WrapTextByMaxCharacters(CarsDetails.Tables[0].Rows[0]["description"].ToString(), 20);

                        string OldNotes = CarsDetails.Tables[0].Rows[0]["InternalNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtSaleNotes.Text = OldNotes;

                        //ListItem liSourceofPhotos = new ListItem();
                        //liSourceofPhotos.Text = CarsDetails.Tables[0].Rows[0]["SourceOfPhotosName"].ToString();
                        //liSourceofPhotos.Value = CarsDetails.Tables[0].Rows[0]["SourceOfPhotosID"].ToString();
                        //ddlPhotosSource.SelectedIndex = ddlPhotosSource.Items.IndexOf(liSourceofPhotos);
                        if (CarsDetails.Tables[0].Rows[0]["SourceOfPhotosName"].ToString() != "")
                        {
                            lblPhotoSource.Text = CarsDetails.Tables[0].Rows[0]["SourceOfPhotosName"].ToString();
                        }
                        else
                        {
                            lblPhotoSource.Text = "Customer will upload";
                        }
                        if (CarsDetails.Tables[0].Rows[0]["SourceOfDescriptionName"].ToString() != "")
                        {
                            lblDescriptionSource.Text = CarsDetails.Tables[0].Rows[0]["SourceOfDescriptionName"].ToString();
                        }
                        else
                        {
                            lblDescriptionSource.Text = "Customer will enter";
                        }
                        //ListItem liSourceofDescription = new ListItem();
                        //liSourceofDescription.Text = CarsDetails.Tables[0].Rows[0]["SourceOfDescriptionName"].ToString();
                        //liSourceofDescription.Value = CarsDetails.Tables[0].Rows[0]["SourceOfDescriptionID"].ToString();
                        //ddlDescriptionSource.SelectedIndex = ddlDescriptionSource.Items.IndexOf(liSourceofDescription);

                        if (CarsDetails.Tables[2].Rows.Count > 0)
                        {
                            lblPaymentStatus.Text = CarsDetails.Tables[2].Rows[0]["pmntStatus"].ToString();
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
                                if (CarsDetails.Tables[2].Rows[0]["bankAccountType"].ToString() != "")
                                {
                                    ListItem liAccType = new ListItem();
                                    liAccType.Text = CarsDetails.Tables[2].Rows[0]["AccountTypeName"].ToString();
                                    liAccType.Value = CarsDetails.Tables[2].Rows[0]["bankAccountType"].ToString();
                                    ddlAccType.SelectedIndex = ddlAccType.Items.IndexOf(liAccType);
                                }
                                //ListItem liCheckType = new ListItem();
                                //liCheckType.Text = CarsDetails.Tables[2].Rows[0]["CheckTypeName"].ToString();
                                //liCheckType.Value = CarsDetails.Tables[2].Rows[0]["CheckTypeID"].ToString();
                                //ddlCheckType.SelectedIndex = ddlCheckType.Items.IndexOf(liCheckType);
                                //txtCheckNumber.Text = CarsDetails.Tables[2].Rows[0]["BankCheckNumber"].ToString();
                            }
                            else if (Convert.ToInt32(CarsDetails.Tables[2].Rows[0]["pmntTypeID"].ToString()) == 6)
                            {
                                divcard.Style["display"] = "none";
                                divcheck.Style["display"] = "none";
                                divpaypal.Style["display"] = "block";
                                txtPaytransID.Text = CarsDetails.Tables[2].Rows[0]["TransactionID"].ToString();
                                txtpayPalEmailAccount.Text = CarsDetails.Tables[2].Rows[0]["cardholderLastName"].ToString();
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
                                lblExpiryDate.Text = EXpDate;
                                string[] EXpDt = EXpDate.Split(new char[] { '/' });

                                //ListItem liExpMnth = new ListItem();
                                //liExpMnth.Text = EXpDt[0].ToString();
                                //liExpMnth.Value = EXpDt[0].ToString();
                                //ExpMon.SelectedIndex = ExpMon.Items.IndexOf(liExpMnth);

                                //if (EXpDate.ToString() != "")
                                //{
                                //    ListItem liExpyear = new ListItem();
                                //    liExpyear.Text = "20" + EXpDt[1].ToString();
                                //    liExpyear.Value = EXpDt[1].ToString();
                                //    CCExpiresYear.SelectedIndex = CCExpiresYear.Items.IndexOf(liExpyear);
                                //}

                                cvv.Text = CarsDetails.Tables[2].Rows[0]["cardCode"].ToString();

                                txtbillingaddress.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["billingAdd"].ToString());
                                txtbillingcity.Text = objGeneralFunc.ToProper(CarsDetails.Tables[2].Rows[0]["billingCity"].ToString());

                                if (CarsDetails.Tables[2].Rows[0]["billingState"].ToString() != "")
                                {
                                    lblbillingstate.Text = CarsDetails.Tables[2].Rows[0]["State_Code"].ToString();
                                    //ListItem liBillST = new ListItem();
                                    //liBillST.Value = CarsDetails.Tables[2].Rows[0]["billingState"].ToString();
                                    //liBillST.Text = CarsDetails.Tables[2].Rows[0]["State_Code"].ToString();
                                    //ddlbillingstate.SelectedIndex = ddlbillingstate.Items.IndexOf(liBillST);
                                }

                                txtbillingzip.Text = CarsDetails.Tables[2].Rows[0]["billingZip"].ToString();
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
                                txtPDDate.Text = PDDate.ToString("MM/dd/yyyy");
                            }

                            txtPDAmountLater.Text = CarsDetails.Tables[2].Rows[0]["PDAmount"].ToString();
                            txtVoicefileConfirmNo.Text = CarsDetails.Tables[2].Rows[0]["VoiceRecord"].ToString();

                            if (CarsDetails.Tables[2].Rows[0]["VoiceFileLocation"].ToString() != "")
                            {
                                //ListItem liVoiceLocation = new ListItem();
                                //liVoiceLocation.Text = CarsDetails.Tables[2].Rows[0]["VoiceFileLocationName"].ToString();
                                //liVoiceLocation.Value = CarsDetails.Tables[2].Rows[0]["VoiceFileLocation"].ToString();
                                //ddlVoiceFileLocation.SelectedIndex = ddlVoiceFileLocation.Items.IndexOf(liVoiceLocation);
                                lblVoiceFileLocation.Text = CarsDetails.Tables[2].Rows[0]["VoiceFileLocationName"].ToString();
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
                        int ImagesHaveCount = 0;
                        DataTable dtTemp = new DataTable();
                        dtTemp.Columns.Add("ColumnPicLocation");
                        dtTemp.Columns.Add("ColumnPic");
                        dtTemp.Columns.Add("PicIDName");
                        dtTemp.Columns.Add("PicID");
                        dtTemp.Columns.Add("CarID");

                        int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());
                        for (int i = 1; i < TotalImgCount + 1; i++)
                        {
                            string ImgID = "Img" + i.ToString();
                            string RowIDName = "trImg" + i.ToString();
                            System.Web.UI.HtmlControls.HtmlTableCell RowID = (System.Web.UI.HtmlControls.HtmlTableCell)form1.FindControl(RowIDName);
                            string BtnID = "btnDelete" + i.ToString();
                            string ColumnPic = "pic" + i.ToString();
                            string ColumnPicName = "PIC" + i.ToString();
                            string ColumnPicLocation = "PICLOC" + i.ToString();
                            System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                            System.Web.UI.WebControls.Button BtnName = (System.Web.UI.WebControls.Button)form1.FindControl(BtnID);
                            string SelModelDis = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                            SelModelDis = SelModelDis.Replace("/", "@");
                            SelModelDis = SelModelDis.Replace("&", "@");
                            //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                            if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                            {
                                DataRow dataRow = dtTemp.NewRow();
                                dataRow["CarID"] = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                                dataRow["PicIDName"] = "pic" + i.ToString();
                                dataRow["ColumnPic"] = CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                                dataRow["ColumnPicLocation"] = CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString();
                                dtTemp.Rows.Add(dataRow);
                                ImagesHaveCount = ImagesHaveCount + 1;
                            }
                            if (i < 6)
                            {

                                if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                                {
                                    //RowID.Style["display"] = "table-cell";
                                    BtnName.Visible = true;
                                    ImageName.Visible = true;
                                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString() + CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                                }
                                else
                                {
                                    //RowID.Style["display"] = "none";
                                    ImageName.Visible = false;
                                    BtnName.Visible = false;
                                }
                            }
                            else
                            {
                                // RowID.Style["display"] = "none";
                                ImageName.Visible = false;
                                BtnName.Visible = false;
                            }
                        }
                        if (ImagesHaveCount > 5)
                        {
                            lnkbtnShowAllPhotosUploaded.Visible = true;
                        }
                        else
                        {
                            lnkbtnShowAllPhotosUploaded.Visible = false;
                        }
                        if (dtTemp.Rows.Count > 0)
                        {
                            lblResult.Text = "Total " + ImagesHaveCount + " image(s) uploaded";
                            lblResultPhotos.Text = "Total " + ImagesHaveCount + " image(s) uploaded";
                        }
                        else
                        {
                            lblResult.Text = "Photos not uploaded";
                            lblResultPhotos.Text = "Photos not uploaded";
                        }
                        if (CarsDetails.Tables[7].Rows.Count > 0)
                        {
                            lblExistUrlRes.Visible = false;
                            grdMultiSites.Visible = true;
                            grdMultiSites.DataSource = CarsDetails.Tables[7];
                            grdMultiSites.DataBind();
                            int RowsCount = Convert.ToInt32(CarsDetails.Tables[7].Rows.Count.ToString());
                            DateTime postdate = Convert.ToDateTime(CarsDetails.Tables[7].Rows[RowsCount - 1]["UrlPostDate"].ToString());
                            lblURLSummary.Text = "UCE plus " + RowsCount.ToString() + " multi-site listings available; latest update " + postdate.ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            grdMultiSites.Visible = false;
                            lblExistUrlRes.Visible = true;
                            lblExistUrlRes.Text = "Multi site listings not uploaded";
                            lblURLSummary.Text = "UCE listing available";
                        }
                        if (CarsDetails.Tables[0].Rows[0]["HomeViewCount"].ToString() == "")
                        {
                            lblHomeViewCount.Text = "0";
                        }
                        else
                        {
                            lblHomeViewCount.Text = CarsDetails.Tables[0].Rows[0]["HomeViewCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["SearchViewCount"].ToString() == "")
                        {
                            lblSearchViewCount.Text = "0";
                        }
                        else
                        {
                            lblSearchViewCount.Text = CarsDetails.Tables[0].Rows[0]["SearchViewCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["FilterCount"].ToString() == "")
                        {
                            lblFilterCount.Text = "0";
                        }
                        else
                        {
                            lblFilterCount.Text = CarsDetails.Tables[0].Rows[0]["FilterCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["MakeViewCount"].ToString() == "")
                        {
                            lblMakeViewCount.Text = "0";
                        }
                        else
                        {
                            lblMakeViewCount.Text = CarsDetails.Tables[0].Rows[0]["MakeViewCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["MakeModelViewCount"].ToString() == "")
                        {
                            lblMakeModelViewCount.Text = "0";
                        }
                        else
                        {
                            lblMakeModelViewCount.Text = CarsDetails.Tables[0].Rows[0]["MakeModelViewCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["MakeModelALLViewCount"].ToString() == "")
                        {
                            lblMakeModelAllViewCount.Text = "0";
                        }
                        else
                        {
                            lblMakeModelAllViewCount.Text = CarsDetails.Tables[0].Rows[0]["MakeModelALLViewCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["DetailsViewCount"].ToString() == "")
                        {
                            lblDetailsViewCount.Text = "0";
                        }
                        else
                        {
                            lblDetailsViewCount.Text = CarsDetails.Tables[0].Rows[0]["DetailsViewCount"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["ThisWeek"].ToString() == "")
                        {
                            lblThisWeek.Text = "0";
                        }
                        else
                        {
                            lblThisWeek.Text = CarsDetails.Tables[0].Rows[0]["ThisWeek"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["ThisMonth"].ToString() == "")
                        {
                            lblThisMonth.Text = "0";
                        }
                        else
                        {
                            lblThisMonth.Text = CarsDetails.Tables[0].Rows[0]["ThisMonth"].ToString();
                        }
                        if (CarsDetails.Tables[6].Rows.Count > 0)
                        {
                            lblTicketsError.Visible = false;
                            grdTicketDetails.Visible = true;
                            grdTicketDetails.DataSource = CarsDetails.Tables[6];
                            grdTicketDetails.DataBind();
                            int Pendings = 0;
                            for (int i = 0; i < CarsDetails.Tables[6].Rows.Count; i++)
                            {
                                if ((CarsDetails.Tables[6].Rows[i]["TicketStatus"].ToString() == "") || (CarsDetails.Tables[6].Rows[i]["TicketStatus"].ToString() != "2"))
                                {
                                    Pendings = Pendings + 1;
                                }
                            }
                            if (Pendings.ToString() == "0")
                            {
                                lblTicketSummary.Text = "None pending";
                                lblTicketsSummaryTop.Text = "None pending";
                            }
                            else
                            {
                                lblTicketSummary.Text = Pendings + "Ticket(s) pending";
                                lblTicketsSummaryTop.Text = Pendings + "Ticket(s) pending";
                            }
                        }
                        else
                        {
                            grdTicketDetails.Visible = false;
                            lblTicketsError.Visible = true;
                            lblTicketsError.Text = "No tickets found";
                            lblTicketSummary.Text = "None pending";
                            lblTicketsSummaryTop.Text = "None pending";
                        }
                        if (CarsDetails.Tables[8].Rows.Count > 0)
                        {
                            lblResultsCustomerServiceCalls.Visible = false;
                            grdCustServiceCalls.Visible = true;
                            grdCustServiceCalls.DataSource = CarsDetails.Tables[8];
                            grdCustServiceCalls.DataBind();
                            int TotalRows = Convert.ToInt32(CarsDetails.Tables[8].Rows.Count);
                            DateTime dtCall = Convert.ToDateTime(CarsDetails.Tables[8].Rows[TotalRows - 1]["CallDate"].ToString());
                            lblTransactionSummary.Text = " Latest call: Call received on " + dtCall.ToString("MM/dd/yyyy") + " by " + objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(CarsDetails.Tables[8].Rows[TotalRows - 1]["CallAgentID"].ToString()));
                        }
                        else
                        {
                            grdCustServiceCalls.Visible = false;
                            lblResultsCustomerServiceCalls.Visible = true;
                            lblResultsCustomerServiceCalls.Text = "Calls not done";
                            lblTransactionSummary.Text = "Calls not done";
                        }
                        if (CarsDetails.Tables[5].Rows.Count > 0)
                        {
                            if (CarsDetails.Tables[5].Rows[0]["CallDate"].ToString() != "")
                            {
                                DateTime WCCallDt = Convert.ToDateTime(CarsDetails.Tables[5].Rows[0]["CallDate"].ToString());
                                // lblWCCallDate.Text = WCCallDt.ToString("MM/dd/yyyy");
                                lblWelcomeCall.Text = "Done(" + WCCallDt.ToString("MM/dd/yyyy") + ")";
                            }
                            //lblWCCallBy.Text = objGeneralFunc.GetSmartzUser(CarsDetails.Tables[5].Rows[0]["CallAgentID"].ToString());

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
                HiddenField hdnValidTill = (HiddenField)e.Row.FindControl("hdnValidTill");
                Label lblValidTill = (Label)e.Row.FindControl("lblValidTill");
                HiddenField hdnDtOfPurchase = (HiddenField)e.Row.FindControl("hdnDtOfPurchase");
                HiddenField hdnPackDescrip = (HiddenField)e.Row.FindControl("hdnPackDescrip");
                HiddenField hdnUserPackID = (HiddenField)e.Row.FindControl("hdnUserPackID");
                //Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                LinkButton lnkbtnPackage = (LinkButton)e.Row.FindControl("lnkbtnPackage");

                if (hdnDtOfPurchase.Value != "")
                {
                    DateTime dtPurchase = Convert.ToDateTime(hdnDtOfPurchase.Value);
                    int ValidDays = Convert.ToInt32(hdnValidTill.Value);
                    DateTime dtValidTill = Convert.ToDateTime(dtPurchase.AddDays(ValidDays).ToString());
                    lblValidTill.Text = dtValidTill.ToString("MM/dd/yyyy");
                }
                //lnkbtnPackage.Text = hdnPackDescrip.Value + "(# " + hdnUserPackID.Value + ")";
                lnkbtnPackage.Text = hdnPackDescrip.Value;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdPackagDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ShowPackage")
            {
                string UserPackID = e.CommandArgument.ToString();
                int UserAssignedPackID = Convert.ToInt32(UserPackID);
                DataSet dsPackageDetails = objdropdownBL.USP_GetPackageDetailsByUserPackID(UserAssignedPackID);
                lblShowPackageID.Text = dsPackageDetails.Tables[0].Rows[0]["UserPackID"].ToString();

                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsPackageDetails.Tables[0].Rows[0]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();

                lblShowPackageName.Text = dsPackageDetails.Tables[0].Rows[0]["Description"].ToString() + "($" + PackAmount + ")";
                if (dsPackageDetails.Tables[0].Rows[0]["PayDate"].ToString() != "")
                {
                    DateTime dtPaydate = Convert.ToDateTime(dsPackageDetails.Tables[0].Rows[0]["PayDate"].ToString());
                    lblShowPurcahseDate.Text = dtPaydate.ToString("MM/dd/yyyy");
                    DateTime dtPurchase = Convert.ToDateTime(dsPackageDetails.Tables[0].Rows[0]["PayDate"]);
                    int ValidDays = Convert.ToInt32(dsPackageDetails.Tables[0].Rows[0]["ValidityPeriod"].ToString());
                    DateTime dtValidTill = Convert.ToDateTime(dtPurchase.AddDays(ValidDays).ToString());
                    lblShowValidTill.Text = dtValidTill.ToString("MM/dd/yyyy");
                }
                lblShowMaxCars.Text = dsPackageDetails.Tables[0].Rows[0]["Maxcars"].ToString();
                lblShowCarsPosted.Text = dsPackageDetails.Tables[0].Rows[0]["CarsCount"].ToString();
                lblShowPaidThrough.Text = dsPackageDetails.Tables[0].Rows[0]["PaymentTypeName"].ToString();
                lblShowTransactionID.Text = dsPackageDetails.Tables[0].Rows[0]["TransactionID"].ToString();
                lblShowTransactionStatus.Text = dsPackageDetails.Tables[0].Rows[0]["PaymentStatusName"].ToString();
                lblShowVoiceFile.Text = dsPackageDetails.Tables[0].Rows[0]["VoiceRecord"].ToString();
                mdepPackageDetails.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdCarDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Response.Redirect("CustomerViewNewForm.aspx");
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
                lblPackage.Text = hdnPackDescription.Value + "(# " + hdnPackUserPackID.Value + ")";
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
    private string CreateTable()
    {
        string strTransaction = string.Empty;
        strTransaction = "<table width=\"120px\" id=\"SalesStatus\" style=\"display: block; background-color:#F3D9F6;border:2px;border-color:Black;height:60px \">";

        strTransaction += "<tr id=\"CampaignsBody3\">";
        strTransaction += "<td  style=\"padding-left:10px;\" >";
        strTransaction += "Active:";
        strTransaction += "</td>";
        strTransaction += "<td>";
        strTransaction += "<img src=\"images/check.gif\" />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Inactive:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/red_x.png\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";
        strTransaction += "<tr id=\"CampaignsTitle11\">";
        strTransaction += "<td colspan=\"2\">";
        strTransaction += "<br />";
        strTransaction += "<br />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += "</table>";

        return strTransaction;

    }

    protected void grdTicketDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                if (hdnStatus.Value.ToString() == "")
                {
                    lblStatus.Text = "Pending";
                }
                else
                {
                    lblStatus.Text = hdnStatus.Value.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillTicketDDLs()
    {
        try
        {

            SmartzTicketDdlDs = Session["TicketDdl"] as DataSet;
            dsActiveSmartzUsers = Session["ActiveSmartzUsers"] as DataSet;

            ddlTicketStatus.DataSource = SmartzTicketDdlDs.Tables[5];
            ddlTicketStatus.DataTextField = "TicketStatusName";
            ddlTicketStatus.DataValueField = "TicketStatusID";
            ddlTicketStatus.DataBind();
            //ddlTicketStatus.Items.Insert(0, new ListItem("Select", "0"));



            ddlAssignedTo.DataSource = dsActiveSmartzUsers.Tables[0];
            ddlAssignedTo.DataTextField = "SmartzFirstName";
            ddlAssignedTo.DataValueField = "SmartzUID";
            ddlAssignedTo.DataBind();
            ddlAssignedTo.Items.Insert(0, new ListItem("Select", "0"));


            ddlCompletedBy.DataSource = dsActiveSmartzUsers.Tables[0];
            ddlCompletedBy.DataTextField = "SmartzFirstName";
            ddlCompletedBy.DataValueField = "SmartzUID";
            ddlCompletedBy.DataBind();
            ddlCompletedBy.Items.Insert(0, new ListItem("Select", "0"));



        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdCustServiceCalls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCSID")
            {
                int CSCallID = Convert.ToInt32(e.CommandArgument.ToString());
                DataSet dsCSData = objdropdownBL.USP_SmartzGetCSDataByCSCallID(CSCallID);
                if (dsCSData.Tables[0].Rows.Count > 0)
                {
                    lblPopupCSCallID.Text = dsCSData.Tables[0].Rows[0]["CallID"].ToString();
                    lblPopupCSCarID.Text = dsCSData.Tables[0].Rows[0]["CarID"].ToString();
                    if (dsCSData.Tables[0].Rows[0]["CallDate"].ToString() != "")
                    {
                        DateTime dtCallDate = Convert.ToDateTime(dsCSData.Tables[0].Rows[0]["CallDate"].ToString());
                        lblPopupCSCallDate.Text = dtCallDate.ToString("MM/dd/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        lblPopupCSCallDate.Text = "";
                    }
                    lblPopupCSCallAgent.Text = dsCSData.Tables[0].Rows[0]["CallAgentName"].ToString();
                    lblPopupCSCallType.Text = dsCSData.Tables[0].Rows[0]["CallTypeName"].ToString();
                    lblPopupCSCallReason.Text = dsCSData.Tables[0].Rows[0]["CallReasonName"].ToString();
                    lblPopupCSCallStatus.Text = dsCSData.Tables[0].Rows[0]["CSResolutionName"].ToString();
                    lblPopupCSCallNotes.Text = dsCSData.Tables[0].Rows[0]["Notes"].ToString();
                    lblPopupCSCallSpokenWith.Text = dsCSData.Tables[0].Rows[0]["SpokeWith"].ToString();
                }
                mdepCSIDPopup.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdTicketDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditTicket")
            {
                FillTicketDDLs();
                int TicketID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["UpTicketID"] = TicketID;
                DataSet dsTicketData = objdropdownBL.USP_SmartzGetDataByTicketID(TicketID);
                if (dsTicketData.Tables[0].Rows.Count > 0)
                {
                    lblPopTicketID.Text = dsTicketData.Tables[0].Rows[0]["TicketID"].ToString();
                    lblPopCarID.Text = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    Session["UpTicketCarID"] = dsTicketData.Tables[0].Rows[0]["CarID"].ToString();
                    lblPopTicketType.Text = dsTicketData.Tables[0].Rows[0]["TicketTypeName"].ToString();

                    if (dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                    {
                        DateTime CreateDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CreatedDate"].ToString());
                        lblPopTicketCreatedDt.Text = CreateDate.ToString("MM/dd/yyyy");
                    }

                    lblPopTicketCreatedBy.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["CreatedBy"].ToString());

                    lblPopPriority.Text = dsTicketData.Tables[0].Rows[0]["PriorityName"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["CallBackDate"].ToString() != "")
                    {
                        DateTime CallBackDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["CallBackDate"].ToString());
                        txtPostDate.Text = CallBackDate.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        txtPostDate.Text = "";
                    }
                    if (dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString() != "")
                    {
                        DateTime SolvedDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString());
                        txtCompletedDt.Text = SolvedDate.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        txtCompletedDt.Text = "";
                    }
                    lblPopTktDescrip.Text = dsTicketData.Tables[0].Rows[0]["TicketDescription"].ToString();
                    if (dsTicketData.Tables[0].Rows[0]["TicketStatusName"].ToString() != "")
                    {
                        ListItem liStatus = new ListItem();
                        liStatus.Value = dsTicketData.Tables[0].Rows[0]["TicketStatusID"].ToString();
                        liStatus.Text = dsTicketData.Tables[0].Rows[0]["TicketStatusName"].ToString();
                        ddlTicketStatus.SelectedIndex = ddlTicketStatus.Items.IndexOf(liStatus);
                    }
                    if (dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString() != "")
                    {
                        ListItem liAssigned = new ListItem();
                        liAssigned.Value = dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString();
                        liAssigned.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["AssignedTo"].ToString());
                        ddlAssignedTo.SelectedIndex = ddlAssignedTo.Items.IndexOf(liAssigned);
                    }
                    if (dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString() != "")
                    {
                        ListItem liCompleted = new ListItem();
                        liCompleted.Value = dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString();
                        liCompleted.Text = objGeneralFunc.GetSmartzUser(dsTicketData.Tables[0].Rows[0]["SolvedBy"].ToString());
                        ddlCompletedBy.SelectedIndex = ddlCompletedBy.Items.IndexOf(liCompleted);
                    }
                    txtPopTktComments.Text = dsTicketData.Tables[0].Rows[0]["TicketComments"].ToString();
                    Session["UpTicketComments"] = dsTicketData.Tables[0].Rows[0]["TicketComments"].ToString();

                }
                Session.Timeout = 180;

                mdepTicketAlertView.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSaveTicketView_Click(object sender, EventArgs e)
    {
        try
        {
            mdepTicketAlertView.Hide();
            int TicketID = Convert.ToInt32(Session["UpTicketID"].ToString());
            DateTime CallBackDate = Convert.ToDateTime(txtPostDate.Text);
            int TicketStatus = Convert.ToInt32(ddlTicketStatus.SelectedItem.Value);
            int AssignedTo = Convert.ToInt32(ddlAssignedTo.SelectedItem.Value);
            int CompletedBy = Convert.ToInt32(ddlCompletedBy.SelectedItem.Value);
            DateTime CompletedDate = Convert.ToDateTime(txtCompletedDt.Text);
            string TicketComments = txtPopTktComments.Text;
            if (txtPopTktComments.Text.Trim() != "")
            {
                if (Session["UpTicketComments"].ToString() != txtPopTktComments.Text.Trim())
                {
                    int CarID = Convert.ToInt32(Session["UpTicketCarID"].ToString());
                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                    String UpdatedBy = Session[Constants.NAME].ToString();
                    string InternalNotesNew = txtPopTktComments.Text.Trim();
                    string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                    InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                    //Notes = InternalNotesNew;
                    DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
                    Session.Timeout = 180;
                }
            }
            bool bnew = objdropdownBL.USP_SmartzUpdateTicketDetails(TicketID, CallBackDate, TicketStatus, AssignedTo, CompletedBy, CompletedDate, TicketComments);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnAddTicketPopup_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Click"] = "7";
            // Response.Redirect("Index.aspx");
            FillTicketDropdown();
            mdepTicketAlert.Show();
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
                string TicketDescriopNotes = string.Empty;
                if (txtTicketDescription.Text.Trim() != "")
                {
                    String UpdatedBy = Session[Constants.NAME].ToString();
                    string InternalNotesNew = txtTicketDescription.Text.Trim();
                    string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
                    InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
                    TicketDescriopNotes = InternalNotesNew;
                    DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, TicketDescriopNotes, UID);
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
            if (Session["Click"] == "4")
            {
                Response.Redirect("Index.aspx");
            }
            if (Session["Click"] == "5")
            {
                if (Session["RedirectFrom"].ToString() == "1")
                {
                    Response.Redirect("SearchNew.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "2")
                {
                    Response.Redirect("WelcomeCalls.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "3")
                {
                    Response.Redirect("Tickets.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "4")
                {
                    Response.Redirect("CustomerService.aspx");
                }

                if (Session["RedirectFrom"].ToString() == "5")
                {
                    Response.Redirect("PostDatePaymentData.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "6")
                {
                    Response.Redirect("Days30CallReview.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "7")
                {
                    Response.Redirect("Days60CallsReview.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "8")
                {
                    Response.Redirect("FreeSales.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "9")
                {
                    Response.Redirect("RecentList.aspx");
                }
            }
            if (Session["Click"] == "6")
            {
                Response.Redirect("SearchNew.aspx");
            }
            if (Session["Click"] == "7")
            {
                Response.Redirect("CustomerViewNewForm.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
            if (Session["Click"] == "4")
            {
                Response.Redirect("Index.aspx");
            }
            if (Session["Click"] == "5")
            {
                if (Session["RedirectFrom"].ToString() == "1")
                {
                    Response.Redirect("SearchNew.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "2")
                {
                    Response.Redirect("WelcomeCalls.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "3")
                {
                    Response.Redirect("Tickets.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "4")
                {
                    Response.Redirect("CustomerService.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "5")
                {
                    Response.Redirect("PostDatePaymentData.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "6")
                {
                    Response.Redirect("Days30CallReview.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "7")
                {
                    Response.Redirect("Days60CallsReview.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "8")
                {
                    Response.Redirect("FreeSales.aspx");
                }
                if (Session["RedirectFrom"].ToString() == "9")
                {
                    Response.Redirect("RecentList.aspx");
                }

            }
            if (Session["Click"] == "6")
            {
                Response.Redirect("SearchNew.aspx");
            }
            if (Session["Click"] == "7")
            {
                //Response.Redirect("CustomerView.aspx");
                mdepTicketAlert.Hide();
            }
            //Response.Redirect("SearchNew.aspx");
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
    //protected void dtlstImages_ItemDataBound(Object sender, DataListItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    //    {
    //        Image ImgImages = (Image)e.Item.FindControl("ImgImages");
    //        HiddenField hdnColumnPic = (HiddenField)e.Item.FindControl("hdnColumnPic");
    //        HiddenField hdnColumnPicLocation = (HiddenField)e.Item.FindControl("hdnColumnPicLocation");
    //        ImgImages.ImageUrl = "http://unitedcarexchange.com/" + hdnColumnPicLocation.Value + hdnColumnPic.Value;
    //    }
    //}
    protected void grdMultiSites_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnExpiryDate = (HiddenField)e.Row.FindControl("hdnExpiryDate");
                Label lblExpirydate = (Label)e.Row.FindControl("lblExpirydate");
                HiddenField hdnPostDate = (HiddenField)e.Row.FindControl("hdnPostDate");
                if (hdnExpiryDate.Value != "")
                {
                    DateTime dtPostDt = Convert.ToDateTime(hdnPostDate.Value.ToString());
                    int ValidDays = Convert.ToInt32(hdnExpiryDate.Value);
                    DateTime dtValidTill = Convert.ToDateTime(dtPostDt.AddDays(ValidDays).ToString());
                    lblExpirydate.Text = dtValidTill.ToString("MM/dd/yy");
                }
                else
                {
                    lblExpirydate.Text = "Not Available";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //private void FillVoiceFileLocation()
    //{
    //    try
    //    {
    //        DataSet dsVoiceFileLocation = objCentralDBBL.GetVoiceFileLocation();
    //        ddlVoiceFileLocation.DataSource = dsVoiceFileLocation.Tables[0];
    //        ddlVoiceFileLocation.DataTextField = "VoiceFileLocationName";
    //        ddlVoiceFileLocation.DataValueField = "VoiceFileLocationID";
    //        ddlVoiceFileLocation.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //private void FillDescriptionSource()
    //{
    //    try
    //    {
    //        DataSet dsDescripSource = objdropdownBL.GetMasterSourceOfDescription();
    //        ddlDescriptionSource.DataSource = dsDescripSource.Tables[0];
    //        ddlDescriptionSource.DataTextField = "SourceOfDescriptionName";
    //        ddlDescriptionSource.DataValueField = "SourceOfDescriptionID";
    //        ddlDescriptionSource.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //private void FillPhotoSource()
    //{
    //    try
    //    {
    //        DataSet dsDescripPhotos = objdropdownBL.GetMasterSourceOfPhotos();
    //        ddlPhotosSource.DataSource = dsDescripPhotos.Tables[0];
    //        ddlPhotosSource.DataTextField = "SourceOfPhotosName";
    //        ddlPhotosSource.DataValueField = "SourceOfPhotosID";
    //        ddlPhotosSource.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        // your code!
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "TransfersInfoBinding();", true);
    }

    //private void fillYears(DataSet dsYears)
    //{
    //    try
    //    {
    //        CCExpiresYear.Items.Clear();
    //        CCExpiresYear.DataSource = dsYears.Tables[0];
    //        CCExpiresYear.DataTextField = "YearNum";
    //        CCExpiresYear.DataValueField = "YearValue";
    //        CCExpiresYear.DataBind();
    //        CCExpiresYear.Items.Insert(0, new ListItem("Select Year", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //private void FillBillingStates()
    //{
    //    try
    //    {
    //        ddlbillingstate.Items.Clear();
    //        if (Session["DsDropDown"] == null)
    //        {
    //            dsDropDown = objdropdownBL.Usp_Get_DropDown();
    //            Session["DsDropDown"] = dsDropDown;
    //        }
    //        else
    //        {
    //            dsDropDown = (DataSet)Session["DsDropDown"];
    //        }

    //        ddlbillingstate.DataSource = dsDropDown.Tables[1];
    //        ddlbillingstate.DataTextField = "State_Code";
    //        ddlbillingstate.DataValueField = "State_ID";
    //        ddlbillingstate.DataBind();
    //        ddlbillingstate.Items.Insert(0, new ListItem("Unspecified", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
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
    private void FillSellerStates()
    {
        try
        {
            ddlSellerState.DataSource = dsDropDown.Tables[1];
            ddlSellerState.DataTextField = "State_Code";
            ddlSellerState.DataValueField = "State_Code";
            ddlSellerState.DataBind();
            ddlSellerState.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    protected void lnkCarTransactionDetails_Click(object sender, EventArgs e)
    {
        try
        {
            lblTransHead.Text = "Car Transaction Details";
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int SellerID = Convert.ToInt32(Session["ViewsellerID"].ToString());
            int paymentID;
            if (Session["ViewpaymentID"].ToString() != "")
            {
                paymentID = Convert.ToInt32(Session["ViewpaymentID"].ToString());
            }
            else
            {
                paymentID = 0;
            }

            DataSet dsTransCarsdata = new DataSet();
            dsTransCarsdata = objdropdownBL.USP_GetTransactionDetailsForCustomer(CarID, PostingID, SellerID, paymentID);

            if (dsTransCarsdata.Tables[0].Rows.Count > 0)
            {
                grdTranscarData.Visible = true;
                grdTranscarData.DataSource = dsTransCarsdata.Tables[0];
                grdTranscarData.DataBind();
                mpeaTransCarData.Show();
            }
            else
            {
                grdTranscarData.Visible = false;
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "No transaction details found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkUserTransDetails_Click(object sender, EventArgs e)
    {
        try
        {
            lblTransHead.Text = "User Transaction Details";
            int UID = Convert.ToInt32(Session["ViewUID"].ToString());
            DataSet dsTransUserData = objdropdownBL.USP_GetTransactionDetailsForUserDetails(UID);
            if (dsTransUserData.Tables[0].Rows.Count > 0)
            {
                grdTranscarData.Visible = true;
                grdTranscarData.DataSource = dsTransUserData.Tables[0];
                grdTranscarData.DataBind();
                mpeaTransCarData.Show();
            }
            else
            {
                grdTranscarData.Visible = false;
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "No transaction details found";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Search.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CarCustomerEditNewForm.aspx");
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
                txtSaleNotes.Text = OldNotes;
                txtNewIntNotes.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnResendWelMail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string LoginName = Session["RegUserName"].ToString();
            string UserDisName = Session["RegName"].ToString();
            string Year = Session["ViewCarYear"].ToString();
            string Model = Session["ViewCarModel"].ToString();
            string Make = Session["ViewCarMake"].ToString();
            string UniqueID = Session["CarViewUniqueID"].ToString();
            string LoginUserID = Session["RegLoginUserID"].ToString();
            Make = Make.Replace(" ", "%20");
            Model = Model.Replace(" ", "%20");
            Model = Model.Replace("&", "@");
            string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
            string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
            clsMailFormats format = new clsMailFormats();
            string text = string.Empty;
            if (Session["ViewPayStatus"].ToString() == "5")
            {
                DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                PDDate = PostDate.ToString("MM/dd/yyyy");
                text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate);
            }
            else
            {
                text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink);
            }
            lblRegisMail.Text = text;
            lblMailTo.Text = LoginName;
            txtEmailTo.Text = "";
            lblRegisMail.Visible = true;
            mpeViewregisterMail.Show();
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
            Session.Timeout = 180;
            ResendRegMail();
            mpeViewregisterMail.Hide();

            int CarID = Convert.ToInt32(Session["CustViewCarID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = "Welcome Mail Send";
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
            Session.Timeout = 180;
            if (dsNewIntNotes.Tables[0].Rows.Count > 0)
            {
                string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["InternalNotes"].ToString();
                OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                txtSaleNotes.Text = OldNotes;
                txtNewIntNotes.Text = "";
            }

            mpealteruser.Show();
            lblErr.Visible = true;
            lblErr.Text = "Email(s) successfully send";
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
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string LoginName = Session["RegUserName"].ToString();
            string UserDisName = Session["RegName"].ToString();
            string Year = Session["ViewCarYear"].ToString();
            string Model = Session["ViewCarModel"].ToString();
            string Make = Session["ViewCarMake"].ToString();
            string UniqueID = Session["CarViewUniqueID"].ToString();
            string LoginUserID = Session["RegLoginUserID"].ToString();
            Make = Make.Replace(" ", "%20");
            Model = Model.Replace(" ", "%20");
            Model = Model.Replace("&", "@");
            string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
            string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("info@unitedcarexchange.com");
            msg.To.Add(LoginName);
            if (txtEmailTo.Text != "")
            {
                msg.CC.Add(txtEmailTo.Text);
            }
            msg.Bcc.Add("archive@unitedcarexchange.com");
            msg.Subject = "Registration Details From United Car Exchange For Car ID# " + Session["ViewCarID"].ToString();
            msg.IsBodyHtml = true;
            string text = string.Empty;
            if (Session["ViewPayStatus"].ToString() == "5")
            {
                DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                PDDate = PostDate.ToString("MM/dd/yyyy");
                text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate);
            }
            else
            {
                text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink);
            }
            msg.Body = text.ToString();
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new System.Net.NetworkCredential("info@unitedcarexchange.com", "info*123*");
            //smtp.EnableSsl = true;
            //smtp.Send(msg);
            smtp.Host = "127.0.0.1";
            smtp.Port = 25;
            smtp.Send(msg);
        }
        catch (Exception ex)
        {
            //throw ex;
            Response.Redirect("EmailServerError.aspx");
        }
    }
    protected void lnkbtnShowAllPhotosUploaded_Click(object sender, EventArgs e)
    {
        try
        {
            CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());
            lnkbtnShowAllPhotosUploaded.Visible = false;
            for (int i = 1; i < TotalImgCount + 1; i++)
            {
                string ImgID = "Img" + i.ToString();
                string RowIDName = "trImg" + i.ToString();
                System.Web.UI.HtmlControls.HtmlTableCell RowID = (System.Web.UI.HtmlControls.HtmlTableCell)form1.FindControl(RowIDName);
                string BtnID = "btnDelete" + i.ToString();
                string ColumnPic = "pic" + i.ToString();
                string ColumnPicName = "PIC" + i.ToString();
                string ColumnPicLocation = "PICLOC" + i.ToString();
                System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                System.Web.UI.WebControls.Button BtnName = (System.Web.UI.WebControls.Button)form1.FindControl(BtnID);
                string SelModelDis = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                SelModelDis = SelModelDis.Replace("/", "@");
                SelModelDis = SelModelDis.Replace("&", "@");
                //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);                
                if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                {
                    //RowID.Style["display"] = "table-cell";
                    BtnName.Visible = true;
                    ImageName.Visible = true;
                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString() + CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                }
                else
                {
                    // RowID.Style["display"] = "none";
                    ImageName.Visible = false;
                    BtnName.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete1_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID2;
            objCarsInfo.Pic2 = picID3;
            objCarsInfo.Pic3 = picID4;
            objCarsInfo.Pic4 = picID5;
            objCarsInfo.Pic5 = picID6;
            objCarsInfo.Pic6 = picID7;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete2_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID3;
            objCarsInfo.Pic3 = picID4;
            objCarsInfo.Pic4 = picID5;
            objCarsInfo.Pic5 = picID6;
            objCarsInfo.Pic6 = picID7;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete3_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID4;
            objCarsInfo.Pic4 = picID5;
            objCarsInfo.Pic5 = picID6;
            objCarsInfo.Pic6 = picID7;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete4_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID5;
            objCarsInfo.Pic5 = picID6;
            objCarsInfo.Pic6 = picID7;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete5_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID6;
            objCarsInfo.Pic6 = picID7;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete6_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID7;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete7_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID8;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete8_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID9;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete9_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID10;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete10_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID11;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete11_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID12;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete12_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID13;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete13_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID14;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete14_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID15;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete15_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID14;
            objCarsInfo.Pic15 = picID16;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete16_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID14;
            objCarsInfo.Pic15 = picID15;
            objCarsInfo.Pic16 = picID17;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete17_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID14;
            objCarsInfo.Pic15 = picID15;
            objCarsInfo.Pic16 = picID16;
            objCarsInfo.Pic17 = picID18;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete18_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID14;
            objCarsInfo.Pic15 = picID15;
            objCarsInfo.Pic16 = picID16;
            objCarsInfo.Pic17 = picID17;
            objCarsInfo.Pic18 = picID19;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete19_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID14;
            objCarsInfo.Pic15 = picID15;
            objCarsInfo.Pic16 = picID16;
            objCarsInfo.Pic17 = picID17;
            objCarsInfo.Pic18 = picID18;
            objCarsInfo.Pic19 = picID20;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDelete20_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(Session["ViewCarID"].ToString());
            DataSet dsImagesData = objdropdownBL.GetPicIDsByCarID(CarID);
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            CarsInfo.CarsInfo objCarsInfo = new CarsInfo.CarsInfo();
            objCarsInfo.CarID = CarID;
            objCarsInfo.Pic1 = picID1;
            objCarsInfo.Pic2 = picID2;
            objCarsInfo.Pic3 = picID3;
            objCarsInfo.Pic4 = picID4;
            objCarsInfo.Pic5 = picID5;
            objCarsInfo.Pic6 = picID6;
            objCarsInfo.Pic7 = picID7;
            objCarsInfo.Pic8 = picID8;
            objCarsInfo.Pic9 = picID9;
            objCarsInfo.Pic10 = picID10;
            objCarsInfo.Pic11 = picID11;
            objCarsInfo.Pic12 = picID12;
            objCarsInfo.Pic13 = picID13;
            objCarsInfo.Pic14 = picID14;
            objCarsInfo.Pic15 = picID15;
            objCarsInfo.Pic16 = picID16;
            objCarsInfo.Pic17 = picID17;
            objCarsInfo.Pic18 = picID18;
            objCarsInfo.Pic19 = picID19;
            objCarsInfo.Pic20 = null;
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.UpdatePicturesByIdForSmartz(objCarsInfo, UID);
            Response.Redirect("CustomerView.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSendListingDetails_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet MultiSite = Session["ViewCarDetailsDataset"] as DataSet;
            DataTable dtMutisite = MultiSite.Tables[4];
            if (dtMutisite.Rows.Count > 0)
            {
                clsMailFormats format = new clsMailFormats();
                string text = string.Empty;
                string LoginName = Session["RegUserName"].ToString();
                lblMultiSiteMailTo.Text = LoginName;
                string PDDate = string.Empty;
                string LoginPassword = Session["RegPassword"].ToString();
                string UserDisName = Session["RegName"].ToString();
                string PackageName = Session["ViewPackageName"].ToString();
                string UniqueID = Session["CarViewUniqueID"].ToString();
                DataSet CarsDetails = (DataSet)Session["ViewCarDetailsDataset"];
                string Carid = Session["ViewCarID"].ToString();
                //text = format.SendMultiSitedetailsTesting(ref text, dtMutisite,CarsDetails);

                text = format.SendMultiListMail(ref text, dtMutisite, Carid, PackageName, UserDisName, UniqueID);


                //if (Session["ViewPayStatus"].ToString() == "5")
                //{
                //    DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                //    PDDate = PostDate.ToString("MM/dd/yyyy");
                //    text = text;
                //}
                //else
                //{
                //    text = text;
                //}


                lblMultiListMail.Text = text;
                lblMailTo.Text = LoginName;
                txtMultiListEmailToCC.Text = "";
                lblMultiListMail.Visible = true;
                MpeListMail.Show();
            }
            else
            {
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "No active multisite listings are in place";
            }





        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnSendListingMail_Click(object sender, EventArgs e)
    {

        Session.Timeout = 180;
        ResendMultiListingMail();
        MpeListMail.Hide();

        int CarID = Convert.ToInt32(Session["CustViewCarID"].ToString());
        int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
        String UpdatedBy = Session[Constants.NAME].ToString();
        string InternalNotesNew = "Listing Details Mail Send";
        string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
        InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
        DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
        Session.Timeout = 180;
        if (dsNewIntNotes.Tables[0].Rows.Count > 0)
        {
            string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["InternalNotes"].ToString();
            OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
            OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
            txtSaleNotes.Text = OldNotes;
            txtNewIntNotes.Text = "";
        }


        mpealteruser.Show();
        lblErr.Visible = true;
        lblErr.Text = "Email(s) successfully send";

    }

    private void ResendMultiListingMail()
    {
        try
        {
            clsMailFormats format = new clsMailFormats();


            MailMessage msg = new MailMessage();



            string LoginName = Session["RegUserName"].ToString();
            msg.From = new MailAddress("info@unitedcarexchange.com");
            msg.To.Add(LoginName);
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string UserDisName = Session["RegName"].ToString();
            if (txtMultiListEmailToCC.Text != "")
            {
                msg.CC.Add(txtMultiListEmailToCC.Text);
            }
            msg.From = new MailAddress("info@unitedcarexchange.com");
            msg.Subject = "MultiSite";

            msg.IsBodyHtml = true;
            string ToEmail = lblMultiSiteMailTo.Text;

            msg.To.Add(ToEmail);

            if (txtEmailTo.Text != "")
            {
                msg.CC.Add(txtEmailTo.Text);
            }
            msg.Bcc.Add("archive@unitedcarexchange.com");
            msg.Subject = "Multisite Listing Details From United Car Exchange For Car ID# " + Session["ViewCarID"].ToString();
            msg.IsBodyHtml = true;


            msg.Body = lblMultiListMail.Text.ToString();

            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new System.Net.NetworkCredential("info@unitedcarexchange.com", "info*123*");
            //smtp.EnableSsl = true;
            //smtp.Send(msg);

            smtp.Host = "127.0.0.1";
            smtp.Port = 25;
            smtp.Send(msg);
        }
        catch (Exception ex)
        {
            //throw ex;
            Response.Redirect("EmailServerError.aspx");
        }
    }

    protected void btnSendCustomMail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string LoginName = Session["RegUserName"].ToString();
            string UserDisName = Session["RegName"].ToString();
            clsMailFormats format = new clsMailFormats();
            string text = string.Empty;
            lblGenMailTo.Text = LoginName;
            txtGenCCMail.Text = "";
            txtGenSubject.Text = "Mail From United Car Exchange For Car ID# " + Session["ViewCarID"].ToString();
            txtgenMailText.Text = "";
            mdepgeneralMail.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void SendGenMail()
    {
        try
        {
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string LoginName = Session["RegUserName"].ToString();
            string UserDisName = Session["RegName"].ToString();
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("info@unitedcarexchange.com");
            string ToEmail = lblGenMailTo.Text;
            msg.To.Add(ToEmail);
            if (txtGenCCMail.Text != "")
            {
                msg.CC.Add(txtGenCCMail.Text);
            }
            msg.Bcc.Add("archive@unitedcarexchange.com");
            msg.Subject = txtGenSubject.Text;
            msg.IsBodyHtml = false;
            string text = string.Empty;
            text = txtgenMailText.Text;
            msg.Body = text.ToString();
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new System.Net.NetworkCredential("info@unitedcarexchange.com", "info*123*");
            //smtp.EnableSsl = true;
            //smtp.Send(msg);
            smtp.Host = "127.0.0.1";
            smtp.Port = 25;
            smtp.Send(msg);
        }
        catch (Exception ex)
        {
            //throw ex;
            Response.Redirect("EmailServerError.aspx");
        }
    }
    protected void btngenMailSend_Click(object sender, EventArgs e)
    {
        try
        {
            SendGenMail();
            mpeViewregisterMail.Hide();
            int CarID = Convert.ToInt32(Session["CustViewCarID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = "General Mail<br>" + txtgenMailText.Text;
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objdropdownBL.USP_UpdateCustomerInternalNotes(CarID, InternalNotesNew, UID);
            Session.Timeout = 180;
            if (dsNewIntNotes.Tables[0].Rows.Count > 0)
            {
                string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["InternalNotes"].ToString();
                OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                txtSaleNotes.Text = OldNotes;
                txtNewIntNotes.Text = "";
            }

            mpealteruser.Show();
            lblErr.Visible = true;
            lblErr.Text = "Email(s) successfully send";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkRegdataEdit_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet dsCarDetails = Session["ViewCarDetailsDataset"] as DataSet;
            lblEditUserID.Text = dsCarDetails.Tables[0].Rows[0]["UserID"].ToString();
            txtEditPassword.Text = dsCarDetails.Tables[0].Rows[0]["Pwd"].ToString();
            txtEditName.Text = dsCarDetails.Tables[0].Rows[0]["Name"].ToString();
            if (dsCarDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
            {
                chkbxEMailNAEdit.Checked = true;
                txtEditRegEmail.Text = "";
            }
            else
            {
                //Session["ViewCarEmailExists"] = 1;
                chkbxEMailNAEdit.Checked = false;
                txtEditRegEmail.Text = dsCarDetails.Tables[0].Rows[0]["UserName"].ToString();
            }
            txtEditRegPhone.Text = dsCarDetails.Tables[0].Rows[0]["PhoneNumber"].ToString();
            txtEditAltPhone.Text = dsCarDetails.Tables[0].Rows[0]["RegAltPhone"].ToString();
            txtEditRegAddress.Text = dsCarDetails.Tables[0].Rows[0]["Address"].ToString();
            txtEditRegCity.Text = dsCarDetails.Tables[0].Rows[0]["RegCity"].ToString();
            ListItem listRegState = new ListItem();
            listRegState.Value = dsCarDetails.Tables[0].Rows[0]["StateID"].ToString();
            listRegState.Text = dsCarDetails.Tables[0].Rows[0]["State_Code"].ToString();
            ddlRegState.SelectedIndex = ddlRegState.Items.IndexOf(listRegState);
            txtEditRegZip.Text = dsCarDetails.Tables[0].Rows[0]["RegZip"].ToString();
            mdepRegEdit.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnAdStatusdataEdit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
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
            mdepAdStatusEdit.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnEditRegUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int UID = Convert.ToInt32(dsCarDetails.Tables[0].Rows[0]["uid"].ToString());
            DataSet dsEditPhoneExists = objdropdownBL.SmartzChkUserPhoneNumberExistsForUpdate(txtEditRegPhone.Text.Trim(), UID);
            if (dsEditPhoneExists.Tables.Count > 0)
            {
                if (dsEditPhoneExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Phone number " + txtEditRegPhone.Text.Trim() + " already exists";
                }
                else
                {
                    int EmailExists = 1;
                    if (chkbxEMailNAEdit.Checked == false)
                    {
                        EmailExists = 1;
                        DataSet dsUserExists = objdropdownBL.USP_SmartzChkUserExistsForUpdate(txtEditRegEmail.Text.Trim(), UID);
                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + txtEditRegEmail.Text.Trim() + " already exists";
                            }
                            else
                            {
                                int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                string RegName = objGeneralFunc.ToProper(txtEditName.Text).Trim();
                                string RegPhone = txtEditRegPhone.Text;
                                string RegCity = objGeneralFunc.ToProper(txtEditRegCity.Text).Trim();
                                int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
                                string RegAddress = objGeneralFunc.ToProper(txtEditRegAddress.Text).Trim();
                                string RegAltPhone = txtEditAltPhone.Text.Trim();
                                string RegZip = string.Empty;
                                RegZip = txtEditRegZip.Text;
                                String RegUserName = txtEditRegEmail.Text.Trim();
                                string Password = txtEditPassword.Text.Trim();
                                bool bnew = objdropdownBL.SmartzUpdateRegUserDetailsForNewForm(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, TranBy, RegAltPhone);
                                if (bnew == true)
                                {
                                    lblAlertUpdatedSuccess.Text = "User details updated successfully";
                                    lblAlertUpdatedSuccess.Visible = true;
                                    MdepUpdatedSuccess.Show();
                                }
                            }
                        }
                        else
                        {
                            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                            string RegName = objGeneralFunc.ToProper(txtEditName.Text).Trim();
                            string RegPhone = txtEditRegPhone.Text;
                            string RegCity = objGeneralFunc.ToProper(txtEditRegCity.Text).Trim();
                            int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
                            string RegAddress = objGeneralFunc.ToProper(txtEditRegAddress.Text).Trim();
                            string RegAltPhone = txtEditAltPhone.Text.Trim();
                            string RegZip = string.Empty;
                            RegZip = txtEditRegZip.Text;
                            String RegUserName = txtEditRegEmail.Text.Trim();
                            string Password = txtEditPassword.Text.Trim();
                            bool bnew = objdropdownBL.SmartzUpdateRegUserDetailsForNewForm(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, TranBy, RegAltPhone);
                            if (bnew == true)
                            {
                                lblAlertUpdatedSuccess.Text = "User details updated successfully";
                                lblAlertUpdatedSuccess.Visible = true;
                                MdepUpdatedSuccess.Show();
                            }
                        }
                    }
                    else
                    {
                        EmailExists = 0;
                        int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                        string RegName = objGeneralFunc.ToProper(txtEditName.Text).Trim();
                        string RegPhone = txtEditRegPhone.Text;
                        string RegCity = objGeneralFunc.ToProper(txtEditRegCity.Text).Trim();
                        int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
                        string RegAddress = objGeneralFunc.ToProper(txtEditRegAddress.Text).Trim();
                        string RegAltPhone = txtEditAltPhone.Text.Trim();
                        string RegZip = string.Empty;
                        RegZip = txtEditRegZip.Text;
                        String RegUserName = "";
                        string Password = txtEditPassword.Text.Trim();
                        bool bnew = objdropdownBL.SmartzUpdateRegUserDetailsForNewForm(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, TranBy, RegAltPhone);
                        if (bnew == true)
                        {
                            lblAlertUpdatedSuccess.Text = "User details updated successfully";
                            lblAlertUpdatedSuccess.Visible = true;
                            MdepUpdatedSuccess.Show();
                        }
                    }
                }
            }
            else
            {
                int EmailExists = 1;
                if (chkbxEMailNAEdit.Checked == false)
                {
                    EmailExists = 1;
                    DataSet dsUserExists = objdropdownBL.USP_SmartzChkUserExistsForUpdate(txtEditRegEmail.Text.Trim(), UID);
                    if (dsUserExists.Tables.Count > 0)
                    {
                        if (dsUserExists.Tables[0].Rows.Count > 0)
                        {
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Email " + txtEditRegEmail.Text.Trim() + " already exists";
                        }
                        else
                        {
                            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                            string RegName = objGeneralFunc.ToProper(txtEditName.Text).Trim();
                            string RegPhone = txtEditRegPhone.Text;
                            string RegCity = objGeneralFunc.ToProper(txtEditRegCity.Text).Trim();
                            int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
                            string RegAddress = objGeneralFunc.ToProper(txtEditRegAddress.Text).Trim();
                            string RegAltPhone = txtEditAltPhone.Text.Trim();
                            string RegZip = string.Empty;
                            RegZip = txtEditRegZip.Text;
                            String RegUserName = txtEditRegEmail.Text.Trim();
                            string Password = txtEditPassword.Text.Trim();
                            bool bnew = objdropdownBL.SmartzUpdateRegUserDetailsForNewForm(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, TranBy, RegAltPhone);
                            if (bnew == true)
                            {
                                lblAlertUpdatedSuccess.Text = "User details updated successfully";
                                lblAlertUpdatedSuccess.Visible = true;
                                MdepUpdatedSuccess.Show();
                            }
                        }
                    }
                    else
                    {
                        int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                        string RegName = objGeneralFunc.ToProper(txtEditName.Text).Trim();
                        string RegPhone = txtEditRegPhone.Text;
                        string RegCity = objGeneralFunc.ToProper(txtEditRegCity.Text).Trim();
                        int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
                        string RegAddress = objGeneralFunc.ToProper(txtEditRegAddress.Text).Trim();
                        string RegAltPhone = txtEditAltPhone.Text.Trim();
                        string RegZip = string.Empty;
                        RegZip = txtEditRegZip.Text;
                        String RegUserName = txtEditRegEmail.Text.Trim();
                        string Password = txtEditPassword.Text.Trim();
                        bool bnew = objdropdownBL.SmartzUpdateRegUserDetailsForNewForm(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, TranBy, RegAltPhone);
                        if (bnew == true)
                        {
                            lblAlertUpdatedSuccess.Text = "User details updated successfully";
                            lblAlertUpdatedSuccess.Visible = true;
                            MdepUpdatedSuccess.Show();
                        }
                    }
                }
                else
                {
                    EmailExists = 0;
                    int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                    string RegName = objGeneralFunc.ToProper(txtEditName.Text).Trim();
                    string RegPhone = txtEditRegPhone.Text;
                    string RegCity = objGeneralFunc.ToProper(txtEditRegCity.Text).Trim();
                    int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
                    string RegAddress = objGeneralFunc.ToProper(txtEditRegAddress.Text).Trim();
                    string RegAltPhone = txtEditAltPhone.Text.Trim();
                    string RegZip = string.Empty;
                    RegZip = txtEditRegZip.Text;
                    String RegUserName = "";
                    string Password = txtEditPassword.Text.Trim();
                    bool bnew = objdropdownBL.SmartzUpdateRegUserDetailsForNewForm(UID, RegName, RegPhone, RegCity, RegState, RegAddress, RegZip, RegUserName, Password, TranBy, RegAltPhone);
                    if (bnew == true)
                    {
                        lblAlertUpdatedSuccess.Text = "User details updated successfully";
                        lblAlertUpdatedSuccess.Visible = true;
                        MdepUpdatedSuccess.Show();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnUpdateSuccessOk_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("CustomerViewNewForm.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAdStatusUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int PostingID = Convert.ToInt32(dsCarDetails.Tables[0].Rows[0]["PostingID"].ToString());
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int AdStatus = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
            int ListingStatus;
            int UCEStatus;
            int MultisiteStatus;
            if (AdStatus == 1)
            {
                ListingStatus = 1;
                UCEStatus = Convert.ToInt32(ddlUceStatus.SelectedItem.Value);
                MultisiteStatus = Convert.ToInt32(ddlMultisiteStatus.SelectedItem.Value);
            }
            else
            {
                ListingStatus = Convert.ToInt32(ddlListingStatus.SelectedItem.Value);
                UCEStatus = 0;
                MultisiteStatus = 0;
            }
            bool bnew = objdropdownBL.SmartzUpdateStatusDetailsForNewForm(PostingID, TranBy, AdStatus, ListingStatus, UCEStatus, MultisiteStatus);
            if (bnew == true)
            {
                lblAlertUpdatedSuccess.Text = "Ad status details updated successfully";
                lblAlertUpdatedSuccess.Visible = true;
                MdepUpdatedSuccess.Show();
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

    protected void lnkbtnSellerdataEdit_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            txtSellerEditZip.Text = CarsDetails.Tables[0].Rows[0]["zip"].ToString();
            txtSellerEditCity.Text = CarsDetails.Tables[0].Rows[0]["city"].ToString();
            txtSellerEditEmail.Text = CarsDetails.Tables[0].Rows[0]["email"].ToString();
            if (CarsDetails.Tables[0].Rows[0]["phone"].ToString() == "")
            {
                txtSellerEditPhone.Text = "";
            }
            else
            {
                txtSellerEditPhone.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["phone"].ToString());
            }
            ListItem listSellerState = new ListItem();
            listSellerState.Value = CarsDetails.Tables[0].Rows[0]["state"].ToString();
            listSellerState.Text = CarsDetails.Tables[0].Rows[0]["state"].ToString();
            ddlSellerState.SelectedIndex = ddlSellerState.Items.IndexOf(listSellerState);
            mdepEditSeller.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnEditSellerUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int SellerID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["sellerID"].ToString());
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            string city = txtSellerEditCity.Text.Trim();
            string state = ddlSellerState.SelectedItem.Text;
            string Zip = txtSellerEditZip.Text.Trim();
            string Phone = txtSellerEditPhone.Text.Trim();
            string email = txtSellerEditEmail.Text.Trim();
            bool bnew = objdropdownBL.SmartzUpdateSellerDetailsForNewForm(city, state, Zip, Phone, SellerID, email, TranBy);
            if (bnew == true)
            {
                lblAlertUpdatedSuccess.Text = "Seller details updated successfully";
                lblAlertUpdatedSuccess.Visible = true;
                MdepUpdatedSuccess.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnVehicleInfoEdit_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
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
                txtAskingPriceEdit.Text = "";
            }
            else
            {
                txtAskingPriceEdit.Text = string.Format("{0:0}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["price"].ToString()));
            }
            if (txtAskingPrice.Text.Length > 6)
            {
                txtAskingPriceEdit.Text = txtAskingPrice.Text.Substring(0, 6);
            }

            if (CarsDetails.Tables[0].Rows[0]["mileage"].ToString() == "0.00")
            {
                txtMileageEdit.Text = "";
            }
            else
            {
                txtMileageEdit.Text = string.Format("{0:0}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["mileage"].ToString()));
            }
            if (txtMileage.Text.Length > 6)
            {
                txtMileageEdit.Text = txtMileage.Text.Substring(0, 6);
            }

            string NumberOfCylinder = CarsDetails.Tables[0].Rows[0]["numberOfCylinder"].ToString();
            if (NumberOfCylinder == "3 Cylinder")
            {
                rdbtnCylinders1Edit.Checked = true;
                rdbtnCylinders7Edit.Checked = false;
            }
            else if (NumberOfCylinder == "4 Cylinder")
            {
                rdbtnCylinders2Edit.Checked = true;
                rdbtnCylinders7Edit.Checked = false;
            }
            else if (NumberOfCylinder == "5 Cylinder")
            {
                rdbtnCylinders3Edit.Checked = true;
                rdbtnCylinders7Edit.Checked = false;
            }
            else if (NumberOfCylinder == "6 Cylinder")
            {
                rdbtnCylinders4Edit.Checked = true;
                rdbtnCylinders7Edit.Checked = false;
            }
            else if (NumberOfCylinder == "7 Cylinder")
            {
                rdbtnCylinders5Edit.Checked = true;
                rdbtnCylinders7Edit.Checked = false;
            }
            else if (NumberOfCylinder == "8 Cylinder")
            {
                rdbtnCylinders6Edit.Checked = true;
                rdbtnCylinders7Edit.Checked = false;
            }
            else
            {
                rdbtnCylinders7Edit.Checked = true;
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
                rdbtnTrans1Edit.Checked = true;
                rdbtnTrans4Edit.Checked = false;
            }
            else if (Transmission == "Manual")
            {
                rdbtnTrans2Edit.Checked = true;
                rdbtnTrans4Edit.Checked = false;
            }
            else if (Transmission == "Tiptronic")
            {
                rdbtnTrans3Edit.Checked = true;
                rdbtnTrans4Edit.Checked = false;
            }
            else
            {
                rdbtnTrans4Edit.Checked = true;
            }
            string NumberOfDoors = CarsDetails.Tables[0].Rows[0]["numberOfDoors"].ToString();
            if (NumberOfDoors == "Two Door")
            {
                rdbtnDoor2Edit.Checked = true;
                rdbtnDoor6Edit.Checked = false;
            }
            else if (NumberOfDoors == "Three Door")
            {
                rdbtnDoor3Edit.Checked = true;
                rdbtnDoor6Edit.Checked = false;
            }
            else if (NumberOfDoors == "Four Door")
            {
                rdbtnDoor4Edit.Checked = true;
                rdbtnDoor6Edit.Checked = false;
            }

            else if (NumberOfDoors == "Five Door")
            {
                rdbtnDoor5Edit.Checked = true;
                rdbtnDoor6Edit.Checked = false;
            }
            else
            {
                rdbtnDoor6Edit.Checked = true;
            }
            string DriveTrain = CarsDetails.Tables[0].Rows[0]["DriveTrain"].ToString();
            if (DriveTrain == "2 wheel drive")
            {
                rdbtnDriveTrain1Edit.Checked = true;
                rdbtnDriveTrain5Edit.Checked = false;
            }
            else if (DriveTrain == "2 wheel drive - front")
            {
                rdbtnDriveTrain2Edit.Checked = true;
                rdbtnDriveTrain5Edit.Checked = false;
            }
            else if (DriveTrain == "All wheel drive")
            {
                rdbtnDriveTrain3Edit.Checked = true;
                rdbtnDriveTrain5Edit.Checked = false;
            }
            else if (DriveTrain == "Rear wheel drive")
            {
                rdbtnDriveTrain4Edit.Checked = true;
                rdbtnDriveTrain5Edit.Checked = false;
            }
            else
            {
                rdbtnDriveTrain5Edit.Checked = true;
            }
            txtVinEdit.Text = CarsDetails.Tables[0].Rows[0]["VIN"].ToString();

            int FuelTypeID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["fuelTypeID"].ToString());
            if (FuelTypeID == 1)
            {
                rdbtnFuelType1Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else if (FuelTypeID == 2)
            {
                rdbtnFuelType2Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else if (FuelTypeID == 3)
            {
                rdbtnFuelType3Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else if (FuelTypeID == 4)
            {
                rdbtnFuelType4Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else if (FuelTypeID == 5)
            {
                rdbtnFuelType5Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else if (FuelTypeID == 6)
            {
                rdbtnFuelType6Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else if (FuelTypeID == 7)
            {
                rdbtnFuelType7Edit.Checked = true;
                rdbtnFuelType8Edit.Checked = false;
            }
            else
            {
                rdbtnFuelType8Edit.Checked = true;
            }
            int ConditionID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["conditionID"].ToString());
            if (ConditionID == 1)
            {
                rdbtnCondition1Edit.Checked = true;
                rdbtnCondition7Edit.Checked = false;
            }
            else if (ConditionID == 2)
            {
                rdbtnCondition2Edit.Checked = true;
                rdbtnCondition7Edit.Checked = false;
            }
            else if (ConditionID == 3)
            {
                rdbtnCondition3Edit.Checked = true;
                rdbtnCondition7Edit.Checked = false;
            }
            else if (ConditionID == 4)
            {
                rdbtnCondition4Edit.Checked = true;
                rdbtnCondition7Edit.Checked = false;
            }
            else if (ConditionID == 5)
            {
                rdbtnCondition5Edit.Checked = true;
                rdbtnCondition7Edit.Checked = false;
            }
            else if (ConditionID == 6)
            {
                rdbtnCondition6Edit.Checked = true;
                rdbtnCondition7Edit.Checked = false;
            }
            else
            {
                rdbtnCondition7Edit.Checked = true;
            }

            mdepEditVehicleInfo.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnEditVehicleInfoUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int CarID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["CarID"].ToString());
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Value);
            int MakeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value);
            int BodyTypeID = Convert.ToInt32(ddlBodyStyle.SelectedItem.Value);
            string Price = string.Empty;
            if (txtAskingPriceEdit.Text.Trim() == "")
            {
                Price = "0";
            }
            else
            {
                Price = txtAskingPriceEdit.Text.Trim();
                Price = Price.Replace(",", "");
            }
            string Mileage = string.Empty;
            if (txtMileageEdit.Text.Trim() == "")
            {
                Mileage = "0";
            }
            else
            {
                Mileage = txtMileageEdit.Text.Trim();
                Mileage = Mileage.Replace(",", "");
                Mileage = Mileage.Replace("mi", "");
                Mileage = Mileage.Replace(" ", "");
            }
            string ExteriorColor = ddlExteriorColor.SelectedItem.Text;
            string InteriorColor = ddlInteriorColor.SelectedItem.Text;
            string Transmission = "Unspecified";
            if (rdbtnTrans1Edit.Checked == true)
            {
                Transmission = "Automatic";
            }
            else if (rdbtnTrans2Edit.Checked == true)
            {
                Transmission = "Manual";
            }
            else if (rdbtnTrans3Edit.Checked == true)
            {
                Transmission = "Tiptronic";
            }
            else if (rdbtnTrans4Edit.Checked == true)
            {
                Transmission = "Unspecified";
            }

            string NumberOfDoors = string.Empty;
            if (rdbtnDoor2Edit.Checked == true)
            {
                NumberOfDoors = "Two Door";
            }
            else if (rdbtnDoor3Edit.Checked == true)
            {
                NumberOfDoors = "Three Door";
            }
            else if (rdbtnDoor4Edit.Checked == true)
            {
                NumberOfDoors = "Four Door";
            }
            else if (rdbtnDoor5Edit.Checked == true)
            {
                NumberOfDoors = "Five Door";
            }
            else
            {
                NumberOfDoors = "Unspecified";
            }
            string DriveTrain = "Unspecified";
            if (rdbtnDriveTrain1Edit.Checked == true)
            {
                DriveTrain = "2 wheel drive";
            }
            else if (rdbtnDriveTrain2Edit.Checked == true)
            {
                DriveTrain = "2 wheel drive - front";
            }
            else if (rdbtnDriveTrain3Edit.Checked == true)
            {
                DriveTrain = "All wheel drive";
            }
            else if (rdbtnDriveTrain4Edit.Checked == true)
            {
                DriveTrain = "Rear wheel drive";
            }
            else if (rdbtnDriveTrain5Edit.Checked == true)
            {
                DriveTrain = "Unspecified";
            }

            string VIN = txtVinEdit.Text;
            string NumberOfCylinder = "Unspecified";
            if (rdbtnCylinders1Edit.Checked == true)
            {
                NumberOfCylinder = "3 Cylinder";
            }
            else if (rdbtnCylinders2Edit.Checked == true)
            {
                NumberOfCylinder = "4 Cylinder";
            }
            else if (rdbtnCylinders3Edit.Checked == true)
            {
                NumberOfCylinder = "5 Cylinder";
            }
            else if (rdbtnCylinders4Edit.Checked == true)
            {
                NumberOfCylinder = "6 Cylinder";
            }
            else if (rdbtnCylinders5Edit.Checked == true)
            {
                NumberOfCylinder = "7 Cylinder";
            }
            else if (rdbtnCylinders6Edit.Checked == true)
            {
                NumberOfCylinder = "8 Cylinder";
            }

            int FuelTypeID = Convert.ToInt32(0);
            if (rdbtnFuelType1Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(1);
            }
            else if (rdbtnFuelType2Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(2);
            }
            else if (rdbtnFuelType3Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(3);
            }
            else if (rdbtnFuelType4Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(4);
            }
            else if (rdbtnFuelType5Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(5);
            }
            else if (rdbtnFuelType6Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(6);
            }
            else if (rdbtnFuelType7Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(7);
            }
            else if (rdbtnFuelType8Edit.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(0);
            }

            int ConditionID = Convert.ToInt32(0);
            string Condition = "Unspecified";
            if (rdbtnCondition1Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(1);
                Condition = "Excellent";
            }
            else if (rdbtnCondition2Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(2);
                Condition = "Very Good";
            }
            else if (rdbtnCondition3Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(3);
                Condition = "Good";
            }
            else if (rdbtnCondition4Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(4);
                Condition = "Fair";
            }
            else if (rdbtnCondition5Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(5);
                Condition = "Poor";
            }
            else if (rdbtnCondition6Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(6);
                Condition = "Parts or Salvage";
            }
            else if (rdbtnCondition7Edit.Checked == true)
            {
                ConditionID = Convert.ToInt32(0);
                Condition = "Unspecified";
            }
            bool bnew = objdropdownBL.SmartzUpdateCardetailsForNewForm(YearOfMake, MakeModelID, BodyTypeID, ConditionID, DriveTrain, CarID, Price, Mileage, ExteriorColor, InteriorColor,
                            Transmission, NumberOfDoors, VIN, NumberOfCylinder, FuelTypeID, Condition, TranBy);
            if (bnew == true)
            {
                lblAlertUpdatedSuccess.Text = "Vehicle details updated successfully";
                lblAlertUpdatedSuccess.Visible = true;
                MdepUpdatedSuccess.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnEditVehicleFeat_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            for (int i = 1; i < 54; i++)
            {
                if (i != 10)
                {
                    if (i != 37)
                    {
                        if (i != 38)
                        {
                            string ChkBoxID = "chkFeaturesEdit" + i.ToString();
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
                rdbtnLeatherEdit.Checked = true;
                rdbtnInteriorNAEdit.Checked = false;
            }
            if (CarsDetails.Tables[3].Rows[36]["Isactive"].ToString() == "True")
            {
                rdbtnVinylEdit.Checked = true;
                rdbtnInteriorNAEdit.Checked = false;
            }
            if (CarsDetails.Tables[3].Rows[37]["Isactive"].ToString() == "True")
            {
                rdbtnClothEdit.Checked = true;
                rdbtnInteriorNAEdit.Checked = false;
            }
            if (CarsDetails.Tables[3].Rows.Count.ToString() == "53")
            {
                if (CarsDetails.Tables[3].Rows[53]["Isactive"].ToString() == "True")
                {
                    rdbtnInteriorNAEdit.Checked = true;
                }
            }
            mdepEditVehicleFeat.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnEditVehicleFeatUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int CarID = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["CarID"].ToString());
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int FeatureID;
            int IsactiveFea;
            for (int i = 1; i < 54; i++)
            {
                if (i != 10)
                {
                    if (i != 37)
                    {
                        if (i != 38)
                        {
                            string ChkBoxID = "chkFeaturesEdit" + i.ToString();
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
                    }
                }
            }
            if (rdbtnLeatherEdit.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 10;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 10;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            if (rdbtnVinylEdit.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 37;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 37;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            if (rdbtnClothEdit.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 38;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 38;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }

            if (rdbtnInteriorNAEdit.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 54;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 54;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, TranBy);
            }
            lblAlertUpdatedSuccess.Text = "Vehicle features updated successfully";
            lblAlertUpdatedSuccess.Visible = true;
            MdepUpdatedSuccess.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
