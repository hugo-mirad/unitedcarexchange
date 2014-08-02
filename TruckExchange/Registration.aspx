<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title1" runat="server"></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    
    <link href="css/searchBlock.css" rel="stylesheet" type="text/css" />
    <link href="css/PaginationStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/gallery.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

<script type="text/javascript" src="js/jquery.vticker.js"></script>
    <script src="Static/JS/CarsJScript.js" type="text/javascript"></script>
    <script type="text/javascript">

        function pageLoad() {
            debugger
            GetRecentListings();
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



        function Validate() {
            debugger;
            var valid = true;


            if ($('#<%=ddlPackage.ClientID%> option:selected').val() == 0) {
                alert('Please select package')
                valid = false;
                $('#ddlPackage').focus();
                return valid;
            }


            if ($('#<%= txtContcname.ClientID%>').val().trim().length < 1) {
                $('#<%= txtContcname.ClientID%>').focus();
                alert("Enter contact name");
                $('#<%=txtContcname.ClientID%>').val('');
                $('#<%=txtContcname.ClientID%>').focus()

                valid = false;
                return valid;
            }
            if ($('#<%= txtemail.ClientID%>').val().trim().length < 1) {
                $('#<%= txtemail.ClientID%>').focus();
                alert("Enter email");
                $('#<%=txtemail.ClientID%>').val('');
                $('#<%=txtemail.ClientID%>').focus()
                valid = false;
                return valid;
            }

            if (($('#<%=txtemail.ClientID%>').val().trim().length > 0) && (echeck($('#<%=txtemail.ClientID%>').val()) == false)) {

                $('#<%=txtemail.ClientID%>').val('');
                $('#<%=txtemail.ClientID%>').focus()
                valid = false;
                return valid;

            }

            if ($('#<%= txtconfEmail.ClientID%>').val().trim().length < 1) {
                $('#<%= txtconfEmail.ClientID%>').focus();
                $('#<%=txtconfEmail.ClientID%>').val(''); ;
                alert("Enter confirm email");
                valid = false;
                return valid;
            }


            if (($('#<%=txtconfEmail.ClientID%>').val().trim().length > 0) && (echeck($('#<%=txtconfEmail.ClientID%>').val()) == false)) {

                $('#<%=txtconfEmail.ClientID%>').val('');
                $('#<%=txtconfEmail.ClientID%>').focus()
                valid = false;
                return valid;

            }
            if ($('#<%=txtemail.ClientID%>').val() != $('#<%=txtconfEmail.ClientID%>').val()) {
                $('#<%=txtconfEmail.ClientID%>').focus();
                $('#<%=txtconfEmail.ClientID%>').val(''); ;
                alert("Email does not match the confirm email");
                valid = false;
                return valid;
            }

            if ($('#<%=txtPassword.ClientID%>').val().trim().length < 1) {
                $('#<%= txtPassword.ClientID%>').focus();
                alert("Enter password");
                $('#<%=txtPassword.ClientID%>').val('');
                $('#<%=txtPassword.ClientID%>').focus()
                valid = false;
                return valid;

            }
            if ($('#<%=txtConfirmPassword.ClientID%>').val().trim().length < 1) {
                $('#<%= txtConfirmPassword.ClientID%>').focus();
                alert("Enter confirm password");
                $('#<%=txtConfirmPassword.ClientID%>').val('');
                $('#<%=txtConfirmPassword.ClientID%>').focus();
                valid = false;
                return valid;

            }
            if ($('#<%=txtPassword.ClientID%>').val() != $('#<%=txtConfirmPassword.ClientID%>').val()) {
                $('#<%=txtConfirmPassword.ClientID%>').focus();
                $('#<%=txtConfirmPassword.ClientID%>').val(''); ;
                alert("Password does not match the confirm password");
                valid = false;
                return valid;
            }

            if (($('#<%= txtphone.ClientID%>').val().trim().length > 0) && ($('#<%= txtphone.ClientID%>').val().trim().length < 10)) {
                $('#<%= txtphone.ClientID%>').focus();
                $('#<%=txtphone.ClientID%>').val(''); ;
                alert("Enter valid phone number");
                valid = false;
                return valid;
            }

            if ($('#<%=txtRegZip.ClientID%>').val().trim().length > 0) {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#<%=txtRegZip.ClientID%>').val());
                if (isValid == false) {
                    $('#<%= txtRegZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                    $('#<%=txtRegZip.ClientID%>').val('');
                    $('#<%=txtRegZip.ClientID%>').focus()
                    valid = false;
                    return valid;
                }
            }

            if ($('#<%=ddlYear.ClientID%> option:selected').val() == 0) {
                alert('Please select year')
                valid = false;
                $('#ddlYear').focus();
                return valid;
            }
            if ($('#<%=ddlType.ClientID%> option:selected').val() == 0) {
                alert("Please select type");
                valid = false;
                $('#ddlType').focus();
                return valid;
            }
            if ($('#<%=ddlCategory.ClientID%> option:selected').val() == 0) {
                alert("Please select category");
                valid = false;
                $('#ddlCategory').focus();
                return valid;
            }

            

            return valid;
        }


        function isNumberKey(evt) {
            debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKeyWithDashForZip(evt) {
            debugger

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
        function isNumberKeyWithDot(evt) {
            debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;

            return true;
        }
    </script>

    
    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager  ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepnlSave"
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
                    <div class="leftBox1">
                        <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
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
                    <div class="info-box" style="background: #fff; padding-top: 0; margin-top: -10px">
                        <div class="wrapper">
                            <table>
                                <tr>
                                    <td style="padding-right: 20px; padding-top: 0;">
                                        <h2>
                                            Registration
                                        </h2>
                                    </td>
                                </tr>
                            </table>
                            <div style="border-top: #ccc 1px solid; padding: 0 10px 15px 10px; width: 100%;">
                                <div style="width: 100%; margin: 0; float: left; padding: 0; position: relative;
                                    z-index: 9">
                                    <!-- Regi Start  -->
                                    <div class="form1" style="width: 450px; margin-top: 0; margin-bottom: 0;">
                                        <table style="width: 85%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 150px; padding: 0">
                                                    Select Package <span class="star">*</span>
                                                </td>
                                                <td style="padding: 10px 0 0 0">
                                                    <asp:DropDownList ID="ddlPackage" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="clear height10">
                                        &nbsp;</div>
                                    <div style="padding: 0; margin: 0; width: 99%">
                                        <!-- Contact Information  Div Start  -->
                                        <h3 class="h3b">
                                            Contact Information</h3>
                                        <table style="width: 380px" cellspacing="0" cellpadding="0" border="0" class="form1">
                                            <tr>
                                                <td style="width: 140px; padding-right: 10px;">
                                                    Contact Name <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <span id="oeFormcontactNameContainer">
                                                        <asp:TextBox ID="txtContcname" runat="server" MaxLength="25" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 0px; overflow: hidden">
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
                                                <td style="width: 0px; overflow: hidden">
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
                                                <td style="width: 0px; overflow: hidden">
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
                                                <td style="width: 0px; overflow: hidden">
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
                                                <td style="width: 0px; overflow: hidden">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 20px; overflow: hidden" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="oeFormcontactType1Container1">
                                                    Phone
                                                </td>
                                                <td>
                                                    <span id="Span1">
                                                        <asp:TextBox ID="txtphone" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 0px; overflow: hidden">
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
                                                <td style="width: 0px; overflow: hidden">
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
                                                <td style="width: 0px; overflow: hidden">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="Td5">
                                                    State
                                                </td>
                                                <td colspan="2">
                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="width: 110px;">
                                                                <span id="Span6">
                                                                    <asp:DropDownList ID="ddlLocationState" runat="server" Width="105">
                                                                    </asp:DropDownList>
                                                                </span>
                                                            </td>
                                                            <td style="width: 10px; overflow: hidden">
                                                                &nbsp;
                                                            </td>
                                                            <td id="Td6" style="width: 25px;">
                                                                Zip
                                                            </td>
                                                            <td>
                                                                <span id="Span7">
                                                                    <asp:TextBox ID="txtRegZip" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"
                                                                        Width="50px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td style="height: 20px; overflow: hidden" colspan="2">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td id="Td1">
                                                    Coupon <i style="font-size: 10px; color: #999">(If available)</i>
                                                </td>
                                                <td>
                                                    <span id="Span2">
                                                        <asp:TextBox ID="txtCoupon" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 0px; overflow: hidden">
                                                </td>
                                            </tr>
                                            <tr style="display: none">
                                                <td id="Td2">
                                                    Reffered By
                                                </td>
                                                <td>
                                                    <span id="Span3">
                                                        <asp:TextBox ID="txtRefferedBy" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                                    </span>
                                                </td>
                                                <td style="width: 0px; overflow: hidden">
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- Contact Information  Div End  -->
                                        <!-- Vehicle Type Div Start -->
                                        <div class="box4">
                                            <h3 class="h3b">
                                                Vehicle Type</h3>
                                            <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 430px;">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 140px; padding-right: 10px;">
                                                            Year <span class="star">*</span>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:DropDownList ID="ddlYear" runat="server" Width="300px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px; padding-right: 10px;">
                                                            Type <span class="star">*</span>
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:UpdatePanel ID="updtType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                                                                        Width="300px">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px; padding-right: 10px;">
                                                            Category <span class="star">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlCategory" runat="server" Width="300px">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px; padding-right: 10px;">
                                                            Make 
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtMake" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMake" runat="server" Width="300px">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 140px; padding-right: 10px;">
                                                            Model
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtModel" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <div class="clear">
                                                &nbsp;</div>
                                        </div>
                                        <!-- Vehicle Type Div End -->
                                        <!-- Vehicle Information  Div Start  -->
                                        <div class="box4 basic" style="width: 99%; margin: 0 0 5px 0">
                                            <div class="h3b" onclick="javascript:choice('1')">
                                                <a>Vehicle Information <i class="non">(You may add or modify these later)</i></a>
                                                <div class="close ">
                                                </div>
                                            </div>
                                            <div id="div1" style="background: #fff; width: 96%">
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" class="form1">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3">
                                                                Title <span style="font-size: 11px">(Ex: 2010 Appalachian Trailers Gooseneck Dump Trailer - $53,500)</span>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="90%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 125px;">
                                                                Asking Price
                                                            </td>
                                                            <td style="width: 170px;">
                                                                <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 60px">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                VIN <em>(may add later)</em>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormvinContainer">
                                                                    <asp:TextBox ID="txtVin" runat="server" MaxLength="17"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Mileage
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Doors
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlDoorCount" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Interior Color
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlInteriorColor" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Fuel Type
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFuelType" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Exterior Color
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlExteriorColor" runat="server" Width="150px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Condition
                                                            </td>
                                                            <td>
                                                                <span id="Span8">
                                                                    <asp:DropDownList ID="ddlCondition" runat="server" Width="150px">
                                                                    </asp:DropDownList>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Engine Manufacturer
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="updtpnlManufacturer" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlEngineManufacturer" runat="server" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Engine Type
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="updtpnlEngineType" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtEngineModel" runat="server" MaxLength="25"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Transmisssion Speed
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlTransmission" runat="server" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Transmisssion Make
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtTransmissionMake" runat="server" MaxLength="25"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Suspension
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlSuspension" runat="server" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Rear
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtRear" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Horse Power
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlHorsePower" runat="server" Width="150px">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Axles
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="txtAxles" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div class="clear head8">
                                                    &nbsp;</div>
                                            </div>
                                        </div>
                                        <!-- Vehicle Information  Div End  -->
                                        <!-- Vehicle Description  Div Start  -->
                                        <div class="box4 basic" style="width: 99%; margin: 0 0 5px 0">
                                            <div class="h3b" onclick="javascript:choice('2')">
                                                <a>Vehicle Description <i class="non">(You may add or modify these later)</i></a>
                                                <div class="close ">
                                                </div>
                                            </div>
                                            <div id="div2" style="background: #fff;">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="form1">
                                                    <tbody>
                                                        <tr>
                                                            <td rowspan="12" width="155" valign="top" style="padding-right: 0px;">
                                                                Features
                                                                <br />
                                                                <br />
                                                                <em>(You may add or modify these later.)</em>
                                                            </td>
                                                            <td valign="top">
                                                                <div>
                                                                    <em><b>Interior Options</b></em>
                                                                    <asp:CheckBoxList ID="chklstIneriorOptions" runat="server" RepeatDirection="Vertical">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </td>
                                                            <td valign="top">
                                                                <div>
                                                                    <em><b>Exterior Options</b></em>
                                                                    <asp:CheckBoxList ID="chklstExteriorOptions" runat="server" RepeatDirection="Vertical">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                                <div>
                                                                    <em><b>Safety Options</b></em>
                                                                    <asp:CheckBoxList ID="chklstSafetyOptions" runat="server" RepeatDirection="Vertical">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table id="vSellpointsbox" border="0" cellpadding="0" cellspacing="0" style="width: 100%;"
                                                    class="form1">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="5" style="height: 10px;">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 140px; padding-right: 10px; vertical-align: top">
                                                                Additional Selling Points
                                                            </td>
                                                            <td>
                                                                <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence"><span id="sellingPointCharCount">
                                                                    1000</span> characters left</span><br />
                                                                    <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Rows="8" cols="10"
                                                                        onchange="updateCharCount(this,'sellingPointCharCount');" onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                        class="textarea" MaxLength="1000"></asp:TextBox>
                                                                </span>
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
                                        <table style="width: 98%" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td style="width: 190px;">
                                                    &nbsp;
                                                </td>
                                                <td style="padding-top: 5px; text-align: left;">
                                                    <div style="width: 110px; float: left">
                                                        <asp:UpdatePanel ID="updatepnlSave" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btnContinue" runat="server" CssClass="button" OnClientClick="return Validate();"
                                                                    Text="Continue" OnClick="btnContinue_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div style="width: 120px; float: left; padding-top: 5px;">
                                                        &nbsp; Already user? <a href="Login.aspx">Login</a> &nbsp;
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <!-- Contact Information  Div End  -->
                                    <!-- Regi End  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Login Page End  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="clear">
                        &nbsp;</div>
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
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists" OkControlID="btnExustCls"
        CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
            
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
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
    </form>

    <script type="text/javascript">


        $(function() {

            $('a').each(function() {
                if ($(this).attr('href') == '#') {
                    $(this).attr('href', 'javascript:void(0)')
                }
            });

        });	
    
    
   
    </script>

</body>
</html>
