<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Packages.aspx.cs" Inherits="Packages" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title id="Title1" runat="server"></title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/grid-12.css" type="text/css" />
    
   
    

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/CarsJScript.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script type="text/javascript" language="javascript">
        function pageLoad() {

            GetRecentListings();

        }
        
        function pageLoad() {
            GetRecentListings();
        }
      
    </script>

    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-33253135-1']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>

</head>
<body class="cssstyle-style1 menu-type-fusionmenu col12" id="all">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <!-- Main Start  -->
    <div class="main">
        <!-- head1 start  -->
        <div class="hed1">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle">
                        <a href="http://UnitedTruckExchange.com/">
                            <img src="images/logo.png" class="logo" /></a>
                    </td>
                    <td valign="top">
                        <uc1:TruckLogin ID="TruckLogin1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- head1 End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- Menu Start  -->
        <div class="menu">
            <uc2:TruckHeader ID="TruckHeader1" runat="server" />
        </div>
        <!-- Menu End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- content Start -->
        <div>
            <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px; background:#fff"
            cellpadding="0" cellspacing="0">
            <tr>
                <tr>
                    <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                    <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px; font-family:Arial; letter-spacing:0; text-transform:capitalize">
                        Recent Used Truck Listings</h2>
                        <small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                    <!-- Left Brand Ads Satrt -->
                    <div class="ticker1">
                        <ul></ul>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                    </div>
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                    <td style="vertical-align: top; padding-left: 10px;">
                        <!-- Right Content Start  -->
                        <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                        <!-- column Left Div End  -->
                        <div class="indent">
                            <div class="wrapper">
                                <table style="width: 100%; border-bottom: #ccc 1px solid; margin-bottom: 10px;" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td style="padding-right: 20px; padding-top: 10px;">
                                            <h2 style="font-family:Arial; letter-spacing:0; text-transform:capitalize; color:#666;">
                                                Select a Premium Package - Private Seller
                                            </h2>
                                        </td>
                                    </tr>
                                </table>
                                <div style="width: 100%; height: 2px; overflow: hidden">
                                    &nbsp;</div>
                                <!-- Sell Packages Div Start -->
                                <div style="width: 91%; margin: 0 auto; padding: 20px; background: url(images/containerBAck.jpg) bottom center;
                                    border: #eee 3px solid">
                                    <div class="pack1">
                                        <h3>
                                            Ad Listing Packages</h3>
                                        <p>
                                            Ad listings will get you online exposure. Today thousands of customers search online
                                            for a used Truck every month.</p>
                                        <ul>
                                            <li>Ad Duration 7 to 90 days</li>
                                            <li>Vehicle Photos up to 25</li>
                                            <li>Ad Traffic Reports</li>
                                        </ul>
                                        <br />
                                        <br />
                                        <br />
                                        <div class="absolute">
                                            <input type="button" class="button1 " value="Place Your Ad" onclick="javascript:window.location.href='SellRegi.aspx'" />
                                        </div>
                                        <div class="startFree">
                                            &nbsp;</div>
                                    </div>
                                    <div class="pack1 pack2">
                                        <h3>
                                            Premium Ad Promotion
                                        </h3>
                                        <p>
                                            Premium ad promotion packages include promotion of your Truck across multiple Internet
                                            sites including social media/facebook thus ensuring you get maximum exposure; Some
                                            of the promo packages come with money back guarantee.</p>
                                        <ul>
                                            <li>Money Back Guarantee</li>
                                            <li>Multi-Site Promotion </li>
                                            <li>Facebook, Google+ Visibility</li>
                                        </ul>
                                        <div class="absolute">
                                            <input type="button" class="button1 " value="Place Your Ad" onclick="javascript:window.location.href='Premium.aspx'" />
                                        </div>
                                        <div class="start99">
                                            &nbsp;</div>
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                                <!-- Sell Packages Div End -->
                                <!-- Box2 Div Start  -->
                                <!-- Box2 Div End  -->
                                <div class="clear">
                                </div>
                                <!-- Box2 Div Start  -->
                                <div class="box3">
                                    <div class="wrapper">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="width: 65%; border-right: #fedaa0 1px dotted; padding: 10px;">
                                                    <h2 class="h33a">
                                                        Sell Your Truck- Easy & Fast With Our Premium Packages</h2>
                                                    <p>
                                                        Thousands of vehicles sold, already - Sign up for United Truck Exchange Premium Packages.</p>
                                                </td>
                                                <td style="padding: 10px;">
                                                    <h2 class="h33a">
                                                        Used Truck Advertising</h2>
                                                    <i class="i1"></i><div class="clear">
                                                    </div>
                                                    View our <a href="SellRegi.aspx" >Advertising plans</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <!-- Box2 Div End  -->
                                <div class="clear">
                                </div>
                                <!-- Box2 Div Start  -->
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- content End -->
    <!-- <div class="push"></div>  -->
    <div class="clear">
        &nbsp;</div>
    <!-- Footer Start  -->
    <div class="footer">
    <uc3:TruckFooter ID="Footer1" runat="server" />
    </div>
    <!-- Footer End -->
    </form>
</body>
</html>
