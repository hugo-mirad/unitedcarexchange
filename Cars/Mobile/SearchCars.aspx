<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCars.aspx.cs" Inherits="Mobile_SearchCars" %>

<!DOCTYPE html PUBLIC "-//WAPFORUM//DTD XHTML Mobile 1.0//EN" "http://www.wapforum.org/DTD/xhtml-mobile10.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>United Car Exchange</title>
    <link href="css/mobile.css" rel="stylesheet" type="text/css" media="handheld,all" />

    <script src="js/jquery-1.7.min.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

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


    within = ['10','25','50','100','Anywhere'];
    LoadingPage = 2;
    page = 1;
    PageResultsCount = 25;
    hideSpinner();
    startNum = 1;    
    maxPages = 0;
    totalTesults = 0;
    carDetails = [];  
    filterarryaycoutn = 0; 
    withinZipRange = 0;
    PAGEFIRST=0;
    var MultiSearch=false;
    //var ZipCodes = [];
   
    var make1='All makes' ;
    var Modal1='All models';
    var ZipCode1='' ;
    var WithinZipNew=3 ; 
            
            
    function pageLoad() { 
        // Onload URL Variable s reading
       GetCarsAds();
       GetMakes();
       GetModelsInfo(); 
       
       
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
            
            CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');
            
            //alert(WithinZip1);       
            
            
            //FindCarID(id);
        }
    // Onload URL Variable s reading End
   
        LoadingPage = 2;
        page = 1;
        PageResultsCount = 25;
        hideSpinner();
        startNum = 1;    
        maxPages = 0;
        totalTesults = 0;
        
        $('.leftArrow div').removeClass('leftAct');
        $('.leftArrow div').addClass('leftDis');
        hideSpinner();
        
        
               
        //WithinZipBinding();        
        
        ///GetCarsSearchPage();
        
      
    }


            
    
    // CarsSearch2(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby)
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager  ID="scrptmgr" runat="server">
    </asp:ScriptManager>
    <!-- MAin Start  -->
    <!-- Google Ad Start  -->
    
    <!-- Google Ad End  -->
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
            <table style="width: 100%;" cellpadding='0' cellspacing='0'>
                <tr>
                    <td>
                        <a href="index.aspx" class="back" style="float: left">< back</a>
                    </td>
                    <td>
                        <!-- Arrow start  -->
                        <div id="PaginationBlock" style="display: none">
                            <div class="rightArrow">
                                <div class="rightAct">
                                </div>
                            </div>
                            <div class="leftArrow">
                                <div class="leftDis">
                                </div>
                            </div>
                            <div class="clear">
                                &nbsp;</div>
                        </div>
                        <!-- Arrow End  -->
                    </td>
                </tr>
            </table>
            <div class="clear">
                &nbsp;</div>
            <h3 class="h2">
                Results: <strong id="totalResultsFound" style="font-size: 16px;"></strong>
            </h3>
            <select id="resultsPerPage" style="width: 55px; padding: 4px 2px; display: none;">
                <option value="25">25</option>
            </select>
            <!-- Results Start  -->
            <div class="searchResultsHolder">
            </div>
            <div id="hiddenAds3">
                <div class="frm">
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
            </div>
            <!-- Results End  -->
            <table style="width: 100%; margin-top: 15px; display: none;" id="botNav1" cellpadding='0'
                cellspacing='0'>
                <tr>
                    <td>
                        <a href="index.aspx" class="back" style="float: left">< back</a>
                    </td>
                    <td>
                        <!-- Arrow start  -->
                        <div id="Div1">
                            <div class="rightArrow">
                                <div class="rightAct">
                                </div>
                            </div>
                            <div class="leftArrow">
                                <div class="leftDis">
                                </div>
                            </div>
                            <div class="clear">
                                &nbsp;</div>
                        </div>
                        <!-- Arrow End  -->
                    </td>
                </tr>
            </table>
        </div>
        <!-- Content End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- MAin End  -->

    <script type="text/javascript">
        
           
        function onTime(){  
           $('.gAd1').each(function(){
                var br = "<br>";
                $(this).empty().append($('#hiddenAds3 .frm .adHeadline').first().html()).append(br).append($('#hiddenAds3 .frm .adText').first().html()); 
           }); 
           //$('.gAd1').empty().append($('#hiddenAds2 .frm .adHeadline').append($('#hiddenAds2 .frm .adText'));        
       }
    </script>

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
    <!-- Dummy For Filter start  -->
    <div class="wrapper" style="display: none">
        <div class="width-1" style="width: 130px;">
            <div class="black">
                Make</div>
            <select id="make" tabindex="1">
                <option>Loading...</option>
            </select>
        </div>
        <div class="width-1" style="width: 205px;">
            <div class="black">
                Model</div>
            <select id="model" style="width: 210px;" tabindex="2">
                <option>Loading...</option>
            </select>
        </div>
        <div class="width-1" style="width: 90px">
            <div class="black">
                Within</div>
            <select id="within" style="width: 95px" tabindex="3">
            </select>
        </div>
        <div class="width-1" style="width: 60px">
            <div class="black">
                ZIP</div>
            <input type="text" id="yourZip" class="zip sample4" maxlength="5" style="width: 50px"
                tabindex="4" />
        </div>
        <div class="clear">
            &nbsp;</div>
        <!--  -->
        <div class="basic" style="float: left;" id="Filter">
            <!-- Mileage  -->
            <div class="hed hh1">
                <!-- onclick="javascript:choice(event,'Mileage')"  -->
                <input type="checkbox" />
                <a>Mileage</a>
                <div class="open ">
                </div>
            </div>
            <div id="choiceMileage">
                <ul>
                    <li>
                        <input type="checkbox" id="m1" />0-5000 miles</li>
                    <li>
                        <input type="checkbox" id="m2" />5000-10000 miles</li>
                    <li>
                        <input type="checkbox" id="m3" />10000-25000 miles</li>
                    <li>
                        <input type="checkbox" id="m4" />25000-50000 miles</li>
                    <li>
                        <input type="checkbox" id="m5" />50000-75000 miles</li>
                    <li>
                        <input type="checkbox" id="m6" />75000-100000 miles</li>
                    <li>
                        <input type="checkbox" id="m7" />100000+ miles</li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- Select By Year  -->
            <div class="hed hh2">
                <!-- onclick="javascript:choice(event,'Year')"  -->
                <input type="checkbox" />
                <a>Year</a>
                <div class="open ">
                </div>
            </div>
            <div id="choiceYear">
                <ul>
                    <li>
                        <input type="checkbox" />2013</li>
                    <li>
                        <input type="checkbox" />2012</li>
                    <li>
                        <input type="checkbox" />2011</li>
                    <li>
                        <input type="checkbox" />2010</li>
                    <li>
                        <input type="checkbox" />2009</li>
                    <li>
                        <input type="checkbox" />2008</li>
                    <li>
                        <input type="checkbox" />2007</li>
                    <li>
                        <input type="checkbox" />2002-2006</li>
                    <li>
                        <input type="checkbox" />Older than 2002</li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- Select By Price  -->
            <div class="hed hh3">
                <!-- onclick="javascript:choice(event,'Price')" -->
                <input type="checkbox" />
                <a>Price</a>
                <div class="open ">
                </div>
            </div>
            <div id="choicePrice">
                <ul>
                    <li>
                        <input type="checkbox" />Below 20,000</li>
                    <li>
                        <input type="checkbox" />20,000 to 50,000</li>
                    <li>
                        <input type="checkbox" />50,000 to 75,000</li>
                    <li>
                        <input type="checkbox" />75,000 to 100,000</li>
                    <li>
                        <input type="checkbox" />Above 100,000</li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- Body Type  -->
            <div class="hed hh4">
                <!-- onclick="javascript:choice(event,'Body')" -->
                <input type="checkbox" />
                <a>Body Type</a>
                <div class="open ">
                </div>
            </div>
            <div id="choiceBody">
                <ul>
                    <li>
                        <input type="checkbox" />Convertible</li>
                    <li>
                        <input type="checkbox" />Coupe</li>
                    <li>
                        <input type="checkbox" />Hatchback</li>
                    <li>
                        <input type="checkbox" />Sedan</li>
                    <li>
                        <input type="checkbox" />SUV</li>
                    <li>
                        <input type="checkbox" />Truck</li>
                    <li>
                        <input type="checkbox" />Van/Minivan</li>
                    <li>
                        <input type="checkbox" />Wagon</li>
                    <li>
                        <input type="checkbox" />Other</li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- Fuel Type-->
            <div class="hed hh5">
                <input type="checkbox" />
                <!-- onclick="javascript:choice(event,'Fuel')" -->
                <a>Fuel Type</a>
                <div class="open ">
                </div>
            </div>
            <div id="choiceFuel">
                <ul>
                    <li>
                        <input type="checkbox" />Diesel</li>
                    <li>
                        <input type="checkbox" />Petrol</li>
                    <li>
                        <input type="checkbox" />Hybrid</li>
                    <li>
                        <input type="checkbox" />Electric</li>
                    <li>
                        <input type="checkbox" />Other</li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- Photos  -->
            <div class="hed hh0">
                <!-- onclick="javascript:choice(event,'Photos')"  -->
                <a>Photos</a>
                <div class="open ">
                </div>
            </div>
            <div id="choicePhotos">
                <ul>
                    <li>
                        <input type="radio" id='photo1' name="photo" value="1" style="margin-right: 6px;" /><span>Available</span><br />
                        <input type="radio" id='photo2' name="photo" checked="checked" value="2" style="margin-right: 6px;" /><span>Do
                            not care</span></li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <!-- Seller type  -->
            <div class="hed hh6">
                <!-- onclick="javascript:choice(event,'Seller')"  -->
                <input type="checkbox" />
                <a>Seller type</a>
                <div class="open ">
                </div>
            </div>
            <div id="choiceSeller">
                <ul>
                    <li>
                        <input type="checkbox" />Individual sellers</li>
                    <li>
                        <input type="checkbox" />Dealers</li>
                </ul>
                <div class="clear">
                    &nbsp;</div>
            </div>
        </div>
        <!-- -->
    </div>
    <!-- Dummy For Filter End  -->

    <script type="text/javascript">
    
       
		
		
    
        var filterMileage = [	['Mileage1','0-5000'],
					        ['Mileage2','5000-10000'],
					        ['Mileage3','10000-25000'],
					        ['Mileage4','25000-50000'],
					        ['Mileage5','50000-75000'],
					        ['Mileage6','75000-100000'],
					        ['Mileage7','100000']
					        ];
    				
    var filterYear = [	['Year1a','2013'],
                        ['Year1b','2012'],
                        ['Year1','2011'],
				        ['Year2','2010'],
				        ['Year3','2009'],
				        ['Year4','2008'],
				        ['Year5','2007'],
				        ['Year6','2002-2006'],
				        ['Year7','Older than 2002']
				        ];
    					
    var filterPrice = [	['Price1','20,000'],
				        ['Price2','20,000 to 50,000'],
				        ['Price3','50,000 to 75,000'],
				        ['Price4','75,000 to 100,000'],
				        ['Price5','Above 100,000']	
				        ];

    var filterBody = [	['Body1','Convertible'],
				        ['Body2','Coupe'],
				        ['Body3','Hatchback'],
				        ['Body4','Sedan'],
				        ['Body5','SUV'],
				        ['Body6','Truck'],
				        ['Body7','Van/Minivan'],
				        ['Body8','Wagon'],
				        ['Body9','Other']
				        ];
    					
    var filterFuel = [	['Fuel1','Diesel'],
				        ['Fuel2','Petrol'],
				        ['Fuel3','Hybrid'],
				        ['Fuel4','Electric'],
				        ['Fuel5','Other']					
			        ];
    				
    var filterPhotos = [['Photos1','Available'],
				        ['Photos2','Do not care']
				        ];
    					
    var filterSeller = [['Seller1','Individual sellers'],
				        ['Seller2','Dealers']
				        ];
				        
				        
    
    
    $(function(){
         endNum = 25;
				
		$('#choiceMileage, #choiceYear, #choicePrice, #choiceBody, #choiceFuel, #choiceSeller').find('ul li input[type=checkbox]').each(function(){
		    $(this).attr('checked','checked');
		    $(this).parent().css('font-weight','bold');
		});
		$('.hh1, .hh2, .hh3, .hh4, .hh5, .hh6').find('input[type=checkbox]').each(function(){
            $(this).attr('checked','checked');
            $(this).parent().css('font-weight','bold');
		});
		
		$('#choicePhotos input:radio[name=photo]:checked').next('span').css('font-weight','bold');	
    
        for(i=0;i<filterMileage.length;i++){
		    $('#choiceMileage ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterMileage[i][0]);
		}
		
		for(i=0;i<filterYear.length;i++){
		    $('#choiceYear ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterYear[i][0]);
		}
		
		for(i=0;i<filterPrice.length;i++){
		    $('#choicePrice ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterPrice[i][0]);
		}
		
		for(i=0;i<filterBody.length;i++){
		    $('#choiceBody ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterBody[i][0]);
		}
		
		for(i=0;i<filterFuel.length;i++){
		    $('#choiceFuel ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterFuel[i][0]);
		}
		
		for(i=0;i<filterPhotos.length;i++){
		    $('#choicePhotos ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterPhotos[i][0]);
		}
		
		for(i=0;i<filterSeller.length;i++){
		    $('#choiceSeller ul li:nth-child('+(i+1)+') input[type=checkbox]').attr('id',filterSeller[i][0]);
		}
    });
    
    
    </script>

    </form>
</body>
</html>
