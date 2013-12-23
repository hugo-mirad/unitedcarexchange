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
using CarsBL.RvTransactions;

public partial class NewSalesAgentReport : System.Web.UI.Page, IPostBackEventHandler
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    public DataSet dsTotdata = new DataSet();
    int TotalBasic;
    int TotalStandard;
    int TotalEnhanced;
    int TotalSilver;
    int TotalGold;
    int TotalPlatinum;
    int TotalTotal;
    Double TotalMoney;
    Double ActiveMoney;
    CentralDBMainBL objCentarlDBBL = new CentralDBMainBL();
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
                if (Session["DsDropDown"] == null)
                {
                    dsDropDown = objdropdownBL.Usp_Get_DropDown();
                    Session["DsDropDown"] = dsDropDown;
                }
                else
                {
                    dsDropDown = (DataSet)Session["DsDropDown"];
                }
                txtStartDate.Text = System.DateTime.Now.AddDays(-6).ToString("MM/dd/yyyy");
                txtEndDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
                DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
                int Active = 0;
                GetResults(StartDate, EndDate, Active);
            }
        }
    }

    private void GetResults(DateTime StartDate, DateTime EndDate, int Active)
    {
        try
        {
            Session["AgentReportActive"] = Active;
            Session["AgentReportStartDate"] = StartDate;
            Session["AgentReportEndDate"] = EndDate;
            DataSet dsAgents = new DataSet();
            if (Active.ToString() == "0")
            {
                dsAgents = objCentarlDBBL.GetSmartzSalesAgentsDetails();
            }
            if (Active.ToString() == "1")
            {
                dsAgents = objCentarlDBBL.GetSmartzSalesAgentsActiveData();
            }
            if (Active.ToString() == "2")
            {
                dsAgents = objCentarlDBBL.GetSmartzSalesAgentsInActivePeriod(StartDate, EndDate);
            }
            DataSet dsCarsPackages = new DataSet();
            dsCarsPackages = objdropdownBL.SmartzGetCarsAllPackages();

            DataSet dsRvPackages = new DataSet();
            dsRvPackages = objRvMainBL.GetAllPackages();

            DataSet dsCarsData = objdropdownBL.GETNewSalesAgentReport(Active, StartDate, EndDate);
            DataSet dsRvsData = objRvMainBL.GETNewSalesAgentReportForRvs(Active, StartDate, EndDate);

            DataSet ds = new DataSet();
            ds.Tables.Add("AgentData");
            ds.Tables[0].Columns.Add("AgentName");
            ds.Tables[0].Columns.Add("AgentID");
            ds.Tables[0].Columns.Add("VehicleType");
            ds.Tables[0].Columns.Add("Package");
            ds.Tables[0].Columns.Add("NoOfSales", typeof(Int32));
            ds.Tables[0].Columns.Add("SaleAmount", typeof(Double));
            ds.Tables[0].Columns.Add("PaidAmount", typeof(Double));
            ds.Tables[0].Columns.Add("PrevSaleAmount", typeof(Double));
            ds.Tables[0].Columns.Add("TotalAmount", typeof(Double));
            int k = 0;
            if (dsAgents.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAgents.Tables[0].Rows.Count; i++)
                {
                    if (dsAgents.Tables[0].Rows[i]["Agent_Name"].ToString() != "Unknown")
                    {
                        for (int j = 0; j < dsCarsPackages.Tables[0].Rows.Count; j++)
                        {
                            ds.Tables[0].Rows.Add();
                            ds.Tables[0].Rows[k]["AgentName"] = dsAgents.Tables[0].Rows[i]["Agent_Name"].ToString();
                            ds.Tables[0].Rows[k]["AgentID"] = dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString();
                            ds.Tables[0].Rows[k]["Package"] = dsCarsPackages.Tables[0].Rows[j]["Description"].ToString();
                            ds.Tables[0].Rows[k]["VehicleType"] = "Cars";
                            if (dsCarsData.Tables[0].Rows.Count > 0)
                            {
                                DataView dvData = new DataView();
                                DataTable dtData = new DataTable();
                                dvData = dsCarsData.Tables[0].DefaultView;
                                dvData.RowFilter = "Sale_Agent_Id='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "' and PackageID='" + dsCarsPackages.Tables[0].Rows[j]["PackageID"] + "'";
                                dtData = dvData.ToTable();
                                if (dtData.Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[k]["NoOfSales"] = dtData.Rows[0]["Count"].ToString();
                                    ds.Tables[0].Rows[k]["SaleAmount"] = dtData.Rows[0]["SaleAmount"].ToString();
                                }
                                else
                                {
                                    ds.Tables[0].Rows[k]["NoOfSales"] = "0";
                                    ds.Tables[0].Rows[k]["SaleAmount"] = "0";
                                }
                                dvData.RowFilter = "";

                                DataView dvData2 = new DataView();
                                DataTable dtData2 = new DataTable();
                                dvData2 = dsCarsData.Tables[1].DefaultView;
                                dvData2.RowFilter = "Sale_Agent_Id='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "' and PackageID='" + dsCarsPackages.Tables[0].Rows[j]["PackageID"] + "'";
                                dtData2 = dvData2.ToTable();
                                if (dtData2.Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[k]["PaidAmount"] = dtData2.Rows[0]["PaidAmount"].ToString();
                                }
                                else
                                {
                                    ds.Tables[0].Rows[k]["PaidAmount"] = "0";
                                }
                                dvData2.RowFilter = "";

                                DataView dvData3 = new DataView();
                                DataTable dtData3 = new DataTable();
                                dvData3 = dsCarsData.Tables[2].DefaultView;
                                dvData3.RowFilter = "Sale_Agent_Id='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "' and PackageID='" + dsCarsPackages.Tables[0].Rows[j]["PackageID"] + "'";
                                dtData3 = dvData3.ToTable();
                                if (dtData3.Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[k]["PrevSaleAmount"] = dtData3.Rows[0]["PrevSalePaidAmount"].ToString();
                                }
                                else
                                {
                                    ds.Tables[0].Rows[k]["PrevSaleAmount"] = "0";
                                }
                                dvData3.RowFilter = "";
                            }
                            else
                            {
                                ds.Tables[0].Rows[k]["NoOfSales"] = "0";
                                ds.Tables[0].Rows[k]["SaleAmount"] = "0";
                                ds.Tables[0].Rows[k]["PaidAmount"] = "0";
                                ds.Tables[0].Rows[k]["PrevSaleAmount"] = "0";
                            }

                            ds.Tables[0].Rows[k]["TotalAmount"] = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[k]["PaidAmount"].ToString()) + Convert.ToDouble(ds.Tables[0].Rows[k]["PrevSaleAmount"].ToString()));
                            k = k + 1;
                        }
                        for (int j = 0; j < dsRvPackages.Tables[0].Rows.Count; j++)
                        {
                            ds.Tables[0].Rows.Add();
                            ds.Tables[0].Rows[k]["AgentName"] = dsAgents.Tables[0].Rows[i]["Agent_Name"].ToString();
                            ds.Tables[0].Rows[k]["AgentID"] = dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString();
                            ds.Tables[0].Rows[k]["Package"] = dsRvPackages.Tables[0].Rows[j]["Description"].ToString();
                            ds.Tables[0].Rows[k]["VehicleType"] = "Rvs";
                            if (dsRvsData.Tables[0].Rows.Count > 0)
                            {
                                DataView dvData = new DataView();
                                DataTable dtData = new DataTable();
                                dvData = dsRvsData.Tables[0].DefaultView;
                                dvData.RowFilter = "Sale_Agent_Id='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "' and PackageID='" + dsRvPackages.Tables[0].Rows[j]["PackageID"] + "'";
                                dtData = dvData.ToTable();
                                if (dtData.Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[k]["NoOfSales"] = dtData.Rows[0]["Count"].ToString();
                                    ds.Tables[0].Rows[k]["SaleAmount"] = dtData.Rows[0]["SaleAmount"].ToString();
                                }
                                else
                                {
                                    ds.Tables[0].Rows[k]["NoOfSales"] = "0";
                                    ds.Tables[0].Rows[k]["SaleAmount"] = "0";
                                }
                                dvData.RowFilter = "";

                                DataView dvData2 = new DataView();
                                DataTable dtData2 = new DataTable();
                                dvData2 = dsRvsData.Tables[1].DefaultView;
                                dvData2.RowFilter = "Sale_Agent_Id='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "' and PackageID='" + dsRvPackages.Tables[0].Rows[j]["PackageID"] + "'";
                                dtData2 = dvData2.ToTable();
                                if (dtData2.Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[k]["PaidAmount"] = dtData2.Rows[0]["PaidAmount"].ToString();
                                }
                                else
                                {
                                    ds.Tables[0].Rows[k]["PaidAmount"] = "0";
                                }
                                dvData2.RowFilter = "";

                                DataView dvData3 = new DataView();
                                DataTable dtData3 = new DataTable();
                                dvData3 = dsRvsData.Tables[2].DefaultView;
                                dvData3.RowFilter = "Sale_Agent_Id='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "' and PackageID='" + dsRvPackages.Tables[0].Rows[j]["PackageID"] + "'";
                                dtData3 = dvData3.ToTable();
                                if (dtData3.Rows.Count > 0)
                                {
                                    ds.Tables[0].Rows[k]["PrevSaleAmount"] = dtData3.Rows[0]["PrevSalePaidAmount"].ToString();
                                }
                                else
                                {
                                    ds.Tables[0].Rows[k]["PrevSaleAmount"] = "0";
                                }
                                dvData3.RowFilter = "";
                            }
                            else
                            {
                                ds.Tables[0].Rows[k]["NoOfSales"] = "0";
                                ds.Tables[0].Rows[k]["SaleAmount"] = "0";
                                ds.Tables[0].Rows[k]["PaidAmount"] = "0";
                                ds.Tables[0].Rows[k]["PrevSaleAmount"] = "0";
                            }

                            ds.Tables[0].Rows[k]["TotalAmount"] = Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[k]["PaidAmount"].ToString()) + Convert.ToDouble(ds.Tables[0].Rows[k]["PrevSaleAmount"].ToString()));
                            k = k + 1;
                        }

                        ds.Tables[0].Rows.Add();
                        ds.Tables[0].Rows[k]["AgentName"] = dsAgents.Tables[0].Rows[i]["Agent_Name"].ToString();
                        ds.Tables[0].Rows[k]["AgentID"] = dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString();
                        ds.Tables[0].Rows[k]["Package"] = "AgentTotal";
                        ds.Tables[0].Rows[k]["VehicleType"] = "Agent Total";
                        DataView dvDataTot = new DataView();
                        DataTable dtDataTot = new DataTable();
                        dvDataTot = ds.Tables[0].DefaultView;
                        dvDataTot.RowFilter = "AgentID='" + dsAgents.Tables[0].Rows[i]["Sale_Agent_Id"].ToString() + "'";
                        dtDataTot = dvDataTot.ToTable();
                        if (dtDataTot.Rows.Count > 0)
                        {
                            ds.Tables[0].Rows[k]["NoOfSales"] = dtDataTot.Compute("sum(NoOfSales)", "");
                            ds.Tables[0].Rows[k]["SaleAmount"] = dtDataTot.Compute("sum(SaleAmount)", "");
                            ds.Tables[0].Rows[k]["PaidAmount"] = dtDataTot.Compute("sum(PaidAmount)", "");
                            ds.Tables[0].Rows[k]["PrevSaleAmount"] = dtDataTot.Compute("sum(PrevSaleAmount)", "");
                            ds.Tables[0].Rows[k]["TotalAmount"] = dtDataTot.Compute("sum(TotalAmount)", "");
                        }
                        else
                        {
                            ds.Tables[0].Rows[k]["NoOfSales"] = "0";
                            ds.Tables[0].Rows[k]["SaleAmount"] = "0";
                            ds.Tables[0].Rows[k]["PaidAmount"] = "0";
                            ds.Tables[0].Rows[k]["PrevSaleAmount"] = "0";
                            ds.Tables[0].Rows[k]["TotalAmount"] = "0";
                        }
                        dvDataTot.RowFilter = "";
                        k = k + 1;
                    }
                }
            }
            lblResHead.Text = "Agent performance report for period " + StartDate.ToString("MM/dd/yyyy") + " to " + EndDate.ToString("MM/dd/yyyy");
            lblResCount.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            Session["NewAgentRepData"] = ds;
            CreateTable();

            DataView dvDataGrandTot = new DataView();
            DataTable dtDataGrandTot = new DataTable();
            dvDataGrandTot = ds.Tables[0].DefaultView;
            dvDataGrandTot.RowFilter = "Package='AgentTotal'";
            dtDataGrandTot = dvDataGrandTot.ToTable();
            if (dtDataGrandTot.Rows.Count > 0)
            {
                lblGrandNoOfSales.Text = dtDataGrandTot.Compute("sum(NoOfSales)", "").ToString();
                lblGrandSaleAmount.Text = dtDataGrandTot.Compute("sum(SaleAmount)", "").ToString(); ;
                lblGrandPaidAmount.Text = dtDataGrandTot.Compute("sum(PaidAmount)", "").ToString(); ;
                lblgrandPrevAmount.Text = dtDataGrandTot.Compute("sum(PrevSaleAmount)", "").ToString();
                lblGrandTotalAmount.Text = dtDataGrandTot.Compute("sum(TotalAmount)", "").ToString();
            }
            else
            {
                lblGrandNoOfSales.Text = "0";
                lblGrandSaleAmount.Text = "0";
                lblGrandPaidAmount.Text = "0";
                lblgrandPrevAmount.Text = "0";
                lblGrandTotalAmount.Text = "0";
            }
            //grdAgentData.DataSource = ds.Tables[0];
            //grdAgentData.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CreateTable()
    {
        try
        {
            DataSet dsDataFinded = new DataSet();
            dsDataFinded = Session["NewAgentRepData"] as DataSet;
            plcholgrid.Controls.Clear();

            // Create a Table and set its properties 
            Table tbl = new Table();
            // Add the table to the placeholder control
            plcholgrid.Controls.Add(tbl);
            // Now iterate through the table and add your controls 
            int m = 1;
            for (int i = 0; i < dsDataFinded.Tables[0].Rows.Count; i++)
            {
                string AgentName = string.Empty;
                string VehicleType = string.Empty;
                string Package = string.Empty;

                if (Session["ChkAgntName"] == null || Session["ChkAgntName"].ToString() == "")
                {
                    AgentName = dsDataFinded.Tables[0].Rows[i]["AgentName"].ToString();
                    Session["ChkAgntName"] = AgentName;
                    AgentName = m.ToString() + ". " + AgentName;
                    m = m + 1;
                }
                else if (Session["ChkAgntName"].ToString() == dsDataFinded.Tables[0].Rows[i]["AgentName"].ToString())
                {
                    AgentName = "";
                    if (dsDataFinded.Tables[0].Rows[i]["VehicleType"].ToString() == "AgentTotal")
                    {
                        AgentName = "Total";
                    }
                }
                else
                {
                    AgentName = dsDataFinded.Tables[0].Rows[i]["AgentName"].ToString();
                    Session["ChkAgntName"] = AgentName;
                    AgentName = m.ToString() + ". " + AgentName;
                    m = m + 1;

                }

                if (Session["ChkvehicleType"] == null || Session["ChkvehicleType"].ToString() == "")
                {
                    VehicleType = dsDataFinded.Tables[0].Rows[i]["VehicleType"].ToString();
                    Session["ChkvehicleType"] = VehicleType;

                    TableRow tr1 = new TableRow();
                    TableCell TableCell11 = new TableCell();
                    TableCell TableCell12 = new TableCell();
                    TableCell TableCell13 = new TableCell();
                    TableCell TableCell14 = new TableCell();
                    TableCell TableCell15 = new TableCell();
                    TableCell TableCell16 = new TableCell();
                    TableCell TableCell17 = new TableCell();
                    TableCell TableCell18 = new TableCell();
                    TableCell11.CssClass = "H10";


                    TableCell11.Text = "&nbsp;";
                    TableCell12.Text = "";
                    TableCell13.Text = "";
                    TableCell14.Text = "";
                    TableCell15.Text = "";
                    TableCell16.Text = "";
                    TableCell17.Text = "";
                    TableCell18.Text = "";
                    tr1.Cells.Add(TableCell11);
                    tr1.Cells.Add(TableCell12);
                    tr1.Cells.Add(TableCell13);
                    tr1.Cells.Add(TableCell14);
                    tr1.Cells.Add(TableCell15);
                    tr1.Cells.Add(TableCell16);
                    tr1.Cells.Add(TableCell17);
                    tr1.Cells.Add(TableCell18);

                    tbl.Rows.Add(tr1);
                }
                else if (Session["ChkvehicleType"].ToString() == dsDataFinded.Tables[0].Rows[i]["VehicleType"].ToString())
                {
                    VehicleType = "";
                }
                else
                {
                    VehicleType = dsDataFinded.Tables[0].Rows[i]["VehicleType"].ToString();
                    Session["ChkvehicleType"] = VehicleType;

                    TableRow tr1 = new TableRow();
                    TableCell TableCell11 = new TableCell();
                    TableCell TableCell12 = new TableCell();
                    TableCell TableCell13 = new TableCell();
                    TableCell TableCell14 = new TableCell();
                    TableCell TableCell15 = new TableCell();
                    TableCell TableCell16 = new TableCell();
                    TableCell TableCell17 = new TableCell();
                    TableCell TableCell18 = new TableCell();
                    TableCell11.CssClass = "H10";

                    TableCell11.Text = "&nbsp;";
                    TableCell12.Text = "";
                    TableCell13.Text = "";
                    TableCell14.Text = "";
                    TableCell15.Text = "";
                    TableCell16.Text = "";
                    TableCell17.Text = "";
                    TableCell18.Text = "";
                    tr1.Cells.Add(TableCell11);
                    tr1.Cells.Add(TableCell12);
                    tr1.Cells.Add(TableCell13);
                    tr1.Cells.Add(TableCell14);
                    tr1.Cells.Add(TableCell15);
                    tr1.Cells.Add(TableCell16);
                    tr1.Cells.Add(TableCell17);
                    tr1.Cells.Add(TableCell18);

                    tbl.Rows.Add(tr1);
                }
                Package = dsDataFinded.Tables[0].Rows[i]["Package"].ToString();

                if (dsDataFinded.Tables[0].Rows[i]["VehicleType"].ToString() == "Agent Total")
                {
                    AgentName = "Total";
                    VehicleType = "";
                    Package = "";
                }

                TableRow tr = new TableRow();
                TableCell TableCell1 = new TableCell();
                TableCell TableCell2 = new TableCell();
                TableCell TableCell3 = new TableCell();
                TableCell TableCell4 = new TableCell();
                TableCell TableCell5 = new TableCell();
                TableCell TableCell6 = new TableCell();
                TableCell TableCell7 = new TableCell();
                TableCell TableCell8 = new TableCell();
                //TableCell1.Font.Bold = true;
                //TableCell2.Font.Bold = true;

                TableCell1.CssClass = "agentName";
                TableCell2.CssClass = "vehicleType";
                TableCell3.CssClass = "package";
                TableCell4.CssClass = "noSales";
                TableCell5.CssClass = "slAmount";
                TableCell6.CssClass = "pAmount";
                TableCell7.CssClass = "prevS";
                TableCell8.CssClass = "total";

                if (AgentName != "Total" && AgentName != "")
                {
                    DataView dvDataAgnt = new DataView();
                    DataTable dtDataAgnt = new DataTable();
                    dvDataAgnt = dsDataFinded.Tables[0].DefaultView;
                    dvDataAgnt.RowFilter = "AgentID='" + dsDataFinded.Tables[0].Rows[i]["AgentID"].ToString() + "' and Package='AgentTotal'";
                    dtDataAgnt = dvDataAgnt.ToTable();
                    string AgntTot = string.Empty;
                    if (dtDataAgnt.Rows.Count > 0)
                    {
                        AgntTot = dtDataAgnt.Rows[0]["NoOfSales"].ToString();
                    }
                    else
                    {
                        AgntTot = "0";
                    }
                    dvDataAgnt.RowFilter = "";
                    LinkButton lnkAgent = new LinkButton();
                    lnkAgent.ID = "lnkAgent" + AgentName;//You can change with Student_ID
                    lnkAgent.Text = AgentName;
                    lnkAgent.CommandName = "Agent Click";
                    lnkAgent.CommandArgument = dsDataFinded.Tables[0].Rows[i]["AgentID"].ToString();
                    if (AgntTot == "0")
                    {
                        lnkAgent.Enabled = false;
                    }
                    else
                    {
                        lnkAgent.Enabled = true;
                        lnkAgent.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this, dsDataFinded.Tables[0].Rows[i]["AgentID"].ToString());
                    }
                    //Create dynamic click event for all link buttons
                    // lnkAgent.Click = "lnkAgent_Click";
                    //lnkAgent.Click += new EventHandler(lnkAgent_Click);
                    //lnkAgent.OnClientClick = "ButtonClick('" + lnkAgent.ClientID + "')";
                    //lnkAgent.Attributes.Add("onclick", "lnkAgent_Click");
                    //lnkAgent.Attributes["onclick"] = ClientScript.GetPostBackEventReference(this, dsDataFinded.Tables[0].Rows[i]["AgentID"].ToString());

                    TableCell1.Controls.Add(lnkAgent);
                }
                else
                {
                    TableCell1.Text = AgentName;
                }
                TableCell2.Text = VehicleType;
                TableCell3.Text = Package;
                TableCell4.Text = dsDataFinded.Tables[0].Rows[i]["NoOfSales"].ToString();
                TableCell5.Text = dsDataFinded.Tables[0].Rows[i]["SaleAmount"].ToString();
                TableCell6.Text = dsDataFinded.Tables[0].Rows[i]["PaidAmount"].ToString();
                TableCell7.Text = dsDataFinded.Tables[0].Rows[i]["PrevSaleAmount"].ToString();
                TableCell8.Text = dsDataFinded.Tables[0].Rows[i]["TotalAmount"].ToString();
                tr.Cells.Add(TableCell1);
                tr.Cells.Add(TableCell2);
                tr.Cells.Add(TableCell3);
                tr.Cells.Add(TableCell4);
                tr.Cells.Add(TableCell5);
                tr.Cells.Add(TableCell6);
                tr.Cells.Add(TableCell7);
                tr.Cells.Add(TableCell8);

                if (AgentName == "Total")
                {
                    tr.CssClass = "gTotal";
                }
                tbl.Rows.Add(tr);
                if (AgentName == "Total")
                {
                    TableRow tr1 = new TableRow();
                    TableCell TableCell11 = new TableCell();
                    TableCell TableCell12 = new TableCell();
                    TableCell TableCell13 = new TableCell();
                    TableCell TableCell14 = new TableCell();
                    TableCell TableCell15 = new TableCell();
                    TableCell TableCell16 = new TableCell();
                    TableCell TableCell17 = new TableCell();
                    TableCell TableCell18 = new TableCell();
                    TableCell11.CssClass = "H10";

                    TableCell11.Text = "&nbsp;";
                    TableCell12.Text = "";
                    TableCell13.Text = "";
                    TableCell14.Text = "";
                    TableCell15.Text = "";
                    TableCell16.Text = "";
                    TableCell17.Text = "";
                    TableCell18.Text = "";
                    tr1.Cells.Add(TableCell11);
                    tr1.Cells.Add(TableCell12);
                    tr1.Cells.Add(TableCell13);
                    tr1.Cells.Add(TableCell14);
                    tr1.Cells.Add(TableCell15);
                    tr1.Cells.Add(TableCell16);
                    tr1.Cells.Add(TableCell17);
                    tr1.Cells.Add(TableCell18);

                    tbl.Rows.Add(tr1);
                }
            }

            // This parameter helps determine in the LoadViewState event,
            // whether to recreate the dynamic controls or not

            ViewState["dynamictable"] = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void lnkAgent_Click(string eventArgument)
    {
        try
        {
            int AgentID = Convert.ToInt32(eventArgument);
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            DateTime StartingDate = StartDate; //Convert.ToDateTime(StartDate.AddDays(-1).ToString("MM/dd/yyyy"));
            DateTime EndingDate = EndDate;//Convert.ToDateTime(EndDate.AddDays(1).ToString("MM/dd/yyyy"));
            DataSet dsIndvidualAgentData = objdropdownBL.USP_SmartzGetAgentSalesBetweenDate(AgentID, StartingDate, EndingDate);
            DataSet dsRvindividualData = objRvMainBL.SmartzGetRvsAgentSalesBetweenDate(AgentID, StartingDate, EndingDate);

            DataSet dsInddata = new DataSet();
            dsInddata.Tables.Add("IndividualAgentData");
            dsInddata.Tables[0].Columns.Add("AgentName");
            dsInddata.Tables[0].Columns.Add("VehicleType");
            dsInddata.Tables[0].Columns.Add("VehicleID");
            dsInddata.Tables[0].Columns.Add("AdStatus");
            dsInddata.Tables[0].Columns.Add("SaleDate");
            dsInddata.Tables[0].Columns.Add("Description");
            dsInddata.Tables[0].Columns.Add("Price");
            dsInddata.Tables[0].Columns.Add("sellerName");
            dsInddata.Tables[0].Columns.Add("city");
            dsInddata.Tables[0].Columns.Add("state");
            dsInddata.Tables[0].Columns.Add("zip");
            dsInddata.Tables[0].Columns.Add("phone");
            dsInddata.Tables[0].Columns.Add("email");
            dsInddata.Tables[0].Columns.Add("PmntStatusName");

            int i = 0;
            if (dsIndvidualAgentData.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < dsIndvidualAgentData.Tables[0].Rows.Count; j++)
                {
                    dsInddata.Tables[0].Rows.Add();
                    dsInddata.Tables[0].Rows[i]["AgentName"] = dsIndvidualAgentData.Tables[0].Rows[j]["American_Name"].ToString();
                    dsInddata.Tables[0].Rows[i]["VehicleType"] = "Cars";
                    dsInddata.Tables[0].Rows[i]["VehicleID"] = dsIndvidualAgentData.Tables[0].Rows[j]["carid"].ToString();
                    dsInddata.Tables[0].Rows[i]["AdStatus"] = dsIndvidualAgentData.Tables[0].Rows[j]["AdStatus"].ToString();
                    dsInddata.Tables[0].Rows[i]["SaleDate"] = dsIndvidualAgentData.Tables[0].Rows[j]["SaleDate"].ToString();
                    dsInddata.Tables[0].Rows[i]["Description"] = dsIndvidualAgentData.Tables[0].Rows[j]["Description"].ToString();
                    dsInddata.Tables[0].Rows[i]["Price"] = dsIndvidualAgentData.Tables[0].Rows[j]["Price"].ToString();
                    dsInddata.Tables[0].Rows[i]["sellerName"] = dsIndvidualAgentData.Tables[0].Rows[j]["sellerName"].ToString();
                    dsInddata.Tables[0].Rows[i]["city"] = dsIndvidualAgentData.Tables[0].Rows[j]["city"].ToString();
                    dsInddata.Tables[0].Rows[i]["state"] = dsIndvidualAgentData.Tables[0].Rows[j]["state"].ToString();
                    dsInddata.Tables[0].Rows[i]["zip"] = dsIndvidualAgentData.Tables[0].Rows[j]["zip"].ToString();
                    dsInddata.Tables[0].Rows[i]["phone"] = dsIndvidualAgentData.Tables[0].Rows[j]["phone"].ToString();
                    dsInddata.Tables[0].Rows[i]["email"] = dsIndvidualAgentData.Tables[0].Rows[j]["email"].ToString();
                    dsInddata.Tables[0].Rows[i]["PmntStatusName"] = dsIndvidualAgentData.Tables[0].Rows[j]["PmntStatusName"].ToString();
                    i = i + 1;
                }
            }
            if (dsRvindividualData.Tables[0].Rows.Count > 0)
            {
                for (int k = 0; k < dsRvindividualData.Tables[0].Rows.Count; k++)
                {
                    dsInddata.Tables[0].Rows.Add();
                    dsInddata.Tables[0].Rows[i]["AgentName"] = dsRvindividualData.Tables[0].Rows[k]["American_Name"].ToString();
                    dsInddata.Tables[0].Rows[i]["VehicleType"] = "Rvs";
                    dsInddata.Tables[0].Rows[i]["VehicleID"] = dsRvindividualData.Tables[0].Rows[k]["carid"].ToString();
                    dsInddata.Tables[0].Rows[i]["AdStatus"] = dsRvindividualData.Tables[0].Rows[k]["AdStatus"].ToString();
                    dsInddata.Tables[0].Rows[i]["SaleDate"] = dsRvindividualData.Tables[0].Rows[k]["SaleDate"].ToString();
                    dsInddata.Tables[0].Rows[i]["Description"] = dsRvindividualData.Tables[0].Rows[k]["Description"].ToString();
                    dsInddata.Tables[0].Rows[i]["Price"] = dsRvindividualData.Tables[0].Rows[k]["Price"].ToString();
                    dsInddata.Tables[0].Rows[i]["sellerName"] = dsRvindividualData.Tables[0].Rows[k]["sellerName"].ToString();
                    dsInddata.Tables[0].Rows[i]["city"] = dsRvindividualData.Tables[0].Rows[k]["city"].ToString();
                    dsInddata.Tables[0].Rows[i]["state"] = dsRvindividualData.Tables[0].Rows[k]["state"].ToString();
                    dsInddata.Tables[0].Rows[i]["zip"] = dsRvindividualData.Tables[0].Rows[k]["zip"].ToString();
                    dsInddata.Tables[0].Rows[i]["phone"] = dsRvindividualData.Tables[0].Rows[k]["phone"].ToString();
                    dsInddata.Tables[0].Rows[i]["email"] = dsRvindividualData.Tables[0].Rows[k]["email"].ToString();
                    dsInddata.Tables[0].Rows[i]["PmntStatusName"] = dsRvindividualData.Tables[0].Rows[k]["PmntStatusName"].ToString();
                    i = i + 1;
                }
            }

            string AgentName;

            if (dsInddata.Tables[0].Rows[0]["AgentName"].ToString() != "")
            {
                AgentName = dsInddata.Tables[0].Rows[0]["AgentName"].ToString();
            }
            else
            {
                AgentName = "Unknown";
            }
            lblSelAgentname.Text = AgentName;
            lblPopupResults.Text = "Performance report for period " + StartDate.ToString("MM/dd/yyyy") + " to " + EndDate.ToString("MM/dd/yyyy");
            lblPopReportDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            if (dsInddata.Tables[0].Rows.Count > 0)
            {
                grdIntroInfo.Visible = true;
                lblRes.Visible = false;
                grdIntroInfo.DataSource = dsInddata.Tables[0];
                grdIntroInfo.DataBind();
                string sTable = CreateTableHeader();
                lblVehStatus.Attributes.Add("onmouseover", "return overlib1('" + sTable + "',STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 100,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');");
                lblVehStatus.Attributes.Add("onmouseout", "return nd(4000);");
            }
            else
            {
                grdIntroInfo.Visible = false;
                lblRes.Visible = true;
                lblRes.Text = "No sales for this agent";
            }
            mpeaSalesData.Show();
        }
        catch (Exception ex)
        {

        }
    }

    #region IPostBackEventHandler Members

    public void RaisePostBackEvent(string eventArgument)
    {

        if (!string.IsNullOrEmpty(eventArgument))
        {
            lnkAgent_Click(eventArgument);

        }

    }
    #endregion IPostBackEventHandler Members

    protected void btnSearchMonth_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active;
            if (rdbtnActive.Checked == true)
            {
                Active = 1;
            }
            else if (rdbtnActivePeriod.Checked == true)
            {
                Active = 2;
            }
            else
            {
                Active = 0;
            }
            GetResults(StartDate, EndDate, Active);
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
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active = 1;
            GetResults(StartDate, EndDate, Active);

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
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active = 0;
            GetResults(StartDate, EndDate, Active);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void rdbtnActivePeriod_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(txtStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(txtEndDate.Text.ToString());
            int Active = 2;
            GetResults(StartDate, EndDate, Active);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    protected void grdAgentData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            DataSet dsData = new DataSet();
            dsData = (DataSet)Session["NewAgentRepData"];
            if (e.CommandName == "ShowSales")
            {

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
                Label lblSaleDtInd = (Label)e.Row.FindControl("lblSaleDtInd");
                HiddenField hdnSaledate = (HiddenField)e.Row.FindControl("hdnSaledate");
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

                if (hdnSaledate.Value.ToString() != "")
                {
                    DateTime dtSaleDate = Convert.ToDateTime(hdnSaledate.Value.ToString());
                    lblSaleDtInd.Text = dtSaleDate.ToString("MM/dd/yy");
                }
                else
                {
                    lblSaleDtInd.Text = "";
                }

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
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdAgentData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnSalesAmount = (HiddenField)e.Row.FindControl("hdnSalesAmount");
                Label lblSalesAmount = (Label)e.Row.FindControl("lblSalesAmount");
                HiddenField hdnPaidAmount = (HiddenField)e.Row.FindControl("hdnPaidAmount");
                Label lblPaidAmount = (Label)e.Row.FindControl("lblPaidAmount");
                HiddenField hdnPrevSalePaidAmount = (HiddenField)e.Row.FindControl("hdnPrevSalePaidAmount");
                Label lblPrevSalePaidAmount = (Label)e.Row.FindControl("lblPrevSalePaidAmount");
                HiddenField hdnTotalPaidAmount = (HiddenField)e.Row.FindControl("hdnTotalPaidAmount");
                Label lblTotalPaidAmount = (Label)e.Row.FindControl("lblTotalPaidAmount");
                if (hdnSalesAmount.Value.ToString() == "0")
                {
                    lblSalesAmount.Text = "0";
                }
                else
                {
                    Double SalesAmount = Convert.ToDouble(hdnSalesAmount.Value.ToString());
                    lblSalesAmount.Text = string.Format("{0:0.00}", SalesAmount);
                }
                if (hdnPaidAmount.Value.ToString() == "0")
                {
                    lblPaidAmount.Text = "0";
                }
                else
                {
                    Double PaidAmount = Convert.ToDouble(hdnPaidAmount.Value.ToString());
                    lblPaidAmount.Text = string.Format("{0:0.00}", PaidAmount);
                }
                if (hdnPrevSalePaidAmount.Value.ToString() == "0")
                {
                    lblPrevSalePaidAmount.Text = "0";
                }
                else
                {
                    Double PrevSalesPaidAmount = Convert.ToDouble(hdnPrevSalePaidAmount.Value.ToString());
                    lblPrevSalePaidAmount.Text = string.Format("{0:0.00}", PrevSalesPaidAmount);
                }
                if (hdnTotalPaidAmount.Value.ToString() == "0")
                {
                    lblTotalPaidAmount.Text = "0";
                }
                else
                {
                    Double TotalPaidAmount = Convert.ToDouble(hdnTotalPaidAmount.Value.ToString());
                    lblTotalPaidAmount.Text = string.Format("{0:0.00}", TotalPaidAmount);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void BtnClsSendRegMail_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime StartDate = Convert.ToDateTime(Session["AgentReportStartDate"].ToString());
            DateTime EndDate = Convert.ToDateTime(Session["AgentReportEndDate"].ToString());
            int Active = Convert.ToInt32(Session["AgentReportActive"].ToString());
            GetResults(StartDate, EndDate, Active);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private string CreateTableHeader()
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
