<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Premium.aspx.cs" Inherits="Premium"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register src="UserControl/HeadderBlogin.ascx" tagname="HeadderBlogin" tagprefix="uc2" %>
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
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>MobiCarz</title>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>

<uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />

    <div id="content" class="pricing-page">
        <div id="page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="heading">
                            <div class="title">
                                <h1>
                                    Pricing for Premium Packages</h1>
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
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="main">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="headline">
                                        Select a Package - Private Seller
                                    </div>
                                </div>
                            </div>
                            <div class="pricing">
                                <div class="row">
                                    <div class="col-sm-6 col-md-4 block-margin">
                                        <div class="pricing-package block block-shadow white">
                                            <div class="block-inner">
                                                <div class="title">
                                                    <h2>
                                                        Silver Deluxe</h2>
                                                </div>
                                                <div class="price gray-light block-shadow block-margin">
                                                    <div class="block-inner">
                                                        $99.99
                                                    </div>
                                                </div>
                                                <div class="product">
                                                    <ul class="product-list">
                                                        <li>Ad runs for 90 days</li>
                                                        <li>Unlimited renewals</li>
                                                        <li>20 photos </li>
                                                        <li>Featured listings </li>
                                                        <li>Promotional placement</li>
                                                        <li>Multi-site promotion</li>
                                                        <li style="border-bottom: none">Ad traffic report </li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                    </ul>
                                                </div>
                                                <div class="action-button">
                                                    <asp:Button ID="btnPremiumSilver" runat="server" Text="Select" OnClick="btnPremiumSilver_Click"
                                                        CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-4 block-margin">
                                        <div class="pricing-package popular block block-shadow white">
                                            <div class="block-inner">
                                            <div class="popular-label block-shadow">
                                                    Popular
                                                </div>
                                                <div class="title">
                                                    <h2>
                                                        Gold Deluxe</h2>
                                                </div>
                                                <div class="price gray-light block-shadow block-margin">
                                                    <div class="block-inner">
                                                        $199.99
                                                    </div>
                                                </div>
                                                <div class="product">
                                                    <ul class="product-list">
                                                        <li>Ad runs for 90 days</li>
                                                        <li>Unlimited renewals</li>
                                                        <li>20 photos </li>
                                                        <li>Featured listings </li>
                                                        <li>Promotional placement</li>
                                                        <li>Multi-site promotion</li>
                                                        <li>Ad traffic report </li>
                                                        <li>Money back guarantee </li>
                                                        <li >Spotlight ad</li>
                                                        <li style="border-bottom: none">VIP consultant team</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                        <li style="border-bottom: none">&nbsp;</li>
                                                    </ul>
                                                </div>
                                                <div class="action-button">
                                                    <asp:Button ID="btnPremiumGold" runat="server" Text="Select" OnClick="btnPremiumGold_Click"
                                                        CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 col-md-4 block-margin">
                                        <div class="pricing-package  block block-shadow white">
                                            <div class="block-inner">
                                                
                                                <div class="title">
                                                    <h2>
                                                        Platinum Deluxe</h2>
                                                </div>
                                                <div class="price gray-light block-shadow block-margin">
                                                    <div class="block-inner">
                                                        $299.99
                                                    </div>
                                                </div>
                                                <div class="product">
                                                    <ul class="product-list">
                                                        <li>Ad runs for 90 days</li>
                                                        <li>Unlimited renewals</li>
                                                        <li>20 photos </li>
                                                        <li>Featured listings </li>
                                                        <li>Promotional placement</li>
                                                        <li>Multi-site promotion</li>
                                                        <li>Max distribution</li>
                                                        <li>Facebook, Google+ visibility</li>
                                                        <li>Ad traffic report </li>
                                                        <li>Money back guarantee </li>
                                                        <li >VIP consultant team</li>
                                                        <li >Ad creation consultant</li>
                                                        <li >CarFax report </li>
                                                    </ul>
                                                </div>
                                                <div class="action-button">
                                                    <asp:Button ID="btnPremiumPlatinum" runat="server" Text="Select" OnClick="btnPremiumPlatinum_Click"
                                                        CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
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
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    <cc1:ModalPopupExtender ID="mpeSuccessalert" runat="server" PopupControlID="SuccessAlert"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnsuccess" CancelControlID="Button1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnsuccess" runat="server" />
    <div class="alert" style="display: block" id="SuccessAlert">
        <div>
             <h4 id="H1">
            Alert !
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
                <div class=" data">
            <p class="pp" style="font-size: 15px;">
                You have already Logged in mobicarz.com. if you want to register again with
                new username. You should logout or click proceed.
            </p>
            <asp:Button ID="btnProceed" class="btn btn-primary2" runat="server" Text="Proceed"
                Style="margin-left: 0; width: 101px;" OnClick="btnProceed_Click"></asp:Button>
            <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Cancel" Style="margin-left: 0;" />
            </asp:Button>
            </div>
        </div>
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

    </form>
</body>
</html>
