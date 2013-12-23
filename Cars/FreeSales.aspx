<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FreeSales.aspx.cs" Inherits="FreeSales" %>

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
            Free Package Customer Data</h1>
        <div class="clear">
            &nbsp;</div>
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
                                                <asp:LinkButton ID="lnkPostedSort" runat="server" Text="Posted Dt &#8657" OnClick="lnkPostedSort_Click"></asp:LinkButton>
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
                                                        <asp:Label ID="lblPostedDt" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
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
