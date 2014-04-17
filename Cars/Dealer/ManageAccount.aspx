<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageAccount.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="Usercontrol/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..::UCE Dealers::..</title>
    <link href="css/maxx.css" rel="stylesheet" type="text/css" />
    <link href="css/buttons.css" rel="stylesheet" type="text/css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>

    <script src="js/jquery.tablesorter.min.js" type="text/javascript"></script>

    <script src="js/production.js" type="text/javascript"></script>

    <!-- Fancyform -->

    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>

    <script type="text/javascript" src="js/jquery.hotkeys.js"></script>

    <script type="text/javascript" src="js/jquery.fancyform.js"></script>

    <script src="Static/JS/JSDealers.js" type="text/javascript"></script>

    <script src="Static/JS/dataFill.js" type="text/javascript"></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

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



        function noLogo() {
            $('.myLogo').attr('src', 'images/Your-Logo.jpg');
        }
        

    </script>

    <script type="text/javascript" language="javascript">


        function isNumberKey(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        var page = 1;
        var actionNow;
        /*
        function pageLoad() {
        // //var path1 = "http://localhost:4111/Cars/2011/Alfa Romeo/8C Competizione/Index.aspx"            
        $.extend({
        getUrlVars: function() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
        }
        return vars;
        },
        getUrlVar: function(name) {
        return $.getUrlVars()[name];
        }
        });


            var urlVars = $.getUrlVars();
        //alert(urlVars["C"]);
        //alert(urlVars["Q"]);

            if (urlVars != null && urlVars != undefined && urlVars != '' && urlVars["C"] != undefined && urlVars["C"] != 'undefined' && urlVars["C"] != null && urlVars["C"] != '') {
        var valid = true;
        if (urlVars["C"]) {
        actionNow = urlVars["C"];
        } else {
        valid = false;
        }
        if (urlVars["Q"]) {
        $('#txtMainSearch').val(urlVars["Q"]);
        }
        if (actionNow.length >= 1 && valid == true) {
        //////console.log(actionNow)                    

                    eval(actionNow)();
        $('.box1 li a').each(function() {
        if ($(this).attr('id') == actionNow) {
        $(this).addClass('act')
        } else { $(this).removeClass('act') }

                    });

                } else {
        searchAllVehicles();
        }


            } else { searchAllVehicles(); }
        }
        */

        $(function() {
            // Use a custom slider
            //$("slider").niceScroll();
            $('#dealerLogo').hide();
            // GetMakes();
            //bindYears();
            //pageLoad();
            //GetModelsInfo();
            //GetModelsInfoByID('1');
            //GetDealerCars('Ford', 'Escape', '2009', 'Asc', '0', '3000', '1', '1', '', '', '1', '25');   // Handler for .ready() called.
            $('#search').click(function() {
                searchVehicle();
            });


            Swid = $('body').width() - (150);
            $(".gridHolder").css({ width: Swid });

            $('.userPic').click(function() {
                var Sleft = $('.userPic').offset().left - ($('.logOutHolder').width()) + 15;
                var Stop = $('.userPic').offset().top + ($('.userPic').height()) + 10;

                $('.logOutHolder').css({ left: Sleft, top: Stop }).show();
            });

            $('.adSer').click(function() {
                var Sleft = $('.searchBlock').offset().left;
                var Stop = $('.searchBlock').offset().top + ($('.searchBlock').height());
                $('.adSearch').css({ left: Sleft, top: Stop }).show();
            });


            $(document).mouseup(function(e) {
                var container = $('.logOutHolder');
                if (container.has(e.target).length === 0) {
                    container.hide();
                }

                var container2 = $('.adSearch');
                if (container2.has(e.target).length === 0) {
                    container2.hide();
                }
            });

            $('.adSearch .close').click(function() {
                $('.adSearch').hide();
            });

            // Custom SelectBox
            /*
            $(".rightNav select").transformSelect();

            $('.rightNav .transformSelect ul').each(function() {
            if ($(this).children().length > 6) {
            $(this).height('160px').css({ 'overflow-y': 'scroll' });
            }
            });
            */




            // Upload Logo btnSaveLogo / selectLogo

            $('.selectLogo').change(function() {
                //alert(this);
                var ext = this.value.match(/\.(.+)$/)[1];
                switch (ext) {
                    case 'png':
                        $('#btnSaveLogo').attr('disabled', false);
                        break;
                    case 'jpg':
                        $('#btnSaveLogo').attr('disabled', false);
                        break;
                    case 'jpeg':
                        $('#btnSaveLogo').attr('disabled', false);
                        break;
                    default:
                        alert('This is not an allowed file type.');
                        this.value = '';
                        $('#btnSaveLogo').attr('disabled', 'disabled');
                }
            });



        });

        $(window).resize(function() {
            Swid = $('body').width() - (150);
            $(".gridHolder").css({ width: Swid });

            $('.logOutHolder').hide();
        });

        function ValidateVehicleType() {
            var valid = true;
            if ((document.getElementById('lblRegEmail').value.length > 0) && (echeck(document.getElementById('lblRegEmail').value) == false)) {

                document.getElementById('lblRegEmail').value = "";
                document.getElementById('lblRegEmail').focus()
                valid = false;
                return valid;
            }
            if ((document.getElementById('txtAltEmail').value.length > 0) && (echeck(document.getElementById('txtAltEmail').value) == false)) {

                document.getElementById('txtAltEmail').value = "";
                document.getElementById('txtAltEmail').focus()
                valid = false;
                return valid;
            }

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

        function AddValidateUser() {

            if ($('#txtName').val() == "") {
                alert("Please enter Name");
                $('#txtName').val('');
                $('#txtName').focus()
                return false;

            }
            else if ($('#txtUserID').val() == "") {
                alert("Please enter UserID ");
                $('#txtUserID').val('');
                $('#txtUserID').focus()
                return false;
            }

            else if ($('#txtUserName').val() == "") {
                alert("Please enter email ID");
                $('#txtUserName').val('');
                $('#txtUserName').focus()
                return false;

            }
            if (($('#txtUserName').val().length > 0) && (echeck($('#txtUserName').val()) == false)) {

                $('#txtUserName').val('');
                $('#txtUserName').focus()
                valid = false;
                return valid;
            }
            else if ($('#txtPhoneNumber').val() == "") {
                alert("Please enter Phone number");
                $('#txtPhoneNumber').val('');
                $('#txtPhoneNumber').focus();
                return false;
            }
            else if ($('#txtPhoneNumber').val().length < 10) {
                alert("Please enter valid Phone number");
                $('#txtPhoneNumber').val('');
                $('#txtPhoneNumber').focus();
                return false;
            }


            else if ($('#txtPassword').val() == "") {
                alert("Please enter Password");
                $('#txtPassword').val('');
                $('#txtPassword').focus();
                return false;
            }

            else if ($('#txtConfirmPassword').val() == "") {
                alert("Please enter confirm Password");
                $('#txtConfirmPassword').val('');
                $('#txtConfirmPassword').focus();
                return false;

            }

            else if ($('#txtConfirmPassword').val() != $('#txtPassword').val()) {
                alert("Confirm password should match to password");
                $('#txtConfirmPassword').val('');
                $('#txtConfirmPassword').focus();
                return false;

            }
            return true;

        }




        function EditValidateUser() {
            debugger
            if ($('#txtEditName').val() == "") {
                alert("Please enter Name");
                $('#txtEditName').val('');
                $('#txtEditName').focus()
                return false;

            }

            else if ($('#txtEditUserName').val() == "") {
                alert("Please enter email ID");
                $('#txtEditUserName').val('');
                $('#txtEditUserName').focus()
                return false;

            }
            if (($('#txtEditUserName').val().length > 0) && (echeck($('#txtEditUserName').val()) == false)) {

                $('#txtEditUserName').val('');
                $('#txtEditUserName').focus()
                valid = false;
                return valid;
            }
            else if ($('#txtEditPhoneNumber').val() == "") {
                alert("Please enter Phone number");
                $('#txtEditPhoneNumber').val('');
                $('#txtEditPhoneNumber').focus();
                return false;
            }
            else if ($('#txtEditPhoneNumber').val().length < 10) {
                alert("Please enter valid Phone number");
                $('#txtEditPhoneNumber').val('');
                $('#txtEditPhoneNumber').focus();
                return false;
            }

            if ($('#txtEditNewPassword').val() != "") {
                if ($('#txtEditNewPassword').val() == "") {
                    alert("Please enter Password");
                    $('#txtEditNewPassword').val('');
                    $('#txtEditNewPassword').focus();
                    return false;

                }
                else if ($('#txtEditNewPassword').val() != $('#txtEditConfirmPassword').val()) {

                    alert("New confirm password should match to new password");
                    $('#txtEditConfirmPassword').val('');
                    $('#txtEditConfirmPassword').focus();
                    return false;

                }

            }


            return true;
        }

       
        

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <table class="bb" style="width: 100%; height: 100%; min-height: 100%; border-collapse: collapse"
        cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 47px;">
                <!-- Head Start  -->
                <!-- Head End  -->
                <uc1:Header ID="Header1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <!-- Main Start  -->
                <div class="main">
                    <!-- twoBox Start   -->
                    <div class="twoBox">
                        <table class="wrapper" style="width: 100%; border-collapse: collapse;" cellpadding="0"
                            cellspacing="0">
                            <tr>
                                <!-- Left Box1 Start -->
                                <td class="box1">
                                    <ul class="links1">
                                        <li><a href="javascript:searchAllVehicles();" id="searchAllVehicles">All Vehicles</a></li>
                                        <li><a href="javascript:searchVehiclePublished();" id="searchVehiclePublished">Published</a></li>
                                        <li><a href="javascript:searchVehiclePrePublished();" id="searchVehiclePrePublished">
                                            Pre Published</a></li>
                                        <li><a href="javascript:searchVehicleSold();" id="searchVehicleSold">Sold</a></li>
                                        <li><a href="javascript:searchVehicleWithdrawn();" id="searchVehicleWithdrawn">Withdrawn</a></li>
                                        <li><a href="javascript:searchVehicleAdminCancel();" id="searchVehicleAdminCancel">Admin
                                            Cancel</a></li>
                                    </ul>
                                    <hr />
                                    <ul class="links2">
                                        <li><a href="javascript:searchVehicleArchive();" id="searchVehicleArchive">Archived
                                        </a></li>
                                    </ul>
                                </td>
                                <!-- Left Box1 End -->
                                <!-- Right Box2 Start  -->
                                <td class="box2">
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div class="rightNav">
                                        <table width="99%">
                                            <tr>
                                                <td style="width: 120px">
                                                    <h3 style="padding-top: 5px;">
                                                        Manage Account
                                                    </h3>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div class="clear">
                                        &nbsp;</div>
                                    <div class="devider1">
                                        &nbsp;</div>
                                    <!-- Form Start -->
                                    <div class="uploadCarForm" style="width: 100%; min-width: 710px;">
                                        <!-- Dealer Information Start  -->
                                        <div class="wid45P left" style="width: 380px;">
                                            <fieldset class="formUploadCar" style="height: 220px">
                                                <legend>Dealer Information</legend>
                                                <table class="wid100P padB6 noPadTable">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 110px;">
                                                                <strong>Business Name</strong>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDealerBName" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>DealerCode</strong>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDealerCode" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>Phone</strong>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDealerPhone" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>Email</strong>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDealerEmail" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: top">
                                                                <strong>Address</strong>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDealerAddress" runat="server"></asp:Label>
                                                                <br />
                                                                <asp:Label ID="lblDealerCity" runat="server"></asp:Label>
                                                                <asp:Label ID="lblDealerState" runat="server"></asp:Label>
                                                                <asp:Label ID="lblDealerZip" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <!-- Dealer Information End  -->
                                        <!-- Seller Information Start  -->
                                        <div class="wid45P left" style="margin-left: 50px; min-width: 550px;">
                                            <fieldset class="formUploadCar" style="height: 220px">
                                                <legend>Seller Information</legend>
                                                <asp:UpdatePanel ID="updtPnlSearchResultBox" runat="server" UpdateMode="Always">
                                                    <ContentTemplate>
                                                        <table id="tbl1LblsDisplay" runat="server" class="wid100P padB6" style="display: block">
                                                            <tr>
                                                                <td style="width: 110px;">
                                                                    <b>Seller Name:</b>
                                                                </td>
                                                                <td>
                                                                    <div id="divlblRegName" runat="server" style="display: block">
                                                                        <asp:Label ID="lblRegName" runat="server"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Email: </b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblRegEmail2" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Alt Email: </b>
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
                                                                    <asp:HiddenField ID="hdnsellarID" runat="server"></asp:HiddenField>
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
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Button runat="server" ID="btnEditDetails" class="g-button right" Text="Edit"
                                                                        OnClick="btnEdit_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="tbl2textDisplay" runat="server" style="display: none; width: 100%;">
                                                            <tr>
                                                                <td style="width: 70px;">
                                                                    <b>Name:</b>
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <div id="divtxtRegName" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtregName" runat="server" MaxLength="25"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td style="width: 75px;">
                                                                    <%--<b>Address:</b>--%>
                                                                    <b>Alt Phone:</b>
                                                                </td>
                                                                <td>
                                                                    <div id="divlblRegAddress" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divtxtRegAddress" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="40"></asp:TextBox>
                                                                    </div>
                                                                    <asp:TextBox ID="txtAltPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 80px;">
                                                                    <b>Email:</b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="lblRegEmail" runat="server"></asp:TextBox>
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
                                                                <td style="width: 80px;">
                                                                    <b>Alt Email:</b>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAltEmail" runat="server" MaxLength="30"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <b>State:</b>
                                                                </td>
                                                                <td>
                                                                    <div id="divlblRegState" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divddlRegState" runat="server" style="display: none">
                                                                        <asp:DropDownList ID="ddlLocationState" runat="server" Width="110px" AppendDataBoundItems="true">
                                                                            <asp:ListItem Value="0" Text="Unspecified"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
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
                                                                    <b>Zip:</b>
                                                                </td>
                                                                <td>
                                                                    <div id="divlblRegZip" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divtxtRegZip" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtRegZip" runat="server" MaxLength="5" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <%-- <tr>
                                                                <td>
                                                                    <b>Alt Phone:</b>
                                                                </td>
                                                                <td>
                                                                  
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnUpdateDetails" runat="server" CssClass="g-button g-button-submit "
                                                                        Visible="false" Text="Save" OnClick="btnUpdateDetails_Click" OnClientClick="return ValidateVehicleType();" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </fieldset>
                                        </div>
                                        <!-- Seller Information End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                        <!-- Dealaer Logo Start  -->
                                        <div class="wid45P left" style="width: auto; width: 380px;">
                                            <fieldset class="formUploadCar">
                                                <legend>Dealer Logo</legend>
                                                <table style="width: 319px; height: auto; margin: 7px auto">
                                                    <tr>
                                                        <td style="width: 115px;">
                                                            <asp:UpdatePanel ID="Updpnlimg" runat="server" UpdateMode="Always">
                                                                <ContentTemplate>
                                                                    <asp:Image runat="server" ID="imgthumb" class="myLogo" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:FileUpload ID="fileUP" runat="server" class="selectLogo" Style="float: none;
                                                                margin: 5px" />
                                                            <br />
                                                            <asp:Button Text="Save" class="g-button" disabled="disabled" ID="btnSaveLogo" runat="server"
                                                                Style="float: none; margin: 5px" OnClick="btnSaveLogo_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <!-- Dealaer Logo End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                        <table style="width: 100%; position: relative; margin-bottom: -29px;">
                                            <tr>
                                                <td style="width: 95px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 85px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 70px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 150px;">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: auto">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 124px;">
                                                    <asp:Button Text="Add User" ID="btnAddUsers" runat="server" class="g-button add-User"
                                                        OnClientClick="return clearData()" />
                                                </td>
                                            </tr>
                                        </table>
                                        <!-- Vehicle Information Start  -->
                                        <div class="wid100P" style="margin-top: 30px;">
                                            <fieldset class="formUploadCar">
                                                <legend>Manage Users</legend>
                                                <div class="gridHolder1">
                                                    <asp:GridView ID="grdUsers" runat="server" class="wid100P padB6 grid1" AutoGenerateColumns="false"
                                                        GridLines="None" OnRowCommand="grdUsers_RowCommand" OnRowDataBound="grdUsers_RowDataBound">
                                                        <RowStyle CssClass="row1" />
                                                        <AlternatingRowStyle CssClass="row1" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Login ID">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserID" runat="server" Text='<%# Eval("UserID")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Email">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("UserName")%>' />
                                                                    <asp:HiddenField ID="hdnpassword" runat="server" Value='<%# Eval("Pwd")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblActive" runat="server" Text='<%# Eval("isActive")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PhoneNumber">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Eval("PhoneNumber")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lblEdit" runat="server" Text="Edit" CommandName="EditRow" CommandArgument='<%# Eval("UID")%>' />
                                                                    <asp:HiddenField ID="hdnisdefault" runat="server" Value='<%# Eval("isdefault")%>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </fieldset>
                                        </div>
                                        <!-- Vehicle Information End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                        <br />
                                        <br />
                                    </div>
                                    <!-- Grid End -->
                                </td>
                                <!-- Right Box2 End  -->
                            </tr>
                        </table>
                    </div>
                    <!-- twoBox End  -->
                </div>
                <!-- Main End  -->
            </td>
        </tr>
        <tr>
            <td style="height: 40px; overflow: hidden;">
                <!-- Footer Start  -->
                <div class="footer">
                    Copyright &copy; 2013 <a href="http://www.unitedcarexchange.com" target="_blank">unitedcarexchange.com</a>
                </div>
                <!-- Footer End  -->
            </td>
        </tr>
    </table>
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
                                Confirm Password <span class="star">*</span>
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
    <!-- Add Use Popup Start  -->

    <script type="text/javascript">
    
          /*  txtregName.Text
                txtRegAddress.Text
                    txtRegCity.Text
                        
                        txtRegZip.Text
                            txtRegPhone.Text
                                txtAltEmail.Text
                                    txtAltPhone.Text
                                    */

        function clearData() {
            $('#txtName').val('');
            $('#txtUserID').val('');
            $('#txtUserName').val('');
            $('#txtPhoneNumber').val('');
            $('#txtPassword').val('');
            $('#txtConfirmPassword').val('');


            $('#ddlActive option').each(function() {
                $(this).removeAttr('selected');
            })
            $('#ddlActive option:eq(' + 0 + ')').attr('selected', 'selected');
            $find('MpeAdduser').show();
            return false;
        }
    /*
        $('#btnAddUsers').click(function() {
            $('#txtName').val('');
            $('#txtUserID').val('');
            $('#txtUserName').val('');
            $('#txtPhoneNumber').val('');
            $('#txtPassword').val('');
            $('#txtConfirmPassword').val('');


            $('#ddlActive option').each(function() {
                $(this).removeAttr('selected');
            })
            $('#ddlActive option:eq('+0+')').attr('selected', 'selected');
            $find('MpeAdduser').show();

        })                           
        */                            
                                    
                                    
    </script>

    <cc1:ModalPopupExtender ID="MpeAdduser" runat="server" PopupControlID="addUser" BackgroundCssClass="ModalPopupBG"
        TargetControlID="hdnAdd" CancelControlID="btnclose" OkControlID="btnCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAdd" runat="server" />
    <div class="addUser" id="addUser" style="display: none">
        <asp:LinkButton ID="btnclose" runat="server" PostBackUrl="#" class="close"></asp:LinkButton>
        <h3 style="padding-top: 5px;">
            Add User
        </h3>
        <div class="devider1">
            &nbsp;</div>
        <table class="vCenter">
            <tr>
                <td style="width: 120px">
                    Name<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtName" MaxLength="50" TabIndex="50" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    LoginID <span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtUserID" MaxLength="50" TabIndex="51" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Email<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" MaxLength="50" TabIndex="52" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Phone Number<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" MaxLength="10" TabIndex="53" onkeypress="return isNumberKey(event)"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Password<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" TabIndex="54" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    Confirm Password<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="50" TabIndex="55"
                        TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    Status
                </td>
                <td>
                    <asp:DropDownList ID="ddlActive" runat="server" TabIndex="56">
                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-top: 6px;">
                    <asp:Button runat="server" ID="btnAddUser" Text="Save" class="g-button left" OnClick="btnAddUser_Click"
                        OnClientClick="return AddValidateUser();" />
                    <asp:Button runat="server" ID="btnCancel" Text="Cancel" class="g-button left cancel"
                        Style="margin-left: 6px;" />
                </td>
            </tr>
        </table>
    </div>
    <!-- Add Use Popup End  -->
    <!-- Edit Use Popup Start  -->
    <cc1:ModalPopupExtender ID="MpeEdituser" runat="server" PopupControlID="editUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hndEditUser" CancelControlID="lbtnClose"
        OkControlID="btnEditCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hndEditUser" runat="server" />
    <div id="editUser" class="editUser">
        <asp:LinkButton ID="lbtnClose" runat="server" PostBackUrl="#" class="close"></asp:LinkButton>
        <h3 style="padding-top: 5px;">
            Edit User
        </h3>
        <div class="devider1">
            &nbsp;</div>
        <table class="vCenter">
            <tr>
                <td style="width: 120px">
                    Name<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEditName" MaxLength="50" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Login ID
                </td>
                <td>
                    <asp:Label ID="txtEditUserID" runat="server" Style="line-height: 30px;" />
                    <asp:HiddenField ID="txtEditUId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Email<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEditUserName" MaxLength="50" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Phone<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEditPhoneNumber" MaxLength="10" onkeypress="return isNumberKey(event)"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="hdnOldPassword" runat="server" />
                    New Password<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEditNewPassword" runat="server" MaxLength="50" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    Confirm Password<span class="star">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtEditConfirmPassword" runat="server" MaxLength="50" TextMode="Password" />
                </td>
            </tr>
            <tr>
                <td>
                    Status
                </td>
                <td>
                    <asp:DropDownList ID="ddlEditActive" runat="server">
                        <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-top: 6px;">
                    <asp:Button runat="server" ID="btnEdit" Text="Save" class="g-button left" OnClick="btnEdit_Click1"
                        OnClientClick="return EditValidateUser();" />
                    <asp:Button runat="server" ID="btnEditCancel" Text="Cancel" class="g-button left cancel"
                        Style="margin-left: 6px;" />
                </td>
            </tr>
        </table>
    </div>
    <!-- Edit Use Popup End  -->
    </form>
</body>
</html>
