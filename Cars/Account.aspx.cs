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


public partial class Account : System.Web.UI.Page
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
                hdnSubAlert.Value = "true";
                GeneralFunc.SetPageDefaults(Page);
                Session["CurrentPage"] = "Account";
                Session["Memebersincedate"] = null;
                Session["k"] = 0;


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


                lblUserName.Text = Session[Constants.NAME].ToString();                
                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
               //  int UID = 120;

                dsDropDown = objdropdownBL.Usp_Get_DropDown();

                FillStates();

                DataSet dsUserInfoDetails1 = objdropdownBL.USP_GetUSerDetailsByUserID(UID);

                //Session["getRegUserdata"] = dsUserInfoDetails;
                Session["getRegUserdata"] = dsUserInfoDetails1;

                lblRegName.Text = dsUserInfoDetails1.Tables[0].Rows[0]["Name"].ToString();


                Session["sName"] = dsUserInfoDetails1.Tables[0].Rows[0]["Name"].ToString();
                Session["sEmail"] = dsUserInfoDetails1.Tables[0].Rows[0]["UserName"].ToString();
                Session["sPhone"] = objGeneralFunc.filPhnm(dsUserInfoDetails1.Tables[0].Rows[0]["PhoneNumber"].ToString());

              //  lblUserName.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();

                lblUserAddPack.Text = dsUserInfoDetails1.Tables[0].Rows[0]["Name"].ToString();
                lblUnamePW.Text = dsUserInfoDetails1.Tables[0].Rows[0]["UserID"].ToString();
                lblRegEmail2.Text = dsUserInfoDetails1.Tables[0].Rows[0]["UserName"].ToString();
                lblRegEmail.Text = dsUserInfoDetails1.Tables[0].Rows[0]["UserName"].ToString();
              //  lblEmailReg.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                lblRegPhone.Text = objGeneralFunc.filPhnm(dsUserInfoDetails1.Tables[0].Rows[0]["PhoneNumber"].ToString());
                if (dsUserInfoDetails1.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    DateTime dtAddDate = Convert.ToDateTime(dsUserInfoDetails1.Tables[0].Rows[0]["CreatedDate"].ToString());
                    lblUserMemberDate.Text = dtAddDate.ToString("MM/dd/yy");
                    Session["Memebersincedate"] = dtAddDate.ToString("MM/dd/yy");
                }

                lblBusinessName.Text = dsUserInfoDetails1.Tables[0].Rows[0]["BusinessName"].ToString();
                lblAltEmail.Text = dsUserInfoDetails1.Tables[0].Rows[0]["AltEmail"].ToString();
                lblAltPhone.Text = dsUserInfoDetails1.Tables[0].Rows[0]["AltPhone"].ToString();

                ArrayList strAddress = new ArrayList();
                strAddress.Add(dsUserInfoDetails1.Tables[0].Rows[0]["Address"].ToString().Trim());
                strAddress.Add(dsUserInfoDetails1.Tables[0].Rows[0]["City"].ToString().Trim());
                strAddress.Add(dsUserInfoDetails1.Tables[0].Rows[0]["State_Code"].ToString());
                strAddress.Add(dsUserInfoDetails1.Tables[0].Rows[0]["Zip"].ToString());
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
             
                grdPackagDetails.DataSource = dsUserInfoDetails1.Tables[2];
                grdPackagDetails.DataBind();
              
               //grdCarDetails.DataSource = dsUserInfoDetails.Tables[1];
              // grdCarDetails.DataBind();
            }
        }
        //------------------------------------------------------------
       // DataSet dsCarDetailsInfoSellerID = new DataSet();
        
       // // dsCarDetailsInfoSellerID = objdropdownBL.USP_GetCarDetailsBySellerID(Convert.ToInt32(Session["RegUSER_ID"].ToString()));
       // dsCarDetailsInfoSellerID = objdropdownBL.USP_GetCarDetailsBySellerID(120);
       // string s0 = dsCarDetailsInfoSellerID.Tables[0].Rows.Count.ToString();//cardetails
       // string s1 = dsCarDetailsInfoSellerID.Tables[1].Rows.Count.ToString();//pictures
       // string s2 = dsCarDetailsInfoSellerID.Tables[2].Rows.Count.ToString();//package
       // string s3 = dsCarDetailsInfoSellerID.Tables[3].Rows.Count.ToString();//makemodel
      
       //// mkmodel.Text = dsCarDetailsInfoSellerID.Tables[3].Rows[0]["make"].ToString() + "   " + dsCarDetailsInfoSellerID.Tables[3].Rows[0]["model"].ToString();
       // Session["dsCarDetailsInfoSellerID"] = dsCarDetailsInfoSellerID;

        DataSet dsUserInfoDetails2 = objdropdownBL.USP_GetUSerDetailsByUserID(Convert.ToInt32(Session[Constants.USER_ID].ToString()));
        Session["dsUserInfoDetails1"] = dsUserInfoDetails2;

        RepDetails.DataSource = dsUserInfoDetails2.Tables[1];
        RepDetails.DataBind();
        //RepDetails.DataSource = dsCarDetailsInfoSellerID.Tables[0];
      //  RepDetails.DataBind();
        // if (dsCarDetailsInfoSellerID.Tables[1].Rows[0]["Pic0"].ToString() != "0" && dsCarDetailsInfoSellerID.Tables[1].Rows[0]["Pic0"].ToString() != "")
        // {

        //  //  ImageName.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic0Name"].ToString();
        // }
        // else
        // {
        //    // ImageName.ImageUrl = "~/images/stockMakes/" + Session["SelMake"].ToString() + ".jpg";

        // }

        //// lblexampledata.Text = s1 + s2 + s3 + dsCarDetailsInfoSellerID.Tables[1].Rows[0]["pic0"].ToString() + dsCarDetailsInfoSellerID.Tables[1].Rows[0]["pic1"].ToString();

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
           // objUserInfo.UId = 120;
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
          //  lblUserName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();
            divlblRegPhone.Style["display"] = "block";
            divtxtRegPhone.Style["display"] = "none";
            lblRegPhone.Text = objGeneralFunc.filPhnm(dsCarDetailsInfo.Tables[0].Rows[0]["PhoneNumber"].ToString());
            lblUserAddPack.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();

            lblBusinessName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["BusinessName"].ToString();
            lblAltEmail.Text = dsCarDetailsInfo.Tables[0].Rows[0]["AltEmail"].ToString();
            lblAltPhone.Text = objGeneralFunc.filPhnm(dsCarDetailsInfo.Tables[0].Rows[0]["AltPhone"].ToString());


            divlblRegCity.Style["display"] = "block";
            divtxtRegCity.Style["display"] = "none";
            lblRegCity.Text = dsCarDetailsInfo.Tables[0].Rows[0]["City"].ToString();

            divlblRegState.Style["display"] = "block";
            divddlRegState.Style["display"] = "none";
            lblRegState.Text = dsCarDetailsInfo.Tables[0].Rows[0]["State_Code"].ToString();

            divlblRegZip.Style["display"] = "block";
            divtxtRegZip.Style["display"] = "none";
            lblRegZip.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Zip"].ToString();

            divlblRegAddress.Style["display"] = "block";
            divtxtRegAddress.Style["display"] = "none";
            lblRegAddress.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Address"].ToString();

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
           // int UID = 120;
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
           // ddlSelPack.Items.Clear();
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
              //  ddlSelPack.Items.Add(list);
            }
           // ddlSelPack.Items.Insert(0, new ListItem("Select", "0"));
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
           // Session["SelUserPackID"] = ddlSelPack.SelectedItem.Value;
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

   
    protected void RepDetails_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataSet dsUserInfoDetails1 = (DataSet)Session["dsUserInfoDetails1"];
            // if (((Image)e.Item.FindControl("ImageName")).ImageUrl.Length == 0)
            //{
            // ((Image)e.Item.FindControl("ImageName")).ImageUrl = "~/images/stockMakes/" + dsCarDetailsInfoSellerID.Tables[3].Rows[0]["make"].ToString() + ".jpg";


            //  }
            //  else
            // {
            //file:///C:\Users\dhanunjay\Desktop\MobiCarz-ASP\Cars\CarImages\2009\Audi\A4\2009_Audi_A4_55915Thumb.jpg
            // ((Image)e.Item.FindControl("ImageName")).ImageUrl = @"~/CarImages/" + dsCarDetailsInfoSellerID.Tables[0].Rows[0]["yearofmake"].ToString() + "/" + dsCarDetailsInfoSellerID.Tables[3].Rows[0]["make"].ToString() + "/" + dsCarDetailsInfoSellerID.Tables[3].Rows[0]["model"].ToString() + "/" + dsCarDetailsInfoSellerID.Tables[1].Rows[0]["Pic0Name"].ToString();
            Image obj = (Image)e.Item.FindControl("ImageName");

            if (dsUserInfoDetails1.Tables[1].Rows[0]["picturelocation"].ToString() != null || dsUserInfoDetails1.Tables[1].Rows[0]["picturelocation"].ToString() != "")

           //15-04-2014  obj.ImageUrl = "~/CarImages/" + dsUserInfoDetails1.Tables[1].Rows[0]["yearofmake"].ToString() + "/" + dsUserInfoDetails1.Tables[1].Rows[0]["make"].ToString() + "/" + dsUserInfoDetails1.Tables[1].Rows[0]["model"].ToString() + "/" + dsUserInfoDetails1.Tables[1].Rows[0]["PicName"].ToString();
            obj.ImageUrl = "http://images.mobicarz.com/" + dsUserInfoDetails1.Tables[1].Rows[0]["picturelocation"].ToString() + "" + dsUserInfoDetails1.Tables[1].Rows[0]["PicName"].ToString();

            if(obj.ImageUrl=="http://images.mobicarz.com/")
                obj.ImageUrl = "http://images.mobicarz.com/images/MakeModelThumbs/" + dsUserInfoDetails1.Tables[1].Rows[0]["Make"].ToString() + "_" + dsUserInfoDetails1.Tables[1].Rows[0]["Model"].ToString()+".jpg";


            LinkButton lnkobj = (LinkButton)e.Item.FindControl("lnkurl");
            lnkobj.Text = "http://www.unitedcarexchange.com/production2.aspx?C" + dsUserInfoDetails1.Tables[1].Rows[0]["carId"].ToString();
            lnkobj.PostBackUrl = "http://www.unitedcarexchange.com/production2.aspx?C=" + dsUserInfoDetails1.Tables[1].Rows[0]["carId"].ToString();

            //  }
        }
    }
    protected void RepDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
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

        //View car Viewcar

        try
        {
            if (e.CommandName == "Viewcar")
            {
               
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
               
                Session["caridhdn"] = arg[0];
                Session["PostingID"] = arg[1];
                Response.Redirect("CarDetails.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //Reviews

        try
        {
            if (e.CommandName == "Reviews")
            {
                string postingID = e.CommandArgument.ToString();
                Session["CaruniqueId"] = postingID;
                Response.Redirect("Reviews.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
          
  
}
