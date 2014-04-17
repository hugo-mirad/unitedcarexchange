<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Packages.aspx.cs" Inherits="Packages" EnableEventValidation="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
        function pageLoad() {
            GetRecentListings();
        }
    </script>

</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                    <div class="loginStat">
                        
                        <uc2:LoginName ID="LoginName1" runat="server" />
                    </div>
                    <div id="menu">
                        <uc3:CarsHeader ID="CarsHeader1" runat="server" />
                        
                    </div>
                </div>
                <!-- content -->
                <div id="content">
                    <div class="wrapper-1">
                        <!-- column Left Div Start  -->
                        <div id="column-left">
                            <div class="indent" style="padding-top: 5px;">
                                <div class="wrapper">
                                    <!-- Recent Used Car Listings  start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Recent Sell Car Listings</h3>
                                        <em class="i1">Most recent Used Cars listed for sale</em>
                                        <!-- Ticker1 Div Start  -->
                                        <div class="ticker1">
                                            <ul>
                                            </ul>
                                        </div>
                                        <!-- Ticker1 Div End  -->
                                    </div>
                                    <!-- Recent Used Car Listings end  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div id="div250X250" runat="server"  style="padding: 3px; margin: 5px auto; width:250px; height:250px">
                                        
                                    </div>
                                    <div id="lBrandAds2" style="padding: 3px; margin: 5px auto;">
                                        <!-- Begin: adBrite, Generated: 2012-05-09 5:53:51  -->
                                        <style type="text/css">
                                            .adHeadline
                                            {
                                                font: bold 10pt Arial;
                                                text-decoration: underline;
                                                color: #0000FF;
                                            }
                                            .adText
                                            {
                                                font: normal 10pt Arial;
                                                text-decoration: none;
                                                color: #000000;
                                            }
                                        </style>

                                        <script type="text/javascript">
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                    </div>
                                    <!-- Left Brand Ads End -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Advantage of Buying Used Cars Start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Advantages & Tips for Buying Used Cars 
                                        </h3>
                                        <em class="i1">Must read tips & advices on Used Cars</em><br />
                                        <ul class="bullet" style="margin-left: 10px;">
                                            <li><a href="tips.aspx">Used Car buying tips</a></li>
                                        </ul>
                                    </div>
                                    <!-- Advantage of Buying Used Cars End -->
                                </div>
                            </div>
                        </div>
                        <!-- column Left Div End  -->
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <table style="width: 100%; border-bottom: #ccc 1px solid; margin-bottom: 10px;" cellpadding="0"
                                        cellspacing="0">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px;">
                                                <h2>
                                                    Select a Package - Private Seller &nbsp;
                                                </h2>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Sell Packages Div Start -->
                                    <div style="width: 91%; margin: 0 auto; padding: 20px; background: url(images/containerBAck.jpg) bottom center;
                                        border: #eee 3px solid">
                                        <div class="pack1">
                                            <h3>
                                                Ad Listing Packages</h3>
                                            <p>
                                                Ad listings will get you online exposure. Today over 15 million customers search online for a used car every month.</p>
                                            <ul>
                                                <li>Ad Traffic Reports</li>
                                                <li>Ad Duration up to 60 days</li>
                                                <li>Vehicle Photos up to 12</li>
                                            </ul>
                                            <br />
                                            <br />
                                            <br />
                                            <input type="button" class="button1" value="Place Your Ad" onclick="javascript:window.location.href='SellRegi.aspx'"
                                                style="float: none; margin: 20px auto 0 65px;" />
                                            <div class="startFree">
                                                &nbsp;</div>
                                        </div>
                                        <div class="pack1">
                                            <h3>
                                                Premium Ad Promotion
                                            </h3>
                                            <p>
                                                Premium ad promotion packages include promotion of your car across multiple Internet
                                                sites including social media/facebook thus ensuring you get maximum exposure; Some
                                                of the promo packages come with money back guarantee.</p>
                                            <ul>
                                                <li>Money Back Guarantee</li>
                                                <li>Multi-Site Promotion </li>
                                                <li>Facebook, Google+ Visibility</li>
                                            </ul>
                                            <input type="button" class="button1" value="Place Your Ad" onclick="javascript:window.location.href='Premium.aspx'"
                                                style="float: none; margin: 20px auto 0 65px;" />
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
                                                        <h3 class="h3">
                                                            Sell Your Car- Easy & Fast With Our Premium Packages</h3>
                                                        <p>
                                                            More then a million cars sold, already - Sign up for United Car Exchange Premium
                                                            Packages.</p>
                                                        <input type="button" class="button1" value="Sign Up for Premium Packages" onclick="window.location.href='Premium.aspx' " />
                                                    </td>
                                                    <td style="padding: 10px;">
                                                        <h3 class="h3">
                                                            Used Cars Advertising</h3>
                                                        <i class="i1">We help you grow your business</i><div class="clear">
                                                        </div>
                                                        View our <a href="Packages.aspx">Advertising Plans</a>
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
                             <div id="div88X720" runat="server"   style="height: 88px;width: 720px;margin: 10px auto;border: #999 1px solid;padding: 1px;background: white;">
                                       
                                    </div>
                             <!-- 
                            <div class="bottomAdd" style="margin-left: 1px;">
                               

                                <script type="text/javascript">
var AdBrite_Title_Color = '0000FF';
var AdBrite_Text_Color = '000000';
var AdBrite_Background_Color = 'FFFFFF';
var AdBrite_Border_Color = 'CCCCCC';
var AdBrite_URL_Color = '008000';
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
                                </script>

                                <span style="white-space: nowrap;">

                                    <script type="text/javascript">document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2102343&zs=3732385f3930&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                    <a target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2102343&afsid=1">
                                        <img src="http://files.adbrite.com/mb/images/adbrite-your-ad-here-leaderboard.gif"
                                            style="background-color: #CCCCCC; border: none; padding: 0; margin: 0;" alt="Your Ad Here"
                                            width="14" height="90" border="0" /></a></span>
                                
                            </div>
                            -->
                            <!-- Results End -->
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer">
                    <uc1:Footer ID="Footer1" runat="server" />
                </div>
            </div>
        </div>
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
    
    var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
	
	 // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-28766349-1']);
  _gaq.push(['_trackPageview']);
  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
    </script>

</body>
</html>
