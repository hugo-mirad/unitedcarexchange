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


public partial class account : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    UsedCarsInfo objUsedCarsInfo = new UsedCarsInfo();
    UserRegistrationInfo objUserInfo = new UserRegistrationInfo();
    UserRegistration objUserRegBL = new UserRegistration();
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
                Session["CurrentPage"] = "Home";

                Session["CurrentPageConfig"] = null;
                Session["PageName"] = "";

                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);


                //lblUserName.Text = Session[Constants.NAME].ToString();

                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                dsDropDown = objdropdownBL.Usp_Get_DropDown();
                DataSet dsGetIDs = objdropdownBL.USP_GetIdsByUID(UID);
                FillStates();
                if (dsGetIDs.Tables.Count > 0)
                {
                    if (dsGetIDs.Tables[0].Rows.Count > 0)
                    {
                        Session["PostingID"] = dsGetIDs.Tables[0].Rows[0]["postingID"].ToString();
                        Session["CarID"] = dsGetIDs.Tables[0].Rows[0]["CarID"].ToString();
                        Session[Constants.SellerID] = dsGetIDs.Tables[0].Rows[0]["SellerID"].ToString();
                        Session["PaymentID"] = dsGetIDs.Tables[0].Rows[0]["paymentID"].ToString();
                        Session["isActive"] = dsGetIDs.Tables[0].Rows[0]["isActive"].ToString();
                        Session["UserPackID"] = dsGetIDs.Tables[1].Rows[0]["UserPackID"].ToString();
                    }
                }
                if ((Session["CarID"] == null) || (Session["CarID"].ToString() == ""))
                {
                    btnAdd.Visible = true;
                    btnDelete.Visible = false;
                    btnEdit.Visible = false;
                    // btnDeactive.Visible = false;
                    btnEditDetails.Visible = true;
                    btnUpdateDetails.Visible = false;
                    //pnl2Error.Style["display"] = "block";
                    divSrchResBox.Style["display"] = "none";
                    grdMultiSites.Visible = false;
                    lblExistUrlRes.Visible = true;
                    lblExistUrlRes.Text = "Not uploaded";
                }
                else
                {
                    if (Session["isActive"].ToString() == "True")
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
                    DataSet dsCarDetailsInfo = new DataSet();
                    dsCarDetailsInfo = objdropdownBL.USP_GetCarDetailsByIds(Convert.ToInt32(Session["CarID"].ToString()), Convert.ToInt32(Session[Constants.SellerID].ToString()));
                    Session["getcardata"] = dsCarDetailsInfo;
                    btnAdd.Visible = false;
                    btnDelete.Visible = false;
                    btnEdit.Visible = true;
                    Session["SelYear"] = dsCarDetailsInfo.Tables[0].Rows[0]["yearOfMake"].ToString();
                    Session["SelMake"] = dsCarDetailsInfo.Tables[0].Rows[0]["make"].ToString();
                    Session["SelModel"] = dsCarDetailsInfo.Tables[0].Rows[0]["model"].ToString();
                    DataSet dsImages = objdropdownBL.USP_GetImages(Convert.ToInt32(Session["CarID"].ToString()), Convert.ToInt32(Session["PackageID"].ToString()));
                    Session["GetImages"] = dsImages;
                    string SelModelName = Session["SelModel"].ToString();
                    SelModelName = SelModelName.Replace("/", "@");
                    SelModelName = SelModelName.Replace("&", "@");
                    if (dsImages.Tables[0].Rows[0]["Pic0"].ToString() != "0" && dsImages.Tables[0].Rows[0]["Pic0"].ToString() != "")
                    {
                        divAdStock.Style["display"] = "none";
                        ImageName.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + SelModelName + "/" + dsImages.Tables[0].Rows[0]["Pic0Name"].ToString();
                    }
                    else
                    {
                        ImageName.ImageUrl = "~/images/stockMakes/" + Session["SelMake"].ToString() + ".jpg";
                        divAdStock.Style["display"] = "block";
                    }
                    if (dsCarDetailsInfo.Tables[0].Rows[0]["Title"].ToString() == "")
                    {
                        lblTitle.Visible = false;
                    }
                    else
                    {
                        lblTitle.Visible = true;
                        lblTitle.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Title"].ToString();
                    }
                    lblCarName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["yearOfMake"].ToString() + " " + dsCarDetailsInfo.Tables[0].Rows[0]["make"].ToString() + " " + dsCarDetailsInfo.Tables[0].Rows[0]["model"].ToString();
                    //string descripText = dsCarDetailsInfo.Tables[0].Rows[0]["description"].ToString();
                    //if (descripText.Length > 75)
                    //{
                    //    lblDescrip.Text = descripText.Trim().Substring(0, 75) + "...";
                    //}
                    //else
                    //{
                    //    lblDescrip.Text = descripText;
                    //}
                    if (dsCarDetailsInfo.Tables[0].Rows[0]["mileage"].ToString() != "0.00")
                    {
                        lbladmilleage.Visible = true;
                        lblMi.Visible = true;
                        lbladmilleage.Text = dsCarDetailsInfo.Tables[0].Rows[0]["mileage"].ToString();
                    }
                    else
                    {
                        lbladmilleage.Visible = true;
                        lblMi.Visible = false;
                        lbladmilleage.Text = "Unspecified";
                    }
                    if (dsCarDetailsInfo.Tables[0].Rows[0]["price"].ToString() != "0.0000")
                    {
                        lbladPrice.Visible = true;
                        lbladPrice.Text = dsCarDetailsInfo.Tables[0].Rows[0]["price"].ToString();
                    }
                    else
                    {
                        lbladPrice.Visible = true;
                        lbladPrice.Text = "Unspecified";
                    }
                    if (dsCarDetailsInfo.Tables[0].Rows[0]["bodyType"].ToString() != "Unspecified")
                    {
                        lblAdBody.Visible = true;
                        lblAdBody.Text = dsCarDetailsInfo.Tables[0].Rows[0]["bodyType"].ToString();
                    }
                    else
                    {
                        lblAdBody.Visible = true;
                        lblAdBody.Text = "Unspecified";
                    }
                    if (dsCarDetailsInfo.Tables[0].Rows[0]["fuelType"].ToString() != "Unspecified")
                    {
                        lblAdFuel.Visible = true;
                        lblAdFuel.Text = dsCarDetailsInfo.Tables[0].Rows[0]["fuelType"].ToString();
                    }
                    else
                    {
                        lblAdFuel.Visible = true;
                        lblAdFuel.Text = "Unspecified";
                    }

                    ArrayList strDescrip = new ArrayList();
                    string ExtClr = string.Empty;
                    string NoOfDoors = string.Empty;
                    string NoOfCyln = string.Empty;
                    string Trans = string.Empty;
                    strDescrip.Add(dsCarDetailsInfo.Tables[0].Rows[0]["exteriorColor"].ToString());
                    strDescrip.Add(dsCarDetailsInfo.Tables[0].Rows[0]["numberOfDoors"].ToString());
                    strDescrip.Add(dsCarDetailsInfo.Tables[0].Rows[0]["numberOfCylinder"].ToString());
                    strDescrip.Add(dsCarDetailsInfo.Tables[0].Rows[0]["Transmission"].ToString());


                    if (strDescrip[0].ToString() != "Unspecified" && (strDescrip[1].ToString() != "Unspecified" || strDescrip[2].ToString() != "Unspecified" || strDescrip[3].ToString() != "Unspecified"))
                    {
                        ExtClr = strDescrip[0].ToString() + ", ";
                    }
                    else if (strDescrip[0].ToString() != "Unspecified")
                    {
                        ExtClr = strDescrip[0].ToString();
                    }
                    if (strDescrip[1].ToString() != "Unspecified" && (strDescrip[2].ToString() != "Unspecified" || strDescrip[3].ToString() != "Unspecified"))
                    {
                        NoOfDoors = strDescrip[1].ToString() + ", ";
                    }
                    else if (strDescrip[1].ToString() != "Unspecified")
                    {
                        NoOfDoors = strDescrip[1].ToString();
                    }
                    if (strDescrip[2].ToString() != "Unspecified" && strDescrip[3].ToString() != "Unspecified")
                    {
                        NoOfCyln = strDescrip[2].ToString() + ", ";
                    }
                    else if (strDescrip[2].ToString() != "Unspecified")
                    {
                        NoOfCyln = strDescrip[2].ToString();
                    }
                    if (strDescrip[3].ToString() != "Unspecified")
                    {
                        Trans = strDescrip[3].ToString();
                    }
                    lblDescrip.Text = ExtClr + NoOfDoors + NoOfCyln + Trans;

                    divSrchResBox.Style["display"] = "block";
                    int PicCount = 0;
                    for (int i = 1; i < 21; i++)
                    {
                        string ColumnPic = "pic" + i.ToString();
                        if (dsCarDetailsInfo.Tables[0].Rows[0][ColumnPic].ToString() != "0" && dsCarDetailsInfo.Tables[0].Rows[0][ColumnPic].ToString() != "")
                        {
                            PicCount = PicCount + 1;
                        }
                    }
                    lblPhotoUploaded.Text = PicCount.ToString();
                    if (dsCarDetailsInfo.Tables[3].Rows.Count > 0)
                    {
                        lblExistUrlRes.Visible = false;
                        divlblMultiSite.Style["display"] = "none";
                        grdMultiSites.Visible = true;
                        grdMultiSites.DataSource = dsCarDetailsInfo.Tables[3];
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

                DataSet dsUserInfoDetails = objdropdownBL.USP_GetUSerDetailsByUserID(Convert.ToInt32(Session[Constants.USER_ID].ToString()));
                Session["getRegUserdata"] = dsUserInfoDetails;
                tbl1LblsDisplay.Style["display"] = "block";
                tbl2textDisplay.Style["display"] = "none";
                lblRegEmail.Text = Session[Constants.USER_NAME].ToString();
                lblRegEmail2.Text = Session[Constants.USER_NAME].ToString();
                lblUnamePW.Text = Session[Constants.USER_NAME].ToString();
                lblRegPhone.Text = objGeneralFunc.filPhnm(dsUserInfoDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                lblRegName.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();
                lblBusinessName.Text = dsUserInfoDetails.Tables[0].Rows[0]["BusinessName"].ToString();
                lblAltEmail.Text = dsUserInfoDetails.Tables[0].Rows[0]["AltEmail"].ToString();
                lblAltPhone.Text = objGeneralFunc.filPhnm(dsUserInfoDetails.Tables[0].Rows[0]["AltPhone"].ToString());

                ArrayList strAddress = new ArrayList();
                strAddress.Add(dsUserInfoDetails.Tables[0].Rows[0]["Address"].ToString().Trim());
                strAddress.Add(dsUserInfoDetails.Tables[0].Rows[0]["City"].ToString().Trim());
                strAddress.Add(dsUserInfoDetails.Tables[0].Rows[0]["State_Code"].ToString());
                strAddress.Add(dsUserInfoDetails.Tables[0].Rows[0]["Zip"].ToString());

                if (strAddress[0].ToString() != "" && (strAddress[1].ToString() != "" || strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
                {
                    lblRegAddress.Text = GeneralFunc.ToProper(strAddress[0].ToString()).Trim() + ", ";
                }
                else
                {
                    lblRegAddress.Text = GeneralFunc.ToProper(strAddress[0].ToString()).Trim();
                }

                if (strAddress[1].ToString() != "" && (strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
                {
                    lblRegCity.Text = GeneralFunc.ToProper(strAddress[1].ToString()).Trim() + ", ";
                }
                else
                {
                    lblRegCity.Text = GeneralFunc.ToProper(strAddress[1].ToString()).Trim();
                }

                if ((strAddress[2].ToString() != "UN") && (strAddress[3].ToString() != ""))
                {
                    lblRegState.Text = strAddress[2].ToString() + " ";
                }
                else if ((strAddress[2].ToString() != "UN") && (strAddress[3].ToString() == ""))
                {
                    lblRegState.Text = strAddress[2].ToString();
                }
                lblRegZip.Text = strAddress[3].ToString();
                btnEditDetails.Visible = true;
                btnUpdateDetails.Visible = false;


                DataSet dsPackDetails = objdropdownBL.USP_GetPackageDetails(Convert.ToInt32(Session["PackageID"]), UID);
                if (dsPackDetails.Tables[0].Rows.Count > 0)
                {
                    lblPackDescrip.Text = dsPackDetails.Tables[0].Rows[0]["Description"].ToString();
                    lblMaxPhotos.Text = dsPackDetails.Tables[0].Rows[0]["Maxphotos"].ToString();
                    Session["MaxPhotos"] = dsPackDetails.Tables[0].Rows[0]["Maxphotos"];
                    if ((dsPackDetails.Tables[0].Rows[0]["dateOfPosting"].ToString() != "") && (dsPackDetails.Tables[0].Rows[0]["PaymentDate"].ToString() != ""))
                    {
                        DateTime PostDate = Convert.ToDateTime(dsPackDetails.Tables[0].Rows[0]["dateOfPosting"].ToString());
                        DateTime PaymentDate = Convert.ToDateTime(dsPackDetails.Tables[0].Rows[0]["PaymentDate"].ToString());
                        if (PostDate > PaymentDate)
                        {
                            lblAdActiveFrom.Text = PostDate.ToString("MM/dd/yyyy");
                        }
                        else if (PostDate <= PaymentDate)
                        {
                            lblAdActiveFrom.Text = PaymentDate.ToString("MM/dd/yyyy");
                        }
                    }
                    //  lblAdActiveFrom.Text = dsPackDetails.Tables[0].Rows[0]["dateOfPosting"].ToString();
                    if (lblAdActiveFrom.Text != "")
                    {
                        TimeSpan timespan = System.DateTime.Now.Subtract(Convert.ToDateTime(lblAdActiveFrom.Text));
                        int daysComplete = Convert.ToInt32(timespan.Days);
                        int RemainDays = Convert.ToInt32(dsPackDetails.Tables[0].Rows[0]["ValidityPeriod"].ToString()) - daysComplete;
                        lblRemainingPeriod.Text = System.DateTime.Now.AddDays(RemainDays).ToString("MM/dd/yyyy");
                    }
                    if (lblPhotoUploaded.Text == "")
                    {
                        lblPhotoUploaded.Text = "0";
                    }


                }
            }
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
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PlaceAd.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PlaceAd.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnEditDetails_Click(object sender, EventArgs e)
    {
        try
        {
            tbl1LblsDisplay.Style["display"] = "none";
            tbl2textDisplay.Style["display"] = "block";
            DataSet dsCarSellerInfo = Session["getRegUserdata"] as DataSet;
            btnEditDetails.Visible = false;
            btnUpdateDetails.Visible = true;
            divlblRegName.Style["display"] = "none";
            divtxtRegName.Style["display"] = "block";
            txtregName.Text = GeneralFunc.ToProper(dsCarSellerInfo.Tables[0].Rows[0]["Name"].ToString()).Trim();
            txtBusinessName.Text = dsCarSellerInfo.Tables[0].Rows[0]["BusinessName"].ToString();
            txtAltEmail.Text = dsCarSellerInfo.Tables[0].Rows[0]["AltEmail"].ToString();
            txtAltPhone.Text = dsCarSellerInfo.Tables[0].Rows[0]["AltPhone"].ToString();

            divlblRegPhone.Style["display"] = "none";
            divtxtRegPhone.Style["display"] = "block";
            txtRegPhone.Text = dsCarSellerInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();

            divlblRegCity.Style["display"] = "none";
            divtxtRegCity.Style["display"] = "block";
            txtRegCity.Text = GeneralFunc.ToProper(dsCarSellerInfo.Tables[0].Rows[0]["City"].ToString()).Trim();

            divlblRegState.Style["display"] = "none";
            divddlRegState.Style["display"] = "block";
            ListItem list5 = new ListItem();
            list5.Value = dsCarSellerInfo.Tables[0].Rows[0]["StateID"].ToString();
            list5.Text = dsCarSellerInfo.Tables[0].Rows[0]["State_Code"].ToString();
            ddlLocationState.SelectedIndex = ddlLocationState.Items.IndexOf(list5);

            divlblRegZip.Style["display"] = "none";
            divtxtRegZip.Style["display"] = "block";
            txtRegZip.Text = dsCarSellerInfo.Tables[0].Rows[0]["Zip"].ToString();

            divlblRegAddress.Style["display"] = "none";
            divtxtRegAddress.Style["display"] = "block";
            txtRegAddress.Text = GeneralFunc.ToProper(dsCarSellerInfo.Tables[0].Rows[0]["Address"].ToString()).Trim();
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnUpdateDetails_Click(object sender, EventArgs e)
    {
        try
        {
            tbl1LblsDisplay.Style["display"] = "block";
            tbl2textDisplay.Style["display"] = "none";
            objUserInfo.Name = GeneralFunc.ToProper(txtregName.Text).Trim();
            objUserInfo.Address = GeneralFunc.ToProper(txtRegAddress.Text).Trim();
            objUserInfo.City = GeneralFunc.ToProper(txtRegCity.Text).Trim();
            objUserInfo.StateID = Convert.ToInt32(ddlLocationState.SelectedItem.Value);
            if (txtRegZip.Text.Length == 4)
            {
                objUserInfo.Zip = "0" + txtRegZip.Text;
            }
            else
            {
                objUserInfo.Zip = txtRegZip.Text;
            }
            objUserInfo.PhoneNumber = txtRegPhone.Text;

            objUserInfo.UId = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            objUserInfo.BusinessName = txtBusinessName.Text;
            objUserInfo.AltEmail = txtAltEmail.Text;
            objUserInfo.AltPhone = txtAltPhone.Text;

            DataSet dsCarDetailsInfo = new DataSet();
            dsCarDetailsInfo = objUserRegBL.USP_UpdateRegUserDetails(objUserInfo);

            Session["getRegUserdata"] = dsCarDetailsInfo;

            btnEditDetails.Visible = true;
            btnUpdateDetails.Visible = false;

            tbl1LblsDisplay.Style["display"] = "block";
            tbl2textDisplay.Style["display"] = "none";

            divlblRegName.Style["display"] = "block";
            divtxtRegName.Style["display"] = "none";
            lblRegName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();

            divlblRegPhone.Style["display"] = "block";
            divtxtRegPhone.Style["display"] = "none";
            lblRegPhone.Text = objGeneralFunc.filPhnm(dsCarDetailsInfo.Tables[0].Rows[0]["PhoneNumber"].ToString());


            lblBusinessName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["BusinessName"].ToString();
            lblAltEmail.Text = dsCarDetailsInfo.Tables[0].Rows[0]["AltEmail"].ToString();
            lblAltPhone.Text = objGeneralFunc.filPhnm(dsCarDetailsInfo.Tables[0].Rows[0]["AltPhone"].ToString());


            divlblRegCity.Style["display"] = "block";
            divtxtRegCity.Style["display"] = "none";
            //lblRegCity.Text = dsCarDetailsInfo.Tables[0].Rows[0]["City"].ToString();

            divlblRegState.Style["display"] = "block";
            divddlRegState.Style["display"] = "none";
            //lblRegState.Text = dsCarDetailsInfo.Tables[0].Rows[0]["State_Code"].ToString();

            divlblRegZip.Style["display"] = "block";
            divtxtRegZip.Style["display"] = "none";
            //lblRegZip.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Zip"].ToString();

            divlblRegAddress.Style["display"] = "block";
            divtxtRegAddress.Style["display"] = "none";
            //lblRegAddress.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Address"].ToString();

            ArrayList strAddress = new ArrayList();

            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["Address"].ToString().Trim());
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["City"].ToString().Trim());
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["State_Code"].ToString());
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["Zip"].ToString());

            if (strAddress[0].ToString() != "" && (strAddress[1].ToString() != "" || strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
            {
                lblRegAddress.Text = GeneralFunc.ToProper(strAddress[0].ToString()).Trim() + ", ";
            }
            else
            {
                lblRegAddress.Text = GeneralFunc.ToProper(strAddress[0].ToString()).Trim();
            }

            if (strAddress[1].ToString() != "" && (strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
            {
                lblRegCity.Text = GeneralFunc.ToProper(strAddress[1].ToString()).Trim() + ", ";
            }
            else
            {
                lblRegCity.Text = GeneralFunc.ToProper(strAddress[1].ToString()).Trim();
            }

            if ((strAddress[2].ToString() != "UN") && (strAddress[3].ToString() != ""))
            {
                lblRegState.Text = strAddress[2].ToString() + " ";
            }
            else if ((strAddress[2].ToString() != "UN") && (strAddress[3].ToString() == ""))
            {
                lblRegState.Text = strAddress[2].ToString();
            }
            lblRegZip.Text = strAddress[3].ToString();




        }
        catch (Exception ex)
        {
        }
    }
    protected void btnChangePW_Click(object sender, EventArgs e)
    {
        try
        {
            string NewPwd = txtNewPW.Text;
            int userID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            bool bnew = objdropdownBL.USP_CHANGE_PASSWORD(NewPwd, userID);
            if (bnew == true)
            {
                mpeChangePW.Hide();
            }
        }
        catch (Exception ex)
        {
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
}
