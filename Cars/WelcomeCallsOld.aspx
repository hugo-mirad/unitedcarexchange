<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WelcomeCallsOld.aspx.cs" Inherits="WelcomeCalls" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
                            <%--<input type="radio" name="showType" />
                    Pending--%>
                            <asp:RadioButton ID="rdbtnPending" runat="server" GroupName="ShowType" Text="Pending"
                                AutoPostBack="true" OnCheckedChanged="btnShow_Click" />
                        </td>
                        <td style="width: 50px; padding-top: 10px;">
                            <%-- <input type="radio" name="showType" />
                    All--%>
                            <asp:RadioButton ID="rdbtnAll" runat="server" GroupName="ShowType" Text="All" Checked="true"
                                AutoPostBack="true" OnCheckedChanged="btnShow_Click" />
                        </td>
                        <td>
                            <%--<input type="button" class="g-button g-button-submit" value="Show" />--%>
                            <%--<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="g-button g-button-submit"
                                OnClick="btnShow_Click" />--%>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="80%">
                                        <%-- Showing up to latest 500 records--%>
                                        <asp:Label ID="lblResHead" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <%-- Record count: 23--%>
                                        <asp:Label ID="lblResCount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                            <%--Status--%>
                                            <asp:LinkButton ID="lnkStatusSort" runat="server" Text="Ad St &darr; &uarr;" OnClick="lnkStatusSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="65px" align="left">
                                            <asp:LinkButton ID="lnkWcStatus" runat="server" Text="WC St &darr; &uarr;" OnClick="lnkWcStatus_Click"></asp:LinkButton>
                                        </td>
                                        <td width="65px" align="left">
                                            <asp:LinkButton ID="lnkSaleDateSort" runat="server" Text="Sale Dt &#8657" OnClick="lnkSaleDateSort_Click"></asp:LinkButton>
                                            <%--Posted Dt--%>
                                        </td>
                                        <td width="80px" align="left">
                                            <asp:LinkButton ID="lnkPostedSort" runat="server" Text="Posted Dt &darr; &uarr;"
                                                OnClick="lnkPostedSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="80px" align="left">
                                            <asp:LinkButton ID="lnkAgentSort" runat="server" Text="Agent &darr; &uarr;" OnClick="lnkAgentSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="110px" align="left">
                                            <%--Name--%>
                                            <asp:LinkButton ID="lnkNameSort" runat="server" Text="Name &darr; &uarr;" OnClick="lnkNameSort_Click"></asp:LinkButton>
                                        </td>
                                        <%--<td width="35px">
                                    State
                                </td>--%>
                                        <td width="80px" align="left">
                                            <asp:LinkButton ID="lnkPhoneSort" runat="server" Text="Phone &darr; &uarr;" OnClick="lnkPhoneSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="65px" align="left">
                                            <asp:LinkButton ID="lnkWCDt" runat="server" Text="WC Dt &darr; &uarr;" OnClick="lnkWCDt_Click"></asp:LinkButton>
                                        </td>
                                        <td width="80px" align="left">
                                            <asp:LinkButton ID="lnkWCBy" runat="server" Text="WC By &darr; &uarr;" OnClick="lnkWCBy_Click"></asp:LinkButton>
                                        </td>
                                        <td width="140px" align="left">
                                            <asp:LinkButton ID="lnkPackageSort" runat="server" Text="Package &darr; &uarr;" OnClick="lnkPackageSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="50px" align="left">
                                            <asp:LinkButton ID="lnkYearSort" runat="server" Text="Year &darr; &uarr;" OnClick="lnkYearSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="100px" align="left">
                                            <asp:LinkButton ID="lnkMakeSort" runat="server" Text="Make &darr; &uarr;" OnClick="lnkMakeSort_Click"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkModelSort" runat="server" Text="Model &darr; &uarr;" OnClick="lnkModelSort_Click"></asp:LinkButton>
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
                                                    <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblStatus" runat="server" ></asp:Label>--%>
                                                    <asp:Image ID="ImgStatus" runat="server" />
                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("isActive")%>' />
                                                    <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblWCStatus" runat="server"></asp:Label>--%>
                                                    <asp:Image ID="ImgWCStatus" runat="server" />
                                                    <asp:HiddenField ID="hdnWCCallID" runat="server" Value='<%# Eval("WCCallID")%>' />
                                                    <asp:HiddenField ID="hdnWCStatus" runat="server" Value='<%# Eval("WCStatus")%>' />
                                                    <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
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
                                                    <asp:Label ID="lblAgent" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"ReferCode")),10) %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),13)%>'></asp:Label>
                                                    <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="110px" />
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblState" runat="server"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="35px" />
                                            </asp:TemplateField>--%>
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
                                                    <asp:Label ID="lblPrice" runat="server" CssClass="price"></asp:Label>
                                                    <asp:HiddenField ID="hdnPackCost" runat="server" Value='<%# Eval("Price")%>' />
                                                    <asp:HiddenField ID="hdnPackName" runat="server" Value='<%# Eval("Description")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblModel" runat="server" Text='<%# Eval("model")%>'></asp:Label>
                                                    <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPmnt" runat="server" Text='<%# Eval("CustomerEmail")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="45px" />
                                                </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdWelcomeDetails" EventName="Sorting" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    </form>
</body>
</html>
