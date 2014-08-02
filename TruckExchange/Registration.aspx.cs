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

public partial class Registration : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();
    UsedCarsInfo objUsedCarsInfo = new UsedCarsInfo();
    UserRegistrationInfo objUserRegInfo = new UserRegistrationInfo();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    UserRegistration objUserregBL = new UserRegistration();
    TruckMainBL objTruckMainBL = new TruckMainBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScript.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

           
            Session["CurrentPage"] = "Home";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;

          

            FillPackage();
            FillStates();
            FillYear();
            FillType();
            GetAllCategories();
            GetAllMakes();
            FillDoors();
            FillFuelTypes();
            FillCondition();
            FillExteriorColor();
            FillInteriorColor();
            FillEngineManufacturer();
            FillTransmissions();
            FillSuspension();
            FillHorsepower();
            FillFeatures();



        }

    }

    private void FillFeatures()
    {
        try
        {
            DataSet dsFeatures = new DataSet();
            if (Session["dsAllFeatures"] == null)
            {
                dsFeatures = objTruckMainBL.GetFeaturesAndTypes();
                Session["dsAllFeatures"] = dsFeatures;
            }
            else
            {
                dsFeatures = Session["dsAllFeatures"] as DataSet;
            }
            for (int i = 0; i < dsFeatures.Tables[0].Rows.Count; i++)
            {
                if (dsFeatures.Tables[0].Rows[i]["FeatureTypeID"].ToString() == "1")
                {
                    ListItem li = new ListItem();
                    li.Value = dsFeatures.Tables[0].Rows[i]["FeatureID"].ToString();
                    li.Text = dsFeatures.Tables[0].Rows[i]["FeatureName"].ToString();
                    chklstIneriorOptions.Items.Add(li);
                }
                if (dsFeatures.Tables[0].Rows[i]["FeatureTypeID"].ToString() == "2")
                {
                    ListItem li = new ListItem();
                    li.Value = dsFeatures.Tables[0].Rows[i]["FeatureID"].ToString();
                    li.Text = dsFeatures.Tables[0].Rows[i]["FeatureName"].ToString();
                    chklstExteriorOptions.Items.Add(li);
                }
                if (dsFeatures.Tables[0].Rows[i]["FeatureTypeID"].ToString() == "3")
                {
                    ListItem li = new ListItem();
                    li.Value = dsFeatures.Tables[0].Rows[i]["FeatureID"].ToString();
                    li.Text = dsFeatures.Tables[0].Rows[i]["FeatureName"].ToString();
                    chklstSafetyOptions.Items.Add(li);
                }
            }
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
            DataSet dsAllActivePackages = new DataSet();
            if (Session["dsActivePackages"] == null)
            {
                dsAllActivePackages = objTruckMainBL.GetActivePackages();
                Session["dsActivePackages"] = dsAllActivePackages;
            }
            else
            {
                dsAllActivePackages = Session["dsActivePackages"] as DataSet;
            }
            for (int i = 0; i < dsAllActivePackages.Tables[0].Rows.Count; i++)
            {
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsAllActivePackages.Tables[0].Rows[i]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = dsAllActivePackages.Tables[0].Rows[i]["Description"].ToString();
                ListItem list = new ListItem();
                list.Text = PackName + "($" + PackAmount + ")";
                list.Value = dsAllActivePackages.Tables[0].Rows[i]["PackageID"].ToString();
                ddlPackage.Items.Add(list);
            }
            ddlPackage.Items.Insert(0, new ListItem("Select", "0"));
            if (Session["PackageID"] != null)
            {
                int RowNo = Convert.ToInt32(Session["PackageID"].ToString()) - 1;
                Double PackCost2 = new Double();
                PackCost2 = Convert.ToDouble(dsAllActivePackages.Tables[0].Rows[RowNo]["Price"].ToString());
                string PackAmount2 = string.Format("{0:0.00}", PackCost2).ToString();
                string PackName2 = dsAllActivePackages.Tables[0].Rows[RowNo]["Description"].ToString();
                ListItem listPack = new ListItem();
                listPack.Value = dsAllActivePackages.Tables[0].Rows[RowNo]["PackageID"].ToString();
                listPack.Text = PackName2 + "($" + PackAmount2 + ")";
                ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(listPack);
            }
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
            DataSet dsAllStates = new DataSet();
            if (Session["dsAllStates"] == null)
            {
                dsAllStates = objTruckMainBL.GetAllStates();
                Session["dsAllStates"] = dsAllStates;
            }
            else
            {
                dsAllStates = Session["dsAllStates"] as DataSet;
            }
            ddlLocationState.DataSource = dsAllStates.Tables[0];
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
    private void FillYear()
    {
        try
        {
            DataSet dsAllYears = new DataSet();
            if (Session["dsAllYears"] == null)
            {
                dsAllYears = objTruckMainBL.GetYears();
                Session["dsAllYears"] = dsAllYears;
            }
            else
            {
                dsAllYears = Session["dsAllYears"] as DataSet;
            }
            ddlYear.DataSource = dsAllYears.Tables[0];
            ddlYear.DataTextField = "Year";
            ddlYear.DataValueField = "Year";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillType()
    {
        try
        {
            DataSet dsAllTypes = new DataSet();
            if (Session["dsAllTypes"] == null)
            {
                dsAllTypes = objTruckMainBL.GetAllTypes();
                Session["dsAllTypes"] = dsAllTypes;
            }
            else
            {
                dsAllTypes = Session["dsAllTypes"] as DataSet;
            }
            ddlType.DataSource = dsAllTypes.Tables[0];
            ddlType.DataTextField = "TypeName";
            ddlType.DataValueField = "TypeID";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetAllMakes()
    {
        try
        {
            DataSet dsAllMakes = new DataSet();
            if (Session["AllMakes"] == null)
            {
                dsAllMakes = objTruckMainBL.GetAllMakes(0);
                Session["AllMakes"] = dsAllMakes;
            }
            else
            {
                dsAllMakes = Session["AllMakes"] as DataSet;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetAllCategories()
    {
        try
        {
            DataSet dsAllCategories = new DataSet();
            if (Session["AllCategories"] == null)
            {
                dsAllCategories = objTruckMainBL.GetAllCategories(0);
                Session["AllCategories"] = dsAllCategories;
            }
            else
            {
                dsAllCategories = Session["AllCategories"] as DataSet;
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
            GetCategoryInfo();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetCategoryInfo()
    {
        try
        {
            DataSet dsCategory = Session["AllCategories"] as DataSet;
            int RVTYPE = Convert.ToInt32(ddlType.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsCategory.Tables[0].DefaultView;
            dvModel.RowFilter = "VehicleTypeID='" + RVTYPE.ToString() + "'";
            dtModel = dvModel.ToTable();
            ddlCategory.DataSource = dtModel;
            ddlCategory.Items.Clear();
            ddlCategory.DataTextField = "Category_Name";
            ddlCategory.DataValueField = "Category_id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Unspecified", "0"));
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
            DataSet dsMakes = Session["AllMakes"] as DataSet;
            int RVTYPE = Convert.ToInt32(ddlType.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsMakes.Tables[0].DefaultView;
            dvModel.RowFilter = "Vehicletype='" + RVTYPE.ToString() + "'";
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
            throw ex;
        }
    }

    private void FillDoors()
    {
        try
        {
            DataSet dsAllDoors = new DataSet();
            if (Session["dsAllDoors"] == null)
            {
                dsAllDoors = objTruckMainBL.GetAllDoors();
                Session["dsAllDoors"] = dsAllDoors;
            }
            else
            {
                dsAllDoors = Session["dsAllDoors"] as DataSet;
            }
            ddlDoorCount.DataSource = dsAllDoors.Tables[0];
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
    private void FillFuelTypes()
    {
        try
        {
            DataSet dsAllFuels = new DataSet();
            if (Session["dsAllFuels"] == null)
            {
                dsAllFuels = objTruckMainBL.GetFuelTypes();
                Session["dsAllFuels"] = dsAllFuels;
            }
            else
            {
                dsAllFuels = Session["dsAllFuels"] as DataSet;
            }
            ddlFuelType.DataSource = dsAllFuels.Tables[0];
            ddlFuelType.DataTextField = "FuelType";
            ddlFuelType.DataValueField = "FuelTypeID";
            ddlFuelType.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillCondition()
    {
        try
        {
            DataSet dsAllConditions = new DataSet();
            if (Session["dsAllConditions"] == null)
            {
                dsAllConditions = objTruckMainBL.GetConditions();
                Session["dsAllConditions"] = dsAllConditions;
            }
            else
            {
                dsAllConditions = Session["dsAllConditions"] as DataSet;
            }
            ddlCondition.DataSource = dsAllConditions.Tables[0];
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
    private void FillInteriorColor()
    {
        try
        {
            DataSet dsAllInteriorColors = new DataSet();
            if (Session["dsAllInteriorColors"] == null)
            {
                dsAllInteriorColors = objTruckMainBL.GetInteriorColors();
                Session["dsAllInteriorColors"] = dsAllInteriorColors;
            }
            else
            {
                dsAllInteriorColors = Session["dsAllInteriorColors"] as DataSet;
            }
            ddlInteriorColor.DataSource = dsAllInteriorColors.Tables[0];
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
            DataSet dsAllExteriorColors = new DataSet();
            if (Session["dsAllExteriorColors"] == null)
            {
                dsAllExteriorColors = objTruckMainBL.GetExteriorColors();
                Session["dsAllExteriorColors"] = dsAllExteriorColors;
            }
            else
            {
                dsAllExteriorColors = Session["dsAllExteriorColors"] as DataSet;
            }
            ddlExteriorColor.DataSource = dsAllExteriorColors.Tables[0];
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
    private void FillEngineManufacturer()
    {
        try
        {
            DataSet dsAllEngineManufacturer = new DataSet();
            if (Session["dsAllEngineManufacturer"] == null)
            {
                dsAllEngineManufacturer = objTruckMainBL.GetEngineManufacturer();
                Session["dsAllEngineManufacturer"] = dsAllEngineManufacturer;
            }
            else
            {
                dsAllEngineManufacturer = Session["dsAllEngineManufacturer"] as DataSet;
            }
            ddlEngineManufacturer.DataSource = dsAllEngineManufacturer.Tables[0];
            ddlEngineManufacturer.DataTextField = "EngineType";
            ddlEngineManufacturer.DataValueField = "EngineTypeID";
            ddlEngineManufacturer.DataBind();
            ddlEngineManufacturer.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillTransmissions()
    {
        try
        {
            DataSet dsAllTransmission = new DataSet();
            if (Session["dsAllTransmission"] == null)
            {
                dsAllTransmission = objTruckMainBL.GetTransmission();
                Session["dsAllTransmission"] = dsAllTransmission;
            }
            else
            {
                dsAllTransmission = Session["dsAllTransmission"] as DataSet;
            }
            ddlTransmission.DataSource = dsAllTransmission.Tables[0];
            ddlTransmission.DataTextField = "TransmissionName";
            ddlTransmission.DataValueField = "TransmissionID";
            ddlTransmission.DataBind();
            ddlTransmission.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillSuspension()
    {
        try
        {
            DataSet dsAllSuspension = new DataSet();
            if (Session["dsAllSuspension"] == null)
            {
                dsAllSuspension = objTruckMainBL.GetSuspension();
                Session["dsAllSuspension"] = dsAllSuspension;
            }
            else
            {
                dsAllSuspension = Session["dsAllSuspension"] as DataSet;
            }
            ddlSuspension.DataSource = dsAllSuspension.Tables[0];
            ddlSuspension.DataTextField = "Suspension";
            ddlSuspension.DataValueField = "SuspensionID";
            ddlSuspension.DataBind();
            ddlSuspension.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillHorsepower()
    {
        try
        {
            DataSet dsAllHorsepower = new DataSet();
            if (Session["dsAllHorsepower"] == null)
            {
                dsAllHorsepower = objTruckMainBL.GetHorsepower();
                Session["dsAllHorsepower"] = dsAllHorsepower;
            }
            else
            {
                dsAllHorsepower = Session["dsAllHorsepower"] as DataSet;
            }
            ddlHorsePower.DataSource = dsAllHorsepower.Tables[0];
            ddlHorsePower.DataTextField = "HorsePower";
            ddlHorsePower.DataValueField = "HorsePowerID";
            ddlHorsePower.DataBind();
            ddlHorsePower.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {

            objUserRegInfo.Name = GeneralFunc.ToProper(txtContcname.Text).Trim();
            objUserRegInfo.UserName = txtemail.Text;
            objUserRegInfo.Pwd = txtPassword.Text;
            objUserRegInfo.PhoneNumber = txtphone.Text;
            objUserRegInfo.CouponCode = txtCoupon.Text;
            objUserRegInfo.ReferCode = txtRefferedBy.Text;
            objUserRegInfo.Address = GeneralFunc.ToProper(txtRegAddress.Text).Trim();
            objUserRegInfo.City = GeneralFunc.ToProper(txtRegCity.Text).Trim();
            objUserRegInfo.StateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
            objUserRegInfo.IsActive = 1;
            if (txtRegZip.Text.Length == 4)
            {
                objUserRegInfo.Zip = "0" + txtRegZip.Text;
            }
            else
            {
                objUserRegInfo.Zip = txtRegZip.Text;
            }

            objUserRegInfo.PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value.ToString());

            DataSet dsUserExists = objUserregBL.USP_ChkUserExists(txtemail.Text);
            if (dsUserExists.Tables.Count > 0)
            {
                if (dsUserExists.Tables[0].Rows.Count > 0)
                {
                    mdepAlertExists.Show();
                    lblErrorExists.Visible = true;
                    lblErrorExists.Text = "Email " + txtemail.Text + " already exists";
                }
                else
                {
                    objcarsInfo.YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Text);
                    Session["SelYear"] = ddlYear.SelectedItem.Text;
                    Session["SelType"] = ddlType.SelectedItem.Text;
                    Session["SelCategory"] = ddlCategory.SelectedItem.Text;
                    Session["SelMake"] = ddlMake.SelectedItem.Text;
                    objcarsInfo.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                    objcarsInfo.MakeID = Convert.ToInt32(ddlMake.SelectedItem.Value);
                    objcarsInfo.Model = GeneralFunc.ToProper(txtModel.Text);
                    objcarsInfo.CarID = Convert.ToInt32(0);
                    if (txtAskingPrice.Text == "")
                    {
                        objcarsInfo.Price = "0";
                    }
                    else
                    {
                        objcarsInfo.Price = txtAskingPrice.Text;
                    }
                    if (txtMileage.Text == "")
                    {
                        objcarsInfo.Mileage = "0";
                    }
                    else
                    {
                        objcarsInfo.Mileage = txtMileage.Text;
                    }
                    objcarsInfo.Title = txtTitle.Text;

                    objcarsInfo.ExteriorColor = ddlExteriorColor.SelectedItem.Text;
                    objcarsInfo.InteriorColor = ddlInteriorColor.SelectedItem.Text;
                    objcarsInfo.NumberOfDoors = ddlDoorCount.SelectedItem.Text;
                    objcarsInfo.ConditionDescription = ddlCondition.SelectedItem.Text;
                    objcarsInfo.VIN = txtVin.Text;
                    objcarsInfo.FuelTypeID = Convert.ToInt32(ddlFuelType.SelectedItem.Value);
                    string Condition = string.Empty;
                    string CondiDescrip = string.Empty;
                    objcarsInfo.Description = GeneralFunc.ToProper(txtCondition.Text);
                    objcarsInfo.EngineManufacturer = txtEngineModel.Text;
                    objcarsInfo.EngineType = Convert.ToInt32(ddlEngineManufacturer.SelectedItem.Value);
                    objcarsInfo.VehicleConditionID = ddlCondition.SelectedItem.Value.ToString();
                    objcarsInfo.Transmission = Convert.ToInt32(ddlTransmission.SelectedItem.Value);
                    objcarsInfo.TransmissionMake = txtTransmissionMake.Text;
                    objcarsInfo.Suspensionid = Convert.ToInt32(ddlSuspension.SelectedItem.Value);
                    objcarsInfo.HorsePower = Convert.ToInt32(ddlHorsePower.SelectedItem.Value);
                    objcarsInfo.Rear = txtRear.Text;
                    objcarsInfo.Axle = txtAxles.Text;
                    int Isactive;
                    int CarIDs;
                    int FeatureID;
                    string StateName;
                    StateName = ddlLocationState.SelectedItem.Text.ToString();
                    objUsedCarsInfo.SellerID = Convert.ToInt32(0);
                    objUsedCarsInfo.State = ddlLocationState.SelectedItem.Text.ToString();
                    int PackageID;

                    String strHostName = Request.UserHostAddress.ToString();
                    string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

                    DataSet dsTotalData = objTruckMainBL.SaveTruckRegisterData(objUserRegInfo, objcarsInfo, StateName, strIp);
                    Session["CarID"] = dsTotalData.Tables[0].Rows[0]["CarID"].ToString();
                    Session["PackageID"] = Convert.ToInt32(ddlPackage.SelectedItem.Value.ToString());
                    Session[Constants.SellerID] = dsTotalData.Tables[0].Rows[0]["SellerID"].ToString();
                    Session["RegUSER_ID"] = Convert.ToInt32(dsTotalData.Tables[0].Rows[0]["UId"].ToString());
                    Session["RegUserName"] = txtemail.Text;
                    Session["RegName"] = GeneralFunc.ToProper(txtContcname.Text).Trim();
                    Session["RegPassword"] = txtPassword.Text;
                    Session["RegUserPackID"] = dsTotalData.Tables[0].Rows[0]["UserPackID"].ToString();
                    Session["PostingID"] = dsTotalData.Tables[0].Rows[0]["PostingID"].ToString();
                    DataSet dsCarFeature = new DataSet();
                    CarIDs = Convert.ToInt32(Session["CarID"].ToString());
                    for (int i = 0; i < chklstIneriorOptions.Items.Count; i++)
                    {

                        if (chklstIneriorOptions.Items[i].Selected == true)
                        {
                            Isactive = 1;
                        }
                        else
                        {
                            Isactive = 0;
                        }
                        FeatureID = Convert.ToInt32(chklstIneriorOptions.Items[i].Value);
                        dsCarFeature = objTruckMainBL.SaveCarFeatures(CarIDs, FeatureID, Isactive);
                        Session["CarID"] = Convert.ToInt32(dsCarFeature.Tables[0].Rows[0]["CarID"].ToString());
                    }
                    for (int i = 0; i < chklstExteriorOptions.Items.Count; i++)
                    {

                        if (chklstExteriorOptions.Items[i].Selected == true)
                        {
                            Isactive = 1;
                        }
                        else
                        {
                            Isactive = 0;
                        }
                        FeatureID = Convert.ToInt32(chklstExteriorOptions.Items[i].Value);
                        dsCarFeature = objTruckMainBL.SaveCarFeatures(CarIDs, FeatureID, Isactive);
                        Session["CarID"] = Convert.ToInt32(dsCarFeature.Tables[0].Rows[0]["CarID"].ToString());
                    }
                    for (int i = 0; i < chklstSafetyOptions.Items.Count; i++)
                    {

                        if (chklstSafetyOptions.Items[i].Selected == true)
                        {
                            Isactive = 1;
                        }
                        else
                        {
                            Isactive = 0;
                        }
                        FeatureID = Convert.ToInt32(chklstSafetyOptions.Items[i].Value);
                        dsCarFeature = objTruckMainBL.SaveCarFeatures(CarIDs, FeatureID, Isactive);
                        Session["CarID"] = Convert.ToInt32(dsCarFeature.Tables[0].Rows[0]["CarID"].ToString());
                    }

                    //GeneralFunc.CreateFile("", Session["SelYear"] + "/" + Session["SelMake"] + "-" + Session["SelModel"] + "/" + Session["CarID"].ToString());
                    //GeneralFunc.CreateFileCS("", Session["SelYear"] + "/" + Session["SelMake"] + "-" + Session["SelModel"] + "/" + Session["CarID"].ToString());

                    Response.Redirect("RegisterPlaceAdPhotos.aspx");

                    //for (int i = 1; i < 52; i++)
                    //{
                    //    if (Session["CarID"] == null)
                    //    {
                    //        CarIDs = 0;
                    //    }
                    //    else
                    //    {
                    //        CarIDs = Convert.ToInt32(Session["CarID"].ToString());
                    //    }
                    //    string ChkBoxID = "chkFeatures" + i.ToString();
                    //    CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                    //    if (ChkedBox.Checked == true)
                    //    {
                    //        Isactive = 1;
                    //    }
                    //    else
                    //    {
                    //        Isactive = 0;
                    //    }
                    //    FeatureID = i;
                    //    dsCarFeature = objdropdownBL.USP_SaveCarFeatures(CarIDs, FeatureID, Isactive, UID);

                    //}
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
