<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewCarNewForm.aspx.cs"
    Inherits="AddNewCarNewForm" ValidateRequest="false"%>

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

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

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
            
         
            if(document.getElementById('<%=chkbxEMailNA.ClientID%>').checked == false)
            {
                 if(document.getElementById('<%= txtLoginEmail.ClientID%>').value.length < 1) {
                    document.getElementById('<%= txtLoginEmail.ClientID%>').focus();
                    alert("Enter email");
                     document.getElementById('<%=txtLoginEmail.ClientID%>').value = ""
                    document.getElementById('<%=txtLoginEmail.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                }  
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
                             
            
            if(document.getElementById('<%=ddlMake.ClientID%>').value =="0")
            {
                alert("Please select make"); 
                valid=false;
                document.getElementById('ddlMake').focus();  
                return valid;               
            }             
             if(document.getElementById('<%=ddlModel.ClientID%>').value =="0")
            {
                alert("Please select model"); 
                valid=false;
                document.getElementById('ddlModel').focus();
                return valid;               
            } 
            if (document.getElementById('<%=ddlYear.ClientID%>').value =="0")
            {
                alert('Please select year')
                valid=false;
                document.getElementById('ddlYear').focus();  
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
        if(document.getElementById('<%=ddlPackage.ClientID%>').value !="1")
        {         
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
           
            var string = $('#ddlPackage option:selected').text();
            var p =string.split('$');
            var pp = p[1].split(')');
            //alert(pp[0]);
            //pp[0] = parseInt(pp[0]);
            pp[0] = parseFloat(pp[0]);
            var selectedPack = pp[0].toFixed(2);


            var EnterAmt = parseFloat($('#txtPDAmountNow').val());

            if(document.getElementById('<%=ddlPaymentDate.ClientID%>').value =="0")
            {
            alert("Please select payment date"); 
            valid=false;
            document.getElementById('ddlPaymentDate').focus();  
            return valid;               
            } 
            if(document.getElementById('<%= txtPDAmountNow.ClientID%>').value.trim().length < 1) {
            document.getElementById('<%= txtPDAmountNow.ClientID%>').focus();
            alert("Enter amount being paid now");
            document.getElementById('<%=txtPDAmountNow.ClientID%>').value = ""
            document.getElementById('<%=txtPDAmountNow.ClientID%>').focus()
            valid = false;            
            return valid;     
            }    

            if(EnterAmt > selectedPack){
            document.getElementById('<%= txtPDAmountNow.ClientID%>').focus();
            alert("Amount more than selected package price");
            document.getElementById('<%=txtPDAmountNow.ClientID%>').value = ""
            document.getElementById('<%=txtPDAmountNow.ClientID%>').focus()
            valid = false; 
            return valid;     
            } 
            
             if(document.getElementById('<%= chkboxlstPDsale.ClientID%>').checked == false)
            {
              if(EnterAmt < selectedPack){
                    document.getElementById('<%= txtPDAmountNow.ClientID%>').focus();
                    alert("Amount less than selected package price");
                    document.getElementById('<%=txtPDAmountNow.ClientID%>').value = ""
                    document.getElementById('<%=txtPDAmountNow.ClientID%>').focus()
                    valid = false; 
                    return valid;     
                    }    
            }                 
              if(document.getElementById('<%= chkboxlstPDsale.ClientID%>').checked == true)
            {
                    if(document.getElementById('<%=ddlPDDate.ClientID%>').value =="0")
                    {
                    alert("Please select PD date"); 
                    valid=false;
                    document.getElementById('ddlPDDate').focus();  
                    return valid;               
                    }  
                    var EnterAmt = parseFloat($('#txtPDAmountNow').val());

                    if(document.getElementById('<%= txtPDAmountNow.ClientID%>').value.trim().length < 1) {
                    document.getElementById('<%= txtPDAmountNow.ClientID%>').focus();
                    alert("Enter amount being paid now");
                    document.getElementById('<%=txtPDAmountNow.ClientID%>').value = ""
                    document.getElementById('<%=txtPDAmountNow.ClientID%>').focus()
                    valid = false;            
                    return valid;     
                    }    

                    if(EnterAmt > selectedPack){
                    document.getElementById('<%= txtPDAmountNow.ClientID%>').focus();
                    alert("Amount more than selected package price");
                    document.getElementById('<%=txtPDAmountNow.ClientID%>').value = ""
                    document.getElementById('<%=txtPDAmountNow.ClientID%>').focus()
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
             
             
            if(document.getElementById('<%=ddlPayStatus.ClientID%>').value =="2") 
            {
                 if(document.getElementById('<%= txtPayConfirmNum.ClientID%>').value.length < 1) {
                        document.getElementById('<%= txtPayConfirmNum.ClientID%>').focus();
                        alert("Enter Payment Trans ID");
                         document.getElementById('<%=txtPayConfirmNum.ClientID%>').value = ""
                        document.getElementById('<%=txtPayConfirmNum.ClientID%>').focus()
                        valid = false;            
                        return valid;     
                    }  
           
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
               
                  
                var string = $('#ddlPackage option:selected').text();
	            var p =string.split('$');
	            var pp = p[1].split(')');
	            //alert(pp[0]);
	            //pp[0] = parseInt(pp[0]);
	            pp[0] = parseFloat(pp[0]);
	            var selectedPack = pp[0].toFixed(2);
    	        
    	        
	           
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
                
                  
                var string = $('#ddlPackage option:selected').text();
	            var p =string.split('$');
	            var pp = p[1].split(')');
	            //alert(pp[0]);
	            //pp[0] = parseInt(pp[0]);
	            pp[0] = parseFloat(pp[0]);
	            var selectedPack = pp[0].toFixed(2);    	         
           }                 
              
        }
         return valid;
      }
       
       function EmailNAClick(){
        var checkbox = document.getElementById("chkbxEMailNA");
            if(checkbox.checked){                
                document.getElementById('<%= txtLoginEmail.ClientID%>').disabled  = true;            
            }
            else
            {
                document.getElementById('<%= txtLoginEmail.ClientID%>').disabled  = false;
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
     
    </script>

    <script type="text/javascript" language="javascript">
        function ValidateVehicleType()
        {
         
            var valid=true;   
             if ((document.getElementById('<%=txtEmailTo.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtEmailTo.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtEmailTo.ClientID%>').value = ""         
                document.getElementById('<%=txtEmailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
            }             
                    
          }   
         
        
          
        function CopySellerInfo()
        {
         
            var valid=true;   
             if (document.getElementById('<%= txtRegName.ClientID%>').value.length < 1)
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
                 document.getElementById('<%= txtCardholderName.ClientID%>').value=  document.getElementById('<%= txtRegName.ClientID%>').value;
                 document.getElementById('<%= txtbillingaddress.ClientID%>').value =   document.getElementById('<%= txtRegAddress.ClientID%>').value;                
                
                 document.getElementById('<%= txtbillingcity.ClientID%>').value = document.getElementById('<%= txtRegCity.ClientID%>').value;
                 document.getElementById('<%= txtbillingzip.ClientID%>').value =  document.getElementById('<%= txtregZip.ClientID%>').value;
                 document.getElementById('<%= ddlbillingstate.ClientID%>').value =  document.getElementById('<%= ddlRegState.ClientID%>').value;                 
                 
                                  
              }             
              return valid;      
        } 
        function CopySellerInfoForPay()
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
 $('#txtPDAmountNow').live('focus',function(){
        if($('#ddlPackage option:selected').text() == 'Select'){ 
            $('#ddlPackage').focus();
            alert('Select package');
        }
    });
     function OnchangeDropdown(){          
            if($('#ddlPackage option:selected').text() != 'Select'){  
               var string = $('#ddlPackage option:selected').text();
                var p =string.split('$');
                var pp = p[1].split(')');
                //alert(pp[0]);
                //pp[0] = parseInt(pp[0]);
                pp[0] = parseFloat(pp[0]);
                var selectedPack = pp[0].toFixed(2);
                selectedPack = parseFloat(selectedPack); 
                $('#txtPDAmountNow').val(selectedPack);
                 $('#txtTotalAmount').val(selectedPack);
                  if(document.getElementById('<%= chkboxlstPDsale.ClientID%>').checked == true)
                  {
                    $('#txtPDAmountLater').val('0.00');
                  }
                  else
                  {
                     $('#txtPDAmountLater').val('');
                  }
                }else{
                 $('#txtPDAmountNow').val('');
                 $('#txtTotalAmount').val('');
                  if(document.getElementById('<%= chkboxlstPDsale.ClientID%>').checked == true)
                  {
                    $('#txtPDAmountLater').val('');
                  }
                   else
                  {
                     $('#txtPDAmountLater').val('');
                  }
                }                            
                      
            }           
    /*
    $('#txtPDAmountNow').live('keydown', function(){
        //console.log($(this).val())
        $(this).val($(this).val().toString().replace(/^[0-9]\./g, ',').replace(/\./g, ''));
    });
    */
    
    
             
    $('#txtPDAmountNow').live('blur', function(){
            $('#txtPDAmountLater').val('');
            if($('#txtPDAmountNow').val().length>0 && ($('#ddlPackage option:selected').text() != 'Select')){   
                var curr = parseFloat($('#txtPDAmountNow').val());
                curr = curr.toFixed(2)         
                var string = $('#ddlPackage option:selected').text();
                var p =string.split('$');
                var pp = p[1].split(')');
                //alert(pp[0]);
                //pp[0] = parseInt(pp[0]);
                pp[0] = parseFloat(pp[0]);
                var selectedPack = pp[0].toFixed(2);
                selectedPack = parseFloat(selectedPack); 
                
                if(selectedPack < curr){
                    alert('Entered amount can not be graterthen selected package..')
                     document.getElementById('<%=txtPDAmountNow.ClientID%>').focus()
                }else{
                    var value = parseFloat(selectedPack-curr);
                    value = value.toFixed(2); 
                    $('#txtPDAmountLater').val(value);
                    $('#txtTotalAmount').val(selectedPack);
                }                            
                      
            }            
    });
    
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
                                            <td>
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
                                                    Email<span class="star">*</span>
                                                    <asp:CheckBox ID="chkbxEMailNA" runat="server" Text="NA" Font-Bold="true" onclick="return EmailNAClick();" /></h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="input3" MaxLength="40" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Password<span class="star">*</span></h4>
                                            </td>
                                            <td>
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
                            <td colspan='2' style="height: 50px; vertical-align: top; padding-top: 200px;">
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
                                            <table style="width: 99%; margin-left: 5px; height: 110px;" cellpadding='1' cellspacing='0'>
                                                <tr style="height: 23px; overflow: hidden;">
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Payment Status</h4>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlPayStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()"
                                                            OnSelectedIndexChanged="ddlPayStatus_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="1">Pending</asp:ListItem>
                                                            <asp:ListItem Value="5">Preliminary</asp:ListItem>
                                                            <asp:ListItem Value="2">Paid</asp:ListItem>
                                                        </asp:DropDownList>
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
                                                    <td colspan='2' style="height: 25px;">
                                                        <table style="width: 100%; display: none" cellpadding='0' cellspacing='0' id="tblPaymentDetails"
                                                            runat="server">
                                                            <tr id="trAdStatus" runat="server">
                                                                <td style="width: 112px">
                                                                    <h4 class="h43">
                                                                        Ad Status</h4>
                                                                </td>
                                                                <td>
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
                                                                    <asp:DropDownList ID="ddlListingStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                        <asp:ListItem Value="2">Preliminary</asp:ListItem>
                                                                        <asp:ListItem Value="3">Withdraw</asp:ListItem>
                                                                        <asp:ListItem Value="4">Sold</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="width: 100%; display: none" cellpadding='0' cellspacing='0' id="trUceStatus"
                                                            runat="server">
                                                            <tr>
                                                                <td style="width: 110px;">
                                                                    <h4 class="h43">
                                                                        Uce Status</h4>
                                                                </td>
                                                                <td style="width: 178px;">
                                                                    <asp:DropDownList ID="ddlUceStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                                                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 110px;">
                                                                    <h4 class="h43">
                                                                        Multisite Status</h4>
                                                                </td>
                                                                <td style="width: 178px;">
                                                                    <asp:DropDownList ID="ddlMultisiteStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                                                        <asp:ListItem Value="0">Inactive</asp:ListItem>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Address</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegAddress" runat="server" CssClass="input3" MaxLength="50" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    City</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegCity" runat="server" CssClass="input3" MaxLength="25" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
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
                <td colspan='5' style="padding: 84px 0 10px 0;">
                    <div style="height: 2px; border-top: 2px #999 solid" class="clear">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdtpnlSellerInfo" runat="server">
                        <ContentTemplate>
                            <div class="box1">
                                <h3>
                                    Seller Info To Display In The Ad
                                </h3>
                                <asp:LinkButton ID="lnkCopyRegInfo" runat="server" Text="Copy data from registration data"
                                    Style="text-align: right; float: right; padding: 5px;" OnClientClick="return CopySellerInfo();"></asp:LinkButton>
                                <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                Phone number</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCustPhoneNumber" CssClass="input3 number" MaxLength="10" runat="server"
                                                onkeyup="return ChangeValuesHidden()"></asp:TextBox>
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <h4 class="h43">
                                                City</h4>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="input3" MaxLength="25" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
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
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;" colspan="5">
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
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Heading</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTitle" runat="server" CssClass="input3" MaxLength="100" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Make<span class="star">*</span></h4>
                                                        </td>
                                                        <td style="width: 230px; padding-right: 20px;" align="left">
                                                            <asp:UpdatePanel ID="updtMake" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true" CssClass="input1"
                                                                        OnSelectedIndexChanged="ddlMake_SelectedIndexChanged" onchange="ChangeValuesHidden()">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Model<span class="star">*</span></h4>
                                                        </td>
                                                        <td style="width: 230px; padding-right: 20px;">
                                                            <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList ID="ddlModel" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                                    </asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Year<span class="star">*</span></h4>
                                                        </td>
                                                        <td style="width: 230px; padding-right: 20px;">
                                                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Type</h4>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblType" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Price $</h4>
                                                        </td>
                                                        <td style="width: 120px; padding-right: 20px;">
                                                            <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" CssClass="input3 number"
                                                                onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Mileage</h4>
                                                        </td>
                                                        <td style="width: 120px; padding-right: 20px;">
                                                            <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" CssClass="input3 number"
                                                                onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Engine Cylinders</h4>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdbtnCylinders1" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" /><span class="featNon">3</span>
                                                            <asp:RadioButton ID="rdbtnCylinders2" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" /><span class="featNon">4</span>
                                                            <asp:RadioButton ID="rdbtnCylinders3" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" /><span class="featNon">5</span>
                                                            <asp:RadioButton ID="rdbtnCylinders4" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" /><span class="featNon">6</span>
                                                            <asp:RadioButton ID="rdbtnCylinders5" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" /><span class="featNon">7</span>
                                                            <asp:RadioButton ID="rdbtnCylinders6" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" /><span class="featNon">8</span>
                                                            <asp:RadioButton ID="rdbtnCylinders7" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Body Style</h4>
                                                        </td>
                                                        <td style="width: 190px; padding-right: 20px;" align="left">
                                                            <asp:DropDownList ID="ddlBodyStyle" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Exterior Color</h4>
                                                        </td>
                                                        <td style="width: 190px; padding-right: 20px;" align="left">
                                                            <asp:DropDownList ID="ddlExteriorColor" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Interior Color</h4>
                                                        </td>
                                                        <td style="width: 190px; padding-right: 20px;" align="left">
                                                            <asp:DropDownList ID="ddlInteriorColor" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Transmission</h4>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdbtnTrans1" CssClass="noLM" Text="" GroupName="Transmission"
                                                                runat="server" /><span class="featNon">Auto</span>
                                                            <asp:RadioButton ID="rdbtnTrans2" CssClass="noLM" Text="" GroupName="Transmission"
                                                                runat="server" /><span class="featNon">Manual</span>
                                                            <asp:RadioButton ID="rdbtnTrans3" CssClass="noLM" Text="" GroupName="Transmission"
                                                                runat="server" /><span class="featNon">Tiptronic</span>
                                                            <asp:RadioButton ID="rdbtnTrans4" CssClass="noLM" Text="" GroupName="Transmission"
                                                                runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                        </td>
                                                        <td style="width: 80px;">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                Doors</h4>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdbtnDoor2" CssClass="noLM" Text="" GroupName="Doors" runat="server" /><span
                                                                class="featNon">2</span>
                                                            <asp:RadioButton ID="rdbtnDoor3" CssClass="noLM" Text="" GroupName="Doors" runat="server" /><span
                                                                class="featNon">3</span>
                                                            <asp:RadioButton ID="rdbtnDoor4" CssClass="noLM" Text="" GroupName="Doors" runat="server" /><span
                                                                class="featNon">4</span>
                                                            <asp:RadioButton ID="rdbtnDoor5" CssClass="noLM" Text="" GroupName="Doors" runat="server" /><span
                                                                class="featNon">5</span>
                                                            <asp:RadioButton ID="rdbtnDoor6" CssClass="noLM" Text="" GroupName="Doors" runat="server"
                                                                Checked="true" /><span class="featNon">NA</span> </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Drive Train</h4>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdbtnDriveTrain1" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                runat="server" /><span class="featNon">2WD</span>
                                                            <asp:RadioButton ID="rdbtnDriveTrain2" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                runat="server" /><span class="featNon">FWD</span>
                                                            <asp:RadioButton ID="rdbtnDriveTrain3" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                runat="server" /><span class="featNon">AWD</span>
                                                            <asp:RadioButton ID="rdbtnDriveTrain4" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                runat="server" /><span class="featNon">RWD</span>
                                                            <asp:RadioButton ID="rdbtnDriveTrain5" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                        </td>
                                                        <td style="width: 70px;">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <h4 class="h43">
                                                                VIN number</h4>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtVinNumber" runat="server" CssClass="input3" MaxLength="20" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Fuel Type</h4>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdbtnFuelType1" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">Diesel</span>
                                                            <asp:RadioButton ID="rdbtnFuelType2" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">Petrol</span>
                                                            <asp:RadioButton ID="rdbtnFuelType3" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">Hybrid</span>
                                                            <asp:RadioButton ID="rdbtnFuelType4" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">Electric</span>
                                                            <asp:RadioButton ID="rdbtnFuelType5" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">Gasoline</span>
                                                            <asp:RadioButton ID="rdbtnFuelType6" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">E-85</span>
                                                            <asp:RadioButton ID="rdbtnFuelType7" CssClass="noLM" Text="" GroupName="Fuels" runat="server" /><span
                                                                class="featNon">Gasoline-Hybrid</span>
                                                            <asp:RadioButton ID="rdbtnFuelType8" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                Checked="true" /><span class="featNon">NA</span> </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Vehicle Condition</h4>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rdbtnCondition1" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" /><span class="featNon">Excellent</span>
                                                            <asp:RadioButton ID="rdbtnCondition2" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" /><span class="featNon">Very good</span>
                                                            <asp:RadioButton ID="rdbtnCondition3" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" /><span class="featNon">Good</span>
                                                            <asp:RadioButton ID="rdbtnCondition4" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" /><span class="featNon">Fair</span>
                                                            <asp:RadioButton ID="rdbtnCondition5" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" /><span class="featNon">Poor</span>
                                                            <asp:RadioButton ID="rdbtnCondition6" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" /><span class="featNon">Parts or salvage</span>
                                                            <asp:RadioButton ID="rdbtnCondition7" CssClass="noLM" Text="" GroupName="Condition"
                                                                runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                        </td>
                                                    </tr>
                                                </table>
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
                            <td style="position: relative; z-index: 9; height: 420px; vertical-align: top">
                                <div class="box1 wid" style="width: 905px;">
                                    <h3>
                                        Vehicle Features</h3>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100px;">
                                                <strong>Comfort:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures51" runat="server" class="noLM" />
                                                <span class="featNon">A/C</span>
                                                <asp:CheckBox ID="chkFeatures1" runat="server" />
                                                <span class="featNon">A/C: Front</span>
                                                <asp:CheckBox ID="chkFeatures2" runat="server" class="noLM" />
                                                <span class="featNon">A/C: Rear</span>
                                                <asp:CheckBox ID="chkFeatures3" runat="server" class="noLM" />
                                                <span class="featNon">Cruise control</span>
                                                <asp:CheckBox ID="chkFeatures4" runat="server" class="noLM" />
                                                <span class="featNon">Navigation system</span>
                                                <asp:CheckBox ID="chkFeatures5" runat="server" class="noLM" />
                                                <span class="featNon">Power locks</span>
                                                <asp:CheckBox ID="chkFeatures6" runat="server" class="noLM" />
                                                <span class="featNon">Power steering</span>
                                                <br />
                                                <asp:CheckBox ID="chkFeatures7" runat="server" class="noLM" />
                                                <span class="featNon">Remote keyless entry</span>
                                                <asp:CheckBox ID="chkFeatures8" runat="server" class="noLM" />
                                                <span class="featNon">TV/VCR</span>
                                                <asp:CheckBox ID="chkFeatures31" runat="server" class="noLM" />
                                                <span class="featNon">Remote start</span>
                                                <asp:CheckBox ID="chkFeatures33" runat="server" class="noLM" />
                                                <span class="featNon">Tilt</span>
                                                <asp:CheckBox ID="chkFeatures35" runat="server" class="noLM" />
                                                <span class="featNon">Rearview camera</span>
                                                <asp:CheckBox ID="chkFeatures36" runat="server" class="noLM" />
                                                <span class="featNon">Power mirrors</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Seats:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures9" runat="server" class="noLM" />
                                                <span class="featNon">Bucket seats</span>
                                                <asp:CheckBox ID="chkFeatures11" runat="server" />
                                                <span class="featNon">Memory seats</span>
                                                <asp:CheckBox ID="chkFeatures12" runat="server" />
                                                <span class="featNon">Power seats</span>
                                                <asp:CheckBox ID="chkFeatures32" runat="server" />
                                                <span class="featNon">Heated seats</span>
                                                <br />
                                                <b style="color: #222; display: inline-block; margin-left: 163px;">Interior</b>
                                                :
                                                <asp:RadioButton ID="rdbtnLeather" runat="server" CssClass="noLM" GroupName="Seats"
                                                    Text="" /><span class="featNon">Leather</span>
                                                <asp:RadioButton ID="rdbtnVinyl" runat="server" CssClass="noLM" GroupName="Seats"
                                                    Text="" /><span class="featNon">Vinyl</span>
                                                <asp:RadioButton ID="rdbtnCloth" runat="server" CssClass="noLM" GroupName="Seats"
                                                    Text="" /><span class="featNon">Cloth</span>
                                                <asp:RadioButton ID="rdbtnInteriorNA" runat="server" CssClass="noLM" GroupName="Seats"
                                                    Text="" Checked="true" /><span class="featNon">NA</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Safety:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures13" runat="server" class="noLM" />
                                                <span class="featNon">Airbag: Driver</span>
                                                <asp:CheckBox ID="chkFeatures14" runat="server" class="noLM" />
                                                <span class="featNon">Airbag: Passenger</span>
                                                <asp:CheckBox ID="chkFeatures15" runat="server" class="noLM" />
                                                <span class="featNon">Airbag: Side</span>
                                                <asp:CheckBox ID="chkFeatures16" runat="server" class="noLM" />
                                                <span class="featNon">Alarm</span>
                                                <asp:CheckBox ID="chkFeatures17" runat="server" class="noLM" />
                                                <span class="featNon">Anti-lock brakes</span>
                                                <asp:CheckBox ID="chkFeatures18" runat="server" class="noLM" />
                                                <span class="featNon">Fog lights</span>
                                                <asp:CheckBox ID="chkFeatures39" runat="server" class="noLM" />
                                                <span class="featNon">Power brakes</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Sound System:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures19" runat="server" class="noLM" />
                                                <span class="featNon">Cassette radio</span>
                                                <asp:CheckBox ID="chkFeatures20" runat="server" class="noLM" />
                                                <span class="featNon">CD changer</span>
                                                <asp:CheckBox ID="chkFeatures21" runat="server" class="noLM" />
                                                <span class="featNon">CD player</span>
                                                <asp:CheckBox ID="chkFeatures22" runat="server" class="noLM" />
                                                <span class="featNon">Premium sound</span>
                                                <asp:CheckBox ID="chkFeatures34" runat="server" class="noLM" />
                                                <span class="featNon">AM/FM</span>
                                                <asp:CheckBox ID="chkFeatures40" runat="server" class="noLM" />
                                                <span class="featNon">DVD</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>New:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures44" runat="server" class="noLM" />
                                                <span class="featNon">Battery</span>
                                                <asp:CheckBox ID="chkFeatures45" runat="server" class="noLM" />
                                                <span class="featNon">Tires</span>
                                                <asp:CheckBox ID="chkFeatures52" runat="server" class="noLM" />
                                                <span class="featNon">Rotors</span>
                                                <asp:CheckBox ID="chkFeatures53" runat="server" class="noLM" />
                                                <span class="featNon">Brakes</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Windows:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures23" runat="server" class="noLM" />
                                                <span class="featNon">Power windows</span>
                                                <asp:CheckBox ID="chkFeatures24" runat="server" class="noLM" />
                                                <span class="featNon">Rear window defroster</span>
                                                <asp:CheckBox ID="chkFeatures25" runat="server" class="noLM" />
                                                <span class="featNon">Rear window wiper</span>
                                                <asp:CheckBox ID="chkFeatures26" runat="server" class="noLM" />
                                                <span class="featNon">Tinted glass</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Others:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures27" runat="server" class="noLM" />
                                                <span class="featNon">Alloy wheels</span>
                                                <asp:CheckBox ID="chkFeatures28" runat="server" class="noLM" />
                                                <span class="featNon">Sunroof</span>
                                                <asp:CheckBox ID="chkFeatures41" runat="server" class="noLM" />
                                                <span class="featNon">Panoramic roof</span>
                                                <asp:CheckBox ID="chkFeatures42" runat="server" class="noLM" />
                                                <span class="featNon">Moonroof</span>
                                                <asp:CheckBox ID="chkFeatures29" runat="server" class="noLM" />
                                                <span class="featNon">Third row seats</span>
                                                <asp:CheckBox ID="chkFeatures30" runat="server" class="noLM" />
                                                <span class="featNon">Tow package</span>
                                                <br />
                                                <asp:CheckBox ID="chkFeatures43" runat="server" class="noLM" />
                                                <span class="featNon">Dashboard wood frame</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="fDevider">
                                                <div>
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Specials:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeatures46" runat="server" class="noLM" />
                                                <span class="featNon">Garage kept</span>
                                                <asp:CheckBox ID="chkFeatures47" runat="server" class="noLM" />
                                                <span class="featNon">Non smoking</span>
                                                <asp:CheckBox ID="chkFeatures48" runat="server" class="noLM" />
                                                <span class="featNon">Records/Receipts kept</span>
                                                <asp:CheckBox ID="chkFeatures49" runat="server" class="noLM" />
                                                <span class="featNon">Well maintained</span>
                                                <asp:CheckBox ID="chkFeatures50" runat="server" class="noLM" />
                                                <span class="featNon">Regular oil changes</span>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clear">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 10px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="position: relative; z-index: 9; height: 130px; vertical-align: top">
                                <div class="box1 wid" style="width: 905px;">
                                    <h3>
                                        Other</h3>
                                    <table style="width: 99%; margin-left: 5px" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Description</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDescription" runat="server" Style="width: 98%; padding: 3px;
                                                    margin-top: 6px; height: 60px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"
                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                            <td style="width: 300px;">
                                                <table class="coll">
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Source of photos
                                                            </h4>
                                                        </td>
                                                        <td>
                                                            <h4 class="h4">
                                                                <asp:DropDownList ID="ddlPhotosSource" runat="server" onchange="ChangeValuesHidden()"
                                                                    CssClass="input1">
                                                                </asp:DropDownList>
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <h4 class="h43">
                                                                Source of description
                                                            </h4>
                                                        </td>
                                                        <td>
                                                            <h4 class="h4">
                                                                <asp:DropDownList ID="ddlDescriptionSource" runat="server" CssClass="input1">
                                                                </asp:DropDownList>
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 10px">
                                                &nbsp;
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
                            <td style="position: relative; z-index: 9; height: 455px; vertical-align: top">
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
                                                                                    runat="server" OnCheckedChanged="rdbtnPayVisa_CheckedChanged" AutoPostBack="true" />
                                                                                <asp:RadioButton ID="rdbtnPayMasterCard" CssClass="noLM" Text="Mastercard" GroupName="PayType"
                                                                                    runat="server" OnCheckedChanged="rdbtnPayMasterCard_CheckedChanged" AutoPostBack="true" />
                                                                                <asp:RadioButton ID="rdbtnPayDiscover" CssClass="noLM" Text="Discover" GroupName="PayType"
                                                                                    runat="server" OnCheckedChanged="rdbtnPayDiscover_CheckedChanged" AutoPostBack="true" />
                                                                                <asp:RadioButton ID="rdbtnPayAmex" CssClass="noLM" Text="Amex" GroupName="PayType"
                                                                                    runat="server" OnCheckedChanged="rdbtnPayAmex_CheckedChanged" AutoPostBack="true" />
                                                                                <asp:RadioButton ID="rdbtnPayPaypal" CssClass="noLM" Text="Paypal" GroupName="PayType"
                                                                                    runat="server" OnCheckedChanged="rdbtnPayPaypal_CheckedChanged" AutoPostBack="true" />
                                                                                <asp:RadioButton ID="rdbtnPayCheck" CssClass="noLM" Text="Check" GroupName="PayType"
                                                                                    runat="server" OnCheckedChanged="rdbtnPayCheck_CheckedChanged" AutoPostBack="true" />
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
                                                                                            <asp:LinkButton ID="lnkbtnCopySellerInfo" runat="server" Text="Copy name & address from Seller Information"
                                                                                                OnClientClick="return CopySellerInfo();" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
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
                                                                                        <asp:DropDownList ID="ExpMon" Style="width: 125px;" runat="server">
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
                                                                                        <asp:DropDownList ID="CCExpiresYear" Style="width: 125px" runat="server">
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
                                                                                            <asp:LinkButton ID="lnkbtnCopyCheckName" runat="server" Text="Copy name from Seller Information"
                                                                                                OnClientClick="return CopySellerInfoForCheck();" Style="color: Blue; text-decoration: underline;"></asp:LinkButton>
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
                                                                <table style="width: 627px;">
                                                                    <tr>
                                                                        <td colspan="2" style="padding: 10px 0 0 0">
                                                                            <h5 style="font-size: 15px; margin: 0; padding: 0">
                                                                                Payment Schedule</h5>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                        <td style="width: 130px; vertical-align: middle">
                                                                            <b>Today's Payment </b>
                                                                        </td>
                                                                        <td style="width: 100px; vertical-align: middle">
                                                                            <table style="width: 100%; border-collapse: collapse">
                                                                                <tr>
                                                                                    <td style="width: 36px">
                                                                                        <span class="star" style="color: #fff">*</span><strong style="width: 35px">Date</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPaymentDate" runat="server" CssClass="input1">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 100px; vertical-align: middle">
                                                                            <table style="width: 100%; border-collapse: collapse" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td style="width: 90px">
                                                                                        <span class="star" style="color: Red">*</span><strong style="width: 55px">Amount $</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtPDAmountNow" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                                            onkeyup="return ChangeValuesHidden()" Width="200px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="padding: 0; margin: 0; vertical-align: middle">
                                                                            <asp:CheckBox ID="chkboxlstPDsale" runat="server" CssClass="noLM" />
                                                                        </td>
                                                                        <td style="vertical-align: middle">
                                                                            <b>Post Dated Payment</b>
                                                                        </td>
                                                                        <td style="vertical-align: middle">
                                                                            <table style="width: 100%; border-collapse: collapse">
                                                                                <tr>
                                                                                    <td>
                                                                                        <span class="star" style="color: Red">*</span><strong style="width: 35px">Date</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPDDate" runat="server" onchange="ChangeValuesHidden()" Width="120px"
                                                                                            ForeColor="Red">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="vertical-align: middle">
                                                                            <table style="width: 100%; border-collapse: collapse">
                                                                                <tr>
                                                                                    <td style="width: 100px;">
                                                                                        <span class="star" style="color: #fff">*</span><strong>Amount $</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtPDAmountLater" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                                            onkeyup="return ChangeValuesHidden()" Enabled="false" Width="200px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                        </td>
                                                                        <td style="vertical-align: middle">
                                                                            <table style="width: 100%; border-collapse: collapse">
                                                                                <tr>
                                                                                    <td>
                                                                                        <span class="star" style="color: #fff">*</span><strong style="width: 55px">Total $</strong>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtTotalAmount" ReadOnly="true" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
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
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td style="padding-top: 10px; vertical-align: top;">
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
        <br />
    </div>
    <cc1:ModalPopupExtender ID="mpeViewregisterMail" runat="server" PopupControlID="divViewregisterMail"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewregisterMail" CancelControlID="btnCancelSendRegMail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewregisterMail" runat="server" />
    <div id="divViewregisterMail" class="PopUpHolder">
        <div class="main">
            <h4>
                Registration Mail
            </h4>
            <div class="dat">
                <div style="position: absolute; width: 300px; left: 250px; top: 50px;">
                    <table>
                        <tr>
                            <td>
                                <h3 class="h43">
                                    Mail To:
                                </h3>
                            </td>
                            <td>
                                <asp:Label ID="lblMailTo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3 class="h43">
                                    CC:
                                </h3>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmailTo" CssClass="input1" Width="160px" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
                <div>
                    <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblRegisMail" runat="server" Visible="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:Button ID="btnCancelSendRegMail" class="g-button btnUpdate" runat="server" Text="Cancel" />
                <asp:Button ID="btnSendregMail" class="g-button btnUpdate" runat="server" Text="Send"
                    OnClick="btnSendregMail_Click" OnClientClick="return ValidateVehicleType();" />
                <div class="clear">
                    &nbsp;</div>
                <br />
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" OkControlID="btnYes"
        CancelControlID="BtnCls">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" />
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
