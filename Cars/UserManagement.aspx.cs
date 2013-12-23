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

public partial class UserManagement : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    SmartzUserRegBL objUserBL = new SmartzUserRegBL();
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
                GetUserModules_AllUsers();
                LoadUsers();
                LoadDDL();
            }
        }
    }

    private void LoadUsers()
    {
        try
        {
            DataSet dsUsers = objUserBL.GetUsersDetails();
            Session["UserDetails"] = dsUsers;
            if (dsUsers.Tables.Count > 0)
            {
                if (dsUsers.Tables[0].Rows.Count > 0)
                {
                    lblResHead.Text = "Results found " + dsUsers.Tables[0].Rows.Count.ToString();
                    grdUserDetails.Visible = true;
                    grdUserDetails.DataSource = dsUsers.Tables[0];
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

        ds = objdropdownBL.Usp_Get_DropDown();


        ddlUpStatus.DataSource = ds.Tables[14].DefaultView;

        ddlUpStatus.DataTextField = "status_name";
        ddlUpStatus.DataValueField = "user_status";

        ddlUpStatus.DataBind();


        //ddlLocation.DataSource = ds.Tables[13].DefaultView;
        //ddlLocationUpdate.DataSource = ds.Tables[13].DefaultView;

        //ddlLocation.DataTextField = "modulename";
        //ddlLocation.DataValueField = "moduleid";

        //ddlLocation.DataBind();
        // ddlLocationUpdate.DataBind();

        //ddlUserType.DataSource = ds.Tables[9].DefaultView;
        //ddlUserType.DataTextField = "status_name";
        //ddlUserType.DataValueField = "user_status";
        //ddlUserType.DataBind();



    }
    protected void ddlUpStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlUpStatus.SelectedItem.Value) == 0)
            {
                if ((Convert.ToInt32(Session[Constants.USER_ID])) == Convert.ToInt32(Session["UserId_Update"]))
                {
                    Session["CkeckPoPUP"] = 2;
                    mpelblUerExist.Show();
                    lblUerExist.Text = "This transaction is not an allowed transaction";
                    lblUerExist.Visible = true;
                    MPEUpdate.Hide();
                }
                else
                {

                }
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private void GetUserModules_AllUsers()
    {
        try
        {
            int UserID = 0;
            DataSet dsAllUsersModuleRights = new DataSet();
            dsAllUsersModuleRights = objUserBL.GetUsersModuleRites_All(0);
            Session["AllUsersModuleRights"] = dsAllUsersModuleRights;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdUserDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            DataSet dsVoice = new DataSet();
            DataTable dt = new DataTable();
            DataView dv = new DataView();

            DataSet dsModules = new DataSet();
            DataTable dt1 = new DataTable();
            DataView dv1 = new DataView();



            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnUID");
                //Label lblUserType = (Label)e.Row.FindControl("lblUserType");
                ////  Label lblLocationRights = (Label)e.Row.FindControl("lblLocationRights");


                //dsVoice = (DataSet)Session["UserDetails"];
                //dv = dsVoice.Tables[0].DefaultView;



                //dv.RowFilter = "SmartzUID=" + hdnId.Value + "";
                //dt = dv.ToTable();

                //if (dt.Rows.Count > 0)
                //{
                //    dsModules = (DataSet)Session["AllUsersModuleRights"];

                //    dv1 = dsModules.Tables[0].DefaultView;
                //    dv1.RowFilter = "SmartzUID=" + hdnId.Value + "";
                //    dt1 = dv1.ToTable();


                //    if (dt1.Rows.Count > 0)
                //    {
                //        for (int i = 0; i <= dt1.Rows.Count - 1; i++)
                //        {
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "IntroMail"))
                //            {
                //                if (lblUserType.Text != "")
                //                {

                //                    lblUserType.Text = lblUserType.Text + ", IntroMail";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "IntroMail";
                //                }

                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Search"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Search";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Search";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "New Customer"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", New Customer";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "New Customer";
                //                }

                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Reports"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Reports";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Reports";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Agent Report"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Agent Report";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Agent Report";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Multi Site Listing"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Multi Site Listing";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Multi Site Listing";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Leads"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Leads";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Leads";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Dealer List"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Dealer List";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Dealer List";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Customer Service"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Customer Service";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Customer Service";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Welcome Calls"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Welcome Calls";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Welcome Calls";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "Tickets"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", Tickets";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "Tickets";
                //                }
                //            }
                //            if ((dt1.Rows[i]["ModuleActive"].ToString() == "1") && (dt1.Rows[i]["modulename"].ToString() == "User Admin"))
                //            {
                //                if (lblUserType.Text != "")
                //                {
                //                    lblUserType.Text = lblUserType.Text + ", User Admin";
                //                }
                //                else
                //                {
                //                    lblUserType.Text = "User Admin";
                //                }
                //            }

                //        }

                //    }

                //}
                //dv1.RowFilter = "";
                //dv.RowFilter = "";
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdUserDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            DataSet dsUser = new DataSet();
            dsUser = (DataSet)Session["UserDetails"];

            if (e.CommandName == "EditUser")
            {
                int UserID = Convert.ToInt32(e.CommandArgument);

                DataView dv1 = new DataView();
                DataTable dt = new DataTable();

                dv1 = dsUser.Tables[0].DefaultView;

                dv1.RowFilter = "SmartzUID=" + UserID + "";
                Session["UserId_Update"] = UserID;

                dt = dv1.ToTable();

                if (dt.Rows.Count > 0)
                {
                    txtUpFName.Text = Convert.ToString(dt.Rows[0]["SmartzFirstName"].ToString());


                    txtUpEmail.Text = Convert.ToString(dt.Rows[0]["SmartzEmail"].ToString());

                    //lblUnamePW.Text = dt.Rows[0]["SmartzUname"].ToString();
                    lblUpdateUser.Text = dt.Rows[0]["SmartzUname"].ToString();
                    lblUnamePW.Text = dt.Rows[0]["SmartzUname"].ToString();
                    //ListItem liUserType = new ListItem();
                    //liUserType.Value = Convert.ToString(dt.Rows[0]["usertypeid"].ToString());
                    //liUserType.Text = Convert.ToString(dt.Rows[0]["UsertypeName"].ToString());
                    //ddlUpUserType.SelectedIndex = ddlUpUserType.Items.IndexOf(liUserType);


                    ListItem liUserStatus = new ListItem();
                    liUserStatus.Value = Convert.ToInt32(dt.Rows[0]["Smartzisactive"]).ToString();
                    liUserStatus.Text = Convert.ToString(dt.Rows[0]["status_name"].ToString());
                    ddlUpStatus.SelectedIndex = ddlUpStatus.Items.IndexOf(liUserStatus);

                }



                DataSet dsModules = new DataSet();

                dsModules = objUserBL.GetUsersModuleRites_All(UserID);

                //ddlLocationUpdate.DataSource = dsModules.Tables[0].DefaultView;
                //ddlLocationUpdate.DataTextField = "ModuleName";
                //ddlLocationUpdate.DataValueField = "ModuleID";
                //  objliaLL.Attributes.Add("onclick", "return Check_All_CheckBoxClick(this)");
                //ddlLocationUpdate.DataBind();

                //for (int y = 0; y < ddlLocationUpdate.Items.Count; y++)
                //{
                //    ddlLocationUpdate.Items[y].Selected = false;
                //}


                //if (dsModules != null)
                //{
                //    if (dsModules.Tables[0].Rows.Count > 0)
                //    {
                //        if (dsModules.Tables[0].Rows.Count > 0)
                //        {
                //            for (int i = 0; i <= dsModules.Tables[0].Rows.Count - 1; i++)
                //            {
                //                if (dsModules.Tables[0].Rows[i]["ModuleActive"].ToString() == "1")
                //                {
                //                    ddlLocationUpdate.Items[i].Selected = true;

                //                }

                //            }
                //        }

                //    }
                //}
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
            else if (Convert.ToInt32(Session["ChangePass"]) == 2)
            {
                MPEUpdate.Show();
                //mpeChangePW.Show();
            }
            else if (Convert.ToInt32(Session["CkeckPoPUP"]) == 1)
            {
                mpeAddNew.Show();
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
            if ((Convert.ToInt32(Session[Constants.USER_ID])) == Convert.ToInt32(Session["UserId_Update"]))
            {
                mpealteruser.Show();
                lblErr.Text = "This transaction is not an allowed transaction";
                lblErr.Visible = true;

            }
            else
            {
                int Tran_By = Convert.ToInt32(Session[Constants.USER_ID].ToString());
                objUserBL.SmartzUpdateUserDetails(Convert.ToInt32(Session["UserId_Update"]), objGeneralFunc.ToProper(txtUpFName.Text), txtUpEmail.Text.Trim(), Convert.ToInt32(ddlUpStatus.SelectedItem.Value));


                //for (int m = 0; m < ddlLocationUpdate.Items.Count; m++)
                //{
                //    if (ddlLocationUpdate.Items[m].Selected == true)
                //    {
                //        //objUserMangmnt.UpdateModuleRights(Convert.ToInt32(Session["UserId_Update"].ToString()), Convert.ToInt32(ddlLocationUpdate.Items[m].Value), 1);
                //    }
                //    else
                //    {
                //        //objUserMangmnt.UpdateModuleRights(Convert.ToInt32(Session["UserId_Update"].ToString()), Convert.ToInt32(ddlLocationUpdate.Items[m].Value), 0);
                //    }
                //}


                mpealteruser.Show();
                lblErr.Text = "User details updated successfully";
                GetUserModules_AllUsers();
                LoadUsers();
                lblErr.Visible = true;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('User Details Updated Successfully.')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkUserName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["UserDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SmartzUname";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkUserName.Text = "User Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkUserName.Text = "User Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkUserName.Text = "User Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkUserName.Text = "User Name &#8659";
            }

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
    protected void lnkName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["UserDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SmartzFirstName";
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

            lnkUserName.Text = "User Name &darr; &uarr;";
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
            ds = Session["UserDetails"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "SmartzIsActive";
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

            lnkUserName.Text = "User Name &darr; &uarr;";
            lnkName.Text = "Name &darr; &uarr;";
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
    protected void btnChangePW_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dsChangePW = new DataSet();

            Session["ChangePass"] = 2;

            dsChangePW = objUserBL.SmartzUpdateUserPassword(Convert.ToInt32(Session["UserId_Update"]), txtNewPW.Text);

            //mpealteruser.Show();
            //LoadUsers();
            //lblErr.Text = "Password Changed Successfully";
            //lblErr.Visible = true;

            mpelblUerExist.Show();
            lblUerExist.Text = "Password changed successfully";

            lblUerExist.Visible = true;
            //MPEUpdate.Hide();

            //mpelblUerExist.Show();
            //lblUerExist.Text = "Password Changed Successfully";
            //lblUerExist.Visible = true;


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void btnCancelPW_Click(object sender, EventArgs e)
    {
        try
        {
            MPEUpdate.Show();
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
            DataSet ds = new DataSet();            
            Session["CkeckPoPUP"] = 1;
            ds = objUserBL.SmartzSaveNewUser(objGeneralFunc.ToProper(txtFName.Text), txtEmail.Text, txtUserName.Text, txtPassword.Text);
            
            if (ds != null)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Checks"]) == 1)
                {
                    mpelblUerExist.Show();
                    lblUerExist.Text = "User name already exists. Please choose another user name.";
                    lblUerExist.Visible = true;

                }
                else
                {
                    mpealteruser.Show();
                    lblErr.Text = "User details updated successfully";
                    GetUserModules_AllUsers();
                    LoadUsers();
                    lblErr.Visible = true;

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
