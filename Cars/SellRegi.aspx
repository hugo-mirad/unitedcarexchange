<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SellRegi.aspx.cs" Inherits="SellRegi"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register src="UserControl/HeadderBlogin.ascx" tagname="HeadderBlogin" tagprefix="uc2" %>
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
                                    Pricing for Basic Packages</h1>
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
                            <div class="pricing" style="margin-bottom: 20px;">
                                <div class="row">
                                    <div class="col-sm-6 col-md-4 block-margin">
                                        <div class="pricing-package block block-shadow white">
                                            <div class="block-inner">
                                                <div class="title">
                                                    <h2>
                                                        Basic - FREE</h2>
                                                </div>
                                                <div class="price gray-light block-shadow block-margin">
                                                    <div class="block-inner">
                                                        FREE
                                                    </div>
                                                </div>
                                                <div class="product">
                                                    <ul class="product-list">
                                                        <li>Ad runs for 21 days</li>
                                                        <li>No renewals</li>
                                                        <li>1 photo </li>
                                                        <li style="border-bottom: none">Featured listings </li>
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
                                        <div class="pricing-package  block block-shadow white">
                                            <div class="block-inner">
                                                <div class="title">
                                                    <h2>
                                                        Standard</h2>
                                                </div>
                                                <div class="price gray-light block-shadow block-margin">
                                                    <div class="block-inner">
                                                        $24.99
                                                    </div>
                                                </div>
                                                <div class="product">
                                                    <ul class="product-list">
                                                        <li>Ad runs for 30 days</li>
                                                        <li>Unlimited renewals </li>
                                                        <li>3 photos </li>
                                                        <li>Featured listings</li>
                                                        <li style="border-bottom: none">Thumbnail photo </li>
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
                                        <div class="pricing-package popular block block-shadow white">
                                            <div class="block-inner">
                                                <div class="popular-label block-shadow">
                                                    Popular
                                                </div>
                                                <div class="title">
                                                    <h2>
                                                        Enhanced</h2>
                                                </div>
                                                <div class="price gray-light block-shadow block-margin">
                                                    <div class="block-inner">
                                                        $49.99
                                                    </div>
                                                </div>
                                                <div class="product">
                                                    <ul class="product-list">
                                                        <li>Ad runs for 60 days</li>
                                                        <li>Unlimited renewals</li>
                                                        <li>12 photos </li>
                                                        <li>Featured listings </li>
                                                        <li>Thumbnail photo</li>
                                                        <li>Ad traffic report </li>
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
                            <div class="row white block-shadow" style="margin: 0 0 30px 0; padding:20px;">
                                <div class="col-sm-6 col-md-9">
                                    <h3 class="h3">
                                        Sell Your Car- Easy & Fast With Our Premium Packages</h3>
                                    <p>
                                        More then a million cars sold, already - Sign up for MobiCarz Premium
                                        Packages.</p>
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
    <div class="alert"  style="display: block" id="SuccessAlert">
        <div>
           <h4 id="H1">
            Alert !
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
                <div class="data">
            <p class="pp">
                You have already Logged in..! 
                If you want to register again with
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
</body>
</form> </body>
</html>
