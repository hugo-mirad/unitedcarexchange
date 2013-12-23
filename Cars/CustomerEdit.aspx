<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerEdit.aspx.cs" Inherits="CustomerEdit"
    ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    var TicketConfirm = false;
     function Validate() {
     debugger;
        var valid = true;
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
                alert("Enter register customer name");
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
            if (document.getElementById('<%= txtRegPhNo.ClientID%>').value.length < 1) {
            document.getElementById('<%= txtRegPhNo.ClientID%>').focus();
            alert("Enter phone number");            
            document.getElementById('<%=txtRegPhNo.ClientID%>').focus();
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
             
          
             
              if((document.getElementById('<%=ddlPayStatus.ClientID%>').value =="2")&& (document.getElementById('<%=hdnPayStatus.ClientID%>').value !="2"))
             {
                 if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                    document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                    alert("Select payment date");                 
                    document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
                    valid = false;            
                     return valid;     
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
             }                           
               var EnterAmt = parseFloat($('#lblPayAmount').text()).toFixed(2);  
               var ppp = '0';
               var EmpAmount = parseFloat(ppp).toFixed(2);            
              if((document.getElementById('<%=ddlAdStatus.ClientID%>').value =="1") &&(EnterAmt == EmpAmount) && ((document.getElementById('<%=ddlPayStatus.ClientID%>').value !="2") || (document.getElementById('<%=ddlPayStatus.ClientID%>').value !="1")))
               {
                    if(document.getElementById('<%=hdnPackageID.ClientID%>').value !="1")
                    {
                      if((document.getElementById('<%=hdnPDID.ClientID%>').value !="") && (document.getElementById('<%=hdnPDpayStatus.ClientID%>').value != "2") )
                      {
                        alert("Ad is active only when payment status is paid or partial paid"); 
                        valid=false;
                        document.getElementById('ddlAdStatus').focus();  
                        return valid;
                      }
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
          
       function ValidatePDDatePopup()       
       {            
            var valid=true;   
            if (document.getElementById('<%=ddlPdDateUp.ClientID%>').value =="0")
            {
                alert('Please select PD Date')
                valid=false;
                document.getElementById('ddlPdDateUp').focus();  
                return valid;
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
  
    </script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
		$('.price').formatCurrency();
        $('.mileage').formatCurrency({symbol: ' '});
        $('#txtOldIntNotes').scrollTop($('#txtOldIntNotes')[0].scrollHeight);
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
                        OnClientClick="return ChangeValues();" OnClick="lnkbtnSearch_Click"></asp:LinkButton>&nbsp;
                    | &nbsp;<asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false"
                        OnClick="lnkBtnLogout_Click" OnClientClick="return ChangeValues();"></asp:LinkButton></div>
            </td>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnChange" runat="server" Value="1" />
            <asp:HiddenField ID="hdnPayStatus" runat="server" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="main" style="border: #ccc 1px solid; padding: 10px; background: rgb(253, 243, 234);
        height: 2300px;">
        <h1 class="h1">
            Edit Customer Data<br />
            <asp:Label ID="lblViewCustDataHeading" runat="server"></asp:Label>
            <div style="width: 400px; float: right; margin-right: 0;">
                <%--  <input type="button" value="Reset" class="g-button g-button-submit" />--%>
                <%-- <input type="button" value="Save" class="g-button g-button-submit" />--%>
                <asp:UpdatePanel ID="UpdatePane1BtnSalesUpdate" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnCancel" runat="server" CssClass="g-button g-button-submit" Text="Back to view"
                            OnClick="btnCancel_Click" OnClientClick="return ChangeValues();" />
                        <asp:Button ID="btnReset" runat="server" CssClass="g-button g-button-submit" Text="Reset"
                            OnClick="btnReset_Click" OnClientClick="return ChangeValues();" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="g-button g-button-submit" Text="Update"
                            OnClick="btnUpdate_Click" OnClientClick="return Validate();" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </h1>
        <div class="clear">
            &nbsp;</div>
        <div class="clear">
            &nbsp;</div>
        <div id="divHeaderNote" runat="server">
            <h4 style="margin: 0 0 8px 2px; padding: 0; line-height: 16px;">
                Header Note
                <asp:Label ID="lblHeaderNote" runat="server" Style="font-weight: normal;"></asp:Label></h4>
        </div>
        <h4 style="margin: 0 0 8px 2px; padding: 0; line-height: 16px;">
            Car ID#
            <%--<label style="font-weight: normal;">
                </label>--%>
            <asp:Label ID="lblCarID" runat="server" Style="font-weight: normal;"></asp:Label></h4>
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
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    Sale Date</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSaleDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    Posting Date</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPostingDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Car Sales ID#</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCarsalesID" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Sales Agent</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSalesAgent" runat="server"></asp:Label>
                                                <%--<asp:TextBox ID="txtAgent" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>--%>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Refer Agent</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtAgent" runat="server"></asp:Label>
                                                <%--<asp:TextBox ID="txtAgent" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>--%>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Verifier</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="txtVerifier" runat="server"></asp:Label>
                                                <%-- <asp:TextBox ID="txtVerifier" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>--%>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Package</h4>
                                            </td>
                                            <td>
                                                <%--<asp:DropDownList ID="ddlPackage" runat="server" CssClass="input1" onchange="ChangeValuesHidden()"
                                                    Enabled="false">
                                                </asp:DropDownList>--%>
                                                <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdnPackageID" runat="server" />
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Last Updated</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLastUpdated" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 " />--%>
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
                                                    User ID</h4>
                                            </td>
                                            <td>
                                                <%-- <input type="text" class="input3" />--%>
                                                <asp:TextBox ID="txtRegUserID" runat="server" CssClass="input3" Enabled="false"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Password</h4>
                                            </td>
                                            <td>
                                                <%--<input type="text" class="input3" />--%>
                                                <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="input3" MaxLength="25"
                                                    onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px">
                                                <h4 class="h43">
                                                    Email
                                                    <asp:CheckBox ID="chkbxEMailNA" runat="server" Text="NA" Font-Bold="true" onclick="return EmailNAClick();" /></h4>
                                            </td>
                                            <td>
                                                <%-- <input type="text" class="input3" />--%>
                                                <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="input3" MaxLength="40" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
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
                                    <asp:UpdatePanel ID="updtpnl" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Payment Date</h4>
                                                    </td>
                                                    <td>
                                                        <%--  <input type="text" class="input3" />--%>
                                                        <asp:DropDownList ID="ddlPaymentDate" runat="server" CssClass="input1">
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            PD Date</h4>
                                                    </td>
                                                    <td>
                                                        <%--  <input type="text" class="input3" />--%>
                                                        <div style="float: left;">
                                                            <asp:UpdatePanel ID="updtpnlfda" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblPDDate" runat="server"></asp:Label>&nbsp;
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                        <div align="right" style="padding-right: 10px">
                                                            <asp:UpdatePanel ID="updtpnlPDupdate" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="lnkbtnUpdatePdDate" Text="Update" runat="server" OnClick="lnkbtnUpdatePdDate_Click"></asp:LinkButton>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Payment Method</h4>
                                                    </td>
                                                    <td>
                                                        <%--  <input type="text" class="input3" />--%>
                                                        <asp:DropDownList ID="ddlPayMethod" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <h4 class="h43">
                                                            Payment Status</h4>
                                                    </td>
                                                    <td>
                                                        <%--<input type="text" class="input3" />--%>
                                                        <asp:DropDownList ID="ddlPayStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()"
                                                            OnSelectedIndexChanged="ddlPayStatus_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:HiddenField ID="hdnPDpayStatus" runat="server" />
                                                        <asp:HiddenField ID="hdnPDAmount" runat="server" />
                                                        <asp:HiddenField ID="hdnPDID" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Payment Trans ID</h4>
                                                    </td>
                                                    <td>
                                                        <%--  <input type="text" class="input3" />--%>
                                                        <asp:Label ID="lblPayConfirmNo" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtPayConfirmNum" runat="server" CssClass="input3" MaxLength="20"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Voice file confirmation #</h4>
                                                    </td>
                                                    <td>
                                                        <%--  <input type="text" class="input3" />--%>
                                                        <asp:Label ID="lblVoiceFileName" runat="server"></asp:Label>
                                                        <asp:TextBox ID="txtVoiceFileName" runat="server" CssClass="input3" MaxLength="20"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Pay Amount</h4>
                                                    </td>
                                                    <td>
                                                        <%--  <input type="text" class="input3" />--%>
                                                        <asp:Label ID="lblPayAmount" runat="server"></asp:Label>
                                                        <%-- <asp:TextBox ID="txtPayAmount" runat="server" CssClass="input3" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>--%>
                                                    </td>
                                                </tr>
                                                <tr>
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
                                            <table style="width: 99%; display: none; margin-left: 5px;" cellpadding='1' cellspacing='0'
                                                id="trListingStatus" runat="server">
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
                                                            <asp:ListItem Value="5">Admin Cancel</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="width: 99%; display: none; margin-left: 5px;" cellpadding='1' cellspacing='0'
                                                id="trUceStatus" runat="server">
                                                <tr>
                                                    <td style="width: 110px;">
                                                        <h4 class="h43">
                                                            Uce Status</h4>
                                                    </td>
                                                    <td style="width: 178px;">
                                                        <%--<input type="text" class="input3" />--%>
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
                                                        <%--<input type="text" class="input3" />--%>
                                                        <asp:DropDownList ID="ddlMultisiteStatus" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                            <asp:ListItem Value="1">Active</asp:ListItem>
                                                            <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                        </asp:DropDownList>
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
                                                    Customer name</h4>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRegName" runat="server" CssClass="input3" MaxLength="30" onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                <%-- <input type="text" class="input3 " />--%>
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
                                                <%-- <input type="text" class="input3 " />--%>
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
                            <td colspan="2" style="height: 10px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2'>
                                <div class="box1">
                                    <h3>
                                        Welcome Call Details</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    W Call Dt</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblWCCallDate" runat="server"></asp:Label>
                                                <%--<asp:TextBox ID="txtWCallDt" runat="server" CssClass="input3" MaxLength="20" onkeyup="return ChangeValuesHidden()"></asp:TextBox>--%>
                                                <%-- <input type="text" class="input3" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    W Call By</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblWCCallBy" runat="server"></asp:Label>
                                                <%-- <asp:TextBox ID="txtWCallBy" runat="server" CssClass="input3" MaxLength="20" onkeyup="return ChangeValuesHidden()"></asp:TextBox>--%>
                                                <%--  <input type="text" class="input3" />--%>
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
                    <asp:Button ID="btnResendWelMail" runat="server" Text="View/Resend Welcome Mail"
                        CssClass="g-button but1 " OnClick="btnResendWelMail_Click" Width="300px" Enabled='false' />
                    <%--<input type="button" value="View/Resend Welcome Mail" class="g-button but1 " />--%>
                    <asp:Button ID="btnSendStatusMail" runat="server" Text="View/Send Status Mail" CssClass="g-button but1"
                        Width="300px" Enabled='false' />
                    <%--<input type="button" value="View/Send Status Mail" class="g-button but1" />--%>
                    <asp:Button ID="btnSendListingDetails" runat="server" Text="View/Send Listing Details"
                        CssClass="g-button but1" Width="300px" Enabled='false' />
                    <%--<input type="button" value="View/Send Listing Details" class="g-button but1" width="290px" />--%>
                    <asp:Button ID="btnSendCustomMail" runat="server" Text="Create/Send custom mail"
                        CssClass="g-button but1" Width="300px" Enabled='false' />
                    <%--<input type="button" value="Create/Send custom mail" class="g-button but1" width="290px" />--%>
                    <asp:Button ID="btnSendPostingDetails" runat="server" Text="View/Send Posting Details"
                        CssClass="g-button but1" Width="300px" Enabled='false' />
                    <%--<input type="button" value="View/Send Posting Details" class="g-button but1" width="290px" />--%>
                    <asp:Button ID="btnSendStatistics" runat="server" Text="View/Send Statistics" CssClass="g-button but1"
                        Width="300px" Enabled='false' />
                    <%--<input type="button" value="View/Send Statistics" class="g-button but1" width="290px" />--%>
                    <table style="width: 300px;">
                        <tr>
                            <td>
                                <div class="box1" style="margin-top: 3px; width: 300px;">
                                    <h3>
                                        Stock Image</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td class="style1">
                                                <asp:Image ID="ImgStockPhoto" runat="server" CssClass="imgThumb" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan='5' style="padding-top: 10px;">
                    <div style="height: 2px; border-top: 2px #999 solid" class="clear">
                        &nbsp;</div>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px;">
                    <table style="width: 100%;" cellpadding='0' cellspacing='0'>
                        <tr>
                            <td colspan="2">
                                <div class="box1">
                                    <h3>
                                        Vehicle Information
                                    </h3>
                                    <table cellpadding='1' cellspacing='0' style="width: 99%; margin: 0 0 0 5px">
                                        <tr>
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    Make</h4>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="updtMake" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlMake" runat="server" AutoPostBack="true" CssClass="input1"
                                                            OnSelectedIndexChanged="ddlMake_SelectedIndexChanged" onchange="ChangeValuesHidden()">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <%-- <select class="input3">
                                    <option>Select make</option>
                                </select>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Model</h4>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel ID="updtpnlModel" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <%--<select class="input3">
                                    <option>Select model</option>
                                </select>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Type</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblType" runat="server"></asp:Label>
                                                <%-- <select class="input3">
                                    <option>Select type</option>
                                </select>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Year</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlYear" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                                <%--<select class="input3">
                                    <option>Select year</option>
                                </select>--%>
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
                                                <%-- <select class="input3">
                                    <option>Select color</option>
                                </select>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Body Style</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBodyStyle" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                    <%-- <asp:ListItem Value="0">Unspecified</asp:ListItem>--%>
                                                </asp:DropDownList>
                                                <%-- <select class="input3">
                                    <option>Select body style</option>
                                </select>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Engine Cylinders</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCylinderCount" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Transmission</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTransmission" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Drive Train</h4>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDriveTrain" runat="server" CssClass="input1" onchange="ChangeValuesHidden()">
                                                </asp:DropDownList>
                                                <%--   <input type="text" class="input3 number" />--%>
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
                                            <td style="width: 175px;">
                                                <div>
                                                    <em><b>Comfort</b></em>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures51" runat="server" />
                                                        <%--<input name="features" value="A/C: Front" type="checkbox" />--%>
                                                        A/C</div>
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
                                                        Navigation System
                                                    </div>
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
                                                        Remote Keyless Entry</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures8" runat="server" />
                                                        <%--<input name="features2" value="TV/VCR" type="checkbox" />--%>
                                                        TV/VCR</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures31" runat="server" />
                                                        <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                        Remote Start</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures33" runat="server" />
                                                        <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                        Tilt</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures35" runat="server" />
                                                        <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                        Rearview Camera</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures36" runat="server" />
                                                        <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                        Power Mirrors</div>
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
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures32" runat="server" />
                                                        <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                        Heated Seats</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures37" runat="server" />
                                                        <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                        Vinyl Interior</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures38" runat="server" />
                                                        <%--<input name="features2" value="Power Seats" type="checkbox" />--%>
                                                        Cloth Interior</div>
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
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures39" runat="server" />
                                                        <%--<input name="features2" value="Fog Lights" type="checkbox" />--%>
                                                        Power Brakes</div>
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
                                                        CD Changer
                                                    </div>
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
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures40" runat="server" />
                                                        <%--<input name="features2" value="Premium Sound" type="checkbox" />--%>
                                                        DVD</div>
                                                </div>
                                                <div>
                                                    <br />
                                                    <em><b>New</b></em>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures44" runat="server" />
                                                        <%--<input name="features2" value="Cassette Radio" type="checkbox" />--%>
                                                        Battery</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures45" runat="server" />
                                                        <%--<input name="features2" value="CD Changer" type="checkbox" />--%>
                                                        Tires
                                                    </div>
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
                                                        Sunroof</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures41" runat="server" />
                                                        <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                        Panoramic Roof</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures42" runat="server" />
                                                        <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                        Moon Roof</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures29" runat="server" />
                                                        <%--<input name="features2" value="Third Row Seats" type="checkbox" />--%>
                                                        Third Row Seats</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures30" runat="server" />
                                                        <%--<input name="features2" value="Tow Package" type="checkbox" />--%>
                                                        Tow Package</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures43" runat="server" />
                                                        <%--<input name="features2" value="Tow Package" type="checkbox" />--%>
                                                        Dashboard Wood frame</div>
                                                </div>
                                                <div>
                                                    <br />
                                                    <em><b>Specials</b></em>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures46" runat="server" />
                                                        <%--<input name="features2" value="Alloy Wheels" type="checkbox" />--%>
                                                        Garage Kept</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures47" runat="server" />
                                                        <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                        Non Smoking</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures48" runat="server" />
                                                        <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                        Records/Receipts Kept</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures49" runat="server" />
                                                        <%--<input name="features2" value="Sunroof/Moonroof" type="checkbox" />--%>
                                                        Well Maintained</div>
                                                    <div>
                                                        <asp:CheckBox ID="chkFeatures50" runat="server" />
                                                        <%--<input name="features2" value="Third Row Seats" type="checkbox" />--%>
                                                        Regular oil changes</div>
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
                                                            margin-top: 6px; height: 35px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"
                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 10px">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="position: absolute; bottom: -110px; vertical-align: top; padding-bottom: 20px;">
                                                <div class="box1" style="width: 290px;">
                                                    <h3>
                                                        URL Links</h3>
                                                    <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <%--  <a href="http://unitedcarexchange.com/SearchCarDetails.aspx?Make=Dodge&Model=Ram%202500%20Truck&ZipCode=0&WithinZip=5&C=4zVbl2Mc1042" target="_blank">Link to UCE listing</a>--%>
                                                                <asp:HyperLink ID="HylinkUCE" runat="server" Text="Link to UCE listing"></asp:HyperLink>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <br />
                                                <div class="box1 wid">
                                                    <h3>
                                                        Internal Notes</h3>
                                                    <asp:UpdatePanel ID="UpdatePane1BtnUpdate" runat="server">
                                                        <ContentTemplate>
                                                            <table style="width: 100%; margin-left: 5px;" cellpadding='1' cellspacing='1'>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtOldIntNotes" runat="server" ReadOnly="true" CssClass="textarea"
                                                                            Style="width: 98%; padding: 3px; margin-top: 6px; height: 140px; background: #eee"
                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="style2">
                                                                        <asp:TextBox ID="txtNewIntNotes" runat="server" Style="width: 98%; padding: 3px;
                                                                            margin-top: 6px; height: 45px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"
                                                                            onkeyup="return ChangeValuesHidden()"></asp:TextBox>
                                                                        <div class="clear">
                                                                            &nbsp;</div>
                                                                        <div style="width: 87px; text-align: center; margin: 0 auto">
                                                                            <asp:Button ID="btnIntUpdate" runat="server" Text="Update" CssClass="g-button " OnClick="btnIntUpdate_Click"
                                                                                OnClientClick="return ValidateVehicleType1();" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td style="padding-top: 10px; vertical-align: top;">
                    <div class="box1">
                        <h3>
                            Seller Info To Display In The Ad</h3>
                        <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                            <%--<tr>
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
                            <%-- <tr>
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
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td>
                    <asp:UpdatePanel ID="updtpnlPhotos" runat="server">
                        <ContentTemplate>
                            <div class="box1 " style="margin-top: 10px; width: 300px; margin-left: 0px; z-index: 15">
                                <h3>
                                    Pictures</h3>
                                <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                    <tr>
                                        <td class="style1">
                                            <table border="0" cellpadding="0" cellspacing="0" class="form1 photoUpload photoUploadPage"
                                                style="padding: 0; margin: 0;">
                                                <tbody>
                                                    <tr id="trShowPhotoCount" runat="server">
                                                        <td colspan="2">
                                                            Total Photos Uploaded:&nbsp<asp:Label ID="lblTotPhotosUploaded" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trShowall" runat="server">
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkbtnShowAllPhotosUploaded" runat="server" Text="Show All" OnClick="lnkbtnShowAllPhotosUploaded_Click"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr id="tdThumb" runat="server">
                                                        <td colspan="2">
                                                            <i style="font-style: inherit; color: #999; font-size: 11px;">* It is the primary picture
                                                                that will be shown in ads</i>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg1" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">1</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img1" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg1" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg2" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">2</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img2" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg2" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg3" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">3</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img3" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg3" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg4" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">4</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img4" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg4" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg5" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">5</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img5" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg5" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg6" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">6</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img6" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg6" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg7" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">7</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img7" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg7" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg8" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">8</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img8" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg8" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg9" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">9</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img9" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg9" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg10" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">10</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img10" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg10" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg11" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">11</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img11" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg11" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg12" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">12</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img12" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg12" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg13" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">13</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img13" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg13" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg14" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">14</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img14" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg14" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg15" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">15</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img15" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg15" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg16" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">16</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img16" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg16" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg17" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">17</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img17" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg17" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg18" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">18</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img18" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg18" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg19" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">19</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img19" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg19" runat="server" Text="Not Uploaded"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="trImg20" runat="server">
                                                        <td style="width: 150px;">
                                                            <span class="num">20</span>
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="Img20" runat="server" CssClass="imgThumb" />
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblImg20" runat="server" Text="Not Uploaded"></asp:Label>
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
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
        <br />
    </div>
    <%--<div class="footer">
        United Car Exchange © 2012</div>--%>
    <cc1:ModalPopupExtender ID="mpeViewregisterMail" runat="server" PopupControlID="divViewregisterMail"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnViewregisterMail" CancelControlID="btnCancelSendRegMail">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnViewregisterMail" runat="server" />
    <div id="divViewregisterMail" class="PopUpHolder">
        <div class="main">
            <h4>
                Registration Mail
                <!-- <asp:Button ID="BtnClsSendRegMail" class="cls" runat="server" Text="" BorderWidth="0" />  -->
                <!-- <div class="cls">
            </div> -->
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
                                <%--<input type="text" class="input1" style="width: 160px" />--%>
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
            <!-- <div class="cls">
            </div> -->
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
    <!-- PupUp For Ticket reason Start  -->
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
                                        <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlCallType" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Call Reason
                                    </td>
                                    <td>
                                        <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlCallReason" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Spoken with
                                    </td>
                                    <td>
                                        <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:TextBox ID="txtSpokenWith" runat="server" CssClass="input3" MaxLength="25"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Notes
                                    </td>
                                    <td>
                                        <%--<textarea class="textarea" style="height: 50px; margin: 0; width: 95%"></textarea>--%>
                                        <asp:TextBox runat="server" ID="txtTicketNotes" CssClass="textarea" Style="height: 50px;
                                            margin: 0; width: 95%" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Call Resolution
                                    </td>
                                    <td>
                                        <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlCallResolution" runat="server" CssClass="input1">
                                        </asp:DropDownList>
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
                                        <%-- <select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlTicketType" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Priority
                                    </td>
                                    <td>
                                        <%--  <select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlTicketPriority" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Call Back
                                    </td>
                                    <td>
                                        <%-- <select class="input1">
                                            <option></option>
                                        </select>--%>
                                        <asp:DropDownList ID="ddlCallBack" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Description
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTicketDescription" runat="server" CssClass="textarea" Style="height: 50px;
                                            margin: 0; width: 95%" TextMode="MultiLine" MaxLength="1000"></asp:TextBox>
                                        <%-- <textarea class="textarea" style="height: 50px; margin: 0; width: 95%"></textarea>--%>
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
                                                <asp:LinkButton ID="btnJustChecking" runat="server" Style="float: right; margin-top: 6px;"
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
    <!-- PupUp For Ticket reason End  -->
    <cc1:ModalPopupExtender ID="mpeAskNewSale" runat="server" PopupControlID="tblAskNewSale"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAskNewSale" CancelControlID="btnUpPdCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAskNewSale" runat="server" />
    <div id="tblAskNewSale" style="display: none; background-color: #adbc79; width: 300px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="3" style="background: #E7E7E7 url(../images/price-list-bg2.jpg) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Update PD Date
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="padding-left: 5px; width: 60px">
                                PD Date
                            </td>
                            <td style="padding-right: 5px; width: 100px">
                                <asp:UpdatePanel ID="updtpnlPDUpdateMdep" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlPdDateUp" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 10px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0 0 20px 0;" colspan="3">
                                <div align="center" style="width: 70%; padding-left: 50px">
                                    <div style="float: left">
                                        <asp:UpdatePanel ID="PDBTNUPDatepnl" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnPDUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit"
                                                    OnClientClick="return ValidatePDDatePopup()" OnClick="btnPDUpdate_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div>
                                        &nbsp;
                                        <asp:Button ID="btnUpPdCancel" CssClass="g-button g-button-submit" runat="server"
                                            Text="Cancel" Style="float: none" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
