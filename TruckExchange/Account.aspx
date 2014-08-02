<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="MyAccount" runat="server">My Account</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/CarsJScript.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

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

            if ($('#txtNewPW').val().trim().length < 1) {
                alert('Please enter new password')
                valid = false;
                $('#txtNewPW').val(''); ;
                $('#txtNewPW').focus()
                return valid;
            }

            else if ($('#txtConfirmPW').val().trim().length < 1) {
                alert('Please enter confirm password')
                valid = false;
                $('#txtConfirmPW').val(''); ;
                $('#txtConfirmPW').focus()
                return valid;
            }
            else if ($('#txtNewPW').val() != $('#txtConfirmPW').val()) {
                $('#txtConfirmPW').focus();
                alert("New password does not match the confirm password");
                $('#txtConfirmPW').val(''); ;
                $('#txtConfirmPW').focus()
                valid = false;
                return valid;
            }


            return valid;
        }

        function ValidateVehicleType() {
            var valid = true;

            if (($('#txtAltEmail').val().trim().length > 0) && (echeck($('#txtAltEmail').val()) == false)) {

                $('#txtAltEmail').val(''); ;
                $('#txtAltEmail').focus()
                valid = false;
                return valid;

            }

            if (($('#txtRegPhone').val().trim().length > 0) && ($('#txtRegPhone').val().trim().length < 10)) {
                $('#txtRegPhone').focus();
                alert("Please enter valid phone number");
                $('#txtRegPhone').val('');
                $('#txtRegPhone').focus()
                valid = false;
                return valid;
            }

            if (($('#txtAltPhone').val().trim().length > 0) && ($('#txtAltPhone').val().trim().length < 10)) {
                $('#txtAltPhone').focus();
                alert("Please enter valid phone number");
                $('#txtAltPhone').val('');
                $('#txtAltPhone').focus()
                valid = false;
                return valid;
            }

            if ($('#txtRegZip').val().trim().length > 0) {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test($('#txtRegZip').val());
                if (isValid == false) {
                    $('#txtRegZip').focus();
                    alert("Please enter valid zipcode");
                    $('#txtRegZip').val(''); ;
                    $('#txtRegZip').focus()
                    valid = false;
                    return valid;
                }
            }


            return valid;
        }

        function ShowPW() {
            debugger
            $('#txtNewPW').val(''); ;
            $('#txtConfirmPW').val(''); ;
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
            if ($('#ddlSelPack option:selected').val() == 0) {
                $('#ddlSelPack').focus();
                alert("Select package");
                $('#ddlSelPack').focus()
                valid = false;
                return valid;
            }
            return valid;
        }


    </script>

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
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px;
            background: #fff" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                        <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
                            Recent Used Truck Listings</h2>
                        <small>
                            <e style="font-size: 11px;">Most recent Used Trucks listed for sale</e>
                        </small>
                        <!-- Left Brand Ads Satrt -->
                        <div class="ticker1">
                            <ul>
                            </ul>
                        </div>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                    <!-- End: adBrite -->
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="border-top: #ccc 1px solid;
                                        width: 98%; padding: 10px 0; margin: 0;">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <!-- Car Info Start -->
                                                    <!-- Car Info End -->
                                                    <!-- My Details Start  -->
                                                    <asp:UpdatePanel ID="updtPnlSearchResultBox" runat="server">
                                                        <ContentTemplate>
                                                            <div class="searchResultsBox activeBox">
                                                                <h3>
                                                                    Registrant Details
                                                                    <asp:Button ID="btnChangePwd" runat="server" CssClass="button1" Text="Change Password"
                                                                        Style="float: right; margin-left: 8px;" OnClientClick="return ShowPW();" />
                                                                    <asp:Button ID="btnEditDetails" runat="server" CssClass="button1" Style="float: right;"
                                                                        Text="Edit Details" OnClick="btnEditDetails_Click" />
                                                                    <asp:Button ID="btnUpdateDetails" runat="server" CssClass="button1" Style="float: right;"
                                                                        Visible="false" Text="Update Details" OnClick="btnUpdateDetails_Click" OnClientClick="return ValidateVehicleType();" />
                                                                </h3>
                                                                <table id="tbl1LblsDisplay" runat="server" style="display: block">
                                                                    <tr>
                                                                        <td style="width: 80px;">
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
                                                                        <td style="width: 80px;">
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
                                                                                <asp:TextBox ID="txtRegPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                                                                                <asp:DropDownList ID="ddlLocationState" runat="server" Width="90px">
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
                                                                <asp:UpdatePanel ID="updtpnlAddPackage" runat="server">
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
                                                                            <asp:TemplateField HeaderText="Dt Of Purchase">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDtOfPurchase" runat="server" Text='<%# Bind("Paydate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                                                    <asp:HiddenField ID="hdnDtOfPurchase" runat="server" Value='<%# Bind("Paydate", "{0:MM/dd/yyyy}") %>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="ValidTill">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblValidTill" runat="server"></asp:Label>
                                                                                    <asp:HiddenField ID="hdnValidTill" runat="server" Value='<%# Eval("Validityperiod")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="# Of Posted Trucks">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblNoOfPostedCars" runat="server" Text='<%# Eval("CarsCount")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="# Of Max Trucks">
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
                                                            Truck Details(Click on TruckID number to view/edit car listing details)
                                                            <div style="width: 90px; font-size: 12px; font-weight: normal; float: right; text-align: right;">
                                                                <asp:UpdatePanel ID="updtpnlAddMultiCar" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="lnkbtnCarDetails" runat="server" Text="Add Truck" OnClick="lnkbtnCarDetails_Click"></asp:LinkButton>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </h3>
                                                        <asp:Panel ID="Panel1" Width="100%" runat="server">
                                                            <asp:UpdatePanel ID="updtpnlTruckdetailsGrid" runat="server">
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
                                                                            <asp:TemplateField HeaderText="TruckID">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                                        CommandName="EditCar"></asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="100px" Font-Bold="true" />
                                                                                <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Post Date">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPostDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yyyy}") %>'></asp:Label>
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
                                                                            <asp:TemplateField HeaderText="Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("TypeName")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Catagory">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("Category_Name")%>'></asp:Label>
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
                </td>
            </tr>
        </table>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        <uc3:TruckFooter ID="TruckFooter1" runat="server" />
    </div>
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updtPnlSearchResultBox"
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
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updtpnlAddPackage"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtpnlAddMultiCar"
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
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="updtpnlTruckdetailsGrid"
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
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                    <h4>
                    </h4>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
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
                                <table>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnChangePW" class="button1" runat="server" Text="Change" OnClientClick="return ValidateChangePW();"
                                                        OnClick="btnChangePW_Click" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnCancelPW" class="button1" runat="server" Text="Cancel" />
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
    <cc1:ModalPopupExtender ID="mdepActiveAd" runat="server" PopupControlID="divActiveAd"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnActiveAd">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnActiveAd" runat="server" />
    <div class="popupBody" style="display: block" id="divActiveAd">
        <div>
            <br />
            <br />
            <p class="pp">
                Inorder to add a new package please contact our customer support.
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
</body>
</html>
