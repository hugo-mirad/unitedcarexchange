<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCars.aspx.cs" Inherits="SearchCars"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title></title>
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name='Description' content='Search and buy used cars. Enter your zip code and specifications like car make and model to find your favorite car to buy online' />
    <meta name='keywords' content='Used Cars, New Cars, Used Cars Online, Used Cars for Sale, New Cars for Sale, Secondhand Cars Online, Find Cars Online, Used Vehicles online, Search Used Cars, Search New Cars' />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/PaginationStyle.css" rel="stylesheet" type="text/css" />

   <!--  <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.min.js"></script>  -->
    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>
    
    <link href="css/jquery-ui.css" rel="stylesheet">
    <script type="text/javascript" src="js/jquery-ui.js"></script> 
    

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/loopedslider.js" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>
    
    
  

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->


<style>
    .infinite-container.infinite-loading:after {
      content:"Loading...";
      height:30px;
      line-height:30px;
      position:absolute;
      left:0;
      right:0;
      bottom:0;
      text-align:center;
      background:#6a6272;
      color:#eae2f2;
    }

    .infinite-item {
      float:left;
      width:100px;
      height:100px;
      background:#444a50;
      margin:20px 0 20px 20px;
    }
    .infinite-item:nth-child(3n) {
      background:#6a6272;
    }
    .infinite-item:nth-child(3n+1) {
      background:#eae2f2;
    }

    .infinite-more-link {
      visibility:hidden;
    }
