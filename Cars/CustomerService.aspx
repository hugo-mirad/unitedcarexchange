<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerService.aspx.cs"
    Inherits="CustomerService" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
	});
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdPnlGrid"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlHeaders"
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
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="updtpnltblGrdcar"
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
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            Customer Service</h1>
        <div class="clear">
            &nbsp;</div>
     
        <asp:UpdatePanel ID="updtpnltblGrdcar" runat="server">
            <ContentTemplate>
                <table style="width: 100%;" id="tblTicketDetails" runat="server">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="80%">
                                                <asp:LinkButton ID="lnkbtnCarsResCount" runat="server" OnClick="lnkbtnCarsResCount_Click"></asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnRVSResCount" runat="server" OnClick="lnkbtnRVSResCount_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="lblResCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div id="divCarResults" runat="server">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="updtPnlHeaders" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1160px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCSIDHead" runat="server" Text="CS CallID &darr; &uarr;"
                                                            OnClick="lnkbtnCSIDHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="120px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCallDateHead" runat="server" Text="Call Dt &#8659" OnClick="lnkbtnCallDateHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCarIDHead" runat="server" Text="Car ID &darr; &uarr;" OnClick="lnkbtnCarIDHead_Click"></asp:LinkButton>
                                                    </td>
                                                     <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkBrand" runat="server" Text="Brand &darr; &uarr;" OnClick="lnkBrand_Click"></asp:LinkButton>
                                                    </td>
                                                    
                                                    <td width="100px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCallByHead" runat="server" Text="Call By &darr; &uarr;"
                                                            OnClick="lnkbtnCallByHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="150px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCallTypeHead" runat="server" Text="Call Type &darr; &uarr;"
                                                            OnClick="lnkbtnCallTypeHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="150px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCallReasonHead" runat="server" Text="Call Reason &darr; &uarr;"
                                                            OnClick="lnkbtnCallReasonHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="120px" align="left">
                                                        <asp:LinkButton ID="lnkbtnSpokenWithHead" runat="server" Text="Spoken With &darr; &uarr;"
                                                            OnClick="lnkbtnSpokenWithHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnTicketIDHead" runat="server" Text="Ticket ID &darr; &uarr;"
                                                            OnClick="lnkbtnTicketIDHead_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkbtnCallResolutionHead" runat="server" Text="Call Resolution &darr; &uarr;"
                                                            OnClick="lnkbtnCallResolutionHead_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1180px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="pnl1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1160px" ID="grdCSDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                    OnRowCommand="grdCSDetails_RowCommand" 
                                                    onrowdatabound="grdCSDetails_RowDataBound">
                                                    <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle CssClass="headder" />
                                                    <PagerSettings Position="Top" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle CssClass="row1" />
                                                    <AlternatingRowStyle CssClass="row2" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblCSID" runat="server" Text='<%# Eval("CallID")%>'></asp:Label>--%>
                                                                <asp:LinkButton ID="lnkbtnCSCallID" runat="server" Text='<%# Eval("CallID")%>' CommandArgument='<%# Eval("CallID")%>'
                                                                    CommandName="EditCSID"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCallDt" runat="server" Text='<%# Bind("CallDate", "{0:MM/dd/yy hh-mm tt}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnCarID" runat="server" Text='<%# Eval("CarID")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCarID"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBrand" runat="server" Text='<%# Eval("BrandCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAgent" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CallAgentID"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCallType" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CallTypeName"),25)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCallReason" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CallReasonName"),25) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSpokenWith" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SpokeWith"),20)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkTicketID" runat="server" Text='<%# Eval("TicketID")%>' CommandArgument='<%# Eval("TicketID")%>'
                                                                    CommandName="EditTicket"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCallResolution" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CSResolutionName"),30)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdCSDetails" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div id="divRVDetails" runat="server">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1080px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvCSCallIDSort" runat="server" Text="CS CallID &darr; &uarr;"
                                                            OnClick="lnkbtnRvCSCallIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="120px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvCallDtSort" runat="server" Text="Call Dt &#8659" OnClick="lnkbtnRvCallDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkBtnRVIDSort" runat="server" Text="RV ID &darr; &uarr;" OnClick="lnkBtnRVIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCallBySort" runat="server" Text="Call By &darr; &uarr;"
                                                            OnClick="lnkbtnCallBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="150px" align="left">
                                                        <asp:LinkButton ID="lnkbtnCalltypeSort" runat="server" Text="Call Type &darr; &uarr;"
                                                            OnClick="lnkbtnCalltypeSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="150px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvCallReaonSort" runat="server" Text="Call Reason &darr; &uarr;"
                                                            OnClick="lnkbtnRvCallReaonSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="120px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvSpokenWithSort" runat="server" Text="Spoken With &darr; &uarr;"
                                                            OnClick="lnkbtnRvSpokenWithSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvTicketIDSort" runat="server" Text="Ticket ID &darr; &uarr;"
                                                            OnClick="lnkbtnRvTicketIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkbtnRvCallResolutionSort" runat="server" Text="Call Resolution &darr; &uarr;"
                                                            OnClick="lnkbtnRvCallResolutionSort_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1100px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="Panel1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1080px" ID="grdRVCSDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                    OnRowCommand="grdRVCSDetails_RowCommand">
                                                    <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle CssClass="headder" />
                                                    <PagerSettings Position="Top" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle CssClass="row1" />
                                                    <AlternatingRowStyle CssClass="row2" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblCSID" runat="server" Text='<%# Eval("CallID")%>'></asp:Label>--%>
                                                                <asp:LinkButton ID="lnkbtnRVCSCallID" runat="server" Text='<%# Eval("CallID")%>'
                                                                    CommandArgument='<%# Eval("CallID")%>' CommandName="EditCSID"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVCallDt" runat="server" Text='<%# Bind("CallDate", "{0:MM/dd/yy hh-mm tt}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnRVID" runat="server" Text='<%# Eval("CarID")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCarID"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVAgent" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CallAgentID"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVCallType" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CallTypeName"),25)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVCallReason" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CallReasonName"),25) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVSpokenWith" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SpokeWith"),20)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRVTicketID" runat="server" Text='<%# Eval("TicketID")%>' CommandArgument='<%# Eval("TicketID")%>'
                                                                    CommandName="EditTicket"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVCallResolution" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CSResolutionName"),30)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdRVCSDetails" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepCSIDPopup" runat="server" PopupControlID="divCSIDPopup"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnCSIDPopup" CancelControlID="btnCSIDOK">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnCSIDPopup" runat="server" />
    <div id="divCSIDPopup" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                CS Call Details</h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="updtpnlCSPop" runat="server">
                                <ContentTemplate>
                                    <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 90px;">
                                                Call ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Vehicle ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCarID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Date
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Agent
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallAgent" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Spoken With
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallSpokenWith" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Type
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Reason
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallReason" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Status
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Notes
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallNotes" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnCSIDOK" runat="server" CssClass="g-button g-button-submit" Text="Ok" />
                        </td>
                    </tr>
                </table>
            </div>
       </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepTicketAlertView" runat="server" PopupControlID="divTicketAlertView"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnTicketAlertView" CancelControlID="btnJustCheckingView">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnTicketAlertView" runat="server" />
    <div id="divTicketAlertView" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                Ticket Details
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdtPopupDdl" runat="server">
                                <ContentTemplate>
                                    <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 90px;">
                                                Tkt ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Vehicle ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopCarID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Type
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Created Dt
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketCreatedDt" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Created By
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketCreatedBy" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Priority
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopPriority" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Callback Dt
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPostDate" runat="server" CssClass="input3" MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                    Width="100px"></asp:TextBox>&nbsp;
                                                <img id="imgcal" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtPostDate,'mm/dd/yyyy',this);"
                                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Description
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTktDescrip" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Status
                                            </td>
                                            <td>
                                                <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                                <asp:DropDownList ID="ddlTicketStatus" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Assigned To
                                            </td>
                                            <td>
                                                <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                                <asp:DropDownList ID="ddlAssignedTo" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Completed By
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompletedBy" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Completed Dt
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCompletedDt" runat="server" CssClass="input3" MaxLength="10"
                                                    onkeypress="return isNumberKeyForDt(event)" Width="100px"></asp:TextBox>&nbsp;
                                                <img id="img21" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtCompletedDt,'mm/dd/yyyy',this);"
                                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Comments
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPopTktComments" runat="server" CssClass="textarea" MaxLength="200"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 90px;">
                                    </td>
                                    <td>
                                        <%--  <input type="button" value="Save" class="g-button g-button-submit" />
                                            <input type="button" value="Just Checking" class="g-button g-button-submit" />--%>
                                        <asp:UpdatePanel ID="updtPnlSave" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSaveTicketView" runat="server" CssClass="g-button g-button-submit"
                                                    Text="Save" OnClientClick="return ValidateData();" OnClick="btnSaveTicketView_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:LinkButton ID="btnJustCheckingView" runat="server" Style="float: right; margin-top: 6px;"
                                            Text="Just Checking" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    </form>
</body>
</html>
