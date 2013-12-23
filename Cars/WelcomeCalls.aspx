<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WelcomeCalls.aspx.cs" Inherits="WelcomeCalls" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updtpnlTableShow"
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
            WELCOME CALLS</h1>
        <div class="clear">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTableShow" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td style="width: 85px; padding-top: 10px;">
                            <asp:RadioButton ID="rdbtnPending" runat="server" GroupName="ShowType" Text="Pending"
                                AutoPostBack="true" OnCheckedChanged="rdbtnPending_CheckedChanged" Checked="true" />
                        </td>
                        <td style="width: 50px; padding-top: 10px;">
                            <asp:RadioButton ID="rdbtnAll" runat="server" GroupName="ShowType" Text="All" AutoPostBack="true"
                                OnCheckedChanged="rdbtnAll_CheckedChanged" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnltblGrdcar" runat="server">
            <ContentTemplate>
                <table style="width: 100%;" id="tblWelcomeCallDetails" runat="server">
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
                                                top: 2px; padding-top: 2px; width: 1188px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="60px" align="left">
                                                        <asp:LinkButton ID="lnkCarIDSort" runat="server" Text="Car ID &darr; &uarr;" OnClick="lnkCarIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="60px">
                                                        <asp:LinkButton ID="lnkStatusSort" runat="server" Text="Ad St &darr; &uarr;" OnClick="lnkStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px" align="left">
                                                        <asp:LinkButton ID="lnkWcStatus" runat="server" Text="WC St &darr; &uarr;" OnClick="lnkWcStatus_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px" align="left">
                                                        <asp:LinkButton ID="lnkSaleDateSort" runat="server" Text="Sale Dt &#8657" OnClick="lnkSaleDateSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkPostedSort" runat="server" Text="Posted Dt &darr; &uarr;"
                                                            OnClick="lnkPostedSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkAgentSort" runat="server" Text="Agent &darr; &uarr;" OnClick="lnkAgentSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="110px" align="left">
                                                        <asp:LinkButton ID="lnkNameSort" runat="server" Text="Name &darr; &uarr;" OnClick="lnkNameSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkPhoneSort" runat="server" Text="Phone &darr; &uarr;" OnClick="lnkPhoneSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px" align="left">
                                                        <asp:LinkButton ID="lnkWCDt" runat="server" Text="WC Dt &darr; &uarr;" OnClick="lnkWCDt_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkWCBy" runat="server" Text="WC By &darr; &uarr;" OnClick="lnkWCBy_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lnkLastCallBySort" runat="server" Text="Last Call By &darr; &uarr;"
                                                            OnClick="lnkLastCallBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lnkLastCallDtSort" runat="server" Text="Last Call Dt &darr; &uarr;"
                                                            OnClick="lnkLastCallDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkLastCallStatusSort" runat="server" Text="Last Call Status &darr; &uarr;"
                                                            OnClick="lnkLastCallStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="90px">
                                                        <asp:LinkButton ID="lnkNoOfAttemptSort" runat="server" Text="No Of Calls &darr; &uarr;"
                                                            OnClick="lnkNoOfAttemptSort_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1208px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="pnl1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1188px" ID="grdWelcomeDetails" runat="server" CellSpacing="0"
                                                    CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                    ShowHeader="false" OnRowCommand="grdWelcomeDetails_RowCommand" OnRowDataBound="grdWelcomeDetails_RowDataBound">
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
                                                                <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCar"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgStatus" runat="server" />
                                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Adstatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgWCStatus" runat="server" />
                                                                <asp:HiddenField ID="hdnWCCallID" runat="server" Value='<%# Eval("WCCallID")%>' />
                                                                <asp:HiddenField ID="hdnWCStatus" runat="server" Value='<%# Eval("WCStatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSaleDt" runat="server" Text='<%# Bind("SaleDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostedDt" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAgent" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"First_Name")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),13)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPhoneNum" runat="server" Value='<%# Eval("PhoneNumber")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblWCCallDt" runat="server" Text='<%# Bind("CallDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblWCBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SmartzFirstName"),10)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastCallBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"LastAttemptBy"),10)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastCallDt" runat="server" Text='<%# Bind("LastAttemptDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLastCallStatus" runat="server" Text='<%# Eval("LastAttemptStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCount" runat="server" Text='<%# Eval("COUNT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdWelcomeDetails" EventName="Sorting" />
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
                                                top: 2px; padding-top: 2px; width: 1188px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="60px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvIDSort" runat="server" Text="RV ID &darr; &uarr;" OnClick="lnkbtnRvIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="60px">
                                                        <asp:LinkButton ID="lnkbtnRvAdStatusSort" runat="server" Text="Ad St &darr; &uarr;"
                                                            OnClick="lnkbtnRvAdStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvWCStatusSort" runat="server" Text="WC St &darr; &uarr;"
                                                            OnClick="lnkbtnRvWCStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvSaleDtSort" runat="server" Text="Sale Dt &#8657" OnClick="lnkbtnRvSaleDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvPostedDtSort" runat="server" Text="Posted Dt &darr; &uarr;"
                                                            OnClick="lnkbtnRvPostedDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRVAgentSort" runat="server" Text="Agent &darr; &uarr;"
                                                            OnClick="lnkbtnRVAgentSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="110px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvNameSort" runat="server" Text="Name &darr; &uarr;" OnClick="lnkbtnRvNameSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvPhoneSort" runat="server" Text="Phone &darr; &uarr;"
                                                            OnClick="lnkbtnRvPhoneSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRVWCDTSort" runat="server" Text="WC Dt &darr; &uarr;" OnClick="lnkbtnRVWCDTSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRVWCBYSort" runat="server" Text="WC By &darr; &uarr;" OnClick="lnkbtnRVWCBYSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvLastCallBySort" runat="server" Text="Last Call By &darr; &uarr;"
                                                            OnClick="lnkbtnRvLastCallBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lnkbtnRvLastCallDtSort" runat="server" Text="Last Call Dt &darr; &uarr;"
                                                            OnClick="lnkbtnRvLastCallDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lnkBtnRvLastCallStatusSort" runat="server" Text="Last Call Status &darr; &uarr;"
                                                            OnClick="lnkBtnRvLastCallStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="90px">
                                                        <asp:LinkButton ID="lnkbtnNOOFCallsSort" runat="server" Text="No Of Calls &darr; &uarr;"
                                                            OnClick="lnkbtnNOOFCallsSort_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1208px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="Panel1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1188px" ID="grdRvWelcomeCals" runat="server" CellSpacing="0"
                                                    CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                    ShowHeader="false" OnRowCommand="grdRvWelcomeCals_RowCommand" OnRowDataBound="grdRvWelcomeCals_RowDataBound">
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
                                                                <asp:LinkButton ID="lnkRvCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditRv"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgRvStatus" runat="server" />
                                                                <asp:HiddenField ID="hdnRvStatus" runat="server" Value='<%# Eval("Adstatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgRvWCStatus" runat="server" />
                                                                <asp:HiddenField ID="hdnRvWCCallID" runat="server" Value='<%# Eval("WCCallID")%>' />
                                                                <asp:HiddenField ID="hdnRvWCStatus" runat="server" Value='<%# Eval("WCStatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvSaleDt" runat="server" Text='<%# Bind("SaleDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPostedDt" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvAgent" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"First_Name")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),13)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnRvPhoneNum" runat="server" Value='<%# Eval("PhoneNumber")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvWCCallDt" runat="server" Text='<%# Bind("CallDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvWCBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SmartzFirstName"),10)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvLastCallBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"LastAttemptBy"),10)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvLastCallDt" runat="server" Text='<%# Bind("LastAttemptDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvLastCallStatus" runat="server" Text='<%# Eval("LastAttemptStatus")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvCount" runat="server" Text='<%# Eval("COUNT")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdRvWelcomeCals" EventName="Sorting" />
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
    </form>
</body>
</html>
