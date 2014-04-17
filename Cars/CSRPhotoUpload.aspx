<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CSRPhotoUpload.aspx.cs" Inherits="CSRPhotoUpload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE9">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="Static/Css/Smartzstyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">        window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <!--  <script src="js/FillMasterData.js" type="text/javascript"></script>  -->

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
       function ValidateVehicleType1()
        {
         
            var valid=true;                
    
             if(document.getElementById('<%=txtCarID.ClientID%>').value.length == 0 ) 
             {
                document.getElementById('<%= txtCarID.ClientID%>').focus();
                alert("Please enter car id");
                 document.getElementById('<%=txtCarID.ClientID%>').value = ""
                document.getElementById('<%=txtCarID.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }                     
            
        
          }     
    </script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
		$('.price').formatCurrency();
        $('.mileage').formatCurrency({symbol: ' '});    
        
       
            
        
        // Phone No Formate
        /*
        $("input[@name='phone']").keyup(function() {
		    var curchr = this.value.length;
		    var curval = $(this).val();
		    if (curchr == 3) {
			    $("input[@name='phone']").val("(" + curval + ")" + "-");
		    } else if (curchr == 9) {
			    $("input[@name='phone']").val(curval + "-");
		    }
	    });
	    */	    
	   
	    
	    
	});   
	    
    

    </script>

    <script type='text/javascript'>  
      function  sample(){
            $('.price').formatCurrency();
            $('.mileage').formatCurrency({symbol: ' '});               
        }
    
      function  showSpinner(){
            $('#spinner').show();            
        }
        function  hideSpinner(){                   
            $('#spinner').hide();       
        } 
        
       function isNumberKey(evt)
         {
         
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
     

    </script>

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
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <div class="headder">
        <table style="width: 100%">
            <td style="width: 250px;">
                <a href="#">
                    <img src="Static/Images/logo2b.png" /></a>
            </td>
            <td>
                <h1 class="h11">
                    Smartz Customer Service System</h1>
            </td>
            <td style="width: 250px;">
                <div class="loginStat">
                    Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false" OnClick="lnkBtnLogout_Click"
                        ></asp:LinkButton>
                </div>
            </td>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            Multi-site listing data uploads</h1>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 350px; vertical-align: top;">
                    Enter Car ID<br />
                    <table cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                        <tr>
                            <td style="width: 60%;">
                                <asp:TextBox ID="txtCarID" runat="server" CssClass="input1 number" MaxLength="12"
                                    Style="padding: 5px;" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                <%--<input type="text" class="input1" style="padding: 5px;" />--%>
                            </td>
                            <td style="width: 15px;">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button ID="btnGoByCarID" runat="server" Text="Go" CssClass="g-button g-button-submit"
                                    OnClick="btnGoByCarID_Click" />
                                <%-- <input type="button" value="Go" class="g-button g-button-submit " />--%>
                            </td>
                        </tr>
                    </table>
                    <div class="clear marginTop">
                        &nbsp;</div>
                    <div id="divCarIDData" runat="server" style="display: none;">
                        <table style="width: 98%;">
                            <tr>
                                <td style="width: 45%;">
                                    Listing Details
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                            <asp:Label ID="lblSearchCarIDRes" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                runat="server"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="upDtPnlListingDetails" runat="server">
                            <ContentTemplate>
                                <table style="background: #eee; border: #ccc 1px solid; padding: 10px; width: 85%">
                                    <tr>
                                        <td style="width: 60%">
                                            Car ID:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSelCarID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 60%">
                                            <b>Ad Status:</b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAdStatus" runat="server" Style="font-weight: bold; color: Blue;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Listing Date:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Customer Name:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListCustName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Model Year:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListYear" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--  <tr>
                                        <td colspan="2" style="height: 15px;">
                                            &nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            Make:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListMake" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Model:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListModel" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Mileage:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListMileage" runat="server" CssClass="mileage"></asp:Label>
                                            <asp:Label ID="lblMi" Text="mi" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Asking Price:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblListPrice" runat="server" CssClass="price"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 15px;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td style="width: 50px;">
                    &nbsp;
                </td>
                <td>
                    <div class="wrapper" id="divPhotos" runat="server" style="display: none;">
                        <!-- Vehicle Type Div Start -->
                        <div class="box4">
                            <table style="float: left; width: 350px;">
                                <tr>
                                    <td style="padding-right: 20px; padding-top: 10px;">
                                        <h2>
                                            Upload Car Photos
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
                                            <h5>
                                                (This is your thumb photo)</h5>
                                            <asp:FileUpload ID="flupImage1" runat="server" Style="width: 98%" onchange="CheckExt(this)" />
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
                                        </td>
                                        <td>
                                            <asp:Image ID="Img3" runat="server" CssClass="imgThumb" />
                                            <%-- <asp:Button ID="btnRotate3" runat="server" OnClick="btnRotate3_Click" CssClass="butRotate" />--%>
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
                                            <%-- <asp:Button ID="btnRotate4" runat="server" OnClick="btnRotate4_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate5" runat="server" OnClick="btnRotate5_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate6" runat="server" OnClick="btnRotate6_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate7" runat="server" OnClick="btnRotate7_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate8" runat="server" OnClick="btnRotate8_Click" CssClass="butRotate" />--%>
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
                                            <%-- <asp:Button ID="btnRotate10" runat="server" OnClick="btnRotate10_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate11" runat="server" OnClick="btnRotate11_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate12" runat="server" OnClick="btnRotate12_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate13" runat="server" OnClick="btnRotate13_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate14" runat="server" OnClick="btnRotate14_Click" CssClass="butRotate" />--%>
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
                                            <%-- <asp:Button ID="btnRotate15" runat="server" OnClick="btnRotate15_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate16" runat="server" OnClick="btnRotate16_Click" CssClass="butRotate" />--%>
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
                                            <%-- <asp:Button ID="btnRotate17" runat="server" OnClick="btnRotate17_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate18" runat="server" OnClick="btnRotate18_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate19" runat="server" OnClick="btnRotate19_Click" CssClass="butRotate" />--%>
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
                                            <%--<asp:Button ID="btnRotate20" runat="server" OnClick="btnRotate20_Click" CssClass="butRotate" />--%>
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
                        <%--       <asp:Button ID="btnContinue" runat="server" CssClass="button1" Text="Add photos later"
                            Style="float: right; margin-right: 8px;" />--%>
                        <%-- <input type="button" class="button1" value="Add photos later" style="float: right;
                                        margin-right: 8px;" onclick="window.location.href='PlaceAdbankdetails.aspx'"
                                        id="btnContinue" runat="server" />--%>
                        <%-- <input type="button" class="button1" value="Continue to add your bank details" style="float: right;
                                        margin-right: 8px;" />--%>
                        <asp:Button ID="btnSave" runat="server" CssClass="g-button g-button-submit" Text="Add photos now"
                            Style="float: right; margin-right: 8px;" OnClientClick="return validate()" OnClick="btnSave_Click" />
                        <br />
                        <br />
                        <!-- Vehicle Type Div End -->
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
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
    </form>
</body>
</html>
