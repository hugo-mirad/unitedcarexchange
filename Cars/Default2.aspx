<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>United Car Exchange Resources</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />

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
            //GetCarBannerAds();
            //CarBannerAds = [];
            //CarBannerAdsDisplay(CarBannerAds);
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
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:ToolkitScriptManager ID="ScriptManager1" runat="server" />
        <html>
        <head>
            <title>United Car Exchange</title>
        </head>
        <body style="padding-top: 0px; padding-right: 0px; padding-bottom: 0px; padding-left: 0px;
            margin-top: 0px; margin-right: 0px; margin-bottom: 0px; margin-left: 0px;" ondragstart="return false"
            onselectstart="return false">
            <!-- START outer table (wrap) -->
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
                        </div>
                        <!-- content -->
                        <div id="content">
                            <div class="wrapper-1">
                                <div id="column-left">
                                    <div class="indent">
                                        <div class="wrapper">
                                            <ul class="list-1">
                                            </ul>
                                            <div class="clear">
                                            </div>
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
            <!-- END outer table (wrap) -->
        </body>
        </html>
    </div>
    </form>
</body>
</html>
