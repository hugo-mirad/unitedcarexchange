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

public partial class MakeAdding : System.Web.UI.Page
{
    AddCarMake objMakeAdd = new AddCarMake();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadMakes();
        }
    }

    private void LoadMakes()
    {
        DataSet dsGetMakes = new DataSet();
        dsGetMakes = objMakeAdd.USP_GetMakes();
        Session["GetAllMakesData"] = dsGetMakes;
        lblResHead.Text = "Results found " + dsGetMakes.Tables[0].Rows.Count.ToString();
        grdUserDetails.DataSource = dsGetMakes;
        grdUserDetails.DataBind();

    }
    protected void btnAddUser_Click(object sender, EventArgs e)
    {

        DataSet dsAddMake = new DataSet();
        dsAddMake = objMakeAdd.USP_SaveMake(objGeneralFunc.ToProper(txtMakeName.Text).Trim());

        if (dsAddMake != null)
        {
            if (dsAddMake.Tables.Count > 0)
            {
                if (dsAddMake.Tables[0].Rows.Count > 0)
                {
                    if (dsAddMake.Tables[0].Rows[0]["Duplicate"].ToString() == "0")
                    {

                        mpealteruser.Show();
                        lblErr.Text = "Make already exist";
                        lblErr.Visible = true;

                    }
                    else
                    {
                        mpealteruser.Show();
                        lblErr.Text = "Make added successfully.";
                        lblErr.Visible = true;
                        LoadMakes();

                    }
                }

            }
        }

    }

    protected void lnkbtnMakeID_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["GetAllMakesData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "makeID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnMakeID.Text = "Make Id &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnMakeID.Text = "Make Id &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnMakeID.Text = "Make Id &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnMakeID.Text = "Make Id &#8659";
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

    protected void lnkbtnMakeName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["GetAllMakesData"] as DataSet;
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

            lnkbtnMakeID.Text = "Make Id &darr; &uarr;";

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
