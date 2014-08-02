<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <link href="css/layout.css" rel="stylesheet" type="text/css" />

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
            if ($('#txtContcname').val().trim().length < 1) {
                $('#txtContcname').focus();
                alert("Enter contact name");
                $('#txtContcname').val('');
                $('#txtContcname').focus()

                valid = false;
            }


            else if ($('#txtphone').val().trim().length < 1) {
                $('#txtphone').focus();
                alert("Enter phone #");
                $('#txtphone').val('');
                $('#txtphone').focus()
                valid = false;

            }

            else if (($('#txtphone').val().trim().length > 0) && ($('#txtphone').val().trim().length < 10)) {
                $('#txtphone').focus();
                $('#txtphone').val(''); ;
                alert("Enter valid phone #");
                valid = false;

            }


            else if ($('#txtemail').val().trim().length < 1) {
                $('#txtemail').focus();
                alert("Enter email");
                $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;

            }

            else if (($('#txtemail').val().trim().length > 0) && (echeck($('#txtemail').val()) == false)) {

                $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;


            }

            else if ($('#txtZip').val().trim().length > 0) {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#txtZip').val());
                if (isValid == false) {
                    $('#txtZip').focus();
                    alert("Please enter valid zipcode");
                    $('#txtZip').val('');
                    $('#txtZip').focus()
                    valid = false;
                    return valid;
                }
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

        function pageLoad() {
            GetRecentListings();
        }
        function isNumberKeyWithDashForZip(evt) {
            debugger

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
   
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
                    <!-- Left Brand Ads Satrt -->
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="info-box" style="background: #fff;">
                        <div class="wrapper">
                            <table>
                                <tr>
                                    <td style="padding-right: 20px; padding-top: 10px;">
                                        <h2>
                                            Contact Us
                                        </h2>
                                    </td>
                                </tr>
                            </table>
                            <div style="border-top: #ccc 1px solid; border-bottom: #ccc 1px solid; padding: 15px 10px;
                                width: 95%;">
                                <table style="width: 98%;" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 58%; border-right: 1px solid #ccc; vertical-align: top">
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
                                                </tr>
                                                <tr>
                                                    <td id="oeFormcontactType1Container1">
                                                        Phone <span class="star">*</span>
                                                    </td>
                                                    <td>
                                                        <span id="Span1">
                                                            <asp:TextBox ID="txtphone" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </span>
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
                                                </tr>
                                                <tr>
                                                    <td id="Td3">
                                                        Address
                                                    </td>
                                                    <td>
                                                        <span id="Span4">
                                                            <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                                        </span>
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
                                                </tr>
                                                <tr>
                                                    <td id="Td1">
                                                        State
                                                    </td>
                                                    <td>
                                                        <span id="Span2">
                                                            <asp:TextBox ID="txtDealerShipName" runat="server" MaxLength="25" Width="200px"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="Td5">
                                                        Zip
                                                    </td>
                                                    <td>
                                                        <span id="Span6">
                                                            <asp:TextBox ID="txtZip" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="Td2" style="vertical-align: top">
                                                        Notes
                                                    </td>
                                                    <td>
                                                        <span id="Span3">
                                                            <asp:TextBox ID="txtDealerNotes" runat="server" MaxLength="500" Width="200px" Height="60px"
                                                                TextMode="MultiLine"></asp:TextBox>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="padding-top: 5px;">
                                                        <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Submit"
                                                            class="button1" OnClick="btnregister_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td style="vertical-align: top; padding-left: 15px;">
                                            <p>
                                                <h3>
                                                    United Truck Exchange</h3>
                                                <strong>P.O. Box #504<br />
                                                    Iselin, NJ 08830-0504</strong>
                                                <br />
                                                <br />
                                                <h3>
                                                    Customer service</h3>
                                                <strong>Phone: </strong>888-786-8307
                                                <br />
                                                <strong>Working Hours: </strong>9 AM to 5 PM EST (<i style="font-size: 11px; color: #666">Mon-Fri</i>)
                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="clear">
                            </div>
                            <br />
                           
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
    <!-- Footer End  -->
    <!-- Processiong Popup Start -->
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="popupBody" style="display: block" id="AlertUser">
        <div>
            <br />
            
            <h3 class="h3">
                Our marketing specialist will be contacting you shortly.
                <br />
                Thank you for your interest in United Truck Exchange</h3>
                <br />
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div>
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
