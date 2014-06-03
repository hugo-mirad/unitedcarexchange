﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Testimonials.aspx.cs" Inherits="Testimonials" 
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
                            <h1>Testimonials</h1>
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
                                        <div class="row">
                        <div class="col-md-12">
                            <div class="testimonials-block block">
                                
                               
                                <div class="row testi">
                                    <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>Our decision to sell our BMW 3-Series Sedan through "MobiCarz" has paid off very well. We experienced a definite increase in buyer responses for our car after posting our advertisement in Mobicarz and sold it with quickly and also managed to get fantastic price. </i>
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
                                    <!-- /.col-md-6 -->
                                    <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I have bought a Mercedes-Benz SLS AMG Roadster using Mobicarz, Thank you very much it's a breathtaking super sports car with the genes of the SLS AMG Coupe, yet with a character all of its own. Loving my Car :) </i>
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
                                    <!-- /.col-md-6 -->
                                    
                                    <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I wish to thank Mobicarz and your sales team in the way you handled the transaction involving my dream car, BMW X Series. <br />
 
I received it in perfect condition. And many people are admiring it, it's fabulous.<br />
 
Please keep it up selling value for money vehicles<br />
 
Thanks,</i>
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
                                                            <input name="star2" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star2" type="radio" class="star icon-normal-star" disabled="disabled">
                                                        </div>
                                                        <!-- /.star-rating -->
                                                        <div class="author">
                                                            <strong>Robert White</strong>
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
                                    
                                    <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I am happy to let you know that I received the vehicle in a very good condition and clean, I personally drove it all the way from Tampa, FL to Alpharetta, GA (490 mi ) without any problems keep Up the good work. The vehicle is for my personal use but I am looking forward to order another before the end of this month.</i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star3" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star3" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star3" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star3" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star3" type="radio" class="star icon-normal-star" disabled="disabled">
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
                                    
                                     <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I wish to express my satisfaction over the way Mobicarz managed to sell our 2005 Ferrari F430. I was wondering if I could sell it for good value, and to my luck on the same day I received a call from sales team of Mobicarz. I was impressed the way the sales guy explained me all the plans and I enrolled for Premium - Platinum package, It was a real worth as well the timely handling and confirmation of money transfers and shipments impressed me very much.</i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star4" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star4" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star4" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star4" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star4" type="radio" class="star icon-normal-star" disabled="disabled">
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
                                    <!-- /.col-md-6 -->
                                    
                                    <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>This was my first time purchasing a car on my own and I was extremely stressed out with pushy sales people until I went to Mobicarz, The sales team helped me and was not pushy at all which made me feel at ease. They were friendly and helped me every step of the way and gave me a great deal on my new Ford Mustang! :) I highly recommend Mobicarz if you are looking for a great sales person!</i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star5" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star5" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star5" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star5" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star5" type="radio" class="star icon-normal-star" disabled="disabled">
                                                        </div>
                                                        <!-- /.star-rating -->
                                                        <div class="author">
                                                            <strong>Steven Miller</strong>
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
                                    
                                    <div class="col-sm-12 col-md-12">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I received the car yesterday. The people at the bond wanted me to sell it off to them. You chose a very nice and good car for my wife. I really want to thank the sales guy at Mobicarz.</i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star6" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star6" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star6" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star6" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star6" type="radio" class="star icon-normal-star" disabled="disabled">
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
                                <div class="col-sm-12 col-md-12">
                                    <h3 class="h3">
                                        Sell Your Car- Easy & Fast With Our Ultimate Packages</h3>
                                    <p>
                                       More then a million cars sold, already. </p>
                                    <input type="button" class="btn btn-primary" value="Sign Up For MobiCarz Packages"
                                        style="display: inline-block; width: auto" onclick="window.location.href='SellRegi.aspx' " />
                                </div>
                                <div class="col-sm-6 col-md-3" style=" display:none">
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