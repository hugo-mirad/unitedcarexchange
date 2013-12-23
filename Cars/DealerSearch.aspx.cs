
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
using CarsBL.RvTransactions;
using CarsInfo.RvInfo;
using CarsBL.CentralDBTransactions;


public partial class DealerSearch : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
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

                trcarMake.Style["display"] = "block";
                trcarModel.Style["display"] = "block";
                trRvType.Style["display"] = "none";
                trRvmake.Style["display"] = "none";
                trcarYear.Style["display"] = "block";
                FillAgents();
                GetAllModels();
                GetMakes();
                FillType();
                GetAllRvMakes();
            }
        }
    }

    private void FillType()
    {
        try
        {
            DataSet dsAllTypes = new DataSet();
            if (Session["RvAllTypes"] == null)
            {
                dsAllTypes = objRvMainBL.GetAllTypes();
                Session["RvAllTypes"] = dsAllTypes;
            }
            else
            {
                dsAllTypes = Session["RvAllTypes"] as DataSet;
            }

            ddlRvType.DataSource = dsAllTypes.Tables[0];
            ddlRvType.DataTextField = "TypeName";
            ddlRvType.DataValueField = "TypeID";
            ddlRvType.DataBind();
            ddlRvType.Items.Insert(0, new ListItem("All Types", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    private void FillAgents()
    {
        DataSet SalesAgents = Session["ActiveSalesAgents"] as DataSet;
        ddlAgentNames.DataSource = SalesAgents.Tables[0];
        ddlAgentNames.DataTextField = "American_Name";
        ddlAgentNames.DataValueField = "Sale_Agent_Id";
        ddlAgentNames.DataBind();
        ddlAgentNames.Items.Insert(0, new ListItem("Unknown", "0"));
    }

    private void GetAllMakes()
    {
        try
        {
            DataSet dsAllMakes = new DataSet();
            if (Session["RvAllMakes"] == null)
            {
                dsAllMakes = objRvMainBL.USP_GetAllMakes(0);
                Session["RvAllMakes"] = dsAllMakes;
            }
            else
            {
                dsAllMakes = Session["RvAllMakes"] as DataSet;
            }
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

            ddlCarMake.DataSource = obj;
            ddlCarMake.DataTextField = "Make";
            ddlCarMake.DataValueField = "MakeID";
            ddlCarMake.DataBind();
            ddlCarMake.Items.Insert(0, new ListItem("All Makes", "0"));
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
            int makeid = Convert.ToInt32(ddlCarMake.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsModels.Tables[0].DefaultView;
            dvModel.RowFilter = "MakeID='" + makeid.ToString() + "'";
            dtModel = dvModel.ToTable();
            ddlCarModel.DataSource = dtModel;
            ddlCarModel.Items.Clear();
            ddlCarModel.DataTextField = "Model";
            ddlCarModel.DataValueField = "MakeModelID";
            ddlCarModel.DataBind();
            ddlCarModel.Items.Insert(0, new ListItem("All Models", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlVehicleType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //if (ddlVehicleType.SelectedItem.Value == "0")
            //{
            //    trcarMake.Style["display"] = "none";
            //    trcarModel.Style["display"] = "none";
            //    trRvType.Style["display"] = "none";
            //    trRvmake.Style["display"] = "none";
            //    trcarYear.Style["display"] = "none";


            //}
            if (ddlVehicleType.SelectedItem.Value == "1")
            {
                trcarMake.Style["display"] = "block";
                trcarModel.Style["display"] = "block";
                trRvType.Style["display"] = "none";
                trRvmake.Style["display"] = "none";
                trcarYear.Style["display"] = "block";


                ListItem licarYear = new ListItem();
                licarYear.Text = "Any Year";
                licarYear.Value = "0";
                ddlYear.SelectedIndex = ddlYear.Items.IndexOf(licarYear);


                ListItem licarmake = new ListItem();
                licarmake.Text = "All Makes";
                licarmake.Value = "0";
                ddlCarMake.SelectedIndex = ddlCarMake.Items.IndexOf(licarmake);
                ddlCarModel.Items.Clear();
                ddlCarModel.Items.Insert(0, new ListItem("All Models", "0"));
            }
            if (ddlVehicleType.SelectedItem.Value == "2")
            {
                trcarMake.Style["display"] = "none";
                trcarModel.Style["display"] = "none";
                trRvType.Style["display"] = "block";
                trRvmake.Style["display"] = "block";
                trcarYear.Style["display"] = "block";



                ListItem licarYear = new ListItem();
                licarYear.Text = "Any Year";
                licarYear.Value = "0";
                ddlYear.SelectedIndex = ddlYear.Items.IndexOf(licarYear);

                ListItem liRvType = new ListItem();
                liRvType.Text = "All Types";
                liRvType.Value = "0";
                ddlRvType.SelectedIndex = ddlRvType.Items.IndexOf(liRvType);
                ddlRVMake.Items.Clear();
                ddlRVMake.Items.Insert(0, new ListItem("All Makes", "0"));
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
            GetRvModelsInfo();
        }
        catch (Exception ex)
        {
        }
    }
    private void GetAllRvMakes()
    {
        try
        {
            DataSet dsAllMakes = new DataSet();
            if (Session["RvAllMakes"] == null)
            {
                dsAllMakes = objRvMainBL.USP_GetAllMakes(0);
                Session["RvAllMakes"] = dsAllMakes;
            }
            else
            {
                dsAllMakes = Session["RvAllMakes"] as DataSet;
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void GetRvModelsInfo()
    {
        try
        {
            DataSet dsMakes = Session["RvAllMakes"] as DataSet;
            int RVTYPE = Convert.ToInt32(ddlRvType.SelectedItem.Value);
            DataView dvModel = new DataView();
            DataTable dtModel = new DataTable();
            dvModel = dsMakes.Tables[0].DefaultView;
            dvModel.RowFilter = "RVTYPE='" + RVTYPE.ToString() + "'";
            dtModel = dvModel.ToTable();
            ddlRVMake.DataSource = dtModel;
            ddlRVMake.Items.Clear();
            ddlRVMake.DataTextField = "make";
            ddlRVMake.DataValueField = "makeID";
            ddlRVMake.DataBind();
            ddlRVMake.Items.Insert(0, new ListItem("All Makes", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSearchUserDetails_Click(object sender, EventArgs e)
    {
        try
        {
            string PhoneNum = txtPhoneNumber.Text;
            string SellerName = txtCustName.Text;
            string Email = txtEmail.Text;
            int AgentName = Convert.ToInt32(ddlAgentNames.SelectedItem.Value);
            DataSet dsCarData = objdropdownBL.SmartzSearchNewByUserDetailsForDealer(PhoneNum, SellerName, Email, AgentName);
            Session["SearchCarsData"] = dsCarData;
            DataSet dsRvsData = objRvMainBL.SmartzSearchNewByRVUserDetails(PhoneNum, SellerName, Email, AgentName);
            Session["SearchRVSData"] = dsRvsData;
            tblGrdcar.Style["display"] = "block";
            divCarresults.Style["display"] = "block";
            divRvResults.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCarData.Tables[0].Rows.Count > 0)
            {
                lnkbtnCarsResCount.Text = dsCarData.Tables[0].Rows.Count.ToString() + " Car(s)";
                lnkbtnCarsResCount.Enabled = true;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing results for Car(s)";
                grdIntroInfo.Visible = true;
                grdIntroInfo.DataSource = dsCarData.Tables[0];
                grdIntroInfo.DataBind();
                string sTable = CreateTable();
                lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");

            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                lblResCount.Text = "Showing results for Car(s)";
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
                lblResCount.Visible = true;
            }
            if (dsRvsData.Tables[0].Rows.Count > 0)
            {
                lnkbtnRVSResCount.Text = dsRvsData.Tables[0].Rows.Count.ToString() + " RV(s)";
                lnkbtnRVSResCount.Enabled = true;
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
            }
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void SearchVehicleDetails_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtVehicleID.Text != "")
            {
                int CarID = Convert.ToInt32(txtVehicleID.Text);
                DataSet dsCarData = new DataSet();
                DataSet dsRvsData = new DataSet();
                dsCarData = objdropdownBL.USP_SmartzSearchByCarID(CarID);
                Session["SearchCarsData"] = dsCarData;
                dsRvsData = objRvMainBL.SmartzSearchNewByRVID(CarID);
                Session["SearchRVSData"] = dsRvsData;
                tblGrdcar.Style["display"] = "block";
                divCarresults.Style["display"] = "block";
                divRvResults.Style["display"] = "none";
                lnkbtnRVSResCount.Visible = true;
                lnkbtnCarsResCount.Visible = true;
                if (dsCarData.Tables[0].Rows.Count > 0)
                {
                    lnkbtnCarsResCount.Text = dsCarData.Tables[0].Rows.Count.ToString() + " Car(s)";
                    lnkbtnCarsResCount.Enabled = true;
                    lblResCount.Visible = true;
                    lblResCount.Text = "Showing results for Car(s)";
                    grdIntroInfo.Visible = true;
                    grdIntroInfo.DataSource = dsCarData.Tables[0];
                    grdIntroInfo.DataBind();
                    string sTable = CreateTable();
                    lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");

                }
                else
                {
                    lnkbtnCarsResCount.Text = "0 Car(s)";
                    lnkbtnCarsResCount.Enabled = false;
                    lblResCount.Text = "Showing results for Car(s)";
                    grdIntroInfo.Visible = false;
                    lblRes.Visible = true;
                    lblResCount.Visible = true;
                }
                if (dsRvsData.Tables[0].Rows.Count > 0)
                {
                    lnkbtnRVSResCount.Text = dsRvsData.Tables[0].Rows.Count.ToString() + " RV(s)";
                    lnkbtnRVSResCount.Enabled = true;
                }
                else
                {
                    lnkbtnRVSResCount.Text = "0 RV(S)";
                    lnkbtnRVSResCount.Enabled = false;
                }
                Session.Timeout = 180;
            }
            else
            {

                if (ddlVehicleType.SelectedItem.Value == "1")
                {
                    lnkbtnRVSResCount.Visible = false;
                    lnkbtnCarsResCount.Visible = true;
                    tblGrdcar.Style["display"] = "block";
                    divCarresults.Style["display"] = "block";
                    divRvResults.Style["display"] = "none";
                    string Year = ddlYear.SelectedItem.Value.ToString();
                    int MakeID = Convert.ToInt32(ddlCarMake.SelectedItem.Value);
                    int MakeModelID = Convert.ToInt32(ddlCarModel.SelectedItem.Value);
                    DataSet dsCarData = new DataSet();
                    dsCarData = objdropdownBL.SmartzSearchNewByCarDetails(MakeID, MakeModelID, Year);
                    Session["SearchCarsData"] = dsCarData;
                    if (dsCarData.Tables.Count > 0)
                    {
                        if (dsCarData.Tables[0].Rows.Count > 0)
                        {
                            lnkbtnCarsResCount.Text = dsCarData.Tables[0].Rows.Count.ToString() + " Car(s)";
                            lnkbtnCarsResCount.Enabled = false;
                            lblResCount.Visible = true;
                            lblResCount.Text = "Showing results for Car(s)";
                            lblRes.Visible = false;
                            grdIntroInfo.Visible = true;
                            grdIntroInfo.DataSource = dsCarData.Tables[0];
                            grdIntroInfo.DataBind();
                            string sTable = CreateTable();
                            lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                            lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
                        }
                        else
                        {
                            lnkbtnCarsResCount.Text = "0 Car(s)";
                            lnkbtnCarsResCount.Enabled = false;
                            grdIntroInfo.Visible = false;
                            lblRes.Visible = false;
                            lblResCount.Visible = true;
                            lblResCount.Text = "Showing results for Car(s)";
                        }
                    }
                    else
                    {
                        lnkbtnCarsResCount.Text = "0 Car(s)";
                        lnkbtnCarsResCount.Enabled = false;
                        lblResCount.Text = "Showing results for Car(s)";
                        grdIntroInfo.Visible = false;
                        lblRes.Visible = false;
                        lblResCount.Visible = true;
                    }

                }

                if (ddlVehicleType.SelectedItem.Value == "2")
                {
                    lnkbtnRVSResCount.Visible = true;
                    lnkbtnCarsResCount.Visible = false;
                    tblGrdcar.Style["display"] = "block";
                    divCarresults.Style["display"] = "none";
                    divRvResults.Style["display"] = "block";
                    string Year = ddlYear.SelectedItem.Value.ToString();
                    int MakeID = Convert.ToInt32(ddlRvType.SelectedItem.Value);
                    int MakeModelID = Convert.ToInt32(ddlRVMake.SelectedItem.Value);
                    DataSet dsRVData = new DataSet();


                    dsRVData = objRvMainBL.SmartzSearchNewByRVVehicleDetails(MakeID, MakeModelID, Year);

                    Session["SearchRVSData"] = dsRVData;
                    if (dsRVData.Tables.Count > 0)
                    {
                        if (dsRVData.Tables[0].Rows.Count > 0)
                        {
                            lnkbtnRVSResCount.Text = dsRVData.Tables[0].Rows.Count.ToString() + " RV(s)";
                            lnkbtnRVSResCount.Enabled = false;
                            lblResCount.Visible = true;
                            lblRes.Visible = false;
                            grdRVDetails.Visible = true;
                            lblResCount.Text = "Showing results for RV(s)";
                            grdRVDetails.DataSource = dsRVData.Tables[0];
                            grdRVDetails.DataBind();
                            string sTable = CreateTable();
                            lnkRVAdStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                            lnkRVAdStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
                        }
                        else
                        {
                            lnkbtnRVSResCount.Text = "0 RV(s)";
                            lnkbtnRVSResCount.Enabled = false;
                            lblResCount.Text = "Showing results for RV(s)";
                            grdRVDetails.Visible = false;
                            lblRes.Visible = false;
                            lblResCount.Visible = true;
                        }
                    }
                    else
                    {
                        lnkbtnRVSResCount.Text = "0 RV(s)";
                        lnkbtnRVSResCount.Enabled = false;
                        lblResCount.Text = "Showing results for RV(s)";
                        grdRVDetails.Visible = false;
                        lblRes.Visible = false;
                        lblResCount.Visible = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdIntroInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image ImgSaleType = (Image)e.Row.FindControl("ImgSaleType");
                HiddenField hdnSaleEnteredBy = (HiddenField)e.Row.FindControl("hdnSaleEnteredBy");
                HiddenField hdnAgentID = (HiddenField)e.Row.FindControl("hdnAgentID");
                Label lblAgent = (Label)e.Row.FindControl("lblAgent");
                HiddenField hdnAgentName = (HiddenField)e.Row.FindControl("hdnAgentName");
                HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                Label lblPhone = (Label)e.Row.FindControl("lblPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnPhoneNum");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackName.Value.ToString();
                lblPackage.Text = PackName + "($" + PackAmount + ")";
                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if (hdnStatus.Value.ToString() == "1")
                {

                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else if (hdnStatus.Value.ToString() == "2")
                {

                    ImgStatus.ImageUrl = "~/images/lock.gif";
                }
                else if (hdnStatus.Value.ToString() == "3")
                {

                    ImgStatus.ImageUrl = "~/images/icon13.png";
                }
                else if (hdnStatus.Value.ToString() == "4")
                {
                    ImgStatus.ImageUrl = "~/images/icon14.gif";
                }
                else if (hdnStatus.Value.ToString() == "5")
                {
                    ImgStatus.ImageUrl = "~/images/red_x.png";
                }
                if (hdnAgentID.Value.ToString() != "0")
                {
                    lblAgent.Text = objGeneralFunc.WrapTextByMaxCharacters(hdnAgentName.Value.ToString(), 10);
                }
                else
                {
                    lblAgent.Text = "";
                }
                if (hdnSaleEnteredBy.Value == "")
                {
                    ImgSaleType.ImageUrl = "~/images/Internet-icon.png";
                }
                else
                {
                    ImgSaleType.ImageUrl = "~/images/phone_icon.png";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdIntroInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCar")
            {
                string postingID = e.CommandArgument.ToString();
                Session["PostingID"] = postingID;
                Session["RedirectFrom"] = 1;
                Response.Redirect("CustomerView.aspx");
            }
            if (e.CommandName == "EditCustomer")
            {
                string UID = e.CommandArgument.ToString();
                Session["SelectUID"] = UID;
                Session["RedirectFrom"] = 1;
                Response.Redirect("MultiCars.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    protected void grdRVDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditRV")
            {
                string postingID = e.CommandArgument.ToString();
                Session["RvPostingID"] = postingID;
                Session["RedirectFrom"] = 1;
                Response.Redirect("RvCustomerView.aspx");
            }
            if (e.CommandName == "EditCustomer")
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkCarIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkCarIDSort.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkCarIDSort.Text = "Car ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkCarIDSort.Text = "Car ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkCarIDSort.Text = "Car ID &#8659";
            }

            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkPostedSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "dateOfPosting";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPostedSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPostedSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPostedSort.Text = "Posted Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPostedSort.Text = "Posted Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkAgentSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "American_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkAgentSort.Text = "Agent &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentSort.Text = "Agent &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkYearSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "yearOfMake";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkYearSort.Text = "Year &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkYearSort.Text = "Year &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkMakeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkMakeSort.Text = "Make &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkMakeSort.Text = "Make &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkModelSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "model";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkModelSort.Text = "Model &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkModelSort.Text = "Model &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkModelSort.Text = "Model &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkModelSort.Text = "Model &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkPackageSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Price";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPackageSort.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPackageSort.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPackageSort.Text = "Package &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPackageSort.Text = "Package &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkNameSort.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkNameSort.Text = "Name &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkPhoneSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "phone";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Reg Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Reg Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkPhoneSort.Text = "Reg Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkPhoneSort.Text = "Reg Phone &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkEmailSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "email";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkEmailSort.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkEmailSort.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkEmailSort.Text = "Email &#8659";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkEmailSort.Text = "Email &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Adstatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkStatusSort.Text = "Ad St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkStatusSort.Text = "Ad St &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkSaleDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchCarsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SaleDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkSaleDateSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkSaleDateSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkSaleDateSort.Text = "Sale Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkSaleDateSort.Text = "Sale Dt &#8659";
            }

            lnkCarIDSort.Text = "Car ID &darr; &uarr;";
            lnkPostedSort.Text = "Posted Dt &darr; &uarr;";
            lnkAgentSort.Text = "Agent &darr; &uarr;";
            lnkYearSort.Text = "Year &darr; &uarr;";
            lnkMakeSort.Text = "Make &darr; &uarr;";
            lnkModelSort.Text = "Model &darr; &uarr;";
            lnkPackageSort.Text = "Package &darr; &uarr;";
            lnkNameSort.Text = "Name &darr; &uarr;";
            lnkPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkEmailSort.Text = "Email &darr; &uarr;";
            lnkStatusSort.Text = "Ad St &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdIntroInfo, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }






    protected void lnkBtnRvIDSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "carid";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvIDSort.Text = "RVID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvIDSort.Text = "RVID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvIDSort.Text = "RVID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvIDSort.Text = "RVID &#8659";
            }

            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvpostedDtSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "dateOfPosting";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvpostedDtSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvpostedDtSort.Text = "Posted Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvpostedDtSort.Text = "Posted Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvpostedDtSort.Text = "Posted Dt &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvAgentSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "American_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvAgentSort.Text = "Agent &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvAgentSort.Text = "Agent &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvAgentSort.Text = "Agent &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvYearSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "yearOfMake";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvYearSort.Text = "Year &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvYearSort.Text = "Year &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvYearSort.Text = "Year &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkBtnRvMakeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvMakeSort.Text = "Make &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvMakeSort.Text = "Make &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvMakeSort.Text = "Make &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkRvTypeSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkRvTypeSort.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkRvTypeSort.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkRvTypeSort.Text = "Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkRvTypeSort.Text = "Type &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRvPackageSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Price";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPackageSort.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPackageSort.Text = "Package &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvPackageSort.Text = "Package &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvPackageSort.Text = "Package &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRVNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVNameSort.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRVNameSort.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVNameSort.Text = "Name &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnRVPhoneSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "phone";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVPhoneSort.Text = "Reg Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVPhoneSort.Text = "Reg Phone &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRVPhoneSort.Text = "Reg Phone &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRVPhoneSort.Text = "Reg Phone &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkBtnRvEmailSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "email";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvEmailSort.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvEmailSort.Text = "Email &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkBtnRvEmailSort.Text = "Email &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkBtnRvEmailSort.Text = "Email &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkRVAdStatusSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Adstatus";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkRVAdStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkRVAdStatusSort.Text = "Ad St &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkRVAdStatusSort.Text = "Ad St &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkRVAdStatusSort.Text = "Ad St &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkbtnRvSaleDateSort.Text = "Sale Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRvSaleDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["SearchRVSData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SaleDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSaleDateSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSaleDateSort.Text = "Sale Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnRvSaleDateSort.Text = "Sale Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnRvSaleDateSort.Text = "Sale Dt &#8659";
            }

            lnkBtnRvIDSort.Text = "RVID &darr; &uarr;";
            lnkbtnRvpostedDtSort.Text = "Posted Dt &darr; &uarr;";
            lnkbtnRvAgentSort.Text = "Agent &darr; &uarr;";
            lnkbtnRvYearSort.Text = "Year &darr; &uarr;";
            lnkBtnRvMakeSort.Text = "Make &darr; &uarr;";
            lnkRvTypeSort.Text = "Type &darr; &uarr;";
            lnkbtnRvPackageSort.Text = "Package &darr; &uarr;";
            lnkbtnRVNameSort.Text = "Name &darr; &uarr;";
            lnkbtnRVPhoneSort.Text = "Reg Phone &darr; &uarr;";
            lnkBtnRvEmailSort.Text = "Email &darr; &uarr;";
            lnkRVAdStatusSort.Text = "Ad St &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdRVDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void grdRVDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image ImgSaleType = (Image)e.Row.FindControl("ImgRVSaleType");
                HiddenField hdnSaleEnteredBy = (HiddenField)e.Row.FindControl("hdnRVSaleEnteredBy");
                HiddenField hdnAgentID = (HiddenField)e.Row.FindControl("hdnRVAgentID");
                Label lblAgent = (Label)e.Row.FindControl("lblRVAgent");
                HiddenField hdnAgentName = (HiddenField)e.Row.FindControl("hdnRVAgentName");
                HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnRVPackName");
                HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnRVPackCost");
                Label lblPackage = (Label)e.Row.FindControl("lblRVPackage");
                Label lblPhone = (Label)e.Row.FindControl("lblRVPhone");
                HiddenField hdnPhoneNum = (HiddenField)e.Row.FindControl("hdnRVPhoneNum");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnRVStatus");

                Image ImgStatus = (Image)e.Row.FindControl("ImgRVStatus");
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackName.Value.ToString();
                lblPackage.Text = PackName + "($" + PackAmount + ")";
                if (hdnPhoneNum.Value.ToString() == "")
                {
                    lblPhone.Text = "";
                }
                else
                {
                    lblPhone.Text = objGeneralFunc.filPhnm(hdnPhoneNum.Value);
                }
                if (hdnStatus.Value.ToString() == "1")
                {

                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else if (hdnStatus.Value.ToString() == "2")
                {

                    ImgStatus.ImageUrl = "~/images/lock.gif";
                }
                else if (hdnStatus.Value.ToString() == "3")
                {

                    ImgStatus.ImageUrl = "~/images/icon13.png";
                }
                else if (hdnStatus.Value.ToString() == "4")
                {
                    ImgStatus.ImageUrl = "~/images/icon14.gif";
                }
                else if (hdnStatus.Value.ToString() == "5")
                {
                    ImgStatus.ImageUrl = "~/images/red_x.png";
                }


                if (hdnAgentID.Value.ToString() != "0")
                {
                    lblAgent.Text = objGeneralFunc.WrapTextByMaxCharacters(hdnAgentName.Value.ToString(), 10);
                }
                else
                {
                    lblAgent.Text = "";
                }
                if (hdnSaleEnteredBy.Value == "")
                {
                    ImgSaleType.ImageUrl = "~/images/Internet-icon.png";
                }
                else
                {
                    ImgSaleType.ImageUrl = "~/images/phone_icon.png";
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkbtnCarsResCount_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarData = Session["SearchCarsData"] as DataSet;
            DataSet dsRvsData = Session["SearchRVSData"] as DataSet;
            tblGrdcar.Style["display"] = "block";
            divCarresults.Style["display"] = "block";
            divRvResults.Style["display"] = "none";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCarData.Tables[0].Rows.Count > 0)
            {
                lnkbtnCarsResCount.Text = dsCarData.Tables[0].Rows.Count.ToString() + " Car(s)";
                lnkbtnCarsResCount.Enabled = true;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing results for Car(s)";
                grdIntroInfo.Visible = true;
                grdIntroInfo.DataSource = dsCarData.Tables[0];
                grdIntroInfo.DataBind();
                string sTable = CreateTable();
                lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");

            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
                lblResCount.Text = "Showing results for Car(s)";
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
                lblResCount.Visible = true;
            }
            if (dsRvsData.Tables[0].Rows.Count > 0)
            {
                lnkbtnRVSResCount.Text = dsRvsData.Tables[0].Rows.Count.ToString() + " RV(s)";
                lnkbtnRVSResCount.Enabled = true;
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnRVSResCount_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsCarData = Session["SearchCarsData"] as DataSet;
            DataSet dsRvsData = Session["SearchRVSData"] as DataSet;
            tblGrdcar.Style["display"] = "block";
            divCarresults.Style["display"] = "none";
            divRvResults.Style["display"] = "block";
            lnkbtnRVSResCount.Visible = true;
            lnkbtnCarsResCount.Visible = true;
            if (dsCarData.Tables[0].Rows.Count > 0)
            {
                lnkbtnCarsResCount.Text = dsCarData.Tables[0].Rows.Count.ToString() + " Car(s)";
                lnkbtnCarsResCount.Enabled = true;
            }
            else
            {
                lnkbtnCarsResCount.Text = "0 Car(s)";
                lnkbtnCarsResCount.Enabled = false;
            }
            if (dsRvsData.Tables[0].Rows.Count > 0)
            {
                lnkbtnRVSResCount.Text = dsRvsData.Tables[0].Rows.Count.ToString() + " RV(s)";
                lnkbtnRVSResCount.Enabled = true;
                lblResCount.Visible = true;
                lblResCount.Text = "Showing results for RV(s)";
                grdRVDetails.Visible = true;
                grdRVDetails.DataSource = dsRvsData.Tables[0];
                grdRVDetails.DataBind();
                string sTable = CreateTable();
                lnkRVAdStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lnkRVAdStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
            }
            else
            {
                lnkbtnRVSResCount.Text = "0 RV(S)";
                lnkbtnRVSResCount.Enabled = false;
                lblResCount.Text = "Showing results for Car(s)";
                grdRVDetails.Visible = false;
                lblRes.Visible = true;
                lblResCount.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    private string CreateTable()
    {
        string strTransaction = string.Empty;
        strTransaction = "<table width=\"120px\" id=\"SalesStatus\" style=\"display: block; background-color:#F3D9F6;border:2px;border-color:Black;height:110px \">";

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
        strTransaction += "Preliminary:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/lock.gif\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Withdraw:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/icon13.png\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";
        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Sold:";
        strTransaction += "</td>";
        strTransaction += " <td>";
        strTransaction += " <img src=\"images/icon14.gif\" />";
        strTransaction += "</td>";
        strTransaction += " </tr>";

        strTransaction += " <tr id=\"CampaignsBody1\">";
        strTransaction += " <td style=\"padding-left:10px;\">";
        strTransaction += "Admin Cancel:";
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
}
