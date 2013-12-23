<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginName.ascx.cs" Inherits="UserControl_LoginName" %>
<table style="width: 100%">
    <td style="width: 250px">
        <a href="index.aspx">
            <img src="images/logo2.png" /></a>
    </td>
    <td>
        <h1 class="h11">
            Smartz Customer Service System</h1>
    </td>
    <td style="width: 250px">
        <div class="loginStat">
            Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            <br />
            <a href="index.aspx" class="home">Home</a>&nbsp; |&nbsp; <a href="SearchNew.aspx">Search</a>&nbsp;
            | &nbsp;<asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false"
                OnClick="lnkBtnLogout_Click"></asp:LinkButton></div>
    </td>
</table>
<%--<table style="text-align: right; float: right;">
    <tr>
        <td style="text-align: right;" align="left">
            <label id="myaccDiv" runat="server" style="text-align: right; float: none;">
                <asp:LinkButton ID="lnkMyaccount" runat="server" Text="My Account" PostBackUrl="~/account.aspx"></asp:LinkButton>&nbsp;|&nbsp;
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
                <asp:LinkButton ID="lnkLogin" runat="server" CssClass="login" Text="Login" PostBackUrl="~/Login.aspx"></asp:LinkButton>
            </label>
            <label style="padding: 2px 4px 0 6px; float: none;">
                <b>Toll-free: <span style="color: #ff6600"><a href="ContactUs.aspx">888-786-8307</a></span>
                </b>
            </label>
        </td>
    </tr>
</table>--%>
