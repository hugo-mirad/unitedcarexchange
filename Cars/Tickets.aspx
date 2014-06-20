<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Tickets.aspx.cs" Inherits="Tickets" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
   function isNumberKeyForDt(evt)
              {	
	    
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
                return false;
            return true;
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
     function isNumberKeyForDt(evt) {	

                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
                    return false;
                    return true;
                    }
    
    
        function ValidateDataForDown() {
            var valid = true;
            var today = new Date();
            var month = today.getMonth() + 1
            var day = today.getDate()
            var year = today.getFullYear()
            today = month + "/" + day + "/" + year
            var today = new Date(today);
            var SDate = document.getElementById('<%= txtStartDate.ClientID %>').value;
            var EDate = document.getElementById('<%= txtEndDate.ClientID %>').value;
            var endDate = new Date(EDate);
            var startDate = new Date(SDate);
            var Startmonth = startDate.getMonth() + 1
            var Startday = startDate.getDate()
            var Startyear = startDate.getFullYear()
            startDate = Startmonth + "/" + Startday + "/" + Startyear
            var startDate = new Date(startDate);

            var Endmonth = endDate.getMonth() + 1
            var Endday = endDate.getDate()
            var Endyear = endDate.getFullYear()
            var oneDay = 24 * 60 * 60 * 1000;

            endDate = Endmonth + "/" + Endday + "/" + Endyear

            var endDate = new Date(endDate);

            var ValidOldData = Math.abs((startDate.getTime() - today.getTime()) / (oneDay));
            var ValidDates = Math.abs((startDate.getTime() - endDate.getTime()) / (oneDay));
            
          
            if (SDate == '') {
                alert("Please enter start date");

                valid = false;
                return valid;
            }
            if (EDate == '') {

                alert("Please enter end date");
                valid = false;
                return valid;
            }
            var dtFromDt = document.getElementById('<%=txtStartDate.ClientID%>').value;
            if (isDate(dtFromDt) == false) {
                document.getElementById('<%=txtStartDate.ClientID%>').focus();
                valid = false;
                return valid;
            }

            var dtTodt = document.getElementById('<%=txtEndDate.ClientID%>').value;
            if (isDate(dtTodt) == false) {
                document.getElementById('<%=txtEndDate.ClientID%>').focus();
                valid = false;
                return valid;
            }                   
            
            if (SDate != '' && EDate != '' && startDate > endDate) {
                alert("Start date is greater than end date");
                valid = false;
                return valid;
            }
            if (startDate > today) {
                alert("Start date should not be greater Than current date");
                valid = false;
                return valid;
            }
            if (endDate > today) {

                alert("End date should not be greater than current date");
                valid = false;
                return valid;
            }
            if (ValidOldData >= 365) {
                alert("Report can be generated for maximum of one year prior. Please change the dates and resubmit again");
                document.getElementById("<%=txtStartDate.ClientID%>").focus();
                valid = false;
                return valid;
            }
            return valid;
        }


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
                alert("Report can be generated for maximum of one year prior. Please change the dates and resubmit again");
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
	});
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updtpnlTableShow"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlHeaders"
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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updtPnlSave"
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
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="updtpnltblGrdcar"
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
            Tickets</h1>
        <div class="clear">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTableShow" runat="server">
            <ContentTemplate>
                <table>
                    <tr>
                        <td style="width: 85px; padding-top: 10px;">
                            <%-- <input type="radio" name="showType" />
                    Pending--%>
                            <asp:RadioButton ID="rdbtnPending" runat="server" GroupName="ShowType" Text="Pending"
                                AutoPostBack="true" OnCheckedChanged="btnShow_Click" Checked="true" />
                        </td>
                        <td style="width: 95px; padding-top: 10px;">
                            <%--  <input type="radio" name="showType" />
                    All--%>
                            <asp:RadioButton ID="rdbtnProcessed" runat="server" GroupName="ShowType" Text="Processed"
                                AutoPostBack="true" OnCheckedChanged="btnShow_Click" />
                        </td>
                        <td style="width: 50px; padding-top: 10px;">
                            <%--  <input type="radio" name="showType" />
                    All--%>
                            <asp:RadioButton ID="rdbtnAll" runat="server" GroupName="ShowType" Text="All" AutoPostBack="true"
                                OnCheckedChanged="btnShow_Click" />
                        </td>
                        <td>
                            <%-- <input type="button" class="g-button g-button-submit" value="Show" />--%>
                            <%--<asp:Button ID="btnShow" runat="server" Text="Show" CssClass="g-button g-button-submit"
                                OnClick="btnShow_Click" />--%>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnltblGrdcar" runat="server">
            <ContentTemplate>
                <table style="width: 100%;" id="tblTicketDetails" runat="server">
                    <tr>
                        <td style="vertical-align: top;">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="85%" colspan="2">
                                                <asp:LinkButton ID="lnkbtnCarsResCount" runat="server" OnClick="lnkbtnCarsResCount_Click"></asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnRVSResCount" runat="server" OnClick="lnkbtnRVSResCount_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" width="60%">
                                                <asp:Label ID="lblResCount" runat="server"></asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:ImageButton ID="ImgbtnExcelForCars" runat="server" ImageUrl="~/images/excel4.jpg"
                                                    OnClick="ImgbtnExcelForCars_Click" />
                                                <asp:ImageButton ID="ImgbtnExcelForRvs" runat="server" ImageUrl="~/images/excel4.jpg"
                                                    OnClick="ImgbtnExcelForRvs_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div id="divCarResults" runat="server">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="updtPnlHeaders" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1398px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="70px">
                                                        <%--Ticket ID--%>
                                                        <asp:LinkButton ID="lnkTicketIDSort" runat="server" Text="Ticket ID &darr; &uarr;"
                                                            OnClick="lnkTicketIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="70px">
                                                        <%--Ticket ID--%>
                                                        <asp:LinkButton ID="lnkTicketDateSort" runat="server" Text="Ticket Dt &#8657" OnClick="lnkTicketDateSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px">
                                                        <%--Ticket ID--%>
                                                        <asp:LinkButton ID="lnkTicketCreatedBySort" runat="server" Text="Created By &darr; &uarr;"
                                                            OnClick="lnkTicketCreatedBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="60px">
                                                        <asp:LinkButton ID="lnkPrioritySort" runat="server" Text="Priority &darr; &uarr;"
                                                            OnClick="lnkPrioritySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkCallBackDtSort" runat="server" Text="Cl Back Dt &darr; &uarr;"
                                                            OnClick="lnkCallBackDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="85px">
                                                        <asp:LinkButton ID="lnkTicketTypeSort" runat="server" Text="Ticket Type &darr; &uarr;"
                                                            OnClick="lnkTicketTypeSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="60px">
                                                        <asp:LinkButton ID="lnkStatusSort" runat="server" Text="Status &darr; &uarr;" OnClick="lnkStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="60px">
                                                        <asp:LinkButton ID="lnkCarIDSort" runat="server" Text="Car ID &darr; &uarr;" OnClick="lnkCarIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkBrand" runat="server" Text="Brand &darr; &uarr;" OnClick="lnkBrand_Click"></asp:LinkButton>
                                                    </td> 
                                                    
                                                    <td width="90px">
                                                        <asp:LinkButton ID="lnkAssignedtoSort" runat="server" Text="Assigned To &darr; &uarr;"
                                                            OnClick="lnkAssignedtoSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px">
                                                        <asp:LinkButton ID="lnkComDtSort" runat="server" Text="Com Dt &darr; &uarr;" OnClick="lnkComDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkComBySort" runat="server" Text="Com By &darr; &uarr;" OnClick="lnkComBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px">
                                                        <asp:LinkButton ID="lnkCustNameSort" runat="server" Text="Cust Name &darr; &uarr;"
                                                            OnClick="lnkCustNameSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkPhoneSort" runat="server" Text="Phone &darr; &uarr;" OnClick="lnkPhoneSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="50px">
                                                        <asp:LinkButton ID="lnkYearSort" runat="server" Text="Year &darr; &uarr;" OnClick="lnkYearSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px">
                                                        <asp:LinkButton ID="lnkMakeSort" runat="server" Text="Make &darr; &uarr;" OnClick="lnkMakeSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkModelSort" runat="server" Text="Model &darr; &uarr;" OnClick="lnkModelSort_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1420px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="pnl1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1398px" ID="grdTicketDetails" runat="server" CellSpacing="0"
                                                    CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                    ShowHeader="false" OnRowCommand="grdTicketDetails_RowCommand" OnRowDataBound="grdTicketDetails_RowDataBound">
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
                                                                <asp:LinkButton ID="lnkTicketID" runat="server" Text='<%# Eval("TicketID")%>' CommandArgument='<%# Eval("TicketID")%>'
                                                                    CommandName="EditTicket"></asp:LinkButton>
                                                                <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTicketDt" runat="server" Text='<%# Bind("CreatedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CreatedBy"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTicketPriority" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"PriorityName")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCallBackDt" runat="server" Text='<%# Bind("CallBackDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTicketType" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"TicketTypeName")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="85px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("TicketStatusName")%>' />
                                                                <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCar"></asp:LinkButton>
                                                                <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        
                                                         <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBrand" runat="server" Text='<%#Eval("BrandCode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAssignedTo" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"AssignedTo"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblComDt" runat="server" Text='<%# Bind("SolvedDate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblComBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"SolvedBy")),10)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),12)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPhoneNum" runat="server" Value='<%# Eval("phone")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblModel" runat="server" Text='<%# Eval("model")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
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
                            </div>
                            <div id="divRVDetails" runat="server">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1318px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="70px">
                                                        <%--Ticket ID--%>
                                                        <asp:LinkButton ID="lnkBtnRVTicketIDSort" runat="server" Text="Ticket ID &darr; &uarr;"
                                                            OnClick="lnkBtnRVTicketIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="70px">
                                                        <%--Ticket ID--%>
                                                        <asp:LinkButton ID="lnkBtnRVTicketDateSort" runat="server" Text="Ticket Dt &#8657"
                                                            OnClick="lnkBtnRVTicketDateSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px">
                                                        <%--Ticket ID--%>
                                                        <asp:LinkButton ID="lnkBtnRvCreatedBySort" runat="server" Text="Created By &darr; &uarr;"
                                                            OnClick="lnkBtnRvCreatedBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="60px">
                                                        <asp:LinkButton ID="lnkBtnRvPrioritySort" runat="server" Text="Priority &darr; &uarr;"
                                                            OnClick="lnkBtnRvPrioritySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkBtnRvCallBackDtSort" runat="server" Text="Cl Back Dt &darr; &uarr;"
                                                            OnClick="lnkBtnRvCallBackDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="85px">
                                                        <asp:LinkButton ID="lnkBtnRvTicketTypeSort" runat="server" Text="Ticket Type &darr; &uarr;"
                                                            OnClick="lnkBtnRvTicketTypeSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="60px">
                                                        <asp:LinkButton ID="lnkBtnRvStatusSort" runat="server" Text="Status &darr; &uarr;"
                                                            OnClick="lnkBtnRvStatusSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="60px">
                                                        <asp:LinkButton ID="lnkBtnRvIDSort" runat="server" Text="RV ID &darr; &uarr;" OnClick="lnkBtnRvIDSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px">
                                                        <asp:LinkButton ID="lnkBtnRVAssignedToSort" runat="server" Text="Assigned To &darr; &uarr;"
                                                            OnClick="lnkBtnRVAssignedToSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="65px">
                                                        <asp:LinkButton ID="lnkBtnRVCompleteDtSort" runat="server" Text="Com Dt &darr; &uarr;"
                                                            OnClick="lnkBtnRVCompleteDtSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkBtnRvComBySort" runat="server" Text="Com By &darr; &uarr;"
                                                            OnClick="lnkBtnRvComBySort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px">
                                                        <asp:LinkButton ID="lnkBtnRvCustNameSort" runat="server" Text="Cust Name &darr; &uarr;"
                                                            OnClick="lnkBtnRvCustNameSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px">
                                                        <asp:LinkButton ID="lnkBtnRVPhoneSort" runat="server" Text="Phone &darr; &uarr;"
                                                            OnClick="lnkBtnRVPhoneSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="50px">
                                                        <asp:LinkButton ID="lnkBtnRvYearSort" runat="server" Text="Year &darr; &uarr;" OnClick="lnkBtnRvYearSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px">
                                                        <asp:LinkButton ID="lnkBtnRvTypeSort" runat="server" Text="Type &darr; &uarr;" OnClick="lnkBtnRvTypeSort_Click"></asp:LinkButton>
                                                    </td>
                                                    <td>
                                                        <asp:LinkButton ID="lnkBtnRvMakeSort" runat="server" Text="Make &darr; &uarr;" OnClick="lnkBtnRvMakeSort_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1340px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="Panel1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1318px" ID="grdRVTicketDetails" runat="server" CellSpacing="0"
                                                    CellPadding="0" CssClass="grid1" AutoGenerateColumns="False" GridLines="None"
                                                    ShowHeader="false" OnRowCommand="grdRVTicketDetails_RowCommand" OnRowDataBound="grdRVTicketDetails_RowDataBound">
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
                                                                <asp:LinkButton ID="lnkRVTicketID" runat="server" Text='<%# Eval("TicketID")%>' CommandArgument='<%# Eval("TicketID")%>'
                                                                    CommandName="EditTicket"></asp:LinkButton>
                                                                <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVTicketDt" runat="server" Text='<%# Bind("CreatedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="70px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVCreatedBy" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"CreatedBy"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVTicketPriority" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"PriorityName")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVCallBackDt" runat="server" Text='<%# Bind("CallBackDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVTicketType" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"TicketTypeName")),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="85px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVStatus" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnRVStatus" runat="server" Value='<%# Eval("TicketStatusName")%>' />
                                                                <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkRVID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCar"></asp:LinkButton>
                                                                <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVAssignedTo" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"AssignedTo"))),12) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVComDt" runat="server" Text='<%# Bind("SolvedDate", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVComBy" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"SolvedBy")),10)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),12)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnRVPhoneNum" runat="server" Value='<%# Eval("phone")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVYear" runat="server" Text='<%# Eval("yearOfMake")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRVType" runat="server" Text='<%# Eval("TypeName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRvMake" runat="server" Text='<%# Eval("make")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdRVTicketDetails" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <cc1:ModalPopupExtender ID="mdepTicketAlert" runat="server" PopupControlID="divTicketAlert"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnTicketAlert" CancelControlID="btnJustChecking">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnTicketAlert" runat="server" />
    <div id="divTicketAlert" class="PopUpHolder" style="display: none">
        <div class="main" style="width: 400px; margin: 60px auto 0 auto;">
            <h4>
                Ticket Details
                <!-- <div class="cls">
            </div> -->
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
                                                <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
                                                <asp:DropDownList ID="ddlTicketStatus" runat="server" CssClass="input1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tkt Assigned To
                                            </td>
                                            <td>
                                                <%--<select class="input1">
                                            <option></option>
                                        </select>--%>
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
                                                <img id="img1" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
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
                                                <asp:Button ID="btnSave" runat="server" CssClass="g-button g-button-submit" Text="Save"
                                                    OnClientClick="return ValidateData();" OnClick="btnSave_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:LinkButton ID="btnJustChecking" runat="server" Style="float: right; margin-top: 6px;"
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
    <cc1:ModalPopupExtender ID="mpeAskNewSale" runat="server" PopupControlID="tblAskNewSale"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAskNewSale" CancelControlID="btnDownloadCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAskNewSale" runat="server" />
    <div id="tblAskNewSale" style="display: none; background-color: #adbc79; width: 300px">
        <table width="100%" align="center" style="background-color: #ffffff;">
            <tr>
                <td colspan="3" style="background: #E7E7E7 url(../images/price-list-bg2.jpg) bottom left repeat-x;
                    height: 20px; padding: 10px 0px; color: #222; text-align: center; font-family: Verdana;
                    font-size: 12px; text-transform: uppercase; font-weight: bold;">
                    Select date range
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 96%; margin: 0 auto;">
                        <tr>
                            <td style="width: 270px; padding-top: 2px;">
                                <asp:UpdatePanel ID="updtPop" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 270px; float: left; margin-left: 0px; margin-right: 13px;">
                                            <tr>
                                                <td colspan="3" align="left">
                                                    <div style="border-bottom: 1px #666 solid; text-align: center; width: 240px; margin: 0 auto 2px auto;
                                                        font-weight: bold; padding-bottom: 2px;">
                                                        Date range</div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 45%; text-align: right">
                                                    <asp:TextBox ID="txtStartDate" runat="server" class="input1 " MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                        Width="70px"></asp:TextBox>&nbsp;
                                                    <img id="img2" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                        border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtStartDate,'mm/dd/yyyy',this);"
                                                        alt="Calendar Control" src="images/Calender.gif" width="18" />
                                                </td>
                                                <td style="width: 26px; text-align: center">
                                                    <b>to</b>
                                                </td>
                                                <td style="text-align: left">
                                                    <asp:TextBox ID="txtEndDate" runat="server" class="input1 " MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                                        Width="70px"></asp:TextBox>&nbsp;
                                                    <img id="img3" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                                        border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtEndDate,'mm/dd/yyyy',this);"
                                                        alt="Calendar Control" src="images/Calender.gif" width="18" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 10px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 0 0 20px 0;">
                                <div align="center">
                                    <asp:Button ID="btnDownloadOk" CssClass="g-button g-button-submit" runat="server"
                                        Text="Download" Style="float: none" OnClientClick="return ValidateDataForDown();" OnClick="btnDownloadOk_Click" />
                                    <asp:Button ID="btnDownloadCancel" CssClass="g-button g-button-submit" runat="server"
                                        Text="Cancel" Style="float: none" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
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
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErrorExists" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnOk" class="btn" runat="server" Text="Ok" />
        </div>
    </div>
    </form>
</body>
</html>
