<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCarDetails.aspx.cs"
    Inherits="Mobile_SearchCarDetails" %>

<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>United Car Exchange</title>
    <link href="css/mobile.css" rel="stylesheet" type="text/css" media="handheld,all" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
    
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


    var models;
    LoadingPage = 3;
    //var ZipCodes = [];
     var make1='All makes' ;
    var Modal1='All models';
    var ZipCode1='' ;
    var within = ['10','25','50','100','Anywhere'];
    var WithinZipNew=4 ; 
    var CarID1;
    function pageLoad() {
        GetRecentListings();
       $.extend({
        getUrlVars: function(){
          var vars = [], hash;
          var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
          for(var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
          }
          return vars;
        },
        getUrlVar: function(name){
          return $.getUrlVars()[name];
        }
      });
      
      
        var urlVars = $.getUrlVars();
        if(urlVars != null && urlVars != undefined && urlVars != ''){        
            make1 = urlVars["Make"].replace('%20',' ');
            make1 = make1.replace('%20',' ');
            Modal1 = urlVars["Model"].replace('%20',' ');
            Modal1 = Modal1.replace('%20',' ');
            Modal1 = Modal1.replace('%20',' ');
            ZipCode1 = urlVars["ZipCode"];
            WithinZipNew = urlVars["WithinZip"].replace('%20',' ');  
            WithinZipNew = WithinZipNew.replace('#','');          
            CarID1 = urlVars["C"];
            CarID1 = CarID1.substring(8);          
            FindCarID(CarID1);            
            //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');            
            //alert(WithinZip1);      
            
        }       
        GetMakes();
        GetModelsInfo();        
        WithinZipBinding();
    }
    
    </script>

    <!-- Look at the configuration -->
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
            <a href='javascript:history.go(-1)' class='back'>< back</a>
            <div class="clear">
                &nbsp;</div>
            <h3 class="h2">
            </h3>
            <!-- Results Start  -->
            <div class="details">
                <div class="profileImg">
                </div>
                <div class="prevImg">
                    &laquo; Prev</div>
                <div class="nextImg">
                    Next &raquo;</div>
                <div class="clear">
                    &nbsp;</div>
                <div class="box">
                    <h4>
                        Seller Info</h4>
                    <strong>Price: </strong><span class="price1"></span>
                    <br />
                    <strong>Seller Type: </strong><span class="SellerType"></span>
                    <br />
                    <strong>Seller Name: </strong><span class="SellerName"></span>
                    <br />
                    <strong>Phone: </strong><span class="phone phone1"></span>
                    <br />
                    <strong>Email: </strong><span class="SellerEmail"></span>
                    <br />
                    <table style="width: 100%;" cellpadding='0' cellspacing='0'>
                        <tr>
                            <td style="width: 66px; vertical-align: top">
                                <strong>Address: </strong>
                            </td>
                            <td style="vertical-align: top">
                                <span class="SellerAddress"></span><span class="SellerAddress2"></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="box">
                    <h4>
                        Vehicle Description</h4>
                    <div class="vehicalDisc">
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                </div>
                <div class="box last">
                    <h4>
                        Vehicle Specifications</h4>
                    <div class="Comfort">
                    </div>
                    <div class="SellerNotes">
                    </div>
                </div>
            </div>
            <!-- Results End  -->
        </div>
        <!-- Content End  -->
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

            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- Home ADS end  -->
    </div>
    <!-- MAin End  -->
    <div class="clear">
        &nbsp;</div>
    <div class="clear">
        &nbsp;</div>
    <!-- Footer Start -->
    <div class="footer">
        <a href="index.aspx">Home</a> | <a href="aboutUs.html">About Us</a> | <a href="contactUs.html">
            Contact Us</a>
        <!-- | <a href="sellmycar.aspx">Sell My car</a>  -->
        <div class="copyRight">
            &copy; 2012 United Car Exchange</div>
    </div>
    <!-- Footer End  -->
    </form>
</body>
</html>
