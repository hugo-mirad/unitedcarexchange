<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlaceAdBankDetails1.aspx.cs"
    Inherits="PlaceAdBankDetails1" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />

    <script src="Static/JS/JSCardValidation.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/jquery.slideViewerPro.1.5.js"></script>

    <script type="text/javascript" src="js/jquery.timers.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
    var models;
    LoadingPage = 3;
    //var ZipCodes = [];
    /*
    function pageLoad() {
        GetMakes();
        GetModelsInfo();
        SearchedCar();
        WithinZipBinding();
       
       
    }
    */
    
    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

</head>
<body id="page1" onload="GetRecentListings()">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updtpnlSave"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                    <div class="loginStat">
                        <%-- Welcome &nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label>
                        <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" OnClick="lnkBtnLogout_Click"></asp:LinkButton>--%>
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
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div id="lBrandAds" style="width: 250px; height: 250px; padding: 3px; margin: 5px auto;
                                        text-align: center;">
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
                                    <!-- Advantage of Buying Used Cars Start -->
                                    <div class="leftBox1">
                                    </div>
                                    <!-- Advantage of Buying Used Cars End -->
                                </div>
                            </div>
                        </div>
                        <!-- column Left Div End  -->
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <!-- Vehicle Type Div Start -->
                                    <div class="box4">
                                        <table style="float: left; width: 350px;">
                                            <tr>
                                                <td style="padding-right: 20px; padding-top: 10px;">
                                                    <h2>
                                                        <asp:Label ID="lblHeadName" runat="server" Font-Size="16px"></asp:Label>
                                                        Payment Details
                                                    </h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="width: 340px; float: right; padding: 0; text-align: right;">
                                            <img src="images/Navigation4.jpg" />
                                        </div>
                                        <div class="clear">
                                            &nbsp;</div>
                                        <div style="border-top: #ccc 1px solid; padding: 10px 0 30px 0; width: 100%">
                                            <h3 style="text-align: right; float: right">
                                                <a href="RegisterPlaceAdPhotos.aspx">« Back To Vehicle Photos</a>
                                            </h3>
                                        </div>
                                        <div class="clear">
                                            &nbsp;</div>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 50%;
                                            float: left; margin: 0;">
                                            <tr>
                                                <td colspan="2">
                                                    <p style="margin: 5px 0; width: 100%;">
                                                        <strong class="hedBack">Credit Card Information</strong>
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 115px;">
                                                    Credit Card<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="CardType" runat="server" Style="width: 130px;">
                                                        <asp:ListItem Value="MasterCard" Text="MasterCard"></asp:ListItem>
                                                        <asp:ListItem Value="VisaCard" Text="Visa"></asp:ListItem>
                                                        <asp:ListItem Value="AmExCard" Text="American Express"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Card Holder Name<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="Span2">
                                                        <asp:TextBox ID="txtCardholderName" runat="server" MaxLength="25" Style="width: 200px"
                                                            CssClass="input1" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr id="methodOfContactEmail">
                                                <td>
                                                    Credit Card # <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:TextBox runat="server" ID="CardNumber" MaxLength="25" Style="width: 200px" CssClass="sample4 input1" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Expiry Date<span class="star">*</span>
                                                </td>
                                                <td colspan="2" align="left">
                                                    <asp:DropDownList ID="ExpMon" Style="width: 100px;" runat="server">
                                                        <asp:ListItem Value="0" Text="Select Month"></asp:ListItem>
                                                        <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                        <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                        <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                        <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                        <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                        <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                        <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                        <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                        <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                        <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                        <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                        <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    /
                                                    <asp:DropDownList ID="CCExpiresYear" Style="width: 100px" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    CVV# <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="Span1">
                                                        <asp:TextBox ID="cvv" MaxLength="3" Style="width: 30px" runat="server" CssClass="sample4 input1" />
                                                    </span>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 47%;
                                            margin: 0; float: right">
                                            <tr>
                                                <td colspan="2">
                                                    <p style="margin: 5px 0; width: 100%;">
                                                        <strong class="hedBack">Billing Address</strong>
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 70px;">
                                                    Name<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBillName" runat="server" MaxLength="25" CssClass="input1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Phone<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtBillPhone" MaxLength="10" CssClass="sample4 input1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="Span3">
                                                        <asp:TextBox ID="txtBillAddress" runat="server" MaxLength="40" CssClass="input1" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    City<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span>
                                                        <asp:TextBox runat="server" ID="txtBillCity" MaxLength="20" CssClass="input1" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    State<span class="star">*</span>
                                                </td>
                                                <td style="padding: 0">
                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlBillState" runat="server" CssClass="input1" Width="110px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 25px; overflow: hidden;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 35px;">
                                                                Zip<span class="star">*</span>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtBillZip" MaxLength="5" Width="55" runat="server" CssClass="sample4 input1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <span></span>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="width: 100%; margin: 10px 0; border-bottom: #ccc 1px solid; clear: both;
                                            height: 2px;">
                                            &nbsp;</div>
                                    </div>
                                    <asp:UpdatePanel ID="updtpnlSave" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSave" runat="server" class="button1" Text="Save" Style="float: right;
                                                margin-right: 8px;" OnClientClick="return CheckCardNumber(this.form)" OnClick="btnSave_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                    <!-- Vehicle Type Div End -->
                                </div>
                            </div>
                            <!-- Results Start -->
                            <div class="wrapper">
                                <div style="width: 97%; margin: 0 auto; display: none" id="carDetailsDivHolder">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="line-height: 20px">
                                                <h3 class="h3 h3b" id="carDet">
                                                </h3>
                                                <div id="carDet0">
                                                    <strong>
                                                        <label id="SellerType">
                                                        </label>
                                                        : &nbsp;</strong><label id="SellerName"></label><br />
                                                    <strong>Call: &nbsp;</strong><label id="SellerNo"></label><br />
                                                    <strong>Email: &nbsp;</strong><label id="SellerEmail"></label><br />
                                                    <strong>Address: &nbsp;</strong><label id="SellerAddress"></label>
                                                </div>
                                            </td>
                                            <td align="right" valign="top">
                                                <h3>
                                                    <a href="javascript:history.go(-1)">&laquo; Back to search results</a></h3>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Car Details Div Start -->
                                    <div id="adv1" class="usual">
                                        <ul>
                                            <li class="tab1"><a href="javascript:void(0);#t1 " class="selected">Vehicle Description</a></li>
                                            <li class="tab1"><a href="javascript:void(0);#t2">Photos</a></li>
                                            <li class="tab1"><a href="javascript:void(0);#t3">Map & Direction</a></li>
                                        </ul>
                                        <div id="t1">
                                            <!-- Slider Start  -->
                                            <div class="sliderHolder">
                                                <div id="basic" class="svwp">
                                                    <ul>
                                                        <li>
                                                            <img alt="" src="images/large/zr1review_01.jpg" width="250" height="199" /></li>
                                                        <!--eccetera-->
                                                    </ul>
                                                </div>
                                            </div>
                                            <!-- Slider End  -->
                                            <!-- Disc Start -->
                                            <div class="disc">
                                            </div>
                                            <!-- Disc End -->
                                            <div class="clear">
                                                &nbsp;
                                            </div>
                                            <div class="SellerNotes">
                                            </div>
                                            <div class="clear">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div id="t2">
                                            <!-- Slider Start  -->
                                            <div class="sliderHolder">
                                                <div id="basic2" class="svwp">
                                                    <ul>
                                                        <li>
                                                            <img alt="" src="images/large/zr1review_01.jpg" width="680" height="452" /></li>
                                                        <!--eccetera-->
                                                    </ul>
                                                </div>
                                            </div>
                                            <!-- Slider End  -->
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <div id="t3">
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
                                    <!-- Car Details Div  End  -->
                                    <div class="bottomAdd" style="margin-left: 1px;">
                                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57  -->

                                        <script type="text/javascript">
