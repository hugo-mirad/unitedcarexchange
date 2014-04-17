<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/RegPageUser.ascx" TagName="RegPageUser" TagPrefix="uc3" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc4" %>
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



  function Validate() {
  ;
   var valid = true;
             if ($('#txtContcname').val().trim().length< 1) {
                $('#txtContcname').focus();
                alert("Enter contact name");
                $('#txtContcname').val('')
                $('#txtContcname').focus()
                
                valid = false;
                return valid;
            }
            if($('#txtemail').val().trim().length < 1) {
                $('#txtemail').focus();
                alert("Enter email");
                 $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;            
                return valid;
            }
            
             if (($('#txtemail').val().trim().length > 0) && (echeck($('#txtemail').val().trim()) == false) )
             {
               
                $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;
                return valid;
           
            }
            
             if($('#txtconfEmail').val().trim().length < 1) {
                $('#txtconfEmail').focus();
                $('#txtconfEmail').val('');;
                alert("Enter confirm email");
                valid = false;            
                return valid;
            }
            
             
             if (($('#txtconfEmail').val().trim().length > 0) && (echeck($('#txtconfEmail').val().trim()) == false) )
             {
               
                $('#txtconfEmail').val('');
                $('#txtconfEmail').focus()
                valid = false;
                return valid;
           
            }
              if ($('#txtemail').val().trim() != $('#txtconfEmail').val().trim()) {
                $('#txtconfEmail').focus();
                 $('#txtconfEmail').val('');;
                alert("Email does not match the confirm email");
                valid = false;
                return valid;
            }

            if ($('#txtPassword').val().length < 1)
             {
                $('#txtPassword').focus();
                alert("Enter password");
                 $('#txtPassword').val('');
                $('#txtPassword').focus()
                valid = false;            
                return valid;
           
            }
             if ($('#txtConfirmPassword').val().trim().length < 1 )
             {
                $('#txtConfirmPassword').focus();
                alert("Enter confirm password");
                 $('#txtConfirmPassword').val('');
                $('#txtConfirmPassword').focus()
                valid = false;            
                return valid;
           
            }
              if ($('#txtPassword').val().trim() != $('#txtConfirmPassword').val().trim()) {
                $('#txtConfirmPassword').focus();
                 $('#txtConfirmPassword').val('');;
                alert("Password does not match the confirm password");
                valid = false;
                return valid;
            } 
            
              if (($('#txtAltEmail').val().trim().length > 0) && (echeck($('#txtAltEmail').val().trim()) == false) )
             {
               
                $('#txtAltEmail').val('');
                $('#txtAltEmail').focus()
                valid = false;
                return valid;
           
            }
               if ($('#txtphone').val().trim().length < 1 )
             {
                $('#txtphone').focus();
                alert("Enter phone number");
                 $('#txtphone').val('');
                $('#txtphone').focus()
                valid = false;            
                return valid;
           
            }
                       
              if(($('#txtphone').val().trim().length > 0) && ($('#txtphone').val().trim().length < 10)) {
                $('#txtphone').focus();
                $('#txtphone').val('');;
                alert("Enter valid phone number");
                valid = false;            
                return valid;
            }   
               
               if(($('#txtAltPhone').val().trim().length > 0) && ($('#txtAltPhone').val().trim().length < 10)) {
                $('#txtAltPhone').focus();
                $('#txtAltPhone').val('');;
                alert("Enter valid phone number");
                valid = false;            
                return valid;
            }         
             if($('#txtRegZip').val().trim().length > 0)
             {
                 var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#txtRegZip').val().trim());
                   if (isValid == false)
                   {
                     $('#txtRegZip').focus();
                    alert("Please enter valid zipcode");
                     $('#txtRegZip').val('');
                    $('#txtRegZip').focus()
                    valid = false;  
                     return valid;      
                   }                             
             }          
               
         return valid;
      }
      
      
      function isNumberKey(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
          function isNumberKeyWithDashForZip(evt)
         {
         
         
            var charCode = (evt.which) ? evt.which : event.keyCode         
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
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
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" alt="" name="logo" id="logo" /></a>
                    <div class="loginStat">
                        <uc3:RegPageUser ID="RegPageUser1" runat="server" />
                    </div>
                    <div id="menu">
                        <uc4:CarsHeader ID="CarsHeader1" runat="server" />
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
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px;">
                                                <h2>
                                                    Registration
                                                </h2>
                                            </td>
                                            <td style="text-align: right">
                                                <img src="images/Navigation1.jpg" />
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Contact Information  Div Start  -->
                                    <div class="box4" style="border-top: #ccc 1px solid; border-bottom: #ccc 1px solid;
                                        padding: 10px 0;">
                                        <table cellspacing="0" cellpadding="0" border="0" class="form1">
                                            <tr>
                                                <td style="width: 120px; padding-right: 10px;">
                                                    Contact Name <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="oeFormcontactNameContainer">
                                                        <asp:TextBox ID="txtContcname" runat="server" MaxLength="25" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="methodOfContactEmail">
                                                <td>
                                                    Email Address <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="oeFormcontactEmailContainer">
                                                        <asp:TextBox ID="txtemail" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="methodOfContactConfirmEmail">
                                                <td>
                                                    Confirm Email <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="oeFormconfirmContactEmailContainer">
                                                        <asp:TextBox ID="txtconfEmail" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="Tr1">
                                                <td>
                                                    Password <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="oeFormcontactNameContainer">
                                                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" Width="200px" TextMode="Password"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr id="Tr2">
                                                <td>
                                                    Confirm Password <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="oeFormcontactNameContainer">
                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" Width="200px"
                                                            TextMode="Password"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; overflow: hidden" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td7">
                                                    Company Name
                                                </td>
                                                <td>
                                                    <span id="Span8">
                                                        <asp:TextBox ID="txtBusinessName" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td8">
                                                    Alt Email
                                                </td>
                                                <td>
                                                    <span id="Span9">
                                                        <asp:TextBox ID="txtAltEmail" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="oeFormcontactType1Container1">
                                                    Phone<span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="Span1">
                                                        <asp:TextBox ID="txtphone" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td9">
                                                    Alt Phone
                                                </td>
                                                <td>
                                                    <span id="Span10">
                                                        <asp:TextBox ID="txtAltPhone" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td3">
                                                    Address
                                                </td>
                                                <td>
                                                    <span id="Span4">
                                                        <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td4">
                                                    City
                                                </td>
                                                <td>
                                                    <span id="Span5">
                                                        <asp:TextBox ID="txtRegCity" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td5">
                                                    State
                                                </td>
                                                <td colspan="2">
                                                    <table style="width: 100%:" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <span id="Span6">
                                                                    <asp:DropDownList ID="ddlLocationState" runat="server" Width="95">
                                                                    </asp:DropDownList>
                                                                </span>
                                                            </td>
                                                            <td style="width: 30px; overflow: hidden">
                                                                &nbsp;
                                                            </td>
                                                            <td id="Td6" style="width: 25px;">
                                                                Zip
                                                            </td>
                                                            <td>
                                                                <span id="Span7">
                                                                    <asp:TextBox ID="txtRegZip" runat="server" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"
                                                                        Width="50px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; overflow: hidden" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td1">
                                                    Coupon <i style="font-size: 10px; color: #999">(If available)</i>
                                                </td>
                                                <td>
                                                    <span id="Span2">
                                                        <asp:TextBox ID="txtCoupon" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td2">
                                                    Referred By
                                                </td>
                                                <td>
                                                    <span id="Span3">
                                                        <asp:TextBox ID="txtRefferedBy" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 280px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="padding-top: 5px;">
                                                    <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Proceed"
                                                        class="button1" OnClick="btnregister_Click" />
                                                    &nbsp; Already user? <a href="login.aspx">Login</a> &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- Contact Information  Div End  -->
                                    <div class="clear">
                                        &nbsp;
                                    </div>
                                    <br />
                                    <!-- Box2 Div Start  -->
                                    <!-- Box2 Div End  -->
                                    <div class="clear">
                                    </div>
                                    <!-- Ads Section Start  -->
                                    <!-- Ads Section Endt  -->
                                </div>
                            </div>
                            <!-- Results Start -->
                            <div class="wrapper">
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
                            </div>
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
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
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
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" OnClick="btnNo_Click" />
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Yes" OnClick="btnYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists" OkControlID="btnExustCls"
        CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
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
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
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
