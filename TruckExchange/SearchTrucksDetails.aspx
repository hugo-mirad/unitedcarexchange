<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTrucksDetails.aspx.cs"
    Inherits="SearchCarDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title runat="server"></title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/searchBlock.css" rel="stylesheet" type="text/css" />
    <link rel='stylesheet' href='css/results.css' type='text/css' media='all' />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link rel="stylesheet" type="text/css" href="css/jquery.thumbs.css" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />
    <link href="css/gallery.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/galleria-1.2.7.js"></script>

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.thumbs.js'></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script type="text/javascript">
        var models;
        LoadingPage = 3;
        //var ZipCodes = [];
        var VehicleType1 = 'Any Type'
        var category1 = 'Any Category';
        var make1 = 'Any Make';
        var Modal1 = 'Any Model';
        var clentZip = '';
        var ZipCode1 = '';
        var WithinZipNew = 1;
        var CarID1;
        var currentImg;
        var VehicleType = [];
        var categoty = [];
        var make = [];
        var models = [];
        function pageLoad() {
            GetRecentListings();
            GetVehicleType();
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
                //console.log($('#hdnzip').val());

                if (ZipCode1 == '0' || ZipCode1 == 0 || ZipCode1 == '' || ZipCode1 == ' ') {
                    $('#yourZip').val($('#hdnzip').val());
                }else{
                    $('#yourZip').val(ZipCode1);
                }
                

                $('#within option').each(function() {
                    $(this).removeAttr('selected');
                });


                WithinZipNew = parseInt(WithinZipNew); 
                if (WithinZipNew == '0' || WithinZipNew == 0 || WithinZipNew == '' || WithinZipNew == 'undefined') {
                    $('#within option[value=' + 1 + ']').attr('selected', 'selected');
                } else {
                    $('#within option[value=' + WithinZipNew + ']').attr('selected', 'selected');
                }

                if (urlVars["VehicleType"]) {
                    VehicleType1 = urlVars["VehicleType"].replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('%20', ' ');
                    VehicleType1 = VehicleType1.replace('#', '')
                }
                if (VehicleType1 == null || VehicleType1 == 'undefined' || VehicleType1 == '' || VehicleType1 == ' ') {
                    VehicleType1 = 'Any Type'
                }

                if (urlVars["Category"]) {
                    category1 = urlVars["Category"].replace('%20', ' ');
                    category1 = category1.replace('%20', ' ');
                    category1 = category1.replace('%20', ' ');
                    category1 = category1.replace('%20', ' ');
                    category1 = category1.replace('%20', ' ');
                    category1 = category1.replace('%20', ' ');
                    category1 = category1.replace('%20', ' ');
                    category1 = category1.replace('#', '')
                }
                if (category1 == null || category1 == 'undefined' || category1 == '' || category1 == ' ') {
                    category1 = 'Any Category';
                }
                var valid = true;
                if (urlVars["C"]) {
                    CarID1 = urlVars["C"];
                    CarID1 = CarID1.replace('#', '')
                } else {
                    valid = false;
                }
                if (CarID1.length >= 9) {

                    CarID1 = CarID1.substring(8);
                    CarID1 = CarID1.replace('#', '');
                    valid = true;
                } else {
                    valid = false;
                }
                if (make1 == null || make1 == 'undefined' || make1 == '' || make1 == ' ') {
                    make1 = 'Any Make'
                }
                if (Modal1 == null || Modal1 == 'undefined' || Modal1 == '' || Modal1 == ' ') {
                    Modal1 = 'Any Model'
                }
                if (WithinZipNew == null || WithinZipNew == 'undefined' || WithinZipNew == '' || WithinZipNew == ' ') {
                    WithinZipNew = 1;
                }

                /*
                if(ZipCode1 == null || ZipCode1 == 'undefined' || ZipCode1 == '' || ZipCode1 == ' '){
                alert('Enter your ZIP');
                }else{
               
                CarsSearch2(make1, 'Any Model', ZipCode1, WithinZipNew,'1', '25', 'Price', VehicleType1, category1);
                }
                */
                if (valid == true) {
                    //alert(CarID1);          
                    //FindCarID(CarID1);
                } else {
                    window.location.href = 'errorPage.aspx'
                }

                //alert(CarID1);

                //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');            
                //alert(WithinZip1);      

            } else {
                // window.location.href='searchcars.aspx?Make=Any make&Model=All models&ZipCode=92404&WithinZip=4';
                window.location.href = 'errorPage.aspx'
            }

        }

        var within = ['100', '250', 'Anywhere'];
    
    
  
    
    
    </script>

    <script type="text/javascript">
        // Gallery Calling Start --------------------------------------------------->

        function ShowSlider() {

            $('.sliderHolder ul li img').click(function() {
                currentImg = $(this).parent().index();
                $('.galleryHolder').fadeIn('fast', function() {
                    // Load the classic theme
                    Galleria.loadTheme('themes/classic/galleria.classic.min.js');
                    // Initialize Galleria
                    Galleria.configure({
                        width: ($('.gallery1').width()) - 320,
                        height: ($('.gallery1').height()) - 40,
                        transition: "pulse",
                        thumbCrop: true,
                        imageCrop: true,
                        carousel: true,
                        imagePan: true,
                        clicknext: true
                    });

                    $('.galleryHolder a.galClose').click(function() {
                        $('.galleryHolder').fadeOut('slow');
                    });
                    //var gal = $("#gallery1").galleria();
                    Galleria.run('#galleria', {
                        showInfo: false,
                        extend: function(options) {
                            this.bind('image', function(e) {
                                $('.imgDisc').hide().html(e.galleriaData.description).fadeIn();
                            });
                        }
                    });


                });
            });
        }
        // Gallery Calling End -------------------------------------------------------------------->


     
        
        
        

    </script>
