<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dealer.aspx.cs" Inherits="Dealer"
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
    <Scripts>
   
    </Scripts>
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="page-heading">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="heading">
                        <div class="title">
                            <h1>
                                Dealer Registration Form</h1>
                        </div>
                    
                    </div>
                 
                </div>
               
            </div>
           
        </div>
      
    </div>
    
    <div id="content" class="page-about">
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="article">
                                <div class="col-xs-12 col-md-9">
                                    <h3>
                                        Please fill in your information and one of our area marketing specialists will contact
                                        you.</h3>
                                    <div class="row">
                                        <div class="form-group col-sm-10 col-md-10 ">
                                            <label>
                                                Contact Name <span class="star">*</span></label>
                                            <asp:TextBox ID="txtContcname" CssClass="form-control" runat="server" MaxLength="25"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                Phone <span class="star">*</span></label>
                                            <asp:TextBox ID="txtphone" runat="server" MaxLength="10" CssClass="form-control"
                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                Email <span class="star">*</span></label>
                                            <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                Address</label>
                                            <asp:TextBox ID="txtRegAddress" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                City</label>
                                            <asp:TextBox ID="txtRegCity" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                ZIP</label>
                                            <asp:TextBox ID="txtZip" runat="server" MaxLength="10" CssClass="form-control" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                Dealership Name</label>
                                            <asp:TextBox ID="txtDealerShipName" runat="server" CssClass="form-control" MaxLength="25"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-6 col-md-5">
                                            <label>
                                                Notes</label>
                                            <asp:TextBox ID="txtDealerNotes" CssClass="form-control" runat="server" MaxLength="500"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-sm-12 col-md-12">
                                            <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Register"
                                                class="btn btn-primary2" OnClick="btnregister_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-3 ">
                                    <div class="block-inner white block-shadow sidebar">
                                        <div class="block-title" style="border-bottom: 1px solid #D9D9D9; margin-bottom: 15px;">
                                            <h3 style="margin: 0 0 10px 0; font-size: 20px;">
                                                Recent Cars</h3>
                                        </div>
                                        <div class="row ticker1">
                                            <ul>
                                                <li>
                                                    <div class="contentLoader">
                                                    </div>
                                                </li>
                                            </ul>
                                       
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                   
                </div>
                
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
                                <div class="col-sm-6 col-md-3" style="display:none" >
                                    <h3 class="h3">
                                        Used Cars Advertising</h3>
                                    <i class="i1">We help you grow your business</i><div class="clear">
                                    </div>
                                    View our <a href="Packages.aspx">Advertising Plans</a>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                           
                        </div>
                      
                    </div>
                   
                </div>
             
            </div>
          
        </div>
      
    </div>
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    
   
  <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="alert" style="display: block" id="AlertUser">
        <h4 id="H1">
            Info
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />           
        </h4>
        <div class="data">
            <p>
                Our marketing specialist will be contacting you shortly.
                <br />
                Thank you for your interest in United Truck Exchange.
                </p>
            <asp:Button ID="btnGo" class="btn btn-primary2" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div
   

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

    <script type="text/javascript" language="javascript">
        var LoadingPage = 10;
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
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#txtZip').value);
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

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function pageLoad() {
            GetRecentListings();
            $('.sample4').numeric();
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
