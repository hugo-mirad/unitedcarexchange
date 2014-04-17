<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Premium.aspx.cs" Inherits="Premium"
    EnableEventValidation="false" %>

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

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

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
                        <%-- <a href="login.aspx" class="login">Login</a>--%>
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
                                    <div id="div250X250" runat="server" style="padding: 3px; margin: 5px auto; width: 250px;
                                        height: 250px">
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
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads End -->
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
                                                    Select a Premium Package - Private Seller
                                                </h2>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 100%; height: 2px; overflow: hidden">
                                        &nbsp;</div>
                                    <!-- Sell Packages Div Start -->
                                    <div id="top" class="container_12" style="height: 820px">
                                        <div class="newsflash">
                                            <!-- block first Start  -->
                                            <div class="block first " style="position: relative">
                                                <h4 class="newsflash-title" style="background: none">
                                                </h4>
                                                <p class="price" style="background: none">
                                                </p>
                                                <div style="position: absolute; top: 0px; left: 25px; width: 119px; height: 120px;">
                                                    <asp:ImageButton ID="ImgbtnSellcar" runat="server" ImageUrl="~/images/sellCar.jpg"
                                                        OnClick="ImgbtnSellcar_Click" />
                                                    <%-- <a href="Registar.aspx">
                                                        <img src="images/sellCar.jpg" alt="" /></a>--%>
                                                </div>
                                                <ul>
                                                    <li class="first-child" style="height: 100px;">
                                                        <h3 style="font-size: 16px; text-align: left; width: 80%; margin: 5px auto">
                                                            Ad Details</h3>
                                                    </li>
                                                    <li style="height: 200px;">
                                                        <h3 style="font-size: 16px; text-align: left; width: 80%; margin: 5px auto">
                                                            Ad Exposure</h3>
                                                    </li>
                                                    <li style="height: 40px;">
                                                        <h3 style="font-size: 16px; text-align: left; width: 80%; margin: 5px auto">
                                                            Guarantees</h3>
                                                    </li>
                                                    <li style="height: 100px;">
                                                        <h3 style="font-size: 16px; text-align: left; width: 80%; margin: 5px auto">
                                                            Enhancements</h3>
                                                    </li>
                                                </ul>
                                            </div>
                                            <!-- block first End  -->
                                            <!-- block first Start  -->
                                            <div class="block second ">
                                                <h4 class="newsflash-title">
                                                    Silver Deluxe</h4>
                                                <p class="price" style="position: relative;">
                                                    <span class="sign">$</span>99.99<span class="package-pricing"></span></p>
                                                <ul>
                                                    <li class="first-child" style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Ad runs for 90 days<br />
                                                        Unlimited renewals<br />
                                                        20 photos </a></li>
                                                    <li style="height: 200px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Featured listings<br />
                                                        Promotional placement<br />
                                                        Multi-site promotion<br />
                                                        Ad traffic report </a></li>
                                                    <li style="height: 40px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        &nbsp; </a></li>
                                                    <li style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        &nbsp; </a></li>
                                                </ul>
                                                <div class="add-cart">
                                                    <p class="button">
                                                        <%--<a href="Registration.aspx"><span>Select</span></a>--%>
                                                        <asp:Button ID="btnPremiumSilver" runat="server" Text="Select" OnClick="btnPremiumSilver_Click"
                                                            CssClass="button-blank" />
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- block first End  -->
                                            <!-- block second Start  -->
                                            <div class="block third">
                                                <h4 class="newsflash-title">
                                                    Gold Deluxe</h4>
                                                <p class="price" style="position: relative;">
                                                    <span class="sign">$</span>199.99<span class="package-pricing"></span></p>
                                                <ul>
                                                    <li class="first-child" style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Ad runs for 90 days<br />
                                                        Unlimited renewals<br />
                                                        20 photos </a></li>
                                                    <li style="height: 200px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Featured listings<br />
                                                        Promotional placement<br />
                                                        Spotlight ad<br />
                                                        Multi-site promotion<br />
                                                        Ad traffic report </a></li>
                                                    <li style="height: 40px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Money back guarantee </a></li>
                                                    <li style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        VIP consultant team </a></li>
                                                </ul>
                                                <div class="add-cart">
                                                    <p class="button">
                                                        <%--<a href="Registration.aspx"><span>Select</span></a>--%>
                                                        <asp:Button ID="btnPremiumGold" runat="server" Text="Select" OnClick="btnPremiumGold_Click"
                                                            CssClass="button-blank" />
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- block second End  -->
                                            <!-- block thired Start  -->
                                            <div class="block fourth">
                                                <h4 class="newsflash-title">
                                                    Platinum Deluxe</h4>
                                                <p class="price" style="position: relative;">
                                                    <span class="sign">$</span>299.99<span class="package-pricing"></span></p>
                                                <ul>
                                                    <li class="first-child" style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Ad runs for 90 days<br />
                                                        Unlimited renewals<br />
                                                        20 photos </a></li>
                                                    <li style="height: 200px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Featured listings<br />
                                                        Promotional placement<br />
                                                        Multi-site promotion<br />
                                                        Max distribution<br />
                                                        Facebook, Google+ visibility<br />
                                                        Ad traffic report </a></li>
                                                    <li style="height: 40px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        Money back guarantee </a></li>
                                                    <li style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                        VIP consultant team<br />
                                                        Ad creation consultant<br />
                                                        CarFax report </a></li>
                                                </ul>
                                                <div class="add-cart">
                                                    <p class="button">
                                                        <%--  <a href="Registration.aspx"><span>Select</span></a>--%>
                                                        <asp:Button ID="btnPremiumPlatinum" runat="server" Text="Select" OnClick="btnPremiumPlatinum_Click"
                                                            CssClass="button-blank" />
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <!-- block thired End  -->
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <!-- TOP POSITION -->
                                    </div>
                                    <!-- Sell Packages Div End -->
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                            <!-- Results Start -->
                            <div class="wrapper">
                                <div id="div88X720" runat="server" style="height: 88px; width: 720px; margin: 10px auto;
                                    border: #999 1px solid; padding: 1px; background: white;">
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
                            </div>
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
        <cc1:ModalPopupExtender ID="mpeSuccessalert" runat="server" PopupControlID="SuccessAlert"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnsuccess" CancelControlID="Button1">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnsuccess" runat="server" />
        <div class="popupBody" style="display: block" id="SuccessAlert">
            <div>
                <h1 class="H2" style="padding: 10px 0 20px 0">
                    ALERT!</h1>
                <p class="pp" style="font-size: 15px;">
                    You have already Logged in UnitedCarExchange.com. if you want to register again
                    with new username. You should logout or click proceed.
                </p>
                <asp:Button ID="btnProceed" class="button1 popBut" runat="server" Text="Proceed"
                    Style="margin-left: 0; width: 101px;" OnClick="btnProceed_Click"></asp:Button>
                <asp:Button ID="Button1" class="button1 popBut" runat="server" Text="Cancel" Style="margin-left: 0;" />
                </asp:Button>
            </div>
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
