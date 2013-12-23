<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgentManagement.aspx.cs"
    Inherits="AgentManagement" %>

<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script src="js/overlibmws.js" type="text/javascript"></script>

    <script src="js/FillMasterData.js" type="text/javascript"></script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
	});
	
	
	   function ShowAddAgent() {  
            
            document.getElementById('<%= txtAddAgentName.ClientID%>').value = "";
            document.getElementById('<%= txtAddFirstName.ClientID%>').value = "";            
            $find('<%= mpeAddNew.ClientID%>').show();
            return false;
        }
        
        function ValidateUpdate(){
        var valid=true;                
           
             if( document.getElementById('<%=txtAgentname.ClientID%>').value.length < 1)
             {
                document.getElementById('<%= txtAgentname.ClientID%>').focus();
                alert("Please enter agent code");
                 document.getElementById('<%=txtAgentname.ClientID%>').value = ""
                document.getElementById('<%=txtAgentname.ClientID%>').focus()
                valid = false; 
                 return valid;              
             } 
               if( document.getElementById('<%=txtFirstName.ClientID%>').value.length < 1)
             {
                document.getElementById('<%= txtFirstName.ClientID%>').focus();
                alert("Please enter full name");
                 document.getElementById('<%=txtFirstName.ClientID%>').value = ""
                document.getElementById('<%=txtFirstName.ClientID%>').focus()
                valid = false; 
                 return valid;              
             } 
             
              return valid;   
             
        }
	    
	    function ValidateAdd()
	    {
	      var valid=true;                
           
             if( document.getElementById('<%=txtAddAgentName.ClientID%>').value.length < 1)
             {
                document.getElementById('<%= txtAddAgentName.ClientID%>').focus();
                alert("Please enter agent code");
                 document.getElementById('<%=txtAddAgentName.ClientID%>').value = ""
                document.getElementById('<%=txtAddAgentName.ClientID%>').focus()
                valid = false; 
                 return valid;              
             } 
               if( document.getElementById('<%=txtAddFirstName.ClientID%>').value.length < 1)
             {
                document.getElementById('<%= txtAddFirstName.ClientID%>').focus();
                alert("Please enter full name");
                 document.getElementById('<%=txtAddFirstName.ClientID%>').value = ""
                document.getElementById('<%=txtAddFirstName.ClientID%>').focus()
                valid = false; 
                 return valid;              
             } 
             
              return valid;   
             
	    
	    }
	    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtpnlRdbtns"
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
            AGENT MANAGEMENT</h1>
        <div class="clear">
            &nbsp;</div>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <div>
            <asp:UpdatePanel ID="updtpnlRdbtns" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:RadioButton ID="rdbtnActive" runat="server" Text="Active" GroupName="AgentStatus"
                                    OnCheckedChanged="rdbtnActive_Click" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rdbtnInactive" runat="server" Text="Inactive" GroupName="AgentStatus"
                                    OnCheckedChanged="rdbtnInactive_Click" AutoPostBack="true" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rdbtnAll" runat="server" Text="All" GroupName="AgentStatus"
                                    Checked="true" OnCheckedChanged="rdbtnAll_Click" AutoPostBack="true" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div align="right" style="width: 530px">
            <asp:LinkButton ForeColor="#BC0101" ID="lnkAddUSer" runat="server" OnClientClick="return ShowAddAgent()"
                CssClass="link" Text="Add Agent"></asp:LinkButton>
            <asp:HiddenField ID="hdnAddnew" runat="server" />
            <cc1:ModalPopupExtender ID="mpeAddNew" runat="server" TargetControlID="hdnAddnew"
                PopupControlID="tblAddNew" CancelControlID="btnCancelAdd" BackgroundCssClass="ModalPopupBG">
            </cc1:ModalPopupExtender>
        </div>
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
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                        <asp:UpdatePanel ID="UpdtpnlHeader" runat="server">
                            <ContentTemplate>
                                <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                    top: 2px; padding-top: 2px; width: 500px; background: #fff;">
                                    <tr class="tbHed">
                                        <td width="150px" align="left">
                                            <asp:LinkButton ID="lnkAgentName" runat="server" Text="Agent Code &#8659" OnClick="lnkAgentName_Click"></asp:LinkButton>
                                        </td>
                                        <td width="150px" align="left">
                                            <asp:LinkButton ID="lnkName" runat="server" Text="Name &darr; &uarr;" OnClick="lnkName_Click"></asp:LinkButton>
                                        </td>
                                        <td width="100px" align="left">
                                            <asp:LinkButton ID="lnkbtnCreateDate" runat="server" Text="Create Date &darr; &uarr;"
                                                OnClick="lnkbtnCreateDate_Click"></asp:LinkButton>
                                        </td>
                                        <td width="100px" align="left">
                                            <asp:LinkButton ID="lnkStatus" runat="server" Text="Status &darr; &uarr;" OnClick="lnkStatus_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="width: 520px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                        border: #ccc 1px solid; height: 400px">
                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                <ContentTemplate>
                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                    <asp:GridView Width="500px" ID="grdUserDetails" runat="server" CellSpacing="0" CellPadding="0"
                                        CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                        OnRowCommand="grdUserDetails_RowCommand">
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
                                                    <asp:LinkButton ID="lnkAgentName" runat="server" Text='<%# Eval("American_Name")%>'
                                                        CommandArgument='<%# Eval("Sale_Agent_Id")%>' CommandName="EditUser"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Agent_Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%# Bind("Created_Date", "{0:MM/dd/yy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status_name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdUserDetails" EventName="Sorting" />
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
    <asp:HiddenField ID="btnOpen" runat="server" />
    <cc1:ModalPopupExtender ID="MPEUpdate" runat="server" PopupControlID="tblUpdate"
        BackgroundCssClass="ModalPopupBG" TargetControlID="btnOpen" CancelControlID="btnCancelUpdate">
    </cc1:ModalPopupExtender>
    <div id="tblUpdate" class="PopUpHolder" style="display: none;">
        <div class="main" style="width: 550px; margin: 60px auto 0 auto;">
            <h4>
                Update Agent Details
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table id="Table2" runat="server" align="center" cellpadding="0" cellspacing="0"
                    style="width: 100%; margin: 0 auto">
                    <tr>
                        <td style="width: 100%;">
                            <asp:UpdatePanel ID="updPnlUser" runat="server">
                                <ContentTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 98%; margin: 0 auto;">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px">
                                                &nbsp; Agent Code<span class="star">*</span>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtAgentname" runat="server" MaxLength="25"></asp:TextBox>
                                            </td>
                                            <td style="width: 50px">
                                                &nbsp;
                                            </td>
                                            <td style="width: 150px">
                                                &nbsp; Full Name<span class="star">*</span>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="25"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Agent Status
                                            </td>
                                            <td valign="top">
                                                <asp:DropDownList ID="ddlUpStatus" CssClass="input1" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <%--&nbsp;Last Name--%>
                                            </td>
                                            <td>
                                                <%--<asp:TextBox ID="txtLastName" CssClass="input1" MaxLength="20" runat="server"></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                        <tr style="height: 10px;">
                                            <td colspan="5">
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 15px;">
                            <div style="width: 190px; margin: 0 auto;">
                                <asp:Button ID="btnAgentUpdate" OnClientClick="return ValidateUpdate();" runat="server"
                                    Text="Update" OnClick="btnUpdate_Click" CssClass="g-button g-button-submit" />
                                <asp:Button ID="btnCancelUpdate" CssClass="g-button g-button-submit" runat="server"
                                    Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clearFix">
                    &nbsp</div>
            </div>
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpelblUerExist" runat="server" PopupControlID="divUerExist"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnlblUerExist" CancelControlID="btnCancel">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnlblUerExist" runat="server" />
    <div id="divUerExist" class="alert" style="display: none;">
        <h4 id="alertHead">
            Alert
            <asp:Button class="cls" ID="btnCancel" runat="server" BorderWidth="0" />
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblUerExist" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button class="btn" ID="btnlblUerExist" runat="server" Text="Ok" OnClick="btnlblUerExist_Click" />
            <div class="clearFix">
            </div>
        </div>
        <div class="clearFix">
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser" CancelControlID="btnclose"
        OkControlID="btnGo">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: none;">
        <h4 id="H1">
            Alert
            <asp:Button ID="btnclose" CssClass="cls" runat="server" BorderWidth="0" />
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnGo" CssClass="btn" runat="server" Text="Ok" />
            <div class="clearFix">
            </div>
        </div>
        <div class="clearFix">
        </div>
    </div>
    <div id="tblAddNew" class="PopUpHolder" style="display: none;">
        <div class="main" style="width: 550px; margin: 60px auto 0 auto;">
            <h4>
                Add Agent Details
                <!-- <div class="cls">
            </div> -->
            </h4>
            <div class="dat" style="padding: 15px 0;">
                <table id="Table1" runat="server" align="center" cellpadding="0" cellspacing="0"
                    style="width: 100%; margin: 0 auto; background-color: White">
                    <tr>
                        <td width="100%" colspan="2" align="center">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 98%; margin: 0 auto">
                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        &nbsp; Agent Code<span class="star">*</span>
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtAddAgentName" runat="server" MaxLength="25"></asp:TextBox>
                                    </td>
                                    <td style="width: 50px">
                                        &nbsp;
                                    </td>
                                    <td style="width: 150px">
                                        &nbsp; Full Name<span class="star">*</span>
                                    </td>
                                    <td style="width: 100px">
                                        <asp:TextBox ID="txtAddFirstName" runat="server" MaxLength="25"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <tr>
                                        <td>
                                            &nbsp;Last Name
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddLastName" CssClass="input1" MaxLength="20" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                        </td>
                                        <td valign="top">
                                        </td>
                                    </tr>
                                </tr>--%>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                        <td colspan="5">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" style="padding-top: 15px;">
                            <div style="width: 190px; margin: 0 auto;">
                                <asp:Button ID="btnAddUser" runat="server" CssClass="g-button g-button-submit" Text="Submit"
                                    OnClientClick="return ValidateAdd();" OnClick="btnAddUser_Click" />
                                <asp:Button ID="btnCancelAdd" CssClass="g-button g-button-submit" runat="server"
                                    Text="Cancel" />
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="clearFix">
                    &nbsp</div>
            </div>
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
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
