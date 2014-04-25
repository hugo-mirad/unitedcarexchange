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
using CarsBL.Transactions;
using CarsInfo;
using System.Collections.Generic;
using CarsBL.Masters;
using System.Web.UI.MobileControls;

public partial class AddNewMultiCar : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();
    UsedCarsInfo objUsedCarsInfo = new UsedCarsInfo();
    public GeneralFunc objGeneralFunc = new GeneralFunc();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Session["CurrentPage"] = "AddNewMulticar";
                Session["PageName"] = "";
                Session["CurrentPageConfig"] = null;
                KeyWords.Addkeywordstags(Header);
                GeneralFunc.SaveSiteVisit();

                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);
                Session["UpDatePackageID"] = null;
                //lblUserName.Text = Session[Constants.NAME].ToString();
                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                Session["DsDropDown"] = dsDropDown;
                DataSet dsUserInfoDetails = objdropdownBL.USP_GetUSerDetailsByUserID(Convert.ToInt32(Session[Constants.USER_ID].ToString()));

                int UserPackID = Convert.ToInt32(Session["SelUserPackID"].ToString());
                DataSet dsSellerInfo = objdropdownBL.USP_GetDataByUserPackID(UserPackID);

                if (dsSellerInfo.Tables[1].Rows.Count > 0)
                {
                    // txtSellerName.Text = "";
                    txtSellerPhone.Text = dsSellerInfo.Tables[1].Rows[0]["PhoneNumber"].ToString();
                    //txtAddress.Text = "";
                    txtCity.Text = dsSellerInfo.Tables[1].Rows[0]["City"].ToString();
                    txtZip.Text = dsSellerInfo.Tables[1].Rows[0]["Zip"].ToString();
                    txtSellerEmail.Text = dsSellerInfo.Tables[1].Rows[0]["UserName"].ToString();

                    ListItem li = new ListItem();
                    li.Text = dsSellerInfo.Tables[1].Rows[0]["State_Code"].ToString();
                    li.Value = dsSellerInfo.Tables[1].Rows[0]["sellerID"].ToString();
                    ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(li);

                }
                if (dsSellerInfo.Tables[0].Rows.Count > 0)
                {
                    Session["MultiCarPackID"] = dsSellerInfo.Tables[0].Rows[0]["PackageID"].ToString();
                    Session["MultiCarPackSaleDate"] = dsSellerInfo.Tables[0].Rows[0]["CreateDate"].ToString();
                    Session["MultiCarPackPaymentID"] = dsSellerInfo.Tables[0].Rows[0]["paymentID"].ToString();
                    Session["MultiCarPaydate"] = dsSellerInfo.Tables[0].Rows[0]["PayDate"].ToString();
                    string PackDescrip = dsSellerInfo.Tables[0].Rows[0]["Description"].ToString();
                    lblPackDiv.Style["display"] = "block";
                    lblPackageName.Text = PackDescrip + "(# " + Session["SelUserPackID"].ToString() + ")";

                }

                GetAllModels();
                GetMakes();
                FillYear();
                GetBody();
                FillFuelTypes();
                FillStates();
                FillExteriorColor();
                FillInteriorColor();
                FillCylinders();
                FillDoors();
                FillTransmissions();
                FillDriveTrain();
                FillCondition();

            }

        }
    }
    private void GetAllModels()
    {
        try
        {
            DataSet dsAllModels = new DataSet();
            dsAllModels = objdropdownBL.USP_GetAllModels(0);
            Session["AllModel"] = dsAllModels;
        }
        catch (Exception ex)
        {
            throw ex;
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
            throw ex;
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
            throw ex;
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
            throw ex;
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
            throw ex;
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
            throw ex;
        }
    }

    private void FillPackage()
    {
        try
        {
            lblPackDiv.Style["display"] = "block";
            int RowNo = Convert.ToInt32(Session["MultiCarPackID"].ToString()) - 1;
            Double PackCost = new Double();
            PackCost = Convert.ToDouble(dsDropDown.Tables[2].Rows[RowNo]["Price"].ToString());
            string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
            string PackName = dsDropDown.Tables[2].Rows[RowNo]["Description"].ToString();
            lblPackageName.Text = PackName + "($" + PackAmount + ")";
            //}

        }
        catch (Exception ex)
        {
            throw ex;
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
            throw ex;
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
            throw ex;
        }
    }

    public void GetMakes()
    {
        try
        {
            var obj = new List<MakesInfo>();

            //MakesInfo objMakes = new MakesInfo();
            MakesBL objMakesBL = new MakesBL();

            obj = (List<MakesInfo>)objMakesBL.GetMakes();
            Session["Makes"] = obj;


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
    public void GetBody()
    {
        try
        {
            var obj = new List<BodyInfo>();

            //MakesInfo objMakes = new MakesInfo();
            MakesBL objMakesBL = new MakesBL();

            obj = (List<BodyInfo>)objMakesBL.GetBodys();
            Session["Bodys"] = obj;


            ddlStyle.DataSource = obj;
            ddlStyle.DataTextField = "bodyType";
            ddlStyle.DataValueField = "bodyTypeID";
            ddlStyle.DataBind();
            ddlStyle.Items.Insert(0, new ListItem("Unspecified", "0"));
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
            DataSet dsModels = Session["AllModel"] as DataSet;
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSaveCarDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int PackageID = Convert.ToInt32(Session["MultiCarPackID"].ToString());
            int YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Text);
            Session["SelYear"] = ddlYear.SelectedItem.Text;
            Session["SelMake"] = ddlMake.SelectedItem.Text;
            Session["SelModel"] = ddlModel.SelectedItem.Text;
            int MakeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value);
            int BodyTypeID = Convert.ToInt32(ddlStyle.SelectedItem.Value);
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
            string Transmission = ddlTransmission.SelectedItem.Text;
            string NumberOfDoors = ddlDoorCount.SelectedItem.Value;
            string DriveTrain = ddlDriveTrain.SelectedItem.Value;
            string VIN = txtVin.Text;
            string NumberOfCylinder = ddlCylinderCount.SelectedItem.Value;
            int FuelTypeID = Convert.ToInt32(ddlFuelType.SelectedItem.Value);
            int ConditionID = Convert.ToInt32(ddlCondition.SelectedItem.Value);
            string SellerZip = string.Empty;
            if (txtZip.Text.Length == 4)
            {
                SellerZip = "0" + txtZip.Text;
            }
            else
            {
                SellerZip = txtZip.Text;
            }
            string SellCity = GeneralFunc.ToProper(txtCity.Text);
            int SellStateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
            string Condition = string.Empty;
            string Description = string.Empty;
            Description = GeneralFunc.ToProper(txtCondition.Text);
            Condition = ddlCondition.SelectedItem.Text;
            string InternalNotesNew = "";
            string Title = txtTitle.Text;
            DataSet dsCarsDetails = objdropdownBL.USP_SmartzSaveCarDetails(YearOfMake, MakeModelID, BodyTypeID, ConditionID, Price, Mileage, ExteriorColor, Transmission, InteriorColor, NumberOfDoors, VIN, NumberOfCylinder, FuelTypeID, SellerZip, SellCity, SellStateID, DriveTrain, Description, Condition, InternalNotesNew, Title);
            Session["CarID"] = Convert.ToInt32(dsCarsDetails.Tables[0].Rows[0]["CarID"].ToString());
            CarID = Convert.ToInt32(Session["CarID"].ToString());
            int RegUID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int FeatureID;
            int IsactiveFea;
            string SellerName = "";
            string Address1 = "";
            string CustPhone = txtSellerPhone.Text;
            string AltCustPhone = "";
            string CustState = ddlLocationState.SelectedItem.Text;
            string CustEmail = txtSellerEmail.Text;
            DateTime SaleDate = Convert.ToDateTime(Session["MultiCarPackSaleDate"].ToString());

            DataSet dsPosting = new DataSet();
            dsPosting = objdropdownBL.USP_SaveMultiCarSellerInfo(SellerName, Address1, SellCity, CustState, SellerZip, CustPhone, AltCustPhone, CustEmail, CarID, RegUID, PackageID, SaleDate);
            Session["PostingID"] = Convert.ToInt32(dsPosting.Tables[0].Rows[0]["PostingID"].ToString());
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
                DataSet dsCarFeature = objdropdownBL.USP_SaveCarFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            int AdActive;
            int ListingStatus;
            int UserPackID = Convert.ToInt32(Session["SelUserPackID"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            AdActive = 1;
            ListingStatus = 1;

            DateTime Paymentdate;
            Paymentdate = Convert.ToDateTime(Session["MultiCarPaydate"].ToString());
            int PaymentID = Convert.ToInt32(Session["MultiCarPackPaymentID"].ToString());
            bool bnewPay = objdropdownBL.USP_SmartzSavePayForMultiCars(PaymentID, AdActive, Paymentdate, ListingStatus, UserPackID, PostingID);


            GeneralFunc.CreateFile("", Session["SelYear"] + "/" + Session["SelMake"] + "-" + Session["SelModel"] + "/" + Session["CarID"].ToString());
            GeneralFunc.CreateFileCS("", Session["SelYear"] + "/" + Session["SelMake"] + "-" + Session["SelModel"] + "/" + Session["CarID"].ToString());

            Response.Redirect("AddNewMultiCarPhotos.aspx");
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
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
