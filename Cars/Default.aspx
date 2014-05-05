<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html>
<head runat="server">

    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="google-site-verification" content="2afWHJV2bG8MLKQu3ALnWHn2yE4On226m-r5ScavdLM" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    <link href="js/jslider/jquery.slider.min.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <!--[if IE]>
  <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script src="assets/js/bannerAd.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <asp:HiddenField ID="hdnPriceMIN" runat="server" Value="" />
    <asp:HiddenField ID="hdnPriceMAX" runat="server" Value="" />
    <asp:HiddenField ID="hdnMileageMIN" runat="server" Value="" />
    <asp:HiddenField ID="hdnMileageMAX" runat="server" Value="" />
    <asp:HiddenField ID="hdnIPAddress" runat="server" />
    <div class="highlighted-wrapper gray">
        <!-- Banner Slider End  ------------------------------------------------------------- -->
        <div class="highlighted section" style="padding-top: 0;">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-sm-3">
                        <div id="overviews" class="slidesData">
                        </div>
                        <!-- /.overviews -->
                    </div>
                    <div class="col-md-7 col-sm-7">
                        <div id="slider" class="slidesImg">
                        </div>
                        <!-- /#slider -->
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.highligted -->
        <!-- Banner Slider End  ------------------------------------------------------------- -->
        <div class="filter-wrapper">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 col-xs-12 pull-right" style="position: relative; z-index: 100;
                        top: -20px;">
                        <div class="filter-block">
                            <div class="block">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="" data-toggle="tab">Search<br />
                                        <span>USED CARS</span></a></li>
                                </ul>
                                <!-- /.nav -->
                                <div class="content">
                                    <div class="inner">
                                        <div class="tab-content searchFormHolder">
                                            <div class="tab-pane active" id="search-sales">
                                                <div class="row dSearch">
                                                    <select id="within" style="display: none;">
                                                        <option value="5" selected="selected">Anywhere</option>
                                                    </select>
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-6 col-xs-6">
                                                        <label> Make </label>
                                                        <select name="maker" class="form-control" id="make" runat="server">
                                                            <option>Loading</option>
                                                        </select>
                                                    </div>
                                                    <!-- /.form-group -->
                                                    <div class="form-group col-lg-12 col-md-12 col-sm-6 col-xs-6">
                                                        <label> Model </label>
                                                        <select name="model" class="form-control" id="model" runat="server">
                                                            <option>Loading</option>
                                                        </select>
                                                    </div>
                                                    <div class="form-group col-lg-8 col-md-6 col-sm-6 col-xs-6">
                                                        <label> Your ZIP </label>
                                                        <input type="text" class="form-control sample4" maxlength="5" placeholder="ZIP" id="yourZip"
                                                            runat="server">
                                                    </div>
                                                    <div style="display: none;">
                                                        <!-- /.form-group -->
                                                        <div class="filter-cars form-group col-lg-12 col-md-12 col-sm-6 col-xs-6" style="margin: 10px 0 0;">
                                                            <div class="filter-range-slider" style="height: 70px; padding-top: 25px">
                                                                <input id="priceRange" type="text" value="0;150000" runat="server">
                                                            </div>
                                                        </div>
                                                        <div class="filter-cars form-group col-lg-12 col-md-12 col-sm-6 col-xs-6" style="margin-bottom: 4px;">
                                                            <div class="filter-range-slider" style="height: 70px; padding-top: 25px;">
                                                                <input id="mileRange" type="text" value="0;100000" runat="server">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- /.form-group -->
                                                </div>
                                                <!-- /.row -->
                                                <div class="form-group">
                                                    <a href="javascript:minMx2();" class="searchButton send btn btn-primary btn-primary-color form-1-submit">
                                                        Search <i class="icon icon-normal-right-arrow-small"></i></a>
                                                </div>
                                                <!-- /.form-group -->
                                            </div>
                                            <!-- /.tab-pane -->
                                            <!-- /.tab-pane -->
                                        </div>
                                        <!-- /.tab-content -->
                                    </div>
                                    <!-- /.inner -->
                                </div>
                                <!-- /.content -->
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /.filter-block -->
                    </div>
                    <!-- /.col-md-3 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.highlighted -->
        </div>
        <!-- /.slider-filter -->
    </div>
    <!-- /.highlighted-wrapper -->
    <div id="content" class="frontpage">
        <div class="section gray-light ">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="partners-block block">
                            <div class="page-header">
                                <div class="page-header-inner">
                                    <div class="heading">
                                        <h2>
                                            List your car in more than 30 sites</h2>
                                    </div>
                                    <!-- /.heading -->
                                    <div class="line">
                                        <hr>
                                    </div>
                                    <!-- /.line -->
                                </div>
                                <!-- /.page-header-inner -->
                            </div>
                            <!-- /.page-header -->
                            <div class="inner-block white block-shadow">
                                <div class="row">
                                    <div class="col-sm-12 col-md-12">
                                        <div class="partner">
                                            <div class=" viewMin ">
                                                <div class="row">
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/31.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/13.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/14.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/15.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/34.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/28.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/33.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/1.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/2.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/3.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/4.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/5.png" /></div>
                                                </div>
                                            </div>
                                            <div class=" clear ">
                                            </div>
                                            <div class="viewMoreLink">
                                                <a href="javascript:void(0);"><i class="icon icon-normal-eye"></i>View more</a></div>
                                            <div class="viewMore" style="display: none;">
                                                <div class="row">
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/6.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/7.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/8.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/9.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/10.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/11.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/12.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/16.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/17.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/18.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/19.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/20.png" /></div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/36.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/21.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/22.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/23.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/24.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/25.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/26.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/27.png" /></div>
                                                   <!--  <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/28.png" /></div>  -->
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/29.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/30.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos">
                                                        <img src="assets/img/multisiteLogos/32.png" /></div>
                                                    <div class="col-xs-4 col-sm-3 col-md-2 col-lg-2 multiSiteLogos"><img src="assets/img/multisiteLogos/35.png" /></div>  
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.partner -->
                                    </div>
                                    <!-- /.col-md-2 -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.inner-block -->
                        </div>
                        <!-- /.partners-block -->
                    </div>
                    <!-- /.col-md-12 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="recent-cars" class="grid-block block">
                            <div class="page-header center">
                                <div class="page-header-inner">
                                    <div class="line">
                                        <hr />
                                    </div>
                                    <!-- /.line -->
                                    <div class="heading">
                                        <h2>
                                            Featured Cars</h2>
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
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-9 col-sm-12">
                        <div id="main">
                            <div class="row-block block" id="best-deals">
                                <div class="page-header">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Popular Cars</h2>
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
                                        <div class="content white">
                                            <div class="inner popular">
                                                <div class="contentLoader">
                                                </div>
                                                <!-- /.row-item -->
                                            </div>
                                            <!-- /.inner -->
                                        </div>
                                        <!-- /.content -->
                                    </div>
                                    <!-- /.col-md-12 -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /#main -->
                    </div>
                    <!-- /.col-md-9 -->
                    <div class="col-md-3 col-sm-12">
                        <div class="sidebar">
                            <div id="random-cars" class="random-cars block block-shadow white">
                                <div class="block-inner">
                                    <div class="block-title">
                                        <h3>
                                            Recent Cars</h3>
                                    </div>
                                    <!-- /.block-title -->
                                    <div class="row ticker1">
                                        <ul>
                                            <li>
                                                <div class="contentLoader">
                                                </div>
                                            </li>
                                        </ul>
                                        <!-- /.teaser-item-wrapper -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.block-inner -->
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /.sidebar -->
                    </div>
                    <!-- /.col-md-3 -->
                </div>
                <!-- /.row -->
                <div id="content-bottom">
                    <div class="row">
                        <div class="col-md-12">
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
                                <div class="row" style=" margin-left:0; margin-right:0 " >
                                    <!-- tttttttttttttttttttttttt  ----------------------------------->
                                    <div id="carousel-example-generic" class="carousel slide gallery-grid" data-ride="carousel">
                                        <ol class="carousel-indicators">
                                            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                                        </ol>
                                        <div class="carousel-inner">
                                            <div class="item clearfix active">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-12">
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
                                                                                <i>Our decision to sell our BMW 3-Series Sedan through "MobiCarz" has paid off very
                                                                                    well. We experienced a definite increase in buyer responses for our car after posting
                                                                                    our advertisement in Mobicarz and sold it with quickly and also managed to get fantastic
                                                                                    price. </i>
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
                                                                            <strong>James Martin</strong>
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
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.item -->
                                            <div class="item clearfix">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-12">
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
                                                                                <i>I have bought a Mercedes-Benz SLS AMG Roadster using Mobicarz, Thank you very much
                                                                                    it's a breathtaking super sports car with the genes of the SLS AMG Coupe, yet with
                                                                                    a character all of its own. Loving my Car :) </i>
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
                                                                            <strong>Paul Jones</strong>
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
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.item -->
                                            <div class="item clearfix">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-12">
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
                                                                                <i>I wish to express my satisfaction over the way Mobicarz managed to sell our 2005
                                                                                    Ferrari F430. I was wondering if I could sell it for good value, and to my luck
                                                                                    on the same day I received a call from sales team of Mobicarz. I was impressed the
                                                                                    way the sales guy explained me all the plans and I enrolled for Premium - Platinum
                                                                                    package, It was a real worth as well the timely handling and confirmation of money
                                                                                    transfers and shipments impressed me very much. </i>
                                                                            </p>
                                                                        </div>
                                                                        <!-- /.description -->
                                                                        <div class="star-rating">
                                                                            <input name="star2" type="radio" class="star icon-normal-star" checked="checked"
                                                                                disabled="disabled">
                                                                            <input name="star2" type="radio" class="star icon-normal-star" checked="checked"
                                                                                disabled="disabled">
                                                                            <input name="star2" type="radio" class="star icon-normal-star" checked="checked"
                                                                                disabled="disabled">
                                                                            <input name="star2" type="radio" class="star icon-normal-star" checked="disabled"
                                                                                disabled="disabled">
                                                                            <input name="star2" type="radio" class="star icon-normal-star" checked="disabled"
                                                                                disabled="disabled">
                                                                        </div>
                                                                        <!-- /.star-rating -->
                                                                        <div class="author">
                                                                            <strong>Barbara Parker</strong>
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
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.item -->
                                        </div>
                                        <!-- /.carousel-inner -->
                                        <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                                            <i class="icon icon-normal-left-arrow-small"></i></a><a class="right carousel-control"
                                                href="#carousel-example-generic" data-slide="next"><i class="icon icon-normal-right-arrow-small">
                                                </i></a>
                                    </div>
                                    <!-- /.carousel -->
                                    <!-- tttttttttttttttttttttttttttttt            ------------------------------------------------------------------>
                                    
                                    
                                    
                                </div>
                                <!-- /.row -->
                               
                            </div>
                            
                            <!-- /.testimonials-block -->
                        </div>
                       
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                   
                </div>
                <!-- /#content-bottom -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
        <div class=" clear "></div>
    </div>
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>

    <script src="libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="libraries/star-rating/jquery.rating.js"></script>

    <script src="libraries/colorbox/jquery.colorbox-min.js"></script>

    <script src="js/jslider/jquery.slider.min.js" type="text/javascript"></script>

    <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="assets/js/carat.js"></script>

    <script type="text/javascript">




        $(function() {

            // viewMin   viewMoreLink   viewMore.

            $('.viewMoreLink').click(function() {
                $(this).remove();
                $('.viewMin').append($('.viewMore').children());
                $('.viewMore').remove();
            })

            //$.cookie('userZip'); // => "the_value"
            //$.cookie('not_existing'); // => undefined

            if ($.cookie('userZip')) {
                $('#yourZip').val($.cookie('userZip'));
            } else {

                /*
                var ip = $('#hdnIPAddress').val();
               
                // if (!ip || !ip.length) { ip = "66.23.236.151"; }
               
                $.get("http://freegeoip.net/json/" + ip, function(data) {
                //console.log(data.zipcode);
                if (data.zipcode && data.zipcode != '') {
                $('#yourZip').val(data.zipcode);
                }

                });
                */
            }






            //myFun();
            KeyListener.init();
            KeyListener2.init()







        });


        /*

        function myFun() {
        //alert('Ok')       
        if (screen.width < 500) {
        var navegador = navigator.userAgent.toLowerCase();
        if (navegador.search(/iphone|ipod|android|nok(6|i)/) > -1) {
        document.location = "http://www.mobicarz.com/index.aspx";
        } else {
        document.location = "http://www.mobicarz.com/index.aspx";
        }
        }
        }
        */


        var models = [];
        //var ZipCodes = [];
        var SessionArray = [];
        within = [10, 25, 50, 100, 'Anywhere'];
        var MakeID1;
        var MakeIDName;
        var zip1;

        var SearchResults;
        LoadingPage = 1;
        page = 1;
        PageResultsCount = 25;
        //hideSpinner();
        startNum = 1;
        var endNum = 25;
        maxPages = 0;
        totalTesults = 0;
        resultsLength = 0;

        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 3;

       


    $(window).load(function(){
            GetCarBannerAds();

            GetMakes();
            GetModelsInfo();

            GetCarsAds();
            GetRecentListings();
    })


        function KeyDownHandler(btn) {
            if (event.keyCode == 13) {
                event.returnValue = false;
                //event.cancel = true;
                //btn.click();
            }
        }


        KeyListener = {
            init: function() {
                $('#searchFormHolder').bind('keypress', function(e) {
                    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                    var target = e.target.tagName.toLowerCase();
                    if (key === 13 && target === 'input') {
                        e.preventDefault();
                        var button = $('.form-1-submit');
                        if (button.length > 0) {
                            if (typeof (button.get(0).onclick) == 'function') {
                                button.trigger('click');
                            } else if (button.attr('href')) {
                                window.location = button.attr('href');
                            } else {
                                button.trigger('click');
                            }
                        }

                    }

                });
            }
        };



        KeyListener2 = {
            init: function() {
                $('#ZipVal').bind('keypress', function(e) {
                    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                    var target = e.target.tagName.toLowerCase();
                    if (key === 13 && target === 'input') {
                        e.preventDefault();
                        var button = $('#zipValBut');
                        if (button.length > 0) {
                            if (typeof (button.get(0).onclick) == 'function') {
                                button.trigger('click');
                            } else if (button.attr('href')) {
                                window.location = button.attr('href');
                            } else {
                                button.trigger('click');
                            }
                        }
                    }

                });
            }
        };
    
   

    </script>

    </form>
</body>
</html>
