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

public partial class AddingModel : System.Web.UI.Page
{
    AddCarModels objCarModel = new AddCarModels();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    AddCarMake objMakeAdd = new AddCarMake();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadModels();
            LoadMakes();
        }

    }
    private void LoadMakes()
    {
        DataSet dsGetMakes = new DataSet();
        dsGetMakes = objMakeAdd.USP_GetMakes();

        ddlMake.DataSource = dsGetMakes.Tables[0].DefaultView;

        ddlMake.DataTextField = "make";
        ddlMake.DataValueField = "makeid";

        ddlMake.DataBind();
        ddlMake.Items.Insert(0, new ListItem("Select", "0"));


    }
    private void LoadModels()
    {
        DataSet dsGetModel = new DataSet();
        dsGetModel = objCarModel.USP_GetModels();
        Session["GetAllMakeModelsDetails"] = dsGetModel;
        Session[Constants.AllModel] = dsGetModel;
        lblResHead.Text = "Results found " + dsGetModel.Tables[0].Rows.Count.ToString();
        grdUserDetails.DataSource = dsGetModel;
        grdUserDetails.DataBind();
    }
    protected void btnAddModel_Click(object sender, EventArgs e)
    {
        DataSet dsAddMakeModel = new DataSet();

        dsAddMakeModel = objCarModel.USP_SaveCarModel(Convert.ToInt32(ddlMake.SelectedItem.Value), txtMakeModelName.Text.Trim());

        if (dsAddMakeModel != null)
        {
            if (dsAddMakeModel.Tables.Count > 0)
            {
                if (dsAddMakeModel.Tables[0].Rows.Count > 0)
                {
                    if (dsAddMakeModel.Tables[0].Rows[0]["Duplicate"].ToString() == "0")
                    {

                        mpealteruser.Show();
                        lblErr.Text = "Model already exist";
                        lblErr.Visible = true;

                    }
                    else
                    {
                        mpealteruser.Show();
                        lblErr.Text = "Model added successfully.";
                        lblErr.Visible = true;
                        LoadModels();

                    }
                }

            }
        }
    }

    protected void lnkbtnMakeName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["GetAllMakeModelsDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "make";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnMakeName.Text = "Make Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnMakeName.Text = "Make Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnMakeName.Text = "Make Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnMakeName.Text = "Make Name &#8659";
            }

            lnkbtnModelName.Text = "Model Name &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdUserDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnModelName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["GetAllMakeModelsDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "model";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnModelName.Text = "Model Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnModelName.Text = "Model Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnModelName.Text = "Model Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnModelName.Text = "Model Name &#8659";
            }

            lnkbtnMakeName.Text = "Make Name &darr; &uarr;";

            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdUserDetails, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