</style>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script type="text/javascript">
        within = ['10', '25', '50', '100', 'Anywhere'];
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
        PAGEFIRST = 0;
        var MultiSearch = false;
        //var ZipCodes = [];

        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 4;


        function pageLoad() {
            // Onload URL Variable s reading
//            GetCarsAds();
//            GetMakes();
//            GetModelsInfo();


            $.extend({
                getUrlVars: function() {
                    var vars = [], hash;
                    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
                    for (var i = 0; i < hashes.length; i++) {
                        hash = hashes[i].split('=');
                        vars.push(hash[0]);
                        vars[hash[0]] = hash[1];
                    }
                    return vars;
                },
                getUrlVar: function(name) {
                    return $.getUrlVars()[name];
                }
            });


            var urlVars = $.getUrlVars();
            if (urlVars != null && urlVars != undefined && urlVars != '') {
                if (urlVars["Make"]) {
                    make1 = urlVars["Make"].replace('%20', ' ');
                    make1 = make1.replace('%20', ' ');
                }
                if (urlVars["Model"]) {
                    Modal1 = urlVars["Model"].replace('%20', ' ');
                    Modal1 = Modal1.replace('%20', ' ');
                    Modal1 = Modal1.replace('%20', ' ');
                }
                if (urlVars["ZipCode"]) {
                    ZipCode1 = urlVars["ZipCode"];
                }
                if (urlVars["WithinZip"]) {
                    WithinZipNew = urlVars["WithinZip"].replace('%20', ' ');
                    if (WithinZipNew.charAt(0) == '#') {
                        WithinZipNew = WithinZipNew.replace('#', '');
                    }
                }

                if (make1 == null || make1 == 'undefined' || make1 == '' || make1 == ' ') {
                    make1 = 'All makes'
                }
                if (Modal1 == null || Modal1 == 'undefined' || Modal1 == '' || Modal1 == ' ') {
                    Modal1 = 'All models'
                }
                if (WithinZipNew == null || WithinZipNew == 'undefined' || WithinZipNew == '' || WithinZipNew == ' ') {
                    WithinZipNew = 4;
                }

                if (ZipCode1 == null || ZipCode1 == 'undefined' || ZipCode1 == '' || ZipCode1 == ' ') {
                    alert('Enter your ZIP');
                } else {
                    ////console.log(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');
                    
                    //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew, '1', '25', 'Price');
                    CarsSearchSpeed(make1, Modal1, ZipCode1, WithinZipNew, '1', '25', 'Price');
                    MinandMaxSpeed(make1, Modal1, WithinZipNew, ZipCode1);
                    
                    
                }

                



                //alert(WithinZip1);       


                //FindCarID(id);
            }
            // Onload URL Variable s reading End
            GetCarsAds();
            GetMakes();
            GetModelsInfo();
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
            init: function() {
                $('#searchFormHolder').bind('keypress', function(e) {
                    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                    var target = e.target.tagName.toLowerCase();
                    if (key === 13 && target === 'input') {
                        e.preventDefault();
                        var button = $('.form-1-submit');
                        if (button.length > 0) {
                            if (typeof (button.get(0).onclick) == 'function') {
                                button.trigger('click');
                            } else if (button.attr('href')) {
                                window.location = button.attr('href');
                            } else {
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

    var Mileage1 ;    
    var Mileage2 ;
    var Year1a ;
    var Year1b;
    var Price1;
    var Price2;
       
        
   var rangeSliderVar = true;
   
   
   
   
      

        // CarsSearch2(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby)
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
                        <img src="images/logo2.png" alt="" name="logo" id="logo" /></a>
                    <div class="loginStat">
                        <%-- <a href="login.aspx" class="login">Login</a>--%>
                        <uc2:LoginName ID="LoginName1" runat="server" />
                    </div>
                    <div id="menu" style="right: 140px; width: 560px">
                        <ul>
                            <li><a href="http://UnitedCarExchange.com">Home</a></li>
                            <li><a href="Usedcars.aspx">Used Cars</a></li>
                            <li><a href="NewCars.aspx">New Cars</a></li>
                            <li class="last"><a href="Packages.aspx">Sell A Car</a>
                                <ul>
                                    <li><a href="Packages.aspx">Private Seller</a></li>
                                    <li><a href="Dealer.aspx">Dealer</a></li>
                                </ul>
                            </li>
                            <!-- <li class="last"><a href="comingsoon.aspx">Tools</a></li>  -->
                        </ul>
                    </div>
                </div>
                <!-- content -->
                <div id="content" style="background: #E0E0E0;">
                    <div class="wrapper-1">
                        <div id="column-left" style="width: 200px; background: #EEE; overflow: visible">
                            <div class="indent" style="overflow: visible">
                                <div class="wrapper" style="overflow: visible">
                                    <h2 style="margin-bottom: 0; padding-bottom: 0; color: #555; font-size: 23px;">
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
                                         <div style="margin:10px 0 20px 0; width:190px">                                                    
                                                <label  class="Mileage" style="border: 0; font-weight:bold " >
                                                    <span class="min"></span><span class="max"></span>
                                                </label>   
                                                <div class="slider-Mileage" style="width:170px; margin:10px auto;"></div>
                                            </div>
                                       <%--     <ul>
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
                                            </ul>--%>
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
                                        
                                          <%--  <ul>
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
                                            </ul>--%>
                                            <div style="margin:10px 0 20px 0; width:190px">                                                
                                            <label  class="Year" style="border: 0; font-weight:bold" ></label>   
                                            <div class="slider-Year" style="width:170px; margin:10px auto;"></div>
                                        </div>
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
                                       <%--     <ul>
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
                                            </ul>--%>
                                              <div style="margin:10px 0 20px 0; width:190px">                                              
                                            <label  class="amount" style="border: 0; font-weight:bold" >
                                                <span class="min"></span><span class="max"></span>
                                            </label>   
                                            <div class="slider-range" style="width:170px; margin:10px auto;"></div>
                                        </div>
                                            <div class="clear">
                                                &nbsp;</div>
                                        </div>
                                        <!-- Body Type  -->
                                        <div class="hed hh4">
                                            <!-- onclick="javascript:choice(event,'Body')"
                                            <input type="checkbox" />  -->
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
                                            <!--  <input type="checkbox" />
                                           onclick="javascript:choice(event,'Fuel')" -->
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
                                            <!-- onclick="javascript:choice(event,'Seller')" 
                                            <input type="checkbox" />  -->
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
                                    <div class="clear">
                                    </div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div class="left-ad-google">
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
                                            try { var AdBrite_Iframe = window.top != window.self ? 2 : 1; var AdBrite_Referrer = document.referrer == '' ? document.location : document.referrer; AdBrite_Referrer = encodeURIComponent(AdBrite_Referrer); } catch (e) { var AdBrite_Iframe = ''; var AdBrite_Referrer = ''; }
                                            document.write(String.fromCharCode(60, 83, 67, 82, 73, 80, 84)); document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr=' + AdBrite_Iframe + '&ref=' + AdBrite_Referrer + '" type="text/javascript">'); document.write(String.fromCharCode(60, 47, 83, 67, 82, 73, 80, 84, 62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                        <div class="clear">
                                            &nbsp;</div>
                                    </div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                            </div>
                        </div>
                        <div id="column-right" class="column-indent" style="width: 800px; height: auto; background: #E0E0E0">
                            <div style="width: 660px; float: left; margin-right: 8px; background: #fff">
                                <div class="indent">
                                    <div class="wrapper">
                                        <!--  -->
                                        <div class="info-box" style="padding: 0">
                                            <div class="wrapper">
                                                <div id="searchFormHolder" style="width: 99%; margin: 0 auto; padding: 10px 5px;
                                                    background: #e7e7e7;">
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
                                                    <div style="margin-top: 27px; margin-left: 4px; float: left; width: 80px;">
                                                        <a href="javascript:newSearch();">
                                                            <img src="images/searChButton.png" alt="" style="border: 1px solid #fff; border-bottom: #999 1px solid;
                                                                border-right: #999 1px solid" tabindex="5" />
                                                        </a>
                                                        <input type="button" class="form-1-submit" onclick="newSearch();" value="Search"
                                                            style="display: none" />
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                    <!-- 
                                                    <h4 style="float: right; width: 125px; text-align: right; margin: 5px 0px 10px 0;">
                                                        <a href="#" id="addMake">Add another make</a>&nbsp;</h4>
                                                        -->
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                    <!-- Add Make Div Start  -->
                                                    <div class="addMake">
                                                        <div class="make1">
                                                            <div class="width-1">
                                                                <select id="makeA" tabindex="6">
                                                                    <option>Loading...</option>
                                                                </select>
                                                            </div>
                                                            <div class="width-1" style="width: 210px;">
                                                                <select id="modelA" style="width: 210px;" tabindex="7">
                                                                    <option>Any Model</option>
                                                                </select>
                                                            </div>
                                                            <div class="width-1" style="width: 60px; text-align: left; margin-left: 10px; margin-right: 0;">
                                                                <h4>
                                                                    <a href="#" class="close closeA" tabindex="8">Close X</a></h4>
                                                            </div>
                                                            <div class="clear" style="height: 8px;">
                                                                &nbsp;
                                                            </div>
                                                        </div>
                                                        <div class="make2">
                                                            <div class="width-1">
                                                                <select id="makeB" tabindex="9">
                                                                    <option>Loading...</option>
                                                                </select>
                                                            </div>
                                                            <div class="width-1" style="width: 210px;">
                                                                <select id="modelB" style="width: 210px;" tabindex="10">
                                                                    <option>Loading...</option>
                                                                </select>
                                                            </div>
                                                            <div class="width-1" style="width: 60px; text-align: left; margin-left: 10px; margin-right: 0;">
                                                                <h4>
                                                                    <a href="#" class="close closeB" tabindex="11">Close X</a></h4>
                                                            </div>
                                                        </div>
                                                        <div class="clear">
                                                        </div>
                                                    </div>
                                                    <!-- Add Make Div End  -->
                                                    <div class="clear">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- -->
                                    </div>
                                </div>
                                <!-- Results Start -->
                                <div class="wrapper">
                                    <div style="width: 99%; padding: 0 10px;">
                                        <ul class="list-2">
                                        </ul>
                                    </div>
                                    <div style="width: 97%; margin: 0 auto">
                                        <div id="PaginationBlock">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 190px;">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <strong style="padding-top: 3px;">Sort by:</strong>
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
                                                    <td align="right" style="width: 175px; display: none">
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
                                                        <div class="rightArrow" style="display: none">
                                                            <div class="rightAct">
                                                            </div>
                                                        </div>
                                                        <div class="leftArrow" style="display: none">
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
                                        <%--<!-- Search Results Blocks Start  -->
                                        <div class="searchResultsHolder">
                                        </div>
                                        <!-- Search Results Blocks End  -->--%>
                                        <!-- Search Results Blocks Start  -->
                                        <div class="searchResultsHolder infinite-container">
                                        </div>
                                        <div class="resultsLoading" style="display: none; padding: 10px; height: 10px; background: #fcf7ed url(images/svwloader.gif) center center no-repeat;
                                            border: #FFDAA3 1px solid;">
                                            &nbsp;
                                        </div>
                                        <a href="." class="infinite-more-link">More</a>
                                        <!-- Search Results Blocks End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                    </div>
                                </div>
                                <!-- Results End -->
                            </div>
                            <div style="width: 130px; float: right; height: 100%; background: #E0E0E0">
                                <div id="div120X600" runat="server" class="ad120-600" style="height:450px;">
                                </div>
                                <br />
                            
                                <div style="width: 99%; padding: 0 0 10px 0; display:none;" class="mostMatchedDiv" >
                                        <h2 style="font-size:22px; margin:0; padding:0;" >Similar Cars</h2>
                                        <ul class="list-1 matched">
                                        </ul>
                                    </div>
                            </div>
                            <div class="clear">
                                &nbsp;</div>
                           
                            <div class="clear">
                                &nbsp;</div>
                        </div>
                        <div class="clear">
                            &nbsp;</div>
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
                Applying your filter
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script src="js/jquery.paginate.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">






        var filterMileage = [['Mileage1', '0-5000'],
					        ['Mileage2', '5000-10000'],
					        ['Mileage3', '10000-25000'],
					        ['Mileage4', '25000-50000'],
					        ['Mileage5', '50000-75000'],
					        ['Mileage6', '75000-100000'],
					        ['Mileage7', '100000']
					        ];

        var filterYear = [['Year1a', '2013'],
                        ['Year1b', '2012'],
                        ['Year1', '2011'],
				        ['Year2', '2010'],
				        ['Year3', '2009'],
				        ['Year4', '2008'],
				        ['Year5', '2007'],
				        ['Year6', '2002-2006'],
				        ['Year7', 'Older than 2002']
				        ];

        var filterPrice = [['Price1', '20,000'],
				        ['Price2', '20,000 to 50,000'],
				        ['Price3', '50,000 to 75,000'],
				        ['Price4', '75,000 to 100,000'],
				        ['Price5', 'Above 100,000']
				        ];

        var filterBody = [['Body1', 'Convertible'],
				        ['Body2', 'Coupe'],
				        ['Body3', 'Hatchback'],
				        ['Body4', 'Sedan'],
				        ['Body5', 'SUV'],
				        ['Body6', 'Truck'],
				        ['Body7', 'Van/Minivan'],
				        ['Body8', 'Wagon'],
				        ['Body9', 'Other']
				        ];

        var filterFuel = [['Fuel1', 'Diesel'],
				        ['Fuel2', 'Petrol'],
				        ['Fuel3', 'Hybrid'],
				        ['Fuel4', 'Electric'],
				        ['Fuel5', 'Other']
			        ];

        var filterPhotos = [['Photos1', 'Available'],
				        ['Photos2', 'Do not care']
				        ];

        var filterSeller = [['Seller1', 'Individual sellers'],
				        ['Seller2', 'Dealers']
				        ];

        var hCars = [['images/1page-img6.jpg', '2009 Audi A3 and S3 Sportback', 25800],
				 ['images/1page-img7.jpg', '2009 Lexus GS 450h', 65800],
				 ['images/1page-img8.jpg', '2009 Audi TTS Coupe', 45800],
				 ['images/1page-img9.jpg', '2010 Honda CR-V', 35800],
				 ['images/1page-img7.jpg', '2009 Lexus GS 450h', 65800]];

        var ad1 = ['images/ads/ads-l1.jpg', 'images/ads/ads-l2.jpg', 'images/ads/ads-l3.jpg'];

        $(function() {




            /*
            choiceMileage,choiceYear,choicePrice,choiceBody,choiceFuel,choicePhotos,choiceSeller
            */
            for (i = 0; i < filterMileage.length; i++) {
                $('#choiceMileage ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterMileage[i][0]);
            }

            for (i = 0; i < filterYear.length; i++) {
                $('#choiceYear ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterYear[i][0]);
            }

            for (i = 0; i < filterPrice.length; i++) {
                $('#choicePrice ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterPrice[i][0]);
            }

            for (i = 0; i < filterBody.length; i++) {
                $('#choiceBody ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterBody[i][0]);
            }

            for (i = 0; i < filterFuel.length; i++) {
                $('#choiceFuel ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterFuel[i][0]);
            }

            for (i = 0; i < filterPhotos.length; i++) {
                $('#choicePhotos ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterPhotos[i][0]);
            }

            for (i = 0; i < filterSeller.length; i++) {
                $('#choiceSeller ul li:nth-child(' + (i + 1) + ') input[type=checkbox]').attr('id', filterSeller[i][0]);
            }

            $('.sample4').numeric({ allow: "-" });
            //$('.sample5').numeric({allow:"."});
            //$('.sample1').alphanumeric();	
            endNum = parseInt($('#resultsPerPage option:selected').val());

            //$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
            $('#yourZip, #yourZipA, #yourZipB').val('');

            $('#make, #model, #modelA, #modelB').attr('disabled', true);

            $('#choiceMileage, #choiceYear, #choicePrice, #choiceBody, #choiceFuel, #choiceSeller').find('ul li input[type=checkbox]').each(function() {
                $(this).attr('checked', 'checked');
                $(this).parent().css('font-weight', 'bold');
            });
            $('.hh1, .hh2, .hh3, .hh4, .hh5, .hh6').find('input[type=checkbox]').each(function() {
                $(this).attr('checked', 'checked');
                $(this).parent().css('font-weight', 'bold');
            });

            $('#choicePhotos input:radio[name=photo]:checked').next('span').css('font-weight', 'bold');


            // lBrandAds
            if (ad1.length > 0) {
                var img = '';
                var imgPath = ad1[Math.floor(Math.random() * ad1.length)];
                img += "<img src='" + imgPath + "' width='180' />";
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









            $("li input[type=checkbox]").click(function() {

                if ($(this).is(':checked')) {
                    $(this).parent().css('font-weight', 'bold');
                } else {
                    $(this).parent().css('color', '#333').css('font-weight', 'normal');
                }
                // $(this).parent().toggleClass('li-hover');
            });


            var makeCount = 0;
            $('#addMake').click(function() {
                $('.addMake').show();

                makeCount++;
                if (makeCount == 1) {

                    $('.make1').show(); $('#modelA').empty(); $('#modelA').attr('disabled', true);
                    $('.make2').hide(); $('#modelB').empty(); $('#modelB').attr('disabled', true);

                    // MakeA Dropdown
                    if (make.length > 0) {
                        var mm = '';
                        mm += "<option value='0'>Select make</option>";
                        for (i = 0; i < make.length; i++) {
                            mm += "<option value=" + make[i]["MakeID"] + ">" + make[i]["Make"] + "</option>"
                        }
                        $('#makeA').empty();
                        $('#makeA').append(mm);
                    }

                    // ModelsA Dropdown 
                    ////////////
                    $('#makeA').live('change keypress', function() {
                        if (models.length > 0) {
                            $('#modelA').removeAttr('disabled');
                            var id = $('#makeA option:selected').val();
                            //alert(id);
                            var mm = '';
                            var count = 0;
                            mm += "<option value='0'>All models</option>";
                            for (i = 0; i < models.length; i++) {
                                if (id == models[i]["MakeID"]['#text']) {
                                    mm += "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
                                    count++;
                                }
                            }
                            $('#modelA').empty();
                            if (count > 0) {
                                $('#modelA').append(mm);
                            }
                        } else {
                            var mm = '';
                            mm += "<option value='0'>All models</option>";
                            $('#modelA').empty();
                            $('#modelA').append(mm);
                            $('#modelA').attr('disabled', true);

                        }

                    });



                } else if (makeCount == 2) {
                    $('#addMake').hide();
                    if ($('.make2').css('display') == 'none') {
                        $('.make1, .make2').show(); $('#modelB').empty(); $('#modelB').attr('disabled', true);
                        // MakeB Dropdown
                        if (make.length > 0) {
                            var mm = '';
                            mm += "<option value='Select make'>Select make</option>";
                            for (i = 0; i < make.length; i++) {
                                mm += "<option value=" + make[i]["MakeID"] + ">" + make[i]["Make"] + "</option>"
                            }
                            $('#makeB').empty();
                            $('#makeB').append(mm);
                        }

                        // ModelsB Dropdown 										        
                        /////////////////////
                        $('#makeB').live('change keypress', function() {
                            if (models.length > 0) {
                                $('#modelB').removeAttr('disabled');
                                var id = $('#makeB option:selected').val();
                                //alert(id);
                                var mm = '';
                                var count = 0;
                                mm += "<option value='0'>All models</option>";
                                for (i = 0; i < models.length; i++) {
                                    if (id == models[i]["MakeID"]['#text']) {
                                        mm += "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
                                        count++;
                                    }
                                }
                                $('#modelB').empty();
                                if (count > 0) {
                                    $('#modelB').append(mm);
                                }
                            } else {
                                var mm = '';
                                mm += "<option value='0'>All models</option>";
                                $('#modelB').empty();
                                $('#modelB').append(mm);
                                $('#modelB').attr('disabled', true);

                            }

                        });


                    } else if ($('.make1').css('display') == 'none') {
                        $('.make1, .make2').show(); $('#modelA').empty(); $('#modelA').attr('disabled', true);
                        // MakeB Dropdown
                        if (make.length > 0) {
                            var mm = '';
                            mm += "<option value='Select make'>Select make</option>";
                            for (i = 0; i < make.length; i++) {
                                mm += "<option value=" + make[i]["MakeID"] + ">" + make[i]["Make"] + "</option>"
                            }
                            $('#makeA').empty();
                            $('#makeA').append(mm);
                        }

                        // ModelsB Dropdown 
                        /////////////////////
                        $('#makeB').live('change keypress', function() {
                            if (models.length > 0) {
                                $('#modelB').removeAttr('disabled');
                                var id = $('#makeB option:selected').val();
                                //alert(id);
                                var mm = '';
                                var count = 0;
                                mm += "<option value='0'>All models</option>";
                                for (i = 0; i < models.length; i++) {
                                    if (id == models[i]["MakeID"]['#text']) {
                                        mm += "<option value=" + models[i]["MakeModelID"]['#text'] + ">" + models[i]["Model"]['#text'] + "</option>";
                                        count++;
                                    }
                                }
                                $('#modelB').empty();
                                if (count > 0) {
                                    $('#modelB').append(mm);
                                }
                            } else {
                                var mm = '';
                                mm += "<option value='0'>All models</option>";
                                $('#modelB').empty();
                                $('#modelB').append(mm);
                                $('#modelB').attr('disabled', true);

                            }

                        });


                    }


                }
            });



            $('.closeA').click(function() {
                if (makeCount > 1) {
                    makeCount--;
                    $('#addMake').show();
                    $('.make1').hide();
                } else {
                    makeCount = 0;
                    $('#addMake').show();
                    $('.addMake, .make1, .make2').hide();
                }

            });

            $('.closeB').click(function() {
                if (makeCount > 1) {
                    makeCount--;
                    $('#addMake').show();
                    $('.make2').hide();
                } else {
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

        $('div.hed').click(function(event) {
            if (event.target.nodeName != 'INPUT' && event.target.nodeName != 'input') {
                var id = $(this).next('DIV').attr('ID');
                $('#' + id).slideToggle();
                //$(this.div).toggleClass("close");		
                $('#' + id).prev('div').children('div').toggleClass("close");
            }

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
