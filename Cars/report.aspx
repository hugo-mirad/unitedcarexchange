<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/jquery.slideViewerPro.1.5.js"></script>

    <script type="text/javascript" src="js/jquery.timers.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
    var models;
    LoadingPage = 3;
    //var ZipCodes = [];
    /*
    function pageLoad() {
        GetMakes();
        GetModelsInfo();
        SearchedCar();
        WithinZipBinding();
       
       
    }
    */
    
    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

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
                        <a href="login.aspx" class="login">Login</a>
                    </div>
                    <div id="menu">
                        <ul>
                            <li><a href="http://UnitedCarExchange.com">Home</a></li>
                            <li><a href="#">Used Cars</a></li>
                            <li><a href="#">New Cars</a></li>
                            <li class="last"><a href="Packages.aspx">Sell A Car</a>
                                <ul>
                                    <li><a href="Packages.aspx">Private Seller</a></li>
                                    <li><a href="#">Dealer</a></li>
                                </ul>
                            </li>
                            <li class="last"><a href="#">Tools</a></li>
                        </ul>
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
                                            Recent Used Car Listings</h3>
                                        <em class="i1">Most recent Used Cars listed for sale</em>
                                        <!-- Ticker1 Div Start  -->
                                        <div class="ticker1">
                                            <ul>
                                                <li>
                                                    <div>
                                                        <a href="#"><strong></strong></a>
                                                        <br />
                                                    </div>
                                                </li>
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
                                            Advantage of Buying Used Cars
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
                                    <!-- Vehicle Type Div Start -->
                                    <div class="box4">
                                        <h4 class="hed2">
                                            Reports Of Your Listing
                                        </h4>
                                        <div style="background: none; float: right; width: 180px; text-align: right;">
                                            <a href="#">&laquo; Back to my listing</a>
                                        </div>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1 photoUpload">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 140px; padding-right: 10px;">
                                                        <!-- Ad Start -->
                                                        <div class="searchResultsBox">
                                                            <h3>
                                                                Listing places</h3>
                                                            <table class="VisitsTable tab2" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <th scope="col">
                                                                        Site Name
                                                                    </th>
                                                                    <th scope="col">
                                                                        URL
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample1.com
                                                                    </td>
                                                                    <td>
                                                                        http://www.sample.com/usedcars/audi
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample2.com
                                                                    </td>
                                                                    <td>
                                                                        http://www.sample.com/usedcars/audi
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample3.com
                                                                    </td>
                                                                    <td>
                                                                        http://www.sample.com/usedcars/audi
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample4.com
                                                                    </td>
                                                                    <td>
                                                                        http://www.sample.com/usedcars/audi
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <!-- <input type="button" value="Reports" class="button1" style="float:right" />  -->
                                                        </div>
                                                        <!-- ad End -->
                                                        <!-- Visits Start -->
                                                        <div class="searchResultsBox">
                                                            <h3>
                                                                No of Visits</h3>
                                                            <table class="VisitsTable" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <th scope="col">
                                                                        Total Visits
                                                                    </th>
                                                                    <th scope="col">
                                                                        This Month
                                                                    </th>
                                                                    <th scope="col">
                                                                        This Week
                                                                    </th>
                                                                    <th scope="col">
                                                                        Today
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        134
                                                                    </td>
                                                                    <td>
                                                                        90
                                                                    </td>
                                                                    <td>
                                                                        18
                                                                    </td>
                                                                    <td>
                                                                        6
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <!-- <input type="button" value="Reports" class="button1" style="float:right" />  -->
                                                        </div>
                                                        <!-- Visits End -->
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <br />
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
                                    <br />
                                    <!-- Vehicle Type Div End -->
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer">
                    <a href="#">Home</a> | <a href="#">Used Cars</a> | <a href="#">New Cars</a> | <a
                        href="SellRegi.aspx">Sell A Car</a> | <a href="#">Car Dealers</a> | <a href="#">Tools</a>
                    | <a href="#">Financial Advice</a> | <a href="#">Advertise With Us</a> | <a href="#">
                        Contact Us</a>
                    <div class="clear">
                        &nbsp;</div>
                    <p style="padding-top: 10px; font-size: 11px">
                        United Car Exchange &copy; 2011 <a href="#">Privacy Policy</a></p>
                </div>
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

    <script type="text/ecmascript" language="javascript">
	/* var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];
	
	var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];  
	
	*/
	
	var within = ['10','25','50','100','Anywhere'];
	
	
	var slideImg = ['images/large/zr1review_01.jpg',
					'images/large/zr1review_02.jpg',
					'images/large/zr1review_03.jpg',
					'images/large/zr1review_04.jpg',
					'images/large/zr1review_05.jpg',
					'images/large/zr1review_06.jpg',
					'images/large/zr1review_07.jpg',
					'images/large/zr1review_08.jpg',
					'images/large/zr1review_09.jpg',
					'images/large/zr1review_10.jpg',
					'images/large/zr1review_11.jpg',
					'images/large/zr1review_12.jpg',
					'images/large/zr1review_13.jpg',
					'images/large/zr1review_14.jpg',
					'images/large/zr1review_15.jpg',
					'images/large/zr1review_16.jpg',					
					];
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	
					  
			  
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
				 
				 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		
		
		$('.sample4').numeric();
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#model, #modelA, #modelB').attr('disabled',true);
		
		
	
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('color','#ffb619').css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}			
			// $(this).parent().toggleClass('li-hover');
		});
		
		
		
		
				
		
		
		
		
		
		// lBrandAds
		/*
		if(ad1.length>0){
			var img = '';
			var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
			img += "<img src='"+imgPath+"' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		*/
		
		 
		
	});	
		
		
    </script>

    <script type="text/javascript">
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
