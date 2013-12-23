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
using CarsBL.CentralDBTransactions;

public partial class AgentManagement : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    SmartzUserRegBL objUserBL = new SmartzUserRegBL();
    AgentMgmtBL objAgentBL = new AgentMgmtBL();
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
                LoadUsers();
                LoadDDL();
            }
        }
    }

    private void LoadUsers()
    {
        try
        {
            DataSet dsAgents = objCentralDBBL.GetSalesAgentDetails();
            Session["AgentDetails"] = dsAgents;
            if (dsAgents.Tables.Count > 0)
            {
                if (dsAgents.Tables[0].Rows.Count > 0)
                {
                    lblResHead.Text = "Results found " + dsAgents.Tables[0].Rows.Count.ToString();
                    grdUserDetails.Visible = true;
                    grdUserDetails.DataSource = dsAgents.Tables[0];
                    grdUserDetails.DataBind();
                }
                else
                {
                    lblResHead.Text = "Results not found";
                    grdUserDetails.Visible = false;

                }
            }
            else
            {
                lblResHead.Text = "Results not found";
                grdUserDetails.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void LoadDDL()
    {
        DataSet ds = new DataSet();
        if (Session["dUsersStatus"] == null)
        {

            ds = objCentralDBBL.GetUserStatus();
        }
        else
        {
            ds = (DataSet)Session["dUsersStatus"];
        }

        ddlUpStatus.DataSource = ds.Tables[0].DefaultView;

        ddlUpStatus.DataTextField = "status_name";
        ddlUpStatus.DataValueField = "user_status";

        ddlUpStatus.DataBind();


    }
    protected void grdUserDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            DataSet dsUser = new DataSet();
            dsUser = (DataSet)Session["AgentDetails"];

            if (e.CommandName == "EditUser")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                DataView dv1 = new DataView();
                DataTable dt = new DataTable();

                dv1 = dsUser.Tables[0].DefaultView;

                dv1.RowFilter = "Sale_Agent_Id=" + UserID + "";
                Session["Sale_Agent_Id"] = UserID;

                dt = dv1.ToTable();

                if (dt.Rows.Count > 0)
                {
                    txtAgentname.Text = dt.Rows[0]["American_Name"].ToString();
                    txtFirstName.Text = dt.Rows[0]["Agent_Name"].ToString();
                    // txtLastName.Text = dt.Rows[0]["Last_Name"].ToString();

                    ListItem liUserStatus = new ListItem();
                    liUserStatus.Value = Convert.ToInt32(dt.Rows[0]["IsActive"]).ToString();
                    liUserStatus.Text = Convert.ToString(dt.Rows[0]["status_name"].ToString());
                    ddlUpStatus.SelectedIndex = ddlUpStatus.Items.IndexOf(liUserStatus);

                }
                MPEUpdate.Show();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnlblUerExist_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["CkeckPoPUP"]) == 2)
            {
                MPEUpdate.Show();
                mpelblUerExist.Hide();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            int Sale_Agent_Id = Convert.ToInt32(Session["Sale_Agent_Id"].ToString());
            string First_Name = objGeneralFunc.ToProper(txtFirstName.Text).Trim();
            string Last_Name = "";
            string American_Name = objGeneralFunc.ToProper(txtAgentname.Text).Trim();
            int Created_by = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int IsActive = Convert.ToInt32(ddlUpStatus.SelectedItem.Value);
            int Disable_By = Convert.ToInt32(Session[Constants.USER_ID].ToString());

            DataSet dsAgentExists = new DataSet();
            dsAgentExists = objCentralDBBL.SmartzCheckAgentExists(Sale_Agent_Id, American_Name);
            if (dsAgentExists.Tables[0].Rows.Count > 0)
            {
                mpealteruser.Show();
                lblErr.Text = "Agent code " + American_Name + " already exists";
                //LoadUsers();
                lblErr.Visible = true;
            }
            else
            {

                bool bnew = objCentralDBBL.SmartzSaveAgentData(Sale_Agent_Id, First_Name, Last_Name, American_Name, Created_by, IsActive, Disable_By);
                LoadUsers();
                mpealteruser.Show();
                lblErr.Text = "Agent details updated successfully";
                //GetUserModules_AllUsers();

                lblErr.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        try
        {
            int Sale_Agent_Id = 0;
            string First_Name = objGeneralFunc.ToProper(txtAddFirstName.Text).Trim();
            string Last_Name = "";
            string American_Name = objGeneralFunc.ToProper(txtAddAgentName.Text).Trim();
            int Created_by = Convert.ToInt32(Session[Constants.USER_ID].ToString());
            int IsActive = 1;
            int Disable_By = Convert.ToInt32(Session[Constants.USER_ID].ToString());

            DataSet dsAgentExists = new DataSet();
            dsAgentExists = objCentralDBBL.SmartzCheckAgentExists(Sale_Agent_Id, American_Name);
            if (dsAgentExists.Tables[0].Rows.Count > 0)
            {
                mpealteruser.Show();
                lblErr.Text = "Agent code " + American_Name + " already exists";
                //LoadUsers();
                lblErr.Visible = true;
            }
            else
            {
                bool bnew = objCentralDBBL.SmartzSaveAgentData(Sale_Agent_Id, First_Name, Last_Name, American_Name, Created_by, IsActive, Disable_By);
                LoadUsers();
                mpealteruser.Show();
                lblErr.Text = "Agent details saved successfully";
                //GetUserModules_AllUsers();

                lblErr.Visible = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void rdbtnActive_Click(object sender, EventArgs e)
    {
        try
        {
            int IsActive = 1;
            LoadUsersStatus(IsActive);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void rdbtnInactive_Click(object sender, EventArgs e)
    {
        try
        {
            int IsActive = 0;
            LoadUsersStatus(IsActive);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void rdbtnAll_Click(object sender, EventArgs e)
    {
        try
        {
            LoadUsers();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadUsersStatus(int IsActive)
    {
        try
        {
            DataSet dsAgents = objCentralDBBL.GetSalesAgentDetailsByStatus(IsActive);
            Session["AgentDetails"] = dsAgents;
            if (dsAgents.Tables.Count > 0)
            {
                if (dsAgents.Tables[0].Rows.Count > 0)
                {
                    lblResHead.Text = "Results found " + dsAgents.Tables[0].Rows.Count.ToString();
                    grdUserDetails.Visible = true;
                    grdUserDetails.DataSource = dsAgents.Tables[0];
                    grdUserDetails.DataBind();
                }
                else
                {
                    lblResHead.Text = "Results not found";
                    grdUserDetails.Visible = false;

                }
            }
            else
            {
                lblResHead.Text = "Results not found";
                grdUserDetails.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkAgentName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["AgentDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "American_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentName.Text = "Agent Code &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentName.Text = "Agent Code &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkAgentName.Text = "Agent Code &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentName.Text = "Agent Code &#8659";
            }

            lnkName.Text = "Name &darr; &uarr;";
            lnkbtnCreateDate.Text = "Create Date &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";

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
    protected void lnkName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["AgentDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Agent_Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkName.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkName.Text = "Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkName.Text = "Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkName.Text = "Name &#8659";
            }

            lnkAgentName.Text = "Agent Code &darr; &uarr;";
            lnkbtnCreateDate.Text = "Create Date &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";

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
    protected void lnkbtnCreateDate_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["AgentDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Created_Date";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCreateDate.Text = "Create Date &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCreateDate.Text = "Create Date &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCreateDate.Text = "Create Date &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCreateDate.Text = "Create Date &#8659";
            }

            lnkAgentName.Text = "Agent Code &darr; &uarr;";
            lnkName.Text = "Name &darr; &uarr;";
            lnkStatus.Text = "Status &darr; &uarr;";

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
    protected void lnkStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["AgentDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "status_name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkStatus.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkStatus.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkStatus.Text = "Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkStatus.Text = "Status &#8659";
            }

            lnkAgentName.Text = "Agent Code &darr; &uarr;";
            lnkName.Text = "Name &darr; &uarr;";
            lnkbtnCreateDate.Text = "Create Date &darr; &uarr;";

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
