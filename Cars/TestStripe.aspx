<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestStripe.aspx.cs" Inherits="TestStripe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%">
            <tr>
                <td style="width: 10%">
                    Amount:
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    Currency:
                </td>
                <td>
                    <asp:TextBox ID="txtcurrency" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardAddressCity:
                </td>
                <td>
                    <asp:TextBox ID="txtCardAddressCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardAddressCountry:
                </td>
                <td>
                    <asp:TextBox ID="txtCardAddressCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardAddressLine1:
                </td>
                <td>
                    <asp:TextBox ID="txtCardAddressLine1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardAddressLine2:
                </td>
                <td>
                    <asp:TextBox ID="txtCardAddressLine2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardAddressState:
                </td>
                <td>
                    <asp:TextBox ID="txtCardAddressState" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardAddressZip:
                </td>
                <td>
                    <asp:TextBox ID="txtCardAddressZip" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardCvc:
                </td>
                <td>
                    <asp:TextBox ID="txtCardCvc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardExpirationMonth:
                </td>
                <td>
                    <asp:TextBox ID="txtCardExpirationMonth" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardExpirationYear:
                </td>
                <td>
                    <asp:TextBox ID="txtCardExpirationYear" runat="server"></asp:TextBox>
                </td>
            </tr>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardName
                </td>
                <td>
                    <asp:TextBox ID="txtCardName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                    CardNumber
                </td>
                <td>
                    <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 10%">
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <br />
        error:<asp:Label ID="lblerror" runat="server"></asp:Label>
        id:
        <asp:Label ID="idm" runat="server"></asp:Label><br />
        invoice number
        <asp:Label ID="invoicenumber" runat="server"></asp:Label><br />
        Failure number
        <asp:Label ID="lblfailuremessge" runat="server"></asp:Label><br />
    </div>
    </form>
</body>
</html>
