<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <div class="headder">
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;
        </div>
    </div>
    <div class="main">
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%; margin-top: 30px;">
            <td style="width: 250px; vertical-align: top;">
                <ul class="menu">
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnIntromail" runat="server" Text="IntroMail" OnClick="lnkbtnIntromail_Click"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkOfferEmail" runat="server" PostBackUrl="~/OfferMailSending.aspx"
                            Text="OfferMail"></asp:LinkButton></li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnSearch" runat="server" PostBackUrl="~/SearchNew.aspx" Text="Search"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:UpdatePanel ID="updtpnlNewCust" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="lnkbtnNewCustomer" runat="server" Text="New Customer" OnClick="lnkbtnNewCustomer_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnNewForm" runat="server" PostBackUrl="~/AddCarNewForm.aspx"
                            Text="New Form"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnMultiSiteListing" runat="server" PostBackUrl="~/MultiSiteListing.aspx"
                            Text="Multi Site Listing"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnCustomerService" runat="server" PostBackUrl="~/CustomerService.aspx"
                            Text="Customer Service"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnWelcomeCalls" runat="server" PostBackUrl="~/WelcomeCalls.aspx"
                            Text="Welcome Calls"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtn30dayCalls" runat="server" PostBackUrl="~/Days30CallReview.aspx"
                            Text="30 Days Calls Review"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtn60dayCalls" runat="server" PostBackUrl="~/Days60CallsReview.aspx"
                            Text="60 Days Calls Review"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnTickets" runat="server" PostBackUrl="~/Tickets.aspx" Text="Tickets"></asp:LinkButton>
                    </li>
                </ul>
            </td>
            <td style="width: 10px;">
                &nbsp;
            </td>
            <td style="width: 250px; vertical-align: top;">
                <ul class="menu">
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnFreeSales" runat="server" PostBackUrl="~/FreeSales.aspx"
                            Text="Free Listings"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnAbandonSales" runat="server" PostBackUrl="~/AbandonSalesSearch.aspx"
                            Text="Abandon Sales"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnESubscription" runat="server" PostBackUrl="~/ESubscription.aspx"
                            Text="E Subscription" Visible="false"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkAgentMgmt" runat="server" PostBackUrl="~/AgentManagement.aspx"
                            Text="Agent Mgmt"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnUserMgmt" runat="server" PostBackUrl="~/UserManagement.aspx"
                            Text="User Admin"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnDealers" runat="server" PostBackUrl="~/Dealerregistration.aspx"
                            Text="Add a Dealer"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnDealerSearch" runat="server" PostBackUrl="~/DealerSearch.aspx"
                            Text="Dealer Search"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnReports" runat="server" PostBackUrl="~/Report.aspx" Text="Reports"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnAgentReport" runat="server" PostBackUrl="~/SalesAgentReport.aspx"
                            Text="Agent Report"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnUsersReport" runat="server" PostBackUrl="~/AgentReport.aspx"
                            Text="Smartz Users Report"></asp:LinkButton>
                    </li>
                    <%--<li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnAddChargebacks" runat="server" PostBackUrl="~/AddNewChargeback.aspx"
                            Text="Add Chargeback"></asp:LinkButton>
                    </li>--%>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnAddNewCB" runat="server" PostBackUrl="~/ChargeBackNoticeForm.aspx"
                            Text="Add Chargeback"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnSearchChargeBacks" runat="server" PostBackUrl="~/CBNoticeClaims.aspx"
                            Text="Chargeback Claims"></asp:LinkButton>
                    </li>
                </ul>
            </td>
            <%-- <td style="vertical-align: top; padding-left: 30px;">
                <img src="images/admin.jpg" style="padding: 10px; border: #ccc 1px solid; margin-top: 10px">
            </td>--%>
            <td style="width: 10px;">
                &nbsp;
            </td>
            <td style="width: 250px; vertical-align: top;">
                <ul class="menu">
                    <%--  <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnLeads" runat="server" Text="Leads"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnDealerList" runat="server" Text="Dealer List"></asp:LinkButton>
                    </li>--%>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnAddingMake" runat="server" Text="Add Make" PostBackUrl="~/MakeAdding.aspx"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnAddingModel" runat="server" Text="Add Model" PostBackUrl="~/AddingModel.aspx"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnOldSearch" runat="server" Text="Old Search" PostBackUrl="~/Search.aspx"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnMultiSiteBulkUpload" runat="server" Text="Multi Site Bulk Upload"
                            OnClick="lnkbtnMultiSiteBulkUpload_Click"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnPDPaymentDate" runat="server" Text="Post Date Payment Data"
                            PostBackUrl="~/PDDateDetails.aspx"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnRecentList" runat="server" Text="Recent List" PostBackUrl="~/RecentList.aspx"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnNewAgentReport" runat="server" Text="New Agent Report"
                            PostBackUrl="~/NewSalesAgentReport.aspx"></asp:LinkButton>
                    </li>
                    <li class="sliding-element">
                        <asp:LinkButton ID="lnkbtnSalesSheetDownLoad" runat="server" PostBackUrl="~/SalesSheetDownload.aspx"
                            Text="Sales Sheet Download"></asp:LinkButton>
                    </li>
                </ul>
            </td>
            <td>
                &nbsp;
            </td>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <cc1:ModalPopupExtender ID="mpeAskNewSale" runat="server" PopupControlID="tblAskNewSale"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAskNewSale" CancelControlID="btnCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAskNewSale" runat="server" />
    <div id="tblAskNewSale" style="display: none; background-color: #adbc79; width: 300px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="3" style="background: #E7E7E7 url(../images/price-list-bg2.jpg) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Select vehicle Type
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="padding-left: 5px; width: 100px">
                                <asp:RadioButton ID="rdbtnCarSale" GroupName="VehicleType" runat="server" Text="Car"
                                    AutoPostBack="true" OnCheckedChanged="rdbtnCarSale_CheckedChanged" />
                            </td>
                            <td style="padding-right: 5px; width: 100px">
                                <asp:RadioButton ID="rdbtnRvSale" GroupName="VehicleType" runat="server" Text="Rv"
                                    AutoPostBack="true" OnCheckedChanged="rdbtnRvSale_CheckedChanged" />
                            </td>
                            <td style="padding-right: 5px; width: 100px">
                                <asp:RadioButton ID="rdbtnTruckSale" GroupName="VehicleType" runat="server" Text="Truck"
                                    AutoPostBack="true" OnCheckedChanged="rdbtnTruckSale_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 10px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0 0 20px 0;" colspan="3">
                                <div align="center">
                                    <asp:Button ID="btnCancel" CssClass="g-button g-button-submit" runat="server" Text="Cancel"
                                        Style="float: none" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
