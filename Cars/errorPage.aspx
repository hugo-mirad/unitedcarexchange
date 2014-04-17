<%@ Page Language="C#" AutoEventWireup="true" CodeFile="errorPage.aspx.cs" Inherits="errorPage"
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
    within = [10, 25, 50, 100, 'Anywhere']; 
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
    
    var make1='All makes' ;
    var Modal1='All models';
    var ZipCode1='' ;
    var WithinZipNew=3 ; 
    
       
   function pageLoad() {
        GetRecentListings();
        GetMakes();
        GetModelsInfo();     
        //GetZips();  
   }
    
    
    function KeyDownHandler(btn)
    {
      if (event.keyCode == 13)
      {
        event.returnValue=false;
        //event.cancel = true;
        //btn.click();
      }
    }

  
    KeyListener = {
        init : function() {
            $('#searchFormHolder').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('.but1');
                    if (button.length > 0) {
                        if (typeof(button.get(0).onclick) == 'function') {
                            button.trigger('click');
                        }else if (button.attr('href')) {
                            window.location = button.attr('href');
                        }else {
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
                        <%--<asp:Label ID="lblWelcome" runat="server" Text="Welcome" Visible="false"></asp:Label>
                        &nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                        <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" Visible="false"
                            OnClick="lnkBtnLogout_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkLogin" runat="server" CssClass="login" Text="Login" PostBackUrl="~/Login.aspx"></asp:LinkButton>--%>
                        <!-- <a href="#"><div  id="gomobile">Go mobile <img src="images/mobile.png" alt="" /></div></a>  -->
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
                                        <em class="i1">Must read tips &amp; advices on used cars</em><br />
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
                                    <!--  -->
                                    <div class="info-box" style="background: #fff;">
                                        <div class="wrapper">
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 20px; padding-top: 10px;">
                                                        <h2 style="color: #FF9900">
                                                            Oops..!
                                                        </h2>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="border-top: #ccc 1px solid; padding: 15px 10px; width: 95%;">
                                                <div style="width: 90%; margin: 20px auto; padding: 20px; background: #FDE7CE; color: #FF6600;
                                                    border: #FF6600 2px dashed;">
                                                    <h2 style="font-size: 22px;">
                                                        Sorry the link doesn't exist.<br />
                                                        Please re-search for a car
                                                    </h2>
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <!-- -->
                                </div>
                            </div>
                            <!-- Results Start -->
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
    <!-- Processiong
    Popup End -->
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
		
		
		
		
		
		// Ads1		
		/*
		$('.ads1').empty();
		//return a random integer between 0 and 10		
		var ads = '';
		var imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		ads += "<div class='left-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		ads += "<div class='right-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		ads += "<div class='clear'>&nbsp;</div>";	
		$('.ads1').append(ads);
				
		
		
		
		
		
		// lBrandAds
		if(ad1.length>0){
			var img = '';
			var imgPath = leftAd[Math.floor(Math.random() * leftAd.length)];			
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
