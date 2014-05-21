<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCars.aspx.cs" Inherits="NewCars"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css"
        media="screen, projection">
    <link href="js/jslider/jquery.slider.min.css" rel="stylesheet" type="text/css"
        media="screen, projection" />
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    
    
    <div id="page-heading">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="heading">
                        <div class="title">
                            <h1>
                                New Cars</h1>
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
    <div id="content" class="page-about">
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="article">
                                <div class="col-xs-12 col-sm-4 col-md-4">
                                    <div class="block-inner white block-shadow">
                                        <div class="picture " style=" margin-bottom:0; " >
                                            <h2>Find New Cars</h2>
                                            <div id="searchFormHolder" runat="server">
                                                <div class="form-section">
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                        
                                                           <label> Name <span class="star" style="color: Red">*</span></label>
                                                        <asp:TextBox ID="txtContactName" runat="server" MaxLength="25" CssClass="form-control"
                                                            ></asp:TextBox>
                                                    </div>
                                                    
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                        <label> 
                                                            Phone Number <span class="star" style="color: Red">*</span></label>
                                                        <asp:TextBox ID="txtphone" runat="server" MaxLength="10"  CssClass="form-control sample4"
                                                            onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </div>
                                                    
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                        <label> 
                                                            Email <span class="star" style="color: Red">*</span></label>
                                                        <asp:TextBox ID="txtemail" runat="server" MaxLength="30"  CssClass="form-control "></asp:TextBox>
                                                    </div>
                                                    <div class="form-group col-sm-12 col-md-12" >
                                                    <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Register"
                                                        class=" btn btn-primary2 " OnClick="btnregister_Click" />
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.picture -->
                                    </div>
                                    <!-- /.inner -->
                                </div>
                                <div class="col-xs-12 col-sd-6 col-md-8">
                                    <div class="description">
                                        <p>
                                            We deal with "New Cars" where people can search new cars available within their
                                            customized radius and specifications. MobiCarz provides detailed car information
                                            about each and every car make & model, pricing information, car description, monthly
                                            calculator tools, photo galleries and also with customer reviews which help to make
                                            confident decisions to buy your new car.</p>
                                        <p>
                                            MobiCarz is America's most trusted Online Buy & Sell used car agency. MobiCarz provides
                                            an online platform where car buyers and sellers can search, buy, sell and come together
                                            to talk about their new cars.</p>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.col-md-12 -->
                </div>
                <!-- /.row -->
                <div id="content-bottom">
                <div class="row">
                        <div class="col-md-12">
                            <div class="row white block-shadow" style="margin: 30px 0; padding: 10px 10px 20px 10px;">
                                <div class="col-sm-12 col-md-12">
                                    <h3 class="h3">
                                        Sell Your Car- Easy & Fast With Our Ultimate Packages</h3>
                                    <p>
                                       More then a million cars sold, already. </p>
                                    <input type="button" class="btn btn-primary" value="Sign Up For MobiCarz Packages"
                                        style="display: inline-block; width: auto" onclick="window.location.href='SellRegi.aspx' " />
                                </div>
                                <div class="col-sm-6 col-md-3" style=" display:none">
                                    <h3 class="h3">
                                        Used Cars Advertising</h3>
                                    <i class="i1">We help you grow your business</i><div class="clear">
                                    </div>
                                    View our <a href="Packages.aspx">Advertising Plans</a>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                
                    <div class="row">
                        <div class="col-md-12">
                            <div class="testimonials-block block">
                                <div class="page-header center">
                                    <div class="page-header-inner">
                                        <div class="line">
                                            <hr />
                                        </div>
                                        <div class="heading">
                                            <h2>
                                                Our Satisfied Customers</h2>
                                        </div>
                                        <!-- /.heading -->
                                        <div class="line">
                                            <hr />
                                        </div>
                                        <!-- /.line -->
                                    </div>
                                    <!-- /.page-header-inner -->
                                </div>
                                <!-- /.page-header -->
                                <div class="row">
                                    <div class="col-sm-12 col-md-6">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                   <%-- <div class="col-sm-3 col-md-4">
                                                        <div class="picture">
                                                            <img src="assets/img/testimonials-1.png" alt="#">
                                                        </div>
                                                        <!-- /.picture -->
                                                    </div>--%>
                                                    <!-- /.col-md-4 -->
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I have bought a Mercedes-Benz SLS AMG Roadster using MobiCarz.com, Thank
                                                                    you very much it's a breathtaking super sports car with the genes of the SLS AMG
                                                                    Coupe. Loving my Car :) </i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star0" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                        </div>
                                                        <!-- /.star-rating -->
                                                        <div class="author">
                                                            <strong>Lisa Turner</strong>
                                                        </div>
                                                        <!-- /.author -->
                                                    </div>
                                                    <!-- /.col-md-8 -->
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.inner -->
                                        </div>
                                        <!-- /.testimonial -->
                                    </div>
                                    <!-- /.col-md-6 -->
                                    <div class="col-sm-12 col-md-6">
                                        <div class="testimonial white">
                                            <div class="inner">
                                                <div class="row">
                                                  <%--  <div class="col-sm-3 col-md-4">
                                                        <div class="picture">
                                                            <img src="assets/img/testimonials-2.png" alt="#">
                                                        </div>
                                                        <!-- /.picture -->
                                                    </div>--%>
                                                    <!-- /.col-md-4 -->
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="description quote">
                                                            <p>
                                                                <i>I received the car yesterday. The people at the bond wanted me to sell it off to
                                                                    them. You chose a very nice and good car for my wife. I really want to thank the sales guy
                                                                    at MobiCarz. </i>
                                                            </p>
                                                        </div>
                                                        <!-- /.description -->
                                                        <div class="star-rating">
                                                            <input name="star1" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" checked="checked"
                                                                disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" disabled="disabled">
                                                            <input name="star1" type="radio" class="star icon-normal-star" disabled="disabled">
                                                        </div>
                                                        <!-- /.star-rating -->
                                                        <div class="author">
                                                            <strong>Thomas Garcia</strong>
                                                        </div>
                                                        <!-- /.author -->
                                                    </div>
                                                    <!-- /.col-md-8 -->
                                                </div>
                                                <!-- /.row -->
                                            </div>
                                            <!-- /.inner -->
                                        </div>
                                        <!-- /.testimonial -->
                                    </div>
                                    <!-- /.col-md-6 -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.testimonials-block -->
                        </div>
                        <!-- /.col-md-12 -->
                    </div>
                    <!-- /.row -->
                    
                </div>
                <!-- /#content-bottom -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
    </div>
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    <!-- Alert Start  -->
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="alert" style="display: block" id="AlertUser">
        <div class="data" >
            <p>
                Your new car request will be shared with participating pre-qualified local dealers
                in your area. They will be contacting you directly.
           </p>
            <asp:Button ID="btngo" runat="server" Text="Ok" class="btn btn-primary2" OnClick="btnGo_Click" />
        </div>
    </div>
    <!-- Alert  End -->

    <script src="libraries/jquery.bxslider/jquery.bxslider.js"></script>

    <script src="libraries/easy-tabs/lib/jquery.easytabs.min.js"></script>

    <script src="libraries/star-rating/jquery.rating.js"></script>

    <script src="libraries/colorbox/jquery.colorbox-min.js"></script>

    <script src="js/jslider/jquery.slider.min.js" type="text/javascript"></script>

    <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

    <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

    <script src="assets/js/carat.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type="text/javascript">

        function pageLoad() {
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
            var valid = true;
            if (document.getElementById('txtContactName').value.trim().length < 1) {
                document.getElementById('txtContactName').focus();
                alert("Enter contact name");
                document.getElementById('txtContactName').value = ""
                document.getElementById('txtContactName').focus()

                valid = false;
                return valid;
            }


            else if (document.getElementById('txtphone').value.trim().length < 1) {
                document.getElementById('txtphone').focus();
                alert("Enter phone #");
                document.getElementById('txtphone').value = ""
                document.getElementById('txtphone').focus()
                valid = false;
                return valid;
            }

            else if ((document.getElementById('txtphone').value.trim().length > 0) && (document.getElementById('txtphone').value.trim().length < 10)) {
                document.getElementById('txtphone').focus();
                document.getElementById('txtphone').value = "";
                alert("Enter valid phone #");
                valid = false;
                return valid;
            }


            else if (document.getElementById('txtemail').value.trim().length < 1) {
                document.getElementById('txtemail').focus();
                alert("Enter email");
                document.getElementById('txtemail').value = ""
                document.getElementById('txtemail').focus()
                valid = false;
                return valid;
            }

            else if ((document.getElementById('txtemail').value.trim().length > 0) && (echeck(document.getElementById('txtemail').value.trim()) == false)) {

                document.getElementById('txtemail').value = ""
                document.getElementById('txtemail').focus()
                valid = false;
                return valid;
            }
            return valid;
        }


        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function isNumberKeyWithDashForZip(evt) {


            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
    </script>

    </form>
</body>
</html>
