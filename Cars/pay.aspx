<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pay.aspx.cs" Inherits="pay"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="#">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/chosen/chosen.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="Static/JS/JSCardValidation1.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="content">
        <div id="progress" class="section">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step done" href="javascript:void(0);">
                            <div class="circle">
                                <i class="icon icon-normal-mark-tick"></i>
                            </div>
                            <div class="title">
                                Seller Information</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step done" href="javascript:void(0);">
                            <div class="circle">
                                <i class="icon icon-normal-mark-tick"></i>
                            </div>
                            <div class="title">
                                Vehicle Information</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step done" href="javascript:void(0);">
                            <div class="active circle">
                                <i class="icon icon-normal-mark-tick"></i>
                            </div>
                            <div class="title">
                                Vehicle Photos</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step active" href="javascript:void(0);">
                            <div class="circle active">
                                4</div>
                            <div class="title">
                                Payment Information</div>
                        </a>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-9">
                        <div id="main">
                            <div class="block checkout">
                                <div class="page-header" style="margin-bottom: 0">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Payment</h2>
                                        </div>
                                        <!-- /.heading -->
                                        <div class="line">
                                            <hr />
                                        </div>
                                        <!-- /.line -->
                                    </div>
                                    <!-- /.page-header-inner -->
                                </div>
                                <!-- /.page-header -->
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="block-inner white block-shadow">
                                            <div class="form-section">
                                                <div class="row">
                                                    <div class="col-sm-11 col-md-10">
                                                        <div class="form-group">
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
                                                        </div>
                                                        <div class=" form-section  ">
                                                            <div class=" row  ">
                                                                <div class="col-sm-11 col-md-10">
                                                                    <div class="form-group" style="display: none;">
                                                                        <!-- Package Info Start -->
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
                                                                        <!-- Package Info End -->
                                                                        <!-- Ad Preview Start  -->
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
                                                                        <!-- Ad Preview End  -->
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-section">
                                                            <div class="block-title">
                                                                <h2>
                                                                    Payment Information</h2>
                                                            </div>
                                                            <div class="form-group">
                                                                <ul class="credit-cards">
                                                                    <li>
                                                                        <img alt="#" src="assets/img/icon-mastercard.png">
                                                                    </li>
                                                                    <li>
                                                                        <img alt="#" src="assets/img/icon-discover.png">
                                                                    </li>
                                                                    <li>
                                                                        <img alt="#" src="assets/img/icon-visa.png">
                                                                    </li>
                                                                    <li>
                                                                        <img alt="#" src="assets/img/icon-amex.png">
                                                                    </li>
                                                                </ul>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-md-5">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            Credit Card <span class="star">*</span></label>
                                                                        <asp:DropDownList ID="CardType" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                                                            <asp:ListItem Value="VisaCard" Text="Visa"></asp:ListItem>
                                                                            <asp:ListItem Value="AmExCard" Text="American Express"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-md-5">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            Card Number <span class="star">*</span></label>
                                                                        <asp:TextBox ID="txtCardNumber" runat="server" CssClass="number form-control" placeholder="XXXX-XXXX-XXXX-XXXX"
                                                                            MaxLength="25">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-md-5">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            Name on card <span class="star">*</span></label>
                                                                        <asp:TextBox ID="txtCardholderName" runat="server" class="form-control">
                                                                        </asp:TextBox>
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-3 col-md-3">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            Expiration Month <span class="star">*</span></label>
                                                                        <asp:DropDownList ID="ExpMon" class="form-control" runat="server">
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
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-3 col-md-3">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            Year <span class="star">*</span></label>
                                                                        <asp:DropDownList ID="CCExpiresYear" runat="server" class="form-control">
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
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6 col-md-5">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            CCV <i style="color: #999">(3-digit card verification number)</i> <span class="star">
                                                                                *</span></label>
                                                                        <table>
                                                                            <tr>
                                                                                <td style="width: 60px">
                                                                                    <asp:TextBox ID="cvv" runat="server" MaxLength="3" class="form-control">
                                                                        </asp:TextBox>
                                                                                </td>
                                                                                <td>
                                                                                    <img src="imagesOld/icon_card_back.gif" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-section">
                                                    <div class="block-title">
                                                        <h2>
                                                            Billing address</h2>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    First Name <span class="star">*</span></label>
                                                                <asp:TextBox ID="FirstNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    Last Name <span class="star">*</span></label>
                                                                <asp:TextBox ID="LastNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    Address <span class="star">*</span></label>
                                                                <asp:TextBox ID="AddressTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    City <span class="star">*</span></label>
                                                                <asp:TextBox ID="CityTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-3">
                                                            <div class="form-group">
                                                                <label>
                                                                    State <span class="star">*</span></label>
                                                                <asp:DropDownList ID="ddlBillState" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-2">
                                                            <div class="form-group">
                                                                <label>
                                                                    Postal Code <span class="star">*</span></label>
                                                                <asp:TextBox ID="txtBillZip" runat="server" CssClass="mediumTextBox form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    Country <span class="star">*</span></label>
                                                                <asp:TextBox ID="CountryTextBox" runat="server" CssClass="mediumTextBox form-control"
                                                                    Text="USA"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    Phone <span class="star">*</span></label>
                                                                <asp:TextBox ID="txtBillPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-5">
                                                            <div class="form-group">
                                                                <label>
                                                                    Email <span class="star">*</span></label>
                                                                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="xx-largeTextBox form-control">
                                                        </asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.content -->
                            </div>
                            <!-- /.col-md-12 -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <div class="col-md-3 sidebar">
                        <div class="block block-shadow extras white">
                            <div class="block-inner">
                                <div class="block-title">
                                    <h3>
                                        Summary </asp:Label></h3>
                                </div>
                                <!-- /.block-title -->
                                <table class=" summary2  ">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Package</h4>
                                                <asp:Label ID="lblpackagename2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Seller Name</h4>
                                                <asp:Label ID="lblSname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Email</h4>
                                                <asp:Label ID="lblSmail" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Phone</h4>
                                                <asp:Label ID="lblSphone" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="devider2">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Year</h4>
                                                <asp:Label ID="lblSyear" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Make</h4>
                                                <asp:Label ID="lblSmake" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Model</h4>
                                                <asp:Label ID="lblSmodel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Asking Price</h4>
                                                <asp:Label ID="lblSprice" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Uploaded Photos</h4>
                                                <asp:Label ID="lblSphotos" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.block-inner -->
                            <div class="total">
                                <div class="title">
                                    Total</div>
                                <div class="value">
                                    <asp:Label ID="lblpckgprice" runat="server"></asp:Label></div>
                            </div>
                        </div>
                        <!-- /.block -->
                    </div>
                    <!-- /.sidebar -->
                    <!-- /.block -->
                </div>
                <div class="row">
                    <div class="col-sm-12 col-md-9">
                        <div class="row">
                            <div class="checkout-actions">
                                <div class="col-sm-4 col-md-3">
                                </div>
                                <div class="col-sm-4 col-md-3">
                                </div>
                                <div class="col-sm-4 col-md-3">
                                </div>
                                <div class="col-sm-4 col-md-3">
                                    <div class="next">
                                        <%--OnClick="SubmitButton_Click"--%>
                                      <%--  <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CausesValidation="true"
                                            ValidationGroup="Authorize" CssClass="btn btn-primary" OnClientClick="return CheckCardNumber(this.form)" />--%>
                                            
                                            <asp:Button ID="SubmitButton" runat="server" Text="Submit Payment" CausesValidation="true"
                                            ValidationGroup="Authorize" CssClass="btn btn-primary" OnClick="SubmitButton_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- /#main -->
            </div>
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container -->
    </div>
    <!-- /.section -->
    </div>
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    <!-- Alerts Start  -->
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
    <!-- Alerts End  -->

    <script src="libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="libraries/star-rating/jquery.rating.js"></script>

    <script src="libraries/colorbox/jquery.colorbox-min.js"></script>

    <script src="js/jslider/jquery.slider.min.js"></script>

    <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

    <script src="http://maps.googleapis.com/maps/api/js?sensor=true&amp;v=3.13"></script>

    <script src="assets/js/carat.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type='text/javascript'>
        var LoadingPage = 10;
        $(function() {
            $('.number').numeric();
            $('.price').formatCurrency();
            $('.mileage').formatCurrency({ symbol: ' ' });

        });    

    </script>

    </form>
</body>
</html>
