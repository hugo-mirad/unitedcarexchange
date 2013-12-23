
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
using CarsBL.CentralDBTransactions;
using CarsInfo;
using System.Net.Mail;
using CarsBL.Masters;

public partial class AgentReport : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    DataSet dsActiveSmartzUsers = new DataSet();
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

                dsActiveSmartzUsers = objCentralDBBL.GetSmartzUsersActiveData();
                Session["ActiveSmartzUsers"] = dsActiveSmartzUsers;
                FillAgents();
                txtStartDate.Text = System.DateTime.Now.AddDays(-6).ToString("MM/dd/yyyy");
                txtEndDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());

                GetResults(StartDate, EndDate);
            }
        }
    }



    private void FillAgents()
    {
        try
        {
            DataSet dsUsers = Session["ActiveSmartzUsers"] as DataSet;
            ddlAgentName.Items.Clear();
            ddlAgentName.DataSource = dsUsers.Tables[0];
            ddlAgentName.DataTextField = "SmartzFirstName";
            ddlAgentName.DataValueField = "SmartzUID";
            ddlAgentName.DataBind();
            ddlAgentName.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void GetResults(DateTime StartDate, DateTime EndDate)
    {
        try
        {
            int AgentID = Convert.ToInt32(ddlAgentName.SelectedItem.Value);
            DateTime StartingDate = Convert.ToDateTime(StartDate.AddDays(-1).ToString("MM/dd/yyyy"));
            DateTime EndingDate = Convert.ToDateTime(EndDate.AddDays(1).ToString("MM/dd/yyyy"));
            DataSet dsAgentsData = objdropdownBL.USP_SmartzGetAgentReport(AgentID, StartingDate, EndingDate);
            Session["AgentData"] = dsAgentsData;

            if (AgentID != 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add("AgentData");
                ds.Tables[0].Columns.Add("Date");
                ds.Tables[0].Columns.Add("Agent");
                ds.Tables[0].Columns.Add("CsCalls");
                ds.Tables[0].Columns.Add("WCCallsDone");
                ds.Tables[0].Columns.Add("TicketsCreated");
                ds.Tables[0].Columns.Add("TicketsSolved");
                ds.Tables[0].Columns.Add("SalesEntered");
                TimeSpan tsDiff = EndDate.Subtract(StartDate);
                int diff = Convert.ToInt32(tsDiff.TotalDays);
                for (int i = 0; i <= diff; i++)
                {
                    ds.Tables[0].Rows.Add();
                    ds.Tables[0].Rows[i]["Date"] = StartDate.AddDays(i).ToString("MM/dd/yyyy");
                }
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ds.Tables[0].Rows[j]["Agent"] = ddlAgentName.SelectedItem.Text;
                    DateTime DateData = Convert.ToDateTime(ds.Tables[0].Rows[j]["Date"].ToString());
                    string SelDt = DateData.ToString("MM/dd/yyyy");
                    DateTime FilterDate = Convert.ToDateTime(SelDt);
                    DataView dvDate = new DataView();
                    DataTable dtDate = new DataTable();
                    dvDate = dsAgentsData.Tables[0].DefaultView;
                    dvDate.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                    dtDate = dvDate.ToTable();
                    if (dtDate.Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[j]["CsCalls"] = dtDate.Rows[0]["Total"].ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["CsCalls"] = "0";
                    }
                    DataView dvDate2 = new DataView();
                    DataTable dtDate2 = new DataTable();
                    dvDate2 = dsAgentsData.Tables[1].DefaultView;
                    dvDate2.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                    dtDate2 = dvDate2.ToTable();
                    if (dtDate2.Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[j]["WCCallsDone"] = dtDate2.Rows[0]["Total"].ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["WCCallsDone"] = "0";
                    }
                    DataView dvDate3 = new DataView();
                    DataTable dtDate3 = new DataTable();
                    dvDate3 = dsAgentsData.Tables[2].DefaultView;
                    dvDate3.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                    dtDate3 = dvDate3.ToTable();
                    if (dtDate3.Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[j]["TicketsCreated"] = dtDate3.Rows[0]["Total"].ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["TicketsCreated"] = "0";
                    }
                    DataView dvDate4 = new DataView();
                    DataTable dtDate4 = new DataTable();
                    dvDate4 = dsAgentsData.Tables[3].DefaultView;
                    dvDate4.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                    dtDate4 = dvDate4.ToTable();
                    if (dtDate4.Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[j]["TicketsSolved"] = dtDate4.Rows[0]["Total"].ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["TicketsSolved"] = "0";
                    }
                    DataView dvDate5 = new DataView();
                    DataTable dtDate5 = new DataTable();
                    dvDate5 = dsAgentsData.Tables[4].DefaultView;
                    dvDate5.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                    dtDate5 = dvDate5.ToTable();
                    if (dtDate5.Rows.Count > 0)
                    {
                        ds.Tables[0].Rows[j]["SalesEntered"] = dtDate5.Rows[0]["Total"].ToString();
                    }
                    else
                    {
                        ds.Tables[0].Rows[j]["SalesEntered"] = "0";
                    }
                }
                Session["FinalAgentData"] = ds;
                grdAgentData.DataSource = ds;
                grdAgentData.DataBind();
            }
            else
            {

                DataSet dsUsers = Session["DsDropDown"] as DataSet;
                DataSet dsAgents = new DataSet();
                dsAgents.Tables.Add("AgentData");
                dsAgents.Tables[0].Columns.Add("Date");
                dsAgents.Tables[0].Columns.Add("Agent");
                dsAgents.Tables[0].Columns.Add("CsCalls");
                dsAgents.Tables[0].Columns.Add("WCCallsDone");
                dsAgents.Tables[0].Columns.Add("TicketsCreated");
                dsAgents.Tables[0].Columns.Add("TicketsSolved");
                dsAgents.Tables[0].Columns.Add("SalesEntered");
                for (int l = 0; l < dsUsers.Tables[12].Rows.Count; l++)
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add("AgentData");
                    ds.Tables[0].Columns.Add("Date");
                    ds.Tables[0].Columns.Add("Agent");
                    ds.Tables[0].Columns.Add("CsCalls");
                    ds.Tables[0].Columns.Add("WCCallsDone");
                    ds.Tables[0].Columns.Add("TicketsCreated");
                    ds.Tables[0].Columns.Add("TicketsSolved");
                    ds.Tables[0].Columns.Add("SalesEntered");
                    TimeSpan tsDiff = EndDate.Subtract(StartDate);
                    int diff = Convert.ToInt32(tsDiff.TotalDays);
                    for (int i = 0; i <= diff; i++)
                    {
                        ds.Tables[0].Rows.Add();
                        ds.Tables[0].Rows[i]["Date"] = StartDate.AddDays(i).ToString("MM/dd/yyyy");
                    }
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        ds.Tables[0].Rows[j]["Agent"] = dsUsers.Tables[12].Rows[l]["SmartzFirstName"].ToString();
                        DateTime DateData = Convert.ToDateTime(ds.Tables[0].Rows[j]["Date"].ToString());
                        string SelDt = DateData.ToString("MM/dd/yyyy");
                        DateTime FilterDate = Convert.ToDateTime(SelDt);
                        DataView dvDate = new DataView();
                        DataTable dtDate = new DataTable();
                        dvDate = dsAgentsData.Tables[0].DefaultView;
                        dvDate.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                        dtDate = dvDate.ToTable();
                        if (dtDate.Rows.Count > 0)
                        {
                            string AgentName = dsUsers.Tables[12].Rows[l]["SmartzFirstName"].ToString();
                            DataView dvAgentName = new DataView();
                            DataTable dtAgentName = new DataTable();
                            dvAgentName = dtDate.DefaultView;
                            dvAgentName.RowFilter = "AgentName='" + AgentName.ToString() + "'";
                            dtAgentName = dvAgentName.ToTable();
                            if (dtAgentName.Rows.Count > 0)
                            {
                                ds.Tables[0].Rows[j]["CsCalls"] = dtAgentName.Rows[0]["Total"].ToString();
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["CsCalls"] = "0";
                            }
                        }
                        else
                        {
                            ds.Tables[0].Rows[j]["CsCalls"] = "0";
                        }
                        DataView dvDate2 = new DataView();
                        DataTable dtDate2 = new DataTable();
                        dvDate2 = dsAgentsData.Tables[1].DefaultView;
                        dvDate2.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                        dtDate2 = dvDate2.ToTable();
                        if (dtDate2.Rows.Count > 0)
                        {
                            string AgentName = dsUsers.Tables[12].Rows[l]["SmartzFirstName"].ToString();
                            DataView dvAgentName = new DataView();
                            DataTable dtAgentName = new DataTable();
                            dvAgentName = dtDate2.DefaultView;
                            dvAgentName.RowFilter = "AgentName='" + AgentName.ToString() + "'";
                            dtAgentName = dvAgentName.ToTable();
                            if (dtAgentName.Rows.Count > 0)
                            {
                                ds.Tables[0].Rows[j]["WCCallsDone"] = dtAgentName.Rows[0]["Total"].ToString();
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["WCCallsDone"] = "0";
                            }
                        }
                        else
                        {
                            ds.Tables[0].Rows[j]["WCCallsDone"] = "0";
                        }
                        DataView dvDate3 = new DataView();
                        DataTable dtDate3 = new DataTable();
                        dvDate3 = dsAgentsData.Tables[2].DefaultView;
                        dvDate3.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                        dtDate3 = dvDate3.ToTable();
                        if (dtDate3.Rows.Count > 0)
                        {
                            string AgentName = dsUsers.Tables[12].Rows[l]["SmartzFirstName"].ToString();
                            DataView dvAgentName = new DataView();
                            DataTable dtAgentName = new DataTable();
                            dvAgentName = dtDate3.DefaultView;
                            dvAgentName.RowFilter = "AgentName='" + AgentName.ToString() + "'";
                            dtAgentName = dvAgentName.ToTable();
                            if (dtAgentName.Rows.Count > 0)
                            {
                                ds.Tables[0].Rows[j]["TicketsCreated"] = dtAgentName.Rows[0]["Total"].ToString();
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["TicketsCreated"] = "0";
                            }

                        }
                        else
                        {
                            ds.Tables[0].Rows[j]["TicketsCreated"] = "0";
                        }
                        DataView dvDate4 = new DataView();
                        DataTable dtDate4 = new DataTable();
                        dvDate4 = dsAgentsData.Tables[3].DefaultView;
                        dvDate4.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                        dtDate4 = dvDate4.ToTable();
                        if (dtDate4.Rows.Count > 0)
                        {

                            string AgentName = dsUsers.Tables[12].Rows[l]["SmartzFirstName"].ToString();
                            DataView dvAgentName = new DataView();
                            DataTable dtAgentName = new DataTable();
                            dvAgentName = dtDate4.DefaultView;
                            dvAgentName.RowFilter = "AgentName='" + AgentName.ToString() + "'";
                            dtAgentName = dvAgentName.ToTable();
                            if (dtAgentName.Rows.Count > 0)
                            {
                                ds.Tables[0].Rows[j]["TicketsSolved"] = dtAgentName.Rows[0]["Total"].ToString();
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["TicketsSolved"] = "0";
                            }
                        }
                        else
                        {
                            ds.Tables[0].Rows[j]["TicketsSolved"] = "0";
                        }
                        DataView dvDate5 = new DataView();
                        DataTable dtDate5 = new DataTable();
                        dvDate5 = dsAgentsData.Tables[4].DefaultView;
                        dvDate5.RowFilter = "Calldate='" + FilterDate.ToString() + "'";
                        dtDate5 = dvDate5.ToTable();
                        if (dtDate5.Rows.Count > 0)
                        {

                            string AgentName = dsUsers.Tables[12].Rows[l]["SmartzFirstName"].ToString();
                            DataView dvAgentName = new DataView();
                            DataTable dtAgentName = new DataTable();
                            dvAgentName = dtDate5.DefaultView;
                            dvAgentName.RowFilter = "AgentName='" + AgentName.ToString() + "'";
                            dtAgentName = dvAgentName.ToTable();
                            if (dtAgentName.Rows.Count > 0)
                            {
                                ds.Tables[0].Rows[j]["SalesEntered"] = dtAgentName.Rows[0]["Total"].ToString();
                            }
                            else
                            {
                                ds.Tables[0].Rows[j]["SalesEntered"] = "0";
                            }
                        }
                        else
                        {
                            ds.Tables[0].Rows[j]["SalesEntered"] = "0";
                        }


                    }

                    dsAgents.Merge(ds);

                }
                Session["FinalAgentData"] = dsAgents;
                grdAgentData.DataSource = dsAgents;
                grdAgentData.DataBind();
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSearchMonth_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            GetResults(StartDate, EndDate);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void lnkDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["FinalAgentData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Date";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkDateSort.Text = "Date &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkDateSort.Text = "Date &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkDateSort.Text = "Date &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkDateSort.Text = "Date &#8659";
            }

            lnkAgentNameSort.Text = "Agent Name &darr; &uarr;";
            lnkCSCallsSort.Text = "CS Calls &darr; &uarr;";
            lnkWCCallsDoneSort.Text = "WC Calls Done &darr; &uarr;";
            lnkTicketsCreatedSort.Text = "Tickets Created &darr; &uarr;";
            lnkTicketsSolvedSort.Text = "Tickets Solved &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdAgentData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkAgentNameSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["FinalAgentData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Agent";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentNameSort.Text = "Agent Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentNameSort.Text = "Agent Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkAgentNameSort.Text = "Agent Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkAgentNameSort.Text = "Agent Name &#8659";
            }

            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkCSCallsSort.Text = "CS Calls &darr; &uarr;";
            lnkWCCallsDoneSort.Text = "WC Calls Done &darr; &uarr;";
            lnkTicketsCreatedSort.Text = "Tickets Created &darr; &uarr;";
            lnkTicketsSolvedSort.Text = "Tickets Solved &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdAgentData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkCSCallsSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["FinalAgentData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CsCalls";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkCSCallsSort.Text = "CS Calls &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkCSCallsSort.Text = "CS Calls &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkCSCallsSort.Text = "CS Calls &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkCSCallsSort.Text = "CS Calls &#8659";
            }

            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkAgentNameSort.Text = "Agent Name &darr; &uarr;";
            lnkWCCallsDoneSort.Text = "WC Calls Done &darr; &uarr;";
            lnkTicketsCreatedSort.Text = "Tickets Created &darr; &uarr;";
            lnkTicketsSolvedSort.Text = "Tickets Solved &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdAgentData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkWCCallsDoneSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["FinalAgentData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "WCCallsDone";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkWCCallsDoneSort.Text = "WC Calls Done &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkWCCallsDoneSort.Text = "WC Calls Done &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkWCCallsDoneSort.Text = "WC Calls Done &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkWCCallsDoneSort.Text = "WC Calls Done &#8659";
            }

            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkAgentNameSort.Text = "Agent Name &darr; &uarr;";
            lnkCSCallsSort.Text = "CS Calls &darr; &uarr;";
            lnkTicketsCreatedSort.Text = "Tickets Created &darr; &uarr;";
            lnkTicketsSolvedSort.Text = "Tickets Solved &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdAgentData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkTicketsCreatedSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["FinalAgentData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketsCreated";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketsCreatedSort.Text = "Tickets Created &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketsCreatedSort.Text = "Tickets Created &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkTicketsCreatedSort.Text = "Tickets Created &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketsCreatedSort.Text = "Tickets Created &#8659";
            }

            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkAgentNameSort.Text = "Agent Name &darr; &uarr;";
            lnkCSCallsSort.Text = "CS Calls &darr; &uarr;";
            lnkWCCallsDoneSort.Text = "WC Calls Done &darr; &uarr;";
            lnkTicketsSolvedSort.Text = "Tickets Solved &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdAgentData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkTicketsSolvedSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["FinalAgentData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "TicketsSolved";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketsSolvedSort.Text = "Tickets Solved &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketsSolvedSort.Text = "Tickets Solved &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkTicketsSolvedSort.Text = "Tickets Solved &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkTicketsSolvedSort.Text = "Tickets Solved &#8659";
            }

            lnkDateSort.Text = "Date &darr; &uarr;";
            lnkAgentNameSort.Text = "Agent Name &darr; &uarr;";
            lnkCSCallsSort.Text = "CS Calls &darr; &uarr;";
            lnkWCCallsDoneSort.Text = "WC Calls Done &darr; &uarr;";
            lnkTicketsCreatedSort.Text = "Tickets Created &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, grdAgentData, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
