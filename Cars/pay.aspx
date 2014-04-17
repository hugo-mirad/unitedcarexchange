<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay.aspx.cs" Inherits="pay" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/RegPageUser.ascx" TagName="RegPageUser" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>


    <script src="Static/JS/JSCardValidation1.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>
    

    <style>
        .usual ul li.tab1 a
        {
            display: block;
            padding: 5px 8px;
            text-decoration: none !important;
            margin: 0 2px 0 0;
            margin-left: 0;
            color: #444;
            font-weight: bold;
            background: url(images/AccordionTab0.gif) repeat-x;
        }
    </style>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
		$('.price').formatCurrency();
        $('.mileage').formatCurrency({symbol: ' '});  
        
   });
	
	
   
	    
    

    </script>

</head>
<body id="page1" style="background: #eee;">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg" style="width: 980px; margin: 0 auto; overflow: hidden; background: #eee;">
            <div id="main" style="width: 980px; margin: 0 auto; overflow: hidden;">
                <!-- header -->
                <div id="header" style="height: 77px; top: 0px; left: 18px;">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" alt="" name="logo" id="logo" /></a>
                    <div class="loginStat">
                        <%-- <a href="login.aspx" class="login">Login</a>--%>
                        <uc3:RegPageUser ID="RegPageUser1" runat="server" />
                    </div>
                </div>
                <!-- content -->
                <div id="content" style="background: #fff;">
                    <div class="wrapper-1">
                        <div id="column-right" class="column-indent" style="width: 100%;">
                            <div class="indent">
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
                                                                            <%--<label class="mileage">
                                                                                                22,301</label>--%>
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

                                                    <script type="text/javascript" language="javascript" src="//VERIFY.AUTHORIZE.NET/anetseal/seal.js"></script>

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
                                                                    
                                                                    <asp:TextBox ID="txtCardNumber" runat="server" CssClass="number" >
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
                        </div>
                        <div class="clear">
                            &nbsp;</div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer" style="width: 730px; margin: 0 auto">
                    <p style="padding-top: 10px; font-size: 11px">
                        United Car Exchange &copy; 2012
                    </p>
                </div>
            </div>
        </div>
    </div>
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
                        <asp:Label ID="lblErr" runat="server" ></asp:Label>
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
                Applying your filter
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script type="text/javascript">
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-28766349-1']);
  _gaq.push(['_trackPageview']);
  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
    </script>

</body>
</html>
