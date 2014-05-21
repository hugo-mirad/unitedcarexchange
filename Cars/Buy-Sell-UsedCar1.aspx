<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Buy-Sell-UsedCar1.aspx.cs"
    Inherits="SearchCarDetails" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<!doctype html>
<html xml:lang="en" lang="en">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="../favicon.ico" type="image/x-icon">
    <link rel="icon" href="../favicon.ico" type="image/x-icon">
    <link rel="stylesheet" type="text/css" href="../assets/css/bootstrap.min.css" media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="../libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="../libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="../js/jslider/jquery.slider.min.css"
        media="screen, projection" />
    <link href="../js/jslider/jquery.slider.min.css" rel="stylesheet" type="text/css"
        media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="../assets/css/carat.css" media="screen, projection" />
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">

    <script src="../assets/js/jquery.js"></script>

    <script src="../assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="../assets/js/jquery.ui.js"></script>

    <script src="../assets/js/bootstrap.js"></script>

    <script src="../assets/js/cycle.js"></script>

    <!-- Magnific Popup core CSS file -->
    <link href="../libraries/magicPopup/magnific-popup.css" rel="stylesheet" type="text/css" />
    <!-- Magnific Popup core JS file -->

    <script src="../libraries/magicPopup/jquery.magnific-popup.js" type="text/javascript"></script>

    <script src="../assets/js/jquery.cookie.js" type="text/javascript"></script>

    <%-- <script>
        $(function() {
            $('#spinner').show();
        })
    </script>
    --%>
</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server" ScriptMode="Release">
    </cc1:ToolkitScriptManager>
    <asp:Label ID="HdnSubScribeValue" CssClass="HdnSubScribeValue" runat="server" Style="display: none"></asp:Label>
    <header id="header">
	<div class="header-inner">
		<div class="container" >
			<div class="row">
				<div class="col-md-12 clearfix">
					<div class="brand">
						<div class="logo">
							<a href="../default.aspx">
								<img src="../assets/img/logo.png" alt="Carat HTML Template">
							</a>
						</div><!-- /.logo -->

						<div class="slogan">The best way to sell/buy a car in your local area and<br />
across the country using web, mobile & social media
</div><!-- /.slogan -->
					</div><!-- /.brand -->
					
					<button class="navbar-toggle" type="button" data-toggle="collapse" data-target=".navbar-collapse">
					    <span class="sr-only">Toggle navigation</span>
					    <span class="icon-bar"></span>
					    <span class="icon-bar"></span>
					    <span class="icon-bar"></span>
					</button>

					<nav class="collapse navbar-collapse navbar-collapse" role="navigation">
						<ul class="navigation">
						<li><a href="http://www.mobicarz.com/default.aspx">Home</a></li>				
						
					<li runat="server" id="usedCarsLi"><a href="javascript:void(0);">Buy A Car</a></li>
                        <li runat="server" id="newCarsLi"><a href="http://www.mobicarz.com/SellRegi.aspx">Sell A Car</a></li>
                         <li runat="server" id="Finaqnce"><a href="http://www.mobicarz.com/Finance.aspx">Finance</a></li>
                         
						<li class="menuparent has-regularmenu" runat="server" visible="false" id="sellLi" style="display:none;"> 
						    <a href="#">Sell A Car</a>
						    <div class="regularmenu">
								<ul class="regularmenu-inner">
									<li><a href="../Packages.aspx">Private Seller</a></li>
									<li><a href="http://www.mobicarz.com/Dealer.aspx">Dealer</a></li>
								</ul><!-- /.regularmenu-inner -->
							</div>						
						</li>						
						<%--<li><a href="contact.html">Contact</a></li>--%>
						<li><a href="../Account.aspx" runat="server" visible="false" id="accountLi">My Account</a></li>
						<li><a href="Reviews.aspx" runat="server" visible="false" id="reviewLi" style=" display:none; " >Reviews</a></li>
						<li runat="server" visible="false" id="loginLi" ><a href="http://www.mobicarz.com/Login.aspx"><i class='icon icon-normal-turn-off'></i>Login</a></li>
						<li runat="server" visible="false" id="logoutLi"><asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="<i class='icon icon-normal-turn-off'></i> Logout" OnClick="lnkBtnLogout_Click"></asp:LinkButton></li>
						</ul><!-- /.nav -->
					</nav>
				</div><!-- /.col-md-12 -->
			</div><!-- /.row -->
		</div><!-- /.container -->
	</div><!-- /.header-inner -->
