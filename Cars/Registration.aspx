<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html>

<head runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="#">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">    
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-outline/pictopro-outline.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/pictopro-normal/pictopro-normal.css"
        media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/colorbox/colorbox.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">

    <script src="assets/js/jquery.js"></script>
    
    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>
    
    <script src="assets/js/jquery.cookie.js" type="text/javascript"></script>
    
    <script>
        function backPage(){
            $('#spinner').show();
            window.location.href="Sellregi.aspx"
        }
    </script>
    

    <title>MobiCarz</title>
</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="content">
        <div id="progress" class="section">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step active" href="javascript:void(0);">
                            <div class="circle">
                                1
                            </div>
                            <div class="title">
                                Seller Information</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step inactive" href="javascript:void(0);">
                            <div class="circle">
                                2
                            </div>
                            <div class="title">
                                Vehicle Information</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step inactive" href="javascript:void(0);">
                            <div class="active circle">
                                3
                            </div>
                            <div class="title">
                                Vehicle Photos</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step inactive" href="javascript:void(0);">
                            <div class="circle active">
                                4</div>
                            <div class="title">
                                Payment Information</div>
                        </a>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <div class="section gray-light">
            <div class="container">
                <div class="row">
                    <div class="col-md-9">
                        <div id="main">
                            <div class="block checkout">
                                <div class="page-header">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Registration</h2>
                                        </div>
                                        <div class="line">
                                            <hr />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="block-inner white block-shadow">
                                            <div class="form-section">
                                                <div class="block-title">
                                                    <h3>
                                                        Personal Information</h3>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group ">
                                                            <label>
                                                                First Name <span class="star">*</span></label>
                                                            <asp:TextBox ID="txtContcname" runat="server" MaxLength="25" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group ">
                                                            <label>
                                                                Last Name <span class="star">*</span></label>
                                                            <asp:TextBox ID="TextBox1" runat="server" MaxLength="25" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                 </div>
                                                 <div class="row">   
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Phone <span class="star">*</span></label>
                                                            <asp:TextBox ID="txtphone" runat="server" MaxLength="10" CssClass="form-control"
                                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Alt Phone
                                                            </label>
                                                            <asp:TextBox ID="txtAltPhone" runat="server" MaxLength="10" CssClass="form-control"
                                                                onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                  </div>
                                                  <div class="row">  
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            E-mail <span class="star">*</span></label>
                                                        <asp:TextBox ID="txtemail" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            Confirm Email <span class="star">*</span></label>
                                                        <asp:TextBox ID="txtconfEmail" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                </div>
                                                <div class="row">
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            Password <span class="star">*</span></label>
                                                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" CssClass="form-control"
                                                            TextMode="Password" onkeyup="return checkValidPass();" ></asp:TextBox>
                                                           
                                                           <span style="display:none; color:red; font-size:12px; text-align:left;" class="InvalidPass" >Invalid Password Format.</span><br />
                                                           
                                                       <%-- <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" ValidationExpression=""
                                                            ErrorMessage="Invalid Password Format." ForeColor="Red" ControlToValidate="txtPassword"
                                                            runat="server">
                                                           

                                                        </asp:RegularExpressionValidator>--%>
                                                        
                                                        <small style="display: block; text-align: left; font-size: 11px;"><i>password must contains
                                                            atleast one alphabet,one numeric,one special character and minimum 8 characters
                                                            length. </i></small>
                                                    </div>
                                                </div>
                                               
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            Confirm Password <span class="star">*</span></label>
                                                        <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" CssClass="form-control"
                                                            TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </div>
                                                 </div>
                                            </div>
                                       
                                        <div class="form-section">
                                            <div class="block-title">
                                                <h3>
                                                    Business Information</h3>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group ">
                                                        <label>
                                                            Company Name
                                                        </label>
                                                        <asp:TextBox ID="txtBusinessName" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    </div>
                                                     <div class="col-sm-6 col-md-5">
                                                    <div class="form-group ">
                                                        <label>
                                                            Alt Email
                                                        </label>
                                                        <asp:TextBox ID="txtAltEmail" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            Address
                                                        </label>
                                                        <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="40" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                    </div>
                                                     <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            City</label>
                                                        <asp:TextBox ID="txtRegCity" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            State
                                                        </label>
                                                        <asp:DropDownList ID="ddlLocationState" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                    </div>
                                                     <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            ZIP</label>
                                                        <asp:TextBox ID="txtRegZip" runat="server" MaxLength="5" CssClass="form-control"
                                                            onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-section">
                                            <div class="block-title">
                                                <h3>
                                                    Coupon <small><i>( if available )</i></small></h3>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 col-md-5">
                                                    <div class="form-group">
                                                        <label>
                                                            Coupon
                                                        </label>
                                                        <asp:TextBox ID="txtCoupon" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-sm-3 col-md-3">
                                                    <div class="form-group">
                                                        <label>
                                                            Referred By</label>
                                                        <asp:TextBox ID="txtRefferedBy" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-section">
                                            <h4 style="text-align: right;">
                                                Already user? <a href="login.aspx">Login</a>
                                            </h4>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 sidebar">
                    <div class="block block-shadow extras white">
                        <div class="block-inner">
                            <div class="block-title">
                                <h3>
                                    Summary</h3>
                            </div>
                            <table class=" summary2  ">
                                <tbody>
                                    <tr>
                                        <td>
                                            <h4>
                                                Package</h4>
                                            <asp:Label ID="lblpackagename" runat="server"></asp:Label>
                                            <br />
                                            <p>
                                                <asp:Label ID="lblpackagFet" runat="server"></asp:Label>
                                            </p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="total">
                            <div class="title">
                                Total</div>
                            <div class="value">
                                <asp:Label ID="lblpckgprice" runat="server"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 col-md-9">
                    <div class="row">
                        <div class="checkout-actions">
                            <div class="col-sm-4 col-md-3">
                            <div class="prev">
                                    <a href="javascript:backPage();"  class="btn btn-primary">< Back</a>
                                  
                                </div>
                            </div>
                            <div class="col-sm-4 col-md-6">
                            </div>
                            <div class="col-sm-4 col-md-3">
                                <div class="next">
                                    <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Proceed >"
                                        class="btn btn-primary" OnClick="btnregister_Click" />
                                </div>
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
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="BtnCls_Click" />
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" OnClick="btnNo_Click" />
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Yes" OnClick="btnYes_Click" />
        </div>
    </div>
    
       <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists" OkControlID="btnExustCls"
        CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: block">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
          
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
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

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>
    
    

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    var LoadingPage = "6"
    
    function checkValidPass(){
        var str = $('#txtPassword').val();
        var patt = new RegExp("^(?=.*?[A-Za-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");      
        var res = patt.test(str);
        
        if(res == true){
            $('.InvalidPass').hide();
        }else{
            $('.InvalidPass').show();
        }
        return true;
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
             if ($('#txtContcname').val().trim().length< 1) {
                $('#txtContcname').focus();
                alert("Enter contact name");
                $('#txtContcname').val('')
                $('#txtContcname').focus()
                
                valid = false;
                return valid;
            }
            if($('#txtemail').val().trim().length < 1) {
                $('#txtemail').focus();
                alert("Enter email");
                 $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;            
                return valid;
            }
            
             if (($('#txtemail').val().trim().length > 0) && (echeck($('#txtemail').val().trim()) == false) )
             {
               
                $('#txtemail').val('');
                $('#txtemail').focus()
                valid = false;
                return valid;
           
            }
            
             if($('#txtconfEmail').val().trim().length < 1) {
                $('#txtconfEmail').focus();
                $('#txtconfEmail').val('');;
                alert("Enter confirm email");
                valid = false;            
                return valid;
            }
            
             
             if (($('#txtconfEmail').val().trim().length > 0) && (echeck($('#txtconfEmail').val().trim()) == false) )
             {
               
                $('#txtconfEmail').val('');
                $('#txtconfEmail').focus()
                valid = false;
                return valid;
           
            }
              if ($('#txtemail').val().trim() != $('#txtconfEmail').val().trim()) {
                $('#txtconfEmail').focus();
                 $('#txtconfEmail').val('');;
                alert("Email does not match the confirm email");
                valid = false;
                return valid;
            }

            if ($('#txtPassword').val().length < 1)
             {
                $('#txtPassword').focus();
                alert("Enter password");
                 $('#txtPassword').val('');
                $('#txtPassword').focus()
                valid = false;            
                return valid;
           
            }
             if ($('#txtConfirmPassword').val().trim().length < 1 )
             {
                $('#txtConfirmPassword').focus();
                alert("Enter confirm password");
                 $('#txtConfirmPassword').val('');
                $('#txtConfirmPassword').focus()
                valid = false;            
                return valid;
           
            }
              if ($('#txtPassword').val().trim() != $('#txtConfirmPassword').val().trim()) {
                $('#txtConfirmPassword').focus();
                 $('#txtConfirmPassword').val('');;
                alert("Password does not match the confirm password");
                valid = false;
                return valid;
            } 
            
              if (($('#txtAltEmail').val().trim().length > 0) && (echeck($('#txtAltEmail').val().trim()) == false) )
             {
               
                $('#txtAltEmail').val('');
                $('#txtAltEmail').focus()
                valid = false;
                return valid;
           
            }
               if ($('#txtphone').val().trim().length < 1 )
             {
                $('#txtphone').focus();
                alert("Enter phone number");
                 $('#txtphone').val('');
                $('#txtphone').focus()
                valid = false;            
                return valid;
           
            }
                       
              if(($('#txtphone').val().trim().length > 0) && ($('#txtphone').val().trim().length < 10)) {
                $('#txtphone').focus();
                $('#txtphone').val('');;
                alert("Enter valid phone number");
                valid = false;            
                return valid;
            }   
               
               if(($('#txtAltPhone').val().trim().length > 0) && ($('#txtAltPhone').val().trim().length < 10)) {
                $('#txtAltPhone').focus();
                $('#txtAltPhone').val('');;
                alert("Enter valid phone number");
                valid = false;            
                return valid;
            }         
             if($('#txtRegZip').val().trim().length > 0)
             {
                 var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#txtRegZip').val().trim());
                   if (isValid == false)
                   {
                     $('#txtRegZip').focus();
                    alert("Please enter valid zipcode");
                     $('#txtRegZip').val('');
                    $('#txtRegZip').focus()
                    valid = false;  
                     return valid;      
                   }
               }



               if (valid) {
                $('#spinner').show();
              }  
               
         return valid;
      }
      
      
      function isNumberKey(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
          function isNumberKeyWithDashForZip(evt)
         {
         
         
            var charCode = (evt.which) ? evt.which : event.keyCode         
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }     
        
</script>

    </form>
</body>
</html>
