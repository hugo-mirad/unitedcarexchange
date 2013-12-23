
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

public partial class Search : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
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
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();

                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showSpinner();", true);

                FillAgents();
                GetAllModels();
                GetMakes();
                FillPackage();
                string PhoneNum = txtPhoneNumber.Text;
                string SellerName = txtCustName.Text;
                string Email = txtEmail.Text;
                int AgentName = Convert.ToInt32(ddlAgentNames.SelectedItem.Value);
                int makeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value.ToString());
                string YearOfMake = ddlYear.SelectedItem.Value.ToString();
                int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value.ToString());
                GetDetails(PhoneNum, SellerName, Email, makeModelID, YearOfMake, PackageID, AgentName);
                lblResHead.Text = "Most recent 500 customers ";
                Session.Timeout = 180;
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "hideSpinner();", true); 
                // spinner1.Style["display"] = "none";
            }
        }
    }

    private void FillAgents()
    {
        ddlAgentNames.DataSource = dsDropDown.Tables[15];
        ddlAgentNames.DataTextField = "American_Name";
        ddlAgentNames.DataValueField = "Sale_Agent_Id";
        ddlAgentNames.DataBind();
        ddlAgentNames.Items.Insert(0, new ListItem("Unknown", "0"));
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
            ddlMake.Items.Insert(0, new ListItem("All Makes", "0"));
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
            ddlModel.Items.Insert(0, new ListItem("All Models", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            txtCarID.Text = "";
            string PhoneNum = txtPhoneNumber.Text;
            string SellerName = txtCustName.Text;
            string Email = txtEmail.Text;
            int AgentName = Convert.ToInt32(ddlAgentNames.SelectedItem.Value);
            int makeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value.ToString());
            string YearOfMake = ddlYear.SelectedItem.Value.ToString();
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value.ToString());
            GetDetails(PhoneNum, SellerName, Email, makeModelID, YearOfMake, PackageID, AgentName);
           
            lblResHead.Text = "Search Results- Top 500";
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetDetails(string PhoneNum, string SellerName, string Email, int makeModelID, string YearOfMake, int PackageID, int AgentName)
    {
        try
        {
            int MakeID = Convert.ToInt32(ddlMake.SelectedItem.Value.ToString());
            DataSet dsCarData = objdropdownBL.USP_SmartzSearchDetails(PhoneNum, SellerName, Email, makeModelID, YearOfMake, PackageID, MakeID, AgentName);
            Session["SearchData"] = dsCarData;
            if (dsCarData.Tables.Count > 0)
            {
                if (dsCarData.Tables[0].Rows.Count > 0)
                {
                    lblResCount.Visible = true;
                    lblRes.Visible = false;
                    grdIntroInfo.Visible = true;
                    lblResCount.Text = dsCarData.Tables[0].Rows.Count + " Records found";
                    grdIntroInfo.DataSource = dsCarData.Tables[0];
                    grdIntroInfo.DataBind();
                    string sTable = CreateTable();
                    lnkStatusSort.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                    lnkStatusSort.Attributes.Add("onmouseout", "return nd(4000);");
                }
                else
                {
                    lblRes.Text = "No records found";
                    grdIntroInfo.Visible = false;
                    lblRes.Visible = true;
                    lblResCount.Visible = false;
                }
            }
            else
            {
                lblRes.Text = "No records found";
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
                lblResCount.Visible = false;
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
                    //lblStatus.Text = "Active";
                    ImgStatus.ImageUrl = "~/images/check.gif";
                }
                else if (hdnStatus.Value.ToString() == "2")
                {
                    //lblStatus.Text = "Inactive";
                    ImgStatus.ImageUrl = "~/images/lock.gif";
                }
                else if (hdnStatus.Value.ToString() == "3")
                {
                    //lblStatus.Text = "Inactive";
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
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        try
        {
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtCustName.Text = "";

            ListItem liagent = new ListItem();
            liagent.Text = "Unknown";
            liagent.Value = "0";
            ddlAgentNames.SelectedIndex = ddlAgentNames.Items.IndexOf(liagent);

            ListItem li1 = new ListItem();
            li1.Text = "All Makes";
            li1.Value = "0";
            ddlMake.SelectedIndex = ddlMake.Items.IndexOf(li1);

            GetModelsInfo();

            ListItem li2 = new ListItem();
            li2.Text = "Any Year";
            li2.Value = "0";
            ddlYear.SelectedIndex = ddlYear.Items.IndexOf(li2);

            ListItem li3 = new ListItem();
            li3.Text = "All Packages";
            li3.Value = "0";
            ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(li3);

            txtCarID.Text = "";
            string PhoneNum = txtPhoneNumber.Text;
            string SellerName = txtCustName.Text;
            string Email = txtEmail.Text;
            int AgentName = Convert.ToInt32(ddlAgentNames.SelectedItem.Value);
            int makeModelID = Convert.ToInt32(ddlModel.SelectedItem.Value.ToString());
            string YearOfMake = ddlYear.SelectedItem.Value.ToString();
            int PackageID = Convert.ToInt32(ddlPackage.SelectedItem.Value.ToString());
            GetDetails(PhoneNum, SellerName, Email, makeModelID, YearOfMake, PackageID, AgentName);
            lblResHead.Text = "Search Results- Top 500";
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Search.aspx");
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
                Response.Redirect("CustomerViewNewForm.aspx");
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
    protected void btnSearchCarID_Click(object sender, EventArgs e)
    {
        try
        {
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtCustName.Text = "";

            ListItem liagent = new ListItem();
            liagent.Text = "Unknown";
            liagent.Value = "0";
            ddlAgentNames.SelectedIndex = ddlAgentNames.Items.IndexOf(liagent);

            //txtAgentName.Text = "";
            ListItem li1 = new ListItem();
            li1.Text = "All Makes";
            li1.Value = "0";
            ddlMake.SelectedIndex = ddlMake.Items.IndexOf(li1);

            GetModelsInfo();
            //ListItem li4 = new ListItem();
            //li4.Text = "All Models";
            //li4.Value = "0";
            //ddlModel.SelectedIndex = ddlModel.Items.IndexOf(li4);

            ListItem li2 = new ListItem();
            li2.Text = "Any Year";
            li2.Value = "0";
            ddlYear.SelectedIndex = ddlYear.Items.IndexOf(li2);

            //FillPackage();
            ListItem li3 = new ListItem();
            li3.Text = "All Packages";
            li3.Value = "0";
            ddlPackage.SelectedIndex = ddlPackage.Items.IndexOf(li3);

            int CarID = Convert.ToInt32(txtCarID.Text);

            DataSet dsCarsData = objdropdownBL.USP_SmartzSearchByCarID(CarID);

            Session.Timeout = 180;
            Session["SearchData"] = dsCarsData;
            if (dsCarsData.Tables.Count > 0)
            {
                if (dsCarsData.Tables[0].Rows.Count > 0)
                {
                    lblResCount.Visible = true;
                    lblRes.Visible = false;
                    grdIntroInfo.Visible = true;
                    lblResCount.Text = dsCarsData.Tables[0].Rows.Count + " Records found";
                    grdIntroInfo.DataSource = dsCarsData.Tables[0];
                    grdIntroInfo.DataBind();
                }
                else
                {
                    lblRes.Text = "No records found";
                    grdIntroInfo.Visible = false;
                    lblRes.Visible = true;
                    lblResCount.Visible = false;
                }
            }
            else
            {
                lblRes.Text = "No records found";
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
                lblResCount.Visible = false;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
            ds = Session["SearchData"] as DataSet;
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
    protected void ImgbtnExcel_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataSet dsExcelSearch = new DataSet();
            dsExcelSearch = Session["SearchData"] as DataSet;
            string SelectedTyepe = "SearchResults";
            if (dsExcelSearch.Tables[0].Rows.Count > 0)
            {
                DataSetToExcel.Convert(dsExcelSearch, Response, SelectedTyepe);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