</header>
    <!-- /#header -->
    <div class="infobar">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <ol class="breadcrumb pull-left">
                        <li><a href="#">Home</a></li>
                        <li><a href="#">Featured Cars</a></li>
                        <li class="active">Buy</li>
                    </ol>
                    <div class="contact pull-right">
                        <div class="contact-item mail">
                            <div class="label">
                                <i class="icon icon-normal-mail"></i>
                            </div>
                            <!-- /.label -->
                            <div class="value">
                                <a href="mailto:example@example.com">info@mobicarz.com</a></div>
                            <!-- /.value -->
                        </div>
                        <div class="contact-item phone">
                            <div class="label">
                                <i class="icon icon-normal-mobile-phone"></i>
                            </div>
                            <!-- /.label -->
                            <div class="value">
                                888-465-6693 <small>(Mon - Fri : 9:00 AM - 5:00 PM)</small></div>
                            <!-- /.value -->
                        </div>
                        <!-- /.phone -->
                        <!-- /.mail -->
                        <div class="contact-item opening" style="display: none;">
                            <div class="label">
                                <i class="icon icon-normal-clock"></i>
                            </div>
                            <!-- /.label -->
                            <div class="value">
                                Mon - Sun: 8:00 - 16:00</div>
                            <!-- /.value -->
                        </div>
                        <!-- /.opening -->
                        <div class="contact-item opening">
                            <!-- /.label -->
                            <div class="value">
                                <asp:UpdatePanel ID="usub" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnsubscr" runat="server" Text="Sign Up For Alerts" Style="margin-bottom: 2px;
                                            margin-left: 25px;" class="btn btn-danger  btn-xs " OnClick="btnsubscr_click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!-- /.value -->
                        </div>
                    </div>
                    <!-- /.contact -->
                </div>
                <!-- /.col-md-12 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </div>
    <!-- /.infobar -->
    <asp:HiddenField ID="Hmake" runat="server" />
    <asp:HiddenField ID="Hmodel" runat="server" />
    <asp:HiddenField ID="HZip" runat="server" />
    <asp:HiddenField ID="HPrice" runat="server" />
    <asp:HiddenField ID="Hadd" runat="server" />

    <script type="text/javascript">


        var dummyPrice = $('#HPrice').val();
        $('.BuyPrice').text($('#HPrice').val());

        if (!dummyPrice) {
            dummyPrice = 10000;
        }
        //$('#yourZip').val($('#HZip').val());
        // ZipCode1 = $('#HZip').val()
        //CarsMatchedData($('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val(), dummyPrice);
        //console.log($('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val());
        // selSearchCri($('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val());


        //lblPrice1
        //CarsMatchedData( $('#make option:selected').val(), $('#model option:selected').val(), '19082', '68998'  );

        // START function updateCharCount300 
        
    
    </script>

    <div id="content">
        <div id="page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="heading">
                            <div class="title">
                                <h1 style="font-size: 45px; margin-top: 5px; font-weight: normal;">
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                    <asp:Label ID="lblPrice1" runat="server" class="detPrice"></asp:Label>
                                </h1>
                            </div>
                            <!-- /.title -->
                            <div class="subtitle">
                                <asp:Label ID="LabelSubtitle" runat="server"></asp:Label>
                            </div>
                            <!-- /.subtitle -->
                        </div>
                        <!-- /.heading -->
                    </div>
                    <!-- /.col-md-8 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /#page-heading -->
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12" style="padding-bottom: 15px;">
                        <div class="action-buttons">
                            <div class="buy-it-now  col-xs-12 col-sm-4 col-md-6 col-lg-2" style="padding-left: 0;">
                                <div class="label">
                                    Buy Now</div>
                                <div class="price BuyPrice">
                                    <asp:Label ID="lblPrice2" runat="server" class="detPrice"></asp:Label>
                                </div>
                            </div>
                            <!-- /.buy-it-now -->
                            <div class="buy-it-financial col-xs-12 col-sm-8 col-md-6 col-lg-10" style="padding-left: 0">
                                <div class="label">
                                    Call Now</div>
                                <div class="price phoneNumber">
                                    <asp:Label runat="server" ID="lblSellerNo2"></asp:Label>
                                </div>
                            </div>
                            <!-- /.buy-it-financial -->
                        </div>
                        <!-- /.action-buttons -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="main">
                            <div class="car car-detail">
                                <div class="row">
                                    <!-- Search block Start ----------------------------------  -->
                                    <div class="search-block" id="Div3" style="display: none;">
                                        <div style="width: 100%;">
                                            <h4>
                                                Make:</h4>
                                            <select id="make">
                                                <option>Select</option>
                                            </select>
                                            <h4>
                                                Model:</h4>
                                            <select id="model">
                                                <option>Select</option>
                                            </select>
                                            <div>
                                                <div class="floatL" style="width: 45%; margin-right: 15px;">
                                                    <h4>
                                                        Within:</h4>
                                                    <select id="within">
                                                        <option>Select</option>
                                                    </select>
                                                </div>
                                                <div class="floatL" style="width: 45%;">
                                                    <h4>
                                                        ZIP:</h4>
                                                    <input type="text" id="yourZip" runat="server" class="sample4">
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <a href="javascript:newSearch();" class="but1 floatR M10 form-1-submit">Go</a>
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <!-- Search Block End -------------------------------------  -->
                                    <!-- Sold Car Start ---------------------------------------- -->
                                    <div class="box30 soldCar">
                                        <h3 class="det-h2" style="display: none;">
                                            <span>Seller Information</span>
                                        </h3>
                                        <div class="inner">
                                            <table style="width: 100%;">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel ID="updpnl" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="soldCar block white block-shadow" id="soldCar" runat="server" style="margin: 20px 0;
                                                                        padding: 15px; border: #d9a863 3px dashed; background: #fffed1">
                                                                        <h2 style="color: #777; font-size: 26px;">
                                                                            <img id="sold" runat="server" visible="false" src="http://www.mobicarz.com/images/sold_out_stamp.gif"
                                                                                style="float: right">
                                                                            Sorry..!<br />
                                                                            <asp:Label ID="lblCarsoldStatus" runat="server"></asp:Label>
                                                                        </h2>
                                                                        <div class="clear">
                                                                            &nbsp;</div>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td style="width: auto; vertical-align: top">
                                                            <div class="sellerInfo1">
                                                                <strong>Phone: &nbsp;</strong><asp:Label runat="server" ID="Label1"></asp:Label>
                                                                <br />
                                                                <strong>Email: &nbsp;</strong> <a id="A2" runat="server" href="javascript: emailSend()">
                                                                    Send an email to seller</a>
                                                                <br />
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: top">
                                                            <div class="sellerInfo2">
                                                                <asp:Label Style="text-transform: capitalize;" ID="Label2" runat="server">
                                                                </asp:Label>
                                                                <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                                                <asp:Label ID="Label3" Style="display: none; text-transform: capitalize;" runat="server">
                                                                        <br />
                                                                        
                                                                </asp:Label>
                                                                <br />
                                                                <strong>Seller Type: </strong>
                                                                <asp:Label ID="Label4" runat="server">
                                                                </asp:Label>
                                                                <br />
                                                                <strong style="display: none">Seller Name: </strong>
                                                                <asp:Label ID="Label5" Style="display: none" runat="server"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td colspan="2">
                                                            <table style="float: right; margin-top: 10px;">
                                                                <tr>
                                                                    <td style="text-align: right; vertical-align: middle;">
                                                                        <a class="addthis_button" href="http://www.addthis.com/bookmark.php?v=300&amp;pubid=ra-50779dc47dd738eb">
                                                                            <img src="http://s7.addthis.com/static/btn/v2/lg-share-en.gif" width="125" height="16"
                                                                                alt="Bookmark and Share" style="border: 0" /></a>
                                                                    </td>
                                                                    <td style="text-align: right; width: 10px;">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td style="text-align: right; vertical-align: middle;">
                                                                        <a href="" id="LinkAdd1" runat="server" class="linkClient" target="_blank">
                                                                            <img src="../images/Eligible1.png" /></a> <a href="" id="linkAdd2" runat="server"
                                                                                class="linkClient" target="_blank">
                                                                                <img src="../images/Eligible2.png" /></a> <a href="" id="LinkAdd3" runat="server"
                                                                                    class="linkClient" target="_blank">
                                                                                    <img src="../images/Eligible3.png" /></a>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Sold Car End ------------------------------------------ -->
                                </div>
                                <asp:Label ID="lblError" runat="server"></asp:Label>
                                <div class="row">
                                    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6" style="margin-bottom: 20px;">
                                        <div class="row zoom-gallery">
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <ItemTemplate>
                                                    <div class="picture-wrapper2 col-xs-6 col-sm-6 col-md-6 col-lg-6">
                                                        <a href='<%# DataBinder.Eval(Container.DataItem, "PICPATH")%>' runat="server">
                                                            <asp:Image ID="ImgURL" class="boxShadow1 img1 shelf-img" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PICPATH")%>'
                                                                onerror="$(this).closest('div.picture-wrapper2').remove()" AlternateText='<%# DataBinder.Eval(Container.DataItem, "PIC")%>'
                                                                runat="server" />
                                                        </a>
                                                    </div>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <!--  <div class="loaderGal"></div>  -->
                                        </div>
                                        <!-- /.row -->
                                    </div>
                                    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                                        <div class="overview">
                                            <div id="tab-container" class="tab-container">
                                                <ul class='nav nav-tabs'>
                                                    <li class='tab'><a href="#overview">Overview</a></li>
                                                    <li class='tab'><a href="#description">Features</a></li>
                                                </ul>
                                                <!-- /.nav-tabs -->
                                                <div class="block white block-shadow">
                                                    <div class="block-inner">
                                                        <div id="overview" class="active">
                                                            <div class="row">
                                                                <div class="col-sm-5 col-md-5">
                                                                    <a class="btn btn-primary" id="mailsend" runat="server" href="javascript: emailSend()">
                                                                        <i class="icon icon-normal-mail"></i>Contact seller</a>
                                                                    <div class="actions">
                                                                        <ul>
                                                                            <li style="display: none;"><i class="icon icon-normal-ribbon"></i>
                                                                                <asp:Label ID="lblSellerName" Style="display: none" runat="server"></asp:Label>
                                                                            </li>
                                                                            <li><i class="icon icon-normal-phone"></i>
                                                                                <asp:Label runat="server" ID="lblSellerNo"></asp:Label></li>
                                                                            <li><i class="icon icon-normal-map-pointer"></i>
                                                                                <asp:Label Style="text-transform: capitalize;" ID="lblSellerAddress" runat="server">
                                                                                </asp:Label>
                                                                                <asp:HiddenField ID="hdnCarid" runat="server"></asp:HiddenField>
                                                                                <asp:HiddenField ID="zipcode" runat="server" />
                                                                                <asp:Label ID="lblSellerAddress2" Style="display: none; text-transform: capitalize;"
                                                                                    runat="server">
                                                                        <br />
                                                                        
                                                                                </asp:Label>
                                                                            </li>
                                                                            <li><i class="icon icon-normal-profile-male"></i>
                                                                                <asp:Label ID="lblSellerType" runat="server">
                                                                                </asp:Label></li>
                                                                        </ul>
                                                                    </div>
                                                                    <!-- /.actions-->
                                                                </div>
                                                                <!-- /.col-md-5 -->
                                                                <div class="col-sm-7 col-md-7">
                                                                    <h3>
                                                                        <span>About this</span>
                                                                        <asp:Label ID="lblSubTitle" runat="server"></asp:Label></h3>
                                                                    <table class="table">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Make
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblMake" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Model
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblModel" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Version
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblCarVersion" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Year
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Body Style
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblBodyStyle" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Exterior Color
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblExteriorColor" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Interior Color
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblInteriorColor" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Doors
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblDoors" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Vehicle Condition
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblVehicleCondition" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Price
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblPrice" runat="server" class="detPrice1"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Miles Done
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblMileage" runat="server" class="detMileage"></asp:Label>
                                                                                    mi
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Fuel Type
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblFuelType" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Fuel Economy
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblFEconomy" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Engine
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblEngine" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    Transmission
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblTransMission" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="property">
                                                                                    DriveTrain
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblDriveTrain" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="display: none">
                                                                                <td class="property">
                                                                                    Reg No
                                                                                </td>
                                                                                <td class="value">
                                                                                    <asp:Label ID="lblVin" runat="server"></asp:Label>
                                                                                    <asp:Label ID="lblModification" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <!-- /.table -->
                                                                </div>
                                                                <!-- /.col-md-7 -->
                                                            </div>
                                                            <!-- /.row -->
                                                            <div class="info">
                                                                <%--<asp:TextBox ID="lblDescription" Enabled="false" style=" border:none; box-shadow:none; outline:none; background:#fff; " runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control"
                                                                    ></asp:TextBox>--%>
                                                                <p>
                                                                    <asp:Label ID="lblDescription" runat="server" Text="" TextMode="MultiLine" Rows="8">
                                                                    </asp:Label></p>
                                                                <div class="box30" style="display: none;">
                                                                    <h3 class="det-h2">
                                                                        Surrounding towns</h3>
                                                                    <div class="inner">
                                                                        <ul class="towns" style="font-size: 11px;" runat="server" id="ulTowns">
                                                                        </ul>
                                                                        <div style="display: none">
                                                                            <asp:Image ID="img" runat="server" class="slide1a" />
                                                                            <asp:Label ID="lblNearbyzipcodes" Style="font-size: 11px;" runat="server"></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- /.info -->
                                                        </div>
                                                        <!-- /#overview -->
                                                        <div id="description">
                                                            <div class="row">
                                                                <div class="col-sm-12 col-md-12">
                                                                    <div class="featuresNew">
                                                                        <asp:DataList ID="dlFeature" runat="server">
                                                                            <ItemTemplate>
                                                                                <p>
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td style="width: 105px;">
                                                                                                <label class="title">
                                                                                                    <%# DataBinder.Eval(Container.DataItem, "FeatureTypeName")%>:</label>
                                                                                            </td>
                                                                                            <td>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "FeatureName")%>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </p>
                                                                            </ItemTemplate>
                                                                        </asp:DataList>
                                                                    </div>
                                                                    <!-- /.appliances -->
                                                                </div>
                                                                <!-- /.col-md-6 -->
                                                            </div>
                                                            <!-- /.row -->
                                                        </div>
                                                        <!-- /#description -->
                                                    </div>
                                                    <!-- /.block-inner -->
                                                </div>
                                                <!-- /.block -->
                                            </div>
                                            <!-- /#tab-container -->
                                        </div>
                                        <!-- ./overview -->
                                    </div>
                                </div>
                                <!-- Row End /  -->
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div id="reviewsBlock" class="grid-block block">
                                    <div class="page-header">
                                        <div class="page-header-inner">
                                            <div class="heading">
                                                <h2>
                                                    Ask a question</h2>
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
                                            <div class="inner-block white">
                                                <!-- Ask Question Start -->
                                                <asp:UpdatePanel ID="up1" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-md-12 col-sm-12">
                                                                <div class="ask">
                                                                    <div class="form-group ">
                                                                        <!-- txtCondition  -->
                                                                        <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence" style="display: inline-block;
                                                                            margin: 0; font-weight: normal; font-size: 12px;"><span id="sellingPointCharCount">300</span>
                                                                            characters left</span>
                                                                            <asp:TextBox ID="txtAskQuest" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"
                                                                                onchange="updateCharCount300(this,'sellingPointCharCount');" onkeyup="updateCharCount300(this,'sellingPointCharCount','sellingPointSentence');"
                                                                                MaxLength="300"></asp:TextBox>
                                                                        </span>
                                                                    </div>
                                                                    <div class="form-group ">
                                                                        <asp:Button ID="btnAskques" runat="server" OnClick="btnAskques_click" Text="Ask"
                                                                            class="btn btn-primary2 btn-sm" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <!-- Ask Question End -->
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12">
                                                        <!-- Answers Start -->
                                                        <dl>
                                                            <asp:DataList ID="rptquestion" runat="server" OnItemDataBound="rptquestion_ItemDataBound1">
                                                                <ItemTemplate>
                                                                    <div class="date">
                                                                        Posted on<span class="glyphicon glyphicon-calendar"></span><asp:Label ID="lblPublishpostdate"
                                                                            runat="server"></asp:Label></div>
                                                                    <strong style="color: #D9534F">
                                                                        <%# DataBinder.Eval(Container.DataItem, "DiscQuestion")%>
                                                                    </strong>
                                                                    <%# DataBinder.Eval(Container.DataItem, "DiscAnswer")%>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </dl>
                                                        <!-- Answers End -->
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="recent-cars" class="grid-block block">
                                    <div class="page-header">
                                        <div class="page-header-inner">
                                            <div class="heading">
                                                <h2>
                                                    Similiar cars
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
                                                <div class="inner-block white">
                                                    <div class="grid-carousel" id="grid-carousel">
                                                        <div class="contentLoader">
                                                        </div>
                                                    </div>
                                                    <!-- /.grid-carousel -->
                                                </div>
                                                <!-- /.inner-block -->
                                            </div>
                                            <!-- /.col-md-12 -->
                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div id="grid-carousel-pager">
                                                    <div class="prev">
                                                    </div>
                                                    <!-- /.prev -->
                                                    <div class="next">
                                                    </div>
                                                    <!-- /.next -->
                                                </div>
                                                <!-- /.grid-carousel-pager -->
                                            </div>
                                            <!-- /.col-md-12 -->
                                        </div>
                                        <!-- /.row -->
                                    </div>
                                    <!-- /.grid-block -->
                                </div>
                                <!-- /.col-md-12 -->
                            </div>
                            <!-- /.row -->
                            <!-- /#main -->
                        </div>
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.container -->
            </div>
            <!-- /.section -->
        </div>
    </div>
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    <!-- Contact Us Popup start-->
    <cc1:ModalPopupExtender ID="MpeEmail" runat="server" PopupControlID="Loginholder1"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEmail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEmail" runat="server" />
    <div id="Loginholder1" class="alert" runat="server" style="display: none;">
        <h4 id="H4">
            Email the Seller -
            <asp:Label ID="lblCartitle" runat="server"></asp:Label>
            <asp:Button ID="btnNopay" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div id="login" class="data sendMail" style="font-size: 14px;">
            <div>
                <div style="display: none;">
                    <label>
                        To:</label>
                    <b>
                        <asp:Label ID="lblSellarname2" runat="server" Visible="false"></asp:Label></b>
                    <br />
                    <asp:Label ID="lblSellarAddress" runat="server"></asp:Label></b>
                    <br />
                    <asp:Label ID="lblphone" runat="server"></asp:Label>
                </div>
                <div style="display: none;">
                    <div style="margin-bottom: 0px; margin-top: 15px;">
                        <label>
                            From:
                        </label>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
                <div>
                    <div id="leadFormHolder">
                        <div id="leadFormContentDiv">
                            <div>
                                <div id="Div1">
                                    <div>
                                        <div style="display: none;">
                                            <p>
                                                Hello!<br>
                                                I'm writing from
                                                <asp:TextBox runat="server" ID="zipCode1" MaxLength="25" ToolTip="Zip or City" class="default-value form-control"
                                                    Style="width: 90px; display: inline-block" />
                                                and I'm interested in the <strong></strong>you have listed on mobicarz.com for <strong>
                                                    <asp:Label ID="lblPrice3" runat="server" class="detPrice"></asp:Label>
                                                </strong>.<br />
                                                I would like to know more about this vehicle.
                                                <div style="display: inline-block; margin-top: 15px;">
                                                    <label>
                                                        I can be reached by phone on</label>
                                                    <a href="javascript:void(0);" tabindex="-1" style="display: none;"></a>
                                                </div>
                                            </p>
                                        </div>
                                        <!-- First Name -->
                                        <div class="form-section emailSeller">
                                            <div class="form-group ">
                                                <div class="col-sm-6 col-md-6">
                                                    <label>
                                                        First name: <span class="star">*</span></label>
                                                    <asp:TextBox ID="txtfirstName" size="8" runat="server" class="default-value form-control"
                                                        MaxLength="50" /><a href="javascript:void(0);" tabindex="-1" style="display: none;"></a>
                                                </div>
                                                <div class="col-sm-6 col-md-6">
                                                    <label>
                                                        Last name:</label>
                                                    <asp:TextBox runat="server" size="8" ID="txtlastName" class="default-value form-control"
                                                        MaxLength="50" /><a href="javascript:void(0);" tabindex="-1" style="display: none;"></a>
                                                </div>
                                                <div class=" clear ">
                                                </div>
                                            </div>
                                            <div class="form-group ">
                                                <div class="col-sm-6 col-md-6">
                                                    <label>
                                                        Email: <span class="star">*</span></label>
                                                    <asp:TextBox ID="txtcemail" alt="my email address*" MaxLength="253" size="20" runat="server"
                                                        ToolTip="my email address*" Text="my email address" class="default-value form-control" />
                                                </div>
                                                <div class="col-sm-6 col-md-6">
                                                    <label>
                                                        Phone: <span class="star">*</span></label>
                                                    <asp:TextBox ID="txtPhone" value="" size="16" runat="server" alt="my phone number*"
                                                        ToolTip="my phone number*" Text="my phone number" class="default-value sample4 form-control"
                                                        MaxLength="10" />
                                                </div>
                                                <div class=" clear ">
                                                </div>
                                            </div>
                                            <div class="col-sm-12 col-md-12">
                                                <label>
                                                    Provide Additional Comments:
                                                </label>
                                                <asp:TextBox ID="txtComments" runat="server" Text="Enter your message here" class="default-value form-control"
                                                    TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <!-- comments -->
                                        <!-- Trade-IN fields -->
                                        <p>
                                        </p>
                                    </div>
                                    <!-- end message -->
                                </div>
                                <!-- end email -->
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
            </div>
            <div style="">
                <div style="width: 100px; float: left;">
                    &nbsp;
                </div>
                <div style="width: 380px; float: left;">
                    <div style="width: 60px; float: left">
                        <asp:Button runat="server" ID="zipValBut" class="pull-left btn btn-primary2" Text="Ok"
                            OnClientClick="javascript:return ValidateContact();" OnClick="zipValBut_Click" />
                    </div>
                    <div style="width: 90px; float: left">
                        <input type="button" class="pull-left btn btn-default" id="btnCancelPW" value="Cancel"
                            onclick="javascript:return cancel1();" /></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Contact Us Popup END-->
    <!--Subscribe Us Popup start-->
    <cc1:ModalPopupExtender ID="mpealert" runat="server" PopupControlID="alertholder"
        TargetControlID="hdnfldalert" BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnfldalert" runat="server" />
    <div id="alertholder" runat="server" style="display: none">
        <div id="ZipVal" class="alert">
            <h4 id="H1">
                Alert
                <asp:Button ID="Button1" class="cls" OnClick="btnOk1_Click" runat="server" Text=""
                    BorderWidth="0" />
            </h4>
            <div class="data">
                <table style="width: 98%; margin: 0 auto">
                    <tr>
                        <td style="width: 95px;" colspan="2">
                            <asp:UpdatePanel ID="updpanel" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblAlertMsg" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px;" colspan="2">
                            <div style="width: 34px; margin: 30px auto 0 auto">
                                <asp:Button ID="btnOk1" runat="server" class="btn btn-primary2" Text="Ok" OnClick="btnOk1_Click" /></div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!----  Subscribe popup-------------->
    <cc1:ModalPopupExtender ID="mpesubscribe111" runat="server" PopupControlID="subScribUs111"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnSubscribe111" OkControlID="btnsubScribUs111">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnSubscribe111" runat="server" />
    <div id="subScribUs111" class="alert" style="height: auto; padding-bottom: 15px;
        max-width: 550px; width: 70%; display: none;">
        <h4 id="">
            Sign up to receive email alerts.
            <asp:LinkButton ID="btnsubScribUs111" runat="server" class="cls" Text="" Style="border-width: 0px;"></asp:LinkButton>
        </h4>
        <div class="data">
            <div class="row" style="color: #333;">
                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                    Any time if we see a car that matches your interest. Our automated robo system will
                    keep you updated with emails.
                    <br />
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <div class="title">
                        <h3>
                            My Preference</h3>
                    </div>
                    <div class="form-section">
                        <div class="form-group " id="delearBox" runat="server">
                            <label>
                                Make <span class="star">*</span></label>
                            <asp:UpdatePanel ID="m1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlmakesp" class="form-control" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlmakesp_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group ">
                            <label>
                                Model <span class="star">*</span></label>
                            <asp:UpdatePanel ID="mpu2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlmodelsp" class="form-control" runat="server" AutoPostBack="true"
                                        Enabled="false">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group ">
                            <label>
                                Year <span class="star">*</span></label>
                            <asp:UpdatePanel ID="upyeas" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlyearp" class="form-control" runat="server">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <div class="title">
                        <h3>
                            Personal Info</h3>
                    </div>
                    <div class="form-section">
                        <asp:UpdatePanel ID="U1" runat="server">
                            <ContentTemplate>
                                <div class="form-group " id="Div2" runat="server">
                                    <label>
                                        First Name</label>
                                    <asp:TextBox ID="txtfnamep" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group ">
                                    <label>
                                        Last Name
                                    </label>
                                    <asp:TextBox ID="txtlastnamep" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group ">
                                    <label>
                                        Email <span class="star">*</span></label>
                                    <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div style="text-align: right; margin: 10px 0;">
                <div style="float: right; width: 80px;">
                    <asp:UpdatePanel ID="Supbtn" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnSubok" runat="server" Text="Submit" class="btn btn-primary2 "
                                OnClientClick="return SendValidate();" OnClick="btnSubok_click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                &nbsp; &nbsp;
                <div style="float: right; width: 80px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btncancelp" runat="server" Text="Cancel" class="btn btn-default "
                                OnClick="btncancelp_click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!---- ------------------ Buy a cra Prompt page ---------------------------------->
    <cc1:ModalPopupExtender ID="MdlBuyacar" runat="server" PopupControlID="Buyacarpopup"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnBuyacar" OkControlID="btnsubScribUs">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnBuyacar" runat="server" />
    <div id="Buyacarpopup" class="alert" style="height: auto; padding-bottom: 15px; max-width: 550px;
        width: 70%; display: none;">
        <h4 id="H2">
            Buy A Car
            <asp:LinkButton ID="btnsubScribUs" runat="server" OnClick="btncancelpopclick_click"
                class="cls" Text="" Style="border-width: 0px;"></asp:LinkButton>
        </h4>
        <div class="data">
            <div class="row" style="color: #333;">
                <div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
                    <div class="form-section">
                        <div class="form-group " id="Div4" runat="server">
                            <label>
                                ZIP <span class="star">*</span></label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="buyzip"  MaxLength="5" CssClass="form-control buyzip sample4" runat="server"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <div style="text-align: right; margin: 10px 0;">
                <div style="float: right; width: 80px;">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="Button2" runat="server" Text="Submit" class="btn btn-primary2 " OnClientClick="return buySearch();" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                &nbsp; &nbsp;
                <div style="float: right; width: 80px;">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btncancelpopclick" runat="server" Text="Cancel" class="btn btn-default "
                                OnClick="btncancelpopclick_click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <!-------------------- Model Popup for automatic alerts------------->
    <cc1:ModalPopupExtender ID="mdlPDetalerts" runat="server" PopupControlID="mdlPopDetailPage"
        BackgroundCssClass="ModalPopupBG ModalPopupBGSP" TargetControlID="hdnPagmdlP" OkControlID="btnsubScribUsDet">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnPagmdlP" runat="server" />
    <div id="mdlPopDetailPage" class="alert Special" style="height: auto; padding-bottom: 15px;
        max-width: 550px; width: 100%; display: none;">
        <h4 id="H3">
            Can i call you to make a best offer on this car?
            <asp:LinkButton ID="btnsubScribUsDet" runat="server" class="cls" Text="" Style="border-width: 0px;"></asp:LinkButton>
        </h4>
        <div class="data">
            <div class="row" style="color: #333;">
                <div class="form-section">
                    <div class="form-group " id="Div6" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group ">
                                        <label>
                                            First Name <span class="star">*</span></label>
                                        <asp:TextBox ID="txt_DFrstName" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group ">
                                        <label>
                                            Last Name <span class="star">*</span></label>
                                        <asp:TextBox ID="txt_Dlastname" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-6">
                                    <div class="form-group ">
                                        <label>
                                            Email <span class="star">*</span></label>
                                        <asp:TextBox ID="txt_DEmail" CssClass="form-control " runat="server"></asp:TextBox>
                                    </div>
                                    </div>
                                    <div class="col-sm-6 col-md-6">
                                    <div class="form-group ">
                                        <label>
                                            Phone No<span class="star">*</span></label>
                                        <asp:TextBox ID="txt_DPhn" CssClass="form-control  sample4 " MaxLength="10" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div style="text-align: right; margin: 10px 0;">
                <div style="float: right; width: 80px;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnDetailClick" runat="server" Text="Submit" class="btn btn-primary2 "
                                OnClick="btnDetailClick_Click" OnClientClick="javascript:return ValidateDetContact();" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                &nbsp; &nbsp;
                <div style="float: right; width: 80px;">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnDetCancelClick" runat="server" Text="Cancel" class="btn btn-default "
                                OnClick="btnDetCancelClick_click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    </form>

    <script src="../libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="../libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="../libraries/star-rating/jquery.rating.js"></script>

    <script src="../js/jslider/jquery.slider.min.js" type="text/javascript"></script>

    <script src="../libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="../libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="../libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="../libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="../libraries/flot/jquery.flot.time.js"></script>

    <script src="../assets/js/carat.js"></script>

    <script type='text/javascript' src='../js/jquery.alphanumeric.pack.js'></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/jquery.vticker.js"></script>

    <script src="../js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type="text/javascript">
        var models;
        LoadingPage = 3;
        //var ZipCodes = [];
        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 4;

        var count = 0;
        var count2 = 0;

        var CarID1;



        var galInit = 0;

    

        $(window).load(function() {
            //GetCarsAds();
            //_initGallery()        
            
            
            
            
            $('#usedCarsLi').live('click', function(){
                stopTimer()
                $find('MdlBuyacar').show();
            })
            
           
            pageLoadCustom();
            
            
            if($('.featuresNew table').length <= 0){
                var ttt = '<h4 style="margin:30px 0 20px; line-height:21px; " ><br>Features are not listed. Contact the seller for additional details.<br></h4>'
                $('.featuresNew').html(ttt);
            }
            
        })

        function pageLoadCustom() {



            CarsMatchedData($('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val(), dummyPrice);
            
            $('table .value span').each(function() {
                if ($.trim($(this).text()).length < 1) {
                    $(this).closest('tr').remove();
                }
            });            

           // _initGridCarousel('.grid-carousel');
            
            
          

            $('.price100,  .detPrice, .detPrice1').formatCurrency();

            // $('.mele100, .lblMileage').formatCurrency({ symbol: ' mi' });
            $('#lblMileage').formatCurrency({ symbol: ' ' });

            var settings = { start: 1, change: false };

            //  $("#adv1 ul").idTabs(settings, true);  ------------------------------------------

            $(function() { $('.sample4').numeric({ allow: "-" }); })
            $('.ldrgif').hide();





            // Magic Popup

            
            
            

            //$(".group1").colorbox({ rel: 'group1' });
            var len2 = $('.contentSlider .galDiv a').length;
            // Content & Images Slider Left ArrowClick
            $('.sliderHolder .left1').click(function() {
                if (count2 >= 4) {
                    count2 -= 4;
                    $('.contentSlider .galDiv').animate({ marginLeft: -(count2 * 164) }, { queue: false, duration: 1200, easing: 'easeInOutQuint' });
                }


            });
            // Content & Images Slider Right ArrowClick
            $('.sliderHolder .right1').click(function() {
                if (count2 < len2 - 4) {
                    count2 += 4;
                    $('.contentSlider .galDiv').animate({ marginLeft: -(count2 * 164) }, { queue: false, duration: 1200, easing: 'easeInOutQuint' });
                } else {
                    count2 = 0;
                    $('.contentSlider .galDiv').animate({ marginLeft: 0 }, { queue: false, duration: 1200, easing: 'easeInOutQuint' });
                }
            });



           setGalDivSize();         


        }
    
    </script>

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
    </script>

    <script type="text/javascript">


        function setGalDivSize() {            
            
        
            $('.picture-wrapper2').each(function() {
                $(this).height($(this).width() - ($(this).width()/4))
            })


            $('img.shelf-img').each(function() {
                var self = $(this);
                var width1 = self.width();
                var height1 = self.height();
                if (width1 > height1) {
                    self.css({ height: self.closest('.picture-wrapper2').height(), width: "auto" });
                }
                else {
                    self.css({ width: self.closest('.picture-wrapper2').width(), height: "auto" });
                }
            });

            if ($('img.shelf-img').length > 0) {

               // $('.zoom-gallery-images').show();
                //$('.loaderGal').hide();
                
                if (galInit == 0) {
                    galInit = 1;
                    $('.zoom-gallery').magnificPopup({
                        delegate: 'a',
                        type: 'image',
                        closeOnContentClick: false,
                        closeBtnInside: false,
                        mainClass: 'mfp-with-zoom mfp-img-mobile',
                        image: {
                            verticalFit: true
                        },
                        retina: {
                            ratio: 1, // Increase this number to enable retina image support.
                            // Image in popup will be scaled down by this number.
                            // Option can also be a function which should return a number (in case you support multiple ratios). For example:
                            // ratio: function() { return window.devicePixelRatio === 1.5 ? 1.5 : 2  }


                            replaceSrc: function(item, ratio) {
                                return item.src.replace(/\.\w+$/, function(m) { return '@2x' + m; });
                            } // function that changes image source
                        },
                        gallery: {
                            enabled: true
                        },
                        zoom: {
                            enabled: true,
                            duration: 300, // don't foget to change the duration also in CSS
                            opener: function(element) {
                                return element.find('img');
                            }
                        }

                    });
                }
                    
                    
            } else {

            /*var carMake = $.trim($('#lblMake').text());
            var carModel = $.trim($('#lblModel').text());
            carMake = carMake.replace(' ', '-');
            carModel = carModel.replace(' ', '-');
            carModel = carModel.replace('/', '@');
                   
            var MakeModel = carMake + "_" + carModel;
            MakeModel = MakeModel.replace(' ', '-');
            MakeModel = MakeModel.replace('/', '@');
            path = "http://unitedcarexchange.com/images/MakeModelThumbs/" + MakeModel + ".jpg";


                    
            var div = "<div class='picture-wrapper2 col-xs-12 col-sm-12 col-md-12 col-lg-12'>"
            + "<img src='" + path + "' class='thumbV'  style='width:100%; height:auto' /><div class='stockPhoto2' >Stock Photo</div>"
            + "</div>";
            */



                    var div = '<div class="page-404" ><div class="not-found">'
                               + '<div class="not-found-icon">'
                               + '<div class="not-found-icon-normal">204</div></div>'
                               + '<div class="title"><h2>Ooops!</h2></div>'
                               + '<div class="subtitle"><h3>No images found.</h3></div>'
                               + '</div></div>';          
                                
                                
                            
                                

                    $('.zoom-gallery').html(div);                                         
                }
            
            
            
        }


        $(function() {

           






            $(window).resize(function() {
                setGalDivSize();
            });



            



            $('.linkClient').each(function() {
                $(this).attr('href', 'http://secondcarloans.com/Apply.aspx?a=' + $('#hdnCarid').val());
                // window.location.href = ';
            });









        })

        function ValidateContact() {

            var valid = true;
            if ($('#txtfirstName').val().trim() == '' || $('#txtfirstName').val().trim() == ' ' || $('#txtfirstName').val().trim().length <= 0) {
                alert("Enter first name");
                $('#txtfirstName').focus();
                valid = false;
                return valid;
            }
            if ($('#txtcemail').val().trim() == 'my email address') {
                alert("Enter from email");
                $('#txtcemail').focus();
                valid = false;
                return valid;
            }
            if (($('#txtcemail').val().trim().length > 0) && (echeck($('#txtcemail').val().trim()) == false)) {
                document.getElementById('txtcemail').value = ""
                document.getElementById('txtcemail').focus()
                valid = false;
                return valid;

            }
            if ($('#txtPhone').val().trim() == 'my phone number') {
                alert("Enter phone#");
                $('#txtPhone').focus();
                valid = false;
                return valid;
            }

            else if (($('#txtPhone').val().trim().length > 0) && ($('#txtPhone').val().trim().length < 10)) {
                $('#txtPhone').focus();
                $('#txtPhone').val();
                alert("Enter valid phone number");
                valid = false;
                return valid;
            }
            
            return valid;

            //, txtlastName, zipCode1
        }
        
        
          function ValidateDetContact() {

            var valid = true;
            if ($('#txt_DFrstName').val().trim() == '' || $('#txt_DFrstName').val().trim() == ' ' || $('#txt_DFrstName').val().trim().length <= 0) {
                alert("Enter first name");
                $('#txt_DFrstName').focus();
                valid = false;
                return valid;
            }
            else   if ($('#txt_Dlastname').val().trim() == '' || $('#txt_Dlastname').val().trim() == ' ' || $('#txt_Dlastname').val().trim().length <= 0) {
                alert("Enter last name");
                $('#txt_Dlastname').focus();
                valid = false;
                return valid;
            }
           
             
            else if(document.getElementById('txt_DEmail').value.length < 1) {
                document.getElementById('txt_DEmail').focus();
                alert("Enter email");
                 document.getElementById('txt_DEmail').value = ""
                document.getElementById('txt_DEmail').focus()
                valid = false;            
            
            }
            
             else if ((document.getElementById('txt_DEmail').value.length > 0) && (echeck(document.getElementById('txt_DEmail').value) == false) )
             {
               
                document.getElementById('txt_DEmail').value = ""
                document.getElementById('txt_DEmail').focus()
                valid = false;
                
           
            }    
         else if(document.getElementById('txt_DPhn').value.length < 1) {
                document.getElementById('txt_DPhn').focus();
                alert("Enter phone Number");
                 document.getElementById('txt_DPhn').value = ""
                document.getElementById('txt_DPhn').focus()
                valid = false;            
            
            }
            else if (($('#txt_DPhn').val().trim().length > 0) && ($('#txt_DPhn').val().trim().length < 10)) {
                $('#txt_DPhn').focus();
                $('#txt_DPhn').val();
                alert("Enter valid phone number");
                valid = false;
                return valid;
            }
            
            return valid;

            //, txtlastName, zipCode1
        }

        

        function slidershow() {


            make1 = $.trim($('#Hmake').text());
            Modal1 = $.trim($('#Hmodel').text());
            ZipCode1 = parseInt($.trim($('#Hzip').val()));
            //$('#yourZip').val($('#Hzip').val());
            WithinZipNew = 4;

            var settings = { start: 1, change: false };
            $("#adv1 ul").idTabs(settings, true);


            $('.detPrice,.detMileage,.detPrice1').formatCurrency();
            $('.detMileage').formatCurrency({ symbol: ' ' });


            var totalImages = $('div#basic2 ul li').length;
            ////console.log(totalImages);
            $('div#basic2 ul li img').each(function() {

                var img = $(this);
                var width = 0; var height = 0;
                $("<img/>").attr("src", $(this).attr("src")).load(function() {
                    totalImages--;
                    width = this.width;   // Note: $(this).width() will not
                    height = this.height; // work for in memory images.                          

                    var maxWidth = 680; // Max width for the image
                    var maxHeight = 452;    // Max height for the image          


                    ratio = maxWidth / width;   // get ratio for scaling image
                    img.attr("width", maxWidth); // Set new width
                    img.attr("height", height * ratio); // Scale height based on ratio

                    ////console.log(img.width()+", "+img.height()); 

                    if (totalImages <= 1) {
                        // Slider2
                        ////console.log(totalImages);
                        $("div#basic2").slideViewerPro({
                            thumbs: 6,
                            thumbsPercentReduction: 14
                        });
                    }
                    $('.ldrgif').hide();
                });
            });
            $('.ldrgif').hide();
        }

        function emailSend() {
            ////console.log('Email Send');
            //$('#Login-holder').show();

            $find('MpeEmail').show();

            $('.cls, #btnCancelPW').click(function() {

                //$('#Login-holder, #Country-holder').hide();

                $find('MpeEmail').hide();
                $('#zipCode1').val('Zip or City');
                $('#txtPhone').val('my phone number');
                $('#txtcemail').val('my email address');
                $('#txtfirstName').val('First Name');
                $('#txtlastName').val('Last Name');
                $('#txtComments').val('Enter your message here');
                return false;

            });

            $(function() {
                $('.default-value').each(function() {
                    var default_value = this.value;
                    $(this).css('color', '#999')
                    $(this).focus(function() {
                        $(this).css('color', '#333')
                        if (this.value == default_value) {
                            this.value = '';
                            $(this).css('color', '#333')
                        } else { $(this).css('color', '#333') }
                    });
                    $(this).blur(function() {
                        if (this.value == '') {
                            this.value = default_value;
                            $(this).css('color', '#999')
                        } else { $(this).css('color', '#333') }
                    });
                });
            })

            // $('#hdnCarid').val(); http://secondcarloans.com/Apply.aspx linkClient

        

        }

        function hide() {
            $('#Login-holder, #Country-holder').hide();
        }
        function alertshow() {
            $('#mpealert').show();
        }
        $(function() {
            $('.default-value').each(function() {
                var default_value = this.value;
                $(this).css('color', '#999')
                $(this).focus(function() {
                    $(this).css('color', '#333')
                    if (this.value == default_value) {
                        this.value = '';
                        $(this).css('color', '#333')
                    } else { $(this).css('color', '#333') }
                });
                $(this).blur(function() {
                    if (this.value == '') {
                        this.value = default_value;
                        $(this).css('color', '#999')
                    } else { $(this).css('color', '#333') }
                });
            });
        })
    </script>

    <script type="text/ecmascript" language="javascript">


        $('a.viewA').click(function() {
            //alert($(this).next("span").attr('id'))
            $(this).hide();
            $(this).next("p").show();

        });
        
        $('#alert-holder .cls').click(function() {
            $('#alert-holder').hide();
        });
    
    
	/* var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];
	
	var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];  
	
	*/
	
	var within = ['10','25','50','100','Anywhere'];
	
	
	var slideImg = ['images/large/zr1review_01.jpg',
					'images/large/zr1review_02.jpg',
					'images/large/zr1review_03.jpg',
					'images/large/zr1review_04.jpg',
					'images/large/zr1review_05.jpg',
					'images/large/zr1review_06.jpg',
					'images/large/zr1review_07.jpg',
					'images/large/zr1review_08.jpg',
					'images/large/zr1review_09.jpg',
					'images/large/zr1review_10.jpg',
					'images/large/zr1review_11.jpg',
					'images/large/zr1review_12.jpg',
					'images/large/zr1review_13.jpg',
					'images/large/zr1review_14.jpg',
					'images/large/zr1review_15.jpg',
					'images/large/zr1review_16.jpg',					
					];
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
				 
				 
	$(function() {
	//$("div.svwp").prepend("<img src='http://www.mobicarz.com/images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		$('.sample4').numeric({allow:"-"});
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		//$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#model, #modelA, #modelB').attr('disabled',true);
		 $('#yourZip').removeAttr('disabled');
		
	
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('color','#ffb619').css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}		
			
		});
		
		
		
		
				
		
		
		
		
		
		  // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		
		 
		
		
	});







	function updateCharCount300(textArea, displayField, displaySentence) {
	    // Only proceed if the parameters are valid
	    if (null != textArea && null != displayField && null != displaySentence) {
	        // Determine the count
	        var count = 300; // Max length
	        count -= textArea.value.length; // Text length
	        // Update the count
	        document.getElementById(displayField).innerHTML = count; // Update the number
	        // Update sentence color
	        if (count > 20) {
	            document.getElementById(displaySentence).style.color = "#808080";
	            document.getElementById(displaySentence).style.fontWeight = "normal";
	        } else if (count > 5) {
	            document.getElementById(displaySentence).style.color = "#C24747";
	            document.getElementById(displaySentence).style.fontWeight = "normal";
	        } else if (count > 0) {
	            document.getElementById(displaySentence).style.color = "#FF0000";
	            document.getElementById(displaySentence).style.fontWeight = "normal";
	        } else {
	            document.getElementById(displaySentence).style.color = "#FF0000";
	            document.getElementById(displaySentence).style.fontWeight = "bold";
	            textArea.value = textArea.value.substr(0, 299);
	        } // END if/else
	    } // END if
	    return false;
	} // END function updateCharCount300
		
    </script>

    <script type="text/javascript">
    function SendValidate()
	  {  
      
            var valid=true;  
            
              if (document.getElementById('<%=ddlmakesp.ClientID%>').value == "0") {
                alert('Please select make')
                valid = false;
                document.getElementById('ddlmakesp').focus();
                return valid;
            }
            else   if (document.getElementById('<%=ddlmodelsp.ClientID%>').value == "0") {
                alert('Please select model')
                valid = false;
                document.getElementById('ddlmodelsp').focus();
                return valid;
            }
               else   if (document.getElementById('<%=ddlyearp.ClientID%>').value == "0") {
                alert('Please select year')
                valid = false;
                document.getElementById('ddlyearp').focus();
                return valid;
            }
            
            
            
            
            if (document.getElementById('<%= txtemail.ClientID %>').value.length < 1)
             {
                alert("Please enter email address");
                document.getElementById('<%= txtemail.ClientID %>').focus();
                valid = false;
            } 
                else if (document.getElementById('<%= txtemail.ClientID %>').value.length < 1)
             {
                alert("Enter email address");
                document.getElementById('<%= txtemail.ClientID %>').focus();
                valid = false;
            }    
            
             else if (echeck(document.getElementById('<%= txtemail.ClientID %>').value)==false)
	        {
		        document.getElementById('<%= txtemail.ClientID %>').value=""
		        document.getElementById('<%= txtemail.ClientID %>').focus()
		        valid=false;
        		return valid;
	        }                     
            else if(document.getElementById("txtemail").value.length<1 && echeck(document.getElementById("txtemail").value)==false)
            {
                alert("Please enter the email address");               
                valid=false;
                document.getElementById("txtemail").focus();
            } 
         
            return valid;
        } 
	function echeck(str) 
    {

		var at="@"
		var dot="."
		var lat=str.indexOf(at)
		var lstr=str.length
		var ldot=str.indexOf(dot)
		if (str.indexOf(at)==-1){
		   alert("Invalid E-mail ID")
		   return false
		}

		if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){
		   alert("Invalid E-mail ID")
		   return false
		}

		if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){
		    alert("Invalid E-mail ID")
		    return false
		}

		 if (str.indexOf(at,(lat+1))!=-1){
		    alert("Invalid E-mail ID")
		    return false
		 }

		 if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){
		    alert("Invalid E-mail ID")
		    return false
		 }

		 if (str.indexOf(dot,(lat+2))==-1){
		    alert("Invalid E-mail ID")
		    return false
		 }
		
		 if (str.indexOf(" ")!=-1){
		    alert("Invalid E-mail ID")
		    return false
		 }

 		 return true					
	}
	
	
	
	
	var subTimer;
	var alertTimer;
	
	
	
	function alertTimerCall(){
	    stopTimer();
	    clearInterval(alertTimer);
	    $find('mdlPDetalerts').show();
	}	
	
	function stopTimer(){
	    clearInterval(subTimer);	    
	}
	
	function alertCall(){
	    stopTimer()
	    $find('mpesubscribe111').show();
	}	
	
	
	
	function resetTimer(){
	    //console.log('resetTimer Enter')
	    if($.cookie('PrefCookie') == 'Pref'){
	         //console.log('subTimer Call')
	        subTimer = setInterval(function(){alertCall()}, parseInt($.trim($('.HdnSubScribeValue').text())));        
	    }
	   
	}
	
	$(function(){	
	
	    if($('#accountLi').length <= 0){
	        resetTimer();
	    }
	    
	    $('#subScribUs111 .cls, #btnsubScribUsDet').live('click', function(){
	        resetTimer();
	    })
	    
	    
	    alertTimer = setInterval(function(){alertTimerCall()}, 30000 );
	    
	})
	
	
     
    </script>

</body>
</html>
