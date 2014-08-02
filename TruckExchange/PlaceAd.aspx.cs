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

public partial class PlaceAd : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();
    UsedCarsInfo objUsedCarsInfo = new UsedCarsInfo();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    TruckMainBL objTruckMainBL = new TruckMainBL();
    SellerInfo objSellerInfo = new SellerInfo();
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
                Session["CurrentPage"] = "Home";
                Session["PageName"] = "";
                Session["CurrentPageConfig"] = null;


                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScript.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);

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



                if ((Session["PostingID"] != null) && (Session["PostingID"].ToString() != ""))
                {
                    //btnUpdatePackage.Visible = true;
                    DataSet dsCarDetailsInfo = new DataSet();
                    dsCarDetailsInfo = objdropdownBL.USP_GetCustomerDetailsByPostingID(Convert.ToInt32(Session["PostingID"].ToString()));
                    if (dsCarDetailsInfo.Tables[0].Rows.Count > 0)
                    {
                        Session["CarID"] = dsCarDetailsInfo.Tables[0].Rows[0]["carid"].ToString();
                        Session["PackageID"] = dsCarDetailsInfo.Tables[0].Rows[0]["packageID"].ToString();
                        Session["PaymentID"] = dsCarDetailsInfo.Tables[0].Rows[0]["PaymentID"].ToString();
                        Session["UserPackID"] = dsCarDetailsInfo.Tables[0].Rows[0]["UserPackID"].ToString();
                        Session["SellerID"] = dsCarDetailsInfo.Tables[0].Rows[0]["SellerID"].ToString();

                        if (dsCarDetailsInfo.Tables[0].Rows[0]["IsActive"].ToString() == "True")
                        {
                            btnSold.Visible = true;
                            btnWithdraw.Visible = true;
                            btnActive.Visible = false;
                        }
                        else
                        {
                            btnSold.Visible = false;
                            btnWithdraw.Visible = false;
                            btnActive.Visible = true;
                        }


                        FillPackage();

                        ListItem list1 = new ListItem();
                        list1.Text = dsCarDetailsInfo.Tables[0].Rows[0]["yearOfMake"].ToString();
                        list1.Value = dsCarDetailsInfo.Tables[0].Rows[0]["yearOfMake"].ToString();
                        ddlYear.SelectedIndex = ddlYear.Items.IndexOf(list1);

                        ListItem list3 = new ListItem();
                        list3.Text = dsCarDetailsInfo.Tables[0].Rows[0]["TypeName"].ToString();
                        list3.Value = dsCarDetailsInfo.Tables[0].Rows[0]["VehicleTypeID"].ToString();
                        ddlType.SelectedIndex = ddlType.Items.IndexOf(list3);

                        GetModelsInfo();
                        GetCategoryInfo();

                        ListItem list2 = new ListItem();
                        list2.Value = dsCarDetailsInfo.Tables[0].Rows[0]["MakeID"].ToString();
                        list2.Text = dsCarDetailsInfo.Tables[0].Rows[0]["make"].ToString();
                        ddlMake.SelectedIndex = ddlMake.Items.IndexOf(list2);

                        ListItem listCat = new ListItem();
                        listCat.Value = dsCarDetailsInfo.Tables[0].Rows[0]["CategoryID"].ToString();
                        listCat.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Category_Name"].ToString();
                        ddlCategory.SelectedIndex = ddlCategory.Items.IndexOf(listCat);

                        txtModel.Text = dsCarDetailsInfo.Tables[0].Rows[0]["model"].ToString();

                        ListItem list5 = new ListItem();
                        list5.Value = dsCarDetailsInfo.Tables[0].Rows[0]["State_Id"].ToString();
                        list5.Text = dsCarDetailsInfo.Tables[0].Rows[0]["State"].ToString();
                        ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(list5);

                        ListItem list6 = new ListItem();
                        list6.Value = dsCarDetailsInfo.Tables[0].Rows[0]["fuelTypeID"].ToString();
                        list6.Text = dsCarDetailsInfo.Tables[0].Rows[0]["fuelType"].ToString();
                        ddlFuelType.SelectedIndex = ddlFuelType.Items.IndexOf(list6);

                        ListItem list7 = new ListItem();
                        list7.Value = dsCarDetailsInfo.Tables[0].Rows[0]["exteriorColor"].ToString();
                        list7.Text = dsCarDetailsInfo.Tables[0].Rows[0]["exteriorColor"].ToString();
                        ddlExteriorColor.SelectedIndex = ddlExteriorColor.Items.IndexOf(list7);


                        ListItem list8 = new ListItem();
                        list8.Text = dsCarDetailsInfo.Tables[0].Rows[0]["interiorColor"].ToString();
                        list8.Value = dsCarDetailsInfo.Tables[0].Rows[0]["interiorColor"].ToString();
                        ddlInteriorColor.SelectedIndex = ddlInteriorColor.Items.IndexOf(list8);

                        ListItem list9 = new ListItem();
                        list9.Value = dsCarDetailsInfo.Tables[0].Rows[0]["EngineType"].ToString();
                        list9.Text = dsCarDetailsInfo.Tables[0].Rows[0]["EngineTypeName"].ToString();
                        ddlEngineManufacturer.SelectedIndex = ddlEngineManufacturer.Items.IndexOf(list9);

                        txtEngineModel.Text = dsCarDetailsInfo.Tables[0].Rows[0]["EngineManufacturer"].ToString();

                        ListItem list10 = new ListItem();
                        list10.Value = dsCarDetailsInfo.Tables[0].Rows[0]["NumberOfDoors"].ToString();
                        list10.Text = dsCarDetailsInfo.Tables[0].Rows[0]["NumberOfDoors"].ToString();
                        ddlDoorCount.SelectedIndex = ddlDoorCount.Items.IndexOf(list10);

                        ListItem list11 = new ListItem();
                        list11.Value = dsCarDetailsInfo.Tables[0].Rows[0]["Transmission"].ToString();
                        list11.Text = dsCarDetailsInfo.Tables[0].Rows[0]["TransmissionName"].ToString();
                        ddlTransmission.SelectedIndex = ddlTransmission.Items.IndexOf(list11);

                        txtTransmissionMake.Text = dsCarDetailsInfo.Tables[0].Rows[0]["TransmissionMake"].ToString();


                        ListItem list13 = new ListItem();
                        list13.Value = dsCarDetailsInfo.Tables[0].Rows[0]["Suspensionid"].ToString();
                        list13.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Suspension"].ToString();
                        ddlCondition.SelectedIndex = ddlCondition.Items.IndexOf(list13);

                        txtRear.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Rear"].ToString();
                        txtAxles.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Axle"].ToString();

                        ListItem listHorse = new ListItem();
                        listHorse.Value = dsCarDetailsInfo.Tables[0].Rows[0]["HorsePower"].ToString();
                        listHorse.Text = dsCarDetailsInfo.Tables[0].Rows[0]["HorsePowerName"].ToString();
                        ddlHorsePower.SelectedIndex = ddlHorsePower.Items.IndexOf(listHorse);

                        //txtSellerName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["sellerName"].ToString();
                        //txtAddress.Text = objGeneralFunc.ToProper(dsCarDetailsInfo.Tables[0].Rows[0]["address1"].ToString());
                        txtCity.Text = GeneralFunc.ToProper(dsCarDetailsInfo.Tables[0].Rows[0]["city"].ToString());
                        txtZip.Text = dsCarDetailsInfo.Tables[0].Rows[0]["zip"].ToString();
                        txtSellerPhone.Text = dsCarDetailsInfo.Tables[0].Rows[0]["phone"].ToString();
                        txtSellerEmail.Text = dsCarDetailsInfo.Tables[0].Rows[0]["email"].ToString();




                        if (dsCarDetailsInfo.Tables[0].Rows[0]["price"].ToString() == "0.0000")
                        {
                            txtAskingPrice.Text = "";
                        }
                        else
                        {
                            txtAskingPrice.Text = string.Format("{0:0.00}", Convert.ToDouble(dsCarDetailsInfo.Tables[0].Rows[0]["price"].ToString()));
                        }
                        if (txtAskingPrice.Text.Length > 6)
                        {
                            txtAskingPrice.Text = txtAskingPrice.Text.Substring(0, 6);
                        }

                        if (dsCarDetailsInfo.Tables[0].Rows[0]["mileage"].ToString() == "0.00")
                        {
                            txtMileage.Text = "";
                        }
                        else
                        {
                            txtMileage.Text = string.Format("{0:0.00}", Convert.ToDouble(dsCarDetailsInfo.Tables[0].Rows[0]["mileage"].ToString()));
                        }
                        if (txtMileage.Text.Length > 6)
                        {
                            txtMileage.Text = txtMileage.Text.Substring(0, 6);
                        }

                        txtVin.Text = dsCarDetailsInfo.Tables[0].Rows[0]["VIN"].ToString();
                        txtCondition.Text = dsCarDetailsInfo.Tables[0].Rows[0]["description"].ToString();
                        for (int j = 0; j < dsCarDetailsInfo.Tables[3].Rows.Count; j++)
                        {
                            if (dsCarDetailsInfo.Tables[3].Rows[j]["FeatureTypeID"].ToString() == "1")
                            {
                                for (int i = 0; i < chklstIneriorOptions.Items.Count; i++)
                                {
                                    if (chklstIneriorOptions.Items[i].Value.ToString() == dsCarDetailsInfo.Tables[3].Rows[j]["FeatureID"].ToString())
                                    {
                                        if (dsCarDetailsInfo.Tables[3].Rows[j]["Isactive"].ToString() == "True")
                                        {
                                            chklstIneriorOptions.Items[i].Selected = true;
                                        }
                                        else
                                        {
                                            chklstIneriorOptions.Items[i].Selected = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (dsCarDetailsInfo.Tables[3].Rows[j]["FeatureTypeID"].ToString() == "2")
                            {
                                for (int i = 0; i < chklstExteriorOptions.Items.Count; i++)
                                {
                                    if (chklstExteriorOptions.Items[i].Value.ToString() == dsCarDetailsInfo.Tables[3].Rows[j]["FeatureID"].ToString())
                                    {
                                        if (dsCarDetailsInfo.Tables[3].Rows[j]["Isactive"].ToString() == "True")
                                        {
                                            chklstExteriorOptions.Items[i].Selected = true;
                                        }
                                        else
                                        {
                                            chklstExteriorOptions.Items[i].Selected = false;
                                        }
                                        break;
                                    }
                                }
                            }
                            if (dsCarDetailsInfo.Tables[3].Rows[j]["FeatureTypeID"].ToString() == "3")
                            {
                                for (int i = 0; i < chklstSafetyOptions.Items.Count; i++)
                                {
                                    if (chklstSafetyOptions.Items[i].Value.ToString() == dsCarDetailsInfo.Tables[3].Rows[j]["FeatureID"].ToString())
                                    {
                                        if (dsCarDetailsInfo.Tables[3].Rows[j]["Isactive"].ToString() == "True")
                                        {
                                            chklstSafetyOptions.Items[i].Selected = true;
                                        }
                                        else
                                        {
                                            chklstSafetyOptions.Items[i].Selected = false;
                                        }
                                        break;
                                    }
                                }
                            }
                        }

                        if (dsCarDetailsInfo.Tables[4].Rows.Count > 0)
                        {
                            lblExistUrlRes.Visible = false;
                            divlblMultiSite.Style["display"] = "none";
                            grdMultiSites.Visible = true;
                            grdMultiSites.DataSource = dsCarDetailsInfo.Tables[4];
                            grdMultiSites.DataBind();

                        }
                        else
                        {
                            grdMultiSites.Visible = false;
                            lblExistUrlRes.Visible = true;
                            lblExistUrlRes.Text = "Not uploaded..!";
                            divlblMultiSite.Style["display"] = "block";
                        }
                    }

                }
            }

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
            lblPackDiv.Style["display"] = "block";
            int RowNo = Convert.ToInt32(Session["PackageID"].ToString()) - 1;
            Double PackCost = new Double();
            PackCost = Convert.ToDouble(dsAllActivePackages.Tables[0].Rows[RowNo]["Price"].ToString());
            string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
            string PackName = dsAllActivePackages.Tables[0].Rows[RowNo]["Description"].ToString();
            lblPackageName.Text = PackName + "($" + PackAmount + ")";

        }
        catch (Exception ex)
        {
            throw ex;
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
    protected void btnSold_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ListStatusAd"] = 4;
            mpealteruser.Show();
            lblErr.Visible = true;
            lblErr.Text = "Are you sure do you want to make sold your listing?";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnWithdraw_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ListStatusAd"] = 3;
            mpealteruser.Show();
            lblErr.Visible = true;
            lblErr.Text = "Are you sure do you want to withdraw your listing?";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {
        try
        {
            mdepActiveAd.Show();
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
            objSellerInfo.City = GeneralFunc.ToProper(txtCity.Text).Trim();
            objSellerInfo.State = ddlLocationState.SelectedItem.Text;
            objSellerInfo.Phone = txtSellerPhone.Text;
            objSellerInfo.Email = txtSellerEmail.Text;

            if (txtZip.Text.Length == 4)
            {
                objSellerInfo.Zip = "0" + txtZip.Text;
            }
            else
            {
                objSellerInfo.Zip = txtZip.Text;
            }
            objSellerInfo.SellerID = Convert.ToInt32(Session["SellerID"].ToString());
            objcarsInfo.YearOfMake = Convert.ToInt32(ddlYear.SelectedItem.Text);
            Session["SelYear"] = ddlYear.SelectedItem.Text;
            Session["SelType"] = ddlType.SelectedItem.Text;
            Session["SelCategory"] = ddlCategory.SelectedItem.Text;
            Session["SelMake"] = ddlMake.SelectedItem.Text;
            objcarsInfo.CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
            objcarsInfo.MakeID = Convert.ToInt32(ddlMake.SelectedItem.Value);
            objcarsInfo.Model = GeneralFunc.ToProper(txtModel.Text);
            objcarsInfo.CarID = Convert.ToInt32(Session["CarID"].ToString());
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

            //if (Session["PostingID"] == null)
            //{
            //    PostingID = Convert.ToInt32(0);
            //}
            //else if (Session["PostingID"].ToString() == "")
            //{
            //    PostingID = Convert.ToInt32(0);
            //}
            //else
            //{
            //    PostingID = Convert.ToInt32(Session["PostingID"]);
            //}
            String strHostName = Request.UserHostAddress.ToString();
            string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

            bool bnew = objTruckMainBL.UpdateTruckEditData(objSellerInfo, objcarsInfo);
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
                //Session["CarID"] = Convert.ToInt32(dsCarFeature.Tables[0].Rows[0]["CarID"].ToString());
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
                //Session["CarID"] = Convert.ToInt32(dsCarFeature.Tables[0].Rows[0]["CarID"].ToString());
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
                //Session["CarID"] = Convert.ToInt32(dsCarFeature.Tables[0].Rows[0]["CarID"].ToString());
            }
            Response.Redirect("PlaceAdPhotos.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnYes_Click(object sender, EventArgs e)
    {
        try
        {
            int IsActive = 0;
            int AdStatus = Convert.ToInt32(Session["ListStatusAd"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            bool bnew = objdropdownBL.USP_UpdateListingStatus(PostingID, IsActive, AdStatus);
            Response.Redirect("account.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
