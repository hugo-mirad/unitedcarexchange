<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dummy.aspx.cs" Inherits="Dummy" %>
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
                    <h2 style="margin-bottom: 10px; padding-bottom: 10px; color: #555; font-size: 16px;">
                        Recent Used Truck Listings</h2><small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                    <!-- Left Brand Ads Satrt -->
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <h3 class="headding2">
                        Headding</h3>
                    <h3 class="headding3">
                        Headding</h3>
                    <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0" class="form1">
                        <tr id="methodOfContactEmail">
                            <td style="width: 120px;">
                                Email Address
                            </td>
                            <td>
                                <input value="" name="contactEmail" maxlength="150" type="text" style="width: 200px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr id="methodOfContactConfirmEmail">
                            <td>
                                Password
                            </td>
                            <td>
                                <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="2" style="padding-top: 5px;">
                                <div style="width: 95px; float: left">
                                    <input type="button" class="button" value="Login" />
                                </div>
                                <p style="padding: 0; margin: 6px 0 0 0;">
                                    <a href="#">Forgot password?</a> &nbsp; &nbsp; <a href="Registration.aspx">Register</a>
                                </p>
                            </td>
                        </tr>
                    </table>
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
	
		$('a').each(function(){
			if($(this).attr('href') == '#'){
				$(this).attr('href','javascript:void(0)')
			}
		});	 
		
	});	
    
    
   
    </script>

</body>
</html>
