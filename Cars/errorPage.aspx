<%@ Page Language="C#" AutoEventWireup="true" CodeFile="errorPage.aspx.cs" Inherits="errorPage" 
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
    
    
   
 <div id="content" class="page-404">
    <div id="page-heading">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="heading">
                        <div class="title">
                            <h1>Page not found</h1>
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
                        <div class="row">
                            <div class="col-md-push-4 col-md-4">
                                <div class="not-found">
                                    <div class="not-found-icon">
                                        <div class="not-found-icon-normal">
                                            404
                                        </div>
                                    </div>
                                    <div class="title">
                                        <h2>Ooops!</h2>
                                    </div>
                                    <div class="subtitle">
                                        <h3>Page you were looking for is not here.</h3>
                                    </div>
                                </div>
                            </div>
                        </div>
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



    
    

    

    </form>
</body>
</html>
