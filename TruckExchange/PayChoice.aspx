<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayChoice.aspx.cs" Inherits="NewTrucks" %>

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
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px; background:#fff"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="info-box" style="background: #fff;">
                        <div class="wrapper">
                            <!-- Box2 Div Start  -->
                            <div class="box3">
                                <div class="wrapper">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="width: 65%; border-right: #77defa 1px dotted; padding: 10px;">
                                                <div>
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
                                                    <div>
                                                        <h2 style="color: #ff9900; font-size: 18px">
                                                            Choose a payment method</h2>
                                                    </div>
                                                    <table border="0" class="form1" cellpadding="5" cellspacing="0" width="500">
                                                        <tr>
                                                            <td class="box6" style="text-align: center">
                                                                <img src="images/Paypal.jpg" /><br />
                                                                Pay using PayPal<br />
                                                                <br />
                                                                <div>
                                                                    <% if (Session["PackageID"].ToString() == "2")
                                                                       {


                                                                           Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                                           Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"YUKBUWEAC6CYS\">");
                                                                           
                                                                           Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");






                                                                       }
                                                                       else if (Session["PackageID"].ToString() == "3")
                                                                       {


                                                                           Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                                           Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"FY9GMQTWTX6R8\">");
                                                                           
                                                                           Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");


                                                                       }
                                                                       else if (Session["PackageID"].ToString() == "4")
                                                                       {
                                                                           Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                                           Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"FY9GMQTWTX6R8\">");
                                                                           
                                                                           Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");



                                                                       }
                                                                       else if (Session["PackageID"].ToString() == "5")
                                                                       {

                                                                           Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                                           Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"5FFSKY7QD7AKY\">");                                                                           
                                                                           Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");



                                                                       }
                                                                       else if (Session["PackageID"].ToString() == "6")
                                                                       {


                                                                           Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                                           Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"A9YWDM2WPPM6C\">");
                                                                           Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");


                                                                       }
                                                                    %>
                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://www.paypalobjects.com/en_US/i/btn/btn_paynowCC_LG.gif"
                                                                        PostBackUrl="https://www.paypal.com/cgi-bin/webscr" />
                                                                </div>
                                                            </td>
                                                            <td style="width: 20px;">
                                                                &nbsp;
                                                            </td>
                                                            <td class="box6" style="text-align: center">
                                                                <img src="images/CreditCard.jpg" /><br />
                                                                Pay using Authorize.Net
                                                                <br />
                                                                <asp:ImageButton ID="paymode" runat="server" ImageUrl="images/cards.jpg"
                                                                    PostBackUrl="~/pay.aspx" OnClick="paymode_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="width: 100%; margin: 10px 0; border-bottom: #ccc 1px solid; clear: both;
                                                        height: 2px;">
                                                        &nbsp;</div>
                                                </div>
                                                <br />
                                                <br />
                                                &nbsp;
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
