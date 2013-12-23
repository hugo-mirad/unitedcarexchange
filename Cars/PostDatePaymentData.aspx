<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostDatePaymentData.aspx.cs"
    Inherits="PostDatePaymentData" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
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

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdPnlGrid"
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
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="updtpnlRvheaders"
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
    <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="updtpnlRvGrid"
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
            POST DATE PAYMENT DATA</h1>
        <div class="clear">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTableShow" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 80px;">
                            <asp:RadioButton ID="rdbtnCars" runat="server" Checked="true" Text="Cars" GroupName="PDPAYDATA"
                                OnCheckedChanged="rdbtnCars_CheckedChanged" AutoPostBack="true" />
                        </td>
                        <td>
                            <asp:RadioButton ID="rdbtnRvs" runat="server" Text="Rvs" GroupName="PDPAYDATA" OnCheckedChanged="rdbtnRvs_CheckedChanged"
                                AutoPostBack="true" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <div class="clear" style="height: 10px; margin-top: 10px; border-top: 2px Solid #ccc;width:250px;">
                    &nbsp;</div>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 80px;">
                            <asp:LinkButton ID="lnkbtnPaid" runat="server" Text="Paid" OnClick="lnkbtnPaid_Click"></asp:LinkButton>
                        </td>
                        <td style="width: 80px;">
                            <asp:LinkButton ID="lnkbtnOpen" runat="server" Text="Open" OnClick="lnkbtnOpen_Click"></asp:LinkButton>
                        </td>
                        <td style="width: 80px;">
                            <asp:LinkButton ID="lnkbtnCancelled" runat="server" Text="Cancelled" OnClick="lnkbtnCancelled_Click"></asp:LinkButton>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear" style="height: 20px; margin-top: 10px; border-top: 2px dotted #ccc;">
            &nbsp;</div>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTotalData" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="80%">
                                                <asp:Label ID="lblResHead" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblResCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <div id="divCars" runat="server" style="width: 100%">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="updtPnlHeaders" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1310px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="60px" align="left">
                                                        <asp:LinkButton ID="lblCarID" runat="server" Text="Car ID &darr; &uarr;" OnClick="lblCarID_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="50px">
                                                        <asp:LinkButton ID="lblAdStatus" runat="server" Text="Ad St &darr; &uarr;" OnClick="lblAdStatus_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblSaleDate" runat="server" Text="Sale Dt &darr; &uarr;" OnClick="lblSaleDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblPostDate" runat="server" Text="Posted Dt &#8659" OnClick="lblPostDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblPDDate" runat="server" Text="PD Pay Dt &darr; &uarr;" OnClick="lblPDDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lblPaymentDate" runat="server" Text="Payment Dt &darr; &uarr;"
                                                            OnClick="lblPaymentDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblAgent" runat="server" Text="Agent &darr; &uarr;" OnClick="lblAgent_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="50px">
                                                        <asp:LinkButton ID="lblYear" runat="server" Text="Year &darr; &uarr;" OnClick="lblYear_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="100px">
                                                        <asp:LinkButton ID="lblMake" runat="server" Text="Make &darr; &uarr;" OnClick="lblMake_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lblModel" runat="server" Text="Model &darr; &uarr;" OnClick="lblModel_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="150px">
                                                        <asp:LinkButton ID="lblPackage" runat="server" Text="Package &darr; &uarr;" OnClick="lblPackage_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="110px">
                                                        <asp:LinkButton ID="lblName" runat="server" Text="Name &darr; &uarr;" OnClick="lblName_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="90px">
                                                        <asp:LinkButton ID="lblPhone" runat="server" Text="Phone &darr; &uarr;" OnClick="lblPhone_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="130px">
                                                        <asp:LinkButton ID="lblEmail" runat="server" Text="Email &darr; &uarr;" OnClick="lblEmail_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1330px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="pnl1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1310px" ID="grdPDPayData" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                    OnRowDataBound="grdPDPayData_RowDataBound" OnRowCommand="grdPDPayData_RowCommand">
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
                                                                <%--   <asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
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
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSaleDate" runat="server" Text='<%# Bind("SaleDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostedDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPDDate" runat="server" Text='<%# Bind("PDDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaymentDate" runat="server" Text='<%# Bind("PaymentDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAgentName" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"Agent_Name")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
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
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPackName" runat="server" Value='<%# Eval("Description")%>' />
                                                                <asp:HiddenField ID="hdnPackCost" runat="server" Value='<%# Eval("Price")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPhoneNum" runat="server" Value='<%# Eval("PhoneNum")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"email"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdPDPayData" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                            </div>
                            <div id="divRvs" runat="server" style="width: 100%">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="updtpnlRvheaders" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1310px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="60px" align="left">
                                                        <asp:LinkButton ID="lblRvID" runat="server" Text="RV ID &darr; &uarr;" OnClick="lblRvID_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="50px">
                                                        <asp:LinkButton ID="lblRvAdSt" runat="server" Text="Ad St &darr; &uarr;" OnClick="lblRvAdSt_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblRvSaleDt" runat="server" Text="Sale Dt &#8659" OnClick="lblRvSaleDt_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblRvpostedDt" runat="server" Text="Posted Dt &darr; &uarr;"
                                                            OnClick="lblRvpostedDt_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblRvPDPayDt" runat="server" Text="PD Pay Dt &darr; &uarr;" OnClick="lblRvPDPayDt_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lblRvPaymentDate" runat="server" Text="Payment Dt &darr; &uarr;"
                                                            OnClick="lblRvPaymentDt_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblRvAgent" runat="server" Text="Agent &darr; &uarr;" OnClick="lblRvAgent_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="50px">
                                                        <asp:LinkButton ID="lblRvYear" runat="server" Text="Year &darr; &uarr;" OnClick="lblRvYear_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="100px">
                                                        <asp:LinkButton ID="lblRvType" runat="server" Text="Type &darr; &uarr;" OnClick="lblRvType_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lblRvMake" runat="server" Text="Make &darr; &uarr;" OnClick="lblRvMake_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="150px">
                                                        <asp:LinkButton ID="lblRvPackage" runat="server" Text="Package &darr; &uarr;" OnClick="lblRvPackage_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="110px">
                                                        <asp:LinkButton ID="lblRvName" runat="server" Text="Name &darr; &uarr;" OnClick="lblRvName_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="90px">
                                                        <asp:LinkButton ID="lblRvPhone" runat="server" Text="Phone &darr; &uarr;" OnClick="lblRvPhone_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="130px">
                                                        <asp:LinkButton ID="lblRvEmail" runat="server" Text="Email &darr; &uarr;" OnClick="lblRvEmail_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1330px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="Panel1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="updtpnlRvGrid" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1310px" ID="grdRvPDPayData" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                    OnRowDataBound="grdRvPDPayData_RowDataBound" OnRowCommand="grdRvPDPayData_RowCommand">
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
                                                                <%--  <asp:Label ID="lblRVID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                                <asp:LinkButton ID="lnkRVID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCar"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="RvImgStatus" runat="server" />
                                                                <asp:HiddenField ID="RvhdnStatus" runat="server" Value='<%# Eval("Adstatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvSaleDate" runat="server" Text='<%# Bind("SaleDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPostedDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPDDate" runat="server" Text='<%# Bind("PDDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPaymentDt" runat="server" Text='<%# Bind("PaymentDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvAgentName" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"Agent_Name")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvType" runat="server" Text='<%# Eval("TypeName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPackage" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnRvPackName" runat="server" Value='<%# Eval("Description")%>' />
                                                                <asp:HiddenField ID="hdnRvPackCost" runat="server" Value='<%# Eval("Price")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPhoneNum" runat="server" Value='<%# Eval("PhoneNum")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvEmail" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"email"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdRvPDPayData" EventName="Sorting" />
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
    </form>
</body>
</html>
