<%@ Page Language="C#" AutoEventWireup="true" CodeFile="offerRegister.aspx.cs" Inherits="offerRegister"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::United Car Exchange::..</title>
    <link href="Offercss/style.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>

    <script src="Static/JS/JCardNewOffer.js" type="text/javascript"></script>

    <script src="js/jquery.alphanumeric.pack.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function echeck(str) {
            var at = "@"
            var dot = "."
            var lat = str.indexOf(at)
            var lstr = str.length
            var ldot = str.indexOf(dot)
            if (str.indexOf(at) == -1) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(at, (lat + 1)) != -1) {
                alert("Enter valid email")
                return false
            }

            if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(dot, (lat + 2)) == -1) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(" ") != -1) {
                alert("Enter valid email")
                return false
            }

            return true
        }



        function ValidateRegisterData() {


            return valid;
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKeyWithDashForZip(evt) {


            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
        
        
    </script>

    <script type='text/javascript'>
        $(function() {

            $('.price').keyup(function() {
                this.value = this.value.replace(/[^0-9\.]/g, '');
            });
            $('.sample1').numeric();
            $('.noPaste').bind("cut copy paste", function(e) {
                e.preventDefault();
            });

        })
		
	
  
    	
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div class="main">
        <div class="hed">
            <div class="logo">
                <a href="http://UnitedCarExchange.com" target="_blank">
                    <img src="Offerimages/logo2.png" /></a></div>
            <div class="phoneNo">
                <b>Questions? Call us!</b><br />
                <strong>888-786-8307</strong><br />
                MON - FRI 9am - 5pm EST</div>
            <div class="agent">
                <img src="Offerimages/women.png" /></div>
            <div class="hedContent">
                <h4>
                    Sell your used car on UnitedCarExchange - Now Just For $9.99</h4>
                <h1>
                    Advertise to Reach
                    <br />
                    15 million plus online customers</h1>
                <ul>
                    <li>Ad runs for 60 Days</li>
                    <li>Unlimited Renewals</li>
                    <li>Upload up to 12 Photos</li>
                    <li>sell your Car at best price </li>
                </ul>
            </div>
        </div>
        <div class="box-holder">
            <div class="box-top">
                &nbsp;</div>
            <div class="box-mid">
                <div class="content">
                    <div class="contentLeft" style="width: 570px;">
                        <h1 style="padding-top: 0; margin-top: 0; color: #9C0; margin-bottom: 0px;">
                            Registration</h1>
                        <!-- Payment Form Start  -->
                        <div class="box4">
                            <div>
                                <h4 style="position: relative; margin-bottom: 5px;">
                                    Vehicle Information</h4>
                                <div style="height: 2px; width: 100%; overflow: hidden; margin: 5px 0 10px 0; border-bottom: 1px dotted #666">
                                    &nbsp;</div>
                                <table style="width: 300px;" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            Contact Name<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContactName" CssClass="noPaste" runat="server" MaxLength="25"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="40"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Confirm Email<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmEmail" runat="server" MaxLength="40"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Password<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" CssClass="noPaste" TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Confirm Password<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" CssClass="noPaste"
                                                TextMode="Password"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Phone<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Year<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlYear" runat="server">
                                                <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                <asp:ListItem Value="2013">2013</asp:ListItem>
                                                <asp:ListItem Value="2012">2012</asp:ListItem>
                                                <asp:ListItem Value="2011">2011</asp:ListItem>
                                                <asp:ListItem Value="2010">2010</asp:ListItem>
                                                <asp:ListItem Value="2009">2009</asp:ListItem>
                                                <asp:ListItem Value="2008">2008</asp:ListItem>
                                                <asp:ListItem Value="2007">2007</asp:ListItem>
                                                <asp:ListItem Value="2006">2006</asp:ListItem>
                                                <asp:ListItem Value="2005">2005</asp:ListItem>
                                                <asp:ListItem Value="2004">2004</asp:ListItem>
                                                <asp:ListItem Value="2003">2003</asp:ListItem>
                                                <asp:ListItem Value="2002">2002</asp:ListItem>
                                                <asp:ListItem Value="2001">2001</asp:ListItem>
                                                <asp:ListItem Value="2000">2000</asp:ListItem>
                                                <asp:ListItem Value="1999">1999</asp:ListItem>
                                                <asp:ListItem Value="1998">1998</asp:ListItem>
                                                <asp:ListItem Value="1997">1997</asp:ListItem>
                                                <asp:ListItem Value="1996">1996</asp:ListItem>
                                                <asp:ListItem Value="1995">1995</asp:ListItem>
                                                <asp:ListItem Value="1994">1994</asp:ListItem>
                                                <asp:ListItem Value="1993">1993</asp:ListItem>
                                                <asp:ListItem Value="1992">1992</asp:ListItem>
                                                <asp:ListItem Value="1991">1991</asp:ListItem>
                                                <asp:ListItem Value="1990">1990</asp:ListItem>
                                                <asp:ListItem Value="1989">1989</asp:ListItem>
                                                <asp:ListItem Value="1988">1988</asp:ListItem>
                                                <asp:ListItem Value="1987">1987</asp:ListItem>
                                                <asp:ListItem Value="1986">1986</asp:ListItem>
                                                <asp:ListItem Value="1985">1985</asp:ListItem>
                                                <asp:ListItem Value="1984">1984</asp:ListItem>
                                                <asp:ListItem Value="1983">1983</asp:ListItem>
                                                <asp:ListItem Value="1982">1982</asp:ListItem>
                                                <asp:ListItem Value="1981">1981</asp:ListItem>
                                                <asp:ListItem Value="1980">1980</asp:ListItem>
                                                <asp:ListItem Value="1979">1979</asp:ListItem>
                                                <asp:ListItem Value="1978">1978</asp:ListItem>
                                                <asp:ListItem Value="1977">1977</asp:ListItem>
                                                <asp:ListItem Value="1976">1976</asp:ListItem>
                                                <asp:ListItem Value="1975">1975</asp:ListItem>
                                                <asp:ListItem Value="1974">1974</asp:ListItem>
                                                <asp:ListItem Value="1973">1973</asp:ListItem>
                                                <asp:ListItem Value="1972">1972</asp:ListItem>
                                                <asp:ListItem Value="1971">1971</asp:ListItem>
                                                <asp:ListItem Value="1970">1970</asp:ListItem>
                                                <asp:ListItem Value="1969">1969</asp:ListItem>
                                                <asp:ListItem Value="1968">1968</asp:ListItem>
                                                <asp:ListItem Value="1967">1967</asp:ListItem>
                                                <asp:ListItem Value="1966">1966</asp:ListItem>
                                                <asp:ListItem Value="1965">1965</asp:ListItem>
                                                <asp:ListItem Value="1964">1964</asp:ListItem>
                                                <asp:ListItem Value="1963">1963</asp:ListItem>
                                                <asp:ListItem Value="1962">1962</asp:ListItem>
                                                <asp:ListItem Value="1961">1961</asp:ListItem>
                                                <asp:ListItem Value="1960">1960</asp:ListItem>
                                                <asp:ListItem Value="1959">1959</asp:ListItem>
                                                <asp:ListItem Value="1958">1958</asp:ListItem>
                                                <asp:ListItem Value="1957">1957</asp:ListItem>
                                                <asp:ListItem Value="1956">1956</asp:ListItem>
                                                <asp:ListItem Value="1955">1955</asp:ListItem>
                                                <asp:ListItem Value="1954">1954</asp:ListItem>
                                                <asp:ListItem Value="1953">1953</asp:ListItem>
                                                <asp:ListItem Value="1952">1952</asp:ListItem>
                                                <asp:ListItem Value="1951">1951</asp:ListItem>
                                                <asp:ListItem Value="1950">1950</asp:ListItem>
                                                <asp:ListItem Value="1949">1949</asp:ListItem>
                                                <asp:ListItem Value="1948">1948</asp:ListItem>
                                                <asp:ListItem Value="1947">1947</asp:ListItem>
                                                <asp:ListItem Value="1946">1946</asp:ListItem>
                                                <asp:ListItem Value="1945">1945</asp:ListItem>
                                                <asp:ListItem Value="1944">1944</asp:ListItem>
                                                <asp:ListItem Value="1943">1943</asp:ListItem>
                                                <asp:ListItem Value="1942">1942</asp:ListItem>
                                                <asp:ListItem Value="1941">1941</asp:ListItem>
                                                <asp:ListItem Value="1940">1940</asp:ListItem>
                                                <asp:ListItem Value="1939">1939</asp:ListItem>
                                                <asp:ListItem Value="1938">1938</asp:ListItem>
                                                <asp:ListItem Value="1937">1937</asp:ListItem>
                                                <asp:ListItem Value="1936">1936</asp:ListItem>
                                                <asp:ListItem Value="1935">1935</asp:ListItem>
                                                <asp:ListItem Value="1934">1934</asp:ListItem>
                                                <asp:ListItem Value="1933">1933</asp:ListItem>
                                                <asp:ListItem Value="1932">1932</asp:ListItem>
                                                <asp:ListItem Value="1931">1931</asp:ListItem>
                                                <asp:ListItem Value="1930">1930</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Make <span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="updtMake" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlMake" runat="server" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Model <span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlModel" runat="server">
                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Price<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPrice" runat="server" MaxLength="6" CssClass="price"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                            </div>
                            <div style="text-align: left;">
                                <h4 style="position: relative; margin-bottom: 5px;">
                                    Payment Information
                                    <div style="float: right; font-size: 10px; text-align: right; font-family: Arial, Helvetica, sans-serif;
                                        font-weight: normal; color: #666;">
                                        Your card details will be safe and secure and will not be shared with anyone.</div>
                                </h4>
                                <div style="height: 2px; width: 100%; overflow: hidden; margin: 5px 0 10px 0; border-bottom: 1px dotted #666">
                                    &nbsp;</div>
                                <table border="0" class="form1" cellpadding="5" cellspacing="0" width="500">
                                    <tr>
                                        <td colspan="4" style="position: relative">
                                            <table>
                                                <tr>
                                                    <td colspan="2">
                                                        <img src="images/V.gif" /><img src="images/MC.gif" /><img src="images/Amex.gif" /><img
                                                            src="images/Disc.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        Credit Card
                                                        <br />
                                                        <asp:DropDownList ID="CardType" runat="server" Style="width: 130px;">
                                                            <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                                            <asp:ListItem Value="VisaCard" Text="Visa"></asp:ListItem>
                                                            <asp:ListItem Value="AmExCard" Text="American Express"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        Credit Card Holder Name <i style="color: #999">(as it appears on card)</i><br />
                                                        <asp:TextBox ID="txtCardholderName" runat="server">
                                                        </asp:TextBox>
                                                        <span class="star">*</span>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        Credit Card Number<br />
                                                        <asp:TextBox ID="txtCardNumber" runat="server" CssClass="sample1 noPaste">
                                                        </asp:TextBox>
                                                        <span class="star">*</span>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1">
                                                        Expiration Month<br />
                                                        <asp:DropDownList ID="ExpMon" Style="width: 100px;" runat="server">
                                                            <asp:ListItem Value="0" Text="Select Month"></asp:ListItem>
                                                            <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                            <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                            <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                            <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="1">
                                                        Year<br />
                                                        <asp:DropDownList ID="CCExpiresYear" runat="server" Style="width: 100px;">
                                                            <asp:ListItem Value="08">2008</asp:ListItem>
                                                            <asp:ListItem Value="09">2009</asp:ListItem>
                                                            <asp:ListItem Value="10">2010</asp:ListItem>
                                                            <asp:ListItem Value="11">2011</asp:ListItem>
                                                            <asp:ListItem Value="12">2012</asp:ListItem>
                                                            <asp:ListItem Value="13">2013</asp:ListItem>
                                                            <asp:ListItem Value="14">2014</asp:ListItem>
                                                            <asp:ListItem Value="15">2015</asp:ListItem>
                                                            <asp:ListItem Value="16">2016</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="1">
                                                        CVV <i style="color: #999">(3-digit card verification number)</i><br />
                                                        <asp:TextBox ID="cvv" runat="server" Width="30" MaxLength="4">
                                                        </asp:TextBox>
                                                        <span class="star">*</span><img src="images/icon_card_back.gif" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <div class="clear">
                                    &nbsp;</div>
                                <br />
                                <h4>
                                    Billing Information</h4>
                                <div style="height: 2px; width: 100%; overflow: hidden; margin: 5px 0 10px 0; border-bottom: 1px solid #666">
                                    &nbsp;</div>
                                <table border="0" class="form1" cellpadding="5" cellspacing="0" width="500">
                                    <tr>
                                        <td>
                                            First Name<br />
                                            <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 20px;">
                                            Last Name<br />
                                            <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                        <td colspan="2" rowspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            Address<br />
                                            <asp:TextBox ID="AddressTextBox" runat="server" Width="94%"></asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            City<br />
                                            <asp:TextBox ID="CityTextBox" runat="server"></asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                        <td style="padding-left: 20px;">
                                            State<br />
                                            <asp:DropDownList ID="ddlBillState" runat="server" CssClass="input1" Style="width: 90%;">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Postal Code<br />
                                            <asp:TextBox ID="txtBillZip" runat="server" CssClass="mediumTextBox"></asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                        <td style="padding-left: 20px;">
                                            Country<br />
                                            <asp:TextBox ID="CountryTextBox" runat="server" CssClass="mediumTextBox" Text="USA"></asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Phone<br />
                                            <asp:TextBox ID="txtBillPhone" runat="server"></asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                        <td style="padding-left: 20px;">
                                            Email<br />
                                            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="xx-largeTextBox">
                                            </asp:TextBox>
                                            <span class="star">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <br />
                                            <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" OnClick="SubmitButton_Click"
                                                CssClass="button1" OnClientClick="return CheckCardNumber(this.form)" />
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                                <br />
                                <br />
                            </div>
                            <div class="clear">
                                &nbsp;</div>
                        </div>
                        <!-- Payment Form End -->
                        <div class="clear">
                        </div>
                    </div>
                    <div class="contentRight">
                        <div class="testi">
                            I received the car yesterday. The people at the bond wanted me to sell it off to
                            them. You chose a very nice car for my wife. I really want to thank the sales guy
                            at United Car Exchange.
                        </div>
                        <h4>
                            Thomas Garcia</h4>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
            </div>
            <div class="box-bot">
                <span style="font-size: 12px; margin-left: 60px"><a href="http://www.UnitedCarExchange.com"
                    target="_blank">www.UnitedCarExchange.com</a></span></div>
        </div>
        <div class="footer">
            United Car Exchange © 2012 &nbsp; | &nbsp; <a href="http://UnitedCarExchange.com/PrivacyPolicy.aspx"
                target="_blank">Privacy Policy</a>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpeAlert" runat="server" PopupControlID="divExists" BackgroundCssClass="ModalPopupBG"
        TargetControlID="hdnExists" OkControlID="btnExustCls" CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    </form>
</body>
</html>
