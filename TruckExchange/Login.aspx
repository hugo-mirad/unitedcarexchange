<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script type="text/javascript">

        function pageLoad() {
            debugger
            GetRecentListings();
        } 
    </script>

    <script type="text/javascript" language="javascript">

        function ValidateDetails() {
            var valid = true;

            if (document.getElementById("txtEmail").value == "") {
                alert('Please enter email')
                valid = false;
                $('#txtEmail').focus();
                if ($('#lblError') != null) {
                    $('#lblError').outerText = "";
                }
            }

            else if (document.getElementById("txtPassword").value == "") {
                alert("Please enter password");
                valid = false;
                $('#txtPassword').focus();
                if ($('#lblError') != null) {
                    $('#lblError').outerText = "";
                }
            }
            return valid;
        }

        function ShowPW() {
            debugger
            $('#txtForgetUserName').val('');
            $find('mpeChangePW').show();

            return false;
        }

        function ValidateChangePW() {

            var valid = true;

            if ($('#<%=txtForgetUserName.ClientID%>').val().trim().length < 1) {
                alert('Please enter email')
                valid = false;
                $('#<%=txtForgetUserName.ClientID%>').val('');
                $('#<%=txtForgetUserName.ClientID%>').focus()
                return valid;
            }
            else {
                $find('mpeChangePW.ClientID%>').hide();
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updatepnlLogin"
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
                    <!-- Left Brand Ads Satrt -->
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <h3 class="headding2">
                        Login</h3>
                    <table style="width: 450px; padding: 20px; margin: 20px auto 80px auto" cellspacing="0"
                        cellpadding="0" border="0" class="form1">
                        <tr id="methodOfContactEmail">
                            <td style="width: 120px;">
                                Email Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="150" Width="200px"></asp:TextBox>
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
                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="150" Width="200px" TextMode="Password"></asp:TextBox>
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
                                    <asp:UpdatePanel ID="updatepnlLogin" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="button" OnClientClick="return ValidateDetails();"
                                                OnClick="btnLogin_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <p style="padding: 0; margin: 6px 0 0 0;">
                                    <asp:LinkButton ID="lnkForgetPwd" runat="server" Text="Forgot password?" OnClientClick="return ShowPW();"
                                        OnClick="btnSendPwd_Click"></asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkRegister" runat="server" Text="Register" OnClick="lnkRegister_Click"></asp:LinkButton>
                                </p>
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
        <div class="clear">
            &nbsp;</div>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        <uc3:TruckFooter ID="TruckFooter1" runat="server" />
    </div>
    <cc1:ModalPopupExtender ID="mpeChangePW" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none; background-color: #adbc79; width: 400px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="2" style="background: #FFB113 url(images/AccordionTab2.jpg); height: 20px;
                    padding: 10px 0px; color: #fff; text-align: center; font-family: Verdana; font-size: 12px;
                    text-transform: uppercase; font-weight: bold;">
                    Forget Password
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
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="updtPnlForgetPwd" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnSendPwd" CssClass="button" runat="server" Text="Get Password"
                                                        OnClientClick="return ValidateChangePW();" OnClick="btnSendPwd_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelPW" CssClass="button" runat="server" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
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
