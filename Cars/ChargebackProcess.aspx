<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargebackProcess.aspx.cs"
    Inherits="ChargebackProcess" ValidateRequest="false" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

    <script>
    function sample()
    {
    alert('Some data will missed because customer not yet selected');
    }
    function sample1()
    {
    alert('Some checked');
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="" DisplayAfter="0">
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
            Chargeback Process</h1>
        <div class="clear">
            &nbsp;</div>
        <div>
            <table style="width: 99%; border-collapse: collapse;" class="difTable1">
                <tr>
                    <td style="width: 24%;">
                        <label>
                            Notice ID:</label>
                        <asp:Label ID="lblNoticeID" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        <label>
                            Notice Type:</label>
                        <asp:Label ID="lblNoticeType" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        <label>
                            Notice Dt:</label>
                        <asp:Label ID="lblNoticeDate" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        <label>
                            Case #:</label>
                        <asp:Label ID="lblCaseNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24%;">
                        <label>
                            Reply By Dt:</label>
                        <asp:Label ID="lblReplyByDt" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        <label>
                            Replied Dt:</label>
                        <asp:Label ID="lblRepliedDt" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        <label>
                            Dispute$:</label>
                        <asp:Label ID="lblDisputeAmt" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        <div style="float: left;">
                            <asp:UpdatePanel ID="updtpnlfda" runat="server">
                                <ContentTemplate>
                                    <label>
                                        Status:</label>
                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div align="right" style="padding-right: 20px">
                            <asp:UpdatePanel ID="updtpnlPDupdate" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="lnkbtnUpdateNotice" Text="Update" runat="server" OnClick="lnkbtnUpdateNotice_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 24%;">
                        <label>
                            Prev Notice ID:</label>
                        <asp:Label ID="lblPrevNoticeID" runat="server"></asp:Label>
                    </td>
                    <td style="width: 24%;">
                        &nbsp;
                    </td>
                    <td style="width: 24%;">
                        &nbsp;
                    </td>
                    <td style="width: 24%;">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        Reasons:</label>
                        <asp:Label ID="lblReasons" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="updtpnldata" runat="server">
                <ContentTemplate>
                    <table style="border: solid 1px #ccc; width: 100%;" cellpadding="10">
                        <tr>
                            <td style="width: 30%">
                                <h1 class="h1" style="padding-bottom: 0">
                                    Review Notice</h1>
                                <ul class="nostyle1">
                                    <li>
                                        <asp:LinkButton ID="lnkbtnNoticeCopy" runat="server" Text="Notice Copy" OnClick="lnkbtnNoticeCopy_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnNoticeData" runat="server" Text="Notice Data" OnClick="lnkbtnNoticeData_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnCustomerData" runat="server" Text="Customer Data" OnClick="lnkbtnCustomerData_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnPaymentData" runat="server" Text="Package/Payment Data"
                                            OnClick="lnkbtnPaymentData_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnVehicleData" runat="server" Text="Vehicle Data" OnClick="lnkbtnVehicleData_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnresponseInfo" runat="server" Text="Contact Info for Response"
                                            OnClick="lnkbtnresponseInfo_Click"></asp:LinkButton>
                                    </li>
                                </ul>
                            </td>
                            <td style="width: 30%; border-left: #ccc 1px dotted; border-right: #ccc 1px dotted">
                                <h1 class="h1" style="padding-bottom: 0">
                                    View/Prepare Documents</h1>
                                <ul class="nostyle1">
                                    <li>
                                        <asp:LinkButton ID="lnkbtnAuthorizationLetter" runat="server" Text="Letter of Authorization"
                                            OnClick="lnkbtnAuthorizationLetter_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnWelcomeEmail" runat="server" Text="Welcome Email" OnClick="lnkbtnWelcomeEmail_Click"></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnkbtnUCEAdv" runat="server" Text="UCE Advertisement" OnClick="lnkbtnUCEAdv_Click"></asp:LinkButton>
                                    </li>
                                    <%--<li>
                                        <asp:Label ID="lblExpErr" runat="server"></asp:Label>
                                    </li>--%>
                                </ul>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <cc1:ModalPopupExtender ID="mpeAskNewSale" runat="server" PopupControlID="tblAskNewSale"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAskNewSale" CancelControlID="btnUpPdCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAskNewSale" runat="server" />
    <div id="tblAskNewSale" style="display: none; background-color: #adbc79; width: 300px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="3" style="background: #E7E7E7 url(../images/price-list-bg2.jpg) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Update Notice Status
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="padding-left: 5px; width: 60px">
                                Status
                            </td>
                            <td style="padding-right: 5px; width: 100px">
                                <asp:UpdatePanel ID="updtpnlPDUpdateMdep" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPopStatus" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 10px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0 0 20px 0;" colspan="3">
                                <div align="center" style="width: 70%; padding-left: 50px">
                                    <div style="float: left">
                                        <asp:UpdatePanel ID="PDBTNUPDatepnl" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnPopNoticeStatusUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit"
                                                    OnClick="btnPopNoticeStatusUpdate_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div>
                                        &nbsp;
                                        <asp:Button ID="btnUpPdCancel" CssClass="g-button g-button-submit" runat="server"
                                            Text="Cancel" Style="float: none" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:ModalPopupExtender ID="mpeViewNoticeCopy" runat="server" PopupControlID="divViewNoticeCopy"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewrNoticeCopy" CancelControlID="btnCancelNoticeCopy">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewrNoticeCopy" runat="server" />
    <div id="divViewNoticeCopy" class="PopUpHolder">
        <div class="main">
            <h4>
                Notice Copy
            </h4>
            <div class="dat">
                <br />
                <div style="height: 380px;">
                    <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                        <ContentTemplate>
                            <asp:Image ID="imgNoticeCopy" runat="server" Height="350px" Width="520px" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelNoticeCopy" class="g-button btnUpdate" runat="server" Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="MdepNoticeData" runat="server" PopupControlID="divViewNoticeData"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewNoticeData" CancelControlID="btnCancelNoticeData">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewNoticeData" runat="server" />
    <div id="divViewNoticeData" class="PopUpHolder">
        <div class="main">
            <h4>
                Notice Data
            </h4>
            <div class="dat">
                <br />
                <div style="height: 250px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 200px;">
                                        <label>
                                            Notice ID:</label>
                                        <asp:Label ID="lblPopNoticeID" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            Notice Type:</label>
                                        <asp:Label ID="lblPopNoticeType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Notice Dt:</label>
                                        <asp:Label ID="lblPopNoticeDt" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            Case #:</label>
                                        <asp:Label ID="lblPopCaseNum" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Reply By Dt:</label>
                                        <asp:Label ID="lblPopReplyByDt" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            Reply Dt:</label>
                                        <asp:Label ID="lblPopReplyDt" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Dispute $:</label>
                                        <asp:Label ID="lblpopAmt" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            Status:</label>
                                        <asp:Label ID="lblPopStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Prev NoticeID:</label>
                                        <asp:Label ID="lblPopPrevNoticeID" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <label>
                                            Reasons:</label>
                                        <asp:Label ID="lblPopReasons" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <label>
                                            Notes:</label>
                                        <asp:TextBox ID="lblPopCBNotes" runat="server" ReadOnly="true" CssClass="textarea"
                                            Style="width: 98%; padding: 3px; margin-top: 6px; height: 60px; background: #eee"
                                            TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelNoticeData" class="g-button btnUpdate" runat="server" Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="MdepCustDetails" runat="server" PopupControlID="divViewMdepCustDetails"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewrMdepCustDetails" CancelControlID="btnCancelCustDetails">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewrMdepCustDetails" runat="server" />
    <div id="divViewMdepCustDetails" class="PopUpHolder">
        <div class="main">
            <h4>
                Customer Data
            </h4>
            <div class="dat">
                <br />
                <div style="height: 250px;">
                    <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblResult" runat="server" Visible="false" Style="color: Red;"></asp:Label>
                            <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 3px 3px 3px 3px;
                                border: #ccc 1px solid; height: 180px; display: none" id="divResults" runat="server">
                                <asp:Panel ID="pnl1" Width="100%" runat="server">
                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                    <table style="width: 400px;" class="scrollTable noPad">
                                        <asp:Repeater ID="grdIntroInfo" runat="server">
                                            <HeaderTemplate>
                                                <tr class="custHead">
                                                    <th style="width: 130px; text-align: left;">
                                                        Name
                                                    </th>
                                                    <th style="width: 80px; text-align: left;">
                                                        Phone
                                                    </th>
                                                    <th style="text-align: left;">
                                                        Email
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 130px; text-align: left;">
                                                        <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 80px; text-align: left;">
                                                        <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("phone")%>'></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"UserName"),25)%>'></asp:Label>
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
                <asp:Button ID="btnCancelCustDetails" class="g-button btnUpdate" runat="server" Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepPayData" runat="server" PopupControlID="divViewPayData"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewrPayData" CancelControlID="btnCancelPayData">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewrPayData" runat="server" />
    <div id="divViewPayData" class="PopUpHolder">
        <div class="main" style="width: 800px;">
            <h4>
                Package/Payment Data
            </h4>
            <div class="dat">
                <br />
                <div style="height: 250px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblPopPayData" runat="server" Visible="false" Style="color: Red;"></asp:Label>
                            <div style="width: 750px; position: relative; padding: 0 3px; height: 1px">
                                <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                    padding-top: 2px; width: 730px; background: #fff;">
                                    <tr class="tbHed">
                                        <td width="50px">
                                            Sno
                                        </td>
                                        <td>
                                            Package
                                        </td>
                                        <td width="100px">
                                            Dt Of Purchase
                                        </td>
                                        <td width="100px">
                                            Pay Type
                                        </td>
                                        <td width="80px">
                                            Tran ID
                                        </td>
                                        <td width="100px">
                                            Status
                                        </td>
                                        <td width="100px">
                                            Conf #
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 750px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                border: #ccc 1px solid; height: 200px">
                                <asp:Panel ID="Panel3" Width="100%" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <input style="width: 91px" id="Hidden5" type="hidden" runat="server" enableviewstate="true" />
                                            <input style="width: 40px" id="Hidden6" type="hidden" runat="server" enableviewstate="true" />
                                            <asp:GridView Width="730px" ID="grdPackagDetails" runat="server" CellSpacing="0"
                                                CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                ShowHeader="false" OnRowDataBound="grdPackagDetails_RowDataBound">
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
                                                            <%# ((GridViewRow)Container).RowIndex + 1%>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <%-- <asp:Label ID="lblPackage" runat="server"></asp:Label>--%>
                                                            <asp:Label ID="lnkbtnPackage" runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnPackDescrip" runat="server" Value='<%# Eval("Description")%>' />
                                                            <asp:HiddenField ID="hdnUserPackID" runat="server" Value='<%# Eval("Price")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPaydate" runat="server" Text='<%# Bind("Paydate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ValidTill">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPayType" runat="server" Text='<%# Eval("PaymentTypeName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTranID" runat="server" Text='<%# Eval("TransactionID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("PaymentStatusName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblConfNum" runat="server" Text='<%# Eval("VoiceRecord")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdPackagDetails" EventName="Sorting" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdIntroInfo" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelPayData" class="g-button btnUpdate" runat="server" Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepCarDetails" runat="server" PopupControlID="divViewCarDetails"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewrCarDetails" CancelControlID="btnCancelCarDetails">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewrCarDetails" runat="server" />
    <div id="divViewCarDetails" class="PopUpHolder">
        <div class="main" style="width: 900px;">
            <h4>
                Vehicle Data
            </h4>
            <div class="dat">
                <br />
                <div style="height: 250px;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblErrVehicle" runat="server" Visible="false" Style="color: Red;"></asp:Label>
                            <div style="width: 840px; position: relative; padding: 0 3px; height: 1px">
                                <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                    padding-top: 2px; width: 820px; background: #fff;">
                                    <tr class="tbHed">
                                        <td width="70px">
                                            CarID
                                        </td>
                                        <td width="40px">
                                            <asp:Label ID="lblStatusHeader" runat="server" Text="Status"></asp:Label>
                                        </td>
                                        <td width="70px">
                                            Post Date
                                        </td>
                                        <td width="160px">
                                            Package
                                        </td>
                                        <td width="120px">
                                            Make
                                        </td>
                                        <td>
                                            Model
                                        </td>
                                        <td width="50px">
                                            Year
                                        </td>
                                        <td width="60px">
                                            Miles
                                        </td>
                                        <td width="60px">
                                            Price
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 840px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                border: #ccc 1px solid; height: 200px">
                                <asp:Panel ID="Panel2" Width="100%" runat="server">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                                            <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                                            <asp:GridView Width="820px" ID="grdCarDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                OnRowDataBound="grdCarDetails_RowDataBound">
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
                                                            <%--  <asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                            <asp:Label ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Image ID="ImgStatus" runat="server" />
                                                            <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("isActive")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPostDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnPackDescription" runat="server" Value='<%# Eval("PackageName")%>' />
                                                            <asp:HiddenField ID="hdnPackUserPackID" runat="server" Value='<%# Eval("PackagePrice")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblModel" runat="server" Text='<%# Eval("model")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMiles" runat="server" Text='<%# Eval("mileage")%>' CssClass="mileage"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPrice" runat="server" CssClass="price"></asp:Label>
                                                            <asp:HiddenField ID="hdncarPrice" runat="server" Value='<%# Eval("price")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="grdCarDetails" EventName="Sorting" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="grdIntroInfo" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelCarDetails" class="g-button btnUpdate" runat="server" Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepReplyInfo" runat="server" PopupControlID="divViewReplyInfo"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewReplyInfo" CancelControlID="btnCancelReplyInfo">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewReplyInfo" runat="server" />
    <div id="divViewReplyInfo" class="PopUpHolder">
        <div class="main" style="width: 500px;">
            <h4>
                Contact Info For Response
            </h4>
            <div class="dat">
                <br />
                <div style="height: 120px;">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <table width="100%">
                                <tr>
                                    <td style="width: 220px;">
                                        <label>
                                            Reply Method:</label>
                                        <asp:Label ID="lblPopreplyMethod" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            Email:</label>
                                        <asp:Label ID="lblPopReplyEmail" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Fax #:</label>
                                        <asp:Label ID="lblPopreplyFaxNum" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            City:</label>
                                        <asp:Label ID="lblPopReplyCity" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Address:</label>
                                        <asp:Label ID="lblPopReplyAddress" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <label>
                                            State:</label>
                                        <asp:Label ID="lblPopreplyState" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Zip:</label>
                                        <asp:Label ID="lblPopreplyZip" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelReplyInfo" class="g-button btnUpdate" runat="server" Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAuthorizeLetter" runat="server" PopupControlID="divViewAuthorizeLetter"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewAuthorizeLetter" CancelControlID="btnCancelAuthorizeLetter">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewAuthorizeLetter" runat="server" />
    <div id="divViewAuthorizeLetter" class="PopUpHolder">
        <div class="main">
            <h4>
                Letter of Authorization
            </h4>
            <div class="dat">
                <br />
                <div style="height: 380px;">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtgenMailText" runat="server" CssClass="textarea" TextMode="MultiLine"
                                MaxLength="5000" Style="height: 360px;"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnSaveAuthorizeLetter" class="g-button btnUpdate" runat="server"
                    Text="Save" OnClick="btnSaveAuthorizeLetter_Click" />
                <asp:Button ID="btnCancelAuthorizeLetter" class="g-button btnUpdate" runat="server"
                    Text="Close" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepCBAlert" runat="server" PopupControlID="divCBAlert"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnCBAlert" OkControlID="btnCBAlertClose"
        CancelControlID="btnCBAlertOK">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnCBAlert" runat="server" />
    <div id="divCBAlert" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnCBAlertClose" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblCBAlertMsg" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnCBAlertOK" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpeViewregisterMail" runat="server" PopupControlID="divViewregisterMail"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewregisterMail" CancelControlID="btnCancelSendRegMail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewregisterMail" runat="server" />
    <div id="divViewregisterMail" class="PopUpHolder">
        <div class="main">
            <h4>
                Welcome Mail
            </h4>
            <div class="dat">
                <br />
                <div>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="lblRegisMail" runat="server" CssClass="textarea" TextMode="MultiLine"
                                MaxLength="5000" Style="height: 350px;"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelSendRegMail" class="g-button btnUpdate" runat="server" Text="Cancel" />
                <asp:Button ID="btnSaveregMail" class="g-button btnUpdate" runat="server" Text="Save"
                    OnClick="btnSaveregMail_Click" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepWelcomeCheckpop" runat="server" PopupControlID="divWelcomeCheckpop"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnWelcomeCheckpop" CancelControlID="btnCancelWelcomeCheckpop">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnWelcomeCheckpop" runat="server" />
    <div id="divWelcomeCheckpop" class="PopUpHolder">
        <div class="main">
            <h4>
                Welcome Mail
            </h4>
            <div class="dat">
                <br />
                <div>
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <div>
                                <p>
                                    Dear
                                    <asp:Label ID="lblCustName" runat="server"></asp:Label>,</p>
                                <p>
                                    We would personally like to thank you for choosing United Car Exchange.<br />
                                    We would just like to let you know that your profile is already listed on our website
                                    and we have included your personalized username and password to access your account.</p>
                                <p>
                                    We do all the work for you, but we do ask for you to upload as many photographs
                                    of your vehicle as possible so that you may receive maximum exposure and interest.
                                    If you have any trouble accessing the website, or if you have any general questions
                                    or concerns you may reach our customer service department directly during regular
                                    business hours.</p>
                                <p>
                                    We will update you often to let you see first hand the progress being made to ensure
                                    you sell your truck or car as fast as possible.<br />
                                    You are in great hands, and just a few clicks away from getting a quick sale on
                                    your automobile!</p>
                                WWW.UNITEDCAREXCHANGE.COM<br />
                                USERNAME:
                                <asp:Label ID="lblUserID" runat="server"></asp:Label>
                                <br />
                                PASSWORD:
                                <asp:Label ID="lblUserPassword" runat="server"></asp:Label>
                                <br />
                                <br />
                                To see your Ad click here:
                                <asp:Label ID="lblUceAdLink" runat="server"></asp:Label><br />
                                To see terms & conditions click here:
                                <asp:Label ID="lblUcetermsAndCondLink" runat="server"></asp:Label>
                                <br />
                                <br />
                                Sincerely,<br />
                                The United Car Exchange Team<br />
                                1(888)786-8307
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelWelcomeCheckpop" class="g-button btnUpdate" runat="server"
                    Text="Cancel" />
                <asp:Button ID="btnSaveWelcomeCheckpop" class="g-button btnUpdate" runat="server"
                    Text="Save" OnClick="btnSaveWelcomeCheckpop_Click" />
                <div class="clear">
                    &nbsp;</div>
                <br />
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
