
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
using System.Collections.Specialized;
using System.Text;
using CarsBL.CentralDBTransactions;


public partial class CustomerView : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
    DataSet dsActiveSmartzUsers = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    ChargeBackInfo objChargeBackInfo = new ChargeBackInfo();
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
                if (Session["TicketDdl"] == null)
                {
                    SmartzTicketDdlDs = objdropdownBL.USP_SmartzTicketDropDown();
                    Session["TicketDdl"] = SmartzTicketDdlDs;
                }
                dsActiveSmartzUsers = objCentralDBBL.GetSmartzUsersActiveData();
                Session["ActiveSmartzUsers"] = dsActiveSmartzUsers;

                int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
                CarsDetails = objdropdownBL.USP_GetCustomerDetailsByPostingID(PostingID);
                Session["ViewCarDetailsDataset"] = CarsDetails;
                if (CarsDetails.Tables.Count > 0)
                {
                    if (CarsDetails.Tables[0].Rows.Count > 0)
                    {
                        lblCarID.Text = CarsDetails.Tables[0].Rows[0]["carid"].ToString();

                        if (CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString() == "NULL" || CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString().Trim() == "")
                        {
                            lblBrand.Text="UCE";
                            Session["BrandID"] = 1;
                        }
                        else
                        {
                            lblBrand.Text = CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString();
                            Session["BrandID"] = CarsDetails.Tables[0].Rows[0]["BrnadId"].ToString();
                        }
                        Session["ViewCarID"] = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        Session["ViewUID"] = CarsDetails.Tables[0].Rows[0]["uid"].ToString();
                        Session["ViewsellerID"] = CarsDetails.Tables[0].Rows[0]["sellerID"].ToString();

                        Session["ViewpaymentID"] = CarsDetails.Tables[0].Rows[0]["paymentID"].ToString();

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
                            Session["ViewPDDate"] = PDDate;
                        }
                        if (CarsDetails.Tables[0].Rows[0]["CarsalesID"].ToString() != "")
                        {
                            lblCarsalesID.Text = CarsDetails.Tables[0].Rows[0]["CarsalesID"].ToString();
                        }
                        else
                        {
                            lblCarsalesID.Text = "0";
                        }
                        lblAgent.Text = CarsDetails.Tables[0].Rows[0]["ReferCode"].ToString();
                        lblSalesAgent.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["SaleAgentID"].ToString());
                        lblVerifier.Text = objGeneralFunc.GetSalesAgent(CarsDetails.Tables[0].Rows[0]["VerifierID"].ToString());
                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["PackagePrice"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = CarsDetails.Tables[0].Rows[0]["PackageName"].ToString();
                        Session["ViewPackageName"] = PackName.ToString();

                        lblPackage.Text = PackName + "($" + PackAmount + ")";
                        //lblCustName.Text = CarsDetails.Tables[0].Rows[0]["sellerName"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["phone"].ToString().Trim() == "")
                        {
                            lblCustPhNo.Text = "";
                        }
                        else
                        {
                            lblCustPhNo.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["phone"].ToString().Trim());
                        }
                        lblAltNum.Text = CarsDetails.Tables[0].Rows[0]["altPhone"].ToString();
                        lblSellerEmail.Text = CarsDetails.Tables[0].Rows[0]["email"].ToString();
                        //lblAddress.Text = CarsDetails.Tables[0].Rows[0]["address1"].ToString();
                        lblCity.Text = CarsDetails.Tables[0].Rows[0]["city"].ToString();

                        if (CarsDetails.Tables[0].Rows[0]["state"].ToString() == "UN" || CarsDetails.Tables[0].Rows[0]["state"].ToString() == "")
                        {
                            lblState.Text = "Unspecified";
                        }
                        else
                        {
                            lblState.Text = CarsDetails.Tables[0].Rows[0]["state"].ToString();
                        }
                        lblZip.Text = CarsDetails.Tables[0].Rows[0]["zip"].ToString();
                        lblMake.Text = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        lblModel.Text = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                        lblYear.Text = CarsDetails.Tables[0].Rows[0]["yearOfMake"].ToString();
                        lblTitle.Text = CarsDetails.Tables[0].Rows[0]["Title"].ToString();


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
                        Model = Model.Replace("/", "@");
                        Model = Model.Replace("&", "@");
                        //lblZip.Text == "" ? "0" : lblZip.Text 
                        //HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/SearchCarDetails.aspx?Make=" + CarsDetails.Tables[0].Rows[0]["make"].ToString() + "&Model=" + CarsDetails.Tables[0].Rows[0]["model"].ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + CarsDetails.Tables[0].Rows[0]["carId"].ToString();

                        string M1 = Make;
                        if (M1 == "W%20&%20M") M1 = "WM";
                        if (Session["BrandID"].ToString().Trim() == "1")
                        {
                            HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + M1 + "-" + Model + "-" + UniqueID;
                            HylinkUCE.Target = "blank";
                        }
                        else if (Session["BrandID"].ToString().Trim() == "2")
                        {
                            HylinkUCE.Text = "Link to MOBI listing";
                            HylinkUCE.NavigateUrl = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + M1.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
                            HylinkUCE.Target = "blank";

                        }

                        if (CarsDetails.Tables[0].Rows[0]["mileage"].ToString() != "0.00")
                        {
                            lblMileage.Visible = true;
                            lblMi.Visible = true;
                            lblMileage.Text = string.Format("{0:0.00}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["mileage"].ToString()));
                        }
                        else
                        {
                            lblMileage.Visible = true;
                            lblMi.Visible = false;
                            lblMileage.Text = "Unspecified";
                        }
                        if (CarsDetails.Tables[0].Rows[0]["price"].ToString() != "0.0000")
                        {
                            lblPrice.Visible = true;
                            lblPrice.Text = "$" + string.Format("{0:0.00}", Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["price"].ToString()));
                        }
                        else
                        {
                            lblPrice.Visible = true;
                            lblPrice.Text = "Unspecified";
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

                        lblExteriorColor.Text = CarsDetails.Tables[0].Rows[0]["exteriorColor"].ToString();
                        lblInteriorColor.Text = CarsDetails.Tables[0].Rows[0]["interiorColor"].ToString();
                        lblBodyStyle.Text = CarsDetails.Tables[0].Rows[0]["bodyType"].ToString();
                        lblEngineCylinders.Text = CarsDetails.Tables[0].Rows[0]["numberOfCylinder"].ToString();
                        lblVehicleCondition.Text = CarsDetails.Tables[0].Rows[0]["ConditionDescription"].ToString();
                        lblTransmission.Text = CarsDetails.Tables[0].Rows[0]["Transmission"].ToString();
                        lblDriveTrain.Text = CarsDetails.Tables[0].Rows[0]["DriveTrain"].ToString();
                        lblDoors.Text = CarsDetails.Tables[0].Rows[0]["numberOfDoors"].ToString();
                        lblFuelType.Text = CarsDetails.Tables[0].Rows[0]["fuelType"].ToString();
                        lblVIN.Text = CarsDetails.Tables[0].Rows[0]["VIN"].ToString();
                        string CarDescription = CarsDetails.Tables[0].Rows[0]["description"].ToString();
                        lblDescription.Text = Server.HtmlEncode(CarDescription);
                        lblUserEmail.Text = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        lblRegUserID.Text = CarsDetails.Tables[0].Rows[0]["UserID"].ToString();
                        lblUnamePW.Text = CarsDetails.Tables[0].Rows[0]["UserID"].ToString();
                        lblPassword.Text = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        lblRegName.Text = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        lblBusinessName.Text = CarsDetails.Tables[0].Rows[0]["BusinessName"].ToString();
                        lblRegAltEmail.Text = CarsDetails.Tables[0].Rows[0]["AltEmail"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString() == "0")
                        {
                            Session["ViewCarEmailExists"] = 0;
                            chkbxEMailNA.Checked = true;
                        }
                        else
                        {
                            Session["ViewCarEmailExists"] = 1;
                            chkbxEMailNA.Checked = false;
                        }
                        if (CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString().Trim() == "")
                        {
                            lblRegPhNo.Text = "";
                        }
                        else
                        {
                            lblRegPhNo.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString().Trim());
                        }
                        if (CarsDetails.Tables[0].Rows[0]["RegAltPhone"].ToString().Trim() == "")
                        {
                            lblRegAltPhone.Text = "";
                        }
                        else
                        {
                            lblRegAltPhone.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["RegAltPhone"].ToString().Trim());
                        }
                        lblRegAddress.Text = CarsDetails.Tables[0].Rows[0]["Address"].ToString();
                        lblRegCity.Text = CarsDetails.Tables[0].Rows[0]["RegCity"].ToString();

                        if (CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "UN" || CarsDetails.Tables[0].Rows[0]["State_Code"].ToString() == "")
                        {
                            lblRegState.Text = "Unspecified";
                        }
                        else
                        {
                            lblRegState.Text = CarsDetails.Tables[0].Rows[0]["State_Code"].ToString();
                        }

                        lblRegZip.Text = CarsDetails.Tables[0].Rows[0]["RegZip"].ToString();

                        string OldNotes = CarsDetails.Tables[0].Rows[0]["InternalNotes"].ToString();
                        OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                        OldNotes = OldNotes.Replace("<br />", Environment.NewLine);
                        txtOldIntNotes.Text = OldNotes;

                        string OldSpecialNotes = CarsDetails.Tables[0].Rows[0]["SpecialNotes"].ToString();
                        OldSpecialNotes = OldSpecialNotes.Replace("<br>", Environment.NewLine);
                        txtOldSpecialNotes.Text = OldSpecialNotes;


                        Session["RegUserName"] = CarsDetails.Tables[0].Rows[0]["UserName"].ToString();
                        Session["RegPassword"] = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        Session["RegName"] = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        Session["RegLoginUserID"] = CarsDetails.Tables[0].Rows[0]["UserID"].ToString();
                        Session["RegEmailExists"] = CarsDetails.Tables[0].Rows[0]["EmailExists"].ToString();
                        Session["CustViewCarID"] = CarsDetails.Tables[0].Rows[0]["carId"].ToString();

                        if (CarsDetails.Tables[0].Rows[0]["isActive"].ToString() == "True")
                        {
                            lblAdStatus.Text = "Active";
                        }
                        else
                        {
                            lblAdStatus.Text = "Inactive";
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
                            lblMultisiteStatus.Text = "Active";
                        }
                        else
                        {
                            lblMultisiteStatus.Text = "Inactive";
                        }
                        lblListingStatus.Text = CarsDetails.Tables[0].Rows[0]["AdStatusName"].ToString();
                        int TotalImgCount = Convert.ToInt32(CarsDetails.Tables[0].Rows[0]["Maxphotos"].ToString());
                        tdThumb.Style["display"] = "block";
                        trShowPhotoCount.Style["display"] = "block";

                        string StockMake = CarsDetails.Tables[0].Rows[0]["make"].ToString();
                        StockMake = StockMake.Replace(" ", "-");
                        string StockModel = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                        StockModel = StockModel.Replace("/", "@");
                        StockModel = StockModel.Replace("&", "@");
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
                            string BtnID = "btnDelete" + i.ToString();
                            string ColumnPic = "pic" + i.ToString();
                            string ColumnPicName = "PIC" + i.ToString();
                            string ColumnPicLocation = "PICLOC" + i.ToString();
                            System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                            System.Web.UI.WebControls.Label LabelName = (System.Web.UI.WebControls.Label)form1.FindControl(lblID);
                            System.Web.UI.WebControls.Button BtnName = (System.Web.UI.WebControls.Button)form1.FindControl(BtnID);
                            string SelModelDis = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                            SelModelDis = SelModelDis.Replace("/", "@");
                            SelModelDis = SelModelDis.Replace("&", "@");
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
                                    BtnName.Visible = true;
                                    ImageName.Visible = true;
                                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString() + CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                                }
                                else
                                {
                                    ImageName.Visible = false;
                                    LabelName.Visible = true;
                                    BtnName.Visible = false;
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

                        if (CarsDetails.Tables[1].Rows.Count > 0)
                        {
                            for (int k = 0; k < CarsDetails.Tables[1].Rows.Count; k++)
                            {
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "1")
                                {
                                    if (lblComFeature.Text == "")
                                    {
                                        lblComFeature.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblComFeature.Text = lblComFeature.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "2")
                                {
                                    if (lblSeatsFea.Text == "")
                                    {
                                        lblSeatsFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblSeatsFea.Text = lblSeatsFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "3")
                                {
                                    if (lblSafetyFea.Text == "")
                                    {
                                        lblSafetyFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblSafetyFea.Text = lblSafetyFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "4")
                                {
                                    if (lblSoundFea.Text == "")
                                    {
                                        lblSoundFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblSoundFea.Text = lblSoundFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "5")
                                {
                                    if (lblWindowsFea.Text == "")
                                    {
                                        lblWindowsFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblWindowsFea.Text = lblWindowsFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "6")
                                {
                                    if (lblOtherFea.Text == "")
                                    {
                                        lblOtherFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblOtherFea.Text = lblOtherFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "7")
                                {
                                    if (lblNewFea.Text == "")
                                    {
                                        lblNewFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblNewFea.Text = lblNewFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                                if (CarsDetails.Tables[1].Rows[k]["FeatureTypeID"].ToString() == "8")
                                {
                                    if (lblSpecialsFea.Text == "")
                                    {
                                        lblSpecialsFea.Text = CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                    else
                                    {
                                        lblSpecialsFea.Text = lblSpecialsFea.Text + ", " + CarsDetails.Tables[1].Rows[k]["FeatureName"].ToString();
                                    }
                                }
                            }
                        }
                        if (CarsDetails.Tables[2].Rows.Count > 0)
                        {
                            Session["ViewPayStatus"] = CarsDetails.Tables[2].Rows[0]["pmntStatusID"].ToString();
                            lblPayStatus.Text = CarsDetails.Tables[2].Rows[0]["pmntStatus"].ToString();
                            lblPayMethod.Text = CarsDetails.Tables[2].Rows[0]["pmntType"].ToString();
                            lblPayConfirmNo.Text = CarsDetails.Tables[2].Rows[0]["TransactionID"].ToString();
                            lblPayAmount.Text = CarsDetails.Tables[2].Rows[0]["Amount"].ToString();
                            lblVoiceFileName.Text = CarsDetails.Tables[2].Rows[0]["VoiceRecord"].ToString();
                        }
                        if (CarsDetails.Tables[0].Rows[0]["DealerCode"].ToString() != "")
                        {
                            divHeaderNote.Style["display"] = "block";
                            lblHeaderNote.Text = "It is a dealer car from " + CarsDetails.Tables[0].Rows[0]["DealerCode"].ToString();
                            if (CarsDetails.Tables[9].Rows.Count > 0)
                            {
                                Session["ViewPayStatus"] = CarsDetails.Tables[9].Rows[0]["pmntStatusID"].ToString();
                                lblPayStatus.Text = CarsDetails.Tables[9].Rows[0]["pmntStatus"].ToString();
                                lblPayMethod.Text = CarsDetails.Tables[9].Rows[0]["pmntType"].ToString();
                                lblPayConfirmNo.Text = CarsDetails.Tables[9].Rows[0]["TransactionID"].ToString();
                                lblPayAmount.Text = CarsDetails.Tables[9].Rows[0]["Amount"].ToString();
                                lblVoiceFileName.Text = CarsDetails.Tables[9].Rows[0]["VoiceRecord"].ToString();
                                if (CarsDetails.Tables[9].Rows[0]["PayDate"].ToString() != "")
                                {
                                    DateTime PaymentDate = Convert.ToDateTime(CarsDetails.Tables[9].Rows[0]["PayDate"].ToString());
                                    lblPaymentDate.Text = PaymentDate.ToString("MM/dd/yyyy");
                                }
                                if (CarsDetails.Tables[9].Rows[0]["PDDate"].ToString() != "")
                                {
                                    DateTime PDDate = Convert.ToDateTime(CarsDetails.Tables[9].Rows[0]["PDDate"].ToString());
                                    lblPDDate.Text = PDDate.ToString("MM/dd/yyyy");
                                    Session["ViewPDDate"] = PDDate;
                                }
                            }
                        }
                        else
                        {
                            divHeaderNote.Style["display"] = "none";
                        }
                        if (CarsDetails.Tables[7].Rows.Count > 0)
                        {
                            lblExistUrlRes.Visible = false;
                            grdMultiSites.Visible = true;
                            grdMultiSites.DataSource = CarsDetails.Tables[7];
                            grdMultiSites.DataBind();
                        }
                        else
                        {
                            grdMultiSites.Visible = false;
                            lblExistUrlRes.Visible = true;
                            lblExistUrlRes.Text = "Not uploaded";
                        }
                        if (CarsDetails.Tables[5].Rows.Count > 0)
                        {
                            if (CarsDetails.Tables[5].Rows[0]["CallDate"].ToString() != "")
                            {
                                DateTime WCCallDt = Convert.ToDateTime(CarsDetails.Tables[5].Rows[0]["CallDate"].ToString());
                                lblWCCallDate.Text = WCCallDt.ToString("MM/dd/yyyy");
                            }
                            lblWCCallBy.Text = objGeneralFunc.GetSmartzUser(CarsDetails.Tables[5].Rows[0]["CallAgentID"].ToString());
                        }
                        if (CarsDetails.Tables[6].Rows.Count > 0)
                        {
                            lblTicketsError.Visible = false;
                            grdTicketDetails.Visible = true;
                            grdTicketDetails.DataSource = CarsDetails.Tables[6];
                            grdTicketDetails.DataBind();
                        }
                        else
                        {
                            grdTicketDetails.Visible = false;
                            lblTicketsError.Visible = true;
                            lblTicketsError.Text = "No tickets found";
                        }
                        if (CarsDetails.Tables[8].Rows.Count > 0)
                        {
                            lblResultsCustomerServiceCalls.Visible = false;
                            grdCustServiceCalls.Visible = true;
                            grdCustServiceCalls.DataSource = CarsDetails.Tables[8];
                            grdCustServiceCalls.DataBind();
                        }
                        else
                        {
                            grdCustServiceCalls.Visible = false;
                            lblResultsCustomerServiceCalls.Visible = true;
                            lblResultsCustomerServiceCalls.Text = "Calls not done";
                        }
                        if (Session["ViewpaymentID"].ToString() != "")
                        {
                            if (Session["ViewPayStatus"].ToString() == "2")
                            {
                                btnAddNewCBNotice.Enabled = true;
                            }
                            else
                            {
                                btnAddNewCBNotice.Enabled = false;
                            }
                        }
                        else
                        {
                            btnAddNewCBNotice.Enabled = false;
                        }
                    }
                }
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            DataSet dsStatus = objdropdownBL.Get_Customer_LockStatus(PostingID);
            if (dsStatus.Tables[0].Rows[0]["Column1"].ToString() == "UnLocked")
            {
                int IsLocked = 1;
                DataSet dsLockCust = objdropdownBL.USP_Lock_Customer(PostingID, IsLocked);
                Response.Redirect("CustomerEdit.aspx");
            }
            else
            {
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "CarID locked by the another user you cannot edit the details";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


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
    protected void btnResendWelMail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string LoginName = Session["RegUserName"].ToString();

            if (Session["RegUserName"].ToString().Trim() != "")
            {
                lblMailTo.Text = LoginName;
                lblMailTo.Enabled = false;
            }
            else
            {
                lblMailTo.Text = "";
                lblMailTo.Enabled = true;
            }

            string UserDisName = Session["RegName"].ToString();
            string Year = Session["ViewCarYear"].ToString();
            string Model = Session["ViewCarModel"].ToString();
            string Make = Session["ViewCarMake"].ToString();
            string UniqueID = Session["CarViewUniqueID"].ToString();
            string LoginUserID = Session["RegLoginUserID"].ToString();
            Make = Make.Replace(" ", "%20");
            Model = Model.Replace(" ", "%20");
            Model = Model.Replace("&", "@");
           
            clsMailFormats format = new clsMailFormats();
            string text = string.Empty;
            if (Session["ViewPayStatus"].ToString() == "5")
            {
                DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                PDDate = PostDate.ToString("MM/dd/yyyy");

                if (Session["BrandID"].ToString() == "1")
                {
                    string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
                    string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate, Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else if (Session["BrandID"].ToString() == "2")
                {
                    string Link = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + Make.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
                    string TermsLink = "http://mobicarz.com/TermsandConditions.aspx";
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate, Convert.ToInt32(Session["BrandID"].ToString()));
                }
            }
            else
            {
                if (Session["BrandID"].ToString() == "1")
                {
                    string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
                    string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink, Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else if (Session["BrandID"].ToString() == "2")
                {
                    string Link = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + Make.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
                    string TermsLink = "http://mobicarz.com/TermsandConditions.aspx";
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink, Convert.ToInt32(Session["BrandID"].ToString()));
                }
            }
            lblRegisMail.Text = text;
            txtEmailTo.Text = "";
            lblRegisMail.Visible = true;
            mpeViewregisterMail.Show();
        }
        catch (Exception ex)
        {
            throw ex;
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
            if (Session["BrandID"].ToString() == "1")
            {

                txtGenSubject.Text = "Mail From United Car Exchange For Car ID# " + Session["ViewCarID"].ToString();
            }
            else if (Session["BrandID"].ToString() == "2")
            {
                txtGenSubject.Text = "Mail From MobiCarz For Car ID# " + Session["ViewCarID"].ToString();
            }
            txtgenMailText.Text = "";
            mdepgeneralMail.Show();
        }
        catch (Exception ex)
        {
            throw ex;
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
                txtOldIntNotes.Text = OldNotes;
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

            if (Session["BrandID"].ToString() == "1")
            {
                msg.From = new MailAddress("info@unitedcarexchange.com");
                msg.Bcc.Add("archive@unitedcarexchange.com");
            }
            else if (Session["BrandID"].ToString() == "2")
            {
                msg.From = new MailAddress("info@mobicarz.com");
                msg.Bcc.Add("archive@mobicarz.com");
            }
            string ToEmail = lblGenMailTo.Text;
            msg.To.Add(ToEmail);
            if (txtGenCCMail.Text != "")
            {
                msg.CC.Add(txtGenCCMail.Text);
            }
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
                txtOldIntNotes.Text = OldNotes;
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
            if (LoginName.Trim() == "")
            {
                LoginName = lblMailTo.Text.Trim();
            }
                       
            string UserDisName = Session["RegName"].ToString();
            string Year = Session["ViewCarYear"].ToString();
            string Model = Session["ViewCarModel"].ToString();
            string Make = Session["ViewCarMake"].ToString();
            string UniqueID = Session["CarViewUniqueID"].ToString();
            string LoginUserID = Session["RegLoginUserID"].ToString();
            Make = Make.Replace(" ", "%20");
            Model = Model.Replace(" ", "%20");
            Model = Model.Replace("&", "@");
            clsMailFormats format = new clsMailFormats();
            string text = string.Empty;
            MailMessage msg = new MailMessage();
            if (Session["BrandID"].ToString() == "1")
            {
                string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
                string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
              
                msg.From = new MailAddress("info@unitedcarexchange.com");
                msg.To.Add(LoginName);
                if (txtEmailTo.Text != "")
                {
                    msg.CC.Add(txtEmailTo.Text);
                }
                msg.Bcc.Add("archive@unitedcarexchange.com");
                msg.Subject = "Registration Details From United Car Exchange For Car ID# " + Session["ViewCarID"].ToString();
                msg.IsBodyHtml = true;
                
                if (Session["ViewPayStatus"].ToString() == "5")
                {
                    DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                    PDDate = PostDate.ToString("MM/dd/yyyy");
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate, Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else
                {
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink, Convert.ToInt32(Session["BrandID"].ToString()));
                }
            }
            else if (Session["BrandID"].ToString() == "2")
            {
                string Link = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + Make.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
                string TermsLink = "http://mobicarz.com/TermsandConditions.aspx";
               
                msg.From = new MailAddress("info@mobicarz.com");
                msg.To.Add(LoginName);
                if (txtEmailTo.Text != "")
                {
                    msg.CC.Add(txtEmailTo.Text);
                }
                msg.Bcc.Add("archive@mobicarz.com");
                msg.Subject = "Registration Details From MobiCarz For Car ID# " + Session["ViewCarID"].ToString();
                msg.IsBodyHtml = true;
             
                if (Session["ViewPayStatus"].ToString() == "5")
                {
                    DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                    PDDate = PostDate.ToString("MM/dd/yyyy");
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate, Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else
                {
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink, Convert.ToInt32(Session["BrandID"].ToString()));
                }
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
    protected void btnSpecialNotesUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int CustUID = Convert.ToInt32(Session["ViewUID"].ToString());
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            String UpdatedBy = Session[Constants.NAME].ToString();
            string InternalNotesNew = txtNewSpecialNotes.Text.Trim();
            string UpdateByWithDate = System.DateTime.Now.ToUniversalTime().AddHours(-4).ToString() + "-" + UpdatedBy + "<br>";
            //InternalNotesNew = UpdateByWithDate + InternalNotesNew.Trim() + "<br>" + "-------------------------------------------------";
            DataSet dsNewIntNotes = objdropdownBL.UpdateCustomerSpecialNotes(CustUID, InternalNotesNew, UID);
            Session.Timeout = 180;
            if (dsNewIntNotes.Tables[0].Rows.Count > 0)
            {
                string OldNotes = dsNewIntNotes.Tables[0].Rows[0]["SpecialNotes"].ToString();
                OldNotes = OldNotes.Replace("<br>", Environment.NewLine);
                txtOldSpecialNotes.Text = OldNotes;
                txtNewSpecialNotes.Text = txtOldSpecialNotes.Text;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnEditSpecialNotes_Click(object sender, EventArgs e)
    {
        try
        {
            txtNewSpecialNotes.Text = txtOldSpecialNotes.Text;
            mpeAskNewSale.Show();
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

    protected void ImgBtnLogo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["Click"] = "4";
            // Response.Redirect("Index.aspx");
            FillTicketDropdown();
            mdepTicketAlert.Show();
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
                    Response.Redirect("PDDateDetails.aspx");
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
    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        try
        {
            //Response.Redirect("index.aspx");
            Session["Click"] = "1";
            FillTicketDropdown();
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
            FillTicketDropdown();
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
        }
    }

    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Click"] = "2";
            FillTicketDropdown();
            //Session.Abandon();
            //Response.Redirect("Login.aspx");
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
        }
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

            ListItem liAssigned = new ListItem();
            liAssigned.Value = Session[Constants.USER_ID].ToString();
            liAssigned.Text = objGeneralFunc.GetSmartzUser(Session[Constants.USER_ID].ToString());
            ddlAssignedTo.SelectedIndex = ddlAssignedTo.Items.IndexOf(liAssigned);

            ListItem liCompleted = new ListItem();
            liCompleted.Value = Session[Constants.USER_ID].ToString();
            liCompleted.Text = objGeneralFunc.GetSmartzUser(Session[Constants.USER_ID].ToString());
            ddlCompletedBy.SelectedIndex = ddlCompletedBy.Items.IndexOf(liCompleted);

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
                DataSet dsDatetime = objdropdownBL.GetDatetime();
                DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                txtPostDate.Text = dtNow.ToString("MM/dd/yyyy");
                txtCompletedDt.Text = dtNow.ToString("MM/dd/yyyy");
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
                    if (dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString() != "")
                    {
                        DateTime SolvedDate = Convert.ToDateTime(dsTicketData.Tables[0].Rows[0]["SolvedDate"].ToString());
                        txtCompletedDt.Text = SolvedDate.ToString("MM/dd/yyyy");
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
                    Response.Redirect("PDDateDetails.aspx");
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
                Response.Redirect("CustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Click"] = "5";
            FillTicketDropdown();
            mdepTicketAlert.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    protected void btnSendStatusMail_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet MultiSite = Session["ViewCarDetailsDataset"] as DataSet;
            DataTable dtMutisite = MultiSite.Tables[4];
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("info@unitedcarexchange.com");
            msg.To.Add("dinesh@datumglobal.net");
            //msg.Bcc.Add("archive@unitedcarexchange.com");
            msg.Subject = "MultiSite";
            msg.IsBodyHtml = true;
            string text = string.Empty;
            //  text = format.SendMultiSitedetailsTesting(ref text, dtMutisite);

            msg.Body = text.ToString();
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("info@unitedcarexchange.com", "info*123*");
            smtp.EnableSsl = true;
            smtp.Send(msg);
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

                if (Session["RegUserName"].ToString().Trim() != "")
                {
                    lblMultiSiteMailTo.Text = LoginName;
                    lblMultiSiteMailTo.Enabled = false;
                }
                else
                {
                    lblMultiSiteMailTo.Text = "";
                    lblMultiSiteMailTo.Enabled = true;
                }

                string PDDate = string.Empty;
                string LoginPassword = Session["RegPassword"].ToString();
                string UserDisName = Session["RegName"].ToString();
                string PackageName = Session["ViewPackageName"].ToString();
                string UniqueID = Session["CarViewUniqueID"].ToString();
                DataSet CarsDetails = (DataSet)Session["ViewCarDetailsDataset"];
                string Carid = Session["ViewCarID"].ToString();
                //text = format.SendMultiSitedetailsTesting(ref text, dtMutisite,CarsDetails);

                if (Session["BrandID"].ToString() == "1")
                {
                    text = format.SendMultiListMail(ref text, dtMutisite, Carid, PackageName, UserDisName, UniqueID);
                }
                else if(Session["BrandID"].ToString() == "2")
                {
                    text = format.SendMultiListMailMobi(ref text, dtMutisite, Carid, PackageName, UserDisName, UniqueID);
                }
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
            txtOldIntNotes.Text = OldNotes;
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

            string LoginName = "";
            if (Session["RegUserName"].ToString().Trim() != "")
            {
                LoginName = Session["RegUserName"].ToString();
            }
            else
            {
                LoginName = lblMultiSiteMailTo.Text.Trim();
            }   
          
            string PDDate = string.Empty;
            string LoginPassword = Session["RegPassword"].ToString();
            string UserDisName = Session["RegName"].ToString();
            if (txtMultiListEmailToCC.Text != "")
            {
                msg.CC.Add(txtMultiListEmailToCC.Text);
            }
            if (Session["BrandID"].ToString() == "1")
            {
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
            }
            else if (Session["BrandID"].ToString() == "2")
            {
                msg.From = new MailAddress("info@mobicarz.com");
                msg.Subject = "MultiSite";
                msg.IsBodyHtml = true;
                string ToEmail = lblMultiSiteMailTo.Text;
                msg.To.Add(ToEmail);
                if (txtEmailTo.Text != "")
                {
                    msg.CC.Add(txtEmailTo.Text);
                }
                msg.Bcc.Add("archive@mobicarz.com");
                msg.Subject = "Multisite Listing Details From MobiCarz For Car ID# " + Session["ViewCarID"].ToString();
                msg.IsBodyHtml = true;

                msg.Body = lblMultiListMail.Text.ToString();
            }
            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new System.Net.NetworkCredential("shobha@datumglobal.net", "sob902290");
            //smtp.EnableSsl = true;
            //smtp.Send(msg);
            SmtpClient smtp = new SmtpClient();
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
    protected void lnkbtnShowAllPhotosUploaded_Click(object sender, EventArgs e)
    {
        try
        {
            CarsDetails = Session["ViewCarDetailsDataset"] as DataSet;
            int TotPhotos = Convert.ToInt32(lblTotPhotosUploaded.Text);
            for (int i = 1; i < TotPhotos + 1; i++)
            {
                string RowIDName = "trImg" + i.ToString();
                System.Web.UI.HtmlControls.HtmlTableRow RowID = (System.Web.UI.HtmlControls.HtmlTableRow)form1.FindControl(RowIDName);
                //RowID.Style["display"] = "block";
                string ImgID = "Img" + i.ToString();
                string lblID = "lblImg" + i.ToString();
                string BtnID = "btnDelete" + i.ToString();
                string ColumnPic = "pic" + i.ToString();
                string ColumnPicName = "PIC" + i.ToString();
                string ColumnPicLocation = "PICLOC" + i.ToString();
                System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                System.Web.UI.WebControls.Label LabelName = (System.Web.UI.WebControls.Label)form1.FindControl(lblID);
                System.Web.UI.WebControls.Button BtnName = (System.Web.UI.WebControls.Button)form1.FindControl(BtnID);
                string SelModelDis = CarsDetails.Tables[0].Rows[0]["model"].ToString();
                SelModelDis = SelModelDis.Replace("/", "@");
                SelModelDis = SelModelDis.Replace("&", "@");
                //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);                

                RowID.Style["display"] = "block";

                if (CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "0" && CarsDetails.Tables[0].Rows[0][ColumnPic].ToString() != "")
                {
                    LabelName.Visible = false;
                    ImageName.Visible = true;
                    BtnName.Visible = true;
                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + CarsDetails.Tables[0].Rows[0][ColumnPicLocation].ToString() + CarsDetails.Tables[0].Rows[0][ColumnPic].ToString();
                }
                else
                {
                    ImageName.Visible = false;
                    LabelName.Visible = true;
                    BtnName.Visible = false;
                }

            }

            trShowall.Style["display"] = "none";
        }
        catch (Exception ex)
        {
            throw ex;
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

    protected void btnAddNewCBNotice_Click(object sender, EventArgs e)
    {
        try
        {
            lblCBVehicle.Text = Session["ViewCarID"].ToString();
            txtCustomerContactDate.Text = "";

            txtReasonCode.Text = "";
            txtReasonCodeDescription.Text = "";
            txtcase.Text = "";
            txtPayAmount.Text = "";

            txtClaimantName.Text = "";
            txtVoiceFile.Text = "";
            txtCBNotes.Text = "";
            FillDdlForNewNotice();
            mpeAddNew.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillDdlForNewNotice()
    {
        try
        {
            DataSet dsDropData = new DataSet();
            if ((Session["CBNoticeDropDown"] == null) || (Session["CBNoticeDropDown"].ToString() == ""))
            {
                dsDropData = objdropdownBL.FillCBDropdown();
                Session["CBNoticeDropDown"] = dsDropData;
            }
            else
            {
                dsDropData = Session["CBNoticeDropDown"] as DataSet;
            }

            ddlType.DataSource = dsDropData.Tables[1];
            ddlType.DataTextField = "RequestTypeName";
            ddlType.DataValueField = "RequestTypeID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnChangePW_Click(object sender, EventArgs e)
    {
        try
        {
            string NewPwd = txtNewPW.Text.Trim();
            int userID = Convert.ToInt32(Session["ViewUID"].ToString());
            bool bnew = objdropdownBL.USP_CHANGE_PASSWORD(NewPwd, userID);
            if (bnew == true)
            {
                Response.Redirect("CustomerView.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnAddCBNotice_Click(object sender, EventArgs e)
    {
        try
        {
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            int PaymentID = Convert.ToInt32(Session["ViewpaymentID"].ToString());
            objChargeBackInfo.CustomerContactdate = Convert.ToDateTime(txtCustomerContactDate.Text);
            objChargeBackInfo.RequestType = Convert.ToInt32(ddlType.SelectedItem.Value);
            objChargeBackInfo.ReasonCode = txtReasonCode.Text.Trim();
            objChargeBackInfo.ReasonCodeDescription = txtReasonCodeDescription.Text.Trim();
            objChargeBackInfo.CaseNumber = txtcase.Text.Trim();
            objChargeBackInfo.CBAmount = txtPayAmount.Text.Trim();
            objChargeBackInfo.ClaimantName = txtClaimantName.Text.Trim();
            objChargeBackInfo.CustomerCBVoiceFile = txtVoiceFile.Text.Trim();
            objChargeBackInfo.Notes = txtCBNotes.Text.Trim();
            DataSet dsSaveCBNotice = objdropdownBL.SmartzSaveCBNotice(PostingID, PaymentID, objChargeBackInfo);
            mdepCBAlert.Show();
            lblCBAlertMsg.Visible = true;
            lblCBAlertMsg.Text = "CB Notice saved successfully";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCBAlertOK_Click(object sender, EventArgs e)
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
}

