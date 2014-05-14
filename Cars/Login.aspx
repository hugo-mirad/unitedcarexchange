<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="#">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/chosen/chosen.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>Packages</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="content" class="pricing-page">
        <div id="page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="heading">
                            <div class="title">
                                <h1>
                                    Login</h1>
                            </div>
                            <!-- /.title -->
                        </div>
                        <!-- /.heading -->
                    </div>
                    <!-- /.col-md-8 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /#page-heading -->
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div id="main">
                            <div class=" row">
                                <div class="col-xs-1 col-sm-1 col-md-2 ">
                                </div>
                                <div class="col-xs-10 col-sm-10 col-md-8 " style="padding-top: 10px; ">
                                    <div class="pricing" style="margin-bottom: 20px;">
                                        <div class="row " style="padding-top: 30px;">
                                            <div class="col-sm-8 col-md-8 col-lg-6 block-margin" style="float:none; margin:0 auto 40px auto;">
                                                <div class="pricing-package block block-shadow white" >
                                                    <div class="block-inner">
                                                        <div class="title">
                                                            <h2>
                                                                Customer Login</h2>
                                                        </div>
                                                        <div class="form-section">
                                                            <div class="form-group ">
                                                                <label>
                                                                    User ID <span class="star">*</span></label>
                                                                <asp:TextBox ID="txtCustLogUserID" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group ">
                                                                <label>
                                                                    Password <span class="star">*</span></label>
                                                                <asp:TextBox ID="txtCustLogUserPwd" runat="server" MaxLength="50" TextMode="Password"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="action-button">
                                                            <asp:UpdatePanel ID="UpdatePanelCustLogin" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnUserLogin" runat="server" Text="Login" CssClass="btn btn-primary"
                                                                        OnClientClick="return Uservalidation();" OnClick="btnUserLogin_Click" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            &nbsp;<br />
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Forgot password?" CssClass="btn btn-link"
                                                                OnClientClick="return ShowPW();"></asp:LinkButton>
                                                            &nbsp;
                                                            <asp:LinkButton ID="LinkButton2" runat="server" Text="Register" CssClass="btn btn-link"
                                                                OnClick="lnkRegister_Click"></asp:LinkButton>
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Label ID="lblUserLogError" runat="server" ForeColor="Red"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 col-md-6 block-margin" style="display:none;" >
                                                <div class="pricing-package  block block-shadow white" style="min-height: 420px">
                                                    <div class="block-inner">
                                                        <div class="title">
                                                            <h2>
                                                                Dealer Login</h2>
                                                        </div>
                                                        <div class="form-section">
                                                            <div class="form-group " id="delearBox" runat="server">
                                                                <label>
                                                                    Dealer ID <span class="star">*</span></label>
                                                                <asp:TextBox ID="txtDealer" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group ">
                                                                <label>
                                                                    User ID<span class="star">*</span></label>
                                                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="form-group ">
                                                                <label>
                                                                    Password<span class="star">*</span></label>
                                                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="action-button">
                                                            <asp:UpdatePanel ID="updatepnlLogin" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary"
                                                                        OnClientClick="return ValidateDetails();" OnClick="btnLogin_Click" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-1 col-sm-1 col-md-2 ">
                                </div>
                            </div>
                            <div class="row white block-shadow" style="margin: 0 0 30px 0; padding: 20px;">
                                <div class="col-sm-6 col-md-9">
                                    <h3 class="h3">
                                        Sell Your Car- Easy & Fast With Our Premium Packages</h3>
                                    <p>
                                        More then a million cars sold, already - Sign up for MobiCarz Premium Packages.</p>
                                    <input type="button" class="btn btn-primary" value="Sign Up for Premium Packages"
                                        style="display: inline-block; width: auto" onclick="window.location.href='Premium.aspx' " />
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <h3 class="h3">
                                        Used Cars Advertising</h3>
                                    <i class="i1">We help you grow your business</i><div class="clear">
                                    </div>
                                    View our <a href="Packages.aspx">Advertising Plans</a>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /#main -->
                    </div>
                    <!-- /.col-md-12 -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
    </div>
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    <cc1:ModalPopupExtender ID="mpeChangePW" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none;" class="alert">
        <h4 id="H2">
            Forgot Password
            <asp:Button ID="Button1" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class=" data">
            <table style="width: 100%; margin: 10px auto;">
                <tr>
                    <td style="padding-left: 5px; width: 120px">
                        Email Address<span class="star">*</span>
                    </td>
                    <td style="padding-right: 5px;">
                        <asp:TextBox ID="txtForgetUserName" MaxLength="70" CssClass=" form-control " runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td style="padding: 16px 0 0 0;">
                        <div style="width: 100%; margin: 0; padding-left: 0">
                            <div class="pull-left" style="width: 120px">
                                <asp:UpdatePanel ID="updtPnlForgetPwd" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSendPwd" class="btn btn-primary2 " runat="server" Text="Get Password"
                                            OnClientClick="return ValidateChangePW();" OnClick="btnSendPwd_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <asp:Button ID="btnCancelPW" class="btn btn-default" runat="server" Text="Cancel" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
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

    <script src="libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="libraries/star-rating/jquery.rating.js"></script>

    <script src="libraries/colorbox/jquery.colorbox-min.js"></script>

    <script src="js/jslider/jquery.slider.min.js"></script>

    <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

    <script src="http://maps.googleapis.com/maps/api/js?sensor=true&amp;v=3.13"></script>

    <script src="assets/js/carat.js"></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        var LoadingPage = 6;
        function EmailNAClick() {
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
            else if ($('#txtEmail').val().trim() == "") {
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
        function Uservalidation() {
            var valid = true;

            if ($('#txtCustLogUserID').val().trim() == "") {
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


        $(function() {
            $('#txtCustLogUserID').focus();
        })

    </script>

    </form>
</body>
</html>
