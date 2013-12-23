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
using CarsInfo.RvInfo;
using CarsBL.CentralDBTransactions;

public partial class CBNoticeClaims : System.Web.UI.Page
{
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    DropdownBL objdropdownBL = new DropdownBL();
    DataSet dsDropDown = new DataSet();
    RvMainBL objRvMainBL = new RvMainBL();
    DataSet dsActiveSaleAgents = new DataSet();
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
                FillCBStatus();
                int Status = Convert.ToInt32(ddlCBStatus.SelectedItem.Value);
                GetResults(Status);
            }
        }
    }

    private void GetResults(int Status)
    {
        try
        {
            DataSet dsData = objdropdownBL.GetNoticeDetailsByStatus(Status);
            Session["CBClaimsData"] = dsData;
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    lblRes.Visible = false;
                    GrdClaims.Visible = true;
                    GrdClaims.DataSource = dsData.Tables[0];
                    GrdClaims.DataBind();
                    div1.Style["display"] = "block";
                }
                else
                {
                    lblRes.Visible = true;
                    GrdClaims.Visible = false;
                    lblRes.Text = "Results not found";
                    div1.Style["display"] = "none";
                }
            }
            else
            {
                lblRes.Visible = true;
                GrdClaims.Visible = false;
                lblRes.Text = "Results not found";
                div1.Style["display"] = "none";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void FillCBStatus()
    {
        try
        {
            DataSet dsCBStatus = new DataSet();
            if ((Session["CBNoticeStatus"] == null) || (Session["CBNoticeStatus"].ToString() == ""))
            {
                dsCBStatus = objdropdownBL.SmartzGetMasterCBNoticeStatus();
                Session["CBNoticeStatus"] = dsCBStatus;
            }
            else
            {
                dsCBStatus = Session["CBNoticeStatus"] as DataSet;
            }

            ddlCBStatus.DataSource = dsCBStatus.Tables[0];
            ddlCBStatus.DataTextField = "NoticeStatusName";
            ddlCBStatus.DataValueField = "NoticeStatusID";
            ddlCBStatus.DataBind();


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnSearchCBDetails_Click(object sender, EventArgs e)
    {
        try
        {
            int Status = Convert.ToInt32(ddlCBStatus.SelectedItem.Value);
            GetResults(Status);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdIntroInfo_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditCBData")
            {
                int UID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["CBViewUID"] = UID;
                Response.Redirect("ChargebackProcess.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNoticeID_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "NoticeID";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeID.Text = "Notice ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeID.Text = "Notice ID &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkNoticeID.Text = "Notice ID &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeID.Text = "Notice ID &#8659";
            }

            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNoticeDateSort_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "NoticeDate";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeDateSort.Text = "Notice Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeDateSort.Text = "Notice Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkNoticeDateSort.Text = "Notice Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeDateSort.Text = "Notice Dt &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkNoticeType_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "NoticeTypeName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeType.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeType.Text = "Type &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkNoticeType.Text = "Type &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkNoticeType.Text = "Type &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnCustName_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "Name";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCustName.Text = "Cust Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCustName.Text = "Cust Name &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCustName.Text = "Cust Name &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCustName.Text = "Cust Name &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnCaseNum_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "CaseNumber";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCaseNum.Text = "Case # &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCaseNum.Text = "Case # &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnCaseNum.Text = "Case # &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnCaseNum.Text = "Case # &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkAmount_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "DisputeAmount";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkAmount.Text = "$ &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkAmount.Text = "$ &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkAmount.Text = "$ &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkAmount.Text = "$ &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnreplyDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "ReplyByDt";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnreplyDt.Text = "Reply By Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnreplyDt.Text = "Reply By Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnreplyDt.Text = "Reply By Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnreplyDt.Text = "Reply By Dt &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnReplySentDt_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "ReplySentDt";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnReplySentDt.Text = "Sent Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnReplySentDt.Text = "Sent Dt &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnReplySentDt.Text = "Sent Dt &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnReplySentDt.Text = "Sent Dt &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnStatus.Text = "Status &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void lnkbtnStatus_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Timeout = 180;
            DataSet ds = new DataSet();
            ds = Session["CBClaimsData"] as DataSet;
            ds.Tables[0].DefaultView.RowFilter = "";
            DataTable dt = ds.Tables[0];
            string SortExp = "NoticeStatusName";
            if (Session["SortDirec"] == null)
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnStatus.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "")
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnStatus.Text = "Status &#8659";
            }
            else if (Session["SortDirec"].ToString() == "Ascending")
            {
                Session["SortDirec"] = "Descending";
                lnkbtnStatus.Text = "Status &#8657";
            }
            else
            {
                Session["SortDirec"] = "Ascending";
                lnkbtnStatus.Text = "Status &#8659";
            }

            lnkNoticeID.Text = "Notice ID &darr; &uarr;";
            lnkNoticeDateSort.Text = "Notice Dt &darr; &uarr;";
            lnkNoticeType.Text = "Type &darr; &uarr;";
            lnkbtnCustName.Text = "Cust Name &darr; &uarr;";
            lnkbtnCaseNum.Text = "Case # &darr; &uarr;";
            lnkAmount.Text = "$ &darr; &uarr;";
            lnkbtnreplyDt.Text = "Reply By Dt &darr; &uarr;";
            lnkbtnReplySentDt.Text = "Sent Dt &darr; &uarr;";
            if (dt != null)
            {
                BizUtility.GridSortForReport(txthdnSortOrder, SortExp, GrdClaims, 0, dt, Session["SortDirec"].ToString());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void GrdClaims_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ViewNotice")
            {
                int NoticeID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["CBViewNoticeID"] = NoticeID;
                Response.Redirect("ChargeBackNoticeEditForm.aspx");
            }
            if (e.CommandName == "ViewProcess")
            {
                int NoticeID = Convert.ToInt32(e.CommandArgument.ToString());
                Session["CBViewNoticeID"] = NoticeID;
                Response.Redirect("ChargebackProcess.aspx");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
