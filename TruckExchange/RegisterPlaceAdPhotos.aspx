<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterPlaceAdPhotos.aspx.cs"
    Inherits="RegisterPlaceAdPhotos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/TruckLogin.ascx" TagName="TruckLogin" TagPrefix="uc1" %>
<%@ Register Src="UserControl/TruckHeader.ascx" TagName="TruckHeader" TagPrefix="uc2" %>
<%@ Register Src="UserControl/TruckFooter.ascx" TagName="TruckFooter" TagPrefix="uc3" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="Title1" runat="server"></title>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:800' rel='stylesheet'
        type='text/css'>
    <link rel="stylesheet" type="text/css" href="css/demo.css" />
    <link href="css/page1.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/searchBlock.css" rel="stylesheet" type="text/css" />
    <link href="css/PaginationStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/gallery.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/jquery.idTabs.min.js" type="text/javascript" charset="utf-8"></script>
<script type="text/javascript" src="js/jquery.vticker.js"></script>
    <script language="Javascript" type="text/javascript">
    
    function OnClickEvent(ctrl)
    {
        if(ctrl.value == "Photo Description")
        {
            ctrl.value="";       
        }
    }
     function OnBlurEvent(ctrl)
    {
        if(ctrl.value == "")
        {
            ctrl.value="Photo Description";       
        }
    }
    function validate()
    {
    debugger
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
        if (document.getElementById("<%=flupImage21.ClientID%>").value!="")
        {
           Count = 1;
           
        }
        if (document.getElementById("<%=flupImage22.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage23.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage24.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage25.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage26.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage27.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage28.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage29.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage30.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage31.ClientID%>").value!="")
        {
           Count = 1;
           
        }
        if (document.getElementById("<%=flupImage32.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage33.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage34.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage35.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage36.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage37.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage38.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage39.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage40.ClientID%>").value!="")
        {
           Count = 1;
        }
          if (document.getElementById("<%=flupImage41.ClientID%>").value!="")
        {
           Count = 1;
           
        }
        if (document.getElementById("<%=flupImage42.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage43.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage44.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage45.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage46.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage47.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage48.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage49.ClientID%>").value!="")
        {
           Count = 1;
        }
        if (document.getElementById("<%=flupImage50.ClientID%>").value!="")
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
       
       function pageLoad() {
            GetRecentListings()               
        }
        
    </script>

    <!--[if lt IE 7]>
  <script type="text/javascript" src="js/ie_png.js"></script>
  <script type="text/javascript">
  ie_png.fix('.png, .container p');
  </script>
  <link href="ie.css" rel="stylesheet" type="text/css" />
<![endif]-->

</head>
<body>
    <form id="form1" runat="server">
    <cc1:ToolkitScriptManager ID="scrptmgr" runat="server">
    </cc1:ToolkitScriptManager>    
    <!-- Main Start  -->
    <div class="main">
        <!-- head1 start  -->
        <div class="hed1">
            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle">
                        <a href="http://UnitedTruckExchange.com/">
                            <img src="images/logo.png" class="logo" /></a>
                    </td>
                    <td valign="top">
                        <uc1:TruckLogin ID="TruckLogin1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- head1 End  -->
        <div class="clear">
            &nbsp;</div>
        <!-- Menu Start  -->
        <div class="menu">
            <uc2:TruckHeader ID="TruckHeader1" runat="server" />
        </div>
        <!-- Menu End  -->
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%; position: relative; border-collapse: collapse; margin-bottom: 20px;"
            cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 270px; background: #eee; vertical-align: top; padding: 0 5px 5px 5px">
                    <div class="leftBox1">
                    <h2 style="margin-bottom: 5px; padding-bottom: 0px; color: #555; font-size: 16px;">
                        Recent Used Truck Listings</h2><small><e style="font-size:11px;">Most recent Used Trucks listed for sale</e></small>
                    <!-- Left Brand Ads Satrt -->
                    <div class="ticker1">
                        <ul></ul>
                    </div>
                    <div class="clear">
                        &nbsp;</div>
                    </div>
                    <!-- End: adBrite -->
                    <div class="clear">
                        &nbsp;</div>
                </td>
                <td style="vertical-align: top; padding-left: 10px;">
                    <!-- Right Content Start  -->
                    <!-- Login Page Start  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div id="column-right" class="column-indent">
                        <div class="indent">
                            <div class="wrapper">
                                <!-- Vehicle Type Div Start -->
                                <div class="box4">
                                    <table style="float: left; width: 350px;">
                                        <tr>
                                            <td style="padding-right: 20px; padding-top: 10px;">
                                                <h2>
                                                    Upload Truck Photos
                                                </h2>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="width: 340px; float: right; padding: 0; text-align: right;">
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
                                                    <%--<b><a href="placead.aspx">« Back To Vehicle Information</a> </b>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <table border="0" cellpadding="0" cellspacing="0" class="form1 photoUpload photoUploadPage"
                                        style="border-bottom: #ccc 1px solid; padding: 10px 0; margin: 0;">
                                        <tbody>
                                            <tr id="Tr1" runat="server" style="display: block">
                                                <td style="width: 30px;">
                                                    &nbsp
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td colspan="2">
                                                    (This is your thumb photo)
                                                </td>
                                            </tr>
                                            <tr id="trImg1" runat="server">
                                                <td style="width: 30px; vertical-align: top">
                                                    <div class="number">
                                                        1</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage1" runat="server" Style="width: 98%" onchange="CheckExt(this)" /><br />
                                                    <asp:TextBox ID="txtFlupDesc1" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img1" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg2" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        2</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                             <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage2" runat="server" Style="width: 98%" onchange="CheckExt(this)" /><br />
                                                    <asp:TextBox ID="txtFlupDesc2" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img2" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg3" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        3</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage3" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc3" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img3" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg4" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        4</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage4" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc4" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img4" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg5" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        5</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage5" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc5" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img5" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg6" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        6</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage6" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc6" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img6" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg7" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        7</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage7" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc7" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img7" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg8" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        8</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage8" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc8" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img8" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg9" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        9</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage9" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc9" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img9" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg10" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        10</div>
                                                </td>
                                                <td style="width: 15px; vertical-align: top;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage10" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc10" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img10" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg11" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        11</div>
                                                </td>
                                                <td style="width: 15px; vertical-align: top;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage11" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc11" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img11" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg12" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        12</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage12" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc12" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img12" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg13" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        13</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage13" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc13" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img13" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg14" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        14</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage14" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc14" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img14" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg15" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        15</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage15" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc15" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img15" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg16" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        16</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage16" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc16" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img16" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg17" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        17</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage17" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc17" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img17" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg18" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        18</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage18" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc18" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img18" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg19" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        19</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage19" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc19" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img19" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg20" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        20</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage20" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc20" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img20" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg21" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        21</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage21" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc21" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img21" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg22" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        22</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage22" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc22" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img22" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg23" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        23</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage23" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc23" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img23" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg24" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        24</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage24" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc24" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img24" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg25" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        25</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage25" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc25" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img25" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg26" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        26</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage26" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc26" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img26" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg27" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        27</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage27" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc27" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img27" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg28" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        28</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage28" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc28" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img28" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg29" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        29</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage29" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc29" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img29" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg30" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        30</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage30" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc30" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img30" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg31" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        31</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage31" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc31" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img31" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg32" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        32</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage32" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc32" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img32" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg33" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        33</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage33" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc33" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img33" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg34" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        34</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage34" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc34" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img34" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg35" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        35</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage35" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc35" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img35" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg36" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        36</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage36" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc36" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img36" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg37" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        37</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage37" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc37" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img37" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg38" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        38</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage38" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc38" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img38" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg39" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        39</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage39" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc39" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img39" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg40" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        40</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage40" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc40" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img40" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg41" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        41</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage41" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc41" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img41" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg42" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        42</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage42" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc42" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img42" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg43" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        43</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage43" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc43" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img43" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg44" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        44</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage44" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc44" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img44" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg45" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        45</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage45" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc45" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img45" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg46" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        46</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage46" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc46" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img46" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg47" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        47</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage47" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc47" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img47" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg48" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        48</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage48" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc48" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: tops;">
                                                    <asp:Image ID="Img48" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg49" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        49</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage49" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc49" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img49" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr id="trImg50" runat="server">
                                                <td style="width: 30px; vertical-align: top;">
                                                    <div class="number">
                                                        50</div>
                                                </td>
                                                <td style="width: 15px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 515px; vertical-align: top;">
                                                    <asp:FileUpload ID="flupImage50" runat="server" Style="width: 98%" /><br />
                                                    <asp:TextBox ID="txtFlupDesc50" runat="server" Width="98%" Text="Photo Description"
                                                        MaxLength="100" onclick="return OnClickEvent(this);" onBlur="return OnBlurEvent(this);"></asp:TextBox>
                                                </td>
                                                <td style="vertical-align: top;">
                                                    <asp:Image ID="Img50" runat="server" CssClass="imgThumb" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <%-- <asp:Button ID="btnUploadAll" runat="server" Text="Upload all" CssClass="button1" />--%>
                                                    <%--<input type="button" value="Upload all" class="button1" />--%>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <asp:Button ID="btnContinue" runat="server" CssClass="button" Text="Add photos later"
                                    Style="float: right; margin-right: 8px;" OnClick="btnContinue_Click" />
                                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Add photos now" Style="float: right;
                                    margin-right: 8px;" OnClientClick="return validate()" OnClick="btnSave_Click" />
                                <br />
                                <br />
                                <!-- Vehicle Type Div End -->
                            </div>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <!-- Login Page End  DINESH----------------------------------------------------------------------------------------------------------------------->
                    <div class="clear">
                        &nbsp;</div>
                    <!-- Bottom Ads Start -->
                    <div class="bottomAdd " id="add730" style="width: 730px; margin: 10px 0; font-size: 11px;">
                        <!-- Begin: adBrite, Generated: 2012-05-09 5:52:57 -->
                        <!-- End: adBrite -->
                    </div>
                    <!-- Bottom Ads End  -->
                    <!-- Right Content End  -->
                </td>
            </tr>
        </table>
    </div>
    <!-- Footer Start  -->
    <div class="footer">
        <uc3:TruckFooter ID="TruckFooter1" runat="server" />
    </div>
    <cc1:ModalPopupExtender ID="mdepAlertExists" runat="server" PopupControlID="divExists"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnExists">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnExists" runat="server" />
    <div id="divExists" class="alert" style="display: none;">
        <h4 id="H3">
            Alert
            <asp:Button ID="btnExustCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnExustCls_Click" />
        </h4>
        <div class="data" style="height: 140px;">
            <p>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Next" OnClick="btnOk_Click" />
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
    <cc1:ModalPopupExtender ID="mdepAlertForFreePack" runat="server" PopupControlID="divAlertFreePack"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertFreePack">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertFreePack" runat="server" />
    <div class="popupBody" style="display: block" id="divAlertFreePack">
        <div>
            <br />
            <br />
            <h1 class="h1">
                Congratulations..!</h1>
            <h3 class="h32">
                You are one step closer to selling your truck.</h3>
            <p class="pp">
                You will recieve mail from our's shortly. Mean while you can login check details
                of your and edit any information required including uploading new photographs.
            </p>
            <asp:Button ID="btnSuccessGO" class="button1 popBut" runat="server" Text="Ok" OnClick="btnSuccessGO_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepEditSuccess" runat="server" PopupControlID="divEditSuccess"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEditSuccess">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEditSuccess" runat="server" />
    <div class="popupBody" style="display: block" id="divEditSuccess">
        <div>
            <br />
            <br />
            <p class="pp">
                Oop's there seems to be some system problem. Contact to our customer service 888-786-8307.
            </p>
            <asp:Button ID="btnGo" class="button1 popBut" runat="server" Text="Ok" OnClick="btnGo_Click" />
        </div>
    </div>
    <!-- Footer End  -->
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

    <script type="text/javascript">
    
     
	$(function() {
	
		$('a').each(function(){
			if($(this).attr('href') == '#'){
				$(this).attr('href','javascript:void(0)')
			}
		});	 
		
	});	
    
    
   
    </script>

</body>
</html>
