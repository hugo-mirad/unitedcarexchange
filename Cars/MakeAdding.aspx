<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MakeAdding.aspx.cs" Inherits="MakeAdding" %>

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

            
            document.getElementById('<%= txtMakeName.ClientID%>').value = "";
           
            $find('<%= mpeAddNew.ClientID%>').show();
            return false;
        }
        
        function ValidateAdd()
        {
             var valid=true;                
           
             if( document.getElementById('<%=txtMakeName.ClientID%>').value.length < 1)
             {
                document.getElementById('<%= txtMakeName.ClientID%>').focus();
                alert("Please enter make");
                 document.getElementById('<%=txtMakeName.ClientID%>').value = ""
                document.getElementById('<%=txtMakeName.ClientID%>').focus()
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
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="updtPnlHeaders"
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
            Adding Make</h1>
        <div class="clear">
            &nbsp;</div>
        <div class="clear" style="height: 10px;">
            &nbsp;</div>
        <div align="right" style="width: 420px">
            <asp:LinkButton ForeColor="#BC0101" ID="lnkAddUSer" runat="server" OnClientClick="return ShowAddAgent()"
                CssClass="link" Text="Add Make"></asp:LinkButton>
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
                        <asp:UpdatePanel ID="updtPnlHeaders" runat="server">
                            <ContentTemplate>
                                <table class="grid1 " cellpadding="0" cellspacing="0" style="position: absolute;
                                    top: 2px; padding-top: 2px; width: 400px; background: #fff;">
                                    <tr class="tbHed">
                                        <td align="left">
                                            <asp:LinkButton ID="lnkbtnMakeID" runat="server" Text="Make Id &darr; &uarr;" OnClick="lnkbtnMakeID_Click"></asp:LinkButton>
                                        </td>
                                        <td width="300px" align="left">
                                            <asp:LinkButton ID="lnkbtnMakeName" runat="server" Text="Make Name &#8659;" OnClick="lnkbtnMakeName_Click"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="width: 420px; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                        border: #ccc 1px solid; height: 430px">
                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                <ContentTemplate>
                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                    <asp:GridView Width="400px" ID="grdUserDetails" runat="server" CellSpacing="0" CellPadding="0"
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
                                                    <asp:Label ID="lblMakeId" runat="server" Text='<%# Eval("makeID") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMakeName" runat="server" Text='<%# Eval("make") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="300px" />
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
            <asp:Button class="btn" ID="btnlblUerExist" runat="server" Text="Ok" />
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
        <div class="main" style="width: 500px; margin: 60px auto 0 auto;">
            <h4>
                Add Make Details
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
                                    <td style="width: 6%; padding: 0">
                                        &nbsp;
                                    </td>
                                    <td style="width: 18%">
                                        Make Name<span class="star">*</span>
                                    </td>
                                    <td style="width: 38%">
                                        <asp:TextBox MaxLength="25" CssClass="input1" ID="txtMakeName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 10px;">
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="padding-top: 15px;">
                            <div style="width: 240px; margin: 0 auto;">
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
    </form>
</body>
</html>
