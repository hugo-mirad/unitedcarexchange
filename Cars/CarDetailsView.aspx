<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CarDetailsView.aspx.cs" Inherits="CarDetailsView"
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
    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
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

    <script type='text/javascript'>
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
	    function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 
	    
	    
	});   
	    
    

    </script>

    <style type="text/css">
        .style1
        {
            width: 209px;
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
    <div class="headder">
        <%--  <uc1:LoginName ID="LoginName1" runat="server" />--%>
        <table style="width: 100%">
            <td style="width: 250px">
                <%-- <a href="index.aspx">
                    <img src="images/logo2.png" /></a>--%>
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
                    &nbsp; |&nbsp;<asp:LinkButton ID="lnkBtnLogout" runat="server" Text="Logout" Visible="false"
                        OnClick="lnkBtnLogout_Click" OnClientClick="return ChangeValues();"></asp:LinkButton></div>
            </td>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <table width="300px">
            <tr>
                <td style="width: 100px">
                    Customer Name:
                </td>
                <td>
                    <asp:Label ID="lblCarCustName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Package:
                </td>
                <td>
                    <asp:Label ID="lblCarPackName" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <h1 class="h1" style="margin-bottom: 5px;">
            Car Data<br />
            <asp:Label ID="lblViewCustDataHeading" runat="server"></asp:Label>
            <div style="width: 200px; float: right; margin-right: 40px;">
                <%--  <input type="button" value="Reset" class="g-button g-button-submit" />--%>
                <%-- <input type="button" value="Save" class="g-button g-button-submit" />--%>
                <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" CssClass="g-button g-button-submit"
                    Text="Edit" />
                <asp:Button ID="btnback" runat="server" CssClass="g-button g-button-submit" Text="Close"
                    OnClick="btnback_Click" />
            </div>
        </h1>
        <div class="clear">
            &nbsp;</div>
        <div id="divHeaderNote" runat="server">
            <h4 style="margin: 0 0 8px 2px; padding: 0; line-height: 16px;">
                Header Note
                <asp:Label ID="lblHeaderNote" runat="server" Style="font-weight: normal;"></asp:Label></h4>
        </div>
        <h4 style="margin: 0 0 8px 2px; padding: 0; line-height: 16px;">
            Car ID#
            <asp:Label ID="lblCarID" runat="server" Style="font-weight: normal;"></asp:Label>&nbsp;&nbsp;
            
              <asp:Label ID="lblBrand" runat="server" Style="font-weight: bold;"></asp:Label>
            </h4>
        <table style="width: 95%">
            <tr>
                <td style="width: 300px; vertical-align: top">
                    <table style="width: 300px;" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan='2'>
                                <div class="box1" style="display: none">
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
                                                    Sales Agent</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAgent" runat="server"></asp:Label>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Verifier</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVerifier" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Package</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2'>
                                <div class="box1" style="display: none">
                                    <h3>
                                        Customer Login Details</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td style="width: 110px">
                                                <h4 class="h43">
                                                    Email</h4>
                                            </td>
                                            <td>
                                                <%-- <input type="text" class="input3" />--%>
                                                <asp:Label ID="lblUserEmail" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Password</h4>
                                            </td>
                                            <td>
                                                <%--<input type="text" class="input3" />--%>
                                                <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan='2' style="height: 120px; vertical-align: top; padding-top: 0;">
                                <div class="box1 wid">
                                    <h3>
                                        Internal Notes</h3>
                                    <asp:UpdatePanel ID="UpdatePane1BtnUpdate" runat="server">
                                        <ContentTemplate>
                                            <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='1'>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtOldIntNotes" runat="server" ReadOnly="true" CssClass="textarea"
                                                            Style="width: 98%; padding: 3px; margin-top: 6px; height: 140px; background: #eee"
                                                            TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtNewIntNotes" runat="server" Style="width: 98%; padding: 3px;
                                                            margin-top: 6px; height: 45px;" TextMode="MultiLine" MaxLength="1000" CssClass="textarea"></asp:TextBox>
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
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 40px;">
                    &nbsp;
                </td>
                <td style="width: 300px; vertical-align: top">
                    <table style="width: 300px; display: none" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan='2'>
                                <div class="box1">
                                    <h3>
                                        Payment Details</h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr>
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    Payment Date</h4>
                                            </td>
                                            <td>
                                                <%--  <input type="text" class="input3" />--%>
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
                                                <asp:Label ID="lblPDDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    Payment Method</h4>
                                            </td>
                                            <td>
                                                <%--  <input type="text" class="input3" />--%>
                                                <asp:Label ID="lblPayMethod" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Payment Status</h4>
                                            </td>
                                            <td>
                                                <%--<input type="text" class="input3" />--%>
                                                <asp:Label ID="lblPayStatus" runat="server"></asp:Label>
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
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Ad Status</h4>
                                            </td>
                                            <td>
                                                <%--<input type="text" class="input3" />--%>
                                                <asp:Label ID="lblAdStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Uce Status</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblUceStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Multisite Status</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMultisiteStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Listing Status</h4>
                                            </td>
                                            <td>
                                                <%--<input type="text" class="input3" />--%>
                                                <asp:Label ID="lblListingStatus" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblRegName" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Phone number</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegPhNo" runat="server"></asp:Label>
                                                <%--<input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Address</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegAddress" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    City</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegCity" runat="server"></asp:Label>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    State</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegState" runat="server"></asp:Label>
                                                <%--  <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Zip</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRegZip" runat="server"></asp:Label>
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
                                                <%-- <input type="text" class="input3" />--%>
                                                <asp:Label ID="lblWCCallDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    W Call By</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblWCCallBy" runat="server"></asp:Label>
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
                        CssClass="g-button but1 " OnClick="btnResendWelMail_Click" Width="300px" />
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
                <td colspan='5' style="padding-top: 4px;">
                    <div style="height: 2px; border-top: 2px #999 solid" class="clear">
                        &nbsp;</div>
                </td>
            </tr>
        </table>
        <table style="width: 95%">
            <tr>
                <td style="width: 620px;">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 310px;">
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
                                                <asp:Label ID="lblMake" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblModel" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblYear" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Heading</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Price</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrice" runat="server" CssClass="price"></asp:Label>
                                                <%-- <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Mileage</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMileage" runat="server" CssClass="mileage"></asp:Label>
                                                <asp:Label ID="lblMi" Text="mi" runat="server" Visible="false"></asp:Label>
                                                <%-- <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Exterior Color</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblExteriorColor" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblInteriorColor" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblBodyStyle" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblEngineCylinders" runat="server"></asp:Label>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Transmission</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTransmission" runat="server"></asp:Label>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Drive Train</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDriveTrain" runat="server"></asp:Label>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Doors</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDoors" runat="server"></asp:Label>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Fuel Type</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFuelType" runat="server"></asp:Label>
                                                <%--   <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    VIN number</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVIN" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                            <td>
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
                                                <asp:Label ID="lblCustName" runat="server"></asp:Label>
                                                
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Phone number</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCustPhNo" runat="server"></asp:Label>
                                                <%--<input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Alt number</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAltNum" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Email</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSellerEmail" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 number" />--%>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td>
                                                <h4 class="h43">
                                                    Address</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                               
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    City</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCity" runat="server"></asp:Label>
                                                <%--<input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    State</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblState" runat="server"></asp:Label>
                                                <%--  <input type="text" class="input3 " />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Zip</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblZip" runat="server"></asp:Label>
                                                <%-- <input type="text" class="input3 number" maxlength="5" />--%>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box1" style="width: 100%">
                                    <h3>
                                        Vehicle Features</h3>
                                    <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Comfort</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblComFeature" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Seats</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSeatsFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Safety</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSafetyFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Sound System</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSoundFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Windows</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblWindowsFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Other</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOtherFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    New</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 110px; vertical-align: top;">
                                                <h4 class="h43">
                                                    Specials</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSpecialsFea" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box1" style="width: 100%">
                                    <h3>
                                        Other</h3>
                                    <table style="width: 99%; margin-left: 5px" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 110px;">
                                                <h4 class="h43">
                                                    Vehicle Condition</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblVehicleCondition" runat="server"></asp:Label>
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
                                                <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 10px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clear" style="height: 10px;">
                                        &nbsp;</div>
                                    <div style="position: absolute; bottom: -110px; vertical-align: top; padding-bottom: 30px;">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box1" style="width: 100%">
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box1" style="width: 100%">
                                    <h3>
                                        Multi-site Listings</h3>
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
                                                                <asp:HyperLink ID="htlnkURLListed" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),35)%>'
                                                                    NavigateUrl='<%# String.Format("http://{0}", Eval("URL").ToString()) %>' Target="_blank"></asp:HyperLink>
                                                                <asp:HiddenField ID="hdnUrlToNav" runat="server" Value='<%# Eval("URL")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Post Dt">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostDate" runat="server" Text='<%# Bind("UrlPostDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                                <asp:HiddenField ID="hdnPostDate" runat="server" Value='<%# Bind("UrlPostDate", "{0:MM/dd/yy}") %>' />
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="box1" style="width: 100%">
                                    <h3>
                                        Visits Count</h3>
                                    <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td style="width: 180px;">
                                                <h4 class="h43">
                                                    Home View Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblHomeViewCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Search View Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSearchViewCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Filter Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblFilterCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Make View Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMakeViewCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Make Model View Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMakeModelViewCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    All Makes and Models Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblMakeModelAllViewCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    Details View Count</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDetailsViewCount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    This Week</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblThisWeek" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <h4 class="h43">
                                                    This Month</h4>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblThisMonth" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <div class="box1" style="width: 100%">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <h3>
                                                Tickets
                                                <asp:LinkButton ID="lnkbtnAddTicketPopup" runat="server" Text="Add Ticket" Style="text-align: right;
                                                    float: right; font-size: 12px; font-weight: normal;" OnClick="lnkbtnAddTicketPopup_Click"></asp:LinkButton></h3>
                                            <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                            <asp:Label ID="lblTicketsError" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                runat="server"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Panel ID="Panel1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <br />
                                <div class="box1" style="width: 100%">
                                    <h3>
                                        Customer Service Calls
                                    </h3>
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
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Call Dt">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCSCallDt" runat="server" Text='<%# Bind("CallDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Call By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCSCallBy" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CallAgentID"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Call Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCSCallType" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"CallTypeName")),20) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Call Reason">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCSCallReason" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"CallReasonName")),20) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
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
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 10px;">
                    &nbsp;
                </td>
                <td style="width: 300px;">
                    <asp:UpdatePanel ID="updtpnlPhotos" runat="server">
                        <ContentTemplate>
                            <div class="box1 " style="margin-top: 3px; width: 300px;">
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
                                <%-- <asp:Label ID="lblMailTo" runat="server"></asp:Label>--%>
                                <%--<input type="text" class="input1" style="width: 160px" />--%>
                                <asp:TextBox ID="lblMailTo" CssClass="input1" Width="160px" runat="server"></asp:TextBox>
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
    <!-- PupUp For Ticket reason End  -->
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
    </form>
</body>
</html>
