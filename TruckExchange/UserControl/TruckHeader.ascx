<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TruckHeader.ascx.cs" Inherits="UserControl_TruckHeader" %>
<ul>
    <li><asp:LinkButton ID="lnkbtnHome" runat="server" Text="Home" 
            onclick="lnkbtnHome_Click1"></asp:LinkButton></li>
    <li>
        <asp:LinkButton ID="lnkbtnUsedTrucks" runat="server" Text="Used Trucks" PostBackUrl="~/UsedTrucks.aspx"></asp:LinkButton></li>
    <li>
        <asp:LinkButton ID="lnkbtnNewTrucks" runat="server" Text="New Trucks" PostBackUrl="~/NewTrucks.aspx"></asp:LinkButton></li>
    <li><a href="Packages.aspx">Sell a Truck</a></li>
    <li class="last">
        <asp:LinkButton ID="lnkbtnContactUS" runat="server" Text="Contact Us" PostBackUrl="~/ContactUs.aspx"></asp:LinkButton>
</ul>
