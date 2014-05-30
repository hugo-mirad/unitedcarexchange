<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultiCars.aspx.cs" Inherits="MultiCars" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
      function isNumberKey(evt)
         {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
        
        
        
        function ValidateVehicleType()
        {      
            var valid=true;             
                 
             if( (document.getElementById('<%=txtRegPhone.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtRegPhone.ClientID%>').value.length < 10))
             {
                document.getElementById('<%= txtRegPhone.ClientID%>').focus();
                alert("Please enter valid phone number");
                 document.getElementById('<%=txtRegPhone.ClientID%>').value = ""
                document.getElementById('<%=txtRegPhone.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }     
                if ((document.getElementById('<%=txtAltEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtAltEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtAltEmail.ClientID%>').value = ""
                document.getElementById('<%=txtAltEmail.ClientID%>').focus()
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
          
                 
            return valid;
        } 
        
        
         function ValidateChangePW()
        {
        
            var valid=true;     
            
              if (document.getElementById('<%=txtNewPW.ClientID%>').value.trim().length <1 )
            {
                alert('Please enter new password')
                valid=false;
              document.getElementById('<%=txtNewPW.ClientID%>').value = ""
               document.getElementById('<%=txtNewPW.ClientID%>').focus()
                return valid;
            }
             if((document.getElementById('<%= txtNewPW.ClientID%>').value.trim().length > 0) && (document.getElementById('<%= txtNewPW.ClientID%>').value.trim().length < 5))
            {
                document.getElementById('<%= txtNewPW.ClientID%>').focus();
                document.getElementById('<%=txtNewPW.ClientID%>').value = "";
                alert("Password length must be 5 characters");
                valid = false;            
                 return valid;     
            }    
             else if (document.getElementById('<%=txtConfirmPW.ClientID%>').value.trim().length <1 )
            {
                alert('Please enter confirm password')
                valid=false;
              document.getElementById('<%=txtConfirmPW.ClientID%>').value = ""
               document.getElementById('<%=txtConfirmPW.ClientID%>').focus()
                return valid;
            }
              else if( document.getElementById('<%=txtNewPW.ClientID%>').value.trim() != document.getElementById('<%=txtConfirmPW.ClientID%>').value.trim())
             {
                document.getElementById('<%= txtConfirmPW.ClientID%>').focus();
                alert("New password does not match the confirm password");
                 document.getElementById('<%=txtConfirmPW.ClientID%>').value = ""
                document.getElementById('<%=txtConfirmPW.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }          
          
                 
            return valid;
        }
        
          function ShowPW() {            
            document.getElementById('<%= txtNewPW.ClientID%>').value = "";
            document.getElementById('<%= txtConfirmPW.ClientID%>').value = "";   
            $find('<%= mpeChangePW.ClientID%>').show();                     
            return false;
        }
        
        function ValidateSelPack()
        { 
            var valid=true; 
            if(document.getElementById('<%= ddlSelPack.ClientID%>').value == "0") {
            document.getElementById('<%= ddlSelPack.ClientID%>').focus();
            alert("Select package");                 
            document.getElementById('<%=ddlSelPack.ClientID%>').focus()
            valid = false;            
            return valid;     
            } 
            return valid; 
        }
         
         function ValidateAddPack()
         {        
             var valid=true; 
            if(document.getElementById('<%= ddlAddPackage.ClientID%>').value == "0") {
            document.getElementById('<%= ddlAddPackage.ClientID%>').focus();
            alert("Select package");                 
            document.getElementById('<%=ddlAddPackage.ClientID%>').focus()
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
             
               if(document.getElementById('<%= txtPayConfirmNum.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtPayConfirmNum.ClientID%>').focus();
                alert("Enter payment Trans ID");
                 document.getElementById('<%=txtPayConfirmNum.ClientID%>').value = ""
                document.getElementById('<%=txtPayConfirmNum.ClientID%>').focus()
                valid = false;            
                return valid;     
            }    
                  
            var string = $('#ddlAddPackage option:selected').text();
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
           
              if(document.getElementById('<%= txtVoiceRecordNum.ClientID%>').value.length < 1) {
                document.getElementById('<%= txtVoiceRecordNum.ClientID%>').focus();
                alert("Enter voice file confirmation #");
                 document.getElementById('<%=txtVoiceRecordNum.ClientID%>').value = ""
                document.getElementById('<%=txtVoiceRecordNum.ClientID%>').focus()
                valid = false;            
                return valid;     
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
	    
      function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updtpnlRegUser"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlChangePwd"
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
    <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdPnlGrid"
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
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            Multi Car Listing</h1>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 610px">
                                <strong>Registrant Details</strong> for <strong><asp:Label ID="lblBrand" runat="server" ></asp:Label></strong> customer
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lnkbtnEditUserdata" Text="Edit" OnClick="lnkbtnEditUserdata_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <table id="tblIfDealer" runat="server" style="display: none;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="font-weight: bold;">
                                Dealer code:
                                <asp:Label ID="lblDealerCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="updtpnlRegUser" runat="server">
                        <ContentTemplate>
                            <div class="clear height2">
                                &nbsp;</div>
                            <div style="width: 300px; margin-right: 20px;" class="borderDiv">
                                <table class="grid1" cellpadding="0" cellspacing="0" id="tblRegDataShow" runat="server">
                                    <tr class="row1">
                                        <td class="hedLeft" style="width: 90px;">
                                            User id
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label runat="server" ID="lblUserIDName"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row2">
                                        <td class="hedLeft" style="width: 90px;">
                                            Password
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblUserPassword" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td class="hedLeft" style="width: 90px;">
                                            Name
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label runat="server" ID="lblUserName"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row2">
                                        <td class="hedLeft" style="width: 90px;">
                                            Business Name
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblBusinessName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td class="hedLeft" style="width: 90px;">
                                            Address
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblRegAddress" runat="server"></asp:Label>
                                            <asp:Label ID="lblRegCity" runat="server"></asp:Label>
                                            <asp:Label ID="lblRegState" runat="server"></asp:Label>
                                            <asp:Label ID="lblRegZip" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 300px;" class="borderDiv">
                                <table class="grid1" cellpadding="0" cellspacing="0" id="tblEmailDataShow" runat="server">
                                    <tr class="row1">
                                        <td class="hedLeft" style="width: 90px;">
                                            Email
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblRegEmail1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row2">
                                        <td class="hedLeft" style="width: 90px;">
                                            Alt Email
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblAltEmail" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row1">
                                        <td class="hedLeft" style="width: 90px;">
                                            Phone
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblRegPhone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="row2">
                                        <td class="hedLeft" style="width: 90px;">
                                            Alt Phone
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="lblAltPhone" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 250px;">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblRegUserName" runat="server"></asp:Label><br />
                            Member since:
                            <asp:Label ID="lblAddDate" runat="server"></asp:Label>
                            <br />
                            <asp:LinkButton ID="lnkbtnResetPassword" runat="server" Text="Change Password" OnClientClick="return ShowPW();"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div class="clear height20">
            &nbsp;</div>
        <table cellpadding="0" cellspacing="0" style="width: 650px">
            <tr>
                <td style="width: 570px;">
                    <strong>Package Details</strong>
                </td>
                <td>
                    <div style="width: 90px; font-size: 12px; font-weight: normal; float: right; text-align: right;">
                        <asp:LinkButton ID="lnkbtnAddPackage" runat="server" Text="Add Package" OnClick="lnkbtnAddPackage_Click"></asp:LinkButton>
                        <asp:LinkButton ID="lnkbtnUpdateDealer" runat="server" Text="Dealer View" OnClick="lnkbtnUpdateDealer_Click"></asp:LinkButton>
                        </div>
                </td>
            </tr>
        </table>
        <div class="clear height2">
            &nbsp;</div>
        <div style="width: 650px; position: relative; padding: 0 3px; height: 1px">
            <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                padding-top: 2px; width: 630px; background: #fff;">
                <tr class="tbHed">
                    <td width="50px">
                        Sno
                    </td>
                    <td>
                        Package
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
        <div style="width: 650px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
            border: #ccc 1px solid; height: 100px">
            <asp:Panel ID="Panel3" Width="100%" runat="server">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <input style="width: 91px" id="Hidden5" type="hidden" runat="server" enableviewstate="true" />
                        <input style="width: 40px" id="Hidden6" type="hidden" runat="server" enableviewstate="true" />
                        <asp:GridView Width="630px" ID="grdPackagDetails" runat="server" CellSpacing="0"
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
                                        <%# ((GridViewRow)Container).RowIndex + 1%>
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
        <div class="clear height20">
            &nbsp;</div>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 750px">
                    <strong>Car Details</strong> (click on CarID number to view/edit car listing details)
                </td>
                <td>
                    <div style="width: 90px; font-size: 12px; font-weight: normal; float: right; text-align: right;">
                        <asp:LinkButton ID="lnkbtnCarDetails" runat="server" Text="Add Car" OnClick="lnkbtnCarDetails_Click"></asp:LinkButton></div>
                </td>
            </tr>
        </table>
        <div class="clear height2">
            &nbsp;</div>
        <div style="width: 840px; position: relative; padding: 0 3px; height: 1px">
            <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                padding-top: 2px; width: 820px; background: #fff;">
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
                    <td width="60px">
                        Miles
                    </td>
                    <td width="60px">
                        Price
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 840px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
            border: #ccc 1px solid; height: 250px">
            <asp:Panel ID="Panel2" Width="100%" runat="server">
                <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                    <ContentTemplate>
                        <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                        <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                        <asp:GridView Width="820px" ID="grdCarDetails" runat="server" CellSpacing="0" CellPadding="0"
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
                                        <asp:Label ID="lblMiles" runat="server" Text='<%# Eval("mileage")%>' CssClass="mileage"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("price")%>' CssClass="price"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
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
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <cc1:ModalPopupExtender ID="mpeChangePW" runat="server" PopupControlID="tblChangePW"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnChangePW" CancelControlID="btnCancelPW">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnChangePW" runat="server" />
    <div id="tblChangePW" style="display: none; background-color: #adbc79; width: 400px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="2" style="background: #E7E7E7 url(../images/price-list-bg2.jpg) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Change Password
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="padding-left: 5px;" colspan="2">
                                <br />
                                <asp:UpdatePanel ID="uplPW" runat="server">
                                    <ContentTemplate>
                                        <span style="font-weight: bold">User Name: </span>
                                        <asp:Label ID="lblUnamePW" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px;">
                                New Password<span class="star">*</span>
                            </td>
                            <td style="padding-right: 5px;">
                                <asp:TextBox ID="txtNewPW" TextMode="Password" MaxLength="20" CssClass="input1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left: 5px;">
                                Confirm New Password<span class="star">*</span>
                            </td>
                            <td style="padding-right: 5px;">
                                <asp:TextBox ID="txtConfirmPW" MaxLength="20" TextMode="Password" CssClass="input1"
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0 0 20px 0;" colspan="2">
                                <div style="width: 60%; margin: 0; padding-left: 0; float: left; padding-right: 10px"
                                    align="right">
                                    <asp:UpdatePanel ID="updtPnlChangePwd" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnChangePW" CssClass="g-button g-button-submit" runat="server" Text="Change"
                                                OnClientClick="return ValidateChangePW();" OnClick="btnChangePW_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div align="left">
                                    <asp:Button ID="btnCancelPW" CssClass="g-button g-button-submit" runat="server" Text="Cancel" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:ModalPopupExtender ID="mpeSelectPack" runat="server" PopupControlID="divSelectPackage"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnSelectPack" CancelControlID="btnCancelSelPack">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnSelectPack" runat="server" />
    <div id="divSelectPackage" style="display: none; background-color: #adbc79; width: 400px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="2" style="background: #E7E7E7 url(../images/price-list-bg2.jpg) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Select Package
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="width: 120px;">
                                User id:
                            </td>
                            <td>
                                <asp:Label ID="lblUserAddPack" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Select a package<span class="star">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSelPack" runat="server" CssClass="input3">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0 0 20px 0;" colspan="2">
                                <div style="width: 60%; margin: 0; padding-left: 0; float: left; padding-right: 10px"
                                    align="right">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnGoSelPack" CssClass="g-button g-button-submit" runat="server"
                                                Text="Select" OnClientClick="return ValidateSelPack();" OnClick="btnGoSelPack_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div align="left">
                                    <asp:Button ID="btnCancelSelPack" CssClass="g-button g-button-submit" runat="server"
                                        Text="Cancel" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <cc1:ModalPopupExtender ID="mdepTicketAlert" runat="server" PopupControlID="divTicketAlert"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnTicketAlert" CancelControlID="btnAddPackCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnTicketAlert" runat="server" />
    <div id="divTicketAlert" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                Add Package
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 130px;">
                                        Package:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlAddPackage" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Payment Method
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPayMethod" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Payment Date
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPaymentDate" runat="server" CssClass="input1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Payment Trans ID
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPayConfirmNum" runat="server" CssClass="input3" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Amount
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPayAmount" runat="server" CssClass="input3" MaxLength="6" onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Voice file confirmation #
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtVoiceRecordNum" runat="server" CssClass="input3" MaxLength="20"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 60%; margin: 0; padding-left: 0; float: left; padding-right: 10px"
                                align="right">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnPackSvae" CssClass="g-button g-button-submit" runat="server" Text="Add"
                                            OnClientClick="return ValidateAddPack();" OnClick="btnPackSvae_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div align="left">
                                <asp:Button ID="btnAddPackCancel" CssClass="g-button g-button-submit" runat="server"
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
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" OkControlID="btnNo"
        CancelControlID="BtnCls">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none; height: 140px">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data" style="height: 110px">
            <p>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnNo" CssClass="btn" runat="server" Text="Cancel" />
            <asp:Button ID="btnYes" CssClass="btn" runat="server" Text="Ok" OnClick="btnYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="MdepUpdateUserDetails" runat="server" PopupControlID="divUpdateUserData"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnUpdateUserData" CancelControlID="btnUpUserCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnUpdateUserData" runat="server" />
    <div id="divUpdateUserData" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                Update Registrant Details
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table style="width: 330px; margin: 0 auto" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="vertical-align: top;">
                            <table class="alignMid" style="width: 100%;" cellpadding="1" cellspacing="0">
                                <tr>
                                    <td style="width: 130px;">
                                        User ID:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUpRegUserID" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px;">
                                        Password:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUpRegPassword" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px;">
                                        Email:
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRegEmail2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtregName" runat="server" MaxLength="25" CssClass="input3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Business Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBusinessName" runat="server" MaxLength="40" CssClass="input3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Phone
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegPhone" runat="server" MaxLength="10" CssClass="input3 number"
                                            onkeypress="return isNumberKey(event)" Enabled="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Alt Phone
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAltPhone" runat="server" MaxLength="10" CssClass="input3 number"
                                            onkeypress="return isNumberKey(event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Alt Email
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAltEmail" runat="server" MaxLength="40" CssClass="input3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Address
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegAddress" runat="server" MaxLength="40" CssClass="input3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        City
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegCity" runat="server" MaxLength="40" CssClass="input3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        State
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRegState" runat="server" CssClass="input1" Width="100px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Zip
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtZip" runat="server" MaxLength="10" CssClass="input3" onkeypress="return isNumberKeyWithDashForZip(event)"
                                            Width="80px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 60%; margin: 0; padding-left: 0; float: left; padding-right: 10px"
                                align="right">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnUpdateUserData" CssClass="g-button g-button-submit" runat="server"
                                            Text="Update" OnClick="lnkbtnUpdateUserData_Click" OnClientClick="return ValidateVehicleType();" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div align="left">
                                <asp:Button ID="btnUpUserCancel" CssClass="g-button g-button-submit" runat="server"
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
    <cc1:ModalPopupExtender ID="mdepAlertSuccess" runat="server" PopupControlID="divAlertPackSucess"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlerSuccess">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlerSuccess" runat="server" />
    <div id="divAlertPackSucess" class="alert" style="display: none;">
        <h4 id="H2">
            Alert
            <asp:Button ID="btnAlertCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnAlertOK_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAlertSuccess" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <%-- <asp:Button ID="btnAlertNo" CssClass="btn" runat="server" Text="Ok" />--%>
            <asp:Button ID="btnAlertOK" CssClass="btn" runat="server" Text="Ok" OnClick="btnAlertOK_Click" />
        </div>
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
    </form>
</body>
</html>
