<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReturnPolicy.aspx.cs" Inherits="ReturnPolicy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::UnitedTruckExchange::..</title><title id="Title1" runat="server"></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />

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

    <script type="text/javascript">
        var models;
        within = ['100', '250', 'Anywhere'];
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
        var WithinZipNew = 1;


        function pageLoad() {
            GetMakes();
            GetModelsInfo();
            GetRecentListings();
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
                        var button = $('.but1');
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
            KeyListener.init()
        });
            
    
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

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

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
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px; background:#fff"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                        <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
                            Recent Used Truck Listings</h2><small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                        <!-- Left Brand Ads Satrt -->
                        <div class="ticker1">
                            <ul>
                            </ul>
                        </div>
                        <div class="clear">
                            &nbsp;</div>
                    </div>
                    <!-- Left Brand Ads Satrt -->
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <!-- column Left Div End  -->
                    <!-- content Start -->
                    <div id="content" style="background: #fff;">
                        <div class="wrapper-1">
                            <!-- column Left Div Start  -->
                            <!-- column Left Div End  -->
                            <div id="column-right" class="column-indent">
                                <div class="indent">
                                    <div class="wrapper" >
                                        <table style="margin-bottom: 10px;" cellpadding="0"
                                            cellspacing="0">
                                            <tr>
                                                <td style="padding-right: 20px; padding-top: 10px;">
                                                    <h2>
                                                        Return Policy &nbsp;
                                                    </h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- Sell Packages Div Start -->
                                        <div style="width: 99%; margin: 0; padding: 0px; border-top: #ccc 1px solid;">
                                            <div style="padding: 15px 0; width: 95%;">
                                                <p>
                                                    If your vehicle does not sell within 180 days, you will be eligible for refund of
                                                    the initial profiling fee on your advertisement cost minus any administrative costs.<br>
                                                    <br>
                                                    You must mail in the Money Back Guarantee Request Form and a notarized copy of title
                                                    within 2 weeks of your eligibility date to receive credit. We will automatically
                                                    remove your ads from the site once your refund is processed.<br>
                                                    <br>
                                                    This offer only applies to ads with Money-Back Guarantee included as an ad feature.
                                                    Additional Terms of Sale apply.
                                                    <br>
                                                    <br>
                                                    <br>
                                                </p>
                                                <h3>
                                                    <a href="MONEY BACK FORM.pdf" target="_blank">Download Money Back Form</a></h3>
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
                                                                Thousands of vehicles sold, already - Sign up for United Truck Exchange Premium
                                                                Packages.</p>
                                                        </td>
                                                        <td style="padding: 10px;">
                                                            <h2 class="h33a">
                                                                Used Truck Advertising</h2>
                                                            <i class="i1"></i><div class="clear">
                                                            </div>
                                                            View our <a href="Packages.aspx">Advertising plans</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <!-- Box2 Div End  -->
                                        <div class="clear">
                                        </div>
                                        <!-- Ads Section Start  -->
                                        <!-- Ads Section Endt  -->
                                    </div>
                                </div>
                                <!-- Results Start -->
                                
                                <!-- Results End -->
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <!-- content End -->
    </div>
    <!-- <div class="push"></div>  -->
    <div class="clear">
        &nbsp;</div>
    <!-- Footer Start  -->
    <div ID="footer" class="footer">
        <uc3:TruckFooter ID="Footer1" runat="server" />
    </div>
    <!-- Footer End -->
    </form>
</body>
</html>