<script type="text/javascript">

    function ValidateContact() {

        var valid = true;

        if ($('#txtcemail').val().trim() == 'my email address') {
            alert("Enter from email");
            $('#txtcemail').focus();
            valid = false;
            return valid;
        }
        if (($('#txtcemail').val().trim().length > 0) && (echeck($('#txtcemail').val().trim()) == false)) {
            document.getElementById('txtcemail').value = ""
            document.getElementById('txtcemail').focus()
            valid = false;
            return valid;

        }
        if ($('#txtPhone').val().trim() == 'my phone number') {
            alert("Enter phone#");
            $('#txtPhone').focus();
            valid = false;
            return valid;
        }

        else if (($('#txtPhone').val().trim().length > 0) && ($('#txtPhone').val().trim().length < 10)) {
            $('#txtPhone').focus();
            $('#txtPhone').val();
            alert("Enter valid phone number");
            valid = false;
            return valid;
        }
        if ($('#txtfirstName').val().trim() == 'First Name') {
            alert("Enter first name");
            $('#txtfirstName').focus();
            valid = false;
            return valid;
        }
        return valid;

        //, txtlastName, zipCode1
    }

    function slidershow() {

        make1 = $('#lblMake').text();
        Modal1 = $('#lblModel').text();
        ZipCode1 = parseInt($('#zipcode').val());

        $('#yourZip').val($('#zipcode').val());
        WithinZipNew = 4;

        var settings = { start: 1, change: false };
        $("#adv1 ul").idTabs(settings, true);


        $('.detPrice,.detMileage,.detPrice1').formatCurrency();
        $('.detMileage').formatCurrency({ symbol: ' ' });


        var totalImages = $('div#basic2 ul li').length;
        //console.log(totalImages);
        $('div#basic2 ul li img').each(function() {

            var img = $(this);
            var width = 0; var height = 0;
            $("<img/>").attr("src", $(this).attr("src")).load(function() {
                totalImages--;
                width = this.width;   // Note: $(this).width() will not
                height = this.height; // work for in memory images.                          

                var maxWidth = 680; // Max width for the image
                var maxHeight = 452;    // Max height for the image          


                ratio = maxWidth / width;   // get ratio for scaling image
                img.attr("width", maxWidth); // Set new width
                img.attr("height", height * ratio); // Scale height based on ratio

                //console.log(img.width()+", "+img.height()); 

                if (totalImages <= 1) {
                    // Slider2
                    //console.log(totalImages);
                    $("div#basic2").slideViewerPro({
                        thumbs: 6,
                        thumbsPercentReduction: 14
                    });
                }
                $('.ldrgif').hide();
            });
        });
        $('.ldrgif').hide();
    }

    function emailSend() {
        //console.log('Email Send');
        //$('#Login-holder').show();

        $find('MpeEmail').show();

        $('.cls, #btnCancelPW').click(function() {

            //$('#Login-holder, #Country-holder').hide();

            $find('MpeEmail').hide();
            $('#zipCode1').val('Zip or City');
            $('#txtPhone').val('my phone number');
            $('#txtcemail').val('my email address');
            $('#txtfirstName').val('First Name');
            $('#txtlastName').val('Last Name');
            $('#txtComments').val('Enter your message here');
            return false;

        });

        $(function() {
            $('.default-value').each(function() {
                var default_value = this.value;
                $(this).css('color', '#999')
                $(this).focus(function() {
                    $(this).css('color', '#333')
                    if (this.value == default_value) {
                        this.value = '';
                        $(this).css('color', '#333')
                    } else { $(this).css('color', '#333') }
                });
                $(this).blur(function() {
                    if (this.value == '') {
                        this.value = default_value;
                        $(this).css('color', '#999')
                    } else { $(this).css('color', '#333') }
                });
            });
        })


    }

    function hide() {
        $('#Login-holder, #Country-holder').hide();
    }
    function alertshow() {
        $('#mpealert').show();
    }
    $(function() {
        $('.default-value').each(function() {
            var default_value = this.value;
            $(this).css('color', '#999')
            $(this).focus(function() {
                $(this).css('color', '#333')
                if (this.value == default_value) {
                    this.value = '';
                    $(this).css('color', '#333')
                } else { $(this).css('color', '#333') }
            });
            $(this).blur(function() {
                if (this.value == '') {
                    this.value = default_value;
                    $(this).css('color', '#999')
                } else { $(this).css('color', '#333') }
            });
        });
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
                 <div class="info-box">
                                        <div class="wrapper leftSearch" style="background:url(images/homepage_search_back.png) center bottom no-repeat; width:96%; padding:0 10px 37px 10px; margin:0 0 0 -5px;">
                                            <h2 style="text-align:center; color:#fff"><span style="font-weight:normal; color:#333;">QUICK</span> SEARCH</h2>
                                            <div id="searchFormHolder" style=" width:103%; margin: 0 auto; padding:0">
                                                <div class="width-1" style="width: 98%;">
                                                    
                                                       <b>Type</b>
                                                    <select id="vehicleType" runat="server" disabled="disabled" style=" padding:2px 1px;">
                                                        <option>Loading...</option>
                                                    </select>
                                                    <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                    <b>Category</b>
                                                    <select id="categoty" runat="server"  disabled="disabled" style=" padding:2px 1px;">
                                                        <option>Loading...</option>
                                                    </select>
                                                    
                                                    <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                    <b>Make</b>
                                                    <select name="select" id="make" runat="server"  disabled="disabled" style=" padding:2px 1px;">
                                                        <option value="0">Loading...</option>
                                                    </select>
                                                    
                                                    <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                    <b>Model</b>
                                                    <select name="select" id="model" runat="server" disabled="disabled" style=" padding:2px 1px;">
                                                        <option value="0">Loading...</option>
                                                    </select>
                                                </div>
                                                <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                <div class="width-1" style="width: 52%">
                                                    <b>Within</b><br />
                                                    <select id="within" runat="server" disabled="disabled" style="width: 98%; padding:2px 1px;">
                                                    </select>
                                                </div>
                                                <div class="width-1" style="width: 40%">
                                                    <b>ZIP</b><br />
                                                    <input type="text" id="yourZip" maxlength="5" runat="server" disabled="disabled"
                                                        class="zip sample4" style="width: 88%; padding:1px;" />
                                                </div>
                                                <div class="clear" style="margin-bottom:6px">&nbsp;</div>
                                                <div style=" margin-left: -1px; float: left; width: 66px;">
                                                    <a href="javascript:search();" class="button" id="form-1-submit" style="margin: 3px 0 0 3px">
                                                        Search</a>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    
                    <div class="leftBox1">
                        <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
                            Recent Used Truck Listings</h2>
                        <small>
                            <e style="font-size: 11px;">Most recent Used Trucks listed for sale</e>
                        </small>
                        <!-- Left Brand Ads Satrt -->
                        <div class="ticker1">
                            <ul>
                            </ul>
                        </div>
                        <div class="clear">
                            &nbsp;</div>
                    </div>
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start 
                    
                    <div class="clear H15">
                        &nbsp;</div>  -->
                    <!-- Details Start  -->
                    <div id="searchResultsHolder" class="searchResultsHolder" style="display: block; margin-top:0">
                        <h3 class="h3 h3b" id="carDet" style="margin-top:0">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>-
                            <asp:Label ID="lblPrice1" runat="server" class="detPrice"></asp:Label>
                        </h3>
                        <div style="width: 100%; margin: 0px auto;" id="carDetailsDivHolder">
                            <table style="width: 100%" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td style="line-height: 20px; padding: 0">
                                            
                                            <table style="width: 100%; margin-top: 10px;" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 320px; vertical-align: top; padding: 0">
                                                            <div class="soldCar" style="display: none;">
                                                                <h2 style="color: #777; font-size: 26px;">
                                                                    <img src="images/sold_out_stamp.gif" style="float: right">
                                                                    Sorry..!<br>
                                                                    This car has been already sold..!
                                                                </h2>
                                                                <div class="clear">
                                                                    &nbsp;</div>
                                                            </div>
                                                            <div class="sellerInfo1" style="">
                                                                <!-- Slider Start  -->
                                                                <div class="sliderHolder2">
                                                                    <div id="basic">
                                                                        <asp:Image Style="width: 240; height: auto" class="slide1a" ID="imgsrc" runat="server" />
                                                                        <div class="clear">
                                                                            &nbsp;</div>
                                                                    </div>
                                                                    <div class="clear">
                                                                        &nbsp;</div>
                                                                </div>
                                                                <!-- Slider End  -->
                                                                <div class="clear">
                                                                    &nbsp;</div>
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: top; padding: 0">
                                                            <div class="sellerInfo2">
                                                                <asp:Label ID="lblSellerAddress1" runat="server" Style="text-transform: capitalize;">
                                                                </asp:Label>
                                                                </br>
                                                                <asp:HiddenField ID="hdnCarid" runat="server"></asp:HiddenField>
                                                                <asp:Label ID="lblSellerAddress" Style="text-transform: capitalize;" runat="server">
                                                                </asp:Label>
                                                                </br>
                                                                <div class="H10">
                                                                    &nbsp;</div>
                                                                <strong>Phone: &nbsp;</strong>
                                                                <asp:Label ID="lblSellerNo" runat="server">
                                                                </asp:Label>
                                                                <strong style="display: none;">Email: &nbsp;</strong>
                                                                <asp:Label ID="lblSellerEmail" runat="server" Style="display: none;">
                                                                </asp:Label>
                                                                </br> <strong>Seller Type: </strong>
                                                                <asp:Label ID="lblSellerType" runat="server">
                                                                </asp:Label>
                                                                </br> <strong style="display: none">Seller Name: </strong>
                                                                <asp:Label ID="lblSellerName" Style="display: none" runat="server">
                                                                </asp:Label>
                                                                <asp:HiddenField ID="hdnzip" runat="server" />
                                                                </br>
                                                                <div style="display:none">
                                                                <strong>Email: &nbsp;</strong> <a href="javascript: emailSend()">Send an email to seller</a>
                                                                </div>
                                                                
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            
                                            
                                            <div class="clear">
                                                &nbsp;</div>
                                            <div id="carDet0">
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 0;">
                                            <br>
                                            <!-- Car Details Div Start -->
                                            <div>
                                                <!-- Disc Start -->
                                                <div class="discTab">
                                                    <h3 class="h3b">
                                                        About This
                                                        <asp:Label ID="lblTitle1" runat="server"></asp:Label>
                                                        <a href="#photos" style="display: inline-block; margin-left: 50px; width: 100px;">View
                                                            Photos</a></h3>
                                                    <table style="width: 99%; margin: 0" id="carDet1">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 50%; vertical-align: top">
                                                                    <strong>New/Used: </strong><span>&nbsp;Used</span><br />
                                                                    <strong>Type: </strong>
                                                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                                                    <br>
                                                                    <strong>Category: </strong>
                                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label><br>
                                                                    <strong>Make: </strong>
                                                                    <asp:Label ID="lblMake" runat="server"></asp:Label>
                                                                    <br>
                                                                    <strong>Model: </strong>
                                                                    <asp:Label ID="lblModel" runat="server"></asp:Label>
                                                                    <br>
                                                                    <strong>Year: </strong>
                                                                    <asp:Label ID="lblYear" runat="server"></asp:Label><br>
                                                                    <strong>Price: </strong>
                                                                    <asp:Label ID="lblPrice" runat="server" class="detPrice2"></asp:Label>
                                                                    <br>
                                                                </td>
                                                                <td valign="top">
                                                                    <strong>Mileage: </strong><span class="detMileage">
                                                                        <asp:Label ID="lblMileage" runat="server"></asp:Label>
                                                                    </span>mi<br>
                                                                    <strong>Exterior Color: </strong>
                                                                    <asp:Label ID="lblExteriorColor" runat="server"></asp:Label><br>
                                                                    <strong>Interior Color: </strong>
                                                                    <asp:Label ID="lblInteriorColor" runat="server"></asp:Label><br>
                                                                    <strong>Vehicle Condition: </strong>
                                                                    <asp:Label ID="lblVehicleCondition" runat="server"></asp:Label><br>
                                                                    <strong>VIN: </strong>
                                                                    <asp:Label ID="lblVIN" runat="server"></asp:Label><br>
                                                                    <strong>Rear: </strong>
                                                                    <asp:Label ID="lblRear" runat="server"></asp:Label>
                                                                    <br>
                                                                    <strong>Axle: </strong><span>
                                                                        <asp:Label ID="lblAxle" runat="server"></asp:Label>
                                                                    </span>
                                                                    <br>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div class="clear">
                                                    </div>
                                                </div>
                                                <!-- Disc End -->
                                                <div class="clear">
                                                    &nbsp;
                                                </div>
                                                <div class="SellerNotes">
                                                    <br>
                                                    <h3 class="h3b">
                                                        Description:
                                                    </h3>
                                                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                                    <br />
                                                    <br />
                                                    <p class="Comfort" style="padding: 0; margin: 0">
                                                        <asp:DataList ID="dlFeature" runat="server">
                                                            <HeaderTemplate>
                                                                <h3 class="h3b">
                                                                    Car Specifications</h3>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <strong>
                                                                    <%# DataBinder.Eval(Container.DataItem, "FeatureTypeName")%>" </strong>
                                                                <%# DataBinder.Eval(Container.DataItem, "FeatureName")%>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                     
                                                    </p>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;
                                                </div>
                                            </div>
                                            <a name='photos' />
                                            <div style="background: #fff">
                                                <!-- Slider Start  -->
                                                <div class="sliderHolder" style="margin: 0 auto; width: 100%">
                                                    <br />
                                                    <h3 class="h3 h3b" id="carDet">
                                                        <span class="detPrice">Vehicle Photos</span></h3>
                                                    <asp:Repeater ID="Repeater2" runat="server">
                                                        <HeaderTemplate>
                                                            <ul>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <li>
                                                                <asp:Image ID="ImgURL" class="slide1b" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PICPATH")%>'
                                                                    AlternateText='<%# DataBinder.Eval(Container.DataItem, "PICDesc")%>' runat="server" />
                                                                <asp:HiddenField ID="hdnFlddesc" runat="server" />
                                                            </li>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </ul>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                </div>
                                                <!-- Slider End  -->
                                                <div class="clear">
                                                </div>
                                                <!--    <strong>Surrounding towns:</strong>
                                                        <asp:Label ID="lblSurrounding" runat="server"></asp:Label>
                                                        <br>
                                                        <strong>Near by zip codes:</strong>
                                                        <asp:Label ID="lblNearbyzipcodes" runat="server"></asp:Label>
                                                        <br>-->
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <!-- Car Details Div  End  -->
                        <div class="clear">
                            &nbsp;</div>
                    </div>
                    <!-- Details End  -->
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
    <!-- Gallery Start -->
    <div class="galleryHolder">
        <div class="gallery1">
            <table style="width: 100%">
                <tr>
                    <td colspan="2" valign="top">
                        <h2>
                            <asp:Label ID="lblTitlePopUp" runat="server"></asp:Label> - 
                            <asp:Label ID="lblprice3" runat="server" class="detPrice"></asp:Label>                            
                            <a href='#' class='galClose'>&nbsp;</a>
                            <span style="display:inline-block; text-align:right; float:right; margin-right:20px;">
                            <b style="font-weight:normal; font-size:16px;">Phone: </b> 
                            <asp:Label ID="lblSellerNo2" runat="server" style="color:#fff" ></asp:Label>
                            </span>
                        </h2>
                    </td>
                </tr>
                <tr>
                    <td class="gal">
                        <!-- Slider Start  -->
                        <div id="galleria" style="width: 98%;">
                            <asp:Repeater ID="Repeater1" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:Image ID="ImgURL" class="slide1b" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PICPATH")%>'
                                            AlternateText='<%# DataBinder.Eval(Container.DataItem, "PICDesc")%>' runat="server" />
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- Slider End  -->
                    </td>
                    <td class="discHolder">
                        <h3>
                            Specifications</h3>
                        <label>
                            <strong>New/Used</strong>Used</label>
                        <label>
                            <strong>Year</strong>
                            <asp:Label ID="lblYear1" runat="server"></asp:Label>
                        </label>
                        <label>
                            <strong>Type</strong>
                            <asp:Label ID="lblType1" runat="server"></asp:Label>
                            <span class="type"></span>
                        </label>
                        <label>
                            <strong>Category</strong>
                            <asp:Label ID="lblCategory1" runat="server"></asp:Label>
                            <span class="category"></span>
                        </label>
                        <label>
                            <strong>Make</strong>
                            <asp:Label ID="lblMake1" runat="server"></asp:Label>
                            <span class="make"></span>
                        </label>
                        <label>
                            <strong>Model</strong>
                            <asp:Label ID="lblModel1" runat="server"></asp:Label>
                            <span class="model"></span>
                        </label>
                        <label>
                            <strong>Location</strong>
                            <asp:Label ID="Label5" runat="server"></asp:Label>
                            <span class="location"></span>
                        </label>
                        <label>
                            <strong>Condition</strong>
                            <asp:Label ID="lblCondition1" runat="server"></asp:Label>
                            <span class="condition"></span>
                        </label>
                        <div class="clear H20">
                            &nbsp;</div>
                        <h3>
                            Description</h3>
                        <p class="imgDisc">
                        </p>
                    </td>
                </tr>
            </table>
            <div class="clear">
                &nbsp;</div>
        </div>
    </div>
    
    
    <!-- Contact Us Popup start-->
    <cc1:ModalPopupExtender ID="MpeEmail" runat="server" PopupControlID="Loginholder1"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEmail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEmail" runat="server" />
    <div id="Loginholder1" runat="server" style="display: none;">
        <div id="login" class="loginForm1">
            <h1 class="title">
                Email the Seller <a href="#" class="cls">X</a>
            </h1>
            <div style="">
                <div style="width: 100px; float: left;">
                    <strong>To:</strong></div>
                <div style="width: 380px; float: left;">
                    <b>
                        <asp:Label ID="lblSellarname2" runat="server"></asp:Label></b>
                    <br />
                    <asp:Label ID="lblSellarAddress" runat="server"></asp:Label></b>
                    <br />
                    <asp:Label ID="lblphone" runat="server"></asp:Label>
                </div>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <br />
            <div class="clear">
                &nbsp;</div>
            <div style="">
                <div style="width: 100px; float: left;">
                    <strong>From: </strong>
                </div>
                <div style="width: 380px; float: left;">
                    <asp:TextBox ID="txtcemail" alt="my email address*" MaxLength="253" size="20" runat="server"
                        ToolTip="my email address*" Text="my email address" class="default-value" /></div>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <br />
            <div class="clear">
                &nbsp;</div>
            <div style="font-size: 12px;">
                <div id="leadFormHolder">
                    <div id="leadFormContentDiv">
                        <div>
                            <div id="Div1">
                                <div>
                                    <p>
                                        Hello!<br>
                                        I'm writing from
                                        <asp:TextBox runat="server" ID="zipCode1" MaxLength="25" ToolTip="Zip or City" Text="Zip or City"
                                            class="default-value" />
                                        and I'm interested in the <strong>
                                            <asp:Label ID="lblCartitle" runat="server"></asp:Label>
                                        </strong>you have listed on UnitedCarExchange.com for <strong>
                                            <asp:Label ID="Label1" runat="server" class="detPrice"></asp:Label>
                                        </strong>.<br />
                                        I would like to know more about this vehicle. I can be reached by phone on
                                        <label id="fitbOnePhone" style="display: none;">
                                            my phone number:</label><asp:TextBox ID="txtPhone" value="" size="16" runat="server"
                                                alt="my phone number*" ToolTip="my phone number*" Text="my phone number" class="default-value sample4"
                                                MaxLength="10" /><a href="javascript:void(0);" tabindex="-1" style="display: none;"></a>.<br>
                                    </p>
                                    <div>
                                        Thanks!<br>
                                        <!-- First Name -->
                                        <label class="fitbPrompt" style="display: none;">
                                            first name:</label><asp:TextBox ID="txtfirstName" size="8" Text="First Name" runat="server"
                                                class="default-value" MaxLength="50" /><a href="javascript:void(0);" tabindex="-1"
                                                    style="display: none;"></a>
                                        <!-- Last Name -->
                                        <label class="fitbPrompt" style="display: none;">
                                            last name:</label><asp:TextBox runat="server" size="8" ID="txtlastName" Text="Last Name"
                                                class="default-value" MaxLength="50" /><a href="javascript:void(0);" tabindex="-1"
                                                    style="display: none;"></a>
                                    </div>
                                    <br>
                                    Provide Additional Comments:<br />
                                    <!-- comments -->
                                    <asp:TextBox ID="txtComments" runat="server" Text="Enter your message here" class="default-value"
                                        TextMode="MultiLine"></asp:TextBox>
                                    <!-- Trade-IN fields -->
                                    <p>
                                    </p>
                                </div>
                                <!-- end message -->
                            </div>
                            <!-- end email -->
                        </div>
                    </div>
                </div>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <br />
            <div class="clear">
                &nbsp;</div>
            <div style="">
                <div style="width: 100px; float: left;">
                    &nbsp;
                </div>
                <div style="width: 380px; float: left;">
                    <div style="width: 70px; float: left">
                        <asp:Button runat="server" ID="zipValBut" class="floatL button1" Text="Ok" OnClientClick="javascript:return ValidateContact();"
                            OnClick="zipValBut_Click" />
                    </div>
                    <div style="width: 90px; float: left">
                        <input type="button" class="floatL button1" id="btnCancelPW" value="Cancel" onclick="javascript:return cancel1();" /></div>
                </div>
            </div>
        </div>
    </div>
    <!-- Gallery End -->
    
    
      <!--Subscribe Us Popup start-->
    <cc1:ModalPopupExtender ID="mpealert" runat="server" PopupControlID="alertholder"
        TargetControlID="hdnfldalert" CancelControlID="btnOk1" BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnfldalert" runat="server" />
    <div id="alertholder" runat="server" style="display: none">
        <div id="ZipVal" class="loginForm1">
            <h1 class="title">
                alert <a href="#" class="cls">X</a>
            </h1>
            <table style="width: 98%; margin: 0 auto">
                <tr>
                    <td style="width: 95px;" colspan="2">
                        <asp:UpdatePanel ID="updpanel" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblAlertMsg" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 5px;" colspan="2">
                        <div style="width: 34px; margin: 30px auto 0 auto">
                            <asp:Button ID="btnOk1" runat="server" class="button1" Text="Ok" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>

    <script src="js/jquery.paginate.js" type="text/javascript"></script>

    <script type="text/javascript">


        function scrollToAnchor(aid) {
            var aTag = $("a[name='" + aid + "']");
            $('html,body').animate({ scrollTop: aTag.offset().top }, 0);
        }




        $(function() {
            $("#bigImg").click(function() {
                scrollToAnchor('ph');
            });

            $('a').each(function() {
                if ($(this).attr('href') == '#') {
                    $(this).attr('href', 'javascript:void(0)')
                }
            });


        });	
    
    
   
    </script>

</body>
</html>
