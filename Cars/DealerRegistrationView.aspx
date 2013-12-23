<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealerRegistrationView.aspx.cs"
    Inherits="DealerRegistrationView" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
       function isNumberKey(evt)
         {
         debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        function isNumberKeyWithDot(evt)
         {
         debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
                return false;

            return true;
        }
         function isNumberKeyWithDashForZip(evt)
         {
         debugger
         
            var charCode = (evt.which) ? evt.which : event.keyCode         
            if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 45)
                return false;

            return true;
        }
         function isNumberKeyForDt(evt)
              {	
	    
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
                return false;
            return true;
        }
          function isKeyNotAcceptSpace(evt)
          {		    
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode == 32)
                return false;
            return true;
        }
        
        
       

    </script>

    <script type="text/javascript" language="javascript">   
        
      var dtCh = "/";
        var Chktoday = new Date();
        var minYear = Chktoday.getFullYear() - 1;
        var maxYear = Chktoday.getFullYear();

        function isInteger(s) {
            var i;
            for (i = 0; i < s.length; i++) {
                // Check that current character is number.
                var c = s.charAt(i);
                if (((c < "0") || (c > "9"))) return false;
            }
            // All characters are numbers.
            return true;
        }

        function stripCharsInBag(s, bag) {
            var i;
            var returnString = "";
            // Search through string's characters one by one.
            // If character is not in bag, append to returnString.
            for (i = 0; i < s.length; i++) {
                var c = s.charAt(i);
                if (bag.indexOf(c) == -1) returnString += c;
            }
            return returnString;
        }

        function daysInFebruary(year) {
            // February has 29 days in any year evenly divisible by four,
            // EXCEPT for centurial years which are not also divisible by 400.
            return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
        }
        function DaysArray(n) {
            for (var i = 1; i <= n; i++) {
                this[i] = 31
                if (i == 4 || i == 6 || i == 9 || i == 11) { this[i] = 30 }
                if (i == 2) { this[i] = 29 }
            }
            return this
        }

        function isDate(dtStr) {
            var daysInMonth = DaysArray(12)
            var pos1 = dtStr.indexOf(dtCh)
            var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
            var strMonth = dtStr.substring(0, pos1)
            var strDay = dtStr.substring(pos1 + 1, pos2)
            var strYear = dtStr.substring(pos2 + 1)
            strYr = strYear
            if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
            if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
            for (var i = 1; i <= 3; i++) {
                if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
            }
            month = parseInt(strMonth)
            day = parseInt(strDay)
            year = parseInt(strYr)
            if (pos1 == -1 || pos2 == -1) {
                alert("The date format should be : mm/dd/yyyy")
                return false
            }
            if (strMonth.length < 1 || month < 1 || month > 12) {
                alert("Please enter a valid month")
                return false
            }
            if (strDay.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year)) || day > daysInMonth[month]) {
                alert("Please enter a valid day")
                return false
            }

            if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
                //alert("Enter only these years "+minYear+" "+maxYear+" to get data");		
                alert("Please enter a valid year");
                return false
            }
            if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
                alert("Please enter a valid date")
                return false
            }
            return true
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
	    
      function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 

    </script>

    <script type='text/javascript'>
     function PayInfoChanges() {
	     debugger;
	        if(document.getElementById('<%= rdbtnPayPaypal.ClientID%>').checked == true)
            { 
	            if((document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="7")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="8"))
	            {
                    document.getElementById('<%=divTransID.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "block";	               
	                document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "block";	                
                }
                else
                {
                    document.getElementById('<%=divTransID.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "none";
	               
                }
	        }
	        else
	        {	        
	            if((document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="7")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="8"))
	            {
                    document.getElementById('<%=divTransID.ClientID%>').style.display = "block";
	                document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "block";	               
	                document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "block";	                
                }
                else
                {
                    document.getElementById('<%=divTransID.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "none";
	               
                }
            }
            return false;
        }

        function ValidateUpdate() {
            var valid = true;
            if(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")
            {
                if(document.getElementById('<%= rdbtnPayPaypal.ClientID%>').checked == true)
                { 
                     if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                        document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                        alert("Select payment date");                 
                        document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
                        valid = false;            
                         return valid;     
                    }  
                    if (document.getElementById('<%= txtPaymentAmountIn.ClientID%>').value.trim().length < 1)
                    {
                        alert("Please enter amount paid"); 
                        valid=false;
                        document.getElementById('txtPaymentAmountIn').focus();  
                        return valid;               
                    }  
                     if (parseFloat(document.getElementById('<%= txtPaymentAmountIn.ClientID%>').value.trim())!=parseFloat(document.getElementById('<%= hdnPackagePrice.ClientID%>').value))
                    {
                        alert("Amount entered not match with amount need to be paid now"); 
                        valid=false;
                        document.getElementById('txtPaymentAmountIn').focus();  
                        return valid;               
                    }  
                }
                else
                {
                    if (document.getElementById('<%= txtPayTransactionID.ClientID%>').value.trim().length < 1)
                    {
                        alert("Please enter transaction id"); 
                        valid=false;
                        document.getElementById('txtPayTransactionID').focus();  
                        return valid;               
                    }
                    if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                        document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                        alert("Select payment date");                 
                        document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
                        valid = false;            
                         return valid;     
                    }  
                    if (document.getElementById('<%= txtPaymentAmountIn.ClientID%>').value.trim().length < 1)
                    {
                        alert("Please enter amount paid"); 
                        valid=false;
                        document.getElementById('txtPaymentAmountIn').focus();  
                        return valid;               
                    }  
                     if (parseFloat(document.getElementById('<%= txtPaymentAmountIn.ClientID%>').value.trim())!=parseFloat(document.getElementById('<%= hdnPackagePrice.ClientID%>').value))
                    {
                        alert("Amount entered not match with amount need to be paid now"); 
                        valid=false;
                        document.getElementById('txtPaymentAmountIn').focus();  
                        return valid;               
                    }  
                }               
           }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdatePane1BtnUpdate"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtpnlUpdatingPayInfo"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="headder">
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;
        </div>
    </div>
    <div class="main">
        <div class="clear">
            &nbsp;</div>
        <table style="width: 750px; margin-top: 30px;">
            <tr>
                <td colspan="2">
                    <div style="width: 350px; float: right; margin-right: 0;">
                        <asp:UpdatePanel ID="UpdatePane1BtnUpdate" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnClose" runat="server" CssClass="g-button g-button-submit floatR"
                                    Text="Close" OnClick="btnClose_Click" />
                                <asp:Button ID="btnReset" runat="server" CssClass="g-button g-button-submit floatR"
                                    Text="Edit" Style="margin-top: 0" OnClick="btnReset_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 360px;">
                    <div class="box1" style="width: 350px;">
                        <h3>
                            Sale Information</h3>
                        <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                            <tr>
                                <td style="width: 110px">
                                    <h4 class="h43">
                                        Sales Date<span class="star">*</span></h4>
                                </td>
                                <td>
                                    <asp:Label ID="lblSaleDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4 class="h43">
                                        Sales Agent<span class="star">*</span></h4>
                                </td>
                                <td>
                                    <asp:Label ID="lblSaleAgent" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4 class="h43">
                                        Verifier</h4>
                                </td>
                                <td>
                                    <asp:Label ID="lblSaleVerifier" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4 class="h43">
                                        Package<span class="star">*</span></h4>
                                </td>
                                <td>
                                    <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                    <asp:HiddenField ID="hdnPackagePrice" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:UpdatePanel ID="updtpnlRegInfo" runat="server">
                        <ContentTemplate>
                            <div class="box1" style="width: 350px;">
                                <h3>
                                    Registration Details</h3>
                                <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                User ID<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblUserID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Dealer ID<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDealerID" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Email<span class="star">*</span>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Password<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Customer name<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Business name<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBusinessName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Alt email</h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegAltEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Phone number<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegPhoneNumber" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Alt Phone number</h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegAltPhoneNumber" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Address<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegAddress" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                City<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegCity" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                State<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegState" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Zip<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRegZip" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdtpnlSellerInfo" runat="server">
                        <ContentTemplate>
                            <div class="box1">
                                <h3>
                                    Seller Info To Display In The Ad
                                </h3>
                                <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Business name<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSellerBusinessName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Phone number<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSellerPhone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Email<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSellerEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                City<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSellerCity" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                State<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSellerState" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Zip<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblSellerZip" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-bottom: 10px;">
                    <div class="box1">
                        <h3>
                            <div style="float: left; width: 90%;">
                                User Special Notes</div>
                        </h3>
                        <asp:UpdatePanel ID="updtpnlSpecialNotes" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%; margin-left: 5px;" cellpadding='1' cellspacing='1'>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtSpecialNotes" runat="server" CssClass="textarea" ReadOnly="true"
                                                Style="width: 98%; padding: 3px; margin-top: 6px; height: 60px; background: #eee"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-bottom: 10px;">
                    <div class="box1">
                        <h3>
                            <div style="float: left; width: 90%;">
                                User Notes</div>
                        </h3>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%; margin-left: 5px;" cellpadding='1' cellspacing='1'>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtUserNotes" runat="server" ReadOnly="true" CssClass="textarea"
                                                Style="width: 98%; padding: 3px; margin-top: 6px; height: 60px; background: #eee"
                                                TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="position: relative; z-index: 9; height: 455px; vertical-align: top" colspan="2">
                    <%--PaymentInfo--%>
                    <div class="box1">
                        <h3>
                            Payment Details</h3>
                        <table>
                            <tr>
                                <td colspan="5" style="padding-top: 5px;">
                                    <div class="hidden Payment-Details">
                                        <!-- <legend>Payment Details</legend>   -->
                                        <table style="width: 99%; position: relative; z-index: 10; margin: 0">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <h4 class="h4 noB">
                                                                <strong style="width: 70px">Pay method:</strong><span style="font-weight: bold">
                                                                    <asp:RadioButton ID="rdbtnPayVisa" CssClass="noLM" Text="Visa" Checked="true" GroupName="PayType"
                                                                        runat="server" Enabled="false" />
                                                                    <asp:RadioButton ID="rdbtnPayMasterCard" CssClass="noLM" Text="Mastercard" GroupName="PayType"
                                                                        runat="server" Enabled="false" />
                                                                    <asp:RadioButton ID="rdbtnPayDiscover" CssClass="noLM" Text="Discover" GroupName="PayType"
                                                                        runat="server" Enabled="false" />
                                                                    <asp:RadioButton ID="rdbtnPayAmex" CssClass="noLM" Text="Amex" GroupName="PayType"
                                                                        runat="server" Enabled="false" />
                                                                    <asp:RadioButton ID="rdbtnPayPaypal" CssClass="noLM" Text="Paypal" GroupName="PayType"
                                                                        runat="server" Enabled="false" />
                                                                    <asp:RadioButton ID="rdbtnPayCheck" CssClass="noLM" Text="Check" GroupName="PayType"
                                                                        runat="server" Enabled="false" />
                                                            </h4>
                                                            <div class="h4 noB" style="left: 878px; top: -29px; display: inline-block; z-index: 11;
                                                                width: 200px; height: auto; padding: 0;">
                                                                <%--  <div class="date2">
                                                        <strong>Post date</strong></div>--%>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <!-- Credit Card Start  -->
                                                            <div id="divcard" runat="server">
                                                                <table border="0" cellpadding="1" cellspacing="1" style="width: 55%; margin: 0 30px 0 0;
                                                                    float: left;">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <h5 style="font-size: 15px; margin: 0 0 10px 0; float: left; width: 130px;">
                                                                                Card Details</h5>
                                                                            <h5 style="font-size: 12px; font-weight: normal; margin: 0; display: inline-block">
                                                                            </h5>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 155px;">
                                                                            <span class="star" style="color: Red">*</span><strong>Card Holder First Name</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:HiddenField ID="CardType" runat="server" />
                                                                            <asp:TextBox ID="txtCardholderName" runat="server" MaxLength="25" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong>Last Name</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCardholderLastName" runat="server" MaxLength="25" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong>Credit Card #</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="CardNumber" MaxLength="16" onkeypress="return isNumberKey(event)"
                                                                                onblur="return CreditCardOnblur();" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong>Expiry Date</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ExpMon" Style="width: 100px;" runat="server" Enabled="false">
                                                                                <asp:ListItem Value="0" Text="Select Month"></asp:ListItem>
                                                                                <asp:ListItem Value="01" Text="01"></asp:ListItem>
                                                                                <asp:ListItem Value="02" Text="02"></asp:ListItem>
                                                                                <asp:ListItem Value="03" Text="03"></asp:ListItem>
                                                                                <asp:ListItem Value="04" Text="04"></asp:ListItem>
                                                                                <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                                                                <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                                                                <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                                                                <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                                                                <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                                                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                                                                <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                                                                <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            -
                                                                            <asp:DropDownList ID="CCExpiresYear" Style="width: 115px" runat="server" Enabled="false">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong style="width: 40px">CVV#</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="cvv" MaxLength="4" runat="server" onkeypress="return isNumberKey(event)"
                                                                                onblur="return CVVOnblur();" Style="width: 60px;" Enabled="false" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 40%; margin: 30px 0 0 0;
                                                                    float: right">
                                                                    <tr>
                                                                        <td colspan="2">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 85px">
                                                                            <span class="star" style="color: Red">*</span><strong style="width: 45px">Address</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtbillingaddress" runat="server" MaxLength="40" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong style="width: 40px">City</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtbillingcity" runat="server" MaxLength="40" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <table style="border-collapse: collapse; vertical-align: middle">
                                                                                <tr>
                                                                                    <td style="width: 105px; vertical-align: middle">
                                                                                        <span class="star" style="color: Red">*</span><strong style="width: 45px">State</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlbillingstate" runat="server" Style="width: 100px" Enabled="false">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 20px;">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td style="width: 30px; vertical-align: middle">
                                                                                        <span class="star" style="color: Red">*</span><strong style="width: 45px">ZIP</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtbillingzip" runat="server" Style="width: 74px" MaxLength="5"
                                                                                            class="sample4" onkeypress="return isNumberKey(event)" onblur="return billingZipOnblur();"
                                                                                            Enabled="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <!-- Credit Card End  -->
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                            <!-- check Start  -->
                                                            <div id="divcheck" runat="server" style="display: none;">
                                                                <table border="0" cellpadding="4" cellspacing="4" style="width: 98%; margin: 0;">
                                                                    <tr>
                                                                        <td>
                                                                            <h5 style="display: inline-block; margin: 0; font-size: 15px;">
                                                                                Check Details</h5>
                                                                            <h5 style="font-size: 12px; font-weight: normal; margin: 0; display: inline-block">
                                                                            </h5>
                                                                            <table style="width: 80%;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table style="width100%; border-collapse: collapse">
                                                                                            <tr>
                                                                                                <td style="width: 147px;">
                                                                                                    <span class="star" style="color: Red">*</span><strong style="width: 125px">Account holder
                                                                                                        name</strong>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtCustNameForCheck" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        <table style="width100%; border-collapse: collapse">
                                                                                            <tr>
                                                                                                <td style="width: 80px;">
                                                                                                    <span class="star" style="color: Red">*</span><strong style="width: 60px">Account #</strong>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtAccNumberForCheck" runat="server" MaxLength="20" Enabled="false"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table style="width100%; border-collapse: collapse">
                                                                                            <tr>
                                                                                                <td style="width: 147px;">
                                                                                                    <span class="star" style="color: #fff">*</span><strong style="width: 67px">Bank name:</strong>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtBankNameForCheck" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        <table style="width100%; border-collapse: collapse">
                                                                                            <tr>
                                                                                                <td style="width: 80px;">
                                                                                                    <span class="star" style="color: Red">*</span><strong style="width: 60px">Routing #</strong>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtRoutingNumberForCheck" runat="server" MaxLength="9" Enabled="false"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table style="width100%; border-collapse: collapse">
                                                                                            <tr>
                                                                                                <td style="width: 147px;">
                                                                                                    <span class="star" style="color: Red">*</span><strong style="width: 76px">Account type</strong>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlAccType" runat="server" Enabled="false">
                                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                                        <asp:ListItem Value="1">CHECKING</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">SAVINGS</asp:ListItem>
                                                                                                        <asp:ListItem Value="3">BUSINESSCHECKING</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <div style="width: 45%; display: inline-block; float: left; margin-right: 10px;">
                                                                            </div>
                                                                            <div style="width: 45%; display: inline-block; float: left">
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <!-- check End  -->
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                            <!-- paypal Start  -->
                                                            <div id="divpaypal" runat="server" style="display: none;">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <h5 style="display: inline-block; margin: 0; font-size: 15px;">
                                                                                Paypal Details</h5>
                                                                            <div id="Div1" runat="server" style="width: 80%;">
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table style="width100%; border-collapse: collapse">
                                                                                                <tr>
                                                                                                    <td style="width: 150px">
                                                                                                        <span class="star" style="color: Red">*</span><strong style="width: 100px">Payment trans
                                                                                                            ID:</strong>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtPaytransID" runat="server" MaxLength="30" Enabled="false"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <%-- <input type="text" style="width: 245px" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <table style="width100%; border-collapse: collapse">
                                                                                                <tr>
                                                                                                    <td style="width: 150px">
                                                                                                        <span class="star" style="color: Red">*</span><strong style="width: 140px">Paypal account
                                                                                                            email:</strong>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtpayPalEmailAccount" runat="server" onblur="return PaypalEmailblur();"
                                                                                                            Enabled="false"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <%-- <input type="text" style="width: 245px" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div class="clear">
                                                                                &nbsp;</div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <!-- paypal End  -->
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                            <!-- Post Date End  -->
                                                            <!-- Post Date End  -->
                                                            <div class="clear">
                                                                &nbsp;</div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="630px">
                                                        <tr>
                                                            <td style="width: 179px; vertical-align: middle">
                                                                <span class="star" style="color: Red">*</span><strong style="font-size: 15px;">Voice
                                                                    file confirmation #:</strong>
                                                                <%-- <input type="text" style="width: 245px" />--%>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblVoiceFile" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="padding: 0; width: 10px;">
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 155px; vertical-align: middle">
                                                                <span class="star" style="color: Red">*</span><strong style="width: 150px; font-size: 15px;">
                                                                    Voice file Location:</strong>
                                                                <%-- <input type="text" style="width: 245px" />--%>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblVoiceFileLocation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 50%; float: left;">
                                                        <tr>
                                                            <td style="width: 52%;">
                                                                <b>Payment status</b>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPaymentStatus" runat="server" onchange="return PayInfoChanges();">
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Paid</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 45%;">
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="updtpnlUpdatingPayInfo" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Button ID="btnUpdate" OnClientClick="return ValidateUpdate();" runat="server"
                                                                            Text="Update" CssClass="g-button g-button-submit" Style="float: left; margin: 0 10px 0 0;"
                                                                            OnClick="btnPayUpdate_Click" />&nbsp;&nbsp;
                                                                        <asp:Button ID="btnCCProcess" runat="server" Text="Process" CssClass="g-button g-button-submit"
                                                                            Style="float: left; margin: 0 10px 0 0;" OnClick="btnCCProcess_Click" />
                                                                        <asp:Button ID="btnCheckProcess" runat="server" Text="Process" CssClass="g-button g-button-submit"
                                                                            Style="float: left; margin: 0 10px 0 0;" OnClick="btnCheckProcess_Click" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="divTransID" runat="server" style="display: none;">
                                                    <!-- Credit Card Start  -->
                                                    <table style="width: 50%;">
                                                        <tr>
                                                            <td style="width: 52%;">
                                                                <b>Transaction ID</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPayTransactionID" runat="server" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="divPaymentDate" runat="server" style="display: none;">
                                                    <table style="width: 50%;">
                                                        <tr>
                                                            <td style="width: 52%;">
                                                                <b>Payment Date</b>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPaymentDate" runat="server" CssClass="input1" Style="width: auto">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="divPaymentAmount" runat="server" style="display: none;">
                                                    <table style="width: 50%;">
                                                        <tr>
                                                            <td style="width: 52%;">
                                                                <b>Amount</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPaymentAmountIn" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%--PaymentInfo End--%>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
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
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpealteruserUpdated" runat="server" PopupControlID="AlertUserUpdated"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuserUpdated">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuserUpdated" runat="server" />
    <div id="AlertUserUpdated" class="alert" style="display: none">
        <h4 id="H3">
            Alert
            <asp:Button ID="BtnClsUpdated" class="cls" runat="server" Text="" BorderWidth="0"
                OnClick="BtnClsUpdated_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data" style="height: auto;">
            <p>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrUpdated" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnYesUpdated" class="btn" runat="server" Text="Ok" OnClick="BtnClsUpdated_Click" />
        </div>
    </div>
    </form>
</body>
</html>
