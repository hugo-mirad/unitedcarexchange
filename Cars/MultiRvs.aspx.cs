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
using CarsBL.RvTransactions;
using CarsBL.CentralDBTransactions;
using CarsBL.Transactions;
using CarsInfo;
public partial class MultiRvs : System.Web.UI.Page
{

    public GeneralFunc objGeneralFunc = new GeneralFunc();
    
    DataSet CarsDetails = new DataSet();
    DataSet SmartzTicketDdlDs = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
    DataSet dsActiveSmartzUsers = new DataSet();
    CentralDBMainBL objCentralDBBL = new CentralDBMainBL();
    UserRegistrationInfo objUserInfo = new UserRegistrationInfo();

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
             
               FillStates();
                int UID = Convert.ToInt32(Session["RvUserID"].ToString());
                DataSet dsUserInfoDetails = objRvMainBL.GetRvUserDetailsByUID(UID);
                Session["getRvRegUserdata"] = dsUserInfoDetails;
                lblUserName.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();
                lblRegUserName.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();
                lblUserAddPack.Text = dsUserInfoDetails.Tables[0].Rows[0]["Name"].ToString();
              //  lblUnamePW.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserID"].ToString();
                lblRegEmail2.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                lblRegEmail1.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                //lblEmailReg.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                lblUserIDName.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();

                lblUserPassword.Text = dsUserInfoDetails.Tables[0].Rows[0]["Pwd"].ToString();
                lblUpRegUserID.Text = dsUserInfoDetails.Tables[0].Rows[0]["UserName"].ToString();
                lblUpRegPassword.Text = dsUserInfoDetails.Tables[0].Rows[0]["Pwd"].ToString();
                //if (dsUserInfoDetails.Tables[0].Rows[0]["DealerCode"].ToString() != "")
                //{
                //    tblIfDealer.Style["display"] = "block";
                //    lblDealerCode.Text = dsUserInfoDetails.Tables[0].Rows[0]["DealerCode"].ToString();
                //    lnkbtnAddPackage.Visible = false;
                //    lnkbtnUpdateDealer.Visible = true;
                //    Session["DealerSellerID"] = dsUserInfoDetails.Tables[3].Rows[0]["sellerID"].ToString();
                //    Session["DealerUID"] = dsUserInfoDetails.Tables[3].Rows[0]["UId"].ToString();
                //    Session["DealerUserPackID"] = dsUserInfoDetails.Tables[3].Rows[0]["UserPackID"].ToString();
                //}
                //else
                //{
                //    tblIfDealer.Style["display"] = "none";
                //    lnkbtnAddPackage.Visible = true;
                //    lnkbtnUpdateDealer.Visible = false;
                //}
                lblRegPhone.Text = objGeneralFunc.filPhnm(dsUserInfoDetails.Tables[0].Rows[0]["PhoneNumber"].ToString());
                if (dsUserInfoDetails.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    DateTime dtAddDate = Convert.ToDateTime(dsUserInfoDetails.Tables[0].Rows[0]["CreatedDate"].ToString());
                    lblAddDate.Text = dtAddDate.ToString("MM/dd/yyyy");
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
                    lblRegAddress.Text = objGeneralFunc.ToProper(strAddress[0].ToString()).Trim() + ", ";
                }
                else
                {
                    lblRegAddress.Text = objGeneralFunc.ToProper(strAddress[0].ToString()).Trim();
                }

                if (strAddress[1].ToString() != "" && (strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
                {
                    lblRegCity.Text = objGeneralFunc.ToProper(strAddress[1].ToString()).Trim() + ", ";
                }
                else
                {
                    lblRegCity.Text = objGeneralFunc.ToProper(strAddress[1].ToString()).Trim();
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
                string sTable = CreateTable();
                lblStatusHeader.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblStatusHeader.Attributes.Add("onmouseout", "return nd(4000);");
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
            }
        }

    }


