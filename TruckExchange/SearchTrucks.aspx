<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTrucks.aspx.cs" Inherits="SearchCars" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>.:United Truck Exchange:.</title>
    <!-- 
<link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet' type='text/css'>
-->
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/searchBlock.css" rel="stylesheet" type="text/css" />
    <link href="css/PaginationStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/gallery.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script src="js/usPhone.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/galleria-1.2.7.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>
    
     <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->
    <!-- 
<script src="js/FillMasterData.js" type="text/javascript"></script>
<script src="js/Filter.js" type="text/javascript"></script>
-->

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script type="text/javascript">
    within = ['100','250','Anywhere'];
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
   
    var VehicleType1 = 'Any Type'
    var category1='Any Category' ;
    var make1='Any Make' ;
    var Modal1='Any Model';
    var ZipCode1='' ;
    var WithinZipNew=1 ; 
    var VehicleType=[]; 
        var categoty=[];
        var make = [];
        var models = [];     
            
    function pageLoad() { 
        GetVehicleType();
        //GetCarsAds();  ------------>
        
        //GetVehicleType();
        
      
       
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
            if(urlVars["Make"]){
                make1 = urlVars["Make"].replace('%20',' ');
                make1 = make1.replace('%20',' ');
            }
            if(urlVars["Model"]){
                Modal1 = urlVars["Model"].replace('%20',' ');
                Modal1 = Modal1.replace('%20',' ');
                Modal1 = Modal1.replace('%20',' ');
            }
            if(urlVars["ZipCode"]){
                ZipCode1 = urlVars["ZipCode"];
            }            
            
            if(urlVars["WithinZip"]){
                WithinZipNew = urlVars["WithinZip"].replace('%20',' '); 
                 if(WithinZipNew.charAt(0)=='#'){
                    WithinZipNew = WithinZipNew.replace('#','');  
                }   
            }
           // console.log(WithinZipNew);
            $('#yourZip').val(ZipCode1);
            
            $('#within option').each(function () {
                $(this).removeAttr('selected');
            });
            $('#within option[value=' + WithinZipNew + ']').attr('selected', 'selected');

             if(urlVars["VehicleType"]){
                VehicleType1 = urlVars["VehicleType"].replace('%20',' ');
                VehicleType1 = VehicleType1.replace('%20',' ');
                VehicleType1 = VehicleType1.replace('%20',' ');
                VehicleType1 = VehicleType1.replace('%20',' ');
                VehicleType1 = VehicleType1.replace('%20',' ');
                VehicleType1 = VehicleType1.replace('%20',' ');
                VehicleType1 = VehicleType1.replace('%20',' '); 
                VehicleType1 = VehicleType1.replace('#','')                 
            }       
            if(VehicleType1 == null || VehicleType1 == 'undefined' || VehicleType1 == '' || VehicleType1 == ' '){
                VehicleType1= 'Any Type'
            }
            
            if(urlVars["Category"]){
                category1 = urlVars["Category"].replace('%20',' '); 
                category1 = category1.replace('%20',' '); 
                category1 = category1.replace('%20',' '); 
                category1 = category1.replace('%20',' '); 
                category1 = category1.replace('%20',' '); 
                category1 = category1.replace('%20',' '); 
                category1 = category1.replace('%20',' '); 
                category1 = category1.replace('#','')               
            }
            if(category1 == null || category1 == 'undefined' || category1 == '' || category1 == ' '){
                category1= 'Any Category'
            }
                        
            if(make1 == null || make1 == 'undefined' || make1 == '' || make1 == ' '){
                make1= 'Any Make'
            }
            if(Modal1 == null || Modal1 == 'undefined' || Modal1 == '' || Modal1 == ' '){
                Modal1= 'Any Model'
            }
            if(WithinZipNew == null || WithinZipNew == 'undefined' || WithinZipNew == '' || WithinZipNew == ' '){
                WithinZipNew= 4;
            }
            
            if(ZipCode1 == null || ZipCode1 == 'undefined' || ZipCode1 == '' || ZipCode1 == ' '){
                alert('Enter your ZIP');
            }else{
               //console.log(make1+', Any Model, '+ ZipCode1, WithinZipNew+', 1,'+ ' 25, Price, '+ VehicleType1, category1);
               CarsSearch2(make1, 'Any Model', ZipCode1, WithinZipNew,'1', '25', 'Price', VehicleType1, category1);
            }
            
                    
            
            
            
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
    
      KeyListener = {
        init : function() {
            $('#searchFormHolder').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('.form-1-submit');
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
            
           
    
    // CarsSearch2(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby)
    </script>

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
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px;"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 253px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <!-- Search Filter Start -->
                    <div class="indent">
                    <div class="info-box">
                                        <div class="wrapper leftSearch" style="background:url(images/homepage_search_back.png) center bottom no-repeat; width:95%; padding:0 10px 37px 10px; margin:0 0 0 -5px;">
                                            <h2 style="text-align:center; color:#fff"><span style="font-weight:normal; color:#333;">QUICK</span> SEARCH</h2>
                                            <div id="searchFormHolder" style=" width:103%; margin: 0 auto; padding:0">
                                                <div class="width-1" style="width: 98%;">
                                                    
                                                       <b>Type</b>
                                                    <select id="vehicleType" runat="server" disabled="disabled" style=" padding:2px 1px;">
                                                        <option>Loading...</option>
                                                    </select>
                                                    <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                    <b>Category</b>
                                                    <select id="categoty" runat="server"  disabled="disabled" style=" padding:2px 1px;">
                                                        <option>Loading...</option>
                                                    </select>
                                                    
                                                    <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                    <b>Make</b>
                                                    <select name="select" id="make" runat="server"  disabled="disabled" style=" padding:2px 1px;">
                                                        <option value="0">Loading...</option>
                                                    </select>
                                                    
                                                    <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                    <b>Model</b>
                                                    <select name="select" id="model" runat="server" disabled="disabled" style=" padding:2px 1px;">
                                                        <option value="0">Loading...</option>
                                                    </select>
                                                </div>
                                                <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                <div class="width-1" style="width: 52%">
                                                    <b>Within</b><br />
                                                    <select id="within" runat="server" disabled="disabled" style="width: 98%; padding:2px 1px;">
                                                    </select>
                                                </div>
                                                <div class="width-1" style="width: 40%">
                                                    <b>ZIP</b><br />
                                                    <input type="text" id="yourZip" maxlength="5" runat="server" disabled="disabled"
                                                        class="zip sample4" style="width: 88%; padding:1px;" />
                                                </div>
                                                <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                <div style=" margin-left: -1px; float: left; width: 66px;">
                                                    <a href="javascript:search();" class="button" id="form-1-submit" style="margin: 3px 0 0 3px">
                                                        Search</a>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clear" style="margin-bottom:10px; padding:10px; border-bottom:#ccc 1px solid;">&nbsp;</div>
                                    
                                    
                        <div class="wrapper">
                            <h2 style="margin-bottom: 10px; padding-bottom: 10px; color: #555; font-size: 16px;">
                                Filter Your Search</h2>
                            <div class="clear">
                                &nbsp;</div>
                            <!--  -->
                            <div class="basic" style="float: left;" id="Filter">
                                <!-- Mileage  -->
                                <div class="hed hh1">
                                    <!-- onclick="javascript:choice(event,'Mileage')"  
                                    <input type="checkbox" /> -->
                                    <a>Mileage</a>
                                    <div class="open ">
                                    </div>
                                </div>
                                <div id="choiceMileage">
                                    <ul>
                                        <li>
                                            <input type="checkbox" id="m1" />
                                            0-5000 miles</li>
                                        <li>
                                            <input type="checkbox" id="m2" />
                                            5000-10000 miles</li>
                                        <li>
                                            <input type="checkbox" id="m3" />
                                            10000-25000 miles</li>
                                        <li>
                                            <input type="checkbox" id="m4" />
                                            25000-50000 miles</li>
                                        <li>
                                            <input type="checkbox" id="m5" />
                                            50000-75000 miles</li>
                                        <li>
                                            <input type="checkbox" id="m6" />
                                            75000-100000 miles</li>
                                        <li>
                                            <input type="checkbox" id="m7" />
                                            100000+ miles</li>
                                    </ul>
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                                <!-- Select By Year  -->
                                <div class="hed hh2">
                                    <!-- onclick="javascript:choice(event,'Year')" 
                                    <input type="checkbox" />  -->
                                    <a>Year</a>
                                    <div class="open ">
                                    </div>
                                </div>
                                <div id="choiceYear">
                                    <ul>
                                        <li>
                                            <input type="checkbox" />
                                            2013</li>
                                        <li>
                                            <input type="checkbox" />
                                            2012</li>
                                        <li>
                                            <input type="checkbox" />
                                            2011</li>
                                        <li>
                                            <input type="checkbox" />
                                            2010</li>
                                        <li>
                                            <input type="checkbox" />
                                            2009</li>
                                        <li>
                                            <input type="checkbox" />
                                            2008</li>
                                        <li>
                                            <input type="checkbox" />
                                            2007</li>
                                        <li>
                                            <input type="checkbox" />
                                            2002-2006</li>
                                        <li>
                                            <input type="checkbox" />
                                            Older than 2002</li>
                                    </ul>
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                                <!-- Select By Price  -->
                                <div class="hed hh3">
                                    <!-- onclick="javascript:choice(event,'Price')" 
                                    <input type="checkbox" /> -->
                                    <a>Price</a>
                                    <div class="open ">
                                    </div>
                                </div>
                                <div id="choicePrice">
                                    <ul>
                                        <li>
                                            <input type="checkbox" />
                                            Below 20,000</li>
                                        <li>
                                            <input type="checkbox" />
                                            20,000 to 50,000</li>
                                        <li>
                                            <input type="checkbox" />
                                            50,000 to 75,000</li>
                                        <li>
                                            <input type="checkbox" />
                                            75,000 to 100,000</li>
                                        <li>
                                            <input type="checkbox" />
                                            Above 100,000</li>
                                    </ul>
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                                <!-- Seller type  -->
                                <div class="hed hh6">
                                    <!-- onclick="javascript:choice(event,'Seller')"  
                                    <input type="checkbox" /> -->
                                    <a>Seller type</a>
                                    <div class="open ">
                                    </div>
                                </div>
                                <div id="choiceSeller">
                                    <ul>
                                        <li>
                                            <input type="checkbox" />
                                            Individual sellers</li>
                                        <li>
                                            <input type="checkbox" />
                                            Dealers</li>
                                    </ul>
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                            </div>
                            <!-- -->
                            <div class="clear H20">
                            </div>
                            <!-- Left Brand Ads Satrt -->
                            <div class="left-ad-google" style="border: #fff 1px solid; padding: 6px;">
                                <div class="clear">
                                    &nbsp;</div>
                            </div>
                            <!-- Left Brand Ads Satrt -->
                            <div class="clear">
                                &nbsp;</div>
                        </div>
                    </div>
                    <!-- Search Filter Start -->
                </td>
                <td style="vertical-align: top;">
                    <!-- Right Content Start  -->
                    <table style="width: 99%; border-collapse: collapse; margin: 0 auto;">
                        <tr>
                            <td style="vertical-align: top;">
                                <div class="wrapper">
                                    <!--  -->
                                    
                                    <div class="wrapper">
                                        <div style="width: 100%; padding: 0 10px;">
                                            <ul class="list-2">
                                            </ul>
                                        </div>
                                        <div style="width: 99%; margin: 0 auto">
                                            <div id="PaginationBlock">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 190px;">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <strong style="padding-top: 3px; display:inline-block; width:45px;">Sort by:</strong>
                                                                    </td>
                                                                    <td>
                                                                        <select id="filterSortBy">
                                                                            <option value="0">Select sort</option>
                                                                            <option value="1">Price low to high</option>
                                                                            <option value="2">Price high to low</option>
                                                                            <option value="3">Year old to new</option>
                                                                            <option value="4">Year new to old</option>
                                                                            <option value="5">Mileage low to high</option>
                                                                            <option value="6">Mileage high to low</option>
                                                                        </select>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td align="right" style="width: 175px;">
                                                            <div class="paginationHolder">
                                                                <table style="padding-left: 10px;">
                                                                    <tr>
                                                                        <td>
                                                                            <strong>Per Page:</strong>
                                                                        </td>
                                                                        <td>
                                                                            <select id="resultsPerPage" style="width: 55px; padding: 4px 2px;">
                                                                                <option value="25">25</option>
                                                                                <option value="50">50</option>
                                                                                <option value="75">75</option>
                                                                                <option value="100">100</option>
                                                                            </select>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                        <td style="text-align: left; width: 280px;">
                                                            <div class="rightArrow">
                                                                <div class="rightAct">
                                                                </div>
                                                            </div>
                                                            <div class="leftArrow">
                                                                <div class="leftDis">
                                                                </div>
                                                            </div>
                                                            <div class="resFound">
                                                                <strong>Results: </strong>
                                                                <label id="totalResultsFound">
                                                                    Loading...</label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <!-- Search Results Blocks Start  -->
                                            <div class="searchResultsHolder">
                                            </div>
                                            <!-- Search Results Blocks End  -->
                                            <div class="clear">
                                                &nbsp;</div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td style="width: 120px; vertical-align: top; overflow: hidden">
                                <div class="ad120-600" style="padding: 6px;">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: top;">
                                <div class="bottomAdd " id="add730" style="width: 730px; margin: 10px 0; font-size: 11px;">
                                </div>
                            </td>
                        </tr>
                    </table>
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
    <!-- Gallery Start -->
    <div class="galleryHolder">
        <div class="gallery1">
            <table style="width: 100%">
                <tr>
                    <td colspan="2" valign="top">
                        <h2>
                            2011 Mercedes-Benz SLS AMG - <span>$229,900</span><a href="#" class="galClose">&nbsp;</a></h2>
                    </td>
                </tr>
                <tr>
                    <td class="gal">
                        <!-- Slider Start  -->
                        <div id="galleria" style="width: 98%;">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/1.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/2.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/3.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/4.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/5.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/6.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/7.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/8.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/9.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/1.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/2.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/3.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/4.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/5.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/6.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/7.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/8.jpeg"
                                data-description="09-28-2001 in New York City">
                            <img src="http://unitedcarexchange.com/CollectedImages/2012/3/Mercedes-Benz/594/9.jpeg"
                                data-description="Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. Designo Mystic White 2, 2 Door, Coupe, Auto 7spd, 6.2l V8, Stock# 004643. ">
                        </div>
                        <!-- Slider End  -->
                    </td>
                    <td class="discHolder">
                        <h3>
                            Specifications</h3>
                        <label>
                            <strong>New/Used</strong>Used</label>
                        <label>
                            <strong>Year</strong>2011</label>
                        <label>
                            <strong>Make</strong>Mercedes-Benz</label>
                        <label>
                            <strong>Model</strong>SLS AMG</label>
                        <label>
                            <strong>Location</strong>Coral Gables, FL 33146</label>
                        <label>
                            <strong>Condition</strong>Good</label>
                        <label>
                            <strong>Type</strong>Coupe</label>
                        <label>
                            <strong>Category</strong>Car</label>
                        <div class="clear H20">
                            &nbsp;</div>
                        <h3>
                            Discription</h3>
                        <p class="disc">
                        </p>
                    </td>
                </tr>
            </table>
            <div class="clear">
                &nbsp;</div>
        </div>
    </div>
    <!-- Gallery End -->

    <script src="js/jquery.paginate.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
  
    
	
	
	

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
	
	var hCars = [['images/1page-img6.jpg','2009 Audi A3 and S3 Sportback',25800],
				 ['images/1page-img7.jpg','2009 Lexus GS 450h',65800],
				 ['images/1page-img8.jpg','2009 Audi TTS Coupe',45800],
				 ['images/1page-img9.jpg','2010 Honda CR-V',35800],
				 ['images/1page-img7.jpg','2009 Lexus GS 450h',65800]];
    
    var ad1 = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
	
	$(function() {
		$('a').each(function(){
			if($(this).attr('href') == '#'){
				$(this).attr('href','javascript:void(0)')
			}
		})
		$('.stockPhoto1 a').click(function(){
				$('.galleryHolder').fadeIn('fast',function(){
				// Load the classic theme
                    Galleria.loadTheme('themes/classic/galleria.classic.min.js');                    
                    // Initialize Galleria
					Galleria.configure({   
						width: ($('.gallery1').width())-320 ,                 	
						height: ($('.gallery1').height())-40 ,
						transition: "pulse",
						thumbCrop: true,
						imageCrop: true,
						carousel: true,
						imagePan: true,
						clicknext: true                   	
                    });
                   
                   $('.galleryHolder a.galClose').click(function(){
							$('.galleryHolder').fadeOut('slow');
					});	 
				  //var gal = $("#gallery1").galleria();
				  Galleria.run('#galleria', {showInfo: false,
						extend: function(options) {						
							this.bind('image', function(e) {											
								$('.disc').hide().html(e.galleriaData.description).fadeIn(); 							
							});
						}
					});

			});			
		});
		
		
		
		
		$('.sample4').numeric({allow:"-"});
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		 endNum = parseInt($('#resultsPerPage option:selected').val());
		
		//$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#make, #model, #modelA, #modelB').attr('disabled',true);
		
		$('#choiceMileage, #choiceYear, #choicePrice, #choiceBody, #choiceFuel, #choiceSeller').find('ul li input[type=checkbox]').each(function(){
		    $(this).attr('checked','checked');
		    $(this).parent().css('font-weight','bold');
		});
		$('.hh1, .hh2, .hh3, .hh4, .hh5, .hh6').find('input[type=checkbox]').each(function(){
            $(this).attr('checked','checked');
            $(this).parent().css('font-weight','bold');
		});
		
		$('#choicePhotos input:radio[name=photo]:checked').next('span').css('font-weight','bold');	
		
        
         // lBrandAds
		if(ad1.length>0){
			var img = '';
			var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		
		
		
		// Horizantal Car Ads
		/*
		if(hCars.length>0){
			var img = '';
			for(i=0;i<hCars.length;i++){
				img +=  "<li> <img src="+hCars[i][0]+" /> <strong><a href='#'>"+hCars[i][1]+"</a></strong> <b>$"+hCars[i][2]+"</b> </li>";
				
			}
			$('ul.list-2').empty();
			$('ul.list-2').append(img);
			$('ul.list-2 li').css('height','130px').css('font-size','12px');
			$('ul.list-2 li, ul.list-2 li img').css('width','126px');
			$('ul.list-2 li strong, ul.list-2 li b').css('padding','0px 5px 6px 5px').css('font-size','12px');			
			
			
		};
		*/
		
		
		/*
	    choiceMileage,choiceYear,choicePrice,choiceBody,choiceFuel,choicePhotos,choiceSeller
	    */
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
		
		
		
		
		
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}			
			// $(this).parent().toggleClass('li-hover');
		});
		
		
		
		
		
		
		$('.closeA').click(function(){
			if(makeCount>1){
				makeCount --;
				$('#addMake').show();
				$('.make1').hide();
			}else{
				makeCount = 0;
				$('#addMake').show();

				$('.addMake, .make1, .make2').hide();
			}
			
		});
		
		$('.closeB').click(function(){
			if(makeCount>1){
				makeCount --;
				$('#addMake').show();
				$('.make2').hide();
			}else{
				makeCount = 0;
				$('#addMake').show();
				$('.addMake, .make1, .make2').hide();
			}
			
		});
		
		// Jquery Pagination
		/*
		$("#demo1").paginate({
				count 		: 50,
				start 		: 5,
				display     : 10,
				border					: true,
				border_color			: '#ccc',
				text_color  			: '#888',
				background_color    	: '#EEE',	
				text_hover_color  		: '#000',
				border_hover_color		: '#ff9900',
				background_hover_color	: '#ffc72a'
			});
		*/
		
		
		
		/* $('div.hed div').click(function(){
		    $(this).toggleClass("close");
        });
        */
		
		
		
	});
	
	/*
	function choice(event,e){	
	
	    var tag = event.target.nodeName;
	    if(tag != 'INPUT' && tag != 'input'){   
		    $('#choice'+e).slideToggle();		
		    //$(this.div).toggleClass("close");		
		    $('#choice'+e).prev('div').children('div').toggleClass("close");
		}
       
		
    }
    */
    
    $('div.hed').click(function(event){
        if(event.target.nodeName != 'INPUT' && event.target.nodeName != 'input' ){             
            var id = $(this).next('DIV').attr('ID');
            $('#'+id).slideToggle();		
            //$(this.div).toggleClass("close");		
            $('#'+id).prev('div').children('div').toggleClass("close");
        }
    
    });
	
	
	
    </script>

    </form>
</body>
</html>
