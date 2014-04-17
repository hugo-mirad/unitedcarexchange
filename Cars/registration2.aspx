<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration2.aspx.cs" Inherits="registration2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/RegPageUser.ascx" TagName="RegPageUser" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="css/tabbed.css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/layout.css" rel="stylesheet" type="text/css" />
    <link href="css/jqtransform.css" rel="stylesheet" type="text/css" />
    <link href="css/svwp_style.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/demo.css" />

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



  function Validate() {
  ;
   var valid = true;
             if (document.getElementById('<%= txtContcname.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtContcname.ClientID%>').focus();
                alert("Enter contact name");
                document.getElementById('<%=txtContcname.ClientID%>').value = ""
                document.getElementById('<%=txtContcname.ClientID%>').focus()
                
                valid = false;
            }
            else if(document.getElementById('<%= txtemail.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtemail.ClientID%>').focus();
                alert("Enter email");
                 document.getElementById('<%=txtemail.ClientID%>').value = ""
                document.getElementById('<%=txtemail.ClientID%>').focus()
                valid = false;            
            
            }
            
             else if ((document.getElementById('<%=txtemail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtemail.ClientID%>').value) == false) )
             {
               
                document.getElementById('<%=txtemail.ClientID%>').value = ""
                document.getElementById('<%=txtemail.ClientID%>').focus()
                valid = false;
                
           
            }
            
              else if(document.getElementById('<%= txtconfEmail.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtconfEmail.ClientID%>').focus();
                document.getElementById('<%=txtconfEmail.ClientID%>').value = "";
                alert("Enter confirm email");
                valid = false;            
            
            }
            
             
              else if ((document.getElementById('<%=txtconfEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtconfEmail.ClientID%>').value) == false) )
             {
               
                document.getElementById('<%=txtconfEmail.ClientID%>').value = ""
                document.getElementById('<%=txtconfEmail.ClientID%>').focus()
                valid = false;
                
           
            }
             else if (document.getElementById('<%=txtemail.ClientID%>').value != document.getElementById('<%=txtconfEmail.ClientID%>').value) {
                document.getElementById('<%=txtconfEmail.ClientID%>').focus();
                 document.getElementById('<%=txtconfEmail.ClientID%>').value = "";
                alert("Email does not match the confirm email");
                valid = false;
            }            
            
              else if (document.getElementById('<%=txtPassword.ClientID%>').value.length < 1 )
             {
                document.getElementById('<%= txtPassword.ClientID%>').focus();
                alert("Enter password");
                 document.getElementById('<%=txtPassword.ClientID%>').value = ""
                document.getElementById('<%=txtPassword.ClientID%>').focus()
                valid = false;            
                
           
            }
             else if (document.getElementById('<%=txtConfirmPassword.ClientID%>').value.length < 1 )
             {
                document.getElementById('<%= txtConfirmPassword.ClientID%>').focus();
                alert("Enter confirm password");
                 document.getElementById('<%=txtConfirmPassword.ClientID%>').value = ""
                document.getElementById('<%=txtConfirmPassword.ClientID%>').focus()
                valid = false;            
                
           
            }
             else if (document.getElementById('<%=txtPassword.ClientID%>').value != document.getElementById('<%=txtConfirmPassword.ClientID%>').value) {
                document.getElementById('<%=txtConfirmPassword.ClientID%>').focus();
                 document.getElementById('<%=txtConfirmPassword.ClientID%>').value = "";
                alert("Password does not match the confirm password");
                valid = false;
            }            
             else if((document.getElementById('<%= txtphone.ClientID%>').value.length > 0) && (document.getElementById('<%= txtphone.ClientID%>').value.length < 10)) {
                document.getElementById('<%= txtphone.ClientID%>').focus();
                document.getElementById('<%=txtphone.ClientID%>').value = "";
                alert("Enter valid phone number");
                valid = false;            
            
            }            
            else if( (document.getElementById('<%=txtRegZip.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtRegZip.ClientID%>').value.length < 4 ))
             {
                document.getElementById('<%= txtRegZip.ClientID%>').focus();
                alert("Please enter valid zipcode");
                 document.getElementById('<%=txtRegZip.ClientID%>').value = ""
                document.getElementById('<%=txtRegZip.ClientID%>').focus()
                valid = false;                            
             }    
         return valid;
      }
      
      
      function isNumberKey(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>

    <style>
        .usual ul li.tab1 a
        {
            display: block;
            padding: 5px 8px;
            text-decoration: none !important;
            margin: 0 2px 0 0;
            margin-left: 0;
            color: #444;
            font-weight: bold;
            background: url(images/AccordionTab0.gif) repeat-x;
        }
    </style>
</head>
<body id="page1" onload="GetRecentListings()" style="background: #eee;">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <div>
        <div id="main-bg" style="width: 730px; margin: 0 auto; overflow: hidden; background: #eee;">
            <div id="main" style="width: 730px; margin: 0 auto; overflow: hidden;">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" alt="" name="logo" id="logo" /></a>
                    <div class="loginStat">
                        <%-- <a href="login.aspx" class="login">Login</a>--%>
                        <uc3:RegPageUser ID="RegPageUser1" runat="server" />
                    </div>
                    <table class="form1" style="margin: 7px 0 0 0; float: right; background: url(images/AccordionTab2.jpg);
                        padding: 6px 6px 0 6px;">
                        <td style="width: 120px;">
                            <select style="width: 120px;">
                                <option>Search by make</option>
                                <option>Search by model</option>
                                <option>Search by name</option>
                                <option>Search by Phone</option>
                            </select>
                        </td>
                        <td style="width: 200px;">
                            <input type="text" class="input1" style="width: 190px;" />
                        </td>
                        <td>
                            <input type="button" value="Search" class="button1" />
                        </td>
                    </table>
                </div>
                <!-- content -->
                <div id="content">
                    <div class="wrapper-1">
                        <div id="column-right" class="column-indent">
                            <div class="indent">
                                <div class="wrapper">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px;">
                                                <h2>
                                                    Registration
                                                </h2>
                                            </td>
                                            <td style="text-align: right">
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Contact Information  Div Start  -->
                                    <div class="box4" style="border-top: #ccc 1px solid; padding: 10px 0;">
                                        <table>
                                            <tr>
                                                <td style="width: 53%">
                                                    <table cellspacing="0" cellpadding="0" border="0" class="form1" style="margin-left: 0;
                                                        padding-left: 0">
                                                        <tr>
                                                            <td style="width: 120px; padding-right: 10px;">
                                                                Contact Name <span class="star">*</span>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormcontactNameContainer">
                                                                    <%--
                                                        <input value="" name="contactName" maxlength="70" type="text" style="width:200px" />--%>
                                                                    <asp:TextBox ID="txtContcname" runat="server" MaxLength="25" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr id="methodOfContactEmail">
                                                            <td>
                                                                Email Address <span class="star">*</span>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormcontactEmailContainer">
                                                                    <%--   <input value="" name="contactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtemail" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr id="methodOfContactConfirmEmail">
                                                            <td>
                                                                Confirm Email <span class="star">*</span>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormconfirmContactEmailContainer">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtconfEmail" runat="server" MaxLength="30" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr1">
                                                            <td>
                                                                Password <span class="star">*</span>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormcontactNameContainer">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" Width="200px" TextMode="Password"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr id="Tr2">
                                                            <td>
                                                                Confirm Password <span class="star">*</span>
                                                            </td>
                                                            <td>
                                                                <span id="oeFormcontactNameContainer">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtConfirmPassword" runat="server" MaxLength="20" Width="200px"
                                                                        TextMode="Password"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 42%; vertical-align: top">
                                                    <table cellspacing="0" cellpadding="0" border="0" class="form1" style="margin-left: 0;
                                                        padding-left: 0">
                                                        <tr>
                                                            <td id="oeFormcontactType1Container1" style="width: 120px;">
                                                                Phone
                                                            </td>
                                                            <td>
                                                                <span id="Span1">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtphone" runat="server" MaxLength="10" Width="200px" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="Td3">
                                                                Address
                                                            </td>
                                                            <td>
                                                                <span id="Span4">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="40" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="Td4">
                                                                City
                                                            </td>
                                                            <td>
                                                                <span id="Span5">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtRegCity" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="Td5">
                                                                State
                                                            </td>
                                                            <td colspan="2">
                                                                <table style="width: 100%:" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <span id="Span6">
                                                                                <asp:DropDownList ID="ddlLocationState" runat="server" Width="95">
                                                                                </asp:DropDownList>
                                                                            </span>
                                                                        </td>
                                                                        <td style="width: 30px; overflow: hidden">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td id="Td6" style="width: 25px;">
                                                                            Zip
                                                                        </td>
                                                                        <td>
                                                                            <span id="Span7">
                                                                                <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                                <asp:TextBox ID="txtRegZip" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"
                                                                                    Width="50px"></asp:TextBox>
                                                                            </span>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 6px;">
                                                    <table cellspacing="0" cellpadding="0" border="0" class="form1" style="margin-left: 0;
                                                        padding-left: 0">
                                                        <tr>
                                                            <td id="Td1" style="width: 120px; padding-right: 10px;">
                                                                Coupon <i style="font-size: 10px; color: #999">(If available)</i>
                                                            </td>
                                                            <td>
                                                                <span id="Span2">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtCoupon" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td id="Td2">
                                                                Reffered By
                                                            </td>
                                                            <td>
                                                                <span id="Span3">
                                                                    <%--
                                                        <input value="" name="confirmContactEmail" maxlength="150" type="text" style="width: 200px" />--%>
                                                                    <asp:TextBox ID="txtRefferedBy" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellspacing="0" cellpadding="0" border="0" class="form1" style="padding-left: 0;
                                            margin-left: 0;">
                                            <!-- 
                                            <tr>
                                                <td>
                                                </td>
                                                <td style="padding-top: 5px;">
                                                   
                                                    <asp:Button ID="btnregister" runat="server" OnClientClick="return Validate();" Text="Proceed"
                                                        class="button1"  />
                                                    &nbsp; Already user? <a href="login.aspx">Login</a> &nbsp;
                                                </td>
                                            </tr>
                                            -->
                                        </table>
                                    </div>
                                    <!-- Contact Information  Div End  -->
                                    <div class="clear">
                                        &nbsp;
                                    </div>
                                    <table style="float: left; width: 370px; padding-left: 0; margin-left: 0;" cellpadding="0"
                                        cellspacing="0" class="form1">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px; width: 130px;">
                                                <h2>
                                                    <asp:Label ID="lblHeadName" runat="server" Font-Size="16px"></asp:Label>
                                                    Build Ad
                                                </h2>
                                            </td>
                                            <td style="padding: 0;">
                                                <table style="font-size: 12px; font-weight: bold; font-family: Arial, Helvetica, sans-serif;
                                                    width: 100%; margin: 0;" class="form1">
                                                    <tr>
                                                        <td style="width: 55px;">
                                                            Package
                                                        </td>
                                                        <td>
                                                            <div id="ddlPackDiv" runat="server" style="display: block;">
                                                                <asp:DropDownList ID="ddlPackage" runat="server">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 100%; margin: 10px 0; height: 2px; overflow: hidden; clear: both;
                                        border-bottom: 1px solid #ccc;">
                                        &nbsp;</div>
                                    <!-- Vehicle Type Div Start -->
                                    <div class="box4">
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 50%;
                                            float: left; margin: 10px 20px 10px 0;">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2">
                                                        <p style="margin: 5px 0; width: 100%;">
                                                            <strong class="hedBack">Vehicle Type</strong>
                                                        </p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 90px;">
                                                        Year <span class="star">*</span>
                                                    </td>
                                                    <td style="width: 300px">
                                                        <asp:DropDownList ID="ddlYear" runat="server">
                                                            <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                            <asp:ListItem Value="2000">2000</asp:ListItem>
                                                            <asp:ListItem Value="2001">2001</asp:ListItem>
                                                            <asp:ListItem Value="2002">2002</asp:ListItem>
                                                            <asp:ListItem Value="2003">2003</asp:ListItem>
                                                            <asp:ListItem Value="2004">2004</asp:ListItem>
                                                            <asp:ListItem Value="2005">2005</asp:ListItem>
                                                            <asp:ListItem Value="2006">2006</asp:ListItem>
                                                            <asp:ListItem Value="2007">2007</asp:ListItem>
                                                            <asp:ListItem Value="2008">2008</asp:ListItem>
                                                            <asp:ListItem Value="2009">2009</asp:ListItem>
                                                            <asp:ListItem Value="2010">2010</asp:ListItem>
                                                            <asp:ListItem Value="2011">2011</asp:ListItem>
                                                            <asp:ListItem Value="2012">2012</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<select name="year">
                                                            <option value="">Select A Year</option>
                                                        </select>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Make <span class="star">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="updtMake" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <%--  <select name="makeId" id="make">
                                                            <option value="">Select a Year First</option>
                                                        </select>--%>
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
                                                        <%-- <select name="modelId" id="model">
                                                            <option value="">Select a Make First</option>
                                                        </select>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Style
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlStyle" runat="server">
                                                                    <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <%-- <select name="trimId">
                                                            <option value="">Select a Model First</option>
                                                        </select>--%>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="right" style="padding-right: 32px;">
                                                        <asp:Button ID="btnSaveVehicleType" runat="server" Text="Save" CssClass="button1"
                                                            OnClientClick="return ValidateVehicleType();" OnClick="btnSaveVehicleType_Click" />
                                                    </td>
                                                </tr>--%>
                                            </tbody>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1" style="width: 43%;
                                            float: left; margin: 10px 0 0 0">
                                            <tr>
                                                <td colspan="2">
                                                    <p style="margin: 5px 0; width: 100%;">
                                                        <strong class="hedBack">Seller Information For Display</strong>
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 80px;">
                                                    Name
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSellerName" runat="server" MaxLength="25" CssClass="input1"></asp:TextBox>
                                                    <%-- <input value="" type="text" maxlength="40" />--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Address
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtAddress" runat="server" MaxLength="40" CssClass="input1"></asp:TextBox>
                                                    <%-- <input value="" type="text" maxlength="40" />--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    City
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCity" runat="server" MaxLength="20" CssClass="input1"></asp:TextBox>
                                                    <%-- <input value="" type="text" maxlength="40" />--%>
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
                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="input1" Width="100px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 40px; overflow: hidden;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 28px;">
                                                                ZIP
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"
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
                                        <div class="clear">
                                            &nbsp;</div>
                                    </div>
                                    <!-- Vehicle Type Div End -->
                                    <!-- Vehicle Information  Div Start  -->
                                    <div class="box4 basic" style="width: 99%; margin: 0 0 5px 0">
                                        <div class="hed hh2" onclick="javascript:choice('1')">
                                            <a style="text-transform: uppercase; font-size: 13px;">Vehicle Information<i class="non">(You
                                                may add or modify these later)</i></a>
                                            <div class="close ">
                                            </div>
                                        </div>
                                        <div id="div1" style="background: #fff;">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 95%; padding-left: 0;
                                                margin-left: 0;" class="form1">
                                                <tbody>
                                                    <tr>
                                                        <td style="padding-top: 6px; vertical-align: top; width: 115px;">
                                                            Asking Price
                                                        </td>
                                                        <td style="width: 170px;">
                                                            <%-- <input type="text" name="askingPrice" value="" />--%>
                                                            <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                            <%--<a href="#">
                                                                <img src="images/questionMark.gif" border="0" alt="" /></a><br />--%>
                                                            <%-- <asp:CheckBox ID="chkAcceptBestOffer" runat="server" />--%>
                                                            <%--<input type="checkbox" name="acceptBestOffer" value="T" />--%>
                                                            <%-- Or Best Offer--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="width: 110px;">
                                                            Drive Train
                                                        </td>
                                                        <td style="width: 170px">
                                                            <asp:DropDownList ID="ddlDriveTrain" runat="server">
                                                            </asp:DropDownList>
                                                            <%--<select name="cylinderCount">
                                                                <option value="" selected="selected">Select One</option>
                                                            </select>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Mileage
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                                            <%--<input type="text" name="mileage" value="" />--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td style="width: 110px;">
                                                            Engine Cylinders
                                                        </td>
                                                        <td style="width: 170px">
                                                            <asp:DropDownList ID="ddlCylinderCount" runat="server">
                                                            </asp:DropDownList>
                                                            <%--<select name="cylinderCount">
                                                                <option value="" selected="selected">Select One</option>
                                                            </select>--%>
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
                                                            <%-- <select name="exteriorColor" style="width: 86%;">
                                                                <option selected="selected" value="">Select One</option>
                                                            </select>--%>
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
                                                                <%--<select name="doorCount" style="width: 86%;">
                                                                    <option value="" selected="selected">Select One</option>
                                                                </select>--%>
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
                                                            <%--<select name="interiorColor" style="width: 86%;">
                                                                <option selected="selected" value="">Select One</option>
                                                            </select>--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            Fuel Type
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFuelType" runat="server">
                                                            </asp:DropDownList>
                                                            <%-- <select name="fuelType">
                                                                <option value="" selected="selected">Select One</option>
                                                            </select>--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Transmission
                                                        </td>
                                                        <td>
                                                            <span id="oeFormtransmissionContainer">
                                                                <asp:DropDownList ID="ddlTransmission" runat="server">
                                                                </asp:DropDownList>
                                                                <%-- <select name="transmission" style="width: 86%;">
                                                                    <option value="" selected="selected">Select One</option>
                                                                </select>--%>
                                                                <%--<a href="#">
                                                                    <img src="images/questionMark.gif" border="0" alt="" /></a>--%>
                                                            </span>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            VIN <em>(may add later)</em>
                                                        </td>
                                                        <td>
                                                            <span id="oeFormvinContainer">
                                                                <asp:TextBox ID="txtVin" runat="server" MaxLength="17"></asp:TextBox>
                                                                <%--<input type="text" name="vin" value="" maxlength="17" />--%>
                                                                <%-- <a href="#">
                                                                    <img src="images/questionMark.gif" border="0" alt="" /></a>--%></span>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Condition
                                                        </td>
                                                        <td>
                                                            <span id="Span8">
                                                                <asp:DropDownList ID="ddlCondition" runat="server">
                                                                </asp:DropDownList>
                                                                <%-- <select name="transmission" style="width: 86%;">
                                                                    <option value="" selected="selected">Select One</option>
                                                                </select>--%>
                                                                <%--<a href="#">
                                                                    <img src="images/questionMark.gif" border="0" alt="" /></a>--%>
                                                            </span>
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
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <%--  ZIP Code <span class="star">*</span>--%>
                                                        </td>
                                                        <td>
                                                            <%--     <span id="oeFormlocationZipContainer"><strong>08830</strong></span>--%>
                                                            <%-- <asp:TextBox ID="txtZip" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"></asp:TextBox>--%>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Vehicle Information  Div End  -->
                                    <!-- Vehicle Description  Div Start  -->
                                    <div class="box4 basic" style="width: 99%; margin: 0 0 5px 0">
                                        <div class="hed hh2" onclick="javascript:choice('2')">
                                            <a style="text-transform: uppercase; font-size: 13px;">Vehicle Description <i class="non">
                                                (You may add or modify these later)</i></a>
                                            <div class="close ">
                                            </div>
                                        </div>
                                        <div id="div2" style="background: #fff;">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="form1" style="padding-left: 0;
                                                margin-left: 0;">
                                                <tbody>
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
                                                                    <asp:CheckBox ID="chkFeatures1" runat="server" />
                                                                    <%--<input name="features" value="A/C: Front" type="checkbox" />--%>
                                                                    A/C: Front</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures2" runat="server" />
                                                                    <%--<input name="features2" value="A/C: Rear" type="checkbox" />--%>
                                                                    A/C: Rear</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures3" runat="server" />
                                                                    <%--<input name="features2" value="Cruise Control" type="checkbox" />--%>
                                                                    Cruise Control</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures4" runat="server" />
                                                                    <%--<input name="features2" value="Navigation System" type="checkbox" />--%>
                                                                    Navigation System <a href="#">
                                                                        <img src="images/questionMark.gif" alt="" border="0" /></a></div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures5" runat="server" />
                                                                    <%--<input name="features2" value="Power Locks" type="checkbox" />--%>
                                                                    Power Locks</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures6" runat="server" />
                                                                    <%--<input name="features2" value="Power Steering" type="checkbox" />--%>
                                                                    Power Steering</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures7" runat="server" />
                                                                    <%-- <input name="features2" value="Remote Keyless Entry" type="checkbox" />--%>
                                                                    Remote Keyless Entry <a href="#">
                                                                        <img src="images/questionMark.gif" alt="" border="0" /></a></div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures8" runat="server" />
                                                                    <%--<input name="features2" value="TV/VCR" type="checkbox" />--%>
                                                                    TV/VCR</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures31" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Remote Start</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures32" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Heated Sheets</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures33" runat="server" />
                                                                    <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                                    Tilt</div>
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
                                                                    CD Changer <a href="#">
                                                                        <img src="images/questionMark.gif" alt="" border="0" /></a></div>
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
                                                                    Sunroof/Moonroof</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures29" runat="server" />
                                                                    <%--<input name="features2" value="Third Row Seats" type="checkbox" />--%>
                                                                    Third Row Seats</div>
                                                                <div>
                                                                    <asp:CheckBox ID="chkFeatures30" runat="server" />
                                                                    <%--<input name="features2" value="Tow Package" type="checkbox" />--%>
                                                                    Tow Package</div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table id="vSellpointsbox" border="0" cellpadding="0" cellspacing="0" width="100%"
                                                class="form1" style="padding-left: 0; margin-left: 0;">
                                                <tbody>
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
                                                        <td style="width: 330px;">
                                                            <span id="oeFormsellingPointsContainer"><span id="sellingPointSentence"><span id="sellingPointCharCount">
                                                                1000</span> characters left</span><br />
                                                                <asp:TextBox ID="txtCondition" runat="server" TextMode="MultiLine" Rows="8" cols="10"
                                                                    onchange="updateCharCount(this,'sellingPointCharCount');" onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                    class="textarea" MaxLength="1000"></asp:TextBox>
                                                                <%--<textarea name="sellingPoints" rows="8" cols="10" onchange="updateCharCount(this,'sellingPointCharCount');"
                                                                    onkeyup="updateCharCount(this,'sellingPointCharCount','sellingPointSentence');"
                                                                    class="textarea" runat="server"></textarea>--%>
                                                            </span>
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
                                                    <%--<tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                        <td align="right" style="padding-right: 20px;">
                                                            <asp:Button ID="btnCarFeaturesSave" runat="server" Text="Save" CssClass="button1"
                                                                OnClick="btnCarFeaturesSave_Click" />
                                                        </td>
                                                    </tr>--%>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Vehicle Description  Div End  -->
                                    <div class="clear">
                                    </div>
                                    <br />
                                    <input type="button" class="button1" value="Submit" style="float: right; margin-right: 8px;" />
                                    <input type="button" class="button1" value="Send a welcome email" style="float: right;
                                        margin-right: 8px;" />
                                    <br />
                                    <br />
                                    <div class="clear">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                            &nbsp;</div>
                    </div>
                </div>
                <!-- footer -->
                <div id="footer" style="width: 730px; margin: 0 auto">
                    <p style="padding-top: 10px; font-size: 11px">
                        United Car Exchange &copy; 2012
                    </p>
                </div>
            </div>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls"> </div> -->
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
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Yes" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists" OkControlID="btnExustCls"
        CancelControlID="btnOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls"> </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <!-- Processiong Popup Start -->
    <div id="spinner" style="display: none;">
        <h4>
            <div>
                Applying your filter
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <!-- Processiong Popup End -->
    </form>

    <script type="text/javascript" language="javascript">
        
					  
	    var ad1 = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
        $(function() {
		    $("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
    		
		    // Vertical Ticker
    		
		   
    		
		    $('.sample4').numeric();
    		
		    if(ad1.length>0){
			    var img = '';
			    var imgPath = ad1[Math.floor(Math.random() * ad1.length)];			
			    img += "<img src='"+imgPath+"' />";
			    $('#lBrandAds').empty();
			    $('#lBrandAds').append(img);
		    };
		
		    $('div.hed div.close').click(function(){
		        $(this).toggleClass("open");
            });
            
            
    		
		});
		
		function choice(e){
		$('#div'+e).slideToggle();	
		
    }
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
