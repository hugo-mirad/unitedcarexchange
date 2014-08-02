﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Premium.aspx.cs" Inherits="Premium" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title id="Title1" runat="server"></title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="css/grid-12.css" type="text/css" />

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/CarsJScript.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script type="text/javascript" language="javascript">
        function pageLoad() {

            GetRecentListings();

        }

        function pageLoad() {
            GetRecentListings();
        }
      
    </script>

    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-33253135-1']);
        _gaq.push(['_trackPageview']);

        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>

</head>
<body class="cssstyle-style1 menu-type-fusionmenu col12" id="all">
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
        <!-- content Start -->
        <div>
            <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px;"
                cellpadding="0" cellspacing="0">
                <tr>
                    <tr>
                        <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                            <div class="leftBox1">
                                 <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px; font-family:Arial; letter-spacing:0; text-transform:capitalize">
                        Recent Used Truck Listings</h2><small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                                <!-- Left Brand Ads Satrt -->
                                <div class="ticker1">
                                    <ul>
                                    </ul>
                                </div>
                                <div class="clear">
                                    &nbsp;</div>
                            </div>
                            <!-- Left Brand Ads Satrt -->
                            <!-- End: adBrite -->
                            <div class="clear">
                                &nbsp;</div>
                        </td>
                        <td style="vertical-align: top; padding-left: 10px;">
                            <!-- Right Content Start  -->
                            <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                            <!-- column Left Div End  -->
                            <div class="indent">
                                <div class="wrapper">
                                    <div id="column-right" class="column-indent">
                                        <div class="indent">
                                            <div class="wrapper">
                                                <div id="Div1" class="column-indent">
                                                    <div class="indent">
                                                        <div class="wrapper">
                                                            <table style="width: 100%; border-bottom: #ccc 1px solid; margin-bottom: 10px;" cellpadding="0"
                                                                cellspacing="0">
                                                                <tr>
                                                                    <td style="padding-right: 20px; padding-top: 10px;">
                                                                        <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #666; font-size: 16px; font-family:Arial; letter-spacing:0; text-transform:capitalize">
                        
                                                                            Select a Premium Package - Private Seller
                                                                        </h2>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div style="width: 100%; height: 2px; overflow: hidden">
                                                                &nbsp;</div>
                                                            <!-- Sell Packages Div Start -->
                                                            <div id="top" class="container_12" style="height: 630px">
                                                                <div class="newsflash">
                                                                    <!-- block first Start  -->
                                                                    <div class="block first " style="position: relative">
                                                                        <h4 class="newsflash-title" style="background: none">
                                                                        </h4>
                                                                        <p class="price" style="background: none">
                                                                        </p>
                                                                        <div style="position: absolute; top: 0px; left: 25px; width: 119px; height: 120px;">
                                                                            <%--<asp:ImageButton ID="ImgbtnSellcar" runat="server" ImageUrl="~/images/sellCar.jpg"
                                                    OnClick="ImgbtnSellcar_Click" />--%>
                                                                            <%-- <a href="Registar.aspx">
                                                        <img src="images/sellCar.jpg" alt="" /></a>--%>
                                                                        </div>
                                                                        <ul>
                                                                            <li class="first-child" style="height: 100px;">
                                                                                <h2 class="h33b">
                                                                                    Ad Details</h2>
                                                                            </li>
                                                                            <li style="height: 30px;">
                                                                                <h2 class="h33b">
                                                                                    Guarantees</h2>
                                                                            </li>
                                                                            <li style="height: 120px;">
                                                                                <h2 class="h33b">
                                                                                    Ad Exposure</h2>
                                                                            </li>
                                                                            <li style="height: 60px;">
                                                                                <h2 class="h33b">
                                                                                    Promotion Package</h2>
                                                                            </li>
                                                                            <li class="last-child" style="height: 60px;">
                                                                                <h2 class="h33b">
                                                                                    Enhanced</h2>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                    <!-- block first End  -->
                                                                    <!-- block first Start  -->
                                                                    <div class="block second ">
                                                                        <h4 class="newsflash-title">
                                                                            Truck Platinum Deluxe</h4>
                                                                        <p class="price" style="position: relative;">
                                                                            <span class="sign">$</span>299.99<span class="package-pricing"></span></p>
                                                                        <ul>
                                                                            <li class="first-child" style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Ad runs for 180 days<br />
                                                                                unlimited renewals<br />
                                                                                50 photos </a></li>
                                                                            <li style="height: 30px; line-height: 28px;"><a href="#" style="line-height: 18px;">
                                                                                None </a></li>
                                                                            <li style="height: 120px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Featured listing<br />
                                                                                Promotional placement<br />
                                                                                Spotlight Ad<br />
                                                                                Ad traffic report </a></li>
                                                                            <li style="height: 60px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Multi-site promotion</a></li>
                                                                            <li style="height: 60px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Ad Creation Consultant</a></li>
                                                                        </ul>
                                                                        <div class="add-cart">
                                                                            <br />
                                                                            <%--<a href="Registration.aspx"><span>Select</span></a>--%>
                                                                            <asp:Button ID="btnPremiumSilver" Style="border: none" runat="server" Text="Select"
                                                                                OnClick="btnPremiumSilver_Click" CssClass="button-blank button" />
                                                                        </div>
                                                                    </div>
                                                                    <!-- block first End  -->
                                                                    <!-- block second Start  -->
                                                                    <div class="block third">
                                                                        <h4 class="newsflash-title">
                                                                            Truck Presidents Package</h4>
                                                                        <p class="price" style="position: relative;">
                                                                            <span class="sign">$</span>399.99<span class="package-pricing"></span></p>
                                                                        <ul>
                                                                            <li class="first-child" style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Ad runs till it sells<br />
                                                                                50 photos<br />
                                                                                Video upload </a></li>
                                                                            <li style="height: 30px; line-height: 28px;"><a href="#" style="line-height: 18px;">
                                                                                Money back guarantee </a></li>
                                                                            <li style="height: 120px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Featured listing<br />
                                                                                Promotional placement<br />
                                                                                Spotlight Ad<br />
                                                                                Ad traffic report </a></li>
                                                                            <li style="height: 60px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Multi-site promotion</a></li>
                                                                            <li style="height: 60px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Ad Creation Consultant</a></li>
                                                                        </ul>
                                                                        <div class="add-cart">
                                                                            <br />
                                                                            <%--<a href="Registration.aspx"><span>Select</span></a>--%>
                                                                            <asp:Button ID="btnPremiumGold" Style="border: none" runat="server" Text="Select"
                                                                                OnClick="btnPremiumGold_Click" CssClass="button-blank button" />
                                                                        </div>
                                                                    </div>
                                                                    <!-- block second End  -->
                                                                    <!-- block thired Start  -->
                                                                    <div class="block fourth">
                                                                        <h4 class="newsflash-title">
                                                                            Truck VIP Package</h4>
                                                                        <p class="price" style="position: relative;">
                                                                            <span class="sign">$</span>499.99<span class="package-pricing"></span></p>
                                                                        <ul>
                                                                            <li class="first-child" style="height: 100px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Ad runs till it sells<br />
                                                                                50 photos<br />
                                                                                Video upload </a></li>
                                                                            <li style="height: 30px; line-height: 28px;"><a href="#" style="line-height: 18px;">
                                                                                Money back guarantee </a></li>
                                                                            <li style="height: 120px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Featured listing<br />
                                                                                Promotional placement<br />
                                                                                Spotlight Ad<br />
                                                                                Ad traffic report </a></li>
                                                                            <li style="height: 60px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Multi-site promotion<br />
                                                                                Social media: FB/G+ etc</a></li>
                                                                            <li style="height: 60px; line-height: 28px;"><a href="#" style="line-height: 28px;">
                                                                                Ad Creation Consultant<br />
                                                                                VIP Consultant Team</a></li>
                                                                        </ul>
                                                                        <div class="add-cart">
                                                                            <br />
                                                                            <%--  <a href="Registration.aspx"><span>Select</span></a>--%>
                                                                            <asp:Button ID="btnPremiumPlatinum" Style="border: none" runat="server" Text="Select"
                                                                                OnClick="btnPremiumPlatinum_Click" CssClass="button-blank button" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="clear">
                                                                    </div>
                                                                    <!-- block thired End  -->
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                                <!-- TOP POSITION -->
                                                            </div>
                                                            <!-- Sell Packages Div End -->
                                                            <div class="clear">
                                                            </div>
                                                            <!-- Box2 Div Start  -->
                                                        </div>
                                                    </div>
                                                    <!-- Results Start -->
                                                    <br />
                                                    <!-- Results End -->
                                                </div>
                                                <!-- Box2 Div Start  -->
                                                <!-- Box2 Div End  -->
                                                <div class="clear">
                                                </div>                                               
                                               
                                                <!-- Box2 Div Start  -->
                                                <div class="box3">
                                                    <div class="wrapper">
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td style="width: 65%; border-right: #fedaa0 1px dotted; padding: 10px;">
                                                                    <h2 class="h33a">
                                                                        Sell Your Truck- Easy & Fast With Our Premium Packages</h2>
                                                                    <p>
                                                                        Thousands of vehicles sold, already - Sign up for United Truck Exchange Premium
                                                                        Packages.</p>
                                                                    <input type="button" class="button1" value="Sign Up for Premium Packages" onclick="window.location.href='Premium.aspx' " />
                                                                </td>
                                                                <td style="padding: 10px;">
                                                                    <h2 class="h33a">
                                                                        Used Truck Advertising</h2>
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
                                                <!-- Ads Section Endt  -->
                                            </div>
                                        </div>
                                        <!-- Results Start -->
                                        <div class="bottomAdd" style="margin-left: 1px;">
                                            <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57  -->

                                            <script type="text/javascript">
                                                var AdBrite_Title_Color = '0000FF';
                                                var AdBrite_Text_Color = '000000';
                                                var AdBrite_Background_Color = 'FFFFFF';
                                                var AdBrite_Border_Color = 'CCCCCC';
                                                var AdBrite_URL_Color = '008000';
                                                try { var AdBrite_Iframe = window.top != window.self ? 2 : 1; var AdBrite_Referrer = document.referrer == '' ? document.location : document.referrer; AdBrite_Referrer = encodeURIComponent(AdBrite_Referrer); } catch (e) { var AdBrite_Iframe = ''; var AdBrite_Referrer = ''; }
                                            </script>

                                            <span style="white-space: nowrap;">

                                                <script type="text/javascript">                                                    document.write(String.fromCharCode(60, 83, 67, 82, 73, 80, 84)); document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2102343&zs=3732385f3930&ifr=' + AdBrite_Iframe + '&ref=' + AdBrite_Referrer + '" type="text/javascript">'); document.write(String.fromCharCode(60, 47, 83, 67, 82, 73, 80, 84, 62));</script>

                                                <a target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2102343&afsid=1">
                                                    <img src="http://files.adbrite.com/mb/images/adbrite-your-ad-here-leaderboard.gif"
                                                        style="background-color: #CCCCCC; border: none; padding: 0; margin: 0;" alt="Your Ad Here"
                                                        width="14" height="90" border="0" /></a></span>
                                            <!-- End: adBrite -->
                                        </div>
                                        <!-- Results End -->
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <!-- Box2 Div Start  -->
                                </div>
                            </div>
                        </td>
                    </tr>
            </table>
        </div>
    </div>
    <!-- content End -->
    <!-- <div class="push"></div>  -->
    <div class="clear">
        &nbsp;</div>
         <cc1:modalpopupextender id="mpeSuccessalert" runat="server" popupcontrolid="SuccessAlert"
            backgroundcssclass="ModalPopupBG" targetcontrolid="hdnsuccess" cancelcontrolid="Button1">
            </cc1:modalpopupextender>
        <asp:HiddenField ID="hdnsuccess" runat="server" />
        <div class="popupBody" style="display: block" id="SuccessAlert">
            <div>
                <h1 class="H2" style="padding:10px 0 20px 0">
                    ALERT!</h1>
                <p class="pp">
                    You have already Logged in UnitedTruckExchange.com. if you want to register again
                    with new username. You should logout or click proceed.
                </p>
                <asp:Button ID="btnProceed" class="button1 popBut" runat="server" Text="Proceed" Style="margin-left: 0; width:101px;"
                    OnClick="btnProceed_Click"></asp:Button>
                <asp:Button ID="Button1" class="button1 popBut" runat="server" Text="Cancel" Style="margin-left: 0;" />
                </asp:Button>
            </div>
        </div>
    <!-- Footer Start  -->
    <div class="footer">
    <uc3:TruckFooter ID="Footer1" runat="server" />
    </div>
    <!-- Footer End -->
    </form>
</body>
</html>
