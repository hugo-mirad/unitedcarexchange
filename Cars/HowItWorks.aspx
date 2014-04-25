<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HowItWorks.aspx.cs" Inherits="HowItWorks" 
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
                            <h1>How it Works?</h1>
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
                            
                                
                                <div class="col-xs-12 col-md-9">
                                    <div class="description">
                                        <p style="padding-top: 0">
                                                    <h3>
                                                        Buyers
                                                    </h3>
                                                    <ul class="ul1" style="margin: 10px 0 0  30px">
                                                        <li>Find used cars within your price range</li>
                                                        <li>Search among the largest collection of vehicle inventory from dealers and private
                                                            sellers</li>
                                                        <li>Search used cars in your neighborhood or all over the country</li>
                                                        <li>Stay up-to-date with the latest listings through our inventory updated daily and
                                                            available 24/7</li>
                                                        <li>Not sure which type of car you want to buy? mobicarz.com lets you research
                                                            and compare used cars by various filter options like searching for body type, mileage,
                                                            price, year and a number of other criteria</li>
                                                        <li>The detail page of each car listed gives you the contact details for private seller/dealer
                                                            of the car, car specifications, description and vehicle history</li>
                                                    </ul>
                                                </p>
                                                <br />
                                                <br />
                                                <p style="padding-top: 0">
                                                    <h3>
                                                        Private Sellers / Dealers</h3>
                                                    <ul class="ul1" style="margin: 10px 0 0  30px">
                                                        <li>Reach over thousands of buyers nationally and locally who are willing to buy used/new
                                                            cars</li>
                                                        <li>Create an online ad suitable to your budget based on the available plans</li>
                                                        <li>Sell your car faster by signing up for any one of the premium packages</li>
                                                        <li>Advanced photo gallery, location mapping and SEO optimized detailed car page gives
                                                            your vehicle more visibility</li>
                                                    </ul>
                                                </p>
                                        
                                    </div>
                                    <p>&nbsp;</p>
                                   
                                    
                                </div>
                                <div class="col-xs-12 col-sm-3 ">
                                    <div class="block-inner white block-shadow sidebar">
                                         <div class="block-title" style="border-bottom: 1px solid #D9D9D9; margin-bottom: 15px;" >
                                        <h3 style=" margin:0 0 10px 0; font-size:20px; " >
                                            Recent Cars</h3>
                                    </div>
                                            <div class="row ticker1">                                    
                                    
                                        <ul>
                                            <li><div class="contentLoader"></div></li>
                                        </ul>
                                       
                                        <!-- /.teaser-item-wrapper -->
                                    </div>
                                    </div>
                                    <!-- /.inner -->
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
        }


        
            
    
    </script>

    

    </form>
</body>
</html>
