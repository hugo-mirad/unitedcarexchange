<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PicsUpload.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Usercontrol/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::UCE Dealers::..</title>
    <link href="css/maxx.css" rel="stylesheet" type="text/css" />
    <link href="css/buttons.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery.min.1.7.2.js"></script>

    <script src="js/jquery.mb.browser.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.dateFormat-1.0.js"></script>

    <!-- Fancyform -->

    <script src="js/jquery.fancyform.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>

    <script type="text/javascript" src="js/jquery.hotkeys.js"></script>

    <script src="Static/JS/JSDealers.js" type="text/javascript"></script>

    <script src="Static/JS/dataFill.js" type="text/javascript"></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.dragsort-0.5.1.min.js"></script>

    <!-- Upload Images Flash 
    <link href="_scripts/uploadify.css" rel="stylesheet" type="text/css" />    
    <script type="text/javascript" src="_scripts/swfobject.js"></script>
    <script type="text/javascript" src="_scripts/jquery.uploadify.v2.1.4.min.js"></script>    
    
    <!-- Upload Images HTML 
    <link href="_scripts/uploadHTML5/uploadifive.css" rel="stylesheet" type="text/css" />

    <script src="_scripts/uploadHTML5/jquery.uploadifive.min.js" type="text/javascript"></script>

    -->

    <script src="js/production.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
