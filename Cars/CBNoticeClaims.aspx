<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CBNoticeClaims.aspx.cs" Inherits="CBNoticeClaims" %>

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
        <div style="width: 1130px;" id="divresults" runat="server">
            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblRes" Font-Size="12px" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                    <div style="width: 100%;" id="div1" runat="server">
                        <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                            <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                padding-top: 2px; width: 1110px; background: #fff;">
                                <tr class="tbHed">
                                    <td width="50px;">
                                    </td>
                                    <td width="70px">
                                        <asp:LinkButton ID="lnkNoticeID" runat="server" Text="Notice ID &darr; &uarr;" OnClick="lnkNoticeID_Click"></asp:LinkButton>
                                        <%-- Date--%>
                                    </td>
                                    <td width="90px">
                                        <asp:LinkButton ID="lnkNoticeDateSort" runat="server" Text="Notice Dt &#8657" OnClick="lnkNoticeDateSort_Click"></asp:LinkButton>
                                    </td>
                                    <td width="120px">
                                        <asp:LinkButton ID="lnkNoticeType" runat="server" Text="Type &darr; &uarr;" OnClick="lnkNoticeType_Click"></asp:LinkButton>
                                    </td>
                                    <td width="110px">
                                        <asp:LinkButton ID="lnkbtnCustName" runat="server" Text="Cust Name &darr; &uarr;"
                                            OnClick="lnkbtnCustName_Click"></asp:LinkButton>
                                    </td>
                                    <td width="90px">
                                        <asp:LinkButton ID="lnkbtnCaseNum" runat="server" Text="Case # &darr; &uarr;" OnClick="lnkbtnCaseNum_Click"></asp:LinkButton>
                                    </td>
                                    <td width="60px">
                                        <asp:LinkButton ID="lnkAmount" runat="server" Text="$ &darr; &uarr;" OnClick="lnkAmount_Click"></asp:LinkButton>
                                        <%-- Date--%>
                                    </td>
                                    <td width="90px">
                                        <asp:LinkButton ID="lnkbtnreplyDt" runat="server" Text="Reply By Dt &darr; &uarr;"
                                            OnClick="lnkbtnreplyDt_Click"></asp:LinkButton>
                                    </td>
                                    <td width="90px">
                                        <asp:LinkButton ID="lnkbtnReplySentDt" runat="server" Text="Sent Dt &darr; &uarr;"
                                            OnClick="lnkbtnReplySentDt_Click"></asp:LinkButton>
                                    </td>
                                    <td width="90px">
                                        <asp:LinkButton ID="lnkbtnStatus" runat="server" Text="Status &darr; &uarr;" OnClick="lnkbtnStatus_Click"></asp:LinkButton>
                                    </td>
                                    <td>
                                        <%--<asp:LinkButton ID="lnkCBNotes" runat="server" Text="Notes &darr; &uarr;"></asp:LinkButton>--%>
                                        Notes
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                            border: #ccc 1px solid; height: 180px">
                            <asp:Panel ID="pnl1" Width="100%" runat="server">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                        <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                        <asp:GridView Width="1110px" ID="GrdClaims" runat="server" CellSpacing="0" CellPadding="0"
                                            CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                            OnRowCommand="GrdClaims_RowCommand">
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
                                                        <%-- <asp:Label ID="lblNoticeID" runat="server" Text='<%# Eval("NoticeID")%>'></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkbtnProcess" runat="server" Text="Process" CommandArgument='<%# Eval("NoticeID")%>'
                                                            CommandName="ViewProcess"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%-- <asp:Label ID="lblNoticeID" runat="server" Text='<%# Eval("NoticeID")%>'></asp:Label>--%>
                                                        <asp:LinkButton ID="lnkbtnNoticeID" runat="server" Text='<%# Eval("NoticeID")%>'
                                                            CommandArgument='<%# Eval("NoticeID")%>' CommandName="ViewNotice"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNoticeDate" runat="server" Text='<%# Bind("NoticeDate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNoticeType" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"NoticeTypeName"),18)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),16)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCaseNumber" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CaseNumber"),12)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("DisputeAmount", "{0:C}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReplyDate" runat="server" Text='<%# Bind("ReplyByDt", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblReplySentDate" runat="server" Text='<%# Bind("ReplySentDt", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"NoticeStatusName"),12)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblNotes" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Notes"),35)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GrdClaims" EventName="Sorting" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                        <div class="clear" style="height: 12px;">
                            &nbsp;</div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    </form>
</body>
</html>
