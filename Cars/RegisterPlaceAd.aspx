<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterPlaceAd.aspx.cs"
    Inherits="RegisterPlaceAd" EnableEventValidation="false" %>

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
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/PaginationStyle.css" rel="stylesheet" type="text/css" />

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
       function isNumberKey(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKeyWithDot(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
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
        
      function ValidateVehicleType()
        {
        
            var valid=true;
                
//              if (document.getElementById('ddlPackage').value =="0")
//            {
//                alert('Please select package')
//                valid=false;
//                document.getElementById('ddlPackage').focus();  
//                return valid;
//            }
     
             if (document.getElementById('ddlYear').value =="0")
            {
                alert('Please select year')
                valid=false;
                document.getElementById('ddlYear').focus();  
                return valid;
            }
             
           if(document.getElementById('ddlMake').value =="0")
            {
                alert("Please select make"); 
                valid=false;
                document.getElementById('ddlMake').focus();  
                return valid;               
            } 
            if(document.getElementById('ddlModel').value =="0")
            {
                alert("Please select model"); 
                valid=false;
                document.getElementById('ddlModel').focus();  
                return valid;               
            }  
              if(document.getElementById('txtZip').value.length > 0)
             {
                 var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('txtZip').value);
                   if (isValid == false)
                   {
                     document.getElementById(' txtZip').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('txtZip').value = ""
                    document.getElementById('txtZip').focus()
                    valid = false;  
                     return valid;      
                   }                 
             }            
               
                        
              if( (document.getElementById('txtSellerPhone').value.length > 0 ) && (document.getElementById('txtSellerPhone').value.length < 10))
             {
                document.getElementById(' txtSellerPhone').focus();
                alert("Please enter valid phone number");
                 document.getElementById('txtSellerPhone').value = ""
                document.getElementById('txtSellerPhone').focus()
                valid = false; 
                 return valid;              
             }   
              if ((document.getElementById('txtSellerEmail').value.length > 0) && (echeck(document.getElementById('txtSellerEmail').value) == false) )
             {
               
                document.getElementById('txtSellerEmail').value = ""
                document.getElementById('txtSellerEmail').focus()
                valid = false;
                
           
            }               
               
            return valid;
        }


        function ValidateVehicleInfo()
        {    
            var valid=true;
           if (document.getElementById('txtZip').value.length < 1 )
             {
                document.getElementById(' txtZip').focus();
                alert("Please enter zipcode");
                 document.getElementById('txtZip').value = ""
                document.getElementById('txtZip').focus()
                valid = false;            
             }
            
            else if (document.getElementById('txtZip').value.length < 4 )
             {
                document.getElementById(' txtZip').focus();
                alert("Enter valid zipcode");
                 document.getElementById('txtZip').value = ""
                document.getElementById('txtZip').focus()
                valid = false;            
             }
            return valid;
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
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="BtnSavePanel"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <div>
                    Processing
                    <img src="images/loading.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px; top: 0px; left: 0px;">
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
                                    <table style="float: left; width: 370px;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px;">
                                                <h2>
                                                    <asp:Label ID="lblHeadName" runat="server" Font-Size="16px"></asp:Label>
                                                    Build Your Ad
                                                </h2>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding: 0;">
                                                <table style="font-size: 12px; font-weight: bold; font-family: Arial, Helvetica, sans-serif;
                                                    width: 100%; margin: 0;" class="form1">
                                                    <tr>
                                                        <td style="width: 55px;">
                                                            Package
                                                        </td>
                                                        <td>
                                                            <div id="ddlPackDiv" runat="server" style="display: block;">
                                                                <asp:DropDownList ID="ddlPackage" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div id="lblPackDiv" runat="server" style="display: none">
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <h4>
                                                                <a href="SellRegi.aspx" target="_blank">Learn about packages</a></h4>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 340px; float: right; padding: 0; text-align: right;">
                                        <img src="images/Navigation2.jpg" id="NavigationImg" runat="server" />
                                    </div>
                                    <div style="width: 100%; margin: 10px 0; height: 2px; overflow: hidden; clear: both;
                                        border-bottom: 1px solid #ccc;">
                                        &nbsp;</div>
                                    <!-- Vehicle Type Div Start -->
                                    <div class="box4">
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 50%;
                                            float: left; margin: 10px 20px 10px 0;">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <p style="margin: 5px 0; width: 100%;">
                                                            <strong class="hedBack">Vehicle Type</strong>
                                                        </p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 90px;">
                                                        Year <span class="star">*</span>
                                                    </td>
                                                    <td style="width: 300px">
                                                        <asp:DropDownList ID="ddlYear" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Make <span class="star">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="updtMake" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlMake" runat="server" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged"
                                                                    AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Model <span class="star">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlModel" runat="server">
                                                                    <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Style
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlStyle" runat="server">
                                                                    <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 43%;
                                            float: left; margin: 10px 0 0 0">
                                            <tr>
                                                <td colspan="2">
                                                    <p style="margin: 5px 0; width: 100%;">
                                                        <strong class="hedBack">Seller Information For Display</strong>
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    City
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    State
                                                </td>
                                                <td>
                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlLocationState" runat="server" CssClass="input1" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 40px; overflow: hidden;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 28px;">
                                                                ZIP
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return isNumberKeyWithDashForZip(event)"
                                                                    CssClass="input1" Width="60px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Phone
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSellerPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                                        CssClass="input1"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSellerEmail" runat="server" MaxLength="30" CssClass="input1"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="clear">
                                            &nbsp;</div>
                                    </div>
                                    <!-- Vehicle Type Div End -->
                                    <!-- Vehicle Information  Div Start  -->
                                    <div class="box4 basic" style="width: 99%; margin: 0 0 5px 0">
                                        <div class="hed hh2" onclick="javascript:choice('1')">
                                            <a style="text-transform: uppercase; font-size: 13px;">Vehicle Information<i class="non">(You
                                                may add or modify these later)</i></a>
                                            <div class="close ">
                                            </div>
                                        </div>
                                        <div id="div1" style="background: #fff;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 95%" class="form1">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3">
                                                            Title <span style="font-size: 11px">(Ex: 2004 Honda Accord EX V6 - Dark Blue - Auto
                                                                - 58K Mi.)</span>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 6px; vertical-align: top; width: 115px;">
                                                            Asking Price
                                                        </td>
                                                        <td style="width: 170px;">
                                                            <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="width: 110px;">
                                                            Drive Train
                                                        </td>
                                                        <td style="width: 170px">
                                                            <asp:DropDownList ID="ddlDriveTrain" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Mileage
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="width: 110px;">
                                                            Engine Cylinders
                                                        </td>
                                                        <td style="width: 170px">
                                                            <asp:DropDownList ID="ddlCylinderCount" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Exterior Color
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlExteriorColor" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            Doors
                                                        </td>
                                                        <td>
                                                            <span id="oeFormdoorCountContainer">
                                                                <asp:DropDownList ID="ddlDoorCount" runat="server">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Interior Color
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInteriorColor" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            Fuel Type
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFuelType" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Transmission
                                                        </td>
                                                        <td>
                                                            <span id="oeFormtransmissionContainer">
                                                                <asp:DropDownList ID="ddlTransmission" runat="server">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            VIN <em>(may add later)</em>
                                                        </td>
                                                        <td>
                                                            <span id="oeFormvinContainer">
                                                                <asp:TextBox ID="txtVin" runat="server" MaxLength="17"></asp:TextBox>
                                                            </span>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Condition
                                                        </td>
                                                        <td>
                                                            <span id="Span1">
                                                                <asp:DropDownList ID="ddlCondition" runat="server">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Vehicle Information  Div End  -->
                                    <!-- Vehicle Description  Div Start  -->
                                    <div class="box4 basic" style="width: 99%; margin: 0 0 5px 0">
                                        <div class="hed hh2" onclick="javascript:choice('2')">
                                            <a style="text-transform: uppercase; font-size: 13px;">Vehicle Description <i class="non">
                                                (You may add or modify these later)</i></a>
                                            <div class="close ">
                                            </div>
                                        </div>
                                        <div id="div2" style="background: #fff;">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="form1">
                                                <tbody>
                                                    <tr>
                                                        <td rowspan="12" width="155px" valign="top" style="padding-right: 0px;">
                                                            Features
                                                            <br />
                                                            <br />
                                                            <em>(You may add or modify these later.)</em>
                                                        </td>
                                                        <td style="width: 175px;">
                                                            <div>
                                                                <em><b>Comfort</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures51" runat="server" />
                                                                    A/C</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures1" runat="server" />
                                                                    A/C: Front</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures2" runat="server" />
                                                                    A/C: Rear</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures3" runat="server" />
                                                                    Cruise Control</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures4" runat="server" />
                                                                    Navigation System
                                                                </div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures5" runat="server" />
                                                                    Power Locks</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures6" runat="server" />
                                                                    Power Steering</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures7" runat="server" />
                                                                    Remote Keyless Entry</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures8" runat="server" />
                                                                    TV/VCR</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures31" runat="server" />
                                                                    Remote Start</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures33" runat="server" />
                                                                    Tilt</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures35" runat="server" />
                                                                    Rearview Camera</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures36" runat="server" />
                                                                    Power Mirrors</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Seats</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures9" runat="server" />
                                                                    Bucket Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures10" runat="server" />
                                                                    Leather Interior</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures11" runat="server" />
                                                                    Memory Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures12" runat="server" />
                                                                    Power Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures32" runat="server" />
                                                                    Heated Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures37" runat="server" />
                                                                    Vinyl Interior</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures38" runat="server" />
                                                                    Cloth Interior</div>
                                                            </div>
                                                        </td>
                                                        <td valign="top" style="width: 155px;">
                                                            <div>
                                                                <em><b>Safety</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures13" runat="server" />
                                                                    Airbag: Driver</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures14" runat="server" />
                                                                    Airbag: Passenger</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures15" runat="server" />
                                                                    Airbag: Side</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures16" runat="server" />
                                                                    Alarm</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures17" runat="server" />
                                                                    Anti-Lock Brakes</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures18" runat="server" />
                                                                    Fog Lights</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures39" runat="server" />
                                                                    Power Brakes</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Sound System</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures19" runat="server" />
                                                                    Cassette Radio</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures20" runat="server" />
                                                                    CD Changer
                                                                </div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures21" runat="server" />
                                                                    CD Player</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures22" runat="server" />
                                                                    Premium Sound</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures34" runat="server" />
                                                                    AM/FM</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures40" runat="server" />
                                                                    DVD</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>New</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures44" runat="server" />
                                                                    Battery</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures45" runat="server" />
                                                                    Tires
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td valign="top">
                                                            <div>
                                                                <em><b>Windows</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures23" runat="server" />
                                                                    Power Windows</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures24" runat="server" />
                                                                    Rear Window Defroster</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures25" runat="server" />
                                                                    Rear Window Wiper</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures26" runat="server" />
                                                                    Tinted Glass</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Other</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures27" runat="server" />
                                                                    Alloy Wheels</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures28" runat="server" />
                                                                    Sunroof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures41" runat="server" />
                                                                    Panoramic Roof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures42" runat="server" />
                                                                    Moon Roof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures29" runat="server" />
                                                                    Third Row Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures30" runat="server" />
                                                                    Tow Package</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures43" runat="server" />
                                                                    Dashboard Wood frame</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Specials</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures46" runat="server" />
                                                                    Garage Kept</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures47" runat="server" />
                                                                    Non Smoking</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures48" runat="server" />
                                                                    Records/Receipts Kept</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures49" runat="server" />
                                                                    Well Maintained</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures50" runat="server" />
                                                                    Regular oil changes</div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table id="vSellpointsbox" border="0" cellpadding="0" cellspacing="0" width="100%"
                                                class="form1">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="5" style="height: 10px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="2">
                                                        </td>
                                                        <td style="width: 160px; padding-right: 10px; vertical-align: top">
                                                            Additional Selling Points
                                                        </td>
                                                        <td style="width: 330px;">
                                                            <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence"><span id="sellingPointCharCount">
                                                                1000</span> characters left</span><br />
                                                                <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Rows="8" cols="10"
                                                                    onchange="updateCharCount(this,'sellingPointCharCount');" onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                    class="textarea" MaxLength="1000"></asp:TextBox>
                                                            </span>
                                                        </td>
                                                        <td>
                                                            <p>
                                                                Include information on additional equipment, how you have cared for the vehicle,
                                                                Kelley Blue Book value and anything else that will help sell your vehicle.<br />
                                                            </p>
                                                        </td>
                                                        <td width="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5">
                                                            <img src="images/spacer.gif" alt="" border="0" height="3" width="1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" style="height: 10px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Vehicle Description  Div End  -->
                                    <div class="clear">
                                    </div>
                                    <br />
                                    <asp:UpdatePanel ID="BtnSavePanel" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnSaveCarDetails" runat="server" CssClass="button1" Text="Proceed"
                                                Style="float: right; margin-right: 8px;" OnClientClick="return ValidateVehicleType();"
                                                OnClick="btnSaveCarDetails_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
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
		
		    $('div.hed div.close').click(function(){
		        $(this).toggleClass("open");
            });
            
            
    		
		});
		
		function choice(e){
		$('#div'+e).slideToggle();	
		
    }
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
