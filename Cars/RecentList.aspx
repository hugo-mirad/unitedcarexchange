<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecentList.aspx.cs" Inherits="RecentList" %>

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

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
		
		
			$('#menu').css('marginLeft','-200px');
		$('#menu').hover(function(){
				$(this).animate({left:'200px'},{queue:false,duration:300});
			}, function(){
				$(this).animate({left:'0px'},{queue:false,duration:500});
			});
			
			
      KeyListener.init();
      KeyListener2.init();
            
            

	});
	
	
	  function  showSpinner(){
            $('#spinner1').show();
            //console.log('Show');
        }
        function  hideSpinner(){
            $('#spinner1').hide();
            //console.log('Hide');
        } 
        
          $(document).ready(function(){   
        $('#spinner1').show();
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

    <script type="text/javascript">
        function ButtonClick(buttonId) {
            alert("Button " + buttonId + " clicked from javascript");
            alert('show');
            return true;
        }
    </script>

</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <div id="spinner1" runat="server">
        <h4>
            <div>
                Processing
                <img src="images/loading.gif" />
            </div>
        </h4>
    </div>
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdtpnlHeader"
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
            Recent Sales and Updated Customer Data</h1>
        <div class="clear">
            &nbsp;</div>
        <table>
            <tr>
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
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top;">
                    <%--Most recent 500 premium customers (or Search Results- Top 500)--%><br />
                    <asp:Label ID="Label3" Font-Size="12px" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div style="width: 100%">
                                <div style="width: 50%; float: left">
                                    <asp:Label ID="lblResHead" runat="server"></asp:Label>
                                </div>
                                <div align="right" style="padding-right: 150px">
                                    <asp:Label ID="lblResCount" runat="server"></asp:Label>
                                </div>
                            </div>
                            <%--Most recent 500 premium customers (or Search Results- Top 500)--%><br />
                            <asp:Label ID="lblRes" Font-Size="12px" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="width: 100%;" id="divresults" runat="server">
                        <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                            <asp:UpdatePanel ID="UpdtpnlHeader" runat="server">
                                <ContentTemplate>
                                    <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                        top: 2px; padding-top: 2px; width: 1198px; background: #fff;">
                                        <tr class="tbHed">
                                            <td width="60" align="left">
                                                <asp:LinkButton ID="lnkCarIDSort" runat="server" Text="Car ID &darr; &uarr;" OnClick="lnkCarIDSort_Click"></asp:LinkButton>
                                                <%--Car ID--%>
                                            </td>
                                            <td width="60" align="left">
                                                Sale Type
                                            </td>
                                            <td align="left" width="50">
                                                <%--Status--%>
                                                <asp:LinkButton ID="lnkStatusSort" runat="server" Text="Ad St &darr; &uarr;" OnClick="lnkStatusSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="65" align="left">
                                                <asp:LinkButton ID="lnkSaleDateSort" runat="server" Text="Sale Dt &darr; &uarr;"
                                                    OnClick="lnkSaleDateSort_Click"></asp:LinkButton>
                                                <%--Posted Dt--%>
                                            </td>
                                            <td width="80" align="left">
                                                <asp:LinkButton ID="lnkPostedSort" runat="server" Text="Updated Dt &#8657" OnClick="lnkPostedSort_Click"></asp:LinkButton>
                                                <%--Posted Dt--%>
                                            </td>
                                            <td width="80" align="left">
                                                <%--Agent--%>
                                                <asp:LinkButton ID="lnkAgentSort" runat="server" Text="Agent &darr; &uarr;" OnClick="lnkAgentSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="50" align="left">
                                                <%--Year--%>
                                                <asp:LinkButton ID="lnkYearSort" runat="server" Text="Year &darr; &uarr;" OnClick="lnkYearSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="100" align="left">
                                                <%--Make--%>
                                                <asp:LinkButton ID="lnkMakeSort" runat="server" Text="Make &darr; &uarr;" OnClick="lnkMakeSort_Click"></asp:LinkButton>
                                            </td>
                                            <td align="left">
                                                <%--Model--%>
                                                <asp:LinkButton ID="lnkModelSort" runat="server" Text="Model &darr; &uarr;" OnClick="lnkModelSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="140" align="left">
                                                <%--Package--%>
                                                <asp:LinkButton ID="lnkPackageSort" runat="server" Text="Package &darr; &uarr;" OnClick="lnkPackageSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="130px" align="left">
                                                <%--Name--%>
                                                <asp:LinkButton ID="lnkNameSort" runat="server" Text="Name &darr; &uarr;" OnClick="lnkNameSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="90" align="left">
                                                <%--Phone--%>
                                                <asp:LinkButton ID="lnkPhoneSort" runat="server" Text="Reg Phone &darr; &uarr;" OnClick="lnkPhoneSort_Click"></asp:LinkButton>
                                            </td>
                                            <td width="130" align="left">
                                                <%--Email--%>
                                                <asp:LinkButton ID="lnkEmailSort" runat="server" Text="Email &darr; &uarr;" OnClick="lnkEmailSort_Click"></asp:LinkButton>
                                            </td>
                                            <%--<td width="40">
                                                Pmnt
                                            </td>
                                            <td width="45">
                                                Status
                                            </td>--%>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="width: 1220px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                            border: #ccc 1px solid; height: 400px">
                            <asp:Panel ID="pnl1" Width="100%" runat="server">
                                <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                    <ContentTemplate>
                                        <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                        <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                        <asp:GridView Width="1198px" ID="grdIntroInfo" runat="server" CellSpacing="0" CellPadding="0"
                                            CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                            OnRowDataBound="grdIntroInfo_RowDataBound" OnRowCommand="grdIntroInfo_RowCommand">
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
                                                        <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                            CommandName="EditCar"></asp:LinkButton>
                                                        <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Image ID="ImgSaleType" runat="server" />
                                                        <asp:HiddenField ID="hdnSaleEnteredBy" runat="server" Value='<%# Eval("SaleEnteredBy")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblStatus" runat="server" ></asp:Label>--%>
                                                        <asp:Image ID="ImgStatus" runat="server" />
                                                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Adstatus")%>' />
                                                        <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSaleDt" runat="server" Text='<%# Bind("SaleDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="65px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPostedDt" runat="server" Text='<%# Bind("UpdatedDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgent" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hdnAgentID" runat="server" Value='<%# Eval("SaleAgentID")%>' />
                                                        <asp:HiddenField ID="hdnAgentName" runat="server" Value='<%# Eval("American_Name")%>' />
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
                                                        <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hdnPackName" runat="server" Value='<%# Eval("Description")%>' />
                                                        <asp:HiddenField ID="hdnPackCost" runat="server" Value='<%# Eval("Price")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="140px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hdnPhoneNum" runat="server" Value='<%# Eval("phone")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"UserName"),15)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="grdIntroInfo" EventName="Sorting" />
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
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <%--<div class="footer">
        United Car Exchange © 2012</div>--%>
    </form>
</body>

<script type="text/javascript" language="javascript">     
    $(window).load(function(){    
        $('#spinner1').hide();
    });
</script>

</html>
