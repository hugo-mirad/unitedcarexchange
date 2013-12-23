<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargebackClaims.aspx.cs"
    Inherits="ChargebackClaims" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

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
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdatePanelBtnSearchUserDetails"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="headder">
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;
        </div>
    </div>
    <div class="main">
        <h1 class="h1">
            Chargeback Claims</h1>
        <div class="clear">
            &nbsp;</div>
        <div style="width: 40%;">
            <table>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                        CB Status:<br />
                        <asp:DropDownList ID="ddlCBStatus" runat="server" Width="200px" CssClass="input1">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanelBtnSearchUserDetails" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnSearchCBDetails" runat="server" Text="Go" CssClass="g-button g-button-submit"
                                    Style="margin-top: 14px;" OnClick="btnSearchCBDetails_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 950px;" id="divresults" runat="server">
            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblResult" runat="server"></asp:Label>
                    <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 3px 3px 3px 3px;
                        border: #ccc 1px solid; height: 280px" id="div1" runat="server">
                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                            <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                            <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                            <table style="width: 950px;" class="scrollTable noPad">
                                <asp:Repeater ID="grdIntroInfo" runat="server" OnItemCommand="grdIntroInfo_ItemCommand">
                                    <HeaderTemplate>
                                        <tr>
                                            <th style="width: 60px; text-align: left;">
                                                CBID
                                            </th>
                                            <th style="width: 130px; text-align: left;">
                                                Name
                                            </th>
                                            <th style="width: 80px; text-align: left;">
                                                CB Dt
                                            </th>
                                            <th style="width: 80px; text-align: left;">
                                                Response Dt
                                            </th>
                                            <th style="width: 130px; text-align: left;">
                                                Response By
                                            </th>
                                            <th style="width: 90px; text-align: left;">
                                                CB Type
                                            </th>
                                            <th style="width: 100px; text-align: left;">
                                                Status
                                            </th>
                                            <th style="width: 80px; text-align: left;">
                                                Closed Dt
                                            </th>
                                            <th style="text-align: left;">
                                                Closed By
                                            </th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="width: 60px; text-align: left;">
                                                <asp:LinkButton ID="lnkCBID" runat="server" Text='<%# Eval("ChargeBackID")%>' CommandArgument='<%# Eval("UId")%>'
                                                    CommandName="EditCBData"></asp:LinkButton>
                                            </td>
                                            <td style="width: 130px; text-align: left;">
                                                <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                            </td>
                                            <td style="width: 80px; text-align: left;">
                                                <asp:Label ID="lblCBDate" runat="server" Text='<%# Bind("ChargeBackDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                            </td>
                                            <td style="width: 80px; text-align: left;">
                                                <asp:Label ID="lblResponseDate" runat="server" Text='<%# Bind("ResponseDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                            </td>
                                            <td style="width: 130px; text-align: left;">
                                                <asp:Label ID="lblResponseBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"REsponseBYName"),15)%>'></asp:Label>
                                            </td>
                                            <td style="width: 90px; text-align: left;">
                                                <asp:Label ID="lblCBType" runat="server" Text='<%# Eval("ProcessorName")%>'></asp:Label>
                                            </td>
                                            <td style="width: 100px; text-align: left;">
                                                <asp:Label ID="lblCBStatus" runat="server" Text='<%# Eval("ChargeBackStatusName")%>'></asp:Label>
                                            </td>
                                            <td style="width: 80px; text-align: left;">
                                                <asp:Label ID="lblCBClosedDate" runat="server" Text='<%# Bind("CBClosedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                            </td>
                                            <td style="text-align: left;">
                                                <asp:Label ID="lblCBClosedBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CBClosedByName"),15)%>'></asp:Label>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="grdIntroInfo" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    </form>
</body>
</html>
