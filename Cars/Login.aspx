<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    EnableEventValidation="false" %>

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
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/jquery.slideViewerPro.1.5.js"></script>

    <script type="text/javascript" src="js/jquery.timers.js"></script>

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

    <script type="text/javascript" language="javascript">
        function EmailNAClick(){
        /*
        var checkbox = document.getElementById("delearChk");       
        if(checkbox.checked){        
       document.getElementById('<%=delearBox.ClientID%>').style.display = "block";        
        }
        else
        {
         document.getElementById('<%=delearBox.ClientID%>').style.display = "none";        
        }
        */
        }     
        function ValidateDetails() {
            var valid = true;           

           
                if ($('#txtDealer').val().trim() == "") {
                    $('#txtDealer').val('');
                    $('#txtDealer').focus() 
                    alert('Please enter dealer id')
                    valid = false;
                    document.getElementById('txtDealer').focus();
                }
                else if ($('#txtEmail').val().trim()== "") {
                    alert('Please enter user id')
                    valid = false;
                    document.getElementById('txtEmail').focus();
                    $('#txtEmail').val('');
                    if (document.getElementById('lblError') != null) {
                        document.getElementById('lblError').outerText = "";
                    }
                }
                else if ($('#txtPassword').val().trim() == "") {
                    alert("Please enter password");
                    valid = false;
                    $('#txtPassword').focus();
                    $('#txtPassword').val('');
                    if (document.getElementById('lblError') != null) {
                        document.getElementById('lblError').outerText = "";
                    }
                }
          return valid;
        }
  function Uservalidation()
  {
       var valid = true;           

        if ($('#txtCustLogUserID').val().trim()== "") {
            alert('Please enter user id')
            valid = false;
            document.getElementById('txtCustLogUserID').focus();
            if (document.getElementById('lblUserLogError') != null) {
                document.getElementById('lblUserLogError').outerText = "";
            }
        }

        else if ($('#txtCustLogUserPwd').val() == "") {
            alert("Please enter password");
            valid = false;
            document.getElementById('txtCustLogUserPwd').focus();
            if (document.getElementById('lblUserLogError') != null) {
                document.getElementById('lblUserLogError').outerText = "";
            }
        }
        return valid;
  }
        function ShowPW() {
            document.getElementById('txtForgetUserName').value = "";
            $find('mpeChangePW').show();
            return false;
        }

        function ValidateChangePW() {

            var valid = true;

            if (document.getElementById('txtForgetUserName').value.length < 1) {
                alert('Please enter email')
                valid = false;
                document.getElementById('txtForgetUserName').value = ""
                document.getElementById('txtForgetUserName').focus()
                return valid;
            }
            else {
                $find('mpeChangePW').hide();
            }
            return valid;
        }

    </script>

    <style>
        .usual ul li.tab1 a
        {
            display: block;
            padding: 5px 8px;
            text-decoration: none !important;
            margin: 0 2px 0 0;
            margin-left: 0;
            color: #444;
            font-weight: bold;
            background: url(images/AccordionTab0.gif) repeat-x;
        }
    </style>