    private string CreateTable()
    {
        string strTransaction = string.Empty;
        strTransaction = "<table width=\"120px\" id=\"SalesStatus\" style=\"display: block; background-color:#F3D9F6;border:2px;border-color:Black;height:60px \">";

        strTransaction += "<tr id=\"CampaignsBody3\">";
        strTransaction += "<td  style=\"padding-left:10px;\" >";
        strTransaction += "Active:";
        strTransaction += "</td>";
        strTransaction += "<td>";
        strTransaction += "<img src=\"images/check.gif\" />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Inactive:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/red_x.png\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";
        strTransaction += "<tr id=\"CampaignsTitle11\">";
        strTransaction += "<td colspan=\"2\">";
        strTransaction += "<br />";
        strTransaction += "<br />";
        strTransaction += "</td>";
        strTransaction += "</tr>";
        strTransaction += "</table>";

        return strTransaction;

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
                //Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                LinkButton lnkbtnPackage = (LinkButton)e.Row.FindControl("lnkbtnPackage");

                if (hdnDtOfPurchase.Value != "")
                {
                    DateTime dtPurchase = Convert.ToDateTime(hdnDtOfPurchase.Value);
                    int ValidDays = Convert.ToInt32(hdnValidTill.Value);
                    DateTime dtValidTill = Convert.ToDateTime(dtPurchase.AddDays(ValidDays).ToString());
                    lblValidTill.Text = dtValidTill.ToString("MM/dd/yyyy");
                }
                lnkbtnPackage.Text = hdnPackDescrip.Value + "(# " + hdnUserPackID.Value + ")";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdPackagDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ShowPackage")
            {
                string UserPackID = e.CommandArgument.ToString();
                int UserAssignedPackID = Convert.ToInt32(UserPackID);
                DataSet dsPackageDetails = objRvMainBL.USP_GetPackageDetailsByUserPackID(UserAssignedPackID);
                lblShowPackageID.Text = dsPackageDetails.Tables[0].Rows[0]["UserPackID"].ToString();

                Double PackCost = new Double();
                PackCost = Convert.ToDouble(dsPackageDetails.Tables[0].Rows[0]["Price"].ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();

                lblShowPackageName.Text = dsPackageDetails.Tables[0].Rows[0]["Description"].ToString() + "($" + PackAmount + ")";
                if (dsPackageDetails.Tables[0].Rows[0]["PayDate"].ToString() != "")
                {
                    DateTime dtPaydate = Convert.ToDateTime(dsPackageDetails.Tables[0].Rows[0]["PayDate"].ToString());
                    lblShowPurcahseDate.Text = dtPaydate.ToString("MM/dd/yyyy");
                    DateTime dtPurchase = Convert.ToDateTime(dsPackageDetails.Tables[0].Rows[0]["PayDate"]);
                    int ValidDays = Convert.ToInt32(dsPackageDetails.Tables[0].Rows[0]["ValidityPeriod"].ToString());
                    DateTime dtValidTill = Convert.ToDateTime(dtPurchase.AddDays(ValidDays).ToString());
                    lblShowValidTill.Text = dtValidTill.ToString("MM/dd/yyyy");
                }
                lblShowMaxCars.Text = dsPackageDetails.Tables[0].Rows[0]["Maxcars"].ToString();
                lblShowCarsPosted.Text = dsPackageDetails.Tables[0].Rows[0]["CarsCount"].ToString();
                lblShowPaidThrough.Text = dsPackageDetails.Tables[0].Rows[0]["PaymentTypeName"].ToString();
                lblShowTransactionID.Text = dsPackageDetails.Tables[0].Rows[0]["TransactionID"].ToString();
                lblShowTransactionStatus.Text = dsPackageDetails.Tables[0].Rows[0]["PaymentStatusName"].ToString();
                lblShowVoiceFile.Text = dsPackageDetails.Tables[0].Rows[0]["VoiceRecord"].ToString();
                mdepPackageDetails.Show();
            }
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
                Session["RvPostingID"] = postingID;
                Session["RedirectFrom"] = 4;
                Response.Redirect("RvCustomerView.aspx");
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
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");
                HiddenField hdnPackDescription = (HiddenField)e.Row.FindControl("hdnPackDescription");
                HiddenField hdnPackUserPackID = (HiddenField)e.Row.FindControl("hdnPackUserPackID");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                lblPackage.Text = hdnPackDescription.Value + "(# " + hdnPackUserPackID.Value + ")";
                if (hdnStatus.Value.ToString() == "True")
                {
                    //lblStatus.Text = "Active";
                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else
                {
                    //lblStatus.Text = "Inactive";
                    ImgStatus.ImageUrl = "~/images/red_x.png";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnUpdateUserData_Click(object sender, EventArgs e)
    {
        try
        {
            MdepUpdateUserDetails.Hide();
            objUserInfo.Name = objGeneralFunc.ToProper(txtregName.Text).Trim();
            objUserInfo.Address = objGeneralFunc.ToProper(txtRegAddress.Text).Trim();
            objUserInfo.City = objGeneralFunc.ToProper(txtRegCity.Text).Trim();
            objUserInfo.StateID = Convert.ToInt32(ddlRegState.SelectedItem.Value);
            //if (txtZip.Text.Length == 4)
            //{
            //    objUserInfo.Zip = "0" + txtZip.Text;
            //}
            //else
            //{
            objUserInfo.Zip = txtZip.Text;
            //}
            objUserInfo.PhoneNumber = txtRegPhone.Text;

            objUserInfo.UId = Convert.ToInt32(Session["RvUserID"].ToString());
            objUserInfo.BusinessName = txtBusinessName.Text;
            objUserInfo.AltEmail = txtAltEmail.Text;
            objUserInfo.AltPhone = txtAltPhone.Text;
            int TranBy = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            DataSet dsCarDetailsInfo = new DataSet();
            dsCarDetailsInfo = objRvMainBL.USP_SmartzUpdateRegUserDetailsForMultiCar(objUserInfo, TranBy);

            Session["getRvRegUserdata"] = dsCarDetailsInfo;

            lblUserName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();
            lblRegUserName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();
            lblUserAddPack.Text = dsCarDetailsInfo.Tables[0].Rows[0]["Name"].ToString();

            lblRegEmail1.Text = dsCarDetailsInfo.Tables[0].Rows[0]["UserName"].ToString();

            lblRegPhone.Text = objGeneralFunc.filPhnm(dsCarDetailsInfo.Tables[0].Rows[0]["PhoneNumber"].ToString());

            lblBusinessName.Text = dsCarDetailsInfo.Tables[0].Rows[0]["BusinessName"].ToString();
            lblAltEmail.Text = dsCarDetailsInfo.Tables[0].Rows[0]["AltEmail"].ToString();
            lblAltPhone.Text = dsCarDetailsInfo.Tables[0].Rows[0]["AltPhone"].ToString();

            ArrayList strAddress = new ArrayList();
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["Address"].ToString().Trim());
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["City"].ToString().Trim());
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["State_Code"].ToString());
            strAddress.Add(dsCarDetailsInfo.Tables[0].Rows[0]["Zip"].ToString());

            if (strAddress[0].ToString() != "" && (strAddress[1].ToString() != "" || strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
            {
                lblRegAddress.Text = objGeneralFunc.ToProper(strAddress[0].ToString()).Trim() + ", ";
            }
            else
            {
                lblRegAddress.Text = objGeneralFunc.ToProper(strAddress[0].ToString()).Trim();
            }

            if (strAddress[1].ToString() != "" && (strAddress[2].ToString() != "UN" || strAddress[3].ToString() != ""))
            {
                lblRegCity.Text = objGeneralFunc.ToProper(strAddress[1].ToString()).Trim() + ", ";
            }
            else
            {
                lblRegCity.Text = objGeneralFunc.ToProper(strAddress[1].ToString()).Trim();
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

    protected void lnkbtnEditUserdata_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarSellerInfo = Session["getRvRegUserdata"] as DataSet;
            txtregName.Text = objGeneralFunc.ToProper(dsCarSellerInfo.Tables[0].Rows[0]["Name"].ToString()).Trim();
            txtRegPhone.Text = dsCarSellerInfo.Tables[0].Rows[0]["PhoneNumber"].ToString();
            txtRegCity.Text = objGeneralFunc.ToProper(dsCarSellerInfo.Tables[0].Rows[0]["City"].ToString()).Trim();
            lblRegEmail2.Text = dsCarSellerInfo.Tables[0].Rows[0]["UserName"].ToString();
            lblUpRegUserID.Text = dsCarSellerInfo.Tables[0].Rows[0]["UserName"].ToString();
            lblUpRegPassword.Text = dsCarSellerInfo.Tables[0].Rows[0]["Pwd"].ToString();
            txtBusinessName.Text = dsCarSellerInfo.Tables[0].Rows[0]["BusinessName"].ToString();
            txtAltEmail.Text = dsCarSellerInfo.Tables[0].Rows[0]["AltEmail"].ToString();
            txtAltPhone.Text = dsCarSellerInfo.Tables[0].Rows[0]["AltPhone"].ToString();
            ListItem list5 = new ListItem();
            list5.Value = dsCarSellerInfo.Tables[0].Rows[0]["StateID"].ToString();
            list5.Text = dsCarSellerInfo.Tables[0].Rows[0]["State_Code"].ToString();
            ddlRegState.SelectedIndex = ddlRegState.Items.IndexOf(list5);

            txtZip.Text = dsCarSellerInfo.Tables[0].Rows[0]["Zip"].ToString();

            txtRegAddress.Text = objGeneralFunc.ToProper(dsCarSellerInfo.Tables[0].Rows[0]["Address"].ToString()).Trim();
            MdepUpdateUserDetails.Show();
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
            string NewPwd = txtNewPW.Text.Trim();
            int userID = Convert.ToInt32(Session["RvUserID"].ToString());
            bool bnew = objRvMainBL.USP_CHANGE_PASSWORD(NewPwd, userID);
            if (bnew == true)
            {
                Response.Redirect("MultiRvs.aspx");
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void FillStates()
    {
        try
        {
            DropdownBL objdropdownBL = new DropdownBL();
            DataSet dsDropDown = new DataSet();
            dsDropDown = objdropdownBL.Usp_Get_DropDown();
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
}
