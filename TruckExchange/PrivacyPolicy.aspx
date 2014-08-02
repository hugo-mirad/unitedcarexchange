<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrivacyPolicy.aspx.cs" Inherits="PrivacyPolicy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::UnitedTruckExchange::..</title>
    
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
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
<body>
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
                    <div class="info-box" style="background: #fff;">
                        <div class="wrapper">
                            <table>
                                <tr>
                                    <td style="padding-right: 20px; padding-top: 10px;">
                                        <h2>
                                            Privacy Policy
                                        </h2>
                                    </td>
                                </tr>
                            </table>
                            <div style="border-top: #ccc 1px solid; padding: 15px 10px; width: 95%;">
                                <p>
                                    At "Unitedtruckexchange.com", the privacy of our visitors is of extreme importance
                                    to us. This privacy policy document outlines the types of personal information is
                                    received and collected by the site, how it is used and safeguard your information.<br />
                                    <br />
                                    <h3>
                                        Log Files</h3>
                                    As with most other websites, we collect and use the data contained in log files.
                                    The information in the log files include User IP address, the time Users visited
                                    our site, pages visited and no of clicks. The information we collect is used for
                                    internal reviews and generating customer monthly reports.<br />
                                    <br />
                                    <h3>
                                        Cookies and Web Beacons</h3>
                                    We do use cookies to store information, such as your personal preferences when you
                                    visit our site.<br />
                                    <br />
                                    We also use third party advertisements on "Unitedtruckexchange.com". Our advertising
                                    partners include Google Adsense, Chitika and Bidvertiser. Some of these advertisers
                                    may use technology such as cookies and web beacons when they advertise on our site,
                                    which will also send these advertisers information including your IP address, your
                                    ISP , the browser you used to visit our site, and in some cases, whether you have
                                    Flash installed. This is generally used for geotargeting purposes or showing certain
                                    ads based on specific sites visited.<br />
                                    <br />
                                    <h3>
                                        Email Address</h3>
                                    We collect the e-mail addresses of visitors those who post messages or suggestion
                                    through Unitedtruckexchange.com. We are not sharing any of those email addresses to
                                    any third party.<br />
                                    <br />
                                    <h3>
                                        External Links</h3>
                                    By visiting the external links shown in Link page of this site, visitors are stipulated
                                    with the Privacy Policy and Terms of Services of respective web sites they visits.
                                    If you require any more information or have any questions about our privacy policy,
                                    please feel free to contact us by email at <a href="mailto:info@unitedtruckexchange.com">
                                        info@unitedtruckexchange.com</a>.
                                </p>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <!-- Login Page End  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="clear">
                        &nbsp;</div>
                    <!-- Bottom Ads Start -->
                    <div class="bottomAdd " id="add730" style="width: 730px; margin: 10px 0; font-size: 11px;">
                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57 -->
                        <!-- End: adBrite -->
                    </div>
                    <!-- Bottom Ads End  -->
                    <!-- Right Content End  -->
                </td>
            </tr>
        </table>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        <uc3:TruckFooter ID="TruckFooter1" runat="server" />
    </div>
    <!-- Footer End  -->
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Processing
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script type="text/javascript">
    
     
	$(function() {
	
		$('a').each(function(){
			if($(this).attr('href') == '#'){
				$(this).attr('href','javascript:void(0)')
			}
		});	 
		
	});	
    
    
   
    </script>

</body>
</html>
