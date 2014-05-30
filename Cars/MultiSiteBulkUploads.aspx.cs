
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
public partial class MultiSiteBulkUploads : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
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
                if (Session["MultiSiteBulkRedirectFrom"].ToString() == "Cars")
                {
                    lblRedirectBy.Text = "Upload car(s) data";
                    GetAllBrands();
                    ddlBrandName.Visible = true;
                    lblBrand.Text = "Brand";
                    lblBrand.Visible = true;
                }
                else if (Session["MultiSiteBulkRedirectFrom"].ToString() == "Rvs")
                {
                    lblRedirectBy.Text = "Upload rv(s) data";
                    ddlBrandName.Visible = false;
                    lblBrand.Visible = false;
                }
                // lblRedirectBy.
            }
        }
    }

    private void GetAllBrands()
    {
        try
        {
            DataSet dsBrands = new DataSet();
            dsBrands = objdropdownBL.GetAllBrands();
            ddlBrandName.DataSource = dsBrands;
            ddlBrandName.DataTextField = "BrandCode";
            ddlBrandName.DataValueField = "BrnadId";
            ddlBrandName.DataBind();
            ddlBrandName.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["MultiSiteBulkRedirectFrom"].ToString() == "Cars")
            {
                DataSet ds = new DataSet();
                ds.Tables.Add("MultiData");
                ds.Tables[0].Columns.Add("CarID");
                ds.Tables[0].Columns.Add("FullUrl");
                ds.Tables[0].Columns.Add("SiteID");
                ds.Tables[0].Columns.Add("UID");
                string strAlltext = txtMultiSiteBulkUpload.Text.Replace("\r", "");
                string[] strAllMails = strAlltext.Split('\n');
                ArrayList str = new ArrayList();
                ArrayList strFailed = new ArrayList();
                foreach (string s in strAllMails)
                    str.Add(s);
                int j = 0;
                for (int i = 0; i < str.Count; i++)
                {
                    if (str[i].ToString().Trim() != "")
                    {
                        string StrMail = string.Empty;
                        StrMail = str[i].ToString();
                        string[] StrMailSplit = StrMail.Split(' ');
                        ArrayList str1 = new ArrayList();
                        foreach (string s in StrMailSplit)
                            str1.Add(s);
                        if (str1.Count > 0 && str1.Count == 2)
                        {
                            if (GeneralFunc.IsNumeric(StrMailSplit[0].ToString().Trim()) == true)
                            {
                                int CarID = Convert.ToInt32(StrMailSplit[0].ToString().Trim());
                                DataSet dsCarIDExists = objdropdownBL.SmartzCheckCarIDExistsForMultiSiteUploads(CarID);
                                if (dsCarIDExists.Tables[0].Rows[0]["Result"].ToString() == "Yes")
                                {
                                    string FullUrl = StrMailSplit[1].ToString().Replace("http://", "");
                                    string[] Domain = FullUrl.Split('/');
                                    ArrayList str2 = new ArrayList();
                                    foreach (string s in Domain)
                                        str2.Add(s);
                                    if (str2.Count > 1)
                                    {
                                        DataSet dsChkDomain = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(Domain[0].ToString());
                                        if (dsChkDomain.Tables[0].Rows.Count > 0)
                                        {
                                            int SiteID = Convert.ToInt32(dsChkDomain.Tables[0].Rows[0]["SiteID"].ToString());
                                            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                            ds.Tables[0].Rows.Add();
                                            ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                            ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                            ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                            ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                            j = j + 1;
                                            // bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                        }
                                        else
                                        {
                                            string[] Middle = Domain[0].Split('.');
                                            ArrayList str3 = new ArrayList();
                                            foreach (string s in Middle)
                                                str3.Add(s);
                                            if (str3.Count > 1)
                                            {
                                                DataSet dsDomainMiddle = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(Middle[1].ToString());
                                                if (dsDomainMiddle.Tables[0].Rows.Count > 0)
                                                {
                                                    int SiteID = Convert.ToInt32(dsDomainMiddle.Tables[0].Rows[0]["SiteID"].ToString());
                                                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                                    ds.Tables[0].Rows.Add();
                                                    ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                                    ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                                    ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                                    ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                                    j = j + 1;
                                                    //bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                                }
                                                else
                                                {
                                                    string First8Char = Domain[0].Substring(0, 8);
                                                    DataSet dsFirst8Char = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(First8Char);
                                                    if (dsFirst8Char.Tables[0].Rows.Count > 0)
                                                    {
                                                        int SiteID = Convert.ToInt32(dsFirst8Char.Tables[0].Rows[0]["SiteID"].ToString());
                                                        int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                                        ds.Tables[0].Rows.Add();
                                                        ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                                        ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                                        ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                                        ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                                        j = j + 1;
                                                        //bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                                    }
                                                    else
                                                    {
                                                        if (str3.Count > 2)
                                                        {
                                                            DataSet dsDomainThirdLine = objdropdownBL.USP_SmartzChaeckUrlExistsInMaster(Middle[2].ToString());
                                                            if (dsDomainThirdLine.Tables[0].Rows.Count > 0)
                                                            {
                                                                int SiteID = Convert.ToInt32(dsDomainThirdLine.Tables[0].Rows[0]["SiteID"].ToString());
                                                                int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                                                ds.Tables[0].Rows.Add();
                                                                ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                                                ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                                                ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                                                ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                                                j = j + 1;
                                                                //bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                                            }
                                                            else
                                                            {
                                                                strFailed.Add((i + 1) + " " + StrMail.ToString());

                                                                lblErrSuccess.Visible = true;
                                                                lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                                                lblErrfailures.Visible = true;
                                                                lblErrfailures.Text = "Error<br />";
                                                                lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                                                mpealteruser.Show();
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            strFailed.Add((i + 1) + " " + StrMail.ToString());

                                                            lblErrSuccess.Visible = true;
                                                            lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                                            lblErrfailures.Visible = true;
                                                            lblErrfailures.Text = "Error<br />";
                                                            lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                                            mpealteruser.Show();
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                strFailed.Add((i + 1) + " " + StrMail.ToString());

                                                lblErrSuccess.Visible = true;
                                                lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                                lblErrfailures.Visible = true;
                                                lblErrfailures.Text = "Error<br />";
                                                lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                                mpealteruser.Show();
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strFailed.Add((i + 1) + " " + StrMail.ToString());

                                        lblErrSuccess.Visible = true;
                                        lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                        lblErrfailures.Visible = true;
                                        lblErrfailures.Text = "Error<br />";
                                        lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                        mpealteruser.Show();
                                        break;
                                    }
                                }
                                else
                                {
                                    strFailed.Add((i + 1) + " " + StrMail.ToString());

                                    lblErrSuccess.Visible = true;
                                    lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                    lblErrfailures.Visible = true;
                                    lblErrfailures.Text = "Error<br />";
                                    lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Vehicle ID(s) not exist";
                                    mpealteruser.Show();
                                    break;
                                }
                            }
                            else
                            {
                                strFailed.Add((i + 1) + " " + StrMail.ToString());

                                lblErrSuccess.Visible = true;
                                lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                lblErrfailures.Visible = true;
                                lblErrfailures.Text = "Error<br />";
                                lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Data not entered properly";
                                mpealteruser.Show();
                                break;
                            }
                        }
                        else
                        {
                            strFailed.Add((i + 1) + " " + StrMail.ToString());

                            lblErrSuccess.Visible = true;
                            lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                            lblErrfailures.Visible = true;
                            lblErrfailures.Text = "Error<br />";
                            lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Data not entered properly";
                            mpealteruser.Show();
                            break;
                        }
                    }
                }
                if (strFailed.Count > 0)
                {
                    mpealteruser.Show();
                }
                else
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                int CarIDds = Convert.ToInt32(ds.Tables[0].Rows[k]["CarID"].ToString());
                                int SiteIDds = Convert.ToInt32(ds.Tables[0].Rows[k]["SiteID"].ToString());
                                int UIDds = Convert.ToInt32(ds.Tables[0].Rows[k]["UID"].ToString());
                                string FullUrlds = ds.Tables[0].Rows[k]["FullUrl"].ToString();
                                bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarIDds, FullUrlds, SiteIDds, UIDds);
                            }
                            lblErrSuccess.Visible = true;
                            lblErrSuccess.Text = "Saved successfully";
                            lblErrfailures.Visible = false;
                            mpealteruser.Show();
                        }
                        else
                        {
                            lblErrSuccess.Visible = true;
                            lblErrSuccess.Text = "Enter valid data";
                            lblErrfailures.Visible = false;
                            mpealteruser.Show();
                        }
                    }
                    else
                    {
                        lblErrSuccess.Visible = true;
                        lblErrSuccess.Text = "Enter valid data";
                        lblErrfailures.Visible = false;
                        mpealteruser.Show();
                    }
                }

            }
            else if (Session["MultiSiteBulkRedirectFrom"].ToString() == "Rvs")
            {
                DataSet ds = new DataSet();
                ds.Tables.Add("MultiData");
                ds.Tables[0].Columns.Add("CarID");
                ds.Tables[0].Columns.Add("FullUrl");
                ds.Tables[0].Columns.Add("SiteID");
                ds.Tables[0].Columns.Add("UID");
                string strAlltext = txtMultiSiteBulkUpload.Text.Replace("\r", "");
                string[] strAllMails = strAlltext.Split('\n');
                ArrayList str = new ArrayList();
                ArrayList strFailed = new ArrayList();
                foreach (string s in strAllMails)
                    str.Add(s);
                int j = 0;
                for (int i = 0; i < str.Count; i++)
                {
                    if (str[i].ToString().Trim() != "")
                    {
                        string StrMail = string.Empty;
                        StrMail = str[i].ToString();
                        string[] StrMailSplit = StrMail.Split(' ');
                        ArrayList str1 = new ArrayList();
                        foreach (string s in StrMailSplit)
                            str1.Add(s);
                        if (str1.Count > 0 && str1.Count == 2)
                        {
                            if (GeneralFunc.IsNumeric(StrMailSplit[0].ToString().Trim()) == true)
                            {
                                int CarID = Convert.ToInt32(StrMailSplit[0].ToString().Trim());
                                DataSet dsCarIDExists = objRvMainBL.SmartzCheckCarIDExistsForMultiSiteUploads(CarID);
                                if (dsCarIDExists.Tables[0].Rows[0]["Result"].ToString() == "Yes")
                                {
                                    string FullUrl = StrMailSplit[1].ToString().Replace("http://", "");
                                    string[] Domain = FullUrl.Split('/');
                                    ArrayList str2 = new ArrayList();
                                    foreach (string s in Domain)
                                        str2.Add(s);
                                    if (str2.Count > 1)
                                    {
                                        DataSet dsChkDomain = objRvMainBL.SmartzChaeckUrlExistsInMaster(Domain[0].ToString());
                                        if (dsChkDomain.Tables[0].Rows.Count > 0)
                                        {
                                            int SiteID = Convert.ToInt32(dsChkDomain.Tables[0].Rows[0]["SiteID"].ToString());
                                            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                            ds.Tables[0].Rows.Add();
                                            ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                            ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                            ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                            ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                            j = j + 1;
                                            // bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                        }
                                        else
                                        {
                                            string[] Middle = Domain[0].Split('.');
                                            ArrayList str3 = new ArrayList();
                                            foreach (string s in Middle)
                                                str3.Add(s);
                                            if (str3.Count > 1)
                                            {
                                                DataSet dsDomainMiddle = objRvMainBL.SmartzChaeckUrlExistsInMaster(Middle[1].ToString());
                                                if (dsDomainMiddle.Tables[0].Rows.Count > 0)
                                                {
                                                    int SiteID = Convert.ToInt32(dsDomainMiddle.Tables[0].Rows[0]["SiteID"].ToString());
                                                    int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                                    ds.Tables[0].Rows.Add();
                                                    ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                                    ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                                    ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                                    ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                                    j = j + 1;
                                                    //bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                                }
                                                else
                                                {
                                                    string First8Char = Domain[0].Substring(0, 8);
                                                    DataSet dsFirst8Char = objRvMainBL.SmartzChaeckUrlExistsInMaster(First8Char);
                                                    if (dsFirst8Char.Tables[0].Rows.Count > 0)
                                                    {
                                                        int SiteID = Convert.ToInt32(dsFirst8Char.Tables[0].Rows[0]["SiteID"].ToString());
                                                        int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                                                        ds.Tables[0].Rows.Add();
                                                        ds.Tables[0].Rows[j]["CarID"] = CarID.ToString();
                                                        ds.Tables[0].Rows[j]["FullUrl"] = FullUrl.ToString();
                                                        ds.Tables[0].Rows[j]["SiteID"] = SiteID.ToString();
                                                        ds.Tables[0].Rows[j]["UID"] = UID.ToString();
                                                        j = j + 1;
                                                        //bool bnew = objdropdownBL.USP_SmartzSaveUrlForCarID(CarID, FullUrl, SiteID, UID);
                                                    }
                                                    else
                                                    {
                                                        strFailed.Add((i + 1) + " " + StrMail.ToString());

                                                        lblErrSuccess.Visible = true;
                                                        lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                                        lblErrfailures.Visible = true;
                                                        lblErrfailures.Text = "Error<br />";
                                                        lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                                        mpealteruser.Show();
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                strFailed.Add((i + 1) + " " + StrMail.ToString());

                                                lblErrSuccess.Visible = true;
                                                lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                                lblErrfailures.Visible = true;
                                                lblErrfailures.Text = "Error<br />";
                                                lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                                mpealteruser.Show();
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        strFailed.Add((i + 1) + " " + StrMail.ToString());

                                        lblErrSuccess.Visible = true;
                                        lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                        lblErrfailures.Visible = true;
                                        lblErrfailures.Text = "Error<br />";
                                        lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Url(s) not exist in our database";
                                        mpealteruser.Show();
                                        break;
                                    }
                                }
                                else
                                {
                                    strFailed.Add((i + 1) + " " + StrMail.ToString());

                                    lblErrSuccess.Visible = true;
                                    lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                    lblErrfailures.Visible = true;
                                    lblErrfailures.Text = "Error<br />";
                                    lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Vehicle ID(s) not exist";
                                    mpealteruser.Show();
                                    break;
                                }
                            }
                            else
                            {
                                strFailed.Add((i + 1) + " " + StrMail.ToString());

                                lblErrSuccess.Visible = true;
                                lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                                lblErrfailures.Visible = true;
                                lblErrfailures.Text = "Error<br />";
                                lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Data not entered properly";
                                mpealteruser.Show();
                                break;
                            }
                        }
                        else
                        {
                            strFailed.Add((i + 1) + " " + StrMail.ToString());

                            lblErrSuccess.Visible = true;
                            lblErrSuccess.Text = "SAVED FAILED<br />None of the records are saved.";
                            lblErrfailures.Visible = true;
                            lblErrfailures.Text = "Error<br />";
                            lblErrfailures.Text = lblErrfailures.Text + "Line " + (i + 1) + ":Data not entered properly";
                            mpealteruser.Show();
                            break;
                        }
                    }
                }
                if (strFailed.Count > 0)
                {
                    mpealteruser.Show();
                }
                else
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                int CarIDds = Convert.ToInt32(ds.Tables[0].Rows[k]["CarID"].ToString());
                                int SiteIDds = Convert.ToInt32(ds.Tables[0].Rows[k]["SiteID"].ToString());
                                int UIDds = Convert.ToInt32(ds.Tables[0].Rows[k]["UID"].ToString());
                                string FullUrlds = ds.Tables[0].Rows[k]["FullUrl"].ToString();
                                bool bnew = objRvMainBL.SmartzSaveUrlForCarID(CarIDds, FullUrlds, SiteIDds, UIDds);
                            }
                            lblErrSuccess.Visible = true;
                            lblErrSuccess.Text = "Saved successfully";
                            lblErrfailures.Visible = false;
                            mpealteruser.Show();
                        }
                        else
                        {
                            lblErrSuccess.Visible = true;
                            lblErrSuccess.Text = "Enter valid data";
                            lblErrfailures.Visible = false;
                            mpealteruser.Show();
                        }
                    }
                    else
                    {
                        lblErrSuccess.Visible = true;
                        lblErrSuccess.Text = "Enter valid data";
                        lblErrfailures.Visible = false;
                        mpealteruser.Show();
                    }
                }
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
            Response.Redirect("MultiSiteBulkUploads.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
