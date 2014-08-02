<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginName.ascx.cs" Inherits="UserControl_LoginName" %>
<table style="text-align: right; float: right;">
    <tr>
        <td style="text-align: right;" align="left">
            
                <label id="myaccDiv" runat="server" style="text-align:right; float:none; ">
                    <asp:LinkButton ID="lnkMyaccount" runat="server" Text="My Account" PostBackUrl="~/account.aspx"></asp:LinkButton>&nbsp;|&nbsp;
                </label>
           
            <label style="text-align:right; float:none">
                <asp:Label ID="lblWelcome" runat="server" Text="Welcome" Visible="false"></asp:Label>
                &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
            </label>
            <label style="text-align:right; float:none">
                <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" Visible="false"
                    OnClick="lnkBtnLogout_Click"></asp:LinkButton>
            </label>
            <label style="text-align:right; float:none">
                <asp:LinkButton ID="lnkLogin" runat="server" CssClass="login" Text="Login" PostBackUrl="~/Login.aspx"></asp:LinkButton>
            </label>
            <label style="padding: 2px 4px 0 6px; float:none; ">
                <b>
                    Customer Services: <span style="color: #ff6600"></span>
                </b>
            </label>
        </td>
    </tr>
</table>
