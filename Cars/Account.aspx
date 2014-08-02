<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>

<%@ Register src="UserControl/HeadderBlogin.ascx" tagname="HeadderBlogin" tagprefix="uc2" %>
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
    <title>Packages</title>

    <script src="assets/js/jquery.js"></script>

    <script src="assets/js/jquery-migrate-1.2.1.js"></script>

    <script src="assets/js/jquery.ui.js"></script>

    <script src="assets/js/bootstrap.js"></script>

    <script src="assets/js/cycle.js"></script>

    <script>
        var LoadingPage = 10;
    </script>


    <style>

        .btn, .btn-primary, .pricing-page .pricing .pricing-package .action-button a, .pricing-page .pricing .pricing-package .action-button input {
            padding:5px 15px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
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
                                     <asp:Label ID="lblUserName" runat="server"></asp:Label> <span class=" semi ">Member since: <b> <asp:Label ID="lblUserMemberDate" runat="server" >
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
                                                <h2>
                                                    My Cars</h2>
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
                                    <asp:Repeater ID="RepDetails" runat="server" OnItemDataBound="RepDetails_ItemDataBound" OnItemCommand="RepDetails_ItemCommand">
                                        <ItemTemplate>
                                       
                                    <div class="col-sm-6 col-md-6 block-margin">
                                        <div class="pricing-package block block-shadow white account">
                                            <div class="block-inner">
                                                <div class="title">
                                                    <h2>
                                                        <asp:Label ID="mkmodel" runat="server" Text='<%# Eval("make") +" "+ Eval("model") %>' /></h2>
                                                </div>
                                                <div class=" row ">
                                                    <div class="col-sm-12 col-md-4">
                                                        <asp:Image ID="ImageName" runat="server" />
                                                    </div>
                                                    <div class="col-sm-12 col-md-8">
                                                        <table>
                                                            <tr>
                                                                <td class="property" style="width: 55px;">
                                                                    Year
                                                                </td>
                                                                <td class="value">
                                                                    <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("yearofmake") %>' />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="property">
                                                                    Price
                                                                </td>
                                                                <td class="value">
                                                                    <asp:Label ID="lblComment" runat="server" Text='<%#Eval("price") %>' />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="property">
                                                                    URL
                                                                </td>
                                                                <td class="value">    
                                                                
                                                              
                                                                    <a href="usedcars/<%#Eval("yearofmake") %>-<%#Eval("make") %>-<%#Eval("model") %>-<%#Eval("CaruniqueId") %>" target="_blank" >MobiCarz Link</a>
                                                                    <asp:LinkButton ID="lnkurl" runat="server" style=" display:none "  />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="property">
                                                                </td>
                                                                <td class="value">
                                                                    <div class="action-button" style="text-align: left">
                                                                       <span style=" display:none; "><%# Eval("carid")%></span>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server"  CssClass="btn btn-primary caredit btn-ssm" Text="View"  CommandArgument='<%#Eval("carid") + ";" +Eval("postingid")%>' CommandName="Viewcar"  />
                                                                        <asp:LinkButton ID="Linkcarid" runat="server"  CssClass="btn btn-primary caredit btn-ssm" Text="Edit" CommandArgument='<%# Eval("postingID")%>' CommandName="EditCar"    />
                                                                        <asp:LinkButton ID="lnkReviews" runat="server"  CssClass="btn btn-primary caredit btn-ssm" Text="Reviews" CommandArgument='<%# Eval("CaruniqueId")%>' CommandName="Reviews"    />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                     </ItemTemplate>
                                    </asp:Repeater>
                                    
                                    <!-- My Cars End  -->
                                </div>
                            </div>
                            <!-- /.row -->
                            
                            
                            
                            <!-- Package Details Start  -->
                            <div class="row ">
                                <div class="page-header " style="margin-left: 15px;">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Package Details</h2>
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
                                    <div class="block block-shadow white ">
                                        <div class="block-inner">
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
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left"  />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                            <asp:HiddenField ID="hdnPackDescrip" runat="server" Value='<%# Eval("Description")%>' />
                                                            <asp:HiddenField ID="hdnUserPackID" runat="server" Value='<%# Eval("UserPackID")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left"  />
                                                        <HeaderStyle HorizontalAlign="Left" />
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
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                           
                            <!--  Package Details End /.row -->
                            
                            
                            
                            <!-- Manage Account Details Start  -->
                            <div class="row ">
                                <div class="page-header " style="margin-left: 15px;">
                                    <div class="page-header-inner">
                                        <div class="heading">
                                            <h2>
                                                Manage Account Details</h2>
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
                                    <div class="block block-shadow white ">
                                        <div class="block-inner">
                                            <!-- My Details Start  -->
                                            <asp:UpdatePanel ID="updtPnlSearchResultBox" runat="server">
                                                <ContentTemplate>
                                                    <div class="searchResultsBox activeBox">
                                                        <h3>
                                                            Registrant Details
                                                        </h3>
                                                        <asp:Button ID="btnChangePwd" runat="server" CssClass="btn btn-danger" Text="Change Password"
                                                            Style="float: right; margin-left: 8px;" OnClientClick="return ShowPW();" />
                                                        <asp:Button ID="btnEditDetails" runat="server" CssClass="btn btn-warning" Style="float: right;"
                                                            Text="Edit Details" OnClick="btnEditDetails_Click" />
                                                        <asp:Button ID="btnUpdateDetails" runat="server" CssClass="btn btn-warning" Style="float: right;"
                                                            Visible="false" Text="Update Details" OnClick="btnUpdateDetails_Click" OnClientClick="return ValidateVehicleType();" />
                                                        <table id="tbl1LblsDisplay" class="table" runat="server" style="display: block">
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
                                                        
                                                        
                                                       
                                                        
                                                        
                                                        
                                                        
                                                        <div class="row" id="tbl2textDisplay" runat="server" style="display: none; width: 100%;">
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Name</label> 
                                                                    <div id="divtxtRegName" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtregName" runat="server" CssClass="form-control"  MaxLength="25"></asp:TextBox>
                                                                    </div>                                                                 
                                                                </div>                                                        
                                                            </div>
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Company Name</label> 
                                                                     <asp:TextBox ID="txtBusinessName" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>                                                                  
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Email</label>  
                                                                     <asp:Label ID="lblRegEmail" CssClass="form-control" runat="server"></asp:Label>                                                                
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Alt Email</label> 
                                                                    <asp:TextBox ID="txtAltEmail" CssClass="form-control" runat="server" MaxLength="30"></asp:TextBox>                                                                 
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Phone</label>  
                                                                     <div id="divtxtRegPhone" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtRegPhone" CssClass="form-control" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"
                                                                            Enabled="false"></asp:TextBox>
                                                                    </div>                                                              
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Alt Phone</label>  
                                                                    <asp:TextBox ID="txtAltPhone" runat="server"  CssClass="form-control" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>                                                                
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>Address</label>  
                                                                    <div id="divlblRegAddress" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divtxtRegAddress" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtRegAddress" CssClass="form-control" runat="server" MaxLength="40"></asp:TextBox>
                                                                    </div>
                                                                                                                                   
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            
                                                            <div class="col-sm-6 col-md-5">
                                                                <div class="form-group ">
                                                                    <label>City</label>  
                                                                    <div id="divlblRegCity" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divtxtRegCity" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtRegCity" CssClass="form-control" runat="server" MaxLength="20"></asp:TextBox>
                                                                    </div>
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-3 col-md-3">
                                                                <div class="form-group ">
                                                                    <label>State</label>  
                                                                    <div id="divlblRegState" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divddlRegState" runat="server" style="display: none">
                                                                        <asp:DropDownList ID="ddlLocationState" CssClass="form-control" runat="server" Width="110px">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>                                                        
                                                            </div>
                                                            
                                                            <div class="col-sm-3 col-md-2">
                                                                <div class="form-group ">
                                                                    <label>ZIP</label>  
                                                                    <div id="divlblRegZip" runat="server" style="display: block">
                                                                    </div>
                                                                    <div id="divtxtRegZip" runat="server" style="display: none">
                                                                        <asp:TextBox ID="txtRegZip" CssClass="form-control" runat="server" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                                    </div>
                                                                </div>                                                        
                                                            </div>
                                                       </div>
                                                        
                                                        
                                                        
                                                        <div class="clear">
                                                            &nbsp;</div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <!-- My Details End  -->
                                            <table>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Manage Account Details End  /.row -->
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
    
    
    
    

    <cc1:ModalPopupExtender ID="mpeChangePW" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none; " class="alert" >
    
        <h4 id="H3">
            Change Password
            <asp:Button ID="BtnClsChPw" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        
         <div class="data">
                <div class="row" >
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                            <label >User Name</label>                            
                           
                            <asp:UpdatePanel ID="uplPW" runat="server" >
                                    <ContentTemplate>                                       
                                        <asp:Label ID="lblUnamePW" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            
                        </div>                                                        
                    </div>
                    
                     <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                            <label>New Password<span class="star">*</span></label> 
                            <asp:TextBox ID="txtNewPW" TextMode="Password" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                    </div>
                    
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                            <label>Confirm New Password<span class="star">*</span></label> 
                            <asp:TextBox ID="txtConfirmPW" MaxLength="20" TextMode="Password" CssClass="form-control"
                                    runat="server"></asp:TextBox>
                         </div>
                    </div>
                    
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                           
                            <div style=" width:100px; display:inline-block; float:right; text-align:right; " >
                            <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnChangePW" class="btn btn-danger"  runat="server" Text="Change" OnClientClick="return ValidateChangePW();"
                                                OnClick="btnChangePW_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                         </div>
                        
                        <asp:Button ID="btnCancelPW" class="btn btn-default"  runat="server" Text="Cancel" style=" float:right; " />
                         </div>
                    </div>
                    
                    
                    
                   
                    
                
                </div>
         </div>
        
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
                To add a new package please contact our customer support #:888-465-6693
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
    <div id="divSelectPackage" style="display: none;  width: 400px"  class="alert"  >
    
    
    <h4 id="H4">
            Select Package
            <asp:Button ID="BtnClsSelPack" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
    
    
         <div class="data">
                <div class="row" >
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                            <label >User Name</label>  
                             <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblUserAddPack" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>                       
                        </div>                                                        
                    </div>
                    
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                            <label >Select a package<span class="star">*</span></label>  
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlSelPack" runat="server" CssClass="input3">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>                      
                        </div>                                                        
                    </div>
                    
                    <div class="col-sm-12 col-md-12">
                        <div class="form-group ">
                           
                            <div style=" width:100px; display:inline-block; float:right; text-align:right; " >
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnGoSelPack" class="btn btn-default" runat="server" Text="Select" OnClientClick="return ValidateSelPack();"
                                                OnClick="btnGoSelPack_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                         </div>
                        
                        
                         <asp:Button ID="btnCancelSelPack" class="btn btn-default" runat="server" Text="Cancel" style=" float:right; "  />
                         </div>
                    </div>
                    
                    
                    
                    
                                   
                    
                    
              </div>
         </div>
                    
    
        
    </div>
   
   
   
   
   
   
   
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




        $(function() {
            $('.caredit').click(function() {
                $('#spinner').show();
            })
        })
        
        

    </script>
   
   
    </form>
</body>
</html>
