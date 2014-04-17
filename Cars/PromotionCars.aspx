<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PromotionCars.aspx.cs" Inherits="PromotionCars"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Search Used Cars, Buy & Sell Used Cars and New Cars Online at UnitedCarExchange.com
    </title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="http://www.unitedcarexchange.com/promotion/css.css" rel="stylesheet"
        type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="http://www.unitedcarexchange.com/promotion/jquery.min.js"></script>

    <script type="text/javascript" src="http://www.unitedcarexchange.com/promotion/jquery.easing.1.3.js"></script>

    <script type="text/javascript" src="http://www.unitedcarexchange.com/promotion/jquery.vticker.js"
        charset="utf-8"></script>

    <script src="http://UnitedCarExchange.com/js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="http://UnitedCarExchange.com/js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function pageLoad() {
            $('.price1').formatCurrency();
            GetRecentListings();
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptMgr" runat="server">
    </cc1:ToolkitScriptManager>
    <!-- Main-bg start  -->
    <div id="main-bg">
        <!-- MAin Start  -->
        <div id="main">
            <!-- HEadder Start  -->
            <div id="header">
                <a href="http://UnitedCarExchange.com">
                    <img src="http://UnitedCarExchange.com/images/logo2.png" id="logo" alt=""></a>
                <div class="loginStat">
                    <uc2:LoginName ID="LoginName1" runat="server" />
                </div>
                <div id="menu">
                    <uc3:CarsHeader ID="CarsHeader1" runat="server" />
                </div>
                <div id="search-box">
                    <div class="inner">
                        <div id="searchFormHolder" class="wrapper">
                            <div class="clear dummyHeight8">
                                &nbsp;</div>
                            <div style="color: #fff; font-size: 35px; font-weight: bold; margin: 60px 0 30px -2px;
                                padding: 0; line-height: 35px; text-shadow: 1px 2px 0 rgba(0,0,0,0.3)">
                                Sell your <strong style="font-size: 40px;">USED CAR</strong></div>
                            <div class="banData">
                                <h4>
                                    Advertise</h4>
                                for as low as $24.99 to Reach<br />
                                15 million plus online customers
                            </div>
                            <asp:LinkButton class="sellMyCar" runat="server" PostBackUrl="http://UnitedCarExchange.com/Packages.aspx">
                                <img src="http://www.unitedcarexchange.com/images/sellmycarToday.png" /></asp:LinkButton>
                        </div>
                        <%--www.unitedcarexchange.com/Packages.aspx--%>
                        <!-- <b><a href="#" onclick="document.getElementById('car-form').submit()"></a></b> -->
                    </div>
                </div>
                <div id="loopedSlider">
                    <div class="container">
                        <img src="http://www.unitedcarexchange.com/images/slides/image-08.jpg" width="630"
                            height="389">
                    </div>
                </div>
            </div>
            <!-- Headder End  -->
            <div class="clear">
                &nbsp;</div>
            <!-- Content Strt  -->
            <div id="content">
                <h1 class="h1">
                    USED CARS IN
                    <asp:Label ID="lblCity" runat="server"></asp:Label>,&nbsp;<asp:Label ID="lblState"
                        runat="server"></asp:Label>
                </h1>
                <!-- featured start -->
                <div class="featured">
                    <asp:Repeater ID="rptrCarsbyState" runat="server" OnItemDataBound="rptrModels_ItemDataBound">
                        <ItemTemplate>
                            <div class="list">
                                <asp:HyperLink ID="lnbtnTitle" runat="server">
                                    <asp:Image runat="server" class="thumb" ID="imgSimliar"></asp:Image>
                                    <div class="data1">
                                        <asp:Label ID="lnkTitle" runat="server" class="makeModel"></asp:Label>
                                        <asp:Label ID="lblprice" runat="server" class="price1">
                                        </asp:Label>
                                    </div>
                                </asp:HyperLink>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!-- featured End -->
            </div>
            <!-- Content End -->
            <div class="clear">
                &nbsp;</div>
        </div>
        <!-- mAin End  -->
        <div class="footerContent">
            <div class="main">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 255px; vertical-align: top">
                            <h3>
                                <span>Recently</span> Listed</h3>
                            <!-- Resent Listing  Ticker Start  -->
                            <div class="ticker1" style="overflow: hidden; position: relative; height: 355px;
                                top: 0px; left: 0px;">
                                <ul>
                                </ul>
                            </div>
                            <!-- Resent Listing  Ticker End  -->
                        </td>
                        <td>
                            <h4>
                                Best way to sell your used car in
                                <asp:Label ID="lblState1" runat="server"></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblCity1" runat="server"></asp:Label>- Welcome to United Car Exchange</h4>
                            <p>
                                Are you looking to sell your used car in
                                <asp:Label ID="lblState2" runat="server"></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblCity2" runat="server"></asp:Label>
                                then you are at the right place. We answer all car buyer and seller needs. United
                                Car Exchange is America's most trusted Online Buy & Sell used car agency.United
                                Car Exchange helps in providing an online platform where car buyers and sellers
                                can search, buy, sell and come together to talk about their Used/ New Cars.
                            </p>
                            <p>
                                United Car Exchange lists detailed pricing information, description, dealer details,
                                monthly calculator tools, photo galleries and customer reviews which helps car buyers
                                with the information they need to make confident buying decisions.
                                <h2 style="font-size: 13px; font-weight: normal; margin: 4px 0">
                                    <b>Tags: </b>&nbsp;<a href="http://unitedcarexchange.com/Packages.aspx" target="_blank"
                                        style="color: #333; text-decoration: none;">Best way to sell my used car</a>&nbsp;
                                    | &nbsp; <a href="http://unitedcarexchange.com/Packages.aspx" target="_blank" style="color: #333;
                                        text-decoration: none;">Fastest way to sell my used car</a>&nbsp; | &nbsp; <a href="http://unitedcarexchange.com/Packages.aspx"
                                            target="_blank" style="color: #333; text-decoration: none;">How to sell my used
                                            car</a>&nbsp; | &nbsp; <a href="http://unitedcarexchange.com/Packages.aspx" target="_blank"
                                                style="color: #333; text-decoration: none;">Used Car for sale</a>
                                </h2>
                            </p>
                            <div class="clear">
                                &nbsp;</div>
                            <!-- Add Start -->
                            <div class="box3">
                                <div class="wrapper">
                                    <table style="width: 100%;">
                                        <tbody>
                                            <tr>
                                                <td style="width: 65%; border-right: #fedaa0 1px dotted; padding: 10px;">
                                                    <h3 class="h3">
                                                        Sell Your Car - Easy &amp; Fast!</h3>
                                                    <p>
                                                        More then a million cars sold, already - Advertise with us.</p>
                                                    <asp:Button ID="LinkButton1" Text="LIST YOUR CAR NOW" class="button1" runat="server"
                                                        PostBackUrl="http://UnitedCarExchange.com/Packages.aspx" />
                                                </td>
                                                <td style="padding: 10px;">
                                                    <h3 class="h3">
                                                        Used Cars Advertising</h3>
                                                    <i class="i1">We help you grow your business</i><div class="clear">
                                                    </div>
                                                    View our
                                                    <asp:LinkButton ID="Button1" Text="Advertising Plans" class="aa" runat="server" PostBackUrl="http://UnitedCarExchange.com/Packages.aspx" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <!-- Ad End  -->
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="main">
            <!-- Footer Start  -->
            <div id="footer">
                <uc1:Footer ID="Footer1" runat="server" />
            </div>
            <!-- Footer End -->
        </div>
    </div>
    <!-- MAin-bg end -->

    <script type="text/javascript">
        $(function() {
            $('.ticker1').vTicker({
                speed: 500,
                pause: 3000,
                animation: 'fade',
                mousePause: true,
                showItems: 4
            });

        });
    </script>

    </form>
</body>
</html>