</head>
<body id="page1" onload="GetRecentListings()">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updatepnlLogin"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanelCustLogin"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlForgetPwd"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
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
                        <img src="images/logo2.png" alt="" name="logo" id="logo" /></a>
                    <div class="loginStat">
                        <%-- <a href="login.aspx" class="login">Login</a>--%>
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
                                            try { var AdBrite_Iframe = window.top != window.self ? 2 : 1; var AdBrite_Referrer = document.referrer == '' ? document.location : document.referrer; AdBrite_Referrer = encodeURIComponent(AdBrite_Referrer); } catch (e) { var AdBrite_Iframe = ''; var AdBrite_Referrer = ''; }
                                            document.write(String.fromCharCode(60, 83, 67, 82, 73, 80, 84)); document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr=' + AdBrite_Iframe + '&ref=' + AdBrite_Referrer + '" type="text/javascript">'); document.write(String.fromCharCode(60, 47, 83, 67, 82, 73, 80, 84, 62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Advantage of Buying Used Cars Start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Advantage of Buying Used Cars
                                        </h3>
                                        <em class="i1">Must read tips & advices on Used Cars</em><br />
                                        <ul class="bullet" style="margin-left: 10px;">
                                            <li><a href="tips.aspx">Used Car buying tips</a></li>
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
                                    <!-- Contact Information  Div Start  -->
                                    <div class="box4">
                                        <br />
                                        <table class="logins">
                                            <tr>
                                                <td style="width: 48%; vertical-align: top">
                                                    <fieldset>
                                                        <legend>Customer Login</legend>
                                                        <asp:UpdatePanel ID="updtpnl" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr id="Tr2">
                                                                        <td style="width: 120px;">
                                                                            User ID
                                                                        </td>
                                                                        <td>
                                                                            <span id="Span3">
                                                                                <asp:TextBox ID="txtCustLogUserID" runat="server" MaxLength="50" Width="200px" CssClass="input1"></asp:TextBox>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="Tr3">
                                                                        <td>
                                                                            Password
                                                                        </td>
                                                                        <td>
                                                                            <span id="Span4">
                                                                                <asp:TextBox ID="txtCustLogUserPwd" runat="server" MaxLength="50" TextMode="Password"
                                                                                    Width="200px" CssClass="input1"></asp:TextBox>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="padding-top: 5px;">
                                                                            <asp:UpdatePanel ID="UpdatePanelCustLogin" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Button ID="btnUserLogin" runat="server" Text="Login" CssClass="button1" OnClientClick="return Uservalidation();"
                                                                                        OnClick="btnUserLogin_Click" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            &nbsp;<br />
                                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Forgot password?" OnClientClick="return ShowPW();"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Register" OnClick="lnkRegister_Click"></asp:LinkButton>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblUserLogError" runat="server" ForeColor="Red"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </fieldset>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 48%; vertical-align: top;">
                                                    <fieldset>
                                                        <legend>Dealer Login</legend>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr id="delearBox" runat="server">
                                                                        <td style="width: 120px;">
                                                                            Dealer ID
                                                                        </td>
                                                                        <td>
                                                                            <span id="Span1">
                                                                                <asp:TextBox ID="txtDealer" runat="server" MaxLength="20" Width="200px" CssClass="input1"></asp:TextBox>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="methodOfContactEmail">
                                                                        <td style="width: 120px;">
                                                                            User ID
                                                                        </td>
                                                                        <td>
                                                                            <span id="oeFormcontactEmailContainer">
                                                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" Width="200px" CssClass="input1"></asp:TextBox>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="methodOfContactConfirmEmail">
                                                                        <td>
                                                                            Password
                                                                        </td>
                                                                        <td>
                                                                            <span id="oeFormconfirmContactEmailContainer">
                                                                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password" Width="200px"
                                                                                    CssClass="input1"></asp:TextBox>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="padding-top: 5px;">
                                                                            <asp:UpdatePanel ID="updatepnlLogin" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button1" OnClientClick="return ValidateDetails();"
                                                                                        OnClick="btnLogin_Click" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            &nbsp;<br />
                                                                          <%--  <asp:LinkButton ID="lnkForgetPwd" runat="server" Text="Forgot password?" OnClientClick="return ShowPW();"></asp:LinkButton>
                                                                            &nbsp;
                                                                            <asp:LinkButton ID="lnkRegister" runat="server" Text="Register" OnClick="lnkRegister_Click"></asp:LinkButton>--%>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>
                                                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </fieldset>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- Contact Information  Div End  -->
                                    <div class="clear">
                                        &bnsp;
                                        <div class="wrapper">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 65%; border-right: #fedaa0 1px dotted; padding: 10px;">
                                                        <h3 class="h3">
                                                            Sell Your Car - Easy & Fast!</h3>
                                                        <p>
                                                            More then a million cars sold, already - Advertise with us.</p>
                                                        <input type="button" class="button1" value="LIST YOUR CAR NOW" onclick="window.location.href='Registration.aspx'" />
                                                    </td>
                                                    <td style="padding: 10px;">
                                                        <h3 class="h3">
                                                            Used Cars Advertising</h3>
                                                        <i class="i1">We help you grow your business</i>
                                                        <div class="clear">
                                                        </div>
                                                        View our <a href="Packages.aspx">Advertising Plans</a>
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
                            <div id="div88X720" runat="server" style="height: 88px; width: 720px; margin: 10px auto;
                                border: #999 1px solid; padding: 1px; background: white;">
                            </div>
                            <!-- 
                            <div class="bottomAdd" style="margin-left: 1px;">
                               

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
                                
                            </div>
                            -->
                            <!-- Results End -->
                        </div>
                        <div class="clear">
                            &nbsp;</div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer">
                    <uc1:Footer ID="Footer1" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpeChangePW" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none; background-color: #adbc79; width: 400px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="2" style="background: #FFB113 url(images/AccordionTab1.gif); height: 20px;
                    padding: 10px 0px; color: #fff; text-align: center; font-family: Verdana; font-size: 12px;
                    text-transform: uppercase; font-weight: bold;">
                    Forgot Password
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 10px auto;">
                        <tr>
                            <td style="padding-left: 5px; width: 120px">
                                Email Address<span class="star">*</span>
                            </td>
                            <td style="padding-right: 5px;">
                                <asp:TextBox ID="txtForgetUserName" MaxLength="70" CssClass="input1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="padding: 6px 0 20px 0;">
                                <div style="width: 100%; margin: 0; padding-left: 0">
                                    <asp:UpdatePanel ID="updtPnlForgetPwd" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSendPwd" class="button1-b" runat="server" Text="Get Password"
                                                OnClientClick="return ValidateChangePW();" OnClick="btnSendPwd_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Button ID="btnCancelPW" class="button1-b" runat="server" Text="Cancel" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="BtnCls"
        OkControlID="btnYes">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
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
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Applying your filter
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script type="text/javascript" language="javascript">



        var ad1 = ['images/ads/ad-v1.jpg', 'images/ads/ad-v2.jpg', 'images/ads/ad-v3.jpg', 'images/ads/ad-v4.jpg', 'images/ads/ad-v5.jpg', 'images/ads/ad-v6.jpg', 'images/ads/ad-v7.jpg', 'images/ads/ad-v8.jpg', 'images/ads/ad-v9.jpg', 'images/ads/ad-v10.jpg'];

        var ad2 = ['images/ads/ad-h1.jpg', 'images/ads/ad-h2.jpg', 'images/ads/ad-h3.jpg', 'images/ads/ad-h4.jpg', 'images/ads/ad-h5.jpg', 'images/ads/ad-h6.jpg', 'images/ads/ad-h7.jpg'];

        var ad1left = ['images/ads/ads-l1.jpg', 'images/ads/ads-l2.jpg', 'images/ads/ads-l3.jpg'];

        // lBrandAds
        if (ad1left.length > 0) {
            var img = '';
            var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];
            img += "<img src='" + imgPath + "' width='180' />";
            $('#lBrandAds').empty();
            $('#lBrandAds').append(img);
        };
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
