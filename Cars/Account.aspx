<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="AccountNew"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/cufon-yui.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js" charset="utf-8"></script>

    <script type="text/javascript" src="js/jquery.slideViewerPro.1.5.js"></script>

    <script type="text/javascript" src="js/jquery.timers.js"></script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterDataNew.js" type="text/javascript"></script>

    <script src="js/Filter.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript">
        var models;
        LoadingPage = 3;
        //var ZipCodes = [];
        /*
        function pageLoad() {
        GetMakes();
        GetModelsInfo();
        SearchedCar();
        WithinZipBinding();
       
       
        }
        */
    
    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
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

        function ValidateChangePW() {

            var valid = true;

            if (document.getElementById('txtNewPW').value.length < 1) {
                alert('Please enter new password')
                valid = false;
                document.getElementById('txtNewPW').value = "";
                document.getElementById('txtNewPW').focus()
                return valid;
            }

            else if (document.getElementById('txtConfirmPW').value.length < 1) {
                alert('Please enter confirm password')
                valid = false;
                document.getElementById('txtConfirmPW').value = "";
                document.getElementById('txtConfirmPW').focus()
                return valid;
            }
            else if (document.getElementById('txtNewPW').value != document.getElementById('txtConfirmPW').value) {
                document.getElementById('txtConfirmPW').focus();
                alert("New password does not match the confirm password");
                document.getElementById('txtConfirmPW').value = "";
                document.getElementById('txtConfirmPW').focus()
                valid = false;
                return valid;
            }


            return valid;
        }

        function ValidateVehicleType() {
            var valid = true;

            if ((document.getElementById('txtAltEmail').value.length > 0) && (echeck(document.getElementById('txtAltEmail').value) == false)) {

                document.getElementById('txtAltEmail').value = "";
                document.getElementById('txtAltEmail').focus()
                valid = false;
                return valid;

            }

            if ((document.getElementById('txtRegPhone').value.length > 0) && (document.getElementById('txtRegPhone').value.length < 10)) {
                document.getElementById('txtRegPhone').focus();
                alert("Please enter valid phone number");
                document.getElementById('txtRegPhone').value = "";
                document.getElementById('txtRegPhone').focus()
                valid = false;
                return valid;
            }

            if ((document.getElementById('txtAltPhone').value.length > 0) && (document.getElementById('txtAltPhone').value.length < 10)) {
                document.getElementById('txtAltPhone').focus();
                alert("Please enter valid phone number");
                document.getElementById('txtAltPhone').value = ""
                document.getElementById('txtAltPhone').focus()
                valid = false;
                return valid;
            }

            if (document.getElementById('txtRegZip').value.length > 0) {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('txtRegZip').value);
                if (isValid == false) {
                    document.getElementById('txtRegZip').focus();
                    alert("Please enter valid zipcode");
                    document.getElementById('txtRegZip').value = "";
                    document.getElementById('txtRegZip').focus()
                    valid = false;
                    return valid;
                }
            }


            return valid;
        }

        function ShowPW() {
            
            document.getElementById('txtNewPW').value = "";
            document.getElementById('txtConfirmPW').value = "";
            $find('mpeChangePW').show();
            return false;
        }

        function pageLoad() {
            GetRecentListings()
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

        function ValidateSelPack() {
            var valid = true;
            if (document.getElementById('ddlSelPack').value == "0") {
                document.getElementById('ddlSelPack').focus();
                alert("Select package");
                document.getElementById('ddlSelPack').focus()
                valid = false;
                return valid;
            }
            return valid;
        }
        

    </script>

</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" alt="" name="logo" id="logo" />
                    </a>&nbsp;<div class="loginStat">
                        <uc2:LoginName ID="LoginName1" runat="server" />
                    </div>
                    <div id="menu">
                        <uc3:CarsHeader ID="CarsHeader1" runat="server" />
                    </div>
                </div>
                <!-- content -->
                <div id="content">
                    <div class="wrapper-1">
                        <!-- column Left Div Start  -->
                        <div id="column-left">
                            <div class="indent" style="padding-top: 5px;">
                                <div class="wrapper">
                                    <!-- Recent Used Car Listings  start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Recent Used Car Listings</h3>
                                        <em class="i1">Most recent Used Cars listed for sale</em>
                                        <!-- Ticker1 Div Start  -->
                                        <div class="ticker1">
                                            <ul>
                                                <li>
                                                    <div>
                                                        <a href="#"><strong></strong></a>
                                                        <br />
                                                    </div>
                                                </li>
                                            </ul>
                                        </div>
                                        <!-- Ticker1 Div End  -->
                                    </div>
                                    <!-- Recent Used Car Listings end  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div id="div250X250" runat="server" style="padding: 3px; margin: 5px auto; width: 250px;
                                        height: 250px">
                                    </div>
                                    <div id="lBrandAds2" style="padding: 3px; margin: 5px auto;">
                                        <!-- Begin: adBrite, Generated: 2012-05-09 5:53:51  -->
                                        <style type="text/css">
                                            .adHeadline
                                            {
                                                font: bold 10pt Arial;
                                                text-decoration: underline;
                                                color: #0000FF;
                                            }
                                            .adText
                                            {
                                                font: normal 10pt Arial;
                                                text-decoration: none;
                                                color: #000000;
                                            }
                                        </style>

                                        <script type="text/javascript">
                                            try { var AdBrite_Iframe = window.top != window.self ? 2 : 1; var AdBrite_Referrer = document.referrer == '' ? document.location : document.referrer; AdBrite_Referrer = encodeURIComponent(AdBrite_Referrer); } catch (e) { var AdBrite_Iframe = ''; var AdBrite_Referrer = ''; }
                                            document.write(String.fromCharCode(60, 83, 67, 82, 73, 80, 84)); document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr=' + AdBrite_Iframe + '&ref=' + AdBrite_Referrer + '" type="text/javascript">'); document.write(String.fromCharCode(60, 47, 83, 67, 82, 73, 80, 84, 62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads Satrt -->
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Advantage of Buying Used Cars Start -->
                                    <div class="leftBox1">
                                        <h3 class="h3">
                                            Advantage of Buying Used Cars
                                        </h3>
                                        <em class="i1">Must read tips & advices on Used Cars</em><br />
                                        <ul class="bullet" style="margin-left: 10px;">
                                            <li><a href="tips.aspx">Used Car buying tips</a></li>
                                        </ul>
                                    </div>
                                    <!-- Advantage of Buying Used Cars End -->
                                </div>
                            </div>
                        </div>
                        <!-- column Left Div End  -->
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <!-- Vehicle Type Div Start -->
                                    <div class="box4">
                                        <table style="float: left; width: 350px;">
                                            <tr>
                                                <td style="padding-right: 20px; padding-top: 10px;">
                                                    <h2>
                                                        My Account
                                                    </h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:UpdatePanel ID="UpdtpnlUserNameData" runat="server">
                                            <ContentTemplate>
                                                <div style="width: 200px; float: right; margin: 20px 20px 0 0; text-align: right;
                                                    font-weight: normal; font-size: 12px;">
                                                    <asp:Label ID="lblUserNameData" runat="server" Text="Dinesh">
                                                    </asp:Label>
                                                    <br />
                                                    Member since:
                                                    <asp:Label ID="lblUserMemberDate" runat="server" Text="">
                                                    </asp:Label>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="clear">
                                            &nbsp;</div>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1 photoUpload" style="border-top: #ccc 1px solid;
                                            padding: 10px 0; margin: 0;">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 140px; padding-right: 10px;">
                                                        <!-- Car Info Start -->
                                                        <!-- Car Info End -->
                                                        <!-- My Details Start  -->
                                                        <asp:UpdatePanel ID="updtPnlSearchResultBox" runat="server">
                                                            <ContentTemplate>
                                                                <div class="searchResultsBox activeBox">
                                                                    <h3>
                                                                        Registrant Details
                                                                    </h3>
                                                                    <asp:Button ID="btnChangePwd" runat="server" CssClass="button1" Text="Change Password"
                                                                        Style="float: right; margin-left: 8px;" OnClientClick="return ShowPW();" />
                                                                    <asp:Button ID="btnEditDetails" runat="server" CssClass="button1" Style="float: right;"
                                                                        Text="Edit Details" OnClick="btnEditDetails_Click" />
                                                                    <asp:Button ID="btnUpdateDetails" runat="server" CssClass="button1" Style="float: right;"
                                                                        Visible="false" Text="Update Details" OnClick="btnUpdateDetails_Click" OnClientClick="return ValidateVehicleType();" />
                                                                    <table id="tbl1LblsDisplay" runat="server" style="display: block">
                                                                        <tr>
                                                                            <td style="width: 110px;">
                                                                                <b>Name:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divlblRegName" runat="server" style="display: block">
                                                                                    <asp:Label ID="lblRegName" runat="server"></asp:Label>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Company Name:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblBusinessName" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Email:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRegEmail2" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Alt Email:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblAltEmail" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Phone:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divlblRegPhone" runat="server" style="display: block">
                                                                                    <asp:Label ID="lblRegPhone" runat="server"></asp:Label>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Alt Phone:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblAltPhone" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Address:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRegAddress" runat="server"></asp:Label>
                                                                                <asp:Label ID="lblRegCity" runat="server"></asp:Label>
                                                                                <asp:Label ID="lblRegState" runat="server"></asp:Label>
                                                                                <asp:Label ID="lblRegZip" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id="tbl2textDisplay" runat="server" style="display: none; width: 100%;">
                                                                        <tr>
                                                                            <td style="width: 80px;">
                                                                                <b>Name:</b>
                                                                            </td>
                                                                            <td style="width: 220px;">
                                                                                <div id="divtxtRegName" runat="server" style="display: none">
                                                                                    <asp:TextBox ID="txtregName" runat="server" MaxLength="25"></asp:TextBox>
                                                                                </div>
                                                                            </td>
                                                                            <td style="width: 80px;">
                                                                                <b>Email:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRegEmail" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 110px;">
                                                                                <b>Company Name:</b>
                                                                            </td>
                                                                            <td style="width: 200px;">
                                                                                <asp:TextBox ID="txtBusinessName" runat="server" MaxLength="30"></asp:TextBox>
                                                                            </td>
                                                                            <td style="width: 80px;">
                                                                                <b>Alt Email:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAltEmail" runat="server" MaxLength="30"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Phone:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divtxtRegPhone" runat="server" style="display: none">
                                                                                    <asp:TextBox ID="txtRegPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                                                                        Enabled="false"></asp:TextBox>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <b>City:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divlblRegCity" runat="server" style="display: block">
                                                                                </div>
                                                                                <div id="divtxtRegCity" runat="server" style="display: none">
                                                                                    <asp:TextBox ID="txtRegCity" runat="server" MaxLength="20"></asp:TextBox>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>State:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divlblRegState" runat="server" style="display: block">
                                                                                </div>
                                                                                <div id="divddlRegState" runat="server" style="display: none">
                                                                                    <asp:DropDownList ID="ddlLocationState" runat="server" Width="110px">
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <b>Zip:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divlblRegZip" runat="server" style="display: block">
                                                                                </div>
                                                                                <div id="divtxtRegZip" runat="server" style="display: none">
                                                                                    <asp:TextBox ID="txtRegZip" runat="server" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <b>Address:</b>
                                                                            </td>
                                                                            <td>
                                                                                <div id="divlblRegAddress" runat="server" style="display: block">
                                                                                </div>
                                                                                <div id="divtxtRegAddress" runat="server" style="display: none">
                                                                                    <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="40"></asp:TextBox>
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <b>Alt Phone:</b>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAltPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <div class="clear">
                                                                        &nbsp;</div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <!-- My Details End  -->
                                                        <!-- Package Info Start -->
                                                        <div class="searchResultsBox activeBox">
                                                            <h3>
                                                                Package Details
                                                                <div style="width: 90px; font-size: 12px; font-weight: normal; float: right; text-align: right;">
                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lnkbtnAddPackage" runat="server" Text="Add Package" OnClick="lnkbtnAddPackage_Click"></asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </h3>
                                                            <asp:Panel ID="Panel2" Width="100%" runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                    <ContentTemplate>
                                                                        <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                                                                        <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                                                                        <asp:GridView Width="100%" ID="grdPackagDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                                            CssClass="grid1 VisitsTable" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdPackagDetails_RowDataBound">
                                                                            <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                            <PagerSettings Position="Top" />
                                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <RowStyle CssClass="row1" />
                                                                            <AlternatingRowStyle CssClass="row2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sno">
                                                                                    <ItemTemplate>
                                                                                        <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Package">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hdnPackDescrip" runat="server" Value='<%# Eval("Description")%>' />
                                                                                        <asp:HiddenField ID="hdnUserPackID" runat="server" Value='<%# Eval("UserPackID")%>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="160px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Date Of Purchase">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDtOfPurchase" runat="server" Text='<%# Bind("Paydate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                        <asp:HiddenField ID="hdnDtOfPurchase" runat="server" Value='<%# Bind("Paydate", "{0:MM/dd/yy}") %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Valid Till">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblValidTill" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hdnValidTill" runat="server" Value='<%# Bind("Validityperiod", "{0:MM/dd/yy}") %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="# Of Posted Cars">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblNoOfPostedCars" runat="server" Text='<%# Eval("CarsCount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="# Of Max Cars">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblMaxCars" runat="server" Text='<%# Eval("Maxcars")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="grdPackagDetails" EventName="Sorting" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </asp:Panel>
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </div>
                                                        <div class="searchResultsBox activeBox">
                                                            <h3>
                                                                Car Details(Click on Car ID number to view/edit car listing details)
                                                                <div style="width: 90px; font-size: 12px; font-weight: normal; float: right; text-align: right;">
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="lnkbtnCarDetails" runat="server" Text="Add Car" OnClick="lnkbtnCarDetails_Click"></asp:LinkButton>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </h3>
                                                            <asp:Panel ID="Panel1" Width="100%" runat="server">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                                        <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                                        <asp:GridView Width="100%" ID="grdCarDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                                            CssClass="grid1 VisitsTable" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdCarDetails_RowDataBound"
                                                                            OnRowCommand="grdCarDetails_RowCommand">
                                                                            <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                            <PagerSettings Position="Top" />
                                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <RowStyle CssClass="row1" />
                                                                            <AlternatingRowStyle CssClass="row2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Car ID">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                                            CommandName="EditCar"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Post Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPostDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Package">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                                                        <asp:HiddenField ID="hdnPackDescription" runat="server" Value='<%# Eval("PackageName")%>' />
                                                                                        <asp:HiddenField ID="hdnPackUserPackID" runat="server" Value='<%# Eval("UserPackID")%>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Make">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Model">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblModel" runat="server" Text='<%# Eval("model")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                    <Triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="grdCarDetails" EventName="Sorting" />
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </asp:Panel>
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <br />
                                    <br />
                                    <!-- Vehicle Type Div End -->
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer">
                    <uc1:Footer ID="Footer1" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpeChangePW" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none; background-color: #adbc79; width: 400px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="2" style="background: #FFB113 url(images/AccordionTab1.gif); height: 20px;
                    padding: 10px 0px; color: #fff; text-align: center; font-family: Verdana; font-size: 12px;
                    text-transform: uppercase; font-weight: bold;">
                    Change Password
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="padding-left: 5px;" colspan="2">
                                <br />
                                <asp:UpdatePanel ID="uplPW" runat="server">
                                    <ContentTemplate>
                                        <span style="font-weight: bold">User Name: </span>
                                        <asp:Label ID="lblUnamePW" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px;">
                                New Password<span class="star">*</span>
                            </td>
                            <td style="padding-right: 5px;">
                                <asp:TextBox ID="txtNewPW" TextMode="Password" MaxLength="20" CssClass="input1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px;">
                                Confirm New Password<span class="star">*</span>
                            </td>
                            <td style="padding-right: 5px;">
                                <asp:TextBox ID="txtConfirmPW" MaxLength="20" TextMode="Password" CssClass="input1"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td style="padding: 0 0 20px 0;">
                                <div style="width: 90%; margin: 0; padding-left: 0">
                                    <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnChangePW" class="button1-b" runat="server" Text="Change" OnClientClick="return ValidateChangePW();"
                                                OnClick="btnChangePW_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Button ID="btnCancelPW" class="button1-b" runat="server" Text="Cancel" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
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
            <asp:Button ID="btnNo" class="btn" runat="server" Text="Cancel" />
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" OnClick="btnYes_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
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
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnActiveAd">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnActiveAd" runat="server" />
    <div class="popupBody" style="display: block" id="divActiveAd">
        <div>
            <br />
            <br />
            <p class="pp">
                To add a new package please contact our customer support #:888-786-8307
            </p>
            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpeSelectPack" runat="server" PopupControlID="divSelectPackage"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnSelectPack" CancelControlID="btnCancelSelPack">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnSelectPack" runat="server" />
    <div id="divSelectPackage" style="display: none; background-color: #adbc79; width: 400px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="2" style="background: #FFB113 url(images/AccordionTab1.gif) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Select Package
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="width: 120px;">
                                User Name:
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblUserAddPack" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select a package<span class="star">*</span>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSelPack" runat="server" CssClass="input3">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%">
                                &nbsp;
                            </td>
                            <td style="padding: 0 0 20px 0;">
                                <div style="width: 90%; margin: 0; padding-left: 0">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnGoSelPack" CssClass="button1-b" runat="server" Text="Select" OnClientClick="return ValidateSelPack();"
                                                OnClick="btnGoSelPack_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Button ID="btnCancelSelPack" CssClass="button1-b" runat="server" Text="Cancel" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
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

    <script type="text/ecmascript" language="javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-28766349-1']);
        _gaq.push(['_trackPageview']);
        (function() {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>

</body>
</html>
