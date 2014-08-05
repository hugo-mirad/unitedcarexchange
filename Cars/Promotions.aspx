<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Promotions.aspx.cs" Inherits="Promotions" EnableEventValidation="false" %>

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
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="#">
    <link rel="stylesheet" type="text/css" href="http://www.mobicarz.com/assets/css/bootstrap.min.css" media="screen, projection">
    
    <link rel="stylesheet" type="text/css" href="http://www.mobicarz.com/libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="http://www.mobicarz.com/libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="http://www.mobicarz.com/libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="http://www.mobicarz.com/js/jslider/jquery.slider.min.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="http://www.mobicarz.com/assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>Packages</title>

     <script src="http://www.mobicarz.com/assets/js/jquery.js"></script>

    <style>
        .featuredCar {
            padding: 0px;
            margin:0;
            background: #fff;
            
        }
            .featuredCar .thumbnail {
                border-radius:2px;
                box-shadow: 0px 1px 1px rgba(0, 0, 0, 0.2);
                border:0;
                padding:0;
            }
                .featuredCar .thumbnail img {
                        width:100%;                        
                }
        .featuredCar .thumbnail .caption, .featuredCar .thumbnail .caption h3{
            margin:0; text-align:center;
            font-size:14px;
            text-decoration:none;
            color:#666;
        }
            .featuredCar .thumbnail .caption h3 .pr {
                font-weight:bold;
                display:block;
            }

            .featuredCar a:hover , .featuredCar a:hover .thumbnail .caption h3{
                color:#232323;
                text-decoration:none;

            }
    </style>

    <script>
        var LoadingPage = 22;

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="scrptMgr" runat="server">
        </cc1:ToolkitScriptManager>

        <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />

        <div id="content" class="rental">
            <div id="highlighted">
                <div class="container">
                    <div class="row">
                        <div class="col-md-6">
                        </div>
                        <div class="col-md-6">
                            <div id="reservation-form" class="block">
                                <div class="pricing pricing2">
                                    <div class="row">
                                        <div class="inner">
                                            <div class="teaser">
                                                <div class="title">
                                                    <h1>Sell your USED CAR</h1>
                                                </div>
                                                <!-- /.title -->
                                                <p>
                                                    <b>Advertise for as low as $99.99 to Reach 15 million plus online customers.</b><br />
                                                    <asp:Button ID="LinkButton1" Text="LIST YOUR CAR NOW" class="button1 btn btn-danger" runat="server"
                                                        PostBackUrl="http://mobicarz.com/SellRegi.aspx" />
                                                </p>
                                            </div>
                                            <!-- /.teaser -->
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
                                <div class=" block" style="margin-bottom: 30px;">
                                    <div class="page-header center">
                                        <div class="page-header-inner">
                                            <div class="line">
                                                <hr />
                                            </div>
                                            <div class="heading">
                                                <h2>Used Cars In <span style="text-transform: capitalize; color: #f95446">
                                                    <asp:Label ID="lblCity" runat="server"></asp:Label>,&nbsp;<asp:Label ID="lblState" runat="server"></asp:Label></span>

                                                </h2>

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
                                       
                                           



                                                        <!-- featured start -->
                                                        <div class="featured">
                                                            <asp:Repeater ID="rptrCarsbyState" runat="server" OnItemDataBound="rptrModels_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <div class="list col-md-3 col-xs-12 col-sm-6">
                                                                        <div class="featuredCar">
                                                                            <!-- -->
                                                                            <asp:HyperLink ID="lnbtnTitle" runat="server">
                                                                                <div class="thumbnail">
                                                                                    <asp:Image runat="server" CssClass="img-thumbnail" ID="imgSimliar"></asp:Image>
                                                                               <div class="caption">
                                                                                    <h3>
                                                                                        <asp:Label ID="lnkTitle" runat="server" class="makeModel"></asp:Label>
                                                                                        <asp:Label ID="lblprice" runat="server" class="price1 pr"></asp:Label>
                                                                                    </h3>

                                                                                </div>
                                                                                     </div>
                                                                                
                                                                            </asp:HyperLink>
                                                                            <!-- -->

                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </div>
                                                        <!-- featured End -->


                                            <!-- /.testimonial -->
                                      
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.testimonials-block -->



                                <!-- Content Dummy Start  -->

                                <div class="row-block block">
                                    <div class="col-md-12">
                                        <div class=" row content white">
                                            <div class="col-md-12">



                                                <h3 class="h3">Best way to sell your used car in
                                                           
                                                    <asp:Label ID="lblState1" runat="server"></asp:Label>,
                                                            &nbsp;
                                                           
                                                    <asp:Label ID="lblCity1" runat="server"></asp:Label></h3>
                                                <p>
                                                    Are you looking to sell your used car in
                               
                                                            <asp:Label ID="lblState2" runat="server"></asp:Label>
                                                    &nbsp;
                               
                                                            <asp:Label ID="lblCity2" runat="server"></asp:Label>
                                                    then you are at the right place. We answer all car buyer and seller needs. MobiCarz
                                                             is America's most trusted Online Buy & Sell used car agency.MobiCarz helps in providing an online platform where car buyers and sellers
                                can search, buy, sell and come together to talk about their Used/ New Cars.
                           
                                                </p>
                                                <p>
                                                    MobiCarz lists detailed pricing information, description, dealer details,
                                monthly calculator tools, photo galleries and customer reviews which helps car buyers
                                with the information they need to make confident buying decisions.
                               
                                                           
                                                </p>
                                                <div class="clear">
                                                    &nbsp;
                                                </div>



                                            </div>
                                        </div>

                                    </div>

                                </div>
                                <!-- Dummy Content End   -->



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

        <script src="http://www.mobicarz.com/assets/js/jquery.js"></script>

        <script src="http://www.mobicarz.com/assets/js/jquery-migrate-1.2.1.js"></script>

        <script src="http://www.mobicarz.com/assets/js/jquery.ui.js"></script>

        <script src="http://www.mobicarz.com/assets/js/bootstrap.js"></script>

        <script src="http://www.mobicarz.com/assets/js/cycle.js"></script>

        <script src="http://www.mobicarz.com/libraries/jquery.bxslider/jquery.bxslider.js"></script>

        <script src="http://www.mobicarz.com/libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

        <script src="http://www.mobicarz.com/libraries/star-rating/jquery.rating.js"></script>

        <script src="http://www.mobicarz.com/libraries/colorbox/jquery.colorbox-min.js"></script>

        <script src="http://www.mobicarz.com/js/jslider/jquery.slider.min.js"></script>

        <script src="http://www.mobicarz.com/libraries/ezMark/js/jquery.ezmark.js"></script>

        <script type="text/javascript" src="http://www.mobicarz.com/libraries/flot/jquery.flot.js"></script>

        <script type="text/javascript" src="http://www.mobicarz.com/libraries/flot/jquery.flot.canvas.js"></script>

        <script type="text/javascript" src="http://www.mobicarz.com/libraries/flot/jquery.flot.resize.js"></script>

        <script type="text/javascript" src="http://www.mobicarz.com/libraries/flot/jquery.flot.time.js"></script>

        <script src="http://maps.googleapis.com/maps/api/js?sensor=true&amp;v=3.13"></script>

        <script src="http://www.mobicarz.com/assets/js/carat.js"></script>

        <script src="http://www.mobicarz.com/js/FillMasterDataNew.js" type="text/javascript"></script>

        <script type="text/javascript" src="http://www.mobicarz.com/js/jquery.vticker.js"></script>

        <script src="http://www.mobicarz.com/js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

        

    </form>
</body>
</html>