var AdBrite_Title_Color = '0000FF';
var AdBrite_Text_Color = '000000';
var AdBrite_Background_Color = 'FFFFFF';
var AdBrite_Border_Color = 'CCCCCC';
var AdBrite_URL_Color = '008000';
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
                                        </script>

                                        <span style="white-space: nowrap;">

                                            <script type="text/javascript">document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2102343&zs=3732385f3930&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                            <a target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2102343&afsid=1">
                                                <img src="http://files.adbrite.com/mb/images/adbrite-your-ad-here-leaderboard.gif"
                                                    style="background-color: #CCCCCC; border: none; padding: 0; margin: 0;" alt="Your Ad Here"
                                                    width="14" height="90" border="0" /></a></span>
                                        <!-- End: adBrite -->
                                    </div>
                                </div>
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
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="popupBody" style="display: block" id="AlertUser">
        <div>
            <h1 class="h1">
                Congratulations..!</h1>
            <h3 class="h32">
                You are one step closer to selling your car.</h3>
            <p class="pp">
                You will recieve mail from our's shortly. Mean while you can login check details
                of your and edit any information required including uploading new photographs.
            </p>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div>
    <%-- <div id="AlertUser" class="alert" style="display: block">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="BtnCls_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnGo" class="btn" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div>--%>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnExustCls_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Next" OnClick="btnOk_Click" />
        </div>
    </div>
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
    <!-- Success PopUp Start  -->
    <!-- Success PopUp Start  -->
    </form>

    <script type="text/ecmascript" language="javascript">
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
	
	 // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};	
				 
				 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		
		
		$('.sample4').numeric();
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#model, #modelA, #modelB').attr('disabled',true);
		
		
	
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('color','#ffb619').css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}			
			// $(this).parent().toggleClass('li-hover');
		});
		
		
		
		
		// lBrandAds
		/*
		if(ad1.length>0){
			var img = '';
			var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
			img += "<img src='"+imgPath+"' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
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
