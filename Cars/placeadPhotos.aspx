<%@ Page Language="C#" AutoEventWireup="true" CodeFile="placeadPhotos.aspx.cs" Inherits="placeadPhotos"
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
    <title>MobiCarz</title>

    <script src="assets/js/jquery.js" type="text/javascript"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js" type="text/javascript"></script>

    <script src="assets/js/jquery.ui.js" type="text/javascript"></script>

    <script src="assets/js/bootstrap.js" type="text/javascript"></script>

    <script src="assets/js/cycle.js" type="text/javascript"></script>

    <script src="js/jquery.mb.browser.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.dragsort-0.5.1.min.js"></script>

    <script type="text/javascript">
        var CARID;
        var PICID0;
        var UploadifyAuthCookie = '<% = Request.Cookies[FormsAuthentication.FormsCookieName] == null ? string.Empty : Request.Cookies[FormsAuthentication.FormsCookieName].Value %>';
        var UploadifySessionId = '<%= Session.SessionID %>';

        cPage = '';
	
	
    </script>

    <script src="js/photoUpload.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    
    <asp:HiddenField ID="hdnSubAlert" runat="server" Value="true" />
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <asp:HiddenField ID="hdnMake" runat="server" />
    <asp:HiddenField ID="hdnModel" runat="server" />
    <asp:HiddenField ID="hdnYear" runat="server" />
    <asp:HiddenField ID="hdnId" runat="server" />
    <asp:HiddenField ID="MaxPhotos" runat="server" />
    <asp:HiddenField ID="hdnUploadedImages" runat="server" />
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
                        <a class="progress-step active" href="javascript:void(0);">
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
                                <div class="page-header" style="margin-bottom: 0">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Upload Car Photos</h2>
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
                                <h4 style="margin-top: 0; margin-bottom: 30px;">
                                    Please note that the first photo which you upload will be your display thumb.</h4>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="block-inner white block-shadow">
                                            <div class="form-section">
                                                <div class="row">
                                                    <div class="col-sm-12 col-md-12">
                                                        <div class="form-group">
                                                            <!-- photosUploadControler Start  -->
                                                            <div class=" photosUploadControler">
                                                                <div style="display: none">
                                                                    <asp:Label ID="lblUserName" runat="server"></asp:Label></div>
                                                                <!-- FileUpload Start ////////////////////////////////////////////////////////////////  -->
                                                                <h4>
                                                                    Max Allowed photos <span id="maxPho"></span>
                                                                </h4>
                                                                <div class=" newFileUploadControler">
                                                                    <div id="fuFiles">
                                                                        <div id="queue">
                                                                        </div>
                                                                        <input id="file_upload" name="file_upload" type="file" multiple="true" class="btn btn-danger floatR MR10"
                                                                            style="display: none;">
                                                                    </div>
                                                                    <%-- <input type="button" value="Add photos now" class="btn btn-danger floatR MR10" />--%>
                                                                    <div class="clear">
                                                                        &nbsp;</div>
                                                                    <br>
                                                                    <div style="width: 70px; vertical-align: top; display: none;">
                                                                        <input type="button" id="backPic" value=" " class="g-button ar6" />
                                                                        <asp:HiddenField ID="hdnPic20" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic19" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic18" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic17" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic16" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic15" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic14" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic13" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic12" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic11" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic10" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic9" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic8" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic7" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic6" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic5" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic4" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic3" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic2" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic1" runat="server" />
                                                                        <asp:HiddenField ID="hdnPic0" runat="server" />
                                                                        <asp:HiddenField ID="hdnCarID" runat="server" />
                                                                        <asp:Image ID="Img1" runat="server" Visible="false" />
                                                                    </div>
                                                                    <asp:Button ID="imageOrder" OnClientClick="return setImagesOrder();" runat="server"
                                                                        Text="Save Images Order" CssClass="btn" OnClick="imageOrder_Click" />
                                                                    <%-- <input type="button" value="Save Images Order" class="g-button right" id="imageOrder" style="display:none;"
                                       />
                                    <input type="button" value="Save Images" class="g-button right" id="imagesSave" runat="server" style="display:none;"/>--%>
                                                                    <asp:Button ID="imagesSave" OnClientClick="return setImagesOrder();" runat="server"
                                                                        Text="Save Images" CssClass="btn" OnClick="imageOrder_Click" />
                                                                    <div class="clearfix">
                                                                        &nbsp;</div>
                                                                    <!-- Photos Start -->
                                                                    <div class="thumbsUpload-holder" style="width: 99%;">
                                                                        <ul class="thumbsUpload">
                                                                        </ul>
                                                                        <div class="clear">
                                                                            &nbsp;</div>
                                                                    </div>
                                                                </div>
                                                                <!-- FileUpload End //////////////////////////////////////////////////////////////////////////  -->
                                                            </div>
                                                            <!-- photosUploadControler End  -->
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
                                <div class="row">
                                    <div class="col-sm-12 col-md-12">
                                        <div class="row">
                                            <div class="checkout-actions">
                                                <div class="col-sm-4 col-md-3">
                                                    <div class="prev">
                                                        <a href="placead.aspx" class=" btn btn-link ">< Back To Vehicle Information</a>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 col-md-3">
                                                </div>
                                                <div class="col-sm-4 col-md-3">
                                                    <div class="next" style="display: none;" id="addPhotosNow">
                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Add photos now"
                                                            OnClick="btnSave_Click" OnClientClick="return validate()" />
                                                        <%--OnClick="btnSave_Click" OnClientClick="return validate()"--%>
                                                    </div>
                                                </div>
                                                <div class="col-sm-4 col-md-3">
                                                    <div class="next">
                                                        <asp:Button ID="btnContinue" runat="server" CssClass="btn btn-primary" Text="Add photos later >"
                                                            OnClick="btnContinue_Click" />
                                                        <%--OnClick="btnContinue_Click"--%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
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
                                                <h4>
                                                    Package</h4>
                                                <asp:Label ID="lblpackagename2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Seller Name</h4>
                                                <asp:Label ID="lblSname" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Email</h4>
                                                <asp:Label ID="lblSmail" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Phone</h4>
                                                <asp:Label ID="lblSphone" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="devider2">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Year</h4>
                                                <asp:Label ID="lblSyear" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Make</h4>
                                                <asp:Label ID="lblSmake" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Model</h4>
                                                <asp:Label ID="lblSmodel" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4>
                                                    Asking Price</h4>
                                                <asp:Label ID="lblSprice" runat="server"></asp:Label>
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
                                    <asp:Label ID="lblpckgprice" runat="server"></asp:Label></div>
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
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="BtnCls"
        OkControlID="btnYes">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4>
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
    <cc1:ModalPopupExtender ID="mdepAlertForAsk" runat="server" PopupControlID="divAlertForAsk"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlretForAsk" OkControlID="btnClsimg"
        CancelControlID="btnNo">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlretForAsk" runat="server" />
    <div id="divAlertForAsk" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnClsimg" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertForAsk" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" />
            <asp:Button ID="btnAskYes" class="btn" runat="server" Text="Yes" OnClick="btnAskYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepEditSuccess" runat="server" PopupControlID="dvsuccess"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEdSuccess">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEdSuccess" runat="server" />
    <div class="alert" style="display: none; width: 450px" id="dvsuccess" runat="server">
        <h4>
            Alert</h4>
        <div class="data">
            <p class="pp">
                <b>Changes have been incorporated successfully. Thank you.</b>
            </p>
            <asp:Button ID="btnGo" class="btn btn-danger btn-sm" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div>
    --%>
    <!-- Alerts ENd  -->

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

    <script type="text/javascript">
        var models;
        LoadingPage = 3;
   
    
    </script>

    <script language="Javascript" type="text/javascript">




        function validate() {

            var Count = 0;



            return true;
        }
    </script>

    <script type="text/javascript">
        var validFiles = ["bmp", "gif", "png", "jpg", "jpeg"];
        function CheckExt(obj) {
            var source = obj.value;
            var ext = source.substring(source.lastIndexOf(".") + 1, source.length).toLowerCase();
            for (var i = 0; i < validFiles.length; i++) {
                if (validFiles[i] == ext)
                    break;
            }
            if (i >= validFiles.length) {
                alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n" + validFiles.join(", "));
                obj.focus();
                obj.value = "";
            }
        }

        function maxPhotos() {
            alert(hdnMaxPhotos.value());
        }


        $(window).load(function() {
            $('#maxPho').text($.trim($('#MaxPhotos').val()))
            FindLoginCarID($.trim($('#hdnId').val()))
        })
           
       
        
    </script>

    </form>
</body>
</html>
