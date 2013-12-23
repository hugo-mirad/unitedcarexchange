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

public partial class AddNewCarNewForm : System.Web.UI.Page
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
                FillPayType();
                FillRegStates();
                FillPhotoSource();
                FillVoiceFileLocation();
                DataSet dsYears = objdropdownBL.USP_GetNext12years();
                fillYears(dsYears);
                FillBillingStates();
                FillDescriptionSource();
                Session.Timeout = 180;
            }
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
            //ddlPayMethod.DataSource = dsDropDown.Tables[10];
            //ddlPayMethod.DataTextField = "pmntType";
            //ddlPayMethod.DataValueField = "pmntTypeID";
            //ddlPayMethod.DataBind();
            ////ddlPayMethod.Items.Insert(0, new ListItem("Unspecified", "0"));
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
            string Transmission = "Unspecified";
            if (rdbtnTrans1.Checked == true)
            {
                Transmission = "Automatic";
            }
            else if (rdbtnTrans2.Checked == true)
            {
                Transmission = "Manual";
            }
            else if (rdbtnTrans3.Checked == true)
            {
                Transmission = "Tiptronic";
            }
            else if (rdbtnTrans4.Checked == true)
            {
                Transmission = "Unspecified";
            }
            string NumberOfDoors = string.Empty;
            if (rdbtnDoor2.Checked == true)
            {
                NumberOfDoors = "Two Door";
            }
            else if (rdbtnDoor3.Checked == true)
            {
                NumberOfDoors = "Three Door";
            }
            else if (rdbtnDoor4.Checked == true)
            {
                NumberOfDoors = "Four Door";
            }
            else if (rdbtnDoor5.Checked == true)
            {
                NumberOfDoors = "Five Door";
            }
            else
            {
                NumberOfDoors = "Unspecified";
            }
            string DriveTrain = "Unspecified";
            if (rdbtnDriveTrain1.Checked == true)
            {
                DriveTrain = "2 wheel drive";
            }
            else if (rdbtnDriveTrain2.Checked == true)
            {
                DriveTrain = "2 wheel drive - front";
            }
            else if (rdbtnDriveTrain3.Checked == true)
            {
                DriveTrain = "All wheel drive";
            }
            else if (rdbtnDriveTrain4.Checked == true)
            {
                DriveTrain = "Rear wheel drive";
            }
            else if (rdbtnDriveTrain5.Checked == true)
            {
                DriveTrain = "Unspecified";
            }


            string VIN = txtVinNumber.Text;
            string NumberOfCylinder = "Unspecified";
            if (rdbtnCylinders1.Checked == true)
            {
                NumberOfCylinder = "3 Cylinder";
            }
            else if (rdbtnCylinders2.Checked == true)
            {
                NumberOfCylinder = "4 Cylinder";
            }
            else if (rdbtnCylinders3.Checked == true)
            {
                NumberOfCylinder = "5 Cylinder";
            }
            else if (rdbtnCylinders4.Checked == true)
            {
                NumberOfCylinder = "6 Cylinder";
            }
            else if (rdbtnCylinders5.Checked == true)
            {
                NumberOfCylinder = "7 Cylinder";
            }
            else if (rdbtnCylinders6.Checked == true)
            {
                NumberOfCylinder = "8 Cylinder";
            }
            int FuelTypeID = Convert.ToInt32(0);
            if (rdbtnFuelType1.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(1);
            }
            else if (rdbtnFuelType2.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(2);
            }
            else if (rdbtnFuelType3.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(3);
            }
            else if (rdbtnFuelType4.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(4);
            }
            else if (rdbtnFuelType5.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(5);
            }
            else if (rdbtnFuelType6.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(6);
            }
            else if (rdbtnFuelType7.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(7);
            }
            else if (rdbtnFuelType8.Checked == true)
            {
                FuelTypeID = Convert.ToInt32(0);
            }

            int ConditionID = Convert.ToInt32(0);
            string Condition = "Unspecified";
            if (rdbtnCondition1.Checked == true)
            {
                ConditionID = Convert.ToInt32(1);
                Condition = "Excellent";
            }
            else if (rdbtnCondition2.Checked == true)
            {
                ConditionID = Convert.ToInt32(2);
                Condition = "Very Good";
            }
            else if (rdbtnCondition3.Checked == true)
            {
                ConditionID = Convert.ToInt32(3);
                Condition = "Good";
            }
            else if (rdbtnCondition4.Checked == true)
            {
                ConditionID = Convert.ToInt32(4);
                Condition = "Fair";
            }
            else if (rdbtnCondition5.Checked == true)
            {
                ConditionID = Convert.ToInt32(5);
                Condition = "Poor";
            }
            else if (rdbtnCondition6.Checked == true)
            {
                ConditionID = Convert.ToInt32(6);
                Condition = "Parts or Salvage";
            }
            else if (rdbtnCondition7.Checked == true)
            {
                ConditionID = Convert.ToInt32(0);
                Condition = "Unspecified";
            }

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

            string Description = string.Empty;
            Description = txtDescription.Text;
            int SourceOfPhotos = Convert.ToInt32(ddlPhotosSource.SelectedItem.Value);
            int SourceOfDescription = Convert.ToInt32(ddlDescriptionSource.SelectedItem.Value);

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

            DataSet dsCarsDetails = objdropdownBL.SmartzSaveCarDetailsForNewForm(YearOfMake, MakeModelID, BodyTypeID, ConditionID, Price, Mileage, ExteriorColor, Transmission, InteriorColor, NumberOfDoors, VIN, NumberOfCylinder, FuelTypeID, SellerZip, SellCity, SellStateID, DriveTrain, Description, Condition, InternalNotesNew, Title, SourceOfPhotos, SourceOfDescription);
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
                    }
                }
            }
            if (rdbtnLeather.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 10;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 10;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            if (rdbtnVinyl.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 37;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 37;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            if (rdbtnCloth.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 38;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 38;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }

            if (rdbtnInteriorNA.Checked == true)
            {
                IsactiveFea = 1;
                FeatureID = 54;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            else
            {
                IsactiveFea = 0;
                FeatureID = 54;
                bool dsCarFeature = objdropdownBL.USP_SmartzUpdateFeatures(CarID, FeatureID, IsactiveFea, RegUID);
            }
            int PaymentType = 0;
            string Cardtype = string.Empty;
            if (rdbtnPayVisa.Checked == true)
            {
                PaymentType = 1;
                Cardtype = "VisaCard";
            }
            else if (rdbtnPayMasterCard.Checked == true)
            {
                PaymentType = 2;
                Cardtype = "MasterCard";
            }
            else if (rdbtnPayDiscover.Checked == true)
            {
                PaymentType = 4;
                Cardtype = "DiscoverCard";
            }
            else if (rdbtnPayAmex.Checked == true)
            {
                PaymentType = 3;
                Cardtype = "AmExCard";
            }
            else if (rdbtnPayPaypal.Checked == true)
            {
                PaymentType = 6;
            }
            else if (rdbtnPayCheck.Checked == true)
            {
                PaymentType = 5;
            }
            int AdActive;
            int UceStatus;
            int MultisiteStatus;
            int ListingStatus;
            string VoiceRecord = txtVoicefileConfirmNo.Text.Trim();
            int pmntStatus = Convert.ToInt32(ddlPayStatus.SelectedItem.Value);
            String TransactionID = String.Empty;
            if (pmntStatus == 1)
            {
                TransactionID = "";
                AdActive = 0;
                UceStatus = 0;
                MultisiteStatus = 0;
               
            }
            else
            {
                if (pmntStatus == 5)
                {
                   // PmntType = Convert.ToInt32(ddlPayMethod.SelectedItem.Value);
                    TransactionID = "";
                    AdActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);                  
                }
                else
                {
                   // PmntType = Convert.ToInt32(ddlPayMethod.SelectedItem.Value);
                    TransactionID = txtPayConfirmNum.Text;
                    AdActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);                   
                }
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
            Response.Redirect("AddNewCarNewForm.aspx");
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
                text = format.SendRegistrationdetailsForPDSales(LoginName, LoginPassword, UserDisName, ref text, PDDate);
            }
            else
            {
                text = format.SendRegistrationdetails(LoginName, LoginPassword, UserDisName, ref text, Link, TermsLink);
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
                tblPaymentDetails.Style["display"] = "none";
                trListingStatus.Style["display"] = "none";
                trUceStatus.Style["display"] = "none";
                trPayConfirm.Style["display"] = "none";
            }
            else if (PayStatus == 2)
            {
                trPayConfirm.Style["display"] = "block";
                tblPaymentDetails.Style["display"] = "block";
                int AdStatus = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
                if (AdStatus == 1)
                {
                    trUceStatus.Style["display"] = "block";
                }
                else
                {
                    trListingStatus.Style["display"] = "block";
                    trUceStatus.Style["display"] = "none";
                }
            }
            else
            {
                tblPaymentDetails.Style["display"] = "block";
                trPayConfirm.Style["display"] = "none";
                int AdStatus = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
                if (AdStatus == 1)
                {
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
            FillBillingStates();
            cvv.Text = "";
            //txtBillingname.Text = "";
            //txtbillingPhone.Text = "";
            txtbillingaddress.Text = "";
            txtbillingcity.Text = "";
            txtbillingzip.Text = "";


            chkboxlstPDsale.Enabled = true;
            ddlPDDate.Enabled = true;
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
        }
        catch (Exception ex)
        {
            throw ex;
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
            FillPaymentDate();
            txtPaytransID.Text = "";
            //txtPayAmount.Text = "";
            txtpayPalEmailAccount.Text = "";

            chkboxlstPDsale.Enabled = false;

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
            //if (chkboxlstPDsale.Checked == true)
            //{
            //    divpdDate.Style["display"] = "block";
            //    FillPDDate();
            //    txtPDAmountNow.Text = "";
            //    txtPDAmountLater.Text = "";
            //    btnProcess.Visible = true;
            //}
            //else
            //{
            //    divpdDate.Style["display"] = "none";
            //    btnProcess.Visible = true;
            //}
        }
        catch (Exception ex)
        {
            throw ex;
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
}
