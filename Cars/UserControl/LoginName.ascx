<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginName.ascx.cs" Inherits="UserControl_LoginName" %>
<table style="text-align: right; float: right; width: 100%;">
    <tr>
        <td id="ChangeLanguage" runat="server" style="width: 195px; text-align: left">
            <asp:Label ID="lblLang" runat="server" class="login" Style="background: none; padding-right: 5px;">Change language:</asp:Label>
            <asp:LinkButton ID="lnbtnLang" runat="server"  PostBackUrl="http://esp.UnitedCarExchange.com" Style="font-size: 11px;">SPANISH</asp:LinkButton>
        </td>
        <td style="text-align: right;" align="left">
            <label id="myaccDiv" runat="server" style="text-align: right; float: none;">
                <asp:LinkButton ID="lnkMyaccount" runat="server" Text="My Account" PostBackUrl="http://UnitedCarExchange.com/account.aspx"></asp:LinkButton>&nbsp;|&nbsp;
            </label>
            <label style="text-align: right; float: none">
                <asp:Label ID="lblWelcome" runat="server" Text="Welcome" Visible="false"></asp:Label>
                &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </label>
            <label style="text-align: right; float: none">
                <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" Visible="false"
                    OnClick="lnkBtnLogout_Click"></asp:LinkButton>
            </label>
            <label style="text-align: right; float: none">
                <asp:LinkButton ID="lnkLogin" runat="server" CssClass="login" Text="Login" PostBackUrl="http://UnitedCarExchange.com/Login.aspx"></asp:LinkButton>
            </label>
            <label style="padding: 2px 4px 0 6px; float: none;">
                <b>Toll-free: <span style="color: #ff6600"><a>888-786-8307</a></span> </b>
            </label>
        </td>
    </tr>
</table>
