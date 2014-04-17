<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Mobile_index" %>

<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>United Car Exchange</title>
    <link href="css/mobile.css" rel="stylesheet" type="text/css" media="handheld,all" />

    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.alphanumeric.js" type="text/javascript"></script>

    <script type="text/javascript">
        var models = [];
       //var ZipCodes = [];
        var SessionArray = [];
        within = [10, 25, 50, 100, 'Anywhere'];  
        var MakeID1; 
        var MakeIDName;
        var zip1 ;    
        
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
        
        var make1='All makes' ;
        var Modal1='All models';
        var ZipCode1='' ;
        var WithinZipNew=4 ; 
    
      function pageLoad() {
        //GetCarBannerAds();
        //CarBannerAds = [];
        //CarBannerAdsDisplay(CarBannerAds);
        
        GetCarsAds();
        GetMakes();
        GetModelsInfo();                  
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
            $('#content').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('.button1');
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
        //alert($('body').width());
	KeyListener.init();        
        $('#make, #model').attr('disabled','disabled');

      
	//window.onresize = function() {cd_setWidth();}

        
    });
	$(window).resize(function(){cd_setWidth();});
	
function cd_setWidth() {
	
	try {
		
		/* var width = -1;
		if (method == "inner width") {
			width = window.innerWidth;
			height = window.innerHeight;
		} else if (method == "outer width") {
			width = window.outerWidth;
			height = window.outerHeight;
		} else if (method == "avail width") {
			width = screen.availWidth;
			height = screen.availHeight;
		} else if (method == "body client width") {
			width = document.body.clientWidth;
			height = document.body.clientHeight;
		} else if (method == "document client width") {
			width = document.documentElement.clientWidth;
			height = document.documentElement.clientHeight;
		}
		if (width == -1) {
			return;
		}
		*/
		
		width = $(document).width();
		//alert(width);
		var body = document.getElementByTagName("BODY")[0];
		var bodyDiv = body.getElementsByTagName("DIV")[0];
		body.style.width = width+"px";
		bodyDiv.style.width = width+"px";
		
		
		//change header graphic
		//var headerElement = document.getElementById("header");
		//var linkEl = headerElement.firstChild;
		//var imageEl = linkEl.firstChild;
		//imageEl.style.width = width+"px";
	} catch(err) {
		//alert("error: "+err);
	}
}


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scrptmgr" runat="server">
    </asp:ScriptManager>
    <!-- MAin Start  -->
    <div class="main">
        <!-- Logo Start -->
        <div class="logo">
            <a href="index.aspx">
                <img src="images/logo.png" alt="" /></a>
            <div class="clear">
                &nbsp;</div>
            &nbsp; Toll-free: <span>888-786-8307</span>
            <div class="clear">
                &nbsp;</div>
            <div class="strip">
                &nbsp;</div>
        </div>
        <!-- Logo End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- Content Start  -->
        <div class="content">
            <h3 class="h2">
                Search <strong>USED CARS</strong></h3>
            <select id="make" class="input1 ">
                <option>Choose Make</option>
                <option>All makes</option>
            </select>
            <select id="model" class="input1 ">
                <option>Choose Model</option>
                <option>All models</option>
            </select>
            <select id="within" class="input1" style="float: left; width: 160px; margin-right: 6px; display:none;" >
                <option>Choose Distance</option>
                <option>10 miles</option>
                <option>25 miles</option>
                <option >50 miles</option>
                <option selected="selected">100 miles</option>
                <option>Anywhere</option>
            </select>
            <table style="width: 96px; float: left;" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 30px; text-align: center; font-size: 13px; color: #666; font-weight: bold">
                        ZIP
                    </td>
                    
                    <td >
                        <input type="text" value="ZIP" id="yourZip" class="input1" style="width: 50px;" />
                    </td>
                </tr>
            </table>
            <div class="clear">&nbsp;</div>
            <input type="button" value="Search" class="button1" onclick="search();" />
            <br />
            <br />
            <br />
            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- Content End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- MAin End  -->
    <div class="clear">
        &nbsp;</div>
    <!-- Home ADS Atsrt -->
    <div class="homeAds">

        <script type="text/javascript"><!--
google_ad_client = "ca-pub-7372260920181787";
/* MobileHome */
google_ad_slot = "3132050414";
google_ad_width = 320;
google_ad_height = 50;
//-->
        </script>

        <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>
        <div class="clear">&nbsp;</div>
    </div>
    <!-- Home ADS end  -->
    <div class="clear">
        &nbsp;</div>
    <!-- Footer Start -->
    <div class="footer">
        <a href="index.aspx">Home</a> | <a href="aboutUs.html">About Us</a> | <a href="contactUs.html">
            Contact Us</a> <!-- | <a href="sellmycar.aspx">Sell My car</a>  -->
        <div class="copyRight">
            &copy; 2012 United Car Exchange</div>
    </div>
    <!-- Footer End  -->
    </form>
</body>
</html>
