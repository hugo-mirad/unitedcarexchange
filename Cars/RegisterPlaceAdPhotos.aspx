<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterPlaceAdPhotos.aspx.cs"
    Inherits="RegisterPlaceAdPhotos" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc2" %>
<%@ Register Src="UserControl/RegPageUser.ascx" TagName="RegPageUser" TagPrefix="uc3" %>
<%@ Register Src="UserControl/CarsHeader.ascx" TagName="CarsHeader" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <title>..:: United Car Exchange ::..</title>
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

    <script src="js/watermark.js" type="text/javascript"></script>

    <script language="Javascript" type="text/javascript">
    
    function validate()
    {
    
     var Count = 0;
        if (document.getElementById("<%=flupImage1.ClientID%>").value!="")
        {
           Count = 1;
           
        }
        if (document.getElementById("<%=flupImage2.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage3.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage4.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage5.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage6.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage7.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage8.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage9.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage10.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage11.ClientID%>").value!="")
        {
           Count = 1;
           
        }
        if (document.getElementById("<%=flupImage12.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage13.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage14.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage15.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage16.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage17.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage18.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage19.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage20.ClientID%>").value!="")
        {
           Count = 1;
        }
        
        if(Count == 0)
        {
            alert("Select atleast one photo");
            document.getElementById("<%=flupImage1.ClientID%>").focus();
            return false;
        }    
        return true;    
    }
    </script>

    <script type="text/javascript">
    var validFiles=["bmp","gif","png","jpg","jpeg"];
        function CheckExt(obj)
        {
          var source=obj.value;
          var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
          for (var i=0; i<validFiles.length; i++)
          { 
            if (validFiles[i]==ext) 
                break;
          }
          if (i>=validFiles.length)
          {
            alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n"+validFiles.join(", "));
            obj.focus();
            obj.value = "";
          }
         }
         
       function maxPhotos(){
            alert(hdnMaxPhotos.value());
       }  
    </script>

