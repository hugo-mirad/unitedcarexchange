<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarDetails.aspx.cs" Inherits="CarDetails"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register Src="UserControl/HeadderBlogin.ascx" TagName="HeadderBlogin" TagPrefix="uc2" %>
<!doctype html>
<html xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="shortcut icon" href="#">
    <link rel="stylesheet" type="text/css" href="assets/css/bootstrap.min.css" media="screen, projection">
    <link rel="stylesheet" type="text/css" href="libraries/chosen/chosen.min.css" media="screen, projection">
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

    <link href="cssOld/production.css" rel="stylesheet" type="text/css" />
    <title>Packages</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script src="js/carDetails.js" type="text/javascript"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>



    <style>
        .detPrice {
            color: #f95446;
        }
        .proDet h3{
            margin-top:40px;
        }
        .grid1 a {
            font-weight:normal
        }
    </style>
    <script type="text/javascript">
        var CarID1;
        function pageLoad() {
            productionFindCarID($('#hdvdicarid').val());
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdvdicarid" Value="" runat="server"/>
        <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
        </cc1:ToolkitScriptManager>


        <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />

        <asp:HiddenField ID="hdnSubAlert" runat="server" Value="true" />

        <div id="content" class="pricing-page">
            <div id="page-heading">
                <div class="container">
                    <div class="row">
                        <div class="col-md-8">
                            <div class="heading">
                                <div class="title">
                                    <h1>
                                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                                        <span class=" semi ">Member since: <b>
                                            <asp:Label ID="lblUserMemberDate" runat="server">
                                                    </asp:Label></b></span></h1>
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
                                <div class="pricing account " style="margin-bottom: 20px;">
                                    <div class="row ">
                                        <div class="page-header " style="margin-left: 15px;">
                                            <div class="page-header-inner">
                                                <div class="heading">
                                                    <h2 class="Title" style="border-bottom:none; padding-bottom:0;" ></h2>
                                                </div>
                                                <!-- /.heading -->
                                                <div class="line">
                                                    <hr>
                                                </div>
                                                <!-- /.line -->
                                            </div>
                                            <!-- /.page-header-inner -->
                                        </div>
                                        <!-- My Cars Start  -->


                                        <div class="col-sm-12 col-md-12 block-margin">
                                            <div class="pricing-package block block-shadow white account">
                                                <div class="block-inner" style="padding:25px;" >

                                                    <div class=" row ">
                                                        <div class="col-sm-12 ">

                                                            <div class="proDet">
                                                                <div class="detailsDiv">

                                                                    <strong>Car ID: </strong>
                                                                    <label class="carID">
                                                                    </label>
                                                                    <br />
                                                                    <strong>Name: </strong>
                                                                    <label class="name">
                                                                    </label>
                                                                    <br />
                                                                    <strong>Email: </strong>
                                                                    <label class="email">
                                                                    </label>
                                                                    <br />
                                                                    <strong>City & State: </strong>
                                                                    <label class="city">
                                                                    </label>
                                                                    <br />
                                                                    <strong>Phone: </strong>
                                                                    <label class="phone2">
                                                                    </label>
                                                                    <br />
                                                                    <strong>URL: </strong>
                                                                    <a href="" class="url" target="_blank"></a>

                                                                    <br />
                                                                    <a href="#" class="link1" style="display: none;">copy</a>

                                                                    <div class="disc" style="width: 100%;">
                                                                    </div>
                                                                    <div class="SellerNotes">
                                                                    </div>
                                                                    <div class="imgHolder" style="">
                                                                        <ul>
                                                                        </ul>
                                                                        <div class="clear">
                                                                            &nbsp;
                                                                        </div>
                                                                        <br />
                                                                        <br />
                                                                    </div>
                                                                </div>


                                                                <h3 class="h33">Multi-site Listings: </h3>

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
                                                            </div>

                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>


                                        <!-- My Cars End  -->
                                    </div>
                                </div>
                                <!-- /.row -->








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

        <script src="js/jslider/jquery.slider.min.js"></script>

        <script src="libraries/ezMark/js/jquery.ezmark.js"></script>

        <script type="text/javascript" src="libraries/flot/jquery.flot.js"></script>

        <script type="text/javascript" src="libraries/flot/jquery.flot.canvas.js"></script>

        <script type="text/javascript" src="libraries/flot/jquery.flot.resize.js"></script>

        <script type="text/javascript" src="libraries/flot/jquery.flot.time.js"></script>

        <script src="http://maps.googleapis
    
    
    
    
    /maps/api/js?sensor=true&amp;v=3.13"></script>

        <script src="assets/js/carat.js"></script>


        <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>
        <script type="text/javascript" src="js/jquery.vticker.js"></script>

        <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>













    </form>
</body>
</html>
