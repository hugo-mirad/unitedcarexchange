<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsedTrucks.aspx.cs" Inherits="UsedTrucks" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title1" runat="server"></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link href="css/page1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>
    
        <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script type="text/javascript">
        var models;
        LoadingPage = 3;
        LoadingPage = 1;
        //var ZipCodes = [];

        var VehicleType1 = 'Any Type'
        var category1 = 'Any Category';
        var make1 = 'Any Make';
        var Modal1 = 'Any Model';
        var ZipCode1 = '';
        var WithinZipNew = 1;
        var VehicleType = [];
        var categoty = [];
        var make = [];
        function pageLoad() {
         
            GetRecentListings();
            GetVehicleType();

        }

        var within = ['100', '250', 'Anywhere'];


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

        $(document).ready(function() {
            KeyListener.init()
        });




        $(function() {
        $('.sample4').numeric();
        })
    
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
                <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                    <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">                        
                        Recent Used Truck Listings</h2>
                        <small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                    <!-- Left Brand Ads Satrt -->
                    <div class="ticker1">
                        <ul></ul>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                    </div>
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="indent">
                        <div class="wrapper">
                            <!--  -->
                            <div class="info-box" style="background: #fff;">
                                <div class="wrapper">
                                    <!-- Box1 Div Start  -->
                                    <div class="box1">
                                        <div class="inner">
                                            <div class="wrapper" id="searchFormHolder" runat="server">
                                                <h3 class="h3">
                                                    Find Used Trucks</h3>
                                                <i class="i1">Search among thousands of used Trucks listed for sale</i>
                                                <div class="clear">
                                                    &nbsp;</div>
                                                <div class="clear dummyHeight8">
                                                    &nbsp;</div>
                                                <div class="width-1" style="width: 280px">
                                                    <div class="black2">
                                                        Vehicle Type</div>
                                                    <select id="vehicleType" style="width: 280px;" tabindex="1">
                                                        <option value="">Loading...</option>
                                                    </select>
                                                </div>
                                                <div class="clear dummyHeight8">
                                                    &nbsp;</div>
                                                <div class="width-1" style="width: 280px">
                                                    <div class="black2">
                                                        Category</div>
                                                    <select id="categoty" style="width: 280px;" tabindex="2" disabled="disabled">
                                                        <option>Loading...</option>
                                                    </select>
                                                </div>
                                                
                                                <div class="width-1" style="width: 280px">
                                                    <div class="black2">
                                                        Make</div>
                                                     <select name="select" id="make" style="width: 280px;" tabindex="3" runat="server" disabled="disabled">
                                                        <option>Loading...</option>
                                                    </select>
                                                </div>
                                                
                                               
                                                
                                                <div class="clear dummyHeight8">
                                                    &nbsp;</div>
                                                <div class="width-1 " style="width: 120px;">
                                                    <div class="black2">
                                                        Within</div>
                                                    <select id="within" tabindex="4">
                                                        <option>Loading...</option>
                                                    </select>
                                                </div>
                                                <div class="width-1"  style="width: 120px; float: right; margin-bottom: 0px;">
                                                    <div class="black2">
                                                        ZIP</div>
                                                    <input type="text" id="yourZip" maxlength="5" class="sample4" tabindex="5" style="width: 111px;" />
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                                <input type="button" value="Search" class="button1 but1 ser" onclick="search();" tabindex="6" />
                                                <br />
                                            </div>
                                            <!-- <b><a href="#" onclick="document.getElementById('Truck-form').submit()"></a></b> -->
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <!-- Box1 Div End  -->
                                    <!-- Box2 Div Start  -->
                                    <div class="box2">
                                        <div class="wrapper">
                                            <h3 class="h3">
                                                Used Trucks</h3>
                                            <img src="images/used-car.jpg" alt="" style="margin: 0 0 6px 6px; float: right; width: 49%;
                                                padding: 4px; border: #ccc 1px solid" />
                                            <p>
                                                United Truck Exchange is the America's most trusted Online Buy & Sell Used Truck
                                                agency.United Truck Exchange helps in providing an online platform where Truck buyers
                                                and sellers can search, buy, sell and come together to talk about their Used/ New
                                                Trucks.</p>
                                            <p>
                                                United Truck Exchange list's detailed pricing information, description, dealer details,
                                                monthly calculator tools, photo galleries and customer reviews which helps Truck
                                                buyers with the information they need to make confident buying decisions.
                                            </p>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Box2 Div End  -->
                                    <div class="clear">
                                    </div>
                                    <!-- Box2 Div Start  -->
                                    <div class="box3">
                                        <div class="wrapper">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 65%; border-right: #77defa 1px dotted; padding: 10px;">
                                                        <h3 class="h3">
                                                            Sell Your Truck - Easy & Fast!</h3>
                                                        <p>
                                                            More then a million Trucks sold, already - Advertise with us.</p>
                                                        <input type="button" class="button1" value="LIST YOUR Truck NOW" onclick="window.location.href='Registration.aspx'" />
                                                    </td>
                                                    <td style="padding: 10px;">
                                                        <h3 class="h3">
                                                            Used Trucks Advertising</h3>
                                                        <i class="i1"></i><div class="clear">
                                                        </div>
                                                        View our <a href="Packages.aspx">Advertising plans</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Box2 Div End  -->
                                    <div class="clear">
                                    </div>
                                    <!-- Ads Section Start  -->
                                    <div class="ads1">
                                    </div>
                                    <!-- Ads Section Endt  -->
                                </div>
                            </div>
                            <!-- -->
                        </div>
                    </div>
                    <!-- Login Page End  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="clear">
                        &nbsp;</div>
                    <!-- Bottom Ads Start -->
                    <div class="bottomAdd " id="add730" style="width: 730px; margin: 10px 0; font-size: 11px;">
                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57 -->
                        <!-- End: adBrite -->
                    </div>
                    <!-- Bottom Ads End  -->
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
    </form>

    <script type="text/javascript">


        $(function() {

            $('a').each(function() {
                if ($(this).attr('href') == '#') {
                    $(this).attr('href', 'javascript:void(0)')
                }
            });

        });	
    
    
   
    </script>

</body>
</html>
