<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellRegi.aspx.cs" Inherits="SellRegi"
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

    <script>
        var LoadingPage = 10
    </script>


</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
        </cc1:ToolkitScriptManager>
        <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
        <div id="content" class="rental">
            <!-- Banner Satrt  -->
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
                                                    <h1>Select a Package</h1>
                                                </div>
                                                <!-- /.title -->
                                                <p>
                                                    <b>Sell Your Car- Easy & Fast With Our Exclusive Packages</b><br />
                                                    More then a million cars sold. - Sign up for MobiCarz Today.
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
            <!-- Banner End  -->
            <div class="pricing-page">
                <div class="section gray-light">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-12">
                                <div id="main">
                                    <div class="row" style="display: none">
                                        <div class="col-md-12">
                                            <div class="headline">
                                                Select a Package - Private Seller
                                            </div>
                                        </div>
                                    </div>
                                    <div class="pricing" style="margin-bottom: 20px;">
                                        <div class="row" style="text-transform: capitalize">
                                            <div class="col-sm-6 col-md-4 block-margin">
                                                <div class="pricing-package block block-shadow white">
                                                    <div class="block-inner">
                                                        <div class="title">
                                                            <h2>Regular</h2>
                                                        </div>
                                                        <div class="price gray-light block-shadow block-margin">
                                                            <div class="block-inner">
                                                                $99.99
                                                            </div>
                                                        </div>
                                                        <div class="product">
                                                            <ul class="product-list">
                                                                <li>Ad runs for 90 days</li>
                                                                <li>20 photos</li>
                                                                <li>15 + Multi site Promotions</li>
                                                                <li>Mobile, Social & Web listings</li>
                                                                <li style="border-bottom: none">Ad traffic report </li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                            </ul>
                                                        </div>
                                                        <div class="action-button">
                                                            <asp:Button ID="btnFree" runat="server" OnClick="btnFree_Click" Text="Select" CssClass="btn btn-primary" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4 block-margin">
                                                <div class="pricing-package popular  block block-shadow white">
                                                    <div class="block-inner">
                                                        <div class="popular-label block-shadow">
                                                            Popular
                                                        </div>
                                                        <div class="title">
                                                            <h2>Premium</h2>
                                                        </div>
                                                        <div class="price gray-light block-shadow block-margin">
                                                            <div class="block-inner">
                                                                $199.99
                                                            </div>
                                                        </div>
                                                        <div class="product">
                                                            <ul class="product-list">
                                                                <li>Ad runs for 90 days</li>
                                                                <li>20 Photos</li>
                                                                <li>15 + Multi Site Promotions</li>
                                                                <li>Mobile, Social & Web Listings</li>
                                                                <li>Ad Traffic Report </li>
                                                                <li>Popular Ads</li>
                                                                <li>Email Promotions & Dealer Network Ads</li>

                                                                <li style="border-bottom: none">Unlimited Renewals (Run Till It Sells)</li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                                <li style="border-bottom: none">&nbsp;</li>
                                                            </ul>
                                                        </div>
                                                        <div class="action-button">
                                                            <asp:Button ID="btnBasic" runat="server" OnClick="btnBasic_Click" Text="Select" CssClass="btn btn-primary" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-4 block-margin">
                                                <div class="pricing-package  block block-shadow white">
                                                    <div class="block-inner">

                                                        <div class="title">
                                                            <h2>Deluxe</h2>
                                                        </div>
                                                        <div class="price gray-light block-shadow block-margin">
                                                            <div class="block-inner">
                                                                $299.99
                                                            </div>
                                                        </div>
                                                        <div class="product">
                                                            <ul class="product-list">
                                                                <li>Ad runs for 90 days</li>
                                                                <li>20 photos</li>
                                                                <li>15 + Multi site Promotions</li>
                                                                <li>Mobile, Social & Web listings</li>
                                                                <li>Ad traffic report </li>
                                                                <li>Popular / Banner Ads</li>
                                                                <li>Email Promotions & Dealer Network Ads</li>
                                                                <li>Unlimited Renewals (Run Till It Sells)</li>
                                                                <li>Expert Advice</li>
                                                                <li>Premium Site Listings</li>

                                                            </ul>
                                                        </div>
                                                        <div class="action-button">
                                                            <asp:Button ID="btnEnhanced" runat="server" OnClick="btnEnhanced_Click" Text="Select"
                                                                CssClass="btn btn-primary" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- /.row -->
                                </div>
                                <!-- /#main -->
                            </div>
                            <!-- /.col-md-12 -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.container -->
                </div>
            </div>
            <!-- /.section -->
        </div>
        <!-- /#content -->
        <div id="footer">
            <uc1:Footer ID="Footer1" runat="server" />
        </div>
        <cc1:ModalPopupExtender ID="mpeSuccessalert" runat="server" PopupControlID="SuccessAlert"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnsuccess" CancelControlID="Button1">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnsuccess" runat="server" />
        <div class="alert" style="display: none" id="SuccessAlert">
            <div>
                <h4 id="H1">Alert !
                <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
                    <!-- <div class="cls">
            </div> -->
                </h4>
                <div class="data">
                    <p class="pp">
                        You have already Logged in..! If you want to register again with new username. You
                    should logout or click proceed.
                    </p>
                    <asp:Button ID="btnProceed" class="btn btn-primary2" runat="server" Text="Proceed"
                        Style="margin-left: 0; width: 101px;" OnClick="btnProceed_Click"></asp:Button>
                    <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Cancel" Style="margin-left: 0;" />
                    </asp:Button>
                </div>
            </div>
        </div>



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



        <script src="js/jquery.alphanumeric.pack.js" type="text/javascript"></script>
        <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

        <script src="js/FillMasterDataNew.js" type="text/javascript"></script>


        <script src="http://maps.googleapis.com/maps/api/js?sensor=true&amp;v=3.13"></script>

        <script src="assets/js/carat.js"></script>
</body>
</form> </body>
</html>