</head>
<body id="page1" onload="GetRecentListings()">
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="">
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
                </h4>
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
                        <uc3:RegPageUser ID="RegPageUser1" runat="server" />
                    </div>
                    <div id="menu">
                        <uc4:CarsHeader ID="CarsHeader1" runat="server" />
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
                                        </h3>
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
                                                        <asp:Label ID="lblHeadName" runat="server" Font-Size="16px"></asp:Label>
                                                        Upload Car Photos
                                                    </h2>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="width: 340px; float: right; padding: 0; text-align: right;">
                                            <img src="images/Navigation3.jpg" id="NavigationImg" runat="server" />
                                        </div>
                                        <br />
                                        <div class="clear">
                                            &nbsp;</div>
                                        <div style="border-top: #ccc 1px solid; padding: 10px 0 20px 0; width: 100%">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        Please note that the first photo which you upload will be your display thumb.
                                                    </td>
                                                    <td>
                                                        <h3 style="text-align: right; float: right">
                                                            <a href="RegisterPlaceAd.aspx">« Back To Vehicle Information</a>
                                                        </h3>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <table border="0" cellpadding="0" cellspacing="0" class="form1 photoUpload photoUploadPage"
                                            style="border-bottom: #ccc 1px solid; padding: 10px 0; margin: 0;">
                                            <tbody>
                                                <tr id="trImg1" runat="server">
                                                    <td style="width: 150px;">
                                                        <h5>
                                                            &nbsp;</h5>
                                                        <span class="num">1</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px">
                                                        <h5 style="text-align: left; padding-left: 145px;">
                                                            (This is your thumb photo)</h5>
                                                        <asp:FileUpload ID="flupImage1" runat="server" Style="width: 98%" onchange="CheckExt(this)" />
                                                        <%--<input type="file" style="width:98%" />--%>
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img1" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg2" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">2</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px">
                                                        <asp:FileUpload ID="flupImage2" runat="server" Style="width: 98%" onchange="CheckExt(this)" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img2" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg3" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">3</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage3" runat="server" Style="width: 98%" />
                                                        <%-- <input type="file" style="width: 98%" />--%>
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img3" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg4" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">4</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage4" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img4" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg5" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">5</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage5" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img5" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg6" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">6</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage6" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img6" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg7" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">7</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage7" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img7" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg8" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">8</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage8" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img8" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg9" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">9</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage9" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img9" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg10" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">10</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage10" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img10" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg11" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">11</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage11" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img11" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg12" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">12</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage12" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img12" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg13" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">13</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage13" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img13" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg14" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">14</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage14" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img14" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg15" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">15</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage15" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img15" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg16" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">16</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage16" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img16" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg17" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">17</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage17" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img17" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg18" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">18</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage18" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img18" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg19" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">19</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage19" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img19" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr id="trImg20" runat="server">
                                                    <td style="width: 150px;">
                                                        <span class="num">20</span>
                                                        <p>
                                                            Upload Photo</p>
                                                    </td>
                                                    <td style="width: 300px;">
                                                        <asp:FileUpload ID="flupImage20" runat="server" Style="width: 98%" />
                                                    </td>
                                                    <td>
                                                        <asp:Image ID="Img20" runat="server" CssClass="imgThumb" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <asp:Button ID="btnContinue" runat="server" CssClass="button1" Text="Add photos later"
                                        Style="float: right; margin-right: 8px;" OnClick="btnContinue_Click" />
                                    <asp:Button ID="btnSave" runat="server" CssClass="button1" Text="Add photos now"
                                        Style="float: right; margin-right: 8px;" OnClick="btnSave_Click" OnClientClick="return validate()" />
                                    <br />
                                    <br />
                                    <!-- Vehicle Type Div End -->
                                </div>
                            </div>
                            <!-- Results Start -->
                            <div class="wrapper">
                                <div style="width: 97%; margin: 0 auto; display: none" id="carDetailsDivHolder">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="line-height: 20px">
                                                <h3 class="h3 h3b" id="carDet">
                                                </h3>
                                                <div id="carDet0">
                                                    <strong>
                                                        <label id="SellerType">
                                                        </label>
                                                        : &nbsp; <strong>Call: &nbsp;</strong><label id="SellerNo"></label><br />
                                                        <strong>Email: &nbsp;</strong><label id="SellerEmail"></label><br />
                                                        <strong>Address: &nbsp;</strong><label id="SellerAddress"></label>
                                                </div>
                                            </td>
                                            <td align="right" valign="top">
                                                <h3>
                                                    <a href="javascript:history.go(-1)">&laquo; Back to search results</a></h3>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- Car Details Div Start -->
                                    <div id="adv1" class="usual">
                                        <ul>
                                            <li class="tab1"><a href="javascript:void(0);#t1 " class="selected">Vehicle Description</a></li>
                                            <li class="tab1"><a href="javascript:void(0);#t2">Photos</a></li>
                                            <li class="tab1"><a href="javascript:void(0);#t3">Map & Direction</a></li>
                                        </ul>
                                        <div id="t1">
                                            <!-- Slider Start  -->
                                            <div class="sliderHolder">
                                                <div id="basic" class="svwp">
                                                    <ul>
                                                        <li>
                                                            <img alt="" src="images/large/zr1review_01.jpg" width="250" height="199" /></li>
                                                        <!--eccetera-->
                                                    </ul>
                                                </div>
                                            </div>
                                            <!-- Slider End  -->
                                            <!-- Disc Start -->
                                            <div class="disc">
                                            </div>
                                            <!-- Disc End -->
                                            <div class="clear">
                                                &nbsp;
                                            </div>
                                            <div class="SellerNotes">
                                            </div>
                                            <div class="clear">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div id="t2">
                                            <!-- Slider Start  -->
                                            <div class="sliderHolder">
                                                <div id="basic2" class="svwp">
                                                    <ul>
                                                        <li>
                                                            <img alt="" src="images/large/zr1review_01.jpg" width="680" height="452" /></li>
                                                        <!--eccetera-->
                                                    </ul>
                                                </div>
                                            </div>
                                            <!-- Slider End  -->
                                            <div class="clear">
                                            </div>
                                        </div>
                                        <div id="t3">
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <h2 style="text-align: center">
                                                Coming soon...!</h2>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                    <!-- Car Details Div  End  -->
                                    <div class="bottomAdd" style="margin-left: 1px;">
                                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57  -->

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
                                        <!-- End: adBrite -->
                                    </div>
                                </div>
                            </div>
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
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="BtnCls"
        OkControlID="btnYes">
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
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertForAsk" runat="server" PopupControlID="divAlertForAsk"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlretForAsk" OkControlID="btnClsimg"
        CancelControlID="btnNo">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlretForAsk" runat="server" />
    <div id="divAlertForAsk" class="alert" style="display: none">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnClsimg" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertForAsk" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnNo" class="btn" runat="server" Text="No" />
            <asp:Button ID="btnAskYes" class="btn" runat="server" Text="Yes" OnClick="btnAskYes_Click" />
        </div>
    </div>
    <div id="divExists1" class="alert" style="display: none">
        <h4 id="H3">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="popupBody1"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnalert1">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnalert1" runat="server" />
    <div class="popupBody" runat="server" style="display: none" id="popupBody1">
        <div>
            <h1 class="h1">
                Alert!</h1>
            <p class="pp">
                No payment details are required as you have selected a free package.
            </p>
            <asp:Button ID="btnOk" class="button1 popBut" runat="server" Text="Ok" OnClick="btnOk_Click" />
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
	
	
			  
	    var ad1 = ['images/ads/ad-v1.jpg','images/ads/ad-v2.jpg','images/ads/ad-v3.jpg','images/ads/ad-v4.jpg','images/ads/ad-v5.jpg','images/ads/ad-v6.jpg','images/ads/ad-v7.jpg','images/ads/ad-v8.jpg','images/ads/ad-v9.jpg','images/ads/ad-v10.jpg'];
	
	var ad2 = ['images/ads/ad-h1.jpg','images/ads/ad-h2.jpg','images/ads/ad-h3.jpg','images/ads/ad-h4.jpg','images/ads/ad-h5.jpg','images/ads/ad-h6.jpg','images/ads/ad-h7.jpg'];
					  
	var ad1left = ['images/ads/ads-l1.jpg','images/ads/ads-l2.jpg','images/ads/ads-l3.jpg'];
	
	 // lBrandAds
		if(ad1left.length>0){
			var img = '';
			var imgPath = ad1left[Math.floor(Math.random() * ad1left.length)];			
			img += "<img src='"+imgPath+"' width='180' />";
			$('#lBrandAds').empty();
			$('#lBrandAds').append(img);
		};	
				 
				 
	$(function() {
		$("div.svwp").prepend("<img src='images/svwloader.gif' class='ldrgif' alt='loading...'/ >");
		
		// Vertical Ticker
		
		
		
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
