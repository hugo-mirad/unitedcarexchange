<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pay.aspx.cs" Inherits="NewTrucks" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title1" runat="server"></title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
        
    <link href="css/page1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="Static/JS/JSCardValidation1.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">


        function pageLoad() {

            GetRecentListings();


        }

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



        function Validate() {
            var valid = true;
            if ($('#txtContactName').val().trim().length < 1) {
                $('#txtContactName').focus();
                alert("Enter name");
                $('#txtContactName').val('');
                $('#txtContactName').focus()

                valid = false;
            }
            else if ($('#txtphone').val().trim().length < 1) {
                $('#txtphone').focus();
                alert("Enter phone #");
                $('#txtphone').val('');
                $('#txtphone').focus()
                valid = false;

            }
            else if (($('#txtphone').val().trim().length > 0) && ($('#txtphone').val().trim().length < 10)) {
                $('#txtphone').focus();
                $('#txtphone').val(''); ;
                alert("Enter valid phone #");
                valid = false;

            }
            else if ($('#txtemail').val().trim().length < 1) {
                $('#txtemail').focus();
                alert("Enter email");
                $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;

            }

            else if (($('#txtemail').val().trim().length > 0) && (echeck($('#txtemail').val()) == false)) {
                $('#txtemail').val('');
                $('#txtemail').focus();
                valid = false;

            }

            return valid;
        }


        function isNumberKey(evt) {
            debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function isNumberKeyWithDashForZip(evt) {
            debugger

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
    </script>
 <script type='text/javascript'>
     $(function() {
     $('.sample4').numeric();
         $('.price').formatCurrency();
         $('.mileage').formatCurrency({ symbol: ' ' });

     });
	
	
   
	    
    

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <!-- Main Start  -->
    <div class="main">
        <!-- head1 start  -->
        <div class="hed1">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle">
                        <a href="http://UnitedTruckExchange.com/">
                            <img src="images/logo.png" class="logo" /></a>
                    </td>
                    <td valign="top">
                        <uc1:TruckLogin ID="TruckLogin1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- head1 End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- Menu Start  -->
        <div class="menu">
            <uc2:TruckHeader ID="TruckHeader1" runat="server" />
        </div>
        <!-- Menu End  -->
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px; background:#fff"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="info-box" style="background: #fff;">
                        <div class="wrapper">
                            <!-- Box2 Div Start  -->
                            <div class="box3">
                                <div class="wrapper">
                                      <table style="width: 100%;">
                                    <tr>
                                        <td style="padding-right: 20px; padding-top: 10px;">
                                            <h2>
                                                Payment
                                            </h2>
                                        </td>
                                    </tr>
                                </table>
                                <table class="errHolder" style="width: 99%; border: #ff3300 1px solid; display: none;
                                    padding-bottom: 18px;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 10px; background: #ff3300; color: #fff; font-weight: bold; font-size: 20px;
                                            padding: 6px;">
                                            !
                                        </td>
                                        <td style="padding: 10px;">
                                            <span class="star" style="color: #333;">The following must be corrected before continuing:</span>
                                            <ul class="error" style="margin-left: 30px; list-style: disc">
                                            </ul>
                                        </td>
                                    </tr>
                                </table>
                                <!-- Package Info Start -->
                                <div class="searchResultsBox" style="border: none; background: #fff">
                                    <h4>
                                        Package Details</h4>
                                    <div style="height: 2px; width: 100%; overflow: hidden; margin: 5px 0 10px 0; border-bottom: 1px solid #666">
                                        &nbsp;</div>
                                    <table class="VisitsTable" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th scope="col">
                                                Package
                                            </th>
                                            <th scope="col">
                                                Price
                                            </th>
                                            <th scope="col">
                                                Photos Uploaded
                                            </th>
                                            <th scope="col">
                                                Max Photos
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPackDescrip" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdPrice2" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPhotoUploaded" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMaxPhotos" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div style="display: none">
                                        <h4>
                                            Ad Preview</h4>
                                        <div style="height: 2px; width: 100%; overflow: hidden; margin: 5px 0 10px 0; border-bottom: 1px solid #666">
                                            &nbsp;</div>
                                        <table style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 130px; vertical-align: top; position: relative; z-index: 10;" class="searchCarThumbHolder">
                                                        <asp:Image ID="ImageName" runat="server" CssClass="thumb imgThumb" Width="120" Height="73" />
                                                        <div class="stock3" id="divAdStock" runat="server">
                                                            Stock Photo</div>
                                                    </td>
                                                    <td class="searchcarDetails" style="vertical-align: top; font-weight: normal">
                                                        <h4>
                                                            <a href="javascript:void(0);">
                                                                <asp:Label ID="lblCarName" runat="server" CssClass="carName"></asp:Label></a>
                                                        </h4>
                                                        <p style="font-weight: normal">
                                                            <strong>Description: </strong>
                                                            <asp:Label ID="lblDescrip" runat="server"></asp:Label></p>
                                                    </td>
                                                    <td class="SearchResultsArrayBox3" style="vertical-align: top; width: 170px;">
                                                        <table style="width: 100%; background: #eee;" cellspacing="6" cellpadding="3">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <strong>Mileage</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbladmilleage" CssClass="mileage" runat="server"></asp:Label>
                                                                        <asp:Label ID="lblMi" Text="mi" runat="server" Visible="false"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <strong>Price</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lbladPrice" CssClass="price" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <strong>Body</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAdBody" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <strong>Fuel</strong>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAdFuel" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <!-- Package Info End -->
                                <!-- Payment Form Start  -->
                                <div class="box4">
                                    <div style="text-align: left;">
                                        <br />
                                        <h4 style="position: relative">
                                            Payment Information
                                            <div style="float: right; font-size: 12px; font-weight: normal; color: #666;">
                                                Your card details will be safe and secure and will not be shared with anyone.</div>
                                            <div style="width: 90px; height: 90px; position: absolute; right: 20px; top: 40px">
                                                <!-- (c) 2006. Authorize.Net is a registered trademark of Lightbridge, Inc. -->

                                                <script type="text/javascript" language="javascript">
                                                    var ANS_customer_id = "1ae28d18-9cbf-488c-a5a3-3fdce9333f50";</script>

                                              <%--  <script type="text/javascript" language="javascript" src="//VERIFY.AUTHORIZE.NET/anetseal/seal.js"></script>--%>

                                                <!--   End Seal  -->
                                            </div>
                                        </h4>
                                        <div style="height: 2px; width: 100%; overflow: hidden; margin: 5px 0 10px 0; border-bottom: 1px solid #666">
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
                                                                <asp:TextBox ID="txtCardNumber" runat="server" CssClass="sample4" >
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
                                                                CCV <i style="color: #999">(3-digit card verification number)</i><br />
                                                                <asp:TextBox ID="cvv" runat="server" Width="30">
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
                                                    <asp:TextBox ID="FirstNameTextBox" runat="server" Width="104px"></asp:TextBox>
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
                                                    <asp:DropDownList ID="ddlBillState" runat="server" CssClass="input1" Width="110px">
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
                                                    <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CausesValidation="true"
                                                        ValidationGroup="Authorize" OnClick="SubmitButton_Click" CssClass="button1" OnClientClick="return CheckCardNumber(this.form)" />
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
                            </div>
                            <!-- Box2 Div End  -->
                            <div class="clear">
                            </div>
                            <!-- Ads Section Start  -->
                            <div class="ads1">
                            </div>
                            <!-- Ads Section Endt  -->
                        </div>
                    </div>
                    <!-- Login Page End  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="clear">
                        &nbsp;</div>
                    <!-- Bottom Ads Start -->
                    <div class="bottomAdd " id="add730" style="width: 730px; margin: 10px 0; font-size: 11px;">
                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57 -->
                        <!-- End: adBrite -->
                    </div>
                    <!-- Bottom Ads End  -->
                    <!-- Right Content End  -->
                </td>
            </tr>
        </table>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        <uc3:TruckFooter ID="TruckFooter1" runat="server" />
    </div>
    <!-- Footer End  -->
    
     <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls"> </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnNo" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists" OkControlID="btnExustCls"
        CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls"> </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Processing
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script type="text/javascript">


        $(function() {

            $('a').each(function() {
                if ($(this).attr('href') == '#') {
                    $(this).attr('href', 'javascript:void(0)')
                }
            });

        });	
    
    
   
    </script>

</body>
</html>
