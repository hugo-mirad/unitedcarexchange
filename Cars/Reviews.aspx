<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="Reviews"
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
    <link rel="stylesheet" type="text/css" href="js/jslider/jquery.slider.min.css" media="screen, projection">
    
     <link href="cssOld/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" href="assets/css/carat.css" media="screen, projection">
    <link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:100,400,700,400italic,700italic"
        rel="stylesheet" type="text/css" media="screen, projection">
    <title>Packages</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script>
        var LoadingPage = 10;
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <uc2:HeadderBlogin ID="HeadderBlogin1" runat="server" />
    <div id="content" class="pricing-page">
        <div id="page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-md-8">
                        <div class="heading">
                            <div class="title">
                                <h1>
                                    <asp:Label ID="lblUserName" runat="server"></asp:Label>
                                    <span class=" semi "><asp:Label ID="labcardeta" runat="server"></asp:Label> <b>
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
                            <!-- Reviews Start -->
                            <div class="row">
                                <div class="page-header " style="margin-left: 15px;">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Reviews</h2>
                                        </div>
                                        <!-- /.heading -->
                                        <div class="line">
                                            <hr>
                                        </div>
                                        <!-- /.line -->
                                    </div>
                                    <!-- /.page-header-inner -->
                                </div>
                                <div class="col-sm-12 col-md-12 block-margin">
                                    <!-- Tab Start  -->
                                    <div id="tabs">
                                        <ul>
                                            <li><a href="#tabs-1">New / Published</a></li>
                                            <li><a href="#tabs-2">Deleted</a></li>
                                        </ul>
                                        <div id="tabs-1">
                                            <h3>
                                                New Reviews</h3>
                                            <div class="newQuest">
                                                <ul>
                                                    <asp:Repeater runat="server" ID="rpt1" OnItemDataBound="rpt1_ItemDataBound" OnItemCommand="rpt1_ItemCommand">
                                                        <ItemTemplate>
                                                            <li>
                                                                <div class="date">
                                                                    Posted on<span class="glyphicon glyphicon-calendar"></span><asp:Label ID="lblpostdate"
                                                                        runat="server"></asp:Label></div>
                                                                <asp:Label ID="NewQuestion" CssClass="quest" runat="server" TextAlign="Right" ForeColor="#D9534F" />
                                                                <div class="action">
                                                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-default btn-xs" CommandName="Delete"
                                                                        CommandArgument='<%# Eval("DiscussQid") %>'><span class="glyphicon glyphicon-remove"></span>Delete</asp:LinkButton>
                                                                    <asp:LinkButton ID="btnApprove" runat="server" CssClass="btn btn-default btn-xs"
                                                                        CommandName="Answer" CommandArgument='<%# Eval("DiscussQid") %>'><span class="glyphicon glyphicon-pencil"></span>Answer</asp:LinkButton>
                                                                </div>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                            <h3>
                                                Published Reviews</h3>
                                            <div class="published">
                                                <ul>
                                                    <asp:Repeater runat="server" ID="rptpublDisc" OnItemDataBound="rptpublDisc_ItemDataBound"
                                                        OnItemCommand="rptpublDisc_ItemCommand">
                                                        <ItemTemplate>
                                                            <li>
                                                                <div class="date">
                                                                    Posted on<span class="glyphicon glyphicon-calendar"></span><asp:Label ID="lblPublishpostdate"
                                                                        runat="server"></asp:Label></div>
                                                                <asp:Label ID="NewPubQuestion" CssClass="head" runat="server" TextAlign="Right" />
                                                                <asp:Label ID="NewPubAnswe" runat="server" TextAlign="Right" />
                                                                <div class="action">
                                                                    <asp:LinkButton ID="btnPubDelete" runat="server" CssClass="btn btn-default btn-xs"
                                                                        CommandName="PubDelete" CommandArgument='<%# Eval("DiscussQid") %>'><span class="glyphicon glyphicon-remove"></span>Delete</asp:LinkButton>
                                                                </div>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                        <div id="tabs-2">
                                            <div class="published">
                                                <ul>
                                                    <asp:Repeater runat="server" ID="rptDeleted" OnItemDataBound="rptDeleted_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <div class="date">
                                                                    Deleted on<span class="glyphicon glyphicon-calendar"></span>
                                                                    <asp:Label ID="lbldeletedpostdate" runat="server"></asp:Label></div>
                                                                <asp:Label ID="NewdeleteQuestion" CssClass="head" runat="server" TextAlign="Right" />
                                                                <asp:Label ID="NewdeleteAnswe" runat="server" TextAlign="Right" />
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- Tab End  -->
                                    <div class="clear">
                                        &nbsp;</div>
                                </div>
                            </div>
                            <!-- Reviews End -->
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
    
    <!-- Alerts Start  -->
    <cc1:ModalPopupExtender ID="MdlAnswer" runat="server" PopupControlID="divSelectPackage"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAnswer" CancelControlID="btnCancelSelPack">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAnswer" runat="server" />
    <div id="divSelectPackage" style="display: none; width: 550px" class="alert">
        <h4 id="H1">
            Question
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
        </h4>
        <div class="data">
            <table style="width: 99%; margin: 0 auto;">
                <tr>
                    <td style="width: 120px;">
                        <asp:Label ID="lblQuestAn" CssClass="quest" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                      
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="lblanswerQyes" runat="server" cssClass="form-control" TextMode="MultiLine" Style="height: 70px;"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px 0; text-align: center">
                        <div style="display: inline-block">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnpublish" CssClass="btn btn-danger btn-sm" runat="server" Text="Pubish"
                                        OnClick="btnpublish_click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <asp:Button ID="btnCancelSelPack" CssClass="btn btn-warning btn-sm" runat="server"
                            Text="Cancel" />
                    </td>
                </tr>
            </table>
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

    <script type="text/javascript" src="js/jquery.vticker.js"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/jquery-ui.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function() {
            $("#tabs").tabs();
        });
    </script>

    </form>
</body>
</html>
