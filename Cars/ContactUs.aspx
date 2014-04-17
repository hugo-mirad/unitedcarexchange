<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs"
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
             if (document.getElementById('txtContcname').value.length < 1) {
                document.getElementById('txtContcname').focus();
                alert("Enter contact name");
                document.getElementById('txtContcname').value = ""
                document.getElementById('txtContcname').focus()
                
                valid = false;
            }
            
            
             else if(document.getElementById('txtphone').value.length < 1) {
                document.getElementById('txtphone').focus();
                alert("Enter phone #");
                 document.getElementById('txtphone').value = ""
                document.getElementById('txtphone').focus()
                valid = false;            
            
            }            
            
             else if((document.getElementById('txtphone').value.length > 0) && (document.getElementById('txtphone').value.length < 10)) {
                document.getElementById('txtphone').focus();
                document.getElementById('txtphone').value = "";
                alert("Enter valid phone #");
                valid = false;            
            
            }      
            
            
            else if(document.getElementById('txtemail').value.length < 1) {
                document.getElementById('txtemail').focus();
                alert("Enter email");
                 document.getElementById('txtemail').value = ""
                document.getElementById('txtemail').focus()
                valid = false;            
            
            }
            
             else if ((document.getElementById('txtemail').value.length > 0) && (echeck(document.getElementById('txtemail').value) == false) )
             {
               
                document.getElementById('txtemail').value = ""
                document.getElementById('txtemail').focus()
                valid = false;
                
           
            }    
            
            else if(document.getElementById('txtZip').value.length > 0)
             {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('txtZip').value);
                   if (isValid == false)
                   {
                     document.getElementById('txtZip').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('txtZip').value = ""
                    document.getElementById('txtZip').focus()
                    valid = false;  
                     return valid;      
                   }                                
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
        
        function pageLoad() {
            GetRecentListings();   
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
                                                        <h2>
                                                            Contact Us
                                                        </h2>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="border-top: #ccc 1px solid; border-bottom: #ccc 1px solid; padding: 15px 10px;
                                                width: 95%;">
                                                <table style="width: 98%;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 58%; border-right: 1px solid #ccc; vertical-align: top">
                                                            <table cellspacing="0" cellpadding="0" border="0" class="form1">
                                                                <tr>
                                                                    <td style="width: 120px; padding-right: 10px;">
                                                                        Contact Name <span class="star">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <span id="oeFormcontactNameContainer">
                                                                            <asp:TextBox ID="txtContcname" runat="server" MaxLength="25" Width="200px"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="oeFormcontactType1Container1">
                                                                        Phone <span class="star">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <span id="Span1">
                                                                            <asp:TextBox ID="txtphone" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr id="methodOfContactEmail">
                                                                    <td>
                                                                        Email Address <span class="star">*</span>
                                                                    </td>
                                                                    <td>
                                                                        <span id="oeFormcontactEmailContainer">
                                                                            <asp:TextBox ID="txtemail" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="Td3">
                                                                        Address
                                                                    </td>
                                                                    <td>
                                                                        <span id="Span4">
                                                                            <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="Td4">
                                                                        City
                                                                    </td>
                                                                    <td>
                                                                        <span id="Span5">
                                                                            <asp:TextBox ID="txtRegCity" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="Td1">
                                                                        State
                                                                    </td>
                                                                    <td>
                                                                        <span id="Span2">
                                                                            <asp:TextBox ID="txtDealerShipName" runat="server" MaxLength="25" Width="200px"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="Td5">
                                                                        Zip
                                                                    </td>
                                                                    <td>
                                                                        <span id="Span6">
                                                                            <asp:TextBox ID="txtZip" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td id="Td2" style="vertical-align: top">
                                                                        Notes
                                                                    </td>
                                                                    <td>
                                                                        <span id="Span3">
                                                                            <asp:TextBox ID="txtDealerNotes" runat="server" MaxLength="500" Width="200px" Height="60px"
                                                                                TextMode="MultiLine"></asp:TextBox>
                                                                        </span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td style="padding-top: 5px;">
                                                                        <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Submit"
                                                                            class="button1" OnClick="btnregister_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="vertical-align: top; padding-left: 15px;">
                                                            <p>
                                                                <h3>
                                                                    United Car Exchange</h3>
                                                                <strong>P.O. Box #504<br />
                                                                    Iselin, NJ 08830-0504</strong>
                                                                <br />
                                                                <br />
                                                                <h3>
                                                                    Customer Service</h3>
                                                                <strong>Phone: </strong>888-786-8307
                                                                <br />
                                                                <strong>Working Hours: </strong>9 AM to 5 PM EST (<i style="font-size: 11px; color: #666">Mon-Fri</i>)
                                                            </p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="clear">
                                            </div>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td style="padding-right: 20px; padding-top: 10px;">
                                                        <h2>
                                                            Map Directions
                                                        </h2>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="width: 98%; height: 350px; border: #ccc 1px solid; padding: 4px">
                                                <iframe width="100%" height="350" frameborder="0" scrolling="no" marginheight="0"
                                                    marginwidth="0" src="https://maps.google.com/maps?hl=en&amp;q=P.O.+Box+%23504+Iselin,+NJ+08830-0504&amp;ie=UTF8&amp;hq=&amp;hnear=Iselin,+New+Jersey+08830&amp;t=m&amp;z=14&amp;ll=40.569393,-74.317688&amp;output=embed">
                                                </iframe>
                                            </div>
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
            <br />
            <br />
            <h3 class="h3">
                Our marketing specialist will be contacting you shortly.
                <br />
                Thank you for your interest in United Car Exchange</h3>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
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
		/*
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
