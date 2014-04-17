<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Usercontrol/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::UCE Dealers::..</title>
    <link href="css/maxx.css" rel="stylesheet" type="text/css" />
    <link href="css/buttons.css" rel="stylesheet" type="text/css" />
    <%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>--%>

    <script src="script/jquery-1.7.2.min.js" type="text/javascript"></script>

    <script src="js/jquery.tablesorter.min.js" type="text/javascript"></script>

    <!-- Fancyform -->

    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>

    <script type="text/javascript" src="js/jquery.hotkeys.js"></script>

    <script type="text/javascript" src="js/jquery.fancyform.js"></script>

    <script src="Static/JS/JSDealers.js" type="text/javascript"></script>

    <script src="Static/JS/dataFill.js" type="text/javascript"></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/jquery.mb.browser.min.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        var page = 0;
        var actionNow;
        function pageLoad() {
           ////debugger
            // //var path1 = "http://localhost:4111/Cars/2011/Alfa Romeo/8C Competizione/Index.aspx"            
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
            //alert(urlVars["C"]);
            //alert(urlVars["Q"]);

            if (urlVars != null && urlVars != undefined && urlVars != '' && urlVars["C"] != undefined && urlVars["C"] != 'undefined' && urlVars["C"] != null && urlVars["C"] != '') {
                var valid = true;
                if (urlVars["C"]) {
                    actionNow = urlVars["C"];
                } else {
                    valid = false;
                }
                if (urlVars["Q"]) {
                    $('#txtMainSearch').val(urlVars["Q"]);
                }
                if (actionNow.length >= 1 && valid == true) {
                    ////console.log(actionNow)                    
                                        
                    eval(actionNow)();
                    $('.box1 li a').each(function() {
                        if ($(this).attr('id') == actionNow) {
                            $(this).addClass('act')
                        } else { $(this).removeClass('act') }

                    });

                } else {
                ////debugger
                    searchAllVehicles();
                }


            } else { searchAllVehicles(); }
        }


        $(function() {
        //alert($.browser.name)
                if ($.browser.name == "Microsoft Internet Explorer" && parseInt($.browser.version) < 8) {
                    alert('Best viewd on Google Chrome, Mozilla, Safari and IE8+ ');
                    //window.location.hrtef='../login.aspx';
                }


            // Use a custom slider
            //$("slider").niceScroll();
            $('#dealerLogo').hide();
            // GetMakes();
            //bindYears();
            pageLoad();
            //GetModelsInfo();
            //GetModelsInfoByID('1');
            //GetDealerCars('Ford', 'Escape', '2009', 'Asc', '0', '3000', '1', '1', '', '', '1', '25');   // Handler for .ready() called.
            $('#search').click(function() {
                searchVehicle();
            });


            Swid = $('body').width() - (150);
            $(".gridHolder").css({ width: Swid });

            $('.userPic').click(function() {
                var Sleft = $('.userPic').offset().left - ($('.logOutHolder').width()) + 15;
                var Stop = $('.userPic').offset().top + ($('.userPic').height()) + 10;

                $('.logOutHolder').css({ left: Sleft, top: Stop }).show();
            });

            $('.adSer').click(function() {
                var Sleft = $('.searchBlock').offset().left;
                var Stop = $('.searchBlock').offset().top + ($('.searchBlock').height());
                $('.adSearch').css({ left: Sleft, top: Stop }).show();
            });


            $(document).mouseup(function(e) {
                var container = $('.logOutHolder');
                if (container.has(e.target).length === 0) {
                    container.hide();
                }

                var container2 = $('.adSearch');
                if (container2.has(e.target).length === 0) {
                    container2.hide();
                }
            });

            $('.adSearch .close').click(function() {
                $('.adSearch').hide();
            });

            // Custom SelectBox
            /*
            $(".rightNav select").transformSelect();

            $('.rightNav .transformSelect ul').each(function() {
                if ($(this).children().length > 6) {
                    $(this).height('160px').css({ 'overflow-y': 'scroll' });
                }
            });
            */


        });

        $(window).resize(function() {
            Swid = $('body').width() - (150);
            $(".gridHolder").css({ width: Swid });

            $('.logOutHolder').hide();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <table class="bb" style="width: 100%; height: 100%; min-height: 100%; border-collapse: collapse"
        cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 47px;">
                <!-- Head Start  -->
                <!-- Head End  -->
                <uc1:Header ID="Header1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <!-- Main Start  -->
                <div class="main">
                    <!-- twoBox Start   -->
                    <div class="twoBox">
                        <table class="wrapper" style="width: 100%; border-collapse: collapse;" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <!-- Left Box1 Start -->
                                <td class="box1" style="vertical-align: top">
                                    <ul class="links1">
                                        <li><a href="javascript:searchAllVehicles();" class="act" id="searchAllVehicles">All
                                            Vehicles</a></li>
                                        <li><a href="javascript:searchVehiclePublished();" id="searchVehiclePublished">Published</a></li>
                                        <li><a href="javascript:searchVehiclePrePublished();" id="searchVehiclePrePublished">
                                            Pre Published</a></li>
                                        <li><a href="javascript:searchVehicleSold();" id="searchVehicleSold">Sold</a></li>
                                        <li><a href="javascript:searchVehicleWithdrawn();" id="searchVehicleWithdrawn">Withdrawn</a></li>
                                        <li><a href="javascript:searchVehicleAdminCancel();" id="searchVehicleAdminCancel">Admin
                                            Cancel</a></li>
                                    </ul>
                                    <hr />
                                    <ul class="links2">
                                        <li><a href="javascript:searchVehicleArchive();" id="searchVehicleArchive">Archived
                                        </a></li>
                                    </ul>
                                </td>
                                <!-- Left Box1 End -->
                                <!-- Right Box2 Start  -->
                                <td class="box2" style="vertical-align: top">
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div class="rightNav">
                                        <table width="99%">
                                            <tr>
                                                <td style="width: 53px;">
                                                    <h4 style="padding-top: 9px;">
                                                        Change status :</h4>
                                                </td>
                                                <td style="width: 120px">
                                                    <select id="resAction1" disabled="disabled">
                                                        <option value="1">Publish</option>
                                                        <option value="6">Pre Publish</option>
                                                        <option value="3">Withdraw</option>
                                                        <option value="4">Sold</option>
                                                        <option value="5">Admin Cancel</option>
                                                    </select>
                                                </td>
                                                <td style="padding-left: 12px; width: 90px">
                                                    <input type="button" value="Apply" class="g-button" onclick="javascript:resApply()"
                                                        id="butApply" disabled="disabled" />
                                                </td>
                                                <td style="padding-left: 12px; width: 72px">
                                                    <input type="button" value="Archive" class="g-button delt" onclick="javascript:resDel()"
                                                        id="butDel" disabled="disabled" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <ul class="useTopMenu">
                                                        <li>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Upload a Vehicle" class="brL"
                                                                PostBackUrl="~/Dealer/NewCar.aspx" /></li>
                                                        <li>
                                                            <asp:LinkButton runat="server" Text="Upload Inventory" PostBackUrl="~/Dealer/DealerCarBulkUpload.aspx"></asp:LinkButton></li>
                                                    </ul>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Grid Start -->
                                    <span class="gridResults">Found <b>loading...</b></span>
                                    <div class="gridHolder" id="result" style="overflow-x: scroll; overflow-y: hidden;
                                        min-height: 60px;">
                                        <table class="tablesorter tablUP grid1 nopad props xmpl" id="myTable" style="margin: 10px;
                                            height: 100%">
                                            <thead>
                                                <tr class="tbHed">
                                                    <th>
                                                    </th>
                                                    <th scope="col" style="width: 80px; min-width: 80px">
                                                        Inventory ID
                                                    </th>
                                                    <th scope="col" style="width: 85px; min-width: 85px">
                                                        Status
                                                    </th>
                                                    <th scope="col" style="width: 82px; min-width: 82px">
                                                        Updated Dt
                                                    </th>
                                                    <th scope="col" style="width: 85px; min-width: 85px">
                                                        Uploaded Dt
                                                    </th>
                                                    <th scope="col" style="width: 45px; min-width: 45px">
                                                        Year
                                                    </th>
                                                    <th scope="col" style="width: 125px; min-width: 125px">
                                                        Make
                                                    </th>
                                                    <th scope="col" style="width: 125px; min-width: 125px">
                                                        Model
                                                    </th>
                                                    <th style="width: 60px; min-width: 60px">
                                                        Trim
                                                    </th>
                                                    <th scope="col" style="width: 85px; min-width: 85px">
                                                        Body Type
                                                    </th>
                                                    <th scope="col" style="width: 80px; min-width: 80px">
                                                        Active Days
                                                    </th>
                                                    <th scope="col" style="width: 70px; min-width: 70px">
                                                        Orig Price
                                                    </th>
                                                    <th scope="col" style="width: 85px; min-width: 85px">
                                                        Current Price
                                                    </th>
                                                    <th scope="col" style="width: 85px; min-width: 85px">
                                                        Purch Cost
                                                    </th>
                                                    <th scope="col" style="width: 85px; min-width: 85px">
                                                        Gross Profit
                                                    </th>
                                                    <th scope="col" style="width: 65px; min-width: 65px">
                                                        # Of Pics
                                                    </th>
                                                    <th scope="col" style="width: 75px; min-width: 75px">
                                                        Ext Color
                                                    </th>
                                                    <th scope="col" style="width: 75px; min-width: 75px">
                                                        Int Color
                                                    </th>
                                                    <th scope="col" style="width: 83px; min-width: 83px">
                                                        Condition
                                                    </th>
                                                    <th scope="col" style="width: 67px; min-width: 67px">
                                                        Multi-Site
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                    <h3 class="noMatch">
                                        No vehicles found.</h3>
                                    <!-- Grid End -->
                                </td>
                                <!-- Right Box2 End  -->
                            </tr>
                        </table>
                    </div>
                    <!-- twoBox End  -->
                </div>
                <!-- Main End  -->
            </td>
        </tr>
        <tr>
            <td style="height: 40px; overflow: hidden;">
                <!-- Footer Start  -->
                <div class="footer">
                    Copyright &copy; 2013 <a href="http://www.unitedcarexchange.com" target="_blank">unitedcarexchange.com</a>
                </div>
                <!-- Footer End  -->
            </td>
        </tr>
    </table>
    <!-- Posting PopUp Start  .popupHolder .popupContent .scroll  -->
    <div class="popupHolder2" id="listingURL" style="display: none;">
        <div class="popupContent">
            <h3>
                <a class="close"></a>
            </h3>
            <div class="scroll">
                <ul class="listingsURL">
                </ul>
            </div>
            <h4 style="margin: 40px 0; font-size: 22px; color: #999; text-align: center;">
                No URL's Found
            </h4>
            <div class="clear">
                &nbsp;</div>
        </div>
    </div>
    <!-- Posting PopUp End  -->
    </form>
</body>
</html>
