<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewMultiCar.aspx.cs" Inherits="AddNewMultiCar" ValidateRequest="false"%>

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
             
               
         return valid;
      }
           
     
    </script>

    <script type="text/javascript" language="javascript">
        
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
        <%--<uc1:LoginName ID="LoginName1" runat="server" />--%>
        <table style="width: 100%">
            <td style="width: 250px">
                <%--  <a href="index.aspx">
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
    <div class="main" style="border: #ccc 1px solid; padding: 10px; background: rgb(253, 243, 234);
        height: 1450px;">
        <table width="300px">
            <tr>
                <td style="width: 100px">
                    Customer Name:
                </td>
                <td>
                    <asp:Label ID="lblCustName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Package:
                </td>
                <td>
                    <asp:Label ID="lblPackage" runat="server"></asp:Label>
                </td>
            </tr>
              <tr>
                <td>
                    Brand:
                </td>
                <td>
                    <asp:Label ID="lblBrand" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <h1 class="h1">
            Add a Car
            <div style="width: 400px; float: right; margin-right: 0;">
                <%--  <input type="button" value="Reset" class="g-button g-button-submit" />--%>
                <%-- <input type="button" value="Save" class="g-button g-button-submit" />--%>
                <asp:UpdatePanel ID="UpdatePane1BtnSalesUpdate" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnCancel" runat="server" CssClass="g-button g-button-submit" Text="Back"
                            OnClick="btnCancel_Click" OnClientClick="return ChangeValues();" />
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
                            <td colspan='2' style="height: 50px; vertical-align: top; padding-top: 0px;">
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
                <td style="width: 300px; vertical-align: top; height: 100px">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <div style="float: left; margin-left: 130px;">
                                <div class="box1">
                                    <h3>
                                        Status
                                    </h3>
                                    <table style="width: 99%; margin-left: 5px;" cellpadding='1' cellspacing='0'>
                                        <tr id="trAdStatus" runat="server">
                                            <td colspan="2">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 110px">
                                                            <h4 class="h43">
                                                                Ad Status</h4>
                                                        </td>
                                                        <td style="width: 178px;">
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
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan='3' style="padding-top: 50px;">
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
                                                    Make<span class="star">*</span></h4>
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
                                                    Model<span class="star">*</span></h4>
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
                                                    Year<span class="star">*</span></h4>
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
                                                    <%-- <h3>
                                                        URL Links</h3>
                                                    <table style="width: 99%; margin: 0 auto" cellpadding="1" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <asp:HyperLink ID="HylinkUCE" runat="server" Text="Link to UCE listing"></asp:HyperLink>
                                                                <br />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>--%>
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
                            Seller Info To Display In The Ad
                        </h3>
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
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
        <br />
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
    </form>
</body>
</html>
