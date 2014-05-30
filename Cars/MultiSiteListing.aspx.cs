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

public partial class MultiSiteListing : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet CarsDetails = new DataSet();
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
                DataSet dsListDetails = objdropdownBL.USP_SmartzPendingMultiSiteListing();
                Session["dsListDetails"] = dsListDetails;
                if (dsListDetails.Tables.Count > 0)
                {
                    if (dsListDetails.Tables[0].Rows.Count > 0)
                    {
                        lblRes.Visible = false;
                        grdListInfo.Visible = true;
                        grdListInfo.DataSource = dsListDetails.Tables[0];
                        grdListInfo.DataBind();
                        lblRecordsCount.Visible = true;
                        lblRecordsCount.Text = dsListDetails.Tables[0].Rows.Count.ToString() + " Records found";
                        divCarIDData.Style["display"] = "none";
                        divExistingUrls.Style["display"] = "none";
                        divNewUrls.Style["display"] = "none";
                        divPendUrl.Style["display"] = "none";
                    }
                    else
                    {
                        grdListInfo.Visible = false;
                        lblRes.Visible = true;
                        lblRes.Text = "Records not found";
                        lblRecordsCount.Visible = false;
                        divCarIDData.Style["display"] = "none";
                        divExistingUrls.Style["display"] = "none";
                        divNewUrls.Style["display"] = "none";
                        divPendUrl.Style["display"] = "none";
                    }
                }
                else
                {
                    grdListInfo.Visible = false;
                    lblRes.Visible = true;
                    lblRes.Text = "Records not found";
                    lblRecordsCount.Visible = false;
                    divCarIDData.Style["display"] = "none";
                    divExistingUrls.Style["display"] = "none";
                    divNewUrls.Style["display"] = "none";
                    divPendUrl.Style["display"] = "none";
                }
                Session.Timeout = 180;
            }
        }
    }

    protected void grdListInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            DataSet dsListDetails = Session["dsListDetails"] as DataSet;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnfUpListCount = (HiddenField)e.Row.FindControl("hdnfUpListCount");
                Label lblPendListCount = (Label)e.Row.FindControl("lblPendListCount");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
                HiddenField hdnPackName = (HiddenField)e.Row.FindControl("hdnPackName");
                HiddenField hdnPackCost = (HiddenField)e.Row.FindControl("hdnPackCost");
                Label lblPackage = (Label)e.Row.FindControl("lblPackage");
                Image ImgStatus = (Image)e.Row.FindControl("ImgStatus");

                int TotCount = Convert.ToInt32(dsListDetails.Tables[1].Rows[0]["TotalSites"].ToString());
                int PendCount = TotCount - Convert.ToInt32(hdnfUpListCount.Value);
                lblPendListCount.Text = PendCount.ToString();

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
                Double PackCost = new Double();
                PackCost = Convert.ToDouble(hdnPackCost.Value.ToString());
                string PackAmount = string.Format("{0:0.00}", PackCost).ToString();
                string PackName = hdnPackName.Value.ToString();
                lblPackage.Text = PackName + "($" + PackAmount + ")";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdListInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditList")
            {
                LinkButton lb = (LinkButton)e.CommandSource;
                string textBoxValue = ((LinkButton)lb.Parent.FindControl("lnkCarID")).Text;
                string postingID = e.CommandArgument.ToString();
                txtCarID.Text = textBoxValue;
                int CarID = Convert.ToInt32(txtCarID.Text);
                DataSet dsCarData = objdropdownBL.USP_SmartzPendListSearchByCarID(CarID);
                Session["PendSearchByCarID"] = dsCarData;
                GetDataBind(dsCarData);
                Session.Timeout = 180;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdExistUrl_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnUrlStatus = (HiddenField)e.Row.FindControl("hdnUrlStatus");
                CheckBox chkbxUrlStatus = (CheckBox)e.Row.FindControl("chkbxUrlStatus");
                HiddenField hdnUrlToNav = (HiddenField)e.Row.FindControl("hdnUrlToNav");
                HyperLink htlnkURLListed = (HyperLink)e.Row.FindControl("htlnkURLListed");
                if (hdnUrlStatus.Value == "True")
                {
                    chkbxUrlStatus.Checked = true;
                }
                else
                {
                    chkbxUrlStatus.Checked = false;
                    htlnkURLListed.Enabled = false;
                }
                //htlnkURLListed.NavigateUrl = hdnUrlToNav.Value.ToString();
                //htlnkURLListed.Target = "blank";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnGoByCarID_Click(object sender, EventArgs e)
    {
        try
        {
            int CarID = Convert.ToInt32(txtCarID.Text);
            DataSet dsCarData = objdropdownBL.USP_SmartzPendListSearchByCarID(CarID);
            Session["PendSearchByCarID"] = dsCarData;
            GetDataBind(dsCarData);
            Session.Timeout = 180;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void GetDataBind(DataSet dsCarData)
    {
        try
        {
            if (dsCarData.Tables.Count > 0)
            {
                if (dsCarData.Tables[0].Rows.Count > 0)
                {
                    divCarIDData.Style["display"] = "block";
                    divExistingUrls.Style["display"] = "block";
                    divNewUrls.Style["display"] = "block";
                    divPendUrl.Style["display"] = "block";

                    lblSelCarID.Text = dsCarData.Tables[0].Rows[0]["carid"].ToString();

                    if (dsCarData.Tables[0].Rows[0]["BrandCode"].ToString().Trim() == "" || dsCarData.Tables[0].Rows[0]["BrandCode"].ToString().Trim()=="NULL")
                    {
                        lblSelCarID.Text = lblSelCarID.Text + " <b>(UCE)</b>";
                    }
                    else
                    {
                        lblSelCarID.Text = lblSelCarID.Text + " <b>(" + dsCarData.Tables[0].Rows[0]["BrandCode"].ToString().Trim() + ")</b>";
                    }

                    DateTime PostDate = Convert.ToDateTime(dsCarData.Tables[0].Rows[0]["dateOfPosting"].ToString());
                    lblListDate.Text = PostDate.ToString("MM/dd/yyyy");
                    lblAdStatus.Text = dsCarData.Tables[0].Rows[0]["AdStatusName"].ToString();

                    lblListCustName.Text = dsCarData.Tables[0].Rows[0]["Name"].ToString();
                    lblListYear.Text = dsCarData.Tables[0].Rows[0]["yearOfMake"].ToString();
                    lblListMake.Text = dsCarData.Tables[0].Rows[0]["make"].ToString();
                    lblListModel.Text = dsCarData.Tables[0].Rows[0]["model"].ToString();

                    if (dsCarData.Tables[0].Rows[0]["mileage"].ToString() != "0.00")
                    {
                        lblMi.Visible = true;
                        lblListMileage.Text = string.Format("{0:0}", Convert.ToDouble(dsCarData.Tables[0].Rows[0]["mileage"].ToString()));
                    }
                    else
                    {
                        lblMi.Visible = false;
                        lblListMileage.Text = "Unspecified";
                    }
                    if (dsCarData.Tables[0].Rows[0]["price"].ToString() != "0.0000")
                    {
                        lblListPrice.Text = "$" + string.Format("{0:0}", Convert.ToDouble(dsCarData.Tables[0].Rows[0]["price"].ToString()));
                    }
                    else
                    {
                        lblListPrice.Text = "Unspecified";
                    }
                    // window.execScript("report_back('Printing complete!')", "JScript");
                    //string x = "javascript: hideSpinner()";
                    //Page.ClientScript.RegisterClientScriptBlock();
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "function", "sample();",true);
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "sample();", true);
                    //lblListPrice.Attributes.Add()
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "sample();", true);
                    lblMultiListUpdateCount.Text = dsCarData.Tables[0].Rows[0]["ListCount"].ToString();
                    lblMultiUpBy.Text = objGeneralFunc.GetSmartzUser(dsCarData.Tables[0].Rows[0]["RecentUrlPostBy"].ToString());
                    if (dsCarData.Tables[0].Rows[0]["RecentUrlPostDate"].ToString() != "")
                    {
                        DateTime updatedate = Convert.ToDateTime(dsCarData.Tables[0].Rows[0]["RecentUrlPostDate"].ToString());
                        lblMultiUpDate.Text = updatedate.ToString("MM/dd/yyyy");
                    }
                    if (dsCarData.Tables[1].Rows.Count > 0)
                    {
                        lblExistUrlRes.Visible = false;
                        grdExistUrl.Visible = true;
                        grdExistUrl.DataSource = dsCarData.Tables[1];
                        grdExistUrl.DataBind();
                    }
                    else
                    {
                        lblExistUrlRes.Visible = true;
                        grdExistUrl.Visible = false;
                        lblExistUrlRes.Text = "Records not found";
                    }
                    if (dsCarData.Tables[3].Rows.Count > 0)
                    {
                        lblPendingCount.Visible = false;
                        grdPendSites.Visible = true;
                        grdPendSites.DataSource = dsCarData.Tables[3];
                        grdPendSites.DataBind();
                    }
                    else
                    {
                        lblPendingCount.Visible = true;
                        grdPendSites.Visible = false;
                        lblPendingCount.Text = "Records not found";
                    }
                }
                else
                {
                    grdExistUrl.Visible = false;
                    lblExistUrlRes.Visible = true;
                    lblExistUrlRes.Text = "Records not found";
                    lblSearchCarIDRes.Visible = true;
                    lblSearchCarIDRes.Text = "Records not found";
                    grdPendSites.Visible = false;
                    lblPendingCount.Visible = true;
                    lblPendingCount.Text = "Records not found";
                    divCarIDData.Style["display"] = "block";
                    divExistingUrls.Style["display"] = "block";
                    divNewUrls.Style["display"] = "block";
                    divPendUrl.Style["display"] = "block";
                }

            }
            else
            {
                grdExistUrl.Visible = false;
                lblExistUrlRes.Visible = true;
                lblExistUrlRes.Text = "Records not found";
                lblSearchCarIDRes.Visible = true;
                lblSearchCarIDRes.Text = "Records not found";
                grdPendSites.Visible = false;
                lblPendingCount.Visible = true;
                lblPendingCount.Text = "Records not found";
                divCarIDData.Style["display"] = "block";
                divExistingUrls.Style["display"] = "block";
                divNewUrls.Style["display"] = "block";
                divPendUrl.Style["display"] = "block";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnNewUrlUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int CarIDs = Convert.ToInt32(lblSelCarID.Text);
            string StrRep = txtUrlForUpload.Text.Replace("\r", "");
            string[] str12 = StrRep.Split('\n');
            ArrayList str = new ArrayList();
            foreach (string s in str12)
                str.Add(s);

            ArrayList strMatch = new ArrayList();


            var sList = new ArrayList();

            for (int i = 0; i < str.Count; i++)
            {
                if (sList.Contains(str[i].ToString().Trim()) == false)
                {
                    sList.Add(str[i].ToString().Trim());
                }
            }


            for (int c = 0; c < sList.Count; c++)
            {
                if (sList[c].ToString().Trim() == "")
                {
                    sList.RemoveAt(c);
                }
            }
            ArrayList sNewlist = new ArrayList();
            for (int d = 0; d < sList.Count; d++)
            {
                string[] strNew = sList[d].ToString().Split(' ');

                if (strNew.Length > 0)
                {
                    string sattach = string.Empty;
                    for (int s = 0; s < strNew.Length; s++)
                    {
                        if (s == 0)
                        {
                            sattach = strNew[s].Trim();
                        }
                        else
                        {
                            sattach = sattach + " " + strNew[s].Trim();
                        }
                    }
                    sNewlist.Add(sattach);
                }
                else
                {
                    sNewlist.Add(sList[d]);
                }
            }
            str = sNewlist;

            DataSet dsMasterSites = Session["PendSearchByCarID"] as DataSet;
            ArrayList strFailed = new ArrayList();
            for (int j = 0; j < str.Count; j++)
            {
                string FullUrl = str[j].ToString().Replace("http://", "");
                string[] Domain = FullUrl.Split('/');
                DataSet dsChkDomain = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(Domain[0].ToString());
                if (dsChkDomain.Tables[0].Rows.Count > 0)
                {
                    int SiteID = Convert.ToInt32(dsChkDomain.Tables[0].Rows[0]["SiteID"].ToString());
                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                    bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarIDs, FullUrl, SiteID, UID);
                }
                else
                {
                    string[] Middle = Domain[0].Split('.');
                    DataSet dsDomainMiddle = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(Middle[1].ToString());
                    if (dsDomainMiddle.Tables[0].Rows.Count > 0)
                    {
                        int SiteID = Convert.ToInt32(dsDomainMiddle.Tables[0].Rows[0]["SiteID"].ToString());
                        int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                        bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarIDs, FullUrl, SiteID, UID);
                    }
                    else
                    {
                        string First8Char = Domain[0].Substring(0, 8);
                        DataSet dsFirst8Char = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(First8Char);
                        if (dsFirst8Char.Tables[0].Rows.Count > 0)
                        {
                            int SiteID = Convert.ToInt32(dsFirst8Char.Tables[0].Rows[0]["SiteID"].ToString());
                            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                            bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarIDs, FullUrl, SiteID, UID);
                        }
                        else
                        {
                            if (Middle.Length > 2)
                            {
                                DataSet dsDomainMiddleThird = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(Middle[2].ToString());
                                if (dsDomainMiddleThird.Tables[0].Rows.Count > 0)
                                {
                                    int SiteID = Convert.ToInt32(dsDomainMiddleThird.Tables[0].Rows[0]["SiteID"].ToString());
                                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                    bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarIDs, FullUrl, SiteID, UID);
                                }
                            }
                            else
                            {
                                strFailed.Add(str[j].ToString());
                            }
                        }

                    }

                }
            }
            Session.Timeout = 180;
            lblErrSuccess.Visible = true;
            lblErrSuccess.Text = "Saved successfully";
            if (strFailed.Count > 0)
            {
                lblErrfailures.Visible = true;
                lblErrfailures.Text = "Failed URL(s)<br />";
                for (int f = 0; f < strFailed.Count; f++)
                {
                    lblErrfailures.Text = lblErrfailures.Text + strFailed[f] + "<br />";
                }
            }
            else
            {
                lblErrfailures.Visible = false;
            }
            mpealteruser.Show();

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
            txtUrlForUpload.Text = "";
            int CarID = Convert.ToInt32(txtCarID.Text);
            DataSet dsCarData = objdropdownBL.USP_SmartzPendListSearchByCarID(CarID);
            Session["PendSearchByCarID"] = dsCarData;
            GetDataBind(dsCarData);
            Session.Timeout = 180;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnUpdateStatus_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow gvr in grdExistUrl.Rows)
            {
                HiddenField hdnUrlID = (HiddenField)gvr.FindControl("hdnUrlID");
                CheckBox chkbxUrlStatus = (CheckBox)gvr.FindControl("chkbxUrlStatus");
                int Status;
                int UrlIDs = Convert.ToInt32(hdnUrlID.Value);
                if (chkbxUrlStatus.Checked == true)
                {
                    Status = 1;
                }
                else
                {
                    Status = 0;
                }
                bool bnew = objdropdownBL.USP_SmartzUpdateSiteUrlStatus(Status, UrlIDs);
            }
            Session.Timeout = 180;
            lblErrSuccess.Visible = true;
            lblErrSuccess.Text = "Updated successfully";
            lblErrfailures.Visible = false;
            mpealteruser.Show();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
