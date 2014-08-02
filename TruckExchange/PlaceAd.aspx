<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlaceAd.aspx.cs" Inherits="PlaceAd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title1" runat="server"></title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />

    
    

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>
    
        <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function isNumberKey(evt) {
            debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
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
        function isNumberKeyWithDashForZip(evt) {
            debugger

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }

        function ValidateVehicleType() {
            debugger
            var valid = true;


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

           
            if ($('#<%=txtZip.ClientID%>').val().trim().length > 0) {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#<%=txtZip.ClientID%>').val());
                if (isValid == false) {
                    $('#<%= txtZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                    $('#<%=txtZip.ClientID%>').val('');
                    $('#<%=txtZip.ClientID%>').focus()
                    valid = false;
                    return valid;
                }

            }

            if (($('#<%=txtSellerPhone.ClientID%>').val().trim().length > 0) && ($('#<%=txtSellerPhone.ClientID%>').val().trim().length < 10)) {
                $('#<%= txtSellerPhone.ClientID%>').focus();
                alert("Please enter valid phone number");
                $('#<%=txtSellerPhone.ClientID%>').val('');
                $('#<%=txtSellerPhone.ClientID%>').focus()
                valid = false;
                return valid;
            }
            if (($('#<%=txtSellerEmail.ClientID%>').val().trim().length > 0) && (echeck($('#<%=txtSellerEmail.ClientID%>').val()) == false)) {

                $('#<%=txtSellerEmail.ClientID%>').val('');                
                $('#<%=txtSellerEmail.ClientID%>').focus()
                valid = false;


            }

            return valid;
        }


        function ValidateVehicleInfo() {
            var valid = true;
            if ($('#<%=txtZip.ClientID%>').val().trim().length < 1) {
                $('#<%= txtZip.ClientID%>').focus();
                alert("Please enter zipcode");
                $('#<%=txtZip.ClientID%>').val('');
                $('#<%=txtZip.ClientID%>').focus()
                valid = false;
            }

            else if ($('#<%=txtZip.ClientID%>').val().trim().length < 4) {
                $('#<%= txtZip.ClientID%>').focus();
                alert("Enter valid zipcode");
                $('#<%=txtZip.ClientID%>').val('');
                $('#<%=txtZip.ClientID%>').focus()
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

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script type="text/javascript">

        function pageLoad() {
            GetRecentListings();
        }

       

       
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="BtnSavePanel"
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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updtpnlStatus"
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
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px; background:#fff"
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
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div id="column-right" class="column-indent">
                        <div class="indent">
                            <div class="wrapper">
                                <table style="float: left; width: 370px;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="padding-right: 20px; padding-top: 10px;">
                                            <h2>
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
                                                        <div id="lblPackDiv" runat="server" style="display: none">
                                                            <asp:Label ID="lblPackageName" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <%-- <h4>
                                                <a href="SellRegi.aspx" target="_blank">Learn about packages</a></h4>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div style="width: 340px; float: right; padding: 0; text-align: right; padding-top: 40px">
                                    <asp:UpdatePanel ID="updtpnlStatus" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnActive" runat="server" CssClass="button" Text="Active" Style="float: right;
                                                margin-left: 8px;" Visible="false" OnClick="btnActive_Click" />
                                            <asp:Button ID="btnSold" runat="server" CssClass="button" Text="Sold" Style="float: right;
                                                margin-left: 8px;" Visible="false" OnClick="btnSold_Click" />
                                            <asp:Button ID="btnWithdraw" runat="server" CssClass="button" Text="Withdraw" Style="float: right;
                                                margin-left: 8px;" Visible="false" OnClick="btnWithdraw_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                                <td style="width: 80px; padding-right: 10px;">
                                                    Year <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlYear" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Type <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="updtType" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Category <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlCategory" runat="server">
                                                                <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Make <span class="star">*</span>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="updtMake" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddlMake" runat="server">
                                                                <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Model
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtModel" runat="server" MaxLength="50"></asp:TextBox>
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
                                            <td style="width: 80px">
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
                                                            <asp:TextBox ID="txtZip" runat="server" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"
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
                                                        Title <span style="font-size: 11px">(Ex: 2007 Travel Trailer Aerolite Cub 235 - $13,500)</span>
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
                                                        <asp:UpdatePanel ID="UpdatePanelhrsep" runat="server">
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
                                                    <td style="width: 550px;">
                                                        <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence"><span id="sellingPointCharCount">
                                                            1000</span> characters left</span><br />
                                                            <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Rows="8" cols="10"
                                                                onchange="updateCharCount(this,'sellingPointCharCount');" onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                class="textarea" MaxLength="1000"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                    <%--  <td>
                                                        <p>
                                                            Include information on additional equipment, how you have cared for the vehicle,
                                                            Kelley Blue Book value and anything else that will help sell your vehicle.<br />
                                                        </p>
                                                    </td>--%>
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
                                <!-- Seller Type  Div Start  -->
                                <!-- Seller Type  Div End  -->
                                <div class="clear">
                                </div>
                                <div class="searchResultsBox">
                                    <h3>
                                        Multi-site Listings</h3>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                            <div class="not" id="divlblMultiSite" runat="server" style="display: block;">
                                                <asp:Label ID="lblExistUrlRes" runat="server"></asp:Label></div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Panel ID="Panel2" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="100%" ID="grdMultiSites" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false">
                                                    <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle CssClass="headder" />
                                                    <PagerSettings Position="Top" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <RowStyle CssClass="row1" />
                                                    <AlternatingRowStyle CssClass="row2" />
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="htlnkURLListed" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),90)%>'
                                                                    NavigateUrl='<%# String.Format("http://{0}", Eval("URL").ToString()) %>' Target="_blank"></asp:HyperLink>
                                                                <asp:HiddenField ID="hdnUrlToNav" runat="server" Value='<%# Eval("URL")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdMultiSites" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                                <br />
                                <asp:UpdatePanel ID="BtnSavePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSaveCarDetails" runat="server" CssClass="button" Text="Proceed"
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
                            <div style="width: 97%; margin: 0 auto">
                            </div>
                        </div>
                        <!-- Results End -->
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
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="BtnCls"
        OkControlID="btnNo">
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
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" />
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Yes" OnClick="btnYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepActiveAd" runat="server" PopupControlID="divActiveAd"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnActiveAd" OkControlID="btnGo">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnActiveAd" runat="server" />
    <div class="popupBody" style="display: block" id="divActiveAd">
        <div>
            <br />
            <br />
            <p class="pp">
                Inorder to active your listing please contact our customer support.
            </p>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" />
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
