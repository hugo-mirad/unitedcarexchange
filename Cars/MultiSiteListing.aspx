<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultiSiteListing.aspx.cs"
    Inherits="MultiSiteListing" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControl/LoginName.ascx" TagName="LoginName" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>..:: United Car Exchange ::..</title>
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">        window.history.forward(1);</script>

    <script type="text/javascript" language="javascript" src="js/jquery-1.7.min.js"></script>

    <script type='text/javascript' src='js/jquery.alphanumeric.pack.js'></script>

    <!--  <script src="js/FillMasterData.js" type="text/javascript"></script>  -->

    <script src="js/jquery.formatCurrency-1.4.0.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
       function ValidateVehicleType1()
        {
         
            var valid=true;                
    
             if(document.getElementById('<%=txtCarID.ClientID%>').value.length == 0 ) 
             {
                document.getElementById('<%= txtCarID.ClientID%>').focus();
                alert("Please enter car id");
                 document.getElementById('<%=txtCarID.ClientID%>').value = ""
                document.getElementById('<%=txtCarID.ClientID%>').focus()
                valid = false; 
                 return valid;              
             }                     
            
        
          }     
    </script>

    <script type='text/javascript'>
	$(function() {
		$('.number').numeric();
		$('.price').formatCurrency();
        $('.mileage').formatCurrency({symbol: ' '});    
        
       
            
        
        // Phone No Formate
        /*
        $("input[@name='phone']").keyup(function() {
		    var curchr = this.value.length;
		    var curval = $(this).val();
		    if (curchr == 3) {
			    $("input[@name='phone']").val("(" + curval + ")" + "-");
		    } else if (curchr == 9) {
			    $("input[@name='phone']").val(curval + "-");
		    }
	    });
	    */	    
	   
	    
	    
	});   
	    
    

    </script>

    <script type="text/javascript" language="javascript">    
         
         function validationDataFirst()
        {
        debugger
                         
            if(document.getElementById("<%=txtUrlForUpload.ClientID%>").value.length<1)
            {                    
            alert("Please enter url");
            document.getElementById("<%=txtUrlForUpload.ClientID%>").focus();
            valid=false;
            return valid;
            } 
            var Lines = document.getElementById("<%=txtUrlForUpload.ClientID%>").value
            var ctrlLines=Lines.split('\n');                    
//            if (ctrlLines.length>50)
//            {
//            alert('More than 50 lines not allowed for search');                     
//            valid=false;
//            return valid;
//            }           
            
            for( var i =0;i<ctrlLines.length ;i++)
            {
              if (ctrlLines[i].trim().length > 0)
              { 
                 var url = ctrlLines[i];
                 var regexp = /^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$/;
                 if(regexp.test(url) == false){
                        alert('Not a valid url(s)')
                        document.getElementById('<%=txtUrlForUpload.ClientID%>').focus()
                        valid=false;
                        return valid;                
                    }                     
              }   
            } 
        }
    </script>

    <script type='text/javascript'>  
      function  sample(){
            $('.price').formatCurrency();
            $('.mileage').formatCurrency({symbol: ' '});               
        }
    
      function  showSpinner(){
            $('#spinner').show();            
        }
        function  hideSpinner(){                   
            $('#spinner').hide();       
        } 
        
        var value = 'http://www.google.in';
       function check_it()
        {
            var url = value;
            var regexp = /^(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$/;
            //alert(regexp.test(url));
            if(regexp.test(url)){
                alert('URL Valid');
               
            }else{
                alert('Not a valid url')
            }
             return true;
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="SM" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="Progress" runat="server" AssociatedUpdatePanelID="UpdtPnlEntercarID"
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
    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdPnlGrid"
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel8"
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
    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel7"
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
            Multi-site listing data uploads</h1>
        <div class="clear">
            &nbsp;</div>
        <table style="width: 100%;">
            <tr>
                <td style="width: 400px; vertical-align: top;">
                    Enter Car ID<br />
                    <asp:UpdatePanel ID="UpdtPnlEntercarID" runat="server">
                        <ContentTemplate>
                            <table cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                                <tr>
                                    <td style="width: 60%;">
                                        <asp:TextBox ID="txtCarID" runat="server" CssClass="input1 number" MaxLength="12"
                                            Style="padding: 5px;"></asp:TextBox>
                                        <%--<input type="text" class="input1" style="padding: 5px;" />--%>
                                    </td>
                                    <td style="width: 15px;">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="btnGoByCarID" runat="server" Text="Go" CssClass="g-button g-button-submit"
                                            OnClick="btnGoByCarID_Click" OnClientClick="return ValidateVehicleType1();" />
                                        <%-- <input type="button" value="Go" class="g-button g-button-submit " />--%>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clear marginTop">
                        &nbsp;</div>
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <div id="divCarIDData" runat="server">
                                <table style="width: 98%;">
                                    <tr>
                                        <td style="width: 45%;">
                                            Listing Details
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                    <asp:Label ID="lblSearchCarIDRes" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                        runat="server"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="upDtPnlListingDetails" runat="server">
                                    <ContentTemplate>
                                        <table style="background: #eee; border: #ccc 1px solid; padding: 10px; width: 100%">
                                            <tr>
                                                <td style="width: 60%">
                                                    Car ID:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblSelCarID" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 60%">
                                                    <b>Ad Status:</b>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAdStatus" runat="server" Style="font-weight: bold; color: Blue;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Listing Date:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Customer Name:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListCustName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Model Year:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListYear" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 15px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Make:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListMake" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Model:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListModel" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Type:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListType" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Mileage:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListMileage" runat="server" CssClass="mileage"></asp:Label>
                                                    <asp:Label ID="lblMi" Text="mi" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Asking Price:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblListPrice" runat="server" CssClass="price"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 15px;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Multisite list update counts:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMultiListUpdateCount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Last Multisite update date:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMultiUpDate" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Last multisite update done by:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblMultiUpBy" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                        <ContentTemplate>
                            <div id="divPendUrl" runat="server">
                                <table style="width: 98%;">
                                    <tr>
                                        <td style="width: 45%;">
                                            Pending URLs
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                <ContentTemplate>
                                                    <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                    <asp:Label ID="lblPendingCount" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                        runat="server"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                        padding-top: 2px; width: 425px; background: #fff;">
                                        <tr class="tbHed">
                                            <td width="50px">
                                                Sno
                                            </td>
                                            <td width="160px">
                                                Name
                                            </td>
                                            <td>
                                                Url
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 150px">
                                    <asp:Panel ID="Panel2" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden3" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden4" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="425px" ID="grdPendSites" runat="server" CellSpacing="0" CellPadding="0"
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
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSiteName" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SiteName"),30)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="160px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSiteUrl" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"SiteUrl"),35)%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdPendSites" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                                <div class="clear marginTop">
                                    &nbsp;</div>
                                <%-- <input type="button" value="Update" class="g-button g-button-submit floatR" />--%>
                                <%--   <asp:Button ID="Button1" runat="server" CssClass="g-button g-button-submit floatR"
                                    Text="Update" OnClick="btnUpdateStatus_Click" />--%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 50px;">
                    &nbsp;
                </td>
                <td style="vertical-align: top; width: 550px">
                    <table style="width: 98%;">
                        <tr>
                            <td style="width: 35%;">
                                Multi-Site Listing
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                        <asp:Label ID="lblRes" Font-Size="12px" Font-Bold="true" ForeColor="Black" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 30%;" align="left">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                        <asp:Label ID="lblRecordsCount" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                            runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                        <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                            padding-top: 2px; width: 525px; background: #fff;">
                            <tr class="tbHed">
                                <td width="60px">
                                    Car ID
                                </td>
                                <td width="50px">
                                    Status
                                </td>
                                <td width="70px">
                                    Posted Dt
                                </td>
                                <td>
                                    Package
                                </td>
                                <td width="70px">
                                    List Count
                                </td>
                                <td width="70px">
                                    Pend Count
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                        border: #ccc 1px solid; height: 170px">
                        <asp:Panel ID="pnl1" Width="100%" runat="server">
                            <asp:UpdatePanel ID="UpdPnlGrid" runat="server">
                                <ContentTemplate>
                                    <input style="width: 91px" id="txthdnSortOrder" type="hidden" runat="server" enableviewstate="true" />
                                    <input style="width: 40px" id="txthdnSortColumnId" type="hidden" runat="server" enableviewstate="true" />
                                    <asp:GridView Width="525px" ID="grdListInfo" runat="server" CellSpacing="0" CellPadding="0"
                                        CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                        OnRowDataBound="grdListInfo_RowDataBound" OnRowCommand="grdListInfo_RowCommand">
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
                                                        CommandName="EditList"></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--  <asp:Label ID="lblStatus" runat="server"></asp:Label>--%>
                                                    <asp:Image ID="ImgStatus" runat="server" />
                                                    <asp:HiddenField ID="hdnStatus" runat="server" Value='<%# Eval("isActive")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="50px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblListDate" runat="server" Text='<%# Bind("dateOfPosting", "{0:MM/dd/yy}") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPackage" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnPackName" runat="server" Value='<%# Eval("Description")%>' />
                                                    <asp:HiddenField ID="hdnPackCost" runat="server" Value='<%# Eval("Price")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUpListCount" runat="server" Text='<%# Eval("UpListCount")%>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPendListCount" runat="server"></asp:Label>
                                                    <asp:HiddenField ID="hdnfUpListCount" runat="server" Value='<%# Eval("UpListCount")%>' />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="70px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="grdListInfo" EventName="Sorting" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </div>
                    <div class="clear" style="height: 30px;">
                        &nbsp;</div>
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <div id="divExistingUrls" runat="server">
                                <table style="width: 98%;">
                                    <tr>
                                        <td style="width: 45%;">
                                            Existing URLs
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <%--Most recent 500 premium customers (or Search Results- Top 500)--%>
                                                    <asp:Label ID="lblExistUrlRes" Font-Size="12px" Font-Bold="true" ForeColor="Black"
                                                        runat="server"></asp:Label>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                                <div style="width: 100%; position: relative; padding: 0 3px; height: 1px">
                                    <table class="grid1" cellpadding="0" cellspacing="0" style="position: absolute; top: 2px;
                                        padding-top: 2px; width: 525px; background: #fff;">
                                        <tr class="tbHed">
                                            <td width="10%">
                                                Sno
                                            </td>
                                            <td>
                                                URL
                                            </td>
                                            <td width="15%">
                                                Status
                                            </td>
                                            <td width="15%">
                                                Posted Dt
                                            </td>
                                            <td width="15%">
                                                Posted By
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: 100%; overflow-y: scroll; overflow-x: hidden; padding: 26px 3px 3px 3px;
                                    border: #ccc 1px solid; height: 150px">
                                    <asp:Panel ID="Panel1" Width="100%" runat="server">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <input style="width: 91px" id="Hidden1" type="hidden" runat="server" enableviewstate="true" />
                                                <input style="width: 40px" id="Hidden2" type="hidden" runat="server" enableviewstate="true" />
                                                <asp:GridView Width="525px" ID="grdExistUrl" runat="server" CellSpacing="0" CellPadding="0"
                                                    CssClass="grid1" AutoGenerateColumns="False" GridLines="None" ShowHeader="false"
                                                    OnRowDataBound="grdExistUrl_RowDataBound">
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
                                                                <%# ((GridViewRow)Container).RowIndex + 1%>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="htlnkURLListed" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),35)%>'
                                                                    NavigateUrl='<%# String.Format("http://{0}", Eval("URL").ToString()) %>' Target="_blank"></asp:HyperLink>
                                                                <asp:HiddenField ID="hdnUrlToNav" runat="server" Value='<%# Eval("URL")%>' />
                                                                <%-- <asp:LinkButton ID="lnkUrlListed" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),35)%>'
                                                                    CommandArgument='<%# Eval("URL")%>' CommandName="OpenLink"></asp:LinkButton>--%>
                                                                <%--<asp:Label ID="lblListDate" runat="server" Text='<%#objGeneralFunc.WrapTextByMaxCharacters(DataBinder.Eval(Container.DataItem,"URL"),35)%>'></asp:Label>--%>
                                                                <asp:HiddenField ID="hdnUrlID" runat="server" Value='<%# Eval("URLID")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkbxUrlStatus" runat="server" />
                                                                <asp:HiddenField ID="hdnUrlStatus" runat="server" Value='<%# Eval("UrlStatus")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUrlPostDt" runat="server" Text='<%# Bind("UrlPostDate", "{0:MM/dd/yy}") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPostedBy" runat="server" Text='<%# objGeneralFunc.WrapTextByMaxCharacters(objGeneralFunc.ToProper(objGeneralFunc.GetSmartzUser(DataBinder.Eval(Container.DataItem,"PostedBy"))),10) %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="grdListInfo" EventName="Sorting" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                                <div class="clear marginTop">
                                    &nbsp;</div>
                                <%-- <input type="button" value="Update" class="g-button g-button-submit floatR" />--%>
                                <asp:Button ID="btnUpdateStatus" runat="server" CssClass="g-button g-button-submit floatR"
                                    Text="Update" OnClick="btnUpdateStatus_Click" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="clear " style="margin-top: 30px;">
                        &nbsp;</div>
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <div id="divNewUrls" runat="server">
                                Enter New URLs (one per line)<br />
                                <%-- <textarea class="textarea" style="height: 90px; margin: 0;"></textarea>--%>
                                <asp:TextBox runat="server" ID="txtUrlForUpload" CssClass="textarea" Style="height: 90px;
                                    margin: 0;" TextMode="MultiLine" MaxLength="3500"></asp:TextBox>
                                <div class="clear marginTop">
                                    &nbsp;</div>
                                <asp:Button ID="btnNewUrlUpdate" runat="server" Text="Update" CssClass="g-button g-button-submit floatR"
                                    OnClientClick="return validationDataFirst();" OnClick="btnNewUrlUpdate_Click" />
                                <%--<input type="button" value="Update" class="g-button g-button-submit floatR" OnClientClick="return validationDataFirst();"/>--%>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div class="clear">
            &nbsp;</div>
        <br />
    </div>
    <cc1:ModalPopupExtender ID="mpealteruser" runat="server" PopupControlID="AlertUser"
        BackgroundCssClass="ModalPopupBG" TargetControlID="hdnAlertuser">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="hdnAlertuser" runat="server" />
    <div id="AlertUser" class="alert" style="display: block; height: auto">
        <h4 id="H1">
            Alert
            <asp:Button ID="BtnCls" class="cls" runat="server" Text="" BorderWidth="0" OnClick="btnYes_Click" />
            <!-- <div class="cls">
            </div> -->
        </h4>
        <div class="data" style="height: auto;">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="updpnlMsgUser1" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblErrSuccess" runat="server" Visible="false"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblErrfailures" runat="server" Visible="false"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnYes" class="btn" runat="server" Text="Ok" OnClick="btnYes_Click" />
        </div>
    </div>
    </form>
</body>
</html>