debugger 
        var UploadifyAuthCookie = '<% = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>';
        var UploadifySessionId = '<%= Session.SessionID %>';


        var page = 10;
        var actionNow;
        var DealerUniqueID;
        var CARID;
        var PICID0;
        var Make;
        var Model;
        var Year;

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

            if (urlVars != null && urlVars != undefined && urlVars != '' && urlVars["CarInventoryID"] != undefined && urlVars["CarInventoryID"] != 'undefined' && urlVars["CarInventoryID"] != null && urlVars["CarInventoryID"] != '') {

                var valid = true;
                if (urlVars["CarInventoryID"]) {
                    CarID1 = urlVars["CarInventoryID"].split('P');
                } else {
                    valid = false;
                }

                if (CarID1.length >= 1 && valid == true) {
                    //FindDealerCarID(sDealerCarID)
                    FindDealerCarID(CarID1[1], $('#Header1_lblDealerCode').text());

                } else {
                    alert('Wrong CarInventoryID..!')
                }

                //alert(CarID1);

                //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');            
                //alert(WithinZip1);      

            } else {
                // window.location.href='searchcars.aspx?Make=All makes&Model=All models&ZipCode=92404&WithinZip=4';
                alert('Wrong DealerUniqueID..!')
            }

        }


        $(function() {
            pageLoad()
            // Use a custom slider
            //$("slider").niceScroll();
            $('#dealerLogo').hide();
            //GetModelsInfo();
            //GetModelsInfoByID('1');
            //GetDealerCars('Ford', 'Escape', '2009', 'Asc', '0', '3000', '1', '1', '', '', '1', '25');   // Handler for .ready() called.

            Swid = $(window).width() - (255);

            $(".thumbsUpload-holder, .archiveBlock").css({ width: Swid });


            Swid = $('body').width() - (150);

            $(".gridHolder").css({ width: Swid });

            $('.userPic').click(function() {
                var Sleft = $('.userPic').offset().left - ($('.logOutHolder').width()) + 15;
                var Stop = $('.userPic').offset().top + ($('.userPic').height()) + 10;

                $('.logOutHolder').css({ left: Sleft, top: Stop }).show();
            });
            $(document).mouseup(function(e) {
                var container = $('.logOutHolder');
                if (container.has(e.target).length === 0) {
                    container.hide();
                }
            });
            //$('.uploadPic').transformFile({ label: 'Add photos' });

        });

        $(window).resize(function() {
            Swid = $('body').width() - (150);
            $(".gridHolder").css({ width: Swid });

            $('.logOutHolder').hide();
        });


        function saveOrder() {
            var data = $("#list1 li").map(function() { return $(this).children().html(); }).get();
            $("input[name=list1SortOrder]").val(data.join("|"));
        };

        // Present Date
        function myDate() {
            var now = new Date(year, month, day, hours, minutes, seconds, milliseconds);

            var date = now.getFullYear();

            var outHour = now.getHours();
            if (outHour > 12) { newHour = outHour - 12; outHour = newHour; }
            if (outHour < 10) { var hours = "0" + outHour; }
            else { var hours = outHour; }

            var outMin = now.getMinutes();
            if (outMin < 10) { var mint = "0" + outMin; }
            else { var mint = outMin; }

            var outSec = now.getSeconds();
            if (outSec < 10) { var sec = "0" + outSec; }
            else { var sec = outSec; }
            var time = hours + ":" + mint + ":" + sec;
            return now;

        } 
	
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
                                <td class="box1">
                                    <ul class="links1">
                                        <li><a href="javascript:searchAllVehicles();" id="searchAllVehicles">All Vehicles</a></li>
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
                                <td class="box2">
                                    <div class="imgHolder">
                                        <ul>
                                        </ul>
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div class="rightNav">
                                        <table width="99%">
                                            <tr>
                                                <td style="width: 70px; vertical-align: top">
                                                    <input type="button" id="backPic" value=" " class="g-button ar6" />
                                                    <asp:HiddenField ID="hdnModel" runat="server" />
                                                    <asp:HiddenField ID="hdnMake" runat="server" />
                                                    <asp:HiddenField ID="hdnYear" runat="server" />
                                                    <asp:HiddenField ID="hdnPic20" runat="server" />
                                                    <asp:HiddenField ID="hdnPic19" runat="server" />
                                                    <asp:HiddenField ID="hdnPic18" runat="server" />
                                                    <asp:HiddenField ID="hdnPic17" runat="server" />
                                                    <asp:HiddenField ID="hdnPic16" runat="server" />
                                                    <asp:HiddenField ID="hdnPic15" runat="server" />
                                                    <asp:HiddenField ID="hdnPic14" runat="server" />
                                                    <asp:HiddenField ID="hdnPic13" runat="server" />
                                                    <asp:HiddenField ID="hdnPic12" runat="server" />
                                                    <asp:HiddenField ID="hdnPic11" runat="server" />
                                                    <asp:HiddenField ID="hdnPic10" runat="server" />
                                                    <asp:HiddenField ID="hdnPic9" runat="server" />
                                                    <asp:HiddenField ID="hdnPic8" runat="server" />
                                                    <asp:HiddenField ID="hdnPic7" runat="server" />
                                                    <asp:HiddenField ID="hdnPic6" runat="server" />
                                                    <asp:HiddenField ID="hdnPic5" runat="server" />
                                                    <asp:HiddenField ID="hdnPic4" runat="server" />
                                                    <asp:HiddenField ID="hdnPic3" runat="server" />
                                                    <asp:HiddenField ID="hdnPic2" runat="server" />
                                                    <asp:HiddenField ID="hdnPic1" runat="server" />
                                                    <asp:HiddenField ID="hdnPic0" runat="server" />
                                                    <asp:HiddenField ID="hdnCarID" runat="server" />
                                                    <asp:Image ID="Img1" runat="server" Visible="false" />
                                                </td>
                                                <td style="vertical-align: top">
                                                    <h3 style="font-weight: bold; padding-top: 6px;" class="headding1">
                                                        Showing images of Inventory ID:&nbsp;<span style="color: #ff6600"></span></h3>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right" style="vertical-align: top">
                                                    <div id="fuFiles">
                                                        <div id="queue">
                                                        </div>
                                                        <input id="file_upload" name="file_upload" type="file" multiple="true">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <%-- <span style="color: #888; font-size: 11px;"><b>Notes: </b>You can use the mouse to rearrange
                                        the photos in the sequence you like. Move the mouse over to the photo.</span>--%>
                                    <div class="devider1">
                                        &nbsp;</div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <asp:Button ID="imageOrder" runat="server" Text="Save Images Order" CssClass="g-button right"
                                        OnClick="imageOrder_Click" />
                                    <%-- <input type="button" value="Save Images Order" class="g-button right" id="imageOrder" style="display:none;"
                                       />
                                    <input type="button" value="Save Images" class="g-button right" id="imagesSave" runat="server" style="display:none;"/>--%>
                                    <asp:Button ID="imagesSave" runat="server" Text="Save Images" CssClass="g-button right"
                                        OnClick="imageOrder_Click" />
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Photos Start -->
                                    <div class="thumbsUpload-holder">
                                        <ul class="thumbsUpload">
                                        </ul>
                                    </div>
                                    <!-- Photos End -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Archive Start  -->
                                    <div class="archiveBlock">
                                        <h2>
                                            Archive</h2>
                                        <ul>
                                        </ul>
                                    </div>
                                    <!-- Archive Start  -->
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
    </form>
</body>
</html>
