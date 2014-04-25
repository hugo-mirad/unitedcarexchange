<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsedCars.aspx.cs" Inherits="UsedCars" 
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
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css"
        media="screen, projection">
    <link href="js/jslider/jquery.slider.min.css" rel="stylesheet" type="text/css"
        media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    
    
    <div id="page-heading">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="heading">
                        <div class="title">
                            <h1>
                                Used Cars</h1>
                        </div>
                        <!-- /.title -->
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
    <div id="content" class="page-about">
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="article">
                                <div class="col-xs-12 col-sm-4 col-md-4">
                                    <div class="block-inner white block-shadow">
                                        <div class="picture " style=" margin-bottom:0; " >
                                            <h2>Find Used Cars</h2>
                                            <div id="searchFormHolder" runat="server">
                                                <div class="form-section">
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                        
                                                           <label> Make </label>
                                                       
                                                            <select id="make" runat="server"  tabindex="1" class="form-control">
                                                                <option value="">Loading...</option>
                                                            </select>
                                                            
                                                    </div>
                                                    
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                        <label> 
                                                            Model</label>
                                                       
                                                            <select id="model" runat="server" tabindex="2" class="form-control" >
                                                                <option>Loading...</option>
                                                            </select>
                                                    </div>
                                                    
                                                    <div class="form-group col-sm-12 col-md-7" style=" display:none; " >
                                                        <label> 
                                                            Within </label>
                                                            <select id="within" tabindex="3" runat="server" class="form-control">
                                                                <option>Loading...</option>
                                                            </select>
                                                        
                                                    </div>
                                                     <div class="form-group col-sm-12 col-md-6 col-lg-5">
                                                        <label> 
                                                            Your ZIP </label>                                                            
                                                            <input type="text" id="yourZip" maxlength="10" class="sample4 form-control" tabindex="4"  />
                                                        
                                                    </div>
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                    <a href="javascript:search();" tabindex="5" style="padding:10px; "  class="searchButton send btn btn-primary btn-primary-color form-1-submit searchBtn">
                                                        Search <i class="icon icon-normal-right-arrow-small"></i></a>
                                                        
                                                   
                                                    </div>
                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.picture -->
                                    </div>
                                    <!-- /.inner -->
                                </div>
                                <div class="col-xs-12 col-sd-6 col-md-8">
                                    <div class="description">
                                        <p>
                                            MobiCarz is America's most trusted Online Buy & Sell used car agency. MobiCarz provides an online platform where car buyers and sellers can search, buy, sell and come together to talk about their Used/ New Cars.</p>
                                        <p>
                                            MobiCarz lists detailed pricing information, description, dealer details, monthly calculator tools, photo galleries and customer reviews which helps car buyers with the information they need to make confident buying decisions.</p>
                                    </div>
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.col-md-12 -->
                </div>
                <!-- /.row -->
                <div id="content-bottom">
                <div class="row">
                        <div class="col-md-12">
                            <div class="row white block-shadow" style="margin: 30px 0; padding: 10px 10px 20px 10px;">
                                <div class="col-sm-6 col-md-9">
                                    <h3 class="h3">
                                        Sell Your Car- Easy & Fast With Our Premium Packages</h3>
                                    <p>
                                        More then a million cars sold, already - Sign up for MobiCarz Premium Packages.</p>
                                    <input type="button" class="btn btn-primary" value="Sign Up for Premium Packages"
                                        style="display: inline-block; width: auto" onclick="window.location.href='Premium.aspx' " />
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <h3 class="h3">
                                        Used Cars Advertising</h3>
                                    <i class="i1">We help you grow your business</i><div class="clear">
                                    </div>
                                    View our <a href="Packages.aspx">Advertising Plans</a>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                
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
                                                                <i>I have bought a Mercedes-Benz SLS AMG Roadster using MobiCarz.com, Thank
                                                                    you very much it's a breathtaking super sports car with the genes of the SLS AMG
                                                                    Coupe. Loving my Car :) </i>
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
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                    
                </div>
                <!-- /#content-bottom -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
    </div>
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

    <script src="assets/js/carat.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>
    
    
    
    <script type="text/javascript">
        var models;
        within = [10, 25, 50, 100, 'Anywhere'];
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
        //var ZipCodes = [];

        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 3;


        function pageLoad() {
            GetRecentListings();
            GetMakes();
            GetModelsInfo();
            //GetZips();  
        }


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
                        var button = $('.searchBtn');
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

        $(document).ready(function() {

        if ($.cookie('userZip')) {
            $('#yourZip').val($.cookie('userZip'));
        }
        
            KeyListener.init();
        });
            
    
    </script>


 </form>
</body>
</html>
