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


public partial class CarDetailsView : System.Web.UI.Page
{
    DataSet dsActiveSmartzUsers = new DataSet();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
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
                Session["ViewMultiCarDetailsDataset"] = CarsDetails;
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
                        lblCarID.Text = CarsDetails.Tables[0].Rows[0]["carid"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString() == "NULL" || CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString().Trim() == "")
                        {
                            lblBrand.Text = "UCE";
                            Session["BrandID"] = 1;
                        }
                        else
                        {
                            lblBrand.Text = CarsDetails.Tables[0].Rows[0]["BrandCode"].ToString();
                            Session["BrandID"] = CarsDetails.Tables[0].Rows[0]["BrnadId"].ToString();
                        }


                        DateTime PostDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["dateOfPosting"].ToString());
                        lblPostingDate.Text = PostDate.ToString("MM/dd/yyyy");
                        DateTime SaleDate = Convert.ToDateTime(CarsDetails.Tables[0].Rows[0]["SaleDate"].ToString());
                        lblSaleDate.Text = SaleDate.ToString("MM/dd/yyyy");

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

                        lblAgent.Text = CarsDetails.Tables[0].Rows[0]["ReferCode"].ToString();
                        Double PackCost = new Double();
                        PackCost = Convert.ToDouble(CarsDetails.Tables[0].Rows[0]["PackagePrice"].ToString());
                        string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                        string PackName = CarsDetails.Tables[0].Rows[0]["PackageName"].ToString();
                        lblPackage.Text = PackName + "($" + PackAmount + ")";
                        lblCarPackName.Text = PackName + "($" + PackAmount + ")";

                        //lblCustName.Text = CarsDetails.Tables[0].Rows[0]["sellerName"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["phone"].ToString() == "")
                        {
                            lblCustPhNo.Text = "";
                        }
                        else
                        {
                            lblCustPhNo.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["phone"].ToString());
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
                        Model = Model.Replace("&", "@");
                        //lblZip.Text == "" ? "0" : lblZip.Text 
                        //HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/SearchCarDetails.aspx?Make=" + CarsDetails.Tables[0].Rows[0]["make"].ToString() + "&Model=" + CarsDetails.Tables[0].Rows[0]["model"].ToString() + "&ZipCode=0&WithinZip=5&C=4zVbl2Mc" + CarsDetails.Tables[0].Rows[0]["carId"].ToString();                        

                        if (Session["BrandID"].ToString().Trim() == "1")
                        {
                            HylinkUCE.NavigateUrl = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
                            HylinkUCE.Target = "blank";

                        }
                        else if (Session["BrandID"].ToString().Trim() == "2")
                        {
                            HylinkUCE.Text = "Link to MOBI listing";
                            HylinkUCE.NavigateUrl = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + Make.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
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
                        lblPassword.Text = CarsDetails.Tables[0].Rows[0]["Pwd"].ToString();
                        lblRegName.Text = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        lblCarCustName.Text = CarsDetails.Tables[0].Rows[0]["Name"].ToString();
                        if (CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString() == "")
                        {
                            lblRegPhNo.Text = "";
                        }
                        else
                        {
                            lblRegPhNo.Text = objGeneralFunc.filPhnm(CarsDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
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
                            string ColumnPic = "pic" + i.ToString();
                            string ColumnPicName = "PIC" + i.ToString();
                            string ColumnPicLocation = "PICLOC" + i.ToString();
                            System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                            System.Web.UI.WebControls.Label LabelName = (System.Web.UI.WebControls.Label)form1.FindControl(lblID);
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
                        if (CarsDetails.Tables[5].Rows.Count > 0)
                        {
                            if (CarsDetails.Tables[5].Rows[0]["CallDate"].ToString() != "")
                            {
                                DateTime WCCallDt = Convert.ToDateTime(CarsDetails.Tables[5].Rows[0]["CallDate"].ToString());
                                lblWCCallDate.Text = WCCallDt.ToString("MM/dd/yyyy");
                            }
                            lblWCCallBy.Text = objGeneralFunc.GetSmartzUser(CarsDetails.Tables[5].Rows[0]["CallAgentID"].ToString());
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
                Response.Redirect("EditmultiCarDetails.aspx");
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
                    DateTime dtPostDt = Convert.ToDateTime(hdnPostDate.Value);
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
                  
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate, Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else if (Session["BrandID"].ToString() == "2")
                {
                    string Link = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + Make.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
                  
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate, Convert.ToInt32(Session["BrandID"].ToString()));
                }
            }
            else
            {
                if (Session["BrandID"].ToString() == "1")
                {
                    string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
                    string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink,Convert.ToInt32(Session["BrandID"].ToString()));
                    //text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink, 
                }
                else if (Session["BrandID"].ToString() == "2")
                {
                    string Link = "http://mobicarz.com/Buy-Sell-UsedCar/" + Year + "-" + Make.Replace("-", "@") + "-" + Model.Replace("-", "@") + "-" + UniqueID;
                    string TermsLink = "http://mobicarz.com/TermsandConditions.aspx";
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink, Convert.ToInt32(Session["BrandID"].ToString()));
                }
               
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
            string LoginName = lblMailTo.Text;
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
            MailMessage msg = new MailMessage();
            string text = string.Empty;
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
                msg.Subject = "Registration Details From United Car Exchange For Car ID# " + Session["CustViewCarID"].ToString();
                msg.IsBodyHtml = true;
               
                if (Session["ViewPayStatus"].ToString() == "5")
                {
                    DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                    PDDate = PostDate.ToString("MM/dd/yyyy");
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate,Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else
                {
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink,Convert.ToInt32(Session["BrandID"].ToString()));
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
                msg.Subject = "Registration Details From MobiCarz For Car ID# " + Session["CustViewCarID"].ToString();
                msg.IsBodyHtml = true;
               
                if (Session["ViewPayStatus"].ToString() == "5")
                {
                    DateTime PostDate = Convert.ToDateTime(Session["ViewPDDate"].ToString());
                    PDDate = PostDate.ToString("MM/dd/yyyy");
                    text = format.SendRegistrationdetailsForPDSales(LoginUserID, LoginPassword, UserDisName, ref text, PDDate,Convert.ToInt32(Session["BrandID"].ToString()));
                }
                else
                {
                    text = format.SendRegistrationdetails(LoginUserID, LoginPassword, UserDisName, ref text, Link, TermsLink,Convert.ToInt32(Session["BrandID"].ToString()));
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
            Response.Redirect("CarDetailsView.aspx");
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
                Response.Redirect("MultiCars.aspx");
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
            if (Session["Click"] == "4")
            {
                Response.Redirect("Index.aspx");
            }
            if (Session["Click"] == "5")
            {
                Response.Redirect("MultiCars.aspx");
            }
            if (Session["Click"] == "6")
            {
                Response.Redirect("SearchNew.aspx");
            }
            if (Session["Click"] == "7")
            {
                Response.Redirect("CarDetailsView.aspx");
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
    protected void lnkbtnShowAllPhotosUploaded_Click(object sender, EventArgs e)
    {
        try
        {
            CarsDetails = Session["ViewMultiCarDetailsDataset"] as DataSet;
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
                SelModelDis = SelModelDis.Replace("&", "@");
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
}
