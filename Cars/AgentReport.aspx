<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgentReport.aspx.cs" Inherits="AgentReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script src="Static/JS/calendar.js" type="text/javascript"></script>

    <link href="Static/Css/calender.css" rel="stylesheet" type="text/css" />

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
	});
    </script>

    <script type="text/javascript" language="javascript">
     function isNumberKeyForDt(evt) {	

                    var charCode = (evt.which) ? evt.which : event.keyCode
                    if (charCode > 31 && (charCode < 48 || charCode > 57)&& charCode != 47)
                    return false;
                    return true;
                    }
    
    
        function ValidateData() {
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
    <div class="headder">
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            SMARTZ USERS REPORT</h1>
        <div class="clear">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTableShow" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 180px;">
                            <div style="margin: 10px 0 2px 0; width: 98%; font-weight: bold">
                                Agent</div>
                            <asp:DropDownList ID="ddlAgentName" runat="server" CssClass="input1">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 270px; padding-top: 2px;">
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
                                        <img id="imgcal" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                            border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtStartDate,'mm/dd/yyyy',this);"
                                            alt="Calendar Control" src="images/Calender.gif" width="18" />
                                    </td>
                                    <td style="width: 26px; text-align: center">
                                        <b>to</b>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtEndDate" runat="server" class="input1 " MaxLength="10" onkeypress="return isNumberKeyForDt(event)"
                                            Width="70px"></asp:TextBox>&nbsp;
                                        <img id="img1" runat="server" style="border-right: 0px; border-top: 0px; border-left: 0px;
                                            border-bottom: 0px" title="Calendar Control" onclick="displayCalendar(document.forms[0].txtEndDate,'mm/dd/yyyy',this);"
                                            alt="Calendar Control" src="images/Calender.gif" width="18" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 105px; padding-top: 28px;">
                            <div style="float: left; width: 100px;">
                                <asp:UpdatePanel ID="updbtnSearch" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSearchMonth" runat="server" CssClass="g-button g-button-submit"
                                            Text="Generate" OnClientClick="return ValidateData();" OnClick="btnSearchMonth_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="updbtnSearch"
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
                            </div>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table style="width: 100%;" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="80%">
                                        <asp:Label ID="lblResHead" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblResCount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                        <asp:UpdatePanel ID="updtPnlHeaders" runat="server">
                            <ContentTemplate>
                                <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                    top: 2px; padding-top: 2px; width: 800px; background: #fff;">
                                    <tr class="tbHed">
                                        <td width="80px" align="left">
                                            <asp:LinkButton ID="lnkDateSort" runat="server" Text="Date &darr; &uarr;" OnClick="lnkDateSort_Click"></asp:LinkButton>
                                        </td>
                                        <td align="left" width="120px">
                                            <asp:LinkButton ID="lnkAgentNameSort" runat="server" Text="Agent Name &darr; &uarr;"
                                                OnClick="lnkAgentNameSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="100px" align="left">
                                            <asp:LinkButton ID="lnkCSCallsSort" runat="server" Text="CS Calls &darr; &uarr;"
                                                OnClick="lnkCSCallsSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="120px" align="left">
                                            <asp:LinkButton ID="lnkWCCallsDoneSort" runat="server" Text="WC Calls Done &darr; &uarr;"
                                                OnClick="lnkWCCallsDoneSort_Click"></asp:LinkButton>
                                        </td>
                                        <td width="120px" align="left">
                                            <asp:LinkButton ID="lnkTicketsCreatedSort" runat="server" Text="Tickets Created &darr; &uarr;"
                                                OnClick="lnkTicketsCreatedSort_Click"></asp:LinkButton>
                                        </td>
                                        <td align="left" width="120px">
                                            <asp:LinkButton ID="lnkTicketsSolvedSort" runat="server" Text="Tickets Solved &darr; &uarr;"
                                                OnClick="lnkTicketsSolvedSort_Click"></asp:LinkButton>
                                        </td>
                                        <td align="left">
                                            <asp:LinkButton ID="lnkSalesEneterdSort" runat="server" Text="Sales Entered &darr; &uarr;"
                                                OnClick="lnkTicketsSolvedSort_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="width: 820px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                        border: #ccc 1px solid; height: 230px">
                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                <ContentTemplate>
                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                    <asp:GridView Width="800px" ID="grdAgentData" runat="server" CellSpacing="0" CellPadding="0"
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
                                                    <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date", "{0:MM/dd/yy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="80px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAgentName" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"Agent")),15) %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCSCalls" runat="server" Text='<%# Eval("CsCalls")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWcCallsDone" runat="server" Text='<%# Eval("WCCallsDone")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTicketsCreated" runat="server" Text='<%# Eval("TicketsCreated")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTicketsSolved" runat="server" Text='<%# Eval("TicketsSolved")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSalesEntered" runat="server" Text='<%# Eval("SalesEntered")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdAgentData" EventName="Sorting" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
    </div>
    </form>
</body>
</html>
