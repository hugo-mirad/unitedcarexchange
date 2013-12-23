
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

public partial class AddNewMultiCar : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
    DataSet dsDropDown = new DataSet();
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
                GetAllModels();
                GetMakes();
                GetModelsInfo();
                FillYear();
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
                int UserPackID = Convert.ToInt32(Session["SelUserPackID"].ToString());
                DataSet dsSellerInfo = objdropdownBL.USP_GetDataByUserPackID(UserPackID);
                if (dsSellerInfo.Tables[1].Rows.Count > 0)
                {
                    lblCustName.Text = dsSellerInfo.Tables[1].Rows[0]["Name"].ToString();
                    //txtCustName.Text = dsSellerInfo.Tables[1].Rows[0]["Name"].ToString();
                    txtCustPhoneNumber.Text = dsSellerInfo.Tables[1].Rows[0]["PhoneNumber"].ToString();
                    //txtCustAddress.Text = dsSellerInfo.Tables[1].Rows[0]["Address"].ToString();
                    txtCity.Text = dsSellerInfo.Tables[1].Rows[0]["City"].ToString();
                    txtZip.Text = dsSellerInfo.Tables[1].Rows[0]["Zip"].ToString();
                    txtSellerEmail.Text = dsSellerInfo.Tables[1].Rows[0]["UserName"].ToString();

                    ListItem li = new ListItem();
                    li.Text = dsSellerInfo.Tables[1].Rows[0]["State_Code"].ToString();
                    li.Value = dsSellerInfo.Tables[1].Rows[0]["StateID"].ToString();
                    ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(li);

                }
                if (dsSellerInfo.Tables[0].Rows.Count > 0)
                {
                    Session["MultiCarPackID"] = dsSellerInfo.Tables[0].Rows[0]["PackageID"].ToString();
                    Session["MultiCarPackSaleDate"] = dsSellerInfo.Tables[0].Rows[0]["CreateDate"].ToString();
                    Session["MultiCarPackPaymentID"] = dsSellerInfo.Tables[0].Rows[0]["paymentID"].ToString();
                    Session["MultiCarPaydate"] = dsSellerInfo.Tables[0].Rows[0]["PayDate"].ToString();
                    string PackDescrip = dsSellerInfo.Tables[0].Rows[0]["Description"].ToString();
                    lblPackage.Text = PackDescrip + "(# " + Session["SelUserPackID"].ToString() + ")";
                }

                Session.Timeout = 180;
            }
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string strIp;
            string strHostName = Request.UserHostAddress.ToString();
            strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
            int PackageID = Convert.ToInt32(Session["MultiCarPackID"].ToString());
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
            int RegUID = Convert.ToInt32(Session["SelectUID"].ToString());
            int FeatureID;
            int IsactiveFea;
            string SellerName = "";
            string Address1 = "";
            string CustPhone = txtCustPhoneNumber.Text;
            string AltCustPhone = txtCustAltNumber.Text;
            string CustState = ddlLocationState.SelectedItem.Text;
            string CustEmail = txtSellerEmail.Text;
            DateTime SaleDate = Convert.ToDateTime(Session["MultiCarPackSaleDate"].ToString());
            int SaleEnteredBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet dsPosting = new DataSet();
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

            int AdActive;
            int ListingStatus;
            int UserPackID = Convert.ToInt32(Session["SelUserPackID"].ToString());
            int PostingID = Convert.ToInt32(Session["PostingID"].ToString());
            AdActive = Convert.ToInt32(ddlAdStatus.SelectedItem.Value);
            if (AdActive == 0)
            {
                ListingStatus = Convert.ToInt32(ddlListingStatus.SelectedItem.Value);
            }
            else
            {
                ListingStatus = 1;
            }
            DateTime Paymentdate;
            Paymentdate = Convert.ToDateTime(Session["MultiCarPaydate"].ToString());
            int PaymentID = Convert.ToInt32(Session["MultiCarPackPaymentID"].ToString());
            bool bnewPay = objdropdownBL.USP_SmartzSavePayForMultiCars(PaymentID, AdActive, Paymentdate, ListingStatus, UserPackID, PostingID);
            Session.Timeout = 180;
            mpealteruserUpdated.Show();
            lblErrUpdated.Visible = true;
            lblErrUpdated.Text = "Car details saved successfully";
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
            Response.Redirect("MultiCars.aspx");
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
            Response.Redirect("Index.aspx");
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
            Response.Redirect("MultiCars.aspx");
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
            Response.Redirect("AddNewMultiCar.aspx");
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
            msg.To.Add(LoginName);
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
}
