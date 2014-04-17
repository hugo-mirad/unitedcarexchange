<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCars.aspx.cs" Inherits="NewCars"
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
        GetMakes();
        GetModelsInfo(); 
        GetRecentListings();    
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

    <script type="text/javascript" language="javascript">
     function echeck(str) {
            var at = "@"
            var dot = "."
            var lat = str.indexOf(at)
            var lstr = str.length
            var ldot = str.indexOf(dot)
            if (str.indexOf(at) == -1) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(at, (lat + 1)) != -1) {
                alert("Enter valid email")
                return false
            }

            if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(dot, (lat + 2)) == -1) {
                alert("Enter valid email")
                return false
            }

            if (str.indexOf(" ") != -1) {
                alert("Enter valid email")
                return false
            }

            return true
        }



  function Validate() {  
   var valid = true;   
             if (document.getElementById('txtContactName').value.trim().length < 1) {
                document.getElementById('txtContactName').focus();
                alert("Enter contact name");
                document.getElementById('txtContactName').value = ""
                document.getElementById('txtContactName').focus()
                
                valid = false;
                return valid;
            }
            
            
             else if(document.getElementById('txtphone').value.trim().length < 1) {
                document.getElementById('txtphone').focus();
                alert("Enter phone #");
                 document.getElementById('txtphone').value = ""
                document.getElementById('txtphone').focus()
                valid = false;            
            return valid;
            }            
            
             else if((document.getElementById('txtphone').value.trim().length > 0) && (document.getElementById('txtphone').value.trim().length < 10)) {
                document.getElementById('txtphone').focus();
                document.getElementById('txtphone').value = "";
                alert("Enter valid phone #");
                valid = false;            
            return valid;
            }      
            
            
            else if(document.getElementById('txtemail').value.trim().length < 1) {
                document.getElementById('txtemail').focus();
                alert("Enter email");
                 document.getElementById('txtemail').value = ""
                document.getElementById('txtemail').focus()
                valid = false;            
            return valid;
            }
            
             else if ((document.getElementById('txtemail').value.trim().length > 0) && (echeck(document.getElementById('txtemail').value.trim()) == false) )
             {
               
                document.getElementById('txtemail').value = ""
                document.getElementById('txtemail').focus()
                valid = false;               
           return valid;
            }    
         return valid;
      }
      
      
      function isNumberKey(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        
            function isNumberKeyWithDashForZip(evt)
         {
         
         
            var charCode = (evt.which) ? evt.which : event.keyCode         
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="" DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
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
                                    <!-- Left Brand Ads Satrt -->
                                    <div class="clear">
                                        &nbsp;</div>
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
                                            <!-- Box1 Div Start  -->
                                            <div class="box1">
                                                <div class="inner">
                                                    <div class="wrapper" id="searchFormHolder" runat="server">
                                                        <h3 class="h3">
                                                            Find New Cars</h3>
                                                        <div class="clear">
                                                            &nbsp;</div>
                                                        <div class="clear dummyHeight8">
                                                            &nbsp;</div>
                                                        <div class="width-1" style="width: 280px">
                                                            <div class="black2">
                                                                Name <span class="star" style="color: Red">*</span></div>
                                                            <asp:TextBox ID="txtContactName" runat="server" MaxLength="25" CssClass="input1"
                                                                Style="width: 260px;"></asp:TextBox>
                                                        </div>
                                                        <div class="clear dummyHeight8">
                                                            &nbsp;</div>
                                                        <div class="width-1" style="width: 280px">
                                                            <div class="black2">
                                                                Phone Number <span class="star" style="color: Red">*</span></div>
                                                            <asp:TextBox ID="txtphone" runat="server" MaxLength="10" class="input1 sample4" Style="width: 260px;"
                                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="clear dummyHeight8">
                                                            &nbsp;</div>
                                                        <div class="width-1" style="width: 280px">
                                                            <div class="black2">
                                                                Email <span class="star" style="color: Red">*</span></div>
                                                            <asp:TextBox ID="txtemail" runat="server" MaxLength="30" Width="260px" CssClass="input1"></asp:TextBox>
                                                        </div>
                                                        <div class="clear">
                                                            &nbsp;</div>
                                                        <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Register"
                                                            class="button1 but1" OnClick="btnregister_Click" />
                                                        <br />
                                                    </div>
                                                    <!-- <b><a href="#" onclick="document.getElementById('car-form').submit()"></a></b> -->
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </div>
                                            <!-- Box1 Div End  -->
                                            <!-- Box2 Div Start  -->
                                            <div class="box2">
                                                <div class="wrapper">
                                                    <h3 class="h3">
                                                        New Cars</h3>
                                                    <img src="images/used-car.jpg" alt="" style="margin: 0 0 6px 6px; float: right; width: 49%;
                                                        padding: 4px; border: #ccc 1px solid" />
                                                    <p>
                                                        We deal with &quot;New Cars&quot; where people can search new cars available
                                                        within their customized radius and specifications. United Car Exchange provides
                                                        detailed car information about each and every car make &amp; model, pricing information,
                                                        car description, monthly calculator tools, photo galleries and also with customer
                                                        reviews which help to make confident decisions to buy your new car.</p>
                                                    <p>
                                                        United Car Exchange is America&#39;s most trusted Online Buy &amp; Sell used car
                                                        agency. United Car Exchange provides an online platform where car buyers and sellers
                                                        can search, buy, sell and come together to talk about their new cars.
                                                    </p>
                                                    <div class="clear">
                                                    </div>
                                                </div>
                                            </div>
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
                                                                    Sell Your Car - Easy &amp; Fast!</h3>
                                                                <p>
                                                                    More then a million cars sold, already - Advertise with us.</p>
                                                                <input type="button" class="button1" value="LIST YOUR CAR NOW" onclick="window.location.href='Packages.aspx'" />
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
                                            <div class="ads1">
                                            </div>
                                            <!-- Ads Section Endt  -->
                                        </div>
                                    </div>
                                    <!-- -->
                                </div>
                            </div>
                            <!-- Results Start -->
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
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="popupBody" style="display: block" id="AlertUser">
        <div>
            <h3 class="h3">
                Your new car request will be shared with participating pre-qualified local dealers
                in your area. They will be contacting you directly.
            </h3>
            <asp:Button ID="btngo" runat="server" Text="Ok" class="button1 but1" OnClick="btnGo_Click" />
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
	
	
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	
					  
	
	
	var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
				 
				 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		
		
		$('.sample4').numeric();
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		
		
	
	
				
		
		
		
		  // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		
		 
		 // Ads		
		//$('.ads1').empty();
		//return a random integer between 0 and 10		
		var ads = '';
		//var imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		//ads += "<div class='left-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		//imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		//ads += "<div class='right-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		ads += "<div class='clear'>&nbsp;</div>";	
		imgPath = ad2[Math.floor(Math.random() * ad2.length)];		
		//ads += "<div class='horiz-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";	
		//ads += "<div class='clear'>&nbsp;</div>";
		$('.ads1').append(ads);
		 
		
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
