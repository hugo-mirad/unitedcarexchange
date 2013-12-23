<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IntroMail.aspx.cs" Inherits="IntroMail" %>

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

    <script type="text/javascript" language="javascript">
    
        function Clear1()
        {        
          document.getElementById('<%= txtEmailAddress.ClientID%>').value = "";               
        }   
         function validationDataFirst()
        {
        debugger
            if(document.getElementById("<%=txtEmailAddress.ClientID%>").value.length<1)
            {                    
            alert("Please enter email address to send");
            document.getElementById("<%=txtEmailAddress.ClientID%>").focus();
            valid=false;
            return valid;
            } 
            var Lines = document.getElementById("<%=txtEmailAddress.ClientID%>").value
            var ctrlLines=Lines.split('\n');                    
//            if (ctrlLines.length>50)
//            {
//            alert('More than 50 lines not allowed for search');                     
//            valid=false;
//            return valid;
//            }
            
            if(document.getElementById("<%=txtAgentName.ClientID%>").value.length<1)
            {                    
            alert("Please enter marketing specialist name");
            document.getElementById("<%=txtAgentName.ClientID%>").focus();
            valid=false;
            return valid;
            }
            for( var i =0;i<ctrlLines.length ;i++)
            {
              if ((ctrlLines[i].trim().length > 0) && (echeck(ctrlLines[i].trim()) == false) )
              { 
                document.getElementById('<%=txtEmailAddress.ClientID%>').focus()
                valid=false;
                return valid;                          
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
    
//onKeyDown="return nocopypaste(event)"
//        function nocopypaste(e)
//        {
//        debugger
//            var code = (document.all) ? event.keyCode:e.which;           
//            if (parseInt(code)==17) //CTRL
//            {  
//                return false;                
//                window.event.returnValue = false;
//            }
//        }


    function Formatdata(e)
    {
       debugger
      /* var code = (document.all) ? event.keyCode:e.which;

        var msg = "Sorry, this functionality is disabled.";
        if (parseInt(code)==17) //CTRL
        {
        alert(msg);
        window.event.returnValue = false;
        }
        */
       
       var charCode = (e.which) ? e.which : event.keyCode   
        var ctrl=e.value.split('\n');                    
//        if (ctrl.length>50)
//        {
//            alert('More than 50 lines not allowed');                     
//            return false; 
//        }        
        //        if (charCode != 13)
        //        {
        //            for( var i =0;i<ctrl .length ;i++)
        //            {
        //                if (ctrl[i].trim().length>30)
        //                {
        //                alert('Only 30 characters allowed for each line');
        //                return false;
        //                }
        //                return true;
        //            }       
        //        }
       return true;      
        
    }
    
     function  showSpinner(){
            $('#spinner').show();
        }
        function  hideSpinner(){
            $('#spinner').hide();
        } 
            
       function OnchangeDropdown(){   
            if(document.getElementById('<%=ddlUserType.ClientID%>').value =="2")
            {
               document.getElementById("ddlLanguage").disabled=true;  
               document.getElementById("ddlLanguage").value = 1;      
            } 
            else
            {
               document.getElementById("ddlLanguage").disabled=false;  
            }
  }      
            
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdatePane1BtnRefresh"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdtPnlBtnSend"
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
        <%-- <table style="width: 100%">
            <td>
                <a href="index.aspx">
                    <img src="images/logo2.png" /></a>
            </td>
            <td>
            </td>
            <td>
                <div class="loginStat">
                    Welecome Rajesh.M
                    <br />
                    <a href="index.aspx" class="home">Home</a> &nbsp; | &nbsp; <a href="#">Logout</a></div>
            </td>
        </table>--%>
        <uc1:LoginName ID="LoginName1" runat="server" />
        <div class="clear">
            &nbsp;</div>
    </div>
    <div class="main">
        <h1 class="h1">
            INTRO EMAIL SENDER APPLICATION FOR CARS</h1>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblHeaderText" runat="server" Style="font-weight: bold"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 300px; vertical-align: top;">
                    Customer Email Address(es)<br />
                    <asp:TextBox ID="txtEmailAddress" runat="server" TextMode="MultiLine" CssClass="emailAddress"
                        MaxLength="4000"></asp:TextBox>
                    Language/Mail Type<br />
                    <asp:DropDownList ID="ddlLanguage" runat="server" Width="95%" CssClass="input3">
                        <asp:ListItem Value="1">English</asp:ListItem>
                        <asp:ListItem Value="2">Spanish</asp:ListItem>
                    </asp:DropDownList>
                    User Type<br />
                    <asp:DropDownList ID="ddlUserType" runat="server" Width="95%" CssClass="input3" onchange="return OnchangeDropdown();">
                        <asp:ListItem Value="1">Consumer</asp:ListItem>
                        <asp:ListItem Value="2">Dealer</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <%--<textarea class="emailAddress"></textarea>--%>
                    Marketing Specialist<br />
                    <asp:TextBox ID="txtAgentName" runat="server" CssClass="input1" MaxLength="20"></asp:TextBox>
                    <%-- <input type="text" class="input1" />--%>
                    <div class="clear">
                        &nbsp;</div>
                    <asp:UpdatePanel ID="UpdtPnlBtnSend" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="g-button g-button-submit"
                                OnClick="btnSend_Click" OnClientClick="return validationDataFirst();" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <%--<input type="button" value="Send" class="g-button g-button-submit" />--%>
                </td>
                <td style="width: 50px;">
                    &nbsp;
                </td>
                <td style="vertical-align: top;">
                    Recently sent intro emails (recent 15 days)<br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblRes" Font-Size="12px" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="width: 100%;" id="divresults" runat="server">
                        <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                            <asp:UpdatePanel ID="UpdtpnlHeader" runat="server">
                                <ContentTemplate>
                                    <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                        padding-top: 2px; width: 675px; background: #fff;">
                                        <tr class="tbHed">
                                            <td width="12%">
                                                <asp:LinkButton ID="lnkDateSort" runat="server" Text="Date &#8657" OnClick="lnkDateSort_Click"></asp:LinkButton>
                                                <%-- Date--%>
                                            </td>
                                            <td width="11%">
                                                Time
                                            </td>
                                            <td width="20%">
                                                <asp:LinkButton ID="lnkMarketSpecialist" runat="server" Text="Market Specialist &darr; &uarr;"
                                                    OnClick="lnkMarketSpecialist_Click"></asp:LinkButton>
                                                <%-- Market Specialist--%>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkCustomerEmail" runat="server" Text="Customer Email &darr; &uarr;"
                                                    OnClick="lnkCustomerEmail_Click"></asp:LinkButton>
                                                <%-- Customer Email--%>
                                            </td>
                                            <td width="12%">
                                                <asp:LinkButton ID="lnkLanguage" runat="server" Text="Language &darr; &uarr;" OnClick="lnkLanguage_Click"></asp:LinkButton>
                                                <%-- Customer Email--%>
                                            </td>
                                            <td width="10%">
                                                <asp:LinkButton ID="lnkStatus" runat="server" Text="Status &darr; &uarr;" OnClick="lnkStatus_Click"></asp:LinkButton>
                                                <%--Status--%>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                            border: #ccc 1px solid; height: 180px">
                            <asp:Panel ID="pnl1" Width="100%" runat="server">
                                <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                    <ContentTemplate>
                                        <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                        <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                        <asp:GridView Width="675px" ID="grdIntroInfo" runat="server" CellSpacing="0" CellPadding="0"
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
                                                        <asp:Label ID="lblMailDate" runat="server" Text='<%# Bind("SentDateTime", "{0:MM/dd/yyyy}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMailTime" runat="server" Text='<%# Bind("SentDateTime", "{0:t}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="11%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAgentName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"MarketSpecialist"),16)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"CustomerEmail"),35)%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLanguage" runat="server" Text='<%# Eval("Language")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("StatusName")%>'></asp:Label>
                                                        <%--<asp:Label ID="lblReverDt" runat="server"></asp:Label>
                                            <asp:Label ID="lblReverBy" runat="server"></asp:Label>--%>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
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
                        <asp:UpdatePanel ID="UpdatePane1BtnRefresh" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="g-button g-button-submit"
                                    OnClick="btnRefresh_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%--<input type="button" value="Refresh" class="g-button g-button-submit" />--%>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <%--  <div class="footer">
        United Car Exchange © 2012</div>--%>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: block">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnYes_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data">
            <p>
                <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblErr" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </p>
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" OnClick="btnYes_Click" />
        </div>
    </div>
    <cc1:ModalPopupExtender ID="mdepAskUserType" runat="server" PopupControlID="divAskUserType"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAskUserType">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAskUserType" runat="server" />
    <div id="divAskUserType" class="alert" style="display: none">
        <h4 id="H2">
            Select User Type
            <%--<asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnNo_Click" />--%>
            <!-- <div class="cls"> </div> -->
        </h4>
        <div class="data">
            <br />
            <asp:RadioButton ID="rdbtnCarsSingleUser" runat="server" Text="Single User" CssClass="noLM"
                GroupName="PmntStatus" Checked="true" />
            <asp:RadioButton ID="rdbtnCarsDealer" runat="server" Text="Cars Dealer" CssClass="noLM"
                GroupName="PmntStatus" />
            &nbsp;
            <asp:Button ID="btnOK" class="btn" runat="server" Text="Ok" OnClick="btnOK_Click" />
        </div>
    </div>
    </form>
</body>
</html>
