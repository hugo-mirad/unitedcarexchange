<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DealerRegistrationEdit.aspx.cs"
    Inherits="DealerRegistrationEdit" %>

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
    
     function ValidateDealerInfo() {
     debugger;
            var valid = true;     
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
             if (document.getElementById('<%= txtRegBusinessName.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtRegBusinessName.ClientID%>').focus();
                alert("Enter business name");
                document.getElementById('<%=txtRegBusinessName.ClientID%>').value = ""
                document.getElementById('<%=txtRegBusinessName.ClientID%>').focus()                
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
             if (document.getElementById('<%= txtRegPhNo.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtRegPhNo.ClientID%>').focus();
                alert("Enter customer phone number");
                document.getElementById('<%=txtRegPhNo.ClientID%>').value = ""
                document.getElementById('<%=txtRegPhNo.ClientID%>').focus()                
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

            if (document.getElementById('<%= txtRegAddress.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtRegAddress.ClientID%>').focus();
            alert("Enter customer address");
            document.getElementById('<%=txtRegAddress.ClientID%>').value = ""
            document.getElementById('<%=txtRegAddress.ClientID%>').focus()                
            valid = false;
             return valid;     
            }     
            if (document.getElementById('<%= txtRegCity.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtRegCity.ClientID%>').focus();
            alert("Enter customer city");
            document.getElementById('<%=txtRegCity.ClientID%>').value = ""
            document.getElementById('<%=txtRegCity.ClientID%>').focus()                
            valid = false;
             return valid;     
            }  
             if(document.getElementById('<%=ddlRegState.ClientID%>').value =="0")
            {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlRegState').focus();  
                return valid;               
            } 
             if (document.getElementById('<%= txtregZip.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtregZip.ClientID%>').focus();
            alert("Enter customer zipcode");
            document.getElementById('<%=txtregZip.ClientID%>').value = ""
            document.getElementById('<%=txtregZip.ClientID%>').focus()                
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
             if (document.getElementById('<%= txtSellerBusinessName.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtSellerBusinessName.ClientID%>').focus();
                alert("Enter seller business name");
                document.getElementById('<%=txtSellerBusinessName.ClientID%>').value = ""
                document.getElementById('<%=txtSellerBusinessName.ClientID%>').focus()                
                valid = false;
                 return valid;     
            } 
             if (document.getElementById('<%= txtCustPhoneNumber.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtCustPhoneNumber.ClientID%>').focus();
                alert("Enter seller phone number");
                document.getElementById('<%=txtCustPhoneNumber.ClientID%>').value = ""
                document.getElementById('<%=txtCustPhoneNumber.ClientID%>').focus()                
                valid = false;
                 return valid;     
            }  
            if((document.getElementById('<%= txtCustPhoneNumber.ClientID%>').value.length > 0) && (document.getElementById('<%= txtCustPhoneNumber.ClientID%>').value.length < 10)) {
            document.getElementById('<%= txtCustPhoneNumber.ClientID%>').focus();
            document.getElementById('<%=txtCustPhoneNumber.ClientID%>').value = "";
            alert("Enter valid phone number");
            valid = false; 
             return valid;                

            }
       
        if(document.getElementById('<%= txtSellerEmail.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtSellerEmail.ClientID%>').focus();
                alert("Enter email");
                 document.getElementById('<%=txtSellerEmail.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEmail.ClientID%>').focus()
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
            
            if (document.getElementById('<%= txtCity.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtCity.ClientID%>').focus();
            alert("Enter seller customer city");
            document.getElementById('<%=txtCity.ClientID%>').value = ""
            document.getElementById('<%=txtCity.ClientID%>').focus()                
            valid = false;
             return valid;     
            }  
             if(document.getElementById('<%=ddlLocationState.ClientID%>').value =="0")
            {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlLocationState').focus();  
                return valid;               
            } 
             if (document.getElementById('<%= txtZip.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtZip.ClientID%>').focus();
            alert("Enter customer zipcode");
            document.getElementById('<%=txtZip.ClientID%>').value = ""
            document.getElementById('<%=txtZip.ClientID%>').focus()                
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
              if(document.getElementById('<%= rdbtnPayAmex.ClientID%>').checked == true)
            {
                if (document.getElementById('<%= txtCardholderName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderName.ClientID%>').focus();
                alert("Enter card holder first name");
                document.getElementById('<%=txtCardholderName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderName.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                
                if (document.getElementById('<%= txtCardholderLastName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderLastName.ClientID%>').focus();
                alert("Enter card holder last name");
                document.getElementById('<%=txtCardholderLastName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderLastName.ClientID%>').focus()                
                valid = false;
                return valid;     
                } 
                if (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();
                alert("Enter card number");
                document.getElementById('<%=CardNumber.ClientID%>').value = ""
                document.getElementById('<%=CardNumber.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 15)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                return valid;              

                }           
                var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
                if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
                {
                CCNum = CCNum.charAt(0);
                if(CCNum != "3")
                {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("This is not a Amex card number");
                valid = false; 
                return valid;  
                }
                }               
                if(document.getElementById('<%=ExpMon.ClientID%>').value =="0")
                {
                alert("Please select the expiration month"); 
                valid=false;
                document.getElementById('ExpMon').focus();  
                return valid;               
                }
                if(document.getElementById('<%=CCExpiresYear.ClientID%>').value =="0")
                {
                alert("Please select the expiration year"); 
                valid=false;
                document.getElementById('CCExpiresYear').focus();  
                return valid;               
                }  
                if (document.getElementById('<%= cvv.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= cvv.ClientID%>').focus();
                alert("Enter cvv number");
                document.getElementById('<%=cvv.ClientID%>').value = ""
                document.getElementById('<%=cvv.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 4)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                return valid;              

                }   
               
                if (document.getElementById('<%= txtbillingaddress.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingaddress.ClientID%>').focus();
                alert("Enter billing address");
                document.getElementById('<%=txtbillingaddress.ClientID%>').value = ""
                document.getElementById('<%=txtbillingaddress.ClientID%>').focus()                
                valid = false;
                return valid;     
                }    
                if (document.getElementById('<%= txtbillingcity.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingcity.ClientID%>').focus();
                alert("Enter city");
                document.getElementById('<%=txtbillingcity.ClientID%>').value = ""
                document.getElementById('<%=txtbillingcity.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=ddlbillingstate.ClientID%>').value =="0")
                {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlbillingstate').focus();  
                return valid;               
                } 
                if (document.getElementById('<%= txtbillingzip.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Enter zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=txtbillingzip.ClientID%>').value.trim().length > 0)
                {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtbillingzip.ClientID%>').value);             
                if (isValid == false)
                {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Please enter valid zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()
                valid = false;  
                return valid;      
                }                                   
                }  

           }
           if(document.getElementById('<%= rdbtnPayVisa.ClientID%>').checked == true)
            {
                if (document.getElementById('<%= txtCardholderName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderName.ClientID%>').focus();
                alert("Enter card holder name");
                document.getElementById('<%=txtCardholderName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderName.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                   
                if (document.getElementById('<%= txtCardholderLastName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderLastName.ClientID%>').focus();
                alert("Enter card holder last name");
                document.getElementById('<%=txtCardholderLastName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderLastName.ClientID%>').focus()                
                valid = false;
                return valid;     
                } 
                if (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();
                alert("Enter card number");
                document.getElementById('<%=CardNumber.ClientID%>').value = ""
                document.getElementById('<%=CardNumber.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 16)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                return valid;              

                }           
                var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
                if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
                {
                CCNum = CCNum.charAt(0);
                if(CCNum != "4")
                {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("This is not a Visa card number");
                valid = false; 
                return valid;  
                }
                }               
                if(document.getElementById('<%=ExpMon.ClientID%>').value =="0")
                {
                alert("Please select the expiration month"); 
                valid=false;
                document.getElementById('ExpMon').focus();  
                return valid;               
                }
                if(document.getElementById('<%=CCExpiresYear.ClientID%>').value =="0")
                {
                alert("Please select the expiration year"); 
                valid=false;
                document.getElementById('CCExpiresYear').focus();  
                return valid;               
                }  
                if (document.getElementById('<%= cvv.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= cvv.ClientID%>').focus();
                alert("Enter cvv number");
                document.getElementById('<%=cvv.ClientID%>').value = ""
                document.getElementById('<%=cvv.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 3)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                return valid;              

                }   
                
                if (document.getElementById('<%= txtbillingaddress.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingaddress.ClientID%>').focus();
                alert("Enter billing address");
                document.getElementById('<%=txtbillingaddress.ClientID%>').value = ""
                document.getElementById('<%=txtbillingaddress.ClientID%>').focus()                
                valid = false;
                return valid;     
                }    
                if (document.getElementById('<%= txtbillingcity.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingcity.ClientID%>').focus();
                alert("Enter city");
                document.getElementById('<%=txtbillingcity.ClientID%>').value = ""
                document.getElementById('<%=txtbillingcity.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=ddlbillingstate.ClientID%>').value =="0")
                {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlbillingstate').focus();  
                return valid;               
                } 
                if (document.getElementById('<%= txtbillingzip.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Enter zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=txtbillingzip.ClientID%>').value.trim().length > 0)
                {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtbillingzip.ClientID%>').value);             
                if (isValid == false)
                {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Please enter valid zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()
                valid = false;  
                return valid;      
                }                                   
                }  

           }    
            
             if(document.getElementById('<%= rdbtnPayMasterCard.ClientID%>').checked == true)
            {
                if (document.getElementById('<%= txtCardholderName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderName.ClientID%>').focus();
                alert("Enter card holder name");
                document.getElementById('<%=txtCardholderName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderName.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                   
                if (document.getElementById('<%= txtCardholderLastName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderLastName.ClientID%>').focus();
                alert("Enter card holder last name");
                document.getElementById('<%=txtCardholderLastName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderLastName.ClientID%>').focus()                
                valid = false;
                return valid;     
                } 
                if (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();
                alert("Enter card number");
                document.getElementById('<%=CardNumber.ClientID%>').value = ""
                document.getElementById('<%=CardNumber.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 16)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                return valid;              

                }           
                var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
                if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
                {
                CCNum = CCNum.charAt(0);
                if(CCNum != "5")
                {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("This is not a Master card number");
                valid = false; 
                return valid;  
                }
                }               
                if(document.getElementById('<%=ExpMon.ClientID%>').value =="0")
                {
                alert("Please select the expiration month"); 
                valid=false;
                document.getElementById('ExpMon').focus();  
                return valid;               
                }
                if(document.getElementById('<%=CCExpiresYear.ClientID%>').value =="0")
                {
                alert("Please select the expiration year"); 
                valid=false;
                document.getElementById('CCExpiresYear').focus();  
                return valid;               
                }  
                if (document.getElementById('<%= cvv.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= cvv.ClientID%>').focus();
                alert("Enter cvv number");
                document.getElementById('<%=cvv.ClientID%>').value = ""
                document.getElementById('<%=cvv.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 3)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                return valid;              

                }   
             

                if (document.getElementById('<%= txtbillingaddress.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingaddress.ClientID%>').focus();
                alert("Enter billing address");
                document.getElementById('<%=txtbillingaddress.ClientID%>').value = ""
                document.getElementById('<%=txtbillingaddress.ClientID%>').focus()                
                valid = false;
                return valid;     
                }    
                if (document.getElementById('<%= txtbillingcity.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingcity.ClientID%>').focus();
                alert("Enter city");
                document.getElementById('<%=txtbillingcity.ClientID%>').value = ""
                document.getElementById('<%=txtbillingcity.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=ddlbillingstate.ClientID%>').value =="0")
                {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlbillingstate').focus();  
                return valid;               
                } 
                if (document.getElementById('<%= txtbillingzip.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Enter zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=txtbillingzip.ClientID%>').value.trim().length > 0)
                {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtbillingzip.ClientID%>').value);             
                if (isValid == false)
                {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Please enter valid zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()
                valid = false;  
                return valid;      
                }                                   
                }  

           }       
              if(document.getElementById('<%= rdbtnPayDiscover.ClientID%>').checked == true)
            {
                if (document.getElementById('<%= txtCardholderName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderName.ClientID%>').focus();
                alert("Enter card holder name");
                document.getElementById('<%=txtCardholderName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderName.ClientID%>').focus()                
                valid = false;
                return valid;     
                } 
                   
                if (document.getElementById('<%= txtCardholderLastName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtCardholderLastName.ClientID%>').focus();
                alert("Enter card holder last name");
                document.getElementById('<%=txtCardholderLastName.ClientID%>').value = ""
                document.getElementById('<%=txtCardholderLastName.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();
                alert("Enter card number");
                document.getElementById('<%=CardNumber.ClientID%>').value = ""
                document.getElementById('<%=CardNumber.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 16)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                return valid;              

                }           
                var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
                if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
                {
                CCNum = CCNum.charAt(0);
                if(CCNum != "6")
                {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("This is not a Discover card number");
                valid = false; 
                return valid;  
                }
                }               
                if(document.getElementById('<%=ExpMon.ClientID%>').value =="0")
                {
                alert("Please select the expiration month"); 
                valid=false;
                document.getElementById('ExpMon').focus();  
                return valid;               
                }
                if(document.getElementById('<%=CCExpiresYear.ClientID%>').value =="0")
                {
                alert("Please select the expiration year"); 
                valid=false;
                document.getElementById('CCExpiresYear').focus();  
                return valid;               
                }  
                if (document.getElementById('<%= cvv.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= cvv.ClientID%>').focus();
                alert("Enter cvv number");
                document.getElementById('<%=cvv.ClientID%>').value = ""
                document.getElementById('<%=cvv.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 3)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                return valid;              

                } 
                

                if (document.getElementById('<%= txtbillingaddress.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingaddress.ClientID%>').focus();
                alert("Enter billing address");
                document.getElementById('<%=txtbillingaddress.ClientID%>').value = ""
                document.getElementById('<%=txtbillingaddress.ClientID%>').focus()                
                valid = false;
                return valid;     
                }    
                if (document.getElementById('<%= txtbillingcity.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingcity.ClientID%>').focus();
                alert("Enter city");
                document.getElementById('<%=txtbillingcity.ClientID%>').value = ""
                document.getElementById('<%=txtbillingcity.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=ddlbillingstate.ClientID%>').value =="0")
                {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlbillingstate').focus();  
                return valid;               
                } 
                if (document.getElementById('<%= txtbillingzip.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Enter zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()                
                valid = false;
                return valid;     
                }   
                if(document.getElementById('<%=txtbillingzip.ClientID%>').value.trim().length > 0)
                {
                var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtbillingzip.ClientID%>').value);             
                if (isValid == false)
                {
                document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                alert("Please enter valid zipcode");
                document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                document.getElementById('<%=txtbillingzip.ClientID%>').focus()
                valid = false;  
                return valid;      
                }                                   
                }  

           }       
            if(document.getElementById('<%= rdbtnPayPaypal.ClientID%>').checked == true)
            {                   
                    if(document.getElementById('<%= txtPaytransID.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtPaytransID.ClientID%>').focus();
                    alert("Enter Payment Trans ID");
                    document.getElementById('<%=txtPaytransID.ClientID%>').value = ""
                    document.getElementById('<%=txtPaytransID.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }    

                    if(document.getElementById('<%= txtpayPalEmailAccount.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtpayPalEmailAccount.ClientID%>').focus();
                    alert("Enter paypal account email");
                    document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').value = ""
                    document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }            
                    if ((document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').value) == false) )
                    {               
                    document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').value = ""
                    document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').focus()
                    valid = false;               
                    return valid;     
                    }          
            }    
            
             if(document.getElementById('<%= rdbtnPayCheck.ClientID%>').checked == true)
            {
                      if(document.getElementById('<%= txtAccNumberForCheck.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtAccNumberForCheck.ClientID%>').focus();
                    alert("Enter account number");
                    document.getElementById('<%=txtAccNumberForCheck.ClientID%>').value = ""
                    document.getElementById('<%=txtAccNumberForCheck.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }  
                      if((document.getElementById('<%= txtAccNumberForCheck.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= txtAccNumberForCheck.ClientID%>').value.trim().length < 4)) {
                    document.getElementById('<%= txtAccNumberForCheck.ClientID%>').focus();
                    document.getElementById('<%=txtAccNumberForCheck.ClientID%>').value = "";
                    alert("Enter valid account number");
                    valid = false; 
                    return valid; 
                    } 
                     if(document.getElementById('<%=ddlAccType.ClientID%>').value =="0")
                    {
                    alert("Please select account type"); 
                    valid=false;
                    document.getElementById('ddlAccType').focus();  
                    return valid;               
                    }   
                    if(document.getElementById('<%= txtRoutingNumberForCheck.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtRoutingNumberForCheck.ClientID%>').focus();
                    alert("Enter routing number");
                    document.getElementById('<%=txtRoutingNumberForCheck.ClientID%>').value = ""
                    document.getElementById('<%=txtRoutingNumberForCheck.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }  
                      if((document.getElementById('<%= txtRoutingNumberForCheck.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= txtRoutingNumberForCheck.ClientID%>').value.trim().length < 9)) {
                    document.getElementById('<%= txtRoutingNumberForCheck.ClientID%>').focus();
                    document.getElementById('<%=txtRoutingNumberForCheck.ClientID%>').value = "";
                    alert("Enter valid routing number");
                    valid = false; 
                    return valid; 
                    } 
                     if(document.getElementById('<%= txtCustNameForCheck.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtCustNameForCheck.ClientID%>').focus();
                    alert("Enter account holder name");
                    document.getElementById('<%=txtCustNameForCheck.ClientID%>').value = ""
                    document.getElementById('<%=txtCustNameForCheck.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }                                           
            }
            if(document.getElementById('<%= txtVoicefileConfirmNo.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtVoicefileConfirmNo.ClientID%>').focus();
            alert("Enter voice file confirmation #");
            document.getElementById('<%=txtVoicefileConfirmNo.ClientID%>').value = ""
            document.getElementById('<%=txtVoicefileConfirmNo.ClientID%>').focus()
            valid = false;            
            return valid;     
            }    

            if(document.getElementById('<%=ddlVoiceFileLocation.ClientID%>').value =="0")
            {
            alert("Please select voice file location"); 
            valid=false;
            document.getElementById('ddlVoiceFileLocation').focus();  
            return valid;               
            }
            if(document.getElementById('<%= rdbtnPayPaypal.ClientID%>').checked == false)
            { 
	            if((document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="7")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="8"))
	            {
                    if(document.getElementById('<%= txtPayTransactionID.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtPayTransactionID.ClientID%>').focus();
                    alert("Enter transaction id");
                    document.getElementById('<%=txtPayTransactionID.ClientID%>').value = ""
                    document.getElementById('<%=txtPayTransactionID.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }    
                    if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                    document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                    alert("Select payment date");                 
                    document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
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


                    var EnterAmt = parseFloat($('#txtPaymentAmountIn').val());
                   
                    if(document.getElementById('<%= txtPaymentAmountIn.ClientID%>').value.trim().length < 1) {
                    document.getElementById('<%= txtPaymentAmountIn.ClientID%>').focus();
                    alert("Enter amount being paid now");
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').value = ""
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }    

                    if(EnterAmt > selectedPack){
                    document.getElementById('<%= txtPaymentAmountIn.ClientID%>').focus();
                    alert("Amount more than selected package price");
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').value = ""
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').focus()
                    valid = false; 
                    return valid;     
                    } 
                     if(EnterAmt < selectedPack){
                    document.getElementById('<%= txtPaymentAmountIn.ClientID%>').focus();
                    alert("Amount less than selected package price");
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').value = ""
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').focus()
                    valid = false; 
                    return valid;     
                    }   
                    
                }
	        }    
	        
	         if(document.getElementById('<%= rdbtnPayPaypal.ClientID%>').checked == true)
            { 
	            if((document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="7")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="8"))
	            {                    
                    if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                    document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                    alert("Select payment date");                 
                    document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
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


                    var EnterAmt = parseFloat($('#txtPaymentAmountIn').val());
                   
                    if(document.getElementById('<%= txtPaymentAmountIn.ClientID%>').value.trim().length < 1) {
                    document.getElementById('<%= txtPaymentAmountIn.ClientID%>').focus();
                    alert("Enter amount being paid now");
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').value = ""
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }    

                    if(EnterAmt > selectedPack){
                    document.getElementById('<%= txtPaymentAmountIn.ClientID%>').focus();
                    alert("Amount more than selected package price");
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').value = ""
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').focus()
                    valid = false; 
                    return valid;     
                    } 
                     if(EnterAmt < selectedPack){
                    document.getElementById('<%= txtPaymentAmountIn.ClientID%>').focus();
                    alert("Amount less than selected package price");
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').value = ""
                    document.getElementById('<%=txtPaymentAmountIn.ClientID%>').focus()
                    valid = false; 
                    return valid;     
                    }   
                    
                }
	        }         
            return valid;              
       }       
    </script>

    <script type="text/javascript" language="javascript">
     $(function(){
        $('input[name=PayType]').live('change', radioValueChanged);      
     
     })
     function radioValueChanged(){
            radioValue = $(this).val(); 
            //console.log(radioValue);  
            switch(radioValue){
                case 'rdbtnPayVisa':
                    document.getElementById('divcard').style.display = 'block'; 
                    document.getElementById('divcheck').style.display = 'none'; 
                    document.getElementById('divpaypal').style.display = 'none'; 
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
                    break;
                case 'rdbtnPayMasterCard':
                        document.getElementById('divcard').style.display = 'block'; 
                        document.getElementById('divcheck').style.display = 'none'; 
                        document.getElementById('divpaypal').style.display = 'none'; 
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
                        break;
                case 'rdbtnPayDiscover':
                        document.getElementById('divcard').style.display = 'block'; 
                        document.getElementById('divcheck').style.display = 'none'; 
                        document.getElementById('divpaypal').style.display = 'none'; 
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
                        break;
                case 'rdbtnPayAmex':
                        document.getElementById('divcard').style.display = 'block'; 
                        document.getElementById('divcheck').style.display = 'none'; 
                        document.getElementById('divpaypal').style.display = 'none'; 
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
                        break;
                case 'rdbtnPayPaypal':
                        document.getElementById('divcard').style.display = 'none'; 
                        document.getElementById('divcheck').style.display = 'none'; 
                        document.getElementById('divpaypal').style.display = 'block'; 
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
                        break;
                case 'rdbtnPayCheck':
                        document.getElementById('divcard').style.display = 'none'; 
                        document.getElementById('divcheck').style.display = 'block'; 
                        document.getElementById('divpaypal').style.display = 'none'; 
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
                        break;        
                
                    
            }
            
            
     }
     
     /*
     function ValidatePaymentType() {     
            
            
            
               
            if(document.getElementById('<%= rdbtnPayAmex.ClientID%>').checked == true)
            {
                 
            } 
            if(document.getElementById('<%= rdbtnPayVisa.ClientID%>').checked == true)
            {
                document.getElementById('divcard').style.display = 'block'; 
                 document.getElementById('divcheck').style.display = 'none'; 
                 document.getElementById('divpaypal').style.display = 'none'; 
            }
             if(document.getElementById('<%= rdbtnPayMasterCard.ClientID%>').checked == true)
            {
                document.getElementById('divcard').style.display = 'block'; 
                 document.getElementById('divcheck').style.display = 'none'; 
                 document.getElementById('divpaypal').style.display = 'none'; 
            }
              if(document.getElementById('<%= rdbtnPayDiscover.ClientID%>').checked == true)
            {
                 document.getElementById('divcard').style.display = 'block'; 
                 document.getElementById('divcheck').style.display = 'none'; 
                 document.getElementById('divpaypal').style.display = 'none'; 
            }
            if(document.getElementById('<%= rdbtnPayPaypal.ClientID%>').checked == true)
            {  
                 document.getElementById('divcard').style.display = 'none'; 
                 document.getElementById('divcheck').style.display = 'none'; 
                 document.getElementById('divpaypal').style.display = 'block'; 
            }
            if(document.getElementById('<%= rdbtnPayCheck.ClientID%>').checked == true)
            {
                 document.getElementById('divcard').style.display = 'none'; 
                 document.getElementById('divcheck').style.display = 'block'; 
                 document.getElementById('divpaypal').style.display = 'none'; 
            }
        }  
        */
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
        
        
          function CopySellerInfoForPay()
        {
         
            var valid=true;   
             if(document.getElementById('<%= txtLoginEmail.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtLoginEmail.ClientID%>').focus();
                alert("Enter registration email");
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
               
          else  if (document.getElementById('<%= txtRegAddress.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtRegAddress.ClientID%>').focus();
            alert("Enter customer address");
            document.getElementById('<%=txtRegAddress.ClientID%>').value = ""
            document.getElementById('<%=txtRegAddress.ClientID%>').focus()                
            valid = false;
             return valid;     
            }     
          else  if (document.getElementById('<%= txtRegCity.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtRegCity.ClientID%>').focus();
            alert("Enter customer city");
            document.getElementById('<%=txtRegCity.ClientID%>').value = ""
            document.getElementById('<%=txtRegCity.ClientID%>').focus()                
            valid = false;
             return valid;     
            }  
           else if(document.getElementById('<%=ddlRegState.ClientID%>').value =="0")
            {
                alert("Please select state"); 
                valid=false;
                document.getElementById('ddlRegState').focus();  
                return valid;               
            } 
            else if (document.getElementById('<%= txtregZip.ClientID%>').value.length < 1)
            {
            document.getElementById('<%= txtregZip.ClientID%>').focus();
            alert("Enter customer zipcode");
            document.getElementById('<%=txtregZip.ClientID%>').value = ""
            document.getElementById('<%=txtregZip.ClientID%>').focus()                
            valid = false;
             return valid;     
            } 
             else if (document.getElementById('<%= txtregZip.ClientID%>').value.length < 5)
            {
            document.getElementById('<%= txtregZip.ClientID%>').focus();
            alert("Enter valid zipcode");
            document.getElementById('<%=txtregZip.ClientID%>').value = ""
            document.getElementById('<%=txtregZip.ClientID%>').focus()                
            valid = false;
             return valid;     
            } 
              else
              {        
                 document.getElementById('<%= txtbillingaddress.ClientID%>').value =  document.getElementById('<%= txtRegAddress.ClientID%>').value;        
                 document.getElementById('<%= txtbillingcity.ClientID%>').value =  document.getElementById('<%= txtRegCity.ClientID%>').value;
                 document.getElementById('<%= txtbillingzip.ClientID%>').value =  document.getElementById('<%= txtregZip.ClientID%>').value;
                 document.getElementById('<%= ddlbillingstate.ClientID%>').value =  document.getElementById('<%= ddlRegState.ClientID%>').value;                 
                 document.getElementById('<%= txtCardholderName.ClientID%>').value =  document.getElementById('<%= txtRegName.ClientID%>').value;                 
                                  
              }             
              return valid;      
        } 
    </script>

    <script type="text/javascript">
       function CopySellerInfoForCheck()
        {
         
            var valid=true;   
                if (document.getElementById('<%= txtRegName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtRegName.ClientID%>').focus();
                alert("Enter customer  name");
                document.getElementById('<%=txtRegName.ClientID%>').value = ""
                document.getElementById('<%=txtRegName.ClientID%>').focus()                
                valid = false;
                 return valid;     
              }   
              else
              {
                 document.getElementById('<%= txtCustNameForCheck.ClientID%>').value =  document.getElementById('<%= txtRegName.ClientID%>').value;                                                       
              }             
              return valid;      
        } 
        
         function CVVOnblur()
     {
         if(document.getElementById('<%= rdbtnPayAmex.ClientID%>').checked == true)
         {
           if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 4)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                 return valid;              
            
            }                      
         }
         
         if(document.getElementById('<%= rdbtnPayVisa.ClientID%>').checked == true)
         {
           if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 3)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                 return valid;              
            
            }     
         }
          if(document.getElementById('<%= rdbtnPayMasterCard.ClientID%>').checked == true)
         {
            if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 3)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                 return valid;              
            
            }  
         }
         if(document.getElementById('<%= rdbtnPayDiscover.ClientID%>').checked == true)
         {
            if((document.getElementById('<%= cvv.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= cvv.ClientID%>').value.trim().length != 3)) {
                document.getElementById('<%= cvv.ClientID%>').focus();             
                alert("Enter valid cvv number");
                valid = false; 
                 return valid;              
            
            }  
         }
         
                      
     }

 function CreditCardOnblur()
     {
         if(document.getElementById('<%= rdbtnPayAmex.ClientID%>').checked == true)
         {
           if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 15)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                 return valid;              
            
            }           
            var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
            if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
            {
                CCNum = CCNum.charAt(0);
                if(CCNum != "3")
                {
                 document.getElementById('<%= CardNumber.ClientID%>').focus();             
                 alert("This is not a Amex card number");
                 valid = false; 
                 return valid;  
                }
            }
         }
         
         if(document.getElementById('<%= rdbtnPayVisa.ClientID%>').checked == true)
         {
           if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 16)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                 return valid;              
            
            }           
            var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
            if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
            {
                CCNum = CCNum.charAt(0);
                if(CCNum != "4")
                {
                 document.getElementById('<%= CardNumber.ClientID%>').focus();             
                 alert("This is not a Visa card number");
                 valid = false; 
                 return valid;  
                }
            }
         }
          if(document.getElementById('<%= rdbtnPayMasterCard.ClientID%>').checked == true)
         {
           if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 16)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                 return valid;              
            
            }           
            var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
            if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
            {
                CCNum = CCNum.charAt(0);
                if(CCNum != "5")
                {
                 document.getElementById('<%= CardNumber.ClientID%>').focus();             
                 alert("This is not a Master card number");
                 valid = false; 
                 return valid;  
                }
            }
         }
         if(document.getElementById('<%= rdbtnPayDiscover.ClientID%>').checked == true)
         {
           if((document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= CardNumber.ClientID%>').value.trim().length != 16)) {
                document.getElementById('<%= CardNumber.ClientID%>').focus();             
                alert("Enter valid card number");
                valid = false; 
                 return valid;              
            
            }           
            var CCNum = document.getElementById('<%= CardNumber.ClientID%>').value.trim();
            if(document.getElementById('<%= CardNumber.ClientID%>').value.trim().length > 0) 
            {
                CCNum = CCNum.charAt(0);
                if(CCNum != "6")
                {
                 document.getElementById('<%= CardNumber.ClientID%>').focus();             
                 alert("This is not a Discover card number");
                 valid = false; 
                 return valid;  
                }
            }
         }
         
                      
     }
     
     function billingZipOnblur()
     {
          if(document.getElementById('<%=txtbillingzip.ClientID%>').value.trim().length > 0)
             {
                  var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtbillingzip.ClientID%>').value);             
                   if (isValid == false)
                   {
                         document.getElementById('<%= txtbillingzip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('<%=txtbillingzip.ClientID%>').value = ""
                    document.getElementById('<%=txtbillingzip.ClientID%>').focus()
                    valid = false;  
                     return valid;      
                   }                                   
             }  
                      
     }
     
     function PaypalEmailblur()
     {           
               if ((document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').value.trim().length > 0) && (echeck(document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').value.trim()) == false) )
             {                           
                document.getElementById('<%=txtpayPalEmailAccount.ClientID%>').focus()
                valid = false;               
                return valid;     
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
                                <asp:Button ID="btnReset" runat="server" CssClass="g-button g-button-submit" Text="Back to View"
                                    OnClick="btnReset_Click" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="g-button g-button-submit" Text="Update"
                                    OnClientClick="return ValidateDealerInfo();" OnClick="btnSave_Click" />
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
                                    <asp:DropDownList ID="ddlSaleDate" runat="server" CssClass="input1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4 class="h43">
                                        Sales Agent<span class="star">*</span></h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSalesAgent" runat="server" CssClass="input1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4 class="h43">
                                        Verifier</h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlVerifier" runat="server" CssClass="input1">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h4 class="h43">
                                        Package<span class="star">*</span></h4>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPackage" runat="server" CssClass="input1">
                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="10">Dealer Compass Package($200.00)</asp:ListItem>
                                    </asp:DropDownList>
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
                                            <%-- <input type="text" class="input3" />--%>
                                            <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="input3" MaxLength="40"></asp:TextBox>
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
                                                onkeypress="return isKeyNotAcceptSpace(event);"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Customer name<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegName" runat="server" CssClass="input3" MaxLength="30"></asp:TextBox>
                                            <%-- <input type="text" class="input3 " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Business name<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegBusinessName" runat="server" CssClass="input3" MaxLength="30"></asp:TextBox>
                                            <%-- <input type="text" class="input3 " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Alt email</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegAltEmail" runat="server" CssClass="input3" MaxLength="30"></asp:TextBox>
                                            <%-- <input type="text" class="input3 " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Phone number<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegPhNo" CssClass="input3 number" MaxLength="10" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="input3 number" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Alt Phone number</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegAltPhoneNum" CssClass="input3 number" MaxLength="10" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="input3 number" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Address<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegAddress" runat="server" CssClass="input3" MaxLength="50"></asp:TextBox>
                                            <%-- <input type="text" class="input3 " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                City<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtRegCity" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>
                                            <%--<input type="text" class="input3 " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                State<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlRegState" runat="server" CssClass="input1" Width="100px">
                                            </asp:DropDownList>
                                            <%--  <input type="text" class="input3 " />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Zip<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtregZip" runat="server" CssClass="input3" MaxLength="10" Width="100px"
                                                onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                                            <%-- <input type="text" class="input3 number" maxlength="5" />--%>
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
                                            <asp:TextBox ID="txtSellerBusinessName" runat="server" CssClass="input3" MaxLength="30"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">
                                            <h4 class="h43">
                                                Phone number<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustPhoneNumber" CssClass="input3 number" MaxLength="10" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="input3 number" />--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Email<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSellerEmail" CssClass="input3" MaxLength="50" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                City<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                State<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocationState" runat="server" CssClass="input1" Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Zip<span class="star">*</span></h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtZip" runat="server" CssClass="input3" MaxLength="10" Width="100px"
                                                onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
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
                                            <asp:TextBox ID="txtSpecialNotes" runat="server" CssClass="textarea" Style="width: 98%;
                                                padding: 3px; margin-top: 6px; height: 60px; background: #eee" TextMode="MultiLine"></asp:TextBox>
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
                                            <asp:TextBox ID="txtUserNotesOld" runat="server" CssClass="textarea" ReadOnly="true" Style="width: 98%;
                                                padding: 3px; margin-top: 6px; height: 60px; background: #ccc" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <asp:TextBox ID="txtUserNotes" runat="server" CssClass="textarea" Style="width: 98%;
                                                padding: 3px; margin-top: 6px; height: 60px; background: #eee" TextMode="MultiLine"></asp:TextBox>
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
                                                                        runat="server" />
                                                                    <asp:RadioButton ID="rdbtnPayMasterCard" CssClass="noLM" Text="Mastercard" GroupName="PayType"
                                                                        runat="server" />
                                                                    <asp:RadioButton ID="rdbtnPayDiscover" CssClass="noLM" Text="Discover" GroupName="PayType"
                                                                        runat="server" />
                                                                    <asp:RadioButton ID="rdbtnPayAmex" CssClass="noLM" Text="Amex" GroupName="PayType"
                                                                        runat="server" />
                                                                    <asp:RadioButton ID="rdbtnPayPaypal" CssClass="noLM" Text="Paypal" GroupName="PayType"
                                                                        runat="server" />
                                                                    <asp:RadioButton ID="rdbtnPayCheck" CssClass="noLM" Text="Check" GroupName="PayType"
                                                                        runat="server" />
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
                                                                                <%-- <asp:LinkButton ID="lnkbtnCopySellerInfo" runat="server" Text="Copy name & address from Seller Information"
                                                                                    OnClientClick="return CopySellerInfoForPay();" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>--%>
                                                                            </h5>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 155px;">
                                                                            <span class="star" style="color: Red">*</span><strong>Card Holder First Name</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:HiddenField ID="CardType" runat="server" />
                                                                            <asp:TextBox ID="txtCardholderName" runat="server" MaxLength="25" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong>Last Name</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtCardholderLastName" runat="server" MaxLength="25" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong>Credit Card #</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox runat="server" ID="CardNumber" MaxLength="16" onkeypress="return isNumberKey(event)"
                                                                                onblur="return CreditCardOnblur();" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong>Expiry Date</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="ExpMon" Style="width: 100px;" runat="server">
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
                                                                            <asp:DropDownList ID="CCExpiresYear" Style="width: 115px" runat="server">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong style="width: 40px">CVV#</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="cvv" MaxLength="4" runat="server" onkeypress="return isNumberKey(event)"
                                                                                onblur="return CVVOnblur();" Style="width: 60px;" />
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
                                                                            <asp:TextBox ID="txtbillingaddress" runat="server" MaxLength="40"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="star" style="color: Red">*</span><strong style="width: 40px">City</strong>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtbillingcity" runat="server" MaxLength="40"></asp:TextBox>
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
                                                                                        <asp:DropDownList ID="ddlbillingstate" runat="server" Style="width: 100px">
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
                                                                                            class="sample4" onkeypress="return isNumberKey(event)" onblur="return billingZipOnblur();"></asp:TextBox>
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
                                                                                <%-- <asp:LinkButton ID="lnkbtnCopyCheckName" runat="server" Text="Copy name from Seller Information"
                                                                                    OnClientClick="return CopySellerInfoForCheck();" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>--%>
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
                                                                                                    <asp:TextBox ID="txtCustNameForCheck" runat="server" MaxLength="50"></asp:TextBox>
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
                                                                                                    <asp:TextBox ID="txtAccNumberForCheck" runat="server" MaxLength="20"></asp:TextBox>
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
                                                                                                    <asp:TextBox ID="txtBankNameForCheck" runat="server" MaxLength="50"></asp:TextBox>
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
                                                                                                    <asp:TextBox ID="txtRoutingNumberForCheck" runat="server" MaxLength="9"></asp:TextBox>
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
                                                                                                    <asp:DropDownList ID="ddlAccType" runat="server">
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
                                                                                                        <asp:TextBox ID="txtPaytransID" runat="server" MaxLength="30"></asp:TextBox>
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
                                                                                                        <asp:TextBox ID="txtpayPalEmailAccount" runat="server" onblur="return PaypalEmailblur();"></asp:TextBox>
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
                                                                <asp:TextBox ID="txtVoicefileConfirmNo" runat="server" MaxLength="30"></asp:TextBox>
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
                                                                <asp:DropDownList ID="ddlVoiceFileLocation" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 50%;">
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
