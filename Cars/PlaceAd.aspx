<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlaceAd.aspx.cs" Inherits="Registar"
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
 
   <asp:HiddenField ID="hdnSubAlert" runat="server" Value="true" />
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
                        <a class="progress-step active" href="javascript:void(0);">
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
                                                Build Your Ad</h2>
                                            <h4>
                                                <div id="lblPackDiv" runat="server" style="display: none">
                                                    <asp:Label ID="lblPackageName" runat="server"></asp:Label>
                                                </div>
                                                Learn about <a href="SellRegi.aspx" target="_blank">packages</a></h4>
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
                                <div class="row" id="adStatus" runat="server" style="display: none;">
                                    <div class=" col-md-12">
                                        <div style="width: 340px; float: right; padding: 0; text-align: right; padding-top: 40px">
                                            <asp:UpdatePanel ID="updtpnlSold" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnActive" runat="server" CssClass="button1" Text="Activate" Style="float: right;
                                                        margin-left: 8px;" Visible="false" OnClick="btnActive_Click" />
                                                    <asp:Button ID="btnSold" runat="server" CssClass="button1" Text="Sold" Style="float: right;
                                                        margin-left: 8px;" Visible="false" OnClick="btnSold_Click" />
                                                    <asp:Button ID="btnWithdraw" runat="server" CssClass="button1" Text="Withdraw" Style="float: right;
                                                        margin-left: 8px;" Visible="false" OnClick="btnWithdraw_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="block-inner white block-shadow">
                                            <div class="form-section">
                                                <div class="block-title">
                                                    <h2>
                                                        Vehicle Type</h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Make <span class="star">*</span></label>
                                                            <asp:UpdatePanel ID="updtMake" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true" CssClass="form-control"
                                                                        OnSelectedIndexChanged="ddlMake_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Model <span class="star">*</span></label>
                                                            <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModel" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Year <span class="star">*</span></label>
                                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Style <span class="star">*</span></label>
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlStyle" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <div class="block-title">
                                                    <h2>
                                                        Seller Information For Display</h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                City
                                                            </label>
                                                            <asp:TextBox ID="txtCity" runat="server" MaxLength="20" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                State
                                                            </label>
                                                            <asp:DropDownList ID="ddlLocationState" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                ZIP
                                                            </label>
                                                            <asp:TextBox ID="txtZip" runat="server" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"
                                                                CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Phone
                                                            </label>
                                                            <asp:TextBox ID="txtSellerPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                                                CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Email
                                                            </label>
                                                            <asp:TextBox ID="txtSellerEmail" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <div class="block-title">
                                                    <h2>
                                                        Vehicle Information <small><i class="non">(You may add or modify these later)</i></small></h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-11 col-md-10">
                                                        <div class="form-group">
                                                            <label>
                                                                Title <small><i>(Ex: 2004 Honda Accord EX V6 - Dark Blue - Auto - 58K Mi.)</i></small></label>
                                                            <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Asking Price
                                                            </label>
                                                            <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" CssClass="form-control"
                                                                onkeypress="return isNumberKeyWithDot(event)"> </asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Mileage
                                                            </label>
                                                            <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" CssClass="form-control"
                                                                onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Exterior Color
                                                            </label>
                                                            <asp:DropDownList ID="ddlExteriorColor" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Interior Color
                                                            </label>
                                                            <asp:DropDownList ID="ddlInteriorColor" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Transmission
                                                            </label>
                                                            <asp:DropDownList ID="ddlTransmission" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Condition
                                                            </label>
                                                            <span id="Span1">
                                                                <asp:DropDownList ID="ddlCondition" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6 col-md-5">
                                                        <div class="form-group">
                                                            <label>
                                                                Drive Train
                                                            </label>
                                                            <asp:DropDownList ID="ddlDriveTrain" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Engine Cylinders
                                                            </label>
                                                            <asp:DropDownList ID="ddlCylinderCount" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Doors
                                                            </label>
                                                            <asp:DropDownList ID="ddlDoorCount" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                Fuel Type
                                                            </label>
                                                            <asp:DropDownList ID="ddlFuelType" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="form-group">
                                                            <label>
                                                                VIN <small><i>(May add later)</i></small>
                                                            </label>
                                                            <asp:TextBox ID="txtVin" runat="server" MaxLength="17" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <div class="block-title">
                                                    <h2>
                                                        Features</h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-4 col-md-4">
                                                        <div class="form-group">
                                                            <h3>
                                                                Comfort</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures51" runat="server" />
                                                                    A/C</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures1" runat="server" />
                                                                    A/C: Front</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures2" runat="server" />
                                                                    A/C: Rear</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures3" runat="server" />
                                                                    Cruise Control</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures4" runat="server" />
                                                                    Navigation System</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures5" runat="server" />
                                                                    Power Locks</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures6" runat="server" />
                                                                    Power Steering</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures7" runat="server" />
                                                                    Remote Keyless Entry</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures8" runat="server" />
                                                                    TV/VCR</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures31" runat="server" />
                                                                    Remote Start</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures33" runat="server" />
                                                                    Tilt</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures35" runat="server" />
                                                                    Rearview Camera</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures36" runat="server" />
                                                                    Power Mirrors</label>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <h3>
                                                                Seats</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures9" runat="server" />
                                                                    Bucket Seats</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures10" runat="server" />
                                                                    Leather Interior</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures11" runat="server" />
                                                                    Memory Seats</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures12" runat="server" />
                                                                    Power Seats</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures32" runat="server" />
                                                                    Heated Seats</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures37" runat="server" />
                                                                    Vinyl Interior</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures38" runat="server" />
                                                                    Cloth Interior</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-md-4">
                                                        <div class="form-group">
                                                            <h3>
                                                                Safety</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures13" runat="server" />
                                                                    Airbag: Driver</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures14" runat="server" />
                                                                    Airbag: Passenger</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures15" runat="server" />
                                                                    Airbag: Side</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures16" runat="server" />
                                                                    Alarm</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures17" runat="server" />
                                                                    Anti-Lock Brakes</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures18" runat="server" />
                                                                    Fog Lights</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures39" runat="server" />
                                                                    Power Brakes</label>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <h3>
                                                                Sound System</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures19" runat="server" />
                                                                    Cassette Radio</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures20" runat="server" />
                                                                    CD Changer</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures21" runat="server" />
                                                                    CD Player</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures22" runat="server" />
                                                                    Premium Sound</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures34" runat="server" />
                                                                    AM/FM</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures40" runat="server" />
                                                                    DVD</label>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <h3>
                                                                New</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures44" runat="server" />
                                                                    Battery</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures45" runat="server" />
                                                                    Tires</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4 col-md-4">
                                                        <div class="form-group">
                                                            <h3>
                                                                Windows</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures23" runat="server" />
                                                                    Power Windows</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures24" runat="server" />
                                                                    Rear Window Defroster</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures25" runat="server" />
                                                                    Rear Window Wiper</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures26" runat="server" />
                                                                    Tinted Glass</label>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <h3>
                                                                Other</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures27" runat="server" />
                                                                    Alloy Wheels</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures28" runat="server" />
                                                                    Sunroof</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures41" runat="server" />
                                                                    Panoramic Roof</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures42" runat="server" />
                                                                    Moon Roof</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures29" runat="server" />
                                                                    Third Row Seats</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures30" runat="server" />
                                                                    Tow Package</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures43" runat="server" />
                                                                    Dashboard Wood frame</label>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <div class="form-group">
                                                            <h3>
                                                                Specials</h3>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures46" runat="server" />
                                                                    Garage Kept</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures47" runat="server" />
                                                                    Non Smoking</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures48" runat="server" />
                                                                    Records/Receipts Kept</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures49" runat="server" />
                                                                    Well Maintained</label>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="chkFeatures50" runat="server" />
                                                                    Regular oil changes</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-section">
                                                <div class="block-title">
                                                    <h2>
                                                        Vehicle Description <small><i class="non">(You may add or modify these later)</i></small></h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-sm-11 col-md-11">
                                                        <div class="form-group">
                                                            <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence"><span id="sellingPointCharCount">
                                                                1000</span> characters left</span><br />
                                                                <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control"
                                                                    onchange="updateCharCount(this,'sellingPointCharCount');" onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                    MaxLength="1000"></asp:TextBox>
                                                                <p>
                                                                    <i>Include information on additional equipment, how you have cared for the vehicle,
                                                                        Kelley Blue Book value and anything else that will help sell your vehicle.</i></p>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=" form-section" runat="server" id="multiSiteListings">
                                                <div class="block-title">
                                                    <h2>
                                                        Multi-site Listings</h2>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="searchResultsBox">
                                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                <ContentTemplate>
                                                                    <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                                    <div class="not" id="divlblMultiSite" runat="server" style="display: block;">
                                                                        <asp:Label ID="lblExistUrlRes" runat="server"></asp:Label></div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <asp:Panel ID="Panel2" Width="100%" runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                    <ContentTemplate>
                                                                        <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                                                                        <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                                                                        <asp:GridView Width="100%" ID="grdMultiSites" runat="server" CellSpacing="0" CellPadding="0"
                                                                            CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false">
                                                                            <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                            <HeaderStyle CssClass="headder" />
                                                                            <PagerSettings Position="Top" />
                                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <RowStyle CssClass="row1" />
                                                                            <AlternatingRowStyle CssClass="row2" />
                                                                            <Columns>
                                                                                <asp:TemplateField>
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="htlnkURLListed" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),90)%>'
                                                                                            NavigateUrl='<%# String.Format("http://{0}", Eval("URL").ToString()) %>' Target="_blank"></asp:HyperLink>
                                                                                        <asp:HiddenField ID="hdnUrlToNav" runat="server" Value='<%# Eval("URL")%>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="grdMultiSites" EventName="Sorting" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </asp:Panel>
                                                            <div class="clear">
                                                                &nbsp;</div>
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
                <div class="row">
                    <div class="checkout-actions">
                        <div class="col-sm-4 col-md-3">
                        </div>
                        <div class="col-sm-4 col-md-3">
                        </div>
                        <div class="col-sm-4 col-md-3">
                            <div class="next">
                                <asp:UpdatePanel ID="BtnSavePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSaveCarDetails" runat="server" CssClass="btn btn-primary" Text="Proceed  >"
                                            OnClick="btnSaveCarDetails_Click" OnClientClick="return ValidateVehicleType();" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-sm-4 col-md-3">
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.container -->
        </div>
        <!-- /.section -->
    </div>
    <!-- /#content -->
    <div id="footer">
        <uc1:Footer ID="Footer1" runat="server" />
    </div>
    <!-- Alerts  --Strt  -->
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="BtnCls"
        OkControlID="btnNo">
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
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" />
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Yes" OnClick="btnYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="MpeAlert" runat="server" PopupControlID="AlertUser1"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlert" CancelControlID="btnAlertClose"
        OkControlID="btnok1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlert" runat="server" />
    <div id="AlertUser1" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnAlertClose" class="cls" runat="server" Text="" BorderWidth="0" />
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorMSg" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnok1" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepActiveAd" runat="server" PopupControlID="divActiveAd"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnActiveAd" OkControlID="btnGo">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnActiveAd" runat="server" />
    <div class="popupBody" style="display: block" id="divActiveAd">
        <div>
            <br />
            <br />
            <p class="pp">
                Inorder to activate your listing please contact our customer support.
            </p>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="MdepAlertSave" runat="server" PopupControlID="divAlertSave"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertSave">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertSave" runat="server" />
    <div id="divAlertSave" class="alert" style="display: none">
        <h4 id="H3">
            Alert..!
        </h4>
        <div class="data" >
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertSave" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnAlertSaveOk" CssClass="btn btn-primary2 " runat="server" Text="Ok" OnClick="btnAlertSaveOk_Click" />
        </div>
    </div>
    <!-- Alerts End  -->

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

    <script>
        var LoadingPage = '10'
        
    </script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function isNumberKey(evt) {
            
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKeyWithDot(evt) {
            
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;

            return true;
        }
        function isNumberKeyWithDashForZip(evt) {        
           var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }



        function ValidateVehicleType() {

            var valid = true;


            if (document.getElementById('<%=ddlYear.ClientID%>').value == "0") {
                alert('Please select year')
                valid = false;
                document.getElementById('ddlYear').focus();
                return valid;
            }

            if (document.getElementById('<%=ddlMake.ClientID%>').value == "0") {
                alert("Please select make");
                valid = false;
                document.getElementById('ddlMake').focus();
                return valid;
            }
            if (document.getElementById('<%=ddlModel.ClientID%>').value == "0") {
                alert("Please select model");
                valid = false;
                document.getElementById('ddlModel').focus();
                return valid;
            }
            if (document.getElementById('<%=txtZip.ClientID%>').value.length > 0) {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtZip.ClientID%>').value);
                if (isValid == false) {
                    document.getElementById('<%= txtZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                    document.getElementById('<%=txtZip.ClientID%>').value = ""
                    document.getElementById('<%=txtZip.ClientID%>').focus()
                    valid = false;
                    return valid;
                }

            }

            if ((document.getElementById('<%=txtSellerPhone.ClientID%>').value.length > 0) && (document.getElementById('<%=txtSellerPhone.ClientID%>').value.length < 10)) {
                document.getElementById('<%= txtSellerPhone.ClientID%>').focus();
                alert("Please enter valid phone number");
                document.getElementById('<%=txtSellerPhone.ClientID%>').value = ""
                document.getElementById('<%=txtSellerPhone.ClientID%>').focus()
                valid = false;
                return valid;
            }
            if ((document.getElementById('<%=txtSellerEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtSellerEmail.ClientID%>').value) == false)) {

                document.getElementById('<%=txtSellerEmail.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEmail.ClientID%>').focus()
                valid = false;


            }
        
            //console.log(valid);
          if (valid) {
              $('#spinner').show();
           }  
//            
//            
            return valid;
        }


        function ValidateVehicleInfo() {
            var valid = true;
            if (document.getElementById('<%=txtZip.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtZip.ClientID%>').focus();
                alert("Please enter zipcode");
                document.getElementById('<%=txtZip.ClientID%>').value = ""
                document.getElementById('<%=txtZip.ClientID%>').focus()
                valid = false;
            }

            else if (document.getElementById('<%=txtZip.ClientID%>').value.length < 4) {
                document.getElementById('<%= txtZip.ClientID%>').focus();
                alert("Enter valid zipcode");
                document.getElementById('<%=txtZip.ClientID%>').value = ""
                document.getElementById('<%=txtZip.ClientID%>').focus()
                valid = false;
            }
            return valid;
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
        function pageLoad() {
            $('#spinner').hide();
            //GetMakes();
            //GetModelsInfo();  
            //GetRecentListings()
        }
    </script>

</body>
</html>
