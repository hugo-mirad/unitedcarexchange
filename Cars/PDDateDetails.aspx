<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PDDateDetails.aspx.cs" Inherits="PDDateDetails"
    ValidateRequest="false" %>

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

    <script type="text/javascript">
  function ClosePopup() {
            $find('<%= MPEUpdate.ClientID%>').hide();
            return false;
        }
        
        function PayInfoChanges() {
	     debugger;
	        if(document.getElementById('<%=hdnPopPayType.ClientID%>').value =="6")
	        {
	            document.getElementById('<%=divTransID.ClientID%>').style.display = "none";
	            document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "none";
	            document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "none";
	        }
	        else
	        {	        
	            if((document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="7")||(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="8"))
	            {
                    document.getElementById('<%=divTransID.ClientID%>').style.display = "block";
	                document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "block";	               
	                document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "block";
	                if(document.getElementById('<%=hdnPophdnAmount.ClientID%>').value =="0")
	                {
	                    document.getElementById('<%=divTransID.ClientID%>').style.display = "none";
	                    document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "none";	                    
	                    document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "none";
	                }
                }
                else
                {
                    document.getElementById('<%=divTransID.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentDate.ClientID%>').style.display = "none";
	                document.getElementById('<%=divPaymentAmount.ClientID%>').style.display = "none";
	               
                }
            }
            return false;
        }
 function ValidateUpdate() {
        
            var valid = true;
            if(document.getElementById('<%=ddlPaymentStatus.ClientID%>').value =="2")
            {
                if(document.getElementById('<%=hdnPophdnAmount.ClientID%>').value != "0")
                {
                    if(document.getElementById('<%= ddlPaymentDate.ClientID%>').value == "0") {
                        document.getElementById('<%= ddlPaymentDate.ClientID%>').focus();
                        alert("Select payment date");                 
                        document.getElementById('<%=ddlPaymentDate.ClientID%>').focus()
                        valid = false;            
                         return valid;     
                    }  
                    if (document.getElementById('<%= txtPaymentAmountInPop.ClientID%>').value.trim().length < 1)
                    {
                        alert("Please enter amount paid"); 
                        valid=false;
                        document.getElementById('txtPaymentAmountInPop').focus();  
                        return valid;               
                    }  
                     if (document.getElementById('<%= txtPaymentAmountInPop.ClientID%>').value.trim()!=document.getElementById('<%= hdnPophdnAmount.ClientID%>').value)
                    {
                        alert("Amount entered not match with amount need to be paid now"); 
                        valid=false;
                        document.getElementById('txtPaymentAmountInPop').focus();  
                        return valid;               
                    }  
                    if (document.getElementById('<%= txtPaytransID.ClientID%>').value.trim().length < 1)
                    {
                        alert("Please enter transaction id"); 
                        valid=false;
                        document.getElementById('txtPaytransID').focus();  
                        return valid;               
                    }
                }
            }             
            
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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdPnlGrid"
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
            POST DATE PAYMENT DATA</h1>
        <div class="clear">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTableShow" runat="server">
            <ContentTemplate>
                <div class="clear" style="height: 10px; margin-top: 10px; border-top: 2px Solid #ccc;
                    width: 250px;">
                    &nbsp;</div>
                <table style="width: 100%;">
                    <tr>
                        <td style="width: 80px;">
                            <asp:RadioButton ID="rdbtnPaid" runat="server" Text="Paid" OnCheckedChanged="rdbtnPaid_CheckedChanged"
                                AutoPostBack="true" GroupName="PDData" />
                            <%--<asp:LinkButton ID="lnkbtnPaid" runat="server" Text="Paid" OnClick="lnkbtnPaid_Click"></asp:LinkButton>--%>
                        </td>
                        <td style="width: 80px;">
                            <asp:RadioButton ID="rdbtnPending" runat="server" Text="Pending" OnCheckedChanged="rdbtnPending_CheckedChanged"
                                AutoPostBack="true" GroupName="PDData" Checked="true" />
                            <%-- <asp:LinkButton ID="lnkbtnOpen" runat="server" Text="Open" OnClick="lnkbtnOpen_Click"></asp:LinkButton>--%>
                        </td>
                        <td style="width: 120px;">
                            <asp:RadioButton ID="rdbtnAdminCancel" runat="server" Text="Admin Cancel" AutoPostBack="true"
                                OnCheckedChanged="rdbtnAdminCancel_CheckedChanged" GroupName="PDData" />
                            <%--<asp:LinkButton ID="lnkbtnCancelled" runat="server" Text="Cancelled" OnClick="lnkbtnCancelled_Click"></asp:LinkButton>--%>
                        </td>
                        <td style="width: 80px;">
                            <asp:RadioButton ID="rdbtnAll" runat="server" Text="All" OnCheckedChanged="rdbtnAll_CheckedChanged"
                                AutoPostBack="true" GroupName="PDData" />
                            <%--<asp:LinkButton ID="lnkbtnCancelled" runat="server" Text="Cancelled" OnClick="lnkbtnCancelled_Click"></asp:LinkButton>--%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clear" style="height: 20px; margin-top: 10px; border-top: 2px dotted #ccc;">
            &nbsp;</div>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <asp:UpdatePanel ID="updtpnlTotalData" runat="server">
            <ContentTemplate>
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
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;">
                            <div id="divCars" runat="server" style="width: 100%">
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <asp:UpdatePanel ID="updtPnlHeaders" runat="server">
                                        <ContentTemplate>
                                            <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                                top: 2px; padding-top: 2px; width: 1710px; background: #fff;">
                                                <tr class="tbHed">
                                                    <td width="60px" align="left">
                                                        <asp:LinkButton ID="lblCarID" runat="server" Text="Car ID &darr; &uarr;" OnClick="lblCarID_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="50px">
                                                        <asp:LinkButton ID="lblAdStatus" runat="server" Text="Ad St &darr; &uarr;" OnClick="lblAdStatus_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblSaleDate" runat="server" Text="Sale Dt &darr; &uarr;" OnClick="lblSaleDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblPostDate" runat="server" Text="Posted Dt &darr; &uarr;" OnClick="lblPostDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblPDDate" runat="server" Text="PD Pay Dt &#8659" OnClick="lblPDDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px" align="left">
                                                        <asp:LinkButton ID="lnkbtnPDStatus" runat="server" Text="PD Status &darr; &uarr;"
                                                            OnClick="lnkbtnPDStatus_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px" align="left">
                                                        <asp:LinkButton ID="lnkPDAmount" runat="server" Text="PD Amount &darr; &uarr;" OnClick="lnkPDAmount_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="90px" align="left">
                                                        <asp:LinkButton ID="lblPaymentDate" runat="server" Text="Payment Dt &darr; &uarr;"
                                                            OnClick="lblPaymentDate_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px" align="left">
                                                        <asp:LinkButton ID="lnkbtnPayStatus" runat="server" Text="Pay Status &darr; &uarr;"
                                                            OnClick="lnkbtnPayStatus_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="100px" align="left">
                                                        <asp:LinkButton ID="lnkPaidAmount" runat="server" Text="Paid Amount &darr; &uarr;"
                                                            OnClick="lnkPaidAmount_Click"></asp:LinkButton>
                                                    </td>
                                                    <td width="80px" align="left">
                                                        <asp:LinkButton ID="lblAgent" runat="server" Text="Agent &darr; &uarr;" OnClick="lblAgent_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="50px">
                                                        <asp:LinkButton ID="lblYear" runat="server" Text="Year &darr; &uarr;" OnClick="lblYear_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="100px">
                                                        <asp:LinkButton ID="lblMake" runat="server" Text="Make &darr; &uarr;" OnClick="lblMake_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left">
                                                        <asp:LinkButton ID="lblModel" runat="server" Text="Model &darr; &uarr;" OnClick="lblModel_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="150px">
                                                        <asp:LinkButton ID="lblPackage" runat="server" Text="Package &darr; &uarr;" OnClick="lblPackage_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="110px">
                                                        <asp:LinkButton ID="lblName" runat="server" Text="Name &darr; &uarr;" OnClick="lblName_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="90px">
                                                        <asp:LinkButton ID="lblPhone" runat="server" Text="Phone &darr; &uarr;" OnClick="lblPhone_Click"></asp:LinkButton>
                                                    </td>
                                                    <td align="left" width="130px">
                                                        <asp:LinkButton ID="lblEmail" runat="server" Text="Email &darr; &uarr;" OnClick="lblEmail_Click"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="width: 1730px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 230px">
                                    <asp:Panel ID="pnl1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="1710px" ID="grdPDPayData" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                    OnRowDataBound="grdPDPayData_RowDataBound" OnRowCommand="grdPDPayData_RowCommand">
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
                                                                <%--<asp:Label ID="lblCarID" runat="server" Text='<%# Eval("carid")%>'></asp:Label>--%>
                                                                <asp:LinkButton ID="lnkCarID" runat="server" Text='<%# Eval("carid")%>' CommandArgument='<%# Eval("postingID")%>'
                                                                    CommandName="EditCar"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Image ID="ImgStatus" runat="server" />
                                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("Adstatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSaleDate" runat="server" Text='<%# Bind("SaleDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostedDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPDDate" runat="server" Text='<%# Bind("PDDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%--<asp:Label ID="lblPDStatus" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"PDPmntStatusName")),15) %>'></asp:Label>--%>
                                                                <asp:LinkButton ID="lnkPDStatus" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"PDPmntStatusName")),15) %>'
                                                                    CommandArgument='<%# Eval("postingID")%>' CommandName="EditPay"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPDAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"PDAmount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaymentDate" runat="server" Text='<%# Bind("PaymentDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPayStatus" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"PmntStatusName")),15) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaidAmount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAgentName" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(DataBinder.Eval(Container.DataItem,"Agent_Name")),10) %>'></asp:Label>
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
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPackName" runat="server" Value='<%# Eval("Description")%>' />
                                                                <asp:HiddenField ID="hdnPackCost" runat="server" Value='<%# Eval("Price")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"Name"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="110px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPhoneNum" runat="server" Value='<%# Eval("PhoneNum")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="90px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEmail" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"email"),15)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdPDPayData" EventName="Sorting" />
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
        <asp:HiddenField ID="btnOpen" runat="server" />
        <cc1:ModalPopupExtender ID="MPEUpdate" runat="server" PopupControlID="tblUpdate"
            BackgroundCssClass="ModalPopupBG" TargetControlID="btnOpen" CancelControlID="btnCancelUpdate">
        </cc1:ModalPopupExtender>
        <div id="tblUpdate" class="PopUpHolder" style="display: none;">
            <div class="main" style="height: 520px; margin-top: 70px; width: 650px">
                <h4>
                    Update Payment Details
                    <!-- <div class="cls">
            </div> -->
                </h4>
                <div class="dat" style="padding: 0 0 0 3; overflow: scroll; height: 480px;">
                    <table id="Table2" runat="server" align="center" cellpadding="0" cellspacing="0"
                        style="width: 100%; margin: 0 auto;">
                        <tr>
                            <td style="width: 100%;">
                                <asp:UpdatePanel ID="updPnlUser" runat="server">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 98%; margin: 0 auto;"
                                            class="noPad">
                                            <tr>
                                                <td>
                                                    <table width="100%" style="margin-top: 10px;">
                                                        <tr>
                                                            <td style="width: 30%;">
                                                                <b>Sale ID</b> &nbsp;
                                                                <asp:Label ID="lblpaymentPopSaleID" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%">
                                                                <b>Phone</b> &nbsp;
                                                                <asp:Label ID="lblPayInfoPhone" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnRegName" runat="server" />
                                                                <asp:HiddenField ID="hdnRegLastName" runat="server" />
                                                                <asp:HiddenField ID="hdnRegAddress" runat="server" />
                                                                <asp:HiddenField ID="hdnRegState" runat="server" />
                                                                <asp:HiddenField ID="hdnRegZip" runat="server" />
                                                                <asp:HiddenField ID="hdnRegCity" runat="server" />
                                                            </td>
                                                            <td>
                                                                <b>Email</b> &nbsp;
                                                                <asp:Label ID="lblPayInfoEmail" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPopPayType" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td>
                                                                <b>Voice file confirmation #</b> &nbsp;
                                                                <asp:Label ID="lblPayInfoVoiceConfNo" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 30%">
                                                                <b>Payment date</b> &nbsp;
                                                                <asp:Label ID="lblPoplblPayDate" runat="server"></asp:Label>
                                                            </td>
                                                            <td style="width: 30%">
                                                                <b>Amount</b> &nbsp;
                                                                <asp:Label ID="lblPoplblPayAmount" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hdnPophdnAmount" runat="server" />
                                                            </td>
                                                            <td>
                                                                <b>Package</b> &nbsp;
                                                                <asp:Label ID="lblPoplblPackage" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="trPopPDData" runat="server">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 30%">
                                                                <b>PD Date</b> &nbsp;
                                                                <asp:Label ID="lblPDDateForPop" runat="server"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <b>Amount</b> &nbsp;
                                                                <asp:Label ID="lblPDAmountForPop" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <!-- Credit Card Start  -->
                                                    <div id="divcard" runat="server" style="display: block; height: auto; min-height: auto;
                                                        max-height: auto; margin-bottom: 15px;">
                                                        <!-- 
                                                <table>
                                                    <tr>
                                                        <td style="width:49%;">
                                                            <table>
                                                                
                                                            </table>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                </table>
                                                -->
                                                        <table border="0" cellpadding="4" cellspacing="4" style="width: 99%; margin: 15px 0;
                                                            float: left;">
                                                            <tr>
                                                                <td colspan="5">
                                                                    <h5 style="font-size: 15px; margin: 0; float: left; width: 130px;">
                                                                        <b>Card Details</b></h5>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Card Type</b>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:Label ID="lblCCCardType" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Card Holder First Name</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCardHolderName" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 50px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 80px;">
                                                                    <b>Last Name</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCardHolderLastName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>Credit Card #</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCCNumber" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <b>Expiry Date</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCCExpiryDate" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>CVV#</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCvv" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <b>Address</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBillingAddress" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <b>City</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBillingCity" runat="server"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                                <td colspan="2">
                                                                    <div style="width: 80px; display: inline-block; float: left; margin-right: 10px;">
                                                                        <b>State &nbsp;</b>
                                                                        <asp:Label ID="lblBillingState" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div style="width: 120px; display: inline-block; float: left">
                                                                        <b>ZIP &nbsp;</b>
                                                                        <asp:Label ID="lblBillingZip" runat="server"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <!-- Credit Card End  -->
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                    <!-- check Start  -->
                                                    <div id="divcheck" runat="server" style="display: none; height: auto; min-height: auto;
                                                        max-height: auto">
                                                        <table border="0" cellpadding="4" cellspacing="4" style="width: 99%; margin: 15px 0;
                                                            float: left;">
                                                            <tr>
                                                                <td colspan="5">
                                                                    <h5 style="font-size: 15px; margin: 0; float: left; width: 130px;">
                                                                        <b>Check Details</b></h5>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Account holder name</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblAccHolderName" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 50px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 80px;">
                                                                    <b>Bank name</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblBankName" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Account type</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblAccType" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width: 50px;">
                                                                    &nbsp;
                                                                </td>
                                                                <td style="width: 80px;">
                                                                    <b>Account #</b>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblAccNumber" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Routing #</b>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:Label ID="lblRouting" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <!-- check End  -->
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                    <!-- paypal Start  -->
                                                    <div id="divpaypal" runat="server" style="display: none; height: auto; min-height: auto;
                                                        max-height: auto;">
                                                        <table border="0" cellpadding="4" cellspacing="4" style="width: 99%; margin: 15px  0;
                                                            float: left;">
                                                            <tr>
                                                                <td colspan="5">
                                                                    <h5 style="font-size: 15px; margin: 0; float: left; width: 130px;">
                                                                        <b>Paypal Details</b></h5>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Payment trans ID</b>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:Label ID="lblPaypalTranID" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 140px">
                                                                    <b>Paypal account email</b>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:Label ID="lblPaypalEmail" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="clear">
                                                        &nbsp;</div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 21%;">
                                                                <b>Payment status</b>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPaymentStatus" runat="server" onchange="return PayInfoChanges();">
                                                                    <asp:ListItem Value="1">Pending</asp:ListItem>
                                                                    <asp:ListItem Value="2">Paid</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="divTransID" runat="server" style="display: none;">
                                                    <!-- Credit Card Start  -->
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 21%;">
                                                                <b>Transaction ID</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPaytransID" runat="server" MaxLength="30"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="divPaymentDate" runat="server" style="display: none;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 21%;">
                                                                <b>Payment Date</b>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlPaymentDate" runat="server" CssClass="input1" Style="width: auto">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td id="divPaymentAmount" runat="server" style="display: none;">
                                                    <table style="width: 100%;">
                                                        <tr>
                                                            <td style="width: 21%;">
                                                                <b>Amount</b>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtPaymentAmountInPop" runat="server" MaxLength="6" onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                        <!-- paypal End  -->
                                        <div class="clear">
                                            &nbsp;</div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="updtpnlBtns" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%;">
                                            <tr align="center">
                                                <td colspan="4" style="padding-top: 15px;">
                                                    <div style="width: 440px; margin: 0 auto;">
                                                        <asp:Button ID="btnUpdate" OnClientClick="return ValidateUpdate();" runat="server"
                                                            Text="Update" CssClass="g-button g-button-submit" Style="float: left; margin: 0 10px 0 0;"
                                                            OnClick="btnUpdate_Click" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnCCProcess" runat="server" Text="Process" CssClass="g-button g-button-submit"
                                                            Style="float: left; margin: 0 10px 0 0;" OnClick="btnCCProcess_Click" />
                                                        <asp:Button ID="btnCheckProcess" runat="server" Text="Process" CssClass="g-button g-button-submit"
                                                            Style="float: left; margin: 0 10px 0 0;" OnClick="btnCheckProcess_Click" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnCancelUpdate" CssClass="g-button g-button-submit" runat="server"
                                                            Text="Cancel" OnClientClick="return ClosePopup();" Style="float: left; margin: 0 10px 0 0;" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <div class="clearFix">
                        &nbsp</div>
                </div>
            </div>
        </div>
        <cc1:ModalPopupExtender ID="mdepAlertStatusUpdated" runat="server" PopupControlID="divAlertStatusUpdated"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnStatusUpdated">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnStatusUpdated" runat="server" />
        <div id="divAlertStatusUpdated" class="alert" style="display: none">
            <h4 id="H2">
                Alert
                <%--  <asp:Button ID="btnCBAlertClose" class="cls" runat="server" Text="" BorderWidth="0"
                OnClick="btnCBAlertOK_Click" />--%>
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="data">
                <p>
                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblCBAlertMsg" runat="server" Visible="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </p>
                <asp:Button ID="btnAlertStatusNo" class="btn" runat="server" Text="No" OnClick="btnAlertStatusNo_Click" />
                <asp:Button ID="btnAlertStatusYes" class="btn" runat="server" Text="Yes" OnClick="btnAlertStatusYes_Click" />
            </div>
        </div>
        <cc1:ModalPopupExtender ID="mpealteruserUpdated" runat="server" PopupControlID="AlertUserUpdated"
            BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuserUpdated">
        </cc1:ModalPopupExtender>
        <asp:HiddenField ID="hdnAlertuserUpdated" runat="server" />
        <div id="AlertUserUpdated" class="alert" style="display: none;">
            <h4 id="H3">
                Alert
                <asp:Button ID="BtnClsUpdated" class="cls" runat="server" Text="" BorderWidth="0"
                    OnClick="BtnClsUpdated_Click" />
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="data" style="height: auto;">
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
