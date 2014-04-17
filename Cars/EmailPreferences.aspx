<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailPreferences.aspx.cs"
    Inherits="EmailPreferences" EnableEventValidation="false"   %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: Welcome to Automatic Vehicle Alerts System of United Car Exchange ::..
    
    </title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

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
    within = [10, 25, 50, 100, 'Anywhere']; 
    var SearchResults;    
    LoadingPage = 1;
    page = 1;
    PageResultsCount = 25;
    //hideSpinner();
    startNum = 1;
    var endNum = 25;
    maxPages = 0;
    totalTesults = 0;
    resultsLength = 0;
    //var ZipCodes = [];
    
    var make1='All makes' ;
    var Modal1='All models';
    var ZipCode1='' ;
    var WithinZipNew=3 ; 
    
       
   function pageLoad() {

       

       $('.sample4').numeric({ allow: "-" });

        $(function() {
            $('.default-value').each(function() {
                var default_value = this.value;
                $(this).css('color', '#999')
                $(this).focus(function() {
                    $(this).css('color', '#333')
                    if (this.value == default_value) {
                        this.value = '';
                        $(this).css('color', '#333')
                    } else { $(this).css('color', '#333') }
                });
                $(this).blur(function() {
                    if (this.value == '') {
                        this.value = default_value;
                        $(this).css('color', '#999')
                    } else { $(this).css('color', '#333') }
                });
            });
        })

        GetRecentListings();
          
   }
    
    
    function KeyDownHandler(btn)
    {
      if (event.keyCode == 13)
      {
        event.returnValue=false;
        //event.cancel = true;
        //btn.click();
      }
    }

  
    KeyListener = {
        init : function() {
            $('#searchFormHolder').bind('keypress', function(e) {
                var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
                var target = e.target.tagName.toLowerCase();
                if (key === 13 && target === 'input') {
                    e.preventDefault();
                    var button = $('.but1');
                    if (button.length > 0) {
                        if (typeof(button.get(0).onclick) == 'function') {
                            button.trigger('click');
                        }else if (button.attr('href')) {
                            window.location = button.attr('href');
                        }else {
                            button.trigger('click');
                        }
                    }
                   
                }               

            });
        }
    };

            $(document).ready(function() {
                KeyListener.init()
            });
            
    
    </script>

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



        function ValidatePreferences() {
 
            var valid = true;

            if ($('#ddlWithin option:selected').val() == 0) {
                alert("Please select Within");
                $('#ddlWithin').focus();
                return false

            }
            if ($('#ddlRange option:selected').val() == 0) {
                alert("Please select Range");
                $('#ddlRange').focus();
                return false

            } 
                                  
             if ($('#txtName').val().trim() == 'Your Name') {                
                alert("Enter Name");
                $('#txtName').focus();
                return false;

            }
            /*else if (($('#txtPhoneNo').val().trim() != 'Phone') && ($('#txtPhoneNo').val().trim().length < 10)) {
            $('#txtPhoneNo').focus();
                alert("Enter valid phone #");
                return false                       
            }
            else if ($('#txtEmailAlert').val().trim()=='Your Email') {
            $('#txtEmailAlert').focus();
                alert("Enter email");                
                $('#txtEmailAlert').focus()
                return false           
            
            }*/
            else if (($('#txtEmailAlert').val().trim().length > 0) && (echeck($('#txtEmailAlert').val().trim()) == false))
             {
                 $('#txtEmailAlert').focus()
                 return false              
           
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
        
            function isNumberKeyWithDashForZip(evt)
         {
         
         
            var charCode = (evt.which) ? evt.which : event.keyCode         
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
    </script>

    <!-- Look at the configuration -->

    <script src="js/watermark.js" type="text/javascript"></script>

</head>
<body id="page1">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="" DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner" style="height: 25px">
                <div>
                    Processing
                    <img src="images/loading.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div>
        <div id="main-bg">
            <div id="main">
                <!-- header -->
                <div id="header" style="height: 77px">
                    <a href="http://UnitedCarExchange.com">
                        <img src="images/logo2.png" id="logo" alt="" /></a>
                    <div class="loginStat">
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
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2100989&br=1&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

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
                                        <em class="i1">Must read tips &amp; advices on used cars</em><br />
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
                                    <!--  -->
                                    <div class="info-box" style="background: #fff;">
                                        <div class="wrapper">
                                            <!-- Box1 Div Start  -->
                                            <br />
                                            <h3 style="font-size: 18px; padding-bottom: 6px; margin-bottom: 10px; border-bottom: #ccc 1px solid;">
                                                Welcome to Automatic Vehicle Alerts System of United Car Exchange</h3>
                                            <div class="clear">
                                                &nbsp;</div>
                                            <div style="width: 681px; margin: 20px 0; padding: 20px 10px; border: #CCC 1px dotted;
                                                background: #f7f7f7;">
                                                <h4>
                                                    <asp:Label ID="lblTitle" runat="server" Visible="false"></asp:Label>
                                                </h4>
                                                <table style="width: 98%; margin: 0 auto" class="makeModelSelEdit">
                                                    <tr id="row0">
                                                        <td style="width: 170px;">
                                                            <h4>
                                                                Make</h4>
                                                            <asp:UpdatePanel ID="UpdMake1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMakes1" Style="width: 162px;" TabIndex="1" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlMake1_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <h4>
                                                                Model</h4>
                                                            <asp:UpdatePanel ID="UpdModel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModels1" Style="width: 99%;" TabIndex="2" runat="server"
                                                                        AutoPostBack="true" AppendDataBoundItems="true" EnableViewState="true">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlMakes1" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 120px;">
                                                            <h4>
                                                                Price Range</h4>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRanges1" Style="width: 100%;" TabIndex="3" runat="server">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 50px;">
                                                            &nbsp;
                                                            <asp:HiddenField ID="TotalRowcount" runat="server" Value="1" />
                                                            <asp:HiddenField ID="hdnPreferenceID1" Value="0" runat="server" />
                                                            <asp:HiddenField ID="hdnPreferenceID2" Value="0" runat="server" />
                                                            <asp:HiddenField ID="hdnPreferenceID3" Value="0" runat="server" />
                                                            <asp:HiddenField ID="hdnPreferenceID4" Value="0" runat="server" />
                                                            <asp:HiddenField ID="hdnPreferenceID5" Value="0" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr id="row1">
                                                        <td style="width: 170px;">
                                                            <asp:UpdatePanel ID="UpdMake2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMakes2" Style="width: 162px;" TabIndex="4" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlMake2_SelectedIndexChanged" EnableViewState="true">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdModel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModels2" Style="width: 99%;" TabIndex="5" runat="server"
                                                                        AutoPostBack="true" AppendDataBoundItems="true">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlMakes2" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 120px;">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlRanges2" Style="width: 100%;" TabIndex="6" runat="server">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <a href="javascript:void(0);" class="rem">Remove</a>
                                                        </td>
                                                    </tr>
                                                    <tr id="row2">
                                                        <td style="width: 170px;">
                                                            <asp:UpdatePanel ID="UpdMake3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMakes3" Style="width: 162px;" TabIndex="7" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlMake3_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdModel3" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModels3" Style="width: 99%;" TabIndex="8" runat="server"
                                                                        AutoPostBack="true" AppendDataBoundItems="true">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlMakes3" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 120px;">
                                                            <asp:DropDownList ID="ddlRanges3" Style="width: 100%;" TabIndex="9" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <a href="javascript:void(0);" class="rem">Remove</a>
                                                        </td>
                                                    </tr>
                                                    <tr id="row3">
                                                        <td style="width: 170px;">
                                                            <asp:UpdatePanel ID="UpdMake4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMakes4" Style="width: 162px;" TabIndex="10" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlMake4_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdModel4" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModels4" Style="width: 99%;" TabIndex="11" runat="server"
                                                                        AutoPostBack="true" AppendDataBoundItems="true">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlMakes4" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 120px;">
                                                            <asp:DropDownList ID="ddlRanges4" Style="width: 100%;" TabIndex="12" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <a href="javascript:void(0);" class="rem">Remove</a>
                                                        </td>
                                                    </tr>
                                                    <tr id="row4">
                                                        <td style="width: 170px;">
                                                            <asp:UpdatePanel ID="UpdMake5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMakes5" Style="width: 162px;" TabIndex="13" AutoPostBack="true"
                                                                        runat="server" OnSelectedIndexChanged="ddlMake5_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdModel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModels5" Style="width: 99%;" TabIndex="14" runat="server"
                                                                        AutoPostBack="true" AppendDataBoundItems="true">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlMakes5" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 120px;">
                                                            <asp:DropDownList ID="ddlRanges5" Style="width: 100%;" TabIndex="15" runat="server">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 50px;">
                                                            <a href="javascript:void(0);" class="rem">Remove</a>
                                                        </td>
                                                    </tr>
                                                    <tr id="row5">
                                                        <td colspan="3">
                                                        </td>
                                                        <td>
                                                            <a href="javascript:void(0);"><b>+ Add</b></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <table style="width: 98%; margin: 0 auto 10px auto">
                                                    <tr>
                                                        <td colspan="2" style="padding-bottom: 10px;">
                                                            <h4>
                                                                Name<span class="star">*</span></h4>
                                                            <asp:HiddenField ID="hdnUserPrefernceID" runat="server" Value="0" />
                                                            <asp:TextBox ID="txtName" Style="width: 99%;" TabIndex="16" runat="server"                                                               MaxLength="50">
                                                            </asp:TextBox>
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 58%;">
                                                            <h4>
                                                                Email <span class="star">*</span></h4>
                                                            <asp:TextBox ID="txtEmailAlert"  Style="width: 95%;" MaxLength="50" 
                                                                TabIndex="17" runat="server">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <h4>
                                                                Phone</h4>
                                                            <asp:TextBox ID="txtPhoneNo" Style="width: 97%;" class="sample4" MaxLength="10"
                                                                TabIndex="18" runat="server">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 120px;">
                                                            <h4>
                                                                Zip</h4>
                                                            <asp:TextBox ID="txtZip" Style="width: 18%;" TabIndex="19" runat="server" Text=""
                                                                MaxLength="5" class="sample4">
                                                            </asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <table style="width: 98%; margin: 0 auto;">
                                                    <tr>
                                                        <td style="width: 56%; text-align: right; padding-right: 4px;">
                                                            <asp:Button runat="server" ID="btnSubscribe" class="floatL button1" Text="Update"
                                                                OnClick="btnSubscribe_Click" OnClientClick="javascript:return ValidatePreferences();" />
                                                        </td>
                                                        <td style="text-align: left; padding-left: 4px;">
                                                            &nbsp;
                                                            <!-- <input type="button" class="floatL button1" id="btnSubscribeCancel" value="No,thanks" />  -->
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <br />
                                            <!-- Box1 Div End  -->
                                            <!-- Box2 Div Start  -->
                                            <!-- Box2 Div End  -->
                                            <div class="clear">
                                            </div>
                                            <!-- Box2 Div Start  -->
                                            <div class="box3">
                                                <div class="wrapper">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 65%; border-right: #fedaa0 1px dotted; padding: 10px;">
                                                                <h3 class="h3">
                                                                    Sell Your Car - Easy &amp; Fast!</h3>
                                                                <p>
                                                                    More then a million cars sold, already - Advertise with us.</p>
                                                                <input type="button" class="button1" value="LIST YOUR CAR NOW" onclick="window.location.href='Registration.aspx'" />
                                                            </td>
                                                            <td style="padding: 10px;">
                                                                <h3 class="h3">
                                                                    Used Cars Advertising</h3>
                                                                <i class="i1">We help you grow your business</i><div class="clear">
                                                                </div>
                                                                View our <a href="Packages.aspx">Advertising Plans</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <!-- Box2 Div End  -->
                                            <div class="clear">
                                            </div>
                                            <!-- Ads Section Start  -->
                                            <div class="ads1">
                                            </div>
                                            <!-- Ads Section Endt  -->
                                        </div>
                                    </div>
                                    <!-- -->
                                </div>
                            </div>
                            <!-- Results Start -->
                            <div id="div88X720" runat="server" style="height: 88px; width: 720px; margin: 10px auto;
                                border: #999 1px solid; padding: 1px; background: white;">
                            </div>
                            <!-- 
                            <div class="bottomAdd" style="margin-left: 1px;">
                               

                                <script type="text/javascript">
var AdBrite_Title_Color = '0000FF';
var AdBrite_Text_Color = '000000';
var AdBrite_Background_Color = 'FFFFFF';
var AdBrite_Border_Color = 'CCCCCC';
var AdBrite_URL_Color = '008000';
try{var AdBrite_Iframe=window.top!=window.self?2:1;var AdBrite_Referrer=document.referrer==''?document.location:document.referrer;AdBrite_Referrer=encodeURIComponent(AdBrite_Referrer);}catch(e){var AdBrite_Iframe='';var AdBrite_Referrer='';}
                                </script>

                                <span style="white-space: nowrap;">

                                    <script type="text/javascript">document.write(String.fromCharCode(60,83,67,82,73,80,84));document.write(' src="http://ads.adbrite.com/mb/text_group.php?sid=2102343&zs=3732385f3930&ifr='+AdBrite_Iframe+'&ref='+AdBrite_Referrer+'" type="text/javascript">');document.write(String.fromCharCode(60,47,83,67,82,73,80,84,62));</script>

                                    <a target="_top" href="http://www.adbrite.com/mb/commerce/purchase_form.php?opid=2102343&afsid=1">
                                        <img src="http://files.adbrite.com/mb/images/adbrite-your-ad-here-leaderboard.gif"
                                            style="background-color: #CCCCCC; border: none; padding: 0; margin: 0;" alt="Your Ad Here"
                                            width="14" height="90" border="0" /></a></span>
                                
                            </div>
                            -->
                            <!-- Results End -->
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
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div class="popupBody" style="display: block" id="AlertUser">
        <div>
            <br />
            <h3 class="h3">
                <asp:Label ID="lblalert" runat="server"></asp:Label>
            </h3>
            <br />
            <asp:Button ID="btngo" runat="server" Text="Ok" class="button1" OnClick="btnGo_Click"
                Style="margin-top: 6px;" />
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
    <!-- Processiong
    Popup End -->
    </form>

    <script type="text/ecmascript" language="javascript">
	/* var make = [['All Makes',0],['Acura',20001],['Alfa Romeo',20047],['Am General',20002],['Aston Martin',20003],['Audi',20049],['Avanti Motors',20050],['Bentley',20051],['BMW',20005],['Bugatti',33583],['Buick',20006],['Cadillac',20052],['Chevrolet',20053],['Chrysler',20008]];
	
	var models = [['All Models',0],['Acadia',20607],['Accent',20605],['Acclaim',20609],['Accord',20606],['Accord Crosstour',34203],['Accord Hybrid',20611],['Achieva',20610],['Aerio',20619],['Aero 8',20621]];  
	
	*/
	
	
					
	// var carDetails = ['car1','Chevrolet Corvette ZR1',2009,'450,000','Coupe','Red','Gray',1,'00000009113300157','Gasoline','3.0L 6 Cylinder','5-Speed Manual',2,'The Honorable Charles W. Anderson (Dear Mr. Ambassador:), Department of State, 2050 Bamako Place, Washington, DC 20521-2050',0,0,'Honda of Princeton','866-649-7910'];
	
	
					  
	
	
	var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];


	var rowCounterEdit = 0;
	var TotalRowcount = 0;
	$(function() {
	    TotalRowcount = parseInt($('#TotalRowcount').val());

	    ////console.log(TotalRowcount)
	    rowCounterEdit = TotalRowcount;

	    $('.makeModelSelEdit a.rem').hide();
	    if (TotalRowcount > 0) {
	        for (kk = 0; kk < TotalRowcount; kk++) {
	            $('.makeModelSelEdit #row' + kk).css('display', 'table-row');

	        }
	        $('.makeModelSelEdit #row' + (kk - 1) + ' a.rem').show();
	        if (TotalRowcount == 5) {
	            $('.makeModelSelEdit #row5').hide();
	        }
	    }

	    $('.makeModelSelEdit #row5 a').click(function() {
	        var selCountEdit = 0;
	        if (rowCounterEdit <= 4) {
	            var selCountEdit = 0;
	            ////console.log(rowCounterEdit - 1);
	            $('.makeModelSelEdit #row' + (rowCounterEdit - 1) + ' select').each(function(index) {
	                var ind = index;
	                var val = $(this).val();
	                ////console.log('rowCounterEdit:' + (rowCounterEdit-1) + ' Index:' + ind + ' val:' + val)
	                if ((val == 0) && (ind == 0 || ind == 1)) {
	                    selCountEdit++;
	                }
	            });

	            if (selCountEdit == 0) {
	                
	                //$('.makeModelSelEdit #row' + (rowCounterEdit - 1) + ' select').attr('disabled', true);
	                $('.makeModelSelEdit #row' + (rowCounterEdit - 1) + ' a.rem').hide();
	                $('.makeModelSelEdit #row' + rowCounterEdit).show();
	                
	                if (rowCounterEdit == 4) {
	                    $('.makeModelSelEdit #row5').hide();
	                }
	                $('.makeModelSelEdit #row' + (rowCounterEdit) + ' a.rem').show();
	                rowCounterEdit++;
	            } else {
	                alert('Select Make and Model')
	            }

	        }
	    });





	    $('.makeModelSelEdit .rem').click(function() {
	        var id = $(this).parent().parent().attr('id');

	        if (rowCounterEdit > 0) {
	            rowCounterEdit--;
	            $('.makeModelSelEdit #' + id).hide()
	            $('.makeModelSelEdit #row' + rowCounterEdit + ' select').removeAttr('disabled');
	            var rem = id.substring(0, 3) + (rowCounterEdit-1);
	            ////console.log(rem);
	            $('.makeModelSelEdit #' + rem + ' a.rem').show();
	            $('.makeModelSelEdit #' + id + ' select').each(function() {
	                $(this).removeAttr('selected').find('option:first').attr('selected', 'selected');

	                var ddModel = 'ddlModel' + parseInt(id.charAt(3));
	                if ($(this).attr('id') == ddModel) {
	                    ////console.log($(this).attr('id'))
	                    $(this).empty().append('<option selected="selected" value="0">Select</option>');
	                }
	            });

	            $('.makeModelSelEdit #row5').show();
	            if (rowCounterEdit == 0) {
	                $('.makeModelSelEdit #row0 select').removeAttr('disabled');
	            }

	        }
	    });

	});
	 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		
		
		$('.sample4').numeric();
        //$('.sample5').numeric({allow:"."});
        //$('.sample1').alphanumeric();	
		
		
		
		
	
	
				
		
		
		
		  // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};
		
		 
		 // Ads		
		//$('.ads1').empty();
		//return a random integer between 0 and 10		
		var ads = '';
		//var imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		//ads += "<div class='left-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		//imgPath = ad1[Math.floor(Math.random() * ad1.length)];	
		//ads += "<div class='right-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";
		ads += "<div class='clear'>&nbsp;</div>";	
		imgPath = ad2[Math.floor(Math.random() * ad2.length)];		
		//ads += "<div class='horiz-ad'><a href='#'><img src='"+imgPath+"' /></a></div>";	
		//ads += "<div class='clear'>&nbsp;</div>";
		$('.ads1').append(ads);
		 
		
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
