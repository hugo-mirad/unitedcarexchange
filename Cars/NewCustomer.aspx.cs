
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


public partial class NewCustomer : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSaleAgents = new DataSet();
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

                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                dsActiveSaleAgents = objCentralDBBL.GetSmartzSalesAgentsActiveData();
                Session["ActiveSalesAgents"] = dsActiveSaleAgents;

                FillSaleDate();
                FillSaleAgents();
                FillVerifier();
                FillPaymentDate();
                FillPDDate();
                GetAllModels();
                GetMakes();
                FillYear();
                FillPackage();
                GetModelsInfo();
                FillStates();
                FillExteriorColor();
                FillInteriorColor();
                GetBody();
                FillCylinders();
                FillCondition();
                FillFuelTypes();
                FillDoors();
                FillTransmissions();
                FillDriveTrain();
                FillPayType();
                FillRegStates();
                Session.Timeout = 180;
            }
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
            ddlSalesAgent.DataSource = dsActiveSaleAgents.Tables[0];
            ddlSalesAgent.DataTextField = "American_Name";
            ddlSalesAgent.DataValueField = "Sale_Agent_Id";
            ddlSalesAgent.DataBind();
            ddlSalesAgent.Items.Insert(0, new ListItem("Unknown", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillPDDate()
    {
        try
        {
            for (int i = 0; i < 21; i++)
            {
                ListItem list = new ListItem();
                list.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(i).ToString("MM/dd/yyyy");
                list.Value = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(i).ToString("MM/dd/yyyy");
                ddlPDDate.Items.Add(list);
            }
            ddlPDDate.Items.Insert(0, new ListItem("Select", "0"));
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
    private void FillSaleDate()
    {
        try
        {
            for (int i = 0; i < 7; i++)
            {
                ListItem list = new ListItem();
                list.Text = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
                list.Value = System.DateTime.Now.ToUniversalTime().AddHours(-4).AddDays(-i).ToString("MM/dd/yyyy");
                ddlSaleDate.Items.Add(list);
            }
            ddlSaleDate.Items.Insert(0, new ListItem("Select", "0"));
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
            ddlLocationState.DataValueField = "State_ID";
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
            ddlMake.Items.Insert(0, new ListItem("Unspecified", "0"));
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
            for (int i = 0; i < dsDropDown.Tables[2].Rows.Count; i++)
            {
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsDropDown.Tables[2].Rows[i]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = dsDropDown.Tables[2].Rows[i]["Description"].ToString();
                ListItem list = new ListItem();
                list.Text = PackName + "($" + PackAmount + ")";
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


    protected void btnSendregMail_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string RegName = objGeneralFunc.ToProper(txtRegName.Text).Trim();
            string RegUserName = txtLoginEmail.Text;
            string Password = txtLoginPassword.Text;
            string RegPhone = txtRegPhNo.Text;
            string CouponCode = "";
            string ReferCode = "";
            string RegAddress = objGeneralFunc.ToProper(txtRegAddress.Text).Trim();
            string RegCity = objGeneralFunc.ToProper(txtRegCity.Text).Trim();
            int RegState = Convert.ToInt32(ddlRegState.SelectedItem.Value);
            string RegZip = string.Empty;
            string BusinessName = txtRegBusinessName.Text;
            string AltEmail = txtRegAltEmail.Text;
            string RegAltPhone = txtRegAltPhoneNum.Text;
            int SalesAgentID = Convert.ToInt32(ddlSalesAgent.SelectedItem.Value);
            int VerifierID = Convert.ToInt32(ddlVerifier.SelectedItem.Value);
            //if (txtregZip.Text.Length == 4)
            //{
            //    RegZip = "0" + txtregZip.Text;
            //}
            //else
            //{
            RegZip = txtregZip.Text;
            //}
            string UserID;
            string FistName = RegName;
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
            UserID = FistName + RegPhone;
            int EmailExists = 1;
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value);
            DataSet dsPhoneExists = objdropdownBL.ChkUserExistsPhoneNumber(RegPhone);
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
                    if (chkbxEMailNA.Checked == false)
                    {
                        EmailExists = 1;
                        DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(txtLoginEmail.Text);
                        if (dsUserExists.Tables.Count > 0)
                        {
                            if (dsUserExists.Tables[0].Rows.Count > 0)
                            {
                                Session.Timeout = 180;
                                mdepAlertExists.Show();
                                lblErrorExists.Visible = true;
                                lblErrorExists.Text = "Email " + RegUserName + " already exists";
                            }
                            else
                            {
                                DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                                if (dsUserIDExists.Tables.Count > 0)
                                {
                                    if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                    {
                                        UserID = UserID + s.ToString();
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                                    }
                                    else
                                    {
                                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                                    }
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
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
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                                }
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                            }
                        }
                    }
                    else
                    {
                        EmailExists = 0;
                        DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                        if (dsUserIDExists.Tables.Count > 0)
                        {
                            if (dsUserIDExists.Tables[0].Rows.Count > 0)
                            {
                                UserID = UserID + s.ToString();
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                            }
                        }
                        else
                        {
                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                        }
                    }
                }
            }
            else
            {
                if (chkbxEMailNA.Checked == false)
                {
                    EmailExists = 1;
                    DataSet dsUserExists = objdropdownBL.USP_ChkUserExists(txtLoginEmail.Text);
                    if (dsUserExists.Tables.Count > 0)
                    {
                        if (dsUserExists.Tables[0].Rows.Count > 0)
                        {
                            Session.Timeout = 180;
                            mdepAlertExists.Show();
                            lblErrorExists.Visible = true;
                            lblErrorExists.Text = "Email " + RegUserName + " already exists";
                        }
                        else
                        {
                            DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                            if (dsUserIDExists.Tables.Count > 0)
                            {
                                if (dsUserIDExists.Tables[0].Rows.Count > 0)
                                {
                                    UserID = UserID + s.ToString();
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                                }
                                else
                                {
                                    SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                                }
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
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
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                            }
                            else
                            {
                                SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                            }
                        }
                        else
                        {
                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                        }
                    }
                }
                else
                {
                    EmailExists = 0;
                    DataSet dsUserIDExists = objdropdownBL.ChkUserExistsUserID(UserID);
                    if (dsUserIDExists.Tables.Count > 0)
                    {
                        if (dsUserIDExists.Tables[0].Rows.Count > 0)
                        {
                            UserID = UserID + s.ToString();
                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                        }
                        else
                        {
                            SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                        }
                    }
                    else
                    {
                        SaveRegDetails(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SaveRegDetails(string RegName, string RegUserName, string Password, string RegPhone, string CouponCode, string ReferCode, int PackageID, int RegState, string RegCity, string RegAddress, string RegZip, string BusinessName, string AltEmail, string RegAltPhone, int SalesAgentID, int VerifierID, int EmailExists, string UserID)
    {
        try
        {
            DataSet dsUserInfo = objdropdownBL.Usp_SmartzSave_RegisterLogUser(RegName, RegUserName, Password, RegPhone, CouponCode, ReferCode, PackageID, RegState, RegCity, RegAddress, RegZip, BusinessName, AltEmail, RegAltPhone, SalesAgentID, VerifierID, EmailExists, UserID);
            Session["RegUSER_ID"] = Convert.ToInt32(dsUserInfo.Tables[0].Rows[0]["UId"].ToString());
            Session["RegUserName"] = dsUserInfo.Tables[0].Rows[0]["UserName"].ToString();
            Session["RegName"] = dsUserInfo.Tables[0].Rows[0]["Name"].ToString();
            Session["RegPhoneNumber"] = dsUserInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
            Session["PackageID"] = dsUserInfo.Tables[0].Rows[0]["PackageID"].ToString();
            Session["RegPassword"] = dsUserInfo.Tables[0].Rows[0]["Pwd"].ToString();
            Session["RegUserPackID"] = dsUserInfo.Tables[0].Rows[0]["UserPackID"].ToString();
            Session["RegEmailExists"] = dsUserInfo.Tables[0].Rows[0]["EmailExists"].ToString();
            Session["RegUserLoginID"] = dsUserInfo.Tables[0].Rows[0]["UserID"].ToString();
            SaveData();
            //ResendRegMail();
            Session.Timeout = 180;
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = "Customer details saved successfully with carid " + Session["CarID"].ToString();
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
            string Transmission = ddlTransmission.SelectedItem.Text;
            string NumberOfDoors = ddlDoorCount.SelectedItem.Value;
            string DriveTrain = ddlDriveTrain.SelectedItem.Value;
            string VIN = txtVinNumber.Text;
            string NumberOfCylinder = ddlCylinderCount.SelectedItem.Value;
            int FuelTypeID = Convert.ToInt32(ddlFuelType.SelectedItem.Value);
            int ConditionID = Convert.ToInt32(ddlCondition.SelectedItem.Value);
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
            string Condition = string.Empty;
            string Description = string.Empty;
            Description = txtDescription.Text;
            Condition = ddlCondition.SelectedItem.Text;
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
            string Title = txtTitle.Text;
            DataSet dsCarsDetails = objdropdownBL.USP_SmartzSaveCarDetails(YearOfMake, MakeModelID, BodyTypeID, ConditionID, Price, Mileage, ExteriorColor, Transmission, InteriorColor, NumberOfDoors, VIN, NumberOfCylinder, FuelTypeID, SellerZip, SellCity, SellStateID, DriveTrain, Description, Condition, InternalNotesNew, Title);
            Session["CarID"] = Convert.ToInt32(dsCarsDetails.Tables[0].Rows[0]["CarID"].ToString());
            Session["UniqueID"] = dsCarsDetails.Tables[0].Rows[0]["CarUniqueID"].ToString();
            CarID = Convert.ToInt32(Session["CarID"].ToString());
            int RegUID = Convert.ToInt32(Session["RegUSER_ID"].ToString());
            int FeatureID;
            int IsactiveFea;
            string SellerName = "";
            string Address1 = "";
            string CustPhone = txtCustPhoneNumber.Text;
            string AltCustPhone = txtCustAltNumber.Text;
            string CustState = ddlLocationState.SelectedItem.Text;
            string CustEmail = txtSellerEmail.Text;
            DateTime SaleDate = Convert.ToDateTime(ddlSaleDate.SelectedItem.Text);
            int SaleEnteredBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet dsPosting = new DataSet();
            Session["CarSellerZip"] = SellerZip;
            dsPosting = objdropdownBL.USP_SmartzSaveSellerInfo(SellerName, Address1, SellCity, CustState, SellerZip, CustPhone, AltCustPhone, CustEmail, CarID, RegUID, PackageID, SaleDate, SaleEnteredBy, strIp);
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
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            int PmntStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
            Session["NewUserPayStatus"] = PmntStatus;
            Session["NewUserPDDate"] = 0;
            int PmntType;
            string TransactionID;
            int AdActive;
            int UceStatus;
            int MultisiteStatus;
            string PayAmount;
            int ListingStatus;
            DateTime PDDate;
            int UserPackID = Convert.ToInt32(Session["RegUserPackID"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            string VoiceFileName = txtVoiceFileName.Text;
            if (PmntStatus == 1)
            {
                PmntType = 0;
                TransactionID = "";
                AdActive = 0;
                UceStatus = 0;
                MultisiteStatus = 0;
                PayAmount = "";
            }
            else
            {
                if (PmntStatus == 5)
                {
                    PmntType = Convert.ToInt32(ddlPayMethod.SelectedItem.Value);

                    TransactionID = "";
                    AdActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
                    PayAmount = txtPayAmount.Text;
                }
                else
                {
                    PmntType = Convert.ToInt32(ddlPayMethod.SelectedItem.Value);
                    TransactionID = txtPayConfirmNum.Text;
                    AdActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
                    PayAmount = txtPayAmount.Text;
                }
            }
            if (AdActive == 0)
            {
                UceStatus = 0;
                MultisiteStatus = 0;
                ListingStatus = Convert.ToInt32(ddlListingStatus.SelectedItem.Value);
            }
            else
            {
                ListingStatus = 1;
                UceStatus = Convert.ToInt32(ddlUceStatus.SelectedItem.Value);
                MultisiteStatus = Convert.ToInt32(ddlMultisiteStatus.SelectedItem.Value);
            }
            if (PackageID != 1)
            {
                DateTime Paymentdate;
                if (PmntStatus == 5)
                {
                    PDDate = Convert.ToDateTime(ddlPDDate.SelectedItem.Text);
                    Paymentdate = Convert.ToDateTime(PDDate);
                }
                else if (PmntStatus == 1)
                {
                    Paymentdate = Convert.ToDateTime(ddlSaleDate.SelectedItem.Text);
                    PDDate = Convert.ToDateTime(Paymentdate);
                }
                else
                {
                    Paymentdate = Convert.ToDateTime(ddlPaymentDate.SelectedItem.Text);
                    PDDate = Convert.ToDateTime(Paymentdate);
                }
                Session["NewUserPDDate"] = PDDate;
                bool bnewPay = objdropdownBL.USP_SmartzSavePmntDetails(PmntType, PmntStatus, TransactionID, strIp, RegUID, AdActive, PayAmount, Paymentdate, ListingStatus, PDDate, UserPackID, PostingID, VoiceFileName, UceStatus, MultisiteStatus);
            }
            else
            {
                bool bnewPay = objdropdownBL.USP_SmartzSavePmntDetailsForFreePackage(RegUID, AdActive, ListingStatus, UserPackID, PostingID, UceStatus, MultisiteStatus);
            }

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
            if (Session["RegEmailExists"].ToString() == "1")
            {
                ResendRegMail();
            }
            if (Session["CarSellerZip"].ToString() != "")
            {
                string SellerZip = Session["CarSellerZip"].ToString();
                DataSet dsZipExists = objdropdownBL.SmartzCheckZipExists(SellerZip);
                if (dsZipExists.Tables[0].Rows[0]["Result"].ToString() == "Yes")
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    int CarID = Convert.ToInt32(Session["CarID"].ToString());
                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                    int CallType = Convert.ToInt32(8);
                    int CallReason = Convert.ToInt32(4);
                    int CallResolution = Convert.ToInt32(8);
                    string SpokeWith = "Internal Ticket";
                    string Notes = "Internal ticket for zip " + SellerZip.ToString() + " is not exists";
                    int TicketType = Convert.ToInt32(3);
                    int Priority = Convert.ToInt32(2);
                    int CallBackID = Convert.ToInt32(1);
                    string TicketDescription = "Internal ticket for zip " + SellerZip.ToString() + " is not exists";
                    bool bnew = objdropdownBL.USP_SmartzSaveCSandTicketDetails(CarID, UID, CallType, CallReason, Notes, TicketType, Priority, CallBackID, TicketDescription, CallResolution, SpokeWith);
                    if (bnew == true)
                    {
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("Index.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
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
            ResendRegMail();
            if (Session["CarSellerZip"].ToString() != "")
            {
                string SellerZip = Session["CarSellerZip"].ToString();
                DataSet dsZipExists = objdropdownBL.SmartzCheckZipExists(SellerZip);
                if (dsZipExists.Tables[0].Rows[0]["Result"].ToString() == "Yes")
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    int CarID = Convert.ToInt32(Session["CarID"].ToString());
                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                    int CallType = Convert.ToInt32(8);
                    int CallReason = Convert.ToInt32(4);
                    int CallResolution = Convert.ToInt32(8);
                    string SpokeWith = "Internal Ticket";
                    string Notes = "Internal ticket for zip " + SellerZip.ToString() + " is not exists";
                    int TicketType = Convert.ToInt32(3);
                    int Priority = Convert.ToInt32(2);
                    int CallBackID = Convert.ToInt32(1);
                    string TicketDescription = "Internal ticket for zip " + SellerZip.ToString() + " is not exists";
                    bool bnew = objdropdownBL.USP_SmartzSaveCSandTicketDetails(CarID, UID, CallType, CallReason, Notes, TicketType, Priority, CallBackID, TicketDescription, CallResolution, SpokeWith);
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
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
            Response.Redirect("CustomerView.aspx");
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
            Response.Redirect("NewCustomer.aspx");
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
            string UserEmail = Session["RegUserName"].ToString();
            string LoginName = Session["RegUserLoginID"].ToString();
            string UserDisName = Session["RegName"].ToString();

            string Year = Session["SelYear"].ToString();
            string Model = Session["SelModel"].ToString();
            string Make = Session["SelMake"].ToString();
            string UniqueID = Session["UniqueID"].ToString();
            Make = Make.Replace(" ", "%20");
            Model = Model.Replace(" ", "%20");
            Model = Model.Replace("&", "@");
            string Link = "http://unitedcarexchange.com/Buy-Sell-UsedCar/" + Year + "-" + Make + "-" + Model + "-" + UniqueID;
            string TermsLink = "http://unitedcarexchange.com/TermsandConditions.aspx";
            clsMailFormats format = new clsMailFormats();
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("info@unitedcarexchange.com");
            msg.To.Add(UserEmail);
            if (txtEmailTo.Text != "")
            {
                msg.CC.Add(txtEmailTo.Text);
            }
            msg.Bcc.Add("archive@unitedcarexchange.com");
            msg.Subject = "Registration Details From United Car Exchange For Car ID# " + Session["CarID"].ToString();
            msg.IsBodyHtml = true;
            string text = string.Empty;
            if (Session["NewUserPayStatus"].ToString() == "5")
            {
                DateTime PostDate = Convert.ToDateTime(Session["NewUserPDDate"].ToString());
                PDDate = PostDate.ToString("MM/dd/yyyy");


                text = format.SendRegistrationdetailsForPDSales(LoginName, LoginPassword, UserDisName, ref text, PDDate,1);
            }
            else
            {
                text = format.SendRegistrationdetails(LoginName, LoginPassword, UserDisName, ref text, Link, TermsLink,1);
            }
            msg.Body = text.ToString();
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
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
    protected void ddlPayStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int PayStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
            if (PayStatus == 1)
            {
                ////trPayMethod.Style["display"] = "none";
                ////trPayDate.Style["display"] = "none";
                ////trPayConfirm.Style["display"] = "none";
                ////trPayAmount.Style["display"] = "none";
                ////trAdStatus.Style["display"] = "none";

                tblPaymentDetails.Style["display"] = "none";
                trListingStatus.Style["display"] = "none";
                trUceStatus.Style["display"] = "none";
            }
            else
            {
                //trPayMethod.Style["display"] = "block";
                //trPayDate.Style["display"] = "block";
                //trPayConfirm.Style["display"] = "block";
                //trPayAmount.Style["display"] = "block";
                //trAdStatus.Style["display"] = "block";
                tblPaymentDetails.Style["display"] = "block";
                if (PayStatus == 5)
                {
                    trPDDate.Style["display"] = "block";
                    trPayDate.Style["display"] = "none";
                    trPayConfirm.Style["display"] = "none";
                    tblVoiceFile.Style["display"] = "none";
                }
                else
                {
                    trPDDate.Style["display"] = "none";
                    trPayDate.Style["display"] = "block";
                    trPayConfirm.Style["display"] = "block";
                    tblVoiceFile.Style["display"] = "block";
                }
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
                //trMultisiteStatus.Style["display"] = "block";
            }
            else
            {
                trListingStatus.Style["display"] = "block";
                trUceStatus.Style["display"] = "none";
                //trMultisiteStatus.Style["display"] = "none";
                //int PmntStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
                //if (PmntStatus == 5)
                //{
                //    ddlListingStatus.Items.Clear();
                //    ListItem liWithPremili = new ListItem();
                //    liWithPremili.Value = "2";
                //    liWithPremili.Text = "Preliminary";
                //    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                //    ddlListingStatus.Items.Add(liWithPremili);
                //}
                //else
                //{
                //    ddlListingStatus.Items.Clear();
                //    ListItem liWithPremili = new ListItem();
                //    liWithPremili.Value = "2";
                //    liWithPremili.Text = "Preliminary";
                //    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                //    ddlListingStatus.Items.Add(liWithPremili);
                //    ListItem liWithDraw = new ListItem();
                //    liWithDraw.Value = "3";
                //    liWithDraw.Text = "Withdraw";
                //    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                //    ddlListingStatus.Items.Add(liWithDraw);
                //    ListItem liSold = new ListItem();
                //    liSold.Value = "4";
                //    liSold.Text = "Sold";
                //    //ddlPayStatus.SelectedIndex = ddlPayStatus.Items.IndexOf(liPayStatusPend);
                //    ddlListingStatus.Items.Add(liSold);
                //}
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
