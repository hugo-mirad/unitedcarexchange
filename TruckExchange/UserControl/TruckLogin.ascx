<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TruckLogin.ascx.cs" Inherits="UserControl_RVLogin" %>
<div class="social">
    <div class="rt-block">
        <div class="smile" style="text-align: left">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <h3>
                            Customer Services: <span>
                                <b style="color:#121212;">888-786-8307</b>
                                
                                <asp:LinkButton ID="lbtn" runat="server" Text="888-786-8307"  style="display:none" ></asp:LinkButton>
                                </span>
                        </h3>
                        <table style="width: 100%;" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right">
                                    <label id="myaccDiv" runat="server" style="text-align: right; float: none;">
                                        <asp:LinkButton ID="lnkMyaccount" CssClass="myAccount" runat="server" Text="My Account"
                                            PostBackUrl="~/account.aspx"></asp:LinkButton>
                                        &nbsp;|&nbsp;
                                    </label>
                                    <label style="text-align: right; float: none">
                                        <asp:Label ID="lblWelcome" runat="server" Text="Welcome" Visible="false"></asp:Label>
                                        &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                                        &nbsp;
                                    </label>
                                </td>
                                <td width="44" align="right">
                                    <label style="text-align: right; float: none">
                                        <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" Visible="false"
                                            OnClick="lnkBtnLogout_Click"></asp:LinkButton>
                                    </label>
                                    <label style="text-align: right; float: none">
                                        <asp:LinkButton ID="lnkLogin" runat="server" CssClass="login" Text="Login" PostBackUrl="~/Login.aspx"></asp:LinkButton>
                                    </label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clr">
        </div>
    </div>
</div>
