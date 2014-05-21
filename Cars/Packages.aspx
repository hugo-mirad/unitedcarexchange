<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Packages.aspx.cs" Inherits="Packages"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register src="UserControl/HeadderBlogin.ascx" tagname="HeadderBlogin" tagprefix="uc2" %>
<!doctype html>
<html xml:lang="en" lang="en">
<head runat="server">
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
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>Packages</title>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    
    
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    
    <div id="content" class="rental">
        <div id="highlighted">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <div class="teaser">
                            <div class="title">
                                <h1>
                                    Select a Package</h1>
                            </div>
                            <!-- /.title -->
                            <p>
                                <b>Sell Your Car- Easy & Fast With Our Ultimate Packages</b><br />
                                More then a million cars sold, already - Sign up for MobiCarz Premium
                                Packages.
                            </p>
                        </div>
                        <!-- /.teaser -->
                    </div>
                    <div class="col-md-5 pricing-page">
                        <div id="reservation-form" class="block">
                            <div class="pricing pricing2">
                                <div class="row">
                                    <div class="inner">
                                        <div class="col-sm-6 col-md-6 block-margin">
                                            <div class="pricing-package block block-shadow white">
                                                <div class="block-inner">
                                                    <div class="title">
                                                        <h2>
                                                            Regular</h2>
                                                    </div>
                                                    <div class="price gray-light block-shadow block-margin">
                                                        <div class="block-inner">
                                                            <span>Starts from</span> FREE
                                                        </div>
                                                    </div>
                                                    <div class="product">
                                                        <ul class="product-list">
                                                            <li>Ad Traffic Reports</li>
                                                            <li>Ad Duration up to 60 days</li>
                                                            <li>Vehicle Photos up to 12</li>
                                                        </ul>
                                                    </div>
                                                    <div class="action-button">
                                                        <a class="btn btn-primary" href="javascript:window.location.href='SellRegi.aspx'">Select</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-6 block-margin">
                                            <div class="pricing-package popular block block-shadow white">
                                                <div class="block-inner">
                                                    <div class="popular-label block-shadow">
                                                        Popular
                                                    </div>
                                                    <div class="title">
                                                        <h2>
                                                            Premium
                                                        </h2>
                                                    </div>
                                                    <div class="price gray-light block-shadow block-margin">
                                                        <div class="block-inner">
                                                            <span>Starts from</span> $99.99
                                                        </div>
                                                    </div>
                                                    <div class="product">
                                                        <ul class="product-list">
                                                            <li>Money Back Guarantee</li>
                                                            <li>Multi-Site Promotion</li>
                                                            <li>Facebook, Google+ Visibility</li>
                                                        </ul>
                                                    </div>
                                                    <div class="action-button">
                                                        <a class="btn btn-primary" href="javascript:window.location.href='Premium.aspx'">Select</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- /.pricing  -->
                        </div>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="main">
                            
                            <!-- /.block -->
                            <div class="testimonials-block block">
                                <div class="page-header center">
                                    <div class="page-header-inner">
                                        <div class="line">
                                            <hr />
                                        </div>
                                        <div class="heading">
                                            <h2>
                                                Our Satisfied Customers</h2>
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
                                    <div class="col-sm-12 col-md-6">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                  <%--  <div class="col-sm-3 col-md-4">
                                                        <div class="picture">
                                                            <img src="assets/img/testimonials-1.png" alt="#">
                                                        </div>
                                                        <!-- /.picture -->
                                                    </div>--%>
                                                    <!-- /.col-md-4 -->
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I have bought a Mercedes-Benz SLS AMG Roadster using UnitedCarExchange.com, Thank
                                                                    you very much it's a breathtaking super sports car with the genes of the SLS AMG
                                                                    Coupe, yet with a character all of its own. Loving my Car :) </i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                        </div>
                                                        <!-- /.star-rating -->
                                                        <div class="author">
                                                            <strong>Lisa Turner</strong>
                                                        </div>
                                                        <!-- /.author -->
                                                    </div>
                                                    <!-- /.col-md-8 -->
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.inner -->
                                        </div>
                                        <!-- /.testimonial -->
                                    </div>
                                    <!-- /.col-md-6 -->
                                    <div class="col-sm-12 col-md-6">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   <%-- <div class="col-sm-3 col-md-4">
                                                        <div class="picture">
                                                            <img src="assets/img/testimonials-2.png" alt="#">
                                                        </div>
                                                        <!-- /.picture -->
                                                    </div>--%>
                                                    <!-- /.col-md-4 -->
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I received the car yesterday. The people at the bond wanted me to sell it off to
                                                                    them. You chose a very nice and good car for my wife. I really want to thank the sales guy
                                                                    at MobiCarz. </i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star1" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" disabled="disabled">
                                                        </div>
                                                        <!-- /.star-rating -->
                                                        <div class="author">
                                                            <strong>Thomas Garcia</strong>
                                                        </div>
                                                        <!-- /.author -->
                                                    </div>
                                                    <!-- /.col-md-8 -->
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.inner -->
                                        </div>
                                        <!-- /.testimonial -->
                                    </div>
                                    <!-- /.col-md-6 -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.testimonials-block -->
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

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

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

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad() {
            GetRecentListings();
        }
    </script>

    </form>
</body>
</html>
