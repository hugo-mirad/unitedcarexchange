﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewTruckVehicle.aspx.cs"
    Inherits="AddNewTruckVehicle" ValidateRequest="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">        window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    
     function Validate() {
     debugger;
            var valid = true;     
             
           //var string = document.getElementById('<%=ddlPackage.ClientID%>').value;
          	       
	       //alert('Sele: '+selectedPack+'    Enter:'+EnterAmt);
	        if(document.getElementById('<%= ddlSaleDate.ClientID%>').value == "0") {
                document.getElementById('<%= ddlSaleDate.ClientID%>').focus();
                alert("Select sale date");                 
                document.getElementById('<%=ddlSaleDate.ClientID%>').focus()
                valid = false;            
                 return valid;     
            }  
            if(document.getElementById('<%= ddlSalesAgent.ClientID%>').value == "0") {
                document.getElementById('<%= ddlSalesAgent.ClientID%>').focus();
                alert("Select sales agent");                 
                document.getElementById('<%=ddlSalesAgent.ClientID%>').focus()
                valid = false;            
                 return valid;     
            }  
            if(document.getElementById('<%= ddlPackage.ClientID%>').value == "0") {
                document.getElementById('<%= ddlPackage.ClientID%>').focus();
                alert("Select package");                 
                document.getElementById('<%=ddlPackage.ClientID%>').focus()
                valid = false;            
                 return valid;     
            }              
            
         
        
             if(document.getElementById('<%= txtLoginEmail.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtLoginEmail.ClientID%>').focus();
                alert("Enter email");
                 document.getElementById('<%=txtLoginEmail.ClientID%>').value = ""
                document.getElementById('<%=txtLoginEmail.ClientID%>').focus()
                valid = false;            
                return valid;     
            }            
             if ((document.getElementById('<%=txtLoginEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtLoginEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtLoginEmail.ClientID%>').value = ""
                document.getElementById('<%=txtLoginEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
            }            
             if(document.getElementById('<%= txtLoginPassword.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtLoginPassword.ClientID%>').focus();
                document.getElementById('<%=txtLoginPassword.ClientID%>').value = "";
                alert("Enter password");
                valid = false;            
                 return valid;     
            }
             if((document.getElementById('<%= txtLoginPassword.ClientID%>').value.length > 0) && (document.getElementById('<%= txtLoginPassword.ClientID%>').value.length < 5))
            {
                document.getElementById('<%= txtLoginPassword.ClientID%>').focus();
                document.getElementById('<%=txtLoginPassword.ClientID%>').value = "";
                alert("Password length must be 5 characters");
                valid = false;            
                 return valid;     
            }                
            if (document.getElementById('<%= txtRegName.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtRegName.ClientID%>').focus();
                alert("Enter customer name");
                document.getElementById('<%=txtRegName.ClientID%>').value = ""
                document.getElementById('<%=txtRegName.ClientID%>').focus()                
                valid = false;
                 return valid;     
            }    
            
              if ((document.getElementById('<%=txtRegAltEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtRegAltEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtRegAltEmail.ClientID%>').value = ""
                document.getElementById('<%=txtRegAltEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
            }         
             if((document.getElementById('<%= txtRegPhNo.ClientID%>').value.length > 0) && (document.getElementById('<%= txtRegPhNo.ClientID%>').value.length < 10)) {
                document.getElementById('<%= txtRegPhNo.ClientID%>').focus();
                document.getElementById('<%=txtRegPhNo.ClientID%>').value = "";
                alert("Enter valid phone number");
                valid = false; 
                 return valid;                
            
            }   
            
             if( (document.getElementById('<%=txtRegAltPhoneNum.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtRegAltPhoneNum.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtRegAltPhoneNum.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtRegAltPhoneNum.ClientID%>').value = ""
                document.getElementById('<%=txtRegAltPhoneNum.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }   
                     
            if(document.getElementById('<%=txtregZip.ClientID%>').value.length > 0)
             {
                  var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtregZip.ClientID%>').value);             
                   if (isValid == false)
                   {
                         document.getElementById('<%= txtregZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('<%=txtregZip.ClientID%>').value = ""
                    document.getElementById('<%=txtregZip.ClientID%>').focus()
                    valid = false;  
                     return valid;      
                   }                                   
             }  
                             
              if (document.getElementById('<%=ddlYear.ClientID%>').value =="0")
            {
                alert('Please select year')
                valid=false;
                document.getElementById('ddlYear').focus();  
                return valid;
            } 
             if(document.getElementById('<%=ddlType.ClientID%>').value =="0")
            {
                alert("Please select type"); 
                valid=false;
                document.getElementById('ddlType').focus();
                return valid;               
            } 
            if(document.getElementById('<%=ddlMake.ClientID%>').value =="0")
            {
                alert("Please select make"); 
                valid=false;
                document.getElementById('ddlMake').focus();  
                return valid;               
            }             
            
          
             if( (document.getElementById('<%=txtCustPhoneNumber.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtCustPhoneNumber.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtCustPhoneNumber.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtCustPhoneNumber.ClientID%>').value = ""
                document.getElementById('<%=txtCustPhoneNumber.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }               
             
              
             if( (document.getElementById('<%=txtCustAltNumber.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtCustAltNumber.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtCustAltNumber.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtCustAltNumber.ClientID%>').value = ""
                document.getElementById('<%=txtCustAltNumber.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }  
              if ((document.getElementById('<%=txtSellerEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtSellerEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtSellerEmail.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
            }             
            
            if(document.getElementById('<%=txtZip.ClientID%>').value.length > 0)
             {
                 var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtZip.ClientID%>').value);
                   if (isValid == false)
                   {
                     document.getElementById('<%= txtZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('<%=txtZip.ClientID%>').value = ""
                    document.getElementById('<%=txtZip.ClientID%>').focus()
                    valid = false;  
                     return valid;      
                   }                    
             }            
                     
             
             
            if(document.getElementById('<%=ddlPayStatus.ClientID%>').value =="2") 
            {
           
                if((document.getElementById('<%=ddlAdStatus.ClientID%>').value =="1") && (document.getElementById('<%=ddlPayStatus.ClientID%>').value !="2"))
                {
                   if(document.getElementById('<%=ddlPackage.ClientID%>').value !="1")
                   {
                        alert("Ad is active only when payment status is paid"); 
                        valid=false;
                        document.getElementById('ddlAdStatus').focus();  
                        return valid;   
                   }            
                }  
                
                 if(document.getElementById('<%=ddlPackage.ClientID%>').value !="1")
                   {
                    if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                        document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                        alert("Select payment date");                 
                        document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
                        valid = false;            
                         return valid;     
                    }  
                  }
                  
                   if(document.getElementById('<%= txtPayConfirmNum.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtPayConfirmNum.ClientID%>').focus();
                    alert("Enter payment Trans ID");
                     document.getElementById('<%=txtPayConfirmNum.ClientID%>').value = ""
                    document.getElementById('<%=txtPayConfirmNum.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                }  
                
                 if(document.getElementById('<%= txtVoiceFileName.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtVoiceFileName.ClientID%>').focus();
                    alert("Enter voice file confirmation #");
                     document.getElementById('<%=txtVoiceFileName.ClientID%>').value = ""
                    document.getElementById('<%=txtVoiceFileName.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                }  
                  
                  
                var string = $('#ddlPackage option:selected').text();
	            var p =string.split('$');
	            var pp = p[1].split(')');
	            //alert(pp[0]);
	            //pp[0] = parseInt(pp[0]);
	            pp[0] = parseFloat(pp[0]);
	            var selectedPack = pp[0].toFixed(2);
    	        
    	        
	            var EnterAmt = parseFloat($('#txtPayAmount').val());
    	       
	          if(document.getElementById('<%= txtPayAmount.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtPayAmount.ClientID%>').focus();
                    alert("Enter amount");
                     document.getElementById('<%=txtPayAmount.ClientID%>').value = ""
                    document.getElementById('<%=txtPayAmount.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                }    
    	       
	           if(EnterAmt != selectedPack){
	               document.getElementById('<%= txtPayAmount.ClientID%>').focus();
                    alert("Amount doesn't match with selected package price");
                     document.getElementById('<%=txtPayAmount.ClientID%>').value = ""
                    document.getElementById('<%=txtPayAmount.ClientID%>').focus()
                    valid = false; 
                    return valid;     
	           }            
           }        
           
                 
            if(document.getElementById('<%=ddlPayStatus.ClientID%>').value =="5") 
            {
           
                if((document.getElementById('<%=ddlAdStatus.ClientID%>').value =="1") && (document.getElementById('<%=ddlPayStatus.ClientID%>').value !="2"))
                {
                   if(document.getElementById('<%=ddlPackage.ClientID%>').value !="1")
                   {
                        alert("Ad is active only when payment status is paid"); 
                        valid=false;
                        document.getElementById('ddlAdStatus').focus();  
                        return valid;   
                   }            
                }  
                
                 if(document.getElementById('<%=ddlPackage.ClientID%>').value !="1")
                   {
                    if(document.getElementById('<%= ddlPDDate.ClientID%>').value == "0") {
                        document.getElementById('<%= ddlPDDate.ClientID%>').focus();
                        alert("Select payment date");                 
                        document.getElementById('<%=ddlPDDate.ClientID%>').focus()
                        valid = false;            
                         return valid;     
                    }  
                  }                 
                  
                  
                var string = $('#ddlPackage option:selected').text();
	            var p =string.split('$');
	            var pp = p[1].split(')');
	            //alert(pp[0]);
	            //pp[0] = parseInt(pp[0]);
	            pp[0] = parseFloat(pp[0]);
	            var selectedPack = pp[0].toFixed(2);
    	        
    	        
	            var EnterAmt = parseFloat($('#txtPayAmount').val());
    	       
	          if(document.getElementById('<%= txtPayAmount.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtPayAmount.ClientID%>').focus();
                    alert("Enter amount");
                     document.getElementById('<%=txtPayAmount.ClientID%>').value = ""
                    document.getElementById('<%=txtPayAmount.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                }    
    	       
	           if(EnterAmt != selectedPack){
	               document.getElementById('<%= txtPayAmount.ClientID%>').focus();
                    alert("Amount doesn't match with selected package price");
                     document.getElementById('<%=txtPayAmount.ClientID%>').value = ""
                    document.getElementById('<%=txtPayAmount.ClientID%>').focus()
                    valid = false; 
                    return valid;     
	           }            
           }    
              
              
         return valid;
      }
           
     
    </script>

    <script type="text/javascript" language="javascript">
        
          
        function CopySellerInfo()
        {
         
            var valid=true;   
             if(document.getElementById('<%= txtLoginEmail.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtLoginEmail.ClientID%>').focus();
                alert("Enter email");
                 document.getElementById('<%=txtLoginEmail.ClientID%>').value = ""
                document.getElementById('<%=txtLoginEmail.ClientID%>').focus()
                valid = false;            
                return valid;     
             }            
            else if ((document.getElementById('<%=txtLoginEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtLoginEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtLoginEmail.ClientID%>').value = ""
                document.getElementById('<%=txtLoginEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
            }      
             else if (document.getElementById('<%= txtRegName.ClientID%>').value.length < 1)
              {
                document.getElementById('<%= txtRegName.ClientID%>').focus();
                alert("Enter customer name");
                document.getElementById('<%=txtRegName.ClientID%>').value = ""
                document.getElementById('<%=txtRegName.ClientID%>').focus()                
                valid = false;
                 return valid;     
              }
              else
              {
                
                 document.getElementById('<%= txtCustPhoneNumber.ClientID%>').value =  document.getElementById('<%= txtRegPhNo.ClientID%>').value;
                 document.getElementById('<%= txtSellerEmail.ClientID%>').value =  document.getElementById('<%= txtLoginEmail.ClientID%>').value;

                 document.getElementById('<%= txtCity.ClientID%>').value =  document.getElementById('<%= txtRegCity.ClientID%>').value;
                 document.getElementById('<%= txtZip.ClientID%>').value =  document.getElementById('<%= txtregZip.ClientID%>').value;
                 document.getElementById('<%= ddlLocationState.ClientID%>').value =  document.getElementById('<%= ddlRegState.ClientID%>').value;                 
                 document.getElementById('<%= txtCustAltNumber.ClientID%>').value =  document.getElementById('<%= txtRegAltPhoneNum.ClientID%>').value;                 
                                  
              }             
              return valid;      
        } 
          
      function ChangeValuesHidden()
      {
       document.getElementById("<%=hdnChange.ClientID%>").value ="1";
//       document.getElementById("<%=btnUpdate.ClientID%>").disabled  = false;
      } 
       function ChangeValues()
       {
         var hidden = document.getElementById("<%=hdnChange.ClientID%>").value ;
         if( hidden == '1')
         {
           var answer = confirm("If you move out of this page, changes will be permanently lost. Are you sure you want to move out of this page?")
           if (answer)
           {
              return true;
//              window.location.href = "CustomerView.aspx ";  
           }
           else           
           {
              return false;
           }
         }
       }    
          
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

    </script>

    <script type="text/javascript" language="javascript">
                 
        function ValidateVehicleType1()
        {
         
            var valid=true;                
    
             if(document.getElementById('<%=txtNewIntNotes.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%= txtNewIntNotes.ClientID%>').focus();
                alert("Please enter notes to update");
                 document.getElementById('<%=txtNewIntNotes.ClientID%>').value = ""
                document.getElementById('<%=txtNewIntNotes.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }                     
            
        
          }       
    </script>

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
        
      	    
	    
	});   
	    
      function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 

    </script>

    <style type="text/css">
        .style2
        {
            height: 84px;
        }
    </style>
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
                    <h4>
                    </h4>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePane1BtnSalesUpdate"
        DisplayAfter="0">
        <ProgressTemplate>
            <div id="spinner">
                <h4>
                    <div>
                        Processing
                        <img src="images/loading.gif" />
                    </div>
                    <h4>
                    </h4>
                </h4>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="headder">
        <table style="width: 100%">
            <td style="width: 250px">
                <asp:ImageButton ID="ImgBtnLogo" runat="server" ImageUrl="~/images/logo2.png" OnClick="ImgBtnLogo_Click"
                    OnClientClick="return ChangeValues();" />
            </td>
            <td>
                <h1 class="h11">
                    Smartz Customer Service System</h1>
            </td>
            <td style="width: 250px">
                <div class="loginStat">
                    Welcome &nbsp;<asp:Label ID="lblUserName" runat="server" Visible="false"></asp:Label>
                    <br />
                    <asp:LinkButton ID="lnkbtnHome" runat="server" Text="Home" class="home" OnClientClick="return ChangeValues();"
                        OnClick="lnkbtnHome_Click"></asp:LinkButton>
                    &nbsp; |&nbsp;&nbsp;<asp:LinkButton ID="lnkbtnSearch" runat="server" Text="Search"
                        OnClientClick="return ChangeValues();" OnClick="lnkbtnSearch_Click"></asp:LinkButton>
                    &nbsp; | &nbsp;<asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false"
                        OnClick="lnkBtnLogout_Click" OnClientClick="return ChangeValues();"></asp:LinkButton></div>
            </td>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnChange" runat="server" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="main">
        <h1 class="h1">
            New Customer Data
            <div style="width: 400px; float: right; margin-right: 0;">
                <asp:UpdatePanel ID="UpdatePane1BtnSalesUpdate" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnReset" runat="server" CssClass="g-button g-button-submit" Text="Reset"
                            OnClick="btnReset_Click" OnClientClick="return ChangeValues();" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="g-button g-button-submit" Text="Save"
                            OnClientClick="return Validate();" OnClick="btnUpdate_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </h1>
        <div class="clear">
            &nbsp;</div>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 90%">
            <tr>
                <td style="width: 300px; vertical-align: top">
                    <table style="width: 300px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan='2'>
                                <div class="box1">
                                    <h3>
                                        Sale Information</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td style="width: 100px;">
                                                <h4 class="h43">
                                                    Sales Date<span class="star">*</span></h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSaleDate" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Sales Agent<span class="star">*</span></h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSalesAgent" runat="server" onchange="ChangeValuesHidden()"
                                                    CssClass="input1">
                                                </asp:DropDownList>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Verifier</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlVerifier" runat="server" onchange="ChangeValuesHidden()"
                                                    CssClass="input1">
                                                </asp:DropDownList>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Package<span class="star">*</span></h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlPackage" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2'>
                                <div class="box1">
                                    <h3>
                                        Customer Login Details</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td style="width: 110px">
                                                <h4 class="h43">
                                                    Email<span class="star">*</span></h4>
                                            </td>
                                            <td>
                                                <%-- <input type="text" class="input3" />--%>
                                                <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="input3" MaxLength="40" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Password<span class="star">*</span></h4>
                                            </td>
                                            <td>
                                                <%--<input type="text" class="input3" />--%>
                                                <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="input3" MaxLength="25"
                                                    onkeyup="return ChangeValuesHidden()" onkeypress="return isKeyNotAcceptSpace(event);"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2' style="height: 50px; vertical-align: top; padding-top: 270px;">
                                <div class="box1 wid">
                                    <h3>
                                        Internal Notes</h3>
                                    <asp:UpdatePanel ID="UpdatePane1BtnUpdate" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='1'>
                                                <tr>
                                                    <td class="style2">
                                                        <asp:TextBox ID="txtNewIntNotes" runat="server" Style="width: 98%; padding: 3px;
                                                            margin-top: 6px; height: 60px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        <div class="clear">
                                                            &nbsp;</div>
                                                        <div style="width: 87px; text-align: center; margin: 0 auto">
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td style="width: 300px; vertical-align: top">
                    <table style="width: 300px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan='2'>
                                <div class="box1">
                                    <h3>
                                        Payment Details</h3>
                                    <asp:UpdatePanel ID="updtpnlPaymentDetails" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 99%; margin-left: 5px; height: 168px;" cellpadding='1' cellspacing='0'>
                                                <tr style="height: 23px; overflow: hidden;">
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Payment Status</h4>
                                                    </td>
                                                    <td>
                                                        <%--<input type="text" class="input3" />--%>
                                                        <asp:DropDownList ID="ddlPayStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()"
                                                            OnSelectedIndexChanged="ddlPayStatus_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="1">Pending</asp:ListItem>
                                                            <asp:ListItem Value="5">Preliminary</asp:ListItem>
                                                            <asp:ListItem Value="2">Paid</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan='2'>
                                                        <table style="width: 100%; display: none" cellpadding='0' cellspacing='0' id="tblPaymentDetails"
                                                            runat="server">
                                                            <tr id="trPayMethod" runat="server">
                                                                <td style="width: 110px; padding-bottom: 0; margin-bottom: 0">
                                                                    <h4 class="h43">
                                                                        Payment Method</h4>
                                                                </td>
                                                                <td style="width: 178px;">
                                                                    <%--  <input type="text" class="input3" />--%>
                                                                    <asp:DropDownList ID="ddlPayMethod" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0;">
                                                                    <table style="width: 100%" id="trPayDate" runat="server" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 110px;">
                                                                                <h4 class="h43">
                                                                                    Payment Date</h4>
                                                                            </td>
                                                                            <td style="width: 178px;">
                                                                                <asp:DropDownList ID="ddlPaymentDate" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0;">
                                                                    <table style="width: 100%" id="trPayConfirm" runat="server" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 110px;">
                                                                                <h4 class="h43">
                                                                                    Payment Trans ID</h4>
                                                                            </td>
                                                                            <td style="width: 178px">
                                                                                <asp:TextBox ID="txtPayConfirmNum" runat="server" CssClass="input3" MaxLength="20"
                                                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0;">
                                                                    <table style="width: 100%" id="tblVoiceFile" runat="server" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 110px;">
                                                                                <h4 class="h43">
                                                                                    Voice file confirmation #</h4>
                                                                            </td>
                                                                            <td style="width: 178px">
                                                                                <%--  <input type="text" class="input3" />--%>
                                                                                <asp:TextBox ID="txtVoiceFileName" runat="server" CssClass="input3" MaxLength="20"
                                                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="padding: 0;">
                                                                    <table id="trPDDate" runat="server" style="display: none; width: 100%" cellpadding="0"
                                                                        cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 110px;">
                                                                                <h4 class="h43">
                                                                                    Payment Date</h4>
                                                                            </td>
                                                                            <td style="width: 178px;">
                                                                                <%--  <input type="text" class="input3" />--%>
                                                                                <asp:DropDownList ID="ddlPDDate" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr id="trPayAmount" runat="server">
                                                                <td>
                                                                    <h4 class="h43">
                                                                        Amount</h4>
                                                                </td>
                                                                <td>
                                                                    <%--  <input type="text" class="input3" />--%>
                                                                    <asp:TextBox ID="txtPayAmount" runat="server" CssClass="input3" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                        onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr id="trAdStatus" runat="server">
                                                                <td>
                                                                    <h4 class="h43">
                                                                        Ad Status</h4>
                                                                </td>
                                                                <td>
                                                                    <%--<input type="text" class="input3" />--%>
                                                                    <asp:DropDownList ID="ddlAdStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()"
                                                                        OnSelectedIndexChanged="ddlAdStatus_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                                                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table style="width: 100%; display: none" cellpadding='0' cellspacing='0' id="trListingStatus"
                                                            runat="server">
                                                            <tr>
                                                                <td style="width: 110px;">
                                                                    <h4 class="h43">
                                                                        Listing Status</h4>
                                                                </td>
                                                                <td style="width: 178px;">
                                                                    <%--<input type="text" class="input3" />--%>
                                                                    <asp:DropDownList ID="ddlListingStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                        <asp:ListItem Value="2">Preliminary</asp:ListItem>
                                                                        <asp:ListItem Value="3">Withdraw</asp:ListItem>
                                                                        <asp:ListItem Value="4">Sold</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2' style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2'>
                                <div class="box1">
                                    <h3>
                                        Registration Details</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td style="width: 110px">
                                                <h4 class="h43">
                                                    Customer name<span class="star">*</span></h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegName" runat="server" CssClass="input3" MaxLength="30" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px">
                                                <h4 class="h43">
                                                    Business name</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegBusinessName" runat="server" CssClass="input3" MaxLength="30"
                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px">
                                                <h4 class="h43">
                                                    Alt email</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegAltEmail" runat="server" CssClass="input3" MaxLength="30"
                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Phone number</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegPhNo" CssClass="input3 number" MaxLength="10" runat="server"
                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                <%--<input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Alt Phone number</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegAltPhoneNum" CssClass="input3 number" MaxLength="10" runat="server"
                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                <%--<input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Address</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegAddress" runat="server" CssClass="input3" MaxLength="50" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    City</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegCity" runat="server" CssClass="input3" MaxLength="25" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    State</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlRegState" runat="server" CssClass="input1" Width="100px"
                                                    onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                                <%--  <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Zip</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtregZip" runat="server" CssClass="input3" MaxLength="10" Width="100px"
                                                    onkeyup="return ChangeValuesHidden()" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                <%-- <input type="text" class="input3 number" maxlength="5" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2' style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td style="width: 300px; vertical-align: top">
                    <table style="width: 300px;" cellpadding='0' cellspacing='0'>
                        <tr>
                            <td colspan='2' style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan='5' style="padding-top: 100px;">
                    <div style="height: 2px; border-top: 2px #999 solid" class="clear">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td colspan='5'>
                    <table style="width: 100%">
                        <tr>
                            <td style="padding-top: 10px; width: 55%">
                                <table style="width: 100%;" cellpadding='0' cellspacing='0'>
                                    <tr>
                                        <td colspan="2">
                                            <div class="box1">
                                                <h3>
                                                    Vehicle Information
                                                </h3>
                                                <table cellpadding='1' cellspacing='0' style="width: 99%; margin: 0 0 0 5px">
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Year<span class="star">*</span></h4>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;">
                                                            <h4 class="h43">
                                                                Type<span class="star">*</span></h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                                                                        CssClass="input1">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;">
                                                            <h4 class="h43">
                                                                Category<span class="star">*</span></h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="input1">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px;">
                                                            <h4 class="h43">
                                                                Make<span class="star">*</span></h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtMake" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMake" runat="server" CssClass="input1">
                                                                        <asp:ListItem Value="0">Unspecified</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Model</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtModel" runat="server" MaxLength="50" CssClass="input3" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Heading</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="input3" MaxLength="100" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Price</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" CssClass="input3 number"
                                                                onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                            <%-- <input type="text" class="input3 number" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Mileage</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" CssClass="input3 number"
                                                                onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                            <%--<asp:Label ID="lblMi" Text="mi" runat="server" Visible="false"></asp:Label>--%>
                                                            <%-- <input type="text" class="input3 number" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Exterior Color</h4>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlExteriorColor" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                            <%-- <select class="input3">
                                    <option>Select color</option>
                                </select>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Interior Color</h4>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlInteriorColor" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Doors</h4>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlDoorCount" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                            <%--   <input type="text" class="input3 number" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Fuel Type</h4>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlFuelType" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                            <%--   <input type="text" class="input3 number" />--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Engine Manufacturer</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtpnlManufacturer" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlEngineManufacturer" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Engine Type</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="updtpnlEngineType" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtEngineModel" runat="server" MaxLength="25" CssClass="input3"
                                                                        onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Transmisssion Speed</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlTransmission" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Transmisssion Make</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtTransmissionMake" runat="server" MaxLength="25" onkeyup="return ChangeValuesHidden()"
                                                                        CssClass="input3"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Suspension</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlSuspension" runat="server" CssClass="input1">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Horse Power</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlHorsePower" runat="server" CssClass="input1">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Rear</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtRear" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"
                                                                        CssClass="input3"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Axles</h4>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:TextBox ID="txtAxles" runat="server" MaxLength="5" onkeypress="return isNumberKey(event)"
                                                                        CssClass="input3"></asp:TextBox>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                VIN number</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtVinNumber" runat="server" CssClass="input3" MaxLength="20" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 10px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="position: relative; z-index: 9; height: 155px; vertical-align: top">
                                            <div class="box1 wid" style="width: 500px;">
                                                <h3>
                                                    Vehicle Features</h3>
                                                <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <div>
                                                                <em><b>Interior Options</b></em>
                                                                <asp:CheckBoxList ID="chklstIneriorOptions" runat="server" RepeatDirection="Vertical">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                        </td>
                                                        <td valign="top">
                                                            <div>
                                                                <em><b>Exterior Options</b></em>
                                                                <asp:CheckBoxList ID="chklstExteriorOptions" runat="server" RepeatDirection="Vertical">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                            <div>
                                                                <em><b>Safety Options</b></em>
                                                                <asp:CheckBoxList ID="chklstSafetyOptions" runat="server" RepeatDirection="Vertical">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="position: relative; top: 20px; left: -1px;">
                                                    <div class="box1 wid" style="width: 500px;">
                                                        <h3>
                                                            Other</h3>
                                                        <table style="width: 99%; margin-left: 5px" cellpadding="1" cellspacing="0">
                                                            <tr>
                                                                <td style="width: 110px;">
                                                                    <h4 class="h43">
                                                                        Vehicle Condition</h4>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCondition" runat="server" CssClass="input1" Width="150px"
                                                                        onchange="ChangeValuesHidden()">
                                                                    </asp:DropDownList>
                                                                    <%--<input type="text" class="input3 " />--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 110px; vertical-align: top;">
                                                                    <h4 class="h43">
                                                                        Description</h4>
                                                                </td>
                                                                <td>
                                                                    <%-- <textarea class="emailAddress" style="width: 100%; height: 50px; margin-bottom: 20px;"></textarea>--%>
                                                                    <!-- <asp:Label ID="lblDescription" runat="server"></asp:Label>  -->
                                                                    <asp:TextBox ID="txtDescription" runat="server" Style="width: 98%; padding: 3px;
                                                                        margin-top: 6px; height: 60px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"
                                                                        onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="height: 10px">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="position: absolute; bottom: -110px; vertical-align: top; padding-bottom: 30px;">
                                                            <div style="width: 290px;">
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td style="padding-top: 10px; vertical-align: top; width: 40%">
                                <asp:UpdatePanel ID="UpdtpnlSellerInfo" runat="server">
                                    <ContentTemplate>
                                        <div class="box1">
                                            <h3>
                                                Seller Info To Display In The Ad
                                            </h3>
                                            <asp:LinkButton ID="lnkCopyRegInfo" runat="server" Text="Copy data from registration data"
                                                Style="text-align: right; float: right; padding: 5px;" OnClientClick="return CopySellerInfo();"></asp:LinkButton>
                                            <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                                <%--  <tr>
                                                    <td style="width: 110px">
                                                        <h4 class="h43">
                                                            Customer name</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustName" runat="server" CssClass="input3" MaxLength="30" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            Phone number</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustPhoneNumber" CssClass="input3 number" MaxLength="10" runat="server"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        <%--<input type="text" class="input3 number" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            Alt number</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustAltNumber" CssClass="input3 number" MaxLength="10" runat="server"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        <%-- <input type="text" class="input3 number" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            Email</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtSellerEmail" CssClass="input3" MaxLength="50" runat="server"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        <%-- <input type="text" class="input3 number" />--%>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            Address</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCustAddress" runat="server" CssClass="input3" MaxLength="50"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            City</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtCity" runat="server" CssClass="input3" MaxLength="25" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        <%--<input type="text" class="input3 " />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            State</h4>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlLocationState" runat="server" CssClass="input1" Width="100px"
                                                            onchange="ChangeValuesHidden()">
                                                        </asp:DropDownList>
                                                        <%--  <input type="text" class="input3 " />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            Zip</h4>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtZip" runat="server" CssClass="input3" MaxLength="10" Width="100px"
                                                            onkeyup="return ChangeValuesHidden()" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                                        <%-- <input type="text" class="input3 number" maxlength="5" />--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
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
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrUpdated" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnYesUpdated" class="btn" runat="server" Text="Ok" OnClick="btnYesUpdated_Click" />
        </div>
    </div>
    </form>
</body>
</html>
