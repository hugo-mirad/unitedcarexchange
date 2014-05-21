<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCars.aspx.cs" Inherits="SearchCars"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html xml:lang="en" lang="en">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    <link href="js/jslider/jquery.slider.min.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:HiddenField ID="hdnPriceMIN" runat="server" Value="" />
    <asp:HiddenField ID="hdnPriceMAX" runat="server" Value="" />
    <asp:HiddenField ID="hdnMileageMIN" runat="server" Value="" />
    <asp:HiddenField ID="hdnMileageMAX" runat="server" Value="" />
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="content" class="page-filter">
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-9">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="block block-margin sort" style="margin: 0;">
                                    <div class="block-inner gray" style="padding: 0;">
                                        <div class="pull-left">
                                            <p id="totalResultsFound">
                                            </p>
                                        </div>
                                        <div id="sort-form" class="form-inline pull-right">
                                            <div class="form-group">
                                                <select id="resultsPerPage" style="display: none;">
                                                    <option value="25">25</option>
                                                    <option value="50">50</option>
                                                    <option value="75">75</option>
                                                    <option value="100">100</option>
                                                </select>
                                                <select id="filterSortBy" class="form-control" name="sort" disabled="disabled">
                                                    <!-- <option value="0">Select sort</option> -->
                                                    <option value="1">Price low to high</option>
                                                    <option value="2">Price high to low</option>
                                                    <option value="3">Year old to new</option>
                                                    <option value="4" selected="selected" >Year new to old</option>
                                                    <option value="5">Mileage low to high</option>
                                                    <option value="6">Mileage high to low</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="main">
                            <div class="row-block block block-margin">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="content white">
                                            <div class="inner searchResultsHolder">
                                                <!-- /.row-item -->
                                            </div>
                                            <div class="resultsLoading">
                                                &nbsp;
                                            </div>
                                            <div style="text-align: center; padding: 20px 0;">
                                                <label class=" btn btn-primary moreResults" style="min-width: 70%; width: 70%; margin: 20px auto;">
                                                    Load more</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /#main -->
                    </div>
                    <div class="col-md-3 sidebar">
                        <div class=" block block-shadow white">
                            <div class="block-inner" style="position: relative;">
                                <div class="block-title">
                                    <h3>
                                        Search <b>Used Cars</b></h3>
                                </div>
                                <select id="within" style="display: none;">
                                    <option value="5" selected="selected">Anywhere</option>
                                </select>
                                <div class="block-inner" style="padding: 0; ">
                                    <div id="disableFilter">
                                    </div>
                                    <div class="form-section">
                                        <div class="form-group">
                                            <select name="maker" class="form-control" id="make" runat="server">
                                                <option>Loading</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <select name="model" class="form-control" id="model" runat="server">
                                                <option>Loading</option>
                                            </select>
                                        </div>
                                        <div class="form-group col-lg-8 col-md-6 col-sm-6 col-xs-6" style="padding-left: 0">
                                            <input type="text" class="form-control sample4" maxlength="5" placeholder="ZIP" id="yourZip"
                                                runat="server">
                                        </div>
                                        
                                        <div class="form-group">
                                        <a href="javascript:newSearch();" class="send btn btn-primary btn-primary-color">Search
                                            now <i class="icon icon-normal-right-arrow-small"></i></a>
                                    </div>
                                    </div>
                                   
                                    
                                    
                                    
                                </div>
                            </div>
                        </div>
                        <!-- /#filter -->
                       
                        
                        
                        
                        
                         <div id="Filter" class="filter-cars block block-shadow white">
                            <div class="block-inner">
                                <div class="block-title">
                                    <h3>Filter</h3>
                                </div>
                                
                                
                                <div class="block-inner" style="padding: 0; position: relative;">
                                    <div class=" filterGrout ">
                                        
                                        <div class="form-section filters">                                            
                                            <div class="filter-cars form-group col-lg-12 col-md-12 col-sm-6 col-xs-6" style="margin-bottom: 0;">
                                                <div class="filter-range-slider" style="height: 70px; padding-top: 25px">
                                                    <input id="priceRange" type="text" value="" disabled="disabled">
                                                </div>
                                            </div>
                                            <div class="filter-cars form-group col-lg-12 col-md-12 col-sm-6 col-xs-6" style="margin-bottom: 4px;">
                                                <div class="filter-range-slider" style="height: 70px; padding-top: 25px;">
                                                    <input id="mileRange" type="text" value="" disabled="disabled">
                                                </div>
                                            </div>
                                            <div class="filter-cars form-group col-lg-12 col-md-12 col-sm-6 col-xs-6" style="margin-bottom: 0;">
                                                <div class="filter-range-slider" style="height: 70px; padding-top: 25px">
                                                    <input id="yearRange" type="text" value="" disabled="disabled">
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="form-section form-colors devider">
                                        </div>
                                        <div class="form-section" id="Div1">
                                            <div class="form-group">
                                                <!-- Body Type  -->
                                                <div class="hed hh4">
                                                    <!-- onclick="javascript:choice(event,'Body')"
                                                <input type="checkbox" />  -->
                                                    <a>Body Type</a>
                                                    <div class="open ">
                                                    </div>
                                                </div>
                                                <div id="choiceBody" style="display: none;">
                                                    <ul>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Convertible</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Coupe</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Hatchback</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Sedan</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />SUV</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Truck</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Van/Minivan</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Wagon</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Other</label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                </div>
                                            </div>
                                            <div class="form-section form-colors devider">
                                            </div>
                                            <div class="form-group">
                                                <!-- Fuel Type-->
                                                <div class="hed hh5">
                                                    <!--  <input type="checkbox" />
                                           onclick="javascript:choice(event,'Fuel')" -->
                                                    <a>Fuel Type</a>
                                                    <div class="open ">
                                                    </div>
                                                </div>
                                                <div id="choiceFuel" style="display: none;">
                                                    <ul>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Diesel</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Petrol</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Hybrid</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Electric</label>
                                                            </div>
                                                        </li>
                                                        <li>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <input type="checkbox" checked="checked" />Other</label>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                </div>
                                            </div>
                                           
                                            <div class="form-group" style="display: none;">
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
                                            </div>
                                            <div class="form-group" style="display: none;">
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
                                        </div>
                                    </div>
                                
                                </div>
                                
                            </div>
                        </div>
                        
                        
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    </form>

    <script src="libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="libraries/star-rating/jquery.rating.js"></script>

    <script src="libraries/colorbox/jquery.colorbox-min.js"></script>

    <script src="js/jslider/jquery.slider.min.js" type="text/javascript"></script>

    <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

    <script src="assets/js/carat.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

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

        $(window).load(function() {
            pageLoad1()
        });


        function pageLoad1() {

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
                /*
                if (urlVars["WithinZip"]) {
                WithinZipNew = urlVars["WithinZip"].replace('%20', ' ');
                if (WithinZipNew.charAt(0) == '#') {
                WithinZipNew = WithinZipNew.replace('#', '');
                }
                }
                */

                if (make1 == null || make1 == 'undefined' || make1 == '' || make1 == ' ') {
                    make1 = 'All makes'
                }
                if (Modal1 == null || Modal1 == 'undefined' || Modal1 == '' || Modal1 == ' ') {
                    Modal1 = 'All models'
                }
                /*
                if (WithinZipNew == null || WithinZipNew == 'undefined' || WithinZipNew == '' || WithinZipNew == ' ') {
                WithinZipNew = 4;
                }
                */
                if (!ZipCode1 || ZipCode1 == null || ZipCode1 == 'undefined' || ZipCode1 == '' || ZipCode1 == ' ') {
                       if($.cookie('userZip')){
                            $('.buyzip').val($.cookie('userZip'));
                            buySearch();
                        }else{
                            $find('HeadderBlogin1_MdlBuyacar').show();
                        }
                } else {
                    //console.log(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');

                //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew, '1', '25', 'Price');

               
                    CarsSearchSpeed(make1, Modal1, ZipCode1, WithinZipNew, '1', '25', 'yearofMake');
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

        var Mileage1;
        var Mileage2;
        var Year1a;
        var Year1b;
        var Price1;
        var Price2;


        var rangeSliderVar = true;






        // CarsSearch2(carMakeid, CarModalId, ZipCode, WithinZip,pageNo, pageresultscount, orderby)
    </script>

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

</body>
</html>
