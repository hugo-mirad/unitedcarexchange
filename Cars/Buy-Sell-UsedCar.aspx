<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Buy-Sell-UsedCar.aspx.cs"
    Inherits="SearchCarDetails" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title></title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../css/tabbed.css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <link href="../css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="../css/svwp_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../js/jquery-1.7.min.js"></script>

    <script src="../js/jquery.tipsy.js" type="text/javascript"></script>

    <script type="text/javascript" src="../js/cufon-yui.js"></script>

    <script type="text/javascript" src="../js/jquery.vticker.js"></script>

    <script type="text/javascript" src="../js/jquery.slideViewerPro.1.5.js"></script>

    <script type="text/javascript" src="../js/jquery.timers.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="../js/tooltips.js" type="text/javascript"></script>

    <script src="../js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='../js/jquery.alphanumeric.pack.js'></script>

    <script src="../js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
    var models;
    LoadingPage = 3;
    //var ZipCodes = [];
     var make1='All makes' ;
    var Modal1='All models';
    var ZipCode1='' ;
    var WithinZipNew = 4;
    
    var CarID1;

       
    
    function pageLoad() {

        //var path1 = "http://localhost:4111/Cars/2011/Alfa Romeo/8C Competizione/Index.aspx"

        
        GetRecentListings();  
        GetMakes();
        GetModelsInfo();
        //WithinZipBinding();


        $('.price100').formatCurrency();
        
        $('.mele100').formatCurrency({ symbol: ' ' });
        
        var settings = { start: 1, change: false };
        
        $("#adv1 ul").idTabs(settings, true);

        $(function() {$('.sample4').numeric({ allow: "-" });})
        $('.ldrgif').hide();
        

    }


   
    
    
    
    </script>

    <script type="text/javascript" language="javascript">
            function echeck(str) {
                var at = "@"
                var dot = "."
                var lat = str.indexOf(at)
                var lstr = str.length
                var ldot = str.indexOf(dot)
                if (str.indexOf(at) == -1) {
                    alert("Enter valid email")
                    return false
                }

                if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
                    alert("Enter valid email")
                    return false
                }

                if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
                    alert("Enter valid email")
                    return false
                }

                if (str.indexOf(at, (lat + 1)) != -1) {
                    alert("Enter valid email")
                    return false
                }

                if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
                    alert("Enter valid email")
                    return false
                }

                if (str.indexOf(dot, (lat + 2)) == -1) {
                    alert("Enter valid email")
                    return false
                }

                if (str.indexOf(" ") != -1) {
                    alert("Enter valid email")
                    return false
                }

                return true
            }
    </script>

    <script type="text/javascript">
    
    
        $(function(){
             $('.linkClient').each(function(){
                    $(this).attr('href', 'http://secondcarloans.com/Apply.aspx?a='+$('#hdnCarid').val());
                   // window.location.href = ';
              });
        })
    

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

            
            make1 = $.trim($('#Hmake').text());
            Modal1 = $.trim($('#Hmodel').text());
            ZipCode1 = parseInt($.trim($('#Hzip').val()));
            //$('#yourZip').val($('#Hzip').val());
            WithinZipNew = 4;
            
            var settings = { start: 1, change: false };
            $("#adv1 ul").idTabs(settings, true);


            $('.detPrice,.detMileage,.detPrice1').formatCurrency();
            $('.detMileage').formatCurrency({ symbol: ' ' });

            
            var totalImages = $('div#basic2 ul li').length;
            ////console.log(totalImages);
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

                    ////console.log(img.width()+", "+img.height()); 

                    if (totalImages <= 1) {
                        // Slider2
                        ////console.log(totalImages);
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
            ////console.log('Email Send');
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
            
           // $('#hdnCarid').val(); http://secondcarloans.com/Apply.aspx linkClient
         


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

    <!-- Look at the configuration -->

    <script src="../js/watermark.js" type="text/javascript"></script>
    

</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://www.UnitedCarExchange.com/Default.aspx">
                        <img src="http://www.UnitedCarExchange.com/images/logo2.png" id="logo" alt="" /></a>
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
                        <!-- column Left Div Start  -->
                        <div id="column-left">
                            <div class="indent" style="padding-top: 5px;">
                                <div class="wrapper">
                                    <!-- Recent Used Car Listings  start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Recent Used Car Listings</h3>
                                        <em class="i1">Most recent Used Cars listed for sale</em>
                                        <!-- Ticker1 Div Start  -->
                                        <div class="ticker1">
                                            <ul>
                                            </ul>
                                        </div>
                                        <!-- Ticker1 Div End  -->
                                    </div>
                                    <!-- Recent Used Car Listings end  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div id="div250X250" runat="server" style="padding: 3px; margin: 5px auto; width: 250px;
                                        height: 250px">
                                    </div>
                                    <div id="lBrandAds2" style="padding: 3px; margin: 5px auto;">
                                        <!-- Begin: adBrite, Generated: 2012-05-09 5:53:51  -->
                                        <style type="text/css">
                                            .adHeadline
                                            {
                                                font: bold 10pt Arial;
                                                text-decoration: underline;
                                                color: #0000FF;
                                            }
                                            .adText
                                            {
                                                font: normal 10pt Arial;
                                                text-decoration: none;
                                                color: #000000;
                                            }
                                        </style>

                                        <script type="text/javascript">
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads End -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Advantage of Buying Used Cars Start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Advantage of Buying Used Cars
                                        </h3>
                                        <em class="i1">Must read tips &amp; advices on Used Cars</em><br />
                                        <ul class="bullet" style="margin-left: 10px;">
                                            <li><a href="../tips.aspx">Used Car buying tips</a></li>
                                        </ul>
                                    </div>
                                    <!-- Advantage of Buying Used Cars End -->
                                </div>
                            </div>
                        </div>
                        <!-- column Left Div End  -->
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <!--  -->
                                    <div class="info-box" style="padding: 0">
                                        <div class="wrapper">
                                            <div style="width: 99%; margin: 0 auto; padding: 10px; background: #e7e7e7;">
                                                <div class="width-1" style="width: 130px;">
                                                    <div class="black">
                                                        Make</div>
                                                    <select id="make" tabindex="1">
                                                        <option>Loading...</option>
                                                    </select>
                                                </div>
                                                <div class="width-1" style="width: 260px;">
                                                    <div class="black">
                                                        Model</div>
                                                    <select id="model" style="width: 265px;" tabindex="2">
                                                        <option>Loading...</option>
                                                    </select>
                                                </div>
                                                <div class="width-1" style="width: 90px">
                                                    <div class="black">
                                                        Within</div>
                                                    <select id="within" style="width: 95px" tabindex="3">
                                                    </select>
                                                </div>
                                                <div class="width-1" style="width: 60px">
                                                    <div class="black">
                                                        ZIP</div>
                                                    <input type="text" id="yourZip" class="zip sample4" maxlength="10" style="width: 50px"
                                                        runat="server" tabindex="4" />
                                                </div>
                                                <div style="margin-top: 27px; margin-left: 7px; float: left; width: 80px;">
                                                    <a href="javascript:search();">
                                                        <img src="http://www.UnitedCarExchange.com/images/searChButton.png" alt="" style="border: 1px solid #fff;
                                                            border-bottom: #999 1px solid; border-right: #999 1px solid" tabindex="5" />
                                                    </a>
                                                </div>
                                                <div class="clear">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- -->
                                </div>
                            </div>
                            <div id="div88X720" class="detailsAd" runat="server" style="height: 88px; width: 707px; margin: 0 auto;
                                border: #999 1px solid; padding: 1px; background: white;">
                            </div>
                            <!-- Results Start -->
                            <div style="width: 97%; margin: 0px auto;" id="carDetailsDivHolder">
                                <table style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td style="line-height: 20px">
                                                <table style="width: 100%; margin-top: 25px;">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="2">
                                                                <h3 class="h3 h3b" id="carDet">
                                                                    
                                                                    
                                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>                                                                  
                                                                   
                                                                    <asp:Label ID="LabelSubtitle" runat="server"></asp:Label>
                                                                      <asp:Label ID="lblPrice1" runat="server" class="detPrice"></asp:Label>
                                                                   
                                                                </h3>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:UpdatePanel ID="updpnl" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="soldCar" id="soldCar" runat="server" style="margin: 20px 0 10px 0; padding: 15px;
                                                                            border: #d9a863 3px dashed; background: #fffed1">
                                                                            <h2 style="color: #777; font-size: 26px;">
                                                                                <img id="sold" runat="server" visible="false" src="http://www.UnitedCarExchange.com/images/sold_out_stamp.gif"
                                                                                    style="float: right">
                                                                                Sorry..!<br />
                                                                                <asp:Label ID="lblCarsoldStatus" runat="server"></asp:Label>
                                                                            </h2>
                                                                            <div class="clear">
                                                                                &nbsp;</div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: auto; vertical-align: top">
                                                                <div class="sellerInfo1">
                                                                    <strong>Phone: &nbsp;</strong><asp:Label runat="server" ID="lblSellerNo"></asp:Label>
                                                                    <br />
                                                                    <strong>Email: &nbsp;</strong> <a id="mailsend" runat="server" href="javascript: emailSend()">
                                                                        Send an email to seller</a>
                                                                    <br />
                                                                </div>
                                                            </td>
                                                            <td style="vertical-align: top">
                                                                <div class="sellerInfo2">
                                                                    <asp:Label Style="text-transform: capitalize;" ID="lblSellerAddress" runat="server">
                                                                    </asp:Label>
                                                                    <asp:HiddenField ID="hdnCarid" runat="server"></asp:HiddenField>
                                                                    <asp:HiddenField ID="zipcode" runat="server" />
                                                                    <asp:Label ID="lblSellerAddress2" Style="display: none; text-transform: capitalize;"
                                                                        runat="server">
                                                                        <br />
                                                                        
                                                                    </asp:Label>
                                                                    <br />
                                                                    <strong>Seller Type: </strong>
                                                                    <asp:Label ID="lblSellerType" runat="server">
                                                                    </asp:Label>
                                                                    <br />
                                                                    <strong style="display: none">Seller Name: </strong>
                                                                    <asp:Label ID="lblSellerName" Style="display: none" runat="server">
                                                                        
                                                                    </asp:Label>
                                                                    <br />
                                                                    <!-- AddThis Button BEGIN -->
                                                                    
                                                                   
                                                                                      

                                                                    <script type="text/javascript">                                                                        var addthis_config = { "data_track_addressbar": true };</script>

                                                                    <script type="text/javascript" src="http://s7.addthis.com/js/300/addthis_widget.js#pubid=ra-50779dc47dd738eb"></script>

                                                                    <!-- AddThis Button END -->
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        
                                                    </tbody>
                                                </table>
                                                <div id="carDet0">
                                                </div>
                                            </td>
                                            <td align="right" valign="top">
                                                <h3>
                                                    <a href="javascript:history.go(-1)" style="font-size: 13px;">« Back</a></h3>
                                            </td>
                                        </tr>
                                        <tr>
                                                        <td colspan=2>
                                                        <table style="float:right;">
                                                                    <tr>
                                                                    <td style="text-align:right;vertical-align:middle;">
                                                                     <a class="addthis_button" href="http://www.addthis.com/bookmark.php?v=300&amp;pubid=ra-50779dc47dd738eb">
                                                                        <img src="http://s7.addthis.com/static/btn/v2/lg-share-en.gif" width="125" height="16"
                                                                            alt="Bookmark and Share" style="border: 0" /></a>
                                                                    </td>
                                                                    <td style="text-align:right; width:10px;">&nbsp;</td>
                                                                    <td style="text-align:right;vertical-align:middle;">
                                                                        <a href="" ID="LinkAdd1" runat="server" Class="linkClient"  target="_blank" ><img src="http://unitedcarexchange.com/images/Eligible1.png" /></a>
                                                                        <a href="" ID="linkAdd2" runat="server" Class="linkClient" target="_blank" ><img src="http://unitedcarexchange.com/images/Eligible2.png" /></a>
                                                                        <a href="" ID="LinkAdd3" runat="server" Class="linkClient" target="_blank" ><img src="http://unitedcarexchange.com/images/Eligible3.png" /></a>
                                                                   
                                                                    </td>
                                                                    </tr>
                                                                    </table>
                                                        
                                                        </td>
                                                        </tr>
                                    </tbody>
                                </table>
                                <!-- Car Details Div Start -->
                                <div id="adv1" class="usual">
                                    <ul>
                                        <li class="tab1"><a href="javascript:void(0);#t1 " class="selected">Vehicle Description</a></li>
                                        <li class="tab1" id="bigImg"><a class="" href="javascript:void(0);#t2">Photos</a></li>
                                    </ul>
                                    <div style="display: block;" id="t1">
                                        <!-- Slider Start  -->
                                        <div class="sliderHolder2" style="width: 260px;float: left;">
                                            <div id="basic" class="svwp2">
                                                <ul>
                                                    <li>
                                                        <asp:Image ID="img" runat="server" class="slide1a" />
                                                    </li>
                                                    <!--eccetera-->
                                                </ul>
                                            </div>
                                        </div>
                                        <!-- Slider End  -->
                                        <!-- Disc Start -->
                                        <div class="disc">
                                            <h3 class="h3a">
                                                About This
                                                <asp:Label ID="lblSubTitle" runat="server"></asp:Label>
                                                <br />
                                            </h3>
                                            <table style="width: 99%; margin: 0" id="carDet1">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 50%; vertical-align: top">
                                                            <strong>Make: </strong>
                                                            <asp:Label ID="lblMake" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Model: </strong>
                                                            <asp:Label ID="lblModel" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Year: </strong>
                                                            <asp:Label ID="lblYear" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Body Style: </strong>
                                                            <asp:Label ID="lblBodyStyle" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Exterior Color: </strong>
                                                            <asp:Label ID="lblExteriorColor" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Interior Color: </strong>
                                                            <asp:Label ID="lblInteriorColor" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Doors: </strong>
                                                            <asp:Label ID="lblDoors" runat="server"></asp:Label><br />
                                                            <strong>Vehicle Condition: </strong>
                                                            <asp:Label ID="lblVehicleCondition" runat="server"></asp:Label>
                                                            <br />
                                                        </td>
                                                        <td valign="top">
                                                            <strong>Price: </strong>
                                                            <asp:Label ID="lblPrice" runat="server" class="detPrice1"></asp:Label><br />
                                                            <strong>Mileage: </strong>
                                                            <asp:Label ID="lblMileage" runat="server" class="detMileage"></asp:Label>
                                                            <br />
                                                            <strong>Fuel: </strong>
                                                            <asp:Label ID="lblFuelType" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Engine:</strong>
                                                            <asp:Label ID="lblEngine" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>Transmission: </strong>
                                                            <asp:Label ID="lblTransMission" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>DriveTrain: </strong>
                                                            <asp:Label ID="lblDriveTrain" runat="server"></asp:Label>
                                                            <br />
                                                            <strong>VIN: </strong>
                                                            <asp:Label ID="lblVin" runat="server"></asp:Label>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <!-- Disc End -->
                                            <div class="clear">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div class="clear">
                                            &nbsp;
                                        </div>
                                        <div class="SellerNotes">
                                            <br />
                                            <p class="Comfort">
                                                <asp:DataList ID="dlFeature" runat="server">
                                                    <HeaderTemplate>
                                                        <h3 class="h3" style="padding: 0; margin: 0 0 4px 0">
                                                            Car Specifications</h3>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <strong>
                                                            <%# DataBinder.Eval(Container.DataItem, "FeatureTypeName")%>: </strong>
                                                        <%# DataBinder.Eval(Container.DataItem, "FeatureName")%>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <br />
                                                
                                                <p style="padding-top: 17px; padding-bottom: 14px;">
                                                    <strong style="font-size: 1.17em;">Description: </strong>
                                                    <asp:Label ID="lblDescription" runat="server" Text="">
                                                    </asp:Label>
                                                    <br />
                                                </p>
                                                <div class="clear">
                                                    &nbsp;</div>
                                                <strong style="float: left; padding-top: 4px;">Surrounding towns:&nbsp;</strong>
                                                <ul class="towns" style="font-size: 11px;" runat="server" id="ulTowns">
                                                </ul>
                                                <div style="clear: both; height: 5px; overflow: hidden">
                                                    &nbsp;</div>
                                                <br />
                                                <div class="clear">
                                                    &nbsp;</div>
                                                <asp:Label ID="lblNearbyzipcodes" Style="font-size: 11px;" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div style="display: none;" id="t2">
                                        <!-- Slider Start  -->
                                        <div class="sliderHolder">
                                            <div id="basic2" class="svwp">
                                                <asp:Repeater ID="Repeater2" runat="server">
                                                    <HeaderTemplate>
                                                        <ul>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <li>
                                                            <%--// Max width for the image //var max--%>
                                                            <asp:Image ID="ImgURL" class="slide1b" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "PICPATH")%>'
                                                                Width="680px" Height="452px" AlternateText='<%# DataBinder.Eval(Container.DataItem, "PIC")%>'
                                                                runat="server" />
                                                        </li>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </ul>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                                <asp:Label ID="lblError" runat="server"></asp:Label>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </div>
                                            <div class="clear">
                                                &nbsp;</div>
                                        </div>
                                        <!-- Slider End  -->
                                        <div class="clear">
                                        </div>
                                        <div class="clear">
                                        </div>
                                    </div>
                                    <div style="display: none;" id="t3">
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <h2 style="text-align: center">
                                            Coming soon...!</h2>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </div>
                            
                            <div class="clear">&nbsp;</div>
                            <br />
                            <div class="mostMatchedDiv" style="  clear:both; margin: 10px auto; padding:10px 0; border-top:#999 1px dashed; width: 96%; display:none; ">
                            
                            
                            <asp:HiddenField id="Hmake" runat="server"/>
                              <asp:HiddenField id="Hmodel" runat="server"/>
                                <asp:HiddenField id="HZip" runat="server"/>
                                  <asp:HiddenField id="HPrice" runat="server"/>
                                   <asp:HiddenField id="Hadd" runat="server"/>
                            <script type="text/javascript">
                            
                            
                            var dummyPrice = $('#HPrice').val()
                                if(!dummyPrice){
                                    dummyPrice = 10000;
                                }
                            //$('#yourZip').val($('#HZip').val());
                           // ZipCode1 = $('#HZip').val()
                              CarsMatchedData( $('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val(), dummyPrice  );
                              //console.log($('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val());
                             // selSearchCri($('#Hmake').val(), $('#Hmodel').val(), $('#HZip').val());
                              
                                  
                                  //lblPrice1
                               //CarsMatchedData( $('#make option:selected').val(), $('#model option:selected').val(), '19082', '68998'  );
                            </script>
                               <h2 style="font-size:22px; margin:0; padding:0; font-weight:normal;">Similar Cars</h2>
                                <ul class="list-1 matched left"></ul>
                            </div>
                            
                            
                            <!-- Car Details Div  End -->
                            <div style="clear: both; width: 95%; margin: 20px auto; display: none;">
                                <div style="padding: 10px">
                                    <h3 style="padding: 4px; margin-bottom: 0px; background: #EEE; line-height: 28px;
                                        padding: 4px;">
                                        Similar cars that may be of interest to you</h3>
                                    <asp:Repeater ID="dlSimilarResults" runat="server" OnItemCommand="dlSimilarResults_ItemCommand"
                                        OnItemDataBound="dlSimilarResults_ItemDataBound">
                                        <HeaderTemplate>
                                            <ul class="list-5">
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li>
                                                <asp:LinkButton ID="lnkTitle" runat="server" class="carName">
                                                    <asp:Image runat="server" class="thumb" Width="117px" Height="71px" ID="imgSimliar">
                                                    </asp:Image>
                                                    <h4>
                                                        <asp:Label ID="sTitle" runat="server" class="carName"></asp:Label>
                                                    </h4>
                                                    <p>
                                                        <asp:Label ID="lblDesc" runat="server">
                                                        </asp:Label>
                                                    </p>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                Price
                                                            </td>
                                                            <td>
                                                                <span class="price100">
                                                                    <%# DataBinder.Eval(Container.DataItem, "Price")%></span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Mileage
                                                            </td>
                                                            <td>
                                                                <span class="mele100">
                                                                    <%# DataBinder.Eval(Container.DataItem, "Mileage")%>
                                                                </span>mi
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br>
                                                    <br>
                                                </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul></FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <!-- Ads Section Start  -->
                        <%--    <div class="bottomAdd" style="margin-left: 1px;">
                                
                            </div>--%>
                            <!-- Ads Section Endt  -->
                        </div>
                        <!-- Results End -->
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
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none">
        <h4>
            <div>
                Processing
            </div>
        </h4>
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
                       <asp:Label ID="lblSellarname2" runat="server" Visible="false" ></asp:Label></b>
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
                                            <asp:Label ID="lblPrice3" runat="server" class="detPrice"></asp:Label>
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
    <!-- Contact Us Popup END-->
    <!--Subscribe Us Popup start-->
    <cc1:ModalPopupExtender ID="mpealert" runat="server" PopupControlID="alertholder"
        TargetControlID="hdnfldalert" BackgroundCssClass="ModalPopupBG">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnfldalert" runat="server" />
    <div id="alertholder" runat="server" style="display: none">
        <div id="ZipVal" class="loginForm1">
            <h1 class="title">
                alert <a href="#" class="cls" onclick="btnOk1_Click">X</a>
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
                            <asp:Button ID="btnOk1" runat="server" class="button1" Text="Ok" OnClick="btnOk1_Click" /></div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>

    <script type="text/ecmascript" language="javascript">


        $('a.viewA').click(function() {
            //alert($(this).next("span").attr('id'))
            $(this).hide();
            $(this).next("p").show();

        });
        
        $('#alert-holder .cls').click(function() {
            $('#alert-holder').hide();
        });
    
    
	/* var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];
	
	var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];  
	
	*/
	
	var within = ['10','25','50','100','Anywhere'];
	
	
	var slideImg = ['images/large/zr1review_01.jpg',
					'images/large/zr1review_02.jpg',
					'images/large/zr1review_03.jpg',
					'images/large/zr1review_04.jpg',
					'images/large/zr1review_05.jpg',
					'images/large/zr1review_06.jpg',
					'images/large/zr1review_07.jpg',
					'images/large/zr1review_08.jpg',
					'images/large/zr1review_09.jpg',
					'images/large/zr1review_10.jpg',
					'images/large/zr1review_11.jpg',
					'images/large/zr1review_12.jpg',
					'images/large/zr1review_13.jpg',
					'images/large/zr1review_14.jpg',
					'images/large/zr1review_15.jpg',
					'images/large/zr1review_16.jpg',					
					];
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
				 
				 
	$(function() {
	//$("div.svwp").prepend("<img src='http://www.UnitedCarExchange.com/images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		$('.sample4').numeric({allow:"-"});
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		//$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#model, #modelA, #modelB').attr('disabled',true);
		 $('#yourZip').removeAttr('disabled');
		
	
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('color','#ffb619').css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}			
			// $(this).parent().toggleClass('li-hover');
		});
		
		
		
		
				
		
		
		
		
		
		  // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		
		 
		 // Ads
		/*
		$('.ads1').empty();
		//return a random integer between 0 and 10		
		var ads = '';
		var imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		ads += "<div class='left-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		ads += "<div class='right-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		ads += "<div class='clear'>&nbsp;</div>";	
		imgPath = ad2[Math.floor(Math.random() * ad2.length)];		
		//ads += "<div class='horiz-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";	
		//ads += "<div class='clear'>&nbsp;</div>";
		$('.ads1').append(ads);
		*/
		
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
