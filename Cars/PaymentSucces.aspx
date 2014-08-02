<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentSucces.aspx.cs" Inherits="PaymentSucces"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>


<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="google-site-verification" content="2afWHJV2bG8MLKQu3ALnWHn2yE4On226m-r5ScavdLM" />
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
    <!--[if IE]>
  <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script src="assets/js/bannerAd.js"></script>



    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>


    <script src="Static/JS/JSCardValidation1.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

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

        var make1 = 'All makes';
        var Modal1 = 'All models';
        var ZipCode1 = '';
        var WithinZipNew = 3;


        function pageLoad() {
            GetRecentListings();
            GetMakes();
            GetModelsInfo();
            //GetZips();  
        }


        function KeyDownHandler(btn) {
            if (event.keyCode == 13) {
                event.returnValue = false;
                //event.cancel = true;
                //btn.click();
            }
        }


        KeyListener = {
            init: function () {
                $('#searchFormHolder').bind('keypress', function (e) {
                    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                    var target = e.target.tagName.toLowerCase();
                    if (key === 13 && target === 'input') {
                        e.preventDefault();
                        var button = $('.but1');
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

        $(document).ready(function () {
            KeyListener.init()
        });


    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

</head>
<body id="page1" style="background:#f0f0f0" >
    <form id="form1" runat="server" >
        <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
        </cc1:ToolkitScriptManager>


        <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />


     
     


        <div id="content ">
            <div class="section gray-light">
                <div class="container">

                    <div class="row">


                        <div class="col-md-12">

                            <!-- New Form Start  -->
                            <div class="wrapper">

                                <div class="content block-shadow white" style="padding: 0 20px;">

                                   
                                            <!--  -->
                                            <div class="info-box" style="background: #fff;">
                                                <div class="wrapper">
                                                    <table>
                                                        <tr>
                                                            <td style="padding-right: 20px; padding-top: 10px;">
                                                                <h2>Payment Info
                                                        </h2>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="border-top: #ccc 1px solid; padding: 15px 10px; width: 95%;">
                                                        <p style="padding-top: 0">
                                                            <h3 style="color: #f95446; font-size: 20px; font-weight: normal; margin-bottom: 20px;">Congratulations.! Your payment has been successfully completed.
                                                    </h3>
                                                            Dear
                                                   
                                                            <asp:Label ID="lbluser" runat="server" Text=""></asp:Label>,
                                                   
                                                            <br />
                                                            <div style="height: 6px; overflow: hidden; clear: both">
                                                                &nbsp;
                                                            </div>
                                                            We wish to inform you that you have subscribed to mobicarz.com, with transaction
                                                    ID
                                                   
                                                            <asp:Label ID="txtTran" runat="server" Text="tran"></asp:Label>
                                                            for
                                                   
                                                            <asp:Label ID="lblPackage" runat="server" Text="Package"></asp:Label>
                                                            Package (<asp:Label ID="lblCurrency" runat="server" Text="$"></asp:Label><asp:Label
                                                                ID="lblamount" runat="server" Text="99.99"></asp:Label>).
                                               
                                                        </p>
                                                    </div>
                                                    <div class="clear">
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- -->

                                    <br /><br /><br /><br />
                                       
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

      

        <div class="indent" style="padding-top: 5px; display:none;">
            <div class="wrapper">
                <!-- Recent Used Car Listings  start -->
                <div class="">
                    <h3 class="h3">Recent Used Car Listings</h3>
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
                    &nbsp;
                </div>
                <!-- Left Brand Ads Satrt -->
                <div id="lBrandAds2" style="padding: 3px; margin: 5px auto;">
                    <!-- Begin: adBrite, Generated: 2012-05-09 5:53:51  -->
                    <style type="text/css">
                        .adHeadline {
                            font: bold 10pt Arial;
                            text-decoration: underline;
                            color: #0000FF;
                        }

                        .adText {
                            font: normal 10pt Arial;
                            text-decoration: none;
                            color: #000000;
                        }
                    </style>

                    <script type="text/javascript">
                        try { var AdBrite_Iframe = window.top != window.self ? 2 : 1; var AdBrite_Referrer = document.referrer == '' ? document.location : document.referrer; AdBrite_Referrer = encodeURIComponent(AdBrite_Referrer); } catch (e) { var AdBrite_Iframe = ''; var AdBrite_Referrer = ''; }
                        document.write(String.fromCharCode(60, 83, 67, 82, 73, 80, 84)); document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr=' + AdBrite_Iframe + '&ref=' + AdBrite_Referrer + '" type="text/javascript">'); document.write(String.fromCharCode(60, 47, 83, 67, 82, 73, 80, 84, 62));</script>

                    <div>
                        <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">Your Ad Here</a>
                    </div>
                    <!-- End: adBrite -->
                </div>
                <div class="clear">
                    &nbsp;
                </div>
                <!-- Left Brand Ads End -->

            </div>
        </div>

       

      
      
      

        <!-- Footer Start  -->
        <div id="footer"  >
            <uc1:footer id="Footer1" runat="server" />
        </div>
        <!-- Footer End  -->

        <!-- Old  -->


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

    

    

</body>
</html>
