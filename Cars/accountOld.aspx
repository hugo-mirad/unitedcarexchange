we<%@ Page Language="C#" AutoEventWireup="true" CodeFile="accountOld.aspx.cs" Inherits="account" %>

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

    <script type="text/javascript" language="javascript">
      function isNumberKey(evt)
         {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
            
     function ValidateChangePW()
        {
        
            var valid=true;     
            
              if (document.getElementById('<%=txtNewPW.ClientID%>').value.length <1 )
            {
                alert('Please enter new password')
                valid=false;
              document.getElementById('<%=txtNewPW.ClientID%>').value = ""
               document.getElementById('<%=txtNewPW.ClientID%>').focus()
                return valid;
            }
            
             else if (document.getElementById('<%=txtConfirmPW.ClientID%>').value.length <1 )
            {
                alert('Please enter confirm password')
                valid=false;
              document.getElementById('<%=txtConfirmPW.ClientID%>').value = ""
               document.getElementById('<%=txtConfirmPW.ClientID%>').focus()
                return valid;
            }
              else if( document.getElementById('<%=txtNewPW.ClientID%>').value != document.getElementById('<%=txtConfirmPW.ClientID%>').value)
             {
                document.getElementById('<%= txtConfirmPW.ClientID%>').focus();
                alert("New password does not match the confirm password");
                 document.getElementById('<%=txtConfirmPW.ClientID%>').value = ""
                document.getElementById('<%=txtConfirmPW.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }          
          
                 
            return valid;
        }
    
     function ValidateVehicleType()
        {      
            var valid=true;             
            
             if ((document.getElementById('<%=txtAltEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtAltEmail.ClientID%>').value) == false) )
             {
               
                document.getElementById('<%=txtAltEmail.ClientID%>').value = ""
                document.getElementById('<%=txtAltEmail.ClientID%>').focus()
                valid = false;
                return valid;
           
            }
            
             if( (document.getElementById('<%=txtRegZip.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtRegZip.ClientID%>').value.length < 4 ))
             {
                document.getElementById('<%= txtRegZip.ClientID%>').focus();
                alert("Please enter valid zipcode");
                 document.getElementById('<%=txtRegZip.ClientID%>').value = ""
                document.getElementById('<%=txtRegZip.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }           
             if( (document.getElementById('<%=txtRegPhone.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtRegPhone.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtRegPhone.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtRegPhone.ClientID%>').value = ""
                document.getElementById('<%=txtRegPhone.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }   
             
              else if( (document.getElementById('<%=txtAltPhone.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtAltPhone.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtAltPhone.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtAltPhone.ClientID%>').value = ""
                document.getElementById('<%=txtAltPhone.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }       
                 
            return valid;
        }
        
           function ShowPW() {            
            document.getElementById('<%= txtNewPW.ClientID%>').value = "";
            document.getElementById('<%= txtConfirmPW.ClientID%>').value = "";   
            $find('<%= mpeChangePW.ClientID%>').show();                     
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
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                    <div class="loginStat">
                        <%-- Welcome &nbsp;&nbsp;<asp:Label ID="lblUserName" runat="server"></asp:Label>
                        <asp:LinkButton ID="lnkBtnLogout" runat="server" CssClass="login" Text="Logout" OnClick="lnkBtnLogout_Click"></asp:LinkButton>--%>
                        <%-- <a href="login.aspx" class="login">Login</a>--%>
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
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                        <div>
                                            <a class="adHeadline" target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2100989&afsid=1">
                                                Your Ad Here</a></div>
                                        <!-- End: adBrite -->
                                    </div>
                                    <div class="clear">
                                        &nbsp;</div>
                                    <!-- Left Brand Ads End -->
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
                                        <div class="clear">
                                            &nbsp;</div>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1 photoUpload" style="border-top: #ccc 1px solid;
                                            padding: 10px 0; margin: 0;">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 140px; padding-right: 10px;">
                                                        <!-- Car Info Start -->
                                                        <asp:UpdatePanel ID="updtpnlButtons" runat="server">
                                                            <ContentTemplate>
                                                                <table style="width: 99%;">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnDelete" runat="server" CssClass="button1" Text="Delete" Style="float: right;
                                                                                margin-left: 8px;" Visible="false" />
                                                                            <asp:Button ID="btnActive" runat="server" CssClass="button1" Text="Active" Style="float: right;
                                                                                margin-left: 8px;" Visible="false" OnClick="btnActive_Click" />
                                                                            <asp:Button ID="btnSold" runat="server" CssClass="button1" Text="Sold" Style="float: right;
                                                                                margin-left: 8px;" Visible="false" OnClick="btnSold_Click" />
                                                                            <asp:Button ID="btnWithdraw" runat="server" CssClass="button1" Text="Withdraw" Style="float: right;
                                                                                margin-left: 8px;" Visible="false" OnClick="btnWithdraw_Click" />
                                                                            <asp:Button ID="btnEdit" runat="server" Text="Edit Listing" CssClass="button1" Style="float: right;"
                                                                                Visible="false" OnClick="btnEdit_Click" />
                                                                            <asp:Button ID="btnAdd" runat="server" Text="Add Listing" CssClass="button1" Style="float: right;"
                                                                                Visible="false" OnClick="btnAdd_Click" />
                                                                            <%-- <input type="button" value="Delete" class="button1" style="float: right; margin-left: 8px;" />
                                                                    <input type="button" value="Deactive" class="button1" style="float: right; margin-left: 8px;" />
                                                                    <input type="button" value="Edit" class="button1" style="float: right;" />--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <div class="searchResultsBox" id="divSrchResBox" runat="server">
                                                            <h3>
                                                                Ad Preview
                                                            </h3>
                                                            <table style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 90px; vertical-align: top; position: relative; z-index: 10;" class="searchCarThumbHolder">
                                                                            <asp:Image ID="ImageName" runat="server" CssClass="thumb" Width="120" Height="73" />
                                                                            <div class="stock3" id="divAdStock" runat="server">
                                                                                Stock Photo</div>
                                                                        </td>
                                                                        <td class="searchcarDetails" style="vertical-align: top; font-weight: normal">
                                                                            <h4>
                                                                                <a href="javascript:void(0);">
                                                                                    <asp:Label ID="lblTitle" runat="server" CssClass="carName"></asp:Label><br />
                                                                                    <asp:Label ID="lblCarName" runat="server" CssClass="carName"></asp:Label></a>
                                                                            </h4>
                                                                            <p style="font-weight: normal">
                                                                                <strong>Description: </strong>
                                                                                <asp:Label ID="lblDescrip" runat="server"></asp:Label></p>
                                                                        </td>
                                                                        <td class="SearchResultsArrayBox3" style="vertical-align: top; width: 170px;">
                                                                            <table style="width: 100%" class="subInfo searchCarCheckBox" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr class="subInfoHed">
                                                                                        <td>
                                                                                            <strong>Mileage</strong>
                                                                                        </td>
                                                                                        <td>
                                                                                            <strong>Price</strong>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr class="subInfo">
                                                                                        <td>
                                                                                            <%--<label class="mileage">
                                                                                                22,301</label>--%>
                                                                                            <asp:Label ID="lbladmilleage" CssClass="mileage" runat="server"></asp:Label>
                                                                                            <asp:Label ID="lblMi" Text="mi" runat="server" Visible="false"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lbladPrice" CssClass="price" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr class="subInfoHed">
                                                                                        <td>
                                                                                            <strong>Body</strong>
                                                                                        </td>
                                                                                        <td>
                                                                                            <strong>Fuel</strong>
                                                                                        </td>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr class="last">
                                                                                        <td>
                                                                                            <asp:Label ID="lblAdBody" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Label ID="lblAdFuel" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td align="center">
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </div>
                                                        <!-- Car Info End -->
                                                        <!-- My Details Start  -->
                                                        <asp:UpdatePanel ID="updtPnlSearchResultBox" runat="server">
                                                            <ContentTemplate>
                                                                <div class="searchResultsBox">
                                                                    <h3>
                                                                        Registrant Details
                                                                        <%--<input type="button" value="Change Password" class="button1" style="float: right;
                                                                            margin-left: 8px;" />--%>
                                                                        <asp:Button ID="btnChangePwd" runat="server" CssClass="button1" Text="Change Password"
                                                                            Style="float: right; margin-left: 8px;" OnClientClick="return ShowPW();" />
                                                                        <asp:Button ID="btnEditDetails" runat="server" CssClass="button1" Style="float: right;"
                                                                            Text="Edit Details" OnClick="btnEditDetails_Click" />
                                                                        <asp:Button ID="btnUpdateDetails" runat="server" CssClass="button1" Style="float: right;"
                                                                            Visible="false" Text="Update Details" OnClick="btnUpdateDetails_Click" OnClientClick="return ValidateVehicleType();" />
                                                                        <%--<input type="button" value="Edit Details" class="button1" style="float: right;" />--%></h3>
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
                                                                                <b>Buss Name:</b>
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
                                                                    <table id="tbl2textDisplay" runat="server" style="display: none; width: 600px;">
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
                                                                                <b>Buss Name:</b>
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
                                                                                    <asp:DropDownList ID="ddlLocationState" runat="server">
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
                                                                                    <asp:TextBox ID="txtRegZip" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"></asp:TextBox>
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
                                                        <div class="searchResultsBox">
                                                            <h3>
                                                                Package Details</h3>
                                                            <table class="VisitsTable" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <th scope="col">
                                                                        Package
                                                                    </th>
                                                                    <th scope="col">
                                                                        Photos Uploaded
                                                                    </th>
                                                                    <th scope="col">
                                                                        Max Photos
                                                                    </th>
                                                                    <th scope="col">
                                                                        Ad Active From
                                                                    </th>
                                                                    <th scope="col">
                                                                        <%--Remaining Period--%>
                                                                        Expiry Date
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblPackDescrip" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblPhotoUploaded" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblMaxPhotos" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblAdActiveFrom" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRemainingPeriod" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </div>
                                                        <!-- Package Info End -->
                                                        <!-- Visits Start -->
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
                                                        <div class="searchResultsBox" id="divNoOfViews" runat="server">
                                                            <h3>
                                                                Traffic Report</h3>
                                                            <div style="font-size: 14px; color: #999; text-align: center; padding: 10px 0 20px 0;
                                                                font-weight: bold">
                                                                Not yet available..!</div>
                                                            <table class="VisitsTable" cellpadding="0" cellspacing="0" style="display: none;">
                                                                <tr>
                                                                    <th scope="col">
                                                                        Today
                                                                    </th>
                                                                    <th scope="col">
                                                                        This Week
                                                                    </th>
                                                                    <th scope="col">
                                                                        This Month
                                                                    </th>
                                                                    <th scope="col">
                                                                        Total Visits
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        6
                                                                    </td>
                                                                    <td>
                                                                        18
                                                                    </td>
                                                                    <td>
                                                                        90
                                                                    </td>
                                                                    <td>
                                                                        134
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                            <!-- <input type="button" value="Reports" class="button1" style="float:right" />  -->
                                                        </div>
                                                        <!-- Visits End -->
                                                        <!-- Ad Start -->
                                                        <div class="searchResultsBox" id="divListingOtherPlaces" runat="server" style="display: none">
                                                            <h3>
                                                                Listing on other places</h3>
                                                            <table class="VisitsTable tab2" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <th scope="col">
                                                                        Site Name
                                                                    </th>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample1.com
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample2.com
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample3.com
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        sample4.com
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <!-- <input type="button" value="Reports" class="button1" style="float:right" />  -->
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </div>
                                                        <!-- ad End -->
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
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" />
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Yes" OnClick="btnYes_Click" />
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
                Inorder to active your listing please contact our customer support.
            </p>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" />
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
    </form>

    <script type="text/ecmascript" language="javascript">
	/* var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];
	
	var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];  
	
	*/
	
	var within = ['10','25','50','100','Anywhere'];
	
	
	var slideImg = ['images/large/zr1review_01.jpg',
					'images/large/zr1review_02.jpg',
					'images/large/zr1review_03.jpg',
					'images/large/zr1review_04.jpg',
					'images/large/zr1review_05.jpg',
					'images/large/zr1review_06.jpg',
					'images/large/zr1review_07.jpg',
					'images/large/zr1review_08.jpg',
					'images/large/zr1review_09.jpg',
					'images/large/zr1review_10.jpg',
					'images/large/zr1review_11.jpg',
					'images/large/zr1review_12.jpg',
					'images/large/zr1review_13.jpg',
					'images/large/zr1review_14.jpg',
					'images/large/zr1review_15.jpg',
					'images/large/zr1review_16.jpg',					
					];
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	
	var ad1 = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
				 
				 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		$('.price').formatCurrency();
        $('.mileage').formatCurrency({symbol: ' '});
		
		$('.sample4').numeric();
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		$('#make, #model, #within, #makeA, #modelA, #withinA, #makeB, #modelB, #withinB').empty();
		$('#yourZip, #yourZipA, #yourZipB').val('');
		
		$('#model, #modelA, #modelB').attr('disabled',true);
		
		
	
	
		$("li input[type=checkbox]").click(function() {
			
			if ($(this).is (':checked')){
				$(this).parent().css('color','#ffb619').css('font-weight','bold');
			}else{
				$(this).parent().css('color','#333').css('font-weight','normal');				
			}			
			// $(this).parent().toggleClass('li-hover');
		});
		
		
		
		
				
		
		
		
		
		
		// lBrandAds
		/*
		if(ad1.length>0){
			var img = '';
			var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
			img += "<img src='"+imgPath+"' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		*/
		
		 
		
	});	
		
		
    </script>

    <script type="text/javascript">
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
