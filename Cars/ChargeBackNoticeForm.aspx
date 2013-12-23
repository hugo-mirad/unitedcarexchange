<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeBackNoticeForm.aspx.cs"
    Inherits="ChargeBackNoticeForm" %>

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
          
          var validFiles=["bmp","gif","png","jpg","jpeg"];
                    function CheckExt(obj)
                    {
                      var source=obj.value;
                      var ext=source.substring(source.lastIndexOf(".")+1,source.length).toLowerCase();
                      for (var i=0; i<validFiles.length; i++)
                      { 
                        if (validFiles[i]==ext) 
                            break;
                      }
                      if (i>=validFiles.length)
                      {
                        alert("THAT IS NOT A VALID IMAGE\nPlease load an image with an extention of one of the following:\n\n"+validFiles.join(", "));
                        obj.focus();
                        obj.value = "";
                      }
                     }
    </script>

    <script type="text/javascript" language="javascript">
   
        
         function ValidateNoticeData()
        {
         
            var valid=true;           
             if((document.getElementById('<%=txtCaseNumber.ClientID%>').value.trim() == "") && (document.getElementById('<%=txtPreviousNoticeID.ClientID%>').value.trim() == "")) 
             {
                document.getElementById('<%= txtCaseNumber.ClientID%>').focus();
                alert("Please enter case # or noticeid");
                document.getElementById('<%= txtCaseNumber.ClientID%>').focus();
                 valid = false; 
                 return valid;      
             }                          
                             
            return valid;    
        
          }   
        function ValidateCBNotice()
        {
            var valid=true;   
            if (document.getElementById('<%=ddlNoticeType.ClientID%>').value =="0")
            {
                alert('Please select type')
                valid=false;
                document.getElementById('ddlNoticeType').focus();  
                return valid;
            }  
             if(document.getElementById('<%=txtNoticeDate.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%=txtNoticeDate.ClientID%>').focus();
                alert("Please enter notice date");
                 document.getElementById('<%=txtNoticeDate.ClientID%>').value = ""
                document.getElementById('<%=txtNoticeDate.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }  
              if (isDate(document.getElementById('<%=txtNoticeDate.ClientID %>').value) == false) {                
                document.getElementById('<%=txtNoticeDate.ClientID%>').value = "";
                document.getElementById('<%=txtNoticeDate.ClientID%>').focus();
                valid = false;
                return valid;
            }      
             if(document.getElementById('<%=txtReceivedDate.ClientID%>').value.trim().length == 0 ) 
             {
                document.getElementById('<%=txtReceivedDate.ClientID%>').focus();
                alert("Please enter received date");
                 document.getElementById('<%=txtReceivedDate.ClientID%>').value = ""
                document.getElementById('<%=txtReceivedDate.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }  
              if (isDate(document.getElementById('<%=txtReceivedDate.ClientID %>').value) == false) {                
                document.getElementById('<%=txtReceivedDate.ClientID%>').value = "";
                document.getElementById('<%=txtReceivedDate.ClientID%>').focus();
                valid = false;
                return valid;
            }   
             if(document.getElementById('<%=txtReplyDt.ClientID%>').value.trim().length > 0 ) 
             {
             if (isDate(document.getElementById('<%=txtReplyDt.ClientID %>').value) == false) {                
                document.getElementById('<%=txtReplyDt.ClientID%>').value = "";
                document.getElementById('<%=txtReplyDt.ClientID%>').focus();
                valid = false;
                return valid;
            }   
            }
             if ((document.getElementById('<%=txtSellerEmail.ClientID%>').value.length > 0) && (echeck(document.getElementById('<%=txtSellerEmail.ClientID%>').value) == false) )
             {               
                document.getElementById('<%=txtSellerEmail.ClientID%>').value = ""
                document.getElementById('<%=txtSellerEmail.ClientID%>').focus()
                valid = false;               
                return valid;     
            }   
             if((document.getElementById('<%= txtFaxNo.ClientID%>').value.length > 0) && (document.getElementById('<%= txtFaxNo.ClientID%>').value.length < 10)) {
                document.getElementById('<%= txtFaxNo.ClientID%>').focus();
                document.getElementById('<%=txtFaxNo.ClientID%>').value = "";
                alert("Enter valid fax number");
                valid = false; 
                 return valid;                
            
            }   
             var grid = document.getElementById("grdIntroInfo");  //Retrieve the grid   
      
                var inputs = document.getElementsByTagName("input"); //Retrieve all the input elements from the grid
                var isValid = false;
                for (var i=0; i < inputs.length; i += 1) { //Iterate over every input element retrieved
                    if (inputs[i].type === "checkbox") { //If the current element's type is checkbox, then it is wat we need
                        if(inputs[i].checked === true) { //If the current checkbox is true, then atleast one checkbox is ticked, so break the loop
                        if(isValid == true) {
                        alert('Please select only one user');
                        return isValid;
                        } 
                        else{ 
                        isValid = true;
                        break;
                        }
                        }
                    }
                }
              var grid1 = document.getElementById("repNotices");  //Retrieve the grid   
      
                var inputs1 = document.getElementsByTagName("input"); //Retrieve all the input elements from the grid
                var isValid1 = false;
                for (var i=0; i < inputs1.length; i += 1) { //Iterate over every input element retrieved
                    if (inputs1[i].type === "checkbox") { //If the current element's type is checkbox, then it is wat we need
                        if(inputs1[i].checked === true) { //If the current checkbox is true, then atleast one checkbox is ticked, so break the loop
                        if(isValid1 == true) {
                        alert('Please select only one user');
                        return isValid1;
                        } 
                        else{ 
                        isValid1 = true;
                        break;
                        }
                        }
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
        function ChangeValues()
       {         
           var answer = confirm("If you move out of this page, data will be permanently lost. Are you sure you want to move out of this page?")
           if (answer)
           {             
              window.location.href = "ChargeBackNoticeForm.aspx ";  
           }
           else           
           {
              return false;
           }  
            return false;       
       }    
          
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
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
        <table style="border-collapse: collapse">
            <tr>
                <td style="width: 380px;">
                    <table style="width: 370px; border-collapse: collapse">
                        <tr>
                            <td style="width: 130px;">
                                Notice Type<span class="star">*</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNoticeType" runat="server" CssClass="input1" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Notice Date<span class="star">*</span>
                            </td>
                            <td>
                                <%--<input type="text" class="input2 mb0" />--%>
                                <asp:TextBox ID="txtNoticeDate" runat="server" class="input2 mb0" MaxLength="10"
                                    onkeypress="return isNumberKeyForDt(event)" Width="80%"></asp:TextBox>&nbsp;
                                <img id="img22" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtNoticeDate,'mm/dd/yyyy',this);"
                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Received Date<span class="star">*</span>
                            </td>
                            <td>
                                <asp:TextBox ID="txtReceivedDate" runat="server" class="input2 mb0" MaxLength="10"
                                    onkeypress="return isNumberKeyForDt(event)" Width="80%"></asp:TextBox>&nbsp;
                                <img id="img1" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtReceivedDate,'mm/dd/yyyy',this);"
                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Case Number
                            </td>
                            <td>
                                <%--<input type="text" class="input2 mb0" />--%>
                                <asp:TextBox ID="txtCaseNumber" runat="server" CssClass="input2 mb0" MaxLength="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Dispute Amount
                            </td>
                            <td>
                                <asp:TextBox ID="txtPayAmount" runat="server" CssClass="input2 mb0" MaxLength="6"
                                    onkeypress="return isNumberKeyWithDot(event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Reply By Dt
                            </td>
                            <td>
                                <asp:TextBox ID="txtReplyDt" runat="server" class="input2 mb0" MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                    Width="80%"></asp:TextBox>&nbsp;
                                <img id="img2" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                    border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtReplyDt,'mm/dd/yyyy',this);"
                                    alt="Calendar Control" src="images/Calender.gif" width="18" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Reply Method
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlReplyMethod" runat="server" CssClass="input1" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                FaxNumber
                            </td>
                            <td>
                                <asp:TextBox ID="txtFaxNo" CssClass="input1" MaxLength="10" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="input2 mb0" MaxLength="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                State
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="input1" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 60px;">
                    &nbsp;
                </td>
                <td style="width: 380px;">
                    <table style="width: 380px;" class="vm">
                        <tr>
                            <td style="width: 100px;">
                                Reasons
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReason1" runat="server" CssClass="align" />
                                Product not as described
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReason2" runat="server" CssClass="align" />
                                Never authorized
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReason3" runat="server" CssClass="align" />
                                Cancelled
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReason4" runat="server" CssClass="align" />
                                Refund not processed
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReason5" runat="server" CssClass="align" />
                                Product not received
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkReason6" runat="server" CssClass="align" />
                                Other
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-top:15px;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email
                            </td>
                            <td>
                                <%--<input type="text" class="input2 mb0" />--%>
                                <asp:TextBox ID="txtSellerEmail" CssClass="input2 mb0" MaxLength="50" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                City
                            </td>
                            <td>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="input2 mb0" MaxLength="25"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Zip
                            </td>
                            <td>
                                <asp:TextBox ID="txtZip" runat="server" CssClass="input2 mb0" MaxLength="10" onkeypress="return isNumberKeyWithDashForZip(event)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;<br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table style="width: 800px; border-collapse: collapse">
                        <tr>
                            <td style="vertical-align: top; width: 130px">
                                Notes
                            </td>
                            <td>
                                <asp:TextBox ID="txtNotes" runat="server" CssClass="input3 w100p minH70" TextMode="MultiLine"
                                    MaxLength="1000"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;<br />
                    <br />
                </td>
            </tr>
            <tr>
            <tr>
                <td colspan="3">
                <div style="padding:10px; border:#999 1px dashed">
                    <table style="border-collapse:collapse; width:100%;">
                    
                        
                        
                        
                        <tr>
                <td>
                    
                    <table style="width: 380px; border-collapse: collapse;">
                        <tr>
                            <td style="width: 90px;">
                                CC# (6 digits)
                            </td>
                            <td>
                                <asp:TextBox ID="txtCCNumber" CssClass="input2 mb0" MaxLength="6" runat="server"
                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                                <div class="clear">
                                    &nbsp;</div>
                                <%--  <input type="button" class="g-button g-button-submit small   mt5" value="Search" />--%>
                            </td>
                        </tr>
                    </table>
                   
                </td>
                <td style="width:40px; text-align:center;">
                    or
                </td>
                <td>
                    <table style="width: 380px; border-collapse: collapse;">
                        <tr>
                            <td style="width: 40px;">
                                CarID
                            </td>
                            <td>
                                <asp:TextBox ID="txtVehicleID" runat="server" CssClass="input2 mb0" MaxLength="15"
                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSearchUserDetails" runat="server" Text="Search" CssClass="g-button g-button-submit small   mt5"
                                            OnClientClick="return ValidateUserData();" OnClick="btnSearchUserDetails_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblResult" runat="server" Visible="false" Style="color: Red;"></asp:Label>
                            <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 3px 3px 3px 3px;
                                border: #ccc 1px solid; height: 180px; display: none" id="divResults" runat="server">
                                <asp:Panel ID="pnl1" Width="100%" runat="server">
                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                    <table style="width: 380px;" class="scrollTable noPad">
                                        <asp:Repeater ID="grdIntroInfo" runat="server">
                                            <HeaderTemplate>
                                                <tr class="custHead">
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
                    </div>
                </td>
            </tr>
            
            
            <tr>
                <td colspan="3">
                    &nbsp;<br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 380px; border-collapse: collapse;">
                        <tr>
                            <td style="width: 130px;">
                                Notice copy
                            </td>
                            <td>
                                <asp:FileUpload ID="flupNoticeCopy" runat="server" CssClass="g-button g-button-submit small mt5 mt0"
                                    onchange="CheckExt(this)" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;<br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div style="padding:10px; border:#999 1px dashed">
                        <table style="border-collapse:collapse; width:100%;">
                            <tr>
                <td>
                    <table style="width: 380px; border-collapse: collapse;">
                        <tr>
                            <td style="width: 130px;">
                                Prev Notice ID
                            </td>
                            <td>
                                <asp:TextBox ID="txtPreviousNoticeID" runat="server" CssClass="input2 mb0" MaxLength="15"
                                    onkeypress="return isNumberKey(event)"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <table style="width: 380px; border-collapse: collapse;">
                        <tr>
                            <td>
                                <%--<input type="button" class="g-button g-button-submit small mt5 mt0" value="Check for prev notices" />--%>
                                <asp:UpdatePanel ID="updtpnl" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnPrevousNoticesCheck" runat="server" CssClass="g-button g-button-submit small mt5 mt0"
                                            Text="Check for prev notices" OnClientClick="return ValidateNoticeData();" OnClick="btnPrevousNoticesCheck_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="clear">
                                    &nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblNoticeResults" runat="server" Visible="false" Style="color: Red;"></asp:Label>
                            <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 3px 3px 3px 3px;
                                border: #ccc 1px solid; height: 180px; display: none" id="divNoticeRes" runat="server">
                                <asp:Panel ID="Panel1" Width="100%" runat="server">
                                    <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                    <table style="width: 580px;" class="scrollTable noPad">
                                        <asp:Repeater ID="repNotices" runat="server">
                                            <HeaderTemplate>
                                                <tr class="custHead">
                                                    <th style="width: 30px;">
                                                        &nbsp;
                                                    </th>
                                                    <th style="width: 60px; text-align: left;">
                                                        Notice ID
                                                    </th>
                                                    <th style="text-align: left;">
                                                        Name
                                                    </th>
                                                    <th style="width: 70px; text-align: left;">
                                                        Notice Dt
                                                    </th>
                                                    <th style="width: 90px; text-align: left;">
                                                        Type
                                                    </th>
                                                    <th style="width: 90px; text-align: left;">
                                                        Case #
                                                    </th>
                                                    <th style="width: 90px; text-align: left;">
                                                        Status
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td style="width: 30px; text-align: left;">
                                                        <asp:CheckBox ID="chkbx" runat="server" />
                                                        <asp:HiddenField ID="hdnNoticeID" runat="server" Value='<%# Eval("NoticeID")%>' />
                                                    </td>
                                                    <td style="width: 80px; text-align: left;">
                                                        <asp:Label ID="lblNoticeID" runat="server" Text='<%# Eval("NoticeID")%>'></asp:Label>
                                                    </td>
                                                    <td style="text-align: left;">
                                                        <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 70px; text-align: left;">
                                                        <asp:Label ID="lblNoticeDt" runat="server" Text='<%# Bind("NoticeDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; text-align: left;">
                                                        <asp:Label ID="lblNoticeType" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"NoticeTypeName"),12)%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; text-align: left;">
                                                        <asp:Label ID="lblCaseNo" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CaseNumber"),12)%>'></asp:Label>
                                                    </td>
                                                    <td style="width: 90px; text-align: left;">
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"NoticeStatusName"),12)%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </asp:Panel>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="repNotices" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td colspan="3">
                    &nbsp;<br />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 380px; border-collapse: collapse;">
                        <tr>
                            <td style="width: 40px; vertical-align:top; padding-top:6px;">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="g-button g-button-submit mt5"
                                    OnClientClick="return ValidateCBNotice();" OnClick="btnSave_Click" />
                                <%-- <input type="button" class="g-button g-button-submit mt5" value="Save" />--%>
                            </td>
                            <td style="width: 1px;">
                                &nbsp;
                            </td>
                            <td style="width: 40px; vertical-align:top;">
                                <%--  <input type="button" class="g-button mt5" value="Cancel" />--%>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="g-button mt5" OnClientClick="return ChangeValues();" />
                            </td>
                        </tr>
                    </table>
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
