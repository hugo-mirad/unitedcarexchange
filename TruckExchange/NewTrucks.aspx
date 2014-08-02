<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewTrucks.aspx.cs" Inherits="NewTrucks" %>

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
    <link href="css/page1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

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
            var valid = true;
            if ($('#txtContactName').val().trim().length < 1) {
                $('#txtContactName').focus();
                alert("Enter name");
                $('#txtContactName').val('');
                $('#txtContactName').focus()

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
                $('#txtemail').focus();
                valid = false;

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
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px;
            background: #fff" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                        <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
                            Recent Used Truck Listings</h2>
                        <small>
                            <e style="font-size: 11px;">Most recent Used Trucks listed for sale</e>
                        </small>
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
                                    <td style="vertical-align: top;">
                                        <!-- Box1 Div Start  -->
                                        <div class="box1">
                                            <div class="inner">
                                                <div class="wrapper" id="searchFormHolder" runat="server">
                                                    <h3 class="h3">
                                                        Find New Trucks</h3>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                    <div class="clear dummyHeight8">
                                                        &nbsp;</div>
                                                    <div class="width-1" style="width: 280px">
                                                        <div class="black2">
                                                            Name <span class="star" style="color: Red">*</span></div>
                                                        <asp:TextBox ID="txtContactName" runat="server" MaxLength="25" CssClass="input1"
                                                            Style="width: 260px;"></asp:TextBox>
                                                    </div>
                                                    <div class="clear dummyHeight8">
                                                        &nbsp;</div>
                                                    <div class="width-1" style="width: 280px">
                                                        <div class="black2">
                                                            Phone Number <span class="star" style="color: Red">*</span></div>
                                                        <asp:TextBox ID="txtphone" runat="server" MaxLength="10" class="input1 sample4" Style="width: 260px;"
                                                            onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </div>
                                                    <div class="clear dummyHeight8">
                                                        &nbsp;</div>
                                                    <div class="width-1" style="width: 280px">
                                                        <div class="black2">
                                                            Email <span class="star" style="color: Red">*</span></div>
                                                        <asp:TextBox ID="txtemail" runat="server" MaxLength="30" Width="260px" CssClass="input1"></asp:TextBox>
                                                    </div>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                    <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Register"
                                                        class="button1 but1 ser" OnClick="btnregister_Click" />
                                                    <br />
                                                </div>
                                                <!-- <b><a href="#" onclick="document.getElementById('car-form').submit()"></a></b> -->
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <!-- Box1 Div End  -->
                                    </td>
                                    <td style="vertical-align: top;">
                                        <!-- Box2 Div Start  -->
                                        <div class="box2">
                                            <div class="wrapper">
                                                <h3 class="h3">
                                                    New Trucks</h3>
                                                <img src="images/used-car.jpg" alt="" style="margin: 0 0 6px 6px; float: right; width: 49%;
                                                    padding: 4px; border: #ccc 1px solid" />
                                                <p>
                                                    We also deal with "New Trucks" where people can search new Trucks available within
                                                    their customized radius and specifications. United Truck Exchange provides detailed
                                                    truck information about each and every truck make & model, pricing information,
                                                    truck description, monthly calculator tools, photo galleries and also with customer
                                                    reviews which helps to take confident decisions to buy your new truck.</p>
                                                <p>
                                                    United Truck Exchange is the America's most trusted Online Buy & Sell used truck
                                                    agency. United Truck Exchange helps in providing an online platform where truck
                                                    buyers and sellers can search, buy, sell and come together to talk about their New
                                                    Trucks.</p>
                                                
                                                <div class="clear">
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Box2 Div End  -->
                                    </td>
                                </tr>
                            </table>
                            <div class="clear">
                            </div>
                            <!-- Box2 Div Start  -->
                            <div class="box3">
                                <div class="wrapper">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 65%; border-right: #77defa 1px dotted; padding: 10px;">
                                                <h3 class="h3">
                                                    Sell Your Truck - Easy & Fast!</h3>
                                                <p>
                                                    More then a million Trucks sold, already - Advertise with us.</p>
                                                <input type="button" class="button1" value="LIST YOUR TRUCK NOW" onclick="window.location.href='Registration.aspx'" />
                                            </td>
                                            <td style="padding: 10px;">
                                                <h3 class="h3">
                                                    Used Trucks Advertising</h3>
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
                            <div class="ads1">
                            </div>
                            <!-- Ads Section Endt  -->
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
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser1" runat="server" />
    <div class="popupBody" runat="server" style="display: block" id="AlertUser">
        <div>
            <h3 class="h3">
                Your New Truck request will be shared with participating pre-qualified local dealers
                in your area. They will be contacting you directly.</h3>
                <br />
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
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
