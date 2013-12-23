<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
	});
    </script>

    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <div class="headder">
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            UCE Summary Report</h1>
        <div class="clear">
            &nbsp;</div>
        <div style="text-align: right; width: 250px; float: right; position: absolute; top: 13px;
            right: 15px">
            Report Dt:
            <asp:Label ID="lblRepDate" runat="server"></asp:Label>
        </div>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
                    <h4 class="h43">
                        SALES</h4>
                    <table class="grid1" cellpadding="0" cellspacing="0" style="padding: 2px; border: #ccc 1px solid;">
                        <tr class="tbHed">
                            <td style="width: 105px;">
                                Name
                            </td>
                            <td>
                                Total
                            </td>
                            <td>
                                Prev Year
                            </td>
                            <td>
                                This year
                            </td>
                            <td>
                                Prev month
                            </td>
                            <td>
                                This month
                            </td>
                            <td>
                                Prev week
                            </td>
                            <td>
                                This week
                            </td>
                            <td>
                                Mon
                            </td>
                            <td>
                                Tue
                            </td>
                            <td>
                                Wed
                            </td>
                            <td>
                                Thu
                            </td>
                            <td>
                                Fri
                            </td>
                            <td>
                                Sat
                            </td>
                            <td>
                                Sun
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Platinum
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotalPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTuePkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunPkgPlatinum" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Gold
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotalPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTuePkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunPkgGold" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Silver
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotalPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTuePkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunPkgSilver" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Enhanced
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotalPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTuePkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunPkgEnhanced" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Standard
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotalPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTuePkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunPkgStandard" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Basic
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotalPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTuePkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunPkgBasic" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                TOTAL
                            </td>
                            <td>
                                <asp:Label ID="lblSalesTotTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevYearTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisYearTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevMonthTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisMonthTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesPrevWeekTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesThisWeekTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTueTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="clear" style="height: 20px;">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <h4 class="h43">
                        Refunds/Chargebacks</h4>
                    <table class="grid1" cellpadding="0" cellspacing="0" style="padding: 2px; border: #ccc 1px solid;">
                        <tr class="tbHed">
                            <td style="width: 105px;">
                                Name
                            </td>
                            <td>
                                Total
                            </td>
                            <td>
                                Prev Year
                            </td>
                            <td>
                                This year
                            </td>
                            <td>
                                Prev month
                            </td>
                            <td>
                                This month
                            </td>
                            <td>
                                Prev week
                            </td>
                            <td>
                                This week
                            </td>
                            <td>
                                Mon
                            </td>
                            <td>
                                Tue
                            </td>
                            <td>
                                Wed
                            </td>
                            <td>
                                Thu
                            </td>
                            <td>
                                Fri
                            </td>
                            <td>
                                Sat
                            </td>
                            <td>
                                Sun
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Platinum
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotalPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTuePkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatPkgPlatinum" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunPkgPlatinum" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Gold
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotalPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTuePkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatPkgGold" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunPkgGold" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Silver
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotalPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTuePkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatPkgSilver" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunPkgSilver" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Enhanced
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotalPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTuePkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatPkgEnhanced" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunPkgEnhanced" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Standard
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotalPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTuePkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatPkgStandard" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunPkgStandard" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Basic
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotalPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTuePkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatPkgBasic" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunPkgBasic" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                TOTAL
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsTotTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevYearTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisYearTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevMonthTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisMonthTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsPrevWeekTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundsThisWeekTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundMonTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundTueTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundWedTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundThuTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundFriTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSatTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRefundSunTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="clear" style="height: 20px;">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <h4 class="h43">
                        SALES BY SOURCE</h4>
                    <table class="grid1" cellpadding="0" cellspacing="0" style="padding: 2px; border: #ccc 1px solid;">
                        <tr class="tbHed">
                            <td style="width: 105px;">
                                Name
                            </td>
                            <td>
                                Total
                            </td>
                            <td>
                                Prev Year
                            </td>
                            <td>
                                This year
                            </td>
                            <td>
                                Prev month
                            </td>
                            <td>
                                This month
                            </td>
                            <td>
                                Prev week
                            </td>
                            <td>
                                This week
                            </td>
                            <td>
                                Mon
                            </td>
                            <td>
                                Tue
                            </td>
                            <td>
                                Wed
                            </td>
                            <td>
                                Thu
                            </td>
                            <td>
                                Fri
                            </td>
                            <td>
                                Sat
                            </td>
                            <td>
                                Sun
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Sales By Online
                            </td>
                            <td>
                                <asp:Label ID="lblTotalOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevYearOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisYearOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevMonthOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisMonthOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevWeekOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisWeekOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTueOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatOnline" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunOnline" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Sales By Smartz
                            </td>
                            <td>
                                <asp:Label ID="lblTotalSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevYearSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisYearSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevMonthSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisMonthSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevWeekSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisWeekSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblMonSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblTueSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblWedSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThuSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblFriSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSatSmartz" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSunSmartz" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                TOTAL
                            </td>
                            <td>
                                <asp:Label ID="lblTotalTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevYearTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisYearTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevMonthTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisMonthTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrevWeekTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblThisWeekTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesByMonTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesByTueTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesByWedTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesByThuTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesByFriTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesBySatTotal" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblSalesBySunTotal" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <div class="clear" style="height: 20px;">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <h4 class="h43">
                        REVENUE</h4>
                    <table class="grid1" cellpadding="0" cellspacing="0" style="padding: 2px; border: #ccc 1px solid;">
                        <tr class="tbHed">
                            <td style="width: 105px;">
                                Name
                            </td>
                            <td>
                                Total
                            </td>
                            <td>
                                Prev Year
                            </td>
                            <td>
                                This year
                            </td>
                            <td>
                                Prev month
                            </td>
                            <td>
                                This month
                            </td>
                            <td>
                                Prev week
                            </td>
                            <td>
                                This week
                            </td>
                            <td>
                                Mon
                            </td>
                            <td>
                                Tue
                            </td>
                            <td>
                                Wed
                            </td>
                            <td>
                                Thu
                            </td>
                            <td>
                                Fri
                            </td>
                            <td>
                                Sat
                            </td>
                            <td>
                                Sun
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Sales Rev
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Billed
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Declines
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Refunds
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Chargebacks
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear" style="height: 20px;">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <h4 class="h43">
                        Cars Details - Work Done</h4>
                    <table class="grid1" cellpadding="0" cellspacing="0" style="padding: 2px; border: #ccc 1px solid;">
                        <tr class="tbHed">
                            <td style="width: 105px;">
                                Name
                            </td>
                            <td>
                                Total
                            </td>
                            <td>
                                Prev Year
                            </td>
                            <td>
                                This year
                            </td>
                            <td>
                                Prev month
                            </td>
                            <td>
                                This month
                            </td>
                            <td>
                                Prev week
                            </td>
                            <td>
                                This week
                            </td>
                            <td>
                                Mon
                            </td>
                            <td>
                                Tue
                            </td>
                            <td>
                                Wed
                            </td>
                            <td>
                                Thu
                            </td>
                            <td>
                                Fri
                            </td>
                            <td>
                                Sat
                            </td>
                            <td>
                                Sun
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Data Entry
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Pictures
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Welcome Letters
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Welcome Calls
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Cust Serv Calls
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Multi-site postings
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear" style="height: 20px;">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top;">
                    <table class="grid1" cellpadding="0" cellspacing="0" style="width: 220px; padding: 2px;
                        border: #ccc 1px solid;">
                        <tr class="tbHed">
                            <td style="width: 105px;">
                                Pending/Open
                            </td>
                            <td>
                                &nbsp
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Data Entry
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Pictures
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Welcome Letters
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Welcome Calls
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row1">
                            <td class="hed">
                                Cust Serv Calls
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr class="row2">
                            <td class="hed">
                                Multi-site postings
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear" style="height: 20px;">
                        &nbsp;</div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <%-- <div class="footer">
        United Car Exchange © 2012</div>--%>
    </form>
</body>
</html>
