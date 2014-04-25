<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaymentMode.aspx.cs" Inherits="PaymentMode"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register src="UserControl/HeadderBlogin.ascx" tagname="HeadderBlogin" tagprefix="uc2" %>
<!doctype html>
<html>
<head id="Head1" runat="server">
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
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css"
        media="screen, projection">
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
   
    <div id="content">
        <div id="progress" class="section">
            <div class="container">
                <div class="row">
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step done" href="javascript:void(0);">
                            <div class="circle">
                                <i class="icon icon-normal-mark-tick"></i>
                            </div>
                            <div class="title">
                                Seller Information</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step done" href="javascript:void(0);">
                            <div class="circle">
                                <i class="icon icon-normal-mark-tick"></i>
                            </div>
                            <div class="title">
                                Vehicle Information</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step done" href="javascript:void(0);">
                            <div class="active circle">
                                <i class="icon icon-normal-mark-tick"></i>
                            </div>
                            <div class="title">
                                Vehicle Photos</div>
                        </a>
                    </div>
                    <div class="col-sm-3 col-md-3">
                        <a class="progress-step active" href="javascript:void(0);">
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
                                <div class="page-header" style="margin-bottom: 0">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                <asp:Label ID="lblHeadName" runat="server" Font-Size="16px"></asp:Label>
                                                Choose a payment method</h2>
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
                                    <div class="col-md-12">
                                        <div class="block-inner ">
                                            <div class="form-section">
                                               
                                                <div class="pricing-page">
                                                <div class="pricing pricing2" style=" margin-top:30px; " >
                                                    <div class="row">
                                                        <div class="inner">
                                                            <div class="col-sm-6 col-md-6 block-margin">
                                                                <div class="pricing-package block block-shadow white">
                                                                    <div class="block-inner" style=" height:310px ">
                                                                        <div class="title">
                                                                            <h2>
                                                                                Pay using PayPal</h2>
                                                                        </div>
                                                                        
                                                                            <div class="block-inner " style=" display:block; text-align:center; "   >
                                                                                <img src="imagesOld/Paypal.jpg" class="price block-shadow block-margin" style=" padding:0 10px; "  />
                                                                            </div>
                                                                        
                                                                        <div class="product">
                                                                           <div style=" text-align:center; " >
                                                        <%--<% if (Session["PackageID"].ToString() == "2")
                                                           {
                                                               
                                                              

                                                               Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                               Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"XB4Z4545KW77C\">");
                                                               Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");



                                                             

                                                           }
                                                           else if (Session["PackageID"].ToString() == "3")
                                                           {

                                                               
                                                               Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                               Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"FRDRN9P9HVSLE\">");

                                                               Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");


                                                           }
                                                           else if (Session["PackageID"].ToString() == "4")
                                                           {
                                                               
                                                               Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                               Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"TE2QP6VZQAT7C\">");

                                                               Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");



                                                           }
                                                           else if (Session["PackageID"].ToString() == "5")
                                                           {

                                                               
                                                               Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                               Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"LWTWCXS9A9PUA\">");

                                                               Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");



                                                           }
                                                           else if (Session["PackageID"].ToString() == "6")
                                                           {

                                                               
                                                               Response.Write("<input type=\"hidden\" name=\"cmd\" value=\"_s-xclick\">");
                                                               Response.Write("<input type=\"hidden\" name=\"hosted_button_id\" value=\"4VUKDXS3BUV9Y\">");
                                                               Response.Write("<img alt=\"\" border=\"0\" src=\"https://www.paypalobjects.com/en_US/i/scr/pixel.gif\" width=\"1\" height=\"1\">");


                                                           }
                                                        %>--%>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://www.paypalobjects.com/en_US/i/btn/btn_paynowCC_LG.gif"
                                                            PostBackUrl="https://www.paypal.com/cgi-bin/webscr" />
                                                    </div>
                                                                        </div>
                                                                        
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 col-md-6 block-margin">
                                                                <div class="pricing-package block block-shadow white">
                                                                    <div class="block-inner" style=" height:310px ">
                                                                       
                                                                        <div class="title">
                                                                            <h2>
                                                                                Pay using Authorize.Net
                                                                            </h2>
                                                                        </div>
                                                                        <div class="block-inner " style=" display:block; text-align:center; "   >
                                                                                <img src="imagesOld/authorizenet.jpg" class="price block-shadow block-margin" style=" padding:0 10px; "  />
                                                                            </div>
                                                                            
                                                                        <div class="product"  style=" text-align:center; " >
                                                                           <asp:ImageButton ID="paymode" runat="server" ImageUrl="imagesOld/logo-authorize-net.gif"
                                                        PostBackUrl="~/pay.aspx" /></asp:ImageButton>
                                                                        </div>
                                                                        
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.content -->
                                    </div>
                                    <!-- /.col-md-12 -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.block -->
                        </div>
                        <!-- /#main -->
                    </div>
                    <div class="col-md-3 sidebar">
                        <div class="block block-shadow extras white">
                            <div class="block-inner">
                                <div class="block-title">
                                    <h3>
                                        Summary</h3>
                                </div>
                                <!-- /.block-title -->
                                <table class=" summary2  ">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <h4>Package</h4>
                                                <asp:Label ID="lblpackagename2" runat ="server" ></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Seller Name</h4>
                                                <asp:Label ID="lblSname" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Email</h4>
                                                <asp:Label ID="lblSmail" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Phone</h4>
                                                <asp:Label ID="lblSphone" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2" >
                                                <div class="devider2"></div>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Year</h4>
                                                <asp:Label ID="lblSyear" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Make</h4>
                                                <asp:Label ID="lblSmake" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Model</h4>
                                                <asp:Label ID="lblSmodel" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Asking Price</h4>
                                                <asp:Label ID="lblSprice" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>Uploaded Photos</h4>
                                                
                                                <asp:Label ID="lblSphotos" runat ="server"></asp:Label>
                                            </td>
                                            
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <!-- /.block-inner -->
                            <div class="total">
                                <div class="title">
                                    Total</div>
                                <div class="value">
                                    <asp:Label ID="lblpckgprice" runat ="server"></asp:Label></div>
                            </div>
                        </div>
                        <!-- /.block -->
                    </div>
                    <!-- /.sidebar -->
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





    <!-- Alerts Start  -->
    
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="popupBody" style="display: block" id="AlertUser">
        <div>
            <h1 class="h1">
                Congratulations..!</h1>
            <h3 class="h32">
                You are one step closer to selling your car.</h3>
            <p class="pp">
                You will receive an email shortly from mobicarz.com. Meanwhile you can
                login and check the details of your car and also edit any information required and
                upload new photographs.
            </p>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnExustCls_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Next" OnClick="btnOk_Click" />
        </div>
    </div>
    
    <!-- Alerts End --->


   

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

    </form>
</body>
</html>
