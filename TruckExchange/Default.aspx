<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>.:United Truck Exchange:.</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/jqtransform.css" type="text/css" media="all" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/tms-0.3.x.js"></script>

    <script type="text/javascript" src="js/tms_presets.js"></script>

    <script type="text/javascript" src="js/jquery.jqtransform.js"></script>

    <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>

    <script type="text/javascript" src="js/jquery.cycle.all.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
        /* $(function(){
        $('#form').jqTransform({imgPath:'images/'});
		
		$('#slider').cycle({ 
        easing:'easeOutCubic',
        fx:      'scrollHorz',
        next: '#next_slide',
        prev: '#prev_slide',
        timeout: 0
        });

	});
	*/

        $(window).load(function() {
            $('.slider')._TMS({
                duration: 500,
                easing: 'easeInBack',
                preset: 'diagonalFade',
                pagination: false, //'.pagination',true,'<ul></ul>'	
                //pagNums:false,	
                slideshow: 5000,
                numStatus: false,
                banners: 'fromRight', // fromLeft, fromRight, fromTop, fromBottom	
                waitBannerAnimation: true
            });
        });
    </script>

    <script type="text/javascript" language="javascript">


        $(function() {

        $('.sample4').numeric();
            //$('#form').jqTransform({imgPath:'images/'});

            $('#slider').cycle({
                easing: 'easeOutCubic',
                fx: 'scrollHorz',
                next: '#next_slide',
                prev: '#prev_slide',
                timeout: 0
            });


            myFun();
            KeyListener.init();
            KeyListener2.init()
        });

        function myFun() {
            //alert('Ok')       
            if (screen.width < 500) {
                var navegador = navigator.userAgent.toLowerCase();
                if (navegador.search(/iphone|ipod|android|nok(6|i)/) > -1) {
                    document.location = "http://m.UnitedTruckExchange.com/index.aspx";
                } else {
                    document.location = "http://m.UnitedTruckExchange.com/index.aspx";
                }
            }
        }



        var models = [];
        //var ZipCodes = [];
        var SessionArray = [];
        var within = ['100', '250', 'Anywhere'];
        var MakeID1;
        var MakeIDName;
        var category1;
        var zip1;

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


        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 1;

        function pageLoad() {
            var VehicleType = [];
            var categoty = [];
            var make = [];
            var models = [];

            
            
            GetCarsAds();
            GetVehicleType();
            
            
            
            $('#txtKeyword').focus();


        }

        
        
        function KeyDownHandler(btn) {
            if (event.keyCode == 13) {
                event.returnValue = false;
                //event.cancel = true;
                //btn.click();
            }
        }


        KeyListener = {
            init: function() {
                $('#search_container').bind('keypress', function(e) {
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

        KeyListener2 = {
            init: function() {
                $('#ZipVal').bind('keypress', function(e) {
                    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                    var target = e.target.tagName.toLowerCase();
                    if (key === 13 && target === 'input') {
                        e.preventDefault();
                        var button = $('#zipValBut');
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
        <!-- Banner Start  -->
        <div class="banner">
            <!-- search_block Start  -->
            <div class="search_block">
                <div class="search_container" id="search_container">
                    <h2>
                        QUICK <span>SEARCH</span></h2>
                    <table style="width: 100%;" id="form">
                        <tr>
                            <td style="width: 90px; line-height: 33px; vertical-align: middle">
                                Type
                            </td>
                            <td>
                                <select id="vehicleType" runat="server" disabled="disabled">
                                    <option>Loading...</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td style="line-height: 33px; vertical-align: middle">
                                Category
                            </td>
                            <td>
                                <select  id="categoty" runat="server" disabled="disabled" >
                                    <option>Loading...</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td style="line-height: 33px; vertical-align: middle">
                                Make
                            </td>
                            <td>
                                <select  id="make" runat="server" disabled="disabled" >
                                    <option>Loading...</option>
                                </select>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="line-height: 33px; vertical-align: middle">
                                Model
                            </td>
                            <td>
                                <select id="model" runat="server"  disabled="disabled">
                                    <option value="0">Loading...</option>
                                </select>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="vertical-align: top; line-height: 32px;">
                                Within range
                            </td>
                            <td>
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 100px">
                                            <select name="select" id="within" runat="server" disabled="disabled">
                                                <option>100 mi</option>
                                                <option>250 mi</option>
                                                <option>Anywhere</option>
                                            </select>
                                        </td>
                                        <td style="width: 20px;">
                                            &nbsp;
                                        </td>
                                        <td>
                                            <label style="display: inline-block; line-height: 35px; height: 35px; margin: 0 5px 0 0;
                                                color: #fff; font-weight: bold" class="left  mR10">
                                                ZIP</label>
                                            <input type="text" style="width: 40px" class="left sample4" id="yourZip" maxlength="5" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="padding-top: 10px;">
                                <a href="javascript:search();" class="button" id="form-1-submit">SEARCH</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- search_block End  -->
            <!-- slider Start  -->
            <div class="slider">
                <ul class="items">
                    <li>
                        <img src="images/slides/truck1.jpg" alt="" /><span class="banner">Easy Way..!<br>
                            to sell your Trucks online</span> </li>
                    <li>
                        <img src="images/slides/truck2.jpg" alt="" /><span class="banner">Sell your Truck. Guaranteed..!</span></li>
                    <li>
                        <img src="images/slides/truck3.jpg" alt="" /><span class="banner">Get best price for
                            your Truck</span></li>
                    <li>
                        <img src="images/slides/truck4.jpg" alt="" /><span class="banner">At United Truck Exchange.<br>
                            Sell it your way..!</span> </li>
                    <li>
                        <img src="images/slides/truck5.jpg" alt="" /><span class="banner">Get best price for
                            your Truck</span></li>
                    <li>
                        <img src="images/slides/truck6.jpg" alt="" /><span class="banner">Sell your Truck. Guaranteed..!</span></li>
                </ul>
            </div>
            <!-- slider End  -->
        </div>
        <!-- Banner End  -->
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- Main End  -->
    <!-- UTE Ads Start  -->
    <div class="UTEads">
        <div class="main">
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- UTE Ads End  -->
    <!-- Content Start  -->
    <div class="main" style="padding: 25px 0;">
        <div id="content" class="column" role="main">
            <div class="section">
                <div class="region region-content">
                    <!-- /.block -->
                    <div id="block-block-6">
                        <h2>
                            <span style="font-weight: normal;font-family: arial; letter-spacing: 0;">welcome to</span> United Truck Exchange</h2>
                        <div class="content">
                            <div class="text-title">
                                Give us a chance and we will prove our efficiency!</div>
                            <div style="font-size: 12px;">
                                United Truck Exchange is the America's most trusted Online Buy & Sell Used Truck
                                agency.United Truck Exchange helps in providing an online platform where Truck buyers
                                and sellers can search, buy, sell and come together to talk about their Used/ New
                                Truck.<br />
                                <br />
                                United Truck Exchange list's detailed pricing information, description, dealer details,
                                monthly calculator tools, photo galleries and customer reviews which helps Truck
                                buyers with the information they need to make confident buying decisions.</div>
                        </div>
                        <!-- /.content -->
                    </div>
                    <!-- /.block -->
                    <div id="block-views-article-block">
                        <div class="content">
                            <div class="view view-article">
                                <div class="view-content">
                                    <div class="views-row views-row-odd views-row-first">
                                        <div class="views-field views-field-title">
                                            <h2 class="field-content">
                                                Used Trucks</h2>
                                        </div>
                                        <div class="views-field views-field-counter">
                                            <span class="field-content">1</span>
                                        </div>
                                        <div class="views-field views-field-body" style="font-size: 12px;">
                                            <span class="field-content">United Truck Exchange is the America's most trusted Online
                                                Buy & Sell Used Truck agency.United Truck Exchange helps in providing an online
                                                platform where Truck buyers and sellers can search, buy, sell and come together
                                                to talk about their Used/ New Truck.</span>
                                        </div>
                                        <div class="views-field views-field-view-node">
                                            <span class="field-content more-link"></span>
                                        </div>
                                    </div>
                                    <div class="views-row views-row-even">
                                        <div class="views-field views-field-title">
                                            <h2 class="field-content">
                                                New Trucks</h2>
                                        </div>
                                        <div class="views-field views-field-counter">
                                            <span class="field-content">2</span>
                                        </div>
                                        <div class="views-field views-field-body" style="font-size: 12px;">
                                            <span class="field-content">We also deal with "New Trucks" where people can search new
                                                Trucks available within their customized radius and specifications. United Truck
                                                Exchange provides detailed Truck information about each and every Truck make & model,
                                                pricing information, Truck description, monthly calculator tools, photo galleries
                                                and also with customer reviews which helps to take confident decisions to buy your
                                                New Truck.</span>
                                        </div>
                                        <div class="views-field views-field-view-node">
                                            <span class="field-content more-link"></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.content -->
                    </div>
                    <!-- /.block -->
                    <!-- /.block -->
                </div>
            </div>
            <!-- /.section -->
        </div>
    </div>
    <!-- Content End  -->
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
    <!-- ZIp Code POPUP  -->
    <div class="ZipVal-holder">
        <div id="ZipVal">
            <table width="100%" align="center" style="background-color: #ffffff;">
                <tr>
                    <td colspan="2" style="background: #52a93c url(images/AccordionTab2.jpg); height: 20px;
                        line-height: 22px; padding: 14px 0 8px 0; color: #fff; text-align: center; font-family: Verdana;
                        font-size: 12px; text-transform: uppercase; font-weight: bold;">
                        Enter your zip code
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 96%; margin: 10px auto;">
                            <tr>
                                <td style="padding-left: 20px; width: 50px">
                                    <b>Zip<span class="star">*</span></b>
                                </td>
                                <td style="padding-right: 5px;">
                                    <input type="text" id="txtZip" maxlength="5" class="input1 sample4" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td style="padding: 6px 0 20px 0;">
                                    <div style="width: 100%; margin: 0; padding-left: 0">
                                        <input id="zipValBut" type="button" class="button1-b" value="Ok" onclick="javascript:ValidateChangePW();" />
                                        <input type="button" id="btnCancelPW" class="button1-b" value="Cancel" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!-- ZIp Code POPUP  -->
    </form>

    <script type="text/javascript" language="javascript">

        var slider01 = [['images/slides/image-01.jpg', '2011 BMW X6', 'BMW', '6'],
					['images/slides/image-02.jpg', '2011 Chevrolet  Camaro ZL1 Carbon', 'Chevrolet', '10'],
					['images/slides/image-03.jpg', '2010 Lexus GX460', 'Lexus', '33'],
					['images/slides/image-04.jpg', '2012 Bentley Continental GT V8', 'Bentley', '7'],
					['images/slides/image-05.jpg', '2007 Porsche Cayman', 'Porsche', '50']];


        var vCars = [['images/1page-img1.jpg', '2009 Nissan Patrol', 25800],
				 ['images/1page-img2.jpg', '2008 Toyota Avalon', 55800],
				 ['images/1page-img3.jpg', '2010 Mercedes Benz S63 AMG', 85800],
				 ['images/1page-img4.jpg', '2007 BMW 5 Series', 125800],
				 ['images/1page-img5.jpg', '2006 Honda S2000', 25800],
				 ['images/1page-img3.jpg', '2011 Mercedes Benz S63 AMG', 85800],
				 ['images/1page-img4.jpg', '2010 BMW 5 Series', 125800],
				 ['images/1page-img5.jpg', '2009 Honda S2000', 25800]];

        var hCars = [['images/1page-img6.jpg', '2009 Audi A3 and S3 Sportback', 25800],
				 ['images/1page-img7.jpg', '2009 Lexus GS 450h', 65800],
				 ['images/1page-img8.jpg', '2009 Audi TTS Coupe', 45800],
				 ['images/1page-img9.jpg', '2010 Honda CR-V', 35800],
				 ['images/1page-img7.jpg', '2009 Lexus GS 450h', 65800]];

        //var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];

        //var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];

        var within = ['100', '250', 'Anywhere'];

        /* var carBrands1 = [['1a'],['1b'],['1c'],['1d'],['1e'],['1f'],['1g'],['1h'],['1i'],['1j'],['1k'],['1l'],['1m'],
        ['1n'],['1o'],['1p'],['1q'],['1r'],['1s'],['1t'],['1u'],['1v'],['1w'],['1x'],['1y'],['1z']
        ];	
        */

        var ad1 = ['images/ads/ad-v1.jpg', 'images/ads/ad-v2.jpg', 'images/ads/ad-v3.jpg', 'images/ads/ad-v4.jpg', 'images/ads/ad-v5.jpg', 'images/ads/ad-v6.jpg', 'images/ads/ad-v7.jpg', 'images/ads/ad-v8.jpg', 'images/ads/ad-v9.jpg', 'images/ads/ad-v10.jpg'];

        var ad2 = ['images/ads/ad-h1.jpg', 'images/ads/ad-h2.jpg', 'images/ads/ad-h3.jpg', 'images/ads/ad-h4.jpg', 'images/ads/ad-h5.jpg', 'images/ads/ad-h6.jpg', 'images/ads/ad-h7.jpg'];

        var VehicleID1;
        var VehicleIDName;
        function modelSearch(id, name) {
            VehicleID1 = id;
            VehicleIDName = name;
            $('.ZipVal-holder input[type=text]').val('');
            $('.ZipVal-holder').show();
            //CarsService.SearchCriteriaSave($('#make option:selected').val(), $('#model option:selected').val(),$('#yourZip').val(), $('#within option:selected').val(),OnSuccessSearchCriteriaSave,onerror);
            //searchByMake()   
        }


        function ValidateChangePW() {
            zip1 = $('#txtZip').val();
            if (zip1 == '') {
                alert('Enter ZIP');
            } else if (zip1.length < 5) {
                alert('Enter valid ZIP')
            } else {
                //$('.ZipVal-holder').hide();	        
                showSpinner();
                ChekZip2(zip1);
                //CarsSearch(MakeID,'All models',zip,'5', '1', '25', 'price'); 
            }
        }

        $('#btnCancelPW').click(function() {
            $('.ZipVal-holder').hide();
        });


        $(function() {

            $('.sample4').numeric();
            //$('.sample5').numeric({allow:"."});
            //$('.sample1').alphanumeric();	

            $('#make, #model, #within').empty();
            $('#yourZip').val('');
            $('#make, #model').attr('disabled', true);





            // Ads		
            //$('.ads1').empty();
            //return a random integer between 0 and 10		
            var ads = '';
            imgPath = ad2[Math.floor(Math.random() * ad2.length)];
            ads += "<div class='horiz-ad'><a href='#'><img src='" + imgPath + "' /></a></div>";
            ads += "<div class='clear'>&nbsp;</div>";
            $('.ads1').append(ads);







        });
    </script>

</body>
</html>
