<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealerCarBulkUpload.aspx.cs"
    Inherits="Dealer_DealerCarBulkUpload" %>

<%@ Register Src="Usercontrol/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..::UCE Dealers::..</title>
    <link href="css/maxx.css" rel="stylesheet" type="text/css" />
    <link href="css/buttons.css" rel="stylesheet" type="text/css" />

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>

    <script src="js/production.js" type="text/javascript"></script>

    <!-- Fancyform -->
    <link href="css/OverlibStyles.css" rel="stylesheet" type="text/css" />

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.mousewheel.js"></script>

    <script type="text/javascript" src="js/jquery.hotkeys.js"></script>

    <script type="text/javascript" src="js/jquery.fancyform.js"></script>

    <script src="Static/JS/JSDealers.js" type="text/javascript"></script>

    <script src="Static/JS/dataFill.js" type="text/javascript"></script>

    <script src="../js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        var page = 10;
        var actionNow;
        /*
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

            if (urlVars != null && urlVars != undefined && urlVars != '' && urlVars["C"] != undefined && urlVars["C"] != 'undefined' && urlVars["C"] != null && urlVars["C"] != '') {
                var valid = true;
                if (urlVars["C"]) {
                    actionNow = urlVars["C"];
                } else {
                    valid = false;
                }

                if (actionNow.length >= 1 && valid == true) {
                    ////console.log(actionNow)
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

            //GetMakes();
            //bindYears();
            //pageLoad();
            //GetModelsInfo();
            //GetModelsInfoByID('1');
            //GetDealerCars('Ford', 'Escape', '2009', 'Asc', '0', '3000', '1', '1', '', '', '1', '25');   // Handler for .ready() called.


            Swid = $('body').width() - (150);
            $(".gridHolder2").css({ width: Swid });

            $('.userPic').click(function() {
                var Sleft = $('.userPic').offset().left - ($('.logOutHolder').width()) + 15;
                var Stop = $('.userPic').offset().top + ($('.userPic').height()) + 10;

                $('.logOutHolder').css({ left: Sleft, top: Stop }).show();
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



            // Custom SelectBox
            /*
            $(".rightNav select").transformSelect();

            $('.rightNav .transformSelect ul').each(function() {
            if ($(this).children().length > 6) {
            $(this).height('160px').css({ 'overflow-y': 'scroll' });
            }
            });
            */
            hideSpinner();

            $('#fuAttachments').change(function () {
                var ext = this.value.match(/\.(.+)$/)[1];
                switch (ext) {
                    case 'xls':
                        $('#btnSubmit').attr('disabled', false);
                        break;
                    case 'xlsx':
                        $('#btnSubmit').attr('disabled', false);
                        break;
                    default:
                        alert('This is not an allowed file type.');
                        this.value = '';
                        $('#btnSubmit').attr('disabled', 'disabled');
                }
            });
            
            

        });

        $(window).resize(function() {
            Swid = $('body').width() - (150);
            $(".gridHolder2").css({ width: Swid });

            $('.logOutHolder').hide();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                                    <div class="rightNav">
                                        <table width="99%">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 120px">
                                                        <h3 style="padding-top: 5px;">
                                                            Bulk Upload</h3>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="devider1">
                                        &nbsp;</div>
                                    <!-- Details Start -->
                                    <div class="uploadCarForm" style="width: 99%;">
                                        <table style="width: 50%; margin: 0; padding: 0;">
                                            <tr>
                                                <td style="width: 160px; padding-top: 10px; vertical-align: top;">
                                                    Select File to Upload
                                                </td>
                                                <td style="padding-bottom: 12px;" id="searchFormHolder">
                                                    <asp:FileUpload ID="fuAttachments" runat="server" Style="width: 80%;" />
                                                    &nbsp;
                                                    <asp:LinkButton runat="server" ID="lnkRefQCText" Text="Help" onmouseover="return overlib1(document.getElementById('SalesUploadHelp').innerHTML,STICKY, MOUSEOFF, CENTER, ABOVE,OFFSETX,30,  WIDTH, 260,  CSSCLASS,TEXTFONTCLASS,'summaryfontClass',FGCLASS,'summaryfgClass',BGCLASS,'summarybgClass',CAPTIONFONTCLASS,'summarycapfontClass', CLOSEFONTCLASS, 'summarycapfontClass');"
                                                        onmouseout="return nd1(4000);" Font-Size="11px" Style="width: 200px"></asp:LinkButton>
                                                    <br />
                                                    <small style="color: #777"><i>( Max 5000 records can upload )</i></small>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 10px; vertical-align: top">
                                                    Enter No of Records
                                                </td>
                                                <td style="height: 10px;">
                                                    <asp:TextBox ID="txtRecordCount" runat="server"></asp:TextBox>
                                                    <asp:Label ID="lblErrorMsg" runat="server" Style="color: red; display: inline-block;
                                                        line-height: 30px;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px;">
                                                    &nbsp;
                                                </td>
                                                <td style="padding-top: 7px;">
                                                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" class="g-button left" OnClick="btnSubmit_Click"
                                                        Enabled="false" />
                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" Enabled="false" class="g-button left"
                                                        OnClick="btnUpload_Click" Style="margin-left: 6px;" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="margin: 0; padding: 0;">
                                            <tr>
                                                <td colspan="2">
                                                    <div class="proDet1" style="margin-top: 10px; display: none" runat="server" id="recGrid">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <div class="gridHolder2" style="width: 100%; overflow-y: hidden; overflow-x: scroll;
                                                                        padding: 3px; border: #ccc 1px solid;">
                                                                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                                                                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                                                                <ContentTemplate>
                                                                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <asp:GridView Width="675px" ID="grdIntroInfo" CssClass="grid1" runat="server" CellSpacing="0"
                                                                                        CellPadding="0" AutoGenerateColumns="False" GridLines="Both">
                                                                                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerSettings Position="Top" />
                                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                                        <HeaderStyle CssClass="headder" />
                                                                                        <PagerSettings Position="Top" />
                                                                                        <RowStyle CssClass="row1" />
                                                                                        <AlternatingRowStyle CssClass="row2" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="DealerUniqueID">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDealerUniqueID" runat="server" Text='<%# Eval("DealerUniqueID")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Make">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblMake" runat="server" Text='<%# Bind("Make") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Model">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblModel" runat="server" Text='<%# Bind("Model") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="11%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Price">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Year">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblyear" runat="server" Text='<%# Eval("year")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Description">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# GenFunc.WrapTextByMaxCharacters(Eval("Description"),30)%>'></asp:Label>
                                                                                                    <asp:HiddenField ID="hdnDescription" runat="server" Value='<%# Eval("Description")%>'>
                                                                                                    </asp:HiddenField>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Mileage">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblMileage" runat="server" Text='<%# Eval("Mileage")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="BodyStyle">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="BodyType" runat="server" Text='<%# Eval("BodyStyle")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Exterior Color">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblExteriorColor" runat="server" Text='<%# Eval("ExteriorColor")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Interior Color">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblInteriorColor" runat="server" Text='<%# Eval("InteriorColor")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="VIN">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblVIN" runat="server" Text='<%# Eval("VIN")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="FuelType">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblFuelType" runat="server" Text='<%# Eval("FuelType")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="NumberOfCylinder">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblNumberOfCylinder" runat="server" Text='<%# Eval("NumberOfCylinder")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Transmission">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblTransmission" runat="server" Text='<%# Eval("Transmission")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="WheelBase">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblWheelbase" runat="server" Text='<%# Eval("Wheelbase")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Doors">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDoors" runat="server" Text='<%# Eval("Doors")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Drive Train">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDrivetrain" runat="server" Text='<%# Eval("Drivetrain")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="VehicleCondition">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblVehicleCondition" runat="server"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ConditionDescription">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblConditionDescription" runat="server" Text='<%# Eval("ConditionDescription")%>'></asp:Label>
                                                                                                    <asp:HiddenField ID="hndDealerUniqueID" runat="server" Value='<%# Eval("DealerUniqueID")%>'>
                                                                                                    </asp:HiddenField>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                        <asp:GridView ID="grdErrors" runat="server" CellPadding="0" TabIndex="8" CssClass="grid1"
                                                                            Width="99%" GridLines="Both" AutoGenerateColumns="False">
                                                                            <HeaderStyle CssClass="headder" />
                                                                            <PagerSettings Position="Top" />
                                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                            <RowStyle CssClass="row1" />
                                                                            <AlternatingRowStyle CssClass="row2" />
                                                                            <Columns>
                                                                                <asp:BoundField DataField="RowNo" HeaderText="RowNo" HeaderStyle-ForeColor="black"
                                                                                    HtmlEncode="False" meta:resourcekey="RowNo" SortExpression="RowNo">
                                                                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="DealerUniqueID" HeaderText="DealerUniqueID" HeaderStyle-ForeColor="black"
                                                                                    HtmlEncode="False">
                                                                                    <ItemStyle Width="10%" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Error" HeaderText="Error" HeaderStyle-ForeColor="black"
                                                                                    HtmlEncode="False" meta:resourcekey="Error" SortExpression="Error">
                                                                                    <ItemStyle Width="50%" HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="clear" style="height: 12px;">
                                                                        &nbsp;</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <!-- Details End -->
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
    <div id="SalesUploadHelp" style="display: none; background-color: #fff">
        <div class="QCTextTitle">
            Help
        </div>
        <div class="QCReferenceText">
            File Format Accepted: .xls
        </div>
        <div class="QCReferenceText">
            (Microsoft Office Excel 97-2003 Worksheet)
        </div>
        <div class="QCReferenceText">
            <a href="../Dealer/DealerFiles/DealerCarUpload.xls" target="_blank" class="link">Download
                Sample Sales File</a>
        </div>
    </div>
    </form>
</body>
</html>
