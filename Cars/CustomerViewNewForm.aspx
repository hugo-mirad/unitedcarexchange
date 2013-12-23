<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerViewNewForm.aspx.cs"
    Inherits="CustomerViewNewForm" ValidateRequest="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: Car Sales System ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script src="Static/JS/CarsJScript.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/emulatetab.joelpurra.js"></script>

    <script type="text/javascript" src="js/plusastab.joelpurra.js"></script>

    <script type='text/javascript' language="javascript" src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript">
//<![CDATA[
        function poptastic(url)
        {
	    newwindow=window.open(url,'name','directories=no,titlebar=no,toolbar=no,location=no,status=no,menubar=no,height=420,width=300');
	        if (window.focus) {newwindow.focus()}
        }
//	JoelPurra.PlusAsTab.setOptions({
//	
//		
//		key: 13
//	});
    $(function() {
		$('.number').numeric();
		$('.price').formatCurrency();
        $('.mileage').formatCurrency({symbol: ' '}); 
        
        if( $('#lblISActiveStatus').text() == 'Inactive'){
            $('#addStatDisp').show();
        }else{
            $('#addStatDisp').hide();
        }
        
       
        
        
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
	     function  sample(){
            $('.price').formatCurrency();
            $('.mileage').formatCurrency({symbol: ' '});               
        } 
    </script>

    <style media="print">
        .Printyes
        {
            display: block;
        }
        .NoPrint
        {
            display: none;
        }
    </style>
    <style>
        .hidden
        {
            display: none;
        }
    </style>

    <script type="text/javascript" language="javascript">
        //-------------------------- Agents Centers Info END ------------------------------------------
//    $(window).load(function(){
//        TransfersInfoBinding();
//    })
  function TransfersInfoBinding(){
       youfunction()
        $(window).load(function(){
            //alert('Ok')
            youfunction()
        });            
     }
  

  
     function youfunction(){
        //alert('ok')
          $('#feat input[type=radio]').each(function(){
                if($(this).is(':checked')){
                    $(this).parent().next('span').addClass('featAct')  
                }    
                
            });
        
        
         $('#infoV input[type=radio]').each(function(){     
                 if($(this).is(':checked')){
                    $(this).parent().next('span').addClass('featAct')  
                }  
            });
        
        $('#feat input[type=checkbox]').each(function(){
                if($(this).is(':checked')){
                $(this).parent().next('span').addClass('featAct')  
                }  
        });
    
        $('#feat input[type=checkbox]').each(function(){
        
            $(this).click(function(){
                if($(this).parent().hasClass('noLM')){
                    $(this).parent().next('span').toggleClass('featAct')                    
                }else{
                    $(this).next('span').toggleClass('featAct')
                }
            })
        });
       
        
        
         $('#feat input[type=radio]').each(function(){
            $(this).click(function(){
              // var name = $(this).attr('name');
               $('#feat input[type=radio]').each(function(){
                    //if(name != $(this).attr('name')){
                        $(this).parent().next('span').removeClass('featAct')
                    //}
               });
               $(this).parent().next('span').addClass('featAct')             
               
            })
        });
        
        
         $('#infoV input[type=radio]').each(function(){
            $(this).click(function(){
               var name = $(this).attr('name');
               $('#infoV input[type=radio]').each(function(){
                    if(name == $(this).attr('name')){
                        $(this).parent().next('span').removeClass('featAct')
                    }
               })  
               $(this).parent().next('span').addClass('featAct')           
               
            })
        });
        
        //$(this).find('span.selected').toggle();	
        //$(this).find('label.selected').toggle(); 
        
       
        $('.hid').click(function(){			
			if($(this).attr('id') == 'Vinfo'){
				var str = '';
				
				if($('#lblVehMake').text().length>0){
				    str += $('#lblVehMake').text()+"-";	
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#lblVehModel').text().length>0){
				    str += $('#lblVehModel').text()+"-";	
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#lblVehYear').text().length>0){
				    str += $('#lblVehYear').text()+"-";	
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#txtAskingPrice').val().length>0){
					str += "<span class='price11'>"+$('#txtAskingPrice').val()+"</span>-";
				}
				else
				{
				    str += "Unspecified"+"-";
				}				
				if($('#txtMileage').val().length>1){
					str += $('#txtMileage').val();
				}
				else
				{
				   str += "Unspecified";
				}	
				if(($('#lblVehMake').text().length<1) &&($('#lblVehModel').text().length<1)&&($('#lblVehYear').text().length<1)&&($('#txtAskingPrice').val().length<1)&&($('#txtMileage').val().length<1))			
				{
				   str = "";
				}		
								
			    $('#Vinfo label').empty().append(str);	
			    $('.price11').formatCurrency();
				
			}    
			if($(this).next('div.hidden').is(':visible')){
                 $(this).find('span.selected').show();	
                $(this).find('label.selected').show();	
            }else{
                $(this).find('span.selected').hide();	
                $(this).find('label.selected').hide();	
               
            }  
           
         }); 
              
    }
    
    </script>

    <script type="text/javascript" language="javascript">
function ValidateVehiclePopup()
        {
         
            var valid=true;                
    
            
            if (document.getElementById('<%=ddlCallType.ClientID%>').value =="0")
            {
                alert('Please select call type')
                valid=false;
                document.getElementById('ddlCallType').focus();  
                return valid;
            }                    
             if (document.getElementById('<%=ddlCallReason.ClientID%>').value =="0")
            {
                alert('Please select call reason')
                valid=false;
                document.getElementById('ddlCallReason').focus();  
                return valid;
            }   
              if (document.getElementById('<%=ddlCallResolution.ClientID%>').value =="0")
            {
                alert('Please select call resolution')
                valid=false;
                document.getElementById('ddlCallResolution').focus();  
                return valid;
            }  
            
             if(document.getElementById('<%=TicketConfirm.ClientID%>').value == "true" ) 
             {
                    if (document.getElementById('<%=ddlTicketType.ClientID%>').value =="0")
                    {
                        alert('Please select ticket type')
                        valid=false;
                        document.getElementById('ddlTicketType').focus();  
                        return valid;
                    }   
                      if (document.getElementById('<%=ddlCallBack.ClientID%>').value =="0")
                    {
                        alert('Please select call back')
                        valid=false;
                        document.getElementById('ddlCallBack').focus();  
                        return valid;
                    }       
                        
             } 
              return valid;  
        
          }    
          
           function ValidateRegMailSend()
        {
          debugger
            var valid=true; 
            if (document.getElementById('<%=lblMailTo.ClientID%>').value.length < 1)
             {               
                alert("Please enter email address") 
                document.getElementById('<%=lblMailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
             }   
              if ((document.getElementById('<%=lblMailTo.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=lblMailTo.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=lblMailTo.ClientID%>').value = ""                  
                document.getElementById('<%=lblMailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
             }    
             if ((document.getElementById('<%=txtEmailTo.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtEmailTo.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtEmailTo.ClientID%>').value = ""                    
                document.getElementById('<%=txtEmailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
            }             
                    
          }
           function ValidateGeneralMail()
        {
         
            var valid=true;   
              if (document.getElementById('<%=lblGenMailTo.ClientID%>').value.length < 1)
             {               
                alert("Please enter email address") 
                document.getElementById('<%=lblGenMailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
             }   
             if ((document.getElementById('<%=lblGenMailTo.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=lblGenMailTo.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=lblGenMailTo.ClientID%>').value = ""         
                document.getElementById('<%=lblGenMailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
            }  
             if ((document.getElementById('<%=txtGenCCMail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtGenCCMail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtGenCCMail.ClientID%>').value = ""         
                document.getElementById('<%=txtGenCCMail.ClientID%>').focus()
                valid = false;              
                return valid;           
            }  
             if (document.getElementById('<%=txtGenSubject.ClientID%>').value.length < 0)
             {               
                alert("Please enter mail subject") 
                document.getElementById('<%=txtGenSubject.ClientID%>').focus()
                valid = false;              
                return valid;           
            }            
                    
          }
          
          function ValidateMultiSiteList()
          {
             var valid=true;   
             
              if (document.getElementById('<%=lblMultiSiteMailTo.ClientID%>').value.length < 1)
             {               
                alert("Please enter email address") 
                document.getElementById('<%=lblMultiSiteMailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
             }   
             if ((document.getElementById('<%=lblMultiSiteMailTo.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=lblMultiSiteMailTo.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=lblMultiSiteMailTo.ClientID%>').value = ""         
                document.getElementById('<%=lblMultiSiteMailTo.ClientID%>').focus()
                valid = false;              
                return valid;           
            }  
             if ((document.getElementById('<%=txtMultiListEmailToCC.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtMultiListEmailToCC.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtMultiListEmailToCC.ClientID%>').value = ""         
                document.getElementById('<%=txtMultiListEmailToCC.ClientID%>').focus()
                valid = false;              
                return valid;           
            }   
          }
             
          
        function ValidateData()
        {
            var valid = true;
            var today = new Date();
            var month = today.getMonth() + 1
            var day = today.getDate()
            var year = today.getFullYear()
            today = month + "/" + day + "/" + year
            var today = new Date(today);      

           
            if (document.getElementById('<%= txtPostDate.ClientID %>').value == '') {
                alert("Please enter callback date");
                document.getElementById('<%= txtPostDate.ClientID %>').value = '';
                document.getElementById('<%=txtPostDate.ClientID%>').focus();
                valid = false;
                return valid;
            }
             if (isDate(document.getElementById('<%= txtPostDate.ClientID %>').value) == false) {
                document.getElementById('<%=txtPostDate.ClientID%>').focus();
                valid = false;
                return valid;
            }   
            
            if (document.getElementById('<%=ddlAssignedTo.ClientID%>').value =="0")
            {
                alert('Please select assigned to')
                valid=false;
                document.getElementById('ddlAssignedTo').focus();  
                return valid;
            }  
            if (document.getElementById('<%=ddlCompletedBy.ClientID%>').value =="0")
            {
                alert('Please select completed by')
                valid=false;
                document.getElementById('ddlCompletedBy').focus();  
                return valid;
            }        
             
            if (document.getElementById('<%= txtCompletedDt.ClientID %>').value == '') {
                alert("Please enter completed date");
                document.getElementById('<%= txtCompletedDt.ClientID %>').value = '';
                document.getElementById('<%=txtCompletedDt.ClientID%>').focus();
                valid = false;
                return valid;
            }
             if (isDate(document.getElementById('<%= txtCompletedDt.ClientID %>').value) == false) {
                document.getElementById('<%=txtCompletedDt.ClientID%>').focus();
                valid = false;
                return valid;
            }   
             return valid;
        }
        
    </script>

    <script type="text/javascript" language="javascript">
	
	
	$(function(){	
	    	
		//$('.hid').next('div.hidden').hide();	
		$('.hid .selected').show();	
		
		$('.hid').live('click', function(){
		    $(this).next('div.hidden').slideToggle(); 
		    
		}) 
		   
		 	
		
		var str = '';
				if($('#lblVehMake').text().length>0){
				    str += $('#lblVehMake').text()+"-";	
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#lblVehModel').text().length>0){
				    str += $('#lblVehModel').text()+"-";	
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#lblVehYear').text().length>0){
				    str += $('#lblVehYear').text()+"-";	
				}
				else
				{
				    str += "Unspecified"+"-";
				}
				if($('#txtAskingPrice').val().length>0){
					str += "<span class='price11'>"+$('#txtAskingPrice').val()+"</span>-";
				}
				else
				{
				    str += "Unspecified"+"-";
				}				
				if($('#txtMileage').val().length>1){
					str += $('#txtMileage').val();
				}
				else
				{
				   str += "Unspecified";
				}	
				if(($('#lblVehMake').text().length<1) &&($('#lblVehModel').text().length<1)&&($('#lblVehYear').text().length<1)&&($('#txtAskingPrice').val().length<1)&&($('#txtMileage').val().length<1))			
				{
				   str = "";
				}		
								
				$('#Vinfo label').empty().append(str);	
				$('.price11').formatCurrency();	
		
		
			
			/* if($(this).next('div.hidden').is(':visible')){
			    $(this).find('span.selected').hide();	
			    $(this).find('label.selected').hide();	
			}else{
			    $(this).find('span.selected').show();	
			    $(this).find('label.selected').show();	
			}
			*/
			
					
	
		$('.sample4').numeric();	
		
		
		$('#txtAskingPrice').live('blur',function(){
		    if($('#txtAskingPrice').val().length >0){      
                 if($('#txtAskingPrice').val() == 0)
                 {
                    alert('Enter valid price');
                    $('#txtAskingPrice').focus();
                     return false;
                 }
              }
		    if($('#txtAskingPrice').val().length >2){
		         $('#txtAskingPrice').formatCurrency({ symbol: '' });
		    } 
		});		
		
		
		$('#txtAskingPrice').live('focus',function(){
		    if($('#txtAskingPrice').val().length >2){
		        var text = $('#txtAskingPrice').val();
		         //text = text.substring(1);
		         text = text.replace(',','');
		         $('#txtAskingPrice').val(text);
		           //alert(text)
		    }  
		    
		});
		
		$('#txtMileage').live('blur',function(){
		    if($('#txtMileage').val().length >0){
		     if($('#txtMileage').val()< 1000){ 
		     alert('Mileage must be greater than 1000')
		     $('#txtMileage').focus();
		     return false;
		     }   
		         $('#txtMileage').formatCurrency({ symbol: '' });
		         $('#txtMileage').val($('#txtMileage').val()+' mi')		    		    
		    } 
		});
		
		$('#txtMileage').live('focus',function(){
		    if($('#txtMileage').val().length >0){
		        var text = $('#txtMileage').val();
		         //text = text.substring(1);
		         text = text.replace(' mi','');
		         text = text.replace(',','');
		         $('#txtMileage').val(text);
		           //alert(text)
		    }  
		    
		});		
		
			
	})	
    </script>

    <script type='text/javascript'>
	$(function() {
	$('#ticType').hide();
        $('.tic input[name=Ticket]').change(function () { 
            //alert($(this).val());
            if($(this).val() == 'Yes'){
                $('#ticType').show();
                $('#TicketConfirm').val('true');
            }else if($(this).val() == 'No'){
                $('#ticType').hide();
                 $('#TicketConfirm').val('false');
            }
        });
        
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
 function ChangeValuesHidden()
      {
       document.getElementById("<%=hdnChange.ClientID%>").value ="1";
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
    
    
    
    $(function(){
    
        $('#feat input[type=radio]').each(function(){
            if($(this).is(':checked')){
                $(this).parent().next('span').addClass('featAct')  
            }    
            
        });
        
        
         $('#infoV input[type=radio]').each(function(){         
            if($(this).is(':checked')){
                $(this).parent().next('span').addClass('featAct')  
            }  
        });
       
       
    
        $('#feat input[type=checkbox]').each(function(){
            $(this).click(function(){
                if($(this).parent().hasClass('noLM')){
                    $(this).parent().next('span').toggleClass('featAct')
                }else{
                    $(this).next('span').toggleClass('featAct')
                }
            })
        });
       
        
        
         $('#feat input[type=radio]').each(function(){
            $(this).click(function(){
              // var name = $(this).attr('name');
               $('#feat input[type=radio]').each(function(){
                    //if(name != $(this).attr('name')){
                        $(this).parent().next('span').removeClass('featAct')
                    //}
               });
               $(this).parent().next('span').addClass('featAct')             
               
            })
        });
        
        
         $('#infoV input[type=radio]').each(function(){
            $(this).click(function(){
               var name = $(this).attr('name');
               $('#infoV input[type=radio]').each(function(){
                    if(name == $(this).attr('name')){
                        $(this).parent().next('span').removeClass('featAct')
                    }
               })  
               $(this).parent().next('span').addClass('featAct')           
               
            })
        });       
        
        $('.MyPrice').formatCurrency({ symbol: '' });
                
    });
    
    
   
    </script>

    <script type="text/javascript">
    
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
    
 function pageLoad()
   { 
      //InitializeTimer();      
   }
   
    var ssTime,TimerID;
   function  InitializeTimer()
   {  
     WebService.sessionGet(onsuccessGet,onError);      
   }
     function onsuccessGet(result)
     {
      ssTime=result; 
      ssTime=parseInt(ssTime)*60000;
     
      TimerDec(ssTime);
     }
   
  
   
   function  TimerDec(ssTime)
   {
   
     ssTime=ssTime-1000;
   
    TimerID=setTimeout(function(){TimerDec(ssTime);},1000);
      
    if(ssTime==60000)
    {      
     SessionInc();     
    }
     
   }
  
    
    function SessionInc()//Increase the session time
    {
     debugger    
      ssTime=parseInt("<%= Session.Timeout %>");     
      WebService.sessionSet(ssTime,onsuccessInc,onError);//call webservice to set the session variable
       ssTime=(parseInt(ssTime)-2)*60000;       
       TimerDec(ssTime);     
    }
    
    function onsuccessInc(result)
    {
     
    }    

     function onError(exception, userContext, methodName)
     {
       try 
       {
        //window.location.href='error.aspx';
        strMessage = strMessage + 'ErrorType: ' + exception._exceptionType + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Message: ' + exception._message + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Stack Trace: ' + exception._stackTrace + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Status Code: ' + exception._statusCode + '&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;';
        strMessage = strMessage + 'Timed Out: ' + exception._timedOut;
        ///alert(strMessage);
      } catch (ex) {}
     return false;
   }   
   
    
   
    </script>

    <script type="text/javascript" language="javascript">
    
     function ValidateRegEditSavedData()
      {
         var valid = true;         
            if(document.getElementById('<%= txtEditPassword.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtEditPassword.ClientID%>').focus();
            document.getElementById('<%=txtEditPassword.ClientID%>').value = "";
            alert("Enter password");
            valid = false; 
            return valid;                 

            }   
          
             if((document.getElementById('<%= txtEditPassword.ClientID%>').value.length > 0) && (document.getElementById('<%= txtEditPassword.ClientID%>').value.length < 5))
            {
                document.getElementById('<%= txtEditPassword.ClientID%>').focus();
                document.getElementById('<%=txtEditPassword.ClientID%>').value = "";
                alert("Password length must be 5 characters");
                valid = false;            
                 return valid;     
            }    
            
               if (document.getElementById('<%= txtEditName.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtEditName.ClientID%>').focus();
                alert("Enter customer name");
                document.getElementById('<%=txtEditName.ClientID%>').value = ""
                document.getElementById('<%=txtEditName.ClientID%>').focus()                
                valid = false;
                 return valid;     
              } 
              
              if (document.getElementById('<%= txtEditRegPhone.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtEditRegPhone.ClientID%>').focus();
                alert("Enter customer phone number");
                document.getElementById('<%=txtEditRegPhone.ClientID%>').value = ""
                document.getElementById('<%=txtEditRegPhone.ClientID%>').focus()                
                valid = false;
                 return valid;     
             }    
             if((document.getElementById('<%= txtEditRegPhone.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= txtEditRegPhone.ClientID%>').value.trim().length < 10)) {
                document.getElementById('<%= txtEditRegPhone.ClientID%>').focus();
                document.getElementById('<%=txtEditRegPhone.ClientID%>').value = "";
                alert("Enter valid phone number");
                valid = false; 
                 return valid;                
            
              }   
           
                 if(document.getElementById('<%= chkbxEMailNAEdit.ClientID%>').checked == false)
                {
                      if (document.getElementById('<%= txtEditRegEmail.ClientID%>').value.trim().length < 1) {
                        document.getElementById('<%= txtEditRegEmail.ClientID%>').focus();
                        alert("Enter customer email");
                        document.getElementById('<%=txtEditRegEmail.ClientID%>').value = ""
                        document.getElementById('<%=txtEditRegEmail.ClientID%>').focus()                
                        valid = false;
                         return valid;     
                     } 
                 }
            
              if ((document.getElementById('<%=txtEditRegEmail.ClientID%>').value.trim().length > 0) && (echeck(document.getElementById('<%=txtEditRegEmail.ClientID%>').value.trim()) == false) )
             {               
                document.getElementById('<%=txtEditRegEmail.ClientID%>').value = ""
                document.getElementById('<%=txtEditRegEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
             }  
             
            if((document.getElementById('<%= txtEditAltPhone.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= txtEditAltPhone.ClientID%>').value.trim().length < 10)) {
            document.getElementById('<%= txtEditAltPhone.ClientID%>').focus();
            document.getElementById('<%=txtEditAltPhone.ClientID%>').value = "";
            alert("Enter valid phone number");
            valid = false; 
             return valid;                
        
          }  
           if(document.getElementById('<%=txtEditRegZip.ClientID%>').value.trim().length > 0)
             {
                  var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtEditRegZip.ClientID%>').value);             
                   if (isValid == false)
                   {
                         document.getElementById('<%= txtEditRegZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('<%=txtEditRegZip.ClientID%>').value = ""
                    document.getElementById('<%=txtEditRegZip.ClientID%>').focus()
                    valid = false;  
                     return valid;      
                   }                                   
             }  
      }
    </script>

    <script type="text/javascript" language="javascript">
    
     function ValidateSellerEditSavedData()
      {
         var valid = true;         
              
              if (document.getElementById('<%= txtSellerEditPhone.ClientID%>').value.trim().length < 1) {
                document.getElementById('<%= txtSellerEditPhone.ClientID%>').focus();
                alert("Enter customer phone number");
                document.getElementById('<%=txtSellerEditPhone.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEditPhone.ClientID%>').focus()                
                valid = false;
                 return valid;     
             }    
             if((document.getElementById('<%= txtSellerEditPhone.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= txtSellerEditPhone.ClientID%>').value.trim().length < 10)) {
                document.getElementById('<%= txtSellerEditPhone.ClientID%>').focus();
                document.getElementById('<%=txtSellerEditPhone.ClientID%>').value = "";
                alert("Enter valid phone number");
                valid = false; 
                 return valid;                
            
              }              
            
              if ((document.getElementById('<%=txtSellerEditEmail.ClientID%>').value.trim().length > 0) && (echeck(document.getElementById('<%=txtSellerEditEmail.ClientID%>').value.trim()) == false) )
             {               
                document.getElementById('<%=txtSellerEditEmail.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEditEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
             }  
           
           if(document.getElementById('<%=txtSellerEditZip.ClientID%>').value.trim().length > 0)
             {
                  var isValid = /^[0-9]{5}(?:-[0-9]{4})?$/.test(document.getElementById('<%=txtSellerEditZip.ClientID%>').value);             
                   if (isValid == false)
                   {
                         document.getElementById('<%= txtSellerEditZip.ClientID%>').focus();
                    alert("Please enter valid zipcode");
                     document.getElementById('<%=txtSellerEditZip.ClientID%>').value = ""
                    document.getElementById('<%=txtSellerEditZip.ClientID%>').focus()
                    valid = false;  
                     return valid;      
                   }                                   
             }  
      }
    </script>

    <script type="text/javascript" language="javascript">
    
     function ValidateVehicleEditSavedData()
      {
         var valid = true;         
              
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
      }
    </script>

</head>
<body>
    <form id="form1" runat="server" data-plus-as-tab="true">
    <asp:ScriptManager ID="scrptmgr" runat="server" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdatePane1BtnSalesUpdate"
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
    <div style="height: 10px;">
    </div>
    <div style="width: 1250px; min-width: 1250px; margin: 0 auto">
        <div class="main" style="border: #ccc 1px solid; padding: 10px; background: rgb(253, 243, 234);
            margin: 0 10px; float: left;">
            <h1 class="h1">
                <asp:Label ID="lblMainHeadName" runat="server" Style="font-size: 16px; color: Navy;"></asp:Label>
                <div style="float: right; margin-right: 0;">
                    <asp:UpdatePanel ID="UpdatePane1BtnSalesUpdate" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnClose" runat="server" CssClass="g-button g-button-submit" Text="Close"
                                OnClick="btnClose_Click" />
                            <%-- <asp:Button ID="btnEdit" runat="server" CssClass="g-button g-button-submit" Text="Edit"
                                OnClick="btnEdit_Click" Visible="false" />--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </h1>
            <div style="height: 15px;">
                &nbsp;
            </div>
            <asp:UpdatePanel ID="updtpnl" runat="server">
                <ContentTemplate>
                    <table style="margin: 0 auto; width: 100%;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="padding: 0">
                                <div style="padding: 5px; margin: 0px; border: #444 1px dashed">
                                    <table style="border-collapse: collapse; width: 100%;">
                                        <tr>
                                            <td colspan="5" style="padding-top: 0px;">
                                                <h2 class="h200 hid">
                                                    Registration Information
                                                    <asp:Label ID="lblRegistrantSummary" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" id="registrationInformation" style="display: none;">
                                                    <fieldset>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="2" style="text-align: right">
                                                                    <asp:LinkButton ID="lnkRegdataEdit" runat="server" OnClick="lnkRegdataEdit_Click"
                                                                        Text="Edit"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 45px">User ID:</strong>
                                                                        <asp:Label ID="lblUserID" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Password:</strong>
                                                                        <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 50px">Name:</strong>
                                                                                    <asp:Label ID="lblRegName" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table style="width: 100%; border-collapse: collapse; padding: 0; margin: 0">
                                                                        <tr>
                                                                            <td style="padding: 2px 0 0 0;">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 40px">Email:</strong>
                                                                                    <asp:Label ID="lblRegEmail" runat="server" Width="315px"></asp:Label>
                                                                                    <asp:CheckBox ID="chkbxEMailNA" runat="server" Text="NA" Font-Bold="true" onclick="return EmailNAClick();"
                                                                                        Enabled="false" />
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 50px">Phone#:</strong>
                                                                                    <asp:Label ID="lblRegPhoneNumber" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table style="width: 100%; border-collapse: collapse; padding: 0; margin: 0">
                                                                        <tr>
                                                                            <td style="padding: 6px 0 0 0;">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 70px">Alt Phone#:</strong>
                                                                                    <asp:Label ID="lblRegAltPhone" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 50px">Address:</strong>
                                                                        <asp:Label ID="lblRegAddress" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td style="padding: 0;">
                                                                    <table style="padding: 4px 0 0 0; width: 100%;" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 220px;">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 30px">City:</strong>
                                                                                    <asp:Label ID="lblRegCity" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="width: 120px;">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 40px">State:</strong>
                                                                                    <asp:Label ID="lblRegState" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 25px">Zip:</strong>
                                                                                    <asp:Label ID="lblRegZip" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <h2 class="h200 hid">
                                                    Sale/Package Info
                                                    <%--  <label class="selected">
                                        4 Packages, 12 Vehicles; Payments pending</label>--%>
                                                    <asp:Label ID="lblSalePackageSummary" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0" style="width: 650px">
                                                                        <tr>
                                                                            <td style="width: 570px;">
                                                                                <strong>Package Details</strong>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <div class="clear height2">
                                                                        &nbsp;</div>
                                                                    <div style="width: 750px; position: relative; padding: 0 3px; height: 1px">
                                                                        <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                                                            padding-top: 2px; width: 730px; background: #fff;">
                                                                            <tr class="tbHed">
                                                                                <td width="50px">
                                                                                    ID
                                                                                </td>
                                                                                <td>
                                                                                    Package
                                                                                </td>
                                                                                <td width="100px">
                                                                                    Pmnt Status
                                                                                </td>
                                                                                <td width="100px">
                                                                                    Dt Of Purchase
                                                                                </td>
                                                                                <td width="80px">
                                                                                    ValidTill
                                                                                </td>
                                                                                <td width="110px">
                                                                                    # Of Posted Cars
                                                                                </td>
                                                                                <td width="110px">
                                                                                    # Of Max Cars
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div style="width: 750px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                                                        border: #ccc 1px solid; height: 100px">
                                                                        <asp:Panel ID="Panel5" Width="100%" runat="server">
                                                                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                                                <ContentTemplate>
                                                                                    <input style="width: 91px" id="Hidden9" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <input style="width: 40px" id="Hidden10" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <asp:GridView Width="730px" ID="grdPackagDetails" runat="server" CellSpacing="0"
                                                                                        CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                                                        ShowHeader="false" OnRowDataBound="grdPackagDetails_RowDataBound" OnRowCommand="grdPackagDetails_RowCommand">
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
                                                                                                    <asp:Label ID="lblUserPackID" runat="server" Text='<%# Eval("UserPackID")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <%-- <asp:Label ID="lblPackage" runat="server"></asp:Label>--%>
                                                                                                    <asp:LinkButton ID="lnkbtnPackage" runat="server" CommandArgument='<%# Eval("UserPackID")%>'
                                                                                                        CommandName="ShowPackage"></asp:LinkButton>
                                                                                                    <asp:HiddenField ID="hdnPackDescrip" runat="server" Value='<%# Eval("Description")%>' />
                                                                                                    <asp:HiddenField ID="hdnUserPackID" runat="server" Value='<%# Eval("UserPackID")%>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPmntStatus" runat="server" Text='<%# Eval("pmntStatus")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDtOfPurchase" runat="server" Text='<%# Bind("Paydate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                                    <asp:HiddenField ID="hdnDtOfPurchase" runat="server" Value='<%# Bind("Paydate", "{0:MM/dd/yy}") %>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ValidTill">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblValidTill" runat="server"></asp:Label>
                                                                                                    <asp:HiddenField ID="hdnValidTill" runat="server" Value='<%# Eval("Validityperiod")%>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblNoOfPostedCars" runat="server" Text='<%# Eval("CarsCount")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblMaxCars" runat="server" Text='<%# Eval("Maxcars")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="grdPackagDetails" EventName="Sorting" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 750px">
                                                                                <strong>Car Details</strong> (click on CarID number to view/edit car listing details)
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <div class="clear height2">
                                                                        &nbsp;</div>
                                                                    <div style="width: 890px; position: relative; padding: 0 3px; height: 1px">
                                                                        <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                                                            padding-top: 2px; width: 870px; background: #fff;">
                                                                            <tr class="tbHed">
                                                                                <td width="70px">
                                                                                    CarID
                                                                                </td>
                                                                                <td width="40px">
                                                                                    <asp:Label ID="lblStatusHeader" runat="server" Text="Status"></asp:Label>
                                                                                </td>
                                                                                <td width="70px">
                                                                                    Post Date
                                                                                </td>
                                                                                <td width="160px">
                                                                                    Package
                                                                                </td>
                                                                                <td width="120px">
                                                                                    Make
                                                                                </td>
                                                                                <td>
                                                                                    Model
                                                                                </td>
                                                                                <td width="50px">
                                                                                    Year
                                                                                </td>
                                                                                <td width="70px">
                                                                                    Miles
                                                                                </td>
                                                                                <td width="70px">
                                                                                    Price
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div style="width: 890px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                                                        border: #ccc 1px solid; height: 250px">
                                                                        <asp:Panel ID="Panel6" Width="100%" runat="server">
                                                                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                                                                <ContentTemplate>
                                                                                    <input style="width: 91px" id="Hidden11" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <input style="width: 40px" id="Hidden12" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <asp:GridView Width="870px" ID="grdCarDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                                                        CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                                                        OnRowCommand="grdCarDetails_RowCommand" OnRowDataBound="grdCarDetails_RowDataBound">
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
                                                                                                    <%--  <asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                                                                    <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                                                        CommandName="EditCar"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Image ID="ImgStatus" runat="server" />
                                                                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("isActive")%>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="40px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPostDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                                                                    <asp:HiddenField ID="hdnPackDescription" runat="server" Value='<%# Eval("PackageName")%>' />
                                                                                                    <asp:HiddenField ID="hdnPackUserPackID" runat="server" Value='<%# Eval("UserPackID")%>' />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblModel" runat="server" Text='<%# Eval("model")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblMiles" runat="server" Text='<%# Eval("mileage")%>' CssClass="sample4 MyPrice"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price")%>' CssClass="sample4 MyPrice"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="grdCarDetails" EventName="Sorting" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <h2 class="h200 hid">
                                                    Log History
                                                    <label class="selected">
                                                    </label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div>
                                                                        <asp:Label ID="lblUserLogresults" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div style="width: 450px; position: relative; padding: 0 3px; height: 1px">
                                                                        <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                                                            padding-top: 2px; width: 430px; background: #fff;">
                                                                            <tr class="tbHed">
                                                                                <td width="50px">
                                                                                    Sno
                                                                                </td>
                                                                                <td width="120px">
                                                                                    Login Date
                                                                                </td>
                                                                                <td>
                                                                                    Login IP
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div style="width: 450px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                                                        border: #ccc 1px solid; height: 100px">
                                                                        <asp:Panel ID="Panel7" Width="100%" runat="server">
                                                                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                                <ContentTemplate>
                                                                                    <input style="width: 91px" id="Hidden13" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <input style="width: 40px" id="Hidden14" type="hidden" runat="server" enableviewstate="true" />
                                                                                    <asp:GridView Width="430px" ID="grdUserLog" runat="server" CellSpacing="0" CellPadding="0"
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
                                                                                                    <%# ((GridViewRow)Container).RowIndex + 1%>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblLoginDate" runat="server" Text='<%# Bind("UCELoginDate", "{0:MM/dd/yyyy hh:mm tt}") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="ValidTill">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblLoginIP" runat="server" Text='<%# Eval("UCELoginIP")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:AsyncPostBackTrigger ControlID="grdUserLog" EventName="Sorting" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </asp:Panel>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0">
                                <div style="padding: 5px; margin: 0; border: #444 1px dashed">
                                    <table style="border-collapse: collapse; width: 100%;">
                                        <tr>
                                            <td colspan="5">
                                                <h2 class="h200 hid">
                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" style="display: block">
                                                    <fieldset>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Car ID:</strong>
                                                                        <asp:Label ID="lblCarID" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Sale Date:</strong>
                                                                        <asp:Label ID="lblSaleDate" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Tickets:</strong>
                                                                        <asp:Label ID="lblTicketsSummaryTop" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Package:</strong>
                                                                        <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Ad Status:</strong>
                                                                        <asp:Label ID="lblAdStatus" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 110px">Payment Status:</strong>
                                                                        <asp:Label ID="lblPaymentStatus" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 85px">Welcome Call:</strong>
                                                                        <asp:Label ID="lblWelcomeCall" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <h2 class="h200 hid">
                                                    Ad Status
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <table style="width: 100%;" cellpadding="1" cellspacing="0">
                                                            <tr>
                                                                <td colspan="2" style="text-align: right">
                                                                    <asp:LinkButton ID="lnkbtnAdStatusdataEdit" runat="server" OnClick="lnkbtnAdStatusdataEdit_Click"
                                                                        Text="Edit"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 75px">Uce Status:</strong>
                                                                        <asp:Label ID="lblUceStatus" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 105px">Multisite Status:</strong>
                                                                        <asp:Label ID="lblMultiSiteStatus" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Ad Status:</strong>
                                                                        <asp:Label ID="lblISActiveStatus" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td id="addStatDisp" runat="server">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 110px">Ad Status Details:</strong>
                                                                        <asp:Label ID="lblListingStatus" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Seller Information For Ad<div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" id="sellerInformation" style="display: none;">
                                                    <fieldset>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="2" style="text-align: right">
                                                                    <asp:LinkButton ID="lnkbtnSellerdataEdit" runat="server" OnClick="lnkbtnSellerdataEdit_Click"
                                                                        Text="Edit"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none">
                                                                <td style="width: 50%;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">First name:</strong>
                                                                        <asp:Label ID="lblSellerFirstName" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Last name:</strong>
                                                                        <asp:Label ID="lblLastName" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 50%;">
                                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 50px">Phone#:</strong>
                                                                                    <asp:Label ID="lblSellerPhone" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    <table style="width: 100%; border-collapse: collapse;">
                                                                        <tr>
                                                                            <td style="padding: 5px 0 0 0">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 40px">Email:</strong>
                                                                                    <asp:Label ID="lblSellerEmail" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="display: none;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 50px">Address:</strong>
                                                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td style="padding: 10px 2px 0 2px">
                                                                    <table style="padding: 0; width: 100%; border-collapse: collapse;">
                                                                        <tr>
                                                                            <td style="width: 220px; padding: 0 2px">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 30px">City:</strong>
                                                                                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="width: 120px; padding: 0 2px">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 40px">State:</strong>
                                                                                    <asp:Label ID="lblSellerState" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="padding: 0 2px">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 25px">Zip:</strong>
                                                                                    <asp:Label ID="lblSellerZip" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid" id="Vinfo">
                                                    Vehicle Information
                                                    <label class="selected">
                                                    </label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" id="infoV">
                                                    <fieldset>
                                                        <table style="width: 100%;">
                                                            <tr>
                                                                <td colspan="3" style="text-align: right">
                                                                    <asp:LinkButton ID="lnkbtnVehicleInfoEdit" runat="server" OnClick="lnkbtnVehicleInfoEdit_Click"
                                                                        Text="Edit"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 330px;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 40px;">Make:</strong>
                                                                        <asp:Label ID="lblVehMake" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td style="width: 330px">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 40px;">Model:</strong>
                                                                        <asp:Label ID="lblVehModel" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 40px;">Year:</strong>
                                                                        <asp:Label ID="lblVehYear" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0;">
                                                                    <table style="padding: 0; width: 99%;">
                                                                        <tr>
                                                                            <td style="width: 270px">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 45px">Price $:</strong>
                                                                                    <asp:TextBox ID="txtAskingPrice" runat="server" MaxLength="6" class="sample4 MyPrice"
                                                                                        onkeypress="return isNumberKey(event);" Enabled="false"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="width: 190px">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 40px">Mileage:</strong>
                                                                                    <asp:TextBox ID="txtMileage" runat="server" MaxLength="6" class="sample4 MyPrice"
                                                                                        onkeypress="return isNumberKey(event);" Enabled="false"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                            <td valign="bottom">
                                                                                <h4 class="h4 noB">
                                                                                    <strong style="width: 50px">Cylinders:</strong><span style="font-weight: bold">
                                                                                        <asp:RadioButton ID="rdbtnCylinders1" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Enabled="false" /><span class="featNon">3</span>
                                                                                        <asp:RadioButton ID="rdbtnCylinders2" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Enabled="false" /><span class="featNon">4</span>
                                                                                        <asp:RadioButton ID="rdbtnCylinders3" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Enabled="false" /><span class="featNon">5</span>
                                                                                        <asp:RadioButton ID="rdbtnCylinders4" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Enabled="false" /><span class="featNon">6</span>
                                                                                        <asp:RadioButton ID="rdbtnCylinders5" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Enabled="false" /><span class="featNon">7</span>
                                                                                        <asp:RadioButton ID="rdbtnCylinders6" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Enabled="false" /><span class="featNon">8</span>
                                                                                        <asp:RadioButton ID="rdbtnCylinders7" CssClass="noLM" Text="" GroupName="Cylinders"
                                                                                            runat="server" Checked="true" Enabled="false" /><span class="featNon">NA</span>
                                                                                    </span>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 65px">Body style:</strong>
                                                                        <asp:Label ID="lblBodyStyle" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 80px">Exterior color:</strong>
                                                                        <asp:Label ID="lblExteriorColor" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                                <td>
                                                                    <h4 class="h4">
                                                                        <strong style="width: 80px">Interior color:</strong>
                                                                        <asp:Label ID="lblInteriorColor" runat="server"></asp:Label>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0">
                                                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 50%;">
                                                                                <h4 class="h4 noB">
                                                                                    <strong style="width: 45px">Transmission:</strong><span style="font-weight: bold">
                                                                                        <asp:RadioButton ID="rdbtnTrans1" CssClass="noLM" Text="" GroupName="Transmission"
                                                                                            runat="server" Enabled="false" /><span class="featNon">Auto</span>
                                                                                        <asp:RadioButton ID="rdbtnTrans2" CssClass="noLM" Text="" GroupName="Transmission"
                                                                                            runat="server" Enabled="false" /><span class="featNon">Manual</span>
                                                                                        <asp:RadioButton ID="rdbtnTrans3" CssClass="noLM" Text="" GroupName="Transmission"
                                                                                            runat="server" Enabled="false" /><span class="featNon">Tiptronic</span>
                                                                                        <asp:RadioButton ID="rdbtnTrans4" CssClass="noLM" Text="" GroupName="Transmission"
                                                                                            runat="server" Checked="true" Enabled="false" /><span class="featNon">NA</span>
                                                                                    </span>
                                                                                </h4>
                                                                            </td>
                                                                            <td>
                                                                                <h4 class="h4 noB">
                                                                                    <strong style="width: 45px">Doors:</strong><span>
                                                                                        <asp:RadioButton ID="rdbtnDoor2" CssClass="noLM" Text="" GroupName="Doors" runat="server"
                                                                                            Enabled="false" /><span class="featNon">2</span>
                                                                                        <asp:RadioButton ID="rdbtnDoor3" CssClass="noLM" Text="" GroupName="Doors" runat="server"
                                                                                            Enabled="false" /><span class="featNon">3</span>
                                                                                        <asp:RadioButton ID="rdbtnDoor4" CssClass="noLM" Text="" GroupName="Doors" runat="server"
                                                                                            Enabled="false" /><span class="featNon">4</span>
                                                                                        <asp:RadioButton ID="rdbtnDoor5" CssClass="noLM" Text="" GroupName="Doors" runat="server"
                                                                                            Enabled="false" /><span class="featNon">5</span>
                                                                                        <asp:RadioButton ID="rdbtnDoor6" CssClass="noLM" Text="" GroupName="Doors" runat="server"
                                                                                            Checked="true" Enabled="false" /><span class="featNon">NA</span> </span>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0;">
                                                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 50%;">
                                                                                <h4 class="h4 noB">
                                                                                    <strong style="width: 65px">Drive train:</strong><span style="font-weight: bold">
                                                                                        <asp:RadioButton ID="rdbtnDriveTrain1" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                                            runat="server" Enabled="false" /><span class="featNon">2WD</span>
                                                                                        <asp:RadioButton ID="rdbtnDriveTrain2" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                                            runat="server" Enabled="false" /><span class="featNon">FWD</span>
                                                                                        <asp:RadioButton ID="rdbtnDriveTrain3" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                                            runat="server" Enabled="false" /><span class="featNon">AWD</span>
                                                                                        <asp:RadioButton ID="rdbtnDriveTrain4" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                                            runat="server" Enabled="false" /><span class="featNon">RWD</span>
                                                                                        <asp:RadioButton ID="rdbtnDriveTrain5" CssClass="noLM" Text="" GroupName="DriveTrain"
                                                                                            runat="server" Checked="true" Enabled="false" /><span class="featNon">NA</span>
                                                                                    </span>
                                                                                </h4>
                                                                            </td>
                                                                            <td>
                                                                                <h4 class="h4">
                                                                                    <strong>VIN #:</strong>
                                                                                    <asp:Label ID="lblVin" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3">
                                                                    <h4 class="h4 noB">
                                                                        <strong style="width: 55px">Fuel type:</strong><span style="font-weight: bold">
                                                                            <asp:RadioButton ID="rdbtnFuelType1" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">Diesel</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType2" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">Petrol</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType3" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">Hybrid</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType4" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">Electric</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType5" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">Gasoline</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType6" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">E-85</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType7" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Enabled="false" /><span class="featNon">Gasoline-Hybrid</span>
                                                                            <asp:RadioButton ID="rdbtnFuelType8" CssClass="noLM" Text="" GroupName="Fuels" runat="server"
                                                                                Checked="true" Enabled="false" /><span class="featNon">NA</span> </span>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="3" style="padding: 0;">
                                                                    <h4 class="h4 noB">
                                                                        <strong style="width: 45px">Condition:</strong><span style="font-weight: bold">
                                                                            <asp:RadioButton ID="rdbtnCondition1" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Enabled="false" /><span class="featNon">Excellent</span>
                                                                            <asp:RadioButton ID="rdbtnCondition2" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Enabled="false" /><span class="featNon">Very good</span>
                                                                            <asp:RadioButton ID="rdbtnCondition3" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Enabled="false" /><span class="featNon">Good</span>
                                                                            <asp:RadioButton ID="rdbtnCondition4" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Enabled="false" /><span class="featNon">Fair</span>
                                                                            <asp:RadioButton ID="rdbtnCondition5" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Enabled="false" /><span class="featNon">Poor</span>
                                                                            <asp:RadioButton ID="rdbtnCondition6" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Enabled="false" /><span class="featNon">Parts or salvage</span>
                                                                            <asp:RadioButton ID="rdbtnCondition7" CssClass="noLM" Text="" GroupName="Condition"
                                                                                runat="server" Checked="true" Enabled="false" /><span class="featNon">NA</span>
                                                                        </span>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Vehicle Features<div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" id="feat">
                                                    <fieldset>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td colspan="2" style="text-align: right">
                                                                    <asp:LinkButton ID="lnkbtnEditVehicleFeat" runat="server" OnClick="lnkbtnEditVehicleFeat_Click"
                                                                        Text="Edit"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 90px;">
                                                                    <strong>Comfort:</strong>
                                                                </td>
                                                                <td style="font-weight: bold; color: #666;">
                                                                    <asp:CheckBox ID="chkFeatures51" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">A/C</span>
                                                                    <asp:CheckBox ID="chkFeatures1" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">A/C: Front</span>
                                                                    <asp:CheckBox ID="chkFeatures2" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">A/C: Rear</span>
                                                                    <asp:CheckBox ID="chkFeatures3" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Cruise control</span>
                                                                    <asp:CheckBox ID="chkFeatures4" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Navigation system</span>
                                                                    <asp:CheckBox ID="chkFeatures5" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Power locks</span>
                                                                    <asp:CheckBox ID="chkFeatures6" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Power steering</span>
                                                                    <br />
                                                                    <asp:CheckBox ID="chkFeatures7" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Remote keyless entry</span>
                                                                    <asp:CheckBox ID="chkFeatures8" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">TV/VCR</span>
                                                                    <asp:CheckBox ID="chkFeatures31" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Remote start</span>
                                                                    <asp:CheckBox ID="chkFeatures33" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Tilt</span>
                                                                    <asp:CheckBox ID="chkFeatures35" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Rearview camera</span>
                                                                    <asp:CheckBox ID="chkFeatures36" runat="server" class="noLM" Enabled="false" />
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
                                                                    <asp:CheckBox ID="chkFeatures9" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Bucket seats</span>
                                                                    <asp:CheckBox ID="chkFeatures11" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Memory seats</span>
                                                                    <asp:CheckBox ID="chkFeatures12" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Power seats</span>
                                                                    <asp:CheckBox ID="chkFeatures32" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Heated seats</span>
                                                                    <br />
                                                                    <b style="color: #222; display: inline-block; margin-left: 163px;">Interior:</b>
                                                                    <asp:RadioButton ID="rdbtnLeather" runat="server" CssClass="noLM" GroupName="Seats"
                                                                        Text="" Enabled="false" /><span class="featNon">Leather</span>
                                                                    <asp:RadioButton ID="rdbtnVinyl" runat="server" CssClass="noLM" GroupName="Seats"
                                                                        Text="" Enabled="false" /><span class="featNon">Vinyl</span>
                                                                    <asp:RadioButton ID="rdbtnCloth" runat="server" CssClass="noLM" GroupName="Seats"
                                                                        Text="" Enabled="false" /><span class="featNon">Cloth</span>
                                                                    <asp:RadioButton ID="rdbtnInteriorNA" runat="server" CssClass="noLM" GroupName="Seats"
                                                                        Text="" Checked="true" Enabled="false" /><span class="featNon">NA</span>
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
                                                                    <asp:CheckBox ID="chkFeatures13" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Airbag: Driver</span>
                                                                    <asp:CheckBox ID="chkFeatures14" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Airbag: Passenger</span>
                                                                    <asp:CheckBox ID="chkFeatures15" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Airbag: Side</span>
                                                                    <asp:CheckBox ID="chkFeatures16" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Alarm</span>
                                                                    <asp:CheckBox ID="chkFeatures17" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Anti-lock brakes</span>
                                                                    <asp:CheckBox ID="chkFeatures18" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Fog lights</span>
                                                                    <asp:CheckBox ID="chkFeatures39" runat="server" class="noLM" Enabled="false" />
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
                                                                    <asp:CheckBox ID="chkFeatures19" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Cassette radio</span>
                                                                    <asp:CheckBox ID="chkFeatures20" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">CD changer</span>
                                                                    <asp:CheckBox ID="chkFeatures21" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">CD player</span>
                                                                    <asp:CheckBox ID="chkFeatures22" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Premium sound</span>
                                                                    <asp:CheckBox ID="chkFeatures34" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">AM/FM</span>
                                                                    <asp:CheckBox ID="chkFeatures40" runat="server" class="noLM" Enabled="false" />
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
                                                                    <asp:CheckBox ID="chkFeatures44" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Battery</span>
                                                                    <asp:CheckBox ID="chkFeatures45" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Tires</span>
                                                                    <asp:CheckBox ID="chkFeatures52" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Rotors</span>
                                                                    <asp:CheckBox ID="chkFeatures53" runat="server" class="noLM" Enabled="false" />
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
                                                                    <asp:CheckBox ID="chkFeatures23" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Power windows</span>
                                                                    <asp:CheckBox ID="chkFeatures24" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Rear window defroster</span>
                                                                    <asp:CheckBox ID="chkFeatures25" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Rear window wiper</span>
                                                                    <asp:CheckBox ID="chkFeatures26" runat="server" class="noLM" Enabled="false" />
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
                                                                    <asp:CheckBox ID="chkFeatures27" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Alloy wheels</span>
                                                                    <asp:CheckBox ID="chkFeatures28" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Sunroof</span>
                                                                    <asp:CheckBox ID="chkFeatures41" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Panoramic roof</span>
                                                                    <asp:CheckBox ID="chkFeatures42" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Moonroof</span>
                                                                    <asp:CheckBox ID="chkFeatures29" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Third row seats</span>
                                                                    <asp:CheckBox ID="chkFeatures30" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Tow package</span>
                                                                    <br />
                                                                    <asp:CheckBox ID="chkFeatures43" runat="server" class="noLM" Enabled="false" />
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
                                                                    <asp:CheckBox ID="chkFeatures46" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Garage kept</span>
                                                                    <asp:CheckBox ID="chkFeatures47" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Non smoking</span>
                                                                    <asp:CheckBox ID="chkFeatures48" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Records/Receipts kept</span>
                                                                    <asp:CheckBox ID="chkFeatures49" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Well maintained</span>
                                                                    <asp:CheckBox ID="chkFeatures50" runat="server" class="noLM" Enabled="false" />
                                                                    <span class="featNon">Regular oil changes</span>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Vehicle Description
                                                    <asp:Label ID="lblVehDescripSummary" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset style="height: 80px;">
                                                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="1000" Style="width: 99%;
                                                            height: 75px; resize: none;" TextMode="MultiLine" CssClass="textAr" data-plus-as-tab="false"
                                                            Enabled="false"></asp:TextBox>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Photos
                                                    <asp:Label ID="lblResult" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" id="photos" style="display: none;">
                                                    <fieldset>
                                                        <table id="tblImages" runat="server" width="100%">
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:Label ID="lblResultPhotos" runat="server"></asp:Label>
                                                                    <asp:LinkButton ID="lnkbtnShowAllPhotosUploaded" runat="server" Text="Show All" OnClick="lnkbtnShowAllPhotosUploaded_Click"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trImg1" runat="server" style="width: 180px;">
                                                                    <asp:Image ID="Img1" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete1" runat="server" CssClass="butRotate" OnClick="btnDelete1_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg2" runat="server" style="width: 180px;">
                                                                    <asp:Image ID="Img2" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete2" runat="server" CssClass="butRotate" OnClick="btnDelete2_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg3" runat="server" style="width: 180px;">
                                                                    <asp:Image ID="Img3" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete3" runat="server" CssClass="butRotate" OnClick="btnDelete3_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg4" runat="server" style="width: 180px;">
                                                                    <asp:Image ID="Img4" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete4" runat="server" CssClass="butRotate" OnClick="btnDelete4_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg5" runat="server">
                                                                    <asp:Image ID="Img5" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete5" runat="server" CssClass="butRotate" OnClick="btnDelete5_Click"
                                                                        Visible="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trImg6" runat="server">
                                                                    <asp:Image ID="Img6" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete6" runat="server" CssClass="butRotate" OnClick="btnDelete6_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg7" runat="server">
                                                                    <asp:Image ID="Img7" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete7" runat="server" CssClass="butRotate" OnClick="btnDelete7_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg8" runat="server">
                                                                    <asp:Image ID="Img8" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete8" runat="server" CssClass="butRotate" OnClick="btnDelete8_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg9" runat="server">
                                                                    <asp:Image ID="Img9" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete9" runat="server" CssClass="butRotate" OnClick="btnDelete9_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg10" runat="server">
                                                                    <asp:Image ID="Img10" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete10" runat="server" CssClass="butRotate" OnClick="btnDelete10_Click"
                                                                        Visible="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trImg11" runat="server">
                                                                    <asp:Image ID="Img11" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete11" runat="server" CssClass="butRotate" OnClick="btnDelete11_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg12" runat="server">
                                                                    <asp:Image ID="Img12" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete12" runat="server" CssClass="butRotate" OnClick="btnDelete12_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg13" runat="server">
                                                                    <asp:Image ID="Img13" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete13" runat="server" CssClass="butRotate" OnClick="btnDelete13_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg14" runat="server">
                                                                    <asp:Image ID="Img14" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete14" runat="server" CssClass="butRotate" OnClick="btnDelete14_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg15" runat="server">
                                                                    <asp:Image ID="Img15" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete15" runat="server" CssClass="butRotate" OnClick="btnDelete15_Click"
                                                                        Visible="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td id="trImg16" runat="server">
                                                                    <asp:Image ID="Img16" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete16" runat="server" CssClass="butRotate" OnClick="btnDelete16_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg17" runat="server">
                                                                    <asp:Image ID="Img17" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete17" runat="server" CssClass="butRotate" OnClick="btnDelete17_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg18" runat="server">
                                                                    <asp:Image ID="Img18" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete18" runat="server" CssClass="butRotate" OnClick="btnDelete18_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg19" runat="server">
                                                                    <asp:Image ID="Img19" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete19" runat="server" CssClass="butRotate" OnClick="btnDelete19_Click"
                                                                        Visible="false" />
                                                                </td>
                                                                <td id="trImg20" runat="server">
                                                                    <asp:Image ID="Img20" runat="server" CssClass="imgThumb" Visible="false" />
                                                                    <asp:Button ID="btnDelete20" runat="server" CssClass="butRotate" OnClick="btnDelete20_Click"
                                                                        Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--   <asp:DataList ID="dtlstImages" runat="server" RepeatColumns="7" RepeatDirection="Horizontal"
                                        OnItemDataBound="dtlstImages_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Image ID="ImgImages" runat="server" CssClass="imgThumb" />
                                            <asp:HiddenField ID="hdnColumnPic" runat="server" Value='<%# Eval("ColumnPic") %>' />
                                            <asp:HiddenField ID="hdnColumnPicLocation" runat="server" Value='<%# Eval("ColumnPicLocation") %>' />
                                        </ItemTemplate>
                                    </asp:DataList>--%>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    URL Links
                                                    <asp:Label ID="lblURLSummary" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <asp:HyperLink ID="HylinkUCE" runat="server" Text="Link to UCE listing"></asp:HyperLink>
                                                        <div style="height: 10px;">
                                                            &nbsp;
                                                        </div>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                                <asp:Label ID="lblExistUrlRes" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                                    runat="server"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:Panel ID="Panel2" Width="100%" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                <ContentTemplate>
                                                                    <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                                                                    <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                                                                    <asp:GridView Width="100%" ID="grdMultiSites" runat="server" CellSpacing="0" CellPadding="0"
                                                                        CssClass="grid1" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdMultiSites_RowDataBound">
                                                                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle CssClass="tbHed" HorizontalAlign="Left" />
                                                                        <PagerSettings Position="Top" />
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <RowStyle CssClass="row1" />
                                                                        <AlternatingRowStyle CssClass="row2" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Main Url">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblMainUrl" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SiteName"),27)%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Post Url">
                                                                                <ItemTemplate>
                                                                                    <asp:HyperLink ID="htlnkURLListed" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),80)%>'
                                                                                        NavigateUrl='<%# String.Format("http://{0}", Eval("URL").ToString()) %>' Target="_blank"></asp:HyperLink>
                                                                                    <asp:HiddenField ID="hdnUrlToNav" runat="server" Value='<%# Eval("URL")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Post Dt">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblPostDate" runat="server" Text='<%# Bind("UrlPostDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                    <asp:HiddenField ID="hdnPostDate" runat="server" Value='<%# Bind("UrlPostDate", "{0:MM/dd/yyyy}") %>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Expiry Dt">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblExpirydate" runat="server"></asp:Label>
                                                                                    <asp:HiddenField ID="hdnExpiryDate" runat="server" Value='<%# Eval("ValidDays")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="grdMultiSites" EventName="Sorting" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </asp:Panel>
                                                    </fieldset>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Counters<div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                                            <tr>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        Home View Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblHomeViewCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 35px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        Search View Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblSearchViewCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 35px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        Filter Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblFilterCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        Make View Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblMakeViewCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 35px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        Make Model View Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblMakeModelViewCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 35px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        All Makes and Models Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblMakeModelAllViewCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        Details View Count</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblDetailsViewCount" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 35px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        This Week</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblThisWeek" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 35px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 180px;">
                                                                    <h4 class="h43">
                                                                        This Month</h4>
                                                                </td>
                                                                <td style="width: 40px;">
                                                                    <asp:Label ID="lblThisMonth" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Internal Notes<div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden" style="height: 262px; max-height: 262px;">
                                                    <fieldset style="width: 70%; float: left; height: 230px;">
                                                        <asp:TextBox ID="txtSaleNotes" runat="server" TextMode="MultiLine" MaxLength="1000"
                                                            Style="width: 99%; height: 235px; resize: none;" CssClass="textAr" data-plus-as-tab="false"
                                                            Enabled="false"> </asp:TextBox>
                                                    </fieldset>
                                                    <table class="coll">
                                                        <tr>
                                                            <td>
                                                                <strong>Source of photos </strong>
                                                                <br />
                                                                <h4 class="h4" style="margin: 0px 0 15px 0; line-height: 25px;">
                                                                    <asp:Label ID="lblPhotoSource" runat="server"></asp:Label>
                                                                </h4>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <strong>Source of description</strong>
                                                                <br />
                                                                <h4 class="h4" style="margin: 0px 0 15px 0; line-height: 25px;">
                                                                    <%--<asp:DropDownList ID="ddlDescriptionSource" runat="server" Enabled="false">
                                                                    </asp:DropDownList>--%>
                                                                    <asp:Label ID="lblDescriptionSource" runat="server"></asp:Label>
                                                                </h4>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Payment Details<div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset style="position: relative; z-index: 9; height: auto; padding-bottom: 20px;
                                                        margin-bottom: 20px;">
                                                        <!-- <legend>Payment Details</legend>   -->
                                                        <table style="width: 99%; position: relative; z-index: 10; margin: 0">
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="updtpnlPaymentDetails" runat="server">
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
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <!-- Credit Card Start  -->
                                                                            <div id="divcard" runat="server">
                                                                                <table border="0" style="width: 55%; margin: 0 30px 0 0; float: left;" cellpadding="0"
                                                                                    cellspacing="0">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <h5 style="font-size: 15px; margin: 0; float: left; width: 130px;">
                                                                                                Card Details</h5>
                                                                                            <h5 style="font-size: 12px; font-weight: normal; margin: 0; display: inline-block">
                                                                                            </h5>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h4 class="h4">
                                                                                                <strong style="width: 135px">Card Holder First Name</strong>
                                                                                                <asp:HiddenField ID="CardType" runat="server" />
                                                                                                <asp:TextBox ID="txtCardholderName" runat="server" MaxLength="25" Enabled="false" />
                                                                                                <strong style="width: 65px">Last Name</strong>
                                                                                                <asp:TextBox ID="txtCardholderLastName" runat="server" MaxLength="25" Enabled="false" />
                                                                                            </h4>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h4 class="h4">
                                                                                                <strong style="width: 77px">Credit Card #</strong>
                                                                                                <asp:TextBox runat="server" ID="CardNumber" MaxLength="16" onkeypress="return isNumberKey(event)"
                                                                                                    onblur="return CreditCardOnblur();" Enabled="false" />
                                                                                            </h4>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h4 class="h4">
                                                                                                <strong style="width: 65px">Expiry Date</strong>
                                                                                                <asp:Label ID="lblExpiryDate" runat="server" Style="padding: 11px 0"></asp:Label>
                                                                                            </h4>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h4 class="h4">
                                                                                                <strong style="width: 40px">CVV#</strong>
                                                                                                <asp:TextBox ID="cvv" MaxLength="4" runat="server" onkeypress="return isNumberKey(event)"
                                                                                                    onblur="return CVVOnblur();" Enabled="false" />
                                                                                            </h4>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 37%; margin: 14px 0 0 0;
                                                                                    float: right">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h4 class="h4">
                                                                                                <strong style="width: 45px">Address</strong>
                                                                                                <asp:TextBox ID="txtbillingaddress" runat="server" MaxLength="40" Enabled="false"></asp:TextBox>
                                                                                            </h4>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <h4 class="h4">
                                                                                                <strong style="width: 40px">City</strong>
                                                                                                <asp:TextBox ID="txtbillingcity" runat="server" MaxLength="40" Enabled="false"></asp:TextBox>
                                                                                            </h4>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div style="width: 45%; display: inline-block; float: left; margin-right: 10px;">
                                                                                                <h4 class="h4" style="padding: 12px 0 7px 0">
                                                                                                    <strong style="width: 40px">State</strong>
                                                                                                    <%--<asp:DropDownList ID="ddlbillingstate" runat="server" Style="width: 120px" Enabled="false">
                                                                                                    </asp:DropDownList>--%>
                                                                                                    <asp:Label ID="lblbillingstate" runat="server"></asp:Label>
                                                                                                </h4>
                                                                                            </div>
                                                                                            <div style="width: 45%; display: inline-block; float: left">
                                                                                                <h4 class="h4">
                                                                                                    <strong style="width: 40px">ZIP</strong>
                                                                                                    <asp:TextBox ID="txtbillingzip" runat="server" Style="width: 74px" MaxLength="5"
                                                                                                        class="sample4" onkeypress="return isNumberKey(event)" onblur="return billingZipOnblur();"
                                                                                                        Enabled="false"></asp:TextBox>
                                                                                                </h4>
                                                                                            </div>
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
                                                                                                        <h4 class="h4">
                                                                                                            <strong style="width: 125px">Account holder name</strong>
                                                                                                            <asp:TextBox ID="txtCustNameForCheck" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                                                                                                        </h4>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <h4 class="h4">
                                                                                                            <strong style="width: 60px">Account #</strong>
                                                                                                            <asp:TextBox ID="txtAccNumberForCheck" runat="server" MaxLength="20" Enabled="false"></asp:TextBox>
                                                                                                        </h4>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <h4 class="h4">
                                                                                                            <strong style="width: 67px">Bank name:</strong>
                                                                                                            <asp:TextBox ID="txtBankNameForCheck" runat="server" MaxLength="50" Enabled="false"></asp:TextBox>
                                                                                                        </h4>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <h4 class="h4">
                                                                                                            <strong style="width: 60px">Routing #</strong>
                                                                                                            <asp:TextBox ID="txtRoutingNumberForCheck" runat="server" MaxLength="9" Enabled="false"></asp:TextBox>
                                                                                                        </h4>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <h4 class="h4">
                                                                                                            <strong style="width: 76px">Account type</strong>
                                                                                                            <asp:DropDownList ID="ddlAccType" runat="server" Enabled="false">
                                                                                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                                                <asp:ListItem Value="1">CHECKING</asp:ListItem>
                                                                                                                <asp:ListItem Value="2">SAVINGS</asp:ListItem>
                                                                                                                <asp:ListItem Value="3">BUSINESSCHECKING</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </h4>
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
                                                                                                            <h4 class="h4">
                                                                                                                <strong style="width: 100px">Payment trans ID:</strong>
                                                                                                                <%-- <input type="text" style="width: 245px" />--%>
                                                                                                                <asp:TextBox ID="txtPaytransID" runat="server" MaxLength="30" Enabled="false"></asp:TextBox>
                                                                                                            </h4>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <h4 class="h4">
                                                                                                                <strong style="width: 140px">Paypal account email:</strong>
                                                                                                                <%-- <input type="text" style="width: 245px" />--%>
                                                                                                                <asp:TextBox ID="txtpayPalEmailAccount" runat="server" onblur="return PaypalEmailblur();"
                                                                                                                    Enabled="false"></asp:TextBox>
                                                                                                            </h4>
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
                                                                    <table>
                                                                        <tr>
                                                                            <td colspan="2" style="padding: 10px 0 0 0">
                                                                                <h5 style="font-size: 15px; margin: 0; padding: 0">
                                                                                    Payment Schedule</h5>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 9px;">
                                                                            </td>
                                                                            <td style="width: 130px; vertical-align: bottom">
                                                                                <b>Today's Payment </b>
                                                                            </td>
                                                                            <td style="width: 100px; vertical-align: bottom">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 35px">Date</strong>
                                                                                    <asp:TextBox ID="txtPaymentDate" runat="server" Enabled="false"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="width: 100px; vertical-align: bottom">
                                                                                <h4 class="h4 non">
                                                                                    <strong style="width: 55px">Amount $</strong>
                                                                                    <asp:TextBox ID="txtPDAmountNow" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                                        onkeyup="return ChangeValuesHidden()" Width="200px" Enabled="false"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 0; margin: 0; vertical-align: middle">
                                                                                <div style="margin-top: 22px;">
                                                                                    <asp:CheckBox ID="chkboxlstPDsale" runat="server" CssClass="noLM" Enabled="false" /></div>
                                                                            </td>
                                                                            <td style="vertical-align: bottom">
                                                                                <b>Post Dated Payment</b>
                                                                            </td>
                                                                            <td style="vertical-align: bottom">
                                                                                <h4 class="h4 ">
                                                                                    <strong style="width: 35px">Date</strong>
                                                                                    <asp:TextBox ID="txtPDDate" runat="server" Enabled="false"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="vertical-align: bottom">
                                                                                <h4 class="h4 non">
                                                                                    <strong style="width: 55px">Amount $</strong>
                                                                                    <asp:TextBox ID="txtPDAmountLater" runat="server" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                                                        onkeyup="return ChangeValuesHidden()" Enabled="false" Width="200px"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                            </td>
                                                                            <td style="vertical-align: bottom">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 40px">Total $</strong>
                                                                                    <asp:TextBox ID="txtTotalAmount" Enabled="false" runat="server"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td width="40%">
                                                                                <h4 class="h4">
                                                                                    <strong style="width: 175px; font-size: 15px;">Voice file confirmation #:</strong>
                                                                                    <asp:TextBox ID="txtVoicefileConfirmNo" runat="server" MaxLength="30" Enabled="false"></asp:TextBox>
                                                                                </h4>
                                                                            </td>
                                                                            <td width="40%">
                                                                                <h4 class="h4" style="padding: 9px 0 10px 0; margin-left: 4px">
                                                                                    <strong style="width: 150px; font-size: 15px;">Voice file Location:</strong>
                                                                                    <asp:Label ID="lblVoiceFileLocation" runat="server"></asp:Label>
                                                                                </h4>
                                                                            </td>
                                                                            <td style="padding: 0;">
                                                                                <div style="width: 100px; float: right; margin: 0 auto 10px auto; clear: both; text-align: right">
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </fieldset>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Tickets
                                                    <asp:Label ID="lblTicketSummary" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                                <asp:Label ID="lblTicketsError" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                                    runat="server"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:Panel ID="Panel1" Width="100%" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                                    <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                                    <asp:GridView Width="100%" ID="grdTicketDetails" runat="server" CellSpacing="0" CellPadding="0"
                                                                        CssClass="grid1" AutoGenerateColumns="False" GridLines="None" OnRowDataBound="grdTicketDetails_RowDataBound"
                                                                        OnRowCommand="grdTicketDetails_RowCommand">
                                                                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle CssClass="tbHed" HorizontalAlign="Left" />
                                                                        <PagerSettings Position="Top" />
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <RowStyle CssClass="row1" />
                                                                        <AlternatingRowStyle CssClass="row2" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Ticket ID">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkTicketID" runat="server" Text='<%# Eval("TicketID")%>' CommandArgument='<%# Eval("TicketID")%>'
                                                                                        CommandName="EditTicket"></asp:LinkButton>
                                                                                    <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Ticket Dt">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTicketDt" runat="server" Text='<%# Bind("CreatedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Created By">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCreatedBy" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CreatedBy"))),12) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Priority">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTicketPriority" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"PriorityName")),10) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Ticket Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblTicketType" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"TicketTypeName")),10) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="85px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Status">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("TicketStatusName")%>' />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="grdTicketDetails" EventName="Sorting" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </asp:Panel>
                                                    </fieldset>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Transaction Details
                                                    <asp:Label ID="lblTransactionSummary" runat="server" CssClass="selected"></asp:Label>
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                                <asp:Label ID="lblResultsCustomerServiceCalls" Font-Size="12px" Font-Bold="true"
                                                                    ForeColor="Black" runat="server"></asp:Label>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:Panel ID="Panel3" Width="100%" runat="server">
                                                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                <ContentTemplate>
                                                                    <input style="width: 91px" id="Hidden5" type="hidden" runat="server" enableviewstate="true" />
                                                                    <input style="width: 40px" id="Hidden6" type="hidden" runat="server" enableviewstate="true" />
                                                                    <asp:GridView Width="100%" ID="grdCustServiceCalls" runat="server" CellSpacing="0"
                                                                        CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                                        OnRowCommand="grdCustServiceCalls_RowCommand">
                                                                        <PagerStyle HorizontalAlign="Right" BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle CssClass="tbHed" HorizontalAlign="Left" />
                                                                        <PagerSettings Position="Top" />
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <RowStyle CssClass="row1" />
                                                                        <AlternatingRowStyle CssClass="row2" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Call ID">
                                                                                <ItemTemplate>
                                                                                    <%--<asp:Label ID="lblCSCallID" runat="server" Text='<%# Eval("CallID")%>'></asp:Label>--%>
                                                                                    <asp:LinkButton ID="lnkbtnCSCallID" runat="server" Text='<%# Eval("CallID")%>' CommandArgument='<%# Eval("CallID")%>'
                                                                                        CommandName="EditCSID">
                                                                                    </asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Call Dt">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCSCallDt" runat="server" Text='<%# Bind("CallDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Call By">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCSCallBy" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CallAgentID"))),18) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Call Type">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCSCallType" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"CallTypeName")),30) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Call Reason">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCSCallReason" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"CallReasonName")),30) %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" Width="180px" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Call Status">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCSCallStatus" runat="server" Text='<%# Eval("CSResolutionName")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="grdCustServiceCalls" EventName="Sorting" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </asp:Panel>
                                                    </fieldset>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding-top: 5px;">
                                                <h2 class="h200 hid">
                                                    Edit Details
                                                    <div class="close">
                                                    </div>
                                                </h2>
                                                <div class="hidden">
                                                    <fieldset>
                                                        <asp:UpdatePanel ID="updtpnlTransaction" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="lnkUserTransDetails" runat="server" Text="User Transaction Details"
                                                                    OnClick="lnkUserTransDetails_Click"></asp:LinkButton><br />
                                                                <asp:LinkButton ID="lnkCarTransactionDetails" runat="server" Text="Car Transaction Details"
                                                                    OnClick="lnkCarTransactionDetails_Click"></asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </fieldset>
                                                </div>
                                                <div class="clear">
                                                    &nbsp;</div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table width="100%">
                <tr>
                    <td width="400px">
                        &nbsp;
                    </td>
                    <td style="text-align: right">
                    </td>
                </tr>
            </table>
        </div>
        <div style="display: inline; float: left; width: 190px; padding: 10px; border: #ccc 1px solid;
            background: #eee">
            <asp:Button ID="btnResendWelMail" runat="server" Text="View/Resend Welcome Mail"
                CssClass="g-button" OnClick="btnResendWelMail_Click" Style="width: 190px; text-transform: capitalize" />
            <asp:Button ID="btnSendListingDetails" runat="server" Text="View/Send Listing Details"
                CssClass="g-button " Style="width: 190px; text-transform: capitalize" OnClick="btnSendListingDetails_Click" />
            <asp:Button ID="btnSendCustomMail" runat="server" Text="Create/Send general mail"
                CssClass="g-button" Style="width: 190px; text-transform: capitalize" OnClick="btnSendCustomMail_Click" />
            <br />
            <br />
            <br />
            <br />
            <%--<input type="button" value="Create-A-Ticket" class="g-button" style="width:190px;" />--%>
            <asp:Button ID="lnkbtnAddTicketPopup" runat="server" Text="Create-A-Ticket" CssClass="g-button"
                Style="width: 190px;" OnClick="lnkbtnAddTicketPopup_Click" />
            <%-- <asp:LinkButton ID="lnkbtnAddTicketPopup" runat="server" Text="Add Ticket" Style="text-align: right;
                                                float: right; font-size: 12px; font-weight: normal;" OnClick="lnkbtnAddTicketPopup_Click"></asp:LinkButton>--%>
            <br />
            <br />
            <br />
            <br />
            <table style="width: 190px; border-collapse: collapse;">
                <tr>
                    <td>
                        <b>Add notes</b>
                    </td>
                    <td>
                        <%--    <input type="button" value="UPDATE" class="g-button g-button-submit" style="font-size: 11px;
                            margin: 2px;" />--%>
                        <asp:Button ID="btnIntUpdate" runat="server" Text="Update" class="g-button g-button-submit"
                            OnClick="btnIntUpdate_Click" OnClientClick="return ValidateVehicleType1();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <%--   <textarea style="width: 99%; padding: 2px; height: 120px;"></textarea>--%>
                        <asp:TextBox ID="txtNewIntNotes" runat="server" Style="width: 99%; padding: 2px;
                            height: 360px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepTicketAlertView" runat="server" PopupControlID="divTicketAlertView"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnTicketAlertView" CancelControlID="btnJustCheckingView">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnTicketAlertView" runat="server" />
    <div id="divTicketAlertView" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                Ticket Details
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdtPopupDdl" runat="server">
                                <ContentTemplate>
                                    <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 90px;">
                                                Tkt ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Vehicle ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopCarID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Type
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Created Dt
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketCreatedDt" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Created By
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTicketCreatedBy" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Priority
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopPriority" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Callback Dt
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPostDate" runat="server" CssClass="input3" MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                    Width="100px"></asp:TextBox>&nbsp;
                                                <img id="imgcal" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtPostDate,'mm/dd/yyyy',this);"
                                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Description
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopTktDescrip" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Status
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTicketStatus" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Assigned To
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAssignedTo" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Completed By
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCompletedBy" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Completed Dt
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtCompletedDt" runat="server" CssClass="input3" MaxLength="10"
                                                    onkeypress="return isNumberKeyForDt(event)" Width="100px"></asp:TextBox>&nbsp;
                                                <img id="img21" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtCompletedDt,'mm/dd/yyyy',this);"
                                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Comments
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPopTktComments" runat="server" CssClass="textarea" MaxLength="200"
                                                    Width="200px" TextMode="MultiLine"></asp:TextBox>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 90px;">
                                    </td>
                                    <td>
                                        <%--  <input type="button" value="Save" class="g-button g-button-submit" />
                                            <input type="button" value="Just Checking" class="g-button g-button-submit" />--%>
                                        <asp:UpdatePanel ID="updtPnlSave" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSaveTicketView" runat="server" CssClass="g-button g-button-submit"
                                                    Text="Save" OnClientClick="return ValidateData();" OnClick="btnSaveTicketView_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:LinkButton ID="btnJustCheckingView" runat="server" Style="float: right; margin-top: 6px;"
                                            Text="Just Checking" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepTicketAlert" runat="server" PopupControlID="divTicketAlert"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnTicketAlert">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnTicketAlert" runat="server" />
    <div id="divTicketAlert" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                Call Disposition
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 90px;">
                                        Call Type
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="updtpnltkt" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCallType" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Call Reason
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCallReason" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Spoken with
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtSpokenWith" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Notes
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox runat="server" ID="txtTicketNotes" CssClass="textarea" Style="height: 50px;
                                                    margin: 0; width: 95%" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Call Resolution
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCallResolution" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ticket
                                    </td>
                                    <td>
                                        <table class="tic">
                                            <tr>
                                                <td style="width: 60px;">
                                                    <input type="radio" name="Ticket" value="Yes" />Yes
                                                </td>
                                                <td>
                                                    <input type="radio" name="Ticket" value="No" checked="checked" />No
                                                    <asp:HiddenField ID="TicketConfirm" runat="server" Value="false" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px;">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table id='ticType' class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 90px;">
                                        Ticket Type
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlTicketType" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Priority
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlTicketPriority" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Call Back
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCallBack" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Description
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtTicketDescription" runat="server" CssClass="textarea" Style="height: 50px;
                                                    margin: 0; width: 95%" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="height: 10px;">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel ID="updtpnlTicketSave" runat="server">
                                <ContentTemplate>
                                    <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 90px;">
                                            </td>
                                            <td>
                                                <%--  <input type="button" value="Save" class="g-button g-button-submit" />
                                            <input type="button" value="Just Checking" class="g-button g-button-submit" />--%>
                                                <asp:Button ID="btnSave" runat="server" CssClass="g-button g-button-submit" Text="Save"
                                                    OnClick="btnSave_Click" OnClientClick="return ValidateVehiclePopup()" />
                                                <asp:LinkButton ID="btnJustChecking" runat="server" Style="float: right; margin-top: 6px"
                                                    Text="Just Checking" OnClick="btnJustChecking_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepCSIDPopup" runat="server" PopupControlID="divCSIDPopup"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnCSIDPopup" CancelControlID="btnCSIDOK">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnCSIDPopup" runat="server" />
    <div id="divCSIDPopup" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                CS Call Details
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="updtpnlCSPop" runat="server">
                                <ContentTemplate>
                                    <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 90px;">
                                                Call ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Vehicle ID
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCarID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Date
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Agent
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallAgent" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Spoken With
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallSpokenWith" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Type
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Reason
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallReason" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Call Status
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Notes
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPopupCSCallNotes" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 10px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnCSIDOK" runat="server" CssClass="g-button g-button-submit" Text="Ok" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mpeaTransCarData" runat="server" PopupControlID="divTransCarData"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdntranscarData" CancelControlID="BtnClsSendRegMail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdntranscarData" runat="server" />
    <div id="divTransCarData" class="PopUpHolder">
        <div class="main" style="width: 1080px">
            <h4>
                <asp:UpdatePanel ID="updtpnlLblHead" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTransHead" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="BtnClsSendRegMail" runat="server" Text="Close" BorderWidth="0"
                    CssClass="close"></asp:LinkButton>
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="dat" style="padding: 0 10px; width: 98%">
                <table style="width: 100%; margin: 10px 0;">
                    <tr>
                        <td style="vertical-align: top;">
                            <div style="width: 100%;" id="divresults" runat="server">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="UpdtpnlHeader" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 gridBoldHed" cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1030px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="60px" align="left">
                                                        Trans ID
                                                    </td>
                                                    <td align="left" width="130px">
                                                        Field Name
                                                    </td>
                                                    <td width="170px" align="left">
                                                        Old Value
                                                    </td>
                                                    <td width="170px" align="left">
                                                        New Value
                                                    </td>
                                                    <td width="130px" align="left">
                                                        Table Name
                                                    </td>
                                                    <td width="80px" align="left">
                                                        Record ID
                                                    </td>
                                                    <td width="90px" align="left">
                                                        Trans Date
                                                    </td>
                                                    <td align="left">
                                                        Trans By
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1050px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 300px">
                                    <asp:Panel ID="Panel4" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="updtpanelGridPopup" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden7" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden8" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1030px" ID="grdTranscarData" runat="server" CellSpacing="0"
                                                    CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                    ShowHeader="false">
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
                                                                <asp:Label ID="lblTransID" runat="server" Text='<%# Eval("THID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFieldName" runat="server" Text='<%# Eval("FieldName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOldValue" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"OldValue"),20)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="170px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNewValue" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"NewValue"),20)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="170px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTableName" runat="server" Text='<%# Eval("TableName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRecordID" runat="server" Text='<%# Eval("RecordID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransDate" runat="server" Text='<%# Bind("TransactionDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransbyName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"TransactionByName"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdTranscarData" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                                <div class="clear" style="height: 12px;">
                                    &nbsp;</div>
                            </div>
                        </td>
                    </tr>
                </table>
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
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" />
        </div>
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
                            <td style="padding: 2px; vertical-align: middle">
                                <b>Mail To:</b>
                            </td>
                            <td style="padding: 2px; vertical-align: middle">
                                <%--<asp:Label ID="lblMailTo" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="lblMailTo" runat="server" CssClass="input1" Width="160px"></asp:TextBox>
                                <%--<input type="text" class="input1" style="width: 160px" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 2px; vertical-align: middle">
                                <b>CC:</b>
                            </td>
                            <td style="padding: 2px; vertical-align: middle">
                                <asp:TextBox ID="txtEmailTo" CssClass="input1" Width="160px" runat="server"></asp:TextBox>
                                <%--<input type="text" class="input1" style="width: 160px" />--%>
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
                    OnClick="btnSendregMail_Click" OnClientClick="return ValidateRegMailSend();" />
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
    <cc1:ModalPopupExtender ID="MpeListMail" runat="server" PopupControlID="divViewListingMail"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnListingMail" CancelControlID="btnCancelSendListingMail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnListingMail" runat="server" />
    <div id="divViewListingMail" class="PopUpHolder">
        <div class="main " style="height: 480px; margin-top: 70px; width: 880px">
            <h4>
                MultiListing Mail
            </h4>
            <div class="dat" style="padding: 0;">
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 70%;">
                            <table>
                                <td>
                                    <b>Mail To:</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="lblMultiSiteMailTo" CssClass="input1" Width="160px" runat="server"
                                        MaxLength="100"></asp:TextBox>
                                    <%--<asp:Label ID="lblMultiSiteMailTo" runat="server"></asp:Label>--%>
                                </td>
                            </table>
                        </td>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <b>CC: </b>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMultiListEmailToCC" CssClass="input1" Width="160px" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnPrint" Text="Print" OnClientClick="javascript:CallPrint('width870');"
                                            runat="Server" Visible="false" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div id="width870" runat="server" class="printyes">
                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMultiListMail" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clear">
                        &nbsp;</div>
                </div>
                <asp:Button ID="btnCancelSendListingMail" class="g-button btnUpdate" runat="server"
                    Text="Cancel" />
                <asp:Button ID="btnSendListingMail" class="g-button btnUpdate" runat="server" Text="Send"
                    OnClick="btnSendListingMail_Click" OnClientClick="return ValidateMultiSiteList();" />
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
    <cc1:ModalPopupExtender ID="mdepgeneralMail" runat="server" PopupControlID="divGeneralMail"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnSendGeneralMail" CancelControlID="btngenMailCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnSendGeneralMail" runat="server" />
    <div id="divGeneralMail" class="PopUpHolder">
        <div class="main">
            <h4>
                General Mail
            </h4>
            <div class="dat">
                <div>
                    <table>
                        <tr>
                            <td style="width: 15%">
                                <h3 class="h43">
                                    Mail To:
                                </h3>
                            </td>
                            <td style="width: 45%">
                                <%--  <asp:Label ID="lblGenMailTo" runat="server"></asp:Label>--%>
                                <asp:TextBox ID="lblGenMailTo" CssClass="input1" Width="160px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                            <td style="width: 10%">
                                <h3 class="h43">
                                    CC:
                                </h3>
                            </td>
                            <td>
                                <asp:TextBox ID="txtGenCCMail" CssClass="input1" Width="160px" runat="server" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h3 class="h43">
                                    Subject:
                                </h3>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtGenSubject" CssClass="input1" Width="250px" runat="server" MaxLength="500"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtgenMailText" runat="server" CssClass="textarea" TextMode="MultiLine"
                                MaxLength="2000" Style="height: 200px;"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <br />
                <asp:Button ID="btngenMailCancel" class="g-button btnUpdate" runat="server" Text="Cancel" />
                <asp:Button ID="btngenMailSend" class="g-button btnUpdate" runat="server" Text="Send"
                    OnClientClick="return ValidateGeneralMail();" OnClick="btngenMailSend_Click" />
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
    <cc1:ModalPopupExtender ID="mdepPackageDetails" runat="server" PopupControlID="divPackageDetails"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnPackageDetails" OkControlID="btnPackageOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnPackageDetails" runat="server" />
    <div id="divPackageDetails" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 650px; margin: 60px auto 0 auto;">
            <h4>
                Package Details
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 580px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="updtpnlShowPackage" runat="server">
                                <ContentTemplate>
                                    <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 300px;">
                                                <table>
                                                    <tr>
                                                        <td style="width: 100px;">
                                                            Package ID:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowPackageID" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Package:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowPackageName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Purchase date:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowPurcahseDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Valid till:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowValidTill" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            # of cars allowed:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowMaxCars" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            # of cars posted:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowCarsPosted" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 10px;">
                                            </td>
                                            <td>
                                                <table style="padding: 10px; border: #ccc 1px solid; background: #F8F8F8">
                                                    <tr>
                                                        <td colspan="2">
                                                            <h3 style="margin: 0 0 5px 0; padding-bottom: 5px; border-bottom: #ccc 1px solid;">
                                                                Package Purchase details
                                                            </h3>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 120px;">
                                                            Paid through:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowPaidThrough" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Transaction ID:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowTransactionID" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Transaction Status:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowTransactionStatus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Recording Conf #:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblShowVoiceFile" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:Button ID="btnPackageOk" CssClass="g-button g-button-submit" runat="server"
                                    Text="Ok" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepRegEdit" runat="server" PopupControlID="divRegEditData"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnRegEditData" OkControlID="btnk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnRegEditData" runat="server" />
    <div id="divRegEditData" class="PopUpHolder editData" style="display: none">
        <div class="main" style="width: 950px; margin: 60px auto 0 auto;">
            <h4>
                Registration Details
            </h4>
            <div class="dat" style="padding: 15px 0; width: 99%;">
                <table style="width: 99%; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                <ContentTemplate>
                                    <table style="width: 85%; margin-left: 15px;">
                                        <tbody>
                                            <tr>
                                                <td style="width: 90px;">
                                                    <strong style="width: 45px">User ID:</strong>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblEditUserID" runat="server"></asp:Label>
                                                </td>
                                                <td style="width: 40px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 90px;">
                                                    <strong style="width: 65px">Password:</strong><span class="star" style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEditPassword" runat="server" MaxLength="25"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong style="width: 50px">Name:</strong> <span class="star" style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEditName" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <strong style="width: 40px">Email:</strong>
                                                </td>
                                                <td>
                                                    <table style="width: 100%; border-collapse: collapse; padding: 0; margin: 0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="padding: 2px 0 0 0;">
                                                                    <asp:TextBox ID="txtEditRegEmail" runat="server" MaxLength="40"></asp:TextBox>
                                                                    <span style="font-weight: bold;">
                                                                        <asp:CheckBox ID="chkbxEMailNAEdit" runat="server" Text="NA" /></span>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong style="width: 50px">Phone#:</strong> <span class="star" style="color: Red">*</span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEditRegPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <strong style="width: 70px">Alt Phone#:</strong>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEditAltPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <strong style="width: 50px">Address:</strong>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEditRegAddress" runat="server" MaxLength="50"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td colspan="2">
                                                    <table style="padding: 0; width: 100%;" cellpadding="0" cellspacing="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 220px;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 95px; text-align: left">City:</strong><asp:TextBox ID="txtEditRegCity"
                                                                            MaxLength="25" runat="server"></asp:TextBox>
                                                                    </h4>
                                                                </td>
                                                                <td style="width: 120px;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 40px">State:</strong>
                                                                        <asp:DropDownList ID="ddlRegState" runat="server">
                                                                        </asp:DropDownList>
                                                                    </h4>
                                                                </td>
                                                                <td style="width: 90px;">
                                                                    <h4 class="h4">
                                                                        <strong style="width: 25px">Zip:</strong><asp:TextBox ID="txtEditRegZip" onkeypress="return isNumberKey(event)"
                                                                            MaxLength="5" runat="server"></asp:TextBox>
                                                                    </h4>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:Button ID="btnEditRegUpdate" CssClass="g-button g-button-submit" runat="server"
                                    Text="Update" OnClientClick="return ValidateRegEditSavedData();" OnClick="btnEditRegUpdate_Click" />
                                <asp:Button ID="btnk" CssClass="g-button g-button-submit" runat="server" Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAdStatusEdit" runat="server" PopupControlID="divAdStEditData"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAdStEditData" OkControlID="btnAdOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAdStEditData" runat="server" />
    <div id="divAdStEditData" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 650px; height: 220px; margin: 60px auto 0 auto;">
            <h4>
                Ad Status
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 580px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 170px;">
                                                <strong style="margin-right: 10px;">Ad Status:</strong>
                                                <asp:DropDownList ID="ddlAdStatus" runat="server" OnSelectedIndexChanged="ddlAdStatus_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <div id="trListingStatus" runat="server">
                                                    <strong style="width: 110px">Ad Status Details:</strong>
                                                    <asp:DropDownList ID="ddlListingStatus" runat="server">
                                                        <asp:ListItem Value="2">Preliminary</asp:ListItem>
                                                        <asp:ListItem Value="3">Withdraw</asp:ListItem>
                                                        <asp:ListItem Value="4">Sold</asp:ListItem>
                                                        <asp:ListItem Value="5">Admin Cancel</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding: 0; height: 40px; overflow: hidden">
                                                <table id="trUceStatus" runat="server" style="padding: 0; border-collapse: collapse;
                                                    width: 100%;">
                                                    <tr>
                                                        <td style="width: 170px;">
                                                            <strong style="margin-right: 4px;">Uce Status:</strong>
                                                            <asp:DropDownList ID="ddlUceStatus" runat="server">
                                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                                <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <strong style="width: 105px">Multisite Status:</strong>
                                                            <asp:DropDownList ID="ddlMultisiteStatus" runat="server">
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:Button ID="btnAdStatusUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit"
                                    OnClick="btnAdStatusUpdate_Click" />
                                <asp:Button ID="btnAdOk" CssClass="g-button g-button-submit" runat="server" Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepEditSeller" runat="server" PopupControlID="divEditSeller"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEditSeller" OkControlID="btnEditSellerOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEditSeller" runat="server" />
    <div id="divEditSeller" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 650px; margin: 60px auto 0 auto;">
            <h4>
                Seller Information For Ad
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 580px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 55px; vertical-align: middle">
                                                <strong style="width: 45px">Phone#:</strong>
                                            </td>
                                            <td style="width: 139px;">
                                                <asp:TextBox ID="txtSellerEditPhone" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                            </td>
                                            <td style="width: 18px;">
                                                &nbsp;
                                            </td>
                                            <td style="width: 55px; vertical-align: middle">
                                                <strong>Email:</strong>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtSellerEditEmail" runat="server" MaxLength="25"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5" style="padding: 0">
                                                <table style="padding: 0; width: 100%;" cellpadding="0" cellspacing="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 220px;">
                                                                <strong style="margin-right: 35px;">City:</strong><asp:TextBox ID="txtSellerEditCity"
                                                                    MaxLength="25" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="width: 155px;">
                                                                <strong style="width: 40px;">State:</strong>
                                                                <asp:DropDownList ID="ddlSellerState" runat="server">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <strong style="width: 25px">Zip:</strong><asp:TextBox ID="txtSellerEditZip" onkeypress="return isNumberKey(event)"
                                                                    MaxLength="5" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:Button ID="btnEditSellerUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit"
                                    OnClientClick="return ValidateSellerEditSavedData();" OnClick="btnEditSellerUpdate_Click" />
                                <asp:Button ID="btnEditSellerOk" CssClass="g-button g-button-submit" runat="server"
                                    Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
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
                <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="MdepUpdatedSuccess" runat="server" PopupControlID="divUpdatedSuccess"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnUpdatedSuccess">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnUpdatedSuccess" runat="server" />
    <div id="divUpdatedSuccess" class="alert" style="display: none">
        <h4 id="H3">
            Alert
            <asp:Button ID="btnUpdateSuccessClose" class="cls" runat="server" Text="" BorderWidth="0"
                OnClick="btnUpdateSuccessOk_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertUpdatedSuccess" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnUpdateSuccessOk" class="btn" runat="server" Text="Ok" OnClick="btnUpdateSuccessOk_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepEditVehicleInfo" runat="server" PopupControlID="divEditVehicleInfo"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEditVehicleInfo" OkControlID="btnEditVehicleOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEditVehicleInfo" runat="server" />
    <div id="divEditVehicleInfo" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 950px; margin: 60px auto 0 auto;">
            <h4>
                Vehicle Information
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 950px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="updtpnlVehEditInfo" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td style="width: 330px;">
                                                <h4 class="h4">
                                                    <strong style="width: 40px;">Make:</strong>
                                                    <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </h4>
                                            </td>
                                            <td style="width: 330px">
                                                <h4 class="h4">
                                                    <strong style="width: 40px;">Model:</strong>
                                                    <asp:DropDownList ID="ddlModel" runat="server">
                                                    </asp:DropDownList>
                                                </h4>
                                            </td>
                                            <td>
                                                <h4 class="h4">
                                                    <strong style="width: 40px;">Year:</strong>
                                                    <asp:DropDownList ID="ddlYear" runat="server">
                                                    </asp:DropDownList>
                                                </h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="padding: 0;">
                                                <table style="padding: 0; width: 99%;">
                                                    <tr>
                                                        <td style="width: 270px">
                                                            <h4 class="h4">
                                                                <strong style="width: 45px">Price $:</strong>
                                                                <asp:TextBox ID="txtAskingPriceEdit" runat="server" MaxLength="6" class="sample4 MyPrice"
                                                                    onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                            </h4>
                                                        </td>
                                                        <td style="width: 190px">
                                                            <h4 class="h4">
                                                                <strong style="width: 40px">Mileage:</strong>
                                                                <asp:TextBox ID="txtMileageEdit" runat="server" MaxLength="6" class="sample4 MyPrice"
                                                                    onkeypress="return isNumberKey(event);"></asp:TextBox>
                                                            </h4>
                                                        </td>
                                                        <td valign="bottom">
                                                            <h4 class="h4 noB">
                                                                <strong style="width: 50px">Cylinders:</strong><span style="font-weight: bold">
                                                                    <asp:RadioButton ID="rdbtnCylinders1Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" /><span class="featNon">3</span>
                                                                    <asp:RadioButton ID="rdbtnCylinders2Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" /><span class="featNon">4</span>
                                                                    <asp:RadioButton ID="rdbtnCylinders3Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" /><span class="featNon">5</span>
                                                                    <asp:RadioButton ID="rdbtnCylinders4Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" /><span class="featNon">6</span>
                                                                    <asp:RadioButton ID="rdbtnCylinders5Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" /><span class="featNon">7</span>
                                                                    <asp:RadioButton ID="rdbtnCylinders6Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" /><span class="featNon">8</span>
                                                                    <asp:RadioButton ID="rdbtnCylinders7Edit" CssClass="noLM" Text="" GroupName="CylindersEdit"
                                                                        runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h4">
                                                    <strong style="width: 65px">Body style:</strong>
                                                    <asp:DropDownList ID="ddlBodyStyle" runat="server">
                                                    </asp:DropDownList>
                                                </h4>
                                            </td>
                                            <td>
                                                <h4 class="h4">
                                                    <strong style="width: 80px">Exterior color:</strong>
                                                    <asp:DropDownList ID="ddlExteriorColor" runat="server">
                                                    </asp:DropDownList>
                                                </h4>
                                            </td>
                                            <td>
                                                <h4 class="h4">
                                                    <strong style="width: 80px">Interior color:</strong>
                                                    <asp:DropDownList ID="ddlInteriorColor" runat="server">
                                                    </asp:DropDownList>
                                                </h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="padding: 0">
                                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 50%;">
                                                            <h4 class="h4 noB">
                                                                <strong style="width: 45px">Transmission:</strong><span style="font-weight: bold">
                                                                    <asp:RadioButton ID="rdbtnTrans1Edit" CssClass="noLM" Text="" GroupName="TransmissionEdit"
                                                                        runat="server" /><span class="featNon">Auto</span>
                                                                    <asp:RadioButton ID="rdbtnTrans2Edit" CssClass="noLM" Text="" GroupName="TransmissionEdit"
                                                                        runat="server" /><span class="featNon">Manual</span>
                                                                    <asp:RadioButton ID="rdbtnTrans3Edit" CssClass="noLM" Text="" GroupName="TransmissionEdit"
                                                                        runat="server" /><span class="featNon">Tiptronic</span>
                                                                    <asp:RadioButton ID="rdbtnTrans4Edit" CssClass="noLM" Text="" GroupName="TransmissionEdit"
                                                                        runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                            </h4>
                                                        </td>
                                                        <td>
                                                            <h4 class="h4 noB">
                                                                <strong style="width: 45px">Doors:</strong><span>
                                                                    <asp:RadioButton ID="rdbtnDoor2Edit" CssClass="noLM" Text="" GroupName="DoorsEdit"
                                                                        runat="server" /><span class="featNon">2</span>
                                                                    <asp:RadioButton ID="rdbtnDoor3Edit" CssClass="noLM" Text="" GroupName="DoorsEdit"
                                                                        runat="server" /><span class="featNon">3</span>
                                                                    <asp:RadioButton ID="rdbtnDoor4Edit" CssClass="noLM" Text="" GroupName="DoorsEdit"
                                                                        runat="server" /><span class="featNon">4</span>
                                                                    <asp:RadioButton ID="rdbtnDoor5Edit" CssClass="noLM" Text="" GroupName="DoorsEdit"
                                                                        runat="server" /><span class="featNon">5</span>
                                                                    <asp:RadioButton ID="rdbtnDoor6Edit" CssClass="noLM" Text="" GroupName="DoorsEdit"
                                                                        runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="padding: 0;">
                                                <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 50%;">
                                                            <h4 class="h4 noB">
                                                                <strong style="width: 65px">Drive train:</strong><span style="font-weight: bold">
                                                                    <asp:RadioButton ID="rdbtnDriveTrain1Edit" CssClass="noLM" Text="" GroupName="DriveTrainEdit"
                                                                        runat="server" /><span class="featNon">2WD</span>
                                                                    <asp:RadioButton ID="rdbtnDriveTrain2Edit" CssClass="noLM" Text="" GroupName="DriveTrainEdit"
                                                                        runat="server" /><span class="featNon">FWD</span>
                                                                    <asp:RadioButton ID="rdbtnDriveTrain3Edit" CssClass="noLM" Text="" GroupName="DriveTrainEdit"
                                                                        runat="server" /><span class="featNon">AWD</span>
                                                                    <asp:RadioButton ID="rdbtnDriveTrain4Edit" CssClass="noLM" Text="" GroupName="DriveTrainEdit"
                                                                        runat="server" /><span class="featNon">RWD</span>
                                                                    <asp:RadioButton ID="rdbtnDriveTrain5Edit" CssClass="noLM" Text="" GroupName="DriveTrainEdit"
                                                                        runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                            </h4>
                                                        </td>
                                                        <td>
                                                            <h4 class="h4">
                                                                <strong>VIN #:</strong>
                                                                <asp:TextBox ID="txtVinEdit" runat="server" Style="width: 400px" MaxLength="20"></asp:TextBox>
                                                            </h4>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <h4 class="h4 noB">
                                                    <strong style="width: 55px">Fuel type:</strong><span style="font-weight: bold">
                                                        <asp:RadioButton ID="rdbtnFuelType1Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">Diesel</span>
                                                        <asp:RadioButton ID="rdbtnFuelType2Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">Petrol</span>
                                                        <asp:RadioButton ID="rdbtnFuelType3Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">Hybrid</span>
                                                        <asp:RadioButton ID="rdbtnFuelType4Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">Electric</span>
                                                        <asp:RadioButton ID="rdbtnFuelType5Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">Gasoline</span>
                                                        <asp:RadioButton ID="rdbtnFuelType6Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">E-85</span>
                                                        <asp:RadioButton ID="rdbtnFuelType7Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" /><span class="featNon">Gasoline-Hybrid</span>
                                                        <asp:RadioButton ID="rdbtnFuelType8Edit" CssClass="noLM" Text="" GroupName="FuelsEdit"
                                                            runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                </h4>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="padding: 0;">
                                                <h4 class="h4 noB">
                                                    <strong style="width: 45px">Condition:</strong><span style="font-weight: bold">
                                                        <asp:RadioButton ID="rdbtnCondition1Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" /><span class="featNon">Excellent</span>
                                                        <asp:RadioButton ID="rdbtnCondition2Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" /><span class="featNon">Very good</span>
                                                        <asp:RadioButton ID="rdbtnCondition3Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" /><span class="featNon">Good</span>
                                                        <asp:RadioButton ID="rdbtnCondition4Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" /><span class="featNon">Fair</span>
                                                        <asp:RadioButton ID="rdbtnCondition5Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" /><span class="featNon">Poor</span>
                                                        <asp:RadioButton ID="rdbtnCondition6Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" /><span class="featNon">Parts or salvage</span>
                                                        <asp:RadioButton ID="rdbtnCondition7Edit" CssClass="noLM" Text="" GroupName="ConditionEdit"
                                                            runat="server" Checked="true" /><span class="featNon">NA</span> </span>
                                                </h4>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:Button ID="btnEditVehicleInfoUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit"
                                    OnClientClick="return ValidateVehicleEditSavedData();" OnClick="btnEditVehicleInfoUpdate_Click" />
                                <asp:Button ID="btnEditVehicleOk" CssClass="g-button g-button-submit" runat="server"
                                    Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    <cc1:ModalPopupExtender ID="mdepEditVehicleFeat" runat="server" PopupControlID="divEditVehicleFeat"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnEditVehicleFeat" OkControlID="btnEditVehicleFeatOk">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnEditVehicleFeat" runat="server" />
    <div id="divEditVehicleFeat" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 950px; margin: 60px auto 0 auto;">
            <h4>
                Vehicle Features
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 950px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 90px;">
                                                <strong>Comfort:</strong>
                                            </td>
                                            <td style="font-weight: bold; color: #666;">
                                                <asp:CheckBox ID="chkFeaturesEdit51" runat="server" class="noLM" />
                                                <span class="featNon">A/C</span>
                                                <asp:CheckBox ID="chkFeaturesEdit1" runat="server" class="noLM" />
                                                <span class="featNon">A/C: Front</span>
                                                <asp:CheckBox ID="chkFeaturesEdit2" runat="server" class="noLM" />
                                                <span class="featNon">A/C: Rear</span>
                                                <asp:CheckBox ID="chkFeaturesEdit3" runat="server" class="noLM" />
                                                <span class="featNon">Cruise control</span>
                                                <asp:CheckBox ID="chkFeaturesEdit4" runat="server" class="noLM" />
                                                <span class="featNon">Navigation system</span>
                                                <asp:CheckBox ID="chkFeaturesEdit5" runat="server" class="noLM" />
                                                <span class="featNon">Power locks</span>
                                                <asp:CheckBox ID="chkFeaturesEdit6" runat="server" class="noLM" />
                                                <span class="featNon">Power steering</span>
                                                <br />
                                                <asp:CheckBox ID="chkFeaturesEdit7" runat="server" class="noLM" />
                                                <span class="featNon">Remote keyless entry</span>
                                                <asp:CheckBox ID="chkFeaturesEdit8" runat="server" class="noLM" />
                                                <span class="featNon">TV/VCR</span>
                                                <asp:CheckBox ID="chkFeaturesEdit31" runat="server" class="noLM" />
                                                <span class="featNon">Remote start</span>
                                                <asp:CheckBox ID="chkFeaturesEdit33" runat="server" class="noLM" />
                                                <span class="featNon">Tilt</span>
                                                <asp:CheckBox ID="chkFeaturesEdit35" runat="server" class="noLM" />
                                                <span class="featNon">Rearview camera</span>
                                                <asp:CheckBox ID="chkFeaturesEdit36" runat="server" class="noLM" />
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
                                                <asp:CheckBox ID="chkFeaturesEdit9" runat="server" class="noLM" />
                                                <span class="featNon">Bucket seats</span>
                                                <asp:CheckBox ID="chkFeaturesEdit11" runat="server" class="noLM" />
                                                <span class="featNon">Memory seats</span>
                                                <asp:CheckBox ID="chkFeaturesEdit12" runat="server" class="noLM" />
                                                <span class="featNon">Power seats</span>
                                                <asp:CheckBox ID="chkFeaturesEdit32" runat="server" class="noLM" />
                                                <span class="featNon">Heated seats</span>
                                                <br />
                                                <b style="color: #222; display: inline-block; margin-left: 163px;">Interior:</b>
                                                <asp:RadioButton ID="rdbtnLeatherEdit" runat="server" CssClass="noLM" GroupName="SeatsEdit"
                                                    Text="" /><span class="featNon">Leather</span>
                                                <asp:RadioButton ID="rdbtnVinylEdit" runat="server" CssClass="noLM" GroupName="SeatsEdit"
                                                    Text="" /><span class="featNon">Vinyl</span>
                                                <asp:RadioButton ID="rdbtnClothEdit" runat="server" CssClass="noLM" GroupName="SeatsEdit"
                                                    Text="" /><span class="featNon">Cloth</span>
                                                <asp:RadioButton ID="rdbtnInteriorNAEdit" runat="server" CssClass="noLM" GroupName="SeatsEdit"
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
                                                <asp:CheckBox ID="chkFeaturesEdit13" runat="server" class="noLM" />
                                                <span class="featNon">Airbag: Driver</span>
                                                <asp:CheckBox ID="chkFeaturesEdit14" runat="server" class="noLM" />
                                                <span class="featNon">Airbag: Passenger</span>
                                                <asp:CheckBox ID="chkFeaturesEdit15" runat="server" class="noLM" />
                                                <span class="featNon">Airbag: Side</span>
                                                <asp:CheckBox ID="chkFeaturesEdit16" runat="server" class="noLM" />
                                                <span class="featNon">Alarm</span>
                                                <asp:CheckBox ID="chkFeaturesEdit17" runat="server" class="noLM" />
                                                <span class="featNon">Anti-lock brakes</span>
                                                <asp:CheckBox ID="chkFeaturesEdit18" runat="server" class="noLM" />
                                                <span class="featNon">Fog lights</span>
                                                <asp:CheckBox ID="chkFeaturesEdit39" runat="server" class="noLM" />
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
                                                <asp:CheckBox ID="chkFeaturesEdit19" runat="server" class="noLM" />
                                                <span class="featNon">Cassette radio</span>
                                                <asp:CheckBox ID="chkFeaturesEdit20" runat="server" class="noLM" />
                                                <span class="featNon">CD changer</span>
                                                <asp:CheckBox ID="chkFeaturesEdit21" runat="server" class="noLM" />
                                                <span class="featNon">CD player</span>
                                                <asp:CheckBox ID="chkFeaturesEdit22" runat="server" class="noLM" />
                                                <span class="featNon">Premium sound</span>
                                                <asp:CheckBox ID="chkFeaturesEdit34" runat="server" class="noLM" />
                                                <span class="featNon">AM/FM</span>
                                                <asp:CheckBox ID="chkFeaturesEdit40" runat="server" class="noLM" />
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
                                                <asp:CheckBox ID="chkFeaturesEdit44" runat="server" class="noLM" />
                                                <span class="featNon">Battery</span>
                                                <asp:CheckBox ID="chkFeaturesEdit45" runat="server" class="noLM" />
                                                <span class="featNon">Tires</span>
                                                <asp:CheckBox ID="chkFeaturesEdit52" runat="server" class="noLM" />
                                                <span class="featNon">Rotors</span>
                                                <asp:CheckBox ID="chkFeaturesEdit53" runat="server" class="noLM" />
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
                                                <asp:CheckBox ID="chkFeaturesEdit23" runat="server" class="noLM" />
                                                <span class="featNon">Power windows</span>
                                                <asp:CheckBox ID="chkFeaturesEdit24" runat="server" class="noLM" />
                                                <span class="featNon">Rear window defroster</span>
                                                <asp:CheckBox ID="chkFeaturesEdit25" runat="server" class="noLM" />
                                                <span class="featNon">Rear window wiper</span>
                                                <asp:CheckBox ID="chkFeaturesEdit26" runat="server" class="noLM" />
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
                                                <asp:CheckBox ID="chkFeaturesEdit27" runat="server" class="noLM" />
                                                <span class="featNon">Alloy wheels</span>
                                                <asp:CheckBox ID="chkFeaturesEdit28" runat="server" class="noLM" />
                                                <span class="featNon">Sunroof</span>
                                                <asp:CheckBox ID="chkFeaturesEdit41" runat="server" class="noLM" />
                                                <span class="featNon">Panoramic roof</span>
                                                <asp:CheckBox ID="chkFeaturesEdit42" runat="server" class="noLM" />
                                                <span class="featNon">Moonroof</span>
                                                <asp:CheckBox ID="chkFeaturesEdit29" runat="server" class="noLM" />
                                                <span class="featNon">Third row seats</span>
                                                <asp:CheckBox ID="chkFeaturesEdit30" runat="server" class="noLM" />
                                                <span class="featNon">Tow package</span>
                                                <br />
                                                <asp:CheckBox ID="chkFeaturesEdit43" runat="server" class="noLM" />
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
                                                <asp:CheckBox ID="chkFeaturesEdit46" runat="server" class="noLM" />
                                                <span class="featNon">Garage kept</span>
                                                <asp:CheckBox ID="chkFeaturesEdit47" runat="server" class="noLM" />
                                                <span class="featNon">Non smoking</span>
                                                <asp:CheckBox ID="chkFeaturesEdit48" runat="server" class="noLM" />
                                                <span class="featNon">Records/Receipts kept</span>
                                                <asp:CheckBox ID="chkFeaturesEdit49" runat="server" class="noLM" />
                                                <span class="featNon">Well maintained</span>
                                                <asp:CheckBox ID="chkFeaturesEdit50" runat="server" class="noLM" />
                                                <span class="featNon">Regular oil changes</span>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <asp:Button ID="btnEditVehicleFeatUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit"
                                    OnClick="btnEditVehicleFeatUpdate_Click" />
                                <asp:Button ID="btnEditVehicleFeatOk" CssClass="g-button g-button-submit" runat="server"
                                    Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clear">
                    &nbsp;</div>
            </div>
            <div class="clear">
                &nbsp;</div>
        </div>
        <div class="clear">
            &nbsp;</div>
    </div>
    </form>
</body>
</html>
