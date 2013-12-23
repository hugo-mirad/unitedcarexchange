<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddChargebackNewForm.aspx.cs"
    Inherits="AddChargebackNewForm" %>

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
    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
   
        
         function ValidateUserData()
        {
         
            var valid=true;
            
             if((document.getElementById('<%=txtCCNumber.ClientID%>').value.trim() == "") && (document.getElementById('<%=txtVehicleID.ClientID%>').value.trim() == "")) 
             {
                document.getElementById('<%= txtCCNumber.ClientID%>').focus();
                alert("Please enter cc # or carid");
                document.getElementById('<%= txtCCNumber.ClientID%>').focus();
                 valid = false; 
                 return valid;      
             }                           
             if( (document.getElementById('<%=txtCCNumber.ClientID%>').value.length > 0 ) && (document.getElementById('<%=txtCCNumber.ClientID%>').value.length < 6))
             {
                document.getElementById('<%= txtCCNumber.ClientID%>').focus();
                alert("Please enter valid cc #");
                 document.getElementById('<%=txtCCNumber.ClientID%>').value = ""
                document.getElementById('<%=txtCCNumber.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }                      
            return valid;    
        
          }     
    </script>

    <script type='text/javascript'>
	
           function ValidateCBNotice()
        {
         
            var valid=true;                
              var grid = document.getElementById("grdIntroInfo");  //Retrieve the grid   
      
                var inputs = document.getElementsByTagName("input"); //Retrieve all the input elements from the grid
                var isValid = false;
                for (var i=0; i < inputs.length; i += 1) { //Iterate over every input element retrieved
                    if (inputs[i].type === "checkbox") { //If the current element's type is checkbox, then it is wat we need
                        if(inputs[i].checked === true) { //If the current checkbox is true, then atleast one checkbox is ticked, so break the loop
                            isValid = true;
                                    break;
                        }
                    }
                }
                if(!isValid) {
                    alert('Please select atleast one user');
                    return isValid;
                }
             if(document.getElementById('<%=txtCustomerContactDate.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%=txtCustomerContactDate.ClientID%>').focus();
                alert("Please enter customer contact date");
                 document.getElementById('<%=txtCustomerContactDate.ClientID%>').value = ""
                document.getElementById('<%=txtCustomerContactDate.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }  
              if (isDate(document.getElementById('<%=txtCustomerContactDate.ClientID %>').value) == false) {                
                document.getElementById('<%=txtCustomerContactDate.ClientID%>').value = "";
                document.getElementById('<%=txtCustomerContactDate.ClientID%>').focus();
                valid = false;
                return valid;
            }                
            if(document.getElementById('<%=txtResponseDate.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%=txtResponseDate.ClientID%>').focus();
                alert("Please enter response date");
                 document.getElementById('<%=txtResponseDate.ClientID%>').value = ""
                document.getElementById('<%=txtResponseDate.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }  
              if (isDate(document.getElementById('<%=txtResponseDate.ClientID %>').value) == false) {                
                document.getElementById('<%=txtResponseDate.ClientID%>').value = "";
                document.getElementById('<%=txtResponseDate.ClientID%>').focus();
                valid = false;
                return valid;
            }   
              if(document.getElementById('<%=txtChargebackDate.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%=txtChargebackDate.ClientID%>').focus();
                alert("Please enter chargeback date");
                 document.getElementById('<%=txtChargebackDate.ClientID%>').value = ""
                document.getElementById('<%=txtChargebackDate.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }  
              if (isDate(document.getElementById('<%=txtChargebackDate.ClientID %>').value) == false) {                
                document.getElementById('<%=txtChargebackDate.ClientID%>').value = "";
                document.getElementById('<%=txtChargebackDate.ClientID%>').focus();
                valid = false;
                return valid;
            }                           
            if (document.getElementById('<%=ddlType.ClientID%>').value =="0")
            {
                alert('Please select type')
                valid=false;
                document.getElementById('ddlType').focus();  
                return valid;
            }  
             if(document.getElementById('<%=txtPayAmount.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%=txtPayAmount.ClientID%>').focus();
                alert("Please enter amount");
                 document.getElementById('<%=txtPayAmount.ClientID%>').value = ""
                document.getElementById('<%=txtPayAmount.ClientID%>').focus()
                valid = false; 
                 return valid;              
             } 
            
          }      
    </script>

    <script type="text/javascript" language="javascript">
     
         function isNumberKeyForDt(evt)
              {	
	    
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
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
            function isNumberKey(evt)
         {
         debugger
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
          
    </script>

    <script type="text/javascript" language="javascript">

       
              var dtCh= "/";
  var Chktoday=new Date();    
            var minYear=Chktoday.getFullYear() - 1;
            var maxYear=Chktoday.getFullYear();

function isInteger(s){
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag){
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++){   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year){
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) {
	for (var i = 1; i <= n; i++) {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}

function isDate(dtStr){
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strMonth=dtStr.substring(0,pos1)
	var strDay=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1){
		alert("The date format should be : mm/dd/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12){
		alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
		alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear){
		alert("You cannot enter date older than one year")
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false){
		alert("Please enter a valid date")
		return false
	}
return true
}

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdatePanelBtnSearchUserDetails"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtpnlChargeBack"
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
        <h1 class="h1">
            Add New Chargeback</h1>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 50%;">
                    <table>
                        <tr>
                            <td>
                                Search Customer
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CC# (6 digits):<br />
                                <asp:TextBox ID="txtCCNumber" Width="150px" CssClass="input2" MaxLength="6" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                CarID:<br />
                                <asp:TextBox ID="txtVehicleID" runat="server" CssClass="input2" MaxLength="15" onkeypress="return isNumberKey(event)"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanelBtnSearchUserDetails" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSearchUserDetails" runat="server" Text="Go" CssClass="g-button g-button-submit"
                                            OnClientClick="return ValidateUserData();" Style="margin-top: 14px;" OnClick="btnSearchUserDetails_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                                        <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 3px 3px 3px 3px;
                                            border: #ccc 1px solid; height: 180px" id="divResults" runat="server">
                                            <asp:Panel ID="pnl1" Width="100%" runat="server">
                                                <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                <table style="width: 380px;" class="scrollTable noPad">
                                                    <asp:Repeater ID="grdIntroInfo" runat="server">
                                                        <HeaderTemplate>
                                                            <tr>
                                                                <th style="width: 30px;">
                                                                    &nbsp;
                                                                </th>
                                                                <th style="width: 130px; text-align: left;">
                                                                    Name
                                                                </th>
                                                                <th style="width: 80px; text-align: left;">
                                                                    Phone
                                                                </th>
                                                                <th style="width: 130px; text-align: left;">
                                                                    Email
                                                                </th>
                                                            </tr>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="width: 30px; text-align: left;">
                                                                    <asp:CheckBox ID="chkbx" runat="server" />
                                                                    <asp:HiddenField ID="hdnUID" runat="server" Value='<%# Eval("UId")%>' />
                                                                </td>
                                                                <td style="width: 130px; text-align: left;">
                                                                    <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 80px; text-align: left;">
                                                                    <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("phone")%>'></asp:Label>
                                                                </td>
                                                                <td style="width: 130px; text-align: left;">
                                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"UserName"),15)%>'></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </asp:Panel>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="grdIntroInfo" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:UpdatePanel ID="updtpnldata" runat="server">
                        <ContentTemplate>
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 98%; margin: 0 auto"
                                id="tblForm" runat="server">
                                <tr>
                                    <td colspan="2" style="height: 10px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="updtpnlChargeBack" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btnSaveChargeback" runat="server" Text="Save" CssClass="g-button g-button-submit"
                                                    OnClientClick="return ValidateCBNotice();" OnClick="btnSaveChargeback_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Notice Type<span class="star">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlNoticeType" runat="server" CssClass="input1" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Customer Contact Date<span class="star">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCustomerContactDate" runat="server" CssClass="input3" MaxLength="10"
                                            onkeypress="return isNumberKeyForDt(event)" Width="100px"></asp:TextBox>&nbsp;
                                        <img id="img22" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                            border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtCustomerContactDate,'mm/dd/yyyy',this);"
                                            alt="Calendar Control" src="images/Calender.gif" width="18" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Response Date<span class="star">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtResponseDate" runat="server" CssClass="input3" MaxLength="10"
                                            onkeypress="return isNumberKeyForDt(event)" Width="100px"></asp:TextBox>&nbsp;
                                        <img id="img1" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                            border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtResponseDate,'mm/dd/yyyy',this);"
                                            alt="Calendar Control" src="images/Calender.gif" width="18" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Chargeback Date<span class="star">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtChargebackDate" runat="server" CssClass="input3" MaxLength="10"
                                            onkeypress="return isNumberKeyForDt(event)" Width="100px"></asp:TextBox>&nbsp;
                                        <img id="img2" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                            border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtChargebackDate,'mm/dd/yyyy',this);"
                                            alt="Calendar Control" src="images/Calender.gif" width="18" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Type<span class="star">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlType" runat="server" CssClass="input1" Width="150px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Reason Code
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReasonCode" runat="server" CssClass="input3" MaxLength="25" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Reason Code Desc
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtReasonCodeDescription" runat="server" CssClass="textarea" MaxLength="500"
                                            Width="200px" TextMode="MultiLine" Style="margin: 2px 0 0 0;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Amount $<span class="star">*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPayAmount" runat="server" CssClass="input3" Width="100px" MaxLength="6"
                                            onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Notes
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCBNotes" runat="server" CssClass="textarea" MaxLength="500" Width="200px"
                                            TextMode="MultiLine" Style="margin: 2px 0 0 0;"></asp:TextBox>
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
        <br />
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
            <asp:Button ID="btnYesUpdated" class="btn" runat="server" Text="Ok" OnClick="BtnClsUpdated_Click" />
        </div>
    </div>
    </form>
</body>
</html>
