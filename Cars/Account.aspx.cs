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

public partial class AccountNew : System.Web.UI.Page
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

                GeneralFunc.SetPageDefaults(Page);
                Session["CurrentPage"] = "Account";
                Session["PageName"] = "";
                Session["CurrentPageConfig"] = null;
                //KeyWords.Addkeywordstags(Header);
                GeneralFunc.SaveSiteVisit();
                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);


                //lblUserName.Text = Session[Constants.NAME].ToString();                
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());

                dsDropDown = objdropdownBL.Usp_Get_DropDown();

                FillStates();

                DataSet dsUserInfoDetails = objdropdownBL.USP_GetUSerDetailsByUserID(UID);

                Session["getRegUserdata"] = dsUserInfoDetails;

                lblRegName.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();
                lblUserNameData.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();

                lblUserAddPack.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();
                lblUnamePW.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserID"].ToString();
                lblRegEmail2.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                lblRegEmail.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                //lblEmailReg.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                lblRegPhone.Text = objGeneralFunc.filPhnm(dsUserInfoDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                if (dsUserInfoDetails.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    DateTime dtAddDate = Convert.ToDateTime(dsUserInfoDetails.Tables[0].Rows[0]["CreatedDate"].ToString());
                    lblUserMemberDate.Text = dtAddDate.ToString("MM/dd/yy");
                }

                lblBusinessName.Text = dsUserInfoDetails.Tables[0].Rows[0]["BusinessName"].ToString();
                lblAltEmail.Text = dsUserInfoDetails.Tables[0].Rows[0]["AltEmail"].ToString();
                lblAltPhone.Text = dsUserInfoDetails.Tables[0].Rows[0]["AltPhone"].ToString();

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
                grdPackagDetails.DataSource = dsUserInfoDetails.Tables[2];
                grdPackagDetails.DataBind();

                grdCarDetails.DataSource = dsUserInfoDetails.Tables[1];
                grdCarDetails.DataBind();
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PlaceAd.aspx");
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
            Response.Redirect("PlaceAd.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnEditDetails_Click(object sender, EventArgs e)
    {
        try
        {
            tbl1LblsDisplay.Style["display"] = "none";
            tbl2textDisplay.Style["display"] = "table";
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
            throw ex;
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
            lblUserNameData.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();
            divlblRegPhone.Style["display"] = "block";
            divtxtRegPhone.Style["display"] = "none";
            lblRegPhone.Text = objGeneralFunc.filPhnm(dsCarDetailsInfo.Tables[0].Rows[0]["PhoneNumber"].ToString());
            lblUserAddPack.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();

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
            throw ex;
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
                MpeAlert.Show();
                lblErrorMSg.Visible = true;
                lblErrorMSg.Text = "Password changed successfully.";
            }
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
            mdepActiveAd.Show();
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
            mpealteruser.Hide();
            mdepActiveAd.Show();
        }
        catch (Exception ex)
        {
            throw ex;
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
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                if (hdnDtOfPurchase.Value != "")
                {
                    DateTime dtPurchase = Convert.ToDateTime(hdnDtOfPurchase.Value);
                    int ValidDays;
                    DateTime dtValidTill; 
                    if (hdnValidTill.Value != "")
                    {
                        ValidDays = Convert.ToInt32(hdnValidTill.Value);

                        dtValidTill = Convert.ToDateTime(dtPurchase.AddDays(ValidDays).ToString());

                        lblValidTill.Text = dtValidTill.ToString("MM/dd/yy");
                    }
                    
                }
                lblPackage.Text = hdnPackDescrip.Value + "(# " + hdnUserPackID.Value + ")";
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
                HiddenField hdnPackDescription = (HiddenField)e.Row.FindControl("hdnPackDescription");
                HiddenField hdnPackUserPackID = (HiddenField)e.Row.FindControl("hdnPackUserPackID");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                lblPackage.Text = hdnPackDescription.Value + "(# " + hdnPackUserPackID.Value + ")";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnCarDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet dsPackages = objdropdownBL.USP_ChkPackageForAddCar(UID);

            if (dsPackages.Tables.Count > 0)
            {
                if (dsPackages.Tables[0].Rows.Count > 0)
                {
                    FillPackSel(dsPackages);
                    mpeSelectPack.Show();
                }
                else
                {
                    lblErr.Visible = true;
                    lblErr.Text = "You need to add a package to be able to add a vehicl1e - Click Ok to visit Add Packages Option.";
                    mpealteruser.Show();
                }
            }
            else
            {
                lblErr.Visible = true;
                lblErr.Text = "You need to add a package to be able to add a vehicle - Click Ok to visit Add Packages Option.";
                mpealteruser.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void FillPackSel(DataSet dsPackages)
    {
        try
        {
            ddlSelPack.Items.Clear();
            for (int i = 0; i < dsPackages.Tables[0].Rows.Count; i++)
            {
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsPackages.Tables[0].Rows[i]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = dsPackages.Tables[0].Rows[i]["Description"].ToString();
                string UserPackID = dsPackages.Tables[0].Rows[i]["UserPackID"].ToString();
                ListItem list = new ListItem();
                list.Text = PackName + "(# " + UserPackID + ")";
                list.Value = dsPackages.Tables[0].Rows[i]["UserPackID"].ToString();
                ddlSelPack.Items.Add(list);
            }
            ddlSelPack.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnGoSelPack_Click(object sender, EventArgs e)
    {
        try
        {
            Session["SelUserPackID"] = ddlSelPack.SelectedItem.Value;
            Response.Redirect("AddNewMultiCar.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnAddPackage_Click(object sender, EventArgs e)
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
    protected void grdCarDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Response.Redirect("PlaceAd.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            mpealteruser.Hide();
            mdepActiveAd.Hide();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
