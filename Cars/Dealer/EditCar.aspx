<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCar.aspx.cs" Inherits="EditCar" %>

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

    <script src="js/production.js" type="text/javascript"></script>

    <!-- Fancyform -->

    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>

    <script type="text/javascript" src="js/jquery.hotkeys.js"></script>

    <script type="text/javascript" src="js/jquery.fancyform.js"></script>

    <script src="Static/JS/JSDealers.js" type="text/javascript"></script>

    <script src="Static/JS/dataFill.js" type="text/javascript"></script>

    <script type='text/javascript' src='../js/jquery.alphanumeric.pack.js'></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function isNumberKeyWithDot(evt) {

            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;

            return true;
        }
        var page = 1;
        var CarID1;

        function pageLoad() {
            //var path1 = "http://localhost:4111/Cars/2011/Alfa Romeo/8C Competizione/Index.aspx"            
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

            if (urlVars != null && urlVars != undefined && urlVars != '' && urlVars["CarInventoryID"] != undefined && urlVars["CarInventoryID"] != 'undefined' && urlVars["CarInventoryID"] != null && urlVars["CarInventoryID"] != '') {

                var valid = true;
                if (urlVars["CarInventoryID"]) {
                    CarID1 = urlVars["CarInventoryID"].split('P');
                } else {
                    valid = false;
                }

                if (CarID1.length >= 1 && valid == true) {
                    //FindDealerCarID(sDealerCarID)
                    //FindDealerCarID(CarID1[0]);
                    ////console.log(CarID1);

                } else {
                    alert('Wrong CarInventoryID..!')
                }

                //alert(CarID1);

                //CarsSearch2(make1, Modal1, ZipCode1, WithinZipNew,'1', '25', 'Price');            
                //alert(WithinZip1);      

            } else {
                // window.location.href='searchcars.aspx?Make=All makes&Model=All models&ZipCode=92404&WithinZip=4';
                alert('Wrong DealerUniqueID..!')
            }

        }


        $(function() {
            // Use a custom slider		
            //$("slider").niceScroll();
            pageLoad();
            // GetMakes();
            // bindYears();



            Swid = $(window).width() - (255);
            //$(".gridHolder").css({ width: Swid });

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

            });



            // RAdio Button On Click
            $('#ddlTransmission input[type=radio]').click(function() {
                if ($(this).is(':checked')) {
                    $('#ddlTransmission label').removeClass('active')
                    $(this).next('label').addClass('active')
                }
            })
            $('#ddlCondition input[type=radio]').click(function() {
                if ($(this).is(':checked')) {
                    $('#ddlCondition label').removeClass('active')
                    $(this).next('label').addClass('active')
                }
            })


        });

        $(window).resize(function() {
            $('.logOutHolder').hide();
        });




        // TExt box char Count
        function updateCharCount(textArea, displayField, displaySentence) {
            // Only proceed if the parameters are valid
            if (null != textArea && null != displayField && null != displaySentence) {
                // Determine the count
                var count = 1000; // Max length
                count -= textArea.value.length; // Text length
                // Update the count
                document.getElementById(displayField).innerHTML = count; // Update the number
                // Update sentence color
                if (count > 20) {
                    document.getElementById(displaySentence).style.color = "#808080";
                    //document.getElementById(displaySentence).style.fontWeight = "normal";
                } else if (count > 5) {
                    document.getElementById(displaySentence).style.color = "#C24747";
                    //document.getElementById(displaySentence).style.fontWeight = "normal";
                } else if (count > 0) {
                    document.getElementById(displaySentence).style.color = "#FF0000";
                    //document.getElementById(displaySentence).style.fontWeight = "normal";
                } else {
                    document.getElementById(displaySentence).style.color = "#FF0000";
                    //document.getElementById(displaySentence).style.fontWeight = "bold";
                    textArea.value = textArea.value.substr(0, 999);
                } // END 
            } // END if
            return false;
        }


        function ValidateVehicleType() {

            var valid = true;
            debugger

          
            if (document.getElementById('<%=ddlYear.ClientID%>').value == "0") {
                alert('Please select year')
                valid = false;
                document.getElementById('ddlYear').focus();
                return valid;
            }

            if (document.getElementById('<%=ddlMake.ClientID%>').value == "-1") {
                alert("Please select make");
                valid = false;
                document.getElementById('ddlMake').focus();
                return valid;
            }
            if (document.getElementById('<%=ddlModel.ClientID%>').value == "") {
                alert("Please select model");
                valid = false;
                document.getElementById('ddlModel').focus();
                return valid;
            }
            if (document.getElementById('<%=ddlModel.ClientID%>').value == "-1") {
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

            if ((document.getElementById('<%=txtSellerEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtSellerEmail.ClientID%>').value) == false)) {

                document.getElementById('<%=txtSellerEmail.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEmail.ClientID%>').focus()
                valid = false;


            }
            //            if ($('#txtCurrentPrice').val() == '') {
            //                $('#txtCurrentPrice').focus();
            //                alert("Please enter Selling price");
            //                $('#txtCurrentPrice').val('');
            //                valid = false;
            //                return valid;

            //            }
            //            if ($('#txtPurchaseCost').val() == '') {

            //                $('#txtPurchaseCost').focus();
            //                alert("Please enter Purchase Cost");
            //                $('#txtPurchaseCost').val('');
            //                
            //                valid = false;
            //                return valid;
            //            }            
            //            else if ($('#txtAskingPrice').val() == '') {
            //            $('#txtAskingPrice').focus();
            //                alert("Please enter asking price");
            //                $('#txtAskingPrice').val('');
            //                valid = false;
            //                return valid;

            //            }
            //            var PurchaseCost = parseFloat($('#txtPurchaseCost').val())  // 1.4
            //            var AskingPrice = parseFloat($('#txtAskingPrice').val())  // 1.4
            //            var SellingPrice = parseFloat($('#txtCurrentPrice').val())  // 1.4
            //            if (PurchaseCost > AskingPrice) {
            //                $('#txtPurchaseCost').focus();
            //                alert("selling price should be greater than purchase cost");
            //                $('#txtPurchaseCost').val('');
            //                valid = false;
            //                return valid;
            //            }

            //            if (PurchaseCost > SellingPrice) {
            //                $('#txtCurrentPrice').focus();
            //                alert("Please enter proper SellingPrice ");
            //                $('#txtCurrentPrice').val('');
            //                valid = false;
            //                return valid;
            //            }
            showSpinner();

            return valid;
        }

	
	
	
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="BtnSavePanel"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <table class="bb" style="width: 100%; height: 100%; min-height: 100%; border-collapse: collapse"
        cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 47px;">
                <!-- Head Start  -->
                <uc1:Header ID="Header1" runat="server" />
                <!-- Head End  -->
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
                                        <li><a href="javascript:void(0);" id="searchAllVehicles">All Vehicles</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehiclePublished">Published</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehiclePrePublished">Pre Published</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehicleSold">Sold</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehicleWithdrawn">Withdrawn</a></li>
                                        <li><a href="javascript:void(0);" id="searchVehicleAdminCancel">Admin Cancel</a></li>
                                    </ul>
                                    <hr />
                                    <ul class="links2">
                                        <li><a href="javascript:void(0);" id="searchVehicleArchive">Archive </a></li>
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
                                                        Edit vehicle details</h3>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <table>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <input type="button" class="g-button" value="Manage Photos" onclick="editImages();" />
                                                                </td>
                                                                <td style="width: 20px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 53px;">
                                                                    <h4 style="padding-top: 3px;">
                                                                        Vehicle Status :</h4>
                                                                </td>
                                                                <td style="width: 120px">
                                                                    <select id="resAction1" style="">
                                                                        <option value="1">Publish</option>
                                                                        <option value="6" selected="selected">Pre Publish</option>
                                                                        <option value="3">Withdraw</option>
                                                                        <option value="4">Sold</option>
                                                                        <option value="5">Admin Cancel</option>
                                                                    </select>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td>
                                                    <table style="font-size: 12px; font-weight: bold; font-family: Arial, Helvetica, sans-serif;
                                                        width: 100%; margin: 0;" class="form1">
                                                        <tr>
                                                            <td>
                                                                <div id="lblPackDiv" runat="server" style="display: none">
                                                                    <asp:Label ID="lblPackageName" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <div style="width: 340px; float: right; padding: 0; text-align: right; padding-top: 40px">
                                                        <asp:UpdatePanel ID="updtpnlSold" runat="server">
                                                            <ContentTemplate>
                                                                <!--<asp:Button ID="btnActive" runat="server" CssClass="g-button" Text="Activate" Style="float: right;
                                                                    margin-left: 8px;" Visible="false" OnClick="btnActive_Click" />
                                                                <asp:Button ID="btnSold" runat="server" CssClass="g-button" Text="Sold" Style="float: right;
                                                                    margin-left: 8px;" Visible="false" OnClick="btnSold_Click" />
                                                                <asp:Button ID="btnWithdraw" runat="server" CssClass="g-button" Text="Withdraw" Style="float: right;
                                                                    margin-left: 8px;" Visible="false" OnClick="btnWithdraw_Click" /> -->
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="devider1">
                                        &nbsp;</div>
                                    <!-- Form Start -->
                                    <div class="uploadCarForm" style="width: 100%; min-width: 710px;">
                                        <!-- VEHICLE TYPE Start  -->
                                        <div class="wid45P left">
                                            <fieldset class="formUploadCar">
                                                <legend>VEHICLE TYPE</legend>
                                                <table class="wid100P padB6">
                                                    <tr>
                                                        <td style="width: 90px;">
                                                            Year <span class="star">*</span>
                                                            <asp:HiddenField ID="hdnDealerUniqueID" runat="server" />
                                                        </td>
                                                        <td style="width: 300px">
                                                            <asp:DropDownList ID="ddlYear" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Make <span class="star">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtMake" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMake" runat="server" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged"
                                                                        AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Model <span class="star">*</span>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModel" runat="server">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Body Type
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlStyle" runat="server">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding-top: 6px; vertical-align: top; width: 115px;">
                                                            Asking Price
                                                        </td>
                                                        <td style="width: 170px;">
                                                            <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                        </td>
                                                        <td style="padding-top: 6px; display: none">
                                                            Selling Price
                                                        </td>
                                                        <td runat="server" style="padding: 0" visible="false">
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtCurrentPrice" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                            Style="width: 90px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="width: 35px;">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td style="width: 92px;">
                                                                        Purchase Cost
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtPurchaseCost" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                            Style="width: 90px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <!-- VEHICLE TYPE End  -->
                                        <!-- SELLER INFORMATION FOR DISPLAY Start  -->
                                        <div class="wid45P left ML5P">
                                            <fieldset class="formUploadCar">
                                                <legend>SELLER INFORMATION FOR DISPLAY</legend>
                                                <table class="wid100P padB6">
                                                    <tr>
                                                        <td>
                                                            Seller Name
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSellerName" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none;">
                                                        <td>
                                                            Address
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSellerAddress" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            City
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtCity" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            State
                                                        </td>
                                                        <td>
                                                            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlLocationState" runat="server" CssClass="input1" Width="100px">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                    <td style="width: 40px; overflow: hidden;">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td style="width: 28px;">
                                                                        ZIP
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtZip" runat="server" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"
                                                                            CssClass="input1" Width="60px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Phone
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSellerPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                                                CssClass="input1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Email
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSellerEmail" runat="server" MaxLength="30" CssClass="input1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <!-- SELLER INFORMATION FOR DISPLAY End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                        <br />
                                        <br />
                                        <!-- Vehicle Information Start  -->
                                        <div class="wid100P">
                                            <fieldset class="formUploadCar">
                                                <legend>Vehicle Details</legend>
                                                <table class="wid100P padB6">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                Title
                                                            </td>
                                                            <td colspan="5">
                                                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="90%"></asp:TextBox><br />
                                                                <span style="font-size: 11px">(Ex: 2004 Honda Accord EX V6 - Dark Blue - Auto - 58K
                                                                    Mi.)</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                           <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td style="width: 110px;">
                                                                Drive Train
                                                            </td>
                                                            <td style="width: 170px">
                                                                <asp:DropDownList ID="ddlDriveTrain" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Mileage
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td style="width: 110px;">
                                                                Engine Cylinders
                                                            </td>
                                                            <td style="width: 170px">
                                                                <asp:DropDownList ID="ddlCylinderCount" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Exterior Color
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlExteriorColor" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Doors
                                                            </td>
                                                            <td>
                                                                <span id="oeFormdoorCountContainer">
                                                                    <asp:DropDownList ID="ddlDoorCount" runat="server">
                                                                    </asp:DropDownList>
                                                                </span>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Interior Color
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlInteriorColor" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                Fuel Type
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlFuelType" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                            </td>
                                                            <td>
                                                                VIN
                                                                <br />
                                                                <em>(may add later)</em>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormvinContainer">
                                                                    <asp:TextBox ID="txtVin" runat="server" MaxLength="17"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Transmission
                                                            </td>
                                                            <td colspan="4">
                                                                <span id="oeFormtransmissionContainer">
                                                                    <asp:RadioButtonList ID="ddlTransmission" runat="server" RepeatDirection="Horizontal"
                                                                        RepeatLayout="Flow">
                                                                    </asp:RadioButtonList>
                                                                </span>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Condition
                                                            </td>
                                                            <td colspan="4">
                                                                <span id="Span1">
                                                                    <asp:RadioButtonList ID="ddlCondition" runat="server" RepeatDirection="Horizontal"
                                                                        RepeatLayout="Flow">
                                                                    </asp:RadioButtonList>
                                                                </span>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <!-- Vehicle Information End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                        <br />
                                        <br />
                                        <!-- Vehicle Description  Start  -->
                                        <div class="wid100P">
                                            <fieldset class="formUploadCar">
                                                <legend>Vehicle FEATURES </legend>
                                                <table class="wid100P padB6">
                                                    <tr>
                                                        <td rowspan="12" width="155px" valign="top" style="padding-right: 0px;">
                                                            Features
                                                            <br />
                                                            <br />
                                                            <em>(You may add or modify these later.)</em>
                                                        </td>
                                                        <td style="width: 175px;">
                                                            <div>
                                                                <em><b>Comfort</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures51" runat="server" />
                                                                    <%--<input name="features" value="A/C: Front" type="checkbox" />--%>
                                                                    A/C</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures1" runat="server" />
                                                                    A/C: Front</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures2" runat="server" />
                                                                    A/C: Rear</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures3" runat="server" />
                                                                    Cruise Control</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures4" runat="server" />
                                                                    Navigation System
                                                                </div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures5" runat="server" />
                                                                    Power Locks</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures6" runat="server" />
                                                                    <%--<input name="features2" value="Power Steering" type="checkbox" />--%>
                                                                    Power Steering</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures7" runat="server" />
                                                                    <%-- <input name="features2" value="Remote Keyless Entry" type="checkbox" />--%>
                                                                    Remote Keyless Entry</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures8" runat="server" />
                                                                    <%--<input name="features2" value="TV/VCR" type="checkbox" />--%>
                                                                    TV/VCR</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures31" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Remote Start</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures33" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Tilt</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures35" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Rearview Camera</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures36" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Power Mirrors</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Seats</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures9" runat="server" />
                                                                    <%-- <input name="features2" value="Bucket Seats" type="checkbox" />--%>
                                                                    Bucket Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures10" runat="server" />
                                                                    <%--<input name="features2" value="Leather Interior" type="checkbox" />--%>
                                                                    Leather Interior</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures11" runat="server" />
                                                                    <%-- <input name="features2" value="Memory Seats" type="checkbox" />--%>
                                                                    Memory Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures12" runat="server" />
                                                                    <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                                    Power Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures32" runat="server" />
                                                                    <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                                    Heated Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures37" runat="server" />
                                                                    <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                                    Vinyl Interior</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures38" runat="server" />
                                                                    <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                                    Cloth Interior</div>
                                                            </div>
                                                        </td>
                                                        <td valign="top" style="width: 155px;">
                                                            <div>
                                                                <em><b>Safety</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures13" runat="server" />
                                                                    <%--<input name="features2" value="Airbag: Driver" type="checkbox" />--%>
                                                                    Airbag: Driver</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures14" runat="server" />
                                                                    <%--<input name="features2" value="Airbag: Passenger" type="checkbox" />--%>
                                                                    Airbag: Passenger</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures15" runat="server" />
                                                                    <%--<input name="features2" value="Airbag: Side" type="checkbox" />--%>
                                                                    Airbag: Side</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures16" runat="server" />
                                                                    <%--<input name="features2" value="Alarm" type="checkbox" />--%>
                                                                    Alarm</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures17" runat="server" />
                                                                    <%--<input name="features2" value="Anti-Lock Brakes" type="checkbox" />--%>
                                                                    Anti-Lock Brakes</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures18" runat="server" />
                                                                    <%--<input name="features2" value="Fog Lights" type="checkbox" />--%>
                                                                    Fog Lights</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures39" runat="server" />
                                                                    <%--<input name="features2" value="Fog Lights" type="checkbox" />--%>
                                                                    Power Brakes</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Sound System</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures19" runat="server" />
                                                                    <%--<input name="features2" value="Cassette Radio" type="checkbox" />--%>
                                                                    Cassette Radio</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures20" runat="server" />
                                                                    <%--<input name="features2" value="CD Changer" type="checkbox" />--%>
                                                                    CD Changer
                                                                </div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures21" runat="server" />
                                                                    <%--<input name="features2" value="CD Player" type="checkbox" />--%>
                                                                    CD Player</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures22" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Premium Sound</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures34" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    AM/FM</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures40" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    DVD</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>New</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures44" runat="server" />
                                                                    <%--<input name="features2" value="Cassette Radio" type="checkbox" />--%>
                                                                    Battery</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures45" runat="server" />
                                                                    <%--<input name="features2" value="CD Changer" type="checkbox" />--%>
                                                                    Tires
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td valign="top">
                                                            <div>
                                                                <em><b>Windows</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures23" runat="server" />
                                                                    <%-- <input name="features2" value="Power Windows" type="checkbox" />--%>
                                                                    Power Windows</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures24" runat="server" />
                                                                    <%--<input name="features2" value="Rear Window Defroster" type="checkbox" />--%>
                                                                    Rear Window Defroster</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures25" runat="server" />
                                                                    <%-- <input name="features2" value="Rear Window Wiper" type="checkbox" />--%>
                                                                    Rear Window Wiper</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures26" runat="server" />
                                                                    <%--<input name="features2" value="Tinted Glass" type="checkbox" />--%>
                                                                    Tinted Glass</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Other</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures27" runat="server" />
                                                                    <%--<input name="features2" value="Alloy Wheels" type="checkbox" />--%>
                                                                    Alloy Wheels</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures28" runat="server" />
                                                                    <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                                    Sunroof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures41" runat="server" />
                                                                    <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                                    Panoramic Roof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures42" runat="server" />
                                                                    <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                                    Moon Roof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures29" runat="server" />
                                                                    <%--<input name="features2" value="Third Row Seats" type="checkbox" />--%>
                                                                    Third Row Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures30" runat="server" />
                                                                    <%--<input name="features2" value="Tow Package" type="checkbox" />--%>
                                                                    Tow Package</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures43" runat="server" />
                                                                    <%--<input name="features2" value="Tow Package" type="checkbox" />--%>
                                                                    Dashboard Wood frame</div>
                                                            </div>
                                                            <div>
                                                                <br />
                                                                <em><b>Specials</b></em>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures46" runat="server" />
                                                                    <%--<input name="features2" value="Alloy Wheels" type="checkbox" />--%>
                                                                    Garage Kept</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures47" runat="server" />
                                                                    <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                                    Non Smoking</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures48" runat="server" />
                                                                    <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                                    Records/Receipts Kept</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures49" runat="server" />
                                                                    <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                                    Well Maintained</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures50" runat="server" />
                                                                    <%--<input name="features2" value="Third Row Seats" type="checkbox" />--%>
                                                                    Regular oil changes</div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div class="clear">
                                                    &nbsp;</div>
                                                <br />
                                                <table class="wid100P padB6">
                                                    <tr>
                                                        <td colspan="5" style="height: 10px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="2">
                                                        </td>
                                                        <td style="width: 160px; padding-right: 10px; vertical-align: top">
                                                            Additional Selling Points
                                                        </td>
                                                        <td>
                                                            <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence"><span id="sellingPointCharCount">
                                                                1000</span> characters left</span><br />
                                                                <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Rows="8" cols="10"
                                                                    onchange="updateCharCount(this,'sellingPointCharCount');" onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                    class="textarea" MaxLength="1000"></asp:TextBox>
                                                            </span>
                                                        </td>
                                                        <td width="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                        </td>
                                                        <td>
                                                            <p>
                                                                Include information on additional equipment, how you have cared for the vehicle,
                                                                Kelley Blue Book value and anything else that will help sell your vehicle.<br />
                                                            </p>
                                                        </td>
                                                        <td width="5">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5">
                                                            <img src="images/spacer.gif" alt="" border="0" height="3" width="1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" style="height: 10px;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </div>
                                        <div class="clear">
                                        </div>
                                        <div class="searchResultsBox">
                                            <h3>
                                                Multi-site Listings</h3>
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
                                        <br />
                                        <asp:UpdatePanel ID="BtnSavePanel" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSaveCarDetails" runat="server" CssClass="g-button g-button-submit"
                                                    Text="Save & Proceed" Style="float: right; margin-right: 8px;" OnClientClick="return ValidateVehicleType();"
                                                    OnClick="btnSaveCarDetails_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- Vehicle Description  End  -->
                                    </div>
                                    <!-- Form End -->
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
                    Copyright © 2013 <a href="http://www.unitedcarexchange.com" target="_blank">unitedcarexchange.com</a>
                </div>
                <!-- Footer End  -->
            </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="BtnCls">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" OnClick="btnNo_Click1" />
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
            Alert
        </h4>
        <div class="data" style="height: 135px;">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertSave" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="btnAlertSaveOk" class="btn" runat="server" Text="Ok" OnClick="btnAlertSaveOk_Click" />
            </p>
        </div>
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

    <script type="text/javascript" language="javascript">


        var ad1 = ['images/ads/ads-l1.jpg', 'images/ads/ads-l2.jpg', 'images/ads/ads-l3.jpg'];
        $(function() {
            $("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");

            // Vertical Ticker



            $('.sample4').numeric();

            /*
            if(ad1.length>0){
            var img = '';
            var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
            img += "<img src='"+imgPath+"' />";
            $('#lBrandAds').empty();
            $('#lBrandAds').append(img);
            };
            */

            $('div.hed div.close').click(function() {
                $(this).toggleClass("open");
            });



        });

        function choice(e) {
            $('#div' + e).slideToggle();

        }
    </script>

    </form>
</body>
</html>
