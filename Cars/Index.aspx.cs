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

public partial class Index : System.Web.UI.Page
{
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
                Session.Timeout = 180;
            }
        }
    }
    protected void lnkbtnNewCustomer_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Show();
            Session["AskForRedirect"] = "NewCustomer";
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void lnkbtnMultiSiteBulkUpload_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Show();
            Session["AskForRedirect"] = "MultiSiteBulupload";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkbtnIntromail_Click(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Show();
            Session["AskForRedirect"] = "IntroMail";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbtnCarSale_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Hide();
            if (Session["AskForRedirect"].ToString() == "NewCustomer")
            {
                Response.Redirect("NewCustomer.aspx");
            }
            else if (Session["AskForRedirect"].ToString() == "MultiSiteBulupload")
            {
                Session["MultiSiteBulkRedirectFrom"] = "Cars";
                Response.Redirect("MultiSiteBulkUploads.aspx");
            }
            else if (Session["AskForRedirect"].ToString() == "IntroMail")
            {
                Response.Redirect("IntroMail.aspx");
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnRvSale_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Hide();
            if (Session["AskForRedirect"].ToString() == "NewCustomer")
            {
                Response.Redirect("AddNewRvVehicle.aspx");
            }
            else if (Session["AskForRedirect"].ToString() == "MultiSiteBulupload")
            {
                Session["MultiSiteBulkRedirectFrom"] = "Rvs";
                Response.Redirect("MultiSiteBulkUploads.aspx");
            }
            else if (Session["AskForRedirect"].ToString() == "IntroMail")
            {
                Response.Redirect("IntroMailByRV.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbtnTruckSale_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            mpeAskNewSale.Hide();
            if (Session["AskForRedirect"].ToString() == "NewCustomer")
            {
                Response.Redirect("AddNewTruckVehicle.aspx");
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
