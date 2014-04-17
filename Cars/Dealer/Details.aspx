<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Dealer_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Usercontrol/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::UCE Dealers::..</title>
    <link href="css/maxx.css" rel="stylesheet" type="text/css" />
    <link href="css/buttons.css" rel="stylesheet" type="text/css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>

    <script src="js/production.js" type="text/javascript"></script>

    <!-- Fancyform -->

    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>

    <script type="text/javascript" src="js/jquery.hotkeys.js"></script>

    <script type="text/javascript" src="js/jquery.fancyform.js"></script>

    <script src="Static/JS/JSDealers.js" type="text/javascript"></script>

    <script src="Static/JS/dataFill.js" type="text/javascript"></script>

    <script type='text/javascript' src='../js/jquery.alphanumeric.pack.js'></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
        var page = 1;
        var CarID1;
        var mainPostingID;
        function pageLoad() {
            //var path1 = "http://localhost:4111/Cars/2011/Alfa Romeo/8C Competizione/Index.aspx"            
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

            if (urlVars != null && urlVars != undefined && urlVars != '' && urlVars["C"] != undefined && urlVars["C"] != 'undefined' && urlVars["C"] != null && urlVars["C"] != '') {

                var valid = true;
                if (urlVars["C"]) {
                    CarID1 = urlVars["C"];

                    if (CarID1.length > 0) {
                        var len = CarID1.length;
                        if (CarID1.charAt(CarID1.length - 1) == "#") {
                            CarID1 = CarID1.slice(0, (CarID1.length - 1));
                        }
                    }
                    gg = CarID1;


                    $('.uploadImages').click(function() {
                        window.location.href = "Picsupload.aspx?CarInventoryID=" + $('#Header1_lblDealerCode').val() + "P" + gg + " ";
                    })
                } else {
                    valid = false;
                }

                if (CarID1.length >= 1 && valid == true) {
                    //FindDealerCarID(sDealerCarID)
                    FindDealerCarID(CarID1, $('#Header1_lblDealerCode').text());




                } else {
                    alert('Wrong DealerUniqueID..!')
                }

                //alert(CarID1);

                //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');            
                //alert(WithinZip1);      

            } else {
                // window.location.href='searchcars.aspx?Make=All makes&Model=All models&ZipCode=92404&WithinZip=4';
                alert('Wrong DealerUniqueID..!')
            }

        }
    </script>

    <script type="text/javascript" language="javascript">

        $(function() {
            // Use a custom slider		
            //$("slider").niceScroll();

            ////            GetMakes();
            ////            bindYears();


            Swid = $(window).width() - (255);
            //$(".gridHolder").css({ width: Swid });

            $('.userPic').click(function() {
                var Sleft = $('.userPic').offset().left - ($('.logOutHolder').width()) + 15;
                var Stop = $('.userPic').offset().top + ($('.userPic').height()) + 10;

                $('.logOutHolder').css({ left: Sleft, top: Stop }).show();
            });


            $('#Apply1').attr('disabled', 'disabled');

            $('#resAction1').change(function() {
                $('#Apply1').removeAttr('disabled', 'disabled');
            })



            $(document).mouseup(function(e) {
                var container = $('.logOutHolder');
                if (container.has(e.target).length === 0) {
                    container.hide();
                }

            });





        });

        $(window).resize(function() {

            $('.logOutHolder').hide();
        });   
	
	
	
	
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <table class="bb" style="width: 100%; height: 100%; min-height: 100%; border-collapse: collapse"
        cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 47px;">
                <!-- Head Start  -->
                <uc1:Header ID="Header1" runat="server" />
                <!-- Head End  -->
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
                                <td class="box1">
                                    <ul class="links1">
                                        <li><a href="javascript:void(0);" id="searchAllVehicles">All Vehicles</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehiclePublished">Published</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehiclePrePublished">Pre Published</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehicleSold">Sold</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehicleWithdrawn">Withdrawn</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehicleAdminCancel">Admin Cancel</a></li>
                                    </ul>
                                    <hr />
                                    <ul class="links2">
                                        <li><a href="javascript:void(0);" id="searchVehicleArchive">Archive </a></li>
                                    </ul>
                                </td>
                                <!-- Left Box1 End -->
                                <!-- Right Box2 Start  -->
                                <td class="box2">
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div class="rightNav">
                                        <table width="99%">
                                            <tr>
                                                <td colspan="5">
                                                    <h3 style="padding-top: 5px;">
                                                        <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                        <asp:Label ID="lblPrice1" runat="server" class="detPrice"></asp:Label></h3>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 78px;">
                                                    <input type="button" value=" " onclick="javascript: window.location.href='home.aspx';"
                                                        class="g-button ar6" />
                                                </td>
                                                <td style="width: 53px;">
                                                    <h4 style="padding-top: 9px;">
                                                        Change status :</h4>
                                                </td>
                                                <td style="width: 120px">
                                                    <select id="resAction1">
                                                        <option value="1">Publish</option>
                                                        <option value="6">Pre Publish</option>
                                                        <option value="3">Withdraw</option>
                                                        <option value="4">Sold</option>
                                                        <option value="5">Admin Cancel</option>
                                                    </select>
                                                </td>
                                                <td style="padding-left: 12px; width: 90px">
                                                    <input type="button" value="Apply" id="Apply1" disabled="disabled" class="g-button"
                                                        onclick="javascript:resApply()" />
                                                </td>
                                                <td style="padding-left: 12px; width: 72px">
                                                    <input type="button" value="Delete" class="g-button delt" onclick="javascript:resDel()" />
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <ul class="useTopMenu">
                                                        <li><a href="#" class="brL editCar">Edit</a></li>
                                                        <li><a href="#" class="brR uploadImages">Manage Photos</a></li>
                                                    </ul>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="devider1">
                                        &nbsp;</div>
                                    <h4 style="padding-top: 9px; font-size: 12px; text-align: right; margin-right: 15px;">
                                        Current status: &nbsp;<label class="currentStat" style="color: #ff9900"></label></h4>
                                    <!-- Details Start -->
                                    <div class="uploadCarForm" style="width: 99%;">
                                        <table style="width: 98%; margin: 0 auto; padding: 0;">
                                            <tr style="display: none">
                                                <td style="padding-bottom: 20px;" id="searchFormHolder">
                                                    <strong style="width: 65px; display: inline-block; font-size: 14px;">Car ID:</strong>
                                                    <input type="text" class="txtCarID" style="padding: 5px; font-size: 13px; border: #ccc 1px solid;
                                                        margin-right: 5px;" maxlength="6" />
                                                    <input type="button" value="Search" class="button1 search" />
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="height: 10px; border-top: #666 2px dashed;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="proDet">
                                                        <div class="detailsDiv">
                                                            <fieldset class="formUploadCar">
                                                                <legend class="Title"></legend><strong>Inventory ID : </strong>
                                                                <label class="carID">
                                                                </label>
                                                                <br />
                                                                <strong>Name: </strong>
                                                                <label class="name">
                                                                </label>
                                                                <br />
                                                                <strong>Email: </strong>
                                                                <label class="email">
                                                                </label>
                                                                <br />
                                                                <strong>City & State: </strong>
                                                                <label class="city">
                                                                </label>
                                                                <br />
                                                                <strong>Phone: </strong>
                                                                <label class="phone">
                                                                </label>
                                                                <br />
                                                                <strong style="vertical-align: top">UCE URL: </strong><a class="url" target="_blank"
                                                                    style="display: none; background: #fff; border: #ccc 1px solid; padding: 5px;
                                                                    width: 80%; margin: 3px 0 0 0;"></a><a href="#" class="link1" style="color: #F90"
                                                                        target="_blank"></a>
                                                            </fieldset>
                                                            <div class="disc" style="width: 100%;">
                                                            </div>
                                                            <div class="SellerNotes">
                                                            </div>
                                                            <div class="imgHolder">
                                                                <ul>
                                                                </ul>
                                                                <div class="clear">
                                                                    &nbsp;</div>
                                                                <br />
                                                                <br />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- Details End -->
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

    <script type="text/javascript" language="javascript">


        var ad1 = ['images/ads/ads-l1.jpg', 'images/ads/ads-l2.jpg', 'images/ads/ads-l3.jpg'];
        $(function() {
            $("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");

            // Vertical Ticker



            $('.sample4').numeric();

            /*
            if(ad1.length>0){
            var img = '';
            var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
            img += "<img src='"+imgPath+"' />";
            $('#lBrandAds').empty();
            $('#lBrandAds').append(img);
            };
            */

            $('div.hed div.close').click(function() {
                $(this).toggleClass("open");
            });



        });

        function choice(e) {
            $('#div' + e).slideToggle();

        }
    </script>

    </form>
</body>
</html>
