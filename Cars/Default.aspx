<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script src="js/jkl-parsexml.js" type="text/javascript"></script>

    <script src="js/preloader.min.js" type="text/javascript"></script>

    <!-- XML to Json Array  -->

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/Swis721_Md_BT_400.font.js"></script>

    <script type="text/javascript" src="js/cufon-replace.js"></script>

    <script type="text/javascript" src="js/loopedslider.js" charset="utf-8"></script>

    <!-- Banner Images Slider  -->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <!-- Tabbed Content  -->

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->
    <style>
        .usual ul li.tab1 a
        {
            display: block;
            padding: 5px 8px;
            text-decoration: none !important;
            margin: 0 2px 0 0;
            margin-left: 0;
            color: #444;
            font-weight: bold;
            background: url(images/AccordionTab0.gif) repeat-x;
        }
    </style>

    <script type="text/javascript">


        $(function() {

            myFun();
            KeyListener.init();
            KeyListener2.init()
        });

        function myFun() {
            //alert('Ok')       
            if (screen.width < 500) {
                var navegador = navigator.userAgent.toLowerCase();
                if (navegador.search(/iphone|ipod|android|nok(6|i)/) > -1) {
                    document.location = "http://m.UnitedCarExchange.com/index.aspx";
                } else {
                    document.location = "http://m.UnitedCarExchange.com/index.aspx";
                }
            }
        }



        var models = [];
        //var ZipCodes = [];
        var SessionArray = [];
        within = [10, 25, 50, 100, 'Anywhere'];
        var MakeID1;
        var MakeIDName;
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
        var WithinZipNew = 3;

        function pageLoad() {
            
            GetCarsAds();
            GetMakes();
            GetModelsInfo();

          
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
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
    
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                    <div class="loginStat">
                        <uc2:LoginName ID="LoginName1" runat="server" />
                    </div>
                    <div id="menu">
                        <uc3:CarsHeader ID="CarsHeader1" runat="server" />
                    </div>
                    <div id="search-box">
                        <div class="inner">
                            <div class="wrapper" id="searchFormHolder" runat="server">
                                <div class="clear dummyHeight8">
                                    &nbsp;</div>
                                <div style="color: #fff; font-size: 27px; font-weight: bold; margin: 0 0 2px 0; padding: 0;
                                    line-height: 35px;">
                                    Search <strong style="font-size: 35px;">USED CARS</strong></div>
                                <div class="clear dummyHeight26" style="height: 10px; overflow: hidden">
                                    &nbsp;</div>
                                <div class="width-1" style="width: 280px">
                                    <span class="text-form">Make</span><br />
                                    <select id="make" style="width: 280px;" tabindex="1" runat="server">
                                        <option value="">Loading...</option>
                                    </select>
                                </div>
                                <div class="clear dummyHeight8">
                                    &nbsp;</div>
                                <div class="width-1" style="width: 280px">
                                    <span class="text-form">Model</span>
                                    <select id="model" style="width: 280px;" tabindex="2" runat="server">
                                        <option>Loading...</option>
                                    </select>
                                </div>
                                <div class="clear dummyHeight8">
                                    &nbsp;</div>
                                <div class="width-1 ">
                                    <span class="text-form">Within</span>
                                    <select id="within" tabindex="3" runat="server">
                                        <option>Loading...</option>
                                    </select>
                                </div>
                                <div class="width-1" style="margin-left: 8px; margin-bottom: 0px;">
                                    <span class="text-form">ZIP</span>
                                    <input type="text" id="yourZip" maxlength="5" class="sample4" tabindex="4" runat="server" />
                                </div>
                                <div class="clear">
                                    &nbsp;</div>
                                <input type="button" value="Search" class="form-1-submit" onclick="search();" tabindex="5" />
                                <br />
                                <br />
                                <h4>
                                    For RVs &nbsp; <a href="http://www.unitedrvexchange.com/" style="color: #fff" target="_blank">
                                        Click here</a> &nbsp; <i style="font-size: 11px;">(unitedrvexchange.com)</i></h4>
                            </div>
                            <!-- <b><a href="#" onclick="document.getElementById('car-form').submit()"></a></b> -->
                        </div>
                    </div>
                    <div id="loopedSlider">
                        <div class="container">
                            <div class="slides">
                            </div>
                        </div>
                    </div>
                </div>
                <!-- content -->
                <div id="content">
                    <div class="wrapper-1">
                        <div id="column-left">
                            <div class="indent">
                                <div class="wrapper">
                                    <h2>
                                        Popular
                                        <!-- <span>Advertisement</span>  -->
                                    </h2>
                                    <ul class="list-1">
                                    </ul>
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <ul class="list-2">
                                    </ul>
                                    <h3 style="margin-bottom: 0; padding: 10px; background: #ccc; color: #444; font-size: 17px;
                                        font-family: arial, helvetica, sans-serif;">
                                        Select Cars By Make</h3>
                                    <div class="info-box">
                                        <div class="wrapper" style="padding-left: 6px; padding-right: -6px;">
                                            <!-- Car Models Div Start -->
                                            <div id="adv1" class="usual">
                                                <ul>
                                                    <li class="tab1"><a href="javascript:void(0);#1a " class="selected">A</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1b">B</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1c">C</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1d">D</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1e">E</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1f">F</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1g">G</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1h">H</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1i">I</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1j">J</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1k">K</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1l">L</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1m">M</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1n">N</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1o">O</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1p">P</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1q">Q</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1r">R</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1s">S</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1t">T</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1u">U</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1v">V</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1w">W</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1x">X</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1y">Y</a></li>
                                                    <li class="tab1"><a href="javascript:void(0);#1z">Z</a></li>
                                                </ul>
                                                <div class="clear">
                                                    &nbsp;</div>
                                                <div id="carBrands">
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </div>
                                            <!-- Car Models Div End -->
                                        </div>
                                    </div>
                                    <!-- Ads Section Start  -->
                                    <div id="div88X720" runat="server" style="height: 88px; width: 720px; margin: 10px 0 0 0;
                                        border: #999 1px solid; padding: 1px; background: #fff;">
                                      
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div class="ads1">
                                    </div>
                                    <!-- Ads Section Endt  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                            </div>
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
    <!-- Processiong Popup End -->
    <!-- ZIp Code POPUP  -->
    <div class="ZipVal-holder">
        <div id="ZipVal">
            <table width="100%" align="center" style="background-color: #ffffff;">
                <tr>
                    <td colspan="2" style="background: #FFB113 url(images/AccordionTab1.gif); height: 20px;
                        padding: 10px 0px; color: #fff; text-align: center; font-family: Verdana; font-size: 12px;
                        text-transform: uppercase; font-weight: bold;">
                        Enter your zip code
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 96%; margin: 10px auto;">
                            <tr>
                                <td style="padding-left: 5px; width: 120px">
                                    ZIP<span class="star">*</span>
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

        var within = ['10', '25', '50', '100', 'Anywhere'];

        /* var carBrands1 = [['1a'],['1b'],['1c'],['1d'],['1e'],['1f'],['1g'],['1h'],['1i'],['1j'],['1k'],['1l'],['1m'],
        ['1n'],['1o'],['1p'],['1q'],['1r'],['1s'],['1t'],['1u'],['1v'],['1w'],['1x'],['1y'],['1z']
        ];	
        */

        var ad1 = ['images/ads/ad-v1.jpg', 'images/ads/ad-v2.jpg', 'images/ads/ad-v3.jpg', 'images/ads/ad-v4.jpg', 'images/ads/ad-v5.jpg', 'images/ads/ad-v6.jpg', 'images/ads/ad-v7.jpg', 'images/ads/ad-v8.jpg', 'images/ads/ad-v9.jpg', 'images/ads/ad-v10.jpg'];

        var ad2 = ['images/ads/ad-h1.jpg', 'images/ads/ad-h2.jpg', 'images/ads/ad-h3.jpg', 'images/ads/ad-h4.jpg', 'images/ads/ad-h5.jpg', 'images/ads/ad-h6.jpg', 'images/ads/ad-h7.jpg'];


        function modelSearch(id, name) {
            MakeID1 = id;
            MakeIDName = name;
            $('.ZipVal-holder input[type=text]').val('');
            $('.ZipVal-holder').show();
            //CarsService.SearchCriteriaSave($('#make option:selected').val(), $('#model option:selected').val(),$('#yourZip').val(), $('#within option:selected').val(),OnSuccessSearchCriteriaSave,onerror);
            //searchByMake()   
        }


        function ValidateChangePW() {
            zip1 = $('#txtZip').val();
            if (zip1 == '') {
                alert('Enter ZIP');
                $('#txtZip').val('');
            } else if (zip1.length < 5) {
                alert('Enter valid ZIP')
                $('#txtZip').val('');
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

            $('.sample4').numeric({ allow: "-" });
            //$('.sample5').numeric({allow:"."});
            //$('.sample1').alphanumeric();	

            $('#make, #model, #within').empty();
            $('#yourZip').val('');
            $('#make, #model').attr('disabled', true);



            // Main Slider images
            if (slider01.length > 0) {
                var img = '';
                for (i = 0; i < slider01.length; i++) {
                    var p = '"' + slider01[i][3] + '"';
                    var brand = '"' + slider01[i][2] + '"';
                    img += "<div> <img src=" + slider01[i][0] + " onclick='javascript:modelSearch(" + p + "," + brand + ");' width='630' height='389' style='cursor:pointer;' /><p> <a href='javascript:modelSearch(" + p + "," + brand + ");'><strong style='font-size:16px; font-weight:bold; padding-top:10px;'>" + slider01[i][1] + "</strong></a> </p> </div>";
                }
                $('#loopedSlider .container .slides').empty();
                $('#loopedSlider .container .slides').append(img);

                // Option set as a global variable
                $.fn.loopedSlider.defaults.addPagination = true;
                $('#loopedSlider').loopedSlider({
                    autoStart: 5000
                });

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
            ads += "<div class='horiz-ad'><a href='#'><img src='" + imgPath + "' /></a></div>";
            ads += "<div class='clear'>&nbsp;</div>";
            $('.ads1').append(ads);



            $('.left-ad, .right-ad').css('text-align', 'left')


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
